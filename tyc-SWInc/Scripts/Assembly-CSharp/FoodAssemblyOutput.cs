using System;
using UnityEngine;

public class FoodAssemblyOutput : MonoBehaviour, IManufacturingConverter, IFurnitureSerialization
{
	public Furniture Furn;

	[NonSerialized]
	private FoodOrder _queue;

	public bool TakeOrder(TransportBox box)
	{
		lock (this)
		{
			if (!Furn.CanPlaceHoldable())
			{
				return false;
			}
			FoodOrder queue;
			if (_queue == null && (queue = box.Order as FoodOrder) != null)
			{
				_queue = queue;
				return true;
			}
			return false;
		}
	}

	private void FixedUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		lock (this)
		{
			if (_queue != null && Furn.CanPlaceHoldable())
			{
				Holdable holdable = ItemDispenser.Instance.Dispense(_queue.Data.Type);
				holdable.Deserialize(_queue.Data);
				Furn.PlaceHoldable(holdable);
				Furn.InteractStart();
				_queue = null;
			}
		}
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["FoodOutput"] = _queue;
	}

	public void Deserialize(WriteDictionary dict, bool loading)
	{
		_queue = dict.Get("FoodOutput", _queue);
	}

	public void PostDeserialize()
	{
	}
}
