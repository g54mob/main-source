using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Longsword_SwallowSlice_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public EME_Longsword_SwallowSlice_Weapon _003C_003E4__this;

		public Vector2 pos;
	}

	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public Vector3 Direction;

		public int localIndex;

		public _003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFireSwallowSwing_003Eb__0()
		{
			//IL_024f: Expected O, but got I4
			//IL_00fb: Expected I, but got O
			//IL_0109: Expected I, but got O
			//IL_0119: Expected O, but got I
			//IL_0199: Expected O, but got I4
			//IL_0155: Expected O, but got I
			//IL_018b: Expected O, but got I4
			//IL_01e9: Expected O, but got Ref
			//IL_0084->IL01ef: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL01ef: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass10_0 obj = CS_0024_003C_003E8__locals1;
			EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice;
			EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice2;
			object obj6;
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
					_003C_003Ec__DisplayClass10_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						eME_LongswordProjectile_SwallowSlice = (EME_LongswordProjectile_SwallowSlice)obj3._003C_003E4__this.FireOneProjectile(pos, localIndex);
						if ((object)eME_LongswordProjectile_SwallowSlice == null)
						{
							eME_LongswordProjectile_SwallowSlice2 = null;
							goto IL_0298;
						}
						nint num = (nint)eME_LongswordProjectile_SwallowSlice;
						nint num2 = (nint)typeof(EME_LongswordProjectile_SwallowSlice);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
							if (0 == (nint)typeof(EME_LongswordProjectile_SwallowSlice))
							{
								obj6 = 1;
								goto IL_0271;
							}
						}
						obj6 = 0;
						goto IL_0271;
					}
				}
			}
			throw new NullReferenceException();
			IL_0298:
			if ((object)eME_LongswordProjectile_SwallowSlice2 != null && ((UnityEngine.Object)eME_LongswordProjectile_SwallowSlice2).m_CachedPtr != (IntPtr)0)
			{
				object obj7 = default(object);
				eME_LongswordProjectile_SwallowSlice2.SetDirection((Vector3)(&obj7));
			}
			return;
			IL_0271:
			bool flag2 = obj6 == null;
			eME_LongswordProjectile_SwallowSlice2 = null;
			if (!flag2)
			{
				eME_LongswordProjectile_SwallowSlice2 = eME_LongswordProjectile_SwallowSlice;
			}
			goto IL_0298;
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public float final;

		public EME_Longsword_SwallowSlice_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__1()
		{
			EME_Longsword_SwallowSlice_Weapon eME_Longsword_SwallowSlice_Weapon = _003C_003E4__this;
			float2 position = ((Equipment)eME_Longsword_SwallowSlice_Weapon)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			eME_Longsword_SwallowSlice_Weapon.FireSwallowSwing(pos, final);
		}
	}

	protected readonly Dictionary<WeaponType, string> _glimmerNames;

	private int swallowSliceInterval;

	protected override void Awake()
	{
		base.Awake();
		((Equipment)this)._003CShowInRecap_003Ek__BackingField = false;
	}

	protected unsafe override void OnStart()
	{
		//IL_0087: Expected O, but got Ref
		base.OnStart();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)2381, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		float num = base.PInterval();
		object obj2 = default(object);
		float num2 = (float)obj2 * 0.5f;
		base._003CTotalTime_003Ek__BackingField = num2;
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

	private void UpdateFiringTimer()
	{
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

	private unsafe void AddGlimmerName(WeaponType glimmerWeaponType)
	{
		//IL_005c: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string term = "weaponLang/{" + text + "}name";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryInsert((System.Int32Enum)glimmerWeaponType, (object)translation, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	private unsafe string GetGlimmerName(WeaponType weaponType)
	{
		//IL_0033: Expected I4, but got O
		//IL_0058: Expected O, but got Ref
		if (_glimmerNames != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)weaponType, out object value))
			{
				object obj = default(object);
				object arg = (WeaponType)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
				GameObject context = base.gameObject;
				Debug.LogWarning(message, context);
				return "Glimmer WeaponType not set";
			}
			return (string)value;
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_004b: Expected I4, but got O
		//IL_0070: Expected O, but got Ref
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_03c5: Invalid comparison between O and F4
		//IL_03f0: Expected F4, but got O
		//IL_01a3: Expected O, but got I4
		//IL_01ac: Invalid comparison between F4 and I4
		//IL_02c3: Expected I, but got O
		//IL_02d9: Expected O, but got I
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_01ef: Expected O, but got I4
		//IL_0355: Expected I, but got O
		//IL_054f: Expected I, but got I8
		//IL_055d: Expected O, but got I4
		//IL_0566: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_05b3: Expected O, but got F4
		//IL_0328: Expected I, but got I8
		//IL_0201: Expected I, but got O
		//IL_0217: Expected O, but got I
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_028e: Expected I, but got O
		//IL_0481: Expected I, but got I8
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Expected O, but got Unknown
		//IL_04e6: Invalid comparison between F4 and I4
		//IL_0277: Expected I, but got I8
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (!((Dictionary<System.Int32Enum, object>)(object)_glimmerNames).TryGetValue((System.Int32Enum)2381, out object value))
		{
			object obj = default(object);
			object arg = (WeaponType)obj;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Glimmer weapon types not configured correctly for weapon {0}", (System.ParamsArray)(&obj2));
			GameObject context = base.gameObject;
			Debug.LogWarning(message, context);
			object obj3 = "Glimmer WeaponType not set";
		}
		else
		{
			object obj3 = value;
		}
		Tuple<string, WeaponType> glimmerNameAndType = null;
		_ = 2381;
		stage._glimmerManager.AddNewGlimmerTechniqueToShow(glimmerNameAndType);
		swallowSliceInterval = 20;
		float num = base.PAmount();
		float num2 = 0f * 4f;
		Vector2 vector = default(Vector2);
		bool flag2;
		bool canPause;
		bool flag3;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Action action2;
		if (28f < num2)
		{
			_003C_003Ec__DisplayClass9_0 obj4 = new _003C_003Ec__DisplayClass9_0();
			obj4._003C_003E4__this = this;
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			FireSwallowSwing(vector, 28f);
			float num3 = num2 - 28f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			float num4 = num3 / 28f;
			obj4.final = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			object obj5 = 24;
			bool flag = !(num4 > 0f);
			flag2 = false;
			canPause = false;
			flag3 = skipTriggers;
			if (!flag)
			{
				flag2 = false;
				object obj6 = 500;
				do
				{
					Action action = null;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ r10_v8 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(EME_Longsword_SwallowSlice_Weapon._003CFire_003Eb__9_0);
					((Delegate)action).m_target = this;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ r10_v8 (Il2CppMethodInfo)+4C]");
					object obj7 = (nint)0 >> 4;
					object obj8 = obj7 & 1;
					nint num6;
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ r10_v8 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num6 = unchecked((nint)6447293664L);
							goto IL_046a;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num6 = ((Delegate)action).method_ptr;
					goto IL_046a;
					IL_046a:
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					float duration = (float)obj6 * 0.001f;
					Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
					obj6 += 500;
				}
				while (num4 > (float)(flag2 ? 1 : 0));
				canPause = false;
				flag3 = skipTriggers;
			}
			action2 = null;
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass9_0._003CFire_003Eb__1);
			((Delegate)action2).m_target = obj4;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj9 = (nint)0 >> 4;
			object obj10 = obj9 & 1;
			nint num8;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v668 @ r10_v6 (Il2CppMethodInfo)+52]");
				bool flag4 = (nint)0 == 0;
				num8 = unchecked((nint)6447293664L);
				if (flag4)
				{
					goto IL_0538;
				}
			}
			num8 = ((Delegate)action2).method_ptr;
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			goto IL_0538;
		}
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		FireSwallowSwing(vector, num2);
		Vector2 vector2 = vector;
		flag3 = skipTriggers;
		goto IL_038c;
		IL_038c:
		float num9 = base.PInterval();
		float num10 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj11 = num10 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num11 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			ResetFiringTimer();
		}
		if (!flag3)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		return;
		IL_0538:
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		object obj12 = (flag2 ? 1 : 0) + 1;
		object obj13 = obj12 * 500;
		float num12 = (float)obj13 * 0.001f;
		Timer timer2 = Timers.Register(num12, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
		vector2 = (Vector2)num12;
		goto IL_038c;
	}

	private unsafe void FireSwallowSwing(Vector2 pos, float _amount)
	{
		//IL_004b: Expected O, but got I4
		//IL_0079: Invalid comparison between F4 and I4
		//IL_00d2: Expected O, but got I4
		//IL_028f: Expected I4, but got F4
		//IL_02bd: Invalid comparison between F4 and I4
		//IL_0142: Expected I, but got O
		//IL_0152: Expected O, but got I
		//IL_01d2: Expected O, but got I4
		//IL_018e: Expected O, but got I
		//IL_01c4: Expected O, but got I4
		//IL_0227: Expected O, but got Ref
		//IL_0227: Expected O, but got I4
		_003C_003Ec__DisplayClass10_0 obj = new _003C_003Ec__DisplayClass10_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_swallow, soundConfig, 100f, 5, num);
		if (!(_amount > 0f))
		{
			return;
		}
		bool flag = false;
		Vector3 direction = default(Vector3);
		bool flag2 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Vector3 vector = default(Vector3);
		do
		{
			_003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass10_1();
			CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
			CS_0024_003C_003E8__locals9.Direction = direction;
			_ = 0;
			object obj2 = (flag ? 1 : 0) * swallowSliceInterval;
			bool flag3;
			object obj6;
			if ((nint)obj2 <= 0)
			{
				_003C_003Ec__DisplayClass10_0 obj3 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
				if (!flag2)
				{
					flag3 = false;
					goto IL_0310;
				}
				bool value = ((bool*)(flag2 ? 1 : 0))->m_value;
				nint num2 = (nint)typeof(EME_LongswordProjectile_SwallowSlice);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ r8_v12 (System.Boolean)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v606 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ r8_v12 (System.Boolean)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rax_v40+FFFFFFF8+v607 @ rax_v36*8]");
					if (0 == (nint)typeof(EME_LongswordProjectile_SwallowSlice))
					{
						obj6 = 1;
						goto IL_02e5;
					}
				}
				obj6 = 0;
				goto IL_02e5;
			}
			CS_0024_003C_003E8__locals9.localIndex = (flag ? 1 : 0);
			Action onComplete = delegate
			{
				//IL_024f: Expected O, but got I4
				//IL_00fb: Expected I, but got O
				//IL_0109: Expected I, but got O
				//IL_0119: Expected O, but got I
				//IL_0199: Expected O, but got I4
				//IL_0155: Expected O, but got I
				//IL_018b: Expected O, but got I4
				//IL_01e9: Expected O, but got Ref
				//IL_0084->IL01ef: Incompatible stack heights: 1 vs 0
				//IL_00a6->IL01ef: Incompatible stack heights: 1 vs 0
				_003C_003Ec__DisplayClass10_0 obj7 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
				EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice;
				object obj12;
				EME_LongswordProjectile_SwallowSlice eME_LongswordProjectile_SwallowSlice2;
				if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj7._003C_003E4__this != null)
				{
					GameObject gameObject = obj7._003C_003E4__this.gameObject;
					if ((object)gameObject != null)
					{
						bool flag5 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
						object obj8 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
						if (obj8 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass10_0 obj9 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj9._003C_003E4__this != null)
						{
							Vector2 pos2 = default(Vector2);
							eME_LongswordProjectile_SwallowSlice = (EME_LongswordProjectile_SwallowSlice)obj9._003C_003E4__this.FireOneProjectile(pos2, CS_0024_003C_003E8__locals9.localIndex);
							if ((object)eME_LongswordProjectile_SwallowSlice != null)
							{
								nint num4 = (nint)eME_LongswordProjectile_SwallowSlice;
								nint num5 = (nint)typeof(EME_LongswordProjectile_SwallowSlice);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_LongswordProjectile_SwallowSlice>)+C8]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
									if (0 == (nint)typeof(EME_LongswordProjectile_SwallowSlice))
									{
										obj12 = 1;
										goto IL_0271;
									}
								}
								obj12 = 0;
								goto IL_0271;
							}
							eME_LongswordProjectile_SwallowSlice2 = null;
							goto IL_0298;
						}
					}
				}
				throw new NullReferenceException();
				IL_0298:
				if ((object)eME_LongswordProjectile_SwallowSlice2 != null && ((UnityEngine.Object)eME_LongswordProjectile_SwallowSlice2).m_CachedPtr != (IntPtr)0)
				{
					object obj13 = default(object);
					eME_LongswordProjectile_SwallowSlice2.SetDirection((Vector3)(&obj13));
				}
				return;
				IL_0271:
				bool flag6 = obj12 == null;
				eME_LongswordProjectile_SwallowSlice2 = null;
				if (!flag6)
				{
					eME_LongswordProjectile_SwallowSlice2 = eME_LongswordProjectile_SwallowSlice;
				}
				goto IL_0298;
			};
			float duration = (float)obj2 * 0.001f;
			Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_lastShotTimer = lastShotTimer;
			goto IL_02a7;
			IL_0310:
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ rbx_v8 (System.Boolean)+10]");
				if ((nint)0 != 0)
				{
					((EME_LongswordProjectile_SwallowSlice)flag3).SetDirection((Vector3)(&vector));
				}
			}
			goto IL_02a7;
			IL_02a7:
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			continue;
			IL_02e5:
			bool flag4 = obj6 == null;
			flag3 = false;
			if (!flag4)
			{
				flag3 = flag2;
			}
			goto IL_0310;
		}
		while (_amount > (float)(flag ? 1 : 0));
	}

	public EME_Longsword_SwallowSlice_Weapon()
	{
		Dictionary<WeaponType, string> glimmerNames = new Dictionary<WeaponType, string>();
		_glimmerNames = glimmerNames;
		base._002Ector();
	}

	private void _003CFire_003Eb__9_0()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		FireSwallowSwing(pos, 32f);
	}
}
