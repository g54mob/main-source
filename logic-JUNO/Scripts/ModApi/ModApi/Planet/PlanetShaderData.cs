using System;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetShaderData
	{
		public enum Type
		{
			Surface = 0,
			Sky = 1
		}

		[SerializeField]
		private MinMaxValue _ambientLightAltitudeRange = new MinMaxValue(0f, 5000f);

		[SerializeField]
		private Color _ambientLightDay = Color.gray;

		[SerializeField]
		private Color _ambientLightNight = Color.gray;

		[Range(0f, 20f)]
		[SerializeField]
		private float _atmosScale;

		[Range(0f, 20f)]
		[SerializeField]
		private float _atmosScaleSpace;

		[Range(0f, 20f)]
		[SerializeField]
		private float _atmosScaleSurface;

		[Range(1f, 10f)]
		[SerializeField]
		private float _atmosSizeScale = 1f;

		[Range(0f, 1f)]
		[SerializeField]
		private float _debugScaler;

		[SerializeField]
		private Color _duskColor = Color.white;

		[SerializeField]
		private float _eSun;

		[SerializeField]
		private float _fresnelBias;

		[SerializeField]
		private float _g;

		[SerializeField]
		[Range(0.0001f, 0.1f)]
		private float _km;

		[SerializeField]
		[Range(0.0001f, 0.1f)]
		private float _kr;

		[SerializeField]
		[Range(0.002f, 100f)]
		private float _maxColorValue = 2f;

		[SerializeField]
		private Color _noonColor = Color.white;

		[SerializeField]
		private PlanetShaderOptionsData _options = new PlanetShaderOptionsData();

		[SerializeField]
		[Range(1f, 500f)]
		private int _samples;

		[SerializeField]
		[Range(0.002f, 1f)]
		private float _scaleDepth;

		[Range(0.002f, 1f)]
		[SerializeField]
		private float _scaleDepthMax;

		[Range(0.002f, 1f)]
		[SerializeField]
		private float _scaleDepthMin;

		[SerializeField]
		private Color _waveLength;

		[SerializeField]
		[Range(-2f, 2f)]
		private float _waveLengthMag = 1f;

		public MinMaxValue AmbientLightAltitudeRange
		{
			get
			{
				return _ambientLightAltitudeRange;
			}
			set
			{
				_ambientLightAltitudeRange = value;
			}
		}

		public Color AmbientLightDay
		{
			get
			{
				return _ambientLightDay;
			}
			set
			{
				_ambientLightDay = value;
			}
		}

		public Color AmbientLightNight
		{
			get
			{
				return _ambientLightNight;
			}
			set
			{
				_ambientLightNight = value;
			}
		}

		public float AtmosScale
		{
			get
			{
				return _atmosScale;
			}
			set
			{
				_atmosScale = value;
			}
		}

		public float AtmosScaleSpace
		{
			get
			{
				return _atmosScaleSpace;
			}
			set
			{
				_atmosScaleSpace = value;
			}
		}

		public float AtmosScaleSurface
		{
			get
			{
				return _atmosScaleSurface;
			}
			set
			{
				_atmosScaleSurface = value;
			}
		}

		public float AtmosSizeScale
		{
			get
			{
				return _atmosSizeScale;
			}
			set
			{
				_atmosSizeScale = value;
			}
		}

		public float DebugScaler
		{
			get
			{
				return _debugScaler;
			}
			set
			{
				_debugScaler = value;
			}
		}

		public Color DuskColor
		{
			get
			{
				return _duskColor;
			}
			set
			{
				_duskColor = value;
			}
		}

		public float ESun
		{
			get
			{
				return _eSun;
			}
			set
			{
				_eSun = value;
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

		public float G
		{
			get
			{
				return _g;
			}
			set
			{
				_g = value;
			}
		}

		public float Km
		{
			get
			{
				return _km;
			}
			set
			{
				_km = value;
			}
		}

		public float Kr
		{
			get
			{
				return _kr;
			}
			set
			{
				_kr = value;
			}
		}

		public float MaxColorValue
		{
			get
			{
				return _maxColorValue;
			}
			set
			{
				_maxColorValue = value;
			}
		}

		public Color NoonColor
		{
			get
			{
				return _noonColor;
			}
			set
			{
				_noonColor = value;
			}
		}

		public PlanetShaderOptionsData Options
		{
			get
			{
				return _options;
			}
			set
			{
				_options = value;
			}
		}

		public int Samples
		{
			get
			{
				return _samples;
			}
			set
			{
				_samples = value;
			}
		}

		public float ScaleDepth
		{
			get
			{
				return _scaleDepth;
			}
			set
			{
				_scaleDepth = value;
			}
		}

		public float ScaleDepthMax
		{
			get
			{
				return _scaleDepthMax;
			}
			set
			{
				_scaleDepthMax = value;
			}
		}

		public float ScaleDepthMin
		{
			get
			{
				return _scaleDepthMin;
			}
			set
			{
				_scaleDepthMin = value;
			}
		}

		public Color WaveLength
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

		public float WaveLengthMag
		{
			get
			{
				return _waveLengthMag;
			}
			set
			{
				_waveLengthMag = value;
			}
		}

		public static PlanetShaderData Clone(PlanetShaderData source)
		{
			PlanetShaderData planetShaderData = new PlanetShaderData();
			planetShaderData.CopyFrom(source);
			return planetShaderData;
		}

		public static PlanetShaderData CreateFromXml(XElement xml)
		{
			PlanetShaderData planetShaderData = xml.FromXElement<PlanetShaderData>();
			if (planetShaderData.ScaleDepthMin <= 0.002f)
			{
				planetShaderData.ScaleDepthMin = 0.002f;
			}
			return planetShaderData;
		}

		public void CopyFrom(PlanetShaderData source)
		{
			int num = GetType().GetProperties().Count();
			if (num != 23)
			{
				Debug.LogWarning($"PlanetShaderData.CopyFrom is setup to copy {23} properties, but the class has {num}...did you add a property w/o adding it to CopyFrom?");
			}
			AmbientLightAltitudeRange = source.AmbientLightAltitudeRange;
			AmbientLightDay = source.AmbientLightDay;
			AmbientLightNight = source.AmbientLightNight;
			AtmosScale = source.AtmosScale;
			AtmosScaleSpace = source.AtmosScaleSpace;
			AtmosScaleSurface = source.AtmosScaleSurface;
			AtmosSizeScale = source.AtmosSizeScale;
			DebugScaler = source.DebugScaler;
			DuskColor = source.DuskColor;
			ESun = source.ESun;
			FresnelBias = source.FresnelBias;
			G = source.G;
			Km = source.Km;
			Kr = source.Kr;
			NoonColor = source.NoonColor;
			Samples = source.Samples;
			ScaleDepth = source.ScaleDepth;
			MaxColorValue = source.MaxColorValue;
			ScaleDepthMax = source.ScaleDepthMax;
			ScaleDepthMin = source.ScaleDepthMin;
			WaveLength = source.WaveLength;
			WaveLengthMag = source.WaveLengthMag;
			Options.CopyFrom(source.Options);
		}

		public XElement SaveXml()
		{
			return this.ToXElement<PlanetShaderData>();
		}

		public PlanetShaderData SetDefaults(Type type)
		{
			switch (type)
			{
			case Type.Sky:
				ESun = 50f;
				Kr = 0.0025f;
				Km = 0.0015f;
				Samples = 2;
				break;
			case Type.Surface:
				ESun = 15f;
				Kr = 0.0015f;
				Km = 0.0015f;
				Samples = 4;
				break;
			}
			AmbientLightAltitudeRange = new MinMaxValue(0f, 5000f);
			AmbientLightDay = Color.gray;
			AmbientLightNight = Color.gray * 0.2f;
			DuskColor = Color.white;
			AtmosScale = 1f;
			AtmosScaleSpace = 1f;
			AtmosScaleSurface = 1f;
			FresnelBias = 0f;
			G = -0.95f;
			NoonColor = Color.white;
			MaxColorValue = 2f;
			ScaleDepth = 0.25f;
			ScaleDepthMax = 0.8f;
			ScaleDepthMin = 0.08f;
			WaveLength = new Color(0.6509804f, 29f / 51f, 0.4745098f, 0.5f);
			WaveLengthMag = 1f;
			return this;
		}
	}
}
