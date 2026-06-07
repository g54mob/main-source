using UnityEngine;

namespace DV.Customization.Gadgets
{
	public struct AttachmentPosition
	{
		public Vector3 offset;

		public Quaternion rotation;

		public AttachmentPosition(Vector3 offset, Quaternion rotation, Transform source, Transform root)
		{
			this.offset = root.InverseTransformPoint(source.TransformPoint(offset));
			this.rotation = Quaternion.Inverse(root.rotation) * source.rotation * rotation;
		}
	}
}
