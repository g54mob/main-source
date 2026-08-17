using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableBananarang : BaseInteractable
{
	public GameObject fx;

	private bool done;

	public override bool Interact()
	{
		//IL_0178: Expected I4, but got O
		if (!done)
		{
			done = true;
			bool flag = MyAchievements.TryUnlock("a_bananarang");
			MyPlayer instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				PlayerInventory inventory = instance.inventory;
				if (instance.inventory != null && (object)DataManager.Instance != null)
				{
					WeaponData weapon = DataManager.Instance.GetWeapon(EWeapon.Bananarang);
					if (inventory.weaponInventory != null)
					{
						inventory.weaponInventory.AddWeapon(weapon, null);
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
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C9A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "BANANARANG");
	}

	public InteractableBananarang()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
