using Simulator.GameWorld;

namespace Simulator
{
	public class ReserveBroom : GroundFurniture
	{
		public void TakeBroom()
		{
			Tutorial.TryShow(TutorialSettings.Cleaning);
		}

		public override bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}
	}
}
