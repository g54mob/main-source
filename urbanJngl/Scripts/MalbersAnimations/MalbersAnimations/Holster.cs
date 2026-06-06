using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class Holster
	{
		public HolsterID ID;

		public int Index;

		[Tooltip("Slots Transforms used to store weapons")]
		public List<Transform> Slots;

		[Tooltip("Weapon GameObject asociated to the Holster")]
		public MWeapon Weapon;

		[Tooltip("Input to Equip the weapon in the holster")]
		public StringReference Input = new StringReference();

		[Tooltip("If the weapon is added to the holster then it will be equipped on the Hand automatically")]
		public BoolReference AutoEquip = new BoolReference();

		public UnityAction<bool> InputListener;

		public WeaponEvent OnWeaponInHolster = new WeaponEvent();

		public int GetID
		{
			get
			{
				if (!(ID != null))
				{
					return 0;
				}
				return ID.ID;
			}
		}

		public Transform GetSlot(int index)
		{
			return Slots[index];
		}

		public bool PrepareWeapon()
		{
			if ((bool)Weapon)
			{
				Transform slot = Slots[Weapon.HolsterSlot];
				if (Weapon.gameObject.IsPrefab())
				{
					if (slot.childCount > 0)
					{
						UnityEngine.Object.Destroy(slot.GetChild(0).gameObject);
					}
					Weapon = UnityEngine.Object.Instantiate(Weapon);
					Weapon.name = Weapon.name.Replace("(Clone)", "");
					Weapon.Debugging("[Instantiated]", Weapon);
				}
				Weapon.Holster = ID;
				Weapon.Delay_Action(delegate
				{
					if (!Weapon.IsEquiped)
					{
						Weapon.transform.SetParent(slot);
						Weapon.transform.SetLocalTransform(Weapon.HolsterOffset);
					}
				});
				OnWeaponInHolster.Invoke(Weapon);
				Weapon.IsCollectable?.Pick();
				return true;
			}
			return false;
		}

		public static implicit operator int(Holster reference)
		{
			return reference.GetID;
		}
	}
}
