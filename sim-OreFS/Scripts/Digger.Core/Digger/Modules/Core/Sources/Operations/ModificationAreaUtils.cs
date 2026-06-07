using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Operations
{
	public static class ModificationAreaUtils
	{
		public static ModificationArea GetSphericalAreaToModify(DiggerSystem digger, float3 position, float radius)
		{
			return GetAABBAreaToModify(digger, position, new float3(radius, radius, radius));
		}

		public static ModificationArea GetAABBAreaToModify(DiggerSystem digger, float3 position, float3 size)
		{
			float3 obj = (position - new float3(digger.Terrain.transform.position)) / digger.HeightmapScale;
			Vector3i vector3i = new Vector3i((int)((size.x + digger.CutMargin.x) / digger.HeightmapScale.x) + 1, (int)((size.y + digger.CutMargin.y) / digger.HeightmapScale.y) + 1, (int)((size.z + digger.CutMargin.z) / digger.HeightmapScale.z) + 1);
			Vector3i vector3i2 = new Vector3i(obj) - vector3i;
			Vector3i vector3i3 = new Vector3i(obj) + vector3i;
			Vector3i min = vector3i2 / digger.SizeOfMesh;
			Vector3i max = vector3i3 / digger.SizeOfMesh;
			if (vector3i2.x < 0)
			{
				min.x--;
			}
			if (vector3i2.y < 0)
			{
				min.y--;
			}
			if (vector3i2.z < 0)
			{
				min.z--;
			}
			if (vector3i3.x < 0)
			{
				max.x--;
			}
			if (vector3i3.y < 0)
			{
				max.y--;
			}
			if (vector3i3.z < 0)
			{
				max.z--;
			}
			if (max.x < 0 || max.z < 0 || min.x > digger.TerrainChunkWidth || min.z > digger.TerrainChunkHeight)
			{
				return new ModificationArea
				{
					NeedsModification = false
				};
			}
			if (min.x < 0)
			{
				min.x = 0;
			}
			if (min.z < 0)
			{
				min.z = 0;
			}
			if (max.x > digger.TerrainChunkWidth)
			{
				max.x = digger.TerrainChunkWidth;
			}
			if (max.z > digger.TerrainChunkHeight)
			{
				max.z = digger.TerrainChunkHeight;
			}
			int2 minMaxHeightWithin = digger.GetMinMaxHeightWithin(vector3i2, vector3i3);
			if (min.y <= minMaxHeightWithin.y && min.y > minMaxHeightWithin.x)
			{
				min.y = minMaxHeightWithin.x;
			}
			if (max.y >= minMaxHeightWithin.x && max.y < minMaxHeightWithin.y)
			{
				max.y = minMaxHeightWithin.y;
			}
			return new ModificationArea
			{
				NeedsModification = true,
				Min = min,
				Max = max
			};
		}
	}
}
