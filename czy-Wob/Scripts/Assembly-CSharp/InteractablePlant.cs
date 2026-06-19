using UnityEngine;

public class InteractablePlant : InteractableBase
{
	protected PlantController controllerRef;

	private void Awake()
	{
		controllerRef = GetComponent<PlantController>();
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		OnAttackedByDog(dog);
	}

	public override void OnObjectGrabbedByDog(GameObject dog)
	{
		base.OnObjectGrabbedByDog(dog);
		OnAttackedByDog(dog);
	}

	public override void OnObjectThrownByDog(GameObject dog)
	{
		base.OnObjectThrownByDog(dog);
		OnAttackedByDog(dog);
	}

	protected virtual void OnAttackedByDog(GameObject dog)
	{
		controllerRef.OnAttackedByDog();
	}
}
