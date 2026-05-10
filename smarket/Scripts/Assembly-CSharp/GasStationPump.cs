using System.Collections.Generic;
using UnityEngine;

public class GasStationPump : MonoBehaviour
{
	private const string GasStationTag = "GasStation";

	[SerializeField]
	private List<BoxCollider> m_PumpAreas;

	public bool IsPumpPointAvailable(out Vector3 p)
	{
		p = default(Vector3);
		return false;
	}
}
