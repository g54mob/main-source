using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_SpreadWeapon : FB_QuantisedAngleWeapon
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public FB_SpreadWeapon _003C_003E4__this;

		public float firingAngle;

		public float spreadPerAmount;

		public float amount;

		public Vector2 pos;

		public Transform target;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFireSalvo_003Eb__0()
		{
			//IL_0275: Expected O, but got I4
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Expected Ref, but got Unknown
			//IL_020b: Expected F4, but got O
			//IL_0084->IL0215: Incompatible stack heights: 1 vs 0
			//IL_0114->IL0215: Incompatible stack heights: 1 vs 0
			//IL_02d6->IL0215: Incompatible stack heights: 1 vs 0
			//IL_01a7->IL0215: Incompatible stack heights: 1 vs 0
			//IL_01c9->IL0215: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass5_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass5_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						float num = obj3.amount - 1f;
						float num2 = obj3.spreadPerAmount * 0.5f;
						float num3 = num * num2;
						object obj4 = localIndex * obj3.spreadPerAmount;
						object obj5 = obj4 + obj3.firingAngle;
						float num4 = (float)obj5 - num3;
						if ((object)obj3._003C_003E4__this != null)
						{
							Vector2 vector = default(Vector2);
							BulletPool pool = default(BulletPool);
							Projectile projectile = obj3._003C_003E4__this.FireOneProjectile(vector, localIndex, obj3.target, pool);
							if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
							{
								return;
							}
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								float projectileSpeed = projectile.ProjectileSpeed;
								if (projectile.body != null && (object)s_scene.physics != null)
								{
									float rotation = num4 * ((float)Math.PI / 180f);
									ref float2 vec = ref *(float2*)(projectile.body + 112);
									float2 float5 = s_scene.physics.velocityFromRotation(rotation, (float)vector, ref vec);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0033: Expected F4, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009a: Invalid comparison between O and F4
		//IL_00c5: Expected F4, but got O
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_SpreadShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		FireSalvo(vector, _targetTransform);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override float PAmount()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_008b: Expected O, but got I4
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = !(10f > num2);
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj = currentWeaponData & 1;
		bool flag2 = obj == null;
		object obj2 = !flag2;
		if (obj2 == null)
		{
			num4++;
		}
		return num4;
	}

	public unsafe void FireSalvo(Vector2 pos, Transform target = null, BulletPool pool = null)
	{
		//IL_0035: Expected F4, but got O
		//IL_0053: Expected O, but got F4
		//IL_0070: Expected O, but got F4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_050b: Invalid comparison between F4 and I4
		//IL_010c: Expected O, but got Ref
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_03f3: Expected I4, but got O
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected Ref, but got Unknown
		//IL_0333: Expected F4, but got O
		//IL_0333: Expected O, but got I
		_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		obj.target = target;
		obj.pool = pool;
		float num = PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		obj.amount = (float)pos;
		float num2 = num - 3f;
		object obj2 = num2 >> 31;
		float num3 = num2 - (float)obj2;
		object obj3 = num3 >> 1;
		object obj4 = obj3 * 4;
		object obj5 = obj3 + obj4;
		float num4 = (float)obj5 + 25f;
		bool flag = num4 > 45f;
		float num5 = 45f;
		if (!flag)
		{
			num5 = num4;
		}
		float spreadPerAmount = num5 / (float)pos;
		obj.spreadPerAmount = spreadPerAmount;
		obj.firingAngle = _firingAngleDegrees;
		if (IsHoming)
		{
			GameManager core = GM.Core;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj6 = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj6), excludeDead: true);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				float2 position2 = enemyController.position;
				float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				float2 position4 = enemyController.position;
				float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				object obj8 = default(object);
				object obj9 = default(object);
				object obj7 = obj8 - obj9;
				object obj10 = position4 - position5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				float firingAngle = (float)obj7 * 57.29578f;
				obj.firingAngle = firingAngle;
			}
		}
		int num6 = 0;
		bool flag2 = false;
		Vector2 vector = default(Vector2);
		BulletPool bulletPool = default(BulletPool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (obj.amount > (float)(flag2 ? 1 : 0))
		{
			WeaponData currentWeaponData = _currentWeaponData;
			object obj11 = num6 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj11 <= 0)
			{
				float num7 = obj.amount - 1f;
				float num8 = obj.spreadPerAmount * 0.5f;
				float num9 = num8 * num7;
				object obj12 = num6 * obj.spreadPerAmount;
				object obj13 = obj12 + obj.firingAngle;
				float num10 = (float)obj13 - num9;
				Projectile projectile = base.FireOneProjectile(vector, num6, obj.target, bulletPool);
				if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
					float projectileSpeed = projectile.ProjectileSpeed;
					float rotation = num10 * ((float)Math.PI / 180f);
					ref float2 vec = ref *(float2*)(projectile.body + 112);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rax_v35+18]");
					float2 float5 = ((ArcadePhysics)0).velocityFromRotation(rotation, (float)vector, ref vec);
					num6++;
					flag2 = (byte)num6 != 0;
					continue;
				}
			}
			else
			{
				_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass5_1();
				CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals8.localIndex = num6;
				WeaponData currentWeaponData2 = _currentWeaponData;
				Action onComplete = delegate
				{
					//IL_0275: Expected O, but got I4
					//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d6: Expected O, but got Unknown
					//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
					//IL_00e8: Expected O, but got Unknown
					//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
					//IL_01f1: Expected Ref, but got Unknown
					//IL_020b: Expected F4, but got O
					//IL_0084->IL0215: Incompatible stack heights: 1 vs 0
					//IL_0114->IL0215: Incompatible stack heights: 1 vs 0
					//IL_02d6->IL0215: Incompatible stack heights: 1 vs 0
					//IL_01a7->IL0215: Incompatible stack heights: 1 vs 0
					//IL_01c9->IL0215: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass5_0 obj14 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null && (object)obj14._003C_003E4__this != null)
					{
						GameObject gameObject = obj14._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj15 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj15 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass5_0 obj16 = CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals8.CS_0024_003C_003E8__locals1 != null)
							{
								float num12 = obj16.amount - 1f;
								float num13 = obj16.spreadPerAmount * 0.5f;
								float num14 = num12 * num13;
								object obj17 = CS_0024_003C_003E8__locals8.localIndex * obj16.spreadPerAmount;
								object obj18 = obj17 + obj16.firingAngle;
								float num15 = (float)obj18 - num14;
								if ((object)obj16._003C_003E4__this != null)
								{
									Vector2 vector2 = default(Vector2);
									BulletPool pool2 = default(BulletPool);
									Projectile projectile2 = obj16._003C_003E4__this.FireOneProjectile(vector2, CS_0024_003C_003E8__locals8.localIndex, obj16.target, pool2);
									if ((object)projectile2 == null || ((UnityEngine.Object)projectile2).m_CachedPtr == (IntPtr)0)
									{
										return;
									}
									PhaserScene s_scene = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										float projectileSpeed2 = projectile2.ProjectileSpeed;
										if (projectile2.body != null && (object)s_scene.physics != null)
										{
											float rotation2 = num15 * ((float)Math.PI / 180f);
											ref float2 vec2 = ref *(float2*)(projectile2.body + 112);
											float2 float6 = s_scene.physics.velocityFromRotation(rotation2, (float)vector2, ref vec2);
											return;
										}
									}
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num11 = (float)num6 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				float duration = num11 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)bulletPool != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			num6++;
			flag2 = (byte)num6 != 0;
		}
	}

	private Projectile _003C_003En__0(Vector2 pos, int index, Transform target, BulletPool pool)
	{
		return base.FireOneProjectile(pos, index, target, pool);
	}
}
