using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CouplersCloseStep : AQuickTutorialStep
	{
		private Coupler a;

		private Coupler b;

		public CouplersCloseStep(Coupler a, Coupler b, string message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			: base(message, a.transform, offset, shouldRecheck)
		{
			this.a = a;
			this.b = b;
		}

		protected override bool InternalCheck()
		{
			return Vector3.Distance(a.transform.position, b.transform.position) < 0.6f;
		}
	}
}
