using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetWaterConfig
	{
		private static Gradient _defaultWaterColorGradient;

		[SerializeField]
		private float _temperature = 290f;

		[SerializeField]
		private float _density = 1000f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _emissiveness;

		[SerializeField]
		private Color _foamColor = new Color(1f, 1f, 1f);

		[SerializeField]
		private float _foamDepth;

		[SerializeField]
		[Range(0f, 255f)]
		private int _foamStrength;

		[SerializeField]
		[Range(0f, 1f)]
		private float _fresnelBias;

		[SerializeField]
		[Range(0f, 1f)]
		private float _metallicness;

		[Range(0f, 100f)]
		[SerializeField]
		[Tooltip("The reflection distortion value. The higher the value, the more distortion due to reflection.")]
		private float _reflectionDistortion = 20f;

		[SerializeField]
		[Range(0f, 255f)]
		private int _reflectionStrength;

		[Range(0f, 4f)]
		[SerializeField]
		[Tooltip("The refraction distortion value. The higher the value, the more distortion due to refraction.")]
		private float _refractionDistortion = 2f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _smoothness;

		[SerializeField]
		[Range(0f, 255f)]
		private int _textureStrength;

		[SerializeField]
		private float _transparencyDepth;

		[SerializeField]
		[Range(0f, 255f)]
		private int _transparencyDepthScale;

		[SerializeField]
		[Range(0f, 255f)]
		private int _transparencyStrength;

		[SerializeField]
		[ColorUsage(false, true)]
		private Color _underwaterColor;

		[SerializeField]
		private float _underwaterColorIntensity;

		[SerializeField]
		[ColorUsage(false, true)]
		private Color _underwaterDarkColor;

		[SerializeField]
		private float _underwaterLightFadeDepth;

		[SerializeField]
		private float _underwaterLightFadeDistance;

		[SerializeField]
		private bool _useDefaultConfig = true;

		[SerializeField]
		[GradientUsage(true)]
		private Gradient _waterColorGradient;

		[SerializeField]
		private double _waterColorGradientMaxDepth;

		[SerializeField]
		private float _waveAmplitude;

		[SerializeField]
		[Range(0f, 255f)]
		private int _waveAmplitudeScale;

		[SerializeField]
		private float _waveLength;

		[SerializeField]
		private float _waveSpeed;

		public float Emissiveness
		{
			get
			{
				return _emissiveness;
			}
			set
			{
				_emissiveness = value;
			}
		}

		public float Temperature
		{
			get
			{
				return _temperature;
			}
			set
			{
				_temperature = value;
			}
		}

		public float Density
		{
			get
			{
				return _density;
			}
			set
			{
				_density = value;
			}
		}

		public Color FoamColor
		{
			get
			{
				return _foamColor;
			}
			set
			{
				_foamColor = value;
			}
		}

		public float FoamDepth
		{
			get
			{
				return _foamDepth;
			}
			set
			{
				_foamDepth = value;
			}
		}

		public int FoamStrength
		{
			get
			{
				return _foamStrength;
			}
			set
			{
				_foamStrength = value;
			}
		}

		public float FresnelBias
		{
			get
			{
				return _fresnelBias;
			}
			set
			{
				_fresnelBias = value;
			}
		}

		public float Metallicness
		{
			get
			{
				return _metallicness;
			}
			set
			{
				_metallicness = value;
			}
		}

		public float ReflectionDistortion
		{
			get
			{
				return _reflectionDistortion;
			}
			set
			{
				_reflectionDistortion = value;
			}
		}

		public int ReflectionStrength
		{
			get
			{
				return _reflectionStrength;
			}
			set
			{
				_reflectionStrength = value;
			}
		}

		public float RefractionDistortion
		{
			get
			{
				return _refractionDistortion;
			}
			set
			{
				_refractionDistortion = value;
			}
		}

		public float Smoothness
		{
			get
			{
				return _smoothness;
			}
			set
			{
				_smoothness = value;
			}
		}

		public int TextureStrength
		{
			get
			{
				return _textureStrength;
			}
			set
			{
				_textureStrength = value;
			}
		}

		public float TransparencyDepth
		{
			get
			{
				return _transparencyDepth;
			}
			set
			{
				_transparencyDepth = value;
			}
		}

		public int TransparencyDepthScale
		{
			get
			{
				return _transparencyDepthScale;
			}
			set
			{
				_transparencyDepthScale = value;
			}
		}

		public int TransparencyStrength
		{
			get
			{
				return _transparencyStrength;
			}
			set
			{
				_transparencyStrength = value;
			}
		}

		public Color UnderwaterColor
		{
			get
			{
				return _underwaterColor;
			}
			set
			{
				_underwaterColor = value;
				UnderwaterColorLinear = value.linear;
			}
		}

		public float UnderwaterColorIntensity
		{
			get
			{
				return _underwaterColorIntensity;
			}
			set
			{
				_underwaterColorIntensity = value;
			}
		}

		public Color UnderwaterColorLinear { get; private set; }

		public Color UnderwaterDarkColor
		{
			get
			{
				return _underwaterDarkColor;
			}
			set
			{
				_underwaterDarkColor = value;
				UnderwaterDarkColorLinear = value.linear;
			}
		}

		public Color UnderwaterDarkColorLinear { get; private set; }

		public float UnderwaterLightFadeDepth
		{
			get
			{
				return _underwaterLightFadeDepth;
			}
			set
			{
				_underwaterLightFadeDepth = value;
			}
		}

		public float UnderwaterLightFadeDistance
		{
			get
			{
				return _underwaterLightFadeDistance;
			}
			set
			{
				_underwaterLightFadeDistance = value;
			}
		}

		public bool UseDefaultConfig
		{
			get
			{
				return _useDefaultConfig;
			}
			set
			{
				_useDefaultConfig = value;
			}
		}

		public Gradient WaterColorGradient
		{
			get
			{
				return _waterColorGradient;
			}
			set
			{
				_waterColorGradient = value;
				WaterColorGradientLinear = value.ToLinear();
			}
		}

		public Gradient WaterColorGradientLinear { get; private set; }

		public double WaterColorGradientMaxDepth
		{
			get
			{
				return _waterColorGradientMaxDepth;
			}
			set
			{
				_waterColorGradientMaxDepth = value;
			}
		}

		public float WaveAmplitude
		{
			get
			{
				return _waveAmplitude;
			}
			set
			{
				_waveAmplitude = value;
			}
		}

		public int WaveAmplitudeScale
		{
			get
			{
				return _waveAmplitudeScale;
			}
			set
			{
				_waveAmplitudeScale = value;
			}
		}

		public float WaveLength
		{
			get
			{
				return _waveLength;
			}
			set
			{
				_waveLength = value;
			}
		}

		public float WaveSpeed
		{
			get
			{
				return _waveSpeed;
			}
			set
			{
				_waveSpeed = value;
			}
		}

		public static PlanetWaterConfig CreateFromXml(XElement xml, PlanetWaterConfig defaultConfig)
		{
			bool flag = defaultConfig == null;
			bool flag2 = !flag && xml.GetBoolAttribute("useDefaultConfig", defaultValue: true);
			return new PlanetWaterConfig
			{
				UseDefaultConfig = flag2,
				Temperature = (flag2 ? defaultConfig._temperature : xml.GetFloatAttribute("temperature", 290f)),
				Density = (flag2 ? defaultConfig._density : xml.GetFloatAttribute("density", 1000f)),
				WaterColorGradient = (flag2 ? defaultConfig._waterColorGradient.Clone() : Utilities.GetGradientAttribute(xml, "waterColorGradient", includeAlphaKeys: false, GetDefaultWaterColorGradient())),
				WaterColorGradientMaxDepth = (flag2 ? defaultConfig._waterColorGradientMaxDepth : ((double)xml.GetFloatAttribute("waterColorGradientMaxDepth", 400f))),
				Emissiveness = (flag2 ? defaultConfig._emissiveness : xml.GetFloatAttribute("emissiveness")),
				Metallicness = (flag2 ? defaultConfig._metallicness : xml.GetFloatAttribute("metallicness")),
				Smoothness = (flag2 ? defaultConfig._smoothness : xml.GetFloatAttribute("smoothness")),
				WaveAmplitudeScale = (flag2 ? defaultConfig._waveAmplitudeScale : Mathf.Clamp(xml.GetIntAttribute("waveAmplitudeScale", 100), 0, 200)),
				TransparencyDepthScale = (flag2 ? defaultConfig._transparencyDepthScale : Mathf.Clamp(xml.GetIntAttribute("transparencyDepthScale", 100), 0, 200)),
				TransparencyStrength = (flag2 ? defaultConfig._transparencyStrength : Mathf.Clamp(xml.GetIntAttribute("transparencyStrength", 15), 0, 100)),
				ReflectionStrength = (flag2 ? defaultConfig._reflectionStrength : Mathf.Clamp(xml.GetIntAttribute("reflectionStrength", 50), 0, 100)),
				FoamStrength = (flag2 ? defaultConfig._foamStrength : Mathf.Clamp(xml.GetIntAttribute("foamStrength", 50), 0, 100)),
				TextureStrength = (flag2 ? defaultConfig._textureStrength : Mathf.Clamp(xml.GetIntAttribute("textureStrength", 100), 0, 200)),
				UnderwaterColor = (flag2 ? defaultConfig._underwaterColor : xml.GetColorAttribute("underwaterColor", new Color(0.05882351f, 0.3411765f, 0.5882353f), XmlColorFormat.FloatRGB)),
				UnderwaterDarkColor = (flag2 ? defaultConfig._underwaterDarkColor : xml.GetColorAttribute("underwaterDarkColor", Color.black, XmlColorFormat.FloatRGB)),
				UnderwaterLightFadeDepth = (flag2 ? defaultConfig._underwaterLightFadeDepth : xml.GetFloatAttribute("underwaterLightFadeDepth", 150f)),
				UnderwaterLightFadeDistance = (flag2 ? defaultConfig._underwaterLightFadeDistance : xml.GetFloatAttribute("underwaterLightFadeDepth", 100f)),
				UnderwaterColorIntensity = (flag2 ? defaultConfig._underwaterColorIntensity : xml.GetFloatAttribute("underwaterColorIntensity", 0.5f)),
				ReflectionDistortion = ((!flag) ? defaultConfig._reflectionDistortion : xml.GetFloatAttribute("reflectionDistortion", 20f)),
				RefractionDistortion = ((!flag) ? defaultConfig._refractionDistortion : xml.GetFloatAttribute("refractionDistortion", 2f)),
				TransparencyDepth = ((!flag) ? defaultConfig._transparencyDepth : xml.GetFloatAttribute("transparencyDepth", 100f)),
				FresnelBias = ((!flag) ? defaultConfig._fresnelBias : xml.GetFloatAttribute("fresnelBias", 0.2f)),
				FoamDepth = ((!flag) ? defaultConfig._foamDepth : xml.GetFloatAttribute("foamDepth", 0.35f)),
				FoamColor = ((!flag) ? defaultConfig._foamColor : xml.GetColorAttribute("foamColor", Color.white, XmlColorFormat.FloatRGB)),
				WaveAmplitude = ((!flag) ? defaultConfig._waveAmplitude : xml.GetFloatAttribute("waveAmplitude", 0.5f)),
				WaveLength = ((!flag) ? defaultConfig._waveLength : xml.GetFloatAttribute("waveLength", 50f)),
				WaveSpeed = ((!flag) ? defaultConfig._waveSpeed : xml.GetFloatAttribute("waveSpeed", 2f))
			};
		}

		public void ApplyLegacyWaterSettings(Gradient colorGradient, float colorGradientMaxDepth, float specularity, float transparencyDepth, int transparencyStrength, int foamStrength, float foamDepth, Color foamColor)
		{
			WaterColorGradient = colorGradient.Clone();
			WaterColorGradientMaxDepth = colorGradientMaxDepth;
			Smoothness = specularity;
			TransparencyDepth = transparencyDepth;
			TransparencyStrength = transparencyStrength;
			FoamStrength = foamStrength;
			FoamDepth = foamDepth;
			FoamColor = foamColor;
		}

		public IGroupModel[] BuildInspectorModel(bool isPlanetDefaultConfig, IGroupModel groupModel = null)
		{
			IGroupModel groupModel2 = groupModel ?? new GroupModel("Water");
			GroupModel groupColor = new GroupModel("Color");
			GroupModel groupTexture = new GroupModel("Texture");
			GroupModel groupReflections = new GroupModel("Reflections");
			GroupModel groupTransparency = new GroupModel("Transparency");
			GroupModel groupFoam = new GroupModel("Foam");
			GroupModel groupWaves = new GroupModel("Waves");
			GroupModel groupUnderwater = new GroupModel("Underwater");
			Action<bool> action = delegate(bool value)
			{
				_useDefaultConfig = value;
				groupColor.Visible = !value;
				groupTexture.Visible = !value;
				groupReflections.Visible = !value;
				groupTransparency.Visible = !value;
				groupFoam.Visible = !value;
				groupWaves.Visible = !value;
				groupUnderwater.Visible = !value;
			};
			_ = groupModel2.AddAndBuild(new ToggleModel("Use Defaults", () => _useDefaultConfig, action)).Build(delegate(ToggleModel x)
			{
				x.Visible = !isPlanetDefaultConfig;
			}).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "If enabled, global water settings will be used for this biome. If false, this biome will override some of the globally defined water settings.";
			})
				.Model;
			Func<bool> visibleIfDefault = () => isPlanetDefaultConfig;
			groupColor.AddAndBuild(new NumericInputModel("Temperature", () => Temperature, delegate(double x)
			{
				_temperature = (float)x;
			}, 1.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "Sets the temperature of the fluid in Kelvin.";
			});
			groupColor.AddAndBuild(new NumericInputModel("Density", () => Density, delegate(double x)
			{
				_density = (float)x;
			}, 1.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "Sets the density of the fluid in kg per m3.";
			});
			groupModel2.Add(groupColor);
			groupColor.AddAndBuild(new GradientModel("Color Gradient", () => WaterColorGradient, delegate(Gradient x)
			{
				WaterColorGradient = x;
			}, hasAlpha: false, allowHDR: true)).Build(delegate(GradientModel x)
			{
				x.Tooltip = "The color gradient of the water. Water color is a gradient based on depth. The max depth for the gradient is configured with the setting below.";
			});
			groupColor.AddAndBuild(new NumericInputModel("Color Gradient Depth", () => WaterColorGradientMaxDepth, delegate(double x)
			{
				_waterColorGradientMaxDepth = x;
			}, 1.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "Sets the depth in meters at which the color gradient evaluates at its max value (on the right of the gradient).";
			});
			groupColor.AddAndBuild(new SliderModel("Specularity", () => Smoothness, delegate(float x)
			{
				Smoothness = x;
			})).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The specularity of the water.";
			});
			groupColor.AddAndBuild(new SliderModel("Metallicness", () => Metallicness, delegate(float x)
			{
				Metallicness = x;
			})).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The metallicness of the water from a visual standpoint.";
			});
			groupColor.AddAndBuild(new SliderModel("Emissiveness", () => Emissiveness, delegate(float x)
			{
				Emissiveness = x;
			})).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The emissivity of the water. At 100% emissiveness, the water is unaffected by light.";
			});
			groupModel2.Add(groupTexture);
			groupTexture.AddAndBuild(new SliderModel("Texture Strength", () => TextureStrength / 10, delegate(float x)
			{
				TextureStrength = (int)x * 10;
			}, 0f, 20f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v * 10f}%";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "Reduces or increases the strength of the water texture.";
			});
			groupModel2.Add(groupReflections);
			groupReflections.AddAndBuild(new SliderModel("Reflection Strength", () => ReflectionStrength, delegate(float x)
			{
				ReflectionStrength = (int)x;
			}, 0f, 100f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v}%";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "Controls the strength of the terrain and craft reflections on the water's surface.";
			});
			groupReflections.AddAndBuild(new SliderModel("Reflection Distortion", () => ReflectionDistortion, delegate(float x)
			{
				ReflectionDistortion = x;
			}, 0f, 40f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{Mathf.RoundToInt(v * 5f)}%";
			}).Build(delegate(SliderModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			})
				.Build(delegate(SliderModel x)
				{
					x.Tooltip = "The higher the value, the more distortion due in the water's reflections.";
				});
			groupReflections.AddAndBuild(new SliderModel("Fresnel Bias", () => FresnelBias, delegate(float x)
			{
				FresnelBias = x;
			})).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v:F2}";
			}).Build(delegate(SliderModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			})
				.Build(delegate(SliderModel x)
				{
					x.Tooltip = "The higher this value, the stronger the reflections will be at a given viewing angle.";
				});
			groupModel2.Add(groupTransparency);
			groupTransparency.AddAndBuild(new FloatInputModel("Transparency Depth", () => TransparencyDepth, delegate(float x)
			{
				TransparencyDepth = x;
			}, 0f)).Build(delegate(FloatInputModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The depth in meters at which the water's transparency fully fades out to opaque.";
			});
			groupTransparency.AddAndBuild(new SliderModel("Transparency Depth Scale", () => TransparencyDepthScale, delegate(float x)
			{
				TransparencyDepthScale = (int)x;
			}, 0f, 200f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v}%";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "A scalar applied to the transparency depth value. This can be overridden per biome.";
			});
			groupTransparency.AddAndBuild(new SliderModel("Transparency Strength", () => TransparencyStrength, delegate(float x)
			{
				TransparencyStrength = (int)x;
			}, 0f, 100f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v}%";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "Controls the strength of the water transparency. The higher the value, the more transparent the water becomes.";
			});
			groupTransparency.AddAndBuild(new SliderModel("Refraction Distortion", () => (int)(RefractionDistortion * 25f), delegate(float x)
			{
				RefractionDistortion = x / 25f;
			}, 0f, 100f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v * 2f}%";
			}).Build(delegate(SliderModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			})
				.Build(delegate(SliderModel x)
				{
					x.Tooltip = "The higher the value, the more distortion in transparent water due to refraction.";
				});
			groupModel2.Add(groupFoam);
			groupFoam.AddAndBuild(new ColorModel("Foam Color", () => FoamColor, delegate(Color x)
			{
				FoamColor = x;
			})).Build(delegate(ColorModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			}).Build(delegate(ColorModel x)
			{
				x.Tooltip = "The color of the water foam which is applied on top of reflection/refraction in very shallow water.";
			});
			groupFoam.AddAndBuild(new FloatInputModel("Foam Depth", () => FoamDepth, delegate(float x)
			{
				FoamDepth = x;
			}, 0f)).Build(delegate(FloatInputModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The maximum depth at which foam is applied.";
			});
			groupFoam.AddAndBuild(new SliderModel("Foam Strength", () => FoamStrength / 10, delegate(float x)
			{
				FoamStrength = (int)x * 10;
			}, 0f, 10f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v * 10f}%";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The strength of the foam color.";
			});
			groupModel2.Add(groupWaves);
			groupWaves.AddAndBuild(new FloatInputModel("Wave Speed", () => WaveSpeed, delegate(float x)
			{
				WaveSpeed = x;
			}, 0f)).Build(delegate(FloatInputModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The movement speed of the waves.";
			});
			groupWaves.AddAndBuild(new FloatInputModel("Wave Length", () => WaveLength, delegate(float x)
			{
				WaveLength = x;
			}, 0f)).Build(delegate(FloatInputModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The length of the waves.";
			});
			groupWaves.AddAndBuild(new FloatInputModel("Wave Amplitude", () => WaveAmplitude, delegate(float x)
			{
				WaveAmplitude = x;
			}, 0f)).Build(delegate(FloatInputModel x)
			{
				x.DetermineVisibility = visibleIfDefault;
			}).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The height of the waves.";
			});
			groupWaves.AddAndBuild(new SliderModel("Wave Amplitude Scale", () => WaveAmplitudeScale, delegate(float x)
			{
				WaveAmplitudeScale = (int)x;
			}, 0f, 200f, wholeNumbers: true, allowManualInput: false)).Build(delegate(SliderModel x)
			{
				x.ValueFormatter = (float v) => $"{v}%";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "A scalar applied to the wave amplitude. This can be overridden per biome.";
			});
			groupModel2.Add(groupUnderwater);
			groupUnderwater.AddAndBuild(new ColorModel("Color", () => UnderwaterColor, delegate(Color x)
			{
				UnderwaterColor = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: false, allowHDR: true)).Build(delegate(ColorModel x)
			{
				x.Tooltip = "The underwater color.";
			});
			groupUnderwater.AddAndBuild(new ColorModel("Dark Color", () => UnderwaterDarkColor, delegate(Color x)
			{
				UnderwaterDarkColor = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: false, allowHDR: true)).Build(delegate(ColorModel x)
			{
				x.Tooltip = "The underwater color used when the light is no longer visible.";
			});
			groupUnderwater.AddAndBuild(new FloatInputModel("Color Intensity", () => UnderwaterColorIntensity, delegate(float x)
			{
				UnderwaterColorIntensity = x;
			}, 0f, 1f)).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The intensity of the underwater color.";
			});
			groupUnderwater.AddAndBuild(new FloatInputModel("Light Fade Depth", () => UnderwaterLightFadeDepth, delegate(float x)
			{
				UnderwaterLightFadeDepth = x;
			}, 1f)).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The depth in meters at which the light from the sun can no longer pass.";
			});
			groupUnderwater.AddAndBuild(new FloatInputModel("Light Fade Distance", () => UnderwaterLightFadeDistance, delegate(float x)
			{
				UnderwaterLightFadeDistance = x;
			}, 1f)).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The distance in meters from the camera at which underwater vision fades.";
			});
			action(_useDefaultConfig);
			if (groupModel == null)
			{
				return new IGroupModel[1] { groupModel2 };
			}
			return new IGroupModel[7] { groupColor, groupTexture, groupReflections, groupTransparency, groupFoam, groupWaves, groupUnderwater };
		}

		public void OnValidate()
		{
			UpdateLinearColors();
		}

		public XElement SaveXml(XElement xml, bool isPlanetDefaultConfig)
		{
			xml.SetAttributeValue("useDefaultConfig", UseDefaultConfig);
			if (!UseDefaultConfig)
			{
				xml.SetAttributeValue("temperature", _temperature);
				xml.SetAttributeValue("density", _density);
				Utilities.SetGradientAttribute(xml, "waterColorGradient", includeAlphaKeys: false, WaterColorGradient);
				xml.SetAttributeValue("waterColorGradientMaxDepth", WaterColorGradientMaxDepth);
				xml.SetAttributeValue("emissiveness", _emissiveness);
				xml.SetAttributeValue("metallicness", _metallicness);
				xml.SetAttributeValue("smoothness", _smoothness);
				xml.SetAttributeValue("waveAmplitudeScale", _waveAmplitudeScale);
				xml.SetAttributeValue("transparencyDepthScale", _transparencyDepthScale);
				xml.SetAttributeValue("transparencyStrength", _transparencyStrength);
				xml.SetAttributeValue("reflectionStrength", _reflectionStrength);
				xml.SetAttributeValue("foamStrength", _foamStrength);
				xml.SetAttributeValue("textureStrength", _textureStrength);
				xml.SetAttribute("underwaterColor", UnderwaterColor, XmlColorFormat.FloatRGB);
				xml.SetAttribute("underwaterDarkColor", UnderwaterDarkColor, XmlColorFormat.FloatRGB);
				xml.SetAttributeValue("underwaterLightFadeDepth", UnderwaterLightFadeDepth);
				xml.SetAttributeValue("underwaterLightFadeDistance", UnderwaterLightFadeDistance);
				xml.SetAttributeValue("underwaterColorIntensity", UnderwaterColorIntensity);
			}
			if (isPlanetDefaultConfig)
			{
				xml.SetAttributeValue("reflectionDistortion", _reflectionDistortion);
				xml.SetAttributeValue("refractionDistortion", _refractionDistortion);
				xml.SetAttributeValue("transparencyDepth", _transparencyDepth);
				xml.SetAttributeValue("fresnelBias", _fresnelBias);
				xml.SetAttributeValue("foamDepth", _foamDepth);
				xml.SetAttribute("foamColor", _foamColor, XmlColorFormat.FloatRGB);
				xml.SetAttributeValue("waveAmplitude", _waveAmplitude);
				xml.SetAttributeValue("waveLength", _waveLength);
				xml.SetAttributeValue("waveSpeed", _waveSpeed);
			}
			return xml;
		}

		public void UpdateCameraPositionData(PlanetVertexData vertexData, IPlanetTerrainData terrainData)
		{
			_underwaterColor = new Color(0f, 0f, 0f, 0f);
			_underwaterDarkColor = new Color(0f, 0f, 0f, 0f);
			_underwaterLightFadeDepth = 0f;
			_underwaterLightFadeDistance = 0f;
			_underwaterColorIntensity = 0f;
			float num = 0f;
			PlanetVertexBiomeData[] biomes = vertexData.Biomes;
			foreach (PlanetVertexBiomeData planetVertexBiomeData in biomes)
			{
				float strength = planetVertexBiomeData.Strength;
				if (strength > 0f)
				{
					PlanetWaterConfig waterConfig = terrainData.Biomes[planetVertexBiomeData.BiomeIndex].WaterConfig;
					_underwaterColor += waterConfig._underwaterColor * strength;
					_underwaterDarkColor += waterConfig._underwaterDarkColor * strength;
					_underwaterLightFadeDepth += waterConfig._underwaterLightFadeDepth * strength;
					_underwaterLightFadeDistance += waterConfig._underwaterLightFadeDistance * strength;
					_underwaterColorIntensity += waterConfig._underwaterColorIntensity * strength;
					num += (float)waterConfig._waveAmplitudeScale * strength;
				}
			}
			UnderwaterColorLinear = _underwaterColor.linear;
			UnderwaterDarkColorLinear = _underwaterDarkColor.linear;
			_waveAmplitudeScale = (byte)num;
		}

		public void UpdateCraftPositionData(PlanetVertexData vertexData, IPlanetTerrainData terrainData)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			PlanetVertexBiomeData[] biomes = vertexData.Biomes;
			foreach (PlanetVertexBiomeData planetVertexBiomeData in biomes)
			{
				float strength = planetVertexBiomeData.Strength;
				if (strength > 0f)
				{
					PlanetWaterConfig waterConfig = terrainData.Biomes[planetVertexBiomeData.BiomeIndex].WaterConfig;
					num += (float)waterConfig._waveAmplitudeScale * strength;
					num2 += waterConfig.Temperature * strength;
					num3 += waterConfig.Density * strength;
				}
			}
			_waveAmplitudeScale = (byte)num;
			_temperature = num2;
			_density = num3;
		}

		private static Gradient GetDefaultWaterColorGradient()
		{
			if (_defaultWaterColorGradient == null)
			{
				Gradient gradient = new Gradient();
				gradient.colorKeys = new GradientColorKey[1]
				{
					new GradientColorKey(new Color(0.1f, 0.2480053f, 0.4901961f), 0f)
				};
				_defaultWaterColorGradient = gradient;
			}
			return _defaultWaterColorGradient;
		}

		private void UpdateLinearColors()
		{
			WaterColorGradientLinear = _waterColorGradient.ToLinear();
			UnderwaterColorLinear = _underwaterColor.linear;
			UnderwaterDarkColorLinear = _underwaterDarkColor.linear;
		}
	}
}
