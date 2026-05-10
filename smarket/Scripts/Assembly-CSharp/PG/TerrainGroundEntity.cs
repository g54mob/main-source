using System;
using System.Collections.Generic;
using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(Terrain))]
	public class TerrainGroundEntity : IGroundEntity
	{
		[Serializable]
		public class TerrainGroundConfig
		{
			[SerializeField]
			private string Caption;

			public byte TextureIndex;

			public GroundType GroundType;
		}

		[SerializeField]
		private GroundType DefaultType;

		[SerializeField]
		private List<TerrainGroundConfig> GroundConfigs;

		[SerializeField]
		[HideInInspector]
		private byte[] DominateTextures;

		[SerializeField]
		[HideInInspector]
		private float StepX;

		[SerializeField]
		[HideInInspector]
		private float StepZ;

		private Dictionary<byte, GroundType> GroundConfigsDictionary;

		private Terrain Terrain;

		private TerrainData TerrainData;

		private Vector3 TerrainPos;

		public override GroundConfig GetGroundConfig(Vector3 position)
		{
			return null;
		}

		private void Awake()
		{
		}

		[ContextMenu("Cache dominant textures")]
		public void CacheDominantTextures()
		{
		}
	}
}
