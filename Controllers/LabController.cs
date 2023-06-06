using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RCSP.Models;
using RCSP.Storage;

namespace RCSP.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private IStorage<LabData> _memCache;

        public LabController(IStorage<LabData> memCache)
        {
            _memCache = memCache;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LabData>> Get()
        {
            return Ok(_memCache.All);
        }

        [HttpGet("{id}")]
        public ActionResult<LabData> Get(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            return Ok(_memCache[id]);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LabData value)
        {
            var validationResult = value;

            _memCache.Add(value);

            return Ok($"{value.ToString()} has been added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] LabData value)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            var validationResult = value;

            var previousValue = _memCache[id];
            _memCache[id] = value;

            return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_memCache.Has(id)) return NotFound("No such");

            var valueToRemove = _memCache[id];
            _memCache.RemoveAt(id);

            return Ok($"{valueToRemove.ToString()} has been removed");
        }
    }
}