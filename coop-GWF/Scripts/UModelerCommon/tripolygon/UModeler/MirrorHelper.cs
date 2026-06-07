using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class MirrorHelper
	{
		public static bool IsMirrorMode(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			return edMesh.mirrorMode.enable;
		}

		public static void SetMirrorPropertyJSON(string json, EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			edMesh.mirrorMode.propertyJSON = json;
		}

		public static string GetMirrorPropertyJSON(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			return edMesh.mirrorMode.propertyJSON;
		}

		public static void EnableMirrorMode(PlaneEx mirrorPlane, EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			edMesh.mirrorMode.enable = true;
			edMesh.mirrorMode.plane = mirrorPlane.Clone();
			edMesh.mirrorMode.Backup(edMesh);
		}

		public static void CancelMirrorMode(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			edMesh.mirrorMode.enable = false;
			edMesh.mirrorMode.plane = null;
			edMesh.mirrorMode.Backup(null);
			edMesh.DisableMirrorMode();
		}

		public static void DisableMirrorMode(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			edMesh.mirrorMode.enable = false;
			edMesh.mirrorMode.plane = null;
			edMesh.mirrorMode.Backup(null);
			edMesh.DisableMirrorMode();
		}

		public static PlaneEx GetMirrorPlane(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			if (!IsMirrorMode(edMesh))
			{
				return null;
			}
			return edMesh.mirrorMode.plane;
		}

		public static bool IsMirrored(VertexInfo vi)
		{
			PlaneEx mirrorPlane = GetMirrorPlane();
			if (mirrorPlane == null)
			{
				return false;
			}
			foreach (Token token in vi.tokens)
			{
				if (!IsMirrored(token.polygon))
				{
					return mirrorPlane.CalcDistanceToPoint(vi.pos) < 0f;
				}
			}
			return true;
		}

		public static bool IsMirrored(SimplePolygon polygon)
		{
			PlaneEx mirrorPlane = GetMirrorPlane();
			if (mirrorPlane == null)
			{
				return false;
			}
			return mirrorPlane.CalcDistanceToPoint(polygon.GetCenter()) <= 0f;
		}

		public static bool IsOnMirrorPlane(SimplePolygon polygon, EditableMesh edMesh = null)
		{
			if (polygon == null)
			{
				return false;
			}
			PlaneEx mirrorPlane = GetMirrorPlane(edMesh);
			if (mirrorPlane == null)
			{
				return false;
			}
			if (!mirrorPlane.IsEquivalent(polygon.plane))
			{
				return mirrorPlane.Clone().Flip().IsEquivalent(polygon.plane);
			}
			return true;
		}

		public static bool IsPolygonCloseToMirrorPlane(SimplePolygon polygon)
		{
			PlaneEx mirrorPlane = GetMirrorPlane();
			if (mirrorPlane == null)
			{
				return false;
			}
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				Vector3 pos = polygon.GetVertex(i).pos;
				if (Mathf.Abs(mirrorPlane.CalcDistanceToPoint(pos)) <= 0f)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsPolygonAcrossMirrorPlane(SimplePolygon polygon)
		{
			PlaneEx mirrorPlane = GetMirrorPlane();
			if (mirrorPlane == null)
			{
				return false;
			}
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge pureEdge = polygon.GetPureEdge(i);
				float num = mirrorPlane.CalcDistanceToPoint(pureEdge.p0);
				float num2 = mirrorPlane.CalcDistanceToPoint(pureEdge.p1);
				if (num * num2 < 0f)
				{
					return true;
				}
			}
			return false;
		}

		public static List<SimplePolygon> GetAllMirroredPolygons(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			List<SimplePolygon> list = null;
			for (int i = 0; i < edMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = edMesh.GetPolygon(i);
				if (IsMirrored(polygon))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public static void RemoveAllMirroredPolygons(EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			List<SimplePolygon> allMirroredPolygons = GetAllMirroredPolygons(edMesh);
			if (allMirroredPolygons != null)
			{
				for (int i = 0; i < allMirroredPolygons.Count; i++)
				{
					edMesh.RemovePolygon(allMirroredPolygons[i]);
				}
			}
		}

		public static void MirrorAll(int shelf = -1, EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			PlaneEx mirrorPlane = GetMirrorPlane(edMesh);
			if (mirrorPlane == null)
			{
				return;
			}
			SmoothingGroupManager smoothingGroups = UMContext.activeModeler.editableMesh.smoothingGroups;
			using (new ShelfHolder())
			{
				for (int i = 0; i < 2; i++)
				{
					if (shelf == -1 || shelf == i)
					{
						edMesh.shelf = i;
						RemoveAllMirroredPolygons(edMesh);
						int polygonCount = edMesh.GetPolygonCount();
						for (int j = 0; j < polygonCount; j++)
						{
							SimplePolygon polygon = edMesh.GetPolygon(j);
							SimplePolygon polygon2 = polygon.Clone().Mirror(mirrorPlane);
							smoothingGroups.FindSmoothingGroupIncludingPolygon(polygon)?.AddPolygon(polygon2);
							edMesh.AddPolygon(polygon2);
						}
					}
				}
			}
		}
	}
}
