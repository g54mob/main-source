using UnityEngine;

namespace DV.Customization
{
	public class GadgetColliderHolderEnabler : MonoBehaviour
	{
		public GadgetColliderHolder mainClass;

		private void OnEnable()
		{
			CustomizationPlacementMeshes.StartPlacingEvent += OnStartPlacing;
			if (CustomizationPlacementMeshes.ShouldBePlacing)
			{
				OnStartPlacing();
			}
		}

		private void OnDisable()
		{
			CustomizationPlacementMeshes.StartPlacingEvent -= OnStartPlacing;
		}

		private void OnStartPlacing()
		{
			if ((bool)mainClass)
			{
				mainClass.enabled = true;
			}
		}
	}
}
