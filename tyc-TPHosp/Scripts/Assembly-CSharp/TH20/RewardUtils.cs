using System.Linq;
using System.Text;

namespace TH20
{
	public static class RewardUtils
	{
		public static string GetFullRewardString(Objective objective, IReward[] rewards, string delimiter = "\n")
		{
			if (rewards == null || rewards.Length == 0)
			{
				return string.Empty;
			}
			int num = 0;
			int num2 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < rewards.Length; i++)
			{
				if (!rewards[i].Description(objective).IsNullOrEmpty())
				{
					num2++;
				}
			}
			for (int j = 0; j < rewards.Length; j++)
			{
				string value = rewards[j].Description(objective);
				if (!value.IsNullOrEmpty())
				{
					num++;
					stringBuilder.Append(value);
					if (num < num2)
					{
						stringBuilder.Append(delimiter);
					}
				}
			}
			return stringBuilder.ToString();
		}

		public static void GiveAllRewards(Objective objective, IReward[] rewards, Metagame metagame, Character character = null)
		{
			if (rewards == null)
			{
				return;
			}
			foreach (IReward reward in rewards)
			{
				IRewardCharacter rewardCharacter = reward as IRewardCharacter;
				if (reward is IRewardMetagame rewardMetagame)
				{
					rewardMetagame.Apply(metagame);
				}
				else if (rewardCharacter != null)
				{
					rewardCharacter.Apply(character);
				}
				else
				{
					reward.Apply(objective, metagame.CurrentLevel);
				}
			}
		}

		public static void GiveAllRewards(IRewardCharacter[] rewards, Character character)
		{
			if (rewards != null)
			{
				for (int i = 0; i < rewards.Length; i++)
				{
					rewards[i].Apply(character);
				}
			}
		}

		public static void GiveAllRewards(IRewardMetagame[] rewards, Metagame metagame)
		{
			if (rewards != null)
			{
				for (int i = 0; i < rewards.Length; i++)
				{
					rewards[i].Apply(metagame);
				}
			}
		}

		public static int GetMoneyValue(IReward[] rewards)
		{
			return rewards?.OfType<RewardMoney>().Sum((RewardMoney reward) => reward.Amount) ?? 0;
		}

		public static int GetSilverValue(IReward[] rewards)
		{
			return rewards?.OfType<RewardSilver>().Sum((RewardSilver reward) => reward.Amount) ?? 0;
		}

		public static float GetReputationValue(IReward[] rewards)
		{
			return rewards?.OfType<RewardReputation>().Sum((RewardReputation reward) => reward.Amount) ?? 0;
		}
	}
}
