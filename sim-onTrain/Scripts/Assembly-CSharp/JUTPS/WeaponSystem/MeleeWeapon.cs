using JUTPS.InventorySystem;
using JUTPS.ItemSystem;
using JUTPSEditor.JUHeader;

namespace JUTPS.WeaponSystem
{
	public class MeleeWeapon : HoldableItem
	{
		[JUHeader("Melee Weapon Settings")]
		public string AttackAnimatorParameterName = "OneHandMeleeAttack";

		public int randomAnimCount;

		public Damager DamagerToEnable;

		[JUHeader("Damage Settings")]
		public bool EnableHealthLoss;

		public float MeleeWeaponHealth = 100f;

		public float DamagePerUse = 1f;

		protected override void Start()
		{
			base.Start();
			DamagerToEnable = DamagerToEnable ?? GetComponentInChildren<Damager>();
		}

		public override void Update()
		{
			base.Update();
			DamagerToEnable.gameObject.SetActive(IsUsingItem);
			if (DamagerToEnable.Collided && EnableHealthLoss)
			{
				MeleeWeaponHealth -= DamagePerUse;
				if (MeleeWeaponHealth <= 0f && (ItemQuantity > 0 || Unlocked))
				{
					JUInventory componentInParent = GetComponentInParent<JUInventory>();
					componentInParent.UnequipItem(JUInventory.GetGlobalItemSwitchID(this, componentInParent));
					RemoveItem();
				}
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
