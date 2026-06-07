using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class BSPTree3D
	{
		private BSPTree3DNode root_;

		public void Build(EditableMesh editable_mesh)
		{
			List<SimplePolygon> convexHulls = editable_mesh.GetConvexHulls();
			root_ = BuildBSP(new EditableMesh(convexHulls));
		}

		private BSPTree3DNode BuildBSP(EditableMesh editable_mesh)
		{
			if (editable_mesh.IsEmpty())
			{
				return null;
			}
			BSPTree3DNode bSPTree3DNode = new BSPTree3DNode();
			editable_mesh.InvalidateCache();
			bSPTree3DNode.AddCoPolygon(editable_mesh.GetPolygon(0));
			PlaneEx plane = editable_mesh.GetPolygon(0).plane;
			PlaneEx planeEx = plane.Clone().Flip();
			EditableMesh editableMesh = new EditableMesh();
			EditableMesh editableMesh2 = new EditableMesh();
			for (int i = 1; i < editable_mesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editable_mesh.GetPolygon(i);
				if (plane.IsEquivalent(polygon.plane) || planeEx.IsEquivalent(polygon.plane))
				{
					bSPTree3DNode.AddCoPolygon(polygon);
					continue;
				}
				polygon.ClipByPlane(plane, out var abovePolygons, out var belowPolygons);
				int num = 0;
				while (abovePolygons != null && num < abovePolygons.GetPolygonCount())
				{
					editableMesh.AddPolygon(abovePolygons.GetPolygon(num));
					num++;
				}
				int num2 = 0;
				while (belowPolygons != null && num2 < belowPolygons.GetPolygonCount())
				{
					editableMesh2.AddPolygon(belowPolygons.GetPolygon(num2));
					num2++;
				}
			}
			if (editableMesh.GetPolygonCount() > 0)
			{
				bSPTree3DNode.positive = BuildBSP(editableMesh);
			}
			if (editableMesh2.GetPolygonCount() > 0)
			{
				bSPTree3DNode.negative = BuildBSP(editableMesh2);
			}
			return bSPTree3DNode;
		}

		public bool IsInside(SimplePolygon polygon)
		{
			Partitions3D partitions = GetPartitions(polygon);
			if (partitions.positives.IsEmpty() && partitions.coNegative.IsEmpty())
			{
				return partitions.coPositive.IsEmpty();
			}
			return false;
		}

		public Partitions3D GetPartitions(SimplePolygon polygon)
		{
			Partitions3D partitions3D = new Partitions3D();
			if (root_ != null)
			{
				root_.GetPartitions(polygon, partitions3D);
			}
			return partitions3D;
		}
	}
}
