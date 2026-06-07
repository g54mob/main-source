using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Utility
{
	[Serializable]
	[CreateAssetMenu(menuName = "Motorways/RoadTileOverride")]
	public class RoadTileMeshOverride : ScriptableObject
	{
		[SerializeField]
		public List<RoadTileMeshOverrideDefinition> meshOverrides;
	}
}
