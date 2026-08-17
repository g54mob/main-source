using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCage : BaseInteractable
{
	public GameObject fx;

	private bool done;

	public AudioSource audioSource;

	public GameObject monke;

	public LocalizedString localizedString;

	public MeshRenderer meshRenderer;

	public BoxCollider collider;

	public override bool Interact()
	{
		//IL_01a7: Expected I4, but got O
		if (!done)
		{
			done = true;
			if ((object)fx != null)
			{
				Transform transform = fx.transform;
				if ((object)transform != null)
				{
					transform.parentInternal = null;
					if ((object)fx != null)
					{
						fx.SetActive(value: true);
						if ((object)collider != null)
						{
							collider.enabled = false;
							if ((object)meshRenderer != null)
							{
								meshRenderer.enabled = false;
								if ((object)audioSource != null)
								{
									audioSource.Stop();
									if ((object)audioSource != null)
									{
										audioSource.enabled = false;
										if ((object)monke != null)
										{
											monke.SetActive(value: true);
											bool flag = MyAchievements.TryUnlock("a_monke");
											return true;
										}
									}
								}
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

	public override bool CanInteract()
	{
		//IL_00ed: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.itemInventory != null)
			{
				int amount = inventory.itemInventory.GetAmount(EItem.CageKey);
				int num = amount ^ amount;
				int num2 = amount & num;
				bool flag = num2 < 0;
				bool flag2 = amount < 0;
				bool flag3 = amount == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override string GetInteractString()
	{
		if (localizedString != null)
		{
			return localizedString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	private bool HasKey()
	{
		//IL_00ed: Expected I4, but got O
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.itemInventory != null)
			{
				int amount = inventory.itemInventory.GetAmount(EItem.CageKey);
				int num = amount ^ amount;
				int num2 = amount & num;
				bool flag = num2 < 0;
				bool flag2 = amount < 0;
				bool flag3 = amount == 0;
				bool flag4 = flag2 == flag;
				bool flag5 = !flag3;
				return flag5 & flag4;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public InteractableCage()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
