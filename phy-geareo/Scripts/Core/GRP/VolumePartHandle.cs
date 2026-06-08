using UnityEngine;

namespace GRP
{
	public class VolumePartHandle : PartHandle<VolumePart>
	{
		public AxisHandle handleRight;

		public AxisHandle handleLeft;

		public AxisHandle handleUp;

		public AxisHandle handleDown;

		public AxisHandle handleForward;

		public AxisHandle handleBack;

		public AxisHandle handleSide;

		public AxisHandle handleRadius;

		public AxisHandle handleTopHeight;

		public AxisHandle handleBottomHeight;

		public GameObject isBox;

		public GameObject isSphere;

		public GameObject isCylinder;

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
