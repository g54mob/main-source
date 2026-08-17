using System;
using System.Collections.Generic;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyLegion : EnemyController
{
	public enum LegionBossPhase
	{
		Unactivated,
		Activating,
		Normal,
		Spewing,
		Dying,
		Dead
	}

	private class Tentacle
	{
		public PhaserSprite _arm;

		public PhaserSprite _head;

		public float _aimCounter;

		public float _chargeCounter;

		public bool _isFiring;

		public PhaserSprite _laser;

		public PhaserSprite _laserCap;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__34_0;

		public static Action _003C_003E9__34_4;

		public static TweenCallback _003C_003E9__39_0;

		public static TweenCallback _003C_003E9__39_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CDoDeathAnimation_003Eb__34_0()
		{
			//IL_0033: Expected F4, but got I4
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
		}

		internal void _003CDoDeathAnimation_003Eb__34_4()
		{
			//IL_008d: Expected O, but got I
			//IL_0064: Expected F4, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v3 (should have been resolved before IL gen)");
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Fireloop, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
		}

		internal void _003CScreenShake_003Eb__39_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.y = -5f;
		}

		internal void _003CScreenShake_003Eb__39_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public float2 randomPoint;

		public EnemyLegion _003C_003E4__this;

		internal void _003CSpawnZombies_003Eb__0()
		{
			float2 position = default(float2);
			_003C_003E4__this.SpawnZombie(position);
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_0
	{
		public List<ParticleSystem> pfxEmitters;

		public EnemyLegion _003C_003E4__this;

		public EmitZone emitZone;

		public ParticleEmitterManager particleManager;

		public TweenCallback _003C_003E9__3;

		internal unsafe void _003CDoDeathAnimation_003Eb__2()
		{
			//IL_001d: Expected I, but got O
			//IL_0085: Expected I, but got O
			//IL_00ea: Expected O, but got I4
			//IL_00fd: Expected O, but got I4
			//IL_0190: Expected I, but got O
			//IL_01a6: Expected O, but got I
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_022a: Expected I, but got O
			//IL_0310: Expected O, but got I4
			//IL_0327: Expected I, but got I8
			//IL_0206: Expected I, but got I8
			List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
			if (enumerator.MoveNext())
			{
				nint num = (nint)typeof(RenderingExtensions);
				throw new NullReferenceException();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_003E4__this != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float2 position = _003C_003E4__this.position;
			tweenConfig.x = (float?)(object)1;
			tweenConfig.y = (float?)(object)1;
			tweenConfig.duration = 600f;
			tweenConfig.ease = Ease.InCirc;
			TweenCallback onComplete = _003C_003E9__3;
			if (_003C_003E9__3 != null)
			{
				goto IL_022f;
			}
			TweenCallback tweenCallback = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass34_0._003CDoDeathAnimation_003Eb__3);
			((Delegate)tweenCallback).m_target = this;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num4;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_0307;
				}
			}
			num4 = ((Delegate)tweenCallback).method_ptr;
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			goto IL_0307;
			IL_0307:
			object obj4 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			_003C_003E9__3 = tweenCallback;
			onComplete = tweenCallback;
			goto IL_022f;
			IL_022f:
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}

		internal unsafe void _003CDoDeathAnimation_003Eb__3()
		{
			//IL_0057: Expected F4, but got I4
			//IL_012e: Expected O, but got I
			//IL_00e9: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_01be: Expected F4, but got I4
			//IL_018b: Expected O, but got I8
			//IL_0088: Expected F4, but got I4
			//IL_01fa: Expected I4, but got F4
			//IL_01fa: Expected O, but got F4
			//IL_01fa: Expected I4, but got O
			//IL_0b31: Expected O, but got I4
			//IL_0d01: Expected O, but got I4
			//IL_0d1f: Expected O, but got I4
			//IL_0b59: Expected O, but got I4
			//IL_0d43: Expected O, but got I4
			//IL_0b71: Expected O, but got I4
			//IL_0d67: Expected O, but got I4
			//IL_07ea: Expected O, but got I4
			//IL_08af: Expected I, but got O
			//IL_08c5: Expected O, but got I
			//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d3: Expected O, but got Unknown
			//IL_093c: Expected I, but got O
			//IL_0c15: Expected O, but got I4
			//IL_0c2c: Expected I, but got I8
			//IL_0c5a: Expected I4, but got F4
			//IL_0c5a: Expected O, but got F4
			//IL_0c5a: Expected I4, but got O
			//IL_095b: Expected I, but got O
			//IL_0971: Expected O, but got I
			//IL_097a: Unknown result type (might be due to invalid IL or missing references)
			//IL_097f: Expected O, but got Unknown
			//IL_09ed: Expected I, but got O
			//IL_0925: Expected I, but got I8
			//IL_0cb6: Expected I, but got I8
			//IL_0ce4: Expected I4, but got F4
			//IL_0ce4: Expected O, but got F4
			//IL_0ce4: Expected I4, but got O
			//IL_09c0: Expected I, but got I8
			//IL_0190->IL0aba: Incompatible stack heights: 1 vs 0
			//IL_008d->IL0a6b: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass34_2 obj = new _003C_003Ec__DisplayClass34_2();
			float? num4 = default(float?);
			float num5 = default(float);
			float num6 = default(float);
			bool flag4 = default(bool);
			Action action;
			if (obj != null)
			{
				obj.CS_0024_003C_003E8__locals1 = this;
				List<ParticleSystem> list = pfxEmitters;
				if (pfxEmitters != null)
				{
					float num = 0f;
					List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
					while (enumerator.MoveNext())
					{
						object obj2 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v18 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rbx_v18 (System.Object)+10]");
						IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
						GameObject obj3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
						UnityEngine.Object.Destroy(obj3, 0f);
						num = 0f;
					}
					Array array = (Array)(object)pfxEmitters;
					if (pfxEmitters != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v31 (System.Array)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v31 (System.Array)+18]");
						bool flag2 = (nint)0 <= (nint)0;
						int num2 = 0;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v31 (System.Array)+10]");
							array = (Array)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v31 (System.Array)+10]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rcx_v31 (System.Array)+18]");
							Array.Clear((Array)num3, 0, 0);
							num2 = 0;
							list = null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag3 = obj4 == null;
							array = (Array)6573110936L;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v503 @ rax_v40 (should have been resolved before IL gen)");
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Fireloop, 1000f, 10, 0f, num4, num5, num6, flag4, 1f);
						Action onComplete = _003C_003Ec._003C_003E9__34_4;
						if (_003C_003Ec._003C_003E9__34_4 == null)
						{
							onComplete = (_003C_003Ec._003C_003E9__34_4 = delegate
							{
								//IL_008d: Expected O, but got I
								//IL_0064: Expected F4, but got I4
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									if (obj10 == null)
									{
										MissingMethodException ex = new MissingMethodException();
										throw ex;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v47 @ rax_v3 (should have been resolved before IL gen)");
								float? volume = default(float?);
								float rate = default(float);
								float detune = default(float);
								bool loop = default(bool);
								PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.Fireloop, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
							});
						}
						Timer timer = Timers.Register(0.2f, onComplete, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
						List<string> list2 = new List<string>();
						int version = list2._version + 1;
						list2._version = version;
						string[] items = list2._items;
						if (list2._size >= items.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire19");
						}
						else
						{
							int size = list2._size + 1;
							list2._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version2 = list2._version + 1;
						list2._version = version2;
						string[] items2 = list2._items;
						if (list2._size >= items2.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire20");
						}
						else
						{
							int size2 = list2._size + 1;
							list2._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version3 = list2._version + 1;
						list2._version = version3;
						string[] items3 = list2._items;
						if (list2._size >= items3.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire21");
						}
						else
						{
							int size3 = list2._size + 1;
							list2._size = size3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list2._version + 1;
						list2._version = version4;
						string[] items4 = list2._items;
						if (list2._size >= items4.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire22");
						}
						else
						{
							int size4 = list2._size + 1;
							list2._size = size4;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version5 = list2._version + 1;
						list2._version = version5;
						string[] items5 = list2._items;
						if (list2._size >= items5.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire23");
						}
						else
						{
							int size5 = list2._size + 1;
							list2._size = size5;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version6 = list2._version + 1;
						list2._version = version6;
						string[] items6 = list2._items;
						if (list2._size >= items6.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire24");
						}
						else
						{
							int size6 = list2._size + 1;
							list2._size = size6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version7 = list2._version + 1;
						list2._version = version7;
						string[] items7 = list2._items;
						if (list2._size >= items7.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire25");
						}
						else
						{
							int size7 = list2._size + 1;
							list2._size = size7;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version8 = list2._version + 1;
						list2._version = version8;
						string[] items8 = list2._items;
						if (list2._size >= items8.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire26");
						}
						else
						{
							int size8 = list2._size + 1;
							list2._size = size8;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						list2.Add("TP_VFX_Fire27");
						list2.Add("TP_VFX_Fire28");
						int version9 = list2._version + 1;
						list2._version = version9;
						string[] items9 = list2._items;
						if (list2._size >= items9.Length)
						{
							((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire29");
						}
						else
						{
							int size9 = list2._size + 1;
							list2._size = size9;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						particleSystemConfig._frame = list2;
						particleSystemConfig._fps = 16;
						ParticleSystem.MinMaxCurve lifespan = new ParticleSystem.MinMaxCurve(500f);
						particleSystemConfig._lifespan = lifespan;
						_ = 0;
						particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)3;
						_ = 0;
						particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)3;
						_ = 0;
						particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
						_ = 0;
						_ = 600f;
						particleSystemConfig._quantity = (int?)(object)1;
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
						_ = 0;
						_ = 1f;
						particleSystemConfig._frequency = (float?)(object)1;
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
						_ = 0;
						_ = 1f;
						particleSystemConfig._emitZone = emitZone;
						particleSystemConfig._simulationSpace = (ParticleSystemSimulationSpace?)(object)1;
						particleSystemConfig._on = true;
						ParticleSystem pfxEmitter = particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
						obj.pfxEmitter2 = pfxEmitter;
						object pfxEmitter2 = obj.pfxEmitter2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rdi_v16 (System.Object)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rdi_v16 (System.Object)+10]");
						IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
						bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						List<ParticleSystem>.Enumerator value = default(List<ParticleSystem>.Enumerator);
						Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
						RenderingExtensions.Start(obj.pfxEmitter2);
						action = null;
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3664 @ r10_v8 (Il2CppMethodInfo)+8]");
						((Delegate)action).method_ptr = (IntPtr)0;
						((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass34_2._003CDoDeathAnimation_003Eb__5);
						((Delegate)action).m_target = obj;
						((Delegate)action).method_code = (IntPtr)action;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3664 @ r10_v8 (Il2CppMethodInfo)+4C]");
						object obj5 = (nint)0 >> 4;
						object obj6 = obj5 & 1;
						nint num8;
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3664 @ r10_v8 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num8 = unchecked((nint)6447293664L);
								goto IL_0c0c;
							}
						}
						((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
						num8 = ((Delegate)action).method_ptr;
						goto IL_0c0c;
					}
				}
			}
			throw new NullReferenceException();
			IL_0c0c:
			object obj7 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			Timer timer2 = Timers.Register(2f, action, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			Action action2 = null;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ r10_v9 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass34_2._003CDoDeathAnimation_003Eb__6);
			((Delegate)action2).m_target = obj;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ r10_v9 (Il2CppMethodInfo)+4C]");
			object obj8 = (nint)0 >> 4;
			object obj9 = obj8 & 1;
			nint num10;
			if (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ r10_v9 (Il2CppMethodInfo)+52]");
				bool flag7 = (nint)0 == 0;
				num10 = unchecked((nint)6447293664L);
				if (flag7)
				{
					goto IL_0c9f;
				}
			}
			num10 = ((Delegate)action2).method_ptr;
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			goto IL_0c9f;
			IL_0c9f:
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			Timer timer3 = Timers.Register(3.0000002f, action2, null, isLooped: false, (byte)(int)num4 != 0, (MonoBehaviour)num5, (int)num6, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_1
	{
		public float fireAngle;

		public ParticleSystem pfxEmitter;

		internal void _003CDoDeathAnimation_003Eb__1()
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Expected O, but got Unknown
			Transform transform = pfxEmitter.transform;
			Vector3 localEulerAngles = transform.localEulerAngles;
			float num = fireAngle - 90f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			object obj2 = obj + localEulerAngles.z;
			float num2 = (float)obj2 * ((float)Math.PI / 180f);
			Transform transform2 = pfxEmitter.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		}
	}

	private sealed class _003C_003Ec__DisplayClass34_2
	{
		public ParticleSystem pfxEmitter2;

		public _003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals1;

		internal void _003CDoDeathAnimation_003Eb__5()
		{
			RenderingExtensions.StopEmitting(pfxEmitter2);
		}

		internal void _003CDoDeathAnimation_003Eb__6()
		{
			//IL_010d: Expected O, but got I
			GameObject gameObject = pfxEmitter2.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
			_003C_003Ec__DisplayClass34_0 obj = CS_0024_003C_003E8__locals1;
			UnityEngine.Object.Destroy(obj.particleManager, 0f);
			_003C_003Ec__DisplayClass34_0 obj2 = CS_0024_003C_003E8__locals1;
			obj2._003C_003E4__this.DropReward();
			_003C_003Ec__DisplayClass34_0 obj3 = CS_0024_003C_003E8__locals1;
			EnemyLegion enemyLegion = obj3._003C_003E4__this;
			CoherenceSync coherenceSync = enemyLegion._coherenceSync;
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v18 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj4 = -3;
					bool flag2 = obj4 == null;
					flag = flag2;
				}
				if (!flag)
				{
					return;
				}
			}
			_003C_003Ec__DisplayClass34_0 obj5 = CS_0024_003C_003E8__locals1;
			obj5._003C_003E4__this.Despawn();
		}
	}

	private LegionBossPhase _phase;

	private ArcadeRect _activationRect;

	private List<EnemyLegionSection> _sections;

	private float _colourLerp;

	private float _colourLerpSpeed = 1f;

	private float2 _spawnLocation;

	private float2 _floorPosition;

	private float2 _startPosition;

	private float _movementTimer;

	private float _spawnTimer;

	private List<EnemyLegionZombie> _zombieList;

	private List<Tentacle> _tentacles;

	private MultiTargetTween _activationTween;

	public float _timeUntilSectionsVulnerable;

	public LegionBossPhase Phase => _phase;

	public float FloorHeight
	{
		get
		{
			//IL_000d: Expected F4, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.EnemyLegion)+2A4]");
			return 0f;
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0083: Expected I4, but got O
		//IL_0310: Expected I4, but got O
		//IL_0554: Expected O, but got I4
		//IL_05c3: Expected O, but got I4
		//IL_05c3: Expected O, but got I4
		//IL_0412->IL06cc: Incompatible stack heights: 1 vs 0
		//IL_0455->IL06cc: Incompatible stack heights: 2 vs 0
		//IL_049e->IL073a: Incompatible stack heights: 2 vs 0
		//IL_04a3->IL04a3: Incompatible stack heights: 2 vs 0
		//IL_07b2->IL06cc: Incompatible stack heights: 1 vs 0
		//IL_0826->IL06cc: Incompatible stack heights: 3 vs 0
		//IL_06af->IL06cc: Incompatible stack heights: 4 vs 0
		base.InitEnemy(enemyType, asRemote);
		List<EnemyLegionZombie> zombieList = new List<EnemyLegionZombie>();
		_zombieList = zombieList;
		_spawnTimer = 0f;
		GameManager core = GM.Core;
		float2 activationRect = default(float2);
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				EnemyType enemyType2 = (EnemyType)stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rsi_v12 (VampireSurvivors.Data.EnemyType)+10]");
					if ((nint)0 != 0)
					{
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
							{
								List<Vector2> specialLocations = stage2._tilingTileset.GetSpecialLocations("LegionSpawn");
								if (specialLocations != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rax_v106 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
										base.position = activationRect;
									}
								}
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null)
								{
									Stage stage3 = core3._stage;
									if ((object)core3._stage != null && (object)stage3._tilingTileset != null)
									{
										List<Vector2> specialLocations2 = stage3._tilingTileset.GetSpecialLocations("LegionFloor");
										if (specialLocations2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rax_v111 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
											if ((nint)0 > (nint)0)
											{
												((List<EnemyLegionZombie>)(object)specialLocations2)._002Ector();
												List<EnemyLegionZombie> floorPosition = default(List<EnemyLegionZombie>);
												_floorPosition = (float2)floorPosition;
											}
										}
										goto IL_06fa;
									}
								}
							}
						}
						goto IL_06cc;
					}
				}
				goto IL_06fa;
			}
		}
		goto IL_06cc;
		IL_04a3:
		GameManager core4 = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage4 = core4._stage;
			if ((object)core4._stage != null)
			{
				if (stage4._spawnTimer != null)
				{
					stage4._spawnTimer.Cancel();
				}
				base._003CIsCullable_003Ek__BackingField = false;
				base._003CIsTeleportOnCull_003Ek__BackingField = false;
				ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
				Sprite sprite = SpriteManager.GetSprite("Legion_Heart", "Legion");
				ArcadeSprite arcadeSprite2 = setFrame(sprite);
				if (body != null)
				{
					BaseBody baseBody = body.setCircle(28f, (float?)(object)1, (float?)(object)1);
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._immovable = true;
						BaseBody baseBody3 = body;
						if (body != null)
						{
							baseBody3._pushable = false;
							BaseBody baseBody4 = body;
							if (body != null)
							{
								baseBody4._enable = false;
								_phase = LegionBossPhase.Unactivated;
								bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v66 (UnityEngine.Transform)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v66 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out Vector3 _);
									bool flag3 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
									Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
									if ((object)transform2 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v76 (UnityEngine.Transform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v76 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out Vector3 _);
										_colourLerp = 0f;
										_timeUntilSectionsVulnerable = 20f;
										_activationRect = (ArcadeRect)activationRect;
										List<EnemyLegionSection> sections = new List<EnemyLegionSection>();
										_sections = sections;
										InstantiateSections();
										Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1055 Invalid \"Jump target not found in method: 0x1876A2340\"");
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_06cc;
		IL_06cc:
		throw new NullReferenceException();
		IL_06fa:
		float2 spawnLocation = base.position;
		_spawnLocation = spawnLocation;
		GameManager core5 = GM.Core;
		if ((object)GM.Core != null)
		{
			core5._canRunTickerTimer = false;
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				Stage stage5 = gameManager._stage;
				if ((object)gameManager._stage != null)
				{
					EnemyType enemyType3 = (EnemyType)stage5._spawnedEnemies;
					bool flag5 = (nint)stage5._spawnedEnemies < 0;
					if (stage5._spawnedEnemies != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rsi_v13 (VampireSurvivors.Data.EnemyType)+18]");
						EnemyType enemyType4 = (EnemyType)(-1);
						if (flag5)
						{
							goto IL_04a3;
						}
						while (true)
						{
							GameManager gameManager2 = _gameManager;
							if ((object)_gameManager == null)
							{
								break;
							}
							Stage stage6 = gameManager2._stage;
							if ((object)gameManager2._stage == null)
							{
								break;
							}
							List<EnemyController> spawnedEnemies = stage6._spawnedEnemies;
							if (stage6._spawnedEnemies == null)
							{
								break;
							}
							bool flag6 = (int)enemyType4 >= spawnedEnemies._size;
							EnemyController[] items = spawnedEnemies._items;
							if (spawnedEnemies._items == null)
							{
								break;
							}
							bool flag7 = (int)enemyType4 >= items.Length;
							if ((object)items[(int)enemyType4] == null)
							{
								break;
							}
							items[(int)enemyType4].Disappear();
							enemyType4--;
							if ((nint)items[(int)enemyType4] >= 0)
							{
								continue;
							}
							goto IL_04a3;
						}
					}
				}
			}
		}
		goto IL_06cc;
	}

	private void InstantiateSections()
	{
		//IL_0098: Expected O, but got I8
		//IL_0227: Expected O, but got I8
		//IL_006f: Expected O, but got I
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v21 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v21 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v21 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		int2 int5 = (int2)4294967295L;
		EnemyLegionSection enemyLegionSection = default(EnemyLegionSection);
		Vector2 param = default(Vector2);
		do
		{
			object obj2 = 4294967295L;
			do
			{
				GameManager core = GM.Core;
				float2 float5 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				GameObject owner = base.gameObject;
				enemyLegionSection.SetOwner(owner);
				GameManager core2 = GM.Core;
				if (!core2._multiplayer.IsOnlineMultiplayer)
				{
					enemyLegionSection.SetupLegionSection(this, int5);
				}
				else
				{
					Action<CoherenceSync, Vector2> action = enemyLegionSection.OnlineSetupSection;
					bool flag3 = ((EnemyController)enemyLegionSection)._coherenceSync.SendCommand((Action<object, Vector2>)action, MessageTarget.All, _coherenceSync, param);
				}
				obj2++;
			}
			while ((nint)obj2 <= 1);
			int5++;
		}
		while ((nint)int5 <= 1);
	}

	private unsafe void SetupTentacles()
	{
		//IL_0034: Expected O, but got I4
		//IL_0315: Expected O, but got I4
		//IL_043c: Expected O, but got I4
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_0081->IL05c2: Incompatible stack heights: 1 vs 0
		//IL_00d5->IL05c2: Incompatible stack heights: 1 vs 0
		//IL_00f7->IL05c2: Incompatible stack heights: 1 vs 0
		//IL_0145->IL05c2: Incompatible stack heights: 1 vs 0
		//IL_0184->IL05c2: Incompatible stack heights: 1 vs 0
		//IL_01c7->IL05c2: Incompatible stack heights: 2 vs 0
		//IL_0224->IL05c2: Incompatible stack heights: 2 vs 0
		//IL_026b->IL05c2: Incompatible stack heights: 2 vs 0
		//IL_077e->IL05c2: Incompatible stack heights: 3 vs 0
		//IL_02ae->IL05c2: Incompatible stack heights: 3 vs 0
		//IL_02fd->IL05c2: Incompatible stack heights: 3 vs 0
		//IL_0331->IL05c2: Incompatible stack heights: 3 vs 0
		//IL_038a->IL05c2: Incompatible stack heights: 3 vs 0
		//IL_079b->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_03d5->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_0424->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_0458->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_04a5->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_04f4->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_05a9->IL05c2: Incompatible stack heights: 4 vs 0
		//IL_059a->IL0735: Incompatible stack heights: 4 vs 0
		List<Tentacle> tentacles = new List<Tentacle>();
		_tentacles = tentacles;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Legion_Tongue", 1, 4, "Legion", num);
		object obj = 0;
		string text = "Legion";
		Vector2 pos = default(Vector2);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		while (true)
		{
			Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
			if ((object)cachedTrans == null)
			{
				break;
			}
			bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (body != null)
			{
				BaseBody baseBody = body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				if (baseBody._transform == null)
				{
					break;
				}
				arcadeTransform.position = ret;
			}
			GameObject gameObject = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "Legion", "Legion_Tongue1");
			if ((object)phaserSprite == null || (object)phaserSprite._spriteAnimation == null)
			{
				break;
			}
			phaserSprite._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			if ((object)phaserSprite._spriteAnimation == null)
			{
				break;
			}
			phaserSprite._spriteAnimation.SetAnimation("idle");
			Transform cachedTrans2 = ((ArcadeSprite)this).CachedTrans;
			if ((object)cachedTrans2 == null)
			{
				break;
			}
			bool flag2 = ((UnityEngine.Object)cachedTrans2).m_CachedPtr == (IntPtr)0;
			float2 ret2;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans2).m_CachedPtr, out *(Vector3*)(&ret2));
			if (body != null)
			{
				BaseBody baseBody2 = body;
				ArcadeTransform arcadeTransform2 = baseBody2._transform;
				if (baseBody2._transform == null)
				{
					break;
				}
				arcadeTransform2.position = ret2;
			}
			GameObject gameObject2 = base.gameObject;
			PhaserSprite head = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "Legion", "Legion_TongueTip");
			Tentacle tentacle = new Tentacle();
			if (tentacle == null)
			{
				break;
			}
			tentacle._arm = phaserSprite;
			tentacle._head = head;
			PhaserWorld instance = PhaserWorld.Instance;
			Transform cachedTrans3 = ((ArcadeSprite)this).CachedTrans;
			if ((object)cachedTrans3 == null)
			{
				break;
			}
			bool flag3 = ((UnityEngine.Object)cachedTrans3).m_CachedPtr == (IntPtr)0;
			float2 ret3;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans3).m_CachedPtr, out *(Vector3*)(&ret3));
			if (body != null)
			{
				BaseBody baseBody3 = body;
				ArcadeTransform arcadeTransform3 = baseBody3._transform;
				if (baseBody3._transform == null)
				{
					break;
				}
				arcadeTransform3.position = ret3;
			}
			if ((object)instance == null)
			{
				break;
			}
			PhaserSprite phaserSprite2 = instance.AddPhaserSprite(pos, "Legion", "Legion_Laser");
			if ((object)phaserSprite2 == null)
			{
				break;
			}
			PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
			if ((object)phaserSprite3 == null)
			{
				break;
			}
			PhaserSprite laser = phaserSprite3.setVisible(visible: false);
			tentacle._laser = laser;
			PhaserWorld instance2 = PhaserWorld.Instance;
			Transform cachedTrans4 = ((ArcadeSprite)this).CachedTrans;
			if ((object)cachedTrans4 == null)
			{
				break;
			}
			num = num;
			bool flag4 = ((UnityEngine.Object)cachedTrans4).m_CachedPtr == (IntPtr)0;
			float2 ret4;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans4).m_CachedPtr, out *(Vector3*)(&ret4));
			if (body != null)
			{
				BaseBody baseBody4 = body;
				ArcadeTransform arcadeTransform4 = baseBody4._transform;
				if (baseBody4._transform == null)
				{
					break;
				}
				arcadeTransform4.position = ret4;
			}
			if ((object)instance2 == null)
			{
				break;
			}
			PhaserSprite phaserSprite4 = instance2.AddPhaserSprite(pos, "Legion", "Legion_LaserCap");
			if ((object)phaserSprite4 == null)
			{
				break;
			}
			PhaserSprite phaserSprite5 = phaserSprite4.setOrigin(0.5f, (float?)(object)1);
			if ((object)phaserSprite5 == null)
			{
				break;
			}
			PhaserSprite laserCap = phaserSprite5.setVisible(visible: false);
			tentacle._laserCap = laserCap;
			List<object> tentacles2 = (List<object>)(object)_tentacles;
			if (_tentacles == null)
			{
				break;
			}
			int version = tentacles2._version + 1;
			tentacles2._version = version;
			text = (string)(object)tentacles2._items;
			if (tentacles2._items == null)
			{
				break;
			}
			int num2 = tentacles2._size;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v2 (System.String)+18]");
			if ((nint)num2 >= (nint)0)
			{
				((List<object>)(object)_tentacles).AddWithResize((object)tentacle);
			}
			else
			{
				int num3 = tentacles2._size + 1;
				tentacles2._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
			if ((nint)obj < 8)
			{
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1124 Invalid \"Jump target not found in method: 0x1876A2D20\"");
			break;
		}
		throw new NullReferenceException();
	}

	private void UpdateTentacles()
	{
		//IL_0262: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		//IL_0304: Expected O, but got I4
		//IL_0320: Expected O, but got I4
		//IL_0111: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_01bc: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 122 Invalid \"Jump target not found in method: 0x1876A3746\"");
		object obj = 0 * 45;
		float num = (float)obj * ((float)Math.PI / 180f);
		List<Tentacle> tentacles = _tentacles;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 139 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 151 Invalid \"Jump target not found in method: 0x1876A37A7\"");
		Tentacle[] items = tentacles._items;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 163 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		float? num2 = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 176 Invalid \"Jump target not found in method: 0x1876A3795\"");
		Tentacle tentacle = items[(object)num2];
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 190 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		PhaserSprite arm = tentacle._arm;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 205 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		PhaserSprite phaserSprite = tentacle._arm.setOrigin(1f, (float?)(object)1);
		PhaserSprite phaserSprite2 = tentacle._arm.setScale(2f, (float?)(object)0);
		float num3 = (float)obj + 180f;
		tentacle._arm.angle = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 232 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num4 = num * -0.1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int num5 = base.depth;
		int num6 = num5 - 1;
		PhaserSprite phaserSprite3 = tentacle._arm.setDepth(num6);
		SpriteAnimation spriteAnimation = arm._spriteAnimation;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 270 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		FrameAnimationData currentAnimation = ((BaseSpriteAnimation)spriteAnimation)._currentAnimation;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 282 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		SpriteAnimation spriteAnimation2 = arm._spriteAnimation;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 297 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,edx\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rax+18h]\"");
		object obj2 = 0 / 0;
		float num7 = (float)obj2 * (float)Math.PI;
		float num8 = num7 + num7;
		float num9 = num8 + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num10 = num9 * -8f;
		float num11 = num10 + (float)obj;
		float num12 = num11 + 2f;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 326 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		PhaserSprite phaserSprite4 = tentacle._head.setOrigin(0.5f, (float?)(object)1);
		PhaserSprite phaserSprite5 = tentacle._head.setScale(2f, (float?)(object)0);
		float num13 = num12 + 90f;
		tentacle._head.angle = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 353 Invalid \"Jump target not found in method: 0x1876A37AF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int num14 = base.depth;
		PhaserSprite phaserSprite6 = tentacle._head.setDepth(num14);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 392 Invalid \"Jump target not found in method: 0x1876A31F4\"");
	}

	private bool IsMiddleSectionDead()
	{
		//IL_0013: Expected O, but got I4
		List<EnemyLegionSection>.Enumerator enumerator = default(List<EnemyLegionSection>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = 0;
		}
		return true;
	}

	public void ChangeTentacleHeadFrame(int tentacleIndex, string spriteName, string textureName, bool isFiring, bool stopFiring)
	{
		List<Tentacle> tentacles = _tentacles;
		if (tentacleIndex < tentacles._size)
		{
			Tentacle[] items = tentacles._items;
			Tentacle tentacle = items[tentacleIndex];
			bool flag = default(bool);
			tentacle._isFiring = flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
			Sprite sprite = default(Sprite);
			PhaserSprite phaserSprite = tentacle._head.setFrame(sprite);
			if (flag)
			{
				tentacle._chargeCounter = 1f;
			}
			object obj = default(object);
			if (obj != null)
			{
				PhaserSprite phaserSprite2 = tentacle._laser.setVisible(visible: false);
				PhaserSprite phaserSprite3 = tentacle._laserCap.setVisible(visible: false);
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe void FireTentacleLaser(int tentacleIndex)
	{
		//IL_0149: Expected O, but got I4
		//IL_02de: Expected O, but got Ref
		//IL_0349: Expected O, but got I4
		//IL_0393: Expected I4, but got I8
		//IL_04c8: Expected O, but got Ref
		//IL_0533: Expected O, but got I4
		//IL_057d: Expected I4, but got I8
		//IL_0b7c: Expected I, but got O
		//IL_0bad: Expected O, but got I
		//IL_065d: Expected I4, but got O
		//IL_06a5: Expected F4, but got I4
		//IL_0b18: Expected O, but got Ref
		//IL_06b3: Expected F4, but got I4
		//IL_06bb: Expected O, but got Ref
		//IL_08e7: Invalid comparison between I4 and F4
		//IL_08bd: Expected O, but got I
		//IL_0982: Expected I4, but got O
		List<Tentacle> tentacles = _tentacles;
		bool flag = _tentacles == null;
		EnemyLegion enemyLegion = this;
		if (!flag)
		{
			if (tentacleIndex >= tentacles._size)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			Tentacle[] items = tentacles._items;
			bool flag2 = tentacles._items == null;
			enemyLegion = this;
			if (!flag2)
			{
				bool flag3 = tentacleIndex >= items.Length;
				enemyLegion = this;
				if (flag3)
				{
					throw new IndexOutOfRangeException();
				}
				Tentacle tentacle = items[tentacleIndex];
				bool flag4 = items[tentacleIndex] == null;
				enemyLegion = this;
				if (!flag4)
				{
					tentacle._aimCounter = 0f;
					float deltaTime = PauseSystem.DeltaTime;
					float num = deltaTime * 0.5f;
					float num2 = (tentacle._chargeCounter -= num);
					object obj = tentacleIndex * 45;
					float num3 = ((!(0.1f > num2)) ? 1f : (num2 * 10f));
					float num4 = (float)obj * ((float)Math.PI / 180f);
					bool flag5 = (object)tentacle._laser == null;
					enemyLegion = (EnemyLegion)(object)tentacle._laser;
					if (!flag5)
					{
						PhaserSprite phaserSprite = tentacle._laser.setVisible(visible: true);
						bool flag6 = (object)tentacle._head == null;
						enemyLegion = (EnemyLegion)(object)tentacle._laser;
						if (!flag6)
						{
							float2 float5 = tentacle._head.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
							float num5 = num4 * 0.6f;
							float num6 = num4 * 0.6f;
							object obj2 = default(object);
							float num7 = (float)obj2 + num5;
							float num8 = (float)float5 + num6;
							enemyLegion = (EnemyLegion)(object)tentacle._laser;
							if ((object)tentacle._laser != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								Transform transform = tentacle._head.transform;
								bool flag7 = (object)transform == null;
								enemyLegion = (EnemyLegion)(object)tentacle._head;
								if (!flag7)
								{
									Vector3 localEulerAngles = transform.localEulerAngles;
									bool flag8 = (object)tentacle._laser == null;
									List<BaseBody> list = default(List<BaseBody>);
									enemyLegion = (EnemyLegion)(&list);
									if (!flag8)
									{
										tentacle._laser.angle = localEulerAngles.z;
										bool flag9 = (object)tentacle._laser == null;
										enemyLegion = (EnemyLegion)(object)tentacle._laser;
										if (!flag9)
										{
											PhaserSprite phaserSprite2 = tentacle._laser.setScale(num3, (float?)(object)1);
											bool flag10 = (object)tentacle._laser == null;
											enemyLegion = (EnemyLegion)(object)tentacle._laser;
											if (!flag10)
											{
												PhaserSprite phaserSprite3 = tentacle._laser.setDepth(-2000);
												bool flag11 = (object)tentacle._laserCap == null;
												enemyLegion = (EnemyLegion)(object)tentacle._laserCap;
												if (!flag11)
												{
													PhaserSprite phaserSprite4 = tentacle._laserCap.setVisible(visible: true);
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
													float num9 = num4 * -1f;
													float num10 = num9 * (1f / 32f);
													float num11 = num10 + num7;
													bool flag12 = (object)tentacle._laserCap == null;
													enemyLegion = (EnemyLegion)(object)tentacle._laserCap;
													if (!flag12)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
														Transform transform2 = tentacle._head.transform;
														bool flag13 = (object)transform2 == null;
														enemyLegion = (EnemyLegion)(object)tentacle._head;
														if (!flag13)
														{
															Vector3 localEulerAngles2 = transform2.localEulerAngles;
															bool flag14 = (object)tentacle._laserCap == null;
															enemyLegion = (EnemyLegion)(&list);
															if (!flag14)
															{
																tentacle._laserCap.angle = localEulerAngles2.z;
																bool flag15 = (object)tentacle._laserCap == null;
																enemyLegion = (EnemyLegion)(object)tentacle._laserCap;
																if (!flag15)
																{
																	PhaserSprite phaserSprite5 = tentacle._laserCap.setScale(num3, (float?)(object)1);
																	bool flag16 = (object)tentacle._laserCap == null;
																	enemyLegion = (EnemyLegion)(object)tentacle._laserCap;
																	if (!flag16)
																	{
																		PhaserSprite phaserSprite6 = tentacle._laserCap.setDepth(-1998);
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
																		float num12 = num4 * 10f;
																		float num13 = num4 * 10f;
																		float y = num7 + num12;
																		float x = num8 + num13;
																		Color color = default(Color);
																		VSDebug.DrawDebugLine(num8, num7, x, y, color);
																		float lineWidth = num3 * 0.22f;
																		nint num14 = (nint)typeof(PhysicsManager);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v43 (Il2CppClass<VampireSurvivors.Framework.PhysicsManager>)+B8]");
																		nint num15 = 0;
																		PhysicsManager sInstance = PhysicsManager._sInstance;
																		bool flag17 = PhysicsManager._sInstance == null;
																		enemyLegion = (EnemyLegion)num15;
																		if (!flag17)
																		{
																			enemyLegion = (EnemyLegion)(object)sInstance._playerGroup;
																			if ((object)ArcadePhysics.s_instance != null)
																			{
																				float2 float6 = default(float2);
																				bool flag18 = default(bool);
																				Group specificGroup = default(Group);
																				List<BaseBody> list2 = ArcadePhysics.s_instance.OverlapLine(float6, float6, lineWidth, (byte)(int)color != 0, flag18, specificGroup);
																				bool flag19 = list2 == null;
																				enemyLegion = (EnemyLegion)(object)ArcadePhysics.s_instance;
																				if (!flag19)
																				{
																					float2 float7 = float6;
																					List<BaseBody> list3 = list2;
																					float num16 = 0f;
																					List<BaseBody>.Enumerator enumerator = default(List<BaseBody>.Enumerator);
																					if (enumerator.MoveNext())
																					{
																						float num17 = 0f;
																						List<BaseBody>.Enumerator enumerator2 = (List<BaseBody>.Enumerator)(&enumerator);
																						throw new NullReferenceException();
																					}
																					CoherenceSync coherenceSync = _coherenceSync;
																					bool flag20 = (object)_coherenceSync == null;
																					enemyLegion = (EnemyLegion)(&enumerator);
																					if (!flag20)
																					{
																						NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
																						if (coherenceSync._003CEntityState_003Ek__BackingField != null)
																						{
																							enemyLegion = (EnemyLegion)(object)networkEntityState._003CAuthorityType_003Ek__BackingField;
																							if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
																							{
																								goto IL_09ca;
																							}
																							bool flag21 = (byte)(nint)((UnityEngine.Object)enemyLegion).m_CachedPtr != 0;
																							if (((UnityEngine.Object)enemyLegion).m_CachedPtr != (IntPtr)1)
																							{
																								object obj3 = (nint)((UnityEngine.Object)enemyLegion).m_CachedPtr - 3;
																								bool flag22 = obj3 == null;
																								flag21 = flag22;
																							}
																							if (!flag21)
																							{
																								return;
																							}
																						}
																						if (0f < tentacle._chargeCounter)
																						{
																							return;
																						}
																						GameManager core = GM.Core;
																						if ((object)GM.Core != null && core._multiplayer != null)
																						{
																							if (!core._multiplayer.IsOnlineMultiplayer)
																							{
																								ChangeTentacleHeadFrame(tentacleIndex, "Legion_TongueTip", "Legion", (byte)(int)color != 0, flag18);
																								return;
																							}
																							Action<int, string, string, bool, bool> action = null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2EA0");
																							if ((object)_coherenceSync != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6FD70");
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
		goto IL_09ca;
		IL_09ca:
		throw new NullReferenceException();
	}

	private void SpawnZombies()
	{
		//IL_006f: Expected O, but got I
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_03d2: Expected O, but got F4
		//IL_0251: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v29 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v29 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ rcx_v29 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		List<EnemyLegionSection> sections = _sections;
		bool flag3 = false;
		bool flag4 = false;
		object obj3 = default(object);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			if ((flag4 ? 1 : 0) >= sections._size)
			{
				return;
			}
			_003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass27_0();
			CS_0024_003C_003E8__locals3._003C_003E4__this = this;
			List<EnemyLegionSection> sections2 = _sections;
			if ((flag3 ? 1 : 0) >= sections2._size)
			{
				break;
			}
			EnemyLegionSection[] items = sections2._items;
			ArcadeSprite arcadeSprite = items[flag3 ? 1u : 0u];
			if ((object)items[flag3 ? 1u : 0u] != null && ((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v9 (ArcadeSprite)+260]");
				if ((nint)0 == 0)
				{
					float num = UnityEngine.Random.Range(0f, (float)Math.PI * 2f);
					BaseBody baseBody = arcadeSprite.body;
					float num2 = UnityEngine.Random.Range(0f, baseBody._radius);
					float2 float5 = items[flag3 ? 1u : 0u].position;
					BaseBody baseBody2 = arcadeSprite.body;
					float2 float6 = float5 + baseBody2._halfSize;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v27 (BaseBody)+64]");
					object obj2 = obj3 + 0;
					if (baseBody2._enable)
					{
						float6 = baseBody2._center;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v27 (BaseBody)+6C]");
						obj2 = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
					float num3 = num * num2;
					float num4 = num * num2;
					float num5 = (float)obj2 + num3;
					float num6 = (float)float6 + num4;
					CS_0024_003C_003E8__locals3.randomPoint = (float2)num6;
					int num7 = UnityEngine.Random.Range(0, 1000);
					Action onComplete = delegate
					{
						float2 float7 = default(float2);
						CS_0024_003C_003E8__locals3._003C_003E4__this.SpawnZombie(float7);
					};
					float duration = (float)num7 * 0.001f;
					Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				}
			}
			sections = _sections;
			flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
			flag4 = flag3;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void SpawnZombie(float2 position)
	{
		//IL_014d: Expected O, but got I4
		List<EnemyLegionZombie> zombieList = _zombieList;
		if (zombieList._size >= 50)
		{
			int num = zombieList._size - 1;
			object obj;
			do
			{
				List<EnemyLegionZombie> zombieList2 = _zombieList;
				bool flag;
				if (num < zombieList2._size)
				{
					EnemyLegionZombie[] items = zombieList2._items;
					EnemyLegionZombie enemyLegionZombie = items[num];
					if ((object)items[num] != null && ((UnityEngine.Object)enemyLegionZombie).m_CachedPtr != (IntPtr)0)
					{
						EnemyLegionZombie enemyLegionZombie2 = _zombieList.get_Item(num);
						flag = (((EnemyController)enemyLegionZombie2)._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!((EnemyController)enemyLegionZombie2)._003CIsDead_003Ek__BackingField)
						{
							goto IL_0134;
						}
					}
					flag = (nint)_zombieList < 0;
					_zombieList.RemoveAt(num);
					goto IL_0134;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_0134:
				num--;
				obj = !flag;
			}
			while (obj != null);
			List<EnemyLegionZombie> zombieList3 = _zombieList;
			if (zombieList3._size >= 50)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		_ = 0;
		_ = 0;
		List<object> zombieList4 = (List<object>)(object)_zombieList;
		int version = zombieList4._version + 1;
		zombieList4._version = version;
		object[] items2 = zombieList4._items;
		if (zombieList4._size >= items2.Length)
		{
			object item = default(object);
			zombieList4.AddWithResize(item);
			return;
		}
		int num2 = zombieList4._size + 1;
		zombieList4._size = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public List<EnemyLegionSection> GetSections()
	{
		return _sections;
	}

	public override void Despawn()
	{
		//IL_0013: Expected O, but got I4
		//IL_00c6: Expected I4, but got O
		//IL_00c6: Expected O, but got I
		bool flag = _sections == null;
		EnemyLegion enemyLegion = this;
		if (!flag)
		{
			List<EnemyLegionSection>.Enumerator enumerator = default(List<EnemyLegionSection>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj = 0;
			}
			enemyLegion = (EnemyLegion)(object)_sections;
			if (_sections != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v2 (VampireSurvivors.Objects.Characters.Enemies.EnemyLegion)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)enemyLegion).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)enemyLegion).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)enemyLegion).m_CachedPtr, 0, (int)((MonoBehaviour)enemyLegion).m_CancellationTokenSource);
				}
				base.Despawn();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_0019: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		if (!IsMiddleSectionDead())
		{
			return;
		}
		List<EnemyLegionSection> sections = _sections;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		while (true)
		{
			if ((nint)obj2 < sections._size)
			{
				List<EnemyLegionSection> sections2 = _sections;
				if ((nint)obj >= sections2._size)
				{
					break;
				}
				EnemyLegionSection[] items = sections2._items;
				EnemyLegionSection enemyLegionSection = items[obj];
				if ((object)items[obj] != null && ((UnityEngine.Object)enemyLegionSection).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v25+260]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v372 @ rdx_v11+3E8] (should have been resolved before IL gen)");
						return;
					}
				}
				sections = _sections;
				obj++;
				obj2 = obj;
				continue;
			}
			base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Disappear()
	{
		//IL_000b: Invalid comparison between I4 and F4
		if (!(0f < _timeUntilSectionsVulnerable))
		{
			base._003CIsDead_003Ek__BackingField = true;
		}
	}

	protected override void Die()
	{
		//IL_000b: Invalid comparison between I4 and F4
		if (!(0f < _timeUntilSectionsVulnerable))
		{
			base._003CIsDead_003Ek__BackingField = true;
		}
	}

	private unsafe void DoDeathAnimation()
	{
		//IL_10b6: Expected I, but got O
		//IL_0052: Expected I, but got O
		//IL_0093: Expected I, but got O
		//IL_00c9: Expected I, but got O
		//IL_10f4: Expected I, but got O
		//IL_021d: Expected I, but got O
		//IL_0146: Invalid comparison between F4 and I4
		//IL_024d: Expected O, but got I
		//IL_0252: Expected I, but got O
		//IL_0168: Expected O, but got F4
		//IL_1170: Expected I, but got O
		//IL_034a: Expected O, but got I
		//IL_034f: Expected I, but got O
		//IL_02d3: Expected I, but got O
		//IL_0455: Expected O, but got I4
		//IL_1216: Expected O, but got I4
		//IL_137f: Expected O, but got I4
		//IL_139d: Expected O, but got I4
		//IL_123e: Expected O, but got I4
		//IL_13c1: Expected O, but got I4
		//IL_1256: Expected O, but got I4
		//IL_13e5: Expected O, but got I4
		//IL_0c9b: Expected O, but got I4
		//IL_12a3: Expected I, but got O
		//IL_0db4: Expected O, but got I
		//IL_0e84: Invalid comparison between F4 and I4
		//IL_0ea4: Expected I4, but got O
		//IL_0e53: Expected I, but got O
		//IL_0ec9: Expected O, but got I4
		//IL_0f9e: Expected I, but got O
		//IL_102f: Expected O, but got I4
		//IL_103d: Expected O, but got I4
		//IL_0e76->IL0e76: Incompatible stack heights: 4 vs 3
		//IL_0f5f->IL134a: Incompatible stack heights: 4 vs 0
		//IL_0fa7->IL1084: Incompatible stack heights: 4 vs 0
		//IL_0ffd->IL1084: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass34_0 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass34_0();
		bool flag = CS_0024_003C_003E8__locals26 == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass34_0);
		if (!flag)
		{
			CS_0024_003C_003E8__locals26._003C_003E4__this = this;
			bool flag2 = (object)GM.Core == null;
			num = (nint)GM.Core;
			if (!flag2)
			{
				GM.Core.SetAllPlayersWeaponsActive(active: false);
				BaseBody baseBody = body;
				bool flag3 = body == null;
				num = (nint)GM.Core;
				if (!flag3)
				{
					baseBody._enable = false;
					bool flag4 = _tentacles == null;
					num = (nint)GM.Core;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183759310");
						List<Tentacle>.Enumerator enumerator = default(List<Tentacle>.Enumerator);
						TweenConfig tweenConfig = default(TweenConfig);
						while (enumerator.MoveNext())
						{
							if (tweenConfig != null)
							{
								if (tweenConfig.targets != null)
								{
									((PhaserSprite)(object)tweenConfig.targets).destroy();
								}
								if (tweenConfig.duration != 0f)
								{
									((PhaserSprite)tweenConfig.duration).destroy();
								}
								if (tweenConfig.onStart != null)
								{
									((PhaserSprite)(object)tweenConfig.onStart).destroy();
								}
								if (tweenConfig.onComplete != null)
								{
									((PhaserSprite)(object)tweenConfig.onComplete).destroy();
								}
							}
						}
						num = (nint)_tentacles;
						if (_tentacles != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+18]");
							bool flag5 = (nint)0 <= (nint)0;
							nint num2 = (nint)typeof(GM);
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+10]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+18]");
								Array.Clear((Array)num3, 0, 0);
								num2 = unchecked((nint)null);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+10]");
								num = 0;
							}
							if (_zombieList != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183759310");
								List<EnemyLegionZombie>.Enumerator enumerator2 = default(List<EnemyLegionZombie>.Enumerator);
								while (enumerator2.MoveNext())
								{
									if (tweenConfig != null && tweenConfig.targets != null)
									{
										nint num4 = (nint)tweenConfig;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1605 @ rdx_v194 (Il2CppClass<VampireSurvivors.Framework.PhaserTweens.TweenConfig>)+388] (should have been resolved before IL gen)");
									}
								}
								num = (nint)_zombieList;
								if (_zombieList != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+1C]");
									_ = (nint)0 + (nint)1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+10]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v360 @ rcx_v35 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyLegion+<>c__DisplayClass34_0>)+18]");
										Array.Clear((Array)num5, 0, 0);
										num2 = unchecked((nint)null);
									}
									TweenConfig tweenConfig2 = new TweenConfig();
									object[] array = new object[1];
									CheckRenderer();
									if ((object)((ArcadeSprite)this)._spriteRenderer != null)
									{
										Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
										if (array != null)
										{
											if ((object)transform != null)
											{
												object obj = array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj2 = default(object);
												if (obj2 == null)
												{
													ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
													throw ex;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig2 != null)
											{
												tweenConfig2.targets = array;
												tweenConfig2.angle = (float?)(object)1;
												tweenConfig2.duration = 3000f;
												tweenConfig2.ease = Ease.Linear;
												tweenConfig2.rotateMode = RotateMode.FastBeyond360;
												MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
												GameObject gameObject = base.gameObject;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A999F0");
												ParticleEmitterManager particleManager = default(ParticleEmitterManager);
												CS_0024_003C_003E8__locals26.particleManager = particleManager;
												Circle circle = new Circle();
												circle._x = 0f;
												circle._radius = 32f;
												EmitZone emitZone = new EmitZone();
												emitZone._type = EmitZoneType.Random;
												emitZone._source = circle;
												CS_0024_003C_003E8__locals26.emitZone = emitZone;
												List<ParticleSystem> pfxEmitters = new List<ParticleSystem>();
												CS_0024_003C_003E8__locals26.pfxEmitters = pfxEmitters;
												Action onComplete = _003C_003Ec._003C_003E9__34_0;
												if (_003C_003Ec._003C_003E9__34_0 == null)
												{
													onComplete = (_003C_003Ec._003C_003E9__34_0 = delegate
													{
														//IL_0033: Expected F4, but got I4
														float? volume = default(float?);
														float rate = default(float);
														float detune = default(float);
														bool loop = default(bool);
														PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
													});
												}
												bool useRealTime = default(bool);
												MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
												int repeat = default(int);
												TimerType type = default(TimerType);
												Timer timer = Timers.Register(0.15f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
												bool flag6 = false;
												TweenConfig tweenConfig3 = tweenConfig;
												TweenConfig value = default(TweenConfig);
												object obj4 = default(object);
												bool flag12;
												TweenConfig tweenConfig5 = default(TweenConfig);
												do
												{
													_003C_003Ec__DisplayClass34_1 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass34_1();
													float fireAngle = (float)(flag6 ? 1 : 0) * 45f;
													CS_0024_003C_003E8__locals20.fireAngle = fireAngle;
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
													particleSystemConfig._fps = 16;
													ParticleSystem.MinMaxCurve lifespan = new ParticleSystem.MinMaxCurve(500f);
													particleSystemConfig._lifespan = lifespan;
													_ = 0;
													particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)3;
													_ = 0;
													particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)3;
													_ = 0;
													particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
													_ = 0;
													_ = 600f;
													particleSystemConfig._quantity = (int?)(object)1;
													particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
													_ = 0;
													_ = 1f;
													particleSystemConfig._frequency = (float?)(object)1;
													particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
													_ = 0;
													_ = 1f;
													particleSystemConfig._emitZone = CS_0024_003C_003E8__locals26.emitZone;
													particleSystemConfig._simulationSpace = (ParticleSystemSimulationSpace?)(object)1;
													particleSystemConfig._on = true;
													ParticleSystem pfxEmitter = CS_0024_003C_003E8__locals26.particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
													CS_0024_003C_003E8__locals20.pfxEmitter = pfxEmitter;
													float num17 = CS_0024_003C_003E8__locals20.fireAngle + 90f;
													float num18 = num17 * ((float)Math.PI / 180f);
													TweenConfig pfxEmitter2 = (TweenConfig)(object)CS_0024_003C_003E8__locals20.pfxEmitter;
													bool flag7 = pfxEmitter2.targets == null;
													IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)pfxEmitter2.targets);
													Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
													Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
													Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
													bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
													RenderingExtensions.Start(CS_0024_003C_003E8__locals20.pfxEmitter);
													List<object> pfxEmitters2 = (List<object>)(object)CS_0024_003C_003E8__locals26.pfxEmitters;
													int version12 = pfxEmitters2._version + 1;
													pfxEmitters2._version = version12;
													object[] items12 = pfxEmitters2._items;
													if (pfxEmitters2._size >= items12.Length)
													{
														pfxEmitters2.AddWithResize((object)CS_0024_003C_003E8__locals20.pfxEmitter);
														object obj3 = 0;
													}
													else
													{
														int num19 = pfxEmitters2._size + 1;
														pfxEmitters2._size = num19;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														object obj3 = CS_0024_003C_003E8__locals20.pfxEmitter;
													}
													TweenConfig tweenConfig4 = new TweenConfig();
													object[] array2 = new object[1];
													Transform pfxEmitter3 = (Transform)(object)CS_0024_003C_003E8__locals20.pfxEmitter;
													bool flag9 = ((UnityEngine.Object)pfxEmitter3).m_CachedPtr == (IntPtr)0;
													IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)pfxEmitter3).m_CachedPtr);
													Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
													if ((object)transform5 != null)
													{
														nint num20 = (nint)array2;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag10 = obj4 == null;
													}
													bool flag11 = !(((TweenConfig)(object)array2).duration > 0f);
													((TweenConfig)(object)array2).ease = (Ease)transform5;
													tweenConfig4.targets = array2;
													tweenConfig4.localAngle = (float?)(object)1;
													tweenConfig4.duration = 3000f;
													tweenConfig4.rotateMode = RotateMode.FastBeyond360;
													tweenConfig4.ease = Ease.Linear;
													TweenCallback onUpdate = delegate
													{
														//IL_0043: Unknown result type (might be due to invalid IL or missing references)
														//IL_0048: Expected O, but got Unknown
														//IL_0055: Unknown result type (might be due to invalid IL or missing references)
														//IL_005a: Expected O, but got Unknown
														Transform transform6 = CS_0024_003C_003E8__locals20.pfxEmitter.transform;
														Vector3 localEulerAngles = transform6.localEulerAngles;
														float num21 = CS_0024_003C_003E8__locals20.fireAngle - 90f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
														object obj7 = num21 ^ 0;
														object obj8 = obj7 + localEulerAngles.z;
														float num22 = (float)obj8 * ((float)Math.PI / 180f);
														Transform transform7 = CS_0024_003C_003E8__locals20.pfxEmitter.transform;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
														bool flag14 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
														Vector3 value2 = default(Vector3);
														Transform.set_localPosition_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref value2);
													};
													tweenConfig4.onUpdate = onUpdate;
													MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig4);
													flag6 = true;
													flag12 = (flag6 ? 1 : 0) < 8;
													tweenConfig3 = tweenConfig5;
												}
												while (flag12);
												TweenConfig tweenConfig6 = new TweenConfig();
												object[] array3 = new object[1];
												bool flag13 = array3 == null;
												num = (nint)typeof(object[]);
												if (!flag13)
												{
													object obj5 = array3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj6 = default(object);
													if (obj6 == null)
													{
														ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
														throw ex2;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig6 != null)
													{
														tweenConfig6.targets = array3;
														ArcadeSprite arcadeSprite = default(ArcadeSprite);
														float2 float5 = arcadeSprite.position;
														tweenConfig6.x = (float?)(object)1;
														tweenConfig6.y = (float?)(object)1;
														tweenConfig6.duration = 3000f;
														TweenCallback onComplete2 = delegate
														{
															//IL_001d: Expected I, but got O
															//IL_0085: Expected I, but got O
															//IL_00ea: Expected O, but got I4
															//IL_00fd: Expected O, but got I4
															//IL_0190: Expected I, but got O
															//IL_01a6: Expected O, but got I
															//IL_01af: Unknown result type (might be due to invalid IL or missing references)
															//IL_01b4: Expected O, but got Unknown
															//IL_022a: Expected I, but got O
															//IL_0310: Expected O, but got I4
															//IL_0327: Expected I, but got I8
															//IL_0206: Expected I, but got I8
															List<ParticleSystem>.Enumerator enumerator3 = default(List<ParticleSystem>.Enumerator);
															if (enumerator3.MoveNext())
															{
																nint num21 = (nint)typeof(RenderingExtensions);
																throw new NullReferenceException();
															}
															TweenConfig tweenConfig7 = new TweenConfig();
															object[] array4 = new object[1];
															if ((object)CS_0024_003C_003E8__locals26._003C_003E4__this != null)
															{
																nint num22 = (nint)array4;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj7 = default(object);
																if (obj7 == null)
																{
																	ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																	throw ex3;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															tweenConfig7.targets = array4;
															float2 float6 = CS_0024_003C_003E8__locals26._003C_003E4__this.position;
															tweenConfig7.x = (float?)(object)1;
															tweenConfig7.y = (float?)(object)1;
															tweenConfig7.duration = 600f;
															tweenConfig7.ease = Ease.InCirc;
															TweenCallback onComplete3 = CS_0024_003C_003E8__locals26._003C_003E9__3;
															if (CS_0024_003C_003E8__locals26._003C_003E9__3 != null)
															{
																goto IL_022f;
															}
															TweenCallback tweenCallback = null;
															nint num23 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r10_v2 (Il2CppMethodInfo)+8]");
															((Delegate)tweenCallback).method_ptr = (IntPtr)0;
															((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass34_0._003CDoDeathAnimation_003Eb__3);
															((Delegate)tweenCallback).m_target = CS_0024_003C_003E8__locals26;
															((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r10_v2 (Il2CppMethodInfo)+4C]");
															object obj8 = (nint)0 >> 4;
															object obj9 = obj8 & 1;
															nint num24;
															if (obj9 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r10_v2 (Il2CppMethodInfo)+52]");
																if ((nint)0 == 0)
																{
																	num24 = unchecked((nint)6447293664L);
																	goto IL_0307;
																}
															}
															num24 = ((Delegate)tweenCallback).method_ptr;
															((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
															goto IL_0307;
															IL_0307:
															object obj10 = 24;
															((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
															CS_0024_003C_003E8__locals26._003C_003E9__3 = tweenCallback;
															onComplete3 = tweenCallback;
															goto IL_022f;
															IL_022f:
															tweenConfig7.onComplete = onComplete3;
															MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig7);
														};
														tweenConfig6.onComplete = onComplete2;
														MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig6);
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
		}
		throw new NullReferenceException();
	}

	private void DropReward()
	{
		//IL_02fc: Expected F4, but got I4
		//IL_0333: Expected I4, but got F4
		//IL_0333: Expected I4, but got F4
		//IL_0333: Expected F4, but got O
		//IL_00ad: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_03b5: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_03dd: Expected O, but got I
		//IL_01f7: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		Vector2 pos = default(Vector2);
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				Treasure treasure = new Treasure();
				List<float> list2 = new List<float>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rdx_v13+18]");
				float item = default(float);
				if (num >= 0)
				{
					list2.AddWithResize(3f);
					item = 3f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj3 = (nint)0 + (nint)1;
					_ = 1077936128;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rdx_v14+18]");
				if (num2 >= 0)
				{
					list2.AddWithResize(10f);
					item = 10f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj5 = (nint)0 + (nint)1;
					_ = 1092616192;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdx_v15+18]");
				if (num3 >= 0)
				{
					list2.AddWithResize(50f);
					item = 50f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v34 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj7 = (nint)0 + (nint)1;
					_ = 1112014848;
				}
				treasure._003Cchances_003Ek__BackingField = list2;
				treasure._003Clevel_003Ek__BackingField = 3;
				List<PrizeType?> list3 = new List<PrizeType?>();
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				((List<float>)(object)list3).Add(item);
				treasure._003CprizeTypes_003Ek__BackingField = list3;
				float2 float5 = base.position;
				TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
				return;
			}
		}
		float? num4 = default(float?);
		float num5 = default(float);
		float num6 = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_PickupRelic, 0f, 10, 0f, num4, num5, num6, loop, 1f);
		float2 float6 = base.position;
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, (float)num4, (ItemType)num5, (byte)(int)num6 != 0);
		if ((object)pickup != null && ((UnityEngine.Object)pickup).m_CachedPtr != (IntPtr)0)
		{
			pickup._003CAutoSafeXY_003Ek__BackingField = true;
		}
	}

	protected override void OnUpdate()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 101 Invalid \"Jump target not found in method: 0x1876A7AC8\"");
	}

	private void Activate()
	{
		//IL_0162: Expected O, but got I4
		//IL_0071: Expected I, but got O
		//IL_00d1: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Loop = true;
		SoundManager.PlayMusic(BgmType.BGM_TP_sotn_FestivalOfServants, soundConfig);
		SoundManager.FadeMusic(0.3f, 1000f);
		ScreenShake(40);
		_phase = LegionBossPhase.Activating;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float2 float5 = base.position;
			tweenConfig.x = (float?)(object)1;
			float2 float6 = base.position;
			tweenConfig.duration = 5000f;
			tweenConfig.y = (float?)(object)1;
			TweenCallback onComplete = ActivationFinish;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween activationTween = Tweens.Add(tweenConfig);
			_activationTween = activationTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void ActivationFinish()
	{
		//IL_0045: Expected O, but got I4
		//IL_004d: Expected O, but got Ref
		GM.Core.SetAllPlayersWeaponsActive(active: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
		List<EnemyLegionSection>.Enumerator enumerator = default(List<EnemyLegionSection>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<EnemyLegionSection>.Enumerator enumerator2 = (List<EnemyLegionSection>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		_activationTween = null;
		_phase = LegionBossPhase.Normal;
		float2 startPosition = base.position;
		_startPosition = startPosition;
		_movementTimer = 0f;
	}

	public void ScreenShake(int repeats = 6)
	{
		//IL_00b3: Expected I, but got O
		//IL_0132: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 80f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.y = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__39_0;
		if (_003C_003Ec._003C_003E9__39_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__39_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.y = -5f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__39_1;
		if (_003C_003Ec._003C_003E9__39_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__39_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}
}
