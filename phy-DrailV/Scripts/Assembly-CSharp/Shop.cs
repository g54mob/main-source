using DV.CashRegister;
using DV.Shops;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public CashRegisterWithModules cashRegister;

	public ScanItemCashRegisterModule[] scanItemResourceModules;

	public Transform itemSpawnTransform;

	private void Awake()
	{
		if (itemSpawnTransform == null)
		{
			Debug.LogError("itemSpawnTransform not set, need to create one in order to function", this);
			itemSpawnTransform = new GameObject("itemSpawnTransform").transform;
			itemSpawnTransform.SetParent(base.transform);
			itemSpawnTransform.localPosition = new Vector3(0f, 2f, 0f);
			itemSpawnTransform.localRotation = Quaternion.identity;
		}
	}
}
