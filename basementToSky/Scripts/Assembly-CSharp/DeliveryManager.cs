using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
	[SerializeField]
	private Transform deliveryPos;

	[SerializeField]
	private GameObject boxPrefab;

	[SerializeField]
	private GameObject paperBagPrefab;

	private void Start()
	{
		GameManager.S.OnDeliveryArrived += Gm_OnDeliveryArrived;
		GameManager.S.OnGroceryArrived += S_OnGroceryArrived;
	}

	private void S_OnGroceryArrived(List<GameObject> arg1, List<GameObject> arg2)
	{
		int num = 5;
		for (int i = 0; i < arg1.Count; i += num)
		{
			DeliveryBox component = Object.Instantiate(paperBagPrefab, deliveryPos.position + Random.onUnitSphere * 0.5f, deliveryPos.rotation).GetComponent<DeliveryBox>();
			int num2 = Mathf.Min(num, arg1.Count - i);
			for (int j = 0; j < num2; j++)
			{
				component.contents.Add(arg1[i + j]);
			}
		}
		for (int k = 0; k < arg2.Count; k++)
		{
			Object.Instantiate(boxPrefab, deliveryPos.position + Random.onUnitSphere * 0.5f, deliveryPos.rotation).GetComponent<DeliveryBox>().contents.Add(arg2[k]);
		}
		if (arg1.Count > 0 || arg2.Count > 0)
		{
			AudioManager.S.PlayDoorBell(AudioManager.S.knockingDoor);
		}
	}

	private void OnDestroy()
	{
		GameManager.S.OnDeliveryArrived -= Gm_OnDeliveryArrived;
		GameManager.S.OnGroceryArrived -= S_OnGroceryArrived;
	}

	private void Gm_OnDeliveryArrived(object sender, GameManager.OnDeliveryArrivedArg e)
	{
		foreach (GameObject item in e.items)
		{
			Object.Instantiate(boxPrefab, deliveryPos.position + Random.onUnitSphere, deliveryPos.rotation).GetComponent<DeliveryBox>().contents.Add(item);
		}
		AudioManager.S.PlayDoorBell(AudioManager.S.knockingDoor);
	}

	private void Update()
	{
	}
}
