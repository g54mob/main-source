using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SummonSpirit_Weapon : FB_QuantisedAngleWeapon
{
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public TP_SummonSpirit_Projectile bullet;

		internal void _003CInternalUpdate_003Eb__0()
		{
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile = bullet;
			if ((object)bullet != null && ((UnityEngine.Object)tP_SummonSpirit_Projectile).m_CachedPtr != (IntPtr)0)
			{
				bullet.Despawn();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public TP_SummonSpirit_Weapon _003C_003E4__this;

		public float detune;
	}

	private sealed class _003C_003Ec__DisplayClass17_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			//IL_0218: Expected O, but got I4
			//IL_00e4: Expected I, but got O
			//IL_014e: Expected I, but got O
			//IL_00a8->IL01e1: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL01e1: Incompatible stack heights: 1 vs 0
			//IL_0112->IL01e1: Incompatible stack heights: 1 vs 0
			//IL_0141->IL01e1: Incompatible stack heights: 1 vs 0
			//IL_017c->IL01e1: Incompatible stack heights: 1 vs 0
			//IL_019e->IL01e1: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass17_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass17_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						GameObject gameObject2 = (GameObject)(object)obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null)
						{
							nint num = (nint)gameObject2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v378 @ rax_v16 (Il2CppClass<UnityEngine.GameObject>)+5D8] (should have been resolved before IL gen)");
							_003C_003Ec__DisplayClass17_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_SummonSpirit_Weapon tP_SummonSpirit_Weapon = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null)
								{
									nint num2 = (nint)gameObject2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
									_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
									{
										float num3 = (float)localIndex * 100f;
										float detune = num3 + obj5.detune;
										obj5._003C_003E4__this.PlayFiringSfx(detune);
										return;
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private float2 _bulletStartOffset;

	private bool _isManualFire;

	protected PhaserSprite _animatedSprite;

	protected MultiTargetTween _alphaTween;

	private float emissionTime;

	private float emissionDuration;

	protected virtual float2 BulletSpawnPos
	{
		get
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float2 result = default(float2);
				return result;
			}
			return (float2)new NullReferenceException();
		}
	}

	protected unsafe virtual SpriteTextureData PortalSprite
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesThosepeople thosepeople = SpriteTextures.Thosepeople;
			if (SpriteTextures.Thosepeople != null && thosepeople.Thosepeople != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A14A6]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "TP_VFX_Dark01");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	public override float PArea()
	{
		//IL_0017: Expected I, but got O
		//IL_0055: Invalid comparison between I4 and F4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num = (nint)characterController;
		float num2 = characterController.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num3 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		if (!(0f > num3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
			return num3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		return num3;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		SpriteTextureData portalSprite = PortalSprite;
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		Vector2 pos = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, portalSprite.Sprite, portalSprite.Sprite);
		_animatedSprite = animatedSprite;
		Transform transform = _animatedSprite.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _animatedSprite.transform;
		bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(0.75f);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: false);
	}

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0018: Expected O, but got I4
		//IL_002b: Expected I, but got O
		//IL_00bd: Expected I, but got O
		//IL_00d5: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_0770: Expected I, but got O
		//IL_0111: Expected O, but got I
		//IL_0168: Expected I, but got O
		//IL_0147: Expected O, but got I4
		//IL_07b8: Expected O, but got I
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected O, but got Unknown
		//IL_06f2: Expected O, but got I4
		//IL_06fa: Expected I, but got O
		//IL_01cf: Expected O, but got I
		//IL_029f: Expected F4, but got I
		//IL_02c0: Invalid comparison between F4 and I4
		//IL_02d7: Invalid comparison between I and F4
		//IL_02e8: Expected O, but got I
		//IL_0378: Invalid comparison between F4 and I4
		//IL_04a3: Expected I, but got O
		//IL_04b3: Expected O, but got I
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected Ref, but got Unknown
		//IL_0550: Invalid comparison between F4 and I4
		//IL_063d: Expected O, but got I4
		//IL_05de: Expected I, but got O
		//IL_0676: Expected I, but got O
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
		while (true)
		{
			_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass13_0();
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			Projectile[] items;
			TP_SummonSpirit_Projectile bullet;
			object obj4;
			if ((nint)obj < spawnedProjectiles2._size)
			{
				items = spawnedProjectiles2._items;
				Projectile projectile = items[obj];
				if ((object)items[obj] == null)
				{
					bullet = null;
					goto IL_0741;
				}
				nint num2 = (nint)typeof(TP_SummonSpirit_Projectile);
				ref float2 reference = ref *(float2*)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SummonSpirit_Projectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ r9_v8 (Unity.Mathematics.float2&)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rdx_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SummonSpirit_Projectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ r9_v8 (Unity.Mathematics.float2&)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ rax_v65+FFFFFFF8+v734 @ rax_v60*8]");
					if (0 == (nint)typeof(TP_SummonSpirit_Projectile))
					{
						obj4 = 1;
						goto IL_0753;
					}
				}
				obj4 = 0;
				goto IL_0753;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
			IL_0753:
			bool flag2 = obj4 == null;
			num = (nint)typeof(TP_SummonSpirit_Projectile);
			bullet = null;
			if (!flag2)
			{
				num = (nint)typeof(TP_SummonSpirit_Projectile);
				bullet = (TP_SummonSpirit_Projectile)items[obj];
			}
			goto IL_0741;
			IL_0741:
			CS_0024_003C_003E8__locals18.bullet = bullet;
			TP_SummonSpirit_Projectile bullet2 = CS_0024_003C_003E8__locals18.bullet;
			bool flag3 = (nint)CS_0024_003C_003E8__locals18.bullet < 0;
			bool flag4 = (object)CS_0024_003C_003E8__locals18.bullet == null;
			TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile = (TP_SummonSpirit_Projectile)num;
			if (!flag4)
			{
				flag3 = (nint)((UnityEngine.Object)bullet2).m_CachedPtr < 0;
				bool flag5 = ((UnityEngine.Object)bullet2).m_CachedPtr == (IntPtr)0;
				tP_SummonSpirit_Projectile = (TP_SummonSpirit_Projectile)num;
				if (!flag5)
				{
					TP_SummonSpirit_Projectile bullet3 = CS_0024_003C_003E8__locals18.bullet;
					float deltaTime = PauseSystem.DeltaTime;
					float timeSinceChangedTarget = deltaTime + bullet3._timeSinceChangedTarget;
					bullet3._timeSinceChangedTarget = timeSinceChangedTarget;
					float num4 = emissionTime;
					float deltaTime2 = PauseSystem.DeltaTime;
					float num5 = deltaTime2 * 1000f;
					float num6 = num5 * 0.25f;
					float num7 = (emissionTime = num6 + emissionTime);
					ArcadeSprite bullet4 = CS_0024_003C_003E8__locals18.bullet;
					float num8 = num7 / emissionDuration;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v25 (ArcadeSprite)+100]");
					float num9 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v25 (ArcadeSprite)+100]");
					float num10 = 0f - 0.1f;
					flag3 = num10 < 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v25 (ArcadeSprite)+100]");
					bool flag6 = !(0f > 0.1f);
					tP_SummonSpirit_Projectile = (TP_SummonSpirit_Projectile)num;
					if (!flag6)
					{
						float2 cachedPosition = bullet4.cachedPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v25 (ArcadeSprite)+F8]");
						num4 = 0f - (float)cachedPosition;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v25 (ArcadeSprite)+FC]");
						float num11 = 0f - 0f;
						float num12 = num4 * num4;
						float num13 = num11 * num11;
						float num14 = num12 + num13;
						float num15 = 0.1f - num14;
						flag3 = num15 < 0f;
						if (!(0.1f > num14))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
							num11 *= 57.29578f;
							float degreesPerSecond = GetDegreesPerSecond();
							TP_SummonSpirit_Projectile bullet5 = CS_0024_003C_003E8__locals18.bullet;
							BaseBody body = bullet5.body;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v14 (BaseBody)+74]");
							float current = 0f * 57.29578f;
							float deltaTime3 = PauseSystem.DeltaTime;
							float num16 = num8 + 0.5f;
							num8 = num16 * degreesPerSecond;
							float maxDelta = deltaTime3 * num8;
							float num17 = Mathf.MoveTowardsAngle(current, num11, maxDelta);
							CS_0024_003C_003E8__locals18.bullet.angle = num17;
							PhaserScene scene = CS_0024_003C_003E8__locals18.bullet.scene;
							TP_SummonSpirit_Projectile bullet6 = CS_0024_003C_003E8__locals18.bullet;
							nint num18 = (nint)bullet6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SummonSpirit_Projectile>)+2E0]");
							tP_SummonSpirit_Projectile = (TP_SummonSpirit_Projectile)0;
							float projectileSpeed = bullet6.ProjectileSpeed;
							TP_SummonSpirit_Projectile bullet7 = CS_0024_003C_003E8__locals18.bullet;
							num4 = num17 * ((float)Math.PI / 180f);
							ref float2 reference = ref *(float2*)(bullet7.body + 112);
							float2 float5 = scene.physics.velocityFromRotation(num4, num17, ref reference);
							TP_SummonSpirit_Projectile bullet8 = CS_0024_003C_003E8__locals18.bullet;
							num9 = bullet8._timeSinceChangedTarget;
							float num19 = bullet8._timeSinceChangedTarget - 5f;
							flag3 = num19 < 0f;
							bool flag7 = !(bullet8._timeSinceChangedTarget > 5f);
							num13 = num17;
							if (!flag7)
							{
								bullet8._timeSinceChangedTarget = -1000f;
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								if ((object)CS_0024_003C_003E8__locals18.bullet != null)
								{
									nint num20 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									if (obj5 == null)
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
									TP_SummonSpirit_Projectile bullet9 = CS_0024_003C_003E8__locals18.bullet;
									if ((object)CS_0024_003C_003E8__locals18.bullet != null && ((UnityEngine.Object)bullet9).m_CachedPtr != (IntPtr)0)
									{
										CS_0024_003C_003E8__locals18.bullet.Despawn();
									}
								};
								tweenConfig.onComplete = onComplete;
								nint num21 = (nint)typeof(Tweens);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1100 @ rcx_v40 (Il2CppClass<VampireSurvivors.Framework.PhaserTweens.Tweens>)+E4]");
								flag3 = (nint)0 < (nint)0;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								num13 = num17;
								reference = ref *(float2*)null;
								tP_SummonSpirit_Projectile = null;
							}
						}
						else
						{
							tP_SummonSpirit_Projectile = CS_0024_003C_003E8__locals18.bullet;
							RefreshTarget(CS_0024_003C_003E8__locals18.bullet);
						}
					}
				}
			}
			obj--;
			object obj6 = !flag3;
			num = (nint)tP_SummonSpirit_Projectile;
			if (obj6 == null)
			{
				return;
			}
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void RefreshTarget(TP_SummonSpirit_Projectile bullet)
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
		//IL_02bc: Expected O, but got I
		//IL_0071: Expected O, but got I
		//IL_00c2: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_018a: Expected I, but got O
		//IL_023c: Expected O, but got F4
		BulletPool pool2 = default(BulletPool);
		Transform target2 = default(Transform);
		Projectile projectile = base.FireOneProjectile(pos, index, target2, pool2);
		TP_SummonSpirit_Projectile tP_SummonSpirit_Projectile;
		if ((object)projectile == null)
		{
			tP_SummonSpirit_Projectile = null;
			goto IL_02d4;
		}
		nint num = (nint)projectile;
		nint num2 = (nint)typeof(TP_SummonSpirit_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SummonSpirit_Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SummonSpirit_Projectile>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v37+FFFFFFF8+v67 @ rax_v33*8]");
			if (0 == (nint)typeof(TP_SummonSpirit_Projectile))
			{
				obj3 = 1;
				goto IL_02a5;
			}
		}
		obj3 = 0;
		goto IL_02a5;
		IL_02a5:
		bool flag = obj3 == null;
		target2 = (Transform)num;
		tP_SummonSpirit_Projectile = null;
		if (!flag)
		{
			target2 = (Transform)num;
			tP_SummonSpirit_Projectile = (TP_SummonSpirit_Projectile)projectile;
		}
		goto IL_02d4;
		IL_02d4:
		if ((object)tP_SummonSpirit_Projectile != null && ((UnityEngine.Object)tP_SummonSpirit_Projectile).m_CachedPtr != (IntPtr)0)
		{
			RefreshTarget(tP_SummonSpirit_Projectile);
			tP_SummonSpirit_Projectile._timeSinceChangedTarget = 0f;
			float num4 = UnityEngine.Random.Range(-15f, 15f);
			float num5 = num4 + _firingAngleDegrees;
			float num6 = num5 / 45f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			float num7 = (tP_SummonSpirit_Projectile.angle = num6 * 45f);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				nint num9 = (nint)tP_SummonSpirit_Projectile;
				float projectileSpeed = tP_SummonSpirit_Projectile.ProjectileSpeed;
				BaseBody body = tP_SummonSpirit_Projectile.body;
				if (tP_SummonSpirit_Projectile.body != null && (object)s_scene.physics != null)
				{
					float num10 = num5 * ((float)Math.PI / 180f);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					float num11 = num10 * num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num12 = num10 * num7;
					body._velocity = (float2)num11;
					return tP_SummonSpirit_Projectile;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		return null;
	}

	private float GetDegreesPerSecond()
	{
		//IL_0010: Expected O, but got I4
		//IL_003a: Expected O, but got I8
		//IL_0054: Expected O, but got I8
		object obj = ((Equipment)this)._003CLevel_003Ek__BackingField - 1;
		if ((nint)obj <= 7)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rdx_v1+74796E8+v2 @ rax_v2*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 100f;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0078: Expected O, but got F4
		//IL_02c8: Expected O, but got F4
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_026a: Invalid comparison between O and F4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_021d: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj._003C_003E4__this = this;
		emissionTime = 0f;
		float num = base.PDuration();
		float num2 = default(float);
		emissionDuration = num2;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
		SetPortalPosition();
		DoPortalTween();
		float2 bulletSpawnPos = BulletSpawnPos;
		float num3 = default(float);
		Projectile projectile = FireOneProjectile((Vector2)num3, 0, _targetTransform);
		object obj2 = UnityEngine.Random.value;
		float num4 = num3 - 0.5f;
		float num5 = (obj.detune = num4 * 200f);
		PlayFiringSfx(num5);
		float num6 = base.PAmount();
		if (num5 > 1f)
		{
			float num7 = base.PAmount();
			if (num5 > 1f)
			{
				bool flag = true;
				float num8 = num5;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj3 = flag * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj3 <= 0)
					{
						float2 bulletSpawnPos2 = BulletSpawnPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						float num9 = (float)(flag ? 1 : 0) * 100f;
						num8 = num9 + obj.detune;
						PlayFiringSfx(num8);
						num5 = num3;
					}
					else
					{
						_003C_003Ec__DisplayClass17_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass17_1();
						CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 = obj;
						CS_0024_003C_003E8__locals11.localIndex = (flag ? 1 : 0);
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_0218: Expected O, but got I4
							//IL_00e4: Expected I, but got O
							//IL_014e: Expected I, but got O
							//IL_00a8->IL01e1: Incompatible stack heights: 1 vs 0
							//IL_00d7->IL01e1: Incompatible stack heights: 1 vs 0
							//IL_0112->IL01e1: Incompatible stack heights: 1 vs 0
							//IL_0141->IL01e1: Incompatible stack heights: 1 vs 0
							//IL_017c->IL01e1: Incompatible stack heights: 1 vs 0
							//IL_019e->IL01e1: Incompatible stack heights: 1 vs 0
							_003C_003Ec__DisplayClass17_0 obj5 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
							{
								GameObject gameObject = obj5._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj6 == null)
									{
										return;
									}
									_003C_003Ec__DisplayClass17_0 obj7 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
									{
										GameObject gameObject2 = (GameObject)(object)obj7._003C_003E4__this;
										if ((object)obj7._003C_003E4__this != null)
										{
											nint num15 = (nint)gameObject2;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v378 @ rax_v16 (Il2CppClass<UnityEngine.GameObject>)+5D8] (should have been resolved before IL gen)");
											_003C_003Ec__DisplayClass17_0 obj8 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
											{
												TP_SummonSpirit_Weapon tP_SummonSpirit_Weapon = obj8._003C_003E4__this;
												if ((object)obj8._003C_003E4__this != null)
												{
													nint num16 = (nint)gameObject2;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ r10_v5 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
													_003C_003Ec__DisplayClass17_0 obj9 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null && (object)obj9._003C_003E4__this != null)
													{
														float num17 = (float)CS_0024_003C_003E8__locals11.localIndex * 100f;
														float detune = num17 + obj9.detune;
														obj9._003C_003E4__this.PlayFiringSfx(detune);
														return;
													}
												}
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num10 = (float)(flag ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num5 = num10 * 0.001f;
						Timer lastShotTimer = Timers.Register(num5, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
					float num11 = base.PAmount();
				}
				while (num5 > (float)(flag ? 1 : 0));
			}
		}
		float num12 = base.PInterval();
		float num13 = _lastFiringInterval - num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj4 = num13 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num14 = base.PInterval();
			_lastFiringInterval = num5;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override void ResetFiringTimer()
	{
		if (!_isManualFire)
		{
			base.ResetFiringTimer();
		}
		else if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible && (object)_animatedSprite != null)
		{
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		}
	}

	protected virtual void SetPortalPosition()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = default(float2);
		PhaserSprite phaserSprite = _animatedSprite.setPosition(position2);
	}

	protected virtual void DoPortalTween()
	{
		//IL_001a: Expected O, but got I4
		//IL_0096: Expected I, but got O
		//IL_00ec: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		PhaserSprite phaserSprite = _animatedSprite.setScale(0.25f, (float?)(object)0);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_animatedSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 600f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.yoyo = true;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void PlayFiringSfx(float detune)
	{
		//IL_0033: Expected F4, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune2 = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_SummonSpirit, 50f, 1, 0f, volume, rate, detune2, loop, 1f);
	}

	public override void Cleanup()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		base.Cleanup();
	}

	public TP_SummonSpirit_Weapon()
	{
		//IL_000b: Expected O, but got I4
		_bulletStartOffset = (float2)0;
		_ = 1067366482;
		emissionDuration = 1000f;
		((Weapon)this)._002Ector();
	}

	private void _003CDoPortalTween_003Eb__21_0()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
	}
}
