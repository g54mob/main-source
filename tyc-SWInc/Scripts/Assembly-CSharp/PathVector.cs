using System;
using AltSerialize;
using UnityEngine;

[Serializable]
public struct PathVector : IAltSerializable
{
	public enum PathType
	{
		None = 0,
		Outside = 1,
		Stairs = 2,
		Elevator = 3,
		Door = 4,
		Portal = 5,
		Furniture = 6,
		Path = 7
	}

	public float x;

	public float y;

	public float z;

	public PathType Type;

	public uint ObjectID;

	[NonSerialized]
	public Writeable Object;

	public float magnitude
	{
		get
		{
			return Mathf.Sqrt(x * x + y * y * y + z * z);
		}
	}

	public Vector3 normalized
	{
		get
		{
			return this / magnitude;
		}
	}

	public bool CanCache
	{
		get
		{
			return false;
		}
	}

	public T GetObject<T>() where T : Writeable
	{
		if (Type == PathType.None || ObjectID == 0)
		{
			return null;
		}
		if (Object == null)
		{
			Object = Writeable.STGetDeserializedObject(ObjectID) as T;
			if (Object == null)
			{
				ObjectID = 0u;
			}
		}
		return (T)Object;
	}

	public float GetSpeed(Vector3 p)
	{
		switch (Type)
		{
		case PathType.Outside:
		{
			if (RoadManager.Instance.GetRoad(p.FlattenVector3(), Mathf.FloorToInt((p.y + 0.1f) / 2f)) > 0)
			{
				return 0f;
			}
			float num = 1f;
			if (p.y < 0.01f)
			{
				num = GameSettings.Instance.GetTrotAmount(p.FlattenVector3()).MapRange(0.5f, 1f, 1f, 0f, true);
			}
			return -0.25f * num;
		}
		case PathType.Stairs:
			return -0.5f;
		case PathType.Portal:
			return float.PositiveInfinity;
		default:
			return 0f;
		}
	}

	public float GetSpeed(Vector2 p)
	{
		return GetSpeed(p.ToVector3(0f));
	}

	public PathVector(float x, float y, float z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		Type = PathType.None;
		ObjectID = 0u;
		Object = null;
	}

	public PathVector(Vector2 p, int floor)
	{
		x = p.x;
		y = floor * 2;
		z = p.y;
		Type = PathType.None;
		ObjectID = 0u;
		Object = null;
	}

