using System.Collections.Generic;
using Events;
using UnityEngine;

namespace CustomAttributes.PrefabPlaceBrushTool
{
	[CreateAssetMenu(menuName = "Events/EraseGrassEvent", fileName = "EraseGrassEvent", order = 0)]
	public class EraseGrassEventSO : BaseEvent<List<Vector3Int>>
	{
	}
}
