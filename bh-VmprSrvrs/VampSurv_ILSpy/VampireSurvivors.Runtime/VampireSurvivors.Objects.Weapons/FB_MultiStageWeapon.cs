using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_MultiStageWeapon : FB_QuantisedAngleWeapon
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public FB_MultiStageProjectile bullet;

		internal void _003CInternalUpdate_003Eb__0()
		{
			FB_MultiStageProjectile fB_MultiStageProjectile = bullet;
			if ((object)bullet != null && ((UnityEngine.Object)fB_MultiStageProjectile).m_CachedPtr != (IntPtr)0)
			{
				bullet.Despawn();
			}
		}
	}

	protected float2 _bulletStartOffset;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0018: Expected O, but got I4
		//IL_002b: Expected I, but got O
		//IL_00bd: Expected I, but got O
		//IL_00d5: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_0773: Expected I, but got O
		//IL_0111: Expected O, but got I
		//IL_0168: Expected I, but got O
		//IL_0147: Expected O, but got I4
		//IL_07bb: Expected O, but got I
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ea: Expected O, but got Unknown
		//IL_06f5: Expected O, but got I4
		//IL_06fd: Expected I, but got O
		//IL_01cf: Expected O, but got I
		//IL_021f: Expected O, but got I
		//IL_0286: Expected F4, but got I
		//IL_02a7: Invalid comparison between F4 and I4
		//IL_02be: Invalid comparison between I and F4
		//IL_02cf: Expected O, but got I
		//IL_035f: Invalid comparison between F4 and I4
		//IL_04a6: Expected I, but got O
		//IL_04b6: Expected O, but got I
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected Ref, but got Unknown
		//IL_0553: Invalid comparison between F4 and I4
		//IL_0640: Expected O, but got I4
		//IL_05e1: Expected I, but got O
		//IL_0679: Expected I, but got O
		base.InternalUpdate();
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		nint num = unchecked((nint)null);
		object obj5 = default(object);
		object obj6 = default(object);
		while (true)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals19 = new _003C_003Ec__DisplayClass2_0();
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			Projectile[] items;
			FB_MultiStageProjectile bullet;
			object obj4;
			if ((nint)obj < spawnedProjectiles2._size)
			{
				items = spawnedProjectiles2._items;
				Projectile projectile = items[obj];
				if ((object)items[obj] == null)
				{
					bullet = null;
					goto IL_0744;
				}
				nint num2 = (nint)typeof(FB_MultiStageProjectile);
				ref float2 reference = ref *(float2*)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ r9_v8 (Unity.Mathematics.float2&)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rdx_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ r9_v8 (Unity.Mathematics.float2&)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rax_v67+FFFFFFF8+v723 @ rax_v62*8]");
					if (0 == (nint)typeof(FB_MultiStageProjectile))
					{
						obj4 = 1;
						goto IL_0756;
					}
				}
				obj4 = 0;
				goto IL_0756;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
			IL_0756:
			bool flag2 = obj4 == null;
			num = (nint)typeof(FB_MultiStageProjectile);
			bullet = null;
			if (!flag2)
			{
				num = (nint)typeof(FB_MultiStageProjectile);
				bullet = (FB_MultiStageProjectile)items[obj];
			}
			goto IL_0744;
			IL_0744:
			CS_0024_003C_003E8__locals19.bullet = bullet;
			FB_MultiStageProjectile bullet2 = CS_0024_003C_003E8__locals19.bullet;
			bool flag3 = (nint)CS_0024_003C_003E8__locals19.bullet < 0;
			bool flag4 = (object)CS_0024_003C_003E8__locals19.bullet == null;
			FB_MultiStageProjectile fB_MultiStageProjectile = (FB_MultiStageProjectile)num;
			if (!flag4)
			{
				flag3 = (nint)((UnityEngine.Object)bullet2).m_CachedPtr < 0;
				bool flag5 = ((UnityEngine.Object)bullet2).m_CachedPtr == (IntPtr)0;
				fB_MultiStageProjectile = (FB_MultiStageProjectile)num;
				if (!flag5)
				{
					FB_MultiStageProjectile bullet3 = CS_0024_003C_003E8__locals19.bullet;
					flag3 = (nint)bullet3.body < 0;
					bool flag6 = bullet3.body == null;
					fB_MultiStageProjectile = (FB_MultiStageProjectile)num;
					if (!flag6)
					{
						float timeSinceChangedTarget = bullet3._timeSinceChangedTarget;
						float deltaTime = PauseSystem.DeltaTime;
						ArcadeSprite bullet4 = CS_0024_003C_003E8__locals19.bullet;
						float timeSinceChangedTarget2 = deltaTime + bullet3._timeSinceChangedTarget;
						bullet3._timeSinceChangedTarget = timeSinceChangedTarget2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v26 (ArcadeSprite)+E0]");
						float num4 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v26 (ArcadeSprite)+E0]");
						float num5 = 0f - 0.1f;
						flag3 = num5 < 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v26 (ArcadeSprite)+E0]");
						bool flag7 = !(0f > 0.1f);
						fB_MultiStageProjectile = (FB_MultiStageProjectile)num;
						if (!flag7)
						{
							float2 cachedPosition = bullet4.cachedPosition;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v26 (ArcadeSprite)+D8]");
							timeSinceChangedTarget = 0f - (float)cachedPosition;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v26 (ArcadeSprite)+DC]");
							float num6 = 0f - 0f;
							float num7 = timeSinceChangedTarget * timeSinceChangedTarget;
							float num8 = num6 * num6;
							float num9 = num7 + num8;
							float num10 = 0.1f - num9;
							flag3 = num10 < 0f;
							if (!(0.1f > num9))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
								FB_MultiStageProjectile bullet5 = CS_0024_003C_003E8__locals19.bullet;
								float target = num6 * 57.29578f;
								num6 = ((((Projectile)bullet5)._indexInWeapon >= 0) ? 300f : 600f);
								BaseBody body = bullet5.body;
								FB_MultiStageProjectile bullet6 = CS_0024_003C_003E8__locals19.bullet;
								BaseBody body2 = bullet6.body;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v13 (BaseBody)+74]");
								float current = 0f * 57.29578f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
								float maxDelta = (float)obj5 * num6;
								float num11 = Mathf.MoveTowardsAngle(current, target, maxDelta);
								CS_0024_003C_003E8__locals19.bullet.angle = num11;
								PhaserScene scene = CS_0024_003C_003E8__locals19.bullet.scene;
								FB_MultiStageProjectile bullet7 = CS_0024_003C_003E8__locals19.bullet;
								nint num12 = (nint)bullet7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1059 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+2E0]");
								fB_MultiStageProjectile = (FB_MultiStageProjectile)0;
								float projectileSpeed = bullet7.ProjectileSpeed;
								FB_MultiStageProjectile bullet8 = CS_0024_003C_003E8__locals19.bullet;
								timeSinceChangedTarget = num11 * ((float)Math.PI / 180f);
								ref float2 reference = ref *(float2*)(bullet8.body + 112);
								float2 float5 = scene.physics.velocityFromRotation(timeSinceChangedTarget, num11, ref reference);
								FB_MultiStageProjectile bullet9 = CS_0024_003C_003E8__locals19.bullet;
								num4 = bullet9._timeSinceChangedTarget;
								float num13 = bullet9._timeSinceChangedTarget - 5f;
								flag3 = num13 < 0f;
								bool flag8 = !(bullet9._timeSinceChangedTarget > 5f);
								num8 = num11;
								if (!flag8)
								{
									bullet9._timeSinceChangedTarget = -1000f;
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if ((object)CS_0024_003C_003E8__locals19.bullet != null)
									{
										nint num14 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										if (obj6 == null)
										{
											break;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig.targets = array;
									tweenConfig.duration = 100f;
									tweenConfig.scale = (float?)(object)1;
									TweenCallback onComplete = delegate
									{
										FB_MultiStageProjectile bullet10 = CS_0024_003C_003E8__locals19.bullet;
										if ((object)CS_0024_003C_003E8__locals19.bullet != null && ((UnityEngine.Object)bullet10).m_CachedPtr != (IntPtr)0)
										{
											CS_0024_003C_003E8__locals19.bullet.Despawn();
										}
									};
									tweenConfig.onComplete = onComplete;
									nint num15 = (nint)typeof(Tweens);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rcx_v39 (Il2CppClass<VampireSurvivors.Framework.PhaserTweens.Tweens>)+E4]");
									flag3 = (nint)0 < (nint)0;
									MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
									num8 = num11;
									reference = ref *(float2*)null;
									fB_MultiStageProjectile = null;
								}
							}
							else
							{
								fB_MultiStageProjectile = CS_0024_003C_003E8__locals19.bullet;
								RefreshTarget(CS_0024_003C_003E8__locals19.bullet);
							}
						}
					}
				}
			}
			obj--;
			object obj7 = !flag3;
			num = (nint)fB_MultiStageProjectile;
			if (obj7 == null)
			{
				return;
			}
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void RefreshTarget(FB_MultiStageProjectile bullet)
	{
		//IL_0033: Expected O, but got Ref
		//IL_0113: Expected O, but got F4
		GameManager core = GM.Core;
		float2 position = bullet.position;
		float2 ret = default(float2);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&ret), excludeDead: true);
		if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
		{
			((ArcadeSprite)enemyController).CheckRenderer();
			Transform transform = ((ArcadeSprite)enemyController)._spriteRenderer.transform;
			if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				throw new NullReferenceException();
			}
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			bullet._targetPosition = ret;
			bullet._timeSinceChangedTarget = 0f;
		}
		else
		{
			float2 position2 = bullet.position;
			BaseBody body = bullet.body;
			float num = (float)body._velocity * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v17 (BaseBody)+74]");
			float num2 = 0f * 100f;
			float num3 = (float)position2 + num;
			object obj = default(object);
			float num4 = (float)obj + num2;
			bullet._targetPosition = (float2)num3;
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0017: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_02d7: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_01a5: Expected I, but got O
		//IL_0257: Expected O, but got F4
		BulletPool pool2 = default(BulletPool);
		Transform target2 = default(Transform);
		Projectile projectile = base.FireOneProjectile(pos, index, target2, pool2);
		FB_MultiStageProjectile fB_MultiStageProjectile;
		if ((object)projectile == null)
		{
			fB_MultiStageProjectile = null;
			goto IL_02ef;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(FB_MultiStageProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_MultiStageProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v38+FFFFFFF8+v67 @ rax_v34*8]");
			if (0 == (nint)typeof(FB_MultiStageProjectile))
			{
				obj3 = 1;
				goto IL_02c0;
			}
		}
		obj3 = 0;
		goto IL_02c0;
		IL_02c0:
		bool flag = obj3 == null;
		target2 = (Transform)num;
		fB_MultiStageProjectile = null;
		if (!flag)
		{
			target2 = (Transform)num;
			fB_MultiStageProjectile = (FB_MultiStageProjectile)projectile;
		}
		goto IL_02ef;
		IL_02ef:
		if ((object)fB_MultiStageProjectile != null && ((UnityEngine.Object)fB_MultiStageProjectile).m_CachedPtr != (IntPtr)0)
		{
			RefreshTarget(fB_MultiStageProjectile);
			fB_MultiStageProjectile._timeSinceChangedTarget = 0f;
			float2 position = fB_MultiStageProjectile.position;
			float2 position2 = default(float2);
			fB_MultiStageProjectile.position = position2;
			float num4;
			float num5;
			if (index >= 0)
			{
				num4 = UnityEngine.Random.Range(-15f, 15f);
				num5 = num4 + _firingAngleDegrees;
			}
			else
			{
				num4 = UnityEngine.Random.Range(0f, 360f);
				num5 = num4;
			}
			fB_MultiStageProjectile.angle = num5;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num6 = (nint)fB_MultiStageProjectile;
				float projectileSpeed = fB_MultiStageProjectile.ProjectileSpeed;
				BaseBody body = fB_MultiStageProjectile.body;
				if (fB_MultiStageProjectile.body != null && (object)s_scene.physics != null)
				{
					float num7 = num5 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num8 = num7 * num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num9 = num7 * num4;
					body._velocity = (float2)num8;
					return fB_MultiStageProjectile;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		return null;
	}

	public FB_MultiStageWeapon()
	{
		//IL_000b: Expected O, but got I4
		_bulletStartOffset = (float2)0;
		_ = 1047904911;
		((Weapon)this)._002Ector();
	}
}
