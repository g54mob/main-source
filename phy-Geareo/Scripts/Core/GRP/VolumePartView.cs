using UnityEngine;

namespace GRP
{
	public class VolumePartView : PartView<VolumePartViewable>
	{
		public VolumeVisual visual;

		public Transform right;

		public Transform left;

		public Transform top;

		public Transform bottom;

		public Transform forward;

		public Transform back;

		protected override void OnRender()
		{
		}
	}
}
