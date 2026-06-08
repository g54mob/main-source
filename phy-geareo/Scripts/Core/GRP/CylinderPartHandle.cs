using UnityEngine;

namespace GRP
{
	public class CylinderPartHandle : PartHandle<CylinderPart>
	{
		public AxisHandle handleUp;

		public AxisHandle handleDown;

		public AxisHandle handleSide;

		public AxisHandle handleTopRadius;

		public AxisHandle handleBottomRadius;

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
