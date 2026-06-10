using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class DynamicCombinedObjectPartInternal : DynamicCombinedObjectPart
	{
		private Matrix4x4 _localTransform;

		private Matrix4x4 _targetLocalTransform;

		private Matrix4x4 _worldToLocalMatrix;

		private bool _inMove;

		public DynamicCombinedObjectPartInternal(DynamicCombinedObject root, CombinedObjectPart basePart, Matrix4x4 transformMatrix)
			: base(root, basePart, transformMatrix)
		{
			Vector3 pos = transformMatrix.GetTranslation() - root.transform.position;
			_localTransform = transformMatrix.SetTranslation(pos);
			_worldToLocalMatrix = base.Root.transform.worldToLocalMatrix;
		}

		public override void Move(Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Move(Matrix4x4.TRS(position, rotation, scale));
		}

		public override void Move(Matrix4x4 transform)
		{
			Matrix4x4 localTransform = _worldToLocalMatrix * transform;
			MoveLocal(localTransform);
		}

		public override void MoveLocal(Matrix4x4 localTransform)
		{
			if (!_inMove)
			{
				_targetLocalTransform = localTransform;
				_root.UpdatePart(this);
				_inMove = true;
			}
		}

		public PartMoveInfo CreateMoveInfo()
		{
			CombinedMeshPart meshPart = _basePart.MeshPart;
			return new PartMoveInfo
			{
				partIndex = meshPart.Index,
				vertexStart = meshPart.VertexStart,
				vertexCount = meshPart.VertexCount,
				currentTransform = _localTransform,
				targetTransform = _targetLocalTransform
			};
		}

		public void PositionUpdated()
		{
			_localTransform = _targetLocalTransform;
			_inMove = false;
		}
	}
}
