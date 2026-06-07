using UnityEngine;

public class CouplingHoseDisconnectButtonPositioner : MonoBehaviour
{
	public Transform connectorA;

	public Transform connectorB;

	private void LateUpdate()
	{
		base.transform.position = (connectorA.position + connectorB.position) / 2f;
	}
}
