using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CockOpenStep : AQuickTutorialStep
	{
		private Coupler coupler;

		private bool open;

		public CockOpenStep(Coupler coupler, AQuickTutorialMessage message, bool open, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, coupler.visualCoupler.hoseAdapter.cockGameObject.transform.GetChild(0), offset, shouldRecheck)
		{
			this.coupler = coupler;
			this.open = open;
		}

		protected override bool InternalCheck()
		{
			return coupler.IsCockOpen == open;
		}

		protected override QTVerb GetVerb()
		{
			if (!open)
			{
				return QTVerb.Close;
			}
			return QTVerb.Open;
		}
	}
}
