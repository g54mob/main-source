using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;
using VLB;

namespace DV.Simulation.Cars
{
	public class HeadlightBeamController : VolumetricBeamControllerBase
	{
		[SerializeField]
		private HeadlightsMainController headlightsMainController;

		private HeadlightsMainController.HeadlightSetup currentSetupFront = new HeadlightsMainController.HeadlightSetup(offSetup: false);

		private HeadlightsMainController.HeadlightSetup currentSetupRear = new HeadlightsMainController.HeadlightSetup(offSetup: true);

		public float intensityMultiplier = 1f;

		private void Awake()
		{
			if (headlightsMainController == null)
			{
				headlightsMainController = GetComponent<HeadlightsMainController>();
				if (headlightsMainController == null)
				{
					Debug.LogError("HeadlightBeamController is missing a HeadlightsMainController reference. Destroying self.");
					Object.Destroy(this);
					return;
				}
			}
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				headlightsMainController.HeadlightSetupChanged += OnHeadlightsSetupChanged;
			}
			else
			{
				headlightsMainController.HeadlightSetupChanged -= OnHeadlightsSetupChanged;
			}
		}

		private void OnHeadlightsSetupChanged(HeadlightsMainController.HeadlightSetup newSetup, HeadlightsMainController.HeadlightSetup oldSetup, bool front)
		{
			if (front)
			{
				currentSetupFront = newSetup;
			}
			else
			{
				currentSetupRear = newSetup;
			}
			ToggleActive(currentSetupFront.setting != HeadlightsMainController.HeadlightSetting.Off || currentSetupRear.setting != HeadlightsMainController.HeadlightSetting.Off);
		}

		private void Update()
		{
			UpdateHeadlightSetup(currentSetupFront);
			UpdateHeadlightSetup(currentSetupRear);
		}

		private void UpdateHeadlightSetup(HeadlightsMainController.HeadlightSetup setup)
		{
			HeadlightsSubControllerBase[] subControllers = setup.subControllers;
			foreach (HeadlightsSubControllerBase headlightsSubControllerBase in subControllers)
			{
				if (headlightsSubControllerBase == null)
				{
					continue;
				}
				Headlight[] headlights = headlightsSubControllerBase.headlights;
				foreach (Headlight headlight in headlights)
				{
					if (!(headlight == null) && headlight.BeamsOn)
					{
						VolumetricBeamData beamData = headlight.beamData;
						VolumetricLightBeam beam = beamData.beam;
						if (!(beam == null))
						{
							float volumetricness = SingletonBehaviour<WeatherDriver>.Instance.GetVolumetricness(beam.transform.position);
							volumetricness *= intensityMultiplier;
							float intensityOutside = Mathf.Lerp(0f, beamData.intensityOutsideMax, volumetricness);
							float intensityInside = Mathf.Lerp(0f, beamData.intensityInsideMax, volumetricness);
							beamData.beam.intensityOutside = intensityOutside;
							beamData.beam.intensityInside = intensityInside;
						}
					}
				}
			}
		}

		public override void ToggleActive(bool on)
		{
			shouldBeActive = on;
			if (base.enabled != on)
			{
				if (!shouldBeActive || headlightsMainController.HeadlightsBroken)
				{
					base.enabled = false;
					return;
				}
				bool flag = !currentSetupFront.mainOffSetup && currentSetupFront.setting != HeadlightsMainController.HeadlightSetting.Off;
				bool flag2 = !currentSetupRear.mainOffSetup && currentSetupRear.setting != HeadlightsMainController.HeadlightSetting.Off;
				base.enabled = flag || flag2;
			}
		}
	}
}
