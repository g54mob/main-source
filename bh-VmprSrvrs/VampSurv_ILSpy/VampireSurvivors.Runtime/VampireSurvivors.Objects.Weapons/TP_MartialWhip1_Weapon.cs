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

public class TP_MartialWhip1_Weapon : TP_WhipCore1_Weapon
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public Vector2 __pos;

		public int localI;

		public Vector2 __pos2;

		public TP_MartialWhip1_Weapon _003C_003E4__this;

		internal void _003CFireImpactProjectiles_003Eb__0()
		{
			//IL_0172: Expected O, but got I4
			//IL_00c4: Expected O, but got I
			//IL_0079->IL013b: Incompatible stack heights: 1 vs 0
			//IL_009e->IL013b: Incompatible stack heights: 1 vs 0
			//IL_00ec->IL013b: Incompatible stack heights: 1 vs 0
			//IL_010e->IL013b: Incompatible stack heights: 1 vs 0
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
					Weapon weapon = _003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v14 (VampireSurvivors.Objects.Weapons.Weapon)+180]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v14 (VampireSurvivors.Objects.Weapons.Weapon)+180]");
							float2 pos = default(float2);
							Projectile projectile = ((BulletPool)0).SpawnAt(pos, _003C_003E4__this, localI);
							TP_MartialWhip1_Weapon tP_MartialWhip1_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null && tP_MartialWhip1_Weapon._impactPool != null)
							{
								Projectile projectile2 = tP_MartialWhip1_Weapon._impactPool.SpawnAt(pos, _003C_003E4__this, localI);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _impactProjectile;

	protected BulletPool _impactPool;

	public override float SecondaryPPower()
	{
		//IL_006e: Invalid comparison between F4 and I
		//IL_0095: Expected F4, but got I
		//IL_0110: Invalid comparison between F4 and I
		//IL_0137: Expected F4, but got I
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.MaxHp();
			float num3 = default(float);
			float num2 = num3 - 100f;
			float num4 = num2 / 400f;
			float num5 = num4 + 1f;
			float num6 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10A10]");
			if (num6 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10A10]");
				num5 = 0f;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
				WeaponData currentWeaponData = _currentWeaponData;
				if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num7 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
					if (num7 < 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
						num5 = 0f;
					}
					float num8 = currentWeaponData._003CsecondaryPower_003Ek__BackingField * num3;
					float num9 = num3 + num8;
					return num9 * num5;
				}
			}
		}
		throw new NullReferenceException();
	}

	protected override void Awake()
	{
		//IL_0093: Expected I, but got O
		//IL_0136: Expected I, but got O
		base.Awake();
		_explosionType = WeaponType.FIREEXPLOSION;
		_weaponNodeType = WeaponType.TP_HOLYWHIP1_NODE;
		BulletPool impactPool = new BulletPool(_impactProjectile);
		_impactPool = impactPool;
		BulletPool impactPool2 = _impactPool;
		impactPool2.UpperLimit = 100;
		BulletPool impactPool3 = _impactPool;
		impactPool3.IsUncapped = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_MartialWhip1_Weapon>)+370]");
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_MartialWhip1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_impactPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			return;
		}
		throw new NullReferenceException();
	}

	public unsafe void FireImpactProjectiles(Vector2 pos)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0088: Expected I, but got O
		//IL_032b: Expected O, but got F4
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_03c3: Expected O, but got F4
		//IL_01a4: Expected I, but got O
		//IL_01ba: Expected O, but got I
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0231: Expected I, but got O
		//IL_03e0: Expected O, but got I4
		//IL_03f7: Expected I, but got I8
		//IL_021a: Expected I, but got I8
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj5 = default(object);
		object obj4 = obj5 ^ 0;
		object obj6 = default(object);
		float num = (float)obj6 * 1.16f;
		float num2 = (float)obj5 * 1.16f;
		float num3 = (float)pos - num;
		float num4 = (float)obj3 - num2;
		nint num5 = (nint)this;
		float num6 = base.PAmount();
		object obj7 = default(object);
		float num7 = (float)obj7 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
		float num8 = base.PArea();
		float num9 = num7 * 0.32f;
		object obj8 = default(object);
		if ((nint)obj8 <= 0)
		{
			return;
		}
		bool flag = false;
		object obj9 = obj6;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool flag2;
		do
		{
			_003C_003Ec__DisplayClass4_0 obj10 = new _003C_003Ec__DisplayClass4_0();
			obj10._003C_003E4__this = this;
			obj10.localI = (flag ? 1 : 0);
			float num10 = (float)obj8 - 1f;
			if (1f > num10)
			{
				num10 = 1f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm4,edi\"");
			float num11 = num3 + (float)position;
			float num12 = 0f / num10;
			float num13 = num4 + (float)obj2;
			float num14 = num12 * num9;
			float num15 = num11 * 0.5f;
			float num16 = num13 * 0.5f;
			float num17 = (float)obj4 * num14;
			float num18 = (float)obj9 * num14;
			float num19 = num15 + num17;
			float num20 = num16 + num18;
			obj10.__pos = (Vector2)num19;
			float num21 = num4 + (float)obj2;
			float num22 = num3 + (float)position;
			float num23 = num22 * 0.5f;
			float num24 = num21 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj11 = num14 ^ 0;
			object obj12 = obj11 * obj9;
			object obj13 = obj11 * obj4;
			float num25 = (float)obj13 + num23;
			float num26 = (float)obj12 + num24;
			obj10.__pos2 = (Vector2)num25;
			WeaponData currentWeaponData = _currentWeaponData;
			Action action = null;
			nint num27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass4_0._003CFireImpactProjectiles_003Eb__0);
			((Delegate)action).m_target = obj10;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj14 = (nint)0 >> 4;
			object obj15 = obj14 & 1;
			nint num28;
			if (obj15 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num28 = unchecked((nint)6447293664L);
					goto IL_03d7;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num28 = ((Delegate)action).method_ptr;
			goto IL_03d7;
			IL_03d7:
			object obj16 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float num29 = (float)(flag ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
			float duration = num29 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = (nint)obj8 > (flag ? 1 : 0);
			obj9 = obj6;
		}
		while (flag2);
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				GameManager gameMan3 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan3._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		CheckBeginningArcana();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}
}
