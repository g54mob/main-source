using System;
using System.Collections.Generic;
using NWH.VehiclePhysics2.Sound.SoundComponents;
using UnityEngine;
using UnityEngine.Audio;

namespace NWH.VehiclePhysics2.Sound
{
	[Serializable]
	public class SoundManager : ManagerVehicleComponent
	{
		[Tooltip("    Sound of engine idling.")]
		public EngineRunningComponent engineRunningComponent = new EngineRunningComponent();

		[Tooltip("    Engine start / stop component. First clip is for starting and second one is for stopping.")]
		public EngineStartStopComponent engineStartStopComponent = new EngineStartStopComponent();

		[Tooltip("Sound of the engine cooling fan. Can also be used to add additional sound layers to the engine instead.")]
		public EngineFanComponent engineFanComponent = new EngineFanComponent();

		[Tooltip("Sound of the engine popping on throttle release.")]
		public ExhaustPopComponent exhaustPopComponent = new ExhaustPopComponent();

		[Tooltip("    Sound from changing gears. Supports multiple clips.")]
		public GearChangeComponent gearChangeComponent = new GearChangeComponent();

		[Tooltip("    Transmission whine from straight cut gears or just a noisy gearbox.")]
		public TransmissionWhineComponent transmissionWhineComponent = new TransmissionWhineComponent();

		[Tooltip("    Sound of turbo's wastegate. Supports multiple clips.")]
		public TurboFlutterComponent turboFlutterComponent = new TurboFlutterComponent();

		[Tooltip("Forced induction whistle component. Can be used for air intake noise or supercharger if spool up time is set to 0 under engine settings.")]
		public TurboWhistleComponent turboWhistleComponent = new TurboWhistleComponent();

		[Tooltip("    Sound produced by wheel skidding over a surface. Tire squeal.")]
		public WheelSkidComponent wheelSkidComponent = new WheelSkidComponent();

		[Tooltip("    Sound produced by wheel rolling over a surface. Tire hum.")]
		public WheelTireNoiseComponent wheelTireNoiseComponent = new WheelTireNoiseComponent();

		[Tooltip("    Sound from wheels hitting ground and/or obstracles. Supports multiple clips.")]
		public SuspensionBumpComponent suspensionBumpComponent = new SuspensionBumpComponent();

		[Tooltip("    Optional custom mixer. If left empty default will be used (VehicleAudioMixer in Resources folder).")]
		public AudioMixer mixer;

		[Tooltip("    GameObject containing all the engine audio sources.")]
		public GameObject engineSourceGO;

		[Tooltip("    GameObject containing all the exhaust audio sources.")]
		public GameObject exhaustSourceGO;

		[Tooltip("    GameObject containing all transmission audio sources.")]
		public GameObject transmissionSourceGO;

		[Range(0f, 2f)]
		[Tooltip("    Master volume of a vehicle. To adjust volume of all vehicles or their components check audio mixer.")]
		public float masterVolume = 1f;

		protected override void FillComponentList()
		{
			_components = new List<VehicleComponent>
			{
				engineStartStopComponent, engineRunningComponent, engineFanComponent, exhaustPopComponent, turboWhistleComponent, turboFlutterComponent, transmissionWhineComponent, gearChangeComponent, wheelSkidComponent, wheelTireNoiseComponent,
				suspensionBumpComponent
			};
		}

		public override bool VC_Enable(bool calledByParent)
		{
			if (base.VC_Enable(calledByParent))
			{
				return true;
			}
			return false;
		}

		public override bool VC_Disable(bool calledByParent)
		{
			if (base.VC_Disable(calledByParent))
			{
				return true;
			}
			return false;
		}

		protected override void VC_Initialize()
		{
			CreateSourceGO("EngineAudioSources", vehicleController.enginePosition, vehicleController.transform, ref engineSourceGO);
			CreateSourceGO("TransmissionAudioSources", vehicleController.transmissionPosition, vehicleController.transform, ref transmissionSourceGO);
			base.VC_Initialize();
		}

		public override void VC_SetDefaults()
		{
			base.VC_SetDefaults();
			if (mixer == null)
			{
				Debug.LogWarning("VehicleAudioMixer resource could not be loaded from resources.");
			}
		}

		public void CreateSourceGO(string name, Vector3 localPosition, Transform parent, ref GameObject sourceGO)
		{
			sourceGO = new GameObject();
			sourceGO.name = name;
			sourceGO.transform.SetParent(parent);
			sourceGO.transform.localPosition = localPosition;
		}

		public void RegisterExternalSoundComponent(SoundComponent component)
		{
			component.VC_SetVehicleController(vehicleController);
			component.VC_LoadStateFromStateSettings();
			component.UpdateLOD();
			_components.Add(component);
		}
	}
}
