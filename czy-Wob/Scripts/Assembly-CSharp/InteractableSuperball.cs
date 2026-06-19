using UnityEngine;

public class InteractableSuperball : InteractableBase
{
	private Superball superballRef;

	private void Awake()
	{
		superballRef = GetComponentInChildren<Superball>();
	}

	public override void OnRegisteredComponentsAdded()
	{
		Object.Destroy(GetComponentInChildren<Unbouncable>());
	}

	public override void OnObjectGrabbedByPlayer()
	{
		base.OnObjectGrabbedByPlayer();
		superballRef.StopBounce();
	}

	public override void OnObjectThrownByPlayer()
	{
		superballRef.InitiateBounce();
	}

	public override void OnObjectGrabbedByDog(GameObject dog)
	{
		base.OnObjectGrabbedByDog(dog);
		superballRef.StopBounce();
	}

	public override void OnObjectThrownByDog(GameObject dog)
	{
		superballRef.InitiateBounce();
		superballRef.ApplyThrowMultiplier();
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		superballRef.ApplyBiteMultiplier(biteVector);
	}
}
