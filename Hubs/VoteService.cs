using System;
using System.Collections.Generic;
using SignalRChat.Models;

namespace SignalRChat.Services
{
    public class VoteService
    {
        private List<VoteModel> voteModelList;
        private int i = 0;
        public VoteService()
        {
            voteModelList = new List<VoteModel>();
            CreateTestVote();
        }
        // 建立測試用投票
        public void CreateTestVote(){
            VoteModel voteModel = new VoteModel();
            voteModel.id = 1;
            voteModel.voteName = "Test Vote";
            voteModel.creator = "me";
            voteModel.startDate = DateTime.Now;
            string[] voteSelect = { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };
            Dictionary<string, int> _voteSelect = new Dictionary<string, int>();
            for (int i = 0; i < voteSelect.Length; i++)
            {
                _voteSelect.Add(voteSelect[i], 0);
            }
            voteModel.voteSelect = _voteSelect;
            voteModelList.Add(voteModel);

        }

        // 取得投票Model
        public VoteModel GetVoteModel(string voteName)
        {
            for (int i = 0; i < voteModelList.Count; i++)
            {
                if (voteModelList[i].voteName == voteName)
                {
                    return voteModelList[i];
                }
            }

            return new VoteModel();
        }

        // 建立新的投票
        public void CreateVote(VoteModel voteModel)
        {
            i++;
            voteModel.id = i;
            voteModelList.Add(voteModel);
        }

        // 新增投票選項
        public void AddVoteSelect(string voteName, string selectName)
        {
            for (int i = 0; i < voteModelList.Count; i++)
            {
                if (voteModelList[i].voteName == voteName)
                {
                    voteModelList[i].voteSelect.Add(selectName, 0);
                }
            }
        }
        // 投票
        public void AddVoteSelectCount(string voteName, string selectName)
        {
            foreach (var voteModel in voteModelList)
            {
                if (voteModel.voteName == voteName)
                {
                    foreach (var voteSelect in voteModel.voteSelect)
                    {
                        if (voteSelect.Key == selectName)
                        {
                            voteModel.voteSelect[selectName] = voteSelect.Value + 1;
                            break;
                        }
                    }
                }
            }
        }

        // 反對票
        public void SubVoteSelectCount(string voteName, string selectName)
        {
            foreach (var voteModel in voteModelList)
            {
                if (voteModel.voteName == voteName)
                {
                    foreach (var voteSelect in voteModel.voteSelect)
                    {
                        if (voteSelect.Key == selectName)
                        {
                            voteModel.voteSelect[selectName] = voteSelect.Value - 1;
                            break;

                        }
                    }
                }
            }
        }
    }
}