using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_GateBoss : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<float> _003C_003E9__76_0;

		public static Action _003C_003E9__81_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnRelicSpawned_003Eb__76_0(float x)
		{
			//IL_0061: Expected I, but got O
			//IL_0069: Expected I, but got O
			//IL_0079: Expected O, but got I
			//IL_00f9: Expected O, but got I4
			//IL_00b5: Expected O, but got I
			//IL_00eb: Expected O, but got I4
			GameManager core = GM.Core;
			Stage stage = core._stage;
			object fancyBg = stage._fancyBg;
			object obj;
			if ((object)stage._fancyBg == null)
			{
				obj = null;
				goto IL_0183;
			}
			nint num = (nint)typeof(BackgroundTP_Basic);
			nint num2 = (nint)fancyBg;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v5 (Il2CppClass<System.Object>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
			object obj4;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ r9_v5 (Il2CppClass<System.Object>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v26+FFFFFFF8+v86 @ rax_v22*8]");
				if (0 == (nint)typeof(BackgroundTP_Basic))
				{
					obj4 = 1;
					goto IL_015c;
				}
			}
			obj4 = 0;
			goto IL_015c;
			IL_015c:
			bool flag = obj4 == null;
			obj = null;
			if (!flag)
			{
				obj = stage._fancyBg;
			}
			goto IL_0183;
			IL_0183:
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdi_v1 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Action onComplete = ((BackgroundTP_Basic)obj)._003CCreateCycleGatesDelayed_003Eb__33_0;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				}
			}
		}

		internal void _003CDoDeathAnimation_003Eb__81_0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public bool PlayCoffinAnimation;

		public Action _003C_003E9__1;

		internal void _003CCheckAssassin_003Eb__0()
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("LightningOniShake");
			Action onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					//IL_001c: Expected O, but got I4
					if (PlayCoffinAnimation)
					{
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Detune = -1000f;
						soundConfig.Rate = 0.5f;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.096f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CCheckAssassin_003Eb__1()
		{
			//IL_001c: Expected O, but got I4
			if (PlayCoffinAnimation)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = -1000f;
				soundConfig.Rate = 0.5f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass68_0
	{
		public Enemy_TP_GateBoss _003C_003E4__this;

		public bool PlayCoffinAnimation;

		public Action _003C_003E9__1;

		internal void _003COneHitKoLogic_003Eb__0()
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("LightningOniShake");
			Action onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					//IL_001c: Expected O, but got I4
					if (PlayCoffinAnimation)
					{
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Volume = (float?)(object)1;
						soundConfig.Detune = -1000f;
						soundConfig.Rate = 0.5f;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.096f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Enemy_TP_GateBoss enemy_TP_GateBoss = _003C_003E4__this;
			enemy_TP_GateBoss._hp = 0f;
		}

		internal void _003COneHitKoLogic_003Eb__1()
		{
			//IL_001c: Expected O, but got I4
			if (PlayCoffinAnimation)
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = -1000f;
				soundConfig.Rate = 0.5f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ThingFound, soundConfig, 0f, 10, time);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass81_0
	{
		public Enemy_TP_GateBoss _003C_003E4__this;

		public EmitZone emitZone;

		public ParticleEmitterManager particleManager;

		public Action _003C_003E9__2;

		internal unsafe void _003CDoDeathAnimation_003Eb__1()
		{
			//IL_0008: Expected O, but got Ref
			//IL_00c7: Expected O, but got I4
			//IL_0187: Expected O, but got I
			//IL_01fd: Expected O, but got I
			//IL_0234: Expected O, but got I
			//IL_02aa: Expected O, but got I
			//IL_02e1: Expected O, but got I
			//IL_0357: Expected O, but got I
			//IL_038e: Expected O, but got I
			//IL_0404: Expected O, but got I
			//IL_043b: Expected O, but got I
			//IL_04b1: Expected O, but got I
			//IL_04e8: Expected O, but got I
			//IL_055e: Expected O, but got I
			//IL_0e2a: Expected I, but got O
			//IL_0595: Expected O, but got I
			//IL_060b: Expected O, but got I
			//IL_0642: Expected O, but got I
			//IL_06b8: Expected O, but got I
			//IL_06ef: Expected O, but got I
			//IL_0765: Expected O, but got I
			//IL_079c: Expected O, but got I
			//IL_0812: Expected O, but got I
			//IL_0849: Expected O, but got I
			//IL_08bf: Expected O, but got I
			//IL_090c: Expected O, but got Ref
			//IL_092f: Expected native int or pointer, but got O
			//IL_0949: Expected O, but got I
			//IL_0969: Expected O, but got Ref
			//IL_0983: Expected native int or pointer, but got O
			//IL_099d: Expected O, but got I
			//IL_09bd: Expected O, but got Ref
			//IL_09d7: Expected native int or pointer, but got O
			//IL_09f1: Expected O, but got I
			//IL_0a11: Expected O, but got Ref
			//IL_0a2b: Expected native int or pointer, but got O
			//IL_0f52: Expected O, but got I4
			//IL_0a56: Expected O, but got Ref
			//IL_0a77: Expected O, but got I
			//IL_0a91: Expected native int or pointer, but got O
			//IL_0f8c: Expected O, but got I
			//IL_0acf: Expected O, but got Ref
			//IL_0af0: Expected O, but got I
			//IL_0b0a: Expected native int or pointer, but got O
			//IL_0fc6: Expected O, but got I
			//IL_1024: Expected O, but got I
			//IL_10c9: Expected O, but got Ref
			//IL_0ef3->IL0e6d: Incompatible stack heights: 1 vs 0
			//IL_0cde->IL0e6d: Incompatible stack heights: 7 vs 0
			//IL_0dc7->IL0e6d: Incompatible stack heights: 7 vs 0
			//IL_0e1d->IL0e6d: Incompatible stack heights: 7 vs 0
			//IL_10d8->IL0f1f: Incompatible stack heights: 18 vs 1
			//IL_0bfa->IL10bb: Incompatible stack heights: 19 vs 18
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_ = 0;
			if ((object)_003C_003E4__this != null)
			{
				ArcadeSprite arcadeSprite = _003C_003E4__this.setVisible(visible: false);
				Enemy_TP_GateBoss enemy_TP_GateBoss = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					Enemy_TP_GateBoss deathVfxParticleSystem = (Enemy_TP_GateBoss)(object)enemy_TP_GateBoss._deathVfxParticleSystem1;
					if ((object)enemy_TP_GateBoss._deathVfxParticleSystem1 != null)
					{
						bool flag = ((UnityEngine.Object)deathVfxParticleSystem).m_CachedPtr == (IntPtr)0;
						ParticleSystem.Stop_Injected(((UnityEngine.Object)deathVfxParticleSystem).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
						Enemy_TP_GateBoss enemy_TP_GateBoss2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							object deathVfxParticleSystem2 = enemy_TP_GateBoss2._deathVfxParticleSystem2;
							Transform transform;
							if ((object)enemy_TP_GateBoss2._deathVfxParticleSystem2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rbx_v11 (System.Object)+10]");
								bool flag2 = (nint)0 != 0;
								transform = (Transform)1;
								if (flag2)
								{
									goto IL_0f1f;
								}
							}
							Circle source = new Circle
							{
								_x = 0f,
								_radius = 16f
							};
							EmitZone emitZone = new EmitZone
							{
								_type = EmitZoneType.Random,
								_source = source
							};
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
							List<string> list = new List<string>();
							bool flag3 = list == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rcx_v62+18]");
							if (num >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj4 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rcx_v64+18]");
							if (num2 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj6 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ rcx_v66+18]");
							if (num3 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire21");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj8 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1100 @ rcx_v68+18]");
							if (num4 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire22");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj10 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag8 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rcx_v70+18]");
							if (num5 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire23");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj12 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag9 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rcx_v72+18]");
							if (num6 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire24");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj14 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag10 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1103 @ rcx_v74+18]");
							if (num7 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire25");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj16 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1104 @ rcx_v76+18]");
							if (num8 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire26");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj18 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag12 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ rcx_v78+18]");
							if (num9 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire27");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj20 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj21 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag13 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rcx_v80+18]");
							if (num10 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire28");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj22 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag14 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rcx_v82+18]");
							if (num11 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire29");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj24 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							bool flag15 = particleSystemConfig == null;
							particleSystemConfig._frame = list;
							ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
							particleSystemConfig._fps = 16;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
							particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
							particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-80f, -100f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
							particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(200f, 400f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
							_ = 0;
							particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
							_ = 0;
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
							_ = 3;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
							particleSystemConfig._quantity = (int?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 1f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
							particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
							_ = 0;
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
							_ = 1065353216;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
							particleSystemConfig._frequency = (float?)(object)0;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
							particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
							_ = 0;
							particleSystemConfig._emitZone = this.emitZone;
							particleSystemConfig._on = true;
							bool flag16 = (object)particleManager == null;
							ParticleSystem particleSystem = particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
							bool flag17 = (object)_003C_003E4__this == null;
							transform = null;
							Enemy_TP_GateBoss enemy_TP_GateBoss3 = _003C_003E4__this;
							bool flag18 = (object)_003C_003E4__this == null;
							bool flag19 = (object)enemy_TP_GateBoss3._deathVfxParticleSystem2 == null;
							_ = enemy_TP_GateBoss3._deathVfxParticleSystem2;
							_ = enemy_TP_GateBoss3._deathVfxParticleSystem2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag20 = obj25 == null;
							}
							object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2789 @ rax_v118 (should have been resolved before IL gen)");
							goto IL_0f1f;
						}
					}
				}
			}
			goto IL_0e6d;
			IL_0e6d:
			throw new NullReferenceException();
			IL_0f1f:
			Enemy_TP_GateBoss enemy_TP_GateBoss4 = _003C_003E4__this;
			bool flag21 = (object)_003C_003E4__this == null;
			bool flag22 = (object)enemy_TP_GateBoss4._deathVfxParticleSystem2 == null;
			Transform transform2 = enemy_TP_GateBoss4._deathVfxParticleSystem2.transform;
			bool flag23 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
			bool flag24 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)0, ref value);
			Enemy_TP_GateBoss enemy_TP_GateBoss5 = _003C_003E4__this;
			bool flag25 = (object)_003C_003E4__this == null;
			RenderingExtensions.Start(enemy_TP_GateBoss5._deathVfxParticleSystem2);
			Enemy_TP_GateBoss enemy_TP_GateBoss6 = _003C_003E4__this;
			bool flag26 = (object)_003C_003E4__this == null;
			if (enemy_TP_GateBoss6.deathTimer1 != null)
			{
				enemy_TP_GateBoss6.deathTimer1.Cancel();
			}
			Enemy_TP_GateBoss enemy_TP_GateBoss7 = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				if (enemy_TP_GateBoss7.deathTimer2 != null)
				{
					enemy_TP_GateBoss7.deathTimer2.Cancel();
				}
				Action onComplete = _003C_003E9__2;
				Enemy_TP_GateBoss enemy_TP_GateBoss8 = _003C_003E4__this;
				if (_003C_003E9__2 == null)
				{
					onComplete = (_003C_003E9__2 = delegate
					{
						Enemy_TP_GateBoss enemy_TP_GateBoss10 = _003C_003E4__this;
						enemy_TP_GateBoss10._deathVfxParticleSystem2.Stop();
					});
				}
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer deathTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				if ((object)_003C_003E4__this != null)
				{
					enemy_TP_GateBoss8.deathTimer1 = deathTimer;
					object obj27 = _003C_003E4__this;
					Enemy_TP_GateBoss enemy_TP_GateBoss9 = _003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1682 @ r8_v15 (Il2CppClass<System.Object>)+3A0]");
					Action onComplete2 = new Action(enemy_TP_GateBoss9, (IntPtr)0);
					if ((object)_003C_003E4__this != null)
					{
						nint num12 = (nint)obj27;
						Timer timer = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						return;
					}
				}
			}
			goto IL_0e6d;
		}

		internal void _003CDoDeathAnimation_003Eb__2()
		{
			Enemy_TP_GateBoss enemy_TP_GateBoss = _003C_003E4__this;
			enemy_TP_GateBoss._deathVfxParticleSystem2.Stop();
		}
	}

	public ItemType RelicToDrop;

	public WeaponType WeaponToDrop;

	public ItemType AlternativePrize;

	public bool HasRelic;

	public bool HasTreasureChest;

	public List<float> TreasureChances;

	public ItemType RequiresItem;

	public List<PrizeType?> TreasurePrizeTypes;

	private DamagingZonePrefab damagingZone;

	private float _damageZoneRespawnTimer;

	public bool DoWiggle;

	private SpriteRenderer _ringSprite;

	private float _shieldDamage;

	private int _deathScreamTimerLoopCount;

	private bool _hasShield;

	private bool _hasRunDeathLogic;

	private bool _hasRunOneHKOLogic;

	private Timer _shieldTimer;

	private Timer _aiTimer;

	private Timer _deathScreamTimer;

	protected bool _isRunningDeathAnimation;

	private SpriteRenderer _posterSprite;

	private SpriteMask _posterMask;

	private MultiTargetTween screamTween;

	protected MultiTargetTween scaleTween;

	private Timer deathTimer1;

	private Timer deathTimer2;

	private Timer exploTimer1;

	private Timer exploTimer2;

	private Timer animTimer;

	private Timer relicDropTimer;

	private Tween posterTween;

	private bool _hasDroppedTreasure;

	private Tween _onEnterTween;

	private SpriteRenderer _enterSprite;

	private SpriteRenderer _enterSprite2;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _rotTween;

	private ParticleSystem _deathVfxParticleSystem1;

	private ParticleSystem _deathVfxParticleSystem2;

	protected uint _damagingZoneSeed;

	private Action _003COnDefeat_003Ek__BackingField;

	private bool _003CDropRelic_003Ek__BackingField;

	private float _003CShieldTime_003Ek__BackingField;

	public WeaponType OHKOWeaponType;

	public SecretType OHKOSecretUnlock;

	public CharacterType OHKOCharacterUnlock;

	public CharacterType Assassin;

	public SecretType AssassinSecretUnlock;

	public CharacterType AssassinCharacterUnlock;

	public Action OnDefeat
	{
		get
		{
			return _003COnDefeat_003Ek__BackingField;
		}
		set
		{
			_003COnDefeat_003Ek__BackingField = value;
		}
	}

	public virtual bool DropRelic
	{
		get
		{
			return _003CDropRelic_003Ek__BackingField;
		}
		set
		{
			_003CDropRelic_003Ek__BackingField = value;
		}
	}

	public virtual float ShieldTime
	{
		get
		{
			return _003CShieldTime_003Ek__BackingField;
		}
		set
		{
			_003CShieldTime_003Ek__BackingField = value;
		}
	}

	public uint DamagingZoneSeed
	{
		get
		{
			return _damagingZoneSeed;
		}
		set
		{
			_damagingZoneSeed = value;
		}
	}

	public unsafe override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_102f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1034: Expected O, but got Unknown
		//IL_10b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bb: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_116f: Expected O, but got I
		//IL_11a0: Expected I, but got O
		//IL_11d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dd: Expected O, but got Unknown
		//IL_046d: Expected F4, but got I4
		//IL_049d: Expected F4, but got I4
		//IL_0af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afc: Expected O, but got Unknown
		//IL_0b9e: Expected I, but got O
		//IL_0bf2: Expected I, but got O
		//IL_0c7b: Expected O, but got I
		//IL_0cb8: Expected O, but got I
		//IL_10e5: Expected I, but got O
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Expected O, but got Unknown
		//IL_111c: Expected I, but got O
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Expected O, but got Unknown
		//IL_0d69: Expected I, but got O
		//IL_0e08: Expected O, but got I
		//IL_0edb: Invalid comparison between I4 and F4
		//IL_12bc: Expected I4, but got O
		//IL_0162->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_01ca->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0391->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_01f9->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0228->IL0256: Incompatible stack heights: 1 vs 0
		//IL_03f7->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0256->IL0256: Incompatible stack heights: 1 vs 0
		//IL_0419->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0448->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_04bc->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_04e8->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0523->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_056d->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_05ad->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_05d9->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0bc1->IL0bc1: Incompatible stack heights: 1 vs 0
		//IL_060a->IL0fb7: Incompatible stack heights: 1 vs 0
		//IL_0c15->IL0c15: Incompatible stack heights: 1 vs 0
		//IL_0712->IL0712: Incompatible stack heights: 6 vs 0
		//IL_0d8c->IL0d8c: Incompatible stack heights: 1 vs 0
		//IL_0f63->IL0fb2: Incompatible stack heights: 0 vs 2
		//IL_0fb7->IL12c1: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		base.InitEnemy(enemyType, asRemote);
		_003COnDefeat_003Ek__BackingField = null;
		_hasRunDeathLogic = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		_hasDroppedTreasure = false;
		base._003CIsCullable_003Ek__BackingField = false;
		_shieldDamage = 0f;
		_isRunningDeathAnimation = false;
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		ArcadeSprite arcadeSprite2 = setAlpha(1f);
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite != null && ((UnityEngine.Object)ringSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0256;
		}
		Transform cachedTransform = _cachedTransform;
		Vector2 vector = default(Vector2);
		Vector2 vector2 = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			object obj3 = obj - 57;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj3);
			GameObject gameObject = base.gameObject;
			SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, vector, "vfx", "sPFX_ring_64");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)spriteRenderer != null)
			{
				((Renderer)spriteRenderer).SetMaterial(material);
				_ringSprite = spriteRenderer;
				GameManager gameManager = _gameManager;
				if ((object)_gameManager != null && gameManager._playerOptions != null)
				{
					PlayerOptionsData config = gameManager._playerOptions.Config;
					if (config != null)
					{
						bool flag2 = config._003CFlashingVFXEnabled_003Ek__BackingField;
						vector2 = vector;
						if (!flag2)
						{
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 0f);
							vector2 = vector;
						}
						goto IL_0256;
					}
				}
			}
		}
		goto IL_0fb7;
		IL_0fb7:
		throw new NullReferenceException();
		IL_0a43:
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_enterSprite, 0.5f);
		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_enterSprite, 1f);
		SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(_enterSprite2, 0.5f);
		SpriteRenderer spriteRenderer6 = RenderingExtensions.SetAlpha(_enterSprite2, 1f);
		if ((object)_enterSprite2 != null)
		{
			Transform transform = _enterSprite2.transform;
			if ((object)transform != null)
			{
				_ = -0f;
				Vector3 localEulerAngles = (Vector3)(obj - 41);
				transform.localEulerAngles = localEulerAngles;
				if (_alphaTween != null)
				{
					_alphaTween.Kill();
				}
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[2];
				if (array != null)
				{
					if ((object)_enterSprite != null)
					{
						nint num = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						bool flag3 = obj4 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if ((object)_enterSprite2 != null)
					{
						nint num2 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						bool flag4 = obj5 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						_ = 0;
						_ = 0;
						_ = 1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+67]");
						tweenConfig.alpha = (float?)(object)0;
						tweenConfig.ease = Ease.InOutSine;
						tweenConfig.duration = 600f;
						_ = 1082130432;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+67]");
						tweenConfig.scale = (float?)(object)0;
						MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
						_alphaTween = alphaTween;
						if (_rotTween != null)
						{
							_rotTween.Kill();
						}
						TweenConfig tweenConfig2 = new TweenConfig();
						object[] array2 = new object[1];
						if (array2 != null)
						{
							if ((object)_enterSprite2 != null)
							{
								nint num3 = (nint)array2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj6 = default(object);
								bool flag5 = obj6 == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig2 != null)
							{
								tweenConfig2.targets = array2;
								_ = 0;
								tweenConfig2.ease = Ease.InOutSine;
								tweenConfig2.duration = 600f;
								_ = 1135869952;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+67]");
								tweenConfig2.angle = (float?)(object)0;
								MultiTargetTween multiTargetTween = (_rotTween = Tweens.Add(tweenConfig2));
								Transform transform2 = (Transform)(object)damagingZone;
								bool flag6 = (object)damagingZone == null;
								float num4 = 1f;
								if (!flag6)
								{
									bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									num4 = 1f;
									if (!flag7)
									{
										multiTargetTween = (MultiTargetTween)(object)damagingZone;
										if ((object)damagingZone == null)
										{
											goto IL_0fb7;
										}
										num4 = (float)(multiTargetTween._isPaused ? 1 : 0) / 1000f;
										_damageZoneRespawnTimer = num4;
									}
								}
								if (!asRemote)
								{
									float num5 = UnityEngine.Random.Range(1f, 4.2949673E+09f);
									if (0f > num5)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
									}
									_damagingZoneSeed = (uint)(int)multiTargetTween;
									return;
								}
								Action<Pickup> b = OnRemoteItemInstantiated;
								Delegate obj7 = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b);
								if ((object)obj7 == null)
								{
									ItemInstantiator.OnRemoteItemInstantiated = null;
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								Action<Pickup> action = default(Action<Pickup>);
								bool flag8 = action == null;
								ItemInstantiator.OnRemoteItemInstantiated = action;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj8 = default(object);
								bool flag9 = obj8 == null;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0fb7;
		IL_0712:
		_shieldDamage = 0f;
		_hasShield = true;
		if (_shieldTimer != null)
		{
			_shieldTimer.Cancel();
		}
		float shieldTime = ShieldTime;
		Action onComplete = delegate
		{
			float hp = _hp - _shieldDamage;
			_hasShield = false;
			_hp = hp;
		};
		float duration = (float)vector2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer shieldTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_shieldTimer = shieldTimer;
		if (HasRelic)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config2 = core._playerOptions.Config;
				if (config2 != null)
				{
					if (!config2.HasCollectedItem(RelicToDrop))
					{
						DropRelic = true;
					}
					goto IL_1145;
				}
			}
			goto IL_0fb7;
		}
		goto IL_1145;
		IL_0256:
		SpriteRenderer posterSprite = _posterSprite;
		if ((object)_posterSprite != null && ((UnityEngine.Object)posterSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0712;
		}
		Transform cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag10 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			object obj9 = obj - 57;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Vector3*)obj9);
			SpriteRenderer spriteRenderer7 = RenderingExtensions.AddSprite(this, vector, "vfx", "CirclePoster01");
			Color? tintColor = (Color?)(object)(obj - 41);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			SpriteRenderer spriteRenderer8 = RenderingExtensions.SetTintFill(spriteRenderer7, isEnabled: true, tintColor);
			SpriteRenderer component2 = RenderingExtensions.SetAlpha(spriteRenderer8, 0.9f);
			SpriteRenderer spriteRenderer9 = RenderingExtensions.SetScale(component2, 0f);
			if ((object)spriteRenderer9 != null)
			{
				spriteRenderer9.enabled = false;
				Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
				((Renderer)spriteRenderer9).SetMaterial(material2);
				_posterSprite = spriteRenderer9;
				GameManager gameManager2 = _gameManager;
				if ((object)_gameManager != null && gameManager2._playerOptions != null)
				{
					PlayerOptionsData config3 = gameManager2._playerOptions.Config;
					if (config3 != null)
					{
						bool flag11 = config3._003CFlashingVFXEnabled_003Ek__BackingField;
						float num6 = 0f;
						if (!flag11)
						{
							SpriteRenderer spriteRenderer10 = RenderingExtensions.SetAlpha(_posterSprite, 0f);
							num6 = 0f;
						}
						if ((object)_posterSprite != null)
						{
							Transform transform3 = _posterSprite.transform;
							if ((object)transform3 != null)
							{
								transform3.SetParent(null, worldPositionStays: true);
								GameObject gameObject2 = new GameObject();
								if ((object)gameObject2 != null)
								{
									SpriteMask posterMask = gameObject2.AddComponent<SpriteMask>();
									_posterMask = posterMask;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
									if ((object)_posterMask != null)
									{
										Sprite sprite = default(Sprite);
										_posterMask.sprite = sprite;
										Transform transform4 = gameObject2.transform;
										if ((object)_posterSprite != null)
										{
											Transform parent = _posterSprite.transform;
											if ((object)transform4 != null)
											{
												transform4.SetParent(parent, worldPositionStays: true);
												if ((object)_posterMask != null)
												{
													Transform transform5 = _posterMask.transform;
													nint num7 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2440 @ rcx_v188 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num8 = 0;
													bool flag12 = (object)transform5 == null;
													Vector3 localPosition = (Vector3)(obj - 57);
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2465 @ rax_v228 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													transform5.localPosition = localPosition;
													bool flag13 = (object)_posterMask == null;
													Transform transform6 = _posterMask.transform;
													nint num9 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ rcx_v192 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num10 = 0;
													bool flag14 = (object)transform6 == null;
													vector2 = Vector3.zeroVector;
													Vector3 localScale = (Vector3)(obj - 41);
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2336 @ rax_v233 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													transform6.localScale = localScale;
													bool flag15 = (object)_posterSprite == null;
													_posterSprite.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
													bool flag16 = (object)_posterMask == null;
													_posterMask.enabled = false;
													goto IL_0712;
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
		goto IL_0fb7;
		IL_1145:
		_ = 0;
		_ = 1056964608;
		_ = 1;
		float scaleMul = _scaleMul;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rbp_v1+67]");
		ArcadeSprite arcadeSprite3 = setScale(scaleMul, (float?)(object)0);
		if (_onEnterTween != null)
		{
			TweenExtensions.Kill(_onEnterTween);
		}
		nint num11 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2025 @ rax_v57 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num12 = 0;
		_ = Vector3.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2026 @ rcx_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num13 = 0f * _scaleMul;
		Vector3 endValue = (Vector3)(obj - 41);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_onEnterTween = tweenerCore;
			Transform enterSprite = (Transform)(object)_enterSprite;
			if ((object)_enterSprite != null)
			{
				bool flag17 = ((UnityEngine.Object)enterSprite).m_CachedPtr != (IntPtr)0;
				string text = null;
				if (flag17)
				{
					goto IL_0a43;
				}
			}
			if ((object)_cachedTransform != null)
			{
				Vector3 vector3 = _cachedTransform.position;
				_ = vector3.z;
				_ = vector3.x;
				SpriteRenderer component3 = RenderingExtensions.AddSprite(this, vector, "ThosePeople", "TP_VFX_Diabologue01");
				SpriteRenderer spriteRenderer11 = RenderingExtensions.SetScale(component3, 0f);
				SpriteRenderer enterSprite2 = RenderingExtensions.SetBlendMode(spriteRenderer11, BlendMode.Add);
				_enterSprite = enterSprite2;
				if ((object)_cachedTransform != null)
				{
					Vector3 vector4 = _cachedTransform.position;
					_ = vector4.z;
					_ = vector4.x;
					SpriteRenderer component4 = RenderingExtensions.AddSprite(this, vector, "ThosePeople", "TP_VFX_Diabologue02");
					SpriteRenderer spriteRenderer12 = RenderingExtensions.SetScale(component4, 0f);
					SpriteRenderer enterSprite3 = RenderingExtensions.SetBlendMode(spriteRenderer12, BlendMode.Add);
					_enterSprite2 = enterSprite3;
					string text = "TP_VFX_Diabologue02";
					goto IL_0a43;
				}
			}
		}
		goto IL_0fb7;
	}

	private void OnRemoteItemInstantiated(Pickup pickup)
	{
		//IL_0038: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_01fb: Expected I, but got O
		//IL_0203: Expected I, but got O
		//IL_0213: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_024f: Expected O, but got I
		//IL_00eb: Expected I4, but got O
		if (pickup._003CPickupType_003Ek__BackingField == ItemType.RELIC)
		{
			nint num = (nint)typeof(PickupRelic);
			nint num2 = (nint)pickup;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v14+FFFFFFF8+v69 @ rax_v13*8]");
				if (0 == (nint)typeof(PickupRelic))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ rdx (VampireSurvivors.Objects.Pickups.Pickup)+1F0]");
					if ((nint)0 == (nint)RelicToDrop)
					{
						object obj4 = default(object);
						object obj3 = (ItemType)obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
						object message = default(object);
						Debug.Log(message);
						OnRelicSpawned((PickupRelic)pickup);
						Action<Pickup> value = OnRemoteItemInstantiated;
						Delegate obj5 = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value);
						if ((object)obj5 == null)
						{
							ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj5;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							Action<Pickup> action = default(Action<Pickup>);
							if (action == null)
							{
								throw new InvalidCastException();
							}
							ItemInstantiator.OnRemoteItemInstantiated = action;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj6 = default(object);
							if (obj6 == null)
							{
								throw new InvalidCastException();
							}
						}
					}
				}
			}
		}
		if (pickup._003CPickupType_003Ek__BackingField != ItemType.WEAPON)
		{
			return;
		}
		nint num4 = (nint)typeof(PickupWeapon);
		nint num5 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		if (num6 < 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v10+FFFFFFF8+v162 @ rax_v9*8]");
		if (0 == (nint)typeof(PickupWeapon))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ rdx (VampireSurvivors.Objects.Pickups.Pickup)+1F0]");
			if ((nint)0 == (nint)WeaponToDrop)
			{
				OnWeaponSpawned(pickup);
			}
		}
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_02bd: Invalid comparison between F4 and I4
		//IL_0335: Invalid comparison between I4 and F4
		//IL_0363: Expected O, but got I4
		//IL_037f: Expected O, but got F4
		//IL_00c2: Expected F4, but got O
		//IL_0325->IL02ad: Incompatible stack heights: 1 vs 0
		//IL_03f9->IL02ad: Incompatible stack heights: 1 vs 0
		//IL_00c7->IL00c7: Incompatible stack heights: 1 vs 0
		//IL_029e->IL029e: Incompatible stack heights: 1 vs 0
		if (!(value > 0f))
		{
			goto IL_00c7;
		}
		Vector3 ret;
		Vector2 vector = default(Vector2);
		float num = default(float);
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				if (!config._003CDamageNumbersEnabled_003Ek__BackingField)
				{
					goto IL_00c7;
				}
				object cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v12 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v12 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					if ((object)_gameManager != null)
					{
						_gameManager.ShowDamageAt(vector, value);
						num = (float)vector;
						goto IL_00c7;
					}
				}
			}
		}
		goto IL_02ad;
		IL_029e:
		bool hasKb2 = default(bool);
		base.OnGetDamaged(showHitVfx, hasKb2);
		return;
		IL_00c7:
		object obj = default(object);
		float num2;
		if (!_hasShield)
		{
			num = (_hp -= value);
			if ((nint)obj == (nint)OHKOWeaponType)
			{
				bool flag2 = obj == null;
				num2 = num;
				if (!flag2)
				{
					goto IL_014a;
				}
			}
		}
		else
		{
			if ((nint)obj == (nint)OHKOWeaponType && obj != null)
			{
				_hasShield = false;
				if (_shieldTimer != null)
				{
					_shieldTimer.Cancel();
					num2 = num;
					goto IL_014a;
				}
				goto IL_02ad;
			}
			float shieldDamage = value + _shieldDamage;
			_shieldDamage = shieldDamage;
		}
		goto IL_032a;
		IL_02ad:
		throw new NullReferenceException();
		IL_032a:
		if (0f < _hp)
		{
			_damageKb = damageKb;
		}
		else
		{
			Die();
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float num3 = num - 0.5f;
		float num4 = num3 * 500f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, time);
		if (showHitVfx == HitVfxType.None)
		{
			goto IL_029e;
		}
		object cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdi_v11 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ rdi_v11 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out ret);
			if ((object)_gameManager != null)
			{
				VFXManager.SpawnImpactVFX(showHitVfx, vector);
				goto IL_029e;
			}
		}
		goto IL_02ad;
		IL_014a:
		OnOHKO();
		num = num2;
		goto IL_032a;
	}

	public unsafe virtual void CheckAssassin()
	{
		//IL_005e: Expected O, but got I4
		//IL_0066: Expected O, but got Ref
		if (Assassin != CharacterType.VOID)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core == null || core._characters == null)
			{
				throw new NullReferenceException();
			}
			List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	public virtual void OnOHKO()
	{
		//IL_0080: Expected I8, but got O
		//IL_008f: Expected I8, but got O
		if (!_hasRunOneHKOLogic && _coherenceSync.HasStateAuthority)
		{
			_hasRunOneHKOLogic = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				OneHitKoLogic();
				return;
			}
			Action<long> action = null;
			((Enemy_TP_GateBoss)(object)action).OneHitKoOnline((long)this);
			((Enemy_TP_GateBoss)(object)action).OneHitKoOnline((long)this);
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
			bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	public void OneHitKoOnline(long startingClientFrame)
	{
		Action onSyncedTimer = OneHitKoLogic;
		OnlineStageManager._instance.FireSyncTimer(startingClientFrame, onSyncedTimer);
	}

	private void OneHitKoLogic()
	{
		//IL_0184: Expected O, but got I4
		//IL_01a0: Expected O, but got F4
		_003C_003Ec__DisplayClass68_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass68_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		if (OHKOSecretUnlock == SecretType.none)
		{
			return;
		}
		CS_0024_003C_003E8__locals8.PlayCoffinAnimation = false;
		if (OHKOCharacterUnlock != CharacterType.VOID)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
			object obj = default(object);
			if (obj == null)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				bool flag = core2._playerOptions.UnlockSecret(OHKOSecretUnlock, config2);
				CS_0024_003C_003E8__locals8.PlayCoffinAnimation = true;
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		float detune = (float)obj3 * -600f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Crystal12, soundConfig, 0f, 10, time);
		Action onComplete = delegate
		{
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			instance.Shake("LightningOniShake");
			Action onComplete2 = CS_0024_003C_003E8__locals8._003C_003E9__1;
			if (CS_0024_003C_003E8__locals8._003C_003E9__1 == null)
			{
				onComplete2 = (CS_0024_003C_003E8__locals8._003C_003E9__1 = delegate
				{
					//IL_001c: Expected O, but got I4
					if (CS_0024_003C_003E8__locals8.PlayCoffinAnimation)
					{
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Volume = (float?)(object)1;
						soundConfig2.Detune = -1000f;
						soundConfig2.Rate = 0.5f;
						float time2 = default(float);
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ThingFound, soundConfig2, 0f, 10, time2);
					}
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.096f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Enemy_TP_GateBoss enemy_TP_GateBoss = CS_0024_003C_003E8__locals8._003C_003E4__this;
			enemy_TP_GateBoss._hp = 0f;
		};
		GM.Core.FrameFreeze(onComplete);
	}

	public override void Disappear()
	{
		if (!_hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x1876CA430\"");
		}
	}

	protected override void Die()
	{
		if (!_hasRunDeathLogic && _coherenceSync.HasStateAuthority)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 46 Invalid \"Jump target not found in method: 0x1876CA430\"");
		}
	}

	private void KillGateBoss()
	{
		_hasRunDeathLogic = true;
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			DeathLogic();
			return;
		}
		Action action = DeathTrigger;
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All);
	}

	public void DeathTrigger()
	{
		DeathLogic();
	}

	protected virtual void DeathLogic()
	{
		CheckAssassin();
		base.Die();
		CustomDeathLogic();
	}

	protected virtual void CustomDeathLogic()
	{
		Action action = _003COnDefeat_003Ek__BackingField;
		if (_003COnDefeat_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v32.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		DeathScream();
		if (HasTreasureChest)
		{
			DropTreasure();
		}
		if (animTimer != null)
		{
			animTimer.Cancel();
		}
		Action onComplete = delegate
		{
			DoDeathAnimation();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		animTimer = timer;
		if (relicDropTimer != null)
		{
			relicDropTimer.Cancel();
		}
		Action onComplete2 = delegate
		{
			//IL_01f5: Expected I, but got O
			//IL_0203: Expected I, but got O
			//IL_0213: Expected O, but got I
			//IL_0293: Expected O, but got I4
			//IL_024f: Expected O, but got I
			//IL_0285: Expected O, but got I4
			//IL_0338: Expected I, but got O
			//IL_0340: Expected I, but got O
			//IL_0350: Expected O, but got I
			//IL_03d0: Expected O, but got I4
			//IL_038c: Expected O, but got I
			//IL_03c2: Expected O, but got I4
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			if (!HasRelic)
			{
				if (WeaponToDrop != WeaponType.VOID)
				{
					float2 float5 = base.position;
					Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponToDrop, value, relicType, validatePickups);
					if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
					{
						OnWeaponSpawned(pickup);
					}
				}
				return;
			}
			if (!DropRelic)
			{
				if (AlternativePrize != ItemType.VOID)
				{
					float2 float6 = base.position;
					Pickup pickup2 = GM.Core.MakeStagePickup(pos, AlternativePrize, WeaponType.VOID, value, relicType, validatePickups);
					if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
					{
						pickup2._003CAutoSafeXY_003Ek__BackingField = true;
					}
				}
				return;
			}
			PlayerOptionsData config = _playerOptions.Config;
			if (config.HasCollectedItem(RelicToDrop))
			{
				return;
			}
			float2 float7 = base.position;
			Pickup pickup3 = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
			object obj3;
			if ((object)pickup3 != null)
			{
				nint num = (nint)pickup3;
				nint num2 = (nint)typeof(PickupRelic);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v50+FFFFFFF8+v634 @ rax_v46*8]");
					if (0 == (nint)typeof(PickupRelic))
					{
						obj3 = 1;
						goto IL_04c3;
					}
				}
				obj3 = 0;
				goto IL_04c3;
			}
			PickupRelic pickupRelic = null;
			goto IL_04ea;
			IL_050c:
			object obj4;
			bool flag = obj4 == null;
			BackgroundTP_Basic backgroundTP_Basic = null;
			Stage stage;
			if (!flag)
			{
				backgroundTP_Basic = (BackgroundTP_Basic)stage._fancyBg;
			}
			goto IL_0533;
			IL_04ea:
			if ((object)pickupRelic == null || ((UnityEngine.Object)pickupRelic).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			GameManager core = GM.Core;
			stage = core._stage;
			BackgroundTP_Basic fancyBg = (BackgroundTP_Basic)stage._fancyBg;
			bool flag2 = (object)stage._fancyBg == null;
			backgroundTP_Basic = null;
			if (!flag2)
			{
				nint num4 = (nint)typeof(BackgroundTP_Basic);
				nint num5 = (nint)fancyBg;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ rax_v39+FFFFFFF8+v796 @ rax_v35*8]");
					if (0 == (nint)typeof(BackgroundTP_Basic))
					{
						obj4 = 1;
						goto IL_050c;
					}
				}
				obj4 = 0;
				goto IL_050c;
			}
			goto IL_0533;
			IL_0533:
			if ((object)backgroundTP_Basic != null && ((UnityEngine.Object)backgroundTP_Basic).m_CachedPtr != (IntPtr)0)
			{
				float2 pos2 = pickupRelic.position;
				float2 float8 = backgroundTP_Basic.RestrictInsideAwakeBounds(pos2);
				pickupRelic.position = float8;
			}
			OnRelicSpawned(pickupRelic);
			return;
			IL_04c3:
			bool flag3 = obj3 == null;
			pickupRelic = null;
			if (!flag3)
			{
				pickupRelic = (PickupRelic)pickup3;
			}
			goto IL_04ea;
		};
		Timer timer2 = Timers.Register(1.5000001f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		relicDropTimer = timer2;
	}

	private void OnWeaponSpawned(Pickup p)
	{
		//IL_0038: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		p._003CAutoSafeXY_003Ek__BackingField = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1.25f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicChargeHeavy, soundConfig, 150f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1.2f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_MagicChargeHeavy, soundConfig2, 150f, 3, time);
		Transform t = p.transform;
		PlayPosterAnimation(t);
	}

	private void OnRelicSpawned(PickupRelic p)
	{
		//IL_00ad: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		((Pickup)p)._003CAutoSafeXY_003Ek__BackingField = true;
		Delegate b = _003C_003Ec._003C_003E9__76_0;
		if (_003C_003Ec._003C_003E9__76_0 == null)
		{
			Action<float> action = null;
			float x = default(float);
			((_003C_003Ec)(object)action)._003COnRelicSpawned_003Eb__76_0(x);
			_003C_003Ec._003C_003E9__76_0 = action;
			b = action;
		}
		Delegate obj = Delegate.Combine(p._onPickedUpCallback, b);
		Action<float> action2 = default(Action<float>);
		if ((object)obj == null)
		{
			action2 = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if (action2 == null)
			{
				throw new InvalidCastException();
			}
		}
		p._onPickedUpCallback = action2;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Teleport, soundConfig, 150f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1.9f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Teleport, soundConfig2, 150f, 3, time);
		Transform transform = p.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 297 Invalid \"Jump target not found in method: 0x1876CAF60\"");
		throw new NullReferenceException();
	}

	private void DropTreasure()
	{
		//IL_0188->IL0102: Incompatible stack heights: 1 vs 0
		//IL_0102->IL018d: Incompatible stack heights: 1 vs 0
		if (_hasDroppedTreasure)
		{
			return;
		}
		_hasDroppedTreasure = true;
		Treasure treasure = new Treasure();
		if (treasure != null)
		{
			treasure._003Cchances_003Ek__BackingField = TreasureChances;
			treasure._003CprizeTypes_003Ek__BackingField = TreasurePrizeTypes;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)core._stage != null)
			{
				int num = core._stage.SetTreasureLevelFromChance(treasure);
				Enemy_TP_GateBoss cachedTransform = (Enemy_TP_GateBoss)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					if ((object)GM.Core != null)
					{
						Vector2 pos = default(Vector2);
						TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PlayPosterAnimation(Transform t)
	{
		//IL_043d: Expected O, but got Ref
		//IL_044e: Expected O, but got I8
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_04c5: Expected O, but got I4
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		//IL_0134->IL02d3: Incompatible stack heights: 9 vs 0
		//IL_04b2->IL02d3: Incompatible stack heights: 9 vs 0
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		if ((object)_posterMask != null)
		{
			_posterMask.enabled = true;
			if ((object)_posterSprite != null)
			{
				Transform transform = _posterSprite.transform;
				if ((object)t != null)
				{
					bool flag = ((UnityEngine.Object)t).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)t).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag4 = (object)_posterMask == null;
					Transform transform2 = _posterMask.transform;
					bool flag5 = (object)transform2 == null;
					bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
					bool flag7 = (object)_posterSprite == null;
					_posterSprite.enabled = true;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_posterSprite, 2f);
					Transform posterSprite = (Transform)(object)_posterSprite;
					bool flag8 = (object)_posterSprite == null;
					bool flag9 = ((UnityEngine.Object)posterSprite).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)posterSprite).m_CachedPtr, 4000);
					if (posterTween != null)
					{
						TweenExtensions.Kill(posterTween);
					}
					if ((object)_posterMask != null)
					{
						Transform target = _posterMask.transform;
						tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&value), 0.4f);
						object obj = 6603577472L;
						TweenCallback tweenCallback2;
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
								bool flag10 = (nint)0 == 0;
								_ = 0;
								if (!flag10)
								{
									object obj2 = tweenerCore + 184;
									object obj3 = obj2 >> 12;
									object obj4 = obj3 & 0x1FFFFF;
									object obj5 = obj4 >> 6;
									object obj6 = obj4 & 0x3F;
									nint num2;
									do
									{
										object obj7 = 1 << (int)obj6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbp_v13+462E0+v1080 @ rdx_v45*8]");
										object obj8 = 0 | obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbp_v13+462E0+v1080 @ rdx_v45*8]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbp_v13+462E0+v1080 @ rdx_v45*8]");
										if (num == 0)
										{
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbp_v13+462E0+v1080 @ rdx_v45*8]");
										num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rbp_v13+462E0+v1080 @ rdx_v45*8]");
									}
									while (num2 != 0);
									TweenCallback tweenCallback = delegate
									{
										_posterSprite.enabled = false;
										_posterMask.enabled = false;
									};
									tweenCallback2 = tweenCallback;
									goto IL_0256;
								}
							}
						}
						TweenCallback tweenCallback3 = delegate
						{
							_posterSprite.enabled = false;
							_posterMask.enabled = false;
						};
						bool flag11 = tweenerCore == null;
						tweenCallback2 = tweenCallback3;
						if (!flag11)
						{
							goto IL_0256;
						}
						goto IL_0285;
					}
				}
			}
		}
		goto IL_02d3;
		IL_02d3:
		throw new NullReferenceException();
		IL_0256:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0285;
		IL_0285:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			posterTween = tweenerCore;
			return;
		}
		goto IL_02d3;
	}

	protected void DeathScream()
	{
		//IL_01d1: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		if (screamTween != null)
		{
			screamTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
		{
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale((SpriteRenderer)(object)transform, 0f);
			if ((object)spriteRenderer2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = targets;
		tweenConfig.duration = 300f;
		tweenConfig.repeat = 1;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			if ((object)_ringSprite != null)
			{
				Transform transform2 = _ringSprite.transform;
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag4 = (object)_ringSprite == null;
					_ringSprite.enabled = true;
					return;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			_ringSprite.enabled = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		screamTween = multiTargetTween;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_00a5: Invalid comparison between I4 and F4
		//IL_0164: Expected O, but got I4
		//IL_01b2->IL01fe: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		if (!DoWiggle)
		{
			base.angle = 0f;
		}
		DamagingZonePrefab damagingZonePrefab = damagingZone;
		if ((object)damagingZone == null || ((UnityEngine.Object)damagingZonePrefab).m_CachedPtr == (IntPtr)0 || !base.CanUseAbility())
		{
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		if (!(0f < (_damageZoneRespawnTimer -= deltaTime)))
		{
			DamagingZonePrefab damagingZonePrefab2 = damagingZone;
			Transform transform = base.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			int num = (int)(_damagingZoneSeed << 13);
			int num2 = num ^ (int)_damagingZoneSeed;
			damagingZonePrefab2._originLocation = ret;
			int num3 = num2 >> 17;
			int num4 = num2 ^ num3;
			int num5 = num4 << 5;
			int num6 = num5 ^ num4;
			bool flag2 = damagingZonePrefab2.spawnType == DamagingZonePrefab.SpawnType.CROSSHATCH;
			damagingZonePrefab2._random = (Unity.Mathematics.Random)num6;
			if (!flag2)
			{
				damagingZonePrefab2.SpawnPattern();
			}
			else
			{
				damagingZonePrefab2.SpawnCrosshatchPattern();
			}
			DamagingZonePrefab damagingZonePrefab3 = damagingZone;
			float damageZoneRespawnTimer = damagingZonePrefab3.respawnCooldown / 1000f;
			_damageZoneRespawnTimer = damageZoneRespawnTimer;
		}
	}

	protected unsafe virtual void DoDeathAnimation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00c5: Expected I, but got O
		//IL_014c: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_01cf: Expected O, but got I
		//IL_028a: Expected O, but got I
		//IL_044b: Expected O, but got Ref
		//IL_046e: Expected native int or pointer, but got O
		//IL_0488: Expected O, but got I
		//IL_04a8: Expected O, but got Ref
		//IL_04c2: Expected native int or pointer, but got O
		//IL_04dc: Expected O, but got I
		//IL_04fc: Expected O, but got Ref
		//IL_0516: Expected native int or pointer, but got O
		//IL_0530: Expected O, but got I
		//IL_0550: Expected O, but got Ref
		//IL_056a: Expected native int or pointer, but got O
		//IL_08eb: Expected O, but got I4
		//IL_058f: Expected O, but got Ref
		//IL_05b6: Expected O, but got I
		//IL_05d0: Expected native int or pointer, but got O
		//IL_0925: Expected O, but got I
		//IL_0608: Expected O, but got Ref
		//IL_062f: Expected O, but got I
		//IL_0649: Expected native int or pointer, but got O
		//IL_095f: Expected O, but got I
		//IL_06b1: Expected I, but got O
		//IL_06d5: Expected O, but got I
		//IL_098c: Expected O, but got Ref
		//IL_085a->IL0892: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_003C_003Ec__DisplayClass81_0 CS_0024_003C_003E8__locals35 = new _003C_003Ec__DisplayClass81_0();
		if (CS_0024_003C_003E8__locals35 != null)
		{
			CS_0024_003C_003E8__locals35._003C_003E4__this = this;
			if (_isRunningDeathAnimation)
			{
				return;
			}
			base._003CIsDead_003Ek__BackingField = true;
			_isRunningDeathAnimation = true;
			if (scaleTween != null)
			{
				scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					_ = 0;
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
					tweenConfig.scaleX = (float?)(object)0;
					_ = 0;
					float num2 = base.scale;
					float num3 = num2 * 1.5f;
					_ = 1;
					tweenConfig.ease = Ease.InOutBounce;
					tweenConfig.duration = 1800f;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
					tweenConfig.scaleY = (float?)(object)0;
					_ = 1041865114;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
					tweenConfig.alpha = (float?)(object)0;
					MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
					scaleTween = multiTargetTween;
					GameObject gameObject = base.gameObject;
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ rbx_v12 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					_ = 0;
					ParticleEmitterManager particleManager;
					if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256))))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
						particleManager = (ParticleEmitterManager)0;
					}
					else
					{
						particleManager = gameObject.AddComponent<ParticleEmitterManager>();
					}
					CS_0024_003C_003E8__locals35.particleManager = particleManager;
					nint num5 = 0;
					Circle circle = new Circle();
					circle._x = 0f;
					circle._radius = 32f;
					EmitZone emitZone = new EmitZone();
					emitZone._type = EmitZoneType.Random;
					emitZone._source = circle;
					CS_0024_003C_003E8__locals35.emitZone = emitZone;
					ParticleSystem deathVfxParticleSystem = _deathVfxParticleSystem1;
					if ((object)_deathVfxParticleSystem1 == null || ((UnityEngine.Object)deathVfxParticleSystem).m_CachedPtr == (IntPtr)0)
					{
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
						List<string> list = new List<string>();
						list.Add("TP_VFX_Fire19");
						list.Add("TP_VFX_Fire20");
						list.Add("TP_VFX_Fire21");
						list.Add("TP_VFX_Fire22");
						list.Add("TP_VFX_Fire23");
						list.Add("TP_VFX_Fire24");
						list.Add("TP_VFX_Fire25");
						list.Add("TP_VFX_Fire26");
						list.Add("TP_VFX_Fire27");
						list.Add("TP_VFX_Fire28");
						list.Add("TP_VFX_Fire29");
						particleSystemConfig._frame = list;
						ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
						particleSystemConfig._fps = 16;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
						particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
						particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
						particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(400f, 600f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
						_ = 0;
						particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
						_ = 0;
						_ = 3;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
						particleSystemConfig._quantity = (int?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 2f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-58]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-48]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
						_ = 0;
						_ = 1065353216;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
						particleSystemConfig._frequency = (float?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+98]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-30]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-20]");
						_ = 0;
						particleSystemConfig._emitZone = CS_0024_003C_003E8__locals35.emitZone;
						particleSystemConfig._on = true;
						ParticleSystem deathVfxParticleSystem2 = CS_0024_003C_003E8__locals35.particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
						_deathVfxParticleSystem1 = deathVfxParticleSystem2;
						num5 = unchecked((nint)null);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj4 == null)
							{
								MissingMethodException ex2 = new MissingMethodException();
								throw ex2;
							}
						}
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2614 @ rax_v137 (should have been resolved before IL gen)");
					}
					Transform transform = _deathVfxParticleSystem1.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					RenderingExtensions.Start(_deathVfxParticleSystem1);
					if (exploTimer1 != null)
					{
						exploTimer1.Cancel();
					}
					if (exploTimer2 != null)
					{
						exploTimer2.Cancel();
					}
					Action onComplete = _003C_003Ec._003C_003E9__81_0;
					if (_003C_003Ec._003C_003E9__81_0 == null)
					{
						onComplete = (_003C_003Ec._003C_003E9__81_0 = delegate
						{
							//IL_0033: Expected F4, but got I4
							float? volume = default(float?);
							float rate = default(float);
							float detune = default(float);
							bool loop = default(bool);
							PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
						});
					}
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(0.125f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					exploTimer1 = timer;
					Action onComplete2 = delegate
					{
						//IL_0008: Expected O, but got Ref
						//IL_00c7: Expected O, but got I4
						//IL_0187: Expected O, but got I
						//IL_01fd: Expected O, but got I
						//IL_0234: Expected O, but got I
						//IL_02aa: Expected O, but got I
						//IL_02e1: Expected O, but got I
						//IL_0357: Expected O, but got I
						//IL_038e: Expected O, but got I
						//IL_0404: Expected O, but got I
						//IL_043b: Expected O, but got I
						//IL_04b1: Expected O, but got I
						//IL_04e8: Expected O, but got I
						//IL_055e: Expected O, but got I
						//IL_0e2a: Expected I, but got O
						//IL_0595: Expected O, but got I
						//IL_060b: Expected O, but got I
						//IL_0642: Expected O, but got I
						//IL_06b8: Expected O, but got I
						//IL_06ef: Expected O, but got I
						//IL_0765: Expected O, but got I
						//IL_079c: Expected O, but got I
						//IL_0812: Expected O, but got I
						//IL_0849: Expected O, but got I
						//IL_08bf: Expected O, but got I
						//IL_090c: Expected O, but got Ref
						//IL_092f: Expected native int or pointer, but got O
						//IL_0949: Expected O, but got I
						//IL_0969: Expected O, but got Ref
						//IL_0983: Expected native int or pointer, but got O
						//IL_099d: Expected O, but got I
						//IL_09bd: Expected O, but got Ref
						//IL_09d7: Expected native int or pointer, but got O
						//IL_09f1: Expected O, but got I
						//IL_0a11: Expected O, but got Ref
						//IL_0a2b: Expected native int or pointer, but got O
						//IL_0f52: Expected O, but got I4
						//IL_0a56: Expected O, but got Ref
						//IL_0a77: Expected O, but got I
						//IL_0a91: Expected native int or pointer, but got O
						//IL_0f8c: Expected O, but got I
						//IL_0acf: Expected O, but got Ref
						//IL_0af0: Expected O, but got I
						//IL_0b0a: Expected native int or pointer, but got O
						//IL_0fc6: Expected O, but got I
						//IL_1024: Expected O, but got I
						//IL_10c9: Expected O, but got Ref
						//IL_0ef3->IL0e6d: Incompatible stack heights: 1 vs 0
						//IL_0cde->IL0e6d: Incompatible stack heights: 7 vs 0
						//IL_0dc7->IL0e6d: Incompatible stack heights: 7 vs 0
						//IL_0e1d->IL0e6d: Incompatible stack heights: 7 vs 0
						//IL_10d8->IL0f1f: Incompatible stack heights: 18 vs 1
						//IL_0bfa->IL10bb: Incompatible stack heights: 19 vs 18
						object obj7 = default(object);
						object obj6 = (object)(&obj7);
						_ = 0;
						if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
						{
							ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals35._003C_003E4__this.setVisible(visible: false);
							Enemy_TP_GateBoss enemy_TP_GateBoss = CS_0024_003C_003E8__locals35._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
							{
								Enemy_TP_GateBoss deathVfxParticleSystem3 = (Enemy_TP_GateBoss)(object)enemy_TP_GateBoss._deathVfxParticleSystem1;
								if ((object)enemy_TP_GateBoss._deathVfxParticleSystem1 != null)
								{
									bool flag2 = ((UnityEngine.Object)deathVfxParticleSystem3).m_CachedPtr == (IntPtr)0;
									ParticleSystem.Stop_Injected(((UnityEngine.Object)deathVfxParticleSystem3).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
									Enemy_TP_GateBoss enemy_TP_GateBoss2 = CS_0024_003C_003E8__locals35._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
									{
										object deathVfxParticleSystem4 = enemy_TP_GateBoss2._deathVfxParticleSystem2;
										Transform transform2;
										if ((object)enemy_TP_GateBoss2._deathVfxParticleSystem2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rbx_v11 (System.Object)+10]");
											bool flag3 = (nint)0 != 0;
											transform2 = (Transform)1;
											if (flag3)
											{
												goto IL_0f1f;
											}
										}
										Circle source = new Circle
										{
											_x = 0f,
											_radius = 16f
										};
										EmitZone emitZone2 = new EmitZone
										{
											_type = EmitZoneType.Random,
											_source = source
										};
										ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("ThosePeople");
										List<string> list2 = new List<string>();
										bool flag4 = list2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num6 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rcx_v62+18]");
										if (num6 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire19");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj9 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rcx_v64+18]");
										if (num7 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire20");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj11 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag7 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ rcx_v66+18]");
										if (num8 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire21");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj13 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag8 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1100 @ rcx_v68+18]");
										if (num9 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire22");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj15 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj16 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag9 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1101 @ rcx_v70+18]");
										if (num10 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire23");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj17 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj18 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag10 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num11 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1102 @ rcx_v72+18]");
										if (num11 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire24");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj19 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag11 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1103 @ rcx_v74+18]");
										if (num12 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire25");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj21 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj22 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag12 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1104 @ rcx_v76+18]");
										if (num13 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire26");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj23 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj24 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag13 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ rcx_v78+18]");
										if (num14 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire27");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj25 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj26 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag14 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rcx_v80+18]");
										if (num15 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire28");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj27 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj28 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag15 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num16 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1107 @ rcx_v82+18]");
										if (num16 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire29");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1323 @ rax_v76 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj29 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										bool flag16 = particleSystemConfig2 == null;
										particleSystemConfig2._frame = list2;
										ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj7, 24));
										particleSystemConfig2._fps = 16;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(500f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
										particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 8));
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
										particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 40));
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(-80f, -100f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
										particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 72));
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(200f, 400f));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
										_ = 0;
										particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
										_ = 0;
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 104));
										_ = 3;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
										particleSystemConfig2._quantity = (int?)(object)0;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1f, 1f));
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
										particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
										_ = 0;
										_ = 0;
										ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 136));
										_ = 1065353216;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
										particleSystemConfig2._frequency = (float?)(object)0;
										_ = 0;
										_ = 0;
										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(1f, 0f));
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
										_ = 0;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
										particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
										_ = 0;
										particleSystemConfig2._emitZone = CS_0024_003C_003E8__locals35.emitZone;
										particleSystemConfig2._on = true;
										bool flag17 = (object)CS_0024_003C_003E8__locals35.particleManager == null;
										ParticleSystem particleSystem = CS_0024_003C_003E8__locals35.particleManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
										bool flag18 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
										transform2 = null;
										Enemy_TP_GateBoss enemy_TP_GateBoss3 = CS_0024_003C_003E8__locals35._003C_003E4__this;
										bool flag19 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
										bool flag20 = (object)enemy_TP_GateBoss3._deathVfxParticleSystem2 == null;
										_ = enemy_TP_GateBoss3._deathVfxParticleSystem2;
										_ = enemy_TP_GateBoss3._deathVfxParticleSystem2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
										object obj30 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
											bool flag21 = obj30 == null;
										}
										object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 272));
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2789 @ rax_v118 (should have been resolved before IL gen)");
										goto IL_0f1f;
									}
								}
							}
						}
						goto IL_0e6d;
						IL_0e6d:
						throw new NullReferenceException();
						IL_0f1f:
						Enemy_TP_GateBoss enemy_TP_GateBoss4 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						bool flag22 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
						bool flag23 = (object)enemy_TP_GateBoss4._deathVfxParticleSystem2 == null;
						Transform transform3 = enemy_TP_GateBoss4._deathVfxParticleSystem2.transform;
						bool flag24 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
						bool flag25 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
						Vector3 value2 = default(Vector3);
						Transform.set_localPosition_Injected((IntPtr)0, ref value2);
						Enemy_TP_GateBoss enemy_TP_GateBoss5 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						bool flag26 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
						RenderingExtensions.Start(enemy_TP_GateBoss5._deathVfxParticleSystem2);
						Enemy_TP_GateBoss enemy_TP_GateBoss6 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						bool flag27 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
						if (enemy_TP_GateBoss6.deathTimer1 != null)
						{
							enemy_TP_GateBoss6.deathTimer1.Cancel();
						}
						Enemy_TP_GateBoss enemy_TP_GateBoss7 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
						{
							if (enemy_TP_GateBoss7.deathTimer2 != null)
							{
								enemy_TP_GateBoss7.deathTimer2.Cancel();
							}
							Action onComplete3 = CS_0024_003C_003E8__locals35._003C_003E9__2;
							Enemy_TP_GateBoss enemy_TP_GateBoss8 = CS_0024_003C_003E8__locals35._003C_003E4__this;
							if (CS_0024_003C_003E8__locals35._003C_003E9__2 == null)
							{
								onComplete3 = (CS_0024_003C_003E8__locals35._003C_003E9__2 = delegate
								{
									Enemy_TP_GateBoss enemy_TP_GateBoss10 = CS_0024_003C_003E8__locals35._003C_003E4__this;
									enemy_TP_GateBoss10._deathVfxParticleSystem2.Stop();
								});
							}
							bool useRealTime2 = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							Timer timer3 = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
							{
								enemy_TP_GateBoss8.deathTimer1 = timer3;
								object obj32 = CS_0024_003C_003E8__locals35._003C_003E4__this;
								Enemy_TP_GateBoss enemy_TP_GateBoss9 = CS_0024_003C_003E8__locals35._003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1682 @ r8_v15 (Il2CppClass<System.Object>)+3A0]");
								Action onComplete4 = new Action(enemy_TP_GateBoss9, (IntPtr)0);
								if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
								{
									nint num17 = (nint)obj32;
									Timer timer4 = Timers.Register(2f, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
									return;
								}
							}
						}
						goto IL_0e6d;
					};
					Timer timer2 = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					exploTimer2 = timer2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (animTimer != null)
		{
			animTimer.Cancel();
		}
		if (relicDropTimer != null)
		{
			relicDropTimer.Cancel();
		}
		if (posterTween != null)
		{
			TweenExtensions.Kill(posterTween);
		}
		if (scaleTween != null)
		{
			scaleTween.Kill();
		}
		if (exploTimer1 != null)
		{
			exploTimer1.Cancel();
		}
		if (exploTimer2 != null)
		{
			exploTimer2.Cancel();
		}
		if (deathTimer1 != null)
		{
			deathTimer1.Cancel();
		}
		if (deathTimer2 != null)
		{
			deathTimer2.Cancel();
		}
		if (screamTween != null)
		{
			screamTween.Kill();
		}
		base.Despawn();
	}

	public Enemy_TP_GateBoss()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_043f: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0467: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_019d: Expected O, but got I
		//IL_01f7: Expected O, but got I
		//IL_01dc: Expected O, but got I4
		//IL_049e: Expected O, but got I
		//IL_0261: Expected O, but got I
		//IL_0246: Expected O, but got I4
		//IL_04c6: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_02b0: Expected O, but got I4
		//IL_04ee: Expected O, but got I
		//IL_0335: Expected O, but got I
		//IL_031a: Expected O, but got I4
		//IL_0516: Expected O, but got I
		//IL_039f: Expected O, but got I
		//IL_0384: Expected O, but got I4
		RelicToDrop = ItemType.TP_RELIC_TELEPORT1;
		AlternativePrize = ItemType.VACUUM;
		HasRelic = true;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(100f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1120403456;
		}
		TreasureChances = list;
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v9+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v11+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v13+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v15+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v17+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v538 @ rax_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		TreasurePrizeTypes = list2;
		DoWiggle = true;
		_003CShieldTime_003Ek__BackingField = 10000f;
		OHKOSecretUnlock = SecretType.none;
		AssassinSecretUnlock = SecretType.none;
		base._002Ector();
	}

	private void _003CInitEnemy_003Eb__62_0()
	{
		float hp = _hp - _shieldDamage;
		_hasShield = false;
		_hp = hp;
	}

	private void _003CCustomDeathLogic_003Eb__74_0()
	{
		DoDeathAnimation();
	}

	private void _003CCustomDeathLogic_003Eb__74_1()
	{
		//IL_01f5: Expected I, but got O
		//IL_0203: Expected I, but got O
		//IL_0213: Expected O, but got I
		//IL_0293: Expected O, but got I4
		//IL_024f: Expected O, but got I
		//IL_0285: Expected O, but got I4
		//IL_0338: Expected I, but got O
		//IL_0340: Expected I, but got O
		//IL_0350: Expected O, but got I
		//IL_03d0: Expected O, but got I4
		//IL_038c: Expected O, but got I
		//IL_03c2: Expected O, but got I4
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		if (!HasRelic)
		{
			if (WeaponToDrop != WeaponType.VOID)
			{
				float2 float5 = base.position;
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponToDrop, value, relicType, validatePickups);
				if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
				{
					OnWeaponSpawned(pickup);
				}
			}
			return;
		}
		if (!DropRelic)
		{
			if (AlternativePrize != ItemType.VOID)
			{
				float2 float6 = base.position;
				Pickup pickup2 = GM.Core.MakeStagePickup(pos, AlternativePrize, WeaponType.VOID, value, relicType, validatePickups);
				if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
				{
					pickup2._003CAutoSafeXY_003Ek__BackingField = true;
				}
			}
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (config.HasCollectedItem(RelicToDrop))
		{
			return;
		}
		float2 float7 = base.position;
		Pickup pickup3 = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
		PickupRelic pickupRelic;
		if ((object)pickup3 == null)
		{
			pickupRelic = null;
			goto IL_04ea;
		}
		nint num = (nint)pickup3;
		nint num2 = (nint)typeof(PickupRelic);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rdx_v15 (Il2CppClass<VampireSurvivors.Objects.Items.PickupRelic>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v632 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v50+FFFFFFF8+v634 @ rax_v46*8]");
			if (0 == (nint)typeof(PickupRelic))
			{
				obj3 = 1;
				goto IL_04c3;
			}
		}
		obj3 = 0;
		goto IL_04c3;
		IL_050c:
		object obj4;
		bool flag = obj4 == null;
		BackgroundTP_Basic backgroundTP_Basic = null;
		Stage stage;
		if (!flag)
		{
			backgroundTP_Basic = (BackgroundTP_Basic)stage._fancyBg;
		}
		goto IL_0533;
		IL_04ea:
		if ((object)pickupRelic == null || ((UnityEngine.Object)pickupRelic).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core = GM.Core;
		stage = core._stage;
		BackgroundTP_Basic fancyBg = (BackgroundTP_Basic)stage._fancyBg;
		bool flag2 = (object)stage._fancyBg == null;
		backgroundTP_Basic = null;
		if (!flag2)
		{
			nint num4 = (nint)typeof(BackgroundTP_Basic);
			nint num5 = (nint)fancyBg;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v794 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundTP_Basic>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ rax_v39+FFFFFFF8+v796 @ rax_v35*8]");
				if (0 == (nint)typeof(BackgroundTP_Basic))
				{
					obj4 = 1;
					goto IL_050c;
				}
			}
			obj4 = 0;
			goto IL_050c;
		}
		goto IL_0533;
		IL_0533:
		if ((object)backgroundTP_Basic != null && ((UnityEngine.Object)backgroundTP_Basic).m_CachedPtr != (IntPtr)0)
		{
			float2 pos2 = pickupRelic.position;
			float2 float8 = backgroundTP_Basic.RestrictInsideAwakeBounds(pos2);
			pickupRelic.position = float8;
		}
		OnRelicSpawned(pickupRelic);
		return;
		IL_04c3:
		bool flag3 = obj3 == null;
		pickupRelic = null;
		if (!flag3)
		{
			pickupRelic = (PickupRelic)pickup3;
		}
		goto IL_04ea;
	}

	private void _003CPlayPosterAnimation_003Eb__78_0()
	{
		_posterSprite.enabled = false;
		_posterMask.enabled = false;
	}

	private void _003CDeathScream_003Eb__79_0()
	{
		if ((object)_ringSprite != null)
		{
			Transform transform = _ringSprite.transform;
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				bool flag4 = (object)_ringSprite == null;
				_ringSprite.enabled = true;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CDeathScream_003Eb__79_1()
	{
		_ringSprite.enabled = false;
	}
}
