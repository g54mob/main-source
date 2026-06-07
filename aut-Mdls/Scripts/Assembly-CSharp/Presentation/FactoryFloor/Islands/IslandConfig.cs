using System;
using Data.FactoryFloor.Islands;
using UnityEngine;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandConfig
	{
		[Serializable]
		public struct IslandBottomPrefabConfig
		{
			public int SelectedIndex;

			public int Rotation;

			public IslandBottomPrefabConfig(int selectedIndex = 0, int rotation = 0)
			{
				SelectedIndex = selectedIndex;
				Rotation = rotation;
			}
		}

		public int CreatedID { get; }

		public Vector3Int Position { get; set; }

		public Vector2 Size { get; }

		public Vector2Int SizeUnits { get; }

		public int Rotation { get; set; }

		public IslandBottomPrefabConfig IslandBottom { get; set; }

		public bool IsGNNGateIsland { get; set; }

		public IslandData IslandData { get; }

		public Guid ID => IslandData.Id;

		public Texture2D Texture => IslandData.Texture2D;

		public IslandConfig(IslandData islandData, int createdID, Vector3 worldPosition, Vector2 size, Vector2Int sizeUnit, int rotation, IslandBottomPrefabConfig islandBottom, bool isGnnGateIsland)
		{
			IslandData = islandData;
			CreatedID = createdID;
			Position = new Vector3Int(Mathf.RoundToInt(worldPosition.x), 0, Mathf.RoundToInt(worldPosition.z));
			Size = size;
			SizeUnits = sizeUnit;
			Rotation = rotation;
			IslandBottom = islandBottom;
			IsGNNGateIsland = isGnnGateIsland;
		}

		public void SetPosition(Vector3 worldPosition)
		{
			Position = new Vector3Int(Mathf.RoundToInt(worldPosition.x), 0, Mathf.RoundToInt(worldPosition.z));
		}
	}
}
