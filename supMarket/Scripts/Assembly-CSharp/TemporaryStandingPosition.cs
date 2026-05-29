using UnityEngine;

public class TemporaryStandingPosition : MonoBehaviour, ICustomerHelperControllable
{
	public Vector3 ControlPosition => default(Vector3);

	public Vector3 StandingPosition => default(Vector3);

	public Quaternion StandingRotation => default(Quaternion);

	public CustomerHelper ControlledBy { get; set; }

	public CustomerHelper Standing { get; set; }

	GameObject ICustomerHelperControllable.gameObject => null;
}
