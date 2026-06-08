using UnityEngine;

namespace GRP
{
	public class RingGearPartHandle : PartHandle<RingGearPart, RingGearPartView>
	{
		public AxisHandle handleTeeth;

		public AxisHandle handleThickness;

		public AxisHandle handleUp;

		public AxisHandle handleDown;

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
