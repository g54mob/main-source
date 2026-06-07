using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDispenser : MonoBehaviour
{
	public static ItemDispenser Instance;

	public Holdable[] Items;

	public GameObject[] HolidayItems;

	[NonSerialized]
	private Dictionary<string, Holdable> _holdables = new Dictionary<string, Holdable>();

	[NonSerialized]
	private Dictionary<string, List<Holdable>> _pool = new Dictionary<string, List<Holdable>>();

	private void Awake()
	{
		if (Instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		for (int i = 0; i < Items.Length; i++)
		{
			Holdable holdable = Items[i];
			_holdables[holdable.Type] = holdable;
			if (!_pool.ContainsKey(holdable.Type))
			{
				_pool[holdable.Type] = new List<Holdable>();
			}
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Holdable Dispense(string itemName)
	{
		Holdable orNull = _holdables.GetOrNull(itemName);
		if (orNull != null)
		{
			List<Holdable> list = _pool[itemName];
			Holdable holdable = null;
			if (list.Count > 0)
			{
				holdable = list.Pop();
				holdable.gameObject.SetActive(true);
				holdable.transform.localScale = orNull.transform.localScale;
				holdable.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
				holdable.MiscValue = 0f;
			}
			else
			{
				holdable = UnityEngine.Object.Instantiate(orNull);
			}
			holdable.Spawned = TimeOfDay.GetDateLocked();
			return holdable;
		}
		throw new UnityException("Tried to dispense non-existent holdable type: " + itemName);
	}

	public void DestroyItem(Holdable hold)
	{
		hold.DecoupleFromParent();
		hold.transform.SetParent(null);
		hold.gameObject.SetActive(false);
		List<Holdable> orDefault = _pool.GetOrDefault(hold.Type);
		if (orDefault != null)
		{
			orDefault.Add(hold);
		}
		else
		{
			Debug.LogError("Tried to release non-existent holdable type: " + hold.Type);
		}
	}
}
