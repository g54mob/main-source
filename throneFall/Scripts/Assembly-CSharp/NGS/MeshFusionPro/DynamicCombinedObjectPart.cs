using UnityEngine;

namespace NGS.MeshFusionPro
{
	public abstract class DynamicCombinedObjectPart : ICombinedObjectPart<DynamicCombinedObject>, ICombinedObjectPart
	{
		protected DynamicCombinedObject _root;

		protected CombinedObjectPart _basePart;

		private bool _destroyed;

		ICombinedObject ICombinedObjectPart.Root => Root;

		public DynamicCombinedObject Root => _root;

		public Bounds LocalBounds => _basePart.LocalBounds;

		public Bounds Bounds => _basePart.Bounds;

		public DynamicCombinedObjectPart(DynamicCombinedObject root, CombinedObjectPart basePart, Matrix4x4 transformMatrix)
		{
			_root = root;
			_basePart = basePart;
		}

		public abstract void Move(Vector3 position, Quaternion rotation, Vector3 scale);

		public abstract void Move(Matrix4x4 transform);

		public abstract void MoveLocal(Matrix4x4 localTransform);

		public void Destroy()
		{
			if (_destroyed)
			{
				Debug.Log("Part already destroyed");
			}
			else
			{
				_root.Destroy(this, _basePart);
			}
		}
	}
}
