using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SimulationScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SettingScripts
{
	public class ZoneSettings : ISaveable
	{
		public static int maxID;

		public int zoneID;

		public StringSimulationSetting zoneName = new StringSimulationSetting
		{
			Name = "Name"
		};

		public readonly MatterMaterialSetting spawnMaterial = new MatterMaterialSetting
		{
			Name = "Spawn Pellet of Type",
			HelperText = "What type of pellets should be spawned",
			DefaultValue = MatterMaterialManager.Plant,
			val = MatterMaterialManager.Plant,
			labelForNoTarget = "None"
		};

		public readonly ChoiceSetting<SpawnDistribution> distribution = new ChoiceSetting<SpawnDistribution>
		{
			Name = "Spawn distribution",
			HelperText = "How the zone spawns pellets",
			DefaultValue = SpawnDistribution.CentricGradual,
			val = SpawnDistribution.CentricGradual,
			choices = distributionChoices
		};

		public readonly FloatSetting biomassDensity = new FloatSetting
		{
			Name = "Biomass ",
			precision = 2,
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.001f,
			maxValue = 100f,
			HelperText = " This defines how fertile the zone is compared to the global biomass density setting.\nA higher value means that this zone will be more fertile than the average Zones.",
			units = "x",
			SI = false
		};

		public readonly FloatSetting fertility = new FloatSetting
		{
			Name = "Fertility",
			precision = 2,
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.001f,
			maxValue = 100f,
			HelperText = " This defines how fertile the zone is compared to the global fertility setting.\nA higher value means that this zone will be more fertile than the average Zones.",
			units = "x",
			SI = false
		};

		public readonly FloatSetting pelletSize = new FloatSetting
		{
			Name = "Pellet Size",
			precision = 2,
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.01f,
			maxValue = 50f,
			HelperText = "This sets the average size of pellets spawned by this zone in relation to the global Setting",
			units = "x",
			SI = false
		};

		public readonly BoolSetting renewBiomass = new BoolSetting
		{
			Name = "Renew Biomass",
			DefaultValue = false,
			val = false,
			HelperText = "If enabled, the zone will continuously spawn new pellets even after reaching its max biomass instead of stopping spawning. In order to do so, it will automatically recycle older pellets."
		};

		public readonly ChoiceSetting<MovementType> movement = new ChoiceSetting<MovementType>
		{
			Name = "Movement",
			HelperText = "How the zone moves.",
			DefaultValue = MovementType.None,
			val = MovementType.None,
			choices = movementChoices
		};

		public readonly TargetZoneSetting target = new TargetZoneSetting
		{
			Name = "Target",
			HelperText = "The zone this zone will target (Follow). If no target is given, the zone will not move."
		};

		public readonly FloatSetting speed = new FloatSetting
		{
			Name = "Speed Factor",
			precision = 2,
			val = 1f,
			DefaultValue = 1f,
			minValue = 0.001f,
			maxValue = 1000f,
			HelperText = "The factor speed at which the zones will move around compared to the global speed parameter."
		};

		public FloatSetting posX = new FloatSetting
		{
			Name = "Pos X",
			precision = 3,
			val = 0f,
			DefaultValue = 0f,
			minValue = -1f,
			maxValue = 1f,
			SI = false,
			canGoOutOfBounds = false
		};

		public FloatSetting posY = new FloatSetting
		{
			Name = "Pos Y",
			precision = 3,
			val = 0f,
			DefaultValue = 0f,
			minValue = -1f,
			maxValue = 1f,
			SI = false,
			canGoOutOfBounds = false
		};

		public readonly BoolSetting sizeScalesWithSim = new BoolSetting
		{
			Name = "Size scales with sim",
			HelperText = "Should the size of the zone scale as the simulation size increases?",
			val = true,
			DefaultValue = true
		};

		public readonly FloatSetting radiusRelative = new FloatSetting
		{
			Name = "Radius",
			HelperText = "Radius of the zone, as a multiple of the Simulation Size.",
			precision = 3,
			val = 0.25f,
			DefaultValue = 0.25f,
			minValue = 0f,
			maxValue = 1f,
			SI = false,
			units = "x",
			canGoOutOfBounds = false
		};

		public readonly FloatSetting radiusAbsolute = new FloatSetting
		{
			Name = "Radius",
			HelperText = "Radius of the zone, will not change when changing sim size.",
			precision = 2,
			val = 1000f,
			DefaultValue = 1000f,
			minValue = 0f,
			maxValue = 25000f,
			SI = true,
			units = "u",
			canGoOutOfBounds = false
		};

		public readonly FloatSetting insideRadius = new FloatSetting
		{
			Name = "Inside radius",
			HelperText = "Inside radius of the ring, as a multiple of the outside radius",
			precision = 2,
			val = 0.8f,
			DefaultValue = 0.8f,
			minValue = 0f,
			maxValue = 0.999f,
			SI = false,
			units = "x",
			canGoOutOfBounds = false
		};

		public readonly FloatSetting widthRelative = new FloatSetting
		{
			Name = "Width",
			HelperText = "Width of the zone, as a multiple of the Simulation Size.",
			precision = 3,
			val = 0.25f,
			DefaultValue = 0.25f,
			minValue = 0f,
			maxValue = 2f,
			SI = false,
			units = "x",
			canGoOutOfBounds = false
		};

		public readonly FloatSetting widthAbsolute = new FloatSetting
		{
			Name = "Width",
			HelperText = "Width of the zone, will not change when changing sim size.",
			precision = 2,
			val = 1000f,
			DefaultValue = 1000f,
			minValue = 0f,
			maxValue = 25000f,
			SI = true,
			units = "u",
			canGoOutOfBounds = false
		};

		public readonly FloatSetting heightRelative = new FloatSetting
		{
			Name = "Height",
			HelperText = "Height of the zone, as a multiple of the Simulation Size.",
			precision = 3,
			val = 0.5f,
			DefaultValue = 0.5f,
			minValue = 0f,
			maxValue = 2f,
			SI = false,
			units = "x",
			canGoOutOfBounds = false
		};

		public readonly FloatSetting heightAbsolute = new FloatSetting
		{
			Name = "Height",
			HelperText = "Height of the zone, will not change when changing sim size.",
			precision = 2,
			val = 1000f,
			DefaultValue = 1000f,
			minValue = 0f,
			maxValue = 25000f,
			SI = true,
			units = "u",
			canGoOutOfBounds = false
		};

		public UnityEvent onSizeChange = new UnityEvent();

		public UnityEvent onBiomassChange = new UnityEvent();

		public UnityEvent onAnySettingChange = new UnityEvent();

		public static SettingChoices<SpawnDistribution> distributionChoices = new SettingChoices<SpawnDistribution>
		{
			choices = new List<SettingChoice<SpawnDistribution>>
			{
				new SettingChoice<SpawnDistribution>(SpawnDistribution.Flat, "Flat Circle", "Pellets will have an equal probability to spawn anywhere in the zone"),
				new SettingChoice<SpawnDistribution>(SpawnDistribution.CentricGradual, "Center to edge Circle", "Pellets have a higher probability to spawn closer to the center, with a probability of 0 at the edges."),
				new SettingChoice<SpawnDistribution>(SpawnDistribution.ExteriorGradual, "Edge to center Circle", "Pellets have a higher probability to spawn closer to the edge, with a probability of 0 at the center."),
				new SettingChoice<SpawnDistribution>(SpawnDistribution.Ring, "Ring", "Pellets will spawn in a ring, with a pellet density of 0 at the ring's edges"),
				new SettingChoice<SpawnDistribution>(SpawnDistribution.FlatRing, "Flat Ring", "Pellets will spawn in a ring, with a pellet density even across the ring"),
				new SettingChoice<SpawnDistribution>(SpawnDistribution.Rect, "Rectangular", "Pellets will spawn in a rectangular inside a rectangle, with a flat distribution across the rectangle")
			}
		};

		public static SettingChoices<MovementType> movementChoices = new SettingChoices<MovementType>
		{
			choices = new List<SettingChoice<MovementType>>
			{
				new SettingChoice<MovementType>(MovementType.None, "None", "The Zone will be fixed and not move."),
				new SettingChoice<MovementType>(MovementType.Free, "Free", "The Zone will freely move around"),
				new SettingChoice<MovementType>(MovementType.Attached, "Locked to Target", "The Zone will be locked to the target Zone and move wih it.")
			}
		};

		public float area => distribution.val switch
		{
			SpawnDistribution.Flat => MathF.PI * Mathf.Pow(absoluteRadius, 2f), 
			SpawnDistribution.CentricGradual => MathF.PI * Mathf.Pow(absoluteRadius, 2f), 
			SpawnDistribution.ExteriorGradual => MathF.PI * Mathf.Pow(absoluteRadius, 2f), 
			SpawnDistribution.Ring => MathF.PI * Mathf.Pow(absoluteRadius, 2f) * (1f - Mathf.Pow(insideRadius.val, 2f)), 
			SpawnDistribution.FlatRing => MathF.PI * Mathf.Pow(absoluteRadius, 2f) * (1f - Mathf.Pow(insideRadius.val, 2f)), 
			SpawnDistribution.Rect => absoluteHeight * absoluteWidth, 
			_ => throw new ArgumentOutOfRangeException(), 
		};

		public bool isRing
		{
			get
			{
				if (distribution.val != SpawnDistribution.Ring)
				{
					return distribution.val == SpawnDistribution.FlatRing;
				}
				return true;
			}
		}

		public bool isRect => distribution.val == SpawnDistribution.Rect;

		public bool isCircle
		{
			get
			{
				if (!isRing)
				{
					return !isRect;
				}
				return false;
			}
		}

		public float maxBiomass
		{
			get
			{
				if (!(spawnMaterial.val == null))
				{
					return biomassDensity.val * area * ScenarioIndependentSettings.Instance.biomassDensity.val;
				}
				return 0f;
			}
		}

		public float totalGrowth
		{
			get
			{
				if (!(spawnMaterial.val == null))
				{
					return fertility.val * area * ScenarioIndependentSettings.Instance.pelletGrowth.val;
				}
				return 0f;
			}
		}

		public int estimatedPellets
		{
			get
			{
				if (!(spawnMaterial.val == null))
				{
					return Mathf.CeilToInt(maxBiomass / (pelletSize.val * ScenarioSettings.Instance.pelletEnergy.val));
				}
				return 0;
			}
		}

		public float sizeFactor => pelletSize.val;

		public float relativeRadius
		{
			get
			{
				if (!sizeScalesWithSim.val)
				{
					return radiusAbsolute.val / ScenarioIndependentSettings.Instance.SimulationSize.val;
				}
				return radiusRelative.val;
			}
		}

		public float absoluteRadius
		{
			get
			{
				if (!sizeScalesWithSim.val)
				{
					return radiusAbsolute.val;
				}
				return radiusRelative.val * ScenarioIndependentSettings.Instance.SimulationSize.val;
			}
		}

		public float relativeHeight
		{
			get
			{
				if (!sizeScalesWithSim.val)
				{
					return heightAbsolute.val / ScenarioIndependentSettings.Instance.SimulationSize.val;
				}
				return heightRelative.val;
			}
		}

		public float absoluteHeight
		{
			get
			{
				if (!sizeScalesWithSim.val)
				{
					return heightAbsolute.val;
				}
				return heightRelative.val * ScenarioIndependentSettings.Instance.SimulationSize.val;
			}
		}

		public float relativeWidth
		{
			get
			{
				if (!sizeScalesWithSim.val)
				{
					return widthAbsolute.val / ScenarioIndependentSettings.Instance.SimulationSize.val;
				}
				return widthRelative.val;
			}
		}

		public float absoluteWidth
		{
			get
			{
				if (!sizeScalesWithSim.val)
				{
					return widthAbsolute.val;
				}
				return widthRelative.val * ScenarioIndependentSettings.Instance.SimulationSize.val;
			}
		}

		private void AnySettingChange()
		{
			onAnySettingChange.Invoke();
		}

		public ZoneSettings()
		{
			spawnMaterial.val = MatterMaterialManager.Plant;
			BaseSubscription();
		}

		public ZoneSettings(MatterMaterial material)
		{
			spawnMaterial.val = material;
			BaseSubscription();
		}

		private void BaseSubscription()
		{
			zoneID = maxID++;
			zoneName.SetValue($"Zone {zoneID}");
			radiusRelative.Subscribe(AlignRadius);
			radiusAbsolute.Subscribe(AlignRadius);
			widthRelative.Subscribe(AlignSize);
			widthAbsolute.Subscribe(AlignSize);
			heightAbsolute.Subscribe(AlignSize);
			heightRelative.Subscribe(AlignSize);
			biomassDensity.Subscribe(onBiomassChange.Invoke);
			fertility.Subscribe(onBiomassChange.Invoke);
			pelletSize.Subscribe(onBiomassChange.Invoke);
			insideRadius.Subscribe(onBiomassChange.Invoke);
			spawnMaterial.Subscribe(AnySettingChange);
			distribution.Subscribe(AnySettingChange);
			biomassDensity.Subscribe(AnySettingChange);
			fertility.Subscribe(AnySettingChange);
			pelletSize.Subscribe(AnySettingChange);
			movement.Subscribe(AnySettingChange);
			target.Subscribe(AnySettingChange);
			speed.Subscribe(AnySettingChange);
			posX.Subscribe(AnySettingChange);
			posY.Subscribe(AnySettingChange);
			sizeScalesWithSim.Subscribe(AnySettingChange);
			onSizeChange.AddListener(AnySettingChange);
			insideRadius.Subscribe(AnySettingChange);
		}

		public static ZoneSettings DefaultTemplate()
		{
			ZoneSettings zoneSettings = new ZoneSettings();
			zoneSettings.posX = null;
			zoneSettings.posY = null;
			zoneSettings.zoneName = null;
			zoneSettings.zoneID = -1;
			zoneSettings.sizeScalesWithSim.SetValue(_value: true);
			zoneSettings.radiusRelative.SetValue(0.15f);
			zoneSettings.fertility.SetValue(10f);
			zoneSettings.biomassDensity.SetValue(10f);
			zoneSettings.distribution.SetValue(SpawnDistribution.CentricGradual);
			zoneSettings.AlignRadius();
			return zoneSettings;
		}

		public static ZoneSettings DefaultZone()
		{
			ZoneSettings zoneSettings = new ZoneSettings(MatterMaterialManager.Plant);
			zoneSettings.radiusRelative.val = 1f;
			zoneSettings.AlignRadius();
			zoneSettings.fertility.val = 1f;
			return zoneSettings;
		}

		private void AlignRadius()
		{
			if (sizeScalesWithSim.val)
			{
				radiusAbsolute.val = absoluteRadius;
			}
			else
			{
				FloatSetting floatSetting = radiusRelative;
				float val = (radiusRelative.val = relativeRadius);
				floatSetting.val = val;
			}
			if (!isRect)
			{
				widthAbsolute.val = 2f * absoluteRadius;
				heightAbsolute.val = 2f * absoluteRadius;
				widthRelative.val = 2f * relativeRadius;
				heightRelative.val = 2f * relativeRadius;
			}
			onSizeChange.Invoke();
			onBiomassChange.Invoke();
			if (posX != null && posY != null)
			{
				CapPosition();
			}
		}

		private void AlignSize()
		{
			if (sizeScalesWithSim.val)
			{
				heightAbsolute.val = absoluteHeight;
				widthAbsolute.val = absoluteWidth;
			}
			else
			{
				heightRelative.val = relativeHeight;
				widthRelative.val = relativeWidth;
			}
			if (isRect)
			{
				radiusAbsolute.val = Mathf.Max(absoluteHeight, absoluteWidth) / 2f;
				radiusRelative.val = Mathf.Max(relativeHeight, relativeWidth) / 2f;
			}
			onSizeChange.Invoke();
			onBiomassChange.Invoke();
			if (posX != null && posY != null)
			{
				CapPosition();
			}
		}

		private void CapPosition()
		{
			float num;
			float num2;
			if (isRect)
			{
				num = Mathf.Clamp01(1f - relativeWidth / 2f);
				num2 = Mathf.Clamp01(1f - relativeHeight / 2f);
			}
			else
			{
				num = (num2 = Mathf.Clamp01(1f - relativeRadius));
			}
			posX.minValue = 0f - num;
			posX.maxValue = num;
			posY.minValue = 0f - num2;
			posY.maxValue = num2;
			posX.SetValue(Mathf.Clamp(posX.val, 0f - num, num));
			posY.SetValue(Mathf.Clamp(posY.val, 0f - num2, num2));
		}

		public void SetRandomPositionInRange()
		{
			float num;
			float num2;
			if (isRect)
			{
				num = Mathf.Clamp01(1f - relativeWidth / 2f);
				num2 = Mathf.Clamp01(1f - relativeHeight / 2f);
			}
			else
			{
				num = (num2 = Mathf.Clamp01(1f - relativeRadius));
			}
			posX.SetValue(UnityEngine.Random.Range(0f - num, num));
			posY.SetValue(UnityEngine.Random.Range(0f - num2, num2));
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			if (!string.IsNullOrEmpty(zoneName?.val))
			{
				jObject["name"] = zoneName.val;
			}
			if (zoneID >= 0)
			{
				jObject["id"] = zoneID;
			}
			if (spawnMaterial.val != null)
			{
				jObject["material"] = spawnMaterial.val.Name;
				jObject["distribution"] = distribution.val.ToString();
				jObject["fertility"] = fertility.val;
				jObject["biomassDensity"] = biomassDensity.val;
				jObject["pelletSize"] = pelletSize.val;
				if (renewBiomass.val)
				{
					jObject["renewBiomass"] = true;
				}
			}
			jObject["movement"] = movement.val.ToString();
			if (target.val != null)
			{
				jObject["target"] = target.val.zoneID;
			}
			jObject["speed"] = speed.val;
			if (posX != null)
			{
				jObject["posX"] = posX.val;
			}
			if (posY != null)
			{
				jObject["posY"] = posY.val;
			}
			jObject["radiusIsRelative"] = sizeScalesWithSim.val;
			if (isRect)
			{
				jObject["width"] = (sizeScalesWithSim.val ? widthRelative.val : widthAbsolute.val);
				jObject["height"] = (sizeScalesWithSim.val ? heightRelative.val : heightAbsolute.val);
			}
			else
			{
				jObject["radius"] = (sizeScalesWithSim.val ? radiusRelative.val : radiusAbsolute.val);
			}
			if (isRing)
			{
				jObject["insideRadius"] = insideRadius.val;
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			if (state["name"] != null)
			{
				zoneName.SetValue(state["name"].ToString());
			}
			zoneID = state["id"]?.ToObject<int>() ?? (-1);
			if (state["material"] != null)
			{
				spawnMaterial.SetValue(MatterMaterialManager.FindMaterial(state["material"].ToString()));
			}
			if (state["distribution"] != null)
			{
				distribution.SetValue(state["distribution"].ToObject<SpawnDistribution>());
			}
			if (state["fertility"] != null)
			{
				fertility.SetValue(state["fertility"].ToObject<float>());
			}
			if (state["biomassDensity"] != null)
			{
				biomassDensity.SetValue(state["biomassDensity"].ToObject<float>());
			}
			if (state["pelletSize"] != null)
			{
				pelletSize.SetValue(state["pelletSize"].ToObject<float>());
			}
			if (state["renewBiomass"] != null)
			{
				renewBiomass.SetValue(_value: true);
			}
			if (state["movement"] != null)
			{
				movement.SetValue(state["movement"].ToObject<MovementType>());
			}
			if (state["target"] != null)
			{
				target.targetID = state["target"].ToObject<int>();
			}
			speed.val = state["speed"].ToObject<float>();
			if (posX != null && state["posX"] != null)
			{
				posX.val = state["posX"].ToObject<float>();
			}
			if (posY != null && state["posY"] != null)
			{
				posY.val = state["posY"].ToObject<float>();
			}
			if (state["radiusIsRelative"] != null)
			{
				sizeScalesWithSim.val = state["radiusIsRelative"].ToObject<bool>();
			}
			if (isRect)
			{
				if (sizeScalesWithSim.val)
				{
					widthRelative.val = state["width"].ToObject<float>();
					heightRelative.val = state["height"].ToObject<float>();
				}
				else
				{
					widthAbsolute.val = state["width"].ToObject<float>();
					heightAbsolute.val = state["height"].ToObject<float>();
				}
				AlignSize();
				return;
			}
			if (isRing && state["insideRadius"] != null)
			{
				insideRadius.SetValue(state["insideRadius"].ToObject<float>());
			}
			if (sizeScalesWithSim.val)
			{
				radiusRelative.SetValue(state["radius"].ToObject<float>());
			}
			else
			{
				radiusAbsolute.SetValue(state["radius"].ToObject<float>());
			}
			AlignRadius();
		}

		public override string ToString()
		{
			return zoneName?.val ?? $"Template Zone {zoneID}";
		}
	}
}
