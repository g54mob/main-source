using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public abstract class MouseElement : Element, IMouseUIElement
	{
		protected bool HasMouseFocus;

		public override void Initialise()
		{
			base.Initialise();
			MouseUI.Main.Register(this);
		}

		public override void Destroy()
		{
			MouseUI.Main.Deregister(this);
			base.Destroy();
		}

		public override void UpdateFocus()
		{
			base.UpdateFocus();
			SetAnimBool("HasMouseFocus", HasMouseFocus);
		}

		public virtual void OnMouseUIDown()
		{
		}

		public virtual void OnMouseUIUp(Vector3 position)
		{
		}

		public virtual void OnMouseUIRollOver()
		{
			if (IsSelectable)
			{
				HasMouseFocus = true;
				UpdateFocus();
			}
		}

		public virtual void OnMouseUIRollOut()
		{
			if (IsSelectable)
			{
				HasMouseFocus = false;
				UpdateFocus();
			}
		}

		protected Vector3 RelativePosition(Vector3 world_point)
		{
			Transform parent = base.transform;
			if (parent.parent != null)
			{
				parent = parent.parent;
			}
			return parent.InverseTransformPoint(world_point);
		}

		public bool IntersectsPoint(Vector3 world_point)
		{
			Vector3 point = RelativePosition(world_point);
			Bounds boundingBox = BoundingBox;
			point.z = boundingBox.center.z;
			return boundingBox.Contains(point);
		}
	}
}
