using System.Collections.Generic;
using Events;
using UnityEngine;

namespace CustomAttributes.PrefabPlaceBrushTool
{
	[CreateAssetMenu(menuName = "Events/UneraseGrassEvent", fileName = "UneraseGrassEvent", order = 0)]
	public class UneraseGrassEventSO : BaseEvent<List<Vector3Int>>
	{
	}
}
