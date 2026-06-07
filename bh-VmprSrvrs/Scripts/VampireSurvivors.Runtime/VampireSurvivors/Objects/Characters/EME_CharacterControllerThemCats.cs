using System.Collections.Generic;

namespace VampireSurvivors.Objects.Characters
{
	public class EME_CharacterControllerThemCats : EME_CharacterControllerShowstopper
	{
		private int _followers;

		private List<CharacterController> _catFollowers;

		public override bool NeedsCart => false;

		protected override void OnShowStopperStarted()
		{
		}

		public override void AfterFullInitialization()
		{
		}
	}
}
