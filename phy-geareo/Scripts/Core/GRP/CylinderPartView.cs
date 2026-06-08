using UnityEngine;

namespace GRP
{
	public class CylinderPartView : PartView<CylinderPartViewable>
	{
		public CircularPrismVisual visual;

		public MeshFilter highlightMeshFilter;

		public SnapPoint snapPointPrefab;

		public Transform top;

		public Transform bottom;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		public void BuildSnapPoints()
		{
		}
	}
}
