using UnityEngine;

namespace GRP
{
	public class RelTransform
	{
		public Part anchor;

		public Part part;

		public Vector3 position;

		public Quaternion rotation;

		public PartView partView;

		public DraggablePart draggablePart;

		public Collider[] colliders;

		public RelTransform(Part anchor, Part part)
		{
		}

		public void Apply()
		{
		}
	}
}
