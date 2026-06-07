using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class PriorityTrait : ActorTrait
	{
		public const int PriorityChange = 20;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected PriorityTrait()
		{
		}

		public PriorityTrait(Actor owner)
		{
		}

		private static void OnAIComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private static void OnAIComponentRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private static void ChangeJobPriorities(Actor actor, int priorityChange)
		{
		}
	}
}
