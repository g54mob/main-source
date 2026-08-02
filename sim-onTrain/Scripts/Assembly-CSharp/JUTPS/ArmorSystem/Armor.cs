using System.Collections.Generic;
using JUTPS.ItemSystem;
using UnityEngine;

namespace JUTPS.ArmorSystem
{
	[AddComponentMenu("JU TPS/Armor System/Armor")]
	public class Armor : Item
	{
		[Header("Visual Settings")]
		public GameObject[] Parts;

		[Header("Armor Settings")]
		public bool EnableArmorHealth;

		public float Health = 100f;

		[HideInInspector]
		public float MaxHealth = 100f;

		public bool EnableArmorProtection;

		public float DamageMultiplier = 0.5f;

		public DamageableBodyPart[] DamageablesToProtect;

		private List<float> defaultDamageMultiplier = new List<float>();

		private void Awake()
		{
			MaxHealth = Health;
			MaxItemQuantity = 1;
			DamageableBodyPart[] damageablesToProtect = DamageablesToProtect;
			foreach (DamageableBodyPart damageableBodyPart in damageablesToProtect)
			{
				if (damageableBodyPart != null)
				{
					defaultDamageMultiplier.Add(damageableBodyPart.DamageMultiplier);
				}
			}
		}

		private void OnEnable()
		{
			EnableAllParts();
			ProtectParts(DamageablesToProtect, DamageMultiplier);
		}

		private void OnDisable()
		{
			DisableAllParts();
			UnprotectParts(DamageablesToProtect, defaultDamageMultiplier);
		}

		public void ProtectParts(DamageableBodyPart[] parts, float targetDamageMultiplier)
		{
			if (!EnableArmorProtection)
			{
				return;
			}
			foreach (DamageableBodyPart damageableBodyPart in parts)
			{
				if (damageableBodyPart != null)
				{
					damageableBodyPart.DamageMultiplier = targetDamageMultiplier;
				}
			}
		}

		public void UnprotectParts(DamageableBodyPart[] parts, List<float> defaultValues)
		{
			if (EnableArmorProtection)
			{
				for (int i = 0; i < parts.Length; i++)
				{
					parts[i].DamageMultiplier = defaultValues[i];
				}
			}
		}

		public void DisableAllParts()
		{
			GameObject[] parts = Parts;
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].SetActive(value: false);
			}
		}

		public void EnableAllParts()
		{
			GameObject[] parts = Parts;
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].SetActive(value: true);
			}
		}

		public void DoDamageOnArmor(float damage)
		{
			if (EnableArmorHealth)
			{
				Health -= damage;
				if (Health <= 0f)
				{
					RemoveItem();
					Health = 0f;
				}
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
