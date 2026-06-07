using System;

public readonly struct EntityLevel : IEquatable<EntityLevel>
{
	public readonly EntityId entityId;

	public readonly int level;

	public static EntityLevel None => new EntityLevel(EntityId.None, 0);

	public EntityLevel(EntityId id, int lvl)
	{
		entityId = id;
		level = lvl;
	}

	public EntityLevel GetCopy()
	{
		return new EntityLevel(entityId, level);
	}

	public override bool Equals(object other)
	{
		if (other is EntityLevel other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public bool Equals(EntityLevel other)
	{
		if (other.entityId.Equals(entityId))
		{
			return other.level == level;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return entityId.GetHashCode() + level * 100000;
	}

	public override string ToString()
	{
		return entityId.ToString() + " " + level;
	}
}
