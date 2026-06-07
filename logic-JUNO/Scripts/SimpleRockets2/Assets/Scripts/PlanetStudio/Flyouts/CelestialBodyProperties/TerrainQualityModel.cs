using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Settings;

namespace Assets.Scripts.PlanetStudio.Flyouts.CelestialBodyProperties
{
	public class TerrainQualityModel
	{
		public enum WaterVertexQualityType
		{
			Full = 0,
			Half = 1
		}

		private List<PlanetTerrainQualityConfiguration> _configs;

		private PlanetStudioFlyoutScript _flyout;

		private int _index;

		private List<(string name, TerrainQualitySettings.GeometryDetailQuality quality, bool mobileOnly)> _modes = new List<(string, TerrainQualitySettings.GeometryDetailQuality, bool)>();

		private PlanetDataScript _planetData;

		private WaterVertexQualityType _waterVertexQuality;

		public bool AutoQuadSphereDistances { get; set; }

		public bool CanDelete
		{
			get
			{
				if (Exists)
				{
					return _modes[_index].mobileOnly;
				}
				return false;
			}
		}

		public bool Exists { get; private set; }

		public int MaxSubdivisionLevel
		{
			get
			{
				return Selected.Quality.MaxSubdivisionLevel;
			}
			set
			{
				if (value < MinSubdivisionLevel)
				{
					value = MinSubdivisionLevel;
				}
				Selected.Quality.MaxSubdivisionLevel = value;
			}
		}

		public int MinSubdivisionLevel
		{
			get
			{
				return Selected.Quality.MinSubdivisionLevel;
			}
			set
			{
				if (value > MaxSubdivisionLevel)
				{
					value = MaxSubdivisionLevel;
				}
				Selected.Quality.MinSubdivisionLevel = value;
			}
		}

		public string ModeName { get; private set; }

		public long QuadSphereActivationDistance
		{
			get
			{
				return Selected.Quality.QuadSphereActivationDistance;
			}
			set
			{
				Selected.Quality.QuadSphereActivationDistance = value;
			}
		}

		public long QuadSphereTransitionDistance
		{
			get
			{
				return Selected.Quality.QuadSphereTransitionDistance;
			}
			set
			{
				Selected.Quality.QuadSphereTransitionDistance = value;
			}
		}

		public PlanetTerrainQualityConfiguration Selected { get; private set; }

		public int TerrainQuadEdgeVertexCount
		{
			get
			{
				return Selected.Quality.TerrainQuadEdgeVertexCount;
			}
			set
			{
				Selected.Quality.TerrainQuadEdgeVertexCount = MathUtils.RoundToOdd(value, roundUp: true);
				UpdateWaterQuadVertexCount();
			}
		}

		public int WaterQuadEdgeVertexCount
		{
			get
			{
				return Selected.Quality.WaterQuadEdgeVertexCount;
			}
			set
			{
				Selected.Quality.WaterQuadEdgeVertexCount = value;
			}
		}

		public WaterVertexQualityType WaterVertexQuality
		{
			get
			{
				return _waterVertexQuality;
			}
			set
			{
				_waterVertexQuality = value;
				UpdateWaterQuadVertexCount();
			}
		}

		public TerrainQualityModel(PlanetDataScript planetData, PlanetStudioFlyoutScript flyout)
		{
			_flyout = flyout;
			_planetData = planetData;
			_configs = _planetData.TerrainData.QualitySettings.QualityConfigurations;
			_modes.Add(("High", TerrainQualitySettings.GeometryDetailQuality.High, false));
			_modes.Add(("Medium", TerrainQualitySettings.GeometryDetailQuality.Medium, false));
			_modes.Add(("Low", TerrainQualitySettings.GeometryDetailQuality.Low, false));
			_modes.Add(("High (Mobile Only)", TerrainQualitySettings.GeometryDetailQuality.High, true));
			_modes.Add(("Medium (Mobile Only)", TerrainQualitySettings.GeometryDetailQuality.Medium, true));
			_modes.Add(("Low (Mobile Only)", TerrainQualitySettings.GeometryDetailQuality.Low, true));
			SelectConfig(_index);
		}

