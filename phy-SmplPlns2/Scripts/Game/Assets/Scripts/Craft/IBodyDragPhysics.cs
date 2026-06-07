using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public interface IBodyDragPhysics
	{
		float TotalDragForceMagnitude { get; }

		float WaveDragMultiplier { get; }

		void AddDrag(PartDrag partDrag);

		void AddFrameDrag(PartDrag.DragDirection direction, float drag, Vector3 position);

		void ApplyDrag(Vector3 velocity);

		void CalculateDrag();

		IPartDragPhysics CreatePartDragPhysics(PartScript part);

		void OnFloatingOriginChanged(Vector3 delta);

		void OnRepositioned();
	}
}
