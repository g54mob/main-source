using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Props;

public class PropCart : Destructible
{
	private WeaponsFacade _weaponsFacade;

	private bool _hasFired;

	private static Timer _timerEvent;

	private void Construct(WeaponsFacade weaponsFacade)
	{
		_weaponsFacade = weaponsFacade;
	}

	public override void Init(PropType destructibleType)
	{
		base.Init(destructibleType);
		base._003CIsStationary_003Ek__BackingField = true;
		_hasFired = false;
		float2 float5 = base.position;
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
			}
		}
		float2 float6 = default(float2);
		base.position = float6;
	}

	protected unsafe override void OnDestroyed()
	{
		//IL_0120: Expected I, but got O
		//IL_012e: Expected I, but got O
		//IL_013e: Expected O, but got I
		//IL_01be: Expected O, but got I4
		//IL_017a: Expected O, but got I
		//IL_01d3: Expected I4, but got O
		//IL_01b0: Expected O, but got I4
		//IL_02a2->IL039f: Incompatible stack heights: 1 vs 0
		if (_hasFired)
		{
			return;
		}
		_hasFired = true;
		if (!CameraExtensions.IsObjectVisible(_mainCamera, _destructibleRenderer))
		{
			return;
		}
		Weapon weapon;
		bool flag = default(bool);
		bool flag3;
		nint num;
		object obj3;
		bool flag2;
		if (_playerOptions != null)
		{
			_playerOptions.IncreaseDestroyedPropCount(_destructibleType);
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && _weaponsFacade != null)
			{
				weapon = _weaponsFacade.AddHiddenWeapon(WeaponType.CART, gameSessionData._activeCharacter, removeFromStore: true, flag);
				if ((object)weapon == null)
				{
					flag2 = true;
					flag3 = false;
					goto IL_0317;
				}
				num = (nint)weapon;
				nint num2 = (nint)typeof(CartWeapon);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.CartWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.CartWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rax_v53+FFFFFFF8+v462 @ rax_v49*8]");
					if (0 == (nint)typeof(CartWeapon))
					{
						obj3 = 1;
						goto IL_02e4;
					}
				}
				obj3 = 0;
				goto IL_02e4;
			}
		}
		goto IL_02b6;
		IL_0317:
		if (flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v8 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					bool value = ((bool*)(flag3 ? 1 : 0))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v759 @ rax_v33 (System.Boolean)+4B8] (should have been resolved before IL gen)");
					if (_timerEvent != null)
					{
						_timerEvent.Cancel();
					}
					Action onComplete = delegate
					{
						GameSessionData gameSessionData2 = _gameSessionData;
						_weaponsFacade.RemoveHiddenWeapon(WeaponType.CART, gameSessionData2._activeCharacter);
					};
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timerEvent = Timers.Register(5f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_timerEvent = timerEvent;
					return;
				}
				goto IL_02b6;
			}
		}
		Debug.LogError("Something went wrong, the player should have a hidden weapon of type CART.");
		return;
		IL_02b6:
		throw new NullReferenceException();
		IL_02e4:
		bool flag5 = obj3 == null;
		flag2 = (byte)num != 0;
		flag3 = false;
		if (!flag5)
		{
			flag2 = (byte)num != 0;
			flag3 = (byte)(int)weapon != 0;
		}
		goto IL_0317;
	}

	public PropCart()
	{
		//IL_0036: Expected I, but got O
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003COnDestroyed_003Eb__5_0()
	{
		GameSessionData gameSessionData = _gameSessionData;
		_weaponsFacade.RemoveHiddenWeapon(WeaponType.CART, gameSessionData._activeCharacter);
	}
}
