using System.Collections.Generic;

namespace App.Data
{
	public class Startup : BaseUnlockedData
	{
		public int testRunsInStartup;

		public int patches;

		public float timeInStartup;

		public string AnalyticsKeyName;

		public bool TutorialStartup;

		public string TaskType;

		public int GenerateBatch;

		public string Texts = "";

		public string TaskKeyName;

		public string AudienceType;

		public int LeaveBorder;

		public float LeaveCoef;

		public int InterestCoef;

		public int CallBorder;

		public float CallUserCoef;

		public float RewardCoef;

		public float RewardChanceCoef;

		public float StartAudienceCoef;

		public int RewardChanceBorder;

		public float DayTime;

		public int ChanceScore;

		public int MinQuest;

		public int MaxQuest;

		public int BaseMoney;

		public int dayMail;

		public string OverloadInfluence;

		public string UsersInfluence;

		public string MoneyInfluence;

		public int SharesCou;

		public int ShareCost;

		public int MinShares;

		public int PlayersShares;

		public float ShareSellCoef;

		public string ReqBlock;

		public List<UnlockGroup> ReqBlockGroups = new List<UnlockGroup>();

		public void ParseBlockQuests()
		{
			ReqBlockGroups = Logic.ParseReqGroups(ReqBlock);
		}

		public Startup()
		{
		}

		public Startup(Startup st)
		{
			Texts = st.Texts;
			KeyName = st.KeyName;
			TaskKeyName = st.TaskKeyName;
			AudienceType = st.AudienceType;
			LeaveBorder = st.LeaveBorder;
			LeaveCoef = st.LeaveCoef;
			InterestCoef = st.InterestCoef;
			CallBorder = st.CallBorder;
			GenerateBatch = st.GenerateBatch;
			CallUserCoef = st.CallUserCoef;
			RewardCoef = st.RewardCoef;
			RewardChanceCoef = st.RewardChanceCoef;
			StartAudienceCoef = st.StartAudienceCoef;
			RewardChanceBorder = st.RewardChanceBorder;
			DayTime = st.DayTime;
			ChanceScore = st.ChanceScore;
			MinQuest = st.MinQuest;
			MaxQuest = st.MaxQuest;
			BaseMoney = st.BaseMoney;
			OverloadInfluence = st.OverloadInfluence;
			UsersInfluence = st.UsersInfluence;
			MoneyInfluence = st.MoneyInfluence;
			AnalyticsKeyName = st.AnalyticsKeyName;
			dayMail = st.dayMail;
			SharesCou = st.SharesCou;
			MinShares = st.MinShares;
			ShareCost = st.ShareCost;
			BaseMoney = st.BaseMoney;
			PlayersShares = st.PlayersShares;
			ShareSellCoef = st.ShareSellCoef;
			TutorialStartup = st.TutorialStartup;
		}
	}
}
