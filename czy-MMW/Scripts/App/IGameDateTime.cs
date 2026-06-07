using System;

public interface IGameDateTime
{
	DateTime LocalNow { get; }

	DateTime LocalToday { get; }

	DateTime UtcNow { get; }

	DateTime UtcToday { get; }
}
