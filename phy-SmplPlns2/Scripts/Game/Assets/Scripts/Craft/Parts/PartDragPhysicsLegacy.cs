using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartDragPhysicsLegacy : IPartDragPhysics
	{
		private BodyDragPhysicsLegacy _dragPhysics;

		private PartScript _part;

		private PartDrag _underWaterFrameDrag;

		public PartDragPhysicsLegacy(PartScript part, BodyDragPhysicsLegacy dragPhysics)
		{
			_part = part;
			_underWaterFrameDrag = new PartDrag();
			_dragPhysics = dragPhysics;
		}

		public void FixedUpdate()
		{
			if (_part.EstimateOfUnderwaterPercent > 0f)
			{
				_underWaterFrameDrag.SetPosition(_part.transform.position);
				_dragPhysics.AddWaterFrameDrag(_underWaterFrameDrag);
				_dragPhysics.SetFrameAngularDrag(_part.EstimateOfUnderwaterPercent * 0.5f);
			}
		}

		public void Update(float estimateOfUnderwaterPercent)
		{
			if (_part.EstimateOfUnderwaterPercent > 0f)
			{
				float scale = _part.Part.UnderwaterDragScalar * Mathf.Clamp(_part.EstimateOfUnderwaterPercent, 0f, 1f);
				_part.Part.PartDrag.Copy(_underWaterFrameDrag, scale);
			}
		}
	}
}
