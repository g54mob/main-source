using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodAssemblyInput : MonoBehaviour, IFurnitureSerialization
{
	public Conveyor Con;

	[NonSerialized]
	private List<FoodOrder> _queue = new List<FoodOrder>();

	public bool CanReceive()
	{
		lock (this)
		{
			return _queue.Count < 5;
		}
	}

	public void ReceiveInput(Holdable hold)
	{
		lock (_queue)
		{
			_queue.Add(new FoodOrder(hold));
		}
		Con.Parent.InteractStart();
		ItemDispenser.Instance.DestroyItem(hold);
	}

	private void Start()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			lock (GameSettings.Instance.FoodAssemblers)
			{
				GameSettings.Instance.FoodAssemblers.Add(this);
			}
		}
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			lock (GameSettings.Instance.FoodAssemblers)
			{
				GameSettings.Instance.FoodAssemblers.Remove(this);
			}
		}
	}

	public void UpdateMe()
	{
		lock (_queue)
		{
			if (_queue.Count > 0)
			{
				FoodOrder order = _queue[0];
				Conveyor output = Con.GetOutput(order, 0, true);
				if (output != null)
				{
					GameSettings.Instance.BoxController.CreateBox(order, Con, output);
					_queue.RemoveAt(0);
				}
			}
		}
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["FoodInput"] = _queue;
	}

	public void Deserialize(WriteDictionary dict, bool loading)
	{
		_queue = dict.Get("FoodInput", _queue);
	}

	public void PostDeserialize()
	{
	}
}