		public void Advance(int advancement)
		{
			_index += advancement;
			if (_index >= _modes.Count)
			{
				_index = 0;
			}
			else if (_index < 0)
			{
				_index = _modes.Count - 1;
			}
			SelectConfig(_index);
		}

		public void CreateMode()
		{
			_configs.Add(Selected);
			SelectConfig(_index);
			_flyout.PlanetStudioUI.CreateUndoStep(null, "Create Terrain Quality Mode");
		}

		public void DeleteMode()
		{
			_configs.Remove(Selected);
			SelectConfig(_index);
			_flyout.PlanetStudioUI.CreateUndoStep(null, "Delete Terrain Quality Mode");
		}

		public void UpdateFromTargetDistance()
		{
			UpdateFromTargetDistance(Selected);
		}

		private void SelectConfig(int index)
		{
			(string name, TerrainQualitySettings.GeometryDetailQuality quality, bool mobileOnly) mode = _modes[index];
			PlanetTerrainQualityConfiguration planetTerrainQualityConfiguration = _configs.Where((PlanetTerrainQualityConfiguration x) => x.QualityLevel == mode.quality && x.MobileOnly == mode.mobileOnly).FirstOrDefault();
			if (planetTerrainQualityConfiguration != null)
			{
				Exists = true;
				AutoQuadSphereDistances = planetTerrainQualityConfiguration.Quality.QuadSphereActivationDistance == 0L && planetTerrainQualityConfiguration.Quality.QuadSphereTransitionDistance == 0;
			}
			else
			{
				Exists = false;
				planetTerrainQualityConfiguration = new PlanetTerrainQualityConfiguration
				{
					Automatic = true,
					MobileOnly = mode.mobileOnly,
					QualityLevel = mode.quality
				};
				planetTerrainQualityConfiguration.Quality = new PlanetTerrainQuality();
				planetTerrainQualityConfiguration.TargetVertexDistance = PlanetTerrainQualityConfiguration.GetDefaultTargetVertexDistance(planetTerrainQualityConfiguration);
				UpdateFromTargetDistance(planetTerrainQualityConfiguration);
				AutoQuadSphereDistances = true;
			}
			ModeName = mode.name;
			Selected = planetTerrainQualityConfiguration;
			if (WaterQuadEdgeVertexCount < TerrainQuadEdgeVertexCount)
			{
				WaterVertexQuality = WaterVertexQualityType.Half;
			}
			else
			{
				WaterVertexQuality = WaterVertexQualityType.Full;
			}
		}

		private void UpdateFromTargetDistance(PlanetTerrainQualityConfiguration config)
		{
			double num = Math.PI * 2.0 * _planetData.Radius / 4.0;
			int num2 = (int)Math.Min(Math.Round(Math.Log(num / (config.TargetVertexDistance * 28.0), 2.0)), 20.0);
			int num3 = MathUtils.RoundToOdd(Math.Min(num / (config.TargetVertexDistance * Math.Pow(2.0, num2)) + 1.0, 29.0));
			config.Quality.MaxSubdivisionLevel = num2;
			config.Quality.TerrainQuadEdgeVertexCount = num3;
			if (config.QualityLevel == TerrainQualitySettings.GeometryDetailQuality.High)
			{
				config.Quality.WaterQuadEdgeVertexCount = num3;
			}
			else
			{
				config.Quality.WaterQuadEdgeVertexCount = (num3 - 1) / 2 + 1;
			}
		}

		private void UpdateWaterQuadVertexCount()
		{
			if (WaterVertexQuality == WaterVertexQualityType.Full)
			{
				WaterQuadEdgeVertexCount = TerrainQuadEdgeVertexCount;
			}
			else
			{
				WaterQuadEdgeVertexCount = (TerrainQuadEdgeVertexCount - 1) / 2 + 1;
			}
		}
	}
}
