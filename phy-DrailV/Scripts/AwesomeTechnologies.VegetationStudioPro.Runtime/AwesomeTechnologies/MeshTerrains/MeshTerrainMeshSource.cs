using System;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.MeshTerrains
{
	[Serializable]
	public struct MeshTerrainMeshSource
	{
		public MeshRenderer MeshRenderer;

		public TerrainSourceID TerrainSourceID;

		public MaterialPropertyBlock MaterialPropertyBlock;
	}
}
