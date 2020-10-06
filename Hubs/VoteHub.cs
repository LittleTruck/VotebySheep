using System;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Models;
using SignalRChat.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SignalRChat.Hubs
{
    public class VoteHub : Hub
    {
        private VoteService _voteService;
        public VoteHub(VoteService voteService)
        {
            _voteService = voteService;
        }

        public async Task GetVote(string voteName)
        {
            await Clients.Caller.SendAsync("ReceiveVote", _voteService.GetVoteModel(voteName));
        }

        public async Task AddVoteSelectCount(string voteName, string voteSelect)
        {
            _voteService.AddVoteSelectCount(voteName, voteSelect);

            var temp =  _voteService.GetVoteModel(voteName);
            int count = 0;
            foreach (var _voteSelect in temp.voteSelect)
            {
                if (_voteSelect.Key == voteSelect)
                {
                    count = _voteSelect.Value;
                }
            } 

            await Clients.All.SendAsync("ReceiveVoteSelectCount", count, voteSelect);
        }
        public async Task SubVoteSelectCount(string voteName, string voteSelect)
        {
            _voteService.SubVoteSelectCount(voteName, voteSelect);

            var temp =  _voteService.GetVoteModel(voteName);
            int count = 0;
            foreach (var _voteSelect in temp.voteSelect)
            {
                if (_voteSelect.Key == voteSelect)
                {
                    count = _voteSelect.Value;
                }
            } 

            await Clients.All.SendAsync("ReceiveVoteSelectCount", count, voteSelect);
        }
    }
}