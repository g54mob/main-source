using CTS.BBT;
using CTS.Core;
using UnityEngine;

public class FurnitureCellLocker : MonoBehaviour
{
	private Furniture _furniture;

	[SerializeField]
	private BoxCollider _box;

	private void Awake()
	{
		_box = GetComponent<BoxCollider>();
		_furniture = GetComponentInParent<Furniture>();
		ConstructionSystem.OnConstructionModeChanged += ConstructionSystem_OnConstructionModeChanged;
	}

	private void ConstructionSystem_OnConstructionModeChanged()
	{
		if (MonoSingleton<ConstructionSystem>.Instance.CurrentMode != EConstructionMode.None)
		{
			Furniture_FurniturePlaced(_furniture);
		}
	}

	private void OnDestroy()
	{
		ConstructionSystem.OnConstructionModeChanged -= ConstructionSystem_OnConstructionModeChanged;
	}

	private void Furniture_FurniturePlaced(Furniture obj)
	{
		RaycastHit[] array = Physics.BoxCastAll(_box.center, _box.size / 2f, Vector3.down, obj.transform.rotation, 1f);
		for (int i = 0; i < array.Length; i++)
		{
			Debug.Log(array[i].collider.name);
		}
	}
}
