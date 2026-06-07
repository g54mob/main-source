using System;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Settings;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetTerrainQualityConfiguration
	{
		[SerializeField]
		private bool _automatic;

		[SerializeField]
		private bool _mobileOnly;

		[SerializeField]
		private PlanetTerrainQuality _quality;

		[SerializeField]
		private TerrainQualitySettings.GeometryDetailQuality _qualityLevel = TerrainQualitySettings.GeometryDetailQuality.Medium;

		public bool Automatic
		{
			get
			{
				return _automatic;
			}
			set
			{
				_automatic = value;
			}
		}

		public bool MobileOnly
		{
			get
			{
				return _mobileOnly;
			}
			set
			{
				_mobileOnly = value;
			}
		}

		public PlanetTerrainQuality Quality
		{
			get
			{
				return _quality;
			}
			set
			{
				_quality = value;
			}
		}

		public TerrainQualitySettings.GeometryDetailQuality QualityLevel
		{
			get
			{
				return _qualityLevel;
			}
			set
			{
				_qualityLevel = value;
			}
		}

		public double TargetVertexDistance { get; set; }

		public static PlanetTerrainQualityConfiguration CreateFromXml(XElement xml, PlanetTerrainQuality defaults, int maxSubdivisionAdjustment)
		{
			PlanetTerrainQualityConfiguration planetTerrainQualityConfiguration = new PlanetTerrainQualityConfiguration();
			planetTerrainQualityConfiguration._qualityLevel = xml.GetEnumAttribute("qualityLevel", TerrainQualitySettings.GeometryDetailQuality.Low);
			planetTerrainQualityConfiguration._automatic = (bool?)xml.Attribute("automatic") == true;
			planetTerrainQualityConfiguration._mobileOnly = (bool?)xml.Attribute("mobileOnly") == true;
			planetTerrainQualityConfiguration._quality = PlanetTerrainQuality.CreateFromXml(xml, defaults, maxSubdivisionAdjustment);
			planetTerrainQualityConfiguration.TargetVertexDistance = ((double?)xml.Attribute("targetVertexDistance")) ?? GetDefaultTargetVertexDistance(planetTerrainQualityConfiguration);
			return planetTerrainQualityConfiguration;
		}

		public static double GetDefaultTargetVertexDistance(PlanetTerrainQualityConfiguration config)
		{
			int num = ((!config.MobileOnly) ? 1 : 2);
			return config.QualityLevel switch
			{
				TerrainQualitySettings.GeometryDetailQuality.Low => 100 * num, 
				TerrainQualitySettings.GeometryDetailQuality.Medium => 50 * num, 
				TerrainQualitySettings.GeometryDetailQuality.High => 25 * num, 
				_ => throw new NotImplementedException($"Unknown quality level: {config.QualityLevel}"), 
			};
		}

		public XElement SaveXml(XElement xml, PlanetTerrainQuality defaults)
		{
			xml.SetAttributeValue("qualityLevel", _qualityLevel);
			xml.SetAttributeValue("automatic", _automatic);
			xml.SetAttributeValue("mobileOnly", _mobileOnly);
			xml.SetAttributeValue("targetVertexDistance", TargetVertexDistance);
			_quality.SaveXml(xml, defaults);
			return xml;
		}
	}
}
