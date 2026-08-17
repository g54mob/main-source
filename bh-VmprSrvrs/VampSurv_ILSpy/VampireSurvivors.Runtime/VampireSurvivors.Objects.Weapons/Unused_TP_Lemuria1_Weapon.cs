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

public class Unused_TP_Lemuria1_Weapon : TP_WhipCore1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public Vector2 spikePos;

		public float __radius;

		public int _right;

		public Unused_TP_Lemuria1_Weapon _003C_003E4__this;

		public bool _flipX;
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public int localI;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireSpikes_003Eb__0()
		{
			//IL_01db: Expected O, but got I4
			//IL_00a8->IL01a4: Incompatible stack heights: 1 vs 0
			//IL_00d7->IL01a4: Incompatible stack heights: 1 vs 0
			//IL_00f6->IL01a4: Incompatible stack heights: 1 vs 0
			//IL_0118->IL01a4: Incompatible stack heights: 1 vs 0
			//IL_0183->IL01a4: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
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
					_003C_003Ec__DisplayClass4_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						Unused_TP_Lemuria1_Weapon unused_TP_Lemuria1_Weapon = obj3._003C_003E4__this;
						if ((object)obj3._003C_003E4__this != null && CS_0024_003C_003E8__locals1 != null && unused_TP_Lemuria1_Weapon._spikePool != null)
						{
							float2 pos = default(float2);
							Projectile projectile = unused_TP_Lemuria1_Weapon._spikePool.SpawnAt(pos, obj3._003C_003E4__this, localI);
							if ((object)projectile == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass4_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								ArcadeSprite arcadeSprite = projectile.setFlipX(obj4._flipX);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected BulletPool _spikePool;

	protected override void Awake()
	{
		base.Awake();
		_weaponNodeType = WeaponType.TP_LEMURIA1_NODE;
	}

	protected override void OnStart()
	{
		//IL_00bf: Expected I, but got O
		//IL_0162: Expected I, but got O
		base.OnStart();
		if (_spikePool == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_LEMURIA1_SPIKE);
			BulletPool spikePool = new BulletPool(projectilePrefab);
			_spikePool = spikePool;
			BulletPool spikePool2 = _spikePool;
			spikePool2.UpperLimit = 100;
			BulletPool spikePool3 = _spikePool;
			spikePool3.IsUncapped = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_spikePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_spikePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public Projectile CreateSpikeProjectile(float2 pos, int index)
	{
		//IL_0161: Expected I, but got O
		//IL_0279: Expected I, but got O
		if (_spikePool != null)
		{
			goto IL_02d3;
		}
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_LEMURIA1_SPIKE);
			BulletPool spikePool = new BulletPool(projectilePrefab);
			_spikePool = spikePool;
			BulletPool spikePool2 = _spikePool;
			if (_spikePool != null)
			{
				spikePool2.UpperLimit = 100;
				BulletPool spikePool3 = _spikePool;
				if (_spikePool != null)
				{
					spikePool3.IsUncapped = true;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							ArcadePhysics physics = s_scene.physics;
							if ((object)s_scene.physics != null)
							{
								GameManager core = GM.Core;
								if ((object)GM.Core != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+350]");
									ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
									nint num = (nint)this;
									if (physics.add != null)
									{
										ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
										CallbackContext callbackContext = default(CallbackContext);
										Collider collider = physics.add.overlap(_spikePool, core.Enemies, collideCallback, processCallback, callbackContext);
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene2 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												ArcadePhysics physics2 = s_scene2.physics;
												if ((object)s_scene2.physics != null)
												{
													GameManager core2 = GM.Core;
													if ((object)GM.Core != null)
													{
														PhysicsManager physicsManager = core2._physicsManager;
														if (core2._physicsManager != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Unused_TP_Lemuria1_Weapon>)+3A0]");
															ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
															nint num2 = (nint)this;
															if (physics2.add != null)
															{
																Collider collider2 = physics2.add.overlap(_spikePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
																goto IL_02d3;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_030f;
		IL_030f:
		return (Projectile)(object)new NullReferenceException();
		IL_02d3:
		if (_spikePool != null)
		{
			return _spikePool.SpawnAt(pos, this, index);
		}
		goto IL_030f;
	}

	public unsafe void FireSpikes(Vector2 spikePos, bool _flipX)
	{
		//IL_006f: Expected I4, but got I8
		//IL_0123: Expected I, but got O
		//IL_0139: Expected O, but got I
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_01b0: Expected I, but got O
		//IL_0207: Expected O, but got I4
		//IL_021e: Expected I, but got I8
		//IL_0199: Expected I, but got I8
		_003C_003Ec__DisplayClass4_0 obj = new _003C_003Ec__DisplayClass4_0();
		obj.spikePos = spikePos;
		obj._003C_003E4__this = this;
		obj._flipX = _flipX;
		float num = base.PAmount();
		obj.__radius = 0.24f;
		bool flag = obj._flipX;
		int right = -1;
		if (!flag)
		{
			right = 1;
		}
		obj._right = right;
		if ((nint)spikePos <= 0)
		{
			return;
		}
		bool flag2 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass4_1 obj2 = new _003C_003Ec__DisplayClass4_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			int localI = (flag2 ? 1 : 0) + 1;
			obj2.localI = localI;
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass4_1._003CFireSpikes_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num3;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v346 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_01fe;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num3 = ((Delegate)action).method_ptr;
			goto IL_01fe;
			IL_01fe:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num4 = (float)(flag2 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float duration = num4 * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
		}
		while ((nint)spikePos > (flag2 ? 1 : 0));
	}

	protected override void OnDestroy()
	{
		if (_spikePool != null)
		{
			_spikePool.Destroy();
			_spikePool = null;
		}
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_spikePool != null)
		{
			_spikePool.Cleanup();
		}
		if (_nodePool != null)
		{
			_nodePool.Cleanup();
		}
		((Weapon)this).Cleanup();
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
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
		CheckBeginningArcana();
	}
}
