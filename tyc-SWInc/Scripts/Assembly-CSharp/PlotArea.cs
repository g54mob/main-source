using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class PlotArea
{
	[Serializable]
	public class PlotPoint
	{
		public float X;

		public float Y;

		public PlotPoint()
		{
		}

		public PlotPoint(float x, float y)
		{
			X = x;
			Y = y;
		}

		public PlotPoint(Vector2 p)
		{
			X = p.x;
			Y = p.y;
		}

		public override string ToString()
		{
			return X + ", " + Y;
		}
	}

	[Serializable]
	public class PointLink
	{
		public PlotPoint Point;

		public PointLink Previous;

		public PointLink Next;

		public PointLink()
		{
		}

		public PointLink(PlotPoint point)
		{
			Point = point;
		}

		public override string ToString()
		{
			return Point.ToString();
		}
	}

	public static float AreaPrice = 350f;

	public static float PriceRange = 100f;

	public static float InsideFuzzy = 0.01f;

	public static float StartPlotPrice = 50000f;

	public List<PointLink> Links;

	[NonSerialized]
	private Vector2[] _polygon;

	[NonSerialized]
	private Vector2[] _polygonEx;

	public float Area;

	public float PricePerSqm;

	public float AddonCost;

	[NonSerialized]
	public int MergeCount;

	public float Monthly;

	public float MonthlyInterest;

	public int MonthsLeft;

	public float MinX;

	public float MaxX;

	public float MinY;

	public float MaxY;

	public bool PlayerStarterPlot;

	public uint ID;

	public HashSet<uint> Neighbors;

	public Dictionary<PlotPoint, PointLink> Points;

	public SVector3 PlotColor;

	public SVector3 Center;

	private NetworkedID<byte> _owner = (byte)0;

	[Obsolete]
	private bool _playerOwned;

	private bool _isRect;

	[NonSerialized]
	public PlotObject PlotObject;

	public Vector2[] Polygon
	{
		get
		{
			if (_polygon == null)
			{
				InitPolygon();
			}
			return _polygon;
		}
	}

	public Vector2[] PolygonEx
	{
		get
		{
			if (_polygon == null)
			{
				InitPolygon();
			}
			return _polygonEx;
		}
	}

	public bool PlayerOwned
	{
		get
		{
			if (GameSettings.Instance.IsNetworkMode)
			{
				return NetworkManager.Self.ID == (byte)_owner;
			}
			return (byte)_owner > 0;
		}
	}

	public float Price
	{
		get
		{
			return PricePerSqm * Area + AddonCost;
		}
		set
		{
			PricePerSqm = value / Area;
		}
	}

	public byte Owner
	{
		get
		{
			return _owner;
		}
	}

	public void SetOwner(byte playerID)
	{
		bool playerOwned = PlayerOwned;
		_owner = playerID;
		if (PlotObject != null)
		{
			PlotObject.UpdatePlayerOwned();
		}
		if (GameSettings.Instance != null && playerOwned != PlayerOwned)
		{
			if (PlayerOwned)
			{
				if (GameSettings.Instance.Plots.Contains(this))
				{
					GameSettings.Instance.Plots.Remove(this);
					GameSettings.Instance.PlayerPlots.Add(this);
				}
			}
			else if (GameSettings.Instance.PlayerPlots.Contains(this))
			{
				GameSettings.Instance.PlayerPlots.Remove(this);
				GameSettings.Instance.Plots.Add(this);
			}
		}
		NetworkMeta.CheckDirty();
	}

	private static float GetClosestPoint(Vector2 p, Vector2[] polygon)
	{
		float num = float.MaxValue;
		for (int i = 0; i < polygon.Length; i++)
		{
			Vector2 a = polygon[i];
			Vector2 b = polygon[(i + 1) % polygon.Length];
			num = Mathf.Min((Utilities.ProjectToLineEndlessClamped(p, a, b) - p).sqrMagnitude, num);
		}
		return num;
	}

	public void CalculateNeighbors(List<PlotArea> plots, GameData.EnvironmentType t)
	{
		if (Neighbors == null)
		{
			Neighbors = new HashSet<uint>();
		}
		List<ValueTuple<PlotArea, float>> list = new List<ValueTuple<PlotArea, float>>(plots.Count - 1);
		float num = float.MaxValue;
		for (int i = 0; i < plots.Count; i++)
		{
			PlotArea plotArea = plots[i];
			if (plotArea != this)
			{
				float num2 = float.MaxValue;
				for (int j = 0; j < Polygon.Length; j++)
				{
					num2 = Mathf.Min(GetClosestPoint(Polygon[j], plotArea.Polygon), num2);
				}
				num2 = Mathf.Sqrt(num2);
				num = Mathf.Min(num2, num);
				list.Add(new ValueTuple<PlotArea, float>(plotArea, num2));
			}
		}
		if (t == GameData.EnvironmentType.City || t == GameData.EnvironmentType.Town)
		{
			num = Mathf.Max(num, 7f);
		}
		for (int k = 0; k < list.Count; k++)
		{
			ValueTuple<PlotArea, float> valueTuple = list[k];
			if (valueTuple.Item2 < num + 1.1f && Neighbors.Add(valueTuple.Item1.ID))
			{
				if (valueTuple.Item1.Neighbors == null)
				{
					valueTuple.Item1.Neighbors = new HashSet<uint>();
				}
				valueTuple.Item1.Neighbors.Add(ID);
			}
		}
	}

	public bool CheckOwner(byte cmp, byte newVal)
	{
		if (cmp == _owner.RealID)
		{
			_owner.TempID = newVal;
			return true;
		}
		return false;
	}

	public PlotArea()
	{
	}

	public PlotArea(Color color, params PlotPoint[] points)
	{
		Init(points);
		PlotColor = color;
	}

	public PlotArea(params PlotPoint[] points)
	{
		Init(points);
		PlotColor = GetRandomColor();
	}

	public PlotArea(IList<PlotPoint> points)
	{
		Init(points);
		PlotColor = GetRandomColor();
	}

	public void FixOwner()
	{
		if (_playerOwned)
		{
			_owner = (byte)1;
			_playerOwned = false;
			PlotObject plotObject = PlotObject;
			if ((object)plotObject != null)
			{
				plotObject.UpdatePlayerOwned();
			}
		}
	}

	private void InitPolygon()
	{
		_polygon = new Vector2[Links.Count];
		_polygonEx = new Vector2[Links.Count];
		for (int i = 0; i < Links.Count; i++)
		{
			PlotPoint point = Links[i].Point;
			_polygon[i] = new Vector2(point.X, point.Y);
		}
		for (int j = 0; j < _polygon.Length; j++)
		{
			Vector2 first = _polygon[(j == 0) ? (_polygon.Length - 1) : (j - 1)];
			Vector2 second = _polygon[j];
			Vector2 third = _polygon[(j + 1) % _polygon.Length];
			_polygonEx[j] = Utilities.GetOffset(first, second, third, 0f - InsideFuzzy, true);
		}
		Center = Utilities.GetPolygonCentroid(_polygon).ToVector3(0f);
		Area = Utilities.PolygonArea(Polygon);
		_isRect = PolygonEx.IsAlignedRectangle();
	}

	private void Init(IList<PlotPoint> points)
	{
		Links = new List<PointLink>(points.Count);
		MinX = float.MaxValue;
		MinY = float.MaxValue;
		MaxX = float.MinValue;
		MaxY = float.MinValue;
		for (int i = 0; i < points.Count; i++)
		{
			Links.Add(new PointLink(points[i]));
			MinX = Mathf.Min(MinX, points[i].X);
			MinY = Mathf.Min(MinY, points[i].Y);
			MaxX = Mathf.Max(MaxX, points[i].X);
			MaxY = Mathf.Max(MaxY, points[i].Y);
		}
		MinX -= InsideFuzzy;
		MinY -= InsideFuzzy;
		MaxX += InsideFuzzy;
		MaxY += InsideFuzzy;
		for (int j = 0; j < Links.Count; j++)
		{
			Links[j].Previous = Links[(j == 0) ? (Links.Count - 1) : (j - 1)];
			Links[j].Next = Links[(j + 1) % Links.Count];
		}
		Points = Links.ToDictionary((PointLink x) => x.Point, (PointLink x) => x);
		InitPolygon();
		PricePerSqm = (AreaPrice + (0.5f - Utilities.RandomValue) * PriceRange) * GameSettings.Instance.Environment.PlotPriceFactor;
	}

	public bool IsInside(Vector2 p)
	{
		if (p.x >= MinX && p.x <= MaxX && p.y >= MinY && p.y <= MaxY)
		{
			if (!_isRect)
			{
				return Utilities.IsInside(p, _polygonEx);
			}
			return true;
		}
		return false;
	}

	public bool IsInside(Vector2 p, float offset)
	{
		if (p.x >= MinX - offset && p.x <= MaxX + offset && p.y >= MinY - offset && p.y <= MaxY + offset)
		{
			if (!_isRect)
			{
				return Utilities.IsInside(p, _polygonEx, 0f - offset);
			}
			return true;
		}
		return false;
	}

	public static List<PlotArea> PlotsFromRects(List<Rect> areas)
	{
		List<PlotArea> list = new List<PlotArea>();
		for (int i = 0; i < areas.Count; i++)
		{
			Rect rect = areas[i];
			list.Add(new PlotArea(new PlotPoint(rect.xMax, rect.yMin), new PlotPoint(rect.xMax, rect.yMax), new PlotPoint(rect.xMin, rect.yMax), new PlotPoint(rect.xMin, rect.yMin)));
		}
		return list;
	}

	public static List<PlotArea> PlotsFromRects(List<KeyValuePair<Rect, float>> areas, int playerStart)
	{
		List<PlotArea> list = new List<PlotArea>();
		for (int i = 0; i < areas.Count; i++)
		{
			Rect key = areas[i].Key;
			PlotArea plotArea = new PlotArea(new PlotPoint(key.xMax, key.yMin), new PlotPoint(key.xMax, key.yMax), new PlotPoint(key.xMin, key.yMax), new PlotPoint(key.xMin, key.yMin));
			plotArea.AddonCost = areas[i].Value;
			plotArea.PlayerStarterPlot = i >= playerStart;
			list.Add(plotArea);
		}
		return list;
	}

	public static List<PlotArea> DividePlots(List<PlotArea> plots, float maxLen)
	{
		List<PlotArea> list = new List<PlotArea>();
		for (int i = 0; i < plots.Count; i++)
		{
			DividePlotSub(plots[i], list, maxLen * 2f);
		}
		return list;
	}

	private static void DividePlotSub(PlotArea plot, List<PlotArea> output, float maxLen)
	{
		if (plot.Points.Count == 4)
		{
			Vector2 vector = plot.Polygon[1] - plot.Polygon[0];
			float magnitude = vector.magnitude;
			Vector2 vector2 = plot.Polygon[3] - plot.Polygon[0];
			float magnitude2 = vector2.magnitude;
			if (magnitude > magnitude2)
			{
				if (magnitude > maxLen)
				{
					Vector2 vector3 = plot.Polygon[2] - plot.Polygon[3];
					if ((vector3.magnitude / magnitude).IsBetween(0.75f, 1.25f))
					{
						PlotPoint plotPoint = new PlotPoint(plot.Polygon[0] + vector * GameData.RNDRange(0.4f, 0.6f));
						PlotPoint plotPoint2 = new PlotPoint(plot.Polygon[3] + vector3 * GameData.RNDRange(0.4f, 0.6f));
						DividePlotSub(new PlotArea(plot.Links[0].Point, plotPoint, plotPoint2, plot.Links[3].Point), output, maxLen);
						DividePlotSub(new PlotArea(plotPoint, plot.Links[1].Point, plot.Links[2].Point, plotPoint2), output, maxLen);
						return;
					}
				}
			}
			else if (magnitude2 > maxLen)
			{
				Vector2 vector4 = plot.Polygon[2] - plot.Polygon[1];
				if ((vector4.magnitude / magnitude2).IsBetween(0.75f, 1.25f))
				{
					PlotPoint plotPoint3 = new PlotPoint(plot.Polygon[0] + vector2 * GameData.RNDRange(0.4f, 0.6f));
					PlotPoint plotPoint4 = new PlotPoint(plot.Polygon[1] + vector4 * GameData.RNDRange(0.4f, 0.6f));
					DividePlotSub(new PlotArea(plot.Links[0].Point, plot.Links[1].Point, plotPoint4, plotPoint3), output, maxLen);
					DividePlotSub(new PlotArea(plotPoint3, plotPoint4, plot.Links[2].Point, plot.Links[3].Point), output, maxLen);
					return;
				}
			}
		}
		output.Add(plot);
	}

	public bool IsInitialized()
	{
		return PlotObject != null;
	}

	public GameObject CreateObject(GameObject prefab)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
		PlotObject component = gameObject.GetComponent<PlotObject>();
		component.EdgeMesh.sharedMesh = GenerateBorderMesh(1f);
		component.PlotMesh.sharedMesh = GenerateInnerMesh();
		component.Renderer.material.color = PlotColor.ToColor().Alpha(0.5f);
		PlotObject = component;
		PlotObject.Plot = this;
		PlotObject.UpdatePlayerOwned();
		return gameObject;
	}

	private static PlotArea Merge(PlotArea p1, PlotArea p2)
	{
		if (p1 == p2)
		{
			return null;
		}
		int num = -1;
		int num2 = -1;
		for (int i = 0; i < p1.Links.Count; i++)
		{
			PointLink pointLink = p1.Links[i];
			PointLink value;
			if (p2.Points.TryGetValue(pointLink.Point, out value) && pointLink.Point == value.Point && pointLink.Previous.Point != value.Next.Point)
			{
				if (num != -1)
				{
					return null;
				}
				num = i;
				num2 = p2.Links.IndexOf(value);
				break;
			}
		}
		if (num == -1)
		{
			return null;
		}
		int num3 = -1;
		for (int j = 0; j < p1.Links.Count; j++)
		{
			PointLink pointLink2 = p1.Links[(num + j) % p1.Links.Count];
			int num4 = num2 - j;
			PointLink pointLink3 = p2.Links[(num4 < 0) ? (p2.Links.Count + num4) : num4];
			if (pointLink2.Next.Point != pointLink3.Previous.Point)
			{
				num3 = j;
				break;
			}
		}
		if (num3 < 1)
		{
			return null;
		}
		List<PlotPoint> list = new List<PlotPoint>();
		int num5;
		for (num5 = (num + num3) % p1.Links.Count; num5 != num; num5 = (num5 + 1) % p1.Links.Count)
		{
			list.Add(p1.Links[num5].Point);
		}
		num5 = num2;
		int num6 = num2 - num3;
		if (num6 < 0)
		{
			num6 = p2.Links.Count + num6;
		}
		while (num5 != num6)
		{
			list.Add(p2.Links[num5].Point);
			num5 = (num5 + 1) % p2.Links.Count;
		}
		if (list.Distinct().Count() == list.Count)
		{
			return new PlotArea(p1.PlotColor, list.ToArray())
			{
				MergeCount = p1.MergeCount + p2.MergeCount + 1
			};
		}
		return null;
	}

	public Mesh GenerateBorderMesh(float width)
	{
		Vector2[] array = new Vector2[Polygon.Length];
		for (int i = 0; i < Polygon.Length; i++)
		{
			int num = ((i == 0) ? (Polygon.Length - 1) : (i - 1));
			int num2 = (i + 1) % Polygon.Length;
			array[i] = Utilities.GetOffset(Polygon[num], Polygon[i], Polygon[num2], width, true);
		}
		int[] array2 = new int[Polygon.Length * 6];
		for (int j = 0; j < Polygon.Length; j++)
		{
			int num3 = (j + 1) % Polygon.Length;
			array2[j * 6] = j + Polygon.Length;
			array2[j * 6 + 1] = num3;
			array2[j * 6 + 2] = j;
			array2[j * 6 + 3] = j + Polygon.Length;
			array2[j * 6 + 4] = num3 + Polygon.Length;
			array2[j * 6 + 5] = num3;
		}
		Mesh mesh = new Mesh();
		Vector3[] l = (mesh.vertices = Polygon.Select((Vector2 x) => x.ToVector3(0f)).Concat(array.Select((Vector2 x) => x.ToVector3(0f))).ToArray());
		mesh.normals = l.Select((Vector3 x) => Vector3.up).ToArray();
		mesh.triangles = array2;
		return mesh;
	}

	public Mesh GenerateInnerMesh()
	{
		int[] triangles = new Triangulator(Polygon).Triangulate();
		return new Mesh
		{
			vertices = Polygon.Select((Vector2 x) => x.ToVector3(0f)).ToArray(),
			normals = Polygon.Select((Vector2 x) => Vector3.up).ToArray(),
			uv = Polygon,
			triangles = triangles
		};
	}

	public static List<PlotArea> GenerateRandom(bool bigPlots, bool online)
	{
		List<PlotPoint> list = new List<PlotPoint>();
		List<PlotArea> list2 = new List<PlotArea>();
		int size = 16;
		float num = 8f;
		float dist = 16f;
		float num2 = (bigPlots ? (dist * 0.4f) : (dist * 0.6f));
		float num3 = (bigPlots ? 0f : 0.4f);
		float num4 = (float)size * dist;
		num4 = Mathf.Sqrt(num4 * num4 + num4 * num4);
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				bool flag = j > 0 && j < size - 1;
				bool flag2 = i > 0 && i < size - 1;
				if (j <= 1 && i >= size / 2 - 1 && i < size / 2 + 1)
				{
					flag2 = false;
					flag = false;
				}
				if (online && ((i <= 1 && j >= size / 2 - 1 && j < size / 2 + 1) || (j >= size - 2 && i >= size / 2 - 1 && i < size / 2 + 1) || (i >= size - 2 && j >= size / 2 - 1 && j < size / 2 + 1)))
				{
					flag2 = false;
					flag = false;
				}
				float num5 = num + (float)j * dist;
				float num6 = num + (float)i * dist;
				float num7 = 0f;
				float num8 = (float)size / 2f * dist;
				num7 -= num5;
				num8 -= num6;
				float num9 = Mathf.Sqrt(num7 * num7 + num8 * num8);
				float num10 = (1f - num9 / num4) * dist * num3;
				num7 /= num9;
				num8 /= num9;
				num7 *= num10;
				num8 *= num10;
				list.Add(new PlotPoint(num5 + (flag ? ((GameData.RNDValue - 0.5f) * num2 + num7) : 0f), num6 + (flag2 ? ((GameData.RNDValue - 0.5f) * num2 + num8) : 0f)));
			}
		}
		for (int k = 0; k < size - 1; k++)
		{
			for (int l = 0; l < size - 1; l++)
			{
				list2.Add(new PlotArea(list[l + k * size], list[l + k * size + 1], list[l + (k + 1) * size + 1], list[l + (k + 1) * size]));
			}
		}
		List<int> list3 = new List<int> { (size / 2 - 1) * (size - 2) + size / 2 - 1 };
		List<PlotArea> list4 = new List<PlotArea>();
		list4.Add(new PlotArea(new PlotPoint(8f, 120f), new PlotPoint(24f, 120f), new PlotPoint(24f, 136f), new PlotPoint(8f, 136f))
		{
			PlayerStarterPlot = true
		});
		List<PlotArea> list5 = list4;
		if (online)
		{
			list3.Add(size / 2 - 1);
			list5.Add(new PlotArea(new PlotPoint(136f, 8f), new PlotPoint(136f, 24f), new PlotPoint(120f, 24f), new PlotPoint(120f, 8f))
			{
				PlayerStarterPlot = true
			});
			list3.Add(size / 2 * (size - 2) + size / 2 - 1);
			list5.Add(new PlotArea(new PlotPoint(248f, 136f), new PlotPoint(232f, 136f), new PlotPoint(232f, 120f), new PlotPoint(248f, 120f))
			{
				PlayerStarterPlot = true
			});
			list3.Add((size - 2) * (size - 1) + size / 2 - 1);
			list5.Add(new PlotArea(new PlotPoint(120f, 248f), new PlotPoint(120f, 232f), new PlotPoint(136f, 232f), new PlotPoint(136f, 248f))
			{
				PlayerStarterPlot = true
			});
		}
		for (int m = 0; m < list3.Count; m++)
		{
			list2[list3[m]] = list5[m];
		}
		if (bigPlots)
		{
			for (int n = 0; n < list5.Count; n++)
			{
				list2.Remove(list5[n]);
			}
			List<PlotArea> list6 = new List<PlotArea>(list2);
			list2.Clear();
			while (list6.Count > 0)
			{
				PlotArea me = list6[0];
				list6.RemoveAt(0);
				List<PlotArea> list7 = list6.Where((PlotArea x) => x.Points.Any((KeyValuePair<PlotPoint, PointLink> y) => me.Points.ContainsKey(y.Key))).ToList();
				for (int num11 = 0; num11 < list7.Count; num11++)
				{
					PlotArea plotArea = Merge(me, list7[num11]);
					if (plotArea != null)
					{
						me = plotArea;
						list6.Remove(list7[num11]);
					}
					else
					{
						list2.Add(list7[num11]);
					}
				}
				me.MergeCount = 0;
				list2.Add(me);
			}
		}
		list2 = list2.OrderByDescending((PlotArea x) => (!online) ? DistanceSqrt(x.Links[0].Point, 0f, (float)size / 2f * dist) : GameData.RNDValue).ToList();
		int num12 = (bigPlots ? 50 : 200);
		int num13 = (bigPlots ? 3 : int.MaxValue);
		List<PlotArea> list8 = new List<PlotArea>();
		for (int num14 = 0; num14 < num12; num14++)
		{
			float rNDValue = GameData.RNDValue;
			rNDValue = rNDValue * rNDValue * rNDValue * rNDValue;
			int index = Mathf.Min((int)Mathf.Round(rNDValue * (float)list2.Count), list2.Count - 1);
			PlotArea p1 = list2[index];
			if (list5.Contains(p1))
			{
				num14--;
				continue;
			}
			PointLink p2 = p1.Links[GameData.RNDRange(0, p1.Links.Count)];
			PlotArea plotArea2 = list2.FirstOrDefault((PlotArea x) => x.Points.ContainsKey(p2.Point) && x != p1);
			if (plotArea2 == null || list5.Contains(plotArea2))
			{
				continue;
			}
			PlotArea plotArea3 = Merge(p1, plotArea2);
			if (plotArea3 != null)
			{
				list2.Remove(p1);
				list2.Remove(plotArea2);
				if (plotArea3.MergeCount >= num13)
				{
					list8.Add(plotArea3);
				}
				else
				{
					list2.Insert(list2.Count - list2.Count / 3, plotArea3);
				}
			}
		}
		list2.AddRange(list8);
		for (int num15 = 0; num15 < list5.Count; num15++)
		{
			list2.Remove(list5[num15]);
		}
		for (int num16 = 0; num16 < list5.Count; num16++)
		{
			list2.Insert(num16, list5[num16]);
		}
		return list2;
	}

	private static Color GetRandomColor()
	{
		Vector3 vector = Utilities.HSVToRGB(UnityEngine.Random.Range(0, 360), 0.75f, 1f);
		return new Color(vector.x, vector.y, vector.z);
	}

	private static float DistanceSqrt(PlotPoint p1, float x, float y)
	{
		float num = x - p1.X;
		float num2 = y - p1.Y;
		return num * num + num2 * num2;
	}
}
