using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using UnityEngine;

public class InteractableCageKey : BaseInteractable
{
	public GameObject fx;

	private bool done;

	public EItem eItem;

	public override bool Interact()
	{
		//IL_0135: Expected I4, but got O
		if (!done)
		{
			done = true;
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null && inventory.itemInventory != null)
				{
					inventory.itemInventory.AddItem(eItem);
					if ((object)fx != null)
					{
						Transform transform = fx.transform;
						if ((object)transform != null)
						{
							transform.parentInternal = null;
							if ((object)fx != null)
							{
								fx.SetActive(value: true);
								GameObject obj = base.gameObject;
								UnityEngine.Object.Destroy(obj);
								return true;
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override string GetInteractString()
	{
		if ((object)DataManager.Instance != null)
		{
			ItemData item = DataManager.Instance.GetItem(eItem);
			if ((object)item != null)
			{
				return item.GetName();
			}
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableCageKey()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
