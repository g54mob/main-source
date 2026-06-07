using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class CelestialBodyScaleData
	{
		[SerializeField]
		private float _angularVelocityScale = 1f;

		[SerializeField]
		private float _atmosphereScale = 1f;

		[SerializeField]
		private float _gravityScale = 1f;

		[SerializeField]
		private float _orbitScale = 1f;

		[SerializeField]
		private float _planetScale = 1f;

		public float AngularVelocityScale
		{
			get
			{
				return _angularVelocityScale;
			}
			private set
			{
				_angularVelocityScale = value;
			}
		}

		public float AtmosphereScale
		{
			get
			{
				return _atmosphereScale;
			}
			private set
			{
				_atmosphereScale = value;
			}
		}

		public float GravityScale
		{
			get
			{
				return _gravityScale;
			}
			private set
			{
				_gravityScale = value;
			}
		}

		public float OrbitScale
		{
			get
			{
				return _orbitScale;
			}
			private set
			{
				_orbitScale = value;
			}
		}

		public float PlanetScale
		{
			get
			{
				return _planetScale;
			}
			private set
			{
				_planetScale = value;
			}
		}

		public CelestialBodyScaleData()
		{
			AngularVelocityScale = 1f;
			AtmosphereScale = 1f;
			GravityScale = 1f;
			OrbitScale = 1f;
			PlanetScale = 1f;
		}

		public static CelestialBodyScaleData operator *(CelestialBodyScaleData a, CelestialBodyScaleData b)
		{
			if (a == null)
			{
				throw new ArgumentNullException("a");
			}
			if (b == null)
			{
				throw new ArgumentNullException("b");
			}
			return new CelestialBodyScaleData
			{
				AngularVelocityScale = a.AngularVelocityScale * b.AngularVelocityScale,
				AtmosphereScale = a.AtmosphereScale * b.AtmosphereScale,
				GravityScale = a.GravityScale * b.GravityScale,
				OrbitScale = a.OrbitScale * b.OrbitScale,
				PlanetScale = a.PlanetScale * b.PlanetScale
			};
		}

		public static CelestialBodyScaleData CreateFromXml(XElement scaleXml)
		{
			if (scaleXml == null)
			{
				return new CelestialBodyScaleData();
			}
			return new CelestialBodyScaleData
			{
				AngularVelocityScale = (((float?)scaleXml.Attribute("angularVelocityScale")) ?? 1f),
				AtmosphereScale = (((float?)scaleXml.Attribute("atmosphereScale")) ?? 1f),
				GravityScale = (((float?)scaleXml.Attribute("gravityScale")) ?? 1f),
				OrbitScale = (((float?)scaleXml.Attribute("orbitScale")) ?? 1f),
				PlanetScale = (((float?)scaleXml.Attribute("planetScale")) ?? 1f)
			};
		}

		public CelestialBodyScaleData Clone()
		{
			return new CelestialBodyScaleData
			{
				AngularVelocityScale = AngularVelocityScale,
				AtmosphereScale = AtmosphereScale,
				GravityScale = GravityScale,
				OrbitScale = OrbitScale,
				PlanetScale = PlanetScale
			};
		}

		public XElement GenerateXml(string xmlElementName)
		{
			return new XElement(xmlElementName, new XAttribute("angularVelocityScale", AngularVelocityScale), new XAttribute("atmosphereScale", AtmosphereScale), new XAttribute("gravityScale", GravityScale), new XAttribute("orbitScale", OrbitScale), new XAttribute("planetScale", PlanetScale));
		}

		public bool IsOne()
		{
			if (AngularVelocityScale == 1f && AtmosphereScale == 1f && GravityScale == 1f && OrbitScale == 1f)
			{
				return PlanetScale == 1f;
			}
			return false;
		}
	}
}
