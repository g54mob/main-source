using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Clockwork_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<ItemType> _003C_003E9__13_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CUpdateOrologionCount_003Eb__13_0(ItemType x)
		{
			//IL_000e: Expected O, but got I4
			object obj = x - 11;
			return obj == null;
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public WeaponType wt;

		internal bool _003CFindClockWeapons_003Eb__0(Weapon x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = ((Equipment)x)._equipmentType - wt;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected bool _initialisedParticles;

	protected int _orologionCount;

	protected float _oroBonus;

	protected List<WeaponType> _otherClockWeapons;

	protected List<Weapon> _foundClockWeapons;

	protected override void Awake()
	{
		base.Awake();
	}

	public override float PPower()
	{
		float num = base.PAmount();
		object obj = default(object);
		float num2 = (float)obj * 0.333f;
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
				float num5 = num2 + num4;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage2 = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
					float num6 = num5 + num2;
					float num7 = num6 + _oroBonus;
					return num7 * num3;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override float PArea()
	{
		//IL_004c: Invalid comparison between F4 and I4
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
			float num2 = num2 - 1f;
			if (num2 > 0f)
			{
				num2 *= 0.65f;
			}
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				float num3 = num2 + 1f;
				return num3 * currentWeaponData._003Carea_003Ek__BackingField;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		bool flag = ((List<System.Int32Enum>)(object)_otherClockWeapons).Remove((System.Int32Enum)((Equipment)this)._equipmentType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
		if (!_initialisedParticles)
		{
			_initialisedParticles = true;
		}
		_orologionCount = 0;
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
			FireOthers();
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
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0057: Invalid comparison between O and F4
		//IL_0082: Expected F4, but got O
		UpdateOrologionCount();
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
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

	public virtual void FireProjectiles(Vector2 pos)
	{
		//IL_009a: Expected O, but got F4
		//IL_0079: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * ((float)Math.PI * 2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num2 = num * renderer.width;
		float num3 = num2 * 0.35f;
		float num4 = num3 + (float)pos;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Projectile projectile = base.FireOneProjectile((Vector2)num4, 0, _targetTransform);
	}

	private void UpdateOrologionCount()
	{
		//IL_00ac: Expected F4, but got I
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Predicate<System.Int32Enum> match = (Predicate<System.Int32Enum>)(object)_003C_003Ec._003C_003E9__13_0;
		if (_003C_003Ec._003C_003E9__13_0 == null)
		{
			match = (Predicate<System.Int32Enum>)(object)(_003C_003Ec._003C_003E9__13_0 = delegate(ItemType x)
			{
				//IL_000e: Expected O, but got I4
				object obj = x - 11;
				return obj == null;
			});
		}
		List<System.Int32Enum> list = ((List<System.Int32Enum>)(object)config._003CRunPickups_003Ek__BackingField).FindAll(match);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		_orologionCount = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		if ((nint)0 <= (nint)0)
		{
			_oroBonus = 0f;
			return;
		}
		List<ItemType> list2 = config._003CRunPickups_003Ek__BackingField.FindAll((Predicate<ItemType>)(object)match);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v10 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		_oroBonus = 0f;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
	}

	public override bool LevelUp(bool skipFire)
	{
		FindClockWeapons();
		return base.LevelUp(skipFire);
	}

	protected void FireOthers()
	{
		//IL_013d: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_00f4: Expected I, but got O
		//IL_009c->IL0112: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL0112: Incompatible stack heights: 1 vs 0
		//IL_01af->IL0112: Incompatible stack heights: 2 vs 0
		//IL_0234->IL0112: Incompatible stack heights: 3 vs 0
		//IL_0111->IL0005: Incompatible stack heights: 3 vs 0
		List<Weapon> foundClockWeapons = _foundClockWeapons;
		bool flag = _foundClockWeapons == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				if ((nint)obj2 < foundClockWeapons._size)
				{
					List<Weapon> foundClockWeapons2 = _foundClockWeapons;
					if (_foundClockWeapons == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= foundClockWeapons2._size;
					Weapon[] items = foundClockWeapons2._items;
					if (foundClockWeapons2._items == null)
					{
						break;
					}
					object obj3 = items[obj];
					if ((object)items[obj] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v10 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v10 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
					GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					if ((object)gameObject == null)
					{
						break;
					}
					bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj4 != null)
					{
						nint num = (nint)obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v501 @ rax_v33 (Il2CppClass<System.Object>)+4C8] (should have been resolved before IL gen)");
					}
					foundClockWeapons = _foundClockWeapons;
					obj++;
					if (_foundClockWeapons == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void FindClockWeapons()
	{
		//IL_016d: Expected O, but got I4
		//IL_0176: Expected O, but got I4
		//IL_0054: Expected O, but got I
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		List<WeaponType> otherClockWeapons = _otherClockWeapons;
		object obj = 0;
		object obj2 = 0;
		object obj6 = default(object);
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)obj3 >= 0)
			{
				return;
			}
			_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass17_0();
			List<WeaponType> otherClockWeapons2 = _otherClockWeapons;
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)obj4 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v6+20+v57 @ rbx_v2*4]");
			CS_0024_003C_003E8__locals3.wt = WeaponType.VOID;
			List<Weapon> foundClockWeapons = _foundClockWeapons;
			Predicate<Weapon> predicate = delegate(Weapon x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj7 = ((Equipment)x)._equipmentType - CS_0024_003C_003E8__locals3.wt;
				return obj7 == null;
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805EA0E0");
			if ((nint)obj6 == -1)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(CS_0024_003C_003E8__locals3.wt, searchHidden: true);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BCD0");
				}
			}
			otherClockWeapons = _otherClockWeapons;
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TP_Clockwork_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0231: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0259: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0281: Expected O, but got I
		//IL_01c0: Expected O, but got I
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1524);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1524;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1525);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1525;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1573);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1573;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1574);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1574;
		}
		_otherClockWeapons = list;
		_foundClockWeapons = new List<Weapon>();
		base._002Ector();
	}
}
