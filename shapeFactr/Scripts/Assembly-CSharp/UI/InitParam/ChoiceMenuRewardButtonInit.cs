namespace UI.InitParam
{
	public class ChoiceMenuRewardButtonInit : ChoiceMenuButtonInitBase
	{
		public readonly int MinionNum;

		public readonly int RewardNum;

		public ChoiceMenuRewardButtonInit(string name, string desc, int rewardNum, string icon, int minionNum)
			: base(null, null, null)
		{
		}
	}
}
