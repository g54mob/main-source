using UnityEngine;

public interface ICustomerHelperControllable
{
	GameObject gameObject { get; }

	Vector3 ControlPosition { get; }

	Vector3 StandingPosition { get; }

	Quaternion StandingRotation { get; }

	CustomerHelper ControlledBy { get; set; }

	CustomerHelper Standing { get; set; }
}
