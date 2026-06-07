using UI.Elements;
using UnityEngine;

namespace UI.Apps
{
	public class MainMenuApp : MultiToolApp
	{
		[SerializeField]
		private UIButton gadgetButton;

		[SerializeField]
		private UIButton createGadgetButton;

		[SerializeField]
		private UIButton gadgetBrowserButton;

		[SerializeField]
		private UIButton learnButton;

		[SerializeField]
		private UIButton creditsButton;

		[SerializeField]
		private UIButton discordButton;

		[SerializeField]
		private UIButton twitterButton;

		[SerializeField]
		private UIButton redditButton;

		public UIButton playMusicButton;

		public UIButton openFolderButton;

		public UIButton settingsButton;

		public UIButton powerButton;

		private UIButton[] buttons;

		private bool musicOn;

		public bool isDeskEmpty => false;

		public override void Init()
		{
		}

		private void CreateGadget()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public override void OnSetGadget(Gadget gadget)
		{
		}

		public override bool NeedGadget()
		{
			return false;
		}

		private void OpenDiscord()
		{
		}

		private void OnOpenDiscordConfirm(bool confirm)
		{
		}

		private void OpenTwitter()
		{
		}

		private void OnOpenTwitterConfirm(bool confirm)
		{
		}

		private void OpenReddit()
		{
		}

		private void OnOpenRedditConfirm(bool confirm)
		{
		}

		private void StopMusic()
		{
		}

		private void PlayMusic()
		{
		}

		private void TurnMusicOnOff()
		{
		}

		private void OpenFolder()
		{
		}

		private void OpenFolderConfirm(bool confirm)
		{
		}

		private void PowerOff()
		{
		}

		private void PowerOffCOnfirm(bool confirm)
		{
		}
	}
}
