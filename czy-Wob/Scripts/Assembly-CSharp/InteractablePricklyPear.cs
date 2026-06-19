using UnityEngine;

public class InteractablePricklyPear : InteractableBase
{
	public InventoryItem cactusFruit;

	public InchwormBounce bouncerRef;

	public Transform fruitSpawnPoint;

	public Transform interactionPointTransform;

	private float spawnForce = 15f;

	private DogHome homeRef;

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		PickFruit();
	}

	public void PickFruit()
	{
		if (homeRef == null)
		{
			homeRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		}
		GameObject obj = homeRef.TrySpawnItem(cactusFruit, fruitSpawnPoint.position);
		AddForceToSpawnedObject(obj);
		bouncerRef.RequestBounce();
	}

	public void AddForceToSpawnedObject(GameObject obj)
	{
		Rigidbody componentInChildren = obj.GetComponentInChildren<Rigidbody>();
		componentInChildren.AddForce(spawnForce * Vector3.up, ForceMode.VelocityChange);
		componentInChildren.AddRelativeTorque(spawnForce * Random.rotation.eulerAngles, ForceMode.VelocityChange);
	}

	public override bool HasCustomInteractionPoint()
	{
		return true;
	}

	public override Vector3 GetInteractionPoint()
	{
		return interactionPointTransform.position;
	}

	public override Transform GetInteractionPointTransform()
	{
		return interactionPointTransform;
	}
}
