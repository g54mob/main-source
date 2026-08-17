using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

namespace VampireSurvivors.Objects.Characters;

public class EnemyControllerBoss : EnemyController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__93_2;

		public static Action _003C_003E9__94_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CPlayDeathVfx_003Eb__93_2()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, time);
		}

		internal void _003CDoDeathAnimation_003Eb__94_0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 500f, 20, 0f, volume, rate, detune, loop, 1f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass94_0
	{
		public EnemyControllerBoss _003C_003E4__this;

		public EmitZone emitZone;

		public ParticleEmitterManager particleManager;

		public Action _003C_003E9__2;

		internal unsafe void _003CDoDeathAnimation_003Eb__1()
		{
			//IL_0008: Expected O, but got Ref
			//IL_00c7: Expected O, but got I4
			//IL_0134: Expected O, but got I
			//IL_01aa: Expected O, but got I
			//IL_01e1: Expected O, but got I
			//IL_0257: Expected O, but got I
			//IL_028e: Expected O, but got I
			//IL_0304: Expected O, but got I
			//IL_033b: Expected O, but got I
			//IL_03b1: Expected O, but got I
			//IL_03e8: Expected O, but got I
			//IL_045e: Expected O, but got I
			//IL_0495: Expected O, but got I
			//IL_050b: Expected O, but got I
			//IL_0542: Expected O, but got I
			//IL_0dd7: Expected I, but got O
			//IL_05b8: Expected O, but got I
			//IL_05ef: Expected O, but got I
			//IL_0665: Expected O, but got I
			//IL_069c: Expected O, but got I
			//IL_0712: Expected O, but got I
			//IL_0749: Expected O, but got I
			//IL_07bf: Expected O, but got I
			//IL_07f6: Expected O, but got I
			//IL_086c: Expected O, but got I
			//IL_08b9: Expected O, but got Ref
			//IL_08dc: Expected native int or pointer, but got O
			//IL_08f6: Expected O, but got I
			//IL_0916: Expected O, but got Ref
			//IL_0930: Expected native int or pointer, but got O
			//IL_094a: Expected O, but got I
			//IL_096a: Expected O, but got Ref
			//IL_0984: Expected native int or pointer, but got O
			//IL_099e: Expected O, but got I
			//IL_09be: Expected O, but got Ref
			//IL_09d8: Expected native int or pointer, but got O
			//IL_0eff: Expected O, but got I4
			//IL_0a03: Expected O, but got Ref
			//IL_0a24: Expected O, but got I
			//IL_0a3e: Expected native int or pointer, but got O
			//IL_0f39: Expected O, but got I
			//IL_0a7c: Expected O, but got Ref
			//IL_0a9d: Expected O, but got I
			//IL_0ab7: Expected native int or pointer, but got O
			//IL_0f73: Expected O, but got I
			//IL_0fd1: Expected O, but got I
			//IL_1076: Expected O, but got Ref
			//IL_0ea0->IL0e1a: Incompatible stack heights: 1 vs 0
			//IL_0c8b->IL0e1a: Incompatible stack heights: 7 vs 0
			//IL_0d74->IL0e1a: Incompatible stack heights: 7 vs 0
			//IL_0dca->IL0e1a: Incompatible stack heights: 7 vs 0
			//IL_1085->IL0ecc: Incompatible stack heights: 18 vs 1
			//IL_0ba7->IL1068: Incompatible stack heights: 19 vs 18
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_ = 0;
			if ((object)_003C_003E4__this != null)
			{
				ArcadeSprite arcadeSprite = _003C_003E4__this.setVisible(visible: false);
				EnemyControllerBoss enemyControllerBoss = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					EnemyControllerBoss deathVfxParticleSystem = (EnemyControllerBoss)(object)enemyControllerBoss._deathVfxParticleSystem1;
					if ((object)enemyControllerBoss._deathVfxParticleSystem1 != null)
					{
						bool flag = ((UnityEngine.Object)deathVfxParticleSystem).m_CachedPtr == (IntPtr)0;
						ParticleSystem.Stop_Injected(((UnityEngine.Object)deathVfxParticleSystem).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
						EnemyControllerBoss enemyControllerBoss2 = _003C_003E4__this;
						if ((object)_003C_003E4__this != null)
						{
							object deathVfxParticleSystem2 = enemyControllerBoss2._deathVfxParticleSystem2;
							Transform transform;
							if ((object)enemyControllerBoss2._deathVfxParticleSystem2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rbx_v11 (System.Object)+10]");
								bool flag2 = (nint)0 != 0;
								transform = (Transform)1;
								if (flag2)
								{
									goto IL_0ecc;
								}
							}
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
							List<string> list = new List<string>();
							bool flag3 = list == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rcx_v59+18]");
							if (num >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj4 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag5 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ rcx_v61+18]");
							if (num2 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj6 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag6 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rcx_v63+18]");
							if (num3 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire21");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj8 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ rcx_v65+18]");
							if (num4 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire22");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj10 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag8 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rcx_v67+18]");
							if (num5 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire23");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj12 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag9 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rcx_v69+18]");
							if (num6 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire24");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj14 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag10 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rcx_v71+18]");
							if (num7 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire25");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj16 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj17 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag11 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1059 @ rcx_v73+18]");
							if (num8 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire26");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj18 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj19 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag12 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1060 @ rcx_v75+18]");
							if (num9 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire27");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj20 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj21 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag13 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rcx_v77+18]");
							if (num10 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire28");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj22 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj23 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag14 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rcx_v79+18]");
							if (num11 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire29");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
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
							particleSystemConfig._emitZone = emitZone;
							particleSystemConfig._on = true;
							bool flag16 = (object)particleManager == null;
							ParticleSystem particleSystem = particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
							bool flag17 = (object)_003C_003E4__this == null;
							transform = null;
							EnemyControllerBoss enemyControllerBoss3 = _003C_003E4__this;
							bool flag18 = (object)_003C_003E4__this == null;
							bool flag19 = (object)enemyControllerBoss3._deathVfxParticleSystem2 == null;
							_ = enemyControllerBoss3._deathVfxParticleSystem2;
							_ = enemyControllerBoss3._deathVfxParticleSystem2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
								bool flag20 = obj25 == null;
							}
							object obj26 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272));
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2714 @ rax_v115 (should have been resolved before IL gen)");
							goto IL_0ecc;
						}
					}
				}
			}
			goto IL_0e1a;
			IL_0e1a:
			throw new NullReferenceException();
			IL_0ecc:
			EnemyControllerBoss enemyControllerBoss4 = _003C_003E4__this;
			bool flag21 = (object)_003C_003E4__this == null;
			bool flag22 = (object)enemyControllerBoss4._deathVfxParticleSystem2 == null;
			Transform transform2 = enemyControllerBoss4._deathVfxParticleSystem2.transform;
			bool flag23 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
			bool flag24 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)0, ref value);
			EnemyControllerBoss enemyControllerBoss5 = _003C_003E4__this;
			bool flag25 = (object)_003C_003E4__this == null;
			RenderingExtensions.Start(enemyControllerBoss5._deathVfxParticleSystem2);
			EnemyControllerBoss enemyControllerBoss6 = _003C_003E4__this;
			bool flag26 = (object)_003C_003E4__this == null;
			if (enemyControllerBoss6.deathTimer1 != null)
			{
				enemyControllerBoss6.deathTimer1.Cancel();
			}
			EnemyControllerBoss enemyControllerBoss7 = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				if (enemyControllerBoss7.deathTimer2 != null)
				{
					enemyControllerBoss7.deathTimer2.Cancel();
				}
				Action onComplete = _003C_003E9__2;
				EnemyControllerBoss enemyControllerBoss8 = _003C_003E4__this;
				if (_003C_003E9__2 == null)
				{
					onComplete = (_003C_003E9__2 = delegate
					{
						EnemyControllerBoss enemyControllerBoss10 = _003C_003E4__this;
						enemyControllerBoss10._deathVfxParticleSystem2.Stop();
					});
				}
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer deathTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				if ((object)_003C_003E4__this != null)
				{
					enemyControllerBoss8.deathTimer1 = deathTimer;
					object obj27 = _003C_003E4__this;
					EnemyControllerBoss enemyControllerBoss9 = _003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1631 @ r8_v15 (Il2CppClass<System.Object>)+3A0]");
					Action onComplete2 = new Action(enemyControllerBoss9, (IntPtr)0);
					if ((object)_003C_003E4__this != null)
					{
						nint num12 = (nint)obj27;
						Timer timer = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						return;
					}
				}
			}
			goto IL_0e1a;
		}

		internal void _003CDoDeathAnimation_003Eb__2()
		{
			EnemyControllerBoss enemyControllerBoss = _003C_003E4__this;
			enemyControllerBoss._deathVfxParticleSystem2.Stop();
		}
	}

	protected bool bossSpawnsBullets;

	protected float bulletSpawnInterval;

	protected bool bulletSpawnLooping;

	protected EnemyType bulletType;

	protected Timer BulletSpawnTimer;

	protected bool bossSpawnsMinions;

	protected float minionSpawnInterval;

	protected int minionSpawnAmount;

	protected bool minionSpawnLooping;

	protected EnemyType minionType;

	protected Timer MinionSpawnTimer;

	protected bool bossSpawnsMinionsOnDeath;

	protected int minionSpawnOnDeathAmount;

	protected EnemyType minionOnDeathType;

	protected bool bossSpawnsSwarms;

	protected float swarmSpawnInterval;

	protected bool swarmSpawnLooping;

	protected EnemyType swarmType;

	protected float swarmSpawnDelay;

	protected int swarmRepeatAmount;

	protected float swarmDistance;

	protected Timer SwarmSpawnTimer;

	protected bool bossSpawnsWave;

	protected float waveSpawnInterval;

	protected bool waveSpawnLooping;

	protected EnemyType waveType;

	protected float waveSpawnDuration;

	protected int waveAmount;

	protected Timer WaveSpawnTimer;

	protected bool bossSpawnsCircle;

	protected bool spawnCircleInstant;

	protected float circleSpawnInterval;

	protected bool circleSpawnLooping;

	protected float circleDuration;

	protected EnemyType circleEnemy;

	protected int circleEnemyAmount;

	protected float circleDiameter;

	protected Timer CircleSpawnTimer;

	protected Timer CircleInstantSpawnTimer;

	protected bool bossHasDamageZones;

	private bool sequentialZoneSpawns;

	private List<DamagingZonePrefab> damagingZones;

	private WeaponType _weaponToDrop;

	private bool _hasTreasureChest;

	private List<float> _treasureChances;

	private bool _playRingDeathVfx;

	private bool _playPosterDeathVfx;

	private bool _playFireballDeath;

	private List<float> _zoneTimers;

	private List<float> _zoneRespawnTimers;

	private float _sequentialRespawnTimer;

	private int _currentZoneIndex;

	private int _zoneLongestRespawner;

	private readonly List<PrizeType?> _treasurePrizeTypes;

	private bool _hasDroppedTreasure;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _deathVfxRingTween;

	private SpriteRenderer _posterSprite;

	private SpriteMask _posterMask;

	private Tween _posterTween;

	private ParticleSystem _deathVfxParticleSystem1;

	private ParticleSystem _deathVfxParticleSystem2;

	private Timer _deathAnimTimer;

	protected MultiTargetTween _deathScaleTween;

	private Timer exploTimer1;

	private Timer exploTimer2;

	private Timer deathTimer1;

	private Timer deathTimer2;

	protected uint _damagingZoneSeed;

	private const string VfxTextureName = "vfx";

	private const string PosterSpriteName = "CirclePoster01";

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

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		base.InitEnemy(enemyType, asRemote);
		base._003CIsBoss_003Ek__BackingField = true;
		InitSpawnBossBullets();
		InitSpawnBossMinions();
		InitSpawnBossSwarm();
		InitSpawnBossCircle();
		InitSpawnWaveEvent();
		InitSpawnDamageZones(asRemote);
		InitDeathVfx();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		UpdateSpawnDamageZones();
	}

	protected virtual void InitSpawnBossBullets()
	{
		//IL_0020: Expected I, but got O
		if (bossSpawnsBullets)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyControllerBoss>)+510]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			float duration = bulletSpawnInterval * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bulletSpawnTimer = Timers.Register(duration, onComplete, null, bulletSpawnLooping, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			BulletSpawnTimer = bulletSpawnTimer;
		}
	}

	protected virtual void InitSpawnBossMinions()
	{
		if (bossSpawnsMinions)
		{
			Action onComplete = delegate
			{
				SpawnBossMinions(minionType, minionSpawnAmount);
			};
			float duration = minionSpawnInterval * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer minionSpawnTimer = Timers.Register(duration, onComplete, null, minionSpawnLooping, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			MinionSpawnTimer = minionSpawnTimer;
		}
	}

	protected virtual void InitSpawnBossSwarm()
	{
		//IL_0020: Expected I, but got O
		if (bossSpawnsSwarms)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyControllerBoss>)+530]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			float duration = swarmSpawnInterval * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer swarmSpawnTimer = Timers.Register(duration, onComplete, null, swarmSpawnLooping, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			SwarmSpawnTimer = swarmSpawnTimer;
		}
	}

	protected virtual void InitSpawnBossCircle()
	{
		//IL_00a1: Expected I, but got O
		//IL_003f: Expected I, but got O
		if (bossSpawnsCircle)
		{
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			if (spawnCircleInstant)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyControllerBoss>)+550]");
				Action onComplete = new Action(this, (IntPtr)0);
				nint num = (nint)this;
				Timer circleInstantSpawnTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				CircleInstantSpawnTimer = circleInstantSpawnTimer;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyControllerBoss>)+550]");
			Action onComplete2 = new Action(this, (IntPtr)0);
			nint num2 = (nint)this;
			float duration = circleSpawnInterval * 0.001f;
			Timer circleSpawnTimer = Timers.Register(duration, onComplete2, null, circleSpawnLooping, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			CircleSpawnTimer = circleSpawnTimer;
		}
	}

	protected virtual void InitSpawnWaveEvent()
	{
		//IL_0020: Expected I, but got O
		if (bossSpawnsWave)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyControllerBoss>)+540]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			float duration = waveSpawnInterval * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer waveSpawnTimer = Timers.Register(duration, onComplete, null, waveSpawnLooping, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			WaveSpawnTimer = waveSpawnTimer;
		}
	}

	protected virtual void InitSpawnDamageZones(bool asRemote)
	{
		//IL_007f: Invalid comparison between I4 and F4
		//IL_037d: Expected F4, but got I4
		//IL_010f: Expected O, but got I4
		//IL_0315: Expected O, but got I
		//IL_032c: Expected F4, but got I
		//IL_01a7: Expected O, but got I
		//IL_0200: Expected O, but got I
		//IL_0237: Expected O, but got I
		//IL_0290: Expected O, but got I
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		if (!bossHasDamageZones || damagingZones == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		uint num = default(uint);
		if (num == 0)
		{
			return;
		}
		if (!asRemote)
		{
			float num2 = UnityEngine.Random.Range(1f, 4.2949673E+09f);
			if (0f > num2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
			}
			_damagingZoneSeed = num;
			float num3 = 0f;
		}
		List<float> zoneTimers = new List<float>();
		_zoneTimers = zoneTimers;
		List<float> zoneRespawnTimers = new List<float>();
		_zoneRespawnTimers = zoneRespawnTimers;
		List<DamagingZonePrefab> list = damagingZones;
		if (list._size <= 0)
		{
			goto IL_02a4;
		}
		object obj = 0;
		while (true)
		{
			List<DamagingZonePrefab> list2 = damagingZones;
			if ((nint)obj >= list2._size)
			{
				break;
			}
			DamagingZonePrefab[] items = list2._items;
			DamagingZonePrefab damagingZonePrefab = items[obj];
			List<float> zoneTimers2 = _zoneTimers;
			float item = damagingZonePrefab.respawnCooldown / 1000f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ r8_v11+18]");
			if (num4 >= 0)
			{
				zoneTimers2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = (nint)0 + (nint)1;
			}
			List<float> zoneRespawnTimers2 = _zoneRespawnTimers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ r8_v13+18]");
			if (num5 >= 0)
			{
				zoneRespawnTimers2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v20 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
			}
			obj++;
			if ((nint)obj < list._size)
			{
				continue;
			}
			goto IL_02a4;
		}
		goto IL_0382;
		IL_0382:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_02a4:
		if (sequentialZoneSpawns)
		{
			List<float> zoneTimers3 = _zoneTimers;
			_currentZoneIndex = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v23 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rax_v23 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rax_v24+20]");
				_sequentialRespawnTimer = 0f;
				return;
			}
			goto IL_0382;
		}
	}

	private unsafe void InitDeathVfx()
	{
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Expected O, but got Unknown
		//IL_00f3: Expected O, but got I4
		//IL_0845: Unknown result type (might be due to invalid IL or missing references)
		//IL_084a: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0192: Expected F4, but got I4
		//IL_01c2: Expected F4, but got I4
		//IL_01cb: Expected O, but got I4
		//IL_03e1: Expected O, but got I4
		//IL_0480: Expected F4, but got I4
		//IL_04b0: Expected F4, but got I4
		//IL_04b9: Expected O, but got I4
		//IL_08d2: Expected I, but got O
		//IL_0925: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Expected O, but got Unknown
		//IL_0968: Expected I, but got O
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c0: Expected O, but got Unknown
		//IL_00ce->IL0701: Incompatible stack heights: 1 vs 0
		//IL_011c->IL0701: Incompatible stack heights: 1 vs 0
		//IL_013e->IL0701: Incompatible stack heights: 1 vs 0
		//IL_016d->IL0701: Incompatible stack heights: 1 vs 0
		//IL_0396->IL0701: Incompatible stack heights: 1 vs 0
		//IL_01ea->IL0701: Incompatible stack heights: 1 vs 0
		//IL_0216->IL0701: Incompatible stack heights: 1 vs 0
		//IL_040a->IL0701: Incompatible stack heights: 1 vs 0
		//IL_042c->IL0701: Incompatible stack heights: 1 vs 0
		//IL_045b->IL0701: Incompatible stack heights: 1 vs 0
		//IL_07ee->IL073b: Incompatible stack heights: 2 vs 0
		//IL_04d8->IL0701: Incompatible stack heights: 1 vs 0
		//IL_0504->IL0701: Incompatible stack heights: 1 vs 0
		//IL_0572->IL0701: Incompatible stack heights: 2 vs 0
		//IL_05bc->IL0701: Incompatible stack heights: 2 vs 0
		//IL_05fc->IL0701: Incompatible stack heights: 2 vs 0
		//IL_0628->IL0701: Incompatible stack heights: 2 vs 0
		//IL_0659->IL0701: Incompatible stack heights: 2 vs 0
		//IL_0700->IL0700: Incompatible stack heights: 9 vs 0
		SpriteRenderer ringSprite = _ringSprite;
		object obj2 = default(object);
		Vector2 pos = default(Vector2);
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				object obj = obj2 - 80;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj);
				GameObject gameObject = base.gameObject;
				SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "sPFX_ring_64");
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				if ((object)spriteRenderer != null)
				{
					((Renderer)spriteRenderer).SetMaterial(material);
					_ringSprite = spriteRenderer;
					object obj3 = 0;
					GameManager gameManager = _gameManager;
					if ((object)_gameManager != null && gameManager._playerOptions != null)
					{
						PlayerOptionsData config = gameManager._playerOptions.Config;
						if (config != null)
						{
							bool flag2 = config._003CFlashingVFXEnabled_003Ek__BackingField;
							float num = 0f;
							if (!flag2)
							{
								SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 0f);
								num = 0f;
								obj3 = 0;
							}
							if ((object)_ringSprite != null)
							{
								Transform transform = _ringSprite.transform;
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v164 (UnityEngine.Transform)+10]");
									bool flag3 = (nint)0 == 0;
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rcx_v139 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v164 (UnityEngine.Transform)+10]");
									Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
									goto IL_073b;
								}
							}
						}
					}
				}
			}
			goto IL_0701;
		}
		goto IL_073b;
		IL_073b:
		SpriteRenderer posterSprite = _posterSprite;
		if ((object)_posterSprite != null && ((UnityEngine.Object)posterSprite).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Transform cachedTransform2 = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			_ = 0;
			_ = 0;
			bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
			object obj4 = obj2 - 80;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Vector3*)obj4);
			GameObject gameObject2 = base.gameObject;
			SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject2, pos, "vfx", "CirclePoster01");
			Color? tintColor = (Color?)(object)(obj2 - 64);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetTintFill(spriteRenderer3, isEnabled: true, tintColor);
			SpriteRenderer component2 = RenderingExtensions.SetAlpha(spriteRenderer4, 0.9f);
			SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(component2, 0f);
			if ((object)spriteRenderer5 != null)
			{
				spriteRenderer5.enabled = false;
				Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
				((Renderer)spriteRenderer5).SetMaterial(material2);
				_posterSprite = spriteRenderer5;
				object obj5 = 0;
				GameManager gameManager2 = _gameManager;
				if ((object)_gameManager != null && gameManager2._playerOptions != null)
				{
					PlayerOptionsData config2 = gameManager2._playerOptions.Config;
					if (config2 != null)
					{
						bool flag5 = config2._003CFlashingVFXEnabled_003Ek__BackingField;
						float num3 = 0f;
						if (!flag5)
						{
							SpriteRenderer spriteRenderer6 = RenderingExtensions.SetAlpha(_posterSprite, 0f);
							num3 = 0f;
							obj5 = 0;
						}
						if ((object)_posterSprite != null)
						{
							Transform transform2 = _posterSprite.transform;
							if ((object)transform2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v69 (UnityEngine.Transform)+10]");
								bool flag6 = (nint)0 == 0;
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1977 @ rcx_v66 (Il2CppMethodInfo)+38]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v69 (UnityEngine.Transform)+10]");
								Transform.SetParent_Injected((IntPtr)0, (IntPtr)0, true);
								GameObject gameObject3 = new GameObject();
								GameObject.Internal_CreateGameObject(gameObject3, (string)null);
								if ((object)gameObject3 != null)
								{
									SpriteMask posterMask = gameObject3.AddComponent<SpriteMask>();
									_posterMask = posterMask;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
									if ((object)_posterMask != null)
									{
										Sprite sprite = default(Sprite);
										_posterMask.sprite = sprite;
										Transform transform3 = gameObject3.transform;
										if ((object)_posterSprite != null)
										{
											Transform parent = _posterSprite.transform;
											if ((object)transform3 != null)
											{
												transform3.SetParent(parent, worldPositionStays: true);
												if ((object)_posterMask != null)
												{
													Transform transform4 = _posterMask.transform;
													nint num5 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1866 @ rcx_v83 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num6 = 0;
													bool flag7 = (object)transform4 == null;
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1863 @ rax_v89 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2132 @ rax_v87 (UnityEngine.Transform)+10]");
													bool flag8 = (nint)0 == 0;
													object obj6 = obj2 - 80;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2132 @ rax_v87 (UnityEngine.Transform)+10]");
													Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj6);
													bool flag9 = (object)_posterMask == null;
													Transform transform5 = _posterMask.transform;
													nint num7 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1470 @ rdx_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num8 = 0;
													bool flag10 = (object)transform5 == null;
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1657 @ rax_v97 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2187 @ rax_v95 (UnityEngine.Transform)+10]");
													bool flag11 = (nint)0 == 0;
													object obj7 = obj2 - 64;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2187 @ rax_v95 (UnityEngine.Transform)+10]");
													Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj7);
													bool flag12 = (object)_posterSprite == null;
													_posterSprite.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
													bool flag13 = (object)_posterMask == null;
													_posterMask.enabled = false;
													return;
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
		goto IL_0701;
		IL_0701:
		throw new NullReferenceException();
	}

	protected virtual void SpawnBossBullets()
	{
		if (bossSpawnsBullets && !base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField && base.CanUseAbility())
		{
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		}
	}

	protected virtual void SpawnBossMinions(EnemyType type, int spawnAmount)
	{
		//IL_00a9: Expected I, but got O
		//IL_00b9: Expected O, but got I
		//IL_0123: Expected O, but got I4
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_01dd: Expected O, but got I4
		if ((!bossSpawnsMinions && !bossSpawnsMinionsOnDeath) || base._003CIsTimeStopped_003Ek__BackingField || !bossSpawnsMinionsOnDeath || !base._003CIsDead_003Ek__BackingField || spawnAmount <= 0)
		{
			return;
		}
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyControllerBoss>)+350]");
		object obj = 0;
		if (!base.CanUseAbility())
		{
			return;
		}
		if (spawnAmount != 1)
		{
			float value = UnityEngine.Random.value;
			float num2 = value * ((float)Math.PI * 2f);
			int num3 = spawnAmount;
			object obj2 = 0;
			EnemyController enemyController = null;
			EnemyController enemyController2 = default(EnemyController);
			bool flag;
			int num8 = default(int);
			do
			{
				BaseBody baseBody = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num4 = num2 + 0.0062831854f;
				float num5 = num2 * 0.8f;
				GameManager core = GM.Core;
				float num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ rdi_v6 (BaseBody)+6C]");
				float num7 = num6 + 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				ScaleSpawnedEnemy(enemyController2);
				obj2++;
				flag = (nint)obj2 < spawnAmount;
				num3 = num8;
				num2 = num4;
				obj = 0;
				enemyController = enemyController2;
			}
			while (flag);
		}
		else
		{
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			EnemyController spawned = default(EnemyController);
			ScaleSpawnedEnemy(spawned);
		}
	}

	private static void ScaleSpawnedEnemy(EnemyController spawned)
	{
		Transform transform = spawned.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Tween tween = spawned._003CScaleTween_003Ek__BackingField;
		if (spawned._003CScaleTween_003Ek__BackingField != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(spawned._003CScaleTween_003Ek__BackingField);
		}
		Transform target = spawned.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, spawned._scaleMul, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		spawned._003CScaleTween_003Ek__BackingField = tweenerCore;
	}

	protected virtual void SpawnBossSwarms()
	{
		if (bossSpawnsSwarms && !base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField && base.CanUseAbility())
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			float moreZ = default(float);
			float rndDiv = default(float);
			stage._stageEventManager.GenerateEnemySwarm(swarmSpawnDelay, swarmRepeatAmount, swarmType, moreZ, rndDiv);
		}
	}

	protected virtual void SpawnBossWave()
	{
		//IL_00ab: Expected O, but got I4
		if (bossSpawnsWave && !base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField && base.CanUseAbility())
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._stageEventManager.PlayMedusaSwarm((float?)(object)1, waveAmount, waveType);
		}
	}

	protected virtual void SpawnBossCircle()
	{
		//IL_00af: Expected O, but got I4
		if (bossSpawnsCircle && !base._003CIsTimeStopped_003Ek__BackingField && !base._003CIsDead_003Ek__BackingField && base.CanUseAbility())
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			float moreZ = default(float);
			stage._stageEventManager.PlayCircle((float?)(object)1, circleEnemyAmount, circleEnemy, moreZ);
		}
	}

	protected virtual void UpdateSpawnDamageZones()
	{
		//IL_003a: Expected F4, but got O
		//IL_033c: Invalid comparison between F4 and I4
		//IL_036e: Expected O, but got I4
		//IL_0391: Expected F4, but got O
		//IL_00f9: Expected F4, but got O
		//IL_0102: Expected O, but got I4
		//IL_0477: Expected F4, but got O
		//IL_0481: Expected F4, but got O
		//IL_03df: Expected F4, but got O
		//IL_03f9: Expected F4, but got O
		//IL_0140: Expected O, but got I
		//IL_0187: Expected O, but got I
		//IL_020d: Expected O, but got I
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_02a8: Expected I4, but got I8
		//IL_02d1: Expected F4, but got O
		//IL_02d9: Expected F4, but got O
		if (!bossHasDamageZones || damagingZones == null)
		{
			return;
		}
		float2 float5 = default(float2);
		((List<float>)null).set_Item(0, (float)float5);
		object obj = default(object);
		if (obj == null || base._003CIsTimeStopped_003Ek__BackingField || base._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		float2 float6 = default(float2);
		if (!sequentialZoneSpawns)
		{
			List<DamagingZonePrefab> list = damagingZones;
			if (list._size <= 0)
			{
				return;
			}
			float num = (float)float5;
			object obj2 = 0;
			while (true)
			{
				List<float> zoneRespawnTimers = _zoneRespawnTimers;
				int currentZoneIndex = _currentZoneIndex;
				int currentZoneIndex2 = _currentZoneIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdi_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)currentZoneIndex2 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdi_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj3 = 0;
				float deltaTime = PauseSystem.DeltaTime;
				int currentZoneIndex3 = _currentZoneIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdi_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)currentZoneIndex3 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdi_v13 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rcx_v23+20+v451 @ rsi_v13 (System.Int32)*4]");
				float num2 = 0f - deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdi_v13 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				List<float> zoneRespawnTimers2 = _zoneRespawnTimers;
				int currentZoneIndex4 = _currentZoneIndex;
				int currentZoneIndex5 = _currentZoneIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rcx_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)currentZoneIndex5 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v474 @ rcx_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rcx_v27+20+v458 @ rax_v30 (System.Int32)*4]");
				if ((nint)0 <= (nint)0 && base.CanUseAbility())
				{
					DamagingZonePrefab damagingZonePrefab = damagingZones.get_Item(_currentZoneIndex);
					Transform transform = base.transform;
					Vector3 vector = transform.position;
					damagingZonePrefab.SpawnZone(4294967295u, float6);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
					_zoneRespawnTimers.set_Item(_currentZoneIndex, (float)float6);
					num = (float)float6;
				}
				obj2++;
				if ((nint)obj2 >= list._size)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		float deltaTime2 = PauseSystem.DeltaTime;
		if (!((_sequentialRespawnTimer -= deltaTime2) > 0f))
		{
			bool flag = base.CanUseAbility();
			bool flag2 = !flag;
			float2 float7 = (float2)0;
			if (!flag2)
			{
				((List<float>)(object)damagingZones).set_Item(_currentZoneIndex, (float)float5);
				Transform transform2 = base.transform;
				Vector3 vector2 = transform2.position;
				DamagingZonePrefab damagingZonePrefab2 = default(DamagingZonePrefab);
				damagingZonePrefab2.SpawnZone(_damagingZoneSeed, float6);
				_zoneTimers.set_Item(_currentZoneIndex, (float)float5);
				_zoneRespawnTimers.set_Item(_currentZoneIndex, (float)float6);
				float7 = float6;
			}
			List<float> zoneTimers = _zoneTimers;
			int num3 = ++_currentZoneIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ rcx_v14 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				_currentZoneIndex = 0;
			}
			zoneTimers.set_Item(_currentZoneIndex, (float)float6);
			_sequentialRespawnTimer = (float)float7;
		}
	}

	protected override void Die()
	{
		base.Die();
		PlayDeathVfx();
		if (_hasTreasureChest)
		{
			DropTreasure();
		}
		if (_weaponToDrop != WeaponType.VOID)
		{
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, _weaponToDrop, value, relicType, validatePickups);
			if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
			{
				pickup._003CAutoSafeXY_003Ek__BackingField = true;
				Transform t = pickup.transform;
				PlayPosterAnimation(t);
			}
		}
		if (bossSpawnsMinionsOnDeath)
		{
			SpawnBossMinions(minionOnDeathType, minionSpawnOnDeathAmount);
		}
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
			treasure._003Cchances_003Ek__BackingField = _treasureChances;
			treasure._003CprizeTypes_003Ek__BackingField = _treasurePrizeTypes;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)core._stage != null)
			{
				int num = core._stage.SetTreasureLevelFromChance(treasure);
				EnemyControllerBoss cachedTransform = (EnemyControllerBoss)(object)_cachedTransform;
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

	private void DropWeapon()
	{
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, _weaponToDrop, value, relicType, validatePickups);
		if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
		{
			pickup._003CAutoSafeXY_003Ek__BackingField = true;
			Transform t = pickup.transform;
			PlayPosterAnimation(t);
		}
	}

	private void PlayDeathVfx()
	{
		//IL_002a: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0283: Expected I4, but got F4
		if (!_playRingDeathVfx)
		{
			return;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Deathscream, soundConfig, 150f, 2, num);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		if (_deathVfxRingTween != null)
		{
			_deathVfxRingTween.Kill();
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
		tweenConfig.repeat = 2;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_ringSprite, 0f);
			if ((object)_ringSprite != null)
			{
				Transform transform2 = _ringSprite.transform;
				SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
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
		TweenCallback onRepeat = _003C_003Ec._003C_003E9__93_2;
		if (_003C_003Ec._003C_003E9__93_2 == null)
		{
			onRepeat = (_003C_003Ec._003C_003E9__93_2 = delegate
			{
				//IL_003d: Expected O, but got I4
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Deathscream, soundConfig2, 150f, 2, time);
			});
		}
		tweenConfig.onRepeat = onRepeat;
		TweenCallback onComplete = delegate
		{
			_ringSprite.enabled = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween deathVfxRingTween = Tweens.Add(tweenConfig);
		_deathVfxRingTween = deathVfxRingTween;
		if (_playFireballDeath)
		{
			if (_deathAnimTimer != null)
			{
				_deathAnimTimer.Cancel();
			}
			Action onComplete2 = delegate
			{
				DoDeathAnimation();
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer deathAnimTimer = Timers.Register(0.3f, onComplete2, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_deathAnimTimer = deathAnimTimer;
		}
	}

	protected unsafe virtual void DoDeathAnimation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0098: Expected I, but got O
		//IL_011f: Expected O, but got I
		//IL_0181: Expected O, but got I
		//IL_01a2: Expected O, but got I
		//IL_025d: Expected O, but got I
		//IL_09e3: Expected O, but got Ref
		//IL_0a06: Expected native int or pointer, but got O
		//IL_0a20: Expected O, but got I
		//IL_0a40: Expected O, but got Ref
		//IL_0a5a: Expected native int or pointer, but got O
		//IL_0a74: Expected O, but got I
		//IL_0a94: Expected O, but got Ref
		//IL_0aae: Expected native int or pointer, but got O
		//IL_0ac8: Expected O, but got I
		//IL_0ae8: Expected O, but got Ref
		//IL_0b02: Expected native int or pointer, but got O
		//IL_0e48: Expected O, but got I4
		//IL_0b27: Expected O, but got Ref
		//IL_0b4e: Expected O, but got I
		//IL_0b68: Expected native int or pointer, but got O
		//IL_0e82: Expected O, but got I
		//IL_0ba0: Expected O, but got Ref
		//IL_0bc7: Expected O, but got I
		//IL_0be1: Expected native int or pointer, but got O
		//IL_0ebc: Expected O, but got I
		//IL_0c55: Expected I, but got O
		//IL_0ef2: Expected O, but got I
		//IL_0fd8: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_003C_003Ec__DisplayClass94_0 CS_0024_003C_003E8__locals35 = new _003C_003Ec__DisplayClass94_0();
		if (CS_0024_003C_003E8__locals35 != null)
		{
			CS_0024_003C_003E8__locals35._003C_003E4__this = this;
			base._003CIsDead_003Ek__BackingField = true;
			if (_deathScaleTween != null)
			{
				_deathScaleTween.Kill();
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
					MultiTargetTween deathScaleTween = Tweens.Add(tweenConfig);
					_deathScaleTween = deathScaleTween;
					GameObject gameObject = base.gameObject;
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v962 @ rbx_v10 (Il2CppMethodInfo)+38]");
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
						int version = list._version + 1;
						list._version = version;
						string[] items = list._items;
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire19");
						}
						else
						{
							int num6 = list._size + 1;
							list._size = num6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version2 = list._version + 1;
						list._version = version2;
						string[] items2 = list._items;
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire20");
						}
						else
						{
							int num7 = list._size + 1;
							list._size = num7;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version3 = list._version + 1;
						list._version = version3;
						string[] items3 = list._items;
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire21");
						}
						else
						{
							int num8 = list._size + 1;
							list._size = num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._size >= items4.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire22");
						}
						else
						{
							int num9 = list._size + 1;
							list._size = num9;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version5 = list._version + 1;
						list._version = version5;
						string[] items5 = list._items;
						if (list._size >= items5.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire23");
						}
						else
						{
							int num10 = list._size + 1;
							list._size = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version6 = list._version + 1;
						list._version = version6;
						string[] items6 = list._items;
						if (list._size >= items6.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire24");
						}
						else
						{
							int num11 = list._size + 1;
							list._size = num11;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version7 = list._version + 1;
						list._version = version7;
						string[] items7 = list._items;
						if (list._size >= items7.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire25");
						}
						else
						{
							int num12 = list._size + 1;
							list._size = num12;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version8 = list._version + 1;
						list._version = version8;
						string[] items8 = list._items;
						if (list._size >= items8.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire26");
						}
						else
						{
							int num13 = list._size + 1;
							list._size = num13;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version9 = list._version + 1;
						list._version = version9;
						string[] items9 = list._items;
						if (list._size >= items9.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire27");
						}
						else
						{
							int num14 = list._size + 1;
							list._size = num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version10 = list._version + 1;
						list._version = version10;
						string[] items10 = list._items;
						if (list._size >= items10.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire28");
						}
						else
						{
							int num15 = list._size + 1;
							list._size = num15;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version11 = list._version + 1;
						list._version = version11;
						string[] items11 = list._items;
						if (list._size >= items11.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fire29");
						}
						else
						{
							int num16 = list._size + 1;
							list._size = num16;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
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
						_ = _deathVfxParticleSystem1;
						num5 = unchecked((nint)null);
						_ = _deathVfxParticleSystem1;
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
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2976 @ rax_v135 (should have been resolved before IL gen)");
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
					Action onComplete = _003C_003Ec._003C_003E9__94_0;
					if (_003C_003Ec._003C_003E9__94_0 == null)
					{
						onComplete = (_003C_003Ec._003C_003E9__94_0 = delegate
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
						//IL_0134: Expected O, but got I
						//IL_01aa: Expected O, but got I
						//IL_01e1: Expected O, but got I
						//IL_0257: Expected O, but got I
						//IL_028e: Expected O, but got I
						//IL_0304: Expected O, but got I
						//IL_033b: Expected O, but got I
						//IL_03b1: Expected O, but got I
						//IL_03e8: Expected O, but got I
						//IL_045e: Expected O, but got I
						//IL_0495: Expected O, but got I
						//IL_050b: Expected O, but got I
						//IL_0542: Expected O, but got I
						//IL_0dd7: Expected I, but got O
						//IL_05b8: Expected O, but got I
						//IL_05ef: Expected O, but got I
						//IL_0665: Expected O, but got I
						//IL_069c: Expected O, but got I
						//IL_0712: Expected O, but got I
						//IL_0749: Expected O, but got I
						//IL_07bf: Expected O, but got I
						//IL_07f6: Expected O, but got I
						//IL_086c: Expected O, but got I
						//IL_08b9: Expected O, but got Ref
						//IL_08dc: Expected native int or pointer, but got O
						//IL_08f6: Expected O, but got I
						//IL_0916: Expected O, but got Ref
						//IL_0930: Expected native int or pointer, but got O
						//IL_094a: Expected O, but got I
						//IL_096a: Expected O, but got Ref
						//IL_0984: Expected native int or pointer, but got O
						//IL_099e: Expected O, but got I
						//IL_09be: Expected O, but got Ref
						//IL_09d8: Expected native int or pointer, but got O
						//IL_0eff: Expected O, but got I4
						//IL_0a03: Expected O, but got Ref
						//IL_0a24: Expected O, but got I
						//IL_0a3e: Expected native int or pointer, but got O
						//IL_0f39: Expected O, but got I
						//IL_0a7c: Expected O, but got Ref
						//IL_0a9d: Expected O, but got I
						//IL_0ab7: Expected native int or pointer, but got O
						//IL_0f73: Expected O, but got I
						//IL_0fd1: Expected O, but got I
						//IL_1076: Expected O, but got Ref
						//IL_0ea0->IL0e1a: Incompatible stack heights: 1 vs 0
						//IL_0c8b->IL0e1a: Incompatible stack heights: 7 vs 0
						//IL_0d74->IL0e1a: Incompatible stack heights: 7 vs 0
						//IL_0dca->IL0e1a: Incompatible stack heights: 7 vs 0
						//IL_1085->IL0ecc: Incompatible stack heights: 18 vs 1
						//IL_0ba7->IL1068: Incompatible stack heights: 19 vs 18
						object obj7 = default(object);
						object obj6 = (object)(&obj7);
						_ = 0;
						if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
						{
							ArcadeSprite arcadeSprite = CS_0024_003C_003E8__locals35._003C_003E4__this.setVisible(visible: false);
							EnemyControllerBoss enemyControllerBoss = CS_0024_003C_003E8__locals35._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
							{
								EnemyControllerBoss deathVfxParticleSystem3 = (EnemyControllerBoss)(object)enemyControllerBoss._deathVfxParticleSystem1;
								if ((object)enemyControllerBoss._deathVfxParticleSystem1 != null)
								{
									bool flag2 = ((UnityEngine.Object)deathVfxParticleSystem3).m_CachedPtr == (IntPtr)0;
									ParticleSystem.Stop_Injected(((UnityEngine.Object)deathVfxParticleSystem3).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
									EnemyControllerBoss enemyControllerBoss2 = CS_0024_003C_003E8__locals35._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
									{
										object deathVfxParticleSystem4 = enemyControllerBoss2._deathVfxParticleSystem2;
										Transform transform2;
										if ((object)enemyControllerBoss2._deathVfxParticleSystem2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rbx_v11 (System.Object)+10]");
											bool flag3 = (nint)0 != 0;
											transform2 = (Transform)1;
											if (flag3)
											{
												goto IL_0ecc;
											}
										}
										ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("ThosePeople");
										List<string> list2 = new List<string>();
										bool flag4 = list2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag5 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num17 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ rcx_v59+18]");
										if (num17 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire19");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj9 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num18 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ rcx_v61+18]");
										if (num18 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire20");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj11 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj12 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag7 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num19 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ rcx_v63+18]");
										if (num19 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire21");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj13 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag8 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ rcx_v65+18]");
										if (num20 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire22");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj15 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj16 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag9 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num21 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rcx_v67+18]");
										if (num21 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire23");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj17 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj18 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag10 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num22 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rcx_v69+18]");
										if (num22 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire24");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj19 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj20 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag11 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num23 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rcx_v71+18]");
										if (num23 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire25");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj21 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj22 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag12 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num24 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1059 @ rcx_v73+18]");
										if (num24 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire26");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj23 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj24 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag13 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num25 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1060 @ rcx_v75+18]");
										if (num25 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire27");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj25 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj26 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag14 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num26 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rcx_v77+18]");
										if (num26 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire28");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
											object obj27 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										object obj28 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+10]");
										bool flag15 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
										nint num27 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rcx_v79+18]");
										if (num27 >= 0)
										{
											((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire29");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v986 @ rax_v73 (System.Collections.Generic.List`1<System.String>)+18]");
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
										EnemyControllerBoss enemyControllerBoss3 = CS_0024_003C_003E8__locals35._003C_003E4__this;
										bool flag19 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
										bool flag20 = (object)enemyControllerBoss3._deathVfxParticleSystem2 == null;
										_ = enemyControllerBoss3._deathVfxParticleSystem2;
										_ = enemyControllerBoss3._deathVfxParticleSystem2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
										object obj30 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9B8]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
											bool flag21 = obj30 == null;
										}
										object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj7, 272));
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2714 @ rax_v115 (should have been resolved before IL gen)");
										goto IL_0ecc;
									}
								}
							}
						}
						goto IL_0e1a;
						IL_0e1a:
						throw new NullReferenceException();
						IL_0ecc:
						EnemyControllerBoss enemyControllerBoss4 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						bool flag22 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
						bool flag23 = (object)enemyControllerBoss4._deathVfxParticleSystem2 == null;
						Transform transform3 = enemyControllerBoss4._deathVfxParticleSystem2.transform;
						bool flag24 = (object)transform3 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
						bool flag25 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v886 @ rax_v33 (UnityEngine.Transform)+10]");
						Vector3 value2 = default(Vector3);
						Transform.set_localPosition_Injected((IntPtr)0, ref value2);
						EnemyControllerBoss enemyControllerBoss5 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						bool flag26 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
						RenderingExtensions.Start(enemyControllerBoss5._deathVfxParticleSystem2);
						EnemyControllerBoss enemyControllerBoss6 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						bool flag27 = (object)CS_0024_003C_003E8__locals35._003C_003E4__this == null;
						if (enemyControllerBoss6.deathTimer1 != null)
						{
							enemyControllerBoss6.deathTimer1.Cancel();
						}
						EnemyControllerBoss enemyControllerBoss7 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
						{
							if (enemyControllerBoss7.deathTimer2 != null)
							{
								enemyControllerBoss7.deathTimer2.Cancel();
							}
							Action onComplete3 = CS_0024_003C_003E8__locals35._003C_003E9__2;
							EnemyControllerBoss enemyControllerBoss8 = CS_0024_003C_003E8__locals35._003C_003E4__this;
							if (CS_0024_003C_003E8__locals35._003C_003E9__2 == null)
							{
								onComplete3 = (CS_0024_003C_003E8__locals35._003C_003E9__2 = delegate
								{
									EnemyControllerBoss enemyControllerBoss10 = CS_0024_003C_003E8__locals35._003C_003E4__this;
									enemyControllerBoss10._deathVfxParticleSystem2.Stop();
								});
							}
							bool useRealTime2 = default(bool);
							MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
							int repeat2 = default(int);
							TimerType type2 = default(TimerType);
							Timer timer3 = Timers.Register(1f, onComplete3, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
							if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
							{
								enemyControllerBoss8.deathTimer1 = timer3;
								object obj32 = CS_0024_003C_003E8__locals35._003C_003E4__this;
								EnemyControllerBoss enemyControllerBoss9 = CS_0024_003C_003E8__locals35._003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1631 @ r8_v15 (Il2CppClass<System.Object>)+3A0]");
								Action onComplete4 = new Action(enemyControllerBoss9, (IntPtr)0);
								if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
								{
									nint num28 = (nint)obj32;
									Timer timer4 = Timers.Register(2f, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
									return;
								}
							}
						}
						goto IL_0e1a;
					};
					Timer timer2 = Timers.Register(2f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					exploTimer2 = timer2;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PlayPosterAnimation(Transform t)
	{
		//IL_045b: Expected O, but got Ref
		//IL_046c: Expected O, but got I8
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_04e4: Expected O, but got I4
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Expected O, but got Unknown
		//IL_0153->IL02f1: Incompatible stack heights: 9 vs 0
		//IL_04d0->IL02f1: Incompatible stack heights: 9 vs 0
		//IL_02f1->IL04d5: Incompatible stack heights: 9 vs 0
		if (!_playPosterDeathVfx)
		{
			return;
		}
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
					if (_posterTween != null)
					{
						TweenExtensions.Kill(_posterTween);
					}
					if ((object)_posterMask != null)
					{
						Transform target = _posterMask.transform;
						tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&value), 0.4f);
						object obj = 6603577472L;
						TweenCallback tweenCallback2;
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbp_v14+462E0+v1134 @ rdx_v46*8]");
										object obj8 = 0 | obj7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbp_v14+462E0+v1134 @ rdx_v46*8]");
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbp_v14+462E0+v1134 @ rdx_v46*8]");
										if (num == 0)
										{
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbp_v14+462E0+v1134 @ rdx_v46*8]");
										num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbp_v14+462E0+v1134 @ rdx_v46*8]");
									}
									while (num2 != 0);
									TweenCallback tweenCallback = delegate
									{
										_posterSprite.enabled = false;
										_posterMask.enabled = false;
									};
									tweenCallback2 = tweenCallback;
									goto IL_0275;
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
							goto IL_0275;
						}
						goto IL_02a4;
					}
				}
			}
		}
		goto IL_02f1;
		IL_02a4:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			_posterTween = tweenerCore;
			return;
		}
		goto IL_02f1;
		IL_02f1:
		throw new NullReferenceException();
		IL_0275:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1082 @ rax_v59 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_02a4;
	}

	public override void Despawn()
	{
		base.Despawn();
		if (BulletSpawnTimer != null)
		{
			BulletSpawnTimer.Cancel();
		}
		if (MinionSpawnTimer != null)
		{
			MinionSpawnTimer.Cancel();
		}
		if (SwarmSpawnTimer != null)
		{
			SwarmSpawnTimer.Cancel();
		}
		if (WaveSpawnTimer != null)
		{
			WaveSpawnTimer.Cancel();
		}
		if (CircleSpawnTimer != null)
		{
			CircleSpawnTimer.Cancel();
		}
		if (CircleInstantSpawnTimer != null)
		{
			CircleInstantSpawnTimer.Cancel();
		}
	}

	public EnemyControllerBoss()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_050a: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_0532: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_01e4: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_0223: Expected O, but got I4
		//IL_0569: Expected O, but got I
		//IL_02a8: Expected O, but got I
		//IL_028d: Expected O, but got I4
		//IL_0591: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_02f7: Expected O, but got I4
		//IL_05b9: Expected O, but got I
		//IL_037c: Expected O, but got I
		//IL_0361: Expected O, but got I4
		//IL_05e1: Expected O, but got I
		//IL_03e6: Expected O, but got I
		//IL_03cb: Expected O, but got I4
		bulletSpawnInterval = 4000f;
		bulletType = EnemyType.BULLET_1;
		minionSpawnInterval = 4000f;
		minionSpawnAmount = 1;
		minionSpawnOnDeathAmount = 1;
		swarmSpawnInterval = 4000f;
		swarmType = EnemyType.BATSWARM;
		swarmSpawnDelay = 10000f;
		swarmRepeatAmount = 5;
		swarmDistance = 0.9f;
		waveSpawnInterval = 4000f;
		waveType = EnemyType.BATSWARM;
		waveSpawnDuration = 1000f;
		waveAmount = 1;
		circleSpawnInterval = 4000f;
		circleDuration = 5000f;
		circleEnemy = EnemyType.FLOWER;
		circleEnemyAmount = 100;
		circleDiameter = 0.9f;
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
		_treasureChances = list;
		_playRingDeathVfx = true;
		_zoneTimers = new List<float>();
		_zoneRespawnTimers = new List<float>();
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rdx_v13+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v15+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdx_v17+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v19+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v21+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ rax_v19 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		_treasurePrizeTypes = list2;
		base._002Ector();
	}

	private void _003CInitSpawnBossMinions_003Eb__77_0()
	{
		SpawnBossMinions(minionType, minionSpawnAmount);
	}

	private void _003CPlayDeathVfx_003Eb__93_1()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		if ((object)_ringSprite != null)
		{
			Transform transform = _ringSprite.transform;
			SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
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

	private void _003CPlayDeathVfx_003Eb__93_3()
	{
		_ringSprite.enabled = false;
	}

	private void _003CPlayDeathVfx_003Eb__93_0()
	{
		DoDeathAnimation();
	}

	private void _003CPlayPosterAnimation_003Eb__95_0()
	{
		_posterSprite.enabled = false;
		_posterMask.enabled = false;
	}
}
