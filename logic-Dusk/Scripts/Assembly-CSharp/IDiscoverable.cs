using System;

public interface IDiscoverable
{
	DateTime timeExpires { get; }

	bool hasBeenDiscovered { get; }

	bool hasBlinkedOnSchematic { get; }
}
