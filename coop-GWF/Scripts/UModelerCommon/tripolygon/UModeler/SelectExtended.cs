using System;

namespace tripolygon.UModeler
{
	public class SelectExtended
	{
		[NonSerialized]
		private SelectionType selection_ = SelectionType.UnSelected;

		private SelectionType prevSelection_ = SelectionType.UnSelected;

		public SelectionType selection
		{
			get
			{
				return selection_;
			}
			set
			{
				prevSelection_ = selection_;
				selection_ = value;
			}
		}

		public void RevertSelection()
		{
			selection_ = prevSelection_;
		}

		public static void UnselectAll(EditableMesh editable_mesh = null)
		{
			UnselectAllEdges(editable_mesh);
			UnselectAllPolygons(editable_mesh);
			UnselectAllVertices(editable_mesh);
		}

		public static void RevertAllEdgeSelections(EditableMesh editable_mesh = null)
		{
			if (editable_mesh == null)
			{
				if (UMContext.activeModeler == null)
				{
					return;
				}
				editable_mesh = UMContext.activeModeler.editableMesh;
			}
			for (int i = 0; i < editable_mesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editable_mesh.GetPolygon(i);
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					IndexPair edge = polygon.GetEdge(j);
					if (edge.selection == SelectionType.PreSelected)
					{
						edge.RevertSelection();
					}
				}
			}
		}

		public static void UnselectAllVertices(EditableMesh editable_mesh = null)
		{
			if (editable_mesh == null)
			{
				if (UMContext.activeModeler == null)
				{
					return;
				}
				editable_mesh = UMContext.activeModeler.editableMesh;
			}
			EditableMeshCache editableMeshCache = editable_mesh.editableMeshCache;
			for (int i = 0; i < editableMeshCache.GetVertexCount(); i++)
			{
				VertexInfo vertexInfo = editableMeshCache.GetVertexInfo(i);
				if (vertexInfo != null)
				{
					vertexInfo.selection = SelectionType.UnSelected;
				}
			}
		}

		public static void UnselectAllEdges(EditableMesh editable_mesh = null)
		{
			if (editable_mesh == null)
			{
				if (UMContext.activeModeler == null)
				{
					return;
				}
				editable_mesh = UMContext.activeModeler.editableMesh;
			}
			for (int i = 0; i < editable_mesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editable_mesh.GetPolygon(i);
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					polygon.GetEdge(j).selection = SelectionType.UnSelected;
				}
			}
		}

		public static void UnselectAllPolygons(EditableMesh editable_mesh = null)
		{
			if (editable_mesh == null)
			{
				if (UMContext.activeModeler == null)
				{
					return;
				}
				editable_mesh = UMContext.activeModeler.editableMesh;
			}
			for (int i = 0; i < editable_mesh.GetPolygonCount(); i++)
			{
				editable_mesh.GetPolygon(i).EnableSelection(selected: false);
			}
		}

		public static void SetSelectedToEdge(Edge edge, bool selected, EditableMesh editable_mesh = null)
		{
			if (editable_mesh == null)
			{
				editable_mesh = UMContext.activeModeler.editableMesh;
			}
			for (int i = 0; i < editable_mesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editable_mesh.GetPolygon(i);
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					if (edge.IsEquivalent(polygon.GetPureEdge(j)))
					{
						IndexPair edge2 = polygon.GetEdge(j);
						if (selected && edge2.selection == SelectionType.UnSelected)
						{
							edge2.selection = SelectionType.Selected;
						}
						else if (!selected && edge2.selection != SelectionType.UnSelected)
						{
							edge2.selection = SelectionType.UnSelected;
						}
						return;
					}
				}
			}
		}
	}
}
