using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyRoastable : EnemyController
{
	private float itemChance = 0.2f;

	public unsafe override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_0357: Invalid comparison between F4 and I4
		//IL_03ea: Invalid comparison between F4 and I4
		//IL_01bc: Invalid comparison between I4 and F4
		//IL_01d5: Expected I, but got O
		//IL_012d: Expected I, but got O
		//IL_02ba: Expected I, but got O
		//IL_040c: Expected O, but got F4
		//IL_043b: Invalid comparison between F4 and I4
		//IL_0464: Expected O, but got I4
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected I4, but got Unknown
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_0176->IL0176: Incompatible stack heights: 1 vs 0
		//IL_02e0->IL02e0: Incompatible stack heights: 1 vs 0
		//IL_027d->IL03fe: Incompatible stack heights: 1 vs 0
		//IL_0250->IL03fe: Incompatible stack heights: 1 vs 0
		bool flag = !(_damageWeakness > 1f);
		float num = value;
		if (!flag)
		{
			num = value * _damageWeakness;
		}
		PlayerOptions fireDamageTypes = (PlayerOptions)(object)EnemyController.FireDamageTypes;
		if (EnemyController.FireDamageTypes != null)
		{
			PlayerOptions.OnValueChanged powerUpPurchased = fireDamageTypes.PowerUpPurchased;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+40]");
			ItemType itemType = ItemType.VOID;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
			object obj2 = default(object);
			object obj = obj2 >> 31;
			object obj3 = obj ^ 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj4 = default(object);
			if (obj4 == null && obj3 != null)
			{
				num *= base._003CWeakFire_003Ek__BackingField;
			}
			object obj6 = default(object);
			if (num > 0f)
			{
				PlayerOptionsData config = _playerOptions.Config;
				bool flag2 = !config._003CDamageNumbersEnabled_003Ek__BackingField;
				itemType = ItemType.VOID;
				if (!flag2)
				{
					nint num2 = (nint)_cachedTransform;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdi_v17 (Il2CppMethodInfo)+10]");
					bool flag3 = (nint)0 == 0;
					object obj5 = obj6 - 80;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdi_v17 (Il2CppMethodInfo)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-48]");
					_ = 0;
					itemType = (ItemType)(obj6 - 64);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2990");
				}
			}
			if (!base._003CIsDead_003Ek__BackingField && !(0f < (_hp -= num)))
			{
				nint num3 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rax_v91 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyRoastable>)+460]");
				itemType = ItemType.VOID;
				base.Die();
			}
			Vector2 vector = default(Vector2);
			if (!(_hp > 0f))
			{
				if (obj3 != null)
				{
					object obj7 = UnityEngine.Random.value;
					bool flag4 = itemChance < _hp;
					float num4 = itemChance - _hp;
					bool flag5 = num4 == 0f;
					bool flag6 = !flag4;
					bool flag7 = !flag5;
					object obj8 = flag7 & flag6;
					if (obj8 != null)
					{
						Transform transform = base.transform;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v61 (UnityEngine.Transform)+10]");
						bool flag8 = (nint)0 == 0;
						object obj9 = obj6 - 80;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rax_v61 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj9);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-50]");
						_ = 0;
						if (_gameManager.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.ROAST))
						{
							Pickup pickup = PickupManager.CreatePickup(vector, ItemType.ROAST);
							powerUpPurchased = null;
						}
					}
				}
			}
			else
			{
				_damageKb = damageKb;
			}
			EnemyController.PlayHitSfx();
			if (showHitVfx != HitVfxType.None)
			{
				nint num5 = (nint)_cachedTransform;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v14 (Il2CppMethodInfo)+10]");
				bool flag9 = (nint)0 == 0;
				object obj10 = obj6 - 80;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v14 (Il2CppMethodInfo)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj10);
				VFXManager.SpawnImpactVFX(showHitVfx, vector);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp+48]");
			base.OnGetDamaged(showHitVfx, hasKb: false);
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("array");
		throw ex;
	}
}
