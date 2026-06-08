using UnityEngine;

namespace GRP
{
	public class SpurGearPartHandle : PartHandle<SpurGearPart, SpurGearPartView>
	{
		public AxisHandle handleUp;

		public AxisHandle handleDown;

		public AxisHandle handleSide;

		public AxisHandle handleInnerRadius;

		public AxisHandle handleSkip;

		public Transform side;

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
