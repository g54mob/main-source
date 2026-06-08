using Timberborn.BlueprintSystem;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	public record WaterInputSpec : ComponentSpec
	{
		[Serialize]
		public Vector3Int WaterInputCoordinates { get; init; }

		[Serialize]
		public int MaxDepth { get; init; }

		[Serialize]
		public string PipeSegmentPrefabPath { get; init; }

		[Serialize]
		public string PipeParentName { get; init; }
	}
}
