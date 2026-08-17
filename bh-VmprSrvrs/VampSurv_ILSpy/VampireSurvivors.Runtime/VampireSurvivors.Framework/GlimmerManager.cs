using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Framework;

public class GlimmerManager
{
	private bool m_isFirstGlimmering;

	private EME_Weapon m_currentFirstGlimmeringWeapon;

	public bool IsFirstGlimmering => m_isFirstGlimmering;

	public void AddNewGlimmerTechniqueToShow(Tuple<string, WeaponType> glimmerNameAndType)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_00bc: Expected I, but got O
		//IL_00db: Expected O, but got I
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CGlimmerCarouselEnabled_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			object signal = (IntPtr)obj3;
			bool requireDeclaration = default(bool);
			core2._signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
		}
	}

	public bool SetFirstGlimmering(EME_Weapon firstGlimmeringWeapon)
	{
		if (m_isFirstGlimmering)
		{
			return false;
		}
		string text = firstGlimmeringWeapon?.ToString();
		string message = "<color=cyan><GlimmerManager.SetFirstGlimmering> first glimmering set to true with weapon :" + text + "</color>";
		Debug.Log(message);
		m_isFirstGlimmering = true;
		m_currentFirstGlimmeringWeapon = firstGlimmeringWeapon;
		Action onComplete = ClearFirstGlimmering;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return true;
	}

	private void ClearFirstGlimmering()
	{
		string text = (((object)m_currentFirstGlimmeringWeapon == null) ? null : m_currentFirstGlimmeringWeapon.ToString());
		string message = "<color=cyan><GlimmerManager.ClearFirstGlimmering> first glimmering cleared for : " + text + "</color>";
		Debug.Log(message);
		m_isFirstGlimmering = false;
		m_currentFirstGlimmeringWeapon = null;
	}
}
