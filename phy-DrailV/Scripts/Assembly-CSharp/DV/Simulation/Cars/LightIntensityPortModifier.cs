using DV.Simulation.Controllers;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class LightIntensityPortModifier : ASimInitializedController
	{
		private class LightData
		{
			public readonly Light light;

			public readonly float maxIntensity;

			public LightData(Light light, float maxIntensity)
			{
				this.light = light;
				this.maxIntensity = maxIntensity;
			}
		}

		private static readonly int glareBrightnessHash = Shader.PropertyToID("_Brightness");

		[PortId(PortValueType.STATE, false)]
		public string lightIntensityModifierPortId;

		[Header("Intensity modifier port value mapping")]
		public float inMapMin;

		public float inMapMax = 1f;

		public float outMapMin;

		public float outMapMax = 1f;

		[Header("optional")]
		public CabLightsController cabLightsController;

		private HeadlightBeamController beamController;

		private HeadlightsMainController headlightsMainController;

		private Port lightIntensityModifierPort;

		private LightData[] lightSources;

		private MaterialPropertyBlock glareBrightnessPropertyBlock;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(lightIntensityModifierPortId, out lightIntensityModifierPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: LightIntensityPortModifier isn't initialized properly! Destroying self");
				Object.Destroy(this);
				return;
			}
			headlightsMainController = GetComponent<HeadlightsMainController>();
			if (headlightsMainController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: LightIntensityPortModifier isn't initialized properly! Destroying self");
				Object.Destroy(this);
				return;
			}
			int num = ((cabLightsController != null) ? cabLightsController.lights.Length : 0);
			lightSources = new LightData[headlightsMainController.allLightSources.Count + num];
			int num2 = 0;
			foreach (Light allLightSource in headlightsMainController.allLightSources)
			{
				lightSources[num2++] = new LightData(allLightSource, allLightSource.intensity);
			}
			if (cabLightsController != null)
			{
				GameObject[] lights = cabLightsController.lights;
				for (int i = 0; i < lights.Length; i++)
				{
					Light component = lights[i].GetComponent<Light>();
					if (component == null)
					{
						Debug.LogError("[" + base.gameObject.GetPath() + "]: Missing Light on cabLightsController");
					}
					else
					{
						lightSources[num2++] = new LightData(component, component.intensity);
					}
				}
			}
			beamController = GetComponent<HeadlightBeamController>();
			if (headlightsMainController.allGlareRenderers.Count > 0)
			{
				glareBrightnessPropertyBlock = new MaterialPropertyBlock();
			}
			OnLightIntensityModifierChanged(lightIntensityModifierPort.Value);
			lightIntensityModifierPort.ValueUpdatedInternally += OnLightIntensityModifierChanged;
		}

		private void OnLightIntensityModifierChanged(float lightIntensityModifier)
		{
			float num = NumberUtil.MapClamp(lightIntensityModifier, inMapMin, inMapMax, outMapMin, outMapMax);
			LightData[] array = lightSources;
			foreach (LightData lightData in array)
			{
				lightData.light.intensity = lightData.maxIntensity * num;
			}
			if (beamController != null)
			{
				beamController.intensityMultiplier = num;
			}
			if (glareBrightnessPropertyBlock == null)
			{
				return;
			}
			glareBrightnessPropertyBlock.SetFloat(glareBrightnessHash, num);
			foreach (Renderer allGlareRenderer in headlightsMainController.allGlareRenderers)
			{
				allGlareRenderer.SetPropertyBlock(glareBrightnessPropertyBlock);
			}
		}
	}
}
