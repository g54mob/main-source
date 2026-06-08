using UnityEngine;

namespace GRP
{
	public class BevelGearPartHandle : PartHandle<BevelGearPart, BevelGearPartView>
	{
		public AxisHandle handleUp;

		public AxisHandle handleDown;

		public AxisHandle handleSide;

		public AxisHandle handleInnerRadius;

		public AxisHandle handleAngle;

		public AxisHandle handleSkip;

		public Transform side;

		public Transform angle;

		protected override void Setup()
		{
		}

		protected override void OnCreated()
		{
		}

		protected override void LateUpdate()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
