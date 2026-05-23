using MG_BlocksEngine2.Block;
using UnityEngine;

namespace MG_BlocksEngine2.DragDrop
{
	public interface I_BE2_Drag
	{
		Transform Transform { get; }

		Vector2 RayPoint { get; }

		I_BE2_Block Block { get; }

		void OnPointerDown();

		void OnRightPointerDownOrHold();

		void OnDragStart();

		void OnDrag();

		void OnPointerUp();
	}
}
