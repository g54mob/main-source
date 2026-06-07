namespace App.Data
{
	public class AlgoProject
	{
		public State State;

		public string Title;

		public string Type;

		public string Description;

		public string ShortDesc;

		public string TextWin;

		public string TextLose;

		public int MinTier;

		public int Reward;

		public int MaxTier;

		public int Accuracy;

		public int WithoutCritMoney;

		public int WithBlockMoney;

		public int WithoutCritServers;

		public int WithBlockServers;

		public string Components;

		public string CriticalComponents;

		public string BlockComponents;

		public string KeyName;

		public AlgoProject(AlgoProject p)
		{
			if (p != null)
			{
				State = p.State;
				Title = p.Title;
				Type = p.Type;
				Description = p.Description;
				ShortDesc = p.ShortDesc;
				TextWin = p.TextWin;
				TextLose = p.TextLose;
				MinTier = p.MinTier;
				Reward = p.Reward;
				MaxTier = p.MaxTier;
				Accuracy = p.Accuracy;
				WithoutCritMoney = p.WithoutCritMoney;
				WithBlockMoney = p.WithBlockMoney;
				WithoutCritServers = p.WithoutCritServers;
				WithBlockServers = p.WithBlockServers;
				Components = p.Components;
				CriticalComponents = p.CriticalComponents;
				BlockComponents = p.BlockComponents;
				KeyName = p.KeyName;
			}
		}
	}
}
