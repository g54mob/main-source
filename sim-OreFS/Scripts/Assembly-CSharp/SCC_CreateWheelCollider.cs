using UnityEngine;

public class SCC_CreateWheelCollider
{
	public static WheelCollider CreateWheelCollider(GameObject car, Transform wheel)
	{
		if (!wheel)
		{
			Debug.LogError("You haven't selected your Wheel Model. Please your Wheel Model before creating Wheel Colliders. Script needs to know their sizes and positions, aye?");
			return null;
		}
		Quaternion rotation = car.transform.rotation;
		car.transform.rotation = Quaternion.identity;
		GameObject gameObject;
		if (!car.transform.Find("Wheel Colliders"))
		{
			gameObject = new GameObject("Wheel Colliders");
			gameObject.transform.SetParent(car.transform, worldPositionStays: false);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
		}
		else
		{
			gameObject = car.transform.Find("Wheel Colliders").gameObject;
		}
		GameObject gameObject2 = new GameObject(wheel.transform.name);
		gameObject2.transform.position = wheel.transform.position;
		gameObject2.transform.rotation = car.transform.rotation;
		gameObject2.transform.name = wheel.transform.name;
		gameObject2.transform.SetParent(gameObject.transform);
		gameObject2.transform.localScale = Vector3.one;
		gameObject2.AddComponent<WheelCollider>();
		Bounds bounds = default(Bounds);
		Renderer[] componentsInChildren = wheel.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer.bounds.size.z > bounds.size.z)
			{
				bounds = renderer.bounds;
			}
		}
		gameObject2.GetComponent<WheelCollider>().radius = bounds.extents.y / car.transform.localScale.y;
		gameObject2.AddComponent<SCC_Wheel>();
		JointSpring suspensionSpring = gameObject2.GetComponent<WheelCollider>().suspensionSpring;
		suspensionSpring.spring = 35000f;
		suspensionSpring.damper = 1500f;
		suspensionSpring.targetPosition = 0.5f;
		gameObject2.GetComponent<WheelCollider>().suspensionSpring = suspensionSpring;
		gameObject2.GetComponent<WheelCollider>().suspensionDistance = 0.2f;
		gameObject2.GetComponent<WheelCollider>().forceAppPointDistance = 0.1f;
		gameObject2.GetComponent<WheelCollider>().mass = 40f;
		gameObject2.GetComponent<WheelCollider>().wheelDampingRate = 1f;
		WheelFrictionCurve sidewaysFriction = gameObject2.GetComponent<WheelCollider>().sidewaysFriction;
		WheelFrictionCurve forwardFriction = gameObject2.GetComponent<WheelCollider>().forwardFriction;
		forwardFriction.extremumSlip = 0.3f;
		forwardFriction.extremumValue = 1f;
		forwardFriction.asymptoteSlip = 1f;
		forwardFriction.asymptoteValue = 1f;
		forwardFriction.stiffness = 1.5f;
		sidewaysFriction.extremumSlip = 0.3f;
		sidewaysFriction.extremumValue = 1f;
		sidewaysFriction.asymptoteSlip = 1f;
		sidewaysFriction.asymptoteValue = 1f;
		sidewaysFriction.stiffness = 1.5f;
		gameObject2.GetComponent<WheelCollider>().sidewaysFriction = sidewaysFriction;
		gameObject2.GetComponent<WheelCollider>().forwardFriction = forwardFriction;
		car.transform.rotation = rotation;
		return gameObject2.GetComponent<WheelCollider>();
	}
}
