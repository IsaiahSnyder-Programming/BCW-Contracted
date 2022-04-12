using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Contracted.Services;
using Contracted.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contracted.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly ContractorsService _cs;

        public ContractorsController(ContractorsService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<Contractor>> GetAll()
        {
            try
            {
                List<Contractor> contractors = _cs.GetAll();
                return Ok(contractors);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Contractor> GetById(int id)
        {
            try
            {
                Contractor contractors = _cs.GetById(id);
                return Ok(contractors);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Contractor>> Create([FromBody] Contractor contractorData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                contractorData.creatorId = userInfo.Id;
                Contractor contractor = _cs.Create(contractorData);
                contractor.Creator = userInfo;
                return Created($"api/contractors/{contractor.Id}", contractor);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> Remove(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_cs.Remove(id, userInfo));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Contractor> Update(int id, [FromBody] Contractor contractorData)
        {
            try
            {
                contractorData.Id = id;
                Contractor contractor = _cs.Update(contractorData);
                return Ok(contractor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}