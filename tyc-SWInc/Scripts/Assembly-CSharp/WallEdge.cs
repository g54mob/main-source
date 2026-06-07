using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallEdge
{
	public Vector2 Pos;

	public int Floor;

	public Dictionary<IRoom, WallEdge> Links = new Dictionary<IRoom, WallEdge>();

	public HashSet<WallEdge> Smooth = new HashSet<WallEdge>();

	private WallEdge TempCutOff;

	private WallEdge otherCutoff;

	private Room CutOffLink;

	private Room otherLink;

	[NonSerialized]
	public Dictionary<WallEdge, HashSet<WallSnap>> Children = new Dictionary<WallEdge, HashSet<WallSnap>>();

	public const float WallAngleThreshold = 0.001f;

	private static List<Vector2> _splitCache = new List<Vector2>();

	public WallEdge[] GetSplitEdges
	{
		get
		{
			return new WallEdge[2] { TempCutOff, otherCutoff };
		}
	}

	public Room[] GetSplitRooms
	{
		get
		{
			return new Room[2] { CutOffLink, otherLink };
		}
	}

	public bool IsSplitter
	{
		get
		{
			return TempCutOff != null;
		}
	}

	public WallEdge GetOppositeSplitEdge(Room r)
	{
		if (TempCutOff.GetRoom(otherCutoff) == r)
		{
			return otherCutoff;
		}
		return TempCutOff;
	}

	public WallEdge GetSplitEdgeFor(Room r)
	{
		if (TempCutOff.GetRoom(otherCutoff) == r)
		{
			return TempCutOff;
		}
		return otherCutoff;
	}

	public Room GetOppositeSplitRoom(Room r)
	{
		if (CutOffLink == r)
		{
			return otherLink;
		}
		return CutOffLink;
	}

	public bool CuttingSameWall(WallEdge e2)
	{
		if (IsSplitter && e2.IsSplitter)
		{
			if (e2.TempCutOff != TempCutOff || e2.otherCutoff != otherCutoff)
			{
				if (e2.TempCutOff == otherCutoff)
				{
					return e2.otherCutoff == TempCutOff;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public void AddSegment(WallEdge edge, WallSnap segment)
	{
		if (!Children.ContainsKey(edge))
		{
			Children.Add(edge, new HashSet<WallSnap>());
		}
		Children[edge].Add(segment);
		Room room = GetRoom(edge);
		if (room != null)
		{
			room.UpdateFurnitureWallNearness();
		}
	}

	public int FenceCount(WallEdge other, bool oneWay = false)
	{
		int num = 0;
		IRoom iRoom = GetIRoom(other);
		if (iRoom != null)
		{
			num += (iRoom.Outdoors ? 1 : (-1));
		}
		if (oneWay)
		{
			return num;
		}
		iRoom = other.GetIRoom(this);
		if (iRoom != null)
		{
			num += (iRoom.Outdoors ? 1 : (-1));
		}
		return num;
	}

	public int FenceCountBalcony(Room r)
	{
		bool sharedBalcony;
		if (IsBalconyWall(r, out sharedBalcony))
		{
			if (!sharedBalcony)
			{
				return 1;
			}
			return 2;
		}
		return 0;
	}

	public bool IsFence(WallEdge other)
	{
		bool shared;
		if (IsBalconyWall(other, out shared))
		{
			return shared;
		}
		return FenceCount(other) > 0;
	}

	public bool IsPillar(WallEdge other)
	{
		Room room = GetRoom(other);
		if (room != null)
		{
			return room.Pillar;
		}
		return false;
	}

	public bool IsUpperAtriumNotBalcony(WallEdge other)
	{
		Room room = GetRoom(other);
		if (room != null)
		{
			return room.IsUpperAtriumNotBalcony;
		}
		return false;
	}

	public bool IsAgainstOutdoors(WallEdge other)
	{
		foreach (KeyValuePair<IRoom, WallEdge> link in Links)
		{
			if (link.Value == other)
			{
				if (link.Key.Outdoors)
				{
					return true;
				}
				break;
			}
		}
		foreach (KeyValuePair<IRoom, WallEdge> link2 in other.Links)
		{
			if (link2.Value == this)
			{
				if (link2.Key.Outdoors)
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	public bool IsAgainstOutside(WallEdge other)
	{
		foreach (KeyValuePair<IRoom, WallEdge> link in other.Links)
		{
			if (link.Value == this)
			{
				return link.Key.Outdoors;
			}
		}
		return true;
	}

	public bool IsAgainstOutdoorsOutsideAtrium(WallEdge other)
	{
		int num = 0;
		foreach (KeyValuePair<IRoom, WallEdge> link in Links)
		{
			if (link.Value == other)
			{
				num++;
				Room room;
				if (link.Key.Outdoors || ((object)(room = link.Key as Room) != null && room.AtriumParent != null))
				{
					return true;
				}
				break;
			}
		}
		foreach (KeyValuePair<IRoom, WallEdge> link2 in other.Links)
		{
			if (link2.Value == this)
			{
				num++;
				Room room2;
				if (link2.Key.Outdoors || ((object)(room2 = link2.Key as Room) != null && room2.AtriumParent != null))
				{
					return true;
				}
				break;
			}
		}
		return num < 2;
	}

	public void RemoveSegment(WallEdge edge, WallSnap segment)
	{
		if (Children.ContainsKey(edge))
		{
			Children[edge].Remove(segment);
		}
	}

	public bool HasSegments(WallEdge edge)
	{
		HashSet<WallSnap> value;
		if (Children.TryGetValue(edge, out value))
		{
			return value.Count > 0;
		}
		return false;
	}

	public bool HasWindows(WallEdge edge)
	{
		HashSet<WallSnap> value;
		if (Children.TryGetValue(edge, out value))
		{
			foreach (WallSnap item in value)
			{
				RoomSegment roomSegment = item as RoomSegment;
				if (roomSegment != null && roomSegment.LightAddition > 0f)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool WindowBalconyCheck(WallEdge edge, float pos)
	{
		if (!IsBalconyWall(edge))
		{
			return WindowCheck(edge, pos);
		}
		return true;
	}

	public bool WindowCheck(WallEdge edge, float pos)
	{
		HashSet<WallSnap> value;
		if (Children.TryGetValue(edge, out value))
		{
			foreach (WallSnap item in value)
			{
				RoomSegment roomSegment = item as RoomSegment;
				if (roomSegment != null && roomSegment.LightAddition > 0f)
				{
					float num = roomSegment.WallPosition[this];
					float num2 = roomSegment.WallWidth / 2f + 2f;
					float num3 = num + num2;
					num -= num2;
					if (pos >= num && pos <= num3)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool IsReadonly(Room link, Room r2)
	{
		if (r2 != null && (link.AtriumParent != null || r2.AtriumParent != null))
		{
			return !IsBalconyWall(link, r2);
		}
		return link.AtriumParent != null;
	}

	public bool IsReadonly2(Room link, Room r2)
	{
		if (r2 != null)
		{
			if (link.IsUpperAtriumNotBalcony)
			{
				return r2.AtriumParent != link;
			}
			if (r2.IsUpperAtriumNotBalcony)
			{
				return link.AtriumParent != r2;
			}
		}
		return link.IsUpperAtriumNotBalcony;
	}

	public bool IsBalconyWall(Room link)
	{
		WallEdge value;
		if (Links.TryGetValue(link, out value))
		{
			Room room = value.GetRoom(this);
			if (room != null && IsBalconyWall(link, room))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsBalconyWall(WallEdge e)
	{
		Room room = GetRoom(e);
		if (room != null)
		{
			Room room2 = e.GetRoom(this);
			if (room2 != null && IsBalconyWall(room, room2))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsBalconyWall(WallEdge e, out bool shared)
	{
		shared = false;
		Room room = GetRoom(e);
		if (room != null)
		{
			Room room2 = e.GetRoom(this);
			if (room2 != null && IsBalconyWall(room, room2))
			{
				shared = room.AtriumParent == room2.AtriumParent;
				return true;
			}
		}
		return false;
	}

	public bool IsBalconyWall(Room link, Room r2)
	{
		if (!(r2.AtriumParent == link) && !(link.AtriumParent == r2))
		{
			if (link.AtriumParent != null)
			{
				return link.AtriumParent == r2.AtriumParent;
			}
			return false;
		}
		return true;
	}

	public bool IsBalconyWall(Room link, out bool sharedBalcony)
	{
		sharedBalcony = false;
		WallEdge value;
		if (Links.TryGetValue(link, out value))
		{
			Room room = value.GetRoom(this);
			if (room != null && IsBalconyWall(link, room))
			{
				sharedBalcony = link.AtriumParent == room.AtriumParent;
				return true;
			}
		}
		return false;
	}

	public Room GetRoom(WallEdge other)
	{
		foreach (KeyValuePair<IRoom, WallEdge> link in Links)
		{
			if (link.Value == other)
			{
				return link.Key as Room;
			}
		}
		return null;
	}

	public IRoom GetIRoom(WallEdge other)
	{
		foreach (KeyValuePair<IRoom, WallEdge> link in Links)
		{
			if (link.Value == other)
			{
				return link.Key;
			}
		}
		return null;
	}

	public float GetHeight(WallEdge other)
	{
		if (FenceCount(other) > 0)
		{
			bool flag = false;
			float result = 0f;
			Room room = GetRoom(other);
			if (room != null && room.Outdoors)
			{
				result = room.FenceHeight;
				flag = true;
			}
			Room room2 = other.GetRoom(this);
			if (room2 != null && room2.Outdoors && (!flag || room2.DID > room.DID))
			{
				return room2.FenceHeight;
			}
			return result;
		}
		return 2f;
	}

	public void GetAllMeshes(WallEdge other, Vector2 from, float last, bool inside, int floor, Vector2 uv2, MeshCombiner mc)
	{
		HashSet<WallSnap> value;
		if (!Children.TryGetValue(other, out value))
		{
			return;
		}
		foreach (WallSnap item in value)
		{
			if (item != null && item.PunchHole())
			{
				MeshFilter[] wallMeshes = item.GetWallMeshes(inside, this);
				bool flag = (item.FirstEdge == this) ^ inside;
				foreach (MeshFilter meshFilter in wallMeshes)
				{
					mc.AddMesh(meshFilter.sharedMesh, meshFilter.transform.localToWorldMatrix * Matrix4x4.Translate(meshFilter.transform.localRotation * (flag ? Vector3.back : Vector3.forward) * Room.WallOffset * 0.5f), from, last, floor, uv2, flag);
				}
			}
		}
	}

	private Mesh FixMeshUV(Mesh inputMesh, Matrix4x4 transform, Vector2 a, float last, int floor, Vector2 uv2)
	{
		Mesh mesh = new Mesh();
		transform *= Matrix4x4.TRS(new Vector3(0f, -floor * 2, 0f), Quaternion.identity, Vector3.one);
		Vector3[] array = (mesh.vertices = inputMesh.vertices.SelectInPlace((Vector3 x) => transform.MultiplyPoint(x)));
		mesh.triangles = inputMesh.triangles;
		mesh.normals = inputMesh.normals.SelectInPlace((Vector3 x) => transform.MultiplyVector(x).normalized);
		mesh.uv2 = Utilities.RepeatValue(uv2, array.Length);
		mesh.tangents = inputMesh.tangents.SelectInPlace((Vector4 x) => transform.MultiplyVector(x.FlattenVector4()).normalized.ToVector4(1f));
		List<Vector2> list = new List<Vector2>();
		for (int num = 0; num < array.Length; num++)
		{
			Vector3 vector = array[num];
			Vector2 p = new Vector2(vector.x, vector.z);
			float num2 = a.Dist(p) / 2f;
			float y = vector.y / 2f;
			list.Add(new Vector2(last + num2, y));
		}
		mesh.SetUVs(0, list);
		return mesh;
	}

	public float? FirstValidFrom(float pos, WallEdge other)
	{
		HashSet<WallSnap> value;
		if (Children.TryGetValue(other, out value))
		{
			List<float> list = (from x in value
				select x.WallPosition[this] - x.WallWidth / 2f into x
				where x >= pos
				orderby x
				select x).ToList();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
		return null;
	}

	public bool IsNextColinear(WallEdge other, bool reverse, bool outside, out WallEdge next)
	{
		Room room = GetRoom(other);
		Vector2 normalized = (other.Pos - Pos).normalized;
		if (outside)
		{
			if (reverse)
			{
				next = FindAllConnectionIn().FirstOrDefault((WallEdge x) => !Links.ContainsValue(x));
				if (next != null)
				{
					return (Pos - next.Pos).normalized.Approximate(normalized, 0.001f);
				}
				return false;
			}
			next = other.Links.FirstOrDefaultOf((KeyValuePair<IRoom, WallEdge> x) => !x.Value.Links.ContainsValue(other), (KeyValuePair<IRoom, WallEdge> x) => x.Value);
			if (next != null)
			{
				return (next.Pos - other.Pos).normalized.Approximate(normalized, 0.001f);
			}
			return false;
		}
		if (reverse)
		{
			next = FindConnectionIn(room);
			return (Pos - next.Pos).normalized.Approximate(normalized, 0.001f);
		}
		next = other.Links[room];
		return (next.Pos - other.Pos).normalized.Approximate(normalized, 0.001f);
	}

	public WallEdge FindNextColinear(Room r, bool reverse, bool outside)
	{
		WallEdge wallEdge = this;
		WallEdge wallEdge2 = Links[r];
		Vector2 normalized = (wallEdge2.Pos - wallEdge.Pos).normalized;
		while ((wallEdge2.Pos - wallEdge.Pos).normalized.Approximate(normalized, 0.001f))
		{
			if (outside)
			{
				if (reverse)
				{
					wallEdge2 = wallEdge;
					WallEdge e3 = wallEdge;
					wallEdge = wallEdge.FindAllConnectionIn().FirstOrDefault((WallEdge x) => !e3.Links.ContainsValue(x));
					if (wallEdge == null)
					{
						break;
					}
					continue;
				}
				wallEdge = wallEdge2;
				WallEdge e4 = wallEdge2;
				wallEdge2 = wallEdge2.Links.FirstOrDefaultOf((KeyValuePair<IRoom, WallEdge> x) => !x.Value.Links.ContainsValue(e4), (KeyValuePair<IRoom, WallEdge> x) => x.Value);
				if (wallEdge2 == null)
				{
					break;
				}
			}
			else if (reverse)
			{
				wallEdge2 = wallEdge;
				wallEdge = wallEdge.FindConnectionIn(r);
			}
			else
			{
				wallEdge = wallEdge2;
				wallEdge2 = wallEdge2.Links[r];
			}
		}
		if (!reverse)
		{
			return wallEdge;
		}
		return wallEdge2;
	}

	public bool ValidSegment(ref Vector2 pos, ref float height, float width, WallEdge other, bool oneSide, bool connector, bool reverse, bool keepInWall, bool onFence, float h1 = 0f, float h2 = 2f, bool fenceWallExclusive = false, float offx = 0f, float offy = 0f, bool clone = false, WallSnap ignore = null, bool customHeight = false, float minHeight = 0f, float maxHeight = 1f, bool canScooch = true, WallEdge from = null, bool canMoveVertically = true)
	{
		float a = h1 + height;
		float num = h2 + height;
		if (IsPillar(other))
		{
			return false;
		}
		if (!oneSide && other.IsPillar(this))
		{
			return false;
		}
		bool shared;
		if (IsBalconyWall(other, out shared) && !shared)
		{
			return false;
		}
		if (connector && (IsUpperAtriumNotBalcony(other) || other.IsUpperAtriumNotBalcony(this)))
		{
			return false;
		}
		if (!clone)
		{
			bool flag = IsFence(other);
			if (fenceWallExclusive && (flag ^ onFence))
			{
				return false;
			}
			if (flag && !onFence)
			{
				return false;
			}
			if (flag && !fenceWallExclusive)
			{
				maxHeight = GetHeight(other);
				if (maxHeight < num)
				{
					return false;
				}
			}
		}
		WallEdge next;
		WallEdge wallEdge = ((!oneSide) ? null : (IsNextColinear(other, true, reverse, out next) ? next : null));
		WallEdge wallEdge2 = ((!oneSide) ? null : (IsNextColinear(other, false, reverse, out next) ? next : null));
		int num2 = ((Utilities.IsLeft(Pos, Pos + (other.Pos - Pos).Turn90(), pos) <= 0) ? 1 : (-1));
		HashSet<WallSnap> value;
		if (Children.TryGetValue(other, out value))
		{
			float num3 = Pos.Dist(other.Pos);
			float num4 = Pos.Dist(new Vector2(pos.x + offx, pos.y + offy)) * (float)num2;
			Vector2 vector = pos;
			float num5 = Pos.Dist(pos) * (float)num2;
			float num6 = num5 - width / 2f;
			float num7 = num5 + width / 2f;
			float a2 = num6;
			float b = num7;
			float? num8 = null;
			foreach (WallSnap item in value)
			{
				if (item == ignore)
				{
					continue;
				}
				Furniture furniture = item as Furniture;
				float num9 = 0f;
				float num10 = 0f;
				RoomSegment roomSegment;
				if (furniture != null)
				{
					if (furniture.IgnoreBoundary)
					{
						continue;
					}
					if (oneSide && !furniture.PokesThroughWall)
					{
						if (reverse != (furniture.IsReversed ^ furniture.ReverseWallSide))
						{
							if (oneSide && furniture.SecondEdge != this)
							{
								continue;
							}
						}
						else if (oneSide && furniture.FirstEdge != this)
						{
							continue;
						}
					}
					num9 = furniture.OffsetHeight(0);
					num10 = furniture.OffsetHeight(1);
					if (!Utilities.Overlap(a, num, num9, num10))
					{
						continue;
					}
				}
				else if ((object)(roomSegment = item as RoomSegment) != null)
				{
					num9 = roomSegment.Height1;
					num10 = roomSegment.Height2;
					if (!Utilities.Overlap(a, num, num9, num10))
					{
						continue;
					}
				}
				float num11 = item.WallPosition[this];
				float num12 = num11 + item.WallWidth / 2f;
				num11 -= item.WallWidth / 2f;
				if (!Utilities.RelaxedOverlap(num6, num7, num11, num12))
				{
					continue;
				}
				if (customHeight)
				{
					if (height > (num9 + num10) * 0.5f)
					{
						float num13 = (h2 - h1) / 2f;
						float num14 = num10 + num13;
						if (num14 < maxHeight)
						{
							num8 = num14;
						}
						else
						{
							float num15 = num9 - num13;
							if (num15 > minHeight)
							{
								num8 = num15;
							}
						}
					}
					else
					{
						float num16 = (h2 - h1) / 2f;
						float num17 = num9 - num16;
						if (num17 > minHeight)
						{
							num8 = num17;
						}
						else
						{
							float num18 = num10 + num16;
							if (num18 < maxHeight)
							{
								num8 = num18;
							}
						}
					}
				}
				if (!canScooch)
				{
					return false;
				}
				if ((num11 + num12) / 2f > num4)
				{
					vector = Pos + (other.Pos - Pos).normalized * (num11 - width / 2f);
					num6 = num11 - width;
					num7 = num11;
				}
				else
				{
					vector = Pos + (other.Pos - Pos).normalized * (num12 + width / 2f);
					num6 = num12;
					num7 = num12 + width;
				}
				float num19 = ((keepInWall && !reverse) ? (Room.WallOffset / 2f) : (-0.0001f));
				float num20 = ((keepInWall && !reverse) ? (num3 - Room.WallOffset / 2f) : num3);
				if ((wallEdge == null && num6 < num19) || (wallEdge2 == null && num7 > num20))
				{
					return false;
				}
				break;
			}
			bool flag2 = true;
			foreach (WallSnap item2 in value)
			{
				if (item2 == ignore)
				{
					continue;
				}
				float num21 = 0f;
				float num22 = 0f;
				float num23 = item2.WallPosition[this];
				float d = num23 + item2.WallWidth / 2f;
				num23 -= item2.WallWidth / 2f;
				Furniture furniture2 = item2 as Furniture;
				RoomSegment roomSegment2;
				if (furniture2 != null)
				{
					if (furniture2.IgnoreBoundary)
					{
						continue;
					}
					if (oneSide && !furniture2.PokesThroughWall)
					{
						if (reverse != (furniture2.IsReversed ^ furniture2.ReverseWallSide))
						{
							if (oneSide && furniture2.SecondEdge != this)
							{
								continue;
							}
						}
						else if (oneSide && furniture2.FirstEdge != this)
						{
							continue;
						}
					}
					num21 = furniture2.OffsetHeight(0);
					num22 = furniture2.OffsetHeight(1);
					if (num8.HasValue && Utilities.Overlap(num8.Value + h1, num8.Value + h2, num21, num22) && Utilities.RelaxedOverlap(a2, b, num23, d))
					{
						num8 = null;
					}
					if (!Utilities.Overlap(a, num, num21, num22))
					{
						continue;
					}
				}
				else if ((object)(roomSegment2 = item2 as RoomSegment) != null)
				{
					num21 = roomSegment2.Height1;
					num22 = roomSegment2.Height2;
					if (num8.HasValue && Utilities.Overlap(num8.Value + h1, num8.Value + h2, num21, num22) && Utilities.RelaxedOverlap(a2, b, num23, d))
					{
						num8 = null;
					}
					if (!Utilities.Overlap(a, num, num21, num22))
					{
						continue;
					}
				}
				if (Utilities.RelaxedOverlap(num6, num7, num23, d))
				{
					if (!num8.HasValue)
					{
						return false;
					}
					flag2 = false;
				}
			}
			if (canMoveVertically && num8.HasValue)
			{
				height = num8.Value;
			}
			else
			{
				if (!flag2)
				{
					return false;
				}
				pos = vector;
			}
		}
		float num24 = Pos.Dist(pos) * (float)num2;
		if (num24 - width < -0.0001f)
		{
			if (wallEdge != null)
			{
				if (wallEdge != from && !wallEdge.ValidSegment(ref pos, ref height, width, this, oneSide, connector, reverse, keepInWall, onFence, h1, h2, fenceWallExclusive, offx, offy, clone, ignore, customHeight, minHeight, maxHeight, canScooch, other, false))
				{
					return false;
				}
			}
			else if (num24 - width / 2f < -0.0001f)
			{
				return false;
			}
		}
		float num25 = Pos.Dist(other.Pos) + 0.0001f;
		if (num24 + width > num25)
		{
			if (wallEdge2 != null)
			{
				if (wallEdge2 != from && !other.ValidSegment(ref pos, ref height, width, wallEdge2, oneSide, connector, reverse, keepInWall, onFence, h1, h2, fenceWallExclusive, offx, offy, clone, ignore, customHeight, minHeight, maxHeight, canScooch, this, false))
				{
					return false;
				}
			}
			else if (num24 + width / 2f > num25)
			{
				return false;
			}
		}
		return true;
	}

	public List<Vector2> GetSplit(WallEdge other)
	{
		HashSet<WallSnap> value;
		if (Children.TryGetValue(other, out value))
		{
			_splitCache.Clear();
			float num = Pos.Dist(other.Pos);
			foreach (WallSnap item in from x in value
				where x != null && x.PunchHole()
				orderby x.WallPosition[this]
				select x)
			{
				float num2 = item.WallPosition[this];
				float num3 = num2 + item.WallWidth / 2f;
				float num4 = (num2 - item.WallWidth / 2f) / num;
				float num5 = num3 / num;
				if (_splitCache.Count > 0)
				{
					Vector2 vector = _splitCache[_splitCache.Count - 1];
					if (Mathf.Approximately(vector.x, num4) || num4 < vector.x)
					{
						if (num5 > vector.x)
						{
							_splitCache.RemoveAt(_splitCache.Count - 1);
							_splitCache.Add(new Vector2(item.IsMerge(other) ? 2f : num5, 0f));
						}
					}
					else
					{
						_splitCache.Add(new Vector2(num4, 0f));
						_splitCache.Add(new Vector2(item.IsMerge(other) ? 2f : num5, 0f));
					}
				}
				else
				{
					_splitCache.Add(new Vector2(item.IsMerge(this) ? (-1f) : num4, 0f));
					_splitCache.Add(new Vector2(item.IsMerge(other) ? 2f : num5, 0f));
				}
			}
			Vector2 vector2 = other.Pos - Pos;
			for (int num6 = 0; num6 < _splitCache.Count; num6++)
			{
				_splitCache[num6] = Pos + vector2 * _splitCache[num6].x;
			}
			return _splitCache;
		}
		return null;
	}

	public WallEdge(Vector2 p, int floor)
	{
		Pos = p;
		Floor = floor;
	}

	public void SetSplit(WallEdge split, Room link)
	{
		TempCutOff = split;
		CutOffLink = link;
		otherCutoff = TempCutOff.Links[CutOffLink];
		otherLink = otherCutoff.GetRoom(TempCutOff);
	}

	public void ResetSplit()
	{
		TempCutOff = null;
		CutOffLink = null;
		otherCutoff = null;
		otherLink = null;
	}

	public WallEdge FindConnectionIn(IRoom r)
	{
		for (int i = 0; i < r.Edges.Count; i++)
		{
			WallEdge value;
			if (r.Edges[i].Links.TryGetValue(r, out value) && value == this)
			{
				return r.Edges[i];
			}
		}
		return null;
	}

	public IEnumerable<WallEdge> FindAllConnectionIn()
	{
		return Links.Keys.Select(FindConnectionIn);
	}

	public void SplitSegment(List<UndoObject.UndoAction> undos)
	{
		if (TempCutOff == null)
		{
			return;
		}
		Dictionary<WallSnap, UndoObject.UndoAction> dictionary = TempCutOff.Children.GetOrDefault(otherCutoff, new HashSet<WallSnap>()).ToDictionary((WallSnap x) => x, (WallSnap x) =>
		{
			Furniture furniture3;
			return (undos != null) ? new UndoObject.UndoAction(x, false, (object)(furniture3 = x as Furniture) != null && furniture3.PreferInventory) : null;
		});
		TempCutOff.Links[CutOffLink] = this;
		Links[CutOffLink] = otherCutoff;
		if (otherLink != null)
		{
			otherCutoff.Links[otherLink] = this;
			Links[otherLink] = TempCutOff;
			int num = otherLink.Edges.IndexOf(otherCutoff);
			otherLink.Edges.Insert(num + 1, this);
		}
		int num2 = CutOffLink.Edges.IndexOf(TempCutOff);
		CutOffLink.Edges.Insert(num2 + 1, this);
		foreach (KeyValuePair<WallSnap, UndoObject.UndoAction> item in dictionary)
		{
			if (!item.Key.IsAliveNotNull())
			{
				continue;
			}
			WallSnap key = item.Key;
			WallEdge firstEdge = key.FirstEdge;
			WallEdge wallEdge = ((firstEdge == TempCutOff) ? otherCutoff : TempCutOff);
			float num3 = firstEdge.Pos.Dist(Pos);
			float num4 = key.WallPosition[firstEdge];
			float num5 = num4 - key.WallWidth / 2f;
			float num6 = num4 + key.WallWidth / 2f;
			RoomSegment roomSegment;
			if ((object)(roomSegment = key as RoomSegment) != null)
			{
				if ((num5 < num3 && num6 > num3) || (num5 > num3 && num6 < num3))
				{
					CutOffLink.DirtyInnerMesh = true;
					if (otherLink != null)
					{
						otherLink.DirtyInnerMesh = true;
					}
					if (roomSegment.IsConnector)
					{
						CutOffLink.DirtyPathNodes = true;
						if (otherLink != null)
						{
							otherLink.DirtyPathNodes = true;
						}
					}
					if (item.Value != null && undos != null)
					{
						undos.Add(item.Value);
					}
					roomSegment.DestroyGO();
					continue;
				}
			}
			else
			{
				Furniture furniture;
				if ((object)(furniture = key as Furniture) != null && !furniture.PokesThroughWall)
				{
					if (num4 > num3)
					{
						furniture.Init(this, wallEdge, (num4 - num3) / Pos.Dist(wallEdge.Pos));
					}
					else
					{
						furniture.Init(firstEdge, this, num4 / num3);
					}
					continue;
				}
				if (Utilities.Overlap(num5, num6, num3 - Room.WallOffset / 2f, num3 + Room.WallOffset / 2f))
				{
					if (item.Value != null && undos != null)
					{
						undos.Add(item.Value);
					}
					Furniture furniture2;
					if ((object)(furniture2 = key as Furniture) != null)
					{
						if (furniture2.PreferInventory)
						{
							GameSettings.AddToInventory(furniture2);
							furniture2.Undo = true;
						}
						foreach (Furniture item2 in furniture2.IterateSnap())
						{
							if (item2.PreferInventory)
							{
								GameSettings.AddToInventory(item2);
								item2.Undo = true;
							}
							List<UndoObject.UndoAction> list = undos;
							if (list != null)
							{
								list.Add(new UndoObject.UndoAction(item2, false, item2.PreferInventory));
							}
						}
					}
					key.DestroyGO();
					continue;
				}
			}
			if (num4 < num3)
			{
				key.Init(firstEdge, this, num4 / num3);
			}
			else
			{
				key.Init(this, wallEdge, (num4 - num3) / Pos.Dist(wallEdge.Pos));
			}
		}
		Links.Keys.OfType<Room>().ForEachEnum(delegate(Room x)
		{
			x.QueueEdgeNetworkUpdate();
		});
		TempCutOff = null;
		CutOffLink = null;
	}

	public bool CouldSplit(Room r)
	{
		if (r != null && !r.Pillar)
		{
			if (!(CutOffLink == r) && !(otherLink == r))
			{
				return Links.ContainsKey(r);
			}
			return true;
		}
		return false;
	}

	public bool IsSplitting(Room r)
	{
		if (TempCutOff == null || !TempCutOff.Links.ContainsKey(r))
		{
			if (otherCutoff != null)
			{
				return otherCutoff.Links.ContainsKey(r);
			}
			return false;
		}
		return true;
	}

	public bool UpAgainst(WallEdge s)
	{
		if (!Links.ContainsValue(s))
		{
			if (TempCutOff != null)
			{
				if (TempCutOff != s && otherCutoff != s)
				{
					if (TempCutOff == s.TempCutOff)
					{
						return otherCutoff == s.otherCutoff;
					}
					return false;
				}
				return true;
			}
			return false;
		}
		return true;
	}

	public bool CanIntersect(WallEdge a, WallEdge b)
	{
		if (a == TempCutOff || b == TempCutOff)
		{
			if (a != otherCutoff)
			{
				return b == otherCutoff;
			}
			return true;
		}
		return false;
	}

	public bool GetRelevantRooms(HashSet<Room> rooms)
	{
		if (rooms.Count == 0)
		{
			if (IsSplitter)
			{
				rooms.Add(CutOffLink);
				if (otherLink != null)
				{
					rooms.Add(otherLink);
				}
			}
			else if (Links.Count > 0)
			{
				rooms.AddRange(Links.Keys.OfType<Room>());
			}
			else
			{
				Room roomFromPoint = GameSettings.Instance.sRoomManager.GetRoomFromPoint(Floor, Pos);
				if (roomFromPoint == null || roomFromPoint.Outside)
				{
					return false;
				}
				rooms.Add(roomFromPoint);
			}
			return true;
		}
		if (IsSplitter)
		{
			bool flag = rooms.Contains(CutOffLink);
			bool flag2 = otherLink != null && rooms.Contains(otherLink);
			if (flag || flag2)
			{
				rooms.Clear();
				if (flag)
				{
					rooms.Add(CutOffLink);
				}
				if (flag2)
				{
					rooms.Add(otherLink);
				}
				return true;
			}
			return false;
		}
		if (Links.Count > 0)
		{
			if (rooms.Count == 1)
			{
				return Links.ContainsKey(rooms.First());
			}
			List<Room> list = rooms.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Room room = list[i];
				if (!Links.ContainsKey(room))
				{
					rooms.Remove(room);
				}
			}
			return rooms.Count > 0;
		}
		Room roomFromPoint2 = GameSettings.Instance.sRoomManager.GetRoomFromPoint(Floor, Pos);
		if (roomFromPoint2 == null || roomFromPoint2.Outside || !rooms.Contains(roomFromPoint2))
		{
			return false;
		}
		rooms.Clear();
		rooms.Add(roomFromPoint2);
		return true;
	}

	public override string ToString()
	{
		return Pos.ToString();
	}
}
