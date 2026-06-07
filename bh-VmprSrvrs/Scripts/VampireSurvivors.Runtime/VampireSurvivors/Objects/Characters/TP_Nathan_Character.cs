using Coherence.Toolkit;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Nathan_Character : TP_Character
	{
		private bool _ArcanaGiven5mins;

		private bool _ArcanaGiven10mins;

		public override void AfterFullInitialization()
		{
		}

		protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		protected override void OnUpdate()
		{
		}

		private void OpenArcana()
		{
		}

		[Command]
		public void OpenArcana(long startingSimFrame)
		{
		}
	}
}
