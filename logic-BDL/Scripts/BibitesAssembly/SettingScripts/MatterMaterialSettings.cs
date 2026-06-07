using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SimulationScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SettingScripts
{
	public class MatterMaterialSettings : ISaveable
	{
		public readonly MatterMaterial mat;

		public readonly UnityEvent onPhysicalParametersChange = new UnityEvent();

		public readonly FloatSetting cohesiveness = new FloatSetting
		{
			Name = "Cohesiveness",
			HelperText = "Cohesiveness determines how hard the material holds together and the strength necessary to tear off a piece or break through it.",
			minValue = 0f,
			maxValue = 1000f,
			precision = 1,
			units = " N/u",
			SI = false
		};

		public readonly FloatSetting reactivity = new FloatSetting
		{
			Name = "Base Reactivity",
			HelperText = "Determines the speed at which the material can be created/consumed/transformed, or the availability of its energetic content.",
			minValue = 0f,
			maxValue = 10f,
			precision = 2,
			units = "u/s"
		};

		public readonly FloatSetting energyDensity = new FloatSetting
		{
			Name = "Energy Density",
			HelperText = "Determines the amount of energy per square unit of matter. A higher value means the same amount of material contains more energy.",
			minValue = 0.01f,
			maxValue = 100f,
			precision = 1,
			units = "E/u²"
		};

		public readonly FloatSetting massDensity = new FloatSetting
		{
			Name = "Mass Density",
			HelperText = "Determines the mass per square unit of matter. A higher value means the same amount of material weighs more.",
			minValue = 0.001f,
			maxValue = 1f,
			precision = 1,
			factor = 1000f,
			units = "g/u²"
		};

		public readonly FloatSetting maxEfficiency = new FloatSetting
		{
			Name = "Max Conversion Efficiency",
			HelperText = "Determines the maximum efficiency when digesting with maximum affinity (ex: carnivore eating meat).",
			minValue = -1f,
			maxValue = 1f,
			precision = 1,
			factor = 100f,
			units = "%",
			SI = false
		};

		public readonly FloatSetting minEfficiency = new FloatSetting
		{
			Name = "Min Conversion Efficiency",
			HelperText = "Determines the minimum efficiency when digesting with worst affinity (ex: carnivore eating plant).",
			minValue = -1f,
			maxValue = 1f,
			precision = 1,
			factor = 100f,
			units = "%",
			SI = false
		};

		public readonly BoolSetting decay = new BoolSetting
		{
			Name = "Decay",
			HelperText = "Will this matter gradually decay over time?"
		};

		public readonly FloatSetting freshTime = new FloatSetting
		{
			Name = "Freshness Time",
			HelperText = "Determines how long it will take before this type of matter stops being fresh and starts decaying.",
			minValue = 0f,
			maxValue = 3600f,
			precision = 1,
			units = "s",
			SI = false
		};

		public readonly FloatSetting decayRate = new FloatSetting
		{
			Name = "Decay Rate",
			HelperText = "When it's not fresh anymore and starts decaying, at what speed \"eggCollision\": {\n\t\t\"Value\": true\n\t},will this material decay?",
			minValue = 0.001f,
			maxValue = 100f,
			precision = 1,
			units = "u²/s"
		};

		public List<IForceUpdateSetting> settings;

		public string Name => mat.Name + "Settings";

		public Sprite defaultSprite => mat.defaultSprite;

		public MatterMaterialSettings(MatterMaterial mat)
		{
			this.mat = mat;
			cohesiveness.SetDefaultAndValue(mat.Cohesiveness);
			reactivity.SetDefaultAndValue(mat.Reactivity);
			energyDensity.SetDefaultAndValue(mat.EnergyDensity);
			massDensity.SetDefaultAndValue(mat.MassDensity);
			maxEfficiency.SetDefaultAndValue(mat.MaxConversionEfficiency);
			minEfficiency.SetDefaultAndValue(mat.MinConversionEfficiency);
			decay.SetDefaultAndValue(mat.decay);
			freshTime.SetDefaultAndValue(mat.freshTime);
			decayRate.SetDefaultAndValue(mat.decayRate);
			settings = new List<IForceUpdateSetting> { cohesiveness, reactivity, energyDensity, massDensity, maxEfficiency, minEfficiency, decay, freshTime, decayRate };
			cohesiveness.Subscribe(delegate(float arg0)
			{
				this.mat.Cohesiveness = arg0;
			});
			reactivity.Subscribe(delegate(float arg0)
			{
				this.mat.Reactivity = arg0;
			});
			energyDensity.Subscribe(delegate(float arg0)
			{
				this.mat.EnergyDensity = arg0;
			});
			massDensity.Subscribe(delegate(float arg0)
			{
				this.mat.MassDensity = arg0;
			});
			maxEfficiency.Subscribe(delegate(float arg0)
			{
				this.mat.MaxConversionEfficiency = arg0;
			});
			minEfficiency.Subscribe(delegate(float arg0)
			{
				this.mat.MinConversionEfficiency = arg0;
			});
			decay.Subscribe(delegate(bool arg0)
			{
				this.mat.decay = arg0;
			});
			freshTime.Subscribe(delegate(float arg0)
			{
				this.mat.freshTime = arg0;
			});
			decayRate.Subscribe(delegate(float arg0)
			{
				this.mat.decayRate = arg0;
			});
			cohesiveness.Subscribe(onPhysicalParametersChange.Invoke);
			reactivity.Subscribe(onPhysicalParametersChange.Invoke);
			energyDensity.Subscribe(onPhysicalParametersChange.Invoke);
			massDensity.Subscribe(onPhysicalParametersChange.Invoke);
		}

		public void UpdateMaterial()
		{
			mat.Cohesiveness = cohesiveness.val;
			mat.Reactivity = reactivity.val;
			mat.EnergyDensity = energyDensity.val;
			mat.MassDensity = massDensity.val;
			mat.MinConversionEfficiency = minEfficiency.val;
			mat.MaxConversionEfficiency = maxEfficiency.val;
			mat.decay = decay.val;
			mat.freshTime = freshTime.val;
			mat.decayRate = decayRate.val;
		}

		public void ResetSettingsFromMaterial(bool forceUpdate = true)
		{
			cohesiveness.val = mat.Cohesiveness;
			reactivity.val = mat.Reactivity;
			energyDensity.val = mat.EnergyDensity;
			massDensity.val = mat.MassDensity;
			minEfficiency.val = mat.MinConversionEfficiency;
			maxEfficiency.val = mat.MaxConversionEfficiency;
			decay.val = mat.decay;
			freshTime.val = mat.freshTime;
			decayRate.val = mat.decayRate;
			if (forceUpdate)
			{
				settings.ForEach(delegate(IForceUpdateSetting s)
				{
					s.ForceUpdate();
				});
			}
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			jObject["cohesiveness"] = cohesiveness.val;
			jObject["reactivity"] = reactivity.val;
			jObject["energyDensity"] = energyDensity.val;
			jObject["massDensity"] = massDensity.val;
			jObject["minEfficiency"] = minEfficiency.val;
			jObject["maxEfficiency"] = maxEfficiency.val;
			jObject["decay"] = decay.val;
			if (decay.val)
			{
				jObject["freshTime"] = freshTime.val;
				jObject["decayRate"] = decayRate.val;
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			reactivity.val = state["reactivity"]?.ToObject<float>() ?? state["digestionRate"].ToObject<float>();
			if (state["cohesiveness"] != null)
			{
				cohesiveness.val = state["cohesiveness"].ToObject<float>();
			}
			energyDensity.val = state["energyDensity"].ToObject<float>();
			massDensity.val = state["massDensity"].ToObject<float>();
			minEfficiency.val = state["minEfficiency"].ToObject<float>();
			maxEfficiency.val = state["maxEfficiency"].ToObject<float>();
			if (state["decay"] == null)
			{
				return;
			}
			decay.val = state["decay"].ToObject<bool>();
			if (decay.val)
			{
				if (state["freshTime"] != null)
				{
					freshTime.val = state["freshTime"].ToObject<float>();
				}
				else
				{
					freshTime.val = 600f / Mathf.Pow(6f, state["perishableFactor"].ToObject<float>());
				}
				decayRate.val = state["decayRate"].ToObject<float>();
			}
		}
	}
}
