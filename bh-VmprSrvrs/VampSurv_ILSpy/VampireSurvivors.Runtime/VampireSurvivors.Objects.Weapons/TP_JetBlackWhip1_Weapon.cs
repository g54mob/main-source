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

public class TP_JetBlackWhip1_Weapon : TP_WhipCore1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public float __amount;

		public float __radius;

		public Vector2 ownerPos;

		public Vector2 pos;

		public Vector2 direction;

		public TP_JetBlackWhip1_Weapon _003C_003E4__this;

		public bool _flipX;
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public int localI;

		public _003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireImpactProjectiles_003Eb__0()
		{
			//IL_02bf: Expected O, but got I4
			//IL_00c4->IL0263: Incompatible stack heights: 1 vs 0
			//IL_00f3->IL0263: Incompatible stack heights: 1 vs 0
			//IL_0112->IL0263: Incompatible stack heights: 1 vs 0
			//IL_0134->IL0263: Incompatible stack heights: 1 vs 0
			//IL_01e3->IL0263: Incompatible stack heights: 1 vs 0
			//IL_019f->IL0263: Incompatible stack heights: 1 vs 0
			//IL_0212->IL0263: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass4_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				float num = obj.__amount - 1f;
				if (1f < num)
				{
				}
				if ((object)obj._003C_003E4__this != null)
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
							TP_JetBlackWhip1_Weapon tP_JetBlackWhip1_Weapon = obj3._003C_003E4__this;
							if ((object)obj3._003C_003E4__this != null && CS_0024_003C_003E8__locals1 != null && tP_JetBlackWhip1_Weapon._impactPool != null)
							{
								float2 pos = default(float2);
								Projectile projectile = tP_JetBlackWhip1_Weapon._impactPool.SpawnAt(pos, obj3._003C_003E4__this, localI);
								if ((object)projectile != null)
								{
									_003C_003Ec__DisplayClass4_0 obj4 = CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals1 == null)
									{
										goto IL_0263;
									}
									ArcadeSprite arcadeSprite = projectile.setFlipX(obj4._flipX);
								}
								_003C_003Ec__DisplayClass4_0 obj5 = CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals1 != null)
								{
									TP_JetBlackWhip1_Weapon tP_JetBlackWhip1_Weapon2 = obj5._003C_003E4__this;
									if ((object)obj5._003C_003E4__this != null)
									{
										if (tP_JetBlackWhip1_Weapon2._explodeOnExpire)
										{
											Projectile projectile2 = obj5._003C_003E4__this.SpawnExplosionAt(pos, 0, 1, 0f);
										}
										return;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0263;
			IL_0263:
			throw new NullReferenceException();
		}
	}

	private Projectile _impactProjectile;

	protected BulletPool _impactPool;

	protected override void Awake()
	{
		base.Awake();
		_explosionType = WeaponType.RAYEXPLOSION;
		_weaponNodeType = WeaponType.TP_LEMURIA1_NODE;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0093: Expected I, but got O
		//IL_0136: Expected I, but got O
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		BulletPool impactPool = new BulletPool(_impactProjectile);
		_impactPool = impactPool;
		BulletPool impactPool2 = _impactPool;
		impactPool2.UpperLimit = 100;
		BulletPool impactPool3 = _impactPool;
		impactPool3.IsUncapped = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+370]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_impactPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v418 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_impactPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void FireImpactProjectiles(Vector2 pos)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0153: Expected O, but got F4
		//IL_015d: Expected I, but got O
		//IL_03b0: Invalid comparison between F4 and I4
		//IL_0246: Expected I, but got O
		//IL_025c: Expected O, but got I
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_02d3: Expected I, but got O
		//IL_0318: Expected O, but got I4
		//IL_032f: Expected I, but got I8
		//IL_02bc: Expected I, but got I8
		_003C_003Ec__DisplayClass4_0 obj = new _003C_003Ec__DisplayClass4_0();
		Vector2 pos2 = default(Vector2);
		obj.pos = pos2;
		obj._003C_003E4__this = this;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		obj.ownerPos = position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon+<>c__DisplayClass4_0)+24]");
		object obj3 = default(object);
		object obj2 = obj3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Vector2 vector = default(Vector2);
		obj.direction = vector;
		float num = (float)vector * 1.16f;
		Vector2 ownerPos = obj.ownerPos;
		Vector2 pos3 = obj.pos;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref ownerPos) < System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref pos3);
		object obj4 = obj.ownerPos - obj.pos;
		bool flag2 = obj4 == null;
		float num2 = (float)obj3 * 1.16f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flipX = flag4 & flag3;
		obj._flipX = flipX;
		float num3 = (float)obj.pos - num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_JetBlackWhip1_Weapon+<>c__DisplayClass4_0)+24]");
		float num4 = 0f - num2;
		float num5 = num4 - 0.16f;
		obj.pos = (Vector2)num3;
		nint num6 = (nint)this;
		float num7 = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		float num8 = default(float);
		obj.__amount = num8;
		float num9 = base.PArea();
		float _radius = num8 * 0.5f;
		obj.__radius = _radius;
		bool flag5 = false;
		object obj8;
		Action action;
		float num12;
		WeaponData currentWeaponData;
		float num13;
		float duration;
		Timer lastShotTimer;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		for (bool flag6 = false; obj.__amount > (float)(flag6 ? 1 : 0); obj8 = 24, ((Delegate)action).extra_arg = unchecked((nint)6447293568L), num12 = (float)(flag5 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField, num13 = num12 + 1f, duration = num13 * 0.001f, lastShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false), _lastShotTimer = lastShotTimer, flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0, flag6 = flag5)
		{
			_003C_003Ec__DisplayClass4_1 obj5 = new _003C_003Ec__DisplayClass4_1();
			obj5.CS_0024_003C_003E8__locals1 = obj;
			obj5.localI = (flag5 ? 1 : 0);
			currentWeaponData = _currentWeaponData;
			action = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass4_1._003CFireImpactProjectiles_003Eb__0);
			((Delegate)action).m_target = obj5;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num11;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num11 = unchecked((nint)6447293664L);
					continue;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num11 = ((Delegate)action).method_ptr;
		}
	}

	protected override void OnDestroy()
	{
		if (_impactPool != null)
		{
			_impactPool.Destroy();
			_impactPool = null;
		}
		base.OnDestroy();
	}

	public override void Cleanup()
	{
		if (_impactPool != null)
		{
			_impactPool.Cleanup();
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				_explodeOnExpire = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}
}
