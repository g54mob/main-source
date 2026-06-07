using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Common.Animation;
using ModApi.Common.Extensions;
using ModApi.Packages.FastNoise;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Craters 2", "A planet modifier used for generating craters. This supports highly configurable multiple passes. In general, this has much better performance than 'Craters 1' at the cost of some loss of quality and control over the generated craters. This modifier, unlike 'Craters 1', does not have built-in noise to provide variation in crater shape. Instead, outputs from two external noise modifiers are passed in via data inputs. For each crater pass, these noise values are linearly interpolated based on the pass configuration to generate the crater shape noise for that pass. This results in less control over noise per-pass but it can be much more efficient than using many 'Crater 1' modifiers to generate many overlapping craters of various sizes.")]
	public class CratersFast : VertexDataCommonPassPlanetModifier
	{
		[Serializable]
		public class CraterPass : ICustomObjectInspectorModelFields
		{
			[NonSerialized]
			public AnimationCurveSampler01 CurveSampler;

			[SerializeField]
			[InspectorProperty(null, false, Order = 10)]
			public PassCurve CustomCurve;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Pass Enabled", Order = 0, Tooltip = "This provides an easy way to quickly disable a crater pass, which can be useful in development and testing.")]
			public bool Enabled = true;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Noise Frequency", Order = 40, Tooltip = "The frequency of the noise that generates the craters. The higher the frequency the smaller and more numerous the craters become.")]
			public int Frequency = 10;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Max Depth", Order = 20, Tooltip = "The maximum depth of the crater in meters. This occurs when the crater shape curve evaluates to -1 on the y-axis.")]
			public float MaxDepth = 100f;

			[NonSerialized]
			[HideInInspector]
			public string Name;

			[NonSerialized]
			public IFastNoise Noise;

			[Range(0f, 1f)]
			[SerializeField]
			[InspectorProperty(null, false, Label = "Noise Interpolation", Order = 60, Tooltip = "This is the value used for linearly interpolating the crater shape noise between data inputs 'A' and 'B'. At a value of 0, only the input 'A' value is used to provide noise to the crater shapes. At a value of 1, only the input 'B' value is used. Any value in between 0 and 1 linearly interpolates between the two.")]
			public double NoiseLerp;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Noise Strength", Order = 50, Tooltip = "The scalar value used to adjust the strength of the crater shape noise before it is applied.")]
			public double NoiseStrength = 1.0;

			[Range(0f, 1f)]
			[SerializeField]
			[InspectorProperty(null, false, Label = "Position Randomness", Order = 70, Tooltip = "The randomness in the crater position noise. Less randomness means more consistent (and larger) craters but they will be more grid like in alignment.")]
			public double Randomness = 0.75;

			[NonSerialized]
			public Quaterniond Rotation;

			[Range(-180f, 180f)]
			[SerializeField]
			[InspectorProperty(null, false, Label = "Rotation Angle", Order = 80, Tooltip = "The angle of the rotation to be applied to the input position used to sample crater positions and sizes. Sometimes adjusting the rotation slightly can help when multiple passes all want to pile craters on top of other craters.")]
			public float RotationAngle;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Rotation Axis", Order = 90, Tooltip = "The axis of the rotation angle to be applied to the input position used to sample crater positions and sizes. Sometimes adjusting the rotation slightly can help when multiple passes all want to pile craters on top of other craters.")]
			public Vector3 RotationAxis = Vector3.up;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Noise Seed", Order = 30, Tooltip = "The seed value used for the cellular noise that generates the crater positions and sizes.")]
			public int Seed;

			public CraterPass()
			{
				CustomCurve = new PassCurve(null);
			}

			public static CraterPass[] LoadXml(XElement xml)
			{
				return xml.Elements("Pass").Select(delegate(XElement x)
				{
					XAttribute xAttribute = x.Attribute("curve");
					return new CraterPass
					{
						Enabled = (((bool?)x.Attribute("enabled")) ?? true),
						Seed = (int)x.Attribute("seed"),
						Frequency = (int)x.Attribute("frequency"),
						MaxDepth = (float)x.Attribute("maxDepth"),
						NoiseStrength = (double)x.Attribute("noiseStrength"),
						NoiseLerp = (double)x.Attribute("noiseLerp"),
						Randomness = Mathd.Clamp01((double)x.Attribute("randomness")),
						RotationAngle = (float)x.Attribute("rotationAngle"),
						RotationAxis = x.GetVector3Attribute("rotationAxis"),
						CustomCurve = new PassCurve((xAttribute == null) ? null : Utilities.GetAnimationCurveAttribute(x, "curve"))
					};
				}).ToArray();
			}

			public static void SaveXml(XElement xml, CraterPass[] passes)
			{
				foreach (CraterPass craterPass in passes)
				{
					XElement xElement = new XElement("Pass");
					xElement.SetAttributeValue("enabled", craterPass.Enabled);
					xElement.SetAttributeValue("seed", craterPass.Seed);
					xElement.SetAttributeValue("frequency", craterPass.Frequency);
					xElement.SetAttributeValue("maxDepth", craterPass.MaxDepth);
					xElement.SetAttributeValue("noiseStrength", craterPass.NoiseStrength);
					xElement.SetAttributeValue("noiseLerp", craterPass.NoiseLerp);
					xElement.SetAttributeValue("randomness", craterPass.Randomness);
					xElement.SetAttributeValue("rotationAngle", craterPass.RotationAngle);
					xElement.SetAttribute("rotationAxis", craterPass.RotationAxis);
					if (craterPass.CustomCurve.Enabled)
					{
						Utilities.SetAnimationCurveAttribute(xElement, "curve", craterPass.CustomCurve.Curve);
					}
					xml.Add(xElement);
				}
			}

			public bool CreateFieldModel(GroupModel groupModel, IObjectInspector inspectorObject, MemberInfo member, int? arrayIndex)
			{
				if (member.Name == "CustomCurve")
				{
					ToggleModel customShapeEnabled = groupModel.AddAndBuild(new ToggleModel("Custom Shape Enabled", () => CustomCurve.Enabled, delegate(bool x)
					{
						CustomCurve.Enabled = x;
					}, "If enabled, the custom crater shape curve defined in this pass will be used for craters generated in this pass. Otherwise, the default crater shape curve defined by the modifier will be used for this pass.")).Model;
					groupModel.AddAndBuild(new CurveModel("Custom Shape", () => CustomCurve.Curve, delegate(AnimationCurve x)
					{
						CustomCurve.Curve = x;
					})).Build(delegate(CurveModel x)
					{
						x.Tooltip = "The custom crater shape curve used for craters generated in this pass only (if enabled).";
					}).Build(delegate(CurveModel x)
					{
						x.DetermineVisibility = () => customShapeEnabled.Value;
					});
					return true;
				}
				return false;
			}
		}

		[Serializable]
		public class PassCurve
		{
			[SerializeField]
			public AnimationCurve Curve;

			[SerializeField]
			public bool Enabled;

			public PassCurve()
				: this(null)
			{
			}

			public PassCurve(AnimationCurve curve)
			{
				Curve = curve ?? GetDefaultCurve();
				Enabled = curve != null;
			}
		}

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Noise Input A", true, true, Order = 0, Tooltip = "The first crater shape noise input data. Each crater pass can choose a value by which this noise input and the other noise input are linearly interpolated to generated the crater shape noise value for that pass. This noise helps provide variation in the crater shape to avoid all craters appearing as perfect circles. Lower frequency noise (relative to the crater size) can be used to create some very intresting non-crater like terrain.")]
		private int _craterNoiseADataIndex = -1;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Noise Input B", true, true, Order = 1, Tooltip = "The second crater shape noise input data. Each crater pass can choose a value by which this noise input and the other noise input are linearly interpolated to generated the crater shape noise value for that pass. This noise helps provide variation in the crater shape to avoid all craters appearing as perfect circles. Lower frequency noise (relative to the crater size) can be used to create some very intresting non-crater like terrain.")]
		private int _craterNoiseBDataIndex = -1;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Crater Passes", Order = 10)]
		private CraterPass[] _craterPasses;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Shape", Order = 0, Tooltip = "The default curve that craters will resembly. This curve can be overridden by individual passes. If a pass does not define a custom curve, it will fall back to this default curve. This is typically a curve mapped between (0,-1) and (1,0).The x-axis represents distance from the center of the crater and the y-axis represents the depth of the crater.The left side of the curve, starting at 0, represents the center of the craters.The right side of the curve, which should typically end at 1, represents the end of the rims of the craters. The bottom of the curve, starting at -1, represents the deepest part of the craters. The top of the curve, ending at 0, represents the regular surface of the planet.")]
		private AnimationCurve _curve;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Output, "Minimum Noise Output", true, true, Order = 3, Tooltip = "An optional data output that stores the minimum noise output used for the height of the craters.")]
		private int _heightNoiseMinOutputDataIndex = -1;

		[SerializeField]
		[InspectorProperty("Prevents the seed from being randomized when the randomize button is clicked.", false)]
		private bool _lockSeed;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Crater Mask Input", true, true, Order = 2, Tooltip = "The data input value that, if used, can mask out the craters generated by this modifier. This is typically a value between zero and one where one represents full strength un-masked craters and zero results in this modifier changing nothing.")]
		private int _maskDataIndex = -1;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Max Height Color Variance", Order = 30, Tooltip = "The red, green, and blue color values (typically from 0 to 1) to add to the terrain color as the crater extends above the planet's surface. This is useful for adding a bit of color variation to the crater rims.")]
		private Vector3 _maxHeightColorVariance;

		[SerializeField]
		[InspectorGroup("Crater Colors")]
		[InspectorProperty(null, false, Label = "Min Height Color Variance", Order = 20, Tooltip = "The red, green, and blue color values (typically from 0 to 1) to subtract from the terrain color as it reaches its minimum height for the craters. This is useful for adding a bit of color variation to the deep centers of the craters")]
		private Vector3 _minHeightColorVariance;

		[SerializeField]
		[InspectorProperty("Allows multiple, unlocked Noise elements to obtain the same seed when the randomize button is clicked.", false)]
		private string _seedSyncId;

		public CraterPass[] CraterPasses
		{
			get
			{
				return _craterPasses;
			}
			set
			{
				_craterPasses = value;
			}
		}

		public AnimationCurve Curve
		{
			get
			{
				return _curve;
			}
			set
			{
				_curve = value;
			}
		}

		public bool HasDualNoiseInputs
		{
			get
			{
				if (_craterNoiseADataIndex >= 0)
				{
					return _craterNoiseBDataIndex >= 0;
				}
				return false;
			}
		}

		public override VertexDataPlanetModifierPassType[] SupportedPassTypes => new VertexDataPlanetModifierPassType[3]
		{
			VertexDataPlanetModifierPassType.Biome,
			VertexDataPlanetModifierPassType.Height,
			VertexDataPlanetModifierPassType.HeightFinal
		};

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public CratersFast()
		{
			base.VisibleInBasicViewMode = true;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			float num = 1f;
			if (_maskDataIndex != -1)
			{
				num = (float)data.Data[_maskDataIndex];
				if (num <= 0f)
				{
					if (_heightNoiseMinOutputDataIndex != -1)
					{
						data.Data[_heightNoiseMinOutputDataIndex] = 1.0;
					}
					return;
				}
			}
			double num2 = 0.0;
			if (_craterNoiseADataIndex != -1)
			{
				num2 = data.Data[_craterNoiseADataIndex] * 0.25 + 0.25;
			}
			double num3 = 0.0;
			if (_craterNoiseBDataIndex != -1)
			{
				num3 = data.Data[_craterNoiseBDataIndex] * 0.25 + 0.25;
			}
			double num4 = num3 - num2;
			double num5 = 1.0;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			for (int i = 0; i < _craterPasses.Length; i++)
			{
				CraterPass craterPass = _craterPasses[i];
				if (!craterPass.Enabled)
				{
					continue;
				}
				Vector3d vector3d = craterPass.Rotation * input.Position;
				double craterNoise = craterPass.Noise.GetCraterNoise(vector3d.x, vector3d.y, vector3d.z);
				double num9 = craterPass.NoiseStrength * craterNoise;
				craterNoise += (num2 + num4 * craterPass.NoiseLerp) * num9;
				if (craterNoise < num5)
				{
					num5 = craterNoise;
				}
				float num10 = ((craterNoise >= 1.0) ? craterPass.CurveSampler.ValueAtMax : craterPass.CurveSampler.Sample((float)craterNoise));
				num6 += num10 * craterPass.MaxDepth;
				if (num10 >= 0f)
				{
					num7 = num10;
					continue;
				}
				num7 = 0f;
				if (num10 < num8)
				{
					num8 = num10;
				}
			}
			data.Height += num6 * num;
			if ((double)num7 > 0.001)
			{
				Vector3 vector = _maxHeightColorVariance * (num7 * num);
				data.Color.r += vector.x;
				data.Color.g += vector.y;
				data.Color.b += vector.z;
			}
			if ((double)num8 < -0.001)
			{
				Vector3 vector2 = _minHeightColorVariance * (num8 * num);
				data.Color.r += vector2.x;
				data.Color.g += vector2.y;
				data.Color.b += vector2.z;
			}
			if (_heightNoiseMinOutputDataIndex != -1)
			{
				data.Data[_heightNoiseMinOutputDataIndex] = (((double)num >= 1.0) ? num5 : (1.0 + (num5 - 1.0) * (double)num));
			}
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			float num = 1f;
			if (_maskDataIndex != -1)
			{
				num = (float)data.Data[_maskDataIndex];
				if (num <= 0f)
				{
					if (_heightNoiseMinOutputDataIndex != -1)
					{
						data.Data[_heightNoiseMinOutputDataIndex] = 1.0;
					}
					return;
				}
			}
			double num2 = 0.0;
			if (_craterNoiseADataIndex != -1)
			{
				num2 = data.Data[_craterNoiseADataIndex] * 0.25 + 0.25;
			}
			double num3 = 0.0;
			if (_craterNoiseBDataIndex != -1)
			{
				num3 = data.Data[_craterNoiseBDataIndex] * 0.25 + 0.25;
			}
			double num4 = num3 - num2;
			double num5 = 1.0;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			for (int i = 0; i < _craterPasses.Length; i++)
			{
				CraterPass craterPass = _craterPasses[i];
				if (!craterPass.Enabled)
				{
					continue;
				}
				Vector3d vector3d = craterPass.Rotation * input.Position;
				double craterNoise = craterPass.Noise.GetCraterNoise(vector3d.x, vector3d.y, vector3d.z);
				double num9 = craterPass.NoiseStrength * craterNoise;
				craterNoise += (num2 + num4 * craterPass.NoiseLerp) * num9;
				if (craterNoise < num5)
				{
					num5 = craterNoise;
				}
				float num10 = ((craterNoise >= 1.0) ? craterPass.CurveSampler.ValueAtMax : ((craterNoise <= 0.0) ? craterPass.CurveSampler.ValueAtMin : craterPass.CurveSampler.Sample((float)craterNoise)));
				num6 += num10 * craterPass.MaxDepth;
				if (num10 > 0f)
				{
					num7 = num10;
					continue;
				}
				num7 = 0f;
				if (num10 < num8)
				{
					num8 = num10;
				}
			}
			data.Height += num6 * num;
			if ((double)num7 > 0.001)
			{
				Vector3 vector = _maxHeightColorVariance * (num7 * num);
				data.Color.r += vector.x;
				data.Color.g += vector.y;
				data.Color.b += vector.z;
			}
			if ((double)num8 < -0.001)
			{
				Vector3 vector2 = _minHeightColorVariance * (num8 * num);
				data.Color.r += vector2.x;
				data.Color.g += vector2.y;
				data.Color.b += vector2.z;
			}
			if (_heightNoiseMinOutputDataIndex != -1)
			{
				data.Data[_heightNoiseMinOutputDataIndex] = num5;
			}
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			for (int i = 0; i < _craterPasses.Length; i++)
			{
				CraterPass craterPass = _craterPasses[i];
				craterPass.CurveSampler = new AnimationCurveSampler01(craterPass.CustomCurve.Enabled ? craterPass.CustomCurve.Curve : _curve);
				craterPass.Rotation = Quaterniond.AngleAxis(craterPass.RotationAngle, craterPass.RotationAxis);
				craterPass.Noise = FastNoise.CreateCraterNoise(craterPass.Seed, craterPass.Frequency, craterPass.Randomness);
			}
		}

		public override Vector2d LegacyGetMinMaxHeight(Vector2d minMaxHeight)
		{
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < _craterPasses.Length; i++)
			{
				CraterPass craterPass = _craterPasses[i];
				num += craterPass.CurveSampler.MinValue * craterPass.MaxDepth;
				num2 += craterPass.CurveSampler.MaxValue * craterPass.MaxDepth;
			}
			return minMaxHeight + new Vector2d(num, num2);
		}

		public override void OnCreatingInPlanetStudio(PlanetTerrainDataScript terrainData, VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatingInPlanetStudio(terrainData, parentModifier);
			_curve = GetDefaultCurve();
			_craterPasses = new CraterPass[1]
			{
				new CraterPass()
			};
		}

		public override bool Randomize(RandomizeContext context)
		{
			if (!_lockSeed)
			{
				if (context.Flags.HasFlag(PlanetModifierRandomizationFlags.SeedValues))
				{
					for (int i = 0; i < _craterPasses.Length; i++)
					{
						_craterPasses[i].Seed = context.GetRandomInt((_seedSyncId != null) ? $"{_seedSyncId}-{i}" : null);
					}
				}
				return true;
			}
			return false;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("maskDataIndex", _maskDataIndex);
			xml.SetAttributeValue("craterNoiseADataIndex", _craterNoiseADataIndex);
			xml.SetAttributeValue("craterNoiseBDataIndex", _craterNoiseBDataIndex);
			xml.SetAttributeValue("heightNoiseMinOutputDataIndex", _heightNoiseMinOutputDataIndex);
			xml.SetAttribute("maxHeightColorVariance", _maxHeightColorVariance);
			xml.SetAttribute("minHeightColorVariance", _minHeightColorVariance);
			Utilities.SetAnimationCurveAttribute(xml, "curve", _curve);
			CraterPass.SaveXml(xml, _craterPasses);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (_craterPasses == null)
			{
				return;
			}
			for (int i = 0; i < _craterPasses.Length; i++)
			{
				CraterPass craterPass = _craterPasses[i];
				if (craterPass != null)
				{
					IFastNoise noise = craterPass.Noise;
					craterPass.Noise = null;
					noise?.Dispose();
				}
			}
		}

		protected virtual void OnValidate()
		{
			UpdatePassNames();
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_maskDataIndex = (int)xml.Attribute("maskDataIndex");
			_craterNoiseADataIndex = (int)xml.Attribute("craterNoiseADataIndex");
			_craterNoiseBDataIndex = (int)xml.Attribute("craterNoiseBDataIndex");
			_heightNoiseMinOutputDataIndex = (int)xml.Attribute("heightNoiseMinOutputDataIndex");
			_maxHeightColorVariance = xml.GetVector3Attribute("maxHeightColorVariance");
			_minHeightColorVariance = xml.GetVector3Attribute("minHeightColorVariance");
			_curve = Utilities.GetAnimationCurveAttribute(xml, "curve");
			_craterPasses = CraterPass.LoadXml(xml);
			UpdatePassNames();
			float planetScale = base.PlanetScale;
			CraterPass[] craterPasses = _craterPasses;
			for (int i = 0; i < craterPasses.Length; i++)
			{
				craterPasses[i].MaxDepth *= planetScale;
			}
		}

		private static AnimationCurve GetDefaultCurve()
		{
			return Utilities.GetAnimationCurveAttribute(new XElement("Defaults", new XAttribute("curve", "0,-1,0,0,0,0,0,0|0.85,0.05,2.438755,2.438755,0,0,0,0|0.88,0.05,-0.9733779,-0.9733779,0,0,0,0|1,0,0,0,0,0,0,0")), "curve");
		}

		private void UpdatePassNames()
		{
			if (_craterPasses != null)
			{
				for (int i = 0; i < _craterPasses.Length; i++)
				{
					CraterPass craterPass = _craterPasses[i];
					craterPass.Name = $"Pass {i}: Seed: {craterPass.Seed}, Freq: {craterPass.Frequency} Depth: {craterPass.MaxDepth}, Rot: {craterPass.RotationAngle} | {craterPass.RotationAxis}";
				}
			}
		}
	}
}
