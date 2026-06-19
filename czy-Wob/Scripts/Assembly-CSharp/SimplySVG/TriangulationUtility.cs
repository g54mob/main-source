using System;
using System.Collections.Generic;
using ClipperLib;
using Poly2Tri;
using UnityEngine;

namespace SimplySVG
{
	public static class TriangulationUtility
	{
		public static bool ClipFill(List<GraphicalElement.ContourPath> contourPaths, PolyFillType fillRule, out PolyTree fillTree)
		{
			Clipper clipper = new Clipper();
			clipper.StrictlySimple = true;
			fillTree = new PolyTree();
			int num = 0;
			for (int i = 0; i < contourPaths.Count; i++)
			{
				if (contourPaths[i].clipperPath.Count >= 3)
				{
					clipper.AddPath(contourPaths[i].clipperPath, PolyType.ptSubject, Closed: true);
					num++;
				}
			}
			if (num < 1)
			{
				return true;
			}
			if (!clipper.Execute(ClipType.ctUnion, fillTree, fillRule, fillRule))
			{
				return false;
			}
			return true;
		}

		public static bool ClipStroke(List<GraphicalElement.ContourPath> contourPaths, PolyFillType fillRule, float strokeWidth, float miterLimit, out PolyTree openStrokeTree, out PolyTree closedStrokeTree)
		{
			openStrokeTree = new PolyTree();
			closedStrokeTree = new PolyTree();
			if (strokeWidth == 0f)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			ClipperOffset clipperOffset = new ClipperOffset(miterLimit);
			Clipper clipper = new Clipper();
			clipper.StrictlySimple = true;
			int num = 0;
			for (int i = 0; i < contourPaths.Count; i++)
			{
				if (contourPaths[i].closed && contourPaths[i].clipperPath.Count >= 3)
				{
					clipper.AddPath(contourPaths[i].clipperPath, PolyType.ptSubject, Closed: true);
					num++;
					flag2 = true;
				}
				else if (contourPaths[i].clipperPath.Count >= 2)
				{
					clipperOffset.AddPath(contourPaths[i].clipperPath, JoinType.jtMiter, EndType.etOpenButt);
					num++;
					flag = true;
				}
			}
			if (flag && num > 0)
			{
				clipperOffset.Execute(ref openStrokeTree, (double)(strokeWidth / 2f) * GraphicalElement.clipperCoordinateScale);
			}
			if (flag2 && num > 0)
			{
				List<List<IntPoint>> list = new List<List<IntPoint>>();
				clipper.Execute(ClipType.ctUnion, list);
				ClipperOffset clipperOffset2 = new ClipperOffset(miterLimit);
				clipperOffset2.AddPaths(list, JoinType.jtMiter, EndType.etClosedPolygon);
				List<List<IntPoint>> solution = new List<List<IntPoint>>();
				List<List<IntPoint>> solution2 = new List<List<IntPoint>>();
				clipperOffset2.Execute(ref solution, 0.0 - (double)strokeWidth * GraphicalElement.clipperCoordinateScale / 2.0);
				clipperOffset2.Execute(ref solution2, (double)strokeWidth * GraphicalElement.clipperCoordinateScale / 2.0);
				Clipper clipper2 = new Clipper();
				clipper2.StrictlySimple = true;
				clipper2.AddPaths(solution2, PolyType.ptSubject, closed: true);
				clipper2.AddPaths(solution, PolyType.ptClip, closed: true);
				if (!clipper2.Execute(ClipType.ctDifference, closedStrokeTree, fillRule, fillRule))
				{
					return false;
				}
			}
			return true;
		}

