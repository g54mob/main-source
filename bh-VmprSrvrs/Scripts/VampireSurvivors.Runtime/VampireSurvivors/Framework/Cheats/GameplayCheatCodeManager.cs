using Zenject;

namespace VampireSurvivors.Framework.Cheats
{
	public class GameplayCheatCodeManager : CheatCodeManager
	{
		private GameManager _gameManager;

		private bool _hasPetTheGoodDoggy;

		[Inject]
		private void Construct(GameManager gameManager)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void CheckForControllerPet()
		{
		}

		protected override void AddCheatCodeCombos()
		{
		}

		private void PraiseTheGoodDoggy()
		{
		}

		private void UnlockHumbug()
		{
		}
	}
}
