using UnityEngine;

namespace GRP
{
	public class BoxPartView : PartView<BoxPartViewable>
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
