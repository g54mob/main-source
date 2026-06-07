using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial.TutorialScenes;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class FailTutorial : NimbatusAction
	{
		public override void Execute()
		{
			GenericTutorialLogic instance = GenericTutorialLogic.Instance;
			if (instance != null)
			{
				instance.IsTargetDestroyed = true;
				instance.IsDroneDead = true;
				RuntimeGlobals.IsGameOver = true;
			}
		}
	}
}
