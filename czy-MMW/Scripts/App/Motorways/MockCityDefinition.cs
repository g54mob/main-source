using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	public class MockCityDefinition : CityDefinition
	{
		public readonly List<Vector2Int> mockWaterPositions = new List<Vector2Int>();

		public readonly List<Vector2Int> mockUnbuildablePositions = new List<Vector2Int>();

		public readonly List<Vector2Int> mockMountainPositions = new List<Vector2Int>();

		public readonly List<Vector2Int> mockRailPositions = new List<Vector2Int>();

		public readonly List<Vector2Int> mockTrainPositions = new List<Vector2Int>();

		public readonly List<Vector2Int> mockUnzoneablePositions = new List<Vector2Int>();

		public readonly List<Vector2Int> mockValidCirclePositions = new List<Vector2Int>();

		public CitySpawningLayerData mockCitySpawningLayerData = new CitySpawningLayerData();

		public readonly Dictionary<Vector2Int, DensityGroup> mockDensityGroup = new Dictionary<Vector2Int, DensityGroup>();

		public override CitySpawningLayerData TileWeightData => mockCitySpawningLayerData;

		protected override void Awake()
		{
			cameraZoom.velocity.AddKey(0f, (float)cameraZoom.startSize);
			cameraZoom.velocity.AddKey((float)cameraZoom.durationInDays, (float)cameraZoom.endSize);
			base.Awake();
		}

		public override bool TileIsBuildable(Vector2Int position)
		{
			return !mockUnbuildablePositions.Contains(position);
		}

		public override bool TileIsOverWater(Vector2Int position)
		{
			return mockWaterPositions.Contains(position);
		}

		public override bool TileIsUnderAMountain(Vector2Int position)
		{
			return mockMountainPositions.Contains(position);
		}

		public override bool TileIsOverRail(Vector2Int position)
		{
			return mockRailPositions.Contains(position);
		}

		public override bool TileIsDriveable(Vector2Int tileCoordinates)
		{
			if (!TileIsOverWater(tileCoordinates) && !TileIsUnderAMountain(tileCoordinates))
			{
				return TileIsBuildable(tileCoordinates);
			}
			return false;
		}

		public override bool TileIsZoneable(Vector2Int position)
		{
			return !mockUnzoneablePositions.Contains(position);
		}

		public override bool TileSupportsCircleDestinations(int groupIndex, Vector2Int position)
		{
			return mockValidCirclePositions.Contains(position);
		}

		public override DensityGroup DensityForPosition(Vector2Int position)
		{
			if (mockDensityGroup.TryGetValue(position, out var value))
			{
				return value;
			}
			return DensityGroup.High;
		}

		protected override Dictionary<Vector2Int, RailType> CompileRailTileCoordinates()
		{
			Dictionary<Vector2Int, RailType> dictionary = new Dictionary<Vector2Int, RailType>();
			foreach (Vector2Int mockRailPosition in mockRailPositions)
			{
				dictionary.Add(mockRailPosition, mockTrainPositions.Contains(mockRailPosition) ? RailType.TrainOrigin : RailType.Normal);
			}
			return dictionary;
		}
	}
}
