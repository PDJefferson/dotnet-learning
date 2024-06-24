
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_learning.Controllers
{

    // used to serve api controller auto routing and http status codes
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {



        private static List<Character> characters = new List<Character> {
            new Character (),
            new Character { Id = 1, Name = "Sam" }
        };


        // to return http status code with the response with get request
        // [HttpGet] not needed since the method name matches with the request type
        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            return Ok(characters);
        }

        [HttpGet]
        public ActionResult<Character> GetSingle()
        {
            return Ok(characters[0]);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> getById(int id)
        {
            return Ok(characters.FirstOrDefault(character => character.Id == id));

        }


        [HttpPost]
        public ActionResult<List<Character>> add(Character character)
        {
            characters.Add(
                new Character
                {
                    Id = characters.Count + 1,
                    Name = character.Name,
                    HitPoints = character.HitPoints,
                    Strength = character.Strength,
                    Defense = character.Defense,
                    Intelligence = character.Intelligence,
                    Class = character.Class
                }
            );
            return Accepted(characters);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Character>> delete(int id)
        {

            var character = characters.FirstOrDefault(character => character.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            characters.Remove(character);

            return Ok(characters);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Character>> update(int id, Character character)
        {


            if (character == null)
            {
                return BadRequest();
            }

            var characterToChange = characters.FirstOrDefault(character => character.Id == id);

            if (characterToChange == null)
            {
                return NotFound();
            }


            character.Name = character.Name;
            character.HitPoints = character.HitPoints;
            character.Strength = character.Strength;
            character.Defense = character.Defense;
            character.Intelligence = character.Intelligence;
            character.Class = character.Class;


            // to change the old character
            characters[characters.IndexOf(characterToChange)] = character;

            return Ok(characters);



        }


    }

}