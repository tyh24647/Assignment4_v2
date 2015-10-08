using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Assignment4_v2.Models;
using System.Net;

namespace Assignment4_v2.Controllers {


    [Route("api/[controller]")]
    public class StarWarsController : Controller {

        private const int MAX_LIST_ENTRIES = 30;

        private static CharacterModel startingCharacter = new CharacterModel() {
            FirstName = "Test",
            Character = "Yoda"
        };

        private static NumTimesModel startingNumTimes = new NumTimesModel() {
            FirstName = "NumTimesName",
            NumberOfTimes = "35"
        };

        private static List<CharacterModel> characters = new List<CharacterModel>() { startingCharacter };


        private static List<NumTimesModel> numTimesList = new List<NumTimesModel>() { startingNumTimes };
        

        // Ensures that both lists do not have more than 30 entries
        private void ValidateModelSizes() {
            if (characters.Count >= MAX_LIST_ENTRIES) {
                characters = new List<CharacterModel>() { startingCharacter };
            }

            if (numTimesList.Count >= MAX_LIST_ENTRIES) {
                numTimesList = new List<NumTimesModel>() { startingNumTimes };
            }
        }


        // GET: api/StarWars
        [HttpGet]
        public IEnumerable<CharacterModel> Get() {
            return characters;
        }


        // GET: api/StarWars/5
        [HttpGet("{id}")]
        public CharacterModel Get(int id) {
            if (id < 0 || id >= characters.Count) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new CharacterModel();
            }

            return characters[id];
        }


        // PUT: api/StarWars/5
        [HttpPut("{id}")]
        public NumTimesModel Put(int id, [FromBody]NumTimesModel numTimes) {
            if (!ModelState.IsValid || id < 0 || id >= numTimesList.Count) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new NumTimesModel();
            }

            numTimesList = new List<NumTimesModel>() {
                numTimes
            };

            return numTimes;
        }


        // POST: api/StarWars
        [HttpPost]
        public CharacterModel Post([FromBody]CharacterModel character) {
            if (!ModelState.IsValid) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new CharacterModel();
            }

            characters.Add(character);
            ValidateModelSizes();
            return character;
        }


        // PATCH: api/StarWars/5
        [HttpPatch("{id}")]
        public NumTimesModel Patch(int id, [FromBody]NumTimesModel numTimes) {
            if (!ModelState.IsValid || id < 0 || id >= numTimesList.Count) {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new NumTimesModel();
            }

            numTimesList.Add(numTimes);
            ValidateModelSizes();
            return numTimes;
        }


        // GET: /
        [HttpGet]
        [Route("/")]
        public CharacterModel GetCharacter() {
            return new CharacterModel() {
                FirstName = "Tyler",
                Character = "Anybody except Jar-Jar"
            };
        }


    }
}
