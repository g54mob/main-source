using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class EngineResourceManager
	{
		private static readonly List<VertexSelection> vertexSelectionObjects_ = new List<VertexSelection>();

		private Mesh renderableMesh = new Mesh();

		private readonly List<Material> renderableMaterials = new List<Material>();

		public Mesh RenderableMesh
		{
			get
			{
				if (renderableMesh == null)
				{
					renderableMesh = new Mesh();
				}
				return renderableMesh;
			}
		}

		public List<Material> RenderableMaterials => renderableMaterials;

		public List<VertexSelection> VertexSelections => vertexSelectionObjects_;

		public void Init()
		{
		}

		public void ClearSystemObjects()
		{
			ClearVertexSelectionObjects();
			if (renderableMesh != null)
			{
				renderableMesh = null;
			}
			renderableMaterials.Clear();
		}

		public VertexSelection GetVertexSelectionObject(int idx)
		{
			for (int i = 0; i < 1000; i++)
			{
				if (idx < vertexSelectionObjects_.Count)
				{
					break;
				}
				vertexSelectionObjects_.Add(new VertexSelection());
			}
			return vertexSelectionObjects_[idx];
		}

		public static void ClearVertexSelectionObjects()
		{
			vertexSelectionObjects_.Clear();
		}
	}
}
