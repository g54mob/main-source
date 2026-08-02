using UnityEngine;

namespace GRP
{
	public class RingPartView : PartView<RingPartViewable>
	{
		public RingVisual visual;

		public MeshFilter highlightMeshFilter;

		public SnapPoint snapPointPrefab;

		public float handleScaleMultiplier;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		private void BuildSnapPoints()
		{
		}
	}
}
