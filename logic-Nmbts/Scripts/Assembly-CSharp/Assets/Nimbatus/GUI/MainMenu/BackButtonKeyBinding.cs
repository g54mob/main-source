using Assets.Nimbatus.GUI.MainMenu.Scripts;

namespace Assets.Nimbatus.GUI.MainMenu
{
	public class BackButtonKeyBinding : UIKeyBinding
	{
		public EMainMenuPage ActivePage;

		protected override void Update()
		{
			if (MainMenuNavigator.CurrentPage == ActivePage)
			{
				base.Update();
			}
		}
	}
}
