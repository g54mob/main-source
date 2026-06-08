using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(fileName = "Theme Unlock", menuName = "Kitchen/Unlock/Theme Unlock", order = 3)]
	public class ThemeUnlock : Unlock
	{
		public bool IsPrimary = true;

		public DecorationType Type;

		public ThemeUnlock ParentTheme1;

		public ThemeUnlock ParentTheme2;

		protected override void InitialiseDefaults()
		{
			CardType = CardType.ThemeUnlock;
		}

		public override void SetupForGame()
		{
			base.SetupForGame();
			UnlockGroup = (IsPrimary ? UnlockGroup.PrimaryTheme : UnlockGroup.SecondaryTheme);
			if (ParentTheme1 != null)
			{
				Requires.Add(ParentTheme1);
			}
			if (ParentTheme1 != null)
			{
				Requires.Add(ParentTheme2);
			}
		}
	}
}
