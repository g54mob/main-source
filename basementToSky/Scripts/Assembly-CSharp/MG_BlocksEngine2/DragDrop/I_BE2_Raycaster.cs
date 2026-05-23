using MG_BlocksEngine2.Block;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.DragDrop
{
	public interface I_BE2_Raycaster
	{
		GraphicRaycaster[] AddRaycaster(GraphicRaycaster raycaster);

		GraphicRaycaster[] RemoveRaycaster(GraphicRaycaster raycaster);

		I_BE2_Drag GetDragAtPosition(Vector2 position);

		I_BE2_Spot GetSpotAtPosition(Vector3 position);

		I_BE2_Spot FindClosestSpotOfType<T>(I_BE2_Drag drag, float maxDistance);
	}
}