		public static bool ClipStencil(PolyTree subject, PolyTree stencil, out PolyTree result)
		{
			Clipper obj = new Clipper
			{
				StrictlySimple = true
			};
			result = new PolyTree();
			obj.AddPaths(Clipper.PolyTreeToPaths(subject), PolyType.ptSubject, closed: true);
			obj.AddPaths(Clipper.PolyTreeToPaths(stencil), PolyType.ptClip, closed: true);
			return obj.Execute(ClipType.ctIntersection, result, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		}

		public static bool TriangulatePolyTree(PolyTree polyTree, Color color, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			if (polyTree.ChildCount == 0)
			{
				if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
				{
					Debug.LogWarning("Polytree is empty. Cannot triangulate.");
				}
				return false;
			}
			foreach (PolyNode child in polyTree.Childs)
			{
				if (!RecurseAndTriangulatePolyTree(child, color, ref meshVertices, ref meshTriangles, ref meshVertexColors))
				{
					return false;
				}
			}
			return true;
		}

		private static bool RecurseAndTriangulatePolyTree(PolyNode node, Color color, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			Queue<PolyNode> queue = new Queue<PolyNode>();
			if (node.IsHole)
			{
				foreach (PolyNode child in node.Childs)
				{
					queue.Enqueue(child);
				}
			}
			else
			{
				Polygon polygon = ConvertIntPointsToPolygon(Clipper.CleanPolygon(node.Contour));
				if (polygon == null)
				{
					if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
					{
						Debug.LogWarning("Building subject polygon failed. Skipping.");
					}
					return false;
				}
				foreach (PolyNode child2 in node.Childs)
				{
					if (child2.IsHole)
					{
						Polygon polygon2 = ConvertIntPointsToPolygon(Clipper.CleanPolygon(child2.Contour));
						if (polygon2 == null)
						{
							if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
							{
								Debug.LogWarning("Building hole polygon failed. Skipping.");
							}
							continue;
						}
						polygon.AddHole(polygon2);
					}
					if (child2.ChildCount > 0)
					{
						queue.Enqueue(child2);
					}
				}
				try
				{
					P2T.Triangulate(polygon);
				}
				catch (Exception ex)
				{
					if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS)
					{
						Debug.LogError("Polygon triangulation failed with an exception: " + ex.Message);
					}
				}
				if (polygon.Triangles.Count > 0)
				{
					AppendToMeshData(polygon.Triangles, color, ref meshVertices, ref meshTriangles, ref meshVertexColors);
				}
				else if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS)
				{
					Debug.LogWarning("Skipped appending polygon to mesh");
				}
			}
			foreach (PolyNode item in queue)
			{
				RecurseAndTriangulatePolyTree(item, color, ref meshVertices, ref meshTriangles, ref meshVertexColors);
			}
			return true;
		}

		private static Polygon ConvertIntPointsToPolygon(List<IntPoint> path)
		{
			if (path.Count < 3)
			{
				return null;
			}
			List<PolygonPoint> list = new List<PolygonPoint>();
			foreach (IntPoint item in path)
			{
				list.Add(ImportUtilities.ConvertToTriangulationPoint(item));
			}
			Polygon polygon = new Polygon(list);
			polygon.RemoveDuplicateNeighborPoints();
			polygon.Simplify();
			if (GlobalSettings.Get().logLevelInteger >= 2 && GlobalSettings.Get().extraDevelopementChecks)
			{
				Point2DList.PolygonError polygonError = polygon.CheckPolygon();
				if (polygonError != Point2DList.PolygonError.None && GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_WARNINGS_AND_INFO)
				{
					Debug.LogWarning("Polygon validity check reported a potential problem: " + polygonError);
				}
			}
			return polygon;
		}

		private static void AppendToMeshData(IList<DelaunayTriangle> triangles, Color color, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			int count = meshVertices.Count;
			for (int i = 0; i < triangles.Count; i++)
			{
				DelaunayTriangle delaunayTriangle = triangles[i];
				for (int j = 0; j < 3; j++)
				{
					TriangulationPoint triangulationPoint = delaunayTriangle.Points[j];
					meshVertices.Add(new Vector3(triangulationPoint.Xf, 0f - triangulationPoint.Yf, 0f));
					meshVertexColors.Add(color);
				}
				meshTriangles.Add(count + i * 3);
				meshTriangles.Add(count + i * 3 + 1);
				meshTriangles.Add(count + i * 3 + 2);
			}
		}
	}
}
