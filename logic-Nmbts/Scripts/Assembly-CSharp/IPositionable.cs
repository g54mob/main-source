using System.Collections.Generic;
using UnityEngine;

public interface IPositionable
{
	bool UpdateInRealtime { get; }

	int TotalCount { get; }

	List<Vector3> GetPositions();

	Vector3 GetPosition(int i);

	void ApplyPositioning();
}
