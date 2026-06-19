using UnityEngine;

namespace TH20
{
	public class MetagameStateCollaborativeTransitionInFromLevel : MetagameState
	{
		public MetagameStateCollaborativeTransitionInFromLevel(MetagameMap map)
			: base(map)
		{
		}

		public override void Update()
		{
			CameraGentleSwayComponent orAddComponent = MetagameMap.CameraLogic.CameraComponent.gameObject.GetOrAddComponent<CameraGentleSwayComponent>();
			orAddComponent.CameraSwayAmplitude = new Vector2(3f, 3f);
			orAddComponent.CameraSwayFrequency = new Vector2(0.41f, 0.73f);
			MetagameMap.CameraLogic.SetFixedTransform(MetagameMap.DefaultCollaborativeModeCameraTransform);
			PopState();
		}
	}
}
