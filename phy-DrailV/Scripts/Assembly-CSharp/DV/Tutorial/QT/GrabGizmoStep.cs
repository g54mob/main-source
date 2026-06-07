using DV.CabControls;
using DV.CabControls.Spec;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class GrabGizmoStep : AQuickTutorialStep
	{
		private GameObject gizmoParent;

		private GameObject gizmoParentAlt;

		private ControlImplBase control;

		private ControlImplBase controlAlt;

		public GrabGizmoStep(GameObject gizmoParent, GameObject gizmoParentAlt, AQuickTutorialMessage message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, gizmoParent.transform, offset, shouldRecheck)
		{
			this.gizmoParent = gizmoParent;
			this.gizmoParentAlt = gizmoParentAlt;
		}

		public GrabGizmoStep(Gizmo gizmo, Gizmo alternativeGizmo, AQuickTutorialMessage message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, gizmo.transform, offset, shouldRecheck)
		{
			control = gizmo.GetComponent<ControlImplBase>();
			controlAlt = (alternativeGizmo ? alternativeGizmo.GetComponent<ControlImplBase>() : null);
		}

		protected override void InternalMakeCurrent()
		{
			if (gizmoParent != null)
			{
				Gizmo componentInChildren = gizmoParent.GetComponentInChildren<Gizmo>(includeInactive: true);
				control = (componentInChildren ? componentInChildren.GetComponent<ControlImplBase>() : null);
				if ((bool)componentInChildren)
				{
					AttentionPoint = componentInChildren.transform;
				}
			}
			if (gizmoParentAlt != null)
			{
				Gizmo componentInChildren2 = gizmoParentAlt.GetComponentInChildren<Gizmo>(includeInactive: true);
				controlAlt = (componentInChildren2 ? componentInChildren2.GetComponent<ControlImplBase>() : null);
			}
		}

		protected override bool InternalCheck()
		{
			if ((bool)controlAlt && controlAlt.IsGrabbed())
			{
				return true;
			}
			if (!control)
			{
				return true;
			}
			return control.IsGrabbed();
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Grab;
		}
	}
}
