using System;

public struct LogEntry : IEquatable<LogEntry>
{
	public readonly int level;

	public readonly int townIndex;

	public readonly EntityId id;

	public readonly int logIndex;

	private static int cumulativeIndex;

	public LogEntry(EntityId entity, int entityLevel, int townIndex)
	{
		id = entity.GetCopy();
		level = entityLevel;
		this.townIndex = townIndex;
		logIndex = cumulativeIndex;
		cumulativeIndex++;
	}

	public override bool Equals(object other)
	{
		if (other is LogEntry other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public bool Equals(LogEntry other)
	{
		return logIndex == other.logIndex;
	}

	public override int GetHashCode()
	{
		return logIndex;
	}
}
