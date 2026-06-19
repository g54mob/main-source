using UnityEngine;

public class InteractableTree : InteractablePlant
{
	private float shakeForce = 500f;

	protected override void OnAttackedByDog(GameObject dog)
	{
		base.OnAttackedByDog(dog);
		Shake();
	}

	private void Shake()
	{
		Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			if (!rigidbody.isKinematic)
			{
				rigidbody.AddForce(new Vector3(Random.Range(0f - shakeForce, shakeForce), Random.Range(0f - shakeForce, shakeForce), Random.Range(0f - shakeForce, shakeForce)));
			}
		}
	}

	public override Rigidbody GetGrabbedBody(GameObject clickedBody)
	{
		if (controllerRef != null && controllerRef.finalPlant.activeSelf)
		{
			return controllerRef.finalPlant.GetComponentInChildren<Rigidbody>();
		}
		return clickedBody.GetComponent<Rigidbody>();
	}
}
