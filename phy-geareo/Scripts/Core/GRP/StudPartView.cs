using UnityEngine;

namespace GRP
{
	public class StudPartView : PartView<StudPartViewable>
	{
		public SphereVisual bodyVisual;

		public CylinderVisual shaftVisual;

		public Transform top;

		public Transform bottom;

		public Transform left;

		public Transform right;

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
