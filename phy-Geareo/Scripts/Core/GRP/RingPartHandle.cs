using UnityEngine;

namespace GRP
{
	public class RingPartHandle : PartHandle<RingPart>
	{
		public AxisHandle offsetHandle;

		public Transform offsetHandleBody;

		public AxisHandle arcHandle;

		public Transform arcHandleBody;

		public AxisHandle heightTopHandle;

		public AxisHandle heightBottomHandle;

		public AxisHandle thicknessHandle;

		public AxisHandle topThicknessHandle;

		public AxisHandle bottomThicknessHandle;

		public AxisHandle radiusHandle;

		public AxisHandle topRadiusHandle;

		public AxisHandle bottomRadiusHandle;

		public float handleScaleMultiplier;

		protected override void Setup()
		{
		}

		protected override void OnCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
