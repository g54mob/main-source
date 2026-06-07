using System;
using UnityEngine;

namespace Motorways.Utility
{
	[Serializable]
	public class RoadTileMeshOverrideDefinition
	{
		[SerializeField]
		public int directions;

		[SerializeField]
		public RoadTileMesh meshes;
	}
}
