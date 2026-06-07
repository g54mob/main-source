using System;
using System.Collections.Generic;
using ModApi.Common;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class AtmosphereShaderModel
	{
		public enum TargetType
		{
			Sky = 0,
			Terrain = 1,
			Both = 2
		}

		private Action _onUpdated;

		private PlanetShaderData _sky;

		private TargetType _target;

		private List<PlanetShaderData> _targets = new List<PlanetShaderData>();

		private PlanetShaderData _terrain;

		public Color AmbientLightDay
		{
			get
			{
				return _targets[0].AmbientLightDay;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AmbientLightDay = value;
				});
			}
		}

		public Color AmbientLightNight
		{
			get
			{
				return _targets[0].AmbientLightNight;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AmbientLightNight = value;
				});
			}
		}

		public float AmbientLightRangeMax
		{
			get
			{
				return _targets[0].AmbientLightAltitudeRange.MaxValue;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AmbientLightAltitudeRange = new MinMaxValue(x.AmbientLightAltitudeRange.MinValue, Mathf.Max(value, x.AmbientLightAltitudeRange.MinValue));
				});
			}
		}

		public float AmbientLightRangeMin
		{
			get
			{
				return _targets[0].AmbientLightAltitudeRange.MinValue;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AmbientLightAltitudeRange = new MinMaxValue(Mathf.Min(value, x.AmbientLightAltitudeRange.MaxValue), x.AmbientLightAltitudeRange.MaxValue);
				});
			}
		}

		public float? AtmosSizeScale
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.AtmosSizeScale);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AtmosSizeScale = value.Value;
				});
			}
		}

		public float? DensityScale
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.ScaleDepth);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Options.ScaleDepthAuto = false;
					x.ScaleDepth = value.Value;
				});
			}
		}

		public float? DensityScaleSpace
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.ScaleDepthMax);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Options.ScaleDepthAuto = true;
					x.ScaleDepthMax = value.Value;
				});
			}
		}

		public float? DensityScaleSurface
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.ScaleDepthMin);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Options.ScaleDepthAuto = true;
					x.ScaleDepthMin = value.Value;
				});
			}
		}

		public Color DuskColor
		{
			get
			{
				return _targets[0].DuskColor;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.DuskColor = value;
				});
			}
		}

		public float? FresnelBias
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.FresnelBias);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.FresnelBias = value.Value;
				});
			}
		}

		public float? Intensity
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.AtmosScale);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AtmosScale = value.Value;
				});
			}
		}

		public float? IntensitySpace
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.AtmosScaleSpace);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AtmosScaleSpace = value.Value;
				});
			}
		}

		public float? IntensitySurface
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.AtmosScaleSurface);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.AtmosScaleSurface = value.Value;
				});
			}
		}

		public bool LegacySkyShader
		{
			get
			{
				return _targets[0].Options.LegacySkyShader;
			}
			set
			{
				UpdateProperty(delegate
				{
					_targets[0].Options.LegacySkyShader = value;
				});
			}
		}

		public bool LerpIntensity
		{
			get
			{
				return _targets[0].Options.AtmosScaleAuto;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Options.AtmosScaleAuto = value;
				});
			}
		}

		public bool? LerpScaleDepth
		{
			get
			{
				return GetBoolProperty((PlanetShaderData x) => x.Options.ScaleDepthAuto);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Options.ScaleDepthAuto = value.Value;
				});
			}
		}

		public float? MaxColorValue
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.MaxColorValue);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.MaxColorValue = value.Value;
				});
			}
		}

		public float? MieScattering
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.Km);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Km = value.Value;
				});
			}
		}

		public Color NoonColor
		{
			get
			{
				return _targets[0].NoonColor;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.NoonColor = value;
				});
			}
		}

		public float? RayleighScattering
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.Kr);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.Kr = value.Value;
				});
			}
		}

		public float? SunBrightness
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.ESun);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.ESun = value.Value;
				});
			}
		}

		public float? SymmetryScattering
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.G);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.G = value.Value;
				});
			}
		}

		public TargetType Target
		{
			get
			{
				return _target;
			}
			set
			{
				_target = value;
				_targets.Clear();
				if (_target == TargetType.Sky)
				{
					_targets.Add(_sky);
					return;
				}
				if (_target == TargetType.Terrain)
				{
					_targets.Add(_terrain);
					return;
				}
				_targets.Add(_sky);
				_targets.Add(_terrain);
			}
		}

		public Color WaveLength
		{
			get
			{
				return _targets[0].WaveLength;
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.WaveLength = value;
				});
			}
		}

		public float? WaveLengthMag
		{
			get
			{
				return GetProperty((PlanetShaderData x) => x.WaveLengthMag);
			}
			set
			{
				UpdateProperty(delegate(PlanetShaderData x)
				{
					x.WaveLengthMag = value.Value;
				});
			}
		}

		public AtmosphereShaderModel(PlanetShaderData skyData, PlanetShaderData terrainData, Action onUpdated)
		{
			_sky = skyData;
			_terrain = terrainData;
			Target = TargetType.Sky;
			_onUpdated = onUpdated;
		}

		public void AdvanceTarget(int direction)
		{
			int num = (int)(Target + direction);
			if (num < 0)
			{
				num = Enum.GetValues(typeof(TargetType)).Length - 1;
			}
			else if (num >= Enum.GetValues(typeof(TargetType)).Length)
			{
				num = 0;
			}
			Target = (TargetType)num;
		}

		public string FormatSlider(int decimals, Func<float?> valueGetter)
		{
			float? num = valueGetter();
			if (num.HasValue)
			{
				return string.Format("{0:n" + decimals + "}", num.Value);
			}
			return "x";
		}

		private bool? GetBoolProperty(Func<PlanetShaderData, bool> property)
		{
			if (_targets.Count == 2)
			{
				bool flag = property(_targets[0]);
				bool flag2 = property(_targets[1]);
				if (flag == flag2)
				{
					return flag;
				}
				return null;
			}
			return property(_targets[0]);
		}

		private float? GetProperty(Func<PlanetShaderData, float> property)
		{
			if (_targets.Count == 2)
			{
				float num = property(_targets[0]);
				float num2 = property(_targets[1]);
				if (num == num2)
				{
					return num;
				}
				return null;
			}
			return property(_targets[0]);
		}

		private void UpdateProperty(Action<PlanetShaderData> action)
		{
			foreach (PlanetShaderData target in _targets)
			{
				action(target);
			}
			_onUpdated();
		}
	}
}
