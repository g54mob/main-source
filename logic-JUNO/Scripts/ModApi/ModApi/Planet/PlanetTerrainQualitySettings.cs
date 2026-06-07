using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Settings;
using UnityEngine;

namespace ModApi.Planet
{
	[Serializable]
	public class PlanetTerrainQualitySettings
	{
		private PlanetTerrainQuality _current;

		[SerializeField]
		private PlanetTerrainQuality _default;

		[SerializeField]
		private List<PlanetTerrainQualityConfiguration> _qualityConfigurations;

		public IPlanetTerrainQuality Current => _current;

		public List<PlanetTerrainQualityConfiguration> QualityConfigurations => _qualityConfigurations;

		public static PlanetTerrainQualitySettings CreateFromXml(XElement xml, int maxSubdivisionAdjustment)
		{
			PlanetTerrainQualitySettings planetTerrainQualitySettings = new PlanetTerrainQualitySettings();
			if (xml == null)
			{
				xml = new XElement("QualitySettings");
			}
			planetTerrainQualitySettings._default = PlanetTerrainQuality.CreateFromXml(xml, PlanetTerrainQuality.Default, maxSubdivisionAdjustment);
			List<PlanetTerrainQualityConfiguration> list = new List<PlanetTerrainQualityConfiguration>();
			foreach (XElement item in xml.Elements("Quality"))
			{
				list.Add(PlanetTerrainQualityConfiguration.CreateFromXml(item, planetTerrainQualitySettings._default, maxSubdivisionAdjustment));
			}
			planetTerrainQualitySettings._qualityConfigurations = list;
			planetTerrainQualitySettings.UpdateCurrentQualitySettings(null);
			return planetTerrainQualitySettings;
		}

		public XElement SaveXml(XElement xml)
		{
			_default.SaveXml(xml, null);
			foreach (PlanetTerrainQualityConfiguration qualityConfiguration in _qualityConfigurations)
			{
				xml.Add(qualityConfiguration.SaveXml(new XElement("Quality"), _default));
			}
			return xml;
		}

		public void UpdateCurrentQualitySettings(IGameQualitySettings qualitySettings)
		{
			_current = _default;
			if (qualitySettings != null)
			{
				TerrainQualitySettings.GeometryDetailQuality quality = qualitySettings.Terrain.GeometryDetail.Value;
				PlanetTerrainQualityConfiguration planetTerrainQualityConfiguration = _qualityConfigurations.FirstOrDefault((PlanetTerrainQualityConfiguration x) => x.QualityLevel == quality && !x.MobileOnly);
				PlanetTerrainQualityConfiguration planetTerrainQualityConfiguration2 = _qualityConfigurations.FirstOrDefault((PlanetTerrainQualityConfiguration x) => x.QualityLevel == quality && x.MobileOnly);
				if (planetTerrainQualityConfiguration2 != null && Game.Instance.Device.IsMobileBuild)
				{
					_current = planetTerrainQualityConfiguration2.Quality;
				}
				else if (planetTerrainQualityConfiguration != null)
				{
					_current = planetTerrainQualityConfiguration.Quality;
				}
			}
		}
	}
}
