﻿using FoxIDs.Client.Logic;
using FoxIDs.Models.Api;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoxIDs.Client.Services
{
    public class ExternalUserService : BaseService
    {
        private const string apiUri = "api/{tenant}/{track}/!externaluser";
        private const string filterApiUri = "api/{tenant}/{track}/!filterexternaluser";

        public ExternalUserService(IHttpClientFactory httpClientFactory, RouteBindingLogic routeBindingLogic, TrackSelectedLogic trackSelectedLogic) : base(httpClientFactory, routeBindingLogic, trackSelectedLogic)
        { }

        public async Task<IEnumerable<ExternalUser>> FilterExternalUserAsync(string filterValue) => await FilterAsync<ExternalUser>(filterApiUri, filterValue, parmName1: nameof(filterValue));

        public async Task<ExternalUser> GetExternalUserAsync(string upPartyName, string linkClaim) => await GetAsync<ExternalUserId, ExternalUser>(apiUri, new ExternalUserId { UpPartyName = upPartyName, LinkClaimValue = linkClaim });
        public async Task<ExternalUser> CreateExternalUserAsync(ExternalUserRequest externalUser) => await PostResponseAsync<ExternalUserRequest, ExternalUser>(apiUri, externalUser);
        public async Task<ExternalUser> UpdateExternalUserAsync(ExternalUserRequest user) => await PutResponseAsync<ExternalUserRequest, ExternalUser>(apiUri, user);
        public async Task DeleteExternalUserAsync(string upPartyName, string linkClaim) => await DeleteAsync(apiUri, new ExternalUserId { UpPartyName = upPartyName, LinkClaimValue = linkClaim });
    }
}
