using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.StorageUniversal;

namespace NSMedieval
{
	public interface IStorageGoap
	{
		List<UniversalStorage> AllStorage { get; }

		ZonePriority Priority { get; }
	}
}
