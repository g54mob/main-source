using System.Collections.Generic;
using UnityEngine;

public interface IElectricConductor
{
	List<Vector3Int> GetElectricConnectPositions();
}
