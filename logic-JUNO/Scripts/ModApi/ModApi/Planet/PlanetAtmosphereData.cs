using System;
using System.Xml.Linq;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetAtmosphereData : IPlanetAtmosphereData
	{
		public const double EarthSurfaceAirDensity = 1.2;

		private const double BoltzmannConstant = 1.38E-23;

		private const double MinAirDensity = 1E-06;

		[SerializeField]
		private double _crushAltitude;

		[SerializeField]
		private string _description;

		[SerializeField]
		private double _fadeDistance = 5000.0;

		[SerializeField]
		private double _atmosphereDensityThreshold = 0.0010000000474974513;

		[SerializeField]
		private bool _hasPhysicsAtmosphere;

		[SerializeField]
		private double _meanAtomicMassPerMolecule;

		[SerializeField]
		private double _meanGamma;

		[SerializeField]
		private double _meanSurfaceTemperatureDay;

		[SerializeField]
		private double _meanSurfaceTemperatureNight;

		[SerializeField]
		private double _surfaceAirDensity;

		public double CrushAltitude
		{
			get
			{
				return _crushAltitude;
			}
			set
			{
				_crushAltitude = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public double FadeDistance
		{
			get
			{
				return _fadeDistance;
			}
			set
			{
				_fadeDistance = value;
			}
		}

		public double AtmosphereDensityThreshold
		{
			get
			{
				return _atmosphereDensityThreshold;
			}
			set
			{
				_atmosphereDensityThreshold = value;
			}
		}

		public bool HasPhysicsAtmosphere
		{
			get
			{
				return _hasPhysicsAtmosphere;
			}
			set
			{
				_hasPhysicsAtmosphere = value;
			}
		}

		public double Height { get; private set; }

		public double MeanGamma
		{
			get
			{
				return _meanGamma;
			}
			private set
			{
				_meanGamma = value;
			}
		}

		public double MeanMassPerMolecule { get; private set; }

		public double MeanSurfaceTemperature { get; private set; }

		public double MeanSurfaceTemperatureDay
		{
			get
			{
				return _meanSurfaceTemperatureDay;
			}
			private set
			{
				_meanSurfaceTemperatureDay = value;
			}
		}

		public double MeanSurfaceTemperatureNight
		{
			get
			{
				return _meanSurfaceTemperatureNight;
			}
			private set
			{
				_meanSurfaceTemperatureNight = value;
			}
		}

		public double ScaleHeight { get; private set; }

		public double SurfaceAirDensity
		{
			get
			{
				return _surfaceAirDensity;
			}
			set
			{
				_surfaceAirDensity = value;
			}
		}

		public static double CalculateAirDensity(double altitude, double scaleHeight, double surfaceAirDensity)
		{
			double result = 0.0;
			if (scaleHeight > 0.0)
			{
				result = surfaceAirDensity * Mathd.Pow(System.Math.E, (0.0 - altitude) / scaleHeight);
			}
			return result;
		}

		public static double CalculateAirPressure(double altitude, double scaleHeight, double surfaceAirDensity, double surfaceAirTemperature, double meanMassPerMolecule)
		{
			double result = 0.0;
			if (scaleHeight > 0.0)
			{
				double num = 8.3144621 / (meanMassPerMolecule / 1.66E-27 * 0.001);
				result = surfaceAirDensity * num * surfaceAirTemperature * Mathd.Pow(System.Math.E, (0.0 - altitude) / scaleHeight);
			}
			return result;
		}

		public static double CalculateAtmosphereHeight(double scaleHeight, double surfaceAirDensity, double threshold)
		{
			double num = Mathd.Max(threshold * surfaceAirDensity, 1E-06);
			return (0.0 - scaleHeight) * Mathd.Log(num / surfaceAirDensity);
		}

		public static double CalculateScaleHeight(double surfaceGravity, double meanMassPerMolecule, double meanSurfaceTemperature)
		{
			return 1.38E-23 * meanSurfaceTemperature / (meanMassPerMolecule * surfaceGravity);
		}

		public static double CalculateSpeedOfSound(double temperature, double meanGamma, double meanMassPerMolecule)
		{
			return Mathd.Sqrt(meanGamma * 1.38E-23 * temperature / meanMassPerMolecule);
		}

		public static double CalculateTemperature(double altitude, double height, double surfaceTemperature)
		{
			if (height > 0.0)
			{
				double num = Mathd.Clamp01(altitude / height);
				return (1.0 - num * num) * (surfaceTemperature - 2.0) + 2.0;
			}
			return 2.0;
		}

		public static PlanetAtmosphereData CreateFromXml(XElement xml, PlanetDataScript planet)
		{
			PlanetAtmosphereData planetAtmosphereData = new PlanetAtmosphereData();
			float atmosphereScale = planet.Scale.AtmosphereScale;
			planetAtmosphereData._crushAltitude = ((double?)xml.Attribute("crushAltitude")).GetValueOrDefault() * (double)atmosphereScale;
			planetAtmosphereData._fadeDistance = (((double?)xml.Attribute("fadeDistance")) ?? 5000.0) * (double)atmosphereScale;
			planetAtmosphereData._atmosphereDensityThreshold = (((double?)xml.Attribute("atmosphereDensityThreshold")) ?? 0.001) * (double)atmosphereScale;
			planetAtmosphereData._hasPhysicsAtmosphere = (bool?)xml.Attribute("hasPhysicsAtmosphere") == true;
			if (planetAtmosphereData._hasPhysicsAtmosphere)
			{
				planetAtmosphereData._surfaceAirDensity = (double)xml.Attribute("surfaceAirDensity");
				planetAtmosphereData._meanAtomicMassPerMolecule = (double)xml.Attribute("meanMassPerMolecule");
				planetAtmosphereData._meanSurfaceTemperatureNight = (double)xml.Attribute("meanNightSurfaceTemperature");
				planetAtmosphereData._meanSurfaceTemperatureDay = (double)xml.Attribute("meanDaySurfaceTemperature");
				planetAtmosphereData._meanGamma = (double)xml.Attribute("meanGamma");
				planetAtmosphereData.RecalculateDependentParameters(planet.SurfaceGravity);
			}
			planetAtmosphereData._description = (string)xml.Attribute("desc");
			return planetAtmosphereData;
		}

		public void GenerateInspectorModel(GroupModel group, PlanetDataScript planet)
		{
			Action<object> update = delegate
			{
				RecalculateDependentParameters(planet.SurfaceGravity);
			};
			if (MeanGamma == 0.0)
			{
				MeanGamma = 1.4;
				planet.SkyShaderData.AmbientLightDay = new Color32(128, 128, 128, byte.MaxValue);
				planet.SkyShaderData.AmbientLightNight = new Color32(60, 60, 70, byte.MaxValue);
				planet.SkyShaderData.WaveLength = new Color32(210, 197, 182, 128);
				_meanSurfaceTemperatureDay = 290.0;
				_meanSurfaceTemperatureNight = 270.0;
				_meanAtomicMassPerMolecule = 28.0;
				_surfaceAirDensity = 1.2000000476837158;
				update(null);
			}
			group.Add(new TextModel("Height", () => Units.GetDistanceString((float)Height))).Tooltip = "The physics height is calculated from the atmospheric parameters.";
			group.AddAndBuild(new SliderModel("Temperature - Day", () => (float)_meanSurfaceTemperatureDay, delegate(float x)
			{
				update(_meanSurfaceTemperatureDay = x);
			}, 0f, 1000f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => $"{x:n1}K";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The mean surface temperature during the day.";
			});
			group.AddAndBuild(new SliderModel("Temperature - Night", () => (float)_meanSurfaceTemperatureNight, delegate(float x)
			{
				update(_meanSurfaceTemperatureNight = x);
			}, 0f, 1000f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => $"{x:n1}K";
			}).Build(delegate(SliderModel x)
			{
				x.Tooltip = "The mean surface temperature during the night.";
			});
			group.AddAndBuild(new SliderModel("Surface Air Density", () => (float)_surfaceAirDensity, delegate(float x)
			{
				update(_surfaceAirDensity = x);
			}, 0.01f, 100f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => $"{x:n2}kg/m3";
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "Air density at the surface.";
			});
			group.AddAndBuild(new SliderModel("Mean Gamma", () => (float)MeanGamma, delegate(float x)
			{
				Action<object> action = update;
				double num = (MeanGamma = System.Math.Round(x, 3));
				action(num);
			}, 1f, 1.8f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => $"{x:n3}";
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The ideal gas mean gamma/specific heat value for the atmospheric composition.";
			});
			group.AddAndBuild(new SliderModel("Mean Molecular Weight", () => (float)_meanAtomicMassPerMolecule, delegate(float x)
			{
				update(_meanAtomicMassPerMolecule = x);
			}, 2f, 50f)).Build(delegate(SliderModel m)
			{
				m.ValueFormatter = (float x) => $"{x:n2}";
			}).Build(delegate(SliderModel m)
			{
				m.Tooltip = "The mean atomic mass per molecule. Changing this can affect the height of the atmosphere.";
			});
			group.Add(new NumericInputModel("Fade Distance", () => FadeDistance, delegate(double x)
			{
				Action<object> action = update;
				double num = (FadeDistance = x);
				action(num);
			})).Tooltip = "The distance from the edge of the atmosphere where the air density begins to linearly fade to zero.";
			group.Add(new NumericInputModel("Atmosphere End", () => AtmosphereDensityThreshold, delegate(double x)
			{
				Action<object> action = update;
				double num = (AtmosphereDensityThreshold = x);
				action(num);
			})).Tooltip = "The threshold at which the atmosphere ends relative to its surface density.";
		}

		public void RecalculateDependentParameters(double surfaceGravity)
		{
			MeanMassPerMolecule = _meanAtomicMassPerMolecule * 1.66E-27;
			MeanSurfaceTemperature = (MeanSurfaceTemperatureDay + MeanSurfaceTemperatureNight) * 0.5;
			ScaleHeight = CalculateScaleHeight(surfaceGravity, MeanMassPerMolecule, MeanSurfaceTemperature);
			Height = CalculateAtmosphereHeight(ScaleHeight, _surfaceAirDensity, AtmosphereDensityThreshold);
		}

		public AtmosphereSample SampleAltitude(double altitude)
		{
			AtmosphereSample result = new AtmosphereSample
			{
				SampleAltitude = (float)altitude,
				SurfaceAirDensity = 0.0,
				ScaleHeight = 1.0,
				AtmosphereHeight = (float)Height
			};
			if (HasPhysicsAtmosphere && altitude < Height)
			{
				result.AirDensity = (float)CalculateAirDensity(altitude, ScaleHeight, SurfaceAirDensity);
				result.AirPressure = (float)CalculateAirPressure(altitude, ScaleHeight, SurfaceAirDensity, MeanSurfaceTemperature, MeanMassPerMolecule);
				result.Temperature = (float)CalculateTemperature(altitude, Height, MeanSurfaceTemperature);
				result.SurfaceAirDensity = SurfaceAirDensity;
				result.ScaleHeight = ScaleHeight;
				if (altitude > Height - FadeDistance)
				{
					float num = Mathf.Clamp01((float)((Height - altitude) / FadeDistance));
					result.AirDensity *= num;
					result.AirPressure *= num;
				}
				result.SpeedOfSound = (float)CalculateSpeedOfSound(MeanSurfaceTemperature, MeanGamma, MeanMassPerMolecule);
			}
			return result;
		}

		public XElement SaveXml(XElement xml)
		{
			xml.SetAttributeValue("hasPhysicsAtmosphere", _hasPhysicsAtmosphere);
			if (_hasPhysicsAtmosphere)
			{
				xml.SetAttributeValue("surfaceAirDensity", _surfaceAirDensity);
				xml.SetAttributeValue("meanMassPerMolecule", _meanAtomicMassPerMolecule);
				xml.SetAttributeValue("meanNightSurfaceTemperature", _meanSurfaceTemperatureNight);
				xml.SetAttributeValue("meanDaySurfaceTemperature", _meanSurfaceTemperatureDay);
				xml.SetAttributeValue("meanGamma", _meanGamma);
			}
			xml.SetAttributeValue("crushAltitude", _crushAltitude);
			xml.SetAttributeValue("fadeDistance", _fadeDistance);
			xml.SetAttributeValue("atmosphereDensityThreshold", _atmosphereDensityThreshold);
			xml.SetAttributeValue("desc", _description);
			return xml;
		}
	}
}
