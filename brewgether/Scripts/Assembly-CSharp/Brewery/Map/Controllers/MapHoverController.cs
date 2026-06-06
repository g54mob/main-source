using UnityEngine;

namespace Brewery.Map.Controllers
{
	public class MapHoverController
	{
		private readonly Camera camera;

		private readonly MapCameraSettings settings;

		private readonly float maxHoverDistance;

		private IMapIconHoverProvider currentHoverProvider;

		private GameObject currentHoveredObject;

		private MapIcon currentHoveredIcon;

		private const float RESET_HOLD_DURATION = 1f;

		private bool isHoldingForReset;

		private float resetHoldStartTime;

		private VehicleHoverProvider currentResetTarget;

		public MapHoverController(Camera camera, MapCameraSettings settings, float maxHoverDistance)
		{
		}

		public void UpdateHoverDetection()
		{
		}

		public void UpdateVehicleResetHold()
		{
		}

		public void HideHoverTooltip()
		{
		}

		public void CancelResetHold()
		{
		}

		private void ShowResetProgressUI(string vehicleName)
		{
		}

		private void UpdateResetProgressUI(float progress)
		{
		}

		private void RequestVehicleReset(VehicleHoverProvider vehicleProvider)
		{
		}
	}
}
