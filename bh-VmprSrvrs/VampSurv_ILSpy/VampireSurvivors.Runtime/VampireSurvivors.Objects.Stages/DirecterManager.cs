using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

[Serializable]
public class DirecterManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static DOGetter<float> _003C_003E9__22_0;

		public static DOSetter<float> _003C_003E9__22_1;

		public static DOGetter<float> _003C_003E9__35_0;

		public static DOSetter<float> _003C_003E9__35_1;

		public static DOGetter<float> _003C_003E9__37_0;

		public static DOSetter<float> _003C_003E9__37_1;

		public static DOGetter<float> _003C_003E9__38_0;

		public static DOSetter<float> _003C_003E9__38_1;

		public static DOGetter<float> _003C_003E9__39_0;

		public static DOSetter<float> _003C_003E9__39_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CUpdate_003Eb__22_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CUpdate_003Eb__22_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}

		internal float _003CStartPhase2_003Eb__35_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CStartPhase2_003Eb__35_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}

		internal float _003CStartPhase3_003Eb__37_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CStartPhase3_003Eb__37_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}

		internal float _003CStartPhase4_003Eb__38_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CStartPhase4_003Eb__38_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}

		internal float _003CStartPhase5_003Eb__39_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CStartPhase5_003Eb__39_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public DirecterManager _003C_003E4__this;

		public AudioSource sound;

		public TweenCallback _003C_003E9__1;

		internal void _003CStartPhase0_003Eb__0()
		{
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleAudio.DOFade(sound, 0f, 1.1f);
			TweenCallback tweenCallback = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				tweenCallback = (_003C_003E9__1 = delegate
				{
					object obj = sound;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
					AudioSource.Stop_Injected((IntPtr)0, true);
					GameObject gameObject = sound.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenCallback tweenCallback2 = _003C_003E4__this.StartPhase1;
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CStartPhase0_003Eb__1()
		{
			object obj = sound;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
			AudioSource.Stop_Injected((IntPtr)0, true);
			GameObject gameObject = sound.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public AudioSource currentSound;

		internal void _003COnOnlineStageSwitch_003Eb__0()
		{
			DestroySound(currentSound);
		}
	}

	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public AudioSource sound1;

		public DirecterManager _003C_003E4__this;

		public int phaseSwitch;

		public int soundPhase;

		public TweenCallback _003C_003E9__2;

		public TweenCallback _003C_003E9__3;

		public TweenCallback _003C_003E9__1;

		public TweenCallback _003C_003E9__5;

		public TweenCallback _003C_003E9__6;

		public TweenCallback _003C_003E9__7;

		public TweenCallback _003C_003E9__8;

		internal void _003CCheckTime1_003Eb__0()
		{
			sound1.volume = 0f;
		}

		internal void _003CCheckTime1_003Eb__1()
		{
			DirecterManager directerManager = _003C_003E4__this;
			if (directerManager._currentPhase < phaseSwitch)
			{
				return;
			}
			directerManager.RemoveTimers();
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleAudio.DOFade(sound1, 0f, 1.2f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 20;
					_ = 0;
				}
			}
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					DestroySound(sound1);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenCallback tweenCallback2 = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				tweenCallback2 = (_003C_003E9__3 = delegate
				{
					_003C_003E4__this.PerformChangePhase(soundPhase, phaseSwitch);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CCheckTime1_003Eb__2()
		{
			DestroySound(sound1);
		}

		internal void _003CCheckTime1_003Eb__3()
		{
			_003C_003E4__this.PerformChangePhase(soundPhase, phaseSwitch);
		}

		internal void _003CCheckTime1_003Eb__4()
		{
			DirecterManager directerManager = _003C_003E4__this;
			if (directerManager._currentPhase < phaseSwitch)
			{
				directerManager.RemoveTimers();
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleAudio.DOFade(sound1, 0f, 0.85f);
				TweenCallback tweenCallback = _003C_003E9__7;
				if (_003C_003E9__7 == null)
				{
					tweenCallback = (_003C_003E9__7 = delegate
					{
						DestroySound(sound1);
					});
				}
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				TweenCallback tweenCallback2 = _003C_003E9__8;
				if (_003C_003E9__8 == null)
				{
					tweenCallback2 = (_003C_003E9__8 = delegate
					{
						_003C_003E4__this.CheckTime1(soundPhase, phaseSwitch, fadeIn: false);
					});
				}
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v31 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				return;
			}
			directerManager.RemoveTimers();
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleAudio.DOFade(sound1, 0f, 0.85f);
			TweenCallback tweenCallback3 = _003C_003E9__5;
			if (_003C_003E9__5 == null)
			{
				tweenCallback3 = (_003C_003E9__5 = delegate
				{
					DestroySound(sound1);
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			TweenCallback tweenCallback4 = _003C_003E9__6;
			if (_003C_003E9__6 == null)
			{
				tweenCallback4 = (_003C_003E9__6 = delegate
				{
					_003C_003E4__this.PerformChangePhase(soundPhase, phaseSwitch);
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CCheckTime1_003Eb__5()
		{
			DestroySound(sound1);
		}

		internal void _003CCheckTime1_003Eb__6()
		{
			_003C_003E4__this.PerformChangePhase(soundPhase, phaseSwitch);
		}

		internal void _003CCheckTime1_003Eb__7()
		{
			DestroySound(sound1);
		}

		internal void _003CCheckTime1_003Eb__8()
		{
			_003C_003E4__this.CheckTime1(soundPhase, phaseSwitch, fadeIn: false);
		}
	}

	private Background6 _background6;

	private Stage _stage;

	private int _currentPhase;

	private float _combatTimer;

	private List<Tween> _bgmTimers;

	private Tween _timer0;

	private bool _quickDebug;

	private bool _startedPhase2;

	private bool _startedPhase4;

	private bool _startedPhase3;

	private bool _startedPhase5;

	private AudioSource _currentBgm;

	private float _volume;

	private DirecterAudioManager _directerAudioManager;

	private List<List<float>> _delays;

	private List<BgmType> _soundKeys;

	private const float ThresholdPhase1 = 30.000002f;

	private const float ThresholdPhase2 = 60.000004f;

	private const float ThresholdPhase3 = 60.000004f;

	private const float ThresholdPhase4 = 45.000004f;

	private const float _soundTweenDuration = 0.85f;

	public DirecterManager(Background6 background6)
	{
		//IL_0064: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_0b69: Expected O, but got I
		//IL_013a: Expected O, but got I
		//IL_0b91: Expected O, but got I
		//IL_01ad: Expected O, but got I
		//IL_0bb9: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_025a: Expected O, but got I
		//IL_02bd: Expected O, but got I
		//IL_0bfd: Expected O, but got I
		//IL_0330: Expected O, but got I
		//IL_0c25: Expected O, but got I
		//IL_03a4: Expected O, but got I
		//IL_03dd: Expected O, but got I
		//IL_0440: Expected O, but got I
		//IL_0c69: Expected O, but got I
		//IL_04b3: Expected O, but got I
		//IL_0c91: Expected O, but got I
		//IL_0527: Expected O, but got I
		//IL_0560: Expected O, but got I
		//IL_05c4: Expected O, but got I
		//IL_0627: Expected O, but got I
		//IL_0681: Expected O, but got I
		//IL_0cf1: Expected O, but got I
		//IL_06eb: Expected O, but got I
		//IL_0d19: Expected O, but got I
		//IL_0755: Expected O, but got I
		//IL_0d41: Expected O, but got I
		//IL_07bf: Expected O, but got I
		//IL_0d69: Expected O, but got I
		//IL_0829: Expected O, but got I
		//IL_0d91: Expected O, but got I
		//IL_0893: Expected O, but got I
		//IL_09ef: Expected O, but got I
		//IL_09f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Expected O, but got Unknown
		//IL_0a64: Expected O, but got I
		//IL_0dd9: Expected O, but got I4
		//IL_0a4f: Expected O, but got I8
		//IL_0af6: Expected O, but got I4
		//IL_0af6: Expected O, but got I
		//IL_0aff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b04: Expected O, but got Unknown
		//IL_0e15: Expected O, but got I
		_currentPhase = 1;
		List<Tween> bgmTimers = new List<Tween>();
		_bgmTimers = bgmTimers;
		List<List<float>> list = new List<List<float>>();
		List<float> list2 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA63B0");
		List<float> list3 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rdx_v10+18]");
		float item = default(float);
		if (num >= 0)
		{
			list3.AddWithResize(8943f);
			item = 8943f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1175174144;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rdx_v11+18]");
		if (num2 >= 0)
		{
			list3.AddWithResize(17886f);
			item = 17886f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1183562752;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdx_v12+18]");
		if (num3 >= 0)
		{
			list3.AddWithResize(26797f);
			item = 26797f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1188125184;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdx_v13+18]");
		if (num4 >= 0)
		{
			list3.AddWithResize(35733f);
			item = 35733f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1191941376;
		}
		((List<float>)(object)list).Add(item);
		List<float> list4 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdx_v16+18]");
		if (num5 >= 0)
		{
			list4.AddWithResize(17852f);
			item = 17852f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1183545344;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v28+18]");
		if (num6 >= 0)
		{
			list4.AddWithResize(35744f);
			item = 35744f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1191944192;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v18+18]");
		if (num7 >= 0)
		{
			list4.AddWithResize(44682f);
			item = 44682f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ rax_v24 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1194232320;
		}
		((List<float>)(object)list).Add(item);
		List<float> list5 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdx_v21+18]");
		if (num8 >= 0)
		{
			list5.AddWithResize(10416f);
			item = 10416f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1176682496;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v22+18]");
		if (num9 >= 0)
		{
			list5.AddWithResize(20834f);
			item = 20834f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1185072128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v23+18]");
		if (num10 >= 0)
		{
			list5.AddWithResize(42834f);
			item = 42834f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v31 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1193759232;
		}
		((List<float>)(object)list).Add(item);
		List<float> list6 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v38 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v38 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v38 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rdx_v26+18]");
		if (num11 >= 0)
		{
			list6.AddWithResize(35744f);
			item = 35744f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1307 @ rax_v38 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 1191944192;
		}
		((List<float>)(object)list).Add(item);
		List<float> list7 = new List<float>();
		((List<float>)(object)list).Add(item);
		_delays = list;
		List<BgmType> list8 = new List<BgmType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v32+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)38);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 38;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v34+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)39);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 39;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v36+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)40);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 40;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v38+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)41);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 41;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v40+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)42);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 42;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v42+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list8).AddWithResize((System.Int32Enum)43);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1395 @ rax_v47 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 43;
		}
		_soundKeys = list8;
		_background6 = background6;
		GameManager core = GM.Core;
		_stage = core._stage;
		GameManager core2 = GM.Core;
		PlayerOptions playerOptions = core2._playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		float num18 = mainGameConfig._003CMusicVolume_003Ek__BackingField * 0.7f;
		if (!(num18 > 0.7f))
		{
			num18 = 0.7f;
		}
		_volume = num18;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "DirecterAudioManager");
		DirecterAudioManager directerAudioManager = ((!gameObject.TryGetComponent<DirecterAudioManager>(out var component)) ? gameObject.AddComponent<DirecterAudioManager>() : component);
		_directerAudioManager = directerAudioManager;
		_directerAudioManager.GetAudioClips();
		GameManager core3 = GM.Core;
		Action<OnlineSignals.OnDirecterStageSwitch> action = null;
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v4 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v4 (Il2CppMethodInfo)+4C]");
		object obj35 = (nint)0 >> 4;
		object obj36 = obj35 & 1;
		object obj37;
		if (obj36 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ r9_v4 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj37 = 6442485696L;
				goto IL_0dd0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1944 @ rax_v77 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+OnDirecterStageSwitch>)+10]");
		obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1944 @ rax_v77 (System.Action`1<VampireSurvivors.Signals.OnlineSignals+OnDirecterStageSwitch>)+20]");
		_ = 0;
		goto IL_0dd0;
		IL_0dd0:
		object obj38 = 24;
		_ = 6447743808L;
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rdi_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj39 = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnDirecterStageSwitch>)obj39)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnDirecterStageSwitch>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj41 = default(object);
		object obj40 = obj41 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = core3._signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rax_v90 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	public void Update(float deltaTime)
	{
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		Background6 background = _background6;
		EnemyDirecter directer = background._directer;
		if ((object)background._directer == null || ((UnityEngine.Object)directer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float num = (_combatTimer = deltaTime + _combatTimer);
		if (_currentPhase == 1)
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			if (activeCharacter._level >= 7 && !(num < 30.000002f))
			{
				Debug.Log("<color=green>Switching to phase 2</color>");
				_currentPhase = 2;
			}
		}
		if (_currentPhase == 2)
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
			if (activeCharacter2._level >= 14 && !(_combatTimer < 60.000004f))
			{
				Background6 background2 = _background6;
				EnemyDirecter directer2 = background2._directer;
				if (directer2._003CBrokenMasks_003Ek__BackingField == 0)
				{
					directer2.MakeMasksBreakable();
				}
				Background6 background3 = _background6;
				EnemyDirecter directer3 = background3._directer;
				if (directer3._003CBrokenMasks_003Ek__BackingField >= 7)
				{
					Debug.Log("<color=green>Switching to phase 3</color>");
					_currentPhase = 3;
					ResetMasks();
				}
			}
		}
		if (_currentPhase == 3 && !GM.Core.HasAPlayerGotRevivals())
		{
			GameManager core3 = GM.Core;
			GameSessionData gameSessionData3 = core3._gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter3 = gameSessionData3._activeCharacter;
			if (activeCharacter3._level >= 19 && !(_combatTimer < 60.000004f))
			{
				Background6 background4 = _background6;
				background4._directer.MakeMasksBreakable();
				Background6 background5 = _background6;
				EnemyDirecter directer4 = background5._directer;
				if (directer4._003CBrokenMasks_003Ek__BackingField >= 7)
				{
					Debug.Log("<color=green>Switching to phase 4</color>");
					_currentPhase = 4;
					ResetMasks();
				}
			}
		}
		if (_currentPhase != 4)
		{
			return;
		}
		GameManager core4 = GM.Core;
		GameSessionData gameSessionData4 = core4._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter4 = gameSessionData4._activeCharacter;
		if (activeCharacter4._level < 22 || _combatTimer < 45.000004f)
		{
			return;
		}
		Background6 background6 = _background6;
		background6._directer.MakeMasksBreakable();
		Background6 background7 = _background6;
		EnemyDirecter directer5 = background7._directer;
		if (directer5._003CBrokenMasks_003Ek__BackingField >= 7)
		{
			_currentPhase = 5;
			Debug.Log("<color=green>Switching to phase 5</color>");
			ResetPlayersGrowth();
			GameManager core5 = GM.Core;
			core5._003CCanInterrupt_003Ek__BackingField = false;
			GameManager core6 = GM.Core;
			core6._003CCanPause_003Ek__BackingField = false;
			ResetMasks();
			DOGetter<float> getter = _003C_003Ec._003C_003E9__22_0;
			if (_003C_003Ec._003C_003E9__22_0 == null)
			{
				DOGetter<float> dOGetter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				_003C_003Ec._003C_003E9__22_0 = dOGetter;
				getter = dOGetter;
			}
			DOSetter<float> setter = _003C_003Ec._003C_003E9__22_1;
			if (_003C_003Ec._003C_003E9__22_1 == null)
			{
				DOSetter<float> dOSetter = null;
				((_003C_003Ec)(object)dOSetter)._003CUpdate_003Eb__22_1(deltaTime);
				_003C_003Ec._003C_003E9__22_1 = dOSetter;
				setter = dOSetter;
			}
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.3f, 5f);
		}
	}

	private static void ResetPlayersGrowth()
	{
		//IL_0019: Expected O, but got I4
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private void ResetMasks()
	{
		Background6 background = _background6;
		_combatTimer = 0f;
		EnemyDirecter directer = background._directer;
		directer._003CBrokenMasks_003Ek__BackingField = 0;
		Background6 background2 = _background6;
		EnemyDirecter directer2 = background2._directer;
		directer2._003CBreakEnabled_003Ek__BackingField = false;
	}

	public void Cleanup()
	{
		AudioSource currentBgm = _currentBgm;
		if ((object)_currentBgm != null && ((UnityEngine.Object)currentBgm).m_CachedPtr != (IntPtr)0)
		{
			_currentBgm.Stop();
		}
	}

	public void StartPhase0()
	{
		//IL_00c7: Expected I8, but got I4
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals12._003C_003E4__this = this;
		_combatTimer = 0f;
		SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		_background6.SwapDirecters();
		if (!_quickDebug)
		{
			_currentPhase = 0;
			AudioSource sound = _directerAudioManager.Add(BgmType.Phase0);
			CS_0024_003C_003E8__locals12.sound = sound;
			CS_0024_003C_003E8__locals12.sound.volume = _volume;
			AudioSource.PlayHelper(CS_0024_003C_003E8__locals12.sound, 0uL);
			_currentBgm = CS_0024_003C_003E8__locals12.sound;
			TweenCallback callback = delegate
			{
				TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleAudio.DOFade(CS_0024_003C_003E8__locals12.sound, 0f, 1.1f);
				TweenCallback tweenCallback = CS_0024_003C_003E8__locals12._003C_003E9__1;
				if (CS_0024_003C_003E8__locals12._003C_003E9__1 == null)
				{
					tweenCallback = (CS_0024_003C_003E8__locals12._003C_003E9__1 = delegate
					{
						object sound2 = CS_0024_003C_003E8__locals12.sound;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
						AudioSource.Stop_Injected((IntPtr)0, true);
						GameObject gameObject = CS_0024_003C_003E8__locals12.sound.gameObject;
						UnityEngine.Object.Destroy(gameObject, 0f);
					});
				}
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals12._003C_003E4__this.StartPhase1;
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
			};
			Tween timer = SetTimeout(31307f, callback);
			_timer0 = timer;
		}
		else
		{
			_currentPhase = 1;
			CheckTime1(1, 2);
		}
	}

	private void OnOnlineStageSwitch(OnlineSignals.OnDirecterStageSwitch newPhase)
	{
		//IL_00d4: Expected I4, but got O
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected I4, but got Unknown
		//IL_00fb: Expected I4, but got O
		if (!GM.Core.IsStageHost)
		{
			_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass27_0();
			RemoveTimers();
			CS_0024_003C_003E8__locals3.currentSound = _currentBgm;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleAudio.DOFade(CS_0024_003C_003E8__locals3.currentSound, 0f, 0.85f);
			TweenCallback tweenCallback = delegate
			{
				DestroySound(CS_0024_003C_003E8__locals3.currentSound);
			};
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}
		_currentPhase = (int)newPhase;
		ChangePhase();
		int phaseSwitch = newPhase + 1;
		CheckTime1((int)newPhase, phaseSwitch);
	}

	private Tween SetTimeout(float delay, TweenCallback callback)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3E75]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float delay2 = delay * 0.001f;
		Tween tween = DOVirtual.DelayedCall(delay2, callback);
		if (tween != null)
		{
			tween.stringId = "DO_NOT_KILL_THESE_PLZ";
			return tween;
		}
		return (Tween)(object)new NullReferenceException();
	}

	private unsafe void CheckTime1(int soundPhase, int phaseSwitch, bool fadeIn = true)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0037: Expected O, but got Ref
		//IL_0061: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_00a5: Expected O, but got Ref
		//IL_00c1: Expected native int or pointer, but got O
		//IL_00d9: Expected O, but got Ref
		//IL_021d: Expected O, but got I
		//IL_0250: Expected O, but got Ref
		//IL_0266: Expected I4, but got O
		//IL_0278: Expected O, but got Ref
		//IL_028c: Expected native int or pointer, but got O
		//IL_02a4: Expected O, but got Ref
		//IL_0360: Expected O, but got I4
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected I4, but got Unknown
		//IL_03e0: Expected I4, but got O
		//IL_0910: Expected O, but got I4
		//IL_092b: Expected O, but got I4
		//IL_05c9: Expected O, but got I4
		//IL_05d2: Expected O, but got I4
		//IL_0477: Expected I8, but got I4
		//IL_0480: Expected O, but got I4
		//IL_05f6: Expected O, but got I
		//IL_0648: Expected O, but got I
		//IL_078b: Expected O, but got I
		//IL_067a: Expected I4, but got O
		//IL_06e8: Expected O, but got I4
		//IL_06e8: Expected F4, but got I
		//IL_07fe: Expected I, but got O
		//IL_0814: Expected O, but got I
		//IL_081d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0822: Expected O, but got Unknown
		//IL_0898: Expected I, but got O
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Expected O, but got Unknown
		//IL_06cd: Expected I4, but got O
		//IL_0942: Expected O, but got I4
		//IL_0959: Expected I, but got I8
		//IL_096f: Expected F4, but got I
		//IL_0874: Expected I, but got I8
		//IL_0199->IL08ad: Incompatible stack heights: 1 vs 0
		//IL_01e0->IL08ad: Incompatible stack heights: 1 vs 0
		//IL_023d->IL08ad: Incompatible stack heights: 2 vs 0
		//IL_02f9->IL08ad: Incompatible stack heights: 2 vs 0
		//IL_0348->IL08ad: Incompatible stack heights: 2 vs 0
		//IL_03fd->IL08ad: Incompatible stack heights: 2 vs 0
		//IL_0429->IL08ad: Incompatible stack heights: 3 vs 0
		//IL_045f->IL08ad: Incompatible stack heights: 3 vs 0
		//IL_05db->IL08ad: Incompatible stack heights: 3 vs 0
		//IL_0668->IL08ad: Incompatible stack heights: 4 vs 0
		//IL_07ab->IL08ad: Incompatible stack heights: 4 vs 0
		//IL_0706->IL08ad: Incompatible stack heights: 4 vs 0
		//IL_0730->IL05e0: Incompatible stack heights: 4 vs 3
		//IL_098d->IL08ad: Incompatible stack heights: 4 vs 0
		//IL_08ac->IL08ac: Incompatible stack heights: 4 vs 3
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass29_0 CS_0024_003C_003E8__locals43 = new _003C_003Ec__DisplayClass29_0();
		int soundPhase2;
		List<float>[] items;
		if (CS_0024_003C_003E8__locals43 != null)
		{
			CS_0024_003C_003E8__locals43._003C_003E4__this = this;
			int phaseSwitch2 = default(int);
			CS_0024_003C_003E8__locals43.phaseSwitch = phaseSwitch2;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			CS_0024_003C_003E8__locals43.soundPhase = soundPhase;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = CS_0024_003C_003E8__locals43.phaseSwitch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			_ = 0;
			_ = 0;
			object arg = default(object);
			object arg2 = default(object);
			object arg3 = default(object);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg, arg2, arg3));
			System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
			_ = 0;
			string message = string.FormatHelper((IFormatProvider)null, "CheckTime1 - SoundPhase: {0}, PhaseSwitch: {1}, FadeIn: {2}", args);
			Debug.Log(message);
			List<List<float>> delays = _delays;
			soundPhase2 = CS_0024_003C_003E8__locals43.soundPhase;
			if (_delays != null)
			{
				bool flag = CS_0024_003C_003E8__locals43.soundPhase >= delays._size;
				items = delays._items;
				if (delays._items != null)
				{
					List<BgmType> soundKeys = _soundKeys;
					List<float> list = items[soundPhase2];
					int soundPhase3 = CS_0024_003C_003E8__locals43.soundPhase;
					if (_soundKeys != null)
					{
						int soundPhase4 = CS_0024_003C_003E8__locals43.soundPhase;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
						bool flag2 = (nint)soundPhase4 >= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
						if ((nint)0 != 0)
						{
							object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v22+20+v119 @ rdx_v15 (System.Int32)*4]");
							_ = 0;
							object arg4 = (BgmType)obj7;
							System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg4));
							System.ParamsArray args2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
							_ = 0;
							string message2 = string.FormatHelper((IFormatProvider)null, "CheckTime1 - Sound1Key: {0}", args2);
							Debug.Log(message2);
							if ((object)_directerAudioManager != null)
							{
								DirecterAudioManager directerAudioManager = _directerAudioManager;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rcx_v22+20+v119 @ rdx_v15 (System.Int32)*4]");
								AudioSource sound = directerAudioManager.Add(BgmType.BGM_Forest);
								CS_0024_003C_003E8__locals43.sound1 = sound;
								if ((object)CS_0024_003C_003E8__locals43.sound1 != null)
								{
									object obj8 = CS_0024_003C_003E8__locals43.soundPhase - 5;
									int num = CS_0024_003C_003E8__locals43.soundPhase ^ 5;
									int num2 = CS_0024_003C_003E8__locals43.soundPhase ^ obj8;
									int num3 = num & num2;
									bool flag3 = num3 < 0;
									bool flag4 = (nint)obj8 < 0;
									bool loop = flag4 != flag3;
									CS_0024_003C_003E8__locals43.sound1.loop = loop;
									int num4 = (int)CS_0024_003C_003E8__locals43.sound1;
									if ((object)CS_0024_003C_003E8__locals43.sound1 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v10 (System.Int32)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v10 (System.Int32)+10]");
										object obj9 = AudioSource.get_isPlaying_Injected((IntPtr)0);
										bool flag6 = obj9 != null;
										object obj10 = 0;
										if (flag6)
										{
											goto IL_0485;
										}
										if ((object)CS_0024_003C_003E8__locals43.sound1 != null)
										{
											CS_0024_003C_003E8__locals43.sound1.volume = _volume;
											if ((object)CS_0024_003C_003E8__locals43.sound1 != null)
											{
												AudioSource.PlayHelper(CS_0024_003C_003E8__locals43.sound1, 0uL);
												obj10 = 0;
												goto IL_0485;
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
		goto IL_08ad;
		IL_08ad:
		throw new NullReferenceException();
		IL_0485:
		_currentBgm = CS_0024_003C_003E8__locals43.sound1;
		if (fadeIn)
		{
			if (CS_0024_003C_003E8__locals43.soundPhase >= 5)
			{
				return;
			}
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleAudio.DOFade(CS_0024_003C_003E8__locals43.sound1, _volume, 0.85f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AF40");
			TweenCallback tweenCallback = delegate
			{
				CS_0024_003C_003E8__locals43.sound1.volume = 0f;
			};
			int num5 = default(int);
			bool flag7 = num5 == 0;
			float num6 = 0.85f;
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1100 @ rax_v67 (System.Int32)+E8]");
				bool flag8 = (nint)0 == 0;
				num6 = 0.85f;
				if (!flag8)
				{
					num6 = 0.85f;
				}
			}
		}
		if (CS_0024_003C_003E8__locals43.soundPhase >= 5)
		{
			return;
		}
		bool flag9 = items[soundPhase2] == null;
		object obj11 = 0;
		object obj12 = 0;
		if (!flag9)
		{
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj13 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
				{
					object obj14 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
					bool flag10 = (nint)obj14 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					int num7 = (int)CS_0024_003C_003E8__locals43._003C_003E9__1;
					if (CS_0024_003C_003E8__locals43._003C_003E9__1 == null)
					{
						num7 = (int)(CS_0024_003C_003E8__locals43._003C_003E9__1 = delegate
						{
							DirecterManager directerManager = CS_0024_003C_003E8__locals43._003C_003E4__this;
							if (directerManager._currentPhase >= CS_0024_003C_003E8__locals43.phaseSwitch)
							{
								directerManager.RemoveTimers();
								TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTweenModuleAudio.DOFade(CS_0024_003C_003E8__locals43.sound1, 0f, 1.2f);
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 20;
										_ = 0;
									}
								}
								TweenCallback tweenCallback3 = CS_0024_003C_003E8__locals43._003C_003E9__2;
								if (CS_0024_003C_003E8__locals43._003C_003E9__2 == null)
								{
									tweenCallback3 = (CS_0024_003C_003E8__locals43._003C_003E9__2 = delegate
									{
										DestroySound(CS_0024_003C_003E8__locals43.sound1);
									});
								}
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
								TweenCallback tweenCallback4 = CS_0024_003C_003E8__locals43._003C_003E9__3;
								if (CS_0024_003C_003E8__locals43._003C_003E9__3 == null)
								{
									tweenCallback4 = (CS_0024_003C_003E8__locals43._003C_003E9__3 = delegate
									{
										CS_0024_003C_003E8__locals43._003C_003E4__this.PerformChangePhase(CS_0024_003C_003E8__locals43.soundPhase, CS_0024_003C_003E8__locals43.phaseSwitch);
									});
								}
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 == 0)
									{
									}
								}
							}
						});
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v51+20+v108 @ r15_v9*4]");
					Tween tween = SetTimeout(0f, (TweenCallback)num7);
					if (_bgmTimers == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
					obj11++;
					obj12 = obj11;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)0 <= (nint)0)
				{
					return;
				}
				object obj16 = obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				bool flag11 = (nint)obj16 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rdi_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				TweenCallback tweenCallback2 = null;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v7 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass29_0._003CCheckTime1_003Eb__4);
				((Delegate)tweenCallback2).m_target = CS_0024_003C_003E8__locals43;
				((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v7 (Il2CppMethodInfo)+4C]");
				object obj18 = (nint)0 >> 4;
				object obj19 = obj18 & 1;
				nint num9;
				if (obj19 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v7 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num9 = unchecked((nint)6447293664L);
						goto IL_0939;
					}
				}
				num9 = ((Delegate)tweenCallback2).method_ptr;
				((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
				goto IL_0939;
				IL_0939:
				object obj20 = 24;
				((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v39+20+v108 @ r15_v9*4]");
				Tween tween2 = SetTimeout(0f, tweenCallback2);
				if (_bgmTimers == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DF90");
				return;
			}
		}
		goto IL_08ad;
	}

	private static void DestroySound(AudioSource sound1)
	{
		bool flag = ((UnityEngine.Object)sound1).m_CachedPtr == (IntPtr)0;
		AudioSource.Stop_Injected(((UnityEngine.Object)sound1).m_CachedPtr, true);
		GameObject gameObject = sound1.gameObject;
		UnityEngine.Object.Destroy(gameObject, 0f);
	}

	private void PerformChangePhase(int soundPhase, int phaseSwitch)
	{
		//IL_00d5: Expected I, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		if (GM.Core.IsStageHost)
		{
			int soundPhase2 = soundPhase + 1;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				ChangePhase();
				int phaseSwitch2 = phaseSwitch + 1;
				CheckTime1(soundPhase2, phaseSwitch2);
			}
			else
			{
				OnlineStageManager instance = OnlineStageManager._instance;
				Action<long, int> action = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
				long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
				int param = default(int);
				bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
			}
		}
	}

	private void RemoveTimers()
	{
		//IL_0206: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		List<Tween> bgmTimers = _bgmTimers;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < bgmTimers._size)
			{
				List<Tween> bgmTimers2 = _bgmTimers;
				if ((nint)obj >= bgmTimers2._size)
				{
					break;
				}
				Tween[] items = bgmTimers2._items;
				Tween tween = items[obj];
				if (items[obj] != null && tween._003Cactive_003Ek__BackingField)
				{
					TweenExtensions.Kill(items[obj]);
				}
				bgmTimers = _bgmTimers;
				obj++;
				obj2 = obj;
				continue;
			}
			Tween timer = _timer0;
			if (_timer0 != null && timer._003Cactive_003Ek__BackingField)
			{
				TweenExtensions.Kill(_timer0);
			}
			List<Tween> bgmTimers3 = _bgmTimers;
			int version = bgmTimers3._version + 1;
			bgmTimers3._version = version;
			bgmTimers3._size = 0;
			if (bgmTimers3._size > 0)
			{
				Array.Clear(bgmTimers3._items, 0, bgmTimers3._size);
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void ChangePhase()
	{
		Debug.Log("Trying to change phase");
		if (_currentPhase >= 2 && !_startedPhase2)
		{
			_startedPhase2 = true;
			StartPhase2();
		}
		if (_currentPhase >= 3 && !_startedPhase3)
		{
			_startedPhase3 = true;
			StartPhase3();
		}
		if (_currentPhase >= 4 && !_startedPhase4)
		{
			_startedPhase4 = true;
			StartPhase4();
		}
		if (_currentPhase >= 5 && !_startedPhase5)
		{
			_startedPhase5 = true;
			StartPhase5();
		}
	}

	private unsafe void StartPhase1()
	{
		//IL_001c: Expected I8, but got O
		//IL_006d: Expected O, but got Ref
		Background6 background = _background6;
		Action singlePlayerTrigger = background._directer.TriggerPhase1OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase1((long)background._directer);
		background._directer.TriggerPhase(singlePlayerTrigger, action);
		_currentPhase = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>Current Phase: {0}</color>", (System.ParamsArray)(&obj));
		Debug.Log(message);
		CheckTime1(1, 2);
	}

	private unsafe void StartPhase2()
	{
		//IL_01aa: Expected O, but got Ref
		//IL_0039: Expected I8, but got O
		//IL_00ee: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		ParticleSystem.MinMaxCurve minMaxCurve = default(ParticleSystem.MinMaxCurve);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>Current Phase: {0}</color>", (System.ParamsArray)(&minMaxCurve));
		Debug.Log(message);
		Background6 background = _background6;
		Action singlePlayerTrigger = background._directer.TriggerPhase2OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase2((long)background._directer);
		background._directer.TriggerPhase(singlePlayerTrigger, action);
		DOGetter<float> getter = _003C_003Ec._003C_003E9__35_0;
		if (_003C_003Ec._003C_003E9__35_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__35_0 = dOGetter;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__35_1;
		if (_003C_003Ec._003C_003E9__35_1 == null)
		{
			DOSetter<float> dOSetter = null;
			((_003C_003Ec)(object)dOSetter)._003CStartPhase2_003Eb__35_1(0f);
			_003C_003Ec._003C_003E9__35_1 = dOSetter;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.9f, 5f);
		_background6.RemoveTileset();
		_background6.ZoomOverStages();
		Background6 background2 = _background6;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(0.9f, 0f);
		RenderingExtensions.SetAlpha(background2._pfxFire1, (ParticleSystem.MinMaxCurve)(&minMaxCurve));
		Action onComplete = delegate
		{
			_background6.RemoveCircles();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Background6 background3 = _background6;
			RenderingExtensions.StopEmitting(background3._pfxFire1);
			Background6 background4 = _background6;
			RenderingExtensions.StopEmitting(background4._pfxFire2);
			Background6 background5 = _background6;
			SetParticlesVelocity(background5._pfxFire1, 600f);
			Background6 background6 = _background6;
			SetParticlesVelocity(background6._pfxFire2, 600f);
		};
		Timer timer2 = Timers.Register(0.6f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SetParticlesVelocity(ParticleSystem ps, float yVel)
	{
		//IL_0070: Expected I4, but got I8
		//IL_009d: Expected O, but got I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		if ((object)ps == null || ((UnityEngine.Object)ps).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		int particleCount = ps.particleCount;
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
		int particles2 = ps.GetParticles(particles, -1, 0);
		if (particles2 > 0)
		{
			object obj = 0;
			bool flag;
			do
			{
				object obj2 = obj * 132;
				object obj3 = obj + 1;
				object obj4 = obj * 132;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+20+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+30+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+40+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+50+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+60+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+70+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+80+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+90+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v15+A0+v320 @ rax_v9 (Particle[])]");
				_ = 0;
				flag = (nint)obj3 < particles2;
				obj = obj3;
			}
			while (flag);
		}
		ps.SetParticles(particles, particles2, 0);
	}

	private unsafe void StartPhase3()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01e4: Expected O, but got Ref
		//IL_0203: Expected O, but got Ref
		//IL_0217: Expected native int or pointer, but got O
		//IL_022a: Expected O, but got Ref
		//IL_0041: Expected I8, but got O
		//IL_030a: Expected F4, but got I
		//IL_00ea: Expected O, but got Ref
		//IL_0104: Expected native int or pointer, but got O
		//IL_0117: Expected O, but got Ref
		//IL_0156: Expected O, but got Ref
		//IL_0170: Expected native int or pointer, but got O
		//IL_0183: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
		_ = _currentPhase;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 0;
		_ = 0;
		object arg = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
		System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>Current Phase: {0}</color>", args);
		Debug.Log(message);
		Background6 background = _background6;
		Action singlePlayerTrigger = background._directer.TriggerPhase3OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase3((long)background._directer);
		background._directer.TriggerPhase(singlePlayerTrigger, action);
		GM.Core.EraseEnemies(showVfx: false);
		DOGetter<float> getter = _003C_003Ec._003C_003E9__37_0;
		if (_003C_003Ec._003C_003E9__37_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__37_0 = dOGetter;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__37_1;
		if (_003C_003Ec._003C_003E9__37_1 == null)
		{
			DOSetter<float> dOSetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
			((_003C_003Ec)(object)dOSetter)._003CStartPhase3_003Eb__37_1(0f);
			_003C_003Ec._003C_003E9__37_1 = dOSetter;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.8f, 5f);
		Background6 background2 = _background6;
		background2._canContinueStageZoom = false;
		RenderingExtensions.StopEmitting(background2._pfxFireRed1);
		RenderingExtensions.StopEmitting(background2._pfxFireRed2);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(-300f, -300f));
		ParticleSystem.MinMaxCurve value = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		RenderingExtensions.SetSpeedY(background2._pfxFireRed1, value);
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-300f, -300f));
		ParticleSystem.MinMaxCurve value2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		_ = 0;
		RenderingExtensions.SetSpeedY(background2._pfxFireRed2, value2);
		RenderingExtensions.Start(background2._pfxFireRed1);
		RenderingExtensions.Start(background2._pfxFireRed2);
	}

	private unsafe void StartPhase4()
	{
		//IL_02f5: Expected O, but got Ref
		//IL_009b: Expected I8, but got O
		//IL_00fa: Expected I, but got O
		//IL_012b: Expected O, but got I
		//IL_0155: Expected O, but got I
		//IL_0183: Expected F4, but got I4
		//IL_018b: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		System.ParamsArray paramsArray2 = default(System.ParamsArray);
		string text = string.FormatHelper((IFormatProvider)null, "<color=green>Current Phase: {0}</color>", (System.ParamsArray)(&paramsArray2));
		Debug.Log(text);
		Background6 background = _background6;
		bool flag = (object)_background6 == null;
		object obj = text;
		if (!flag)
		{
			bool flag2 = (object)background._directer == null;
			obj = text;
			if (!flag2)
			{
				Action singlePlayerTrigger = background._directer.TriggerPhase4OnClient;
				Action<long> action = null;
				((EnemyDirecter)(object)action).OnlineTriggerPhase4((long)background._directer);
				background._directer.TriggerPhase(singlePlayerTrigger, action);
				bool flag3 = (object)GM.Core == null;
				obj = GM.Core;
				if (!flag3)
				{
					GM.Core.EraseEnemies(showVfx: false);
					nint num = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v27 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num2 = 0;
					GameManager core = GM.Core;
					bool flag4 = (object)GM.Core == null;
					obj = num2;
					if (!flag4)
					{
						bool flag5 = core._characters == null;
						obj = num2;
						if (!flag5)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator.MoveNext())
							{
								float num3 = 0f;
								obj = (object)(&enumerator);
								throw new NullReferenceException();
							}
							DOGetter<float> getter = _003C_003Ec._003C_003E9__38_0;
							if (_003C_003Ec._003C_003E9__38_0 == null)
							{
								DOGetter<float> dOGetter = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
								_003C_003Ec._003C_003E9__38_0 = dOGetter;
								getter = dOGetter;
							}
							DOSetter<float> setter = _003C_003Ec._003C_003E9__38_1;
							if (_003C_003Ec._003C_003E9__38_1 == null)
							{
								DOSetter<float> dOSetter = null;
								((_003C_003Ec)(object)dOSetter)._003CStartPhase4_003Eb__38_1(0f);
								_003C_003Ec._003C_003E9__38_1 = dOSetter;
								setter = dOSetter;
							}
							TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.3f, 25.000002f);
							if ((object)_background6 != null)
							{
								_background6.StartColorChangingBackground();
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void StartPhase5()
	{
		//IL_0163: Expected O, but got Ref
		//IL_0075: Expected I8, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "<color=green>Current Phase: {0}</color>", (System.ParamsArray)(&obj));
		Debug.Log(message);
		DOGetter<float> getter = _003C_003Ec._003C_003E9__39_0;
		if (_003C_003Ec._003C_003E9__39_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__39_0 = dOGetter;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__39_1;
		if (_003C_003Ec._003C_003E9__39_1 == null)
		{
			DOSetter<float> dOSetter = null;
			((_003C_003Ec)(object)dOSetter)._003CStartPhase5_003Eb__39_1(0f);
			_003C_003Ec._003C_003E9__39_1 = dOSetter;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.65f, 10f);
		Background6 background = _background6;
		Action singlePlayerTrigger = background._directer.TriggerPhase5OnClient;
		Action<long> action = null;
		((EnemyDirecter)(object)action).OnlineTriggerPhase5((long)background._directer);
		background._directer.TriggerPhase(singlePlayerTrigger, action);
		GM.Core.EraseEnemies(showVfx: false);
		GameManager core = GM.Core;
		core._003CCanPause_003Ek__BackingField = false;
		GM.Core.TogglePlayerHealthBar(visible: false);
		GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
		List<EquipmentInfo> list = GM.Core.RemoveAllEquipmentFromPlayers();
		_background6.InitShatterVfx();
		Background6._003CShatterImageRoutine_003Ed__100 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = _background6;
		Coroutine coroutine = _background6.StartCoroutine(obj2);
		Background6._003CEnterPhase5PostShatterAnimation_003Ed__80 obj3 = null;
		obj3._003C_003E1__state = 0;
		obj3._003C_003E4__this = _background6;
		Coroutine coroutine2 = _background6.StartCoroutine(obj3);
	}

	private void _003CStartPhase2_003Eb__35_2()
	{
		_background6.RemoveCircles();
	}

	private void _003CStartPhase2_003Eb__35_3()
	{
		Background6 background = _background6;
		RenderingExtensions.StopEmitting(background._pfxFire1);
		Background6 background2 = _background6;
		RenderingExtensions.StopEmitting(background2._pfxFire2);
		Background6 background3 = _background6;
		SetParticlesVelocity(background3._pfxFire1, 600f);
		Background6 background4 = _background6;
		SetParticlesVelocity(background4._pfxFire2, 600f);
	}
}
