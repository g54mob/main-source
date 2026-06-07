using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class RoadSegment : MonoBehaviour, IRoomConnector
{
	public Mesh SideWalk;

	public bool NeedsCrossing;

	public bool DisableCrossing;

	public int CrossingType;

	public RoadNode EastIn;

	public RoadNode EastOut;

	public RoadNode NorthIn;

	public RoadNode NorthOut;

	public RoadNode WestIn;

	public RoadNode WestOut;

	public RoadNode SouthIn;

	public RoadNode SouthOut;

	public bool AlwaysShadow;

	public bool EastRaised;

	public bool NorthRaised;

	public bool WestRaised;

	public bool SouthRaised;

	public int x;

	public int y;

	public int floor;

	public int rotI;

	public float Tx;

	public float Ty;

	public bool IsInputOutput;

	public Renderer[] rends;

	public RoadNode[] Parking = new RoadNode[0];

	[NonSerialized]
	public PathNode<Vector3> Self;

	[NonSerialized]
	private int[] _traffic = new int[50];

	private int _trafficPointer;

	private int _nextTraffic;

	private int _cachedTraffic = -1;

	private MaterialPropertyBlock _matBlock;

	public bool AIAllowed;

	public List<RoadNode> AllNodes = new List<RoadNode>();

	private static HashSet<PathNode<Vector3>> _visited = new HashSet<PathNode<Vector3>>();

	public bool Raised
	{
		get
		{
			if (!EastRaised && !NorthRaised && !WestRaised)
			{
				return SouthRaised;
			}
			return true;
		}
	}

	public bool IsBlocked
	{
		get
		{
			return false;
		}
	}

	public bool MovesBetweenFloors
	{
		get
		{
			return false;
		}
	}

	public bool IsConnecter
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public PathNode<Vector3> pathNode
	{
		get
		{
			return Self;
		}
		set
		{
		}
	}

	public Transform ObjectTransform
	{
		get
		{
			return base.transform;
		}
	}

	public bool IsNull
	{
		get
		{
			if (!(this == null))
			{
				return base.gameObject == null;
			}
			return true;
		}
	}

	public bool IsRefreshing
	{
		get
		{
			return false;
		}
	}

	[ContextMenu("Init nodes")]
	public void InitParking()
	{
		AllNodes = GetComponentsInChildren<RoadNode>().ToList();
		Parking = AllNodes.Where((RoadNode x) => x.Parking).ToArray();
		for (int num = 0; num < AllNodes.Count; num++)
		{
			AllNodes[num].Parent = this;
		}
		for (int num2 = 0; num2 < Parking.Length; num2++)
		{
			Parking[num2].ID = num2;
		}
	}

	public void AddTraffic()
	{
		int num = SDateTime.Now().ToInt();
		_traffic[_nextTraffic] = num;
		_nextTraffic++;
		if (_nextTraffic >= 50)
		{
			_nextTraffic = 0;
		}
		if (_nextTraffic == _trafficPointer)
		{
			_trafficPointer++;
			if (_trafficPointer >= 50)
			{
				_trafficPointer = 0;
			}
		}
		ClearOldTraffic(num);
		_cachedTraffic = -1;
	}

	public int GetTrafficCount()
	{
		int num = SDateTime.Now().ToInt();
		if (_cachedTraffic < 0 || num - _traffic[_trafficPointer] > 1440)
		{
			ClearOldTraffic(num);
			_cachedTraffic = ((_nextTraffic >= _trafficPointer) ? (_nextTraffic - _trafficPointer) : (50 - _trafficPointer + _nextTraffic));
		}
		return _cachedTraffic;
	}

	private void ClearOldTraffic(int now)
	{
		int num = _trafficPointer;
		for (int i = 0; i < 50; i++)
		{
			int num2 = (_trafficPointer + i) % 50;
			if (num2 == _nextTraffic)
			{
				num = num2;
				break;
			}
			if (now - _traffic[num2] <= 1440)
			{
				break;
			}
			num = num2 + 1;
		}
		_trafficPointer = num % 50;
	}

	public void Awake()
	{
		_matBlock = new MaterialPropertyBlock();
		_matBlock.SetVector("_offset", new Vector4(Tx, Ty));
		rends[0].SetPropertyBlock(_matBlock);
	}

	public void SetDataColor(Color color)
	{
		_matBlock.SetColor("_DataColor", color);
		rends[0].SetPropertyBlock(_matBlock);
	}

	public PathNode<Vector3> FindNode(Vector3 pos)
	{
		_visited.Clear();
		PathNode<Vector3> pathNode = CheckRoadNode(NorthIn, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		pathNode = CheckRoadNode(NorthOut, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		pathNode = CheckRoadNode(SouthIn, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		pathNode = CheckRoadNode(SouthOut, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		pathNode = CheckRoadNode(EastIn, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		pathNode = CheckRoadNode(EastOut, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		pathNode = CheckRoadNode(WestIn, pos);
		if (pathNode != null)
		{
			return pathNode;
		}
		return CheckRoadNode(WestOut, pos);
	}

	private PathNode<Vector3> CheckRoadNode(RoadNode n, Vector3 pos)
	{
		if (n != null)
		{
			return CheckNode(n.self, pos);
		}
		return null;
	}

	private PathNode<Vector3> CheckNode(PathNode<Vector3> n, Vector3 pos)
	{
		if (_visited.Add(n))
		{
			RoadNode roadNode = n.Tag as RoadNode;
			if (roadNode == null || roadNode.Parent == this)
			{
				if (n.Point.MaxDist(pos) < 0.001f)
				{
					return n;
				}
				foreach (PathNode<Vector3> connection in n.GetConnections())
				{
					PathNode<Vector3> pathNode = CheckNode(connection, pos);
					if (pathNode != null)
					{
						return pathNode;
					}
				}
			}
		}
		return null;
	}

	public void Init(int rot)
	{
		int num = (rotI = rot / 90);
		Self = new PathNode<Vector3>(base.transform.position.ReplaceY(floor * 4), this);
		Self.Weight = 2f;
		if (floor > 0)
		{
			GameSettings.Instance.sRoomManager.RoomRoadDirty = 2;
		}
		if (floor == 0 && !AlwaysShadow)
		{
			for (int i = 0; i < rends.Length; i++)
			{
				rends[i].shadowCastingMode = ShadowCastingMode.Off;
			}
		}
		for (int j = 0; j < num; j++)
		{
			bool northRaised = NorthRaised;
			bool southRaised = SouthRaised;
			bool eastRaised = EastRaised;
			bool westRaised = WestRaised;
			NorthRaised = westRaised;
			SouthRaised = eastRaised;
			EastRaised = northRaised;
			WestRaised = southRaised;
			RoadNode northOut = NorthOut;
			RoadNode northIn = NorthIn;
			RoadNode southOut = SouthOut;
			RoadNode southIn = SouthIn;
			RoadNode eastOut = EastOut;
			RoadNode eastIn = EastIn;
			RoadNode westOut = WestOut;
			RoadNode westIn = WestIn;
			NorthOut = westOut;
			NorthIn = westIn;
			SouthOut = eastOut;
			SouthIn = eastIn;
			EastOut = northOut;
			EastIn = northIn;
			WestOut = southOut;
			WestIn = southIn;
		}
		if (NorthOut != null)
		{
			NorthOut.Init(true);
		}
		if (NorthIn != null)
		{
			NorthIn.Init(true);
		}
		if (SouthOut != null)
		{
			SouthOut.Init(false);
		}
		if (SouthIn != null)
		{
			SouthIn.Init(false);
		}
		if (EastOut != null)
		{
			EastOut.Init(true);
		}
		if (EastIn != null)
		{
			EastIn.Init(false);
		}
		if (WestOut != null)
		{
			WestOut.Init(false);
		}
		if (WestIn != null)
		{
			WestIn.Init(true);
		}
		for (int k = 0; k < Parking.Length; k++)
		{
			if (Parking[k].Bike)
			{
				RoadManager.Instance.RegisterParking(Parking[k]);
			}
		}
	}

	private bool UseCrossing(RoadSegment other)
	{
		if ((CrossingType != other.CrossingType || rotI != other.rotI) && (NeedsCrossing || other.NeedsCrossing) && !DisableCrossing)
		{
			return !other.DisableCrossing;
		}
		return false;
	}

	public void Connect()
	{
		bool[] array = new bool[4];
		List<PathNode<Vector3>> connections = Self.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			PathNode<Vector3> pathNode = connections[i];
			if (pathNode.Tag is RoadSegment)
			{
				Self.RemoveConnection(pathNode);
				i--;
			}
		}
		if (!EastRaised && !WestRaised)
		{
			RoadSegment segment = RoadManager.Instance.GetSegment(x + 1, y, floor + (NorthRaised ? 1 : 0), !NorthRaised);
			if (segment != null && !segment.EastRaised && !segment.WestRaised && segment.floor < floor == segment.SouthRaised)
			{
				array[0] = UseCrossing(segment);
				Self.AddConnection(segment.Self);
				segment.Self.AddConnection(Self);
			}
			RoadSegment segment2 = RoadManager.Instance.GetSegment(x - 1, y, floor + (SouthRaised ? 1 : 0), !SouthRaised);
			if (segment2 != null && !segment2.EastRaised && !segment2.WestRaised && segment2.floor < floor == segment2.NorthRaised)
			{
				array[2] = UseCrossing(segment2);
				Self.AddConnection(segment2.Self);
				segment2.Self.AddConnection(Self);
			}
		}
		if (!NorthRaised && !SouthRaised)
		{
			RoadSegment segment3 = RoadManager.Instance.GetSegment(x, y - 1, floor + (EastRaised ? 1 : 0), !EastRaised);
			if (segment3 != null && !segment3.NorthRaised && !segment3.SouthRaised && segment3.floor < floor == segment3.WestRaised)
			{
				array[3] = UseCrossing(segment3);
				Self.AddConnection(segment3.Self);
				segment3.Self.AddConnection(Self);
			}
			RoadSegment segment4 = RoadManager.Instance.GetSegment(x, y + 1, floor + (WestRaised ? 1 : 0), !WestRaised);
			if (segment4 != null && !segment4.NorthRaised && !segment4.SouthRaised && segment4.floor < floor == segment4.EastRaised)
			{
				array[1] = UseCrossing(segment4);
				Self.AddConnection(segment4.Self);
				segment4.Self.AddConnection(Self);
			}
		}
		_matBlock.SetColor("_Crossings", new Color(array[0] ? 1 : 0, array[1] ? 1 : 0, array[2] ? 1 : 0, array[3] ? 1 : 0));
		rends[0].SetPropertyBlock(_matBlock);
	}

	public void RemoveConnections()
	{
		RoadSegment segment = RoadManager.Instance.GetSegment(x + 1, y, floor + (NorthRaised ? 1 : 0), !NorthRaised);
		if (segment != null)
		{
			segment.Self.RemoveConnection(Self);
			if (segment.SouthOut != null && NorthIn != null)
			{
				segment.SouthOut.self.RemoveConnection(NorthIn.self);
			}
		}
		RoadSegment segment2 = RoadManager.Instance.GetSegment(x - 1, y, floor + (SouthRaised ? 1 : 0), !SouthRaised);
		if (segment2 != null)
		{
			segment2.Self.RemoveConnection(Self);
			if (segment2.NorthOut != null && SouthIn != null)
			{
				segment2.NorthOut.self.RemoveConnection(SouthIn.self);
			}
		}
		RoadSegment segment3 = RoadManager.Instance.GetSegment(x, y - 1, floor + (EastRaised ? 1 : 0), !EastRaised);
		if (segment3 != null)
		{
			segment3.Self.RemoveConnection(Self);
			if (segment3.WestOut != null && EastIn != null)
			{
				segment3.WestOut.self.RemoveConnection(EastIn.self);
			}
		}
		RoadSegment segment4 = RoadManager.Instance.GetSegment(x, y + 1, floor + (WestRaised ? 1 : 0), !WestRaised);
		if (segment4 != null)
		{
			segment4.Self.RemoveConnection(Self);
			if (segment4.EastOut != null && WestIn != null)
			{
				segment4.EastOut.self.RemoveConnection(WestIn.self);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (Self == null)
		{
			return;
		}
		foreach (PathNode<Vector3> connection in Self.GetConnections())
		{
			Gizmos.color = Color.red;
			try
			{
				Gizmos.DrawLine(Self.Point, connection.Point);
			}
			catch (Exception)
			{
				Gizmos.DrawSphere(base.transform.position, 1f);
			}
		}
		Vector2 mouseProj = HUD.Instance.GetMouseProj();
		Gizmos.DrawSphere(mouseProj.ToVector3(SampleHeight(mouseProj)), 0.1f);
		Gizmos.color = (AIAllowed ? new Color(0f, 1f, 0f, 0.5f) : new Color(1f, 0f, 0f, 0.5f));
		Gizmos.DrawCube(base.transform.position, new Vector3(8f, 0.05f, 8f));
		Gizmos.color = Color.white;
	}

	private void DrawConnection(RoadNode start, HashSet<RoadNode> visited = null)
	{
		if (start != null && (visited == null || !visited.Contains(start)))
		{
			if (visited == null)
			{
				visited = new HashSet<RoadNode>();
			}
			visited.Add(start);
			RoadNode[] connected = start.Connected;
			foreach (RoadNode roadNode in connected)
			{
				Gizmos.DrawLine(start.transform.position, roadNode.transform.position);
				DrawConnection(roadNode, visited);
			}
		}
	}

	public Vector3 GetOffsetPos(Room room, bool inverse = false)
	{
		float rot;
		return GetOffset(true, 0f, out rot, false);
	}

	public bool AllowExit()
	{
		return true;
	}

	public bool AllowEntry()
	{
		return true;
	}

	public void UpdateBlocked()
	{
	}

	public Transform[] IntermediatePoints(Room from)
	{
		return null;
	}

	public RoadSegment GetRoad(Room from)
	{
		return null;
	}

	public bool GetRight(Vector3 pos)
	{
		if (NorthRaised)
		{
			return pos.z - Self.Point.z < 0f;
		}
		if (EastRaised)
		{
			return pos.x - Self.Point.x < 0f;
		}
		if (SouthRaised)
		{
			return pos.z - Self.Point.z > 0f;
		}
		return pos.x - Self.Point.x > 0f;
	}

	public Vector2Int GetRaisedVector()
	{
		return GetRaisedDirection().ToVector();
	}

	public Utilities.Direction GetRaisedDirection()
	{
		if (NorthRaised)
		{
			return Utilities.Direction.North;
		}
		if (SouthRaised)
		{
			return Utilities.Direction.South;
		}
		if (WestRaised)
		{
			return Utilities.Direction.West;
		}
		if (EastRaised)
		{
			return Utilities.Direction.East;
		}
		return Utilities.Direction.None;
	}

	public bool RaisedDir(int dx, int dy)
	{
		if (dy == 0)
		{
			switch (dx)
			{
			case 1:
				return NorthRaised;
			case -1:
				return SouthRaised;
			}
		}
		else if (dx == 0)
		{
			switch (dy)
			{
			case 1:
				return WestRaised;
			case -1:
				return EastRaised;
			}
		}
		return false;
	}

	public bool ValidRaisedIn(int dx, int dy, int dfloor)
	{
		if (dfloor <= 0)
		{
			Utilities.Direction raisedDirection = GetRaisedDirection();
			Utilities.Direction other = new Vector2Int(dx, dy).ToDirection();
			return raisedDirection.IsOpposite(other);
		}
		if (dfloor == 1)
		{
			return GetRaisedDirection() == new Vector2Int(dx, dy).ToDirection();
		}
		return false;
	}

	public float SampleHeight(Vector2 p)
	{
		bool flag = false;
		float num = 0f;
		float roadSize = RoadManager.Instance.RoadSize;
		if (NorthRaised)
		{
			num = p.x - (float)x * roadSize;
			flag = true;
		}
		if (SouthRaised)
		{
			num = (float)x * roadSize + roadSize - p.x;
			flag = true;
		}
		if (EastRaised)
		{
			num = (float)y * roadSize + roadSize - p.y;
			flag = true;
		}
		if (WestRaised)
		{
			num = p.y - (float)y * roadSize;
			flag = true;
		}
		float num2 = (float)floor * 4f;
		if (!flag)
		{
			return num2;
		}
		return num2 + Mathf.Clamp01(num / roadSize) * 4f;
	}

	public Vector3 GetOffset(bool right, float yPos, out float rot, bool goingIn)
	{
		Vector3 vector = Self.Point.ReplaceY(yPos);
		Vector3 vector2 = ((right == goingIn) ? new Vector3(3.5f, 0f, -4.5f) : new Vector3(-3.5f, 0f, -4.5f));
		rot = 0f;
		if (NorthRaised)
		{
			rot = 90f;
		}
		else if (EastRaised)
		{
			rot = 180f;
		}
		else if (SouthRaised)
		{
			rot = 270f;
		}
		return vector + Quaternion.Euler(0f, rot, 0f) * vector2;
	}

	public bool CheckSideWalkConnection(int dx, int dy, ref bool lip, byte sT, out bool bike)
	{
		bike = false;
		if (floor == 0)
		{
			if ((dy == -1 || dy == RoadManager.Instance.GridSize) && dx == 0)
			{
				return true;
			}
			if ((dy == 0 || dy == RoadManager.Instance.GridSize - 1) && dx == RoadManager.Instance.GridSize)
			{
				return true;
			}
		}
		RoadSegment segment = RoadManager.Instance.GetSegment(dx, dy, floor);
		bool flag = false;
		byte b = 0;
		if (segment != null)
		{
			bool flag2 = dx > x;
			bool flag3 = dy > y;
			bool flag4 = dx < x;
			bool flag5 = dy < y;
			if (segment.floor == floor - 1)
			{
				flag = (flag2 && segment.SouthRaised) || (flag3 && segment.EastRaised) || (flag4 && segment.NorthRaised) || (flag5 && segment.WestRaised);
			}
			else if (segment.floor == floor)
			{
				flag = (flag2 && !segment.WestRaised && !segment.EastRaised && !segment.SouthRaised) || (flag3 && !segment.NorthRaised && !segment.EastRaised && !segment.SouthRaised) || (flag4 && !segment.WestRaised && !segment.EastRaised && !segment.NorthRaised) || (flag5 && !segment.WestRaised && !segment.NorthRaised && !segment.SouthRaised);
				b = RoadManager.Instance.GetRoad(dx, dy, floor);
				bike = b == 8 || b == 9;
				bool flag6 = sT == 8 || sT == 9;
				if (bike && flag6)
				{
					flag = true;
				}
				else if ((flag && !flag6) & bike)
				{
					flag = false;
					lip = false;
				}
			}
		}
		if (lip && !flag)
		{
			bool flag7 = dx > x;
			bool flag8 = dy > y;
			bool flag9 = dx < x;
			bool flag10 = dy < y;
			if (Self != null && Self.GetConnections().Count > 0)
			{
				List<PathNode<Vector3>> connections = Self.GetConnections();
				for (int i = 0; i < connections.Count; i++)
				{
					PathNode<Vector3> pathNode = connections[i];
					if (pathNode.Tag is RoomSegment)
					{
						if (flag7 && pathNode.Point.x > Self.Point.x + 3.9f)
						{
							lip = false;
							break;
						}
						if (flag8 && pathNode.Point.z > Self.Point.z + 3.9f)
						{
							lip = false;
							break;
						}
						if (flag9 && pathNode.Point.x < Self.Point.x - 3.9f)
						{
							lip = false;
							break;
						}
						if (flag10 && pathNode.Point.z < Self.Point.z - 3.9f)
						{
							lip = false;
							break;
						}
					}
				}
			}
			if (lip)
			{
				float roadSize = RoadManager.Instance.RoadSize;
				float num = (float)x * roadSize + roadSize / 2f + (float)(dx - x) * (roadSize / 2f + 0.5f);
				float num2 = (float)y * roadSize + roadSize / 2f + (float)(dy - y) * (roadSize / 2f + 0.5f);
				if (GameSettings.Instance.sRoomManager.GetRoomFromPoint(floor * 2, new Vector2(num, num2)) != null)
				{
					lip = false;
				}
			}
		}
		return flag;
	}

	public void GenerateSidewalk(MeshCombiner mc)
	{
		if (SideWalk != null)
		{
			mc.AddMesh(SideWalk, Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one), false);
			return;
		}
		bool lip2;
		bool lip3;
		bool lip4;
		bool lip5;
		bool lip = (lip2 = (lip3 = (lip4 = (lip5 = floor > 0))));
		byte road = RoadManager.Instance.GetRoad(x, y, floor);
		bool flag = road == 8 || road == 9;
		bool bike;
		bool flag2 = CheckSideWalkConnection(x + 1, y, ref lip5, road, out bike);
		bool bike2;
		bool flag3 = CheckSideWalkConnection(x, y + 1, ref lip4, road, out bike2);
		bool bike3;
		bool flag4 = CheckSideWalkConnection(x - 1, y, ref lip3, road, out bike3);
		bool bike4;
		bool flag5 = CheckSideWalkConnection(x, y - 1, ref lip2, road, out bike4);
		bool bike5;
		bool leftUp = CheckSideWalkConnection(x + 1, y + 1, ref lip, road, out bike5) && (flag || (!bike && !bike2));
		bool leftUp2 = CheckSideWalkConnection(x - 1, y + 1, ref lip, road, out bike5) && (flag || (!bike3 && !bike2));
		bool leftUp3 = CheckSideWalkConnection(x - 1, y - 1, ref lip, road, out bike5) && (flag || (!bike3 && !bike4));
		bool leftUp4 = CheckSideWalkConnection(x + 1, y - 1, ref lip, road, out bike5) && (flag || (!bike && !bike4));
		CreateSideWalk(0f, flag3, leftUp, flag2, flag5, lip5, mc);
		CreateSideWalk(270f, flag4, leftUp2, flag3, flag2, lip4, mc);
		CreateSideWalk(180f, flag5, leftUp3, flag4, flag3, lip3, mc);
		CreateSideWalk(90f, flag2, leftUp4, flag5, flag4, lip2, mc);
	}

	private void CreateSideWalk(float rot, bool left, bool leftUp, bool straight, bool right, bool lip, MeshCombiner mc)
	{
		if (!straight)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(base.transform.position, Quaternion.Euler(0f, rot, 0f), Vector3.one);
			mc.AddMesh(lip ? RoadManager.Instance.SideWalkLip : RoadManager.Instance.SideWalkStraight, matrix4x, false);
			if (left)
			{
				mc.AddMesh(RoadManager.Instance.SideWalkCorner1, matrix4x, false);
			}
			if (right)
			{
				mc.AddMesh(RoadManager.Instance.SideWalkCorner2, matrix4x, false);
			}
		}
		else if (left && !leftUp)
		{
			mc.AddMesh((floor > 0) ? RoadManager.Instance.SideWalkCrossLip : RoadManager.Instance.SideWalkCross, Matrix4x4.TRS(base.transform.position, Quaternion.Euler(0f, rot, 0f), Vector3.one), false);
		}
	}

	private void OnDestroy()
	{
		if (GameSettings.Instance.IsReferenceNull() || Self == null)
		{
			return;
		}
		List<PathNode<Vector3>> connections = Self.GetConnections();
		for (int i = 0; i < connections.Count; i++)
		{
			RoomSegment roomSegment = connections[i].Tag as RoomSegment;
			if (roomSegment != null)
			{
				roomSegment.pathNode.RemoveConnection(Self);
				roomSegment.UpdateBlocked();
				GameSettings.Instance.sRoomManager.TeamAssignmentDirty = true;
			}
		}
	}

	public Vector2 GetLocalPosition(Vector3 p)
	{
		return new Vector2(p.x - (float)x * RoadManager.Instance.RoadSize, p.z - (float)y * RoadManager.Instance.RoadSize);
	}

	public Vector3 GetNearestSidewalk(Vector3 p)
	{
		Vector2 localPosition = GetLocalPosition(p);
		float roadSize = RoadManager.Instance.RoadSize;
		if ((localPosition.x < 0.8f || localPosition.x > roadSize - 0.8f) && (localPosition.y < 0.8f || localPosition.y > roadSize - 0.8f))
		{
			return p;
		}
		Vector2 vector = new Vector2(roadSize / 2f, roadSize / 2f);
		float num = float.MaxValue;
		Vector2 vector2 = Vector2.zero;
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				if (i == 0 && j == i)
				{
					continue;
				}
				Vector2 vector3;
				if (i == 0 || j == 0)
				{
					if (HasConn(i, j))
					{
						continue;
					}
					vector3 = ((i != 0) ? new Vector2(roadSize / 2f + (float)i * (roadSize / 2f - UnityEngine.Random.Range(0.2f, 0.6f)), localPosition.y) : new Vector2(localPosition.x, roadSize / 2f + (float)j * (roadSize / 2f - UnityEngine.Random.Range(0.2f, 0.6f))));
				}
				else
				{
					vector3 = vector + new Vector2(i, j) * (roadSize / 2f - UnityEngine.Random.Range(0.2f, 0.6f));
				}
				float num2 = vector3.SqrDist(localPosition);
				if (num2 < num)
				{
					num = num2;
					vector2 = vector3;
				}
			}
		}
		return new Vector3(vector2.x + (float)x * roadSize, p.y, vector2.y + (float)y * roadSize);
	}

	public bool HasConn(int dx, int dy)
	{
		return RoadManager.Instance.GetRoad(x + dx, y + dy, floor) > 0;
	}

	public int GetFloorTo(Utilities.Direction dir)
	{
		int num = floor;
		if (dir == Utilities.Direction.North && NorthRaised)
		{
			num++;
		}
		if (dir == Utilities.Direction.East && EastRaised)
		{
			num++;
		}
		if (dir == Utilities.Direction.South && SouthRaised)
		{
			num++;
		}
		if (dir == Utilities.Direction.West && WestRaised)
		{
			num++;
		}
		return num;
	}
}
