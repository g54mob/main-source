using UnityEngine;

namespace GRP
{
	public class LinearBearingPartView : PartView<LinearBearingPartViewable>
	{
		public BoxVisual body;

		public BoxVisual shaft;

		public BoxVisual core;

		public LinearBearingMotorVisual motor;

		public Transform left;

		public Transform right;

		public Transform forward;

		public Transform back;

		public Transform top;

		public Transform bottom;

		public float spacing;

		private MagicController magicController;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		public static void BuildCore(LinearBearingPart part, BoxVisual coreVisual)
		{
		}
	}
}
