using NSEipix;
using NSEipix.Base;
using NSMedieval.Animation;
using NSMedieval.BuildingComponents;
using NSMedieval.State;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class BackgammonEntertainmentGoal : EntertainmentBaseGoal
	{
		public BackgammonEntertainmentGoal(Agent selfAgent)
			: base("BackgammonEntertainmentGoal", selfAgent)
		{
		}

		protected override void SetupUsePosition(EntertainmentComponentInstance entertainmentComponentInstance, HumanoidInstance humanoid)
		{
			EntertainmentComponent component = map.EntertainmentComponentManager.GetComponent(entertainmentComponentInstance);
			if (component == null)
			{
				return;
			}
			Transform useTransform = component.BuildingUsePositionsComponent.GetUsePositionTransform(reservablePosition.Position);
			if (!(useTransform == null))
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					humanoid.FaceObject(useTransform);
				});
				overrideBoneAnimation = base.AgentOwner.GetTransform().GetComponent<OverrideBoneAnimation>();
				overrideBoneAnimation.OverridePosition = component.ChairSitPositions[useTransform];
				overrideBoneAnimation.StartOverrideAnimation();
				if (Vector3.Distance(humanoid.GetPosition(), useTransform.position) > 0.2f)
				{
					humanoid.PathDriver.Teleport(useTransform.position);
				}
			}
		}
	}
}
