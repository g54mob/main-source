using UnityEngine;

namespace Kitchen.Modules
{
	public class SpacerElement : Element
	{
		public float Size = 0.2f;

		public override Bounds BoundingBox => new Bounds
		{
			center = ((this != null) ? base.transform.localPosition : Vector3.zero),
			size = new Vector3(Size, Size, 0f)
		};

		public override bool IsSelectable => false;
	}
}
