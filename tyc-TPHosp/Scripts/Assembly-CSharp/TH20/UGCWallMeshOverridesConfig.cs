using System;
using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/UGC Wall Mesh Overrides")]
	public class UGCWallMeshOverridesConfig : ScriptableObjectWithID
	{
		[Serializable]
		public struct OverrideDefinition
		{
			public Mesh Mesh;

			public int MaterialIndex;
		}

		public OverrideDefinition[] OverrideDefinitions;
	}
}
