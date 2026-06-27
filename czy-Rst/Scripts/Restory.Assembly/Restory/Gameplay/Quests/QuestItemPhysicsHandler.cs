using Restory.Constants;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Quests
{
	public class QuestItemPhysicsHandler : ElementPhysicsHandler
	{
		[SerializeField]
		private Vector3 questElementDropPosition;

		public override void TogglePhysics(bool enable)
		{
			if (enable)
			{
				base.transform.parent.position = questElementDropPosition;
			}
			base.TogglePhysics(enable);
		}

		protected override void ResetElementLayer()
		{
			base.gameObject.layer = ProjectConstants.Layers.Obstacles;
		}
	}
}
