using UnityEngine;

namespace GRP
{
	public class GrabberPartView : PartView<GrabberPartViewable>
	{
		public GrabberVisual visual;

		public Transform right;

		public Transform left;

		public Transform bottom;

		public Transform forward;

		public Transform back;

		protected override void OnRender()
		{
		}
	}
}
