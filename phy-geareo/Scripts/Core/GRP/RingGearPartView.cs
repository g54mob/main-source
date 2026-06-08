using UnityEngine;

namespace GRP
{
	public class RingGearPartView : PartView<RingGearPartViewable>
	{
		public RingGearVisual visual;

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
