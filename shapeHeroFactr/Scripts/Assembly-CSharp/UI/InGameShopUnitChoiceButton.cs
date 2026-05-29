namespace UI
{
	public class InGameShopUnitChoiceButton : UnitUnlockRewardChoiceButton
	{
		public override void InitComponent(string archiveId, string iconPath, string name, string desc)
		{
		}

		protected override bool IsUnlock(PlayUnlockData unlockData)
		{
			return false;
		}

		public new void OnMouseOver()
		{
		}

		public new void OnMouseExit()
		{
		}
	}
}
