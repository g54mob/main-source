using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using ModApi.CelestialData;
using ModApi.Common.Extensions;
using ModApi.Common.SimpleTypes;
using ModApi.Packages;
using ModApi.Packages.FastNoise;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.Common;
using ModApi.PlanetStudio;
using ModApi.Ui.Inspector;
using Unity.Collections;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Noise", "A highly configurable planet modifier that can be used to generate all sorts of noise.")]
	public class VertexDataNoise : VertexDataCommonPassPlanetModifier, IBrushCubemapModifier, ICustomInspectorFields
	{
		[Serializable]
		internal class DomainWarping : IDisposable, ICustomInspectorFields
		{
			public bool Enabled;

			private static Dictionary<DomainWarpingType, List<FieldInfo>> _typeFieldMap;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Amplitude", Tooltip = "The amplitude of the domain warping noise.")]
			private double _amplitude = 1.0;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Domain Warping Type", ForceRefresh = true, Tooltip = "The domain warping type. Domain warping adjusts the input position prior to generating the actual noise, thus 'warping' it. Some domain warping uses additional noise to perform the warping")]
			private DomainWarpingType _domainWarpingType;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Frequency", Tooltip = "The frequency of the domain warping noise.")]
			private double _frequency = 1.0;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Gain", Tooltip = "The gain of the domain warping noise.")]
			private double _gain = 0.5;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Interpolation", Tooltip = "The interpolation method of the domain warping noise. Linear is the fastest and lowest quality. Quintic is the slowest and best quality.")]
			private Interpolation _interpolation = Interpolation.Quintic;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Lacunarity", Tooltip = "The lacunarity of the domain warping noise.")]
			private double _lacunarity = 2.0;

			private IFastNoise _noise;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Octaves", Tooltip = "The number of octaves for the domain warping noise.")]
			private int _octaves = 1;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Offset", Tooltip = "The X,Y,Z offset to apply to the input position before generating the noise value for that position.")]
			private Vector3d _offset;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Rotation", Tooltip = "The euler angles, in degrees, to rotate the input position before generating the noise value for that position.")]
			private Vector3d _rotation;

			private Quaterniond _rotationQuaternion;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Seed", Tooltip = "The noise seed value used for the domain warping noise.")]
			private int _seed;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Angle", Tooltip = "The amount of twist (in degrees) to apply to the lines in a single hemisphere.")]
			private double _twistAngle = 30.0;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Axis", Tooltip = "The axis around which to apply the twisting.")]
			private Vector3d _twistAxis = new Vector3d(0f, 1f, 0f);

			[SerializeField]
			[InspectorProperty(null, false, Label = "Exponent", Tooltip = "The exponent to apply to the twist amount. Increasing this can reduce the twisting near the equator and increase the twisting near the poles.")]
			private double _twistExponent = 1.0;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Method", Tooltip = "The method used to determine the strength of the twist at a given position.\n\nDistance On Axis - The twisting increases as distance on the axis increases.\n\nDistance On Axis Inverse - The twisting decreases as distance on the axis increases.\n\nDistance From Axis - The twisting increases as distance from the axis increases.\n\nDistance From Axis Inverse - The twisting decreases as distance from the axis increases.")]
			private DomainWarpingAxialTwistMethod _twistMethod;

			[SerializeField]
			[InspectorProperty(null, false, Label = "Warp Scale", Tooltip = "The X,Y,Z scale to apply to the input position before generating the noise value for that position.")]
			private Vector3 _warpScale = Vector3.one;

			public DomainWarpingType DomainWarpingType => _domainWarpingType;

			public void Dispose()
			{
				IFastNoise noise = _noise;
				_noise = null;
				noise?.Dispose();
			}

			public List<FieldInfo> GetCurrentFields()
			{
				if (_typeFieldMap == null)
				{
					_typeFieldMap = new Dictionary<DomainWarpingType, List<FieldInfo>>();
				}
				List<FieldInfo> value = null;
				if (!_typeFieldMap.TryGetValue(_domainWarpingType, out value))
				{
					value = new List<FieldInfo>();
					_typeFieldMap.Add(_domainWarpingType, value);
					GetCurrentFields(value);
				}
				return value;
			}

			public List<FieldInfo> GetInspectorFields()
			{
				return GetCurrentFields();
			}

			public void Initialize()
			{
				if (_domainWarpingType == DomainWarpingType.None)
				{
					Enabled = false;
					return;
				}
				Enabled = true;
				if (_domainWarpingType == DomainWarpingType.Basic || _domainWarpingType == DomainWarpingType.Fractal)
				{
					_noise = FastNoise.CreateNoise(_seed);
					_noise.SetFrequency(_frequency);
					_noise.SetFractalOctaves(_octaves);
					_noise.SetFractalLacunarity(_lacunarity);
					_noise.SetFractalGain(_gain);
					_noise.SetInterpolation(_interpolation);
					_noise.SetGradientPerturbAmp(_amplitude);
				}
				else if (_domainWarpingType == DomainWarpingType.Rotate)
				{
					_rotationQuaternion = Quaterniond.Euler(_rotation.x, _rotation.y, _rotation.z);
				}
			}

			public void Randomize(RandomizeContext context, string seedSyncId)
			{
				if (context.Flags.HasFlag(PlanetModifierRandomizationFlags.SeedValues))
				{
					_seed = context.GetRandomInt(seedSyncId);
				}
			}

			public void RestoreXml(XElement xml)
			{
				_domainWarpingType = (DomainWarpingType)Enum.Parse(typeof(DomainWarpingType), (string)xml.Attribute("domainWarpingType"), ignoreCase: true);
				foreach (FieldInfo currentField in GetCurrentFields())
				{
					string text = currentField.Name.TrimStart('_');
					if (currentField.FieldType == typeof(int))
					{
						int? num = (int?)xml.Attribute(text);
						currentField.SetValue(this, num.HasValue ? ((object)num.GetValueOrDefault()) : currentField.GetValue(this));
						continue;
					}
					if (currentField.FieldType == typeof(double))
					{
						double? num2 = (double?)xml.Attribute(text);
						currentField.SetValue(this, num2.HasValue ? ((object)num2.GetValueOrDefault()) : currentField.GetValue(this));
						continue;
					}
					if (currentField.FieldType == typeof(bool))
					{
						bool? flag = (bool?)xml.Attribute(text);
						currentField.SetValue(this, flag.HasValue ? ((object)(flag == true)) : currentField.GetValue(this));
						continue;
					}
					if (currentField.FieldType == typeof(Vector3))
					{
						currentField.SetValue(this, Utilities.GetVectorAttribute(xml, text, Vector3.one));
						continue;
					}
					if (currentField.FieldType == typeof(Vector3d))
					{
						currentField.SetValue(this, xml.GetVector3dAttribute(text, Vector3.one));
						continue;
					}
					if (currentField.FieldType.IsEnum)
					{
						currentField.SetValue(this, Enum.Parse(currentField.FieldType, ((string)xml.Attribute(text)) ?? currentField.GetValue(this).ToString(), ignoreCase: true));
						continue;
					}
					throw new NotSupportedException();
				}
			}

			public void SaveXml(XElement xml)
			{
				foreach (FieldInfo currentField in GetCurrentFields())
				{
					string text = currentField.Name.TrimStart('_');
					if (currentField.FieldType == typeof(Vector3))
					{
						xml.SetAttributeValue(text, Utilities.Vector3ToString((Vector3)currentField.GetValue(this)));
					}
					else
					{
						xml.SetAttributeValue(text, currentField.GetValue(this));
					}
				}
			}

			public void Warp(ref double x, ref double y, ref double z)
			{
				switch (_domainWarpingType)
				{
				case DomainWarpingType.Basic:
					_noise.GradientPerturb(ref x, ref y, ref z);
					break;
				case DomainWarpingType.Fractal:
					_noise.GradientPerturbFractal(ref x, ref y, ref z);
					break;
				case DomainWarpingType.Scaled:
					x *= _warpScale.x;
					y *= _warpScale.y;
					z *= _warpScale.z;
					break;
				case DomainWarpingType.Rotate:
				{
					Vector3d vector3d3 = _rotationQuaternion * new Vector3d(x, y, z);
					x = vector3d3.x;
					y = vector3d3.y;
					z = vector3d3.z;
					break;
				}
				case DomainWarpingType.Offset:
					x += _offset.x;
					y += _offset.y;
					z += _offset.z;
					break;
				case DomainWarpingType.AxialTwist:
				{
					Vector3d vector3d = new Vector3d(x, y, z);
					double num = 0.0;
					switch (_twistMethod)
					{
					case DomainWarpingAxialTwistMethod.DistanceOnAxis:
						num = Vector3d.Dot(vector3d, _twistAxis);
						break;
					case DomainWarpingAxialTwistMethod.DistanceOnAxisInverse:
						num = Vector3d.Dot(vector3d, _twistAxis);
						num = ((num >= 0.0) ? (1.0 - num) : (1.0 + num));
						break;
					case DomainWarpingAxialTwistMethod.DistanceFromAxis:
						num = Vector3d.ProjectOnPlane(vector3d, _twistAxis).magnitude;
						break;
					case DomainWarpingAxialTwistMethod.DistanceFromAxisInverse:
						num = 1.0 - Vector3d.ProjectOnPlane(vector3d, _twistAxis).magnitude;
						break;
					default:
						throw new NotSupportedException("Twist method not supported.");
					}
					if (_twistExponent != 1.0)
					{
						num = ((num >= 0.0) ? System.Math.Pow(num, _twistExponent) : (0.0 - System.Math.Pow(0.0 - num, _twistExponent)));
					}
					Vector3d vector3d2 = Quaterniond.AngleAxis(_twistAngle * num, _twistAxis) * vector3d;
					x = vector3d2.x;
					y = vector3d2.y;
					z = vector3d2.z;
					break;
				}
				case DomainWarpingType.None:
					break;
				}
			}

			private void GetCurrentFields(List<FieldInfo> fields)
			{
				fields.Add(GetField((DomainWarping x) => x._domainWarpingType));
				if (_domainWarpingType == DomainWarpingType.None)
				{
					return;
				}
				switch (_domainWarpingType)
				{
				case DomainWarpingType.Basic:
					fields.Add(GetField((DomainWarping x) => x._seed));
					fields.Add(GetField((DomainWarping x) => x._frequency));
					fields.Add(GetField((DomainWarping x) => x._amplitude));
					fields.Add(GetField((DomainWarping x) => x._interpolation));
					break;
				case DomainWarpingType.Fractal:
					fields.Add(GetField((DomainWarping x) => x._seed));
					fields.Add(GetField((DomainWarping x) => x._frequency));
					fields.Add(GetField((DomainWarping x) => x._amplitude));
					fields.Add(GetField((DomainWarping x) => x._octaves));
					fields.Add(GetField((DomainWarping x) => x._gain));
					fields.Add(GetField((DomainWarping x) => x._lacunarity));
					fields.Add(GetField((DomainWarping x) => x._interpolation));
					break;
				case DomainWarpingType.Scaled:
					fields.Add(GetField((DomainWarping x) => x._warpScale));
					break;
				case DomainWarpingType.Rotate:
					fields.Add(GetField((DomainWarping x) => x._rotation));
					break;
				case DomainWarpingType.Offset:
					fields.Add(GetField((DomainWarping x) => x._offset));
					break;
				case DomainWarpingType.AxialTwist:
					fields.Add(GetField((DomainWarping x) => x._twistAxis));
					fields.Add(GetField((DomainWarping x) => x._twistAngle));
					fields.Add(GetField((DomainWarping x) => x._twistExponent));
					fields.Add(GetField((DomainWarping x) => x._twistMethod));
					break;
				case DomainWarpingType.None:
					break;
				}
			}

			private FieldInfo GetField<T>(Expression<Func<DomainWarping, T>> fieldSelector)
			{
				return (FieldInfo)((MemberExpression)fieldSelector.Body).Member;
			}
		}

		private static readonly Gradient _mapColorGradientDefault = new Gradient
		{
			colorKeys = new GradientColorKey[2]
			{
				new GradientColorKey(Color.black, 0f),
				new GradientColorKey(Color.white, 1f)
			}
		};

		private static Dictionary<string, List<FieldInfo>> _typeFieldMap;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Cellular Distance", Tooltip = "The method used to calculate disatance when using cellular noise.")]
		private CellularDistanceFunction _cellularDistanceFunction;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Cellular Return Type", ForceRefresh = true, Tooltip = "When using cellular noise, this determines what kind of values will be stored as the output of this modifier.")]
		private CustomCellularReturnType _cellularReturnType = CustomCellularReturnType.Distance2Add;

		private SingleChannelByteCubemapDataSampler _cubemap;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", true, true, Tooltip = "The output of this noise modifier. Many noise methods are capped between -1 and 1, but that is not always the case.")]
		private int _dataIndex;

		[SerializeField]
		private double _displacement;

		[SerializeField]
		[InspectorGroup(null, Reset = true)]
		private DomainWarping[] _domainWarping;

		[SerializeField]
		private double[] _fractalAmplitudes;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Fractal Amplitude Type", ForceRefresh = true, Tooltip = "Typically each octave of noise scales the amplitude of the previous octave by the 'Gain' value. If this is set to manual, the amplitude used at each octave can be manually set to a specific value. This is an advanced technique and generally not recommended, but it can be very useful in some scenarios.")]
		private FractalAmplitudeType _fractalAmplitudeType;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Fractal Lacunarity Type", ForceRefresh = true, Tooltip = "Typically each octave of noise scales the frequency of the previous octave by the 'Lacunarity' value. If this is set to manual, the frequency used at each octave can be manually set to a specific value. This is an advanced technique and generally not recommended, but it can be very useful in some scenarios.")]
		private FractalLacunarityType _fractalLacunarityType;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Fractal Type", ForceRefresh = true, Tooltip = "If using fractal based noise, this determines the fractal type used. These all behave in different and interesting ways. It is best to just experiment with each to get a feel for what they do and how the various settings impact them. Good luck!")]
		private FractalType _fractalType;

		[SerializeField]
		[InspectorProperty(null, false, Label = "Derivative Fractal Type", ForceRefresh = true, Tooltip = "If using fractal with derivative based noise, this determines the type used. These all behave in different and interesting ways. It is best to just experiment with each to get a feel for what they do and how the various settings impact them. Good luck!")]
		private FractalWithDerivativeType _fractalWithDerivativeType;

		[SerializeField]
		[InspectorProperty("The number of cycles per unit length.", false)]
		private double _frequency = 1.0;

		[SerializeField]
		[InspectorProperty("A multiplier that determines how the strength changes with each successive octave.", false)]
		private double _gain = 0.5;

		[SerializeField]
		[InspectorProperty("Interpolation Method", false, Tooltip = "The interpolation method used by the noise. Linear is the fastest and lowest quality. Quintic is the slowest and best quality.")]
		private Interpolation _interpolation = Interpolation.Quintic;

		[SerializeField]
		private double[] _lacunarities;

		[SerializeField]
		[InspectorProperty("A multiplier that determines how quickly the frequency increases for each successive octave.", false)]
		private double _lacunarity = 2.0;

		[SerializeField]
		[InspectorProperty("Prevents the seed from being randomized when the randomize button is clicked.", false)]
		private bool _lockSeed;

		[SerializeField]
		[ColorUsage(false, false)]
		[InspectorProperty("Map Color Gradient", false, Tooltip = "This is the color gradient that will be used on the brush painting flyout if a custom map is painted for this modifier.")]
		private Gradient _mapColorGradient;

		[SerializeField]
		[InspectorProperty("Disable Map", false, Tooltip = "If enabled, this will ignore any custom map that has been created (using the brush flyout) for for this modifier.")]
		private bool _mapIgnore;

		[SerializeField]
		[InspectorProperty("Map Max Value", false, Tooltip = "The maximum value represented by map pixel data.")]
		private double _mapMaxValue = 1.0;

		[SerializeField]
		[InspectorProperty("Map Min Value", false, Tooltip = "The minimum value represented by map pixel data.")]
		private double _mapMinValue = -1.0;

		[SerializeField]
		[InspectorGroup("Planet Brush Map")]
		[InspectorProperty("Map Name", false, ForceRefresh = true, Tooltip = "The ID of the optional map to use with this modifier. If this is left blank, this brush flyout cannot make use of this modifier for creating custom painted maps. This should be a unique name within the celestial body being created.")]
		private string _mapName;

		[SerializeField]
		[InspectorProperty("Map Noise Combine", false, ForceRefresh = true, Tooltip = "If enabled and a cubemap is used, the regular noise will be combined with the cubemap noise. If false, only the cubemap noise value is returned.")]
		private bool _mapNoiseCombine;

		[SerializeField]
		private int _mapNoiseOctaveSkip;

		[SerializeField]
		[InspectorProperty("Map Noise Strength", false, Tooltip = "The strength of the noise used with a custom map.")]
		private double _mapNoiseStrength = 1.0;

		[SerializeField]
		[InspectorProperty("Map Sample Mode", false, Tooltip = "If a custom cubemap is used, this determines the sampling mode used when applying the map data to the planet. Bicubic is generally better looking (not always), but it is much more expensive than Bilinear.")]
		private TextureDataSampleMode _mapSampleMode;

		private double _mapValueRange;

		[SerializeField]
		[Range(-1f, 9f)]
		[DataSlot(DataSlotType.Input, "Mask", true, true, Tooltip = "The optional data input used as a mask for this modifier. These values are typically in the range of 0 to 1 and they scale the strength of the noise result.")]
		private int _maskDataIndex = -1;

		private IFastNoise _noise;

		private INoiseGenerator _noiseGenerator;

		[SerializeField]
		[InspectorProperty("The base type of noise", true)]
		private NoiseType _noiseType = NoiseType.Perlin;

		[SerializeField]
		[InspectorProperty("The number of times to run the noise, each time modifying its frequency by lacunarity and its strength by gain. More octaves can improve visuals, but also reduce runtime performance.", false)]
		private int _octaves = 1;

		[SerializeField]
		[NumericRange(1.0, 10000.0)]
		[InspectorProperty("Power Exponent", false, Tooltip = "The power exponent used in some noise types.")]
		private double _powerExponent = 2.0;

		[SerializeField]
		[InspectorProperty("Seed", false, Tooltip = "The seed value for the noise. Each unique seed should produce completely unique noise for a given set of configuration values.")]
		private int _seed;

		[SerializeField]
		[InspectorProperty("Allows multiple, unlocked Noise elements to obtain the same seed when the randomize button is clicked.", false)]
		private string _seedSyncId;

		[SerializeField]
		[InspectorProperty("Slope Erosion Strength", false, Tooltip = "The strength of the 'slope erosion' used by some noise types.")]
		private double _slopeErosionStrength = 1.0;

		[SerializeField]
		[InspectorProperty("The amplitude of the noise.", false)]
		private double _strength = 1.0;

		[SerializeField]
		private bool _useDistance = true;

		bool IBrushCubemapModifier.ApplyNoise
		{
			get
			{
				return _mapNoiseCombine;
			}
			set
			{
				_mapNoiseCombine = value;
			}
		}

		bool IBrushCubemapModifier.CanApplyNoise => true;

		bool IBrushCubemapModifier.CanSkipOctaves
		{
			get
			{
				if (_octaves > 1)
				{
					if (_noiseType != NoiseType.CubicFractal && _noiseType != NoiseType.PerlinFractal && _noiseType != NoiseType.ValueFractal)
					{
						return _noiseType == NoiseType.ValueFractalWithDerivative;
					}
					return true;
				}
				return false;
			}
		}

		public FractalType FractalType
		{
			get
			{
				return _fractalType;
			}
			set
			{
				_fractalType = value;
			}
		}

		public double Frequency
		{
			get
			{
				return _frequency;
			}
			set
			{
				_frequency = value;
			}
		}

		public double Gain
		{
			get
			{
				return _gain;
			}
			set
			{
				_gain = value;
			}
		}

		public double Lacunarity
		{
			get
			{
				return _lacunarity;
			}
			set
			{
				_lacunarity = value;
			}
		}

		public Gradient MapColorGradient
		{
			get
			{
				return _mapColorGradient;
			}
			set
			{
				_mapColorGradient = value;
			}
		}

		public string MapDisplayName => _mapName;

		public string MapId
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(_mapName))
				{
					return "Cubemap - " + _mapName;
				}
				return null;
			}
		}

		int IBrushCubemapModifier.NoiseOctaveSkipCount
		{
			get
			{
				return _mapNoiseOctaveSkip;
			}
			set
			{
				_mapNoiseOctaveSkip = value;
			}
		}

		double IBrushCubemapModifier.NoiseStrength
		{
			get
			{
				return _mapNoiseStrength;
			}
			set
			{
				_mapNoiseStrength = value;
			}
		}

		public NoiseType NoiseType
		{
			get
			{
				return _noiseType;
			}
			set
			{
				_noiseType = value;
			}
		}

		public int Octaves
		{
			get
			{
				return _octaves;
			}
			set
			{
				_octaves = value;
			}
		}

		public int Seed
		{
			get
			{
				return _seed;
			}
			set
			{
				_seed = value;
			}
		}

		public double Strength
		{
			get
			{
				return _strength;
			}
			set
			{
				_strength = value;
			}
		}

		public override bool SupportsRandomization => true;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		protected int DataIndex
		{
			get
			{
				return _dataIndex;
			}
			set
			{
				_dataIndex = value;
			}
		}

		protected bool LockSeed => _lockSeed;

		protected string SeedSyncId => _seedSyncId;

		public VertexDataNoise()
		{
			base.VisibleInBasicViewMode = true;
		}

		public byte[] GenerateMap(int size)
		{
			byte[] array = null;
			bool flag = _noise != null;
			bool mapIgnore = _mapIgnore;
			try
			{
				_mapIgnore = true;
				if (!flag)
				{
					Initialize(GetComponentInParent<PlanetDataScript>().TerrainData);
				}
				int num = size * 6;
				Texture2D texture2D = new Texture2D(num, size, TextureFormat.RGB24, mipChain: false, linear: true);
				NativeArray<ColorRGB24> rawTextureData = texture2D.GetRawTextureData<ColorRGB24>();
				double num2 = 2.0 / ((double)size - 1.0);
				for (int i = 0; i < 6; i++)
				{
					CubemapFace cubemapFace = (CubemapFace)i;
					int num3 = i * size;
					for (int j = 0; j < size; j++)
					{
						double num4 = (double)j * num2 - 1.0;
						for (int k = 0; k < size; k++)
						{
							double num5 = (double)k * num2 - 1.0;
							Vector3d vector3d = default(Vector3d);
							Vector3d normalized = (cubemapFace switch
							{
								CubemapFace.PositiveX => new Vector3d(1.0, num4, 0.0 - num5), 
								CubemapFace.NegativeX => new Vector3d(-1.0, num4, num5), 
								CubemapFace.PositiveY => new Vector3d(num5, 1.0, 0.0 - num4), 
								CubemapFace.NegativeY => new Vector3d(num5, -1.0, num4), 
								CubemapFace.PositiveZ => new Vector3d(num5, num4, 1.0), 
								CubemapFace.NegativeZ => new Vector3d(0.0 - num5, num4, -1.0), 
								_ => throw new NotSupportedException(), 
							}).normalized;
							byte b = (byte)Mathf.Clamp(Mathd.RoundToInt((GetVertexDataForMap(normalized.x, normalized.y, normalized.z) - _mapMinValue) / _mapValueRange * 255.0), 0, 255);
							rawTextureData[j * num + num3 + k] = new ColorRGB24(b, b, b);
						}
					}
				}
				return texture2D.EncodeToPNG();
			}
			finally
			{
				_mapIgnore = mapIgnore;
				if (!flag)
				{
					OnDestroy();
				}
			}
		}

		public List<FieldInfo> GetCurrentFields()
		{
			if (_typeFieldMap == null)
			{
				_typeFieldMap = new Dictionary<string, List<FieldInfo>>();
			}
			string key = _noiseType.ToString() + _fractalAmplitudeType.ToString() + _fractalLacunarityType.ToString() + _fractalType.ToString() + _fractalWithDerivativeType.ToString() + string.IsNullOrWhiteSpace(_mapName) + _mapNoiseCombine;
			List<FieldInfo> value = null;
			if (!_typeFieldMap.TryGetValue(key, out value))
			{
				value = new List<FieldInfo>();
				_typeFieldMap.Add(key, value);
				GetCurrentNoiseFields(value);
			}
			return value;
		}

		public List<FieldInfo> GetInspectorFields()
		{
			List<FieldInfo> list = new List<FieldInfo>();
			list.AddRange(GetCurrentFields());
			if (_domainWarping == null)
			{
				_domainWarping = new DomainWarping[0];
			}
			list.Add(GetField((VertexDataNoise x) => x._domainWarping));
			return list;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			Vector3d position = input.Position;
			data.Data[_dataIndex] = GetNoise(position.x, position.y, position.z, data.Data, data.CacheData);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			Vector3d position = input.Position;
			data.Data[_dataIndex] = GetNoise(position.x, position.y, position.z, data.Data, data.CommonData.CacheData);
		}

		public override void Initialize(IPlanetData planetData)
		{
			base.Initialize(planetData);
			InitializeCubemapSampler();
			_noise = FastNoise.CreateNoise(_seed);
			_noise.SetNoiseType(FastNoiseType());
			_noise.SetFrequency(_frequency);
			_noise.SetFractalType(_fractalType);
			_noise.SetFractalWithDerivativeType(_fractalWithDerivativeType);
			_noise.SetFractalOctaves(_octaves);
			_noise.SetFractalPowerExponent(_powerExponent);
			_noise.SetSlopeErosionStrength(_slopeErosionStrength);
			_noise.SetInterpolation(_interpolation);
			_noise.SetCellularDistanceFunction(_cellularDistanceFunction);
			_noise.SetCellularReturnType(ConvertCelluarReturnType(_cellularReturnType));
			if (_fractalLacunarityType == FractalLacunarityType.Manual)
			{
				if (_lacunarities.Length != _octaves - 1)
				{
					Debug.LogWarning($"Modifier {GetType().FullName} with name '{base.Name}' has {_lacunarities.Length} " + $"lacunarity values manually set but requires {_octaves - 1}");
					double[] array = new double[_octaves - 1];
					for (int i = 0; i < array.Length; i++)
					{
						if (i < _lacunarities.Length)
						{
							array[i] = _lacunarities[i];
						}
						else
						{
							array[i] = ((i == 0) ? 2.0 : array[i - 1]);
						}
					}
					_noise.SetFractalLacunarities(array);
				}
				else
				{
					_noise.SetFractalLacunarities(_lacunarities);
				}
			}
			else
			{
				_noise.SetFractalLacunarity(_lacunarity);
			}
			if (_fractalAmplitudeType == FractalAmplitudeType.Manual)
			{
				if (_fractalAmplitudes.Length < _octaves)
				{
					Debug.LogWarning($"Modifier {GetType().FullName} with name '{base.Name}' has {_fractalAmplitudes.Length} " + $"amplitude values manually set but requires {_octaves}");
					double[] array2 = new double[_octaves];
					for (int j = 0; j < array2.Length; j++)
					{
						if (j < _fractalAmplitudes.Length)
						{
							array2[j] = _fractalAmplitudes[j];
						}
						else
						{
							array2[j] = ((j == 0) ? 1.0 : (array2[j - 1] * 0.5));
						}
					}
					_noise.SetFractalAmplitudes(array2);
				}
				else
				{
					_noise.SetFractalAmplitudes(_fractalAmplitudes);
				}
			}
			else
			{
				_noise.SetFractalGain(_gain);
			}
			if (_cubemap != null && _mapNoiseCombine && _mapNoiseOctaveSkip > 0)
			{
				_noise.SetFractalOctaveSkipCount(_mapNoiseOctaveSkip);
			}
			if (_domainWarping != null)
			{
				DomainWarping[] domainWarping = _domainWarping;
				for (int k = 0; k < domainWarping.Length; k++)
				{
					domainWarping[k].Initialize();
				}
			}
			else
			{
				_domainWarping = new DomainWarping[0];
			}
			_noiseGenerator = _noise;
		}

		public override void OnCreatedInPlanetStudio(VertexDataPlanetModifier parentModifier)
		{
			base.OnCreatedInPlanetStudio(parentModifier);
			if (_mapColorGradient == null)
			{
				_mapColorGradient = _mapColorGradientDefault;
			}
		}

		public override bool Randomize(RandomizeContext context)
		{
			base.Randomize(context);
			if (!_lockSeed)
			{
				if (context.Flags.HasFlag(PlanetModifierRandomizationFlags.SeedValues))
				{
					_seed = context.GetRandomInt(_seedSyncId);
				}
				if (_domainWarping != null)
				{
					int num = 0;
					DomainWarping[] domainWarping = _domainWarping;
					foreach (DomainWarping obj in domainWarping)
					{
						num++;
						string text = _seedSyncId;
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = text + "_Child_" + num;
						}
						obj.Randomize(context, text);
					}
				}
				return true;
			}
			return false;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			foreach (FieldInfo currentField in GetCurrentFields())
			{
				string text = currentField.Name.TrimStart('_');
				if (currentField.FieldType.HasElementType && currentField.FieldType.GetElementType() == typeof(double))
				{
					xml.SetAttributeValue(text, string.Join(",", ((double[])currentField.GetValue(this)).Select((double x) => DataIO.ToString(x)).ToArray()));
					continue;
				}
				if (currentField.FieldType == typeof(Gradient))
				{
					if (_mapColorGradient != null)
					{
						xml.SetAttribute("mapColorGradient", _mapColorGradient, includeAlphaKeys: false);
					}
					continue;
				}
				object value = currentField.GetValue(this);
				if (!currentField.FieldType.IsClass || value != null)
				{
					xml.SetAttributeValue(text, value);
				}
			}
			if (_domainWarping == null)
			{
				return;
			}
			DomainWarping[] domainWarping = _domainWarping;
			foreach (DomainWarping domainWarping2 in domainWarping)
			{
				if (domainWarping2 != null)
				{
					XElement xElement = new XElement("DomainWarping");
					domainWarping2.SaveXml(xElement);
					xml.Add(xElement);
				}
			}
		}

		protected virtual double GetNoise(double x, double y, double z, double[] data, TerrainGeneratorCacheData cacheData)
		{
			double num = _strength;
			if (_maskDataIndex != -1)
			{
				num *= data[_maskDataIndex];
				if (num <= 0.0)
				{
					return 0.0;
				}
			}
			if (_cubemap == null)
			{
				if (_domainWarping.Length != 0)
				{
					DomainWarping[] domainWarping = _domainWarping;
					foreach (DomainWarping domainWarping2 in domainWarping)
					{
						if (domainWarping2.Enabled)
						{
							domainWarping2.Warp(ref x, ref y, ref z);
						}
					}
				}
				return _noiseGenerator.GetNoise(x, y, z) * num;
			}
			Vector3d normal = new Vector3d(x, y, z);
			float num2 = ((_mapSampleMode == TextureDataSampleMode.Bicubic) ? _cubemap.SampleBicubic(normal, cacheData.MapSampleArray) : _cubemap.SampleBilinear(normal));
			double num3 = (_mapMinValue + (double)num2 * _mapValueRange) * num;
			if (_mapNoiseCombine && _mapNoiseStrength > 0.0)
			{
				if (_domainWarping.Length != 0)
				{
					DomainWarping[] domainWarping = _domainWarping;
					foreach (DomainWarping domainWarping3 in domainWarping)
					{
						if (domainWarping3.Enabled)
						{
							domainWarping3.Warp(ref x, ref y, ref z);
						}
					}
				}
				num3 += _noiseGenerator.GetNoise(x, y, z) * _mapNoiseStrength;
			}
			return num3;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			IFastNoise noise = _noise;
			_noise = null;
			_noiseGenerator = null;
			noise?.Dispose();
			if (_domainWarping != null)
			{
				DomainWarping[] domainWarping = _domainWarping;
				for (int i = 0; i < domainWarping.Length; i++)
				{
					domainWarping[i]?.Dispose();
				}
			}
		}

		protected virtual void OnValidate()
		{
			if (_octaves < 1)
			{
				_octaves = 1;
			}
			if (_fractalAmplitudes == null)
			{
				_fractalAmplitudes = new double[_octaves];
			}
			if (_fractalAmplitudes.Length != _octaves)
			{
				Array.Resize(ref _fractalAmplitudes, _octaves);
			}
			if (_fractalAmplitudeType == FractalAmplitudeType.Default || _fractalAmplitudes.Sum() == 0.0)
			{
				_fractalAmplitudes[0] = 1.0;
				for (int i = 1; i < _octaves; i++)
				{
					_fractalAmplitudes[i] = _fractalAmplitudes[i - 1] * _gain;
				}
			}
			if (_lacunarities == null)
			{
				_lacunarities = new double[_octaves - 1];
			}
			if (_lacunarities.Length != _octaves - 1)
			{
				Array.Resize(ref _lacunarities, _octaves - 1);
			}
			if (_fractalLacunarityType == FractalLacunarityType.Default || _lacunarities.Sum() == 0.0)
			{
				for (int j = 0; j < _octaves - 1; j++)
				{
					_lacunarities[j] = _lacunarity;
				}
			}
			if (_dataIndex == -1 && GetType() == typeof(VertexDataNoise))
			{
				_dataIndex = 0;
			}
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_noiseType = (NoiseType)Enum.Parse(typeof(NoiseType), (string)xml.Attribute("noiseType"), ignoreCase: true);
			string value = (string)xml.Attribute("fractalType");
			_fractalType = ((!string.IsNullOrEmpty(value)) ? ((FractalType)Enum.Parse(typeof(FractalType), value, ignoreCase: true)) : FractalType.FBM);
			string value2 = (string)xml.Attribute("fractalWithDerivativeType");
			_fractalWithDerivativeType = ((!string.IsNullOrEmpty(value2)) ? ((FractalWithDerivativeType)Enum.Parse(typeof(FractalWithDerivativeType), value2, ignoreCase: true)) : FractalWithDerivativeType.IQSlopeErosion);
			string value3 = (string)xml.Attribute("fractalAmplitudeType");
			_fractalAmplitudeType = ((!string.IsNullOrEmpty(value3)) ? ((FractalAmplitudeType)Enum.Parse(typeof(FractalAmplitudeType), value3, ignoreCase: true)) : FractalAmplitudeType.Default);
			string value4 = (string)xml.Attribute("fractalLacunarityType");
			_fractalLacunarityType = ((!string.IsNullOrEmpty(value4)) ? ((FractalLacunarityType)Enum.Parse(typeof(FractalLacunarityType), value4, ignoreCase: true)) : FractalLacunarityType.Default);
			_mapName = (string)xml.Attribute("mapName");
			_mapNoiseCombine = (bool?)xml.Attribute("mapNoiseCombine") == true;
			foreach (FieldInfo currentField in GetCurrentFields())
			{
				string text = currentField.Name.TrimStart('_');
				if (currentField.FieldType == typeof(int))
				{
					int? num = (int?)xml.Attribute(text);
					currentField.SetValue(this, num.HasValue ? ((object)num.GetValueOrDefault()) : currentField.GetValue(this));
					continue;
				}
				if (currentField.FieldType == typeof(double))
				{
					double? num2 = (double?)xml.Attribute(text);
					currentField.SetValue(this, num2.HasValue ? ((object)num2.GetValueOrDefault()) : currentField.GetValue(this));
					continue;
				}
				if (currentField.FieldType == typeof(bool))
				{
					bool? flag = (bool?)xml.Attribute(text);
					currentField.SetValue(this, flag.HasValue ? ((object)(flag == true)) : currentField.GetValue(this));
					continue;
				}
				if (currentField.FieldType.IsEnum)
				{
					currentField.SetValue(this, Enum.Parse(currentField.FieldType, ((string)xml.Attribute(text)) ?? currentField.GetValue(this).ToString(), ignoreCase: true));
					continue;
				}
				if (currentField.FieldType.HasElementType && currentField.FieldType.GetElementType() == typeof(double))
				{
					currentField.SetValue(this, (from x in ((string)xml.Attribute(text)).Split(',')
						select DataIO.ParseDouble(x)).ToArray());
					continue;
				}
				if (currentField.FieldType == typeof(string))
				{
					currentField.SetValue(this, (string)xml.Attribute(text));
					continue;
				}
				if (currentField.FieldType == typeof(Gradient))
				{
					currentField.SetValue(this, xml.GetGradientAttribute("mapColorGradient", includeAlphaKeys: false, _mapColorGradientDefault));
					continue;
				}
				throw new NotSupportedException();
			}
			if (_mapColorGradient == null)
			{
				_mapColorGradient = _mapColorGradientDefault;
			}
			XElement[] array = xml.Elements("DomainWarping").ToArray();
			_domainWarping = new DomainWarping[array.Length];
			if (array.Length != 0)
			{
				for (int num3 = 0; num3 < array.Length; num3++)
				{
					_domainWarping[num3] = new DomainWarping();
					_domainWarping[num3].RestoreXml(array[num3]);
				}
			}
		}

		private static CellularReturnType ConvertCelluarReturnType(CustomCellularReturnType cellularReturnType)
		{
			return cellularReturnType switch
			{
				CustomCellularReturnType.CellValue => CellularReturnType.CellValue, 
				CustomCellularReturnType.Distance => CellularReturnType.Distance, 
				CustomCellularReturnType.Distance2 => CellularReturnType.Distance2, 
				CustomCellularReturnType.Distance2Add => CellularReturnType.Distance2Add, 
				CustomCellularReturnType.Distance2Sub => CellularReturnType.Distance2Sub, 
				CustomCellularReturnType.Distance2Mul => CellularReturnType.Distance2Mul, 
				CustomCellularReturnType.Distance2Div => CellularReturnType.Distance2Div, 
				CustomCellularReturnType.MaskedDistance => CellularReturnType.MaskedDistance, 
				_ => throw new NotImplementedException($"The cellular return type {cellularReturnType} is not supported."), 
			};
		}

		private ModApi.Packages.FastNoise.NoiseType FastNoiseType()
		{
			return _noiseType switch
			{
				NoiseType.Cellular => ModApi.Packages.FastNoise.NoiseType.Cellular, 
				NoiseType.Cubic => ModApi.Packages.FastNoise.NoiseType.Cubic, 
				NoiseType.CubicFractal => ModApi.Packages.FastNoise.NoiseType.CubicFractal, 
				NoiseType.Perlin => ModApi.Packages.FastNoise.NoiseType.Perlin, 
				NoiseType.PerlinFractal => ModApi.Packages.FastNoise.NoiseType.PerlinFractal, 
				NoiseType.Value => ModApi.Packages.FastNoise.NoiseType.Value, 
				NoiseType.ValueFractal => ModApi.Packages.FastNoise.NoiseType.ValueFractal, 
				NoiseType.ValueFractalWithDerivative => ModApi.Packages.FastNoise.NoiseType.ValueFractalWithDerivative, 
				NoiseType.WhiteNoise => ModApi.Packages.FastNoise.NoiseType.WhiteNoise, 
				_ => throw new NotSupportedException($"{_noiseType} not supported."), 
			};
		}

		private void GetCurrentNoiseFields(List<FieldInfo> fields)
		{
			fields.Add(GetField((VertexDataNoise x) => x._noiseType));
			fields.Add(GetField((VertexDataNoise x) => x._maskDataIndex));
			fields.Add(GetField((VertexDataNoise x) => x._seed));
			fields.Add(GetField((VertexDataNoise x) => x._lockSeed));
			fields.Add(GetField((VertexDataNoise x) => x._seedSyncId));
			fields.Add(GetField((VertexDataNoise x) => x._frequency));
			fields.Add(GetField((VertexDataNoise x) => x._strength));
			bool flag = false;
			switch (_noiseType)
			{
			case NoiseType.Cellular:
				fields.Add(GetField((VertexDataNoise x) => x._cellularDistanceFunction));
				fields.Add(GetField((VertexDataNoise x) => x._cellularReturnType));
				break;
			case NoiseType.CellularLN:
				fields.Add(GetField((VertexDataNoise x) => x._displacement));
				fields.Add(GetField((VertexDataNoise x) => x._useDistance));
				break;
			case NoiseType.Perlin:
			case NoiseType.Value:
				fields.Add(GetField((VertexDataNoise x) => x._interpolation));
				break;
			case NoiseType.PerlinFractal:
			case NoiseType.ValueFractal:
				flag = true;
				fields.Add(GetField((VertexDataNoise x) => x._fractalType));
				fields.Add(GetField((VertexDataNoise x) => x._octaves));
				fields.Add(GetField((VertexDataNoise x) => x._fractalLacunarityType));
				fields.Add(GetField((VertexDataNoise x) => x._fractalAmplitudeType));
				fields.Add(GetField((VertexDataNoise x) => x._interpolation));
				break;
			case NoiseType.CubicFractal:
				flag = true;
				fields.Add(GetField((VertexDataNoise x) => x._fractalType));
				fields.Add(GetField((VertexDataNoise x) => x._octaves));
				fields.Add(GetField((VertexDataNoise x) => x._fractalLacunarityType));
				fields.Add(GetField((VertexDataNoise x) => x._fractalAmplitudeType));
				break;
			case NoiseType.ValueFractalWithDerivative:
				flag = true;
				fields.Add(GetField((VertexDataNoise x) => x._fractalWithDerivativeType));
				fields.Add(GetField((VertexDataNoise x) => x._octaves));
				fields.Add(GetField((VertexDataNoise x) => x._fractalLacunarityType));
				fields.Add(GetField((VertexDataNoise x) => x._fractalAmplitudeType));
				break;
			}
			if (fields.Contains(GetField((VertexDataNoise x) => x._fractalType)))
			{
				switch (_fractalType)
				{
				case FractalType.FBMPowerV1:
				case FractalType.FBMPowerV2:
				case FractalType.FBMPowerV3:
				case FractalType.BillowPowerV1:
				case FractalType.BillowPowerV2:
				case FractalType.BillowPowerV3:
				case FractalType.RigidMultiPowerV1:
				case FractalType.RigidMultiPowerV2:
				case FractalType.RigidMultiPowerV3:
					fields.Add(GetField((VertexDataNoise x) => x._powerExponent));
					break;
				}
			}
			if (fields.Contains(GetField((VertexDataNoise x) => x._fractalWithDerivativeType)))
			{
				switch (_fractalWithDerivativeType)
				{
				case FractalWithDerivativeType.IQSlopeErosion:
					fields.Add(GetField((VertexDataNoise x) => x._slopeErosionStrength));
					break;
				case FractalWithDerivativeType.GDCSwiss:
					fields.Remove(GetField((VertexDataNoise x) => x._fractalAmplitudeType));
					fields.Add(GetField((VertexDataNoise x) => x._gain));
					break;
				}
			}
			if (fields.Contains(GetField((VertexDataNoise x) => x._fractalLacunarityType)))
			{
				int index = fields.IndexOf(GetField((VertexDataNoise x) => x._fractalLacunarityType)) + 1;
				switch (_fractalLacunarityType)
				{
				case FractalLacunarityType.Default:
					fields.Insert(index, GetField((VertexDataNoise x) => x._lacunarity));
					break;
				case FractalLacunarityType.Manual:
					fields.Insert(index, GetField((VertexDataNoise x) => x._lacunarities));
					break;
				}
			}
			if (fields.Contains(GetField((VertexDataNoise x) => x._fractalAmplitudeType)))
			{
				int index2 = fields.IndexOf(GetField((VertexDataNoise x) => x._fractalAmplitudeType)) + 1;
				switch (_fractalAmplitudeType)
				{
				case FractalAmplitudeType.Default:
					fields.Insert(index2, GetField((VertexDataNoise x) => x._gain));
					break;
				case FractalAmplitudeType.Manual:
					fields.Insert(index2, GetField((VertexDataNoise x) => x._fractalAmplitudes));
					break;
				}
			}
			fields.Add(GetField((VertexDataNoise x) => x._dataIndex));
			fields.Add(GetField((VertexDataNoise x) => x._mapName));
			if (string.IsNullOrWhiteSpace(_mapName))
			{
				return;
			}
			fields.Add(GetField((VertexDataNoise x) => x._mapMinValue));
			fields.Add(GetField((VertexDataNoise x) => x._mapMaxValue));
			fields.Add(GetField((VertexDataNoise x) => x._mapSampleMode));
			fields.Add(GetField((VertexDataNoise x) => x._mapColorGradient));
			fields.Add(GetField((VertexDataNoise x) => x._mapIgnore));
			fields.Add(GetField((VertexDataNoise x) => x._mapNoiseCombine));
			if (!_mapNoiseCombine)
			{
				return;
			}
			if (flag)
			{
				fields.Add(GetField((VertexDataNoise x) => x._mapNoiseOctaveSkip));
			}
			fields.Add(GetField((VertexDataNoise x) => x._mapNoiseStrength));
		}

		private FieldInfo GetField<T>(Expression<Func<VertexDataNoise, T>> fieldSelector)
		{
			return (FieldInfo)((MemberExpression)fieldSelector.Body).Member;
		}

		private double GetVertexDataForMap(double x, double y, double z)
		{
			if (_domainWarping != null)
			{
				DomainWarping[] domainWarping = _domainWarping;
				foreach (DomainWarping domainWarping2 in domainWarping)
				{
					if (domainWarping2.Enabled)
					{
						domainWarping2.Warp(ref x, ref y, ref z);
					}
				}
			}
			return _noiseGenerator.GetNoise(x, y, z);
		}

		private void InitializeCubemapSampler()
		{
			_mapValueRange = _mapMaxValue - _mapMinValue;
			string mapId = MapId;
			if (_mapIgnore || mapId == null)
			{
				return;
			}
			Texture2D texture2D = ((mapId == PlanetBrushTextureOverride.MapId) ? PlanetBrushTextureOverride.GetTexture() : null);
			if (texture2D != null)
			{
				_cubemap = new SingleChannelByteCubemapDataSampler(texture2D, 0);
				UnityEngine.Object.Destroy(texture2D);
				return;
			}
			CelestialFile supportFile = base.TerrainData.PlanetData.FileData.GetSupportFile(mapId);
			if (supportFile == null)
			{
				return;
			}
			string filePath = base.TerrainData.PlanetData.GeneratedData.GetFilePath(mapId, createDirectory: true);
			if (File.Exists(filePath))
			{
				using (FileStream input = File.OpenRead(filePath))
				{
					using BinaryReader reader = new BinaryReader(input);
					_cubemap = SingleChannelByteCubemapDataSampler.Load(reader);
					return;
				}
			}
			Texture2D texture2D2 = supportFile.LoadTexture(mipmaps: false, linear: true, markNonReadable: false);
			if (texture2D2 == null)
			{
				return;
			}
			SingleChannelByteCubemapDataSampler singleChannelByteCubemapDataSampler = new SingleChannelByteCubemapDataSampler(texture2D2, 0);
			using (FileStream output = new FileStream(filePath, FileMode.Create, FileAccess.Write))
			{
				using BinaryWriter writer = new BinaryWriter(output);
				singleChannelByteCubemapDataSampler.Save(writer);
			}
			UnityEngine.Object.Destroy(texture2D2);
			_cubemap = singleChannelByteCubemapDataSampler;
		}
	}
}
