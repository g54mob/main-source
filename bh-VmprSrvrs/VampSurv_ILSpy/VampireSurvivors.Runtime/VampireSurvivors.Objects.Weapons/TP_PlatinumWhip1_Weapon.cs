using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_PlatinumWhip1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public TP_PlatinumWhip1_Weapon _003C_003E4__this;

		public Vector2 _offset;
	}

	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

		internal void _003COnSpecialCounter_003Eb__0()
		{
			//IL_01bd: Expected O, but got I4
			//IL_00a8->IL0186: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL0186: Incompatible stack heights: 1 vs 0
			//IL_00f9->IL0186: Incompatible stack heights: 1 vs 0
			//IL_0134->IL0186: Incompatible stack heights: 1 vs 0
			//IL_0156->IL0186: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass8_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass8_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						TP_PlatinumWhip1_Weapon tP_PlatinumWhip1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && (object)((Equipment)tP_PlatinumWhip1_Weapon)._003COwner_003Ek__BackingField != null)
						{
							float2 position = ((Equipment)tP_PlatinumWhip1_Weapon)._003COwner_003Ek__BackingField.position;
							_003C_003Ec__DisplayClass8_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null && tP_PlatinumWhip1_Weapon._memoryWhipPool != null)
							{
								float2 pos = default(float2);
								Projectile projectile = tP_PlatinumWhip1_Weapon._memoryWhipPool.SpawnAt(pos, obj4._003C_003E4__this, localIndex);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _memoryWhipPrefab;

	protected int _fireCounter;

	protected int _specialCounter = 3;

	protected int _subWeaponCounter = 7;

	private BulletPool _memoryWhipPool;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	protected override void OnStart()
	{
		//IL_0076: Expected I, but got O
		//IL_0119: Expected I, but got O
		base.OnStart();
		BulletPool memoryWhipPool = new BulletPool(_memoryWhipPrefab);
		_memoryWhipPool = memoryWhipPool;
		BulletPool memoryWhipPool2 = _memoryWhipPool;
		memoryWhipPool2.UpperLimit = 200;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_PlatinumWhip1_Weapon>)+370]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_memoryWhipPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_PlatinumWhip1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_memoryWhipPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		if (++_fireCounter % _specialCounter == 0)
		{
			OnSpecialCounter(skipTriggers);
		}
		if (_fireCounter % _subWeaponCounter == 0)
		{
			OnSubWeaponCounter(skipTriggers);
		}
	}

	public virtual void OnSpecialCounter(bool skipTriggers = false)
	{
		//IL_0063: Expected O, but got I4
		//IL_007b: Invalid comparison between F4 and I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_01cc: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass8_0 obj = new _003C_003Ec__DisplayClass8_0();
		obj._003C_003E4__this = this;
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 size = arcadeSprite._spriteRenderer.size;
		object obj2 = default(object);
		float num = (float)obj2 * 0.5f;
		obj._offset = (Vector2)0;
		float num2 = base.PAmount();
		if (!(num > 0f))
		{
			return;
		}
		int num3 = 0;
		float2 pos = default(float2);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			WeaponData currentWeaponData = _currentWeaponData;
			object obj3 = num3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			if ((nint)obj3 <= 0)
			{
				Vector2 playerPos = base.PlayerPos;
				Projectile projectile = _memoryWhipPool.SpawnAt(pos, this, num3);
			}
			else
			{
				_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass8_1();
				CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
				CS_0024_003C_003E8__locals9.localIndex = num3;
				WeaponData currentWeaponData2 = _currentWeaponData;
				Action onComplete = delegate
				{
					//IL_01bd: Expected O, but got I4
					//IL_00a8->IL0186: Incompatible stack heights: 1 vs 0
					//IL_00d7->IL0186: Incompatible stack heights: 1 vs 0
					//IL_00f9->IL0186: Incompatible stack heights: 1 vs 0
					//IL_0134->IL0186: Incompatible stack heights: 1 vs 0
					//IL_0156->IL0186: Incompatible stack heights: 1 vs 0
					_003C_003Ec__DisplayClass8_0 obj4 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
					{
						GameObject gameObject = obj4._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj5 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass8_0 obj6 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
							{
								TP_PlatinumWhip1_Weapon tP_PlatinumWhip1_Weapon = obj6._003C_003E4__this;
								if ((object)obj6._003C_003E4__this != null && (object)((Equipment)tP_PlatinumWhip1_Weapon)._003COwner_003Ek__BackingField != null)
								{
									float2 position = ((Equipment)tP_PlatinumWhip1_Weapon)._003COwner_003Ek__BackingField.position;
									_003C_003Ec__DisplayClass8_0 obj7 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && tP_PlatinumWhip1_Weapon._memoryWhipPool != null)
									{
										float2 pos2 = default(float2);
										Projectile projectile2 = tP_PlatinumWhip1_Weapon._memoryWhipPool.SpawnAt(pos2, obj7._003C_003E4__this, CS_0024_003C_003E8__locals9.localIndex);
										return;
									}
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num4 = (float)num3 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
				float duration = num4 * 0.001f;
				Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_lastShotTimer = lastShotTimer;
			}
			num3++;
		}
		while (num > (float)num3);
	}

	public virtual void OnSubWeaponCounter(bool skipTriggers = false)
	{
	}

	public override void Cleanup()
	{
		base.Cleanup();
		if (_memoryWhipPool != null)
		{
			_memoryWhipPool.Cleanup();
		}
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				base._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}
}
