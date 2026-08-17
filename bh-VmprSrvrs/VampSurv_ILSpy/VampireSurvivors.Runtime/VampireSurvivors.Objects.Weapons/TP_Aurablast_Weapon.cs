using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
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

public class TP_Aurablast_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Vector2 __pos;

		public int localIndex;

		public Vector2 __pos2;

		public TP_Aurablast_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_0129: Expected O, but got I4
			//IL_0079->IL00f2: Incompatible stack heights: 1 vs 0
			//IL_00c5->IL00f2: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					TP_Aurablast_Weapon tP_Aurablast_Weapon = _003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						Projectile projectile = _003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Aurablast_Weapon._targetTransform);
						TP_Aurablast_Weapon tP_Aurablast_Weapon2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							Projectile projectile2 = _003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Aurablast_Weapon2._targetTransform);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _bigProjectile;

	protected BulletPool _bigPool;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0076: Expected I, but got O
		//IL_0119: Expected I, but got O
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
		BulletPool bigPool = new BulletPool(_bigProjectile);
		_bigPool = bigPool;
		BulletPool bigPool2 = _bigPool;
		bigPool2.UpperLimit = 100;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Aurablast_Weapon>)+350]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_bigPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Aurablast_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_bigPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			float num3 = base.PInterval();
			object obj = default(object);
			float num4 = (float)obj * 0.1f;
			base._003CTotalTime_003Ek__BackingField = num4;
			return;
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_03bd: Expected I, but got O
		//IL_03ea: Invalid comparison between F4 and O
		//IL_047a: Invalid comparison between O and F4
		//IL_0191: Invalid comparison between O and F4
		//IL_01b5: Expected O, but got I8
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_028f: Expected O, but got F4
		//IL_02cf: Expected O, but got F4
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		nint num = (nint)this;
		float num2 = base.PAmount();
		object obj = default(object);
		float num3 = (float)obj * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		object obj2 = default(object);
		float2 float5 = default(float2);
		bool canPause;
		Vector2 vector;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile = _bigPool.SpawnAt(float5, this);
			if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
			{
				BaseBody body = projectile.body;
				if (projectile.body != null)
				{
					body._transform.ForceFullReupdate();
				}
			}
			bool flag = (object)projectile == null;
			canPause = false;
			vector = float5;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0;
				canPause = false;
				vector = float5;
				if (!flag2)
				{
					Transform transform = projectile.transform;
					Transform parent = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					transform.parent = parent;
					canPause = false;
					vector = float5;
				}
			}
		}
		else
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Projectile projectile2 = base.FireOneProjectile(float5, 0, _targetTransform);
			canPause = false;
			vector = float5;
		}
		float num4 = base.PArea();
		float num5 = (float)vector * 0.16f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
			{
				object obj3 = 4294967295L;
				int num6 = 1;
				float num8 = default(float);
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj4 = num6 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj4 <= 0)
					{
						float num7 = num8 - 0.16f;
						float num9 = (float)obj3 * num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					}
					else
					{
						_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass5_0();
						CS_0024_003C_003E8__locals14._003C_003E4__this = this;
						CS_0024_003C_003E8__locals14.localIndex = num6;
						float num10 = (float)num6 * num5;
						float num11 = num8 - 0.16f;
						float num12 = (float)position3 + num10;
						CS_0024_003C_003E8__locals14.__pos = (Vector2)num12;
						float num13 = num8 - 0.16f;
						float num14 = (float)obj3 * num5;
						float num15 = (float)position3 + num14;
						CS_0024_003C_003E8__locals14.__pos2 = (Vector2)num15;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_0129: Expected O, but got I4
							//IL_0079->IL00f2: Incompatible stack heights: 1 vs 0
							//IL_00c5->IL00f2: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals14._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals14._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj5 == null)
									{
										return;
									}
									TP_Aurablast_Weapon tP_Aurablast_Weapon = CS_0024_003C_003E8__locals14._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals14._003C_003E4__this != null)
									{
										Vector2 pos = default(Vector2);
										Projectile projectile3 = CS_0024_003C_003E8__locals14._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals14.localIndex, tP_Aurablast_Weapon._targetTransform);
										TP_Aurablast_Weapon tP_Aurablast_Weapon2 = CS_0024_003C_003E8__locals14._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals14._003C_003E4__this != null)
										{
											Projectile projectile4 = CS_0024_003C_003E8__locals14._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals14.localIndex, tP_Aurablast_Weapon2._targetTransform);
											return;
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num16 = (float)num6 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						float duration = num16 * 0.001f;
						Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
						_lastShotTimer = lastShotTimer;
					}
					num6++;
					obj3--;
				}
				while ((nint)obj2 > num6);
			}
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public Projectile FireBigAssProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		if (_bigPool != null)
		{
			float2 pos2 = default(float2);
			Projectile projectile = _bigPool.SpawnAt(pos2, this, index);
			if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
			{
				BaseBody body = projectile.body;
				if (projectile.body != null)
				{
					if (body._transform == null)
					{
						goto IL_00bc;
					}
					body._transform.ForceFullReupdate();
				}
			}
			return projectile;
		}
		goto IL_00bc;
		IL_00bc:
		return (Projectile)(object)new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
	}
}
