using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MedicalScan2Projectile : MedicalScanProjectile
{
	private Dictionary<WeaponType, float> _bonusList;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		Dictionary<WeaponType, float> dictionary = new Dictionary<WeaponType, float>();
		bool flag = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)65, 0.1f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)57, 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)56, 20f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)58, 0.08f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)53, -0.03f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag6 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)55, 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)63, 0.2f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag8 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)59, 0.5f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)61, 0.05f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)60, 0.05f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag11 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)50, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)52, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)54, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<System.Int32Enum, float>)(object)dictionary).TryInsert((System.Int32Enum)51, 0.04f, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_bonusList = dictionary;
	}

	protected unsafe override void ApplyScanEffect()
	{
		//IL_00a5: Expected O, but got Ref
		Weapon weapon = _weapon;
		float num = ((Equipment)weapon)._003COwner_003Ek__BackingField.PRegen();
		float num2 = _weapon.PAmount();
		object obj = default(object);
		float num3 = (float)obj + 4f;
		float num4 = num3 * (float)obj;
		float radius = GetRadius();
		float num5 = radius * 17f;
		float num6 = num5 * num5;
		GameManager core = GM.Core;
		List<CharacterController>.Enumerator characters = (List<CharacterController>.Enumerator)core._characters;
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			CharacterController characterController = null;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}
}
