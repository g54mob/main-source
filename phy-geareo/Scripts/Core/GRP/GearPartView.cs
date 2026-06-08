using UnityEngine;

namespace GRP
{
	public class GearPartView : PartView<GearPartViewable>
	{
		public GearVisual gearVisual;

		public Transform selectedBody;

		public AxisHandle handleUp;

		public AxisHandle handleDown;

		public AxisHandle handleSide;

		public AxisHandle handleAngle;

		public Transform side;

		public Transform top;

		public Transform bottom;

		public Transform angle;

		public Vector3 minSize;

		public Vector3 maxSize;

		private Vector3 startPosition;

		private Vector3 startSize;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void LateUpdate()
		{
		}
	}
}
