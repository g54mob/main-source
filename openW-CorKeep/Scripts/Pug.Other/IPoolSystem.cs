using UnityEngine;

public interface IPoolSystem
{
	string Name { get; }

	int PeakUse { get; }

	int AllocatedCount { get; }

	void Free(GameObject gameObject);

	bool IsFree(GameObject gameObject);
}
