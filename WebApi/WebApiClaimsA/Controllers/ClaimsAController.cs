﻿using AutoMapper;
using DomainModel;
using DomainModel.ClaimsA.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ResourceModel.Api;
using ResourceModel.Authentication;
using ResourceModel.ClaimsA.Create;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiClaimsA.Repository;

namespace WebApiClaimsA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClaimsAController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClaimsAController> _logger;
        private readonly IClaimsRepository _claimsRepository;

        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ClaimsAController(IMapper mapper, ILogger<ClaimsAController> logger, IClaimsRepository claimsRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _claimsRepository = claimsRepository;
        }

        [Authorize]
        [HttpGet("GetClaimsCountAsync")]
        public async Task<Int64> GetClaimsCountAsync(Int64 userId)
        {
            Int64 claimsACount = 0;

            claimsACount = await this._claimsRepository.GetClaimsCountAsync(userId);

            return claimsACount;
        }

        [Authorize]
        [HttpGet("GetOpenClaimIdAsync")]
        public async Task<Int64> GetOpenClaimIdAsync(Int64 userId)
        {
            Int64? claimAId = 0;
            claimAId = await this._claimsRepository.GetOpenClaimIdAsync(userId);

            if (claimAId == null)
            {
                claimAId = 0;
            }

            return claimAId.Value;
        }

        [Authorize]
        [HttpPost("CreateClaimAAsync")]
        public async Task<Int64> CreateClaimAAsync(CreateClaimsAResModel createClaimsA)
        {
            Int64 claimAItemid = 0;
            ClaimAItemModel claimAItem = new ClaimAItemModel();

            claimAItem = this._mapper.Map<ClaimAItemModel>(createClaimsA);
            claimAItem.ClaimType = 1;

            claimAItemid = await this._claimsRepository.CreateClaimAAsync(claimAItem);

            return claimAItemid;
        }
    }
}