using RootMotion.FinalIK;

namespace RootMotion.Demos
{
	public class UserControlInteractions : UserControlThirdPerson
	{
		public CharacterThirdPerson character;

		public InteractionSystem interactionSystem;

		public bool disableInputInInteraction;

		public float enableInputAtProgress;

		protected override void Update()
		{
		}

		private void OnGUI()
		{
		}
	}
}
