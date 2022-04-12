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
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _cs;

        public CompaniesController(CompaniesService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<Company>> GetAll()
        {
            try
            {
                List<Company> companies = _cs.GetAll();
                return Ok(companies);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetById(int id)
        {
            try
            {
                Company companies = _cs.GetById(id);
                return Ok(companies);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Company>> Create([FromBody] Company companyData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                companyData.creatorId = userInfo.Id;
                Company company = _cs.Create(companyData);
                company.Creator = userInfo;
                return Created($"api/companies/{company.Id}", company);
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
        public ActionResult<Company> Update(int id, [FromBody] Company companyData)
        {
            try
            {
                companyData.Id = id;
                Company company = _cs.Update(companyData);
                return Ok(company);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}