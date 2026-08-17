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

public class FB_HomingWeapon : FB_QuantisedAngleWeapon
{
	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public FB_HomingProjectile bullet;

		internal void _003CInternalUpdate_003Eb__0()
		{
			FB_HomingProjectile fB_HomingProjectile = bullet;
			if ((object)bullet != null && ((UnityEngine.Object)fB_HomingProjectile).m_CachedPtr != (IntPtr)0)
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
		//IL_073e: Expected I, but got O
		//IL_0111: Expected O, but got I
		//IL_0168: Expected I, but got O
		//IL_0147: Expected O, but got I4
		//IL_0786: Expected O, but got I
		//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Expected O, but got Unknown
		//IL_06c0: Expected O, but got I4
		//IL_06c8: Expected I, but got O
		//IL_01cf: Expected O, but got I
		//IL_0248: Expected F4, but got I
		//IL_0269: Invalid comparison between F4 and I4
		//IL_0280: Invalid comparison between I and F4
		//IL_0291: Expected O, but got I
		//IL_0321: Invalid comparison between F4 and I4
		//IL_0353: Expected I, but got O
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_0471: Expected I, but got O
		//IL_0481: Expected O, but got I
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected Ref, but got Unknown
		//IL_051e: Invalid comparison between F4 and I4
		//IL_060b: Expected O, but got I4
		//IL_05ac: Expected I, but got O
		//IL_0644: Expected I, but got O
		base.InternalUpdate();
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		nint num = unchecked((nint)null);
		object obj6 = default(object);
		while (true)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass2_0();
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			Projectile[] items;
			FB_HomingProjectile bullet;
			object obj4;
			if ((nint)obj < spawnedProjectiles2._size)
			{
				items = spawnedProjectiles2._items;
				Projectile projectile = items[obj];
				if ((object)items[obj] == null)
				{
					bullet = null;
					goto IL_070f;
				}
				nint num2 = (nint)typeof(FB_HomingProjectile);
				ref float2 reference = ref *(float2*)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_HomingProjectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ r9_v8 (Unity.Mathematics.float2&)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_HomingProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ r9_v8 (Unity.Mathematics.float2&)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v69+FFFFFFF8+v736 @ rax_v64*8]");
					if (0 == (nint)typeof(FB_HomingProjectile))
					{
						obj4 = 1;
						goto IL_0721;
					}
				}
				obj4 = 0;
				goto IL_0721;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
			IL_0721:
			bool flag2 = obj4 == null;
			num = (nint)typeof(FB_HomingProjectile);
			bullet = null;
			if (!flag2)
			{
				num = (nint)typeof(FB_HomingProjectile);
				bullet = (FB_HomingProjectile)items[obj];
			}
			goto IL_070f;
			IL_070f:
			CS_0024_003C_003E8__locals17.bullet = bullet;
			FB_HomingProjectile bullet2 = CS_0024_003C_003E8__locals17.bullet;
			bool flag3 = (nint)CS_0024_003C_003E8__locals17.bullet < 0;
			bool flag4 = (object)CS_0024_003C_003E8__locals17.bullet == null;
			FB_HomingProjectile fB_HomingProjectile = (FB_HomingProjectile)num;
			if (!flag4)
			{
				flag3 = (nint)((UnityEngine.Object)bullet2).m_CachedPtr < 0;
				bool flag5 = ((UnityEngine.Object)bullet2).m_CachedPtr == (IntPtr)0;
				fB_HomingProjectile = (FB_HomingProjectile)num;
				if (!flag5)
				{
					FB_HomingProjectile bullet3 = CS_0024_003C_003E8__locals17.bullet;
					float timeSinceChangedTarget = bullet3._timeSinceChangedTarget;
					float deltaTime = PauseSystem.DeltaTime;
					ArcadeSprite bullet4 = CS_0024_003C_003E8__locals17.bullet;
					float timeSinceChangedTarget2 = deltaTime + bullet3._timeSinceChangedTarget;
					bullet3._timeSinceChangedTarget = timeSinceChangedTarget2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v25 (ArcadeSprite)+E0]");
					float num4 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v25 (ArcadeSprite)+E0]");
					float num5 = 0f - 0.1f;
					flag3 = num5 < 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v25 (ArcadeSprite)+E0]");
					bool flag6 = !(0f > 0.1f);
					fB_HomingProjectile = (FB_HomingProjectile)num;
					if (!flag6)
					{
						float2 cachedPosition = bullet4.cachedPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v25 (ArcadeSprite)+D8]");
						timeSinceChangedTarget = 0f - (float)cachedPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v25 (ArcadeSprite)+DC]");
						float num6 = 0f - 0f;
						float num7 = timeSinceChangedTarget * timeSinceChangedTarget;
						float num8 = num6 * num6;
						float num9 = num7 + num8;
						float num10 = 0.1f - num9;
						flag3 = num10 < 0f;
						if (!(0.1f > num9))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
							nint num11 = (nint)this;
							float target = num6 * 57.29578f;
							float num12 = base.PSpeed();
							float num13 = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj5 = num13 & 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
							FB_HomingProjectile bullet5 = CS_0024_003C_003E8__locals17.bullet;
							float deltaTime2 = PauseSystem.DeltaTime;
							num6 = (float)obj5 * 300f;
							float maxDelta = deltaTime2 * num6;
							float num14 = Mathf.MoveTowardsAngle(bullet5._facingAngle, target, maxDelta);
							FB_HomingProjectile bullet6 = CS_0024_003C_003E8__locals17.bullet;
							float num15 = num14 / 45f;
							bullet6._facingAngle = num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
							float num16 = (bullet6.angle = num15 * 45f);
							PhaserScene scene = bullet6.scene;
							FB_HomingProjectile bullet7 = CS_0024_003C_003E8__locals17.bullet;
							nint num18 = (nint)bullet7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_HomingProjectile>)+2E0]");
							fB_HomingProjectile = (FB_HomingProjectile)0;
							float projectileSpeed = bullet7.ProjectileSpeed;
							FB_HomingProjectile bullet8 = CS_0024_003C_003E8__locals17.bullet;
							timeSinceChangedTarget = num14 * ((float)Math.PI / 180f);
							ref float2 reference = ref *(float2*)(bullet8.body + 112);
							float2 float5 = scene.physics.velocityFromRotation(timeSinceChangedTarget, num16, ref reference);
							FB_HomingProjectile bullet9 = CS_0024_003C_003E8__locals17.bullet;
							num4 = bullet9._timeSinceChangedTarget;
							float num19 = bullet9._timeSinceChangedTarget - 5f;
							flag3 = num19 < 0f;
							bool flag7 = !(bullet9._timeSinceChangedTarget > 5f);
							num8 = num16;
							if (!flag7)
							{
								bullet9._timeSinceChangedTarget = -1000f;
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								if ((object)CS_0024_003C_003E8__locals17.bullet != null)
								{
									nint num20 = (nint)array;
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
									FB_HomingProjectile bullet10 = CS_0024_003C_003E8__locals17.bullet;
									if ((object)CS_0024_003C_003E8__locals17.bullet != null && ((UnityEngine.Object)bullet10).m_CachedPtr != (IntPtr)0)
									{
										CS_0024_003C_003E8__locals17.bullet.Despawn();
									}
								};
								tweenConfig.onComplete = onComplete;
								nint num21 = (nint)typeof(Tweens);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1095 @ rcx_v39 (Il2CppClass<VampireSurvivors.Framework.PhaserTweens.Tweens>)+E4]");
								flag3 = (nint)0 < (nint)0;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								num8 = num16;
								reference = ref *(float2*)null;
								fB_HomingProjectile = null;
							}
						}
						else
						{
							fB_HomingProjectile = CS_0024_003C_003E8__locals17.bullet;
							RefreshTarget(CS_0024_003C_003E8__locals17.bullet);
						}
					}
				}
			}
			obj--;
			object obj7 = !flag3;
			num = (nint)fB_HomingProjectile;
			if (obj7 == null)
			{
				return;
			}
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void RefreshTarget(FB_HomingProjectile bullet)
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
		//IL_02e8: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_01b6: Expected I, but got O
		//IL_0268: Expected O, but got F4
		BulletPool pool2 = default(BulletPool);
		Transform target2 = default(Transform);
		Projectile projectile = base.FireOneProjectile(pos, index, target2, pool2);
		FB_HomingProjectile fB_HomingProjectile;
		if ((object)projectile == null)
		{
			fB_HomingProjectile = null;
			goto IL_0300;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(FB_HomingProjectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_HomingProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_HomingProjectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v39+FFFFFFF8+v67 @ rax_v35*8]");
			if (0 == (nint)typeof(FB_HomingProjectile))
			{
				obj3 = 1;
				goto IL_02d1;
			}
		}
		obj3 = 0;
		goto IL_02d1;
		IL_02d1:
		bool flag = obj3 == null;
		target2 = (Transform)num;
		fB_HomingProjectile = null;
		if (!flag)
		{
			target2 = (Transform)num;
			fB_HomingProjectile = (FB_HomingProjectile)projectile;
		}
		goto IL_0300;
		IL_0300:
		if ((object)fB_HomingProjectile != null && ((UnityEngine.Object)fB_HomingProjectile).m_CachedPtr != (IntPtr)0)
		{
			RefreshTarget(fB_HomingProjectile);
			fB_HomingProjectile._timeSinceChangedTarget = 0f;
			float2 position = fB_HomingProjectile.position;
			float2 position2 = default(float2);
			fB_HomingProjectile.position = position2;
			float num4 = UnityEngine.Random.Range(-15f, 15f);
			float num5 = (fB_HomingProjectile._facingAngle = num4 + _firingAngleDegrees);
			float num6 = num5 / 45f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			float num7 = (fB_HomingProjectile.angle = num6 * 45f);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num9 = (nint)fB_HomingProjectile;
				float projectileSpeed = fB_HomingProjectile.ProjectileSpeed;
				BaseBody body = fB_HomingProjectile.body;
				if (fB_HomingProjectile.body != null && (object)s_scene.physics != null)
				{
					float num10 = num5 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num11 = num10 * num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num12 = num10 * num7;
					body._velocity = (float2)num11;
					return fB_HomingProjectile;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		return null;
	}

	public FB_HomingWeapon()
	{
		//IL_000b: Expected O, but got I4
		_bulletStartOffset = (float2)0;
		_ = 1047904911;
		((Weapon)this)._002Ector();
	}
}
