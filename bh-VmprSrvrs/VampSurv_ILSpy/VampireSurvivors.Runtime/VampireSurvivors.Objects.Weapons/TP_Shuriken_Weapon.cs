using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Shuriken_Weapon : FB_QuantisedAngleWeapon
{
	private float _amount;

	private List<float> _shuffledIndexes;

	public override float QuantisationStep => 1f;

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0022: Invalid comparison between F4 and I4
		//IL_0034: Expected F4, but got I4
		//IL_0074: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_00dd: Expected O, but got I
		float num = base.PAmount();
		float num2 = default(float);
		_amount = num2;
		List<float> shuffledIndexes = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		_shuffledIndexes = shuffledIndexes;
		bool flag = !(num2 > 0f);
		float num3 = 0f;
		if (!flag)
		{
			do
			{
				List<float> shuffledIndexes2 = _shuffledIndexes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ r8_v7+18]");
				if (num4 >= 0)
				{
					shuffledIndexes2.AddWithResize(num3);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rcx_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj3 = (nint)0 + (nint)1;
				}
				num3++;
			}
			while (num2 > num3);
		}
		Extensions.Shuffle(_shuffledIndexes);
		base.Fire(skipTriggers);
	}

	public unsafe override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0070: Expected O, but got I
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,dword ptr [rdi+160h]\"");
		float num = _firingAngleDegrees;
		object obj2 = default(object);
		object obj = obj2 - 3;
		object obj3 = obj >> 31;
		object obj4 = obj - obj3;
		object obj5 = obj4 >> 1;
		object obj6 = obj5 * 4;
		object obj7 = obj5 + obj6;
		List<float> shuffledIndexes = _shuffledIndexes;
		float num2 = (float)obj7 + 15f;
		bool flag = !(60f > num2);
		float num3 = 60f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = num3 / _amount;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)index < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)index >= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Projectile result = default(Projectile);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj8 = 0;
			float num5 = _amount - 1f;
			float num6 = num4 * 0.5f;
			float num7 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v23+20+index @ r8 (System.Int32)*4]");
			float num8 = num7 * 0f;
			float num9 = num5 * num6;
			float num10 = num8 - num9;
			num += num10;
		}
		object obj9 = default(object);
		float speed = (float)obj9 + 0.12f;
		BulletPool pool2 = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, index, target, pool2);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			if (!IsHoming)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				float projectileSpeed = projectile.ProjectileSpeed;
				float rotation = num * ((float)Math.PI / 180f);
				ref float2 vec = ref *(float2*)(projectile.body + 112);
				float2 float5 = s_scene.physics.velocityFromRotation(rotation, speed, ref vec);
			}
			else
			{
				Transform transform = projectile.AimForNearestEnemy();
			}
		}
		return projectile;
	}

	public override void CheckArcanas()
	{
		//IL_00b0: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
				List<Collider> wallsColliders = _wallsColliders;
				_bonusBounces = 3;
				object obj2 = 0;
				object obj3 = 0;
				while ((nint)obj3 < wallsColliders._size)
				{
					List<Collider> wallsColliders2 = _wallsColliders;
					if ((nint)obj2 < wallsColliders2._size)
					{
						Collider[] items = wallsColliders2._items;
						World world = ArcadePhysics.s_world.removeCollider(items[obj2]);
						wallsColliders = _wallsColliders;
						obj2++;
						obj3 = obj2;
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return;
				}
				WeaponData currentWeaponData2 = _currentWeaponData;
				currentWeaponData2._003ChitsWalls_003Ek__BackingField = false;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	private void GenerateShuffleIndexes(float amount)
	{
		//IL_000e: Invalid comparison between F4 and I4
		//IL_0020: Expected F4, but got I4
		//IL_0051: Expected O, but got I
		//IL_00aa: Expected O, but got I
		List<float> shuffledIndexes = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		_shuffledIndexes = shuffledIndexes;
		bool flag = !(amount > 0f);
		float num = 0f;
		if (!flag)
		{
			do
			{
				List<float> shuffledIndexes2 = _shuffledIndexes;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v5+18]");
				if (num2 >= 0)
				{
					shuffledIndexes2.AddWithResize(num);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj2 = (nint)0 + (nint)1;
				}
				num++;
			}
			while (amount > num);
		}
		Extensions.Shuffle(_shuffledIndexes);
	}
}
