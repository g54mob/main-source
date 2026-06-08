using UnityEngine;

namespace GRP
{
	public class CamPartView : PartView<CamPartViewable>
	{
		public CamPartVisual visual;

		public MeshFilter highlightMeshFilter;

		public Transform top;

		public Transform bottom;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}
	}
}
