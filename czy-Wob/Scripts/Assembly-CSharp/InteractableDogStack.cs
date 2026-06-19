using System.Collections.Generic;
using UnityEngine;

public class InteractableDogStack : InteractableBase
{
	public List<Rigidbody> headList;

	public Transform interactionPointTransform;

	public Collider topHead;

	public Collider topEars;

	public Collider topCircle;

	private float spinTorque = 3000f;

	private float spinRequestAdd = 1f;

	private float currentSpinTimer;

	private void OnEnable()
	{
		Physics.IgnoreCollision(topHead, topCircle);
		Physics.IgnoreCollision(topEars, topCircle);
	}

	private void FixedUpdate()
	{
		ApplySpinTorque();
	}

	public override Vector3 GetInteractionPoint()
	{
		return interactionPointTransform.position;
	}

	public override Transform GetInteractionPointTransform()
	{
		return interactionPointTransform;
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		Spin();
	}

	public void Spin()
	{
		currentSpinTimer += spinRequestAdd;
	}

	private void ApplySpinTorque()
	{
		if (currentSpinTimer <= 0f)
		{
			currentSpinTimer = 0f;
			return;
		}
		for (int i = 0; i < headList.Count; i++)
		{
			headList[i].maxAngularVelocity = 10000f;
			headList[i].AddTorque(Vector3.up * spinTorque, ForceMode.Force);
		}
		currentSpinTimer -= Time.fixedDeltaTime;
	}
}
