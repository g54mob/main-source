using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Evil2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__13_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitWeapon_003Eb__13_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 1467;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private bool _initialisedParticles;

	private PhaserSprite _cursor;

	private bool _hasGemini;

	private Timer rainStopTimer;

	private TP_Evil1_Weapon _baseWeapon;

	private PhaserSprite _sDarkness;

	public bool HasNightmare;

	private float _radius = 32f;

	public virtual float PlayerFacing => 1f;

	public virtual bool IsPrimaryWeapon => true;

	public override float PPower()
	{
		float hitBoxDelay = base.HitBoxDelay;
		float num = base.PDuration();
		float num2 = hitBoxDelay / hitBoxDelay;
		bool flag = !(1f < num2);
		float num3 = 1f;
		if (!flag)
		{
			num3 = num2;
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num4 = currentWeaponData._003Cpower_003Ek__BackingField * num2;
				float num5 = num4 * num3;
				return num2 + num5;
			}
		}
		throw new NullReferenceException();
	}

	protected override void Awake()
	{
		//IL_00f3: Expected O, but got I4
		base.Awake();
		_hasGemini = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Evil02");
		_cursor = cursor;
		PhaserSprite phaserSprite = _cursor.setDepth(1);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				PhaserWorld instance = PhaserWorld.Instance;
				PhaserSprite phaserSprite2 = instance.AddPhaserSprite(pos, "vfx", "stageShadows");
				PhaserSprite component = phaserSprite2.setOrigin(0f, (float?)(object)0);
				PhaserSprite component2 = RenderingExtensions.SetScrollFactor(component, 0f);
				float xScale = renderer2.width / 1.5999999f;
				PhaserSprite phaserSprite3 = RenderingExtensions.SetScale(component2, xScale, renderer.height);
				PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
				PhaserSprite phaserSprite5 = phaserSprite4.setDepth(10000);
				GameObject gameObject2 = phaserSprite5.gameObject;
				((UnityEngine.Object)gameObject2).SetName("Evil2Shadows");
				_sDarkness = phaserSprite5;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_030e: Expected I, but got O
		//IL_0074: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_033f: Expected I, but got O
		//IL_0112: Expected O, but got I4
		//IL_00ce: Expected O, but got I
		//IL_0104: Expected O, but got I4
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		CharacterWeaponsManager weaponsManager = characterController2._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__13_0;
		bool flag = _003C_003Ec._003C_003E9__13_0 != null;
		nint num3 = unchecked((nint)null);
		if (!flag)
		{
			Predicate<Equipment> predicate = (_003C_003Ec._003C_003E9__13_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj6 = x._equipmentType - 1467;
				return obj6 == null;
			});
			num3 = unchecked((nint)null);
			match = predicate;
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField.Find(match);
		bool flag2 = (object)equipment == null;
		Equipment baseWeapon = equipment;
		if (flag2)
		{
			goto IL_034c;
		}
		num3 = (nint)equipment;
		nint num4 = (nint)typeof(TP_Evil1_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v457 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil1_Weapon>)+130]");
		object obj4;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ rax_v47+FFFFFFF8+v458 @ rax_v42*8]");
			if (0 == (nint)typeof(TP_Evil1_Weapon))
			{
				obj4 = 1;
				goto IL_035b;
			}
		}
		obj4 = 0;
		goto IL_035b;
		IL_034c:
		_baseWeapon = (TP_Evil1_Weapon)baseWeapon;
		TP_Evil1_Weapon baseWeapon2 = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon2).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager2 = characterController3._weaponsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0AA0");
			object obj5 = default(object);
			if (obj5 != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
				CharacterWeaponsManager weaponsManager3 = characterController4._weaponsManager;
				bool flag3 = ((List<object>)(object)((EquipmentManager)weaponsManager3)._003CActiveEquipment_003Ek__BackingField).Remove((object)_baseWeapon);
			}
			_baseWeapon.Cleanup();
			VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
			CharacterWeaponsManager weaponsManager4 = characterController5._weaponsManager;
			bool flag4 = ((EquipmentManager)weaponsManager4)._003CHiddenEquipment_003Ek__BackingField.Remove(_baseWeapon);
			TP_Evil1_Weapon baseWeapon3 = _baseWeapon;
			baseWeapon3._003CCanFireNormally_003Ek__BackingField = false;
			GameObject gameObject = _baseWeapon.gameObject;
			gameObject.SetActive(value: true);
		}
		return;
		IL_035b:
		bool flag5 = obj4 == null;
		baseWeapon = null;
		if (!flag5)
		{
			baseWeapon = equipment;
		}
		goto IL_034c;
	}

	public override void InternalUpdate()
	{
		//IL_035a: Expected I, but got O
		//IL_036a: Expected O, but got I
		//IL_000a: Expected I, but got O
		//IL_0025: Expected O, but got I
		//IL_0052: Expected I, but got O
		//IL_0062: Expected O, but got I
		//IL_01d4: Invalid comparison between I4 and F4
		//IL_023d: Invalid comparison between F4 and I4
		//IL_0200: Invalid comparison between F4 and I4
		//IL_0265: Expected F4, but got I4
		//IL_00db: Expected I, but got O
		//IL_00eb: Expected O, but got I
		//IL_0220: Expected F4, but got I4
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil2_Weapon>)+490]");
		object obj = 0;
		float num2 = base.PInterval();
		float num3 = deltaTime * 1000f;
		bool flag = (base._003CTotalTime_003Ek__BackingField = num3 + base._003CTotalTime_003Ek__BackingField) < deltaTime;
		TP_Evil2_Weapon tP_Evil2_Weapon = this;
		if (!flag)
		{
			nint num4 = (nint)this;
			base._003CTotalTime_003Ek__BackingField = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil2_Weapon>)+5D0]");
			obj = 0;
			bool isPrimaryWeapon = IsPrimaryWeapon;
			bool flag2 = !isPrimaryWeapon;
			tP_Evil2_Weapon = this;
			if (!flag2)
			{
				nint num5 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil2_Weapon>)+4C0]");
				obj = 0;
				base.Fire();
				TP_Evil1_Weapon baseWeapon = _baseWeapon;
				tP_Evil2_Weapon = (TP_Evil2_Weapon)(object)typeof(UnityEngine.Object);
				if ((object)_baseWeapon != null)
				{
					bool flag3 = ((UnityEngine.Object)baseWeapon).m_CachedPtr == (IntPtr)0;
					tP_Evil2_Weapon = (TP_Evil2_Weapon)(object)typeof(UnityEngine.Object);
					if (!flag3)
					{
						tP_Evil2_Weapon = (TP_Evil2_Weapon)(object)_baseWeapon;
						nint num6 = (nint)tP_Evil2_Weapon;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rax_v37 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil2_Weapon>)+4C0]");
						obj = 0;
						tP_Evil2_Weapon.Fire();
					}
				}
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float2 position3 = default(float2);
		PhaserSprite phaserSprite = _cursor.setPosition(position3);
		NightmareCheck();
		float num9;
		if (!HasNightmare)
		{
			float alpha = _sDarkness.Alpha;
			float deltaTime2 = PauseSystem.DeltaTime;
			float num7 = deltaTime2 * 1000f;
			float num8 = num7 * 0.001f;
			if (!(0f > alpha))
			{
				num9 = alpha - num8;
				if (num9 < 0f)
				{
					num9 = 0f;
				}
			}
			else
			{
				float num10 = num8 + alpha;
				bool flag4 = !(num10 > 0f);
				num9 = num10;
				if (!flag4)
				{
					num9 = 0f;
				}
			}
		}
		else
		{
			float alpha2 = _sDarkness.Alpha;
			float deltaTime3 = PauseSystem.DeltaTime;
			float num11 = deltaTime3 * 1000f;
			float num12 = num11 * 0.001f;
			if (!(1f > alpha2))
			{
				num9 = alpha2 - num12;
				if (num9 < 1f)
				{
					num9 = 1f;
				}
			}
			else
			{
				float num13 = num12 + alpha2;
				bool flag5 = !(num13 > 1f);
				num9 = num13;
				if (!flag5)
				{
					num9 = 1f;
				}
			}
		}
		PhaserSprite phaserSprite2 = _sDarkness.setAlpha(num9);
	}

	protected float CalcRadAngle(float x1, float y1, float x2, float y2)
	{
		float num = x2 - x1;
		object obj = default(object);
		float result = (float)obj - y1;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		return result;
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
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005c: Invalid comparison between O and F4
		//IL_0087: Expected F4, but got O
		float2 position = _cursor.position;
		Vector2 vector = default(Vector2);
		FireProjectiles(vector);
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public void FireProjectiles(Vector2 pos)
	{
		//IL_0184->IL0132: Incompatible stack heights: 1 vs 0
		//IL_0132->IL0139: Incompatible stack heights: 1 vs 0
		DisplayCursorVFX(1, 250f);
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj = obj2 - obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform);
			if (!_hasGemini)
			{
				return;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						object obj4 = obj2 - obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
						Vector2 pos2 = default(Vector2);
						Projectile projectile2 = base.FireOneProjectile(pos2, 0, _targetTransform);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_explodeOnExpire = true;
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager2 = core._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_hasGemini = true;
		}
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_0112: Expected O, but got Ref
		//IL_0169->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0113: Incompatible stack heights: 1 vs 0
		//IL_00e8->IL0113: Incompatible stack heights: 1 vs 0
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
			if ((object)pool != null)
			{
				SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
				if ((object)_cursor != null)
				{
					Transform transform = _cursor.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						if ((object)_cursor != null)
						{
							Transform transform2 = _cursor.transform;
							if ((object)transform2 != null)
							{
								Vector3 localEulerAngles = transform2.localEulerAngles;
								if ((object)objectComponent != null)
								{
									object obj = default(object);
									float angle = default(float);
									string texture = default(string);
									string frame = default(string);
									bool flip = default(bool);
									objectComponent.Display(_times, _duration, (Vector3)(&obj), angle, texture, frame, flip);
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

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = _cursor.setVisible(visible);
		TP_Evil1_Weapon baseWeapon = _baseWeapon;
		if ((object)_baseWeapon != null && ((UnityEngine.Object)baseWeapon).m_CachedPtr != (IntPtr)0)
		{
			_baseWeapon.SetVisible(visible);
		}
	}

	private float Approach(float start, float end, float shift)
	{
		if (!(end > start))
		{
			float num = start - shift;
			if (num < end)
			{
				num = end;
			}
			return num;
		}
		float num2 = start + shift;
		if (num2 > end)
		{
			num2 = end;
		}
		return num2;
	}

	private unsafe void NightmareCheck()
	{
		//IL_0499: Expected I, but got O
		//IL_0366: Expected I, but got O
		//IL_004f: Expected O, but got Ref
		//IL_03ca: Expected O, but got I
		float num = base.PArea();
		float num2 = _radius * 0f;
		float num3 = num2 * 0.01f;
		float num4 = num3 * num3;
		HasNightmare = false;
		nint num5 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v6 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num6 = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._characters != null)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			num6 = (nint)GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v15 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+B8]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v15 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+B8]");
				num6 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v15 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+B8]");
					((Stage)0).CalculateEnemySpeed();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool IsCharacterInRange(Vector2 charPos, Vector2 projPos, float radiusSqrd)
	{
		//IL_0049: Invalid comparison between F4 and O
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		object obj4 = projPos - charPos;
		object obj5 = obj * obj;
		object obj6 = obj4 * obj4;
		object obj7 = obj5 + obj6;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)radiusSqrd) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7);
		return !flag;
	}
}
