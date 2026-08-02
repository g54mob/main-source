using UnityEngine;

namespace GRP
{
	public class WingPartView : PartView<WingPartViewable>
	{
		public BoxVisual visual;

		public Transform right;

		public Transform left;

		public Transform top;

		public Transform bottom;

		public Transform forward;

		public Transform back;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
