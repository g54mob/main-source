using NSEipix.Base;
using NSMedieval;
using NSMedieval.BuildingComponents;
using NSMedieval.EnvironmentEffects;
using UnityEngine;

namespace Effects
{
	public class BlueprintPlacedEffect : MonoBehaviour
	{
		[SerializeField]
		private BaseBuildingViewComponent baseBuildingViewComponent;

		public BaseBuildingViewComponent BaseBuildingViewComponent => baseBuildingViewComponent;

		public float Progress { get; set; }

		public void PlacedAnimationFinished()
		{
			baseBuildingViewComponent.PlayParticlesOnBlueprintPlaced();
			if (baseBuildingViewComponent.GetAsWorldObject() != null && baseBuildingViewComponent.GetAsWorldObject().OwnedByPlayer())
			{
				MonoSingleton<CameraManager>.Instance.OnCameraShakeEvent(base.transform.position, CameraShakeStrength.Blueprint);
			}
		}
	}
}
