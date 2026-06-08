using Timberborn.BlueprintSystem;
using UnityEngine;

namespace Timberborn.WaterBuildings
{
	internal record WaterOutputSpec : ComponentSpec
	{
		[Serialize]
		public Vector3Int WaterCoordinates { get; init; }
	}
}
