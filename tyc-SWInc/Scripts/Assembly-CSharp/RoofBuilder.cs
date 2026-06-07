using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoofBuilder
{
	public class RoofPoint
	{
		public float uvX;

		public float uvX2;

		public float? ExplicitUVY;

		public Vector2 Point;

		public Vector2? ExpPoint;

		public Vector3 FinalPoint;

		public bool RoofTop;

		public bool Ignore;

		public bool GableOffset = true;

		public RoofEdge GableTop;

		public int Index = -1;

		private Dictionary<RoofPoint, int> lastConnect;

		private HashSet<RoofPoint> lastConnect2;

		public RoofPoint GablePoint;

		public RoofPointObject Corr;

		public Vector2 GetGableOffset()
		{
			if (GableTop == null || !GableOffset)
			{
				return Vector2.zero;
			}
			return -GableTop.Normalized.Turn90() * Room.WallOffset;
		}

		public bool IsValid()
		{
			if (lastConnect != null)
			{
				return lastConnect.All((KeyValuePair<RoofPoint, int> x) => x.Value > 1);
			}
			return false;
		}

		public void SetError()
		{
			if (Corr != null)
			{
				Corr.Error(true);
			}
		}

		public bool CanConnect(RoofPoint a, RoofPoint b)
		{
			if (lastConnect != null)
			{
				if (lastConnect.GetOrDefault(a, 0) < 2)
				{
					return lastConnect.GetOrDefault(b, 0) < 2;
				}
				return false;
			}
			return true;
		}

		public int CanConnect2(RoofPoint a, RoofPoint b)
		{
			if (lastConnect2 == null)
			{
				return 1;
			}
			bool num = lastConnect2.Contains(a);
			bool flag = lastConnect2.Contains(b);
			int num2 = 0;
			if (num)
			{
				num2++;
			}
			if (flag)
			{
				num2++;
			}
			if (num2 <= 0)
			{
				return num2;
			}
			return num2 + 1;
		}

		public void ConnectTo(RoofPoint pp, int value = 1, bool self = false)
		{
			if (lastConnect == null)
			{
				lastConnect = new Dictionary<RoofPoint, int>();
			}
			if (lastConnect2 == null)
			{
				lastConnect2 = new HashSet<RoofPoint>();
			}
			if (value == 1)
			{
				lastConnect2.Add(pp);
			}
			lastConnect.AddUp(pp, value);
			if (!self)
			{
				pp.ConnectTo(this, value, true);
			}
		}

		public RoofPoint(float x, float y, bool roofTop)
		{
			Point = new Vector2(x, y);
			RoofTop = roofTop;
		}

		public RoofPoint(Vector2 p, bool roofTop, RoofPointObject corr = null)
		{
			Point = p;
			RoofTop = roofTop;
			Corr = corr;
		}

		public RoofPoint(RoofPoint p)
		{
			Point = p.Point;
			ExpPoint = p.ExpPoint;
			RoofTop = p.RoofTop;
			uvX = p.uvX;
			uvX2 = p.uvX2;
			GableTop = p.GableTop;
			GableOffset = p.GableOffset;
			GablePoint = p.GablePoint;
		}

		private static float GetOffsetPower(float y1, float y2, float t, float bulge, bool reverse)
		{
			float num = ((bulge > 1f) ? 0.5f : 0.25f);
			return Mathf.Lerp(y1, y2, Mathf.Pow(t, reverse ? (bulge + (1f - bulge) * num) : bulge));
		}

		public RoofPoint(RoofPoint a, RoofPoint b, float bulge, bool gable, Vector2 gableA, Vector2 gableB, RoofPoint gablePoint, float t, bool canSub)
		{
			float offsetPower = GetOffsetPower(a.FinalPoint.y, b.FinalPoint.y, t, bulge, false);
			if (!canSub || (gable && (a.Point - b.Point).sqrMagnitude < 0.03f))
			{
				Point = Vector2.Lerp(a.Point, b.Point, t);
				FinalPoint = Vector3.Lerp(a.FinalPoint, b.FinalPoint, t);
				ExplicitUVY = t.MapRange(0f, 1f, -4f, 0f);
				uvX = Mathf.Lerp(a.uvX, b.uvX, t);
			}
			else
			{
				Point = Vector2.Lerp(a.Point, b.Point, offsetPower);
				FinalPoint = Vector2.Lerp(a.FinalPoint.FlattenVector3(), b.FinalPoint.FlattenVector3(), offsetPower).ToVector3(Mathf.Lerp(a.FinalPoint.y, b.FinalPoint.y, t));
				if (gable)
				{
					Point = Utilities.ProjectToLineEndless(Point, gableA, gableB);
					Vector2 v = Utilities.ProjectToLineEndless(FinalPoint.FlattenVector3(), gableA, gableB);
					FinalPoint = v.ToVector3(FinalPoint.y);
				}
				ExplicitUVY = GetOffsetPower(a.FinalPoint.y, b.FinalPoint.y, t, bulge, true).MapRange(0f, 1f, -4f, 0f);
				uvX = Mathf.Lerp(a.uvX, b.uvX, offsetPower);
			}
			GablePoint = gablePoint;
			RoofTop = a.RoofTop && b.RoofTop;
		}

		public override string ToString()
		{
			return "{ " + Point.x + "; " + Point.y + " }";
		}
	}

	public class RoofEdge
	{
		public RoofPoint[] Points;

		public Vector2 Normalized;

		public bool FreeLeft = true;

		public bool FreeRight = true;

		public RoofEdgeObject Corr;

		public RoofPoint A
		{
			get
			{
				return Points[0];
			}
			set
			{
				Points[0] = value;
			}
		}

		public RoofPoint B
		{
			get
			{
				return Points[1];
			}
			set
			{
				Points[1] = value;
			}
		}

		public void SetError()
		{
			if (Corr != null)
			{
				Corr.Error(true);
			}
		}

		public RoofEdge(RoofPoint a, RoofPoint b, RoofEdgeObject corr = null)
		{
			if (a == b)
			{
				b = new RoofPoint(a.Point + Vector2.left * 0.001f, a.RoofTop, a.Corr);
				b.Ignore = true;
			}
			Points = new RoofPoint[2] { a, b };
			Normalized = (b.Point - a.Point).normalized;
			Corr = corr;
		}

		public void UpdateNormalization()
		{
			Normalized = (A.Point - B.Point).normalized;
		}
	}

	public class MeshTriangle
	{
		public RoofPoint[] Points;

		public bool Gable;

		public bool CanSub = true;

		public bool SubA = true;

		public bool SubB = true;

		public MeshTriangle Rect;

		public bool FromRoofLine;

		public RoofPoint A
		{
			get
			{
				return Points[0];
			}
		}

		public RoofPoint B
		{
			get
			{
				return Points[1];
			}
		}

		public RoofPoint C
		{
			get
			{
				return Points[2];
			}
		}

		public MeshTriangle(RoofPoint a, RoofPoint b, RoofPoint c, bool createPoints)
		{
			Points = (createPoints ? FixGableSides(a, b, c) : new RoofPoint[3] { a, b, c });
		}

		public bool Match(params RoofPoint[] rs)
		{
			foreach (RoofPoint pp in rs)
			{
				if (!Points.Any((RoofPoint x) => (x.Point - pp.Point).sqrMagnitude < 0.03f))
				{
					return false;
				}
			}
			if (rs.Length == Points.Length)
			{
				for (int num = 0; num < Points.Length; num++)
				{
					RoofPoint pp2 = Points[num];
					if (!rs.Any((RoofPoint x) => (x.Point - pp2.Point).sqrMagnitude < 0.03f))
					{
						return false;
					}
				}
			}
			return true;
		}

		public void Subdivide(float bulge, int subLevel, List<MeshTriangle> res)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < Points.Length; i++)
			{
				if (Points[i].RoofTop)
				{
					num3++;
					num = i;
				}
				else
				{
					num2 = i;
				}
			}
			RoofPoint roofPoint;
			RoofPoint roofPoint2;
			RoofPoint roofPoint3;
			if (num3 == 2)
			{
				roofPoint = Points[num2];
				roofPoint2 = Points[(num2 + 1) % 3];
				roofPoint3 = Points[(num2 + 2) % 3];
			}
			else
			{
				roofPoint = Points[num];
				roofPoint2 = Points[(num + 1) % 3];
				roofPoint3 = Points[(num + 2) % 3];
			}
			RoofPoint roofPoint4 = roofPoint2;
			RoofPoint c = roofPoint3;
			for (int j = 1; j < subLevel; j++)
			{
				float num4 = (float)j / (float)subLevel;
				RoofPoint roofPoint5;
				RoofPoint roofPoint6;
				if (num3 == 2)
				{
					num4 = 1f - num4;
					roofPoint5 = SubDivideEdge(roofPoint, roofPoint2, bulge, A.Point, B.Point, num4, SubA);
					roofPoint6 = SubDivideEdge(roofPoint, roofPoint3, bulge, A.Point, B.Point, num4, SubB);
				}
				else
				{
					roofPoint5 = SubDivideEdge(roofPoint2, roofPoint, bulge, B.Point, C.Point, num4, SubA);
					roofPoint6 = SubDivideEdge(roofPoint3, roofPoint, bulge, B.Point, C.Point, num4, SubB);
				}
				res.Add(new MeshTriangle(roofPoint6, roofPoint5, roofPoint4, false).MarkGable(Gable, FromRoofLine));
				res.Add(new MeshTriangle(roofPoint6, roofPoint4, c, false).MarkGable(Gable, FromRoofLine));
				roofPoint4 = roofPoint5;
				c = roofPoint6;
			}
			res.Add(new MeshTriangle(roofPoint, roofPoint4, c, false).MarkGable(Gable, FromRoofLine));
		}

		private RoofPoint SubDivideEdge(RoofPoint a, RoofPoint b, float bulge, Vector2 gabA, Vector2 gabB, float t, bool canSub)
		{
			if (Gable)
			{
				return new RoofPoint(a, b, bulge, Gable, gabA, gabB, null, t, canSub);
			}
			RoofPoint roofPoint = ((a.GableTop != null) ? a : a.GablePoint);
			RoofPoint roofPoint2 = ((b.GableTop != null) ? b : b.GablePoint);
			if (roofPoint != null && roofPoint == roofPoint2)
			{
				Vector2 vector = roofPoint.GetGableOffset() * 0.5f;
				return new RoofPoint(a, b, bulge, true, roofPoint.GableTop.A.Point + vector, roofPoint.GableTop.B.Point + vector, roofPoint, t, canSub);
			}
			return new RoofPoint(a, b, bulge, Gable, gabA, gabB, null, t, canSub);
		}

		private void FixGable(RoofPoint top, RoofPoint a, RoofPoint b)
		{
			top.FinalPoint = top.Point.ToVector3(1f);
			if (top.GableOffset)
			{
				Vector2 v = ((a.ExpPoint.HasValue && (a.Point - top.Point).magnitude > Room.WallOffset) ? Utilities.ProjectToLineEndless(a.ExpPoint.Value, a.Point, b.Point) : a.Point);
				a.FinalPoint = v.ToVector3(0f);
				Vector2 v2 = ((b.ExpPoint.HasValue && (b.Point - top.Point).magnitude > Room.WallOffset) ? Utilities.ProjectToLineEndless(b.ExpPoint.Value, a.Point, b.Point) : b.Point);
				b.FinalPoint = v2.ToVector3(0f);
			}
			else
			{
				a.FinalPoint = (a.ExpPoint ?? a.Point).ToVector3(0f);
				b.FinalPoint = (b.ExpPoint ?? b.Point).ToVector3(0f);
			}
		}

		private MeshTriangle MarkGable(bool gable, bool roofline)
		{
			Gable = gable;
			FromRoofLine = roofline;
			return this;
		}

		public void FixPoints()
		{
			if (Gable)
			{
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < Points.Length; i++)
				{
					if (Points[i].RoofTop)
					{
						num = i;
					}
					else
					{
						num2++;
					}
				}
				if (num2 == 2)
				{
					FixGable(Points[num], Points[(num + 1) % 3], Points[(num + 2) % 3]);
					return;
				}
				for (int j = 0; j < Points.Length; j++)
				{
					RoofPoint roofPoint = Points[j];
					roofPoint.FinalPoint = roofPoint.Point.ToVector3(roofPoint.RoofTop ? 1 : 0);
				}
			}
			else
			{
				for (int k = 0; k < Points.Length; k++)
				{
					RoofPoint roofPoint2 = Points[k];
					roofPoint2.FinalPoint = ((roofPoint2.ExpPoint ?? roofPoint2.Point) + roofPoint2.GetGableOffset()).ToVector3(roofPoint2.RoofTop ? 1 : 0);
				}
			}
		}

		public MeshTriangle CUVTOA()
		{
			FixUvs(A, B, C, null);
			return this;
		}
	}

	public class RoofTriangle
	{
		public int[] Index;

		public Vector2[] Points;

		public RoofTriangle[] Adjacent = new RoofTriangle[3];

		public int[] AdjacentIndex = new int[3];

		public RoofPoint[] MidPoints = new RoofPoint[3];

		public bool Visited;

		public RoofTriangle(int a, int b, int c, Vector2[] outline)
		{
			Index = new int[3] { a, b, c };
			Points = new Vector2[3]
			{
				outline[a],
				outline[b],
				outline[c]
			};
		}
	}

	public class RoofEdgeCloseness
	{
		public RoofEdge Edge;

		public RoofPoint Point;

		public float Dist;

		public bool Reverse;

		public int Priority = 2;

		public bool IsPoint
		{
			get
			{
				return Point != null;
			}
		}

		public RoofEdgeCloseness(RoofEdge edge, float dist, bool reverse)
		{
			Edge = edge;
			Dist = dist;
			Reverse = reverse;
		}

		public RoofEdgeCloseness(RoofPoint point, float dist, int priority)
		{
			Point = point;
			Dist = dist;
			Priority = priority;
		}

		public bool LowerThan(RoofEdgeCloseness other)
		{
			if (other != null && Priority <= other.Priority)
			{
				if (Dist < other.Dist)
				{
					return Priority == other.Priority;
				}
				return false;
			}
			return true;
		}
	}

	public class RoofNode
	{
		public RoofPoint Point;

		public Dictionary<RoofNode, RoofEdge> Connections = new Dictionary<RoofNode, RoofEdge>();

		public RoofNode PointingAt;

		public RoofNode(RoofPoint point)
		{
			Point = point;
		}
	}

	public const float UVEnd = -4f;

	public LineDrawer LineDraw;

	public Material RoofMat;

	public Material GableMat;

	private static Vector2[] _tempPol = new Vector2[3];

	public static void CollapseLoops(List<RoofEdge> roofLine, List<RoofEdge[]> loops)
	{
		if (loops.Count == 0)
		{
			return;
		}
		bool[] array = new bool[loops.Count];
		Vector2[] array2 = new Vector2[loops.Count];
		int[] array3 = new int[loops.Count];
		int l1x = 0;
		int l2x = 0;
		RoofPoint p = null;
		for (int i = 0; i < loops.Count; i++)
		{
			RoofEdge[] l = loops[i];
			if (array[i])
			{
				continue;
			}
			for (int j = i + 1; j < loops.Count; j++)
			{
				RoofEdge[] l2 = loops[j];
				if (!array[j] && MatchLoops(l, l2, ref l1x, ref l2x, ref p))
				{
					array[i] = true;
					array[j] = true;
					array2[i] = (array2[j] = p.Point);
					array3[i] = l1x;
					array3[j] = l2x;
					break;
				}
			}
		}
		for (int k = 0; k < loops.Count; k++)
		{
			RoofEdge[] array4 = loops[k];
			if (array[k])
			{
				RoofEdge roofEdge = array4[array3[k]];
				RoofPoint a = roofEdge.A;
				HashSet<RoofPoint> hashSet = array4.Select((RoofEdge x) => x.A).ToHashSet();
				hashSet.Remove(roofEdge.A);
				hashSet.Remove(roofEdge.B);
				for (int num = 0; num < array4.Length; num++)
				{
					if (array3[k] != num)
					{
						roofLine.Remove(array4[num]);
					}
				}
				for (int num2 = 0; num2 < roofLine.Count; num2++)
				{
					RoofEdge roofEdge2 = roofLine[num2];
					if (hashSet.Contains(roofEdge2.A))
					{
						roofEdge2.A = a;
						roofEdge2.UpdateNormalization();
					}
					if (hashSet.Contains(roofEdge2.B))
					{
						roofEdge2.B = a;
						roofEdge2.UpdateNormalization();
					}
				}
				continue;
			}
			RoofPoint roofPoint = new RoofPoint(Utilities.GetPolygonCentroid(array4.SelectInPlace((RoofEdge x) => x.A.Point)), true);
			HashSet<RoofPoint> hashSet2 = array4.Select((RoofEdge x) => x.A).ToHashSet();
			foreach (RoofEdge item in array4)
			{
				roofLine.Remove(item);
			}
			for (int num4 = 0; num4 < roofLine.Count; num4++)
			{
				RoofEdge roofEdge3 = roofLine[num4];
				if (hashSet2.Contains(roofEdge3.A))
				{
					roofEdge3.A = roofPoint;
					roofEdge3.UpdateNormalization();
				}
				if (hashSet2.Contains(roofEdge3.B))
				{
					roofEdge3.B = roofPoint;
					roofEdge3.UpdateNormalization();
				}
			}
		}
		for (int num5 = 0; num5 < roofLine.Count; num5++)
		{
			RoofEdge roofEdge4 = roofLine[num5];
			if (roofEdge4.A == roofEdge4.B || (roofEdge4.A.Point - roofEdge4.B.Point).magnitude < 0.0001f)
			{
				roofLine.RemoveAt(num5);
				num5--;
			}
		}
	}

	private static bool MatchLoops(RoofEdge[] l1, RoofEdge[] l2, ref int l1x, ref int l2x, ref RoofPoint p)
	{
		for (int i = 0; i < l1.Length; i++)
		{
			RoofEdge roofEdge = l1[i];
			for (int j = 0; j < l2.Length; j++)
			{
				RoofEdge roofEdge2 = l2[j];
				if (roofEdge.A == roofEdge2.A)
				{
					l1x = i;
					l2x = j;
					p = roofEdge.A;
					return true;
				}
			}
		}
		return false;
	}

	private static void FixUvs(RoofPoint topA, RoofPoint topB, RoofPoint botA, RoofPoint botB)
	{
		if (botB == null)
		{
			float num = Utilities.ProjectToLineEndlessMag(botA.Point, topA.Point, topB.Point, true);
			topA.uvX = botA.uvX - num;
			topB.uvX = botA.uvX + (topA.Point - topB.Point).magnitude - num;
			return;
		}
		if (botB.uvX < botA.uvX)
		{
			botB.uvX = botB.uvX2;
		}
		if (topB == null)
		{
			float num2 = Utilities.ProjectToLineEndlessMag(topA.Point, botA.Point, botB.Point, true);
			topA.uvX = botA.uvX + num2;
			return;
		}
		float num3 = Utilities.ProjectToLineEndlessMag(topA.Point, botA.Point, botB.Point, true);
		float num4 = Utilities.ProjectToLineEndlessMag(topB.Point, botB.Point, botA.Point, true);
		topA.uvX = botA.uvX + num3;
		topB.uvX = botB.uvX - num4;
	}

	private static bool IsGable(RoofEdge edge, RoofPoint roofLinePoint)
	{
		Vector2 point = edge.A.Point;
		Vector2 point2 = edge.B.Point;
		Vector2 point3 = roofLinePoint.Point;
		if ((point - point3).magnitude < Room.WallOffset)
		{
			return true;
		}
		if ((point2 - point3).magnitude < Room.WallOffset)
		{
			return true;
		}
		Vector2 res;
		if (Utilities.ProjectToLine(point3, point, point2, out res) && (point3 - res).magnitude < Room.WallOffset)
		{
			return true;
		}
		return false;
	}

	private static bool CheckInside(RoofPoint a, RoofPoint b, RoofPoint c, List<RoofPoint> points)
	{
		_tempPol[0] = a.Point;
		_tempPol[1] = b.Point;
		_tempPol[2] = c.Point;
		if (Utilities.Clockwise(_tempPol))
		{
			_tempPol[0] = c.Point;
			_tempPol[2] = a.Point;
		}
		for (int i = 0; i < points.Count; i++)
		{
			RoofPoint roofPoint = points[i];
			if (roofPoint != c && Utilities.IsInside(roofPoint.Point, _tempPol))
			{
				return true;
			}
		}
		return false;
	}

	private static void DoGableCheck(RoofEdge e, bool reverse, List<RoofEdge> outline, HashSet<RoofPoint> isDone, bool[] roofIntersect)
	{
		RoofPoint roofPoint = (reverse ? e.B : e.A);
		if (roofPoint.Ignore || isDone.Contains(roofPoint))
		{
			return;
		}
		isDone.Add(roofPoint);
		for (int i = 0; i < outline.Count; i++)
		{
			RoofEdge roofEdge = outline[i];
			Vector2 point = roofEdge.A.Point;
			Vector2 point2 = roofEdge.B.Point;
			Vector2 res;
			if (Utilities.ProjectToLine(roofPoint.Point, point, point2, out res) && (res - roofPoint.Point).magnitude < Room.WallOffset)
			{
				roofPoint.GableTop = roofEdge;
				if (roofIntersect != null && roofIntersect[i])
				{
					roofPoint.GableOffset = false;
				}
				break;
			}
		}
	}

	private static RoofPoint[] FixGableSides(params RoofPoint[] input)
	{
		RoofPoint[] array = new RoofPoint[input.Length];
		for (int i = 0; i < input.Length; i++)
		{
			array[i] = new RoofPoint(input[i]);
		}
		for (int j = 0; j < input.Length; j++)
		{
			RoofPoint roofPoint = input[j];
			if (roofPoint.GableTop == null)
			{
				continue;
			}
			for (int k = 0; k < input.Length; k++)
			{
				if (k != j)
				{
					RoofPoint roofPoint2 = input[k];
					if (roofPoint2 == roofPoint.GableTop.A || roofPoint2 == roofPoint.GableTop.B)
					{
						array[k].GablePoint = array[j];
					}
				}
			}
		}
		return array;
	}

	public static List<MeshTriangle> BuildRoof(Vector2[] outline, List<RoofEdge> roofLine, bool[] roofIntersections = null)
	{
		List<RoofEdge[]> loops = FindLoops(roofLine, true);
		CollapseLoops(roofLine, loops);
		List<RoofPoint> list = new List<RoofPoint>();
		Vector2[] offset = outline.GetOffset((0f - Room.WallOffset) * 0.5f);
		Vector2[] offset2 = outline.GetOffset(0f - Room.WallOffset);
		if (roofIntersections != null)
		{
			for (int i = 0; i < roofIntersections.Length; i++)
			{
				if (roofIntersections[i])
				{
					int num = (i + 1) % outline.Length;
					offset2[i] = Utilities.ProjectToLineEndless(offset2[i], outline[i], outline[num]);
					offset2[num] = Utilities.ProjectToLineEndless(offset2[num], outline[i], outline[num]);
				}
			}
		}
		for (int j = 0; j < outline.Length; j++)
		{
			RoofPoint roofPoint = new RoofPoint(offset[j], false);
			roofPoint.ExpPoint = offset2[j];
			list.Add(roofPoint);
		}
		float num2 = 0f;
		Vector2 res;
		for (int k = 0; k < list.Count; k++)
		{
			RoofPoint roofPoint2 = list[k];
			res = list[(k + 1) % list.Count].Point - roofPoint2.Point;
			float magnitude = res.magnitude;
			roofPoint2.uvX = num2;
			num2 += magnitude;
		}
		float num3 = Mathf.Round(num2);
		for (int l = 0; l < list.Count; l++)
		{
			RoofPoint roofPoint3 = list[l];
			roofPoint3.uvX = (roofPoint3.uvX2 = roofPoint3.uvX / num2 * num3);
		}
		list[0].uvX2 = num3;
		List<RoofEdge> list2 = new List<RoofEdge>();
		for (int m = 0; m < list.Count; m++)
		{
			list2.Add(new RoofEdge(list[m], list[(m + 1) % list.Count]));
		}
		HashSet<RoofPoint> hashSet = new HashSet<RoofPoint>();
		for (int n = 0; n < roofLine.Count; n++)
		{
			RoofEdge e = roofLine[n];
			DoGableCheck(e, false, list2, hashSet, roofIntersections);
			DoGableCheck(e, true, list2, hashSet, roofIntersections);
		}
		Dictionary<RoofEdge, RoofEdgeCloseness> dictionary = new Dictionary<RoofEdge, RoofEdgeCloseness>();
		List<RoofEdge> list3 = new List<RoofEdge>(list2);
		Vector2[] array = new Vector2[4];
		for (int num4 = 0; num4 < list3.Count; num4++)
		{
			RoofEdge roofEdge = list3[num4];
			RoofEdgeCloseness roofEdgeCloseness = null;
			Vector2 p = (roofEdge.A.Point + roofEdge.B.Point) * 0.5f;
			Vector2 normalized = roofEdge.Normalized;
			for (int num5 = 0; num5 < roofLine.Count; num5++)
			{
				RoofEdge roofEdge2 = roofLine[num5];
				if (roofEdge2.A.Ignore || roofEdge2.B.Ignore)
				{
					continue;
				}
				bool flag = Utilities.IsLeft(roofEdge.A.Point, roofEdge.B.Point, roofEdge2.A.Point) > 0;
				bool flag2 = Utilities.IsLeft(roofEdge.A.Point, roofEdge.B.Point, roofEdge2.B.Point) > 0;
				if (!flag && !flag2)
				{
					continue;
				}
				bool flag3 = IsGable(roofEdge, roofEdge2.A) || IsGable(roofEdge, roofEdge2.B);
				float num6 = Mathf.Abs(Vector2.Dot(normalized, roofEdge2.Normalized));
				if (!flag || !flag2 || flag3 || num6 < 0.6f)
				{
					continue;
				}
				Vector2 vector = (roofEdge2.A.Point + roofEdge2.B.Point) * 0.5f;
				if (!Utilities.ProjectToLine(roofEdge.A.Point, roofEdge2.A.Point, roofEdge2.B.Point, out res) && !Utilities.ProjectToLine(roofEdge.B.Point, roofEdge2.A.Point, roofEdge2.B.Point, out res) && !Utilities.ProjectToLine(p, roofEdge2.A.Point, roofEdge2.B.Point, out res))
				{
					continue;
				}
				float sqrMagnitude = (Utilities.ProjectToLineEndlessClamped(vector, roofEdge.A.Point, roofEdge.B.Point) - vector).sqrMagnitude;
				float num7 = (roofEdge.A.Point - roofEdge2.A.Point).sqrMagnitude + (roofEdge.B.Point - roofEdge2.B.Point).sqrMagnitude;
				float sqrMagnitude2 = (roofEdge.A.Point - roofEdge2.B.Point).sqrMagnitude;
				res = roofEdge.B.Point - roofEdge2.A.Point;
				bool flag4 = num7 > sqrMagnitude2 + res.sqrMagnitude;
				array[0] = roofEdge.A.Point;
				array[1] = roofEdge.B.Point;
				array[2] = (flag4 ? roofEdge2.A.Point : roofEdge2.B.Point);
				array[3] = (flag4 ? roofEdge2.B.Point : roofEdge2.A.Point);
				if (Utilities.Clockwise(array))
				{
					array.ReverseArray();
				}
				bool flag5 = true;
				for (int num8 = 0; num8 < list.Count; num8++)
				{
					RoofPoint roofPoint4 = list[num8];
					if (roofPoint4 != roofEdge.A && roofPoint4 != roofEdge.B && Utilities.IsInside(roofPoint4.Point, array))
					{
						flag5 = false;
						break;
					}
				}
				if (flag5)
				{
					foreach (RoofPoint item in hashSet)
					{
						if (item != roofEdge2.A && item != roofEdge2.B && Utilities.IsInside(item.Point, array))
						{
							flag5 = false;
							break;
						}
					}
				}
				if (flag5)
				{
					RoofEdgeCloseness roofEdgeCloseness2 = new RoofEdgeCloseness(roofEdge2, Mathf.Approximately(num6, 1f) ? (sqrMagnitude / 4f) : sqrMagnitude, flag4);
					if (roofEdgeCloseness2.LowerThan(roofEdgeCloseness))
					{
						roofEdgeCloseness = roofEdgeCloseness2;
					}
				}
			}
			if (roofEdgeCloseness != null)
			{
				list3.RemoveAt(num4);
				num4--;
				dictionary[roofEdge] = roofEdgeCloseness;
			}
		}
		List<MeshTriangle> list4 = new List<MeshTriangle>();
		foreach (KeyValuePair<RoofEdge, RoofEdgeCloseness> item2 in dictionary.OrderBy((KeyValuePair<RoofEdge, RoofEdgeCloseness> x) => x.Value.Dist))
		{
			MakeTriangle(item2.Key, item2.Value, list4, list3);
		}
		int count;
		do
		{
			count = list3.Count;
			dictionary.Clear();
			bool flag6 = false;
			for (int num9 = 0; num9 < list3.Count; num9++)
			{
				RoofEdge roofEdge3 = list3[num9];
				RoofEdgeCloseness roofEdgeCloseness3 = null;
				foreach (RoofPoint item3 in hashSet)
				{
					int num10 = item3.CanConnect2(roofEdge3.A, roofEdge3.B);
					if (num10 == 0 || Utilities.IsLeft(roofEdge3.A.Point, roofEdge3.B.Point, item3.Point) <= 0 || !item3.CanConnect(roofEdge3.A, roofEdge3.B))
					{
						continue;
					}
					if (IsGable(roofEdge3, item3))
					{
						roofEdgeCloseness3 = new RoofEdgeCloseness(item3, 0f, 4);
						continue;
					}
					float sqrMagnitude3 = (Utilities.ProjectToLineEndlessClamped(item3.Point, roofEdge3.A.Point, roofEdge3.B.Point) - item3.Point).sqrMagnitude;
					RoofEdgeCloseness roofEdgeCloseness4 = new RoofEdgeCloseness(item3, sqrMagnitude3, num10);
					if (roofEdgeCloseness4.LowerThan(roofEdgeCloseness3))
					{
						if (roofEdgeCloseness4.Priority > 1)
						{
							flag6 = true;
						}
						roofEdgeCloseness3 = roofEdgeCloseness4;
					}
				}
				if (roofEdgeCloseness3 != null)
				{
					list3.RemoveAt(num9);
					num9--;
					dictionary[roofEdge3] = roofEdgeCloseness3;
				}
			}
			foreach (KeyValuePair<RoofEdge, RoofEdgeCloseness> item4 in dictionary.OrderBy((KeyValuePair<RoofEdge, RoofEdgeCloseness> x) => x.Value.Dist))
			{
				if (flag6 && item4.Value.Priority == 1)
				{
					list3.Add(item4.Key);
				}
				else
				{
					MakeTriangle(item4.Key, item4.Value, list4, list3);
				}
			}
		}
		while (list3.Count > 0 && list3.Count != count);
		for (int num11 = 0; num11 < roofLine.Count; num11++)
		{
			RoofEdge edge = roofLine[num11];
			if (edge.A.Ignore || edge.B.Ignore || (!edge.FreeLeft && !edge.FreeRight))
			{
				continue;
			}
			RoofPoint leftP = null;
			RoofPoint rightP = null;
			float num12 = float.MaxValue;
			float num13 = float.MaxValue;
			float num14 = 1f;
			float num15 = 1f;
			int num16 = 0;
			int num17 = 0;
			Vector2 vector2 = (edge.A.Point + edge.B.Point) * 0.5f;
			for (int num18 = 0; num18 < list.Count; num18++)
			{
				RoofPoint roofPoint5 = list[num18];
				int num19 = roofPoint5.CanConnect2(edge.A, edge.B);
				if (num19 == 0 || !roofPoint5.CanConnect(edge.A, edge.B) || CheckInside(edge.A, edge.B, roofPoint5, list))
				{
					continue;
				}
				float num20 = Mathf.Abs(Vector2.Dot(edge.Normalized, (roofPoint5.Point - vector2).normalized));
				bool flag7 = Utilities.IsLeft(edge.A.Point, edge.B.Point, roofPoint5.Point) > 0;
				if (edge.FreeLeft && flag7 && num19 >= num16)
				{
					float sqrMagnitude4 = (vector2 - roofPoint5.Point).sqrMagnitude;
					if ((sqrMagnitude4 < num12 || num19 > num16) && (num12 - sqrMagnitude4 > 2f || num20 < num14 || num19 > num16))
					{
						leftP = roofPoint5;
						num12 = sqrMagnitude4;
						num14 = num20;
						num16 = num19;
					}
				}
				else if (edge.FreeRight && !flag7 && num19 >= num17)
				{
					float sqrMagnitude5 = (vector2 - roofPoint5.Point).sqrMagnitude;
					if ((sqrMagnitude5 < num13 || num19 > num17) && (num13 - sqrMagnitude5 > 2f || num20 < num15 || num19 > num17))
					{
						rightP = roofPoint5;
						num13 = sqrMagnitude5;
						num15 = num20;
						num17 = num19;
					}
				}
			}
			if (rightP != null)
			{
				rightP.ConnectTo(edge.A);
				rightP.ConnectTo(edge.B);
				MeshTriangle meshTriangle = new MeshTriangle(edge.A, edge.B, rightP, true).CUVTOA();
				meshTriangle.FromRoofLine = true;
				meshTriangle.Gable = (Utilities.ProjectToLineEndless(rightP.Point, edge.A.Point, edge.B.Point) - rightP.Point).magnitude < Room.WallOffset;
				if (meshTriangle.Gable)
				{
					MeshTriangle meshTriangle2 = list4.FirstOrDefault((MeshTriangle x) => x.Gable && x.Match(edge.A, edge.B, rightP));
					if (meshTriangle2 != null)
					{
						meshTriangle.CanSub = false;
						meshTriangle2.CanSub = false;
					}
					else
					{
						meshTriangle2 = list4.FirstOrDefault((MeshTriangle x) => x.Gable && x.Match(edge.B, rightP));
						if (meshTriangle2 != null)
						{
							meshTriangle2.SubB = false;
						}
						meshTriangle.SubB = false;
					}
				}
				list4.Add(meshTriangle);
			}
			else if (edge.FreeRight)
			{
				edge.SetError();
				return null;
			}
			if (leftP != null)
			{
				leftP.ConnectTo(edge.A);
				leftP.ConnectTo(edge.B);
				MeshTriangle meshTriangle3 = new MeshTriangle(edge.B, edge.A, leftP, true).CUVTOA();
				meshTriangle3.FromRoofLine = true;
				meshTriangle3.Gable = (Utilities.ProjectToLineEndless(leftP.Point, edge.A.Point, edge.B.Point) - leftP.Point).magnitude < Room.WallOffset;
				if (meshTriangle3.Gable)
				{
					MeshTriangle meshTriangle4 = list4.FirstOrDefault((MeshTriangle x) => x.Gable && x.Match(edge.A, edge.B, leftP));
					if (meshTriangle4 != null)
					{
						meshTriangle3.CanSub = false;
						meshTriangle4.CanSub = false;
					}
					else
					{
						meshTriangle4 = list4.FirstOrDefault((MeshTriangle x) => x.Gable && x.Match(edge.B, leftP));
						if (meshTriangle4 != null)
						{
							meshTriangle4.SubA = false;
						}
						meshTriangle3.SubA = false;
					}
				}
				list4.Add(meshTriangle3);
			}
			else if (edge.FreeLeft)
			{
				edge.SetError();
				return null;
			}
		}
		foreach (RoofPoint item5 in hashSet)
		{
			if (!item5.IsValid())
			{
				item5.SetError();
				return null;
			}
		}
		for (int num21 = 0; num21 < list4.Count; num21++)
		{
			list4[num21].FixPoints();
		}
		return list4;
	}

	public static List<MeshTriangle> Subdivide(float bulge, List<MeshTriangle> input)
	{
		int num = ((!Mathf.Approximately(bulge, 1f)) ? (Mathf.Abs(bulge - 1f).Quantize(3) + 1) : 0);
		if (num > 0)
		{
			List<MeshTriangle> list = new List<MeshTriangle>();
			for (int i = 0; i < input.Count; i++)
			{
				if (!input[i].CanSub)
				{
					list.Add(input[i]);
				}
				else
				{
					input[i].Subdivide(bulge, num + 1, list);
				}
			}
			return list;
		}
		return input;
	}

	public static Mesh[] BuildRoofMesh(IList<MeshTriangle> triangles, float height, bool onlyGable, bool merge = false)
	{
		for (int i = 0; i < triangles.Count; i++)
		{
			MeshTriangle meshTriangle = triangles[i];
			for (int j = 0; j < meshTriangle.Points.Length; j++)
			{
				meshTriangle.Points[j].Index = -1;
			}
		}
		List<Vector3> list = new List<Vector3>();
		List<Vector2> list2 = new List<Vector2>();
		List<int> list3 = new List<int>();
		Mesh mesh = ((merge || !onlyGable) ? new Mesh() : null);
		int num = 0;
		if (!onlyGable)
		{
			for (int k = 0; k < triangles.Count; k++)
			{
				MeshTriangle meshTriangle2 = triangles[k];
				if (meshTriangle2.Gable)
				{
					continue;
				}
				for (int l = 0; l < meshTriangle2.Points.Length; l++)
				{
					RoofPoint roofPoint = meshTriangle2.Points[l];
					if (roofPoint.Index < 0)
					{
						list.Add(roofPoint.FinalPoint);
						list2.Add(new Vector2(roofPoint.uvX, roofPoint.ExplicitUVY ?? (roofPoint.RoofTop ? 0f : (-4f))));
						roofPoint.Index = num;
						num++;
					}
					list3.Add(roofPoint.Index);
				}
			}
			if (!merge)
			{
				mesh.SetVertices(list);
				mesh.SetUVs(0, list2);
				mesh.SetTriangles(list3, 0);
				mesh.RecalculateNormals();
				mesh.RecalculateTangents();
				list.Clear();
				list2.Clear();
				list3.Clear();
				num = 0;
			}
		}
		bool flag = false;
		for (int m = 0; m < triangles.Count; m++)
		{
			MeshTriangle meshTriangle3 = triangles[m];
			if (!meshTriangle3.Gable)
			{
				continue;
			}
			flag = true;
			for (int n = 0; n < meshTriangle3.Points.Length; n++)
			{
				RoofPoint roofPoint2 = meshTriangle3.Points[n];
				if (roofPoint2.Index < 0)
				{
					list.Add(roofPoint2.FinalPoint);
					list2.Add(new Vector2(roofPoint2.uvX * 0.5f, roofPoint2.FinalPoint.y * height));
					roofPoint2.Index = num;
					num++;
				}
				list3.Add(roofPoint2.Index);
			}
		}
		if (flag && !merge)
		{
			Mesh mesh2 = new Mesh();
			mesh2.SetVertices(list);
			mesh2.SetUVs(0, list2);
			mesh2.SetTriangles(list3, 0);
			mesh2.RecalculateNormals();
			mesh2.RecalculateTangents();
			if (onlyGable)
			{
				return new Mesh[1] { mesh2 };
			}
			return new Mesh[2] { mesh, mesh2 };
		}
		if (merge)
		{
			mesh.SetVertices(list);
			mesh.SetUVs(0, list2);
			mesh.SetTriangles(list3, 0);
			mesh.RecalculateNormals();
			mesh.RecalculateTangents();
			return new Mesh[1] { mesh };
		}
		if (!onlyGable)
		{
			return new Mesh[1] { mesh };
		}
		return null;
	}

	private static void MakeTriangle(RoofEdge edge, RoofEdgeCloseness closeness, List<MeshTriangle> result, List<RoofEdge> abort)
	{
		if (closeness.Edge != null)
		{
			RoofPoint roofPoint = closeness.Edge.A;
			RoofPoint roofPoint2 = closeness.Edge.B;
			bool num = roofPoint.CanConnect(edge.A, edge.B) && roofPoint2.CanConnect(edge.A, edge.B);
			bool flag = Utilities.IsLeft(roofPoint.Point, roofPoint2.Point, (edge.A.Point + edge.B.Point) * 0.5f) > 0;
			if (!num || (flag && !closeness.Edge.FreeLeft) || (!flag && !closeness.Edge.FreeRight))
			{
				abort.Add(edge);
				return;
			}
			if (flag)
			{
				closeness.Edge.FreeLeft = false;
			}
			else
			{
				closeness.Edge.FreeRight = false;
			}
			if (closeness.Reverse)
			{
				RoofPoint roofPoint3 = roofPoint;
				roofPoint = roofPoint2;
				roofPoint2 = roofPoint3;
			}
			edge.A.ConnectTo(roofPoint);
			edge.B.ConnectTo(roofPoint2);
			edge.A.ConnectTo(roofPoint2, 2);
			edge.B.ConnectTo(roofPoint, 2);
			RoofPoint[] array = FixGableSides(roofPoint, roofPoint2, edge.A, edge.B);
			roofPoint = array[0];
			roofPoint2 = array[1];
			RoofPoint roofPoint4 = array[2];
			RoofPoint roofPoint5 = array[3];
			FixUvs(roofPoint, roofPoint2, roofPoint4, roofPoint5);
			MeshTriangle meshTriangle = new MeshTriangle(roofPoint2, roofPoint5, roofPoint4, false);
			MeshTriangle meshTriangle2 = new MeshTriangle(roofPoint4, roofPoint, roofPoint2, false);
			result.Add(meshTriangle);
			result.Add(meshTriangle2);
			meshTriangle.Rect = meshTriangle2;
			meshTriangle2.Rect = meshTriangle;
		}
		else if (closeness.Point != null)
		{
			RoofPoint point = closeness.Point;
			RoofPoint a = edge.A;
			RoofPoint b = edge.B;
			a.ConnectTo(point);
			b.ConnectTo(point);
			bool flag2 = (Utilities.ProjectToLineEndless(point.Point, a.Point, b.Point) - point.Point).magnitude < Room.WallOffset;
			if (!flag2)
			{
				RoofPoint[] array2 = FixGableSides(point, a, b);
				point = array2[0];
				a = array2[1];
				b = array2[2];
			}
			else
			{
				point = new RoofPoint(point);
				a = new RoofPoint(a);
				b = new RoofPoint(b);
			}
			FixUvs(point, null, a, b);
			MeshTriangle meshTriangle3 = new MeshTriangle(point, b, a, false);
			meshTriangle3.Gable = flag2;
			result.Add(meshTriangle3);
		}
	}

	public static List<RoofEdge> SuggestRoofLine(Vector2[] outline, bool addGable)
	{
		int[] array = new Triangulator(outline).Triangulate();
		List<RoofTriangle> list = new List<RoofTriangle>();
		Dictionary<KeyValuePair<int, int>, KeyValuePair<RoofTriangle, int>> dict = new Dictionary<KeyValuePair<int, int>, KeyValuePair<RoofTriangle, int>>();
		for (int i = 0; i < array.Length; i += 3)
		{
			RoofTriangle roofTriangle = new RoofTriangle(array[i], array[i + 1], array[i + 2], outline);
			list.Add(roofTriangle);
			CheckEdge(roofTriangle, array[i], array[i + 1], 0, dict);
			CheckEdge(roofTriangle, array[i + 1], array[i + 2], 1, dict);
			CheckEdge(roofTriangle, array[i + 2], array[i], 2, dict);
		}
		List<RoofEdge> list2 = new List<RoofEdge>();
		RecursiveRoofLine(list[0], list2);
		if (addGable)
		{
			for (int j = 0; j < list.Count; j++)
			{
				RoofTriangle roofTriangle2 = list[j];
				int num = 0;
				int num2 = -1;
				for (int k = 0; k < roofTriangle2.Adjacent.Length; k++)
				{
					if (roofTriangle2.Adjacent[k] != null)
					{
						num2 = k;
						num++;
					}
				}
				if (num == 1)
				{
					int num3 = (num2 + 1) % 3;
					RoofPoint roofPoint = roofTriangle2.MidPoints[num2] ?? new RoofPoint((roofTriangle2.Points[num2] + roofTriangle2.Points[num3]) * 0.5f, true);
					RoofPoint roofPoint2 = roofTriangle2.MidPoints[num3] ?? new RoofPoint((roofTriangle2.Points[num3] + roofTriangle2.Points[(num3 + 1) % 3]) * 0.5f, true);
					Vector2 vector = roofPoint2.Point - roofPoint.Point;
					float magnitude = vector.magnitude;
					roofPoint2.ExpPoint = roofPoint.Point + vector * ((magnitude + Room.WallOffset) / magnitude);
					list2.Add(new RoofEdge(roofPoint, roofPoint2));
				}
			}
		}
		return list2;
	}

	private static void RecursiveRoofLine(RoofTriangle self, List<RoofEdge> result)
	{
		for (int i = 0; i < 3; i++)
		{
			if (self.Adjacent[i] != null && self.MidPoints[i] == null)
			{
				Vector2 p = (self.Points[i] + self.Points[(i + 1) % 3]) * 0.5f;
				self.MidPoints[i] = new RoofPoint(p, true);
				self.Adjacent[i].MidPoints[self.AdjacentIndex[i]] = self.MidPoints[i];
			}
		}
		for (int j = 0; j < 3; j++)
		{
			RoofPoint roofPoint = self.MidPoints[j];
			for (int k = j + 1; k < 3; k++)
			{
				RoofPoint roofPoint2 = self.MidPoints[k];
				if (roofPoint != null && roofPoint2 != null)
				{
					result.Add(new RoofEdge(roofPoint, roofPoint2));
				}
			}
		}
		self.Visited = true;
		for (int l = 0; l < 3; l++)
		{
			if (self.Adjacent[l] != null && !self.Adjacent[l].Visited)
			{
				RecursiveRoofLine(self.Adjacent[l], result);
			}
		}
	}

	private static void CheckEdge(RoofTriangle self, int a, int b, int index, Dictionary<KeyValuePair<int, int>, KeyValuePair<RoofTriangle, int>> dict)
	{
		KeyValuePair<int, int> key = new KeyValuePair<int, int>(b, a);
		KeyValuePair<RoofTriangle, int> value;
		if (dict.TryGetValue(key, out value))
		{
			value.Key.Adjacent[value.Value] = self;
			value.Key.AdjacentIndex[value.Value] = index;
			self.Adjacent[index] = value.Key;
			self.AdjacentIndex[index] = value.Value;
		}
		else
		{
			dict[new KeyValuePair<int, int>(a, b)] = new KeyValuePair<RoofTriangle, int>(self, index);
		}
	}

	private static Dictionary<RoofPoint, RoofNode> GetRoofPointNetwork(List<RoofEdge> edges)
	{
		Dictionary<RoofPoint, RoofNode> dictionary = new Dictionary<RoofPoint, RoofNode>();
		for (int i = 0; i < edges.Count; i++)
		{
			RoofEdge roofEdge = edges[i];
			RoofNode orAdd = dictionary.GetOrAdd(roofEdge.A, (RoofPoint x) => new RoofNode(x));
			RoofNode orAdd2 = dictionary.GetOrAdd(roofEdge.B, (RoofPoint x) => new RoofNode(x));
			orAdd.Connections.Add(orAdd2, roofEdge);
			orAdd2.Connections.Add(orAdd, roofEdge);
		}
		return dictionary;
	}

	private void InitializeUVs(List<RoofEdge> edges)
	{
		RoofNode roofNode = GetRoofPointNetwork(edges).Values.FirstOrDefault();
		if (roofNode != null)
		{
			InitializeUVSub(roofNode, new HashSet<RoofNode>());
		}
	}

	private void InitializeUVSub(RoofNode node, HashSet<RoofNode> visited)
	{
		visited.Add(node);
		float uvX = node.Point.uvX;
		foreach (RoofNode key in node.Connections.Keys)
		{
			if (!visited.Contains(key))
			{
				key.Point.uvX = uvX + (node.Point.Point - key.Point.Point).magnitude;
				InitializeUVSub(key, visited);
			}
		}
	}

	public static List<RoofEdge[]> FindLoops(List<RoofEdge> edges, bool simpleRemove)
	{
		List<RoofEdge[]> list = new List<RoofEdge[]>();
		if (edges.Count == 0)
		{
			return list;
		}
		Dictionary<RoofPoint, RoofNode> roofPointNetwork = GetRoofPointNetwork(edges);
		HashSet<RoofEdge> inLoop = new HashSet<RoofEdge>();
		FindLoop(roofPointNetwork.First().Value, inLoop, list);
		if (simpleRemove)
		{
			for (int i = 0; i < list.Count; i++)
			{
				RoofEdge[] array = list[i];
				foreach (RoofEdge roofEdge in array)
				{
					RoofNode roofNode = roofPointNetwork[roofEdge.A];
					if (roofNode.Connections.Count != 2)
					{
						continue;
					}
					foreach (KeyValuePair<RoofNode, RoofEdge> connection in roofNode.Connections)
					{
						edges.Remove(connection.Value);
					}
					list.RemoveAt(i);
					i--;
					break;
				}
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			RoofEdge[] array2 = list[k];
			for (int l = 0; l < array2.Length - 1; l++)
			{
				RoofEdge obj = array2[l];
				RoofEdge roofEdge2 = array2[l + 1];
				if (obj.B != roofEdge2.A)
				{
					RoofPoint a = roofEdge2.A;
					roofEdge2.A = roofEdge2.B;
					roofEdge2.B = a;
					roofEdge2.UpdateNormalization();
				}
			}
		}
		return list;
	}

	private static void FindLoop(RoofNode node, HashSet<RoofEdge> inLoop, List<RoofEdge[]> result)
	{
		foreach (KeyValuePair<RoofNode, RoofEdge> connection in node.Connections)
		{
			if (!inLoop.Contains(connection.Value) && connection.Key.PointingAt != node)
			{
				node.PointingAt = connection.Key;
				if (connection.Key.PointingAt != null)
				{
					result.Add(CompleteLoop(connection.Key.PointingAt, inLoop).ToArray());
				}
				else
				{
					FindLoop(node.PointingAt, inLoop, result);
				}
			}
		}
	}

	private static List<RoofEdge> CompleteLoop(RoofNode from, HashSet<RoofEdge> inLoop)
	{
		List<RoofEdge> list = new List<RoofEdge>();
		RoofNode roofNode = from;
		while (roofNode.PointingAt != from)
		{
			RoofEdge item = roofNode.Connections[roofNode.PointingAt];
			inLoop.Add(item);
			list.Add(item);
			roofNode = roofNode.PointingAt;
		}
		RoofEdge item2 = roofNode.Connections[roofNode.PointingAt];
		inLoop.Add(item2);
		list.Add(item2);
		return list;
	}
}
