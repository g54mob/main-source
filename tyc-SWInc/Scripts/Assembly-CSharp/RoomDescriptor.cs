using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class RoomDescriptor
{
	[Serializable]
	public class RoomObject
	{
		public WriteDictionary RoomData;

		public int Floor;

		public int[] Edges;

		public RoomObject(WriteDictionary data, int[] edge, int floor)
		{
			RoomData = data;
			Edges = edge;
			Floor = floor;
		}

		public RoomObject()
		{
		}
	}

	public RoomObject[] Rooms;

	public SVector3[] Edges;

	public Dictionary<int, int[]> Smoothing;

	public RoomDescriptor(RoomObject[] r, SVector3[] e, Dictionary<int, int[]> smoothing)
	{
		Rooms = r;
		Edges = e;
		Smoothing = smoothing;
	}

	public RoomDescriptor()
	{
	}

	public static RoomDescriptor SaveRooms(IEnumerable<Room> rooms, GameReader.NewLoadMode mode)
	{
		Dictionary<WallEdge, int> edgeNum = new Dictionary<WallEdge, int>();
		List<WallEdge> list = new List<WallEdge>();
		List<RoomObject> list2 = new List<RoomObject>();
		List<int> list3 = new List<int>();
		Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
		int num = 0;
		foreach (Room item in rooms.OrderBy((Room x) => x.GetAtriumSubOrder()))
		{
			for (int num2 = 0; num2 < item.Edges.Count; num2++)
			{
				WallEdge wallEdge = item.Edges[num2];
				int value = 0;
				if (edgeNum.TryGetValue(wallEdge, out value))
				{
					list3.Add(value);
					continue;
				}
				list3.Add(num);
				edgeNum[wallEdge] = num;
				list.Add(wallEdge);
				num++;
			}
			list2.Add(new RoomObject(item.SerializeThis(mode, true), list3.ToArray(), item.Floor));
			list3.Clear();
		}
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			WallEdge edge = list[num3];
			if (edge.Smooth.Count > 0)
			{
				int[] array = (from x in edge.Smooth
					where edge.Links.ContainsValue(x)
					select edgeNum[x]).ToArray();
				if (array.Length != 0)
				{
					dictionary[edgeNum[edge]] = array;
				}
			}
		}
		return new RoomDescriptor(list2.ToArray(), ((IList<WallEdge>)list).Select((Func<WallEdge, SVector3>)((WallEdge x) => x.Pos)).ToArray(), dictionary);
	}

	public void BuildRooms(Func<GameObject> makeRoom, bool loading)
	{
		bool flag = false;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		Dictionary<int, WallEdge> dictionary2 = new Dictionary<int, WallEdge>();
		Dictionary<KeyValuePair<int, int>, WallEdge> dictionary3 = new Dictionary<KeyValuePair<int, int>, WallEdge>();
		bool flag2 = false;
		bool flag3 = false;
		for (int i = 0; i < Rooms.Length; i++)
		{
			RoomObject roomObject = Rooms[i];
			uint num = roomObject.RoomData.Get("AtriumParent", 0u);
			if (num != 0 && num != roomObject.RoomData.Get("WriteID", 0u))
			{
				flag3 = true;
			}
			else if (flag3)
			{
				flag2 = true;
			}
			for (int j = 0; j < roomObject.Edges.Length; j++)
			{
				int num2 = roomObject.Edges[j];
				int value;
				if (dictionary.TryGetValue(num2, out value))
				{
					if (value != roomObject.Floor)
					{
						dictionary3[new KeyValuePair<int, int>(num2, roomObject.Floor)] = new WallEdge(Edges[num2], roomObject.Floor);
						flag = true;
					}
				}
				else
				{
					WallEdge value2 = new WallEdge(Edges[num2], roomObject.Floor);
					dictionary3[new KeyValuePair<int, int>(num2, roomObject.Floor)] = value2;
					dictionary[num2] = roomObject.Floor;
					dictionary2[num2] = value2;
				}
			}
		}
		WallEdge[] array = null;
		GameSettings.Instance.sRoomManager.AllSegments.AddRange(dictionary3.Values);
		if (!flag)
		{
			array = new WallEdge[dictionary3.Count];
			foreach (KeyValuePair<KeyValuePair<int, int>, WallEdge> item in dictionary3)
			{
				array[item.Key.Key] = item.Value;
			}
		}
		if (Smoothing != null)
		{
			foreach (KeyValuePair<int, int[]> item2 in Smoothing)
			{
				WallEdge orDefault = dictionary2.GetOrDefault(item2.Key);
				if (orDefault == null)
				{
					continue;
				}
				for (int k = 0; k < item2.Value.Length; k++)
				{
					WallEdge orDefault2 = dictionary2.GetOrDefault(item2.Value[k]);
					if (orDefault2 != null)
					{
						orDefault.Smooth.Add(orDefault2);
					}
				}
			}
		}
		if (flag2)
		{
			Dictionary<uint, RoomObject> dictionary4 = new Dictionary<uint, RoomObject>();
			Dictionary<RoomObject, RoomObject> atrDict = new Dictionary<RoomObject, RoomObject>();
			for (int l = 0; l < Rooms.Length; l++)
			{
				RoomObject roomObject2 = Rooms[l];
				dictionary4[roomObject2.RoomData.Get("WriteID", 0u)] = roomObject2;
			}
			for (int m = 0; m < Rooms.Length; m++)
			{
				RoomObject roomObject3 = Rooms[m];
				uint num3 = roomObject3.RoomData.Get("AtriumParent", 0u);
				if (num3 != 0)
				{
					atrDict[roomObject3] = dictionary4[num3];
				}
			}
			{
				foreach (RoomObject item3 in Rooms.OrderBy((RoomObject x) => AtriumSubOrder(x, atrDict)))
				{
					CreateRoom(item3, array, dictionary3, makeRoom, loading, flag);
				}
				return;
			}
		}
		for (int num4 = 0; num4 < Rooms.Length; num4++)
		{
			CreateRoom(Rooms[num4], array, dictionary3, makeRoom, loading, flag);
		}
	}

	private static int AtriumSubOrder(RoomObject r, Dictionary<RoomObject, RoomObject> atriums)
	{
		RoomObject orNull = atriums.GetOrNull(r);
		if (orNull == null || orNull == r)
		{
			return 0;
		}
		if (atriums[orNull] != orNull)
		{
			return 2;
		}
		return 1;
	}

	private void CreateRoom(RoomObject item, WallEdge[] edges, Dictionary<KeyValuePair<int, int>, WallEdge> bugEdge, Func<GameObject> makeRoom, bool loading, bool bugged)
	{
		Room component = makeRoom().GetComponent<Room>();
		component.Deserialized = true;
		IEnumerable<int> source = item.Edges;
		if (item.Edges[0] == item.Edges[item.Edges.Length - 1])
		{
			source = source.Take(item.Edges.Length - 1);
		}
		if (bugged)
		{
			RoomObject item2 = item;
			component.Init(source.Select((int x) => bugEdge[new KeyValuePair<int, int>(x, item2.Floor)]), item.Floor, false, null, false, false, false);
		}
		else
		{
			component.Init(source.Select((int x) => edges[x]), item.Floor, false, null, false, false, false);
		}
		component.DeserializeThis(item.RoomData, loading);
	}
}
