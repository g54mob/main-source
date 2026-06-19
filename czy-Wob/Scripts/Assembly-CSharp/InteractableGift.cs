using System.Collections.Generic;
using UnityEngine;

public class InteractableGift : InteractableBase
{
	public List<InventoryItem> possibleDrops = new List<InventoryItem>();

	public GameObject smoke;

	public GameObject confetti;

	public Rigidbody rb;

	private int dropRangeLow = 2;

	private int dropRangeHigh = 5;

	private string capsuleOpenSound = "capsule_open";

	private float currentTimer;

	private float autoCollectTimer = 10f;

	private float autoCollectionJiggle = 5f;

	private CursorController cursorRef;

	private void Awake()
	{
		currentTimer = Random.Range(0f - autoCollectionJiggle, 0f);
	}

	public void Update()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoUnwrapGifts())
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= autoCollectTimer)
			{
				Unwrap();
			}
		}
	}

	public override void OnObjectBittenByDog(Vector3 biteVector, GameObject dog)
	{
		Unwrap();
	}

	public void Unwrap()
	{
		AudioController.Play(capsuleOpenSound);
		GameObject obj = Object.Instantiate(smoke, rb.position, Quaternion.identity);
		Object.Instantiate(confetti, rb.position, Quaternion.identity);
		ObjectSpawnParticles component = obj.GetComponent<ObjectSpawnParticles>();
		component.spawnPos = rb.position;
		int num = Random.Range(dropRangeLow, dropRangeHigh + 1);
		for (int i = 0; i < num; i++)
		{
			component.SetContainedItem(ListUtil.GetRandomElement(possibleDrops));
		}
		component.SetMoveItemsToGoodLocation(val: true);
		GetComponent<RegisterTaggedObject>().SetSafeDestroy();
		Object.Destroy(base.gameObject);
	}
}
