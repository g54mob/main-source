using DV.Damage;
using DV.VFX;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class CabLightsController : APoweredControlHandler
	{
		public Material lightsLit;

		public Material lightsUnlit;

		public GameObject[] lights;

		public Renderer[] lightRenderers;

		public float lightsOnControlThreshold = 0.5f;

		public float damagedThresholdPercentage = 0.8f;

		private bool isOn;

		private BodyDamageDetector damageDetector;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			base.Init(car, simFlow);
			if (lights.Length == 0 && (float)lightRenderers.Length == 0f)
			{
				Debug.LogError("Unexpected state: lights and lightRenderers are not set. Destroying self");
				Object.Destroy(this);
				return;
			}
			GameObject[] array = lights;
			foreach (GameObject gameObject in array)
			{
				if (gameObject.TryGetComponent<ItemLight>(out var _))
				{
					Debug.Log("Found existing ItemLight, is this expected?");
				}
				else
				{
					gameObject.AddComponent<ItemLight>().light = gameObject.GetComponent<Light>();
				}
			}
			if (car.TryGetComponent<DamageController>(out var component2))
			{
				damageDetector = new BodyDamageDetector(damagedThresholdPercentage, component2);
				damageDetector.DamagedStateChanged += OnCabLightsDamagedStateChanged;
				UpdateLightState();
			}
			else
			{
				Debug.LogError("Unexpected state: Couldn't find dmgController in CabLightsController. CabLights can't be damaged");
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (damageDetector != null)
			{
				damageDetector.DamagedStateChanged -= OnCabLightsDamagedStateChanged;
				damageDetector.OnDestroy();
			}
		}

		private void OnCabLightsDamagedStateChanged(bool isDamaged)
		{
			UpdateLightState();
		}

		protected override void OnControlChanged(float controlValue)
		{
			UpdateLightState();
		}

		protected override void OnFuseChanged(bool state)
		{
			UpdateLightState();
		}

		private void UpdateLightState()
		{
			if ((powerFuse != null && !powerFuse.State) || (damageDetector != null && damageDetector.IsDamaged))
			{
				if (isOn)
				{
					isOn = false;
					UpdateLights(isOn);
				}
			}
			else
			{
				isOn = controlPort.Value > lightsOnControlThreshold;
				UpdateLights(isOn);
			}
			void UpdateLights(bool set)
			{
				GameObject[] array = lights;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(set);
				}
				Renderer[] array2 = lightRenderers;
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i].sharedMaterial = (isOn ? lightsLit : lightsUnlit);
				}
			}
		}
	}
}
