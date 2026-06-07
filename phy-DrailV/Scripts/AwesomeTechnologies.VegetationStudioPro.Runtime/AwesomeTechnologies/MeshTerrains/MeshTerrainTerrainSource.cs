using System;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	[Serializable]
	public struct MeshTerrainTerrainSource
	{
		public Terrain Terrain;

		public TerrainSourceID TerrainSourceID;

		public MaterialPropertyBlock MaterialPropertyBlock;
	}
}
