using UnityEngine;

namespace GRP
{
	public class LightPartView : PartView<LightPartViewable>
	{
		public LightVisual visual;

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