	public PathVector(float x, float y, float z, PathType type, Writeable obj)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		Type = type;
		ObjectID = ((obj != null) ? obj.DID : 0u);
		Object = obj;
	}

	public PathVector(float x, float y, float z, PathType type, uint obj)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		Type = type;
		ObjectID = obj;
		Object = null;
	}

	public PathVector(float x, float y, float z, PathType type)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		Type = type;
		ObjectID = 0u;
		Object = null;
	}

	public PathVector(Vector3 p)
		: this(p.x, p.y, p.z)
	{
	}

	public PathVector(Vector3 p, object o)
		: this(p.x, p.y, p.z, o)
	{
	}

	public PathVector(Vector3 p, Writeable o)
		: this(p.x, p.y, p.z, o)
	{
	}

	public PathVector(Vector3 p, Writeable o, PathType type)
		: this(p.x, p.y, p.z, type, o)
	{
	}

	public PathVector(Vector3 p, PathType type)
		: this(p.x, p.y, p.z, type)
	{
	}

	public PathVector MostInteresting(PathVector other)
	{
		if (Type == PathType.None)
		{
			return other;
		}
		return this;
	}

	public PathVector(float x, float y, float z, object o)
	{
		this.x = x;
		this.y = y;
		this.z = z;
		Type = PathType.None;
		Object = null;
		ObjectID = 0u;
		Writeable writeable;
		if ((object)(writeable = o as Writeable) != null)
		{
			Type = GetFromObject(writeable);
			if (Type != PathType.None)
			{
				Object = writeable;
				ObjectID = writeable.DID;
			}
		}
	}

	public PathVector SetType(PathType type)
	{
		return new PathVector(x, y, z, type, null);
	}

	public static PathType GetFromObject(object obj)
	{
		Writeable w;
		if ((object)(w = obj as Writeable) != null)
		{
			return GetFromObject(w);
		}
		return PathType.None;
	}

	public static PathType GetFromObject(Writeable w)
	{
		if ((object)w != null)
		{
			Furniture furniture;
			if ((object)(furniture = w as Furniture) != null)
			{
				switch (furniture.Type)
				{
				case "Elevator":
					return PathType.Elevator;
				case "Portal":
					return PathType.Portal;
				case "Stairs":
					return PathType.Stairs;
				default:
					return PathType.Furniture;
				}
			}
			Room room;
			if ((object)(room = w as Room) == null)
			{
				RoomSegment roomSegment;
				if ((object)(roomSegment = w as RoomSegment) != null)
				{
					return PathType.Door;
				}
				PathObject pathObject;
				if ((object)(pathObject = w as PathObject) != null)
				{
					return PathType.Path;
				}
			}
			else if (room.Outside)
			{
				return PathType.Outside;
			}
		}
		return PathType.None;
	}

	public PathVector SetObject(object obj)
	{
		Writeable writeable;
		if ((object)(writeable = obj as Writeable) != null)
		{
			PathType fromObject = GetFromObject(writeable);
			if (fromObject == PathType.None)
			{
				return new PathVector(x, y, z);
			}
			return new PathVector(x, y, z, fromObject, writeable);
		}
		return new PathVector(x, y, z);
	}

	public PathVector SetObject(Writeable obj)
	{
		PathType fromObject = GetFromObject(obj);
		if (fromObject == PathType.None)
		{
			return new PathVector(x, y, z);
		}
		return new PathVector(x, y, z, fromObject, obj);
	}

	public PathVector SetObject(Writeable obj, PathType type)
	{
		return new PathVector(x, y, z, type, obj);
	}

	public void Serialize(AltSerializer serializer, int depth)
	{
		serializer.Serialize(x, depth);
		serializer.Serialize(y, depth);
		serializer.Serialize(z, depth);
		serializer.Serialize((byte)Type, depth);
		if (Type != PathType.None)
		{
			serializer.Serialize(ObjectID, depth);
		}
	}

	public IAltSerializable Deserialize(AltSerializer deserializer)
	{
		float num = (float)deserializer.Deserialize(typeof(float), 0);
		float num2 = (float)deserializer.Deserialize(typeof(float), 0);
		float num3 = (float)deserializer.Deserialize(typeof(float), 0);
		PathType pathType = (PathType)(byte)deserializer.Deserialize(typeof(byte), 0);
		uint obj = 0u;
		if (pathType != PathType.None)
		{
			obj = (uint)deserializer.Deserialize(typeof(uint), 0);
		}
		return new PathVector(num, num2, num3, pathType, obj);
	}

	public void OpenDoors()
	{
		RoomSegment roomSegment = GetObject<RoomSegment>();
		if (roomSegment != null)
		{
			PathVector p = this;
			roomSegment.Hinges.ForEachEnum(delegate(DoorScript x)
			{
				x.DoorCollision(x.IsInFront(p));
			});
		}
	}

	public static implicit operator Vector3(PathVector v)
	{
		return new Vector3(v.x, v.y, v.z);
	}

	public static implicit operator PathVector(Vector3 v)
	{
		return new PathVector(v.x, v.y, v.z);
	}

	public static implicit operator SVector3(PathVector v)
	{
		return new SVector3(v.x, v.y, v.z);
	}

	public static implicit operator PathVector(SVector3 v)
	{
		return new PathVector(v.x, v.y, v.z);
	}

	public static Vector3 operator *(PathVector v, float m)
	{
		return new Vector3(v.x * m, v.y * m, v.z * m);
	}

	public static Vector3 operator /(PathVector v, float m)
	{
		return new Vector3(v.x / m, v.y / m, v.z / m);
	}

	public static Vector3 operator +(PathVector v, PathVector v2)
	{
		return new Vector3(v.x + v2.x, v.y + v2.y, v.z + v2.z);
	}

	public static Vector3 operator +(PathVector v, Vector3 v2)
	{
		return new Vector3(v.x + v2.x, v.y + v2.y, v.z + v2.z);
	}

	public static Vector3 operator +(Vector3 v, PathVector v2)
	{
		return new Vector3(v.x + v2.x, v.y + v2.y, v.z + v2.z);
	}

	public static Vector3 operator -(PathVector v, PathVector v2)
	{
		return new Vector3(v.x - v2.x, v.y - v2.y, v.z - v2.z);
	}

	public static Vector3 operator -(PathVector v, Vector3 v2)
	{
		return new Vector3(v.x - v2.x, v.y - v2.y, v.z - v2.z);
	}

	public static Vector3 operator -(Vector3 v, PathVector v2)
	{
		return new Vector3(v.x - v2.x, v.y - v2.y, v.z - v2.z);
	}

	public Vector2 Flatten()
	{
		return new Vector2(x, z);
	}

	public bool Approximate(PathVector v2)
	{
		if (Mathf.Approximately(x, v2.x) && Mathf.Approximately(y, v2.y))
		{
			return Mathf.Approximately(z, v2.z);
		}
		return false;
	}

	public override string ToString()
	{
		if (Type == PathType.None)
		{
			return "{ " + x.ToString("0.##") + ", " + y.ToString("0.##") + ", " + z.ToString("0.##") + " }";
		}
		return string.Concat(Type, ": { ", x.ToString("0.##"), ", ", y.ToString("0.##"), ", ", z.ToString("0.##"), " }");
	}
}
