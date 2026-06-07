using System;
using AltSerialize;

[Serializable]
public class NetworkedID<T> : IAltSerializable where T : struct
{
	private T id;

	[NonSerialized]
	public T? TempID;

	public T ID
	{
		get
		{
			return id;
		}
		set
		{
			id = value;
			TempID = null;
		}
	}

	public T RealID
	{
		get
		{
			return TempID ?? id;
		}
	}

	public bool CanCache
	{
		get
		{
			return false;
		}
	}

	public NetworkedID()
	{
	}

	public NetworkedID(T id)
	{
		this.id = id;
	}

	public static implicit operator T(NetworkedID<T> c)
	{
		return c.id;
	}

	public static implicit operator NetworkedID<T>(T c)
	{
		return new NetworkedID<T>(c);
	}

	protected bool Equals(NetworkedID<T> other)
	{
		return id.Equals(other.id);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj is T)
		{
			return id.Equals(obj);
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((NetworkedID<T>)obj);
	}

	public override int GetHashCode()
	{
		return id.GetHashCode();
	}

	public void Serialize(AltSerializer serializer, int depth)
	{
		serializer.Serialize(id, depth);
	}

	public IAltSerializable Deserialize(AltSerializer deserializer)
	{
		id = (T)deserializer.Deserialize(typeof(T), -1);
		return this;
	}

	public override string ToString()
	{
		if (TempID.HasValue)
		{
			return string.Concat(id, " (", TempID.Value, ")");
		}
		return id.ToString();
	}
}
