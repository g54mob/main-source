using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class GluePartView : PartView<GluePartViewable>
	{
		public Transform body;

		public Renderer renderer;

		public Material material;

		public Material softMaterial;

		public PhysicsMaterial glueMaterial;

		private Highlight highlight;

		private List<Highlightable> highlightables;

		protected override void OnViewOpen()
		{
		}

		protected override void OnViewClose()
		{
		}

		protected override void OnRender()
		{
		}

		public List<PartView> GetNeighbors()
		{
			return null;
		}
	}
}
