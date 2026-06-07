using DV.CabControls;
using DV.CabControls.Spec;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CoupleHoseStep : AQuickTutorialStep
	{
		private GameObject[] gizmoParents;

		private CouplingHoseAdapterBase[] hoses;

		private Gizmo[] gizmos;

		private ControlImplBase[] grabbables;

		public CoupleHoseStep(CouplingHoseAdapterBase hoseAdapter, CouplingHoseAdapterBase otherAdapter, Gizmo gizmo, Gizmo otherGizmo, string message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, null, offset, shouldRecheck)
		{
			hoses = new CouplingHoseAdapterBase[2] { hoseAdapter, otherAdapter };
			gizmos = new Gizmo[2] { gizmo, otherGizmo };
			grabbables = new ControlImplBase[2]
			{
				gizmos[0].GetComponentInChildren<ControlImplBase>(),
				gizmos[1].GetComponentInChildren<ControlImplBase>()
			};
		}

		public CoupleHoseStep(CouplingHoseAdapterBase hoseAdapter, CouplingHoseAdapterBase otherAdapter, GameObject gizmoParent, GameObject otherGizmoParent, string message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, null, offset, shouldRecheck)
		{
			hoses = new CouplingHoseAdapterBase[2] { hoseAdapter, otherAdapter };
			gizmoParents = new GameObject[2] { gizmoParent, otherGizmoParent };
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			if (gizmoParents != null)
			{
				gizmos = new Gizmo[2];
				grabbables = new ControlImplBase[2];
				for (int i = 0; i < 2; i++)
				{
					gizmos[i] = gizmoParents[i].GetComponentInChildren<Gizmo>();
					grabbables[i] = (gizmos[i] ? gizmos[i].GetComponentInChildren<ControlImplBase>() : null);
				}
				if (gizmos[0] != null && gizmos[1] == null)
				{
					AttentionPoint = gizmos[0].transform;
				}
				else if (gizmos[0] == null && gizmos[1] != null)
				{
					AttentionPoint = gizmos[1].transform;
				}
			}
		}

		protected override bool InternalCheck()
		{
			for (int i = 0; i < 2; i++)
			{
				if (grabbables[i] != null && gizmos[1 - i] != null && grabbables[i].IsGrabbed() && AttentionPoint != gizmos[1 - i].transform)
				{
					AttentionPoint = gizmos[1 - i].transform;
					ShowVisual();
				}
			}
			return hoses[0].IsConnected;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Attach;
		}
	}
}
