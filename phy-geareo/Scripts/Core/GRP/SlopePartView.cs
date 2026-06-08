using UnityEngine;

namespace GRP
{
	public class SlopePartView : PartView<SlopePartViewable>
	{
		public SlopeVisual visual;

		public MeshFilter highlightMeshFilter;

		public Transform bottom;

		public Transform back;

		public Transform slope;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
