using UnityEngine;

namespace GRP
{
	public class CamPartHandle : PartHandle<CamPart>
	{
		public AxisHandle handleTop;

		public AxisHandle handleBottom;

		public AxisHandle handleRadius;

		public AxisHandle handleThickness;

		public Transform side;

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
