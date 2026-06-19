using System;
using UnityEngine;

namespace TH20
{
	public class RoomItemModifyTerrainComponent : EntityComponent
	{
		private RoomItem _item;

		private int _cachedX;

		private int _cachedY;

		private float[,] _cachedHeights;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_item = GetOwner<RoomItem>();
		}

		public override void Destroy()
		{
			RestoreTerrain();
			base.Destroy();
		}

		public void ModifyTerrain()
		{
			RestoreTerrain();
			Terrain activeTerrain = Terrain.activeTerrain;
			if (!(activeTerrain != null))
			{
				return;
			}
			Bounds[] cachedBounds = _item.CachedBounds;
			ConvexPolygon combinedCollisionShape = _item.GetCombinedCollisionShape(worldSpace: true, includeSolid: true, includeNonSolid: true);
			if (cachedBounds == null || combinedCollisionShape == null)
			{
				return;
			}
			TerrainData terrainData = activeTerrain.terrainData;
			Bounds bounds = cachedBounds[0].Transform(_item.WorldPosition, Quaternion.Euler(0f, _item.Rotation, 0f));
			Vector3 position = activeTerrain.gameObject.transform.position;
			Vector3 vector = terrainData.WorldCoordToTerrain(bounds.center - position);
			Vector3 vector2 = terrainData.WorldCoordToTerrain(bounds.size);
			int num = (int)vector2.x;
			int num2 = (int)vector2.z;
			int num3 = (int)vector.x - num / 2;
			int num4 = (int)vector.z - num2 / 2;
			float num5 = vector.y - vector2.y;
			if (num3 < 0 || num3 + num >= terrainData.heightmapResolution || num4 < 0 || num4 + num2 >= terrainData.heightmapResolution)
			{
				return;
			}
			float[,] heights = terrainData.GetHeights(num3, num4, num, num2);
			_cachedX = num3;
			_cachedY = num4;
			_cachedHeights = heights.Clone() as float[,];
			for (int i = 0; i < heights.GetLength(0); i++)
			{
				for (int j = 0; j < heights.GetLength(1); j++)
				{
					Vector3 terrainCoord = new Vector3(num3 + j, 0f, num4 + i);
					Vector3 vector3 = terrainData.TerrainCoordToWorld(terrainCoord);
					vector3.x += position.x;
					vector3.z += position.z;
					if (combinedCollisionShape.PointInPoly(vector3.x, vector3.z))
					{
						heights[i, j] = num5;
					}
				}
			}
			terrainData.SetHeights(num3, num4, heights);
		}

		public void RestoreTerrain()
		{
			if (_cachedHeights != null)
			{
				Terrain activeTerrain = Terrain.activeTerrain;
				if (activeTerrain != null)
				{
					activeTerrain.terrainData.SetHeights(_cachedX, _cachedY, _cachedHeights);
				}
				_cachedHeights = null;
			}
		}
	}
}
