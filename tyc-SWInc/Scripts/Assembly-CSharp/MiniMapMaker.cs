using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class MiniMapMaker : MonoBehaviour
{
	[Serializable]
	public struct MapDescriptor
	{
		public SVector3[][] Rooms;

		public SVector3[][] RoofPoints;

		public SVector3[][] RoofUVs;

		public SVector3[] RoomColors;

		public SVector3[] RoofColors;

		public SVector3[] TreePos;

		public SVector3[] Skrapers;

		public SVector3[][] Fences;

		public SVector3[][] FenceFloor;

		public SVector3[] FenceColors;

		public float[] FenceHeight;

		public float[] RoofHeight;

		public int[] RoomFloors;

		public float[] SkraperHeights;

		public bool[,] RoadMap;

		public string[] SegmentType;

		public SVector3[] SegmentPos;

		public float[] SegmentRot;

		public SVector3 Plot;

		public float[] SegmentWidth;

		public byte[,] NewRoadmap;

		public int[] RoofFloor;

		public int[][] RoofTris;

		public SVector3[][] Lakes;

		public MapDescriptor(SVector3 plot)
		{
			Rooms = new SVector3[0][];
			RoomColors = new SVector3[0];
			TreePos = new SVector3[0];
			Skrapers = new SVector3[0];
			Fences = new SVector3[0][];
			FenceFloor = new SVector3[0][];
			FenceColors = new SVector3[0];
			FenceHeight = new float[0];
			RoomFloors = new int[0];
			SkraperHeights = new float[0];
			RoadMap = new bool[0, 0];
			SegmentType = new string[0];
			SegmentPos = new SVector3[0];
			SegmentRot = new float[0];
			Plot = plot;
			SegmentWidth = new float[0];
			NewRoadmap = new byte[0, 0];
			RoofPoints = new SVector3[0][];
			RoofUVs = new SVector3[0][];
			RoofColors = new SVector3[0];
			RoofHeight = new float[0];
			RoofFloor = new int[0];
			RoofTris = new int[0][];
			Lakes = new SVector3[0][];
		}

		public MapDescriptor(SVector3[][] rooms, SVector3[] roomColors, int[] roomFloors, SVector3[][] fences, SVector3[][] fenceFloor, SVector3[] fenceColors, SVector3[] houses, float[] fenceHeight, SVector3[] treePos, SVector3[] skrapers, float[] skraperHeights, byte[,] roadMap, string[] segmentType, SVector3[] segmentPos, float[] segmentRot, SVector3[][] roofPoints, SVector3[][] roofUVs, int[][] roofTris, float[] roofHeight, int[] roofFloor, SVector3[] roofColors, SVector3 plot, SVector3[][] lakes)
		{
			Rooms = rooms;
			RoomColors = roomColors;
			RoomFloors = roomFloors;
			Fences = fences;
			FenceFloor = fenceFloor;
			FenceColors = fenceColors.Concat(houses).ToArray();
			FenceHeight = fenceHeight;
			TreePos = treePos;
			Skrapers = skrapers;
			SkraperHeights = skraperHeights;
			NewRoadmap = roadMap;
			RoadMap = null;
			SegmentType = segmentType;
			SegmentPos = segmentPos;
			SegmentRot = segmentRot;
			SegmentWidth = null;
			Plot = plot;
			RoofPoints = roofPoints;
			RoofUVs = roofUVs;
			RoofTris = roofTris;
			RoofHeight = roofHeight;
			RoofColors = roofColors;
			RoofFloor = roofFloor;
			Lakes = lakes;
		}
	}

	public Mesh cubeMesh;

	public Mesh cubeTube;

	public Mesh Tree;

	public Mesh House;

	public Mesh Quad;

	public Material Mat;

	public GameObject CreateMap(bool allowComplexSegments)
	{
		return CreateMap(MapDescFromGame(GameSettings.Instance.PlotRect()), allowComplexSegments);
	}

	private static SVector3[] GetRoom(BuildingPrefab prefab, BuildingPrefab.RoomObject room)
	{
		SVector3[] array = new SVector3[room.Edges.Length];
		for (int i = 0; i < room.Edges.Length; i++)
		{
			int num = room.Edges[i];
			int element = room.Edges[(i + 1) % room.Edges.Length];
			int[] value;
			if (prefab.Smoothing.TryGetValue(num, out value) && value.Contains(element))
			{
				array[i] = prefab.Edges[num].Swizzle(1f, 3);
			}
			else
			{
				array[i] = prefab.Edges[num];
			}
		}
		return array;
	}

	public static SVector3[] GetRoom(Room room)
	{
		SVector3[] array = new SVector3[room.Edges.Count];
		for (int i = 0; i < room.Edges.Count; i++)
		{
			WallEdge wallEdge = room.Edges[i];
			WallEdge item = room.Edges[(i + 1) % room.Edges.Count];
			array[i] = wallEdge.Pos;
			if (wallEdge.Smooth.Contains(item))
			{
				array[i] = array[i].Swizzle(1f, 3);
			}
		}
		return array;
	}

	public MapDescriptor MapDescFromRooms(BuildingPrefab r, bool basement)
	{
		float xmin = r.Edges.Min((SVector3 x) => x.x);
		float ymin = r.Edges.Min((SVector3 x) => x.y);
		float xmax = r.Edges.Max((SVector3 x) => x.x);
		float ymax = r.Edges.Max((SVector3 x) => x.y);
		Rect rect = Rect.MinMaxRect(xmin, ymin, xmax, ymax);
		int floorOffset = int.MaxValue;
		List<BuildingPrefab.RoomObject> list = new List<BuildingPrefab.RoomObject>();
		List<BuildingPrefab.RoomObject> list2 = new List<BuildingPrefab.RoomObject>();
		for (int num = 0; num < r.Rooms.Length; num++)
		{
			BuildingPrefab.RoomObject roomObject = r.Rooms[num];
			if (roomObject.Outdoor)
			{
				if (!basement)
				{
					list2.Add(roomObject);
					floorOffset = Mathf.Min(floorOffset, roomObject.Floor);
				}
			}
			else if (roomObject.Floor < 0 == basement)
			{
				list.Add(roomObject);
				floorOffset = Mathf.Min(floorOffset, roomObject.Floor);
			}
		}
		if (list.Count + list2.Count == 0)
		{
			throw new Exception("Tried creating miniature with no rooms");
		}
		SVector3[][] rooms = list.SelectInPlace((BuildingPrefab.RoomObject x) => GetRoom(r, x));
		SVector3[] roomColors = list.SelectInPlace((BuildingPrefab.RoomObject x) => (x.Atrium < 0) ? x.Colors[1] : r.Rooms[x.Atrium].Colors[1]);
		int[] roomFloors = list.SelectInPlace((BuildingPrefab.RoomObject x) => x.Floor - floorOffset);
		SVector3 gColor = TimeOfDay.Instance.GetGroundColor();
		SVector3[][] fences;
		SVector3[] fenceColors;
		SVector3[][] fenceFloor;
		float[] fenceHeight;
		if (!basement)
		{
			fences = list2.SelectInPlace(delegate(BuildingPrefab.RoomObject x)
			{
				SVector3[] array8 = new SVector3[x.Edges.Length * 2];
				for (int i = 0; i < x.Edges.Length; i++)
				{
					int num12 = (i + 1) % x.Edges.Length;
					array8[i * 2] = r.Edges[x.Edges[i]];
					array8[i * 2 + 1] = r.Edges[x.Edges[num12]];
				}
				for (int j = 0; j < array8.Length; j++)
				{
					array8[j] = new SVector3(array8[j].x, x.Floor - floorOffset, array8[j].y);
				}
				return array8;
			});
			fenceColors = list2.SelectInPlace((BuildingPrefab.RoomObject x) => x.Colors[1]);
			fenceFloor = list2.SelectInPlace(delegate(BuildingPrefab.RoomObject x)
			{
				List<SVector3> list8 = x.Edges.Select((int z) => new SVector3(r.Edges[z].x, x.Floor - floorOffset, r.Edges[z].y)).ToList();
				list8.Add(x.Materials[2].Equals("None") ? gColor : x.Colors[2]);
				return list8.ToArray();
			});
			fenceHeight = list2.SelectInPlace((BuildingPrefab.RoomObject x) => x.GetFenceHeight());
		}
		else
		{
			fences = new SVector3[0][];
			fenceColors = new SVector3[0];
			fenceFloor = new SVector3[0][];
			fenceHeight = new float[0];
		}
		Dictionary<string, RoomSegment> dictionary = ObjectDatabase.Instance.RoomSegments.ToDictionary((GameObject x) => x.name, (GameObject x) => x.GetComponent<RoomSegment>());
		List<string> list3 = new List<string>();
		List<SVector3> list4 = new List<SVector3>();
		List<float> list5 = new List<float>();
		List<float> list6 = new List<float>();
		for (int num2 = 0; num2 < r.Rooms.Length; num2++)
		{
			BuildingPrefab.RoomObject roomObject2 = r.Rooms[num2];
			if (roomObject2.Floor < 0 != basement)
			{
				continue;
			}
			for (int num3 = 0; num3 < roomObject2.Segments.Length; num3++)
			{
				BuildingPrefab.SegmentObject segmentObject = roomObject2.Segments[num3];
				RoomSegment value;
				if (!dictionary.TryGetValue(segmentObject.Name, out value) || !value.MiniMap)
				{
					continue;
				}
				Vector2 vector = segmentObject.Position.ToVector3().FlattenVector3();
				for (int num4 = 0; num4 < roomObject2.Edges.Length; num4++)
				{
					Vector2 vector2 = r.Edges[roomObject2.Edges[num4]].ToVector2();
					Vector2 vector3 = r.Edges[roomObject2.Edges[(num4 + 1) % roomObject2.Edges.Length]].ToVector2();
					Vector2 res;
					if (Utilities.ProjectToLine(vector, vector2, vector3, out res) && (res - vector).sqrMagnitude < 0.05f)
					{
						list3.Add(segmentObject.Name);
						list4.Add(new SVector3(segmentObject.Position.x, segmentObject.Position.y - (float)(floorOffset * 2), segmentObject.Position.z));
						Vector2 vector4 = vector3 - vector2;
						list5.Add(Utilities.EulerAngleY(0f - vector4.y, vector4.x));
						list6.Add(segmentObject.Width);
						break;
					}
				}
			}
		}
		int num5 = ((!basement) ? r.Roofs.Length : 0);
		SVector3[][] array = new SVector3[num5][];
		SVector3[][] array2 = new SVector3[num5][];
		int[][] array3 = new int[num5][];
		float[] array4 = new float[num5];
		SVector3[] array5 = new SVector3[num5];
		int[] array6 = new int[num5];
		for (int num6 = 0; num6 < num5; num6++)
		{
			BuildingPrefab.RoofObject roofObject = r.Roofs[num6];
			RoofBuilder.RoofPoint[] ps = roofObject.RoofPoints.SelectInPlace((SVector3 x) => new RoofBuilder.RoofPoint(x, true));
			List<RoofBuilder.MeshTriangle> list7 = RoofBuilder.BuildRoof(roofObject.Area.SelectInPlace((SVector3 x) => x.ToVector2()), roofObject.RoofEdges.ZipList((int x, int y) => new RoofBuilder.RoofEdge(ps[x], ps[y])));
			ps = list7.SelectMany((RoofBuilder.MeshTriangle x) => x.Points).Distinct().ToArray();
			for (int num7 = 0; num7 < ps.Length; num7++)
			{
				ps[num7].Index = num7;
			}
			array[num6] = ((IList<RoofBuilder.RoofPoint>)ps).SelectInPlace((Func<RoofBuilder.RoofPoint, SVector3>)((RoofBuilder.RoofPoint x) => x.FinalPoint));
			array2[num6] = ps.SelectInPlace((RoofBuilder.RoofPoint x) => new SVector3(x.uvX, x.ExplicitUVY ?? (-1f), x.RoofTop ? 1 : 0));
			array3[num6] = list7.SelectMany((RoofBuilder.MeshTriangle x) => x.Points.Select((RoofBuilder.RoofPoint z) => z.Index)).ToArray();
			array4[num6] = roofObject.Height;
			array5[num6] = roofObject.RoofColor;
			array6[num6] = roofObject.Floor - floorOffset;
		}
		SVector3[] treePos = new SVector3[0];
		SVector3[] array7 = new SVector3[0];
		float[] skraperHeights = new float[3] { gColor.x, gColor.y, gColor.z };
		int num8 = (int)rect.x / 8;
		int num9 = (int)(rect.x + rect.width) / 8;
		int num10 = (int)rect.y / 8;
		int num11 = (int)(rect.y + rect.height) / 8;
		byte[,] roadMap = new byte[num9 - num8, num11 - num10];
		MapDescriptor result = new MapDescriptor(rooms, roomColors, roomFloors, fences, fenceFloor, fenceColors, array7, fenceHeight, treePos, array7, skraperHeights, roadMap, list3.ToArray(), list4.ToArray(), list5.ToArray(), array, array2, array3, array4, array6, array5, new SVector3(rect.x, rect.y, rect.width, rect.height), new SVector3[0][]);
		result.SegmentWidth = list6.ToArray();
		return result;
	}

	public MapDescriptor MapDescFromRooms(Room[] r, Roof[] roofs, bool fixPlot = true)
	{
		Rect rect;
		if (fixPlot)
		{
			float xmin = r.Min((Room x) => x.RoomBounds.xMin);
			float ymin = r.Min((Room x) => x.RoomBounds.yMin);
			float xmax = r.Max((Room x) => x.RoomBounds.xMax);
			float ymax = r.Max((Room x) => x.RoomBounds.yMax);
			rect = Rect.MinMaxRect(xmin, ymin, xmax, ymax);
		}
		else
		{
			rect = new Rect(0f, 0f, 256f, 256f);
		}
		int floorOffset = Mathf.Max(0, r.Min((Room x) => x.Floor));
		Room[] arr = r.Where((Room x) => !x.Outdoors).ToArray();
		SVector3[][] rooms = arr.SelectInPlace(GetRoom);
		SVector3[] roomColors = ((IList<Room>)arr).SelectInPlace((Func<Room, SVector3>)((Room x) => x.OutsideColor));
		int[] roomFloors = arr.SelectInPlace((Room x) => x.Floor - floorOffset);
		Color gColor = TimeOfDay.Instance.GetGroundColor();
		Room[] arr2 = r.Where((Room x) => x.Outdoors).ToArray();
		SVector3[][] fences = arr2.SelectInPlace((Room x) => x.GetFenceSegments().SelectInPlace((Vector2 z) => new SVector3(z.x, x.Floor - floorOffset, z.y)));
		SVector3[] fenceColors = ((IList<Room>)arr2).SelectInPlace((Func<Room, SVector3>)((Room x) => x.OutsideColor));
		SVector3[][] fenceFloor = arr2.SelectInPlace(delegate(Room x)
		{
			List<SVector3> list2 = x.Edges.Select((WallEdge z) => new SVector3(z.Pos.x, x.Floor - floorOffset, z.Pos.y)).ToList();
			list2.Add(x.FloorMat.Equals("None") ? gColor : x.FloorColor);
			return list2.ToArray();
		});
		float[] fenceHeight = arr2.SelectInPlace((Room x) => x.FenceHeight);
		List<RoomSegment> arr3 = (from x in r.SelectMany((Room x) => x.GetSegments()).Distinct()
			where x.MiniMap && (x.FirstEdge.IsAgainstOutdoors(x.SecondEdge) || !x.FirstEdge.Links.ContainsValue(x.SecondEdge) || !x.SecondEdge.Links.ContainsValue(x.FirstEdge))
			select x).ToList();
		string[] segmentType = arr3.SelectInPlace((RoomSegment z) => z.name.Replace("(Clone)", "").Trim());
		SVector3[] segmentPos = ((IList<RoomSegment>)arr3).SelectInPlace((Func<RoomSegment, SVector3>)((RoomSegment z) => z.transform.position + Vector3.down * floorOffset * 2f));
		float[] segmentRot = arr3.SelectInPlace((RoomSegment z) => z.transform.rotation.eulerAngles.y);
		float[] segmentWidth = arr3.SelectInPlace((RoomSegment z) => z.MiniWidth);
		SVector3[] treePos = new SVector3[0];
		SVector3[] array = new SVector3[0];
		float[] skraperHeights = new float[3] { gColor.r, gColor.g, gColor.b };
		int num = (int)rect.x / 8;
		int num2 = (int)(rect.x + rect.width) / 8;
		int num3 = (int)rect.y / 8;
		int num4 = (int)(rect.y + rect.height) / 8;
		byte[,] roadMap = new byte[num2 - num, num4 - num3];
		SVector3[][] array2 = new SVector3[roofs.Length][];
		SVector3[][] array3 = new SVector3[roofs.Length][];
		int[][] array4 = new int[roofs.Length][];
		float[] array5 = new float[roofs.Length];
		SVector3[] array6 = new SVector3[roofs.Length];
		int[] array7 = new int[roofs.Length];
		for (int num5 = 0; num5 < roofs.Length; num5++)
		{
			Roof roof = roofs[num5];
			List<RoofBuilder.MeshTriangle> list = RoofBuilder.BuildRoof(roof.Area.ToArray(), Roof.GenerateRoofLine(roof.RoofLine));
			RoofBuilder.RoofPoint[] array8 = list.SelectMany((RoofBuilder.MeshTriangle x) => x.Points).Distinct().ToArray();
			for (int num6 = 0; num6 < array8.Length; num6++)
			{
				array8[num6].Index = num6;
			}
			array2[num5] = ((IList<RoofBuilder.RoofPoint>)array8).SelectInPlace((Func<RoofBuilder.RoofPoint, SVector3>)((RoofBuilder.RoofPoint x) => x.FinalPoint));
			array3[num5] = array8.SelectInPlace((RoofBuilder.RoofPoint x) => new SVector3(x.uvX, x.ExplicitUVY ?? (-1f), x.RoofTop ? 1 : 0));
			array4[num5] = list.SelectMany((RoofBuilder.MeshTriangle x) => x.Points.Select((RoofBuilder.RoofPoint z) => z.Index)).ToArray();
			array5[num5] = roof.Height;
			array6[num5] = roof.RoofColor;
			array7[num5] = roof.Floor;
		}
		MapDescriptor result = new MapDescriptor(rooms, roomColors, roomFloors, fences, fenceFloor, fenceColors, array, fenceHeight, treePos, array, skraperHeights, roadMap, segmentType, segmentPos, segmentRot, array2, array3, array4, array5, array7, array6, new SVector3(rect.x, rect.y, rect.width, rect.height), new SVector3[0][]);
		result.SegmentWidth = segmentWidth;
		return result;
	}

	public MapDescriptor MapDescFromGame(Rect plot)
	{
		Color gColor = TimeOfDay.Instance.GetGroundColor();
		plot = new Rect(Mathf.Floor(plot.x / 8f) * 8f, Mathf.Floor(plot.y / 8f) * 8f, Mathf.Max(4f, Mathf.Ceil((plot.x + plot.width) / 8f) * 8f - Mathf.Floor(plot.x / 8f) * 8f), Mathf.Max(4f, Mathf.Ceil((plot.y + plot.height) / 8f) * 8f - Mathf.Floor(plot.y / 8f) * 8f));
		Room[] arr = GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.Floor >= 0 && !x.Outdoors).ToArray();
		SVector3[][] rooms = arr.SelectInPlace(GetRoom);
		SVector3[] roomColors = ((IList<Room>)arr).SelectInPlace((Func<Room, SVector3>)((Room x) => x.OutsideColor));
		int[] roomFloors = arr.SelectInPlace((Room x) => x.Floor);
		Room[] arr2 = GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.Outdoors).ToArray();
		SVector3[][] fences = arr2.SelectInPlace((Room x) => x.GetFenceSegments().SelectInPlace((Vector2 z) => new SVector3(z.x, x.Floor, z.y)));
		SVector3[] fenceColors = ((IList<Room>)arr2).SelectInPlace((Func<Room, SVector3>)((Room x) => x.FenceColor));
		SVector3[][] fenceFloor = arr2.SelectInPlace(delegate(Room x)
		{
			List<SVector3> list5 = x.Edges.Select((WallEdge z) => new SVector3(z.Pos.x, x.Floor, z.Pos.y)).ToList();
			list5.Add(x.FloorMat.Equals("None") ? gColor : x.FloorColor);
			return list5.ToArray();
		});
		float[] fenceHeight = arr2.SelectInPlace((Room x) => x.FenceHeight);
		List<RoomSegment> arr3 = GameSettings.Instance.sRoomManager.RoomSegments.Where((RoomSegment x) => x != null && x.MiniMap && x.WallPosition.Count > 1 && x.IsAgainstExterior).ToList();
		string[] segmentType = arr3.SelectInPlace((RoomSegment z) => z.name.Replace("(Clone)", "").Trim());
		SVector3[] segmentPos = ((IList<RoomSegment>)arr3).SelectInPlace((Func<RoomSegment, SVector3>)((RoomSegment z) => z.transform.position));
		float[] segmentRot = arr3.SelectInPlace((RoomSegment z) => z.transform.rotation.eulerAngles.y);
		float[] segmentWidth = arr3.SelectInPlace((RoomSegment z) => z.MiniWidth);
		SVector3[] array = (from x in GameSettings.Instance.Trees
			where x.Position.x >= plot.xMin && x.Position.x <= plot.xMax && x.Position.z >= plot.yMin && x.Position.z <= plot.yMax
			select x.Position).ToArray();
		array.Shuffle();
		RoadManager instance = RoadManager.Instance;
		SkraperGen[] list = (from x in instance.Landmarks.OfType<SkraperGen>()
			where x.Blob.xMin >= plot.xMin && x.Blob.xMax <= plot.xMax && x.Blob.yMin >= plot.yMin && x.Blob.yMax <= plot.yMax
			select x).ToArray();
		SVector3[] skrapers = (from x in list.SelectMany((SkraperGen x) => x.Blobs)
			select new SVector3(x.Item1.x, x.Item1.y, x.Item1.width, x.Item1.height)).ToArray();
		float[] skraperHeights = (from x in list.SelectMany((SkraperGen x) => x.Blobs)
			select x.Item2).Concat(new float[3] { gColor.r, gColor.g, gColor.b }).ToArray();
		SVector3[] houses = (from x in instance.Landmarks.OfType<BurbHouse>()
			where plot.ContainsEntirely(x.transform.position.FlattenVector3(), 0.1f)
			select x).Select(delegate(BurbHouse x)
		{
			Vector3 position = x.transform.position;
			float y = x.transform.rotation.eulerAngles.y;
			return new SVector3(position.x, position.y, position.z, y);
		}).ToArray();
		int num = Mathf.Clamp((int)plot.x / 8, 0, instance.GridSize);
		int num2 = Mathf.Clamp((int)(plot.x + plot.width) / 8, 0, instance.GridSize);
		int num3 = Mathf.Clamp((int)plot.y / 8, 0, instance.GridSize);
		int num4 = Mathf.Clamp((int)(plot.y + plot.height) / 8, 0, instance.GridSize);
		byte[,] array2 = new byte[num2 - num, num4 - num3];
		for (int num5 = num; num5 < num2; num5++)
		{
			for (int num6 = num3; num6 < num4; num6++)
			{
				int num7 = instance.GetRoadHeight(num5, num6, false) / 2;
				if (num7 >= 0)
				{
					int num8 = (instance.GetRoad(num5, num6, num7) << 4) & 0xF0;
					array2[num5 - num, num6 - num3] = (byte)(num7 | num8);
				}
				else
				{
					array2[num5 - num, num6 - num3] = 0;
				}
			}
		}
		List<Roof> list2 = new List<Roof>(GameSettings.Instance.sRoomManager.Roofs);
		for (int num9 = 0; num9 < list2.Count; num9++)
		{
			if (list2[num9].RoofLine == null)
			{
				list2.RemoveAt(num9);
				num9--;
			}
		}
		SVector3[][] array3 = new SVector3[list2.Count][];
		SVector3[][] array4 = new SVector3[list2.Count][];
		int[][] array5 = new int[list2.Count][];
		float[] array6 = new float[list2.Count];
		SVector3[] array7 = new SVector3[list2.Count];
		int[] array8 = new int[list2.Count];
		for (int num10 = 0; num10 < list2.Count; num10++)
		{
			Roof roof = list2[num10];
			List<RoofBuilder.MeshTriangle> list3 = RoofBuilder.BuildRoof(roof.Area.ToArray(), Roof.GenerateRoofLine(roof.RoofLine));
			RoofBuilder.RoofPoint[] array9 = list3.SelectMany((RoofBuilder.MeshTriangle x) => x.Points).Distinct().ToArray();
			for (int num11 = 0; num11 < array9.Length; num11++)
			{
				array9[num11].Index = num11;
			}
			array3[num10] = ((IList<RoofBuilder.RoofPoint>)array9).SelectInPlace((Func<RoofBuilder.RoofPoint, SVector3>)((RoofBuilder.RoofPoint x) => x.FinalPoint));
			array4[num10] = array9.SelectInPlace((RoofBuilder.RoofPoint x) => new SVector3(x.uvX, x.ExplicitUVY ?? (-1f), x.RoofTop ? 1 : 0));
			array5[num10] = list3.SelectMany((RoofBuilder.MeshTriangle x) => x.Points.Select((RoofBuilder.RoofPoint z) => z.Index)).ToArray();
			array6[num10] = roof.Height;
			array7[num10] = roof.RoofColor;
			array8[num10] = roof.Floor;
		}
		List<SVector3[]> list4 = new List<SVector3[]>();
		foreach (Lake item in RoadManager.Instance.Landmarks.OfType<Lake>())
		{
			if (item.LakeArea.xMin >= plot.xMin && item.LakeArea.yMin >= plot.yMin && item.LakeArea.xMax <= plot.xMax && item.LakeArea.yMax <= plot.yMax)
			{
				list4.Add(((IList<Vector2>)item.LakeBounds).SelectInPlace((Func<Vector2, SVector3>)((Vector2 x) => x)));
			}
		}
		MapDescriptor result = new MapDescriptor(rooms, roomColors, roomFloors, fences, fenceFloor, fenceColors, houses, fenceHeight, array, skrapers, skraperHeights, array2, segmentType, segmentPos, segmentRot, array3, array4, array5, array6, array8, array7, new SVector3(plot.x, plot.y, plot.width, plot.height), list4.ToArray());
		result.SegmentWidth = segmentWidth;
		return result;
	}

	public GameObject CreateMap(MapDescriptor map, bool allowComplexSegments, bool includeGround = true, bool includeGroundStuff = true)
	{
		byte[,] array = map.NewRoadmap;
		if (array == null && map.RoadMap != null)
		{
			array = new byte[map.RoadMap.GetLength(0), map.RoadMap.GetLength(1)];
			for (int i = 0; i < map.RoadMap.GetLength(0); i++)
			{
				for (int j = 0; j < map.RoadMap.GetLength(1); j++)
				{
					array[i, j] = (byte)(map.RoadMap[i, j] ? 16u : 0u);
				}
			}
		}
		return CreateMap(map.Rooms, map.RoomColors, map.RoomFloors, map.Fences, map.FenceFloor, map.FenceColors, map.FenceHeight, map.TreePos, map.Skrapers, map.SkraperHeights, array, map.SegmentType, map.SegmentPos, map.SegmentRot, map.SegmentWidth, map.RoofPoints, map.RoofUVs, map.RoofTris, map.RoofFloor, map.RoofHeight, map.RoofColors, map.Lakes, new Rect(map.Plot.x, map.Plot.y, map.Plot.z, map.Plot.w), true, includeGround, includeGroundStuff, allowComplexSegments);
	}

	public Mesh CreateBuildingMesh(MapDescriptor desc, Vector2 voffset)
	{
		Vector3 offset = new Vector3(0f - voffset.x, 0f - voffset.y, 0f);
		List<CombineInstance> list = new List<CombineInstance>();
		for (int i = 0; i < desc.Rooms.Length; i++)
		{
			list.Add(new CombineInstance
			{
				mesh = CreateRoom(desc.Rooms[i], desc.RoomFloors[i], desc.RoomColors[i], offset),
				transform = Matrix4x4.identity
			});
		}
		if (desc.RoofPoints != null)
		{
			for (int j = 0; j < desc.RoofHeight.Length; j++)
			{
				list.Add(new CombineInstance
				{
					mesh = CreateRoof(desc.RoofPoints[j], desc.RoofUVs[j], desc.RoofTris[j], desc.RoofColors[j], desc.RoofHeight[j]),
					transform = Matrix4x4.TRS(-voffset.ToVector3(-desc.RoofFloor[j] * 2), Quaternion.identity, new Vector3(1f, desc.RoofHeight[j], 1f))
				});
			}
		}
		if (desc.Fences != null)
		{
			for (int k = 0; k < desc.Fences.Length; k++)
			{
				if (desc.Fences[k].Length != 0)
				{
					list.Add(new CombineInstance
					{
						mesh = CreateFence(desc.Fences[k], desc.FenceFloor[k], desc.FenceColors[k], offset, desc.FenceHeight[k]),
						transform = Matrix4x4.identity
					});
				}
			}
		}
		MeshCombiner meshCombiner = new MeshCombiner("Minimap: Segments", false, false, true);
		Dictionary<string, RoomSegment> dictionary = ObjectDatabase.Instance.RoomSegments.ToDictionary((GameObject x) => x.name, (GameObject x) => x.GetComponent<RoomSegment>());
		for (int num = 0; num < desc.SegmentType.Length; num++)
		{
			RoomSegment value;
			if (dictionary.TryGetValue(desc.SegmentType[num], out value))
			{
				AddSegment(value, desc.SegmentPos[num], desc.SegmentRot[num], desc.SegmentWidth[num], offset, false, meshCombiner);
			}
		}
		if (meshCombiner.HasData())
		{
			list.Add(meshCombiner.CreateCombine());
		}
		Mesh mesh = new Mesh();
		mesh.CombineMeshes(list.ToArray());
		list.ForEach(delegate(CombineInstance x)
		{
			UnityEngine.Object.Destroy(x.mesh);
		});
		return mesh;
	}

	private Mesh CreateFence(SVector3[] edges, SVector3[] floorPlan, Color color, Vector3 offset, float height)
	{
		Mesh m = new Mesh();
		List<CombineInstance> list = new List<CombineInstance>();
		Mesh mesh = ColorMesh(cubeMesh, color);
		float y = edges.First().y;
		float off = 0f;
		if (y == 0f)
		{
			off = 0.05f;
		}
		for (int i = 0; i < edges.Length; i += 2)
		{
			int num = i + 1;
			Vector3 vector = new Vector3(edges[i].x + offset.x, y * 2f + offset.z + height / 2f + off, edges[i].z + offset.y);
			Vector3 vector2 = new Vector3(edges[num].x + offset.x, y * 2f + offset.z + height / 2f + off, edges[num].z + offset.y);
			if (!(vector == vector2))
			{
				list.Add(new CombineInstance
				{
					mesh = mesh,
					transform = Matrix4x4.TRS((vector + vector2) * 0.5f, Quaternion.LookRotation(vector - vector2), new Vector3(0.05f, height, (vector - vector2).magnitude))
				});
			}
		}
		m.CombineMeshes(list.ToArray());
		UnityEngine.Object.Destroy(mesh);
		Color fCol = floorPlan.Last().ToColor();
		Vector3[] array = (from x in floorPlan.Take(floorPlan.Length - 1)
			select new Vector3(x.x + offset.x, x.y * 2f + offset.z + 0.01f + off, x.z + offset.y)).ToArray();
		int[] l = new Triangulator(array.Select((Vector3 x) => x.FlattenVector3()).ToArray()).Triangulate();
		Vector3[] vertices = m.vertices.ConcatArray(array);
		Vector3[] normals = m.normals.Concat(array.Select((Vector3 x) => Vector3.up)).ToArray();
		Color[] colors = m.colors.Concat(array.Select((Vector3 x) => fCol)).ToArray();
		int[] triangles = m.triangles.Concat(l.Select((int x) => x + m.vertexCount)).ToArray();
		Vector2[] uv = m.uv.Concat(array.Select((Vector3 x) => Vector2.zero)).ToArray();
		m.vertices = vertices;
		m.normals = normals;
		m.colors = colors;
		m.triangles = triangles;
		m.uv = uv;
		return m;
	}

	private Mesh CreateRoom(SVector3[] edges, int floor, Color color, Vector3 offset)
	{
		Mesh mesh = new Mesh();
		Vector3[] array = new Vector3[edges.Length * 2];
		Vector3[] array2 = new Vector3[edges.Length * 2];
		Vector3[] array3 = new Vector3[edges.Length * 2];
		bool flag = false;
		for (int i = 0; i < edges.Length; i++)
		{
			int num = (i + 1) % edges.Length;
			Vector3 vector = new Vector3(edges[i].x + offset.x, (float)(floor * 2) + offset.z, edges[i].y + offset.y);
			Vector3 vector2 = new Vector3(edges[num].x + offset.x, (float)(floor * 2) + offset.z, edges[num].y + offset.y);
			Vector3 vector3 = vector2 - vector;
			array[i * 2] = vector;
			array[i * 2 + 1] = vector2;
			array2[i * 2] = new Vector3(vector.x, vector.y + 2f, vector.z);
			array2[i * 2 + 1] = new Vector3(vector2.x, vector2.y + 2f, vector2.z);
			Vector3 normalized = new Vector3(vector3.z, 0f, 0f - vector3.x).normalized;
			if (edges[i].w > 0.5f)
			{
				int num2 = ((i == 0) ? (edges.Length - 1) : (i - 1));
				int num3 = (i + 2) % edges.Length;
				Vector2 first = new Vector2(edges[num2].x + offset.x, edges[num2].y + offset.y);
				Vector2 third = new Vector2(edges[num3].x + offset.x, edges[num3].y + offset.y);
				Vector2 vector4 = vector.FlattenVector3();
				Vector2 vector5 = vector2.FlattenVector3();
				Vector2 offset2 = Utilities.GetOffset(first, vector4, vector5, -1f, true);
				Vector2 offset3 = Utilities.GetOffset(vector4, vector5, third, -1f, true);
				Vector3 vector6 = (offset2 - vector4).normalized.ToVector3(0f);
				Vector3 vector7 = (offset3 - vector5).normalized.ToVector3(0f);
				if (Vector3.Dot(vector6, vector7) < 0.89f)
				{
					if (flag)
					{
						vector7 = normalized;
					}
					else
					{
						vector6 = normalized;
					}
					flag = false;
				}
				else
				{
					flag = true;
				}
				array3[i * 2] = vector6;
				array3[i * 2 + 1] = vector7;
			}
			else
			{
				array3[i * 2] = normalized;
				array3[i * 2 + 1] = normalized;
				flag = false;
			}
		}
		int[] array4 = new Triangulator(edges.Select((SVector3 x) => new Vector2(x.x, x.y))).Triangulate();
		int[] array5 = new int[array4.Length + edges.Length * 6];
		for (int num4 = 0; num4 < array4.Length; num4++)
		{
			array5[num4] = array4[num4] + array.Length * 2;
		}
		int num5 = array4.Length;
		for (int num6 = 0; num6 < edges.Length * 2 - 1; num6 += 2)
		{
			array5[num5] = num6;
			array5[num5 + 1] = edges.Length * 2 + num6;
			array5[num5 + 2] = edges.Length * 2 + num6 + 1;
			array5[num5 + 3] = edges.Length * 2 + num6 + 1;
			array5[num5 + 4] = num6 + 1;
			array5[num5 + 5] = num6;
			num5 += 6;
		}
		Vector3[] array6 = new Vector3[array.Length + array2.Length + edges.Length];
		for (int num7 = 0; num7 < array.Length; num7++)
		{
			array6[num7] = array[num7];
		}
		for (int num8 = 0; num8 < array2.Length; num8++)
		{
			array6[num8 + array.Length] = array2[num8];
		}
		for (int num9 = 0; num9 < edges.Length; num9++)
		{
			SVector3 sVector = edges[num9];
			array6[num9 + array.Length + array2.Length] = new Vector3(sVector.x + offset.x, (float)(floor * 2 + 2) + offset.z, sVector.y + offset.y);
		}
		Vector3[] array7 = new Vector3[array3.Length * 2 + edges.Length];
		for (int num10 = 0; num10 < array3.Length; num10++)
		{
			array7[num10] = array3[num10];
			array7[num10 + array3.Length] = array3[num10];
		}
		for (int num11 = 0; num11 < edges.Length; num11++)
		{
			array7[num11 + array3.Length * 2] = Vector3.up;
		}
		mesh.vertices = array6;
		mesh.normals = array7;
		mesh.triangles = array5;
		mesh.colors = Utilities.RepeatValue(color, array6.Length);
		mesh.uv = Utilities.RepeatValue(Vector2.zero, array6.Length);
		return mesh;
	}

	private Mesh CreateRoof(SVector3[] roofPoints, SVector3[] roofUVs, int[] roofTris, SVector3 color, float height)
	{
		List<RoofBuilder.RoofPoint> list = new List<RoofBuilder.RoofPoint>();
		for (int i = 0; i < roofPoints.Length; i++)
		{
			SVector3 sVector = roofPoints[i];
			SVector3 sVector2 = roofUVs[i];
			RoofBuilder.RoofPoint roofPoint = new RoofBuilder.RoofPoint(Vector2.zero, sVector2.z > 0f);
			roofPoint.FinalPoint = sVector;
			roofPoint.uvX = sVector2.x;
			if (sVector2.y >= 0f)
			{
				roofPoint.ExplicitUVY = sVector2.y;
			}
			list.Add(roofPoint);
		}
		List<RoofBuilder.MeshTriangle> list2 = new List<RoofBuilder.MeshTriangle>();
		for (int j = 0; j < roofTris.Length; j += 3)
		{
			int index = roofTris[j];
			int index2 = roofTris[j + 1];
			int index3 = roofTris[j + 2];
			list2.Add(new RoofBuilder.MeshTriangle(list[index], list[index2], list[index3], false));
		}
		Mesh mesh = RoofBuilder.BuildRoofMesh(list2, height / 2f, false, true)[0];
		mesh.colors = Utilities.RepeatValue(color.ToColor(), mesh.vertexCount);
		return mesh;
	}

	private void AddSegment(RoomSegment seg, Vector3 segP, float segmentRot, float? segmentWidth, Vector3 offset, bool complex, MeshCombiner combiner)
	{
		Vector3 vector = new Vector3(segmentWidth ?? seg.MiniWidth, seg.MiniHeight, complex ? 0.1f : 0f);
		Vector3 vector2 = new Vector3(segP.x + offset.x, segP.y + offset.z + seg.MiniYOffset, segP.z + offset.y);
		Quaternion quaternion = Quaternion.Euler(0f, segmentRot, 0f);
		if (complex)
		{
			combiner.ColorMesh(cubeMesh, Matrix4x4.TRS(vector2, quaternion, vector), seg.MiniColor);
			return;
		}
		Vector3 vector3 = quaternion * vector * 0.5f;
		Vector3 vector4 = vector2 + new Vector3(0f - vector3.x, vector3.y, 0f - vector3.z);
		Vector3 vector5 = vector2 + new Vector3(vector3.x, vector3.y, vector3.z);
		Vector3 vector6 = vector2 + new Vector3(vector3.x, 0f - vector3.y, vector3.z);
		Vector3 vector7 = vector2 + new Vector3(0f - vector3.x, 0f - vector3.y, 0f - vector3.z);
		Vector3 vector8 = new Vector3(Mathf.Sin(segmentRot * ((float)Math.PI / 180f)), 0f, Mathf.Cos(segmentRot * ((float)Math.PI / 180f)));
		Vector3 vector9 = vector8 * 0.01f;
		combiner.MakeFace(vector4 - vector9, vector5 - vector9, vector6 - vector9, vector7 - vector9, -vector8, seg.MiniColor);
		combiner.MakeFace(vector7 + vector9, vector6 + vector9, vector5 + vector9, vector4 + vector9, vector8, seg.MiniColor);
	}

	public GameObject CreateMap(SVector3[][] rooms, SVector3[] roomColors, int[] roomFloors, SVector3[][] fences, SVector3[][] fenceFloor, SVector3[] fenceColors, float[] fenceHeight, SVector3[] treePos, SVector3[] skrapers, float[] skraperHeights, byte[,] roadMap, string[] segmentType, SVector3[] segmentPos, float[] segmentRot, float[] segmentWidth, SVector3[][] roofPoints, SVector3[][] roofUVs, int[][] roofTris, int[] roofFloor, float[] roofHeight, SVector3[] roofColors, SVector3[][] lakes, Rect plot, bool unitSize, bool includeGround, bool includeGroundStuff, bool allowComplexSegments)
	{
		GameObject gameObject = new GameObject("Minimap");
		Vector3 offset = new Vector3(0f - plot.x - plot.width / 2f, 0f - plot.y - plot.height / 2f, includeGround ? ((float)(roomFloors.Any() ? (-roomFloors.Max()) : 0) + 3.5f) : 0f);
		List<CombineInstance> list = new List<CombineInstance>();
		for (int i = 0; i < rooms.Length; i++)
		{
			list.Add(new CombineInstance
			{
				mesh = CreateRoom(rooms[i], roomFloors[i], roomColors[i], offset),
				transform = Matrix4x4.identity
			});
		}
		if (roofPoints != null)
		{
			for (int j = 0; j < roofFloor.Length; j++)
			{
				list.Add(new CombineInstance
				{
					mesh = CreateRoof(roofPoints[j], roofUVs[j], roofTris[j], roofColors[j], roofHeight[j]),
					transform = Matrix4x4.TRS(new Vector3(offset.x, offset.z + (float)(roofFloor[j] * 2), offset.y), Quaternion.identity, new Vector3(1f, roofHeight[j], 1f))
				});
			}
		}
		if (fences != null)
		{
			for (int k = 0; k < fences.Length; k++)
			{
				if (fences[k].Length != 0)
				{
					list.Add(new CombineInstance
					{
						mesh = CreateFence(fences[k], fenceFloor[k], fenceColors[k], offset, fenceHeight[k]),
						transform = Matrix4x4.identity
					});
				}
			}
		}
		MeshCombiner meshCombiner = new MeshCombiner("Minimap: Skyscrapers", false, false, true);
		for (int l = 0; l < skrapers.Length; l++)
		{
			SVector3 sVector = skrapers[l];
			Vector2 vector = new Vector2(sVector.x + sVector.z / 2f + offset.x, sVector.y + sVector.w / 2f + offset.y);
			meshCombiner.ColorMesh(cubeMesh, Matrix4x4.TRS(new Vector3(vector.x, skraperHeights[l] / 2f + offset.z, vector.y), Quaternion.identity, new Vector3(sVector.z + 1f, skraperHeights[l], sVector.w + 1f)), new Color(0.8f, 0.8f, 0.8f, 1f));
		}
		if (meshCombiner.HasData())
		{
			list.Add(meshCombiner.CreateCombine());
		}
		meshCombiner.Clear("Minimap: Fences");
		if (fences != null)
		{
			for (int m = fences.Length; m < fenceColors.Length; m++)
			{
				SVector3 sVector2 = fenceColors[m];
				meshCombiner.ColorMesh(House, Matrix4x4.TRS(new Vector3(sVector2.x + offset.x, sVector2.y + offset.z, sVector2.z + offset.y), Quaternion.Euler(0f, sVector2.w, 0f), Vector3.one), new Color(0.8f, 0.5f, 0.4f, 1f));
			}
		}
		if (meshCombiner.HasData())
		{
			list.Add(meshCombiner.CreateCombine());
		}
		GameObject obj = CreateGameObject(list, "Building");
		list.ForEach(delegate(CombineInstance combineInstance)
		{
			UnityEngine.Object.Destroy(combineInstance.mesh);
		});
		obj.transform.parent = gameObject.transform;
		if (includeGround)
		{
			list.Clear();
			CombineInstance item = default(CombineInstance);
			Color color = ((skraperHeights.Length == skrapers.Length + 3) ? new Color(skraperHeights[skraperHeights.Length - 3], skraperHeights[skraperHeights.Length - 2], skraperHeights[skraperHeights.Length - 1]) : ((Color)new Color32(90, 132, 69, byte.MaxValue)));
			item.mesh = ColorMesh(cubeMesh, color);
			item.transform = Matrix4x4.TRS(new Vector3(0f, -2f + offset.z, 0f), Quaternion.identity, new Vector3(plot.width + 1f, 4f, plot.height + 1f));
			list.Add(item);
			list.Add(new CombineInstance
			{
				mesh = ColorMesh(cubeMesh, new Color32(105, 93, 61, byte.MaxValue)),
				transform = Matrix4x4.TRS(new Vector3(0f, -6f + offset.z, 0f), Quaternion.identity, new Vector3(plot.width, 4f, plot.height))
			});
			if (lakes != null && lakes.Length != 0)
			{
				meshCombiner.Clear("Minimap: Lakes");
				for (int num = 0; num < lakes.Length; num++)
				{
					Vector2[] array = lakes[num].SelectInPlace((SVector3 sVector4) => sVector4.ToVector2() + new Vector2(offset.x, offset.y));
					int[] tris = new Triangulator(array).Triangulate();
					meshCombiner.AddFlatMesh(array, tris, offset.z + 0.05f, null, new Color(0.4f, 0.7f, 1f, 1f));
				}
				list.Add(meshCombiner.CreateCombine());
			}
			CreateGameObject(list, "Ground").transform.parent = gameObject.transform;
			list.ForEach(delegate(CombineInstance combineInstance)
			{
				UnityEngine.Object.Destroy(combineInstance.mesh);
			});
		}
		meshCombiner.Clear("Minimap: Segments");
		Dictionary<string, RoomSegment> dictionary = ObjectDatabase.Instance.RoomSegments.ToDictionary((GameObject gameObject2) => gameObject2.name, (GameObject gameObject2) => gameObject2.GetComponent<RoomSegment>());
		bool complex = allowComplexSegments && segmentType.Length * 24 <= 65535;
		for (int num2 = 0; num2 < segmentType.Length; num2++)
		{
			RoomSegment value;
			if (dictionary.TryGetValue(segmentType[num2], out value))
			{
				AddSegment(value, segmentPos[num2], segmentRot[num2], (segmentWidth == null) ? ((float?)null) : new float?(segmentWidth[num2]), offset, complex, meshCombiner);
			}
		}
		CreateGameObject(meshCombiner, "Segments").transform.parent = gameObject.transform;
		if (includeGroundStuff)
		{
			Vector3 vector2 = new Vector3(offset.x, offset.z, offset.y);
			list.Clear();
			int num3 = treePos.Length * 48 / 50000 + 1;
			for (int num4 = 0; num4 < treePos.Length; num4 += num3)
			{
				SVector3 sVector3 = treePos[num4];
				list.Add(new CombineInstance
				{
					mesh = Tree,
					transform = Matrix4x4.TRS(sVector3.ToVector3() + vector2, Quaternion.identity, Vector3.one)
				});
			}
			CreateGameObject(list, "trees").transform.parent = gameObject.transform;
			meshCombiner.Clear("Minimap: Roads");
			if (roadMap != null)
			{
				int[] array2 = new int[4];
				bool[,] array3 = new bool[4, 2]
				{
					{ true, true },
					{ true, false },
					{ false, true },
					{ false, false }
				};
				int num5 = 8;
				for (int num6 = 0; num6 < roadMap.GetLength(0) + 1; num6++)
				{
					for (int num7 = 0; num7 < roadMap.GetLength(1) + 1; num7++)
					{
						array2[0] = GetRoadHeight(roadMap, num6, num7, 2);
						array2[1] = GetRoadHeight(roadMap, num6 - 1, num7, 1);
						array2[2] = GetRoadHeight(roadMap, num6, num7 - 1, 3);
						array2[3] = GetRoadHeight(roadMap, num6 - 1, num7 - 1, 0);
						int num8 = Mathf.Max(array2[0], array2[1], array2[2], array2[3]);
						if (num8 <= 0)
						{
							continue;
						}
						int num9 = 0;
						int num10 = 0;
						int num11 = 0;
						for (int num12 = 0; num12 < 4; num12++)
						{
							if (array2[num12] >= num8)
							{
								num9++;
								num10 = Mathf.Clamp(num10 + (array3[num12, 1] ? 1 : (-1)), -1, 1);
								num11 = Mathf.Clamp(num11 + (array3[num12, 0] ? 1 : (-1)), -1, 1);
							}
						}
						if (num9 < 3)
						{
							if (num9 > 2)
							{
								num10 = (num11 = 0);
							}
							float x = (float)num6 + (float)num10 * 0.1f;
							float z = (float)num7 + (float)num11 * 0.1f;
							float num13 = (float)num8 - 0.1f;
							meshCombiner.ColorMesh(cubeTube, Matrix4x4.TRS(new Vector3(x, num13 / 2f, z), Quaternion.identity, new Vector3(0.1f, num13, 0.1f)), Color.gray);
						}
					}
				}
				for (int num14 = 0; num14 < roadMap.GetLength(0); num14++)
				{
					for (int num15 = 0; num15 < roadMap.GetLength(1); num15++)
					{
						int roadType = GetRoadType(roadMap, num14, num15);
						if (roadType <= 0)
						{
							continue;
						}
						bool flag = true;
						for (int num16 = 0; num16 < 4; num16++)
						{
							array2[num16] = GetRoadHeight(roadMap, num14, num15, roadType, num16);
							if (num16 > 0 && array2[num16] != array2[num16 - 1])
							{
								flag = false;
							}
						}
						for (int num17 = 0; num17 < 4; num17++)
						{
							int num18 = (num17 + 1) % 2;
							int num19 = num17 % 2;
							if (num17.IsBetween(0, 3))
							{
								num18 *= -1;
								num19 *= -1;
							}
							int num20 = array2[num17];
							int num21 = array2[(num17 + 1) % 4];
							Vector2 vector3 = new Vector2((num17 < 2) ? 1 : 0, (!num17.IsBetween(0, 3)) ? 1 : 0);
							Vector2 vector4 = new Vector2((!num17.IsBetween(0, 3)) ? 1 : 0, (num17 > 1) ? 1 : 0);
							int roadType2 = GetRoadType(roadMap, num14 + num18, num15 + num19);
							int roadHeight = GetRoadHeight(roadMap, num14 + num18, num15 + num19, roadType2, (num17 + 3) % 4);
							int roadHeight2 = GetRoadHeight(roadMap, num14 + num18, num15 + num19, roadType2, (num17 + 2) % 4);
							if (num20 - roadHeight > 0 || num21 - roadHeight2 > 0)
							{
								meshCombiner.MakeFace(new Vector3((float)num14 + vector3.x, num20, (float)num15 + vector3.y), new Vector3((float)num14 + vector3.x, (float)num20 - 0.1f, (float)num15 + vector3.y), new Vector3((float)num14 + vector4.x, (float)num21 - 0.1f, (float)num15 + vector4.y), new Vector3((float)num14 + vector4.x, num21, (float)num15 + vector4.y), new Vector3(num18, 0f, num19), Color.gray);
							}
						}
						float num22 = ((flag && array2[0] == 0) ? 0.05f : 0f);
						meshCombiner.MakeFace(new Vector3(num14 + 1, (float)array2[0] + num22, num15 + 1), new Vector3(num14 + 1, (float)array2[1] + num22, num15), new Vector3(num14, (float)array2[2] + num22, num15), new Vector3(num14, (float)array2[3] + num22, num15 + 1), flag ? new Vector3?(Vector3.up) : ((Vector3?)null), Color.gray);
					}
				}
				CreateGameObject(meshCombiner, new Vector3((0f - plot.width) / 2f, 0.01f + offset.z, (0f - plot.height) / 2f), new Vector3(num5, 4f, num5), "road").transform.parent = gameObject.transform;
			}
		}
		if (unitSize)
		{
			float num23 = (roomFloors.Any() ? ((float)Mathf.Max(0, roomFloors.Max())) : 0f);
			num23 = ((fences != null && fences.Any()) ? Mathf.Max(fences.Max((SVector3[] array4) => (array4.Length == 0) ? 0f : array4[0].y), num23) : num23);
			float num24 = num23 * 2f + 2f;
			float num25 = 1f / Mathf.Max(plot.width, plot.height, num24 + (includeGround ? 12f : 0f));
			if (!includeGround)
			{
				gameObject.transform.position = gameObject.transform.position + Vector3.down * (num24 * num25 / 2f);
			}
			gameObject.transform.localScale = new Vector3(num25, num25, num25);
		}
		return gameObject;
	}

	private static int GetRoadHeight(byte[,] roadMap, int x, int y, int c)
	{
		return GetRoadHeight(roadMap, x, y, GetRoadType(roadMap, x, y), c);
	}

	private static int GetRoadHeight(byte[,] roadMap, int x, int y, int t, int c)
	{
		if (x >= 0 && x < roadMap.GetLength(0) && y >= 0 && y < roadMap.GetLength(1))
		{
			int num = roadMap[x, y] & 0xF;
			if (c == 0 && (t == 4 || t == 5))
			{
				num++;
			}
			if (c == 1 && (t == 5 || t == 6))
			{
				num++;
			}
			if (c == 2 && (t == 6 || t == 7))
			{
				num++;
			}
			if (c == 3 && (t == 7 || t == 4))
			{
				num++;
			}
			return num;
		}
		return 0;
	}

	private static int GetRoadType(byte[,] roadMap, int x, int y)
	{
		if (x >= 0 && x < roadMap.GetLength(0) && y >= 0 && y < roadMap.GetLength(1))
		{
			return (roadMap[x, y] & 0xF0) >> 4;
		}
		return 0;
	}

	private GameObject CreateGameObject(MeshCombiner combiner, string name)
	{
		GameObject gameObject = new GameObject(name);
		if (combiner.HasData())
		{
			FillGameobject(gameObject, combiner.CreateMesh());
		}
		return gameObject;
	}

	private GameObject CreateGameObject(MeshCombiner combiner, Vector3 translate, Vector3 scale, string name)
	{
		GameObject gameObject = new GameObject(name);
		if (combiner.HasData())
		{
			FillGameobject(gameObject, combiner.CreateMesh(translate, scale));
		}
		return gameObject;
	}

	private GameObject CreateGameObject(List<CombineInstance> meshes, string name)
	{
		GameObject gameObject = new GameObject(name);
		if (meshes != null)
		{
			Mesh mesh = new Mesh();
			mesh.CombineMeshes(meshes.ToArray());
			FillGameobject(gameObject, mesh);
		}
		return gameObject;
	}

	private void FillGameobject(GameObject go, Mesh mesh)
	{
		MeshRenderer meshRenderer = go.AddComponent<MeshRenderer>();
		meshRenderer.material = Mat;
		meshRenderer.lightProbeUsage = LightProbeUsage.Off;
		meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
		go.AddComponent<MeshFilter>().sharedMesh = mesh;
	}

	private static Mesh ColorMesh(Mesh mesh, Color color)
	{
		return new Mesh
		{
			vertices = mesh.vertices,
			triangles = mesh.triangles,
			uv = mesh.uv,
			colors = mesh.vertices.SelectInPlace((Vector3 x) => color),
			normals = mesh.normals,
			tangents = mesh.tangents
		};
	}
}
