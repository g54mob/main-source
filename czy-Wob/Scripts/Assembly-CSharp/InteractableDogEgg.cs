using UnityEngine;

public class InteractableDogEgg : InteractableBase
{
	private float breakChance = 0.25f;

	private DogEgg eggRef;

	private void Awake()
	{
		eggRef = GetComponent<DogEgg>();
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		if (Random.value <= breakChance)
		{
			eggRef.Break();
		}
	}
}
