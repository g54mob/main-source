using DV.CabControls;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class BrakeCylinderReleaseButtonFeeder : MonoBehaviour
	{
		private BrakeSystem bs;

		private ButtonBase brakeCylinderReleaseButton;

		private void Start()
		{
			bs = TrainCar.Resolve(base.transform)?.brakeSystem;
			if (bs == null)
			{
				Debug.LogError("Unexpected state: Couldn't extract BrakeSystem from BrakeCylinderReleaseButtonFeeder. Destroying self", base.gameObject);
				Object.Destroy(this);
				return;
			}
			brakeCylinderReleaseButton = base.gameObject.GetComponent<ButtonBase>();
			if (brakeCylinderReleaseButton == null)
			{
				Debug.LogError("Unexpected state: Can't find ButtonBase on " + base.gameObject.name + ". Destroying self", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				brakeCylinderReleaseButton.Used += OnBrakeCylinderButtonPressed;
			}
		}

		private void OnDestroy()
		{
			if (brakeCylinderReleaseButton != null)
			{
				brakeCylinderReleaseButton.Used -= OnBrakeCylinderButtonPressed;
			}
		}

		private void OnBrakeCylinderButtonPressed()
		{
			bs.ReleaseBrakeCylinderPressure();
		}
	}
}
