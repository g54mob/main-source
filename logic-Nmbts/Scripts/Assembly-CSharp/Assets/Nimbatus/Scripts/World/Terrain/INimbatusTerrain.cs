using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.World.Terrain
{
	public interface INimbatusTerrain
	{
		bool IsBackground();

		bool HasCollider();

		string GetName();

		NimbatusTerrainData GenerateData(Vector3 worldPosition);
	}
}
