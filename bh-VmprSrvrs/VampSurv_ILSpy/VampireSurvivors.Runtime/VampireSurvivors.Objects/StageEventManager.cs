using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using I2.Loc;
using IngameDebugConsole;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Scripts.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Stages;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects;

public class StageEventManager : IInitializable, IDisposable
{
	private enum CardinalTypeEnum
	{
		Cardinal,
		SubCardinal,
		All
	}

	public class EventTargetInstace(int eventTargetIndex, Vector2 eventTargetPosition)
	{
		public int _eventTargetIndex = eventTargetIndex;

		public Vector2 _eventTargetPosition = eventTargetPosition;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__100_0;

		public static TweenCallback _003C_003E9__100_1;

		public static Action _003C_003E9__107_1;

		public static Action _003C_003E9__116_0;

		public static Action _003C_003E9__116_1;

		public static Action _003C_003E9__116_2;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnSabotagionFailure_003Eb__100_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -2f;
		}

		internal void _003COnSabotagionFailure_003Eb__100_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}

		internal void _003CFB_BigFuzz_Pointer_003Eb__107_1()
		{
		}

		internal void _003CfnGoldFever_003Eb__116_0()
		{
			GM.Core.TurnOnVacuumForGold();
		}

		internal void _003CfnGoldFever_003Eb__116_1()
		{
			GM.Core.TurnOnVacuumForGold();
		}

		internal void _003CfnGoldFever_003Eb__116_2()
		{
			GM.Core.TurnOnVacuumForGold();
		}
	}

	private sealed class _003C_003Ec__DisplayClass101_0
	{
		public EmitZone emitZone;

		public ParticleEmitterManager particleManager;

		public ParticleSystem pfxEmitter;

		public PhaserSprite crackSprite;

		public PhaserSprite lavaSprite;

		public float2 position;

		public float circleRadius;

		public TweenCallback _003C_003E9__3;

		public Action<float> _003C_003E9__2;

		internal unsafe void _003CSpawnLava_003Eb__0()
		{
			//IL_0008: Expected O, but got Ref
			//IL_06e7: Expected O, but got F4
			//IL_0068: Expected F4, but got I
			//IL_06ff: Expected I4, but got I8
			//IL_0703: Expected O, but got I4
			//IL_070c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0711: Expected O, but got Unknown
			//IL_023c: Expected O, but got Ref
			//IL_0251: Expected native int or pointer, but got O
			//IL_026b: Expected O, but got I
			//IL_028b: Expected O, but got Ref
			//IL_02a5: Expected native int or pointer, but got O
			//IL_02bf: Expected O, but got I
			//IL_02df: Expected O, but got Ref
			//IL_0317: Expected native int or pointer, but got O
			//IL_0331: Expected O, but got I
			//IL_0351: Expected O, but got Ref
			//IL_036b: Expected native int or pointer, but got O
			//IL_0749: Expected O, but got I
			//IL_03a9: Expected O, but got Ref
			//IL_03ca: Expected O, but got I
			//IL_03e4: Expected native int or pointer, but got O
			//IL_0783: Expected O, but got I
			//IL_0422: Expected O, but got Ref
			//IL_0443: Expected O, but got I
			//IL_045d: Expected native int or pointer, but got O
			//IL_07bd: Expected O, but got I
			//IL_054c: Expected O, but got I
			//IL_083b: Expected O, but got I
			//IL_05b1: Expected O, but got I8
			//IL_05eb: Expected O, but got I8
			//IL_06ac: Expected I4, but got F4
			//IL_06ac: Expected O, but got F4
			//IL_06ac: Expected I4, but got O
			//IL_05b6->IL0821: Incompatible stack heights: 2 vs 1
			//IL_05f0->IL08ac: Incompatible stack heights: 2 vs 1
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_003C_003Ec__DisplayClass101_1 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass101_1();
			if (CS_0024_003C_003E8__locals12 != null)
			{
				CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1 = this;
				_ = 0;
				_ = 1065353216;
				_ = 1;
				object obj3 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
				float? num = default(float?);
				float num2 = default(float);
				float num3 = default(float);
				bool flag = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 150f, 3, 0f, num, num2, num3, flag);
				object obj4 = UnityEngine.Random.RandomRangeInt(-50, 50);
				object obj5 = obj4 + 270;
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
				List<string> list = new List<string>();
				list._002Ector();
				if (list != null)
				{
					int version = list._version + 1;
					list._version = version;
					string[] items = list._items;
					if (list._items != null)
					{
						if (list._size >= items.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"HitSmoke1");
						}
						else
						{
							int size = list._size + 1;
							list._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version2 = list._version + 1;
						list._version = version2;
						string[] items2 = list._items;
						if (list._items != null)
						{
							if (list._size >= items2.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"HitSmoke2");
							}
							else
							{
								int size2 = list._size + 1;
								list._size = size2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
								float min = (float)obj5 + 10f;
								float max = (float)obj5 - 10f;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(min, max));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(200f, 300f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
								particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
								_ = 0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
								_ = 5;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
								_ = 0;
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
								_ = 1065353216;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
								particleSystemConfig._frequency = (float?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
								_ = 0;
								particleSystemConfig._emitZone = emitZone;
								particleSystemConfig._on = true;
								ParticleSystem pfxEmitter = particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
								CS_0024_003C_003E8__locals12.pfxEmitter2 = pfxEmitter;
								Transform transform = CS_0024_003C_003E8__locals12.pfxEmitter2.transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1231 @ rax_v71 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1231 @ rax_v71 (UnityEngine.Transform)+10]");
								float value = default(float);
								Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
								GravityWellConfig config = new GravityWellConfig
								{
									_power = 1f,
									_epsilon = 50f,
									_gravity = 100f
								};
								GravityWell gravityWell = particleManager.CreateGravityWell(config);
								Transform transform2 = gravityWell.transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								bool flag3 = (nint)0 != 0;
								Component component = gravityWell;
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									bool flag4 = obj6 == null;
									component = (Component)6573110936L;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2027 @ rax_v81 (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									bool flag5 = obj7 == null;
									component = (Component)6573110936L;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2051 @ rax_v84 (should have been resolved before IL gen)");
								bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								float value2 = default(float);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
								RenderingExtensions.Start(CS_0024_003C_003E8__locals12.pfxEmitter2);
								Action onComplete = delegate
								{
									//IL_007e: Expected I, but got O
									//IL_00e8: Expected I, but got O
									//IL_013e: Expected O, but got I4
									_003C_003Ec__DisplayClass101_0 obj8 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
									RenderingExtensions.StopEmitting(obj8.pfxEmitter);
									RenderingExtensions.StopEmitting(CS_0024_003C_003E8__locals12.pfxEmitter2);
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[2];
									_003C_003Ec__DisplayClass101_0 obj9 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
									if ((object)obj9.crackSprite != null)
									{
										nint num4 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj10 = default(object);
										if (obj10 == null)
										{
											ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
											throw ex;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									_003C_003Ec__DisplayClass101_0 obj11 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
									if ((object)obj11.lavaSprite != null)
									{
										nint num5 = (nint)array;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj12 = default(object);
										if (obj12 == null)
										{
											ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
											throw ex2;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									tweenConfig.targets = array;
									tweenConfig.alpha = (float?)(object)1;
									tweenConfig.duration = 300f;
									_003C_003Ec__DisplayClass101_0 obj13 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1;
									TweenCallback onComplete2 = obj13._003C_003E9__3;
									if (obj13._003C_003E9__3 == null)
									{
										TweenCallback tweenCallback = delegate
										{
											GameObject gameObject = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1.crackSprite.gameObject;
											UnityEngine.Object.Destroy(gameObject, 0f);
											GameObject gameObject2 = CS_0024_003C_003E8__locals12.CS_0024_003C_003E8__locals1.lavaSprite.gameObject;
											UnityEngine.Object.Destroy(gameObject2, 0f);
										};
										onComplete2 = tweenCallback;
									}
									tweenConfig.onComplete = onComplete2;
									MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								};
								Action<float> onUpdate = _003C_003E9__2;
								if (_003C_003E9__2 == null)
								{
									Action<float> action = null;
									float time = default(float);
									((_003C_003Ec__DisplayClass101_0)(object)action)._003CSpawnLava_003Eb__2(time);
									_003C_003E9__2 = action;
									onUpdate = action;
								}
								Timer timer = Timers.Register(2f, onComplete, onUpdate, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CSpawnLava_003Eb__3()
		{
			GameObject gameObject = crackSprite.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
			GameObject gameObject2 = lavaSprite.gameObject;
			UnityEngine.Object.Destroy(gameObject2, 0f);
		}

		internal unsafe void _003CSpawnLava_003Eb__2(float time)
		{
			//IL_0013: Expected F4, but got I4
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected O, but got Unknown
			//IL_0197: Expected O, but got F4
			//IL_019f: Invalid comparison between O and F4
			//IL_00bb: Expected I, but got O
			//IL_01b1->IL01b6: Incompatible stack heights: 2 vs 0
			//IL_00d3->IL01b6: Incompatible stack heights: 2 vs 0
			GameManager core = GM.Core;
			float num = 0f;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			object obj2 = default(object);
			while (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
				bool flag = (object)cachedTrans == null;
				bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				object obj;
				float2 float5;
				if (arcadeSprite.body != null)
				{
					BaseBody body = arcadeSprite.body;
					ArcadeTransform transform = body._transform;
					transform.position = ret;
					obj = obj2;
					float5 = ret;
				}
				else
				{
					obj = obj2;
					float5 = ret;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass101_0)+3C]");
				object obj3 = 0 - obj;
				object obj4 = position - float5;
				object obj5 = obj3 * obj3;
				object obj6 = obj4 * obj4;
				num = (float)obj6 + (float)obj5;
				characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(circleRadius * circleRadius);
				if (System.Runtime.CompilerServices.Unsafe.As<List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator, UIntPtr>(ref characters) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
				{
					nint num2 = (nint)arcadeSprite;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v570 @ r8_v4 (Il2CppClass<ArcadeSprite>)+5F8] (should have been resolved before IL gen)");
					num = 10f;
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass101_1
	{
		public ParticleSystem pfxEmitter2;

		public _003C_003Ec__DisplayClass101_0 CS_0024_003C_003E8__locals1;

		internal void _003CSpawnLava_003Eb__1()
		{
			//IL_007e: Expected I, but got O
			//IL_00e8: Expected I, but got O
			//IL_013e: Expected O, but got I4
			_003C_003Ec__DisplayClass101_0 obj = CS_0024_003C_003E8__locals1;
			RenderingExtensions.StopEmitting(obj.pfxEmitter);
			RenderingExtensions.StopEmitting(pfxEmitter2);
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[2];
			_003C_003Ec__DisplayClass101_0 obj2 = CS_0024_003C_003E8__locals1;
			if ((object)obj2.crackSprite != null)
			{
				nint num = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			_003C_003Ec__DisplayClass101_0 obj4 = CS_0024_003C_003E8__locals1;
			if ((object)obj4.lavaSprite != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = 300f;
			_003C_003Ec__DisplayClass101_0 obj6 = CS_0024_003C_003E8__locals1;
			TweenCallback onComplete = obj6._003C_003E9__3;
			if (obj6._003C_003E9__3 == null)
			{
				TweenCallback tweenCallback = delegate
				{
					GameObject gameObject = CS_0024_003C_003E8__locals1.crackSprite.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
					GameObject gameObject2 = CS_0024_003C_003E8__locals1.lavaSprite.gameObject;
					UnityEngine.Object.Destroy(gameObject2, 0f);
				};
				onComplete = tweenCallback;
			}
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
	}

	private sealed class _003C_003Ec__DisplayClass102_0
	{
		public StageEventManager _003C_003E4__this;

		public EnemyType enemyType;

		public int eventID;

		public Action _003C_003E9__0;

		internal void _003COnSabotage_PickleRushFailure_003Eb__0()
		{
			//IL_0020: Expected I4, but got I8
			_003C_003E4__this.SpawnCircleWave(enemyType, eventID, -1);
		}
	}

	private sealed class _003C_003Ec__DisplayClass106_0
	{
		public StageEventManager _003C_003E4__this;

		public EnemyType enemyType;

		public int eventID;

		public Action _003C_003E9__0;

		internal void _003COnSabotagionEMEFailure_003Eb__0()
		{
			//IL_0020: Expected I4, but got I8
			_003C_003E4__this.SpawnCircleWave(enemyType, eventID, -1);
		}
	}

	private sealed class _003C_003Ec__DisplayClass109_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int spawnCount;

		internal void _003CSpawnCircleWave_003Eb__0()
		{
			//IL_0013: Expected O, but got I4
			//IL_0085: Expected O, but got I
			bool flag = enemies == null;
			_003C_003Ec__DisplayClass109_0 obj = this;
			if (!flag)
			{
				List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj2 = 0;
				}
				obj = (_003C_003Ec__DisplayClass109_0)(object)_003C_003E4__this;
				if (_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v2 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass109_0)+8C]");
					object obj3 = -spawnCount;
					return;
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass122_0
	{
		public SpawnType saveSpawnType;

		internal void _003CfnUltraWave_003Eb__0()
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._spawnType = saveSpawnType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass123_0
	{
		public SpawnType saveSpawnType;

		internal void _003CfnSummonMolise_003Eb__0()
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._spawnType = saveSpawnType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass124_0
	{
		public SpawnType saveSpawnType;

		internal void _003CfnSummonNight_003Eb__0()
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._spawnType = saveSpawnType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass125_0
	{
		public SpawnType saveSpawnType;

		internal void _003CfnMinuteOfPanic_003Eb__0()
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._spawnType = saveSpawnType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass128_0
	{
		public SpawnType saveSpawnType;

		internal void _003CfnCrabFest_003Eb__0()
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			stage._spawnType = saveSpawnType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass130_0
	{
		public int sameType;

		public List<EnemyType> list;

		public StageEventManager _003C_003E4__this;
	}

	private sealed class _003C_003Ec__DisplayClass130_1
	{
		public int localI;

		public _003C_003Ec__DisplayClass130_0 CS_0024_003C_003E8__locals1;

		internal void _003CfnInvaders_003Eb__0()
		{
			//IL_0077: Expected O, but got I
			_003C_003Ec__DisplayClass130_0 obj = CS_0024_003C_003E8__locals1;
			List<EnemyType> list = obj.list;
			int num = localI / obj.sameType;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			int num2 = (int)((nint)num % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			if ((nint)num2 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ r8_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
				object obj2 = 0;
				_003C_003Ec__DisplayClass130_0 obj3 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager = obj3._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass40_0
	{
		public StageEventManager _003C_003E4__this;

		public VampireSurvivors.Data.Stage.Event stageDataEvent;

		public StageEventType stageEventType;

		public bool fromTrisection;

		internal void _003CTriggerEvent_003Eb__0()
		{
			StageEventManager stageEventManager = _003C_003E4__this;
			VampireSurvivors.Data.Stage.Event obj = stageDataEvent;
			if (!stageEventManager._stageEventsDisabled)
			{
				string message = "EventTriggered: " + obj._003CeventType_003Ek__BackingField;
				Debug.Log(message);
				VampireSurvivors.Data.Stage.Event obj2 = stageDataEvent;
				int moreX = default(int);
				object moreY = default(object);
				float moreZ = default(float);
				bool flag2 = default(bool);
				bool flag = _003C_003E4__this.TriggerSwitchEvent(stageEventType, obj2._003Cchance_003Ek__BackingField, obj2._003Cduration_003Ek__BackingField, moreX, moreY, moreZ, flag2);
			}
			else
			{
				string message2 = "Not triggering queued event " + obj._003CeventType_003Ek__BackingField + " because stage events are disabled";
				Debug.Log(message2);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass51_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CGenerateEnemySwarm_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass52_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CGenerateEnemyWall_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass60_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlayMedusaSwarm_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass61_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlayVerticalSwarm_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass62_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlayMedusaWall_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass64_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlayPileAssault_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass71_0
	{
		public int times;

		public StageEventManager _003C_003E4__this;

		public float fixedY;

		public float moreZ;

		public EnemyType moreY;

		public int eventId;

		public List<EnemyController> enemies;

		public Action _003C_003E9__1;

		internal void _003CPlayDragonStream_003Eb__1()
		{
			//IL_013d: Expected O, but got I4
			//IL_0170: Invalid comparison between F4 and I4
			//IL_0013: Expected O, but got I4
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00fe: Invalid comparison between F4 and O
			int num = times & 1;
			bool flag = num == 0;
			object obj = !flag;
			if (obj == null)
			{
			}
			int num2 = times + 1;
			times = num2;
			if (!(moreZ > 0f))
			{
				return;
			}
			object obj2 = 0;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			float num5;
			do
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				GameObject gameObject = stageEventManager._ourStage.SpawnEnemy(moreY, spawnPos, asRemote: false, forceSpawn);
				EnemyController component = gameObject.GetComponent<EnemyController>();
				InitEventEnemy(eventId, component, enemies);
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					float num3 = component._003CSpeed_003Ek__BackingField * 1.5f;
					component._003CSpeed_003Ek__BackingField = num3;
				}
				StageEventManager stageEventManager2 = _003C_003E4__this;
				obj2++;
				int num4 = stageEventManager2._003CSpawned_003Ek__BackingField + 1;
				stageEventManager2._003CSpawned_003Ek__BackingField = num4;
				num5 = moreZ;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
		}

		internal void _003CPlayDragonStream_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass72_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlaySkeleStream_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass73_0
	{
		public StageEventManager _003C_003E4__this;

		public float fixedY;

		public float yStep;

		public EnemyType moreY;

		public int eventId;

		public List<EnemyController> enemies;

		internal void _003CPlaySkullPilePile_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass73_1
	{
		public int counter;

		public _003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals1;
	}

	private sealed class _003C_003Ec__DisplayClass73_2
	{
		public int index;

		public _003C_003Ec__DisplayClass73_1 CS_0024_003C_003E8__locals2;

		internal void _003CPlaySkullPilePile_003Eb__1()
		{
			//IL_0032: Expected O, but got I4
			_003C_003Ec__DisplayClass73_1 obj = CS_0024_003C_003E8__locals2;
			int num = obj.counter & 1;
			bool flag = num == 0;
			object obj2 = !flag;
			if (obj2 == null)
			{
			}
			_003C_003Ec__DisplayClass73_1 obj3 = CS_0024_003C_003E8__locals2;
			_003C_003Ec__DisplayClass73_0 obj4 = obj3.CS_0024_003C_003E8__locals1;
			StageEventManager stageEventManager = obj4._003C_003E4__this;
			_003C_003Ec__DisplayClass73_0 obj5 = obj3.CS_0024_003C_003E8__locals1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			_003C_003Ec__DisplayClass73_1 obj6 = CS_0024_003C_003E8__locals2;
			_003C_003Ec__DisplayClass73_0 obj7 = obj6.CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass73_1 obj8 = CS_0024_003C_003E8__locals2;
			_003C_003Ec__DisplayClass73_0 obj9 = obj8.CS_0024_003C_003E8__locals1;
			EnemyController enemyController = default(EnemyController);
			InitEventEnemy(obj7.eventId, enemyController, obj9.enemies);
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				enemyController._003CSpeed_003Ek__BackingField = 0f;
			}
			_003C_003Ec__DisplayClass73_1 obj10 = CS_0024_003C_003E8__locals2;
			_003C_003Ec__DisplayClass73_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
			StageEventManager stageEventManager2 = obj11._003C_003E4__this;
			int num2 = stageEventManager2._003CSpawned_003Ek__BackingField + 1;
			stageEventManager2._003CSpawned_003Ek__BackingField = num2;
			_003C_003Ec__DisplayClass73_1 obj12 = CS_0024_003C_003E8__locals2;
			int counter = obj12.counter + 1;
			obj12.counter = counter;
		}
	}

	private sealed class _003C_003Ec__DisplayClass74_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlayPolterRoulette_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass77_0
	{
		public List<EnemyController> enemies;

		public StageEventManager _003C_003E4__this;

		public int eventId;

		internal void _003CPlayShadeBomb_003Eb__0()
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				StageEventManager stageEventManager = _003C_003E4__this;
				int num = stageEventManager._003CSpawned_003Ek__BackingField - 1;
				stageEventManager._003CSpawned_003Ek__BackingField = num;
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass80_0
	{
		public EnemyController enemy;

		public int eventId;

		internal void _003CSummonTimedEnemy_003Eb__0()
		{
			EnemyController enemyController = enemy;
			if ((object)enemy != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemyController2 = enemy;
				if (!enemyController2._003CIsDead_003Ek__BackingField && enemyController2._003CStageEventId_003Ek__BackingField == eventId)
				{
					enemyController2._003CIsCullable_003Ek__BackingField = true;
					enemy.Disappear();
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass81_0
	{
		public EnemyController enemy;

		public int eventId;

		internal void _003CPlayStalker_003Eb__0()
		{
			EnemyController enemyController = enemy;
			if ((object)enemy != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemyController2 = enemy;
				if (!enemyController2._003CIsDead_003Ek__BackingField && enemyController2._003CStageEventId_003Ek__BackingField == eventId)
				{
					enemyController2._003CIsCullable_003Ek__BackingField = true;
					enemy.Disappear();
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass82_0
	{
		public EnemyController enemy;

		public int eventId;

		internal void _003CPlaySleeper_003Eb__0()
		{
			EnemyController enemyController = enemy;
			if ((object)enemy != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemyController2 = enemy;
				if (!enemyController2._003CIsDead_003Ek__BackingField && enemyController2._003CStageEventId_003Ek__BackingField == eventId)
				{
					enemyController2._003CIsCullable_003Ek__BackingField = true;
					enemy.Disappear();
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass83_0
	{
		public EnemyController enemy;

		public int eventId;

		internal void _003CPlayDrowner_003Eb__0()
		{
			//IL_00d5: Expected I, but got O
			//IL_00dd: Expected I, but got O
			//IL_00ed: Expected O, but got I
			//IL_016d: Expected O, but got I4
			//IL_0129: Expected O, but got I
			//IL_015f: Expected O, but got I4
			EnemyController enemyController = enemy;
			if ((object)enemy == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			EnemyController enemyController2 = enemy;
			if (enemyController2._003CIsDead_003Ek__BackingField || enemyController2._003CStageEventId_003Ek__BackingField != eventId)
			{
				return;
			}
			enemyController2._003CIsCullable_003Ek__BackingField = true;
			EnemyController enemyController3 = enemy;
			if ((object)enemy == null)
			{
				goto IL_018c;
			}
			nint num = (nint)typeof(EnemyDrowner);
			nint num2 = (nint)enemyController3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
			object obj3;
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v21+FFFFFFF8+v250 @ rax_v15*8]");
				if (0 == (nint)typeof(EnemyDrowner))
				{
					obj3 = 1;
					goto IL_01d0;
				}
			}
			obj3 = 0;
			goto IL_01d0;
			IL_018c:
			enemy.Disappear();
			return;
			IL_01d0:
			bool flag = obj3 == null;
			EnemyController enemyController4 = null;
			if (!flag)
			{
				enemyController4 = enemy;
			}
			if ((object)enemyController4 != null)
			{
				_ = 1;
			}
			goto IL_018c;
		}
	}

	private sealed class _003C_003Ec__DisplayClass84_0
	{
		public StageEventManager _003C_003E4__this;

		public float lerp;

		public Color color1;

		public Color color2;

		public Action _003C_003E9__0;

		internal unsafe void _003CPlayEraseEnemies_003Eb__0()
		{
			//IL_008f: Invalid comparison between I4 and F4
			//IL_00da: Expected F4, but got I4
			float num = lerp + 0.05f;
			StageEventManager stageEventManager = _003C_003E4__this;
			if (num > 1f)
			{
				num = 1f;
			}
			lerp = num;
			if (_003C_003E4__this != null)
			{
				Stage ourStage = stageEventManager._ourStage;
				if ((object)stageEventManager._ourStage != null)
				{
					TilingBackground tilingBackground = ourStage._tilingBackground;
					if (!(0f > num))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					if ((object)ourStage._tilingBackground != null)
					{
						TileSprite bgtile = tilingBackground._bgtile;
						object spriteRenderer = bgtile._spriteRenderer;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v7 (System.Object)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v7 (System.Object)+10]");
						float value = default(float);
						SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public int moreX;

		public int index;

		public StageEventManager _003C_003E4__this;

		public EnemyType moreY;

		public int eventId;

		public List<EnemyController> enemies;

		public Action _003C_003E9__1;

		internal void _003CSpawnInSteps_003Eb__1()
		{
			//IL_034a->IL02af: Incompatible stack heights: 1 vs 0
			//IL_0371->IL02af: Incompatible stack heights: 1 vs 0
			//IL_00ff->IL02af: Incompatible stack heights: 1 vs 0
			//IL_0126->IL02af: Incompatible stack heights: 1 vs 0
			//IL_0155->IL02af: Incompatible stack heights: 1 vs 0
			//IL_0177->IL02af: Incompatible stack heights: 1 vs 0
			//IL_01a6->IL02af: Incompatible stack heights: 1 vs 0
			//IL_03bf->IL02af: Incompatible stack heights: 2 vs 0
			//IL_03e6->IL02af: Incompatible stack heights: 2 vs 0
			//IL_01d7->IL02af: Incompatible stack heights: 2 vs 0
			//IL_0200->IL02af: Incompatible stack heights: 2 vs 0
			//IL_0222->IL02af: Incompatible stack heights: 2 vs 0
			//IL_026f->IL02af: Incompatible stack heights: 2 vs 0
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
				{
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData = core._gameSessionData;
						if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
						{
							Transform transform = gameSessionData._activeCharacter.transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v21 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v21 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out Vector3 _);
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
									{
										GameManager core2 = GM.Core;
										if ((object)GM.Core != null)
										{
											GameSessionData gameSessionData2 = core2._gameSessionData;
											if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
											{
												Transform transform2 = gameSessionData2._activeCharacter.transform;
												if ((object)transform2 != null)
												{
													bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
													if ((object)GM.Core != null)
													{
														PhaserScene s_scene3 = ArcadePhysics.s_scene;
														if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
														{
															StageEventManager stageEventManager = _003C_003E4__this;
															if (_003C_003E4__this != null && (object)stageEventManager._ourStage != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
																EnemyController enemy = default(EnemyController);
																InitEventEnemy(eventId, enemy, enemies);
																StageEventManager stageEventManager2 = _003C_003E4__this;
																if (_003C_003E4__this != null)
																{
																	int num = stageEventManager2._003CSpawned_003Ek__BackingField + 1;
																	stageEventManager2._003CSpawned_003Ek__BackingField = num;
																	int num2 = index + 1;
																	index = num2;
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
			throw new NullReferenceException();
		}

		internal void _003CSpawnInSteps_003Eb__0()
		{
			//IL_0059: Expected O, but got I4
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Expected O, but got Unknown
			//IL_0213: Expected O, but got I4
			//IL_0145: Expected O, but got I4
			StageEventManager stageEventManager = _003C_003E4__this;
			int num = stageEventManager._003CSpawned_003Ek__BackingField - moreX;
			stageEventManager._003CSpawned_003Ek__BackingField = num;
			List<EnemyController> list = enemies;
			bool flag = (nint)enemies < 0;
			object obj = list._size - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				List<EnemyController> list2 = enemies;
				if ((nint)obj >= list2._size)
				{
					break;
				}
				EnemyController[] items = list2._items;
				EnemyController enemyController = items[obj];
				bool flag2 = (nint)items[obj] < 0;
				if ((object)items[obj] != null)
				{
					flag2 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
					if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						flag2 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
						if (!enemyController._003CIsDead_003Ek__BackingField)
						{
							object obj2 = enemyController._003CStageEventId_003Ek__BackingField - eventId;
							flag2 = (nint)obj2 < 0;
							if (enemyController._003CStageEventId_003Ek__BackingField == eventId)
							{
								enemyController._003CIsCullable_003Ek__BackingField = true;
								items[obj].Disappear();
							}
						}
					}
				}
				obj--;
				object obj3 = !flag2;
				if (obj3 == null)
				{
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass87_0
	{
		public StageEventManager _003C_003E4__this;

		public EnemyType? moreY;
	}

	private sealed class _003C_003Ec__DisplayClass87_1
	{
		public float half;

		public float length;

		public _003C_003Ec__DisplayClass87_0 CS_0024_003C_003E8__locals1;

		internal void _003CPlayDiamondSquare_003Eb__0()
		{
			//IL_0066: Invalid comparison between F4 and I4
			//IL_0078: Expected O, but got I4
			//IL_011c: Invalid comparison between F4 and I4
			//IL_01f9: Expected O, but got I4
			//IL_013c: Expected O, but got I4
			//IL_02dd: Expected O, but got I4
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00fd: Invalid comparison between F4 and O
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Expected O, but got Unknown
			//IL_028e: Invalid comparison between F4 and O
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Expected O, but got Unknown
			//IL_01b8: Invalid comparison between F4 and O
			//IL_034a: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Expected O, but got Unknown
			//IL_0369: Invalid comparison between F4 and O
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position = gameSessionData._activeCharacter.position;
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			float2 position2 = gameSessionData2._activeCharacter.position;
			bool flag = !(length > 0f);
			object obj = 0;
			if (flag)
			{
				goto IL_0111;
			}
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			while (true)
			{
				_003C_003Ec__DisplayClass87_0 obj2 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager = obj2._003C_003E4__this;
				if ((object)obj2.moreY == null)
				{
					break;
				}
				Stage ourStage = stageEventManager._ourStage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v15 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass87_0)+1C]");
				GameObject gameObject = ourStage.SpawnEnemy(EnemyType.BAT1, spawnPos, asRemote: false, forceSpawn);
				obj++;
				float num = length;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					continue;
				}
				goto IL_0111;
			}
			goto IL_038c;
			IL_01cc:
			float num2 = length - 1f;
			bool flag2 = !(num2 > 1f);
			object obj3 = 1;
			if (flag2)
			{
				goto IL_02a2;
			}
			while (true)
			{
				_003C_003Ec__DisplayClass87_0 obj4 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager2 = obj4._003C_003E4__this;
				if ((object)obj4.moreY == null)
				{
					break;
				}
				Stage ourStage2 = stageEventManager2._ourStage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v20 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass87_0)+1C]");
				GameObject gameObject2 = ourStage2.SpawnEnemy(EnemyType.BAT1, spawnPos, asRemote: false, forceSpawn);
				obj3++;
				float num3 = length - 1f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					continue;
				}
				goto IL_02a2;
			}
			goto IL_038c;
			IL_038c:
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			return;
			IL_0111:
			if (!(length > 0f))
			{
				goto IL_01cc;
			}
			object obj5 = 0;
			while (true)
			{
				_003C_003Ec__DisplayClass87_0 obj6 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager3 = obj6._003C_003E4__this;
				if ((object)obj6.moreY == null)
				{
					break;
				}
				Stage ourStage3 = stageEventManager3._ourStage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v28 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass87_0)+1C]");
				GameObject gameObject3 = ourStage3.SpawnEnemy(EnemyType.BAT1, spawnPos, asRemote: false, forceSpawn);
				obj5++;
				float num4 = length;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
				{
					continue;
				}
				goto IL_01cc;
			}
			goto IL_038c;
			IL_02a2:
			float num5 = length - 1f;
			if (!(num5 > 1f))
			{
				return;
			}
			object obj7 = 1;
			while (true)
			{
				_003C_003Ec__DisplayClass87_0 obj8 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager4 = obj8._003C_003E4__this;
				if ((object)obj8.moreY == null)
				{
					break;
				}
				Stage ourStage4 = stageEventManager4._ourStage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v25 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass87_0)+1C]");
				GameObject gameObject4 = ourStage4.SpawnEnemy(EnemyType.BAT1, spawnPos, asRemote: false, forceSpawn);
				obj7++;
				float num6 = length - 1f;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
				{
					return;
				}
			}
			goto IL_038c;
		}
	}

	private sealed class _003C_003Ec__DisplayClass88_0
	{
		public StageEventManager _003C_003E4__this;

		public EnemyType? moreY;
	}

	private sealed class _003C_003Ec__DisplayClass88_1
	{
		public int width;

		public _003C_003Ec__DisplayClass88_0 CS_0024_003C_003E8__locals1;

		internal void _003CPlayDiamondRoad_003Eb__0()
		{
			//IL_0096: Expected O, but got I4
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected O, but got Unknown
			//IL_0193: Invalid comparison between F4 and O
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position = gameSessionData._activeCharacter.position;
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			float2 position2 = gameSessionData2._activeCharacter.position;
			GameManager core3 = GM.Core;
			GameSessionData gameSessionData3 = core3._gameSessionData;
			float2 position3 = gameSessionData3._activeCharacter.position;
			object obj = 1;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			while (true)
			{
				_003C_003Ec__DisplayClass88_0 obj2 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager = obj2._003C_003E4__this;
				_003C_003Ec__DisplayClass88_0 obj3 = CS_0024_003C_003E8__locals1;
				if ((object)obj3.moreY == null)
				{
					break;
				}
				Stage ourStage = stageEventManager._ourStage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rdx_v4 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass88_0)+1C]");
				GameObject gameObject = ourStage.SpawnEnemy(EnemyType.BAT1, spawnPos, asRemote: false, forceSpawn);
				_003C_003Ec__DisplayClass88_0 obj4 = CS_0024_003C_003E8__locals1;
				StageEventManager stageEventManager2 = obj4._003C_003E4__this;
				_003C_003Ec__DisplayClass88_0 obj5 = CS_0024_003C_003E8__locals1;
				if ((object)obj5.moreY == null)
				{
					break;
				}
				Stage ourStage2 = stageEventManager2._ourStage;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdx_v6 (VampireSurvivors.Objects.StageEventManager+<>c__DisplayClass88_0)+1C]");
				GameObject gameObject2 = ourStage2.SpawnEnemy(EnemyType.BAT1, spawnPos, asRemote: false, forceSpawn);
				obj++;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)48f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
				{
					return;
				}
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	private sealed class _003C_FB_BigFuzz_Pointer_003Ed__108(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public object moreY;

		public StageEventManager _003C_003E4__this;

		public Action<Vector2> onSuccess;

		public Action onFailure;

		private float _003CdurationLeft_003E5__2;

		private int _003ClastSecond_003E5__3;

		private PhaserText _003Ctext_003E5__4;

		private NewsFeed _003CnewsFeed_003E5__5;

		private Vector2 _003CtargetLocation_003E5__6;

		private EventTargetInstace _003CeventInstance_003E5__7;

		private PizzaCircle _003CtargetPizza_003E5__8;

		private CursorData _003CcursorData_003E5__9;

		private VampireSurvivors.Objects.Characters.CharacterController _003CplayerInPizza_003E5__10;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_002f: Expected I4, but got I8
			//IL_0057: Expected I4, but got F4
			//IL_0900: Expected I4, but got I8
			//IL_0909: Expected F4, but got I4
			//IL_0946: Expected O, but got I
			//IL_0993: Expected O, but got I
			//IL_0128: Expected O, but got Ref
			//IL_0e1a: Expected O, but got I
			//IL_01a7: Expected O, but got I4
			//IL_01c2: Expected O, but got I8
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e0: Expected I4, but got Unknown
			//IL_024e: Expected O, but got I4
			//IL_0477: Expected O, but got I
			//IL_12a5: Expected O, but got I4
			//IL_1492: Invalid comparison between F4 and I4
			//IL_0be7: Expected I4, but got F4
			//IL_04d7: Expected O, but got I
			//IL_16f4: Expected I4, but got F4
			//IL_0f56: Expected O, but got I
			//IL_0530: Expected O, but got I
			//IL_1587: Expected O, but got I
			//IL_0c9b: Expected O, but got I
			//IL_058f: Expected O, but got I
			//IL_05c4: Expected O, but got I
			//IL_16c7: Expected O, but got I4
			//IL_0f90: Expected O, but got I
			//IL_1000: Expected O, but got I
			//IL_065a: Expected O, but got Ref
			//IL_065a: Expected O, but got Ref
			//IL_0443: Expected O, but got I4
			//IL_0707: Expected O, but got F4
			//IL_10e6: Expected O, but got Ref
			//IL_1168: Expected O, but got I4
			//IL_083c: Expected F4, but got I4
			//IL_0859: Unknown result type (might be due to invalid IL or missing references)
			//IL_085e: Expected O, but got Unknown
			//IL_0875: Unknown result type (might be due to invalid IL or missing references)
			//IL_087a: Expected O, but got Unknown
			//IL_0891: Unknown result type (might be due to invalid IL or missing references)
			//IL_0896: Expected I4, but got Unknown
			//IL_176c: Expected O, but got I4
			//IL_177c: Unknown result type (might be due to invalid IL or missing references)
			//IL_1781: Expected O, but got Unknown
			//IL_08c1: Expected F4, but got I4
			//IL_1400->IL11e0: Incompatible stack heights: 1 vs 0
			//IL_0af7->IL11e0: Incompatible stack heights: 1 vs 0
			//IL_0b19->IL11e0: Incompatible stack heights: 1 vs 0
			//IL_0b48->IL11e0: Incompatible stack heights: 1 vs 0
			//IL_0c09->IL11e0: Incompatible stack heights: 3 vs 0
			//IL_0c2b->IL11e0: Incompatible stack heights: 3 vs 0
			//IL_0bc0->IL11e0: Incompatible stack heights: 3 vs 0
			//IL_0ced->IL14db: Incompatible stack heights: 3 vs 0
			//IL_0cb3->IL14a9: Incompatible stack heights: 5 vs 3
			//IL_0ccf->IL14cf: Incompatible stack heights: 5 vs 3
			//IL_1633->IL11e0: Incompatible stack heights: 1 vs 0
			//IL_1686->IL11e0: Incompatible stack heights: 2 vs 0
			//IL_10a4->IL11e0: Incompatible stack heights: 2 vs 0
			//IL_113b->IL11e0: Incompatible stack heights: 4 vs 0
			//IL_116d->IL168b: Incompatible stack heights: 4 vs 0
			object obj = _003C_003E4__this;
			Vector2 vector = default(Vector2);
			Quaternion quaternion2 = default(Quaternion);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003CdurationLeft_003E5__2 = duration;
				float num = duration / 1000f;
				_003ClastSecond_003E5__3 = (int)num;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null && (object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
						{
							PhaserScene s_scene3 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
							{
								float num2 = default(float);
								PhaserText component = RenderingExtensions.text(s_scene.add, vector, "", (Color)(&quaternion2), num2);
								PhaserText phaserText = RenderingExtensions.SetScrollFactor(component, 0f);
								if ((object)phaserText != null)
								{
									PhaserText phaserText2 = phaserText.SetDepth(31758);
									if ((object)phaserText2 != null)
									{
										PhaserText phaserText3 = phaserText2.setOrigin(0.5f, (float?)(object)1);
										_003Ctext_003E5__4 = phaserText3;
										object obj2 = 6603577472L;
										CultureInfo invariantCulture = CultureInfo.InvariantCulture;
										int num3 = this + 76;
										string text = ((int*)num3)->ToString(invariantCulture);
										if ((object)_003Ctext_003E5__4 != null)
										{
											PhaserText phaserText4 = _003Ctext_003E5__4.SetText(text);
											_003CnewsFeed_003E5__5 = null;
											bool flag = moreY == null;
											object obj3 = 0;
											if (!flag)
											{
												object obj4 = moreY;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
												bool flag2 = obj4 != null;
												object obj5 = null;
												if (!flag2)
												{
													obj5 = obj4;
												}
												bool flag3 = obj5 == null;
												obj3 = 0;
												if (!flag3)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
													bool flag4 = obj4 != null;
													string term = null;
													if (!flag4)
													{
														term = (string)obj4;
													}
													GameObject localParametersRoot = default(GameObject);
													string overrideLanguage = default(string);
													bool allowLocalizedParameters = default(bool);
													string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num2 != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
													GameObject gameObject = new GameObject();
													if ((object)gameObject != null)
													{
														NewsFeed newsFeed = gameObject.AddComponent<NewsFeed>();
														_003CnewsFeed_003E5__5 = newsFeed;
														NewsFeed newsFeed2 = _003CnewsFeed_003E5__5;
														if ((object)_003CnewsFeed_003E5__5 != null && (object)newsFeed2._text != null)
														{
															PhaserText phaserText5 = newsFeed2._text.SetText(translation);
															NewsFeed newsFeed3 = _003CnewsFeed_003E5__5;
															if ((object)_003CnewsFeed_003E5__5 != null && (object)newsFeed3._bannerTileSprite != null)
															{
																newsFeed3._bannerTileSprite.SetFrame("NewsfeedWarningFB", "firstBlood");
																NewsFeed newsFeed4 = _003CnewsFeed_003E5__5;
																if ((object)_003CnewsFeed_003E5__5 != null && (object)newsFeed4._text != null)
																{
																	PhaserText phaserText6 = newsFeed4._text.SetTint(9366996u);
																	if ((object)_003CnewsFeed_003E5__5 != null)
																	{
																		_003CnewsFeed_003E5__5.Show();
																		obj3 = 0;
																		goto IL_0448;
																	}
																}
															}
														}
													}
													goto IL_11e0;
												}
											}
											goto IL_0448;
										}
									}
								}
							}
						}
					}
				}
				goto IL_11e0;
			}
			float num4;
			float num5;
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				num4 = 0f;
				num5 = 1000f;
				goto IL_1321;
			}
			goto IL_1379;
			IL_1321:
			float num6 = _003CdurationLeft_003E5__2;
			if (_003C_003E4__this != null)
			{
				goto IL_0917;
			}
			goto IL_11e0;
			IL_168b:
			Action<Vector2> action = onSuccess;
			if (onSuccess == null)
			{
				goto IL_11e0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1254 @ rax_v78 (System.Action`1<UnityEngine.Vector2>)+18] (should have been resolved before IL gen)");
			goto IL_1379;
			IL_12e5:
			throw new IndexOutOfRangeException();
			IL_0917:
			Vector2 ret2 = default(Vector2);
			Action action2;
			Action action3;
			object obj11;
			if (num6 > num4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+98]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+98]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rcx_v105+10]");
					nint num7 = 0;
					EventTargetInstace value = _003CeventInstance_003E5__7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v483 @ rcx_v105+18]");
					int num8 = Array.IndexOf((object[])num7, value, 0, 0);
					bool visible = num8 == 0;
					PhaserText phaserText7 = (PhaserText)(object)_003CnewsFeed_003E5__5;
					if ((object)_003CnewsFeed_003E5__5 != null && ((UnityEngine.Object)phaserText7).m_CachedPtr != (IntPtr)0)
					{
						if ((object)_003CnewsFeed_003E5__5 == null)
						{
							goto IL_11e0;
						}
						_003CnewsFeed_003E5__5.SetVisible(visible);
					}
					if ((object)_003Ctext_003E5__4 != null)
					{
						Transform transform = _003Ctext_003E5__4.transform;
						CursorData cursorData = _003CcursorData_003E5__9;
						if (_003CcursorData_003E5__9 != null && (object)cursorData._CursorInstanceReference != null)
						{
							Transform transform2 = cursorData._CursorInstanceReference.transform;
							if ((object)transform2 != null)
							{
								bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
								CursorData cursorData2 = _003CcursorData_003E5__9;
								if (_003CcursorData_003E5__9 != null)
								{
									CursorIndicator cursorInstanceReference = cursorData2._CursorInstanceReference;
									if ((object)cursorData2._CursorInstanceReference != null && (object)cursorInstanceReference._CursorRenderer != null)
									{
										Transform transform3 = cursorInstanceReference._CursorRenderer.transform;
										if ((object)transform3 != null)
										{
											Vector3 right = transform3.right;
											bool flag6 = (object)transform == null;
											bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&ret2));
											float deltaTime = PauseSystem.DeltaTime;
											float num9 = deltaTime * num5;
											float num10 = _003CdurationLeft_003E5__2 - num9;
											_003CdurationLeft_003E5__2 = num10;
											float num11 = _003CdurationLeft_003E5__2 - num9;
											float num12 = num11 / num5;
											if (num12 < (float)_003ClastSecond_003E5__3)
											{
												CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
												int num13 = default(int);
												string text2 = num13.ToString(invariantCulture2);
												if ((object)_003Ctext_003E5__4 == null)
												{
													goto IL_11e0;
												}
												PhaserText phaserText8 = _003Ctext_003E5__4.SetText(text2);
											}
											_003ClastSecond_003E5__3 = (int)num12;
											GameManager core = GM.Core;
											if ((object)GM.Core != null && core._mainCharacters != null)
											{
												List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
												while (enumerator.MoveNext())
												{
													string text3 = (string)(object)_003CtargetPizza_003E5__8;
													float2 position = ((ArcadeSprite)null).position;
													bool flag8 = (object)_003CtargetPizza_003E5__8 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ r14_v31 (System.String)+40]");
													bool flag9 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ r14_v31 (System.String)+40]");
													if (((Circle)0).Contains(vector))
													{
														_003CdurationLeft_003E5__2 = 0f;
														_003CplayerInPizza_003E5__10 = null;
														break;
													}
												}
												_003C_003E2__current = null;
												_003C_003E1__state = 1;
												return true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else if ((object)_003CtargetPizza_003E5__8 != null)
			{
				GameObject gameObject2 = _003CtargetPizza_003E5__8.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
					if ((object)_003CtargetPizza_003E5__8 != null)
					{
						GameObject gameObject3 = _003CtargetPizza_003E5__8.gameObject;
						if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
						{
							ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
							if ((object)pool != null)
							{
								pool.Release(gameObject3);
								if ((object)_003Ctext_003E5__4 != null)
								{
									GameObject gameObject4 = _003Ctext_003E5__4.gameObject;
									UnityEngine.Object.Destroy(gameObject4, num4);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+98]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+98]");
										bool flag10 = ((List<object>)0).Remove(_003CeventInstance_003E5__7);
										PhaserText phaserText9 = (PhaserText)(object)_003CnewsFeed_003E5__5;
										bool flag11 = (object)_003CnewsFeed_003E5__5 == null;
										nint num14 = 0;
										if (!flag11)
										{
											bool flag12 = ((UnityEngine.Object)phaserText9).m_CachedPtr == (IntPtr)0;
											num14 = 0;
											if (!flag12)
											{
												if ((object)_003CnewsFeed_003E5__5 == null)
												{
													goto IL_11e0;
												}
												_003CnewsFeed_003E5__5.Hide();
												_003CnewsFeed_003E5__5 = null;
												num14 = 0;
											}
										}
										VampireSurvivors.Objects.Characters.CharacterController characterController = _003CplayerInPizza_003E5__10;
										if ((object)_003CplayerInPizza_003E5__10 != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
										{
											GameManager core2 = GM.Core;
											object obj7 = _003CplayerInPizza_003E5__10;
											action2 = delegate
											{
												_003C_003E4__this._finishedTeleportingToRemotePlayer = true;
											};
											if ((object)GM.Core != null && (object)_003CplayerInPizza_003E5__10 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rsi_v26 (System.Object)+A8]");
												string text4 = (string)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rsi_v26 (System.Object)+A8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r14_v23 (System.String)+160]");
													object obj8 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r14_v23 (System.String)+160]");
													if ((nint)0 == 0)
													{
														goto IL_116d;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v76+20]");
													object obj9 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ rax_v76+20]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v68+10]");
														bool flag13 = false;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v68+10]");
														if ((nint)0 != 1)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rcx_v68+10]");
															object obj10 = -3;
															bool flag14 = obj10 == null;
															flag13 = flag14;
														}
														if (flag13)
														{
															goto IL_116d;
														}
														if ((object)OnlineStageManager._instance != null)
														{
															PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
															if ((object)myPlayerInfo != null)
															{
																VampireSurvivors.Objects.Characters.CharacterController characterController2 = myPlayerInfo.CharacterController;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rsi_v26 (System.Object)+10]");
																bool flag15 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rsi_v26 (System.Object)+10]");
																IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
																Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
																if ((object)transform4 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1241 @ rax_v94 (UnityEngine.Transform)+10]");
																	bool flag16 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1241 @ rax_v94 (UnityEngine.Transform)+10]");
																	Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
																	if ((object)characterController2 != null)
																	{
																		characterController2.position = vector;
																		Transform transform5 = characterController2.transform;
																		if ((object)transform5 != null)
																		{
																			Vector3 position2 = transform5.position;
																			bool flag17 = (object)core2._coopCameraTarget == null;
																			float num15 = default(float);
																			core2._coopCameraTarget.position = (Vector3)(&num15);
																			Transform transform6 = characterController2.transform;
																			bool flag18 = (object)transform6 == null;
																			Vector3 position3 = transform6.position;
																			if ((object)core2._stage != null)
																			{
																				core2._stage.DoTeleportVfx(vector, null, action2);
																				action3 = action2;
																				obj11 = 1;
																				goto IL_168b;
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
										else
										{
											Action action4 = onFailure;
											if (onFailure != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1244.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
												goto IL_1379;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_11e0;
			IL_1379:
			return false;
			IL_11e0:
			throw new NullReferenceException();
			IL_116d:
			if (action2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3724.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			action3 = null;
			obj11 = 0;
			goto IL_168b;
			IL_0448:
			if (_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+38]");
				object obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+38]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1213 @ rax_v226+208]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1213 @ rax_v226+208]");
						List<Vector2> specialLocations = ((TilingTileset)0).GetSpecialLocations("BossPlateSpawn");
						if (specialLocations != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1214 @ rax_v227 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							if ((nint)0 <= (nint)0)
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
								goto IL_12e5;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1214 @ rax_v227 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1214 @ rax_v227 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v228+18]");
								if ((nint)0 <= (nint)0)
								{
									goto IL_12e5;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v228+20]");
								_003CtargetLocation_003E5__6 = (Vector2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v228+24]");
								_ = 0;
								EventTargetInstace eventTargetInstace = null;
								eventTargetInstace._eventTargetIndex = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v228+20]");
								eventTargetInstace._eventTargetPosition = (Vector2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v228+24]");
								_ = 0;
								_003CeventInstance_003E5__7 = eventTargetInstace;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+98]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA48C0");
									if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
									{
										ObjectPool pool2 = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
										if ((object)pool2 != null)
										{
											GameObject gameObject5 = pool2.GetObject((Vector3)(&ret2), (Quaternion)(&quaternion2));
											if ((object)gameObject5 != null)
											{
												PizzaCircle component2 = gameObject5.GetComponent<PizzaCircle>();
												_003CtargetPizza_003E5__8 = component2;
												if ((object)_003CtargetPizza_003E5__8 != null)
												{
													_003CtargetPizza_003E5__8.Init(16f);
													PhaserText phaserText10 = (PhaserText)(object)_003CtargetPizza_003E5__8;
													if ((object)_003CtargetPizza_003E5__8 != null)
													{
														SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)phaserText10._originX, 1f);
														CursorData cursorData3 = new CursorData();
														cursorData3.IconAlpha = 1f;
														cursorData3._cursorProportionOfScreenFromCenter = 0.45f;
														cursorData3.AnimationName = "arrow_0";
														cursorData3.AnimationStartingFrame = 1;
														cursorData3.AnimationFramesCount = 8;
														cursorData3.AnimationFrameRate = 16;
														Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
														cursorData3.CursorSprite = sprite;
														bool flag19 = true;
														cursorData3.CursorScale = 2f;
														cursorData3.CursorColorHex = "#ff0000";
														cursorData3.CursorAlpha = 1f;
														cursorData3.OnScreenPointAt = true;
														cursorData3._cursorProportionOfScreenFromCenter = 0.3f;
														_003CcursorData_003E5__9 = cursorData3;
														if ((object)_003CtargetPizza_003E5__8 != null)
														{
															GameObject gameObject6 = _003CtargetPizza_003E5__8.gameObject;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ r15_v21 (System.Object)+20]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
																_003CplayerInPizza_003E5__10 = null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																bool flag20 = (nint)0 == 0;
																float num16 = 1f;
																num4 = 0f;
																num5 = 1000f;
																if (!flag20)
																{
																	object obj14 = this + 128;
																	object obj15 = obj14 >> 12;
																	object obj16 = obj15 & 0x1FFFFF;
																	object obj17 = obj16 >> 6;
																	flag19 = (byte)(obj16 & 0x3F) != 0;
																	nint num18;
																	do
																	{
																		object obj18 = 1 << (flag19 ? 1 : 0);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v26+462E0+v1525 @ rdx_v110*8]");
																		object obj19 = 0 | obj18;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v26+462E0+v1525 @ rdx_v110*8]");
																		nint num17 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v26+462E0+v1525 @ rdx_v110*8]");
																		if (num17 == 0)
																		{
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v26+462E0+v1525 @ rdx_v110*8]");
																		num18 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v26+462E0+v1525 @ rdx_v110*8]");
																	}
																	while (num18 != 0);
																	num6 = _003CdurationLeft_003E5__2;
																	num16 = 1f;
																	num4 = 0f;
																	num5 = 1000f;
																	goto IL_0917;
																}
																goto IL_1321;
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
			goto IL_11e0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003C_SabotageEMEWithCallbacks_003Ed__104(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public StageEventManager _003C_003E4__this;

		public float duration;

		public object moreY;

		public Action<Vector2> onSuccess;

		public Action onFailure;

		private List<Vector2> _003CeventTargets_003E5__2;

		private float _003CdurationLeft_003E5__3;

		private int _003ClastSecond_003E5__4;

		private PhaserSprite _003CgreenOverlay_003E5__5;

		private PhaserText _003Ctext_003E5__6;

		private NewsFeed _003CnewsFeed_003E5__7;

		private Vector2 _003CtargetLocation_003E5__8;

		private EventTargetInstace _003CsabotageInstance_003E5__9;

		private PizzaCircle _003CtargetPizza_003E5__10;

		private CursorData _003CcursorData_003E5__11;

		private bool _003Csuccess_003E5__12;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_00e3: Expected I4, but got I8
			//IL_0030: Expected O, but got I4
			//IL_00cf: Expected I4, but got I8
			//IL_0376: Expected I4, but got F4
			//IL_017d: Expected I, but got O
			//IL_018b: Expected I, but got O
			//IL_019b: Expected O, but got I
			//IL_0076: Expected I4, but got I8
			//IL_021b: Expected O, but got I4
			//IL_01d7: Expected O, but got I
			//IL_00a8: Expected F4, but got I4
			//IL_00b2: Expected F4, but got I4
			//IL_020d: Expected O, but got I4
			//IL_0287: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Expected I4, but got Unknown
			//IL_04a2: Expected O, but got I4
			//IL_13dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_13e1: Expected I4, but got Unknown
			//IL_1843: Expected O, but got I4
			//IL_064c: Expected O, but got Ref
			//IL_12e2: Expected O, but got I4
			//IL_1751: Invalid comparison between F4 and I4
			//IL_1040: Expected I4, but got F4
			//IL_06cb: Expected O, but got I4
			//IL_132a: Expected O, but got I4
			//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f7: Expected I4, but got Unknown
			//IL_0ebd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ec2: Expected O, but got Unknown
			//IL_0eed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef2: Expected O, but got Unknown
			//IL_0efb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f00: Expected O, but got Unknown
			//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f0e: Expected O, but got Unknown
			//IL_10f4: Expected O, but got I
			//IL_0f88: Expected F4, but got I4
			//IL_0f88: Expected O, but got F4
			//IL_092a: Expected O, but got I
			//IL_1887: Expected O, but got F4
			//IL_1887: Expected O, but got F4
			//IL_1887: Expected I4, but got F4
			//IL_0984: Expected O, but got I
			//IL_09b8: Expected O, but got I
			//IL_0a4b: Expected O, but got Ref
			//IL_0a4b: Expected O, but got Ref
			//IL_0c0c: Expected F4, but got I4
			//IL_16bf->IL1434: Incompatible stack heights: 1 vs 0
			//IL_0dcf->IL1434: Incompatible stack heights: 1 vs 0
			//IL_0df1->IL1434: Incompatible stack heights: 1 vs 0
			//IL_0e20->IL1434: Incompatible stack heights: 1 vs 0
			//IL_0684->IL1434: Incompatible stack heights: 22 vs 0
			//IL_06b3->IL1434: Incompatible stack heights: 22 vs 0
			//IL_1062->IL1434: Incompatible stack heights: 3 vs 0
			//IL_1084->IL1434: Incompatible stack heights: 3 vs 0
			//IL_0e98->IL1434: Incompatible stack heights: 3 vs 0
			//IL_0727->IL1434: Incompatible stack heights: 22 vs 0
			//IL_08b4->IL1434: Incompatible stack heights: 22 vs 0
			//IL_1141->IL1851: Incompatible stack heights: 3 vs 0
			//IL_110c->IL17a7: Incompatible stack heights: 5 vs 3
			//IL_0fa9->IL1434: Incompatible stack heights: 3 vs 0
			//IL_0f44->IL1434: Incompatible stack heights: 3 vs 0
			//IL_08f2->IL1434: Incompatible stack heights: 22 vs 0
			//IL_112c->IL17cd: Incompatible stack heights: 5 vs 3
			//IL_0fd8->IL1434: Incompatible stack heights: 3 vs 0
			//IL_094a->IL1434: Incompatible stack heights: 23 vs 0
			//IL_07e0->IL1434: Incompatible stack heights: 22 vs 0
			//IL_1023->IL1434: Incompatible stack heights: 3 vs 0
			//IL_09f1->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0825->IL1434: Incompatible stack heights: 22 vs 0
			//IL_0847->IL1434: Incompatible stack heights: 22 vs 0
			//IL_18b3->IL1434: Incompatible stack heights: 24 vs 0
			//IL_087c->IL1434: Incompatible stack heights: 22 vs 0
			//IL_0a30->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0a67->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0aa2->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0ad1->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0b9f->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0bd5->IL1434: Incompatible stack heights: 24 vs 0
			//IL_0c1a->IL1469: Incompatible stack heights: 24 vs 0
			StageEventManager stageEventManager = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			bool result;
			float num;
			float num3;
			float num4;
			Stage stage;
			Factory factory;
			object obj4;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_034e;
				}
				bool flag2 = (nint)obj != 1;
				result = false;
				if (flag2)
				{
					goto IL_1464;
				}
				_003C_003E1__state = -1;
				num = _003CdurationLeft_003E5__3;
				if (_003C_003E4__this != null)
				{
					float num2 = 0f;
					num3 = 0f;
					num4 = 1000f;
					goto IL_1469;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					stage = core._stage;
					if ((object)core._stage != null)
					{
						Factory fancyBg = (Factory)(object)stage._fancyBg;
						if ((object)stage._fancyBg == null)
						{
							factory = null;
							goto IL_1488;
						}
						nint num5 = (nint)fancyBg;
						nint num6 = (nint)typeof(BackgroundCoop);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1352 @ r8_v154 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundCoop>)+130]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ r9_v46 (Il2CppClass<Factory>)+130]");
						nint num7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1352 @ r8_v154 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundCoop>)+130]");
						if (num7 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1351 @ r9_v46 (Il2CppClass<Factory>)+C8]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1504 @ rax_v328+FFFFFFF8+v1353 @ rax_v324*8]");
							if (0 == (nint)typeof(BackgroundCoop))
							{
								obj4 = 1;
								goto IL_14a7;
							}
						}
						obj4 = 0;
						goto IL_14a7;
					}
				}
			}
			goto IL_1434;
			IL_089a:
			Vector2 value = default(Vector2);
			Quaternion quaternion2 = default(Quaternion);
			if (_003C_003E4__this != null)
			{
				int num8 = _003C_003E4__this.ChooseEMEEventTargetIndex(_003CeventTargets_003E5__2);
				List<Vector2> list = _003CeventTargets_003E5__2;
				if (_003CeventTargets_003E5__2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v207 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					bool flag3 = (nint)num8 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v207 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v207 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v208+18]");
						bool flag4 = (nint)num8 >= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v208+20+v4150 @ rax_v206 (System.Int32)*8]");
						_003CtargetLocation_003E5__8 = (Vector2)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v208+24+v4150 @ rax_v206 (System.Int32)*8]");
						_ = 0;
						EventTargetInstace eventTargetInstace = null;
						eventTargetInstace._eventTargetIndex = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v208+20+v4150 @ rax_v206 (System.Int32)*8]");
						eventTargetInstace._eventTargetPosition = (Vector2)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ rax_v208+24+v4150 @ rax_v206 (System.Int32)*8]");
						_ = 0;
						_003CsabotageInstance_003E5__9 = eventTargetInstace;
						if (stageEventManager._eventTargets != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA48C0");
							if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
							{
								ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
								if ((object)pool != null)
								{
									GameObject gameObject = pool.GetObject((Vector3)(&value), (Quaternion)(&quaternion2));
									if ((object)gameObject != null)
									{
										PizzaCircle component = gameObject.GetComponent<PizzaCircle>();
										_003CtargetPizza_003E5__10 = component;
										if ((object)_003CtargetPizza_003E5__10 != null)
										{
											_003CtargetPizza_003E5__10.Init(16f);
											if ((object)_003CtargetPizza_003E5__10 != null)
											{
												_003CtargetPizza_003E5__10.SetAlpha(1f);
												CursorData cursorData = new CursorData();
												cursorData.IconAlpha = 1f;
												cursorData._cursorProportionOfScreenFromCenter = 0.45f;
												cursorData.AnimationName = "arrow_0";
												cursorData.AnimationStartingFrame = 1;
												cursorData.AnimationFramesCount = 8;
												cursorData.AnimationFrameRate = 16;
												Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
												cursorData.CursorSprite = sprite;
												bool flag5 = true;
												cursorData.CursorScale = 2f;
												cursorData.CursorColorHex = "#ff0000";
												cursorData.CursorAlpha = 1f;
												cursorData.OnScreenPointAt = true;
												cursorData._cursorProportionOfScreenFromCenter = 0.3f;
												_003CcursorData_003E5__11 = cursorData;
												if ((object)_003CtargetPizza_003E5__10 != null)
												{
													GameObject gameObject2 = _003CtargetPizza_003E5__10.gameObject;
													if (stageEventManager._signalBus != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
														_003Csuccess_003E5__12 = false;
														num = _003CdurationLeft_003E5__3;
														float num2 = 1f;
														num3 = 0f;
														num4 = 1000f;
														goto IL_1469;
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
			goto IL_1434;
			IL_1036:
			float num9;
			_003ClastSecond_003E5__4 = (int)num9;
			GameManager core2 = GM.Core;
			if ((object)GM.Core == null || core2._characters == null)
			{
				goto IL_1434;
			}
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			Vector2 vector = default(Vector2);
			while (enumerator.MoveNext())
			{
				Factory factory2 = (Factory)(object)_003CtargetPizza_003E5__10;
				float2 position = ((ArcadeSprite)null).position;
				bool flag6 = (object)_003CtargetPizza_003E5__10 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2544 @ rsi_v26 (Factory)+40]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2544 @ rsi_v26 (Factory)+40]");
				if (((Circle)0).Contains(vector))
				{
					_003CdurationLeft_003E5__3 = 0f;
					_003Csuccess_003E5__12 = true;
					break;
				}
			}
			_003C_003E2__current = null;
			_003C_003E1__state = 2;
			goto IL_1851;
			IL_1488:
			if (_003C_003E4__this != null)
			{
				Stage ourStage = stageEventManager._ourStage;
				if ((object)stageEventManager._ourStage != null && factory != null)
				{
					int num10 = factory + 128;
					string text = ((int*)num10)->ToString();
					string scriptName = "EventTarget" + text;
					if ((object)ourStage._tilingTileset != null)
					{
						List<Vector2> specialLocations = ourStage._tilingTileset.GetSpecialLocations(scriptName);
						_003CeventTargets_003E5__2 = specialLocations;
						bool flag5 = false;
						if (_003CeventTargets_003E5__2 != null)
						{
							List<Vector2> list2 = _003CeventTargets_003E5__2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ rax_v319 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							if ((nint)0 != 0)
							{
								goto IL_034e;
							}
						}
						int num11 = factory + 128;
						string text2 = ((int*)num11)->ToString();
						string message = "No EventTarget" + text2 + " found in map data";
						Debug.Log(message);
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						goto IL_1851;
					}
				}
			}
			goto IL_1434;
			IL_034e:
			_003CdurationLeft_003E5__3 = duration;
			float num12 = duration / 1000f;
			_003ClastSecond_003E5__4 = (int)num12;
			Camera main = Camera.main;
			float num13 = default(float);
			float num15 = default(float);
			float num16 = default(float);
			bool flag35 = default(bool);
			if ((object)main != null)
			{
				GameObject gameObject3 = main.gameObject;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "WhiteDot");
				_003CgreenOverlay_003E5__5 = phaserSprite;
				bool flag8 = (object)GM.Core == null;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				bool flag9 = ArcadePhysics.s_scene == null;
				PhaserScene.Renderer renderer = s_scene._renderer;
				bool flag10 = s_scene._renderer == null;
				bool flag11 = (object)GM.Core == null;
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				bool flag12 = ArcadePhysics.s_scene == null;
				bool flag13 = s_scene2._renderer == null;
				bool flag14 = (object)_003CgreenOverlay_003E5__5 == null;
				PhaserSprite phaserSprite2 = _003CgreenOverlay_003E5__5.setScale(renderer.screenWidthPixels, (float?)(object)1);
				bool flag15 = (object)_003CgreenOverlay_003E5__5 == null;
				PhaserSprite phaserSprite3 = _003CgreenOverlay_003E5__5.setTint(65280u);
				bool flag16 = (object)_003CgreenOverlay_003E5__5 == null;
				PhaserSprite phaserSprite4 = _003CgreenOverlay_003E5__5.setAlpha(0.25f);
				bool flag17 = (object)_003CgreenOverlay_003E5__5 == null;
				PhaserSprite phaserSprite5 = _003CgreenOverlay_003E5__5.setVisible(visible: false);
				bool flag18 = (object)_003CgreenOverlay_003E5__5 == null;
				Transform transform = _003CgreenOverlay_003E5__5.transform;
				bool flag19 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2253 @ rax_v178 (UnityEngine.Transform)+10]");
				bool flag20 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2253 @ rax_v178 (UnityEngine.Transform)+10]");
				Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
				bool flag21 = (object)_003CgreenOverlay_003E5__5 == null;
				PhaserSprite phaserSprite6 = _003CgreenOverlay_003E5__5.setDepth(3000);
				bool flag22 = (object)GM.Core == null;
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				bool flag23 = ArcadePhysics.s_scene == null;
				bool flag24 = (object)GM.Core == null;
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				bool flag25 = ArcadePhysics.s_scene == null;
				bool flag26 = s_scene4._renderer == null;
				bool flag27 = (object)GM.Core == null;
				PhaserScene s_scene5 = ArcadePhysics.s_scene;
				bool flag28 = ArcadePhysics.s_scene == null;
				bool flag29 = s_scene5._renderer == null;
				PhaserText component2 = RenderingExtensions.text(s_scene3.add, vector, "", (Color)(&quaternion2), num13);
				PhaserText phaserText = RenderingExtensions.SetScrollFactor(component2, 0f);
				if ((object)phaserText != null)
				{
					PhaserText phaserText2 = phaserText.SetDepth(31758);
					if ((object)phaserText2 != null)
					{
						PhaserText phaserText3 = phaserText2.setOrigin(0.5f, (float?)(object)1);
						_003Ctext_003E5__6 = phaserText3;
						CultureInfo invariantCulture = CultureInfo.InvariantCulture;
						int num14 = this + 84;
						string text3 = ((int*)num14)->ToString(invariantCulture);
						if ((object)_003Ctext_003E5__6 != null)
						{
							PhaserText phaserText4 = _003Ctext_003E5__6.SetText(text3);
							_003CnewsFeed_003E5__7 = null;
							bool flag30 = moreY == null;
							bool flag31 = false;
							if (!flag30)
							{
								object obj6 = moreY;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
								bool flag32 = obj6 != null;
								object obj7 = null;
								if (!flag32)
								{
									obj7 = obj6;
								}
								bool flag33 = obj7 == null;
								flag31 = false;
								if (!flag33)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
									bool flag34 = obj6 != null;
									string term = null;
									if (!flag34)
									{
										term = (string)obj6;
									}
									string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num13 != 0, (GameObject)num15, (string)num16, flag35);
									GameObject gameObject4 = new GameObject();
									if ((object)gameObject4 != null)
									{
										NewsFeed newsFeed = gameObject4.AddComponent<NewsFeed>();
										_003CnewsFeed_003E5__7 = newsFeed;
										NewsFeed newsFeed2 = _003CnewsFeed_003E5__7;
										if ((object)_003CnewsFeed_003E5__7 != null && (object)newsFeed2._text != null)
										{
											PhaserText phaserText5 = newsFeed2._text.SetText(translation);
											if ((object)_003CnewsFeed_003E5__7 != null)
											{
												_003CnewsFeed_003E5__7.Show();
												flag31 = true;
												goto IL_089a;
											}
										}
									}
									goto IL_1434;
								}
							}
							goto IL_089a;
						}
					}
				}
			}
			goto IL_1434;
			IL_1434:
			throw new NullReferenceException();
			IL_1469:
			PhaserSprite phaserSprite7;
			bool visible;
			if (num > num3)
			{
				List<EventTargetInstace> eventTargets = stageEventManager._eventTargets;
				if (stageEventManager._eventTargets != null)
				{
					int num17 = Array.IndexOf((object[])eventTargets._items, (object)_003CsabotageInstance_003E5__9, 0, eventTargets._size);
					bool flag36 = num17 == 0;
					Factory factory3 = (Factory)(object)_003CnewsFeed_003E5__7;
					if ((object)_003CnewsFeed_003E5__7 != null && factory3._world != null)
					{
						if ((object)_003CnewsFeed_003E5__7 == null)
						{
							goto IL_1434;
						}
						_003CnewsFeed_003E5__7.SetVisible(flag36);
					}
					if ((object)_003Ctext_003E5__6 != null)
					{
						Transform transform2 = _003Ctext_003E5__6.transform;
						CursorData cursorData2 = _003CcursorData_003E5__11;
						if (_003CcursorData_003E5__11 != null && (object)cursorData2._CursorInstanceReference != null)
						{
							Transform transform3 = cursorData2._CursorInstanceReference.transform;
							if ((object)transform3 != null)
							{
								bool flag37 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)(&value));
								CursorData cursorData3 = _003CcursorData_003E5__11;
								if (_003CcursorData_003E5__11 != null)
								{
									CursorIndicator cursorInstanceReference = cursorData3._CursorInstanceReference;
									if ((object)cursorData3._CursorInstanceReference != null && (object)cursorInstanceReference._CursorRenderer != null)
									{
										Transform transform4 = cursorInstanceReference._CursorRenderer.transform;
										if ((object)transform4 != null)
										{
											Vector3 right = transform4.right;
											bool flag38 = (object)transform2 == null;
											bool flag39 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
											float deltaTime = PauseSystem.DeltaTime;
											float num18 = deltaTime * num4;
											float num19 = _003CdurationLeft_003E5__3 - num18;
											_003CdurationLeft_003E5__3 = num19;
											float num20 = _003CdurationLeft_003E5__3 - num18;
											num9 = num20 / num4;
											if (!(num9 < (float)_003ClastSecond_003E5__4))
											{
												goto IL_1036;
											}
											CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
											int num21 = default(int);
											string text4 = num21.ToString(invariantCulture2);
											if ((object)_003Ctext_003E5__6 != null)
											{
												PhaserText phaserText6 = _003Ctext_003E5__6.SetText(text4);
												object obj8 = num9 & 0x80000001L;
												if ((nint)_003Ctext_003E5__6 < 0)
												{
													object obj9 = obj8 - 1;
													object obj10 = obj9 | -2;
													obj8 = obj10 + 1;
												}
												bool flag40 = (nint)obj8 != 1;
												bool flag41 = false;
												if (!flag40)
												{
													flag41 = flag36;
												}
												if (!flag41)
												{
													phaserSprite7 = _003CgreenOverlay_003E5__5;
													if ((object)_003CgreenOverlay_003E5__5 != null)
													{
														visible = false;
														goto IL_1791;
													}
												}
												else
												{
													PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_AlarmSabotage, num4, 10, num3, (float?)(object)num13, num15, num16, flag35, 1f);
													if (stageEventManager._playerOptions != null)
													{
														PlayerOptionsData config = stageEventManager._playerOptions.Config;
														if (config != null)
														{
															if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
															{
																goto IL_1036;
															}
															phaserSprite7 = _003CgreenOverlay_003E5__5;
															if ((object)_003CgreenOverlay_003E5__5 != null)
															{
																visible = true;
																goto IL_1791;
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
			else if ((object)_003CtargetPizza_003E5__10 != null)
			{
				GameObject gameObject5 = _003CtargetPizza_003E5__10.gameObject;
				if (stageEventManager._signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
					if ((object)_003CtargetPizza_003E5__10 != null)
					{
						GameObject gameObject6 = _003CtargetPizza_003E5__10.gameObject;
						if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
						{
							ObjectPool pool2 = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
							if ((object)pool2 != null)
							{
								pool2.Release(gameObject6);
								if ((object)_003Ctext_003E5__6 != null)
								{
									GameObject gameObject7 = _003Ctext_003E5__6.gameObject;
									UnityEngine.Object.Destroy(gameObject7, num3);
									if (stageEventManager._eventTargets != null)
									{
										bool flag42 = ((List<object>)(object)stageEventManager._eventTargets).Remove((object)_003CsabotageInstance_003E5__9);
										if ((object)_003CgreenOverlay_003E5__5 != null)
										{
											GameObject gameObject8 = _003CgreenOverlay_003E5__5.gameObject;
											UnityEngine.Object.Destroy(gameObject8, num3);
											Factory factory4 = (Factory)(object)_003CnewsFeed_003E5__7;
											bool flag43 = (object)_003CnewsFeed_003E5__7 == null;
											object obj11 = 0;
											if (!flag43)
											{
												bool flag44 = factory4._world == null;
												obj11 = 0;
												if (!flag44)
												{
													if ((object)_003CnewsFeed_003E5__7 == null)
													{
														goto IL_1434;
													}
													_003CnewsFeed_003E5__7.Hide();
													_003CnewsFeed_003E5__7 = null;
													obj11 = 0;
												}
											}
											if (!_003Csuccess_003E5__12)
											{
												Action action = onFailure;
												if (onFailure == null)
												{
													goto IL_1434;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1039.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
												result = false;
											}
											else
											{
												Action<Vector2> action2 = onSuccess;
												if (onSuccess == null)
												{
													goto IL_1434;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1040 @ rax_v56 (System.Action`1<UnityEngine.Vector2>)+18] (should have been resolved before IL gen)");
												result = false;
											}
											goto IL_1464;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_1434;
			IL_1464:
			return result;
			IL_14a7:
			bool flag45 = obj4 == null;
			factory = null;
			if (!flag45)
			{
				factory = (Factory)(object)stage._fancyBg;
			}
			goto IL_1488;
			IL_1851:
			result = true;
			goto IL_1464;
			IL_1791:
			PhaserSprite phaserSprite8 = phaserSprite7.setVisible(visible);
			goto IL_1036;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003C_SabotageWithCallbacks_003Ed__98(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float duration;

		public object moreY;

		public int chosenEventTarget;

		public Vector2 targetLocation;

		public StageEventManager _003C_003E4__this;

		public Action<Vector2> onSuccess;

		public Action onFailure;

		private float _003CdurationLeft_003E5__2;

		private int _003ClastSecond_003E5__3;

		private PhaserSprite _003CredOverlay_003E5__4;

		private PhaserText _003Ctext_003E5__5;

		private NewsFeed _003CnewsFeed_003E5__6;

		private EventTargetInstace _003CsabotageInstance_003E5__7;

		private PizzaCircle _003CtargetPizza_003E5__8;

		private CursorData _003CcursorData_003E5__9;

		private bool _003Csuccess_003E5__10;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_002f: Expected I4, but got I8
			//IL_0057: Expected I4, but got F4
			//IL_085a: Expected I4, but got I8
			//IL_088d: Expected F4, but got I4
			//IL_0174: Expected O, but got I4
			//IL_143f: Expected O, but got I4
			//IL_0f71: Expected O, but got I4
			//IL_031e: Expected O, but got Ref
			//IL_1348: Invalid comparison between F4 and I4
			//IL_0cc3: Expected I4, but got F4
			//IL_0fb9: Expected O, but got I4
			//IL_039d: Expected O, but got I4
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Expected I4, but got Unknown
			//IL_0b40: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b45: Expected O, but got Unknown
			//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b75: Expected O, but got Unknown
			//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b83: Expected O, but got Unknown
			//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b91: Expected O, but got Unknown
			//IL_0421: Expected O, but got I4
			//IL_0d77: Expected O, but got I
			//IL_0c0b: Expected F4, but got I4
			//IL_0c0b: Expected O, but got F4
			//IL_1475: Expected O, but got F4
			//IL_1475: Expected O, but got F4
			//IL_1475: Expected I4, but got F4
			//IL_0653: Expected O, but got Ref
			//IL_0653: Expected O, but got Ref
			//IL_0570: Expected O, but got I4
			//IL_0703: Expected O, but got I
			//IL_081b: Expected F4, but got I4
			//IL_12b6->IL1050: Incompatible stack heights: 1 vs 0
			//IL_0a53->IL1050: Incompatible stack heights: 1 vs 0
			//IL_0a75->IL1050: Incompatible stack heights: 1 vs 0
			//IL_0aa4->IL1050: Incompatible stack heights: 1 vs 0
			//IL_0356->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0ce5->IL1050: Incompatible stack heights: 3 vs 0
			//IL_0385->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0d07->IL1050: Incompatible stack heights: 3 vs 0
			//IL_0b1b->IL1050: Incompatible stack heights: 3 vs 0
			//IL_03f9->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0dcd->IL13d0: Incompatible stack heights: 3 vs 0
			//IL_0d8f->IL139e: Incompatible stack heights: 5 vs 3
			//IL_0c2c->IL1050: Incompatible stack heights: 3 vs 0
			//IL_0bc7->IL1050: Incompatible stack heights: 3 vs 0
			//IL_05d7->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0daf->IL13c4: Incompatible stack heights: 5 vs 3
			//IL_0c5b->IL1050: Incompatible stack heights: 3 vs 0
			//IL_05f9->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0ca6->IL1050: Incompatible stack heights: 3 vs 0
			//IL_14a1->IL1050: Incompatible stack heights: 22 vs 0
			//IL_04bb->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0638->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0500->IL1050: Incompatible stack heights: 22 vs 0
			//IL_066f->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0522->IL1050: Incompatible stack heights: 22 vs 0
			//IL_06aa->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0557->IL1050: Incompatible stack heights: 22 vs 0
			//IL_06e3->IL1050: Incompatible stack heights: 22 vs 0
			//IL_07b7->IL1050: Incompatible stack heights: 22 vs 0
			//IL_07ed->IL1050: Incompatible stack heights: 22 vs 0
			//IL_0829->IL120a: Incompatible stack heights: 22 vs 0
			StageEventManager stageEventManager = _003C_003E4__this;
			Vector2 vector = default(Vector2);
			Vector2 value = default(Vector2);
			Quaternion quaternion2 = default(Quaternion);
			float num2 = default(float);
			float num4 = default(float);
			float num5 = default(float);
			bool flag28 = default(bool);
			float num6;
			float num7;
			float num8;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003CdurationLeft_003E5__2 = duration;
				float num = duration / 1000f;
				_003ClastSecond_003E5__3 = (int)num;
				Camera main = Camera.main;
				if ((object)main != null)
				{
					GameObject gameObject = main.gameObject;
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "vfx", "WhiteDot");
					_003CredOverlay_003E5__4 = phaserSprite;
					bool flag = (object)GM.Core == null;
					PhaserScene s_scene = ArcadePhysics.s_scene;
					bool flag2 = ArcadePhysics.s_scene == null;
					PhaserScene.Renderer renderer = s_scene._renderer;
					bool flag3 = s_scene._renderer == null;
					bool flag4 = (object)GM.Core == null;
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					bool flag5 = ArcadePhysics.s_scene == null;
					bool flag6 = s_scene2._renderer == null;
					bool flag7 = (object)_003CredOverlay_003E5__4 == null;
					PhaserSprite phaserSprite2 = _003CredOverlay_003E5__4.setScale(renderer.screenWidthPixels, (float?)(object)1);
					bool flag8 = (object)_003CredOverlay_003E5__4 == null;
					PhaserSprite phaserSprite3 = _003CredOverlay_003E5__4.setTint(16711680u);
					bool flag9 = (object)_003CredOverlay_003E5__4 == null;
					PhaserSprite phaserSprite4 = _003CredOverlay_003E5__4.setAlpha(0.25f);
					bool flag10 = (object)_003CredOverlay_003E5__4 == null;
					PhaserSprite phaserSprite5 = _003CredOverlay_003E5__4.setVisible(visible: false);
					bool flag11 = (object)_003CredOverlay_003E5__4 == null;
					Transform transform = _003CredOverlay_003E5__4.transform;
					bool flag12 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1947 @ rax_v172 (UnityEngine.Transform)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1947 @ rax_v172 (UnityEngine.Transform)+10]");
					Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value));
					bool flag14 = (object)_003CredOverlay_003E5__4 == null;
					PhaserSprite phaserSprite6 = _003CredOverlay_003E5__4.setDepth(3000);
					bool flag15 = (object)GM.Core == null;
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					bool flag16 = ArcadePhysics.s_scene == null;
					bool flag17 = (object)GM.Core == null;
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					bool flag18 = ArcadePhysics.s_scene == null;
					bool flag19 = s_scene4._renderer == null;
					bool flag20 = (object)GM.Core == null;
					PhaserScene s_scene5 = ArcadePhysics.s_scene;
					bool flag21 = ArcadePhysics.s_scene == null;
					bool flag22 = s_scene5._renderer == null;
					PhaserText component = RenderingExtensions.text(s_scene3.add, vector, "", (Color)(&quaternion2), num2);
					PhaserText phaserText = RenderingExtensions.SetScrollFactor(component, 0f);
					if ((object)phaserText != null)
					{
						PhaserText phaserText2 = phaserText.SetDepth(31758);
						if ((object)phaserText2 != null)
						{
							PhaserText phaserText3 = phaserText2.setOrigin(0.5f, (float?)(object)1);
							_003Ctext_003E5__5 = phaserText3;
							CultureInfo invariantCulture = CultureInfo.InvariantCulture;
							int num3 = this + 92;
							string text = ((int*)num3)->ToString(invariantCulture);
							if ((object)_003Ctext_003E5__5 != null)
							{
								PhaserText phaserText4 = _003Ctext_003E5__5.SetText(text);
								_003CnewsFeed_003E5__6 = null;
								object obj = 0;
								bool flag23 = moreY == null;
								bool flag24 = false;
								if (!flag23)
								{
									object obj2 = moreY;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
									bool flag25 = obj2 != null;
									object obj3 = null;
									if (!flag25)
									{
										obj3 = obj2;
									}
									bool flag26 = obj3 == null;
									flag24 = false;
									if (!flag26)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
										bool flag27 = obj2 != null;
										string term = null;
										if (!flag27)
										{
											term = (string)obj2;
										}
										string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num2 != 0, (GameObject)num4, (string)num5, flag28);
										GameObject gameObject2 = new GameObject();
										if ((object)gameObject2 != null)
										{
											NewsFeed newsFeed = gameObject2.AddComponent<NewsFeed>();
											_003CnewsFeed_003E5__6 = newsFeed;
											NewsFeed newsFeed2 = _003CnewsFeed_003E5__6;
											if ((object)_003CnewsFeed_003E5__6 != null && (object)newsFeed2._text != null)
											{
												PhaserText phaserText5 = newsFeed2._text.SetText(translation);
												if ((object)_003CnewsFeed_003E5__6 != null)
												{
													_003CnewsFeed_003E5__6.Show();
													obj = 0;
													flag24 = true;
													goto IL_057e;
												}
											}
										}
										goto IL_1050;
									}
								}
								goto IL_057e;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_1229;
				}
				_003C_003E1__state = -1;
				num6 = _003CdurationLeft_003E5__2;
				if (_003C_003E4__this != null)
				{
					num7 = 0f;
					num8 = 1000f;
					goto IL_120a;
				}
			}
			goto IL_1050;
			IL_120a:
			float num13;
			PhaserSprite phaserSprite7;
			bool visible;
			if (num6 > num7)
			{
				List<EventTargetInstace> eventTargets = stageEventManager._eventTargets;
				if (stageEventManager._eventTargets != null)
				{
					int num9 = Array.IndexOf((object[])eventTargets._items, (object)_003CsabotageInstance_003E5__7, 0, eventTargets._size);
					bool flag29 = num9 == 0;
					object obj4 = _003CnewsFeed_003E5__6;
					if ((object)_003CnewsFeed_003E5__6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rbx_v18 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							if ((object)_003CnewsFeed_003E5__6 == null)
							{
								goto IL_1050;
							}
							_003CnewsFeed_003E5__6.SetVisible(flag29);
						}
					}
					if ((object)_003Ctext_003E5__5 != null)
					{
						Transform transform2 = _003Ctext_003E5__5.transform;
						CursorData cursorData = _003CcursorData_003E5__9;
						if (_003CcursorData_003E5__9 != null && (object)cursorData._CursorInstanceReference != null)
						{
							Transform transform3 = cursorData._CursorInstanceReference.transform;
							if ((object)transform3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v82 (UnityEngine.Transform)+10]");
								bool flag30 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rax_v82 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&value));
								CursorData cursorData2 = _003CcursorData_003E5__9;
								if (_003CcursorData_003E5__9 != null)
								{
									CursorIndicator cursorInstanceReference = cursorData2._CursorInstanceReference;
									if ((object)cursorData2._CursorInstanceReference != null && (object)cursorInstanceReference._CursorRenderer != null)
									{
										Transform transform4 = cursorInstanceReference._CursorRenderer.transform;
										if ((object)transform4 != null)
										{
											Vector3 right = transform4.right;
											bool flag31 = (object)transform2 == null;
											bool flag32 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value));
											float deltaTime = PauseSystem.DeltaTime;
											float num10 = deltaTime * num8;
											float num11 = _003CdurationLeft_003E5__2 - num10;
											_003CdurationLeft_003E5__2 = num11;
											float num12 = _003CdurationLeft_003E5__2 - num10;
											num13 = num12 / num8;
											if (!(num13 < (float)_003ClastSecond_003E5__3))
											{
												goto IL_0cb9;
											}
											CultureInfo invariantCulture2 = CultureInfo.InvariantCulture;
											int num14 = default(int);
											string text2 = num14.ToString(invariantCulture2);
											if ((object)_003Ctext_003E5__5 != null)
											{
												PhaserText phaserText6 = _003Ctext_003E5__5.SetText(text2);
												object obj5 = num13 & 0x80000001L;
												if ((nint)_003Ctext_003E5__5 < 0)
												{
													object obj6 = obj5 - 1;
													object obj7 = obj6 | -2;
													obj5 = obj7 + 1;
												}
												bool flag33 = (nint)obj5 != 1;
												bool flag34 = false;
												if (!flag33)
												{
													flag34 = flag29;
												}
												if (!flag34)
												{
													phaserSprite7 = _003CredOverlay_003E5__4;
													if ((object)_003CredOverlay_003E5__4 != null)
													{
														visible = false;
														goto IL_1388;
													}
												}
												else
												{
													PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_AlarmSabotage, num8, 10, num7, (float?)(object)num2, num4, num5, flag28, 1f);
													if (stageEventManager._playerOptions != null)
													{
														PlayerOptionsData config = stageEventManager._playerOptions.Config;
														if (config != null)
														{
															if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
															{
																goto IL_0cb9;
															}
															phaserSprite7 = _003CredOverlay_003E5__4;
															if ((object)_003CredOverlay_003E5__4 != null)
															{
																visible = true;
																goto IL_1388;
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
			else if ((object)_003CtargetPizza_003E5__8 != null)
			{
				GameObject gameObject3 = _003CtargetPizza_003E5__8.gameObject;
				if (stageEventManager._signalBus != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
					if ((object)_003CtargetPizza_003E5__8 != null)
					{
						GameObject gameObject4 = _003CtargetPizza_003E5__8.gameObject;
						if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
						{
							ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
							if ((object)pool != null)
							{
								pool.Release(gameObject4);
								if ((object)_003Ctext_003E5__5 != null)
								{
									GameObject gameObject5 = _003Ctext_003E5__5.gameObject;
									UnityEngine.Object.Destroy(gameObject5, num7);
									if (stageEventManager._eventTargets != null)
									{
										bool flag35 = ((List<object>)(object)stageEventManager._eventTargets).Remove((object)_003CsabotageInstance_003E5__7);
										if ((object)_003CredOverlay_003E5__4 != null)
										{
											GameObject gameObject6 = _003CredOverlay_003E5__4.gameObject;
											UnityEngine.Object.Destroy(gameObject6, num7);
											object obj8 = _003CnewsFeed_003E5__6;
											bool flag36 = (object)_003CnewsFeed_003E5__6 == null;
											object obj9 = 0;
											if (!flag36)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rbx_v17 (System.Object)+10]");
												bool flag37 = (nint)0 == 0;
												obj9 = 0;
												if (!flag37)
												{
													if ((object)_003CnewsFeed_003E5__6 == null)
													{
														goto IL_1050;
													}
													_003CnewsFeed_003E5__6.Hide();
													_003CnewsFeed_003E5__6 = null;
													obj9 = 0;
												}
											}
											if (!_003Csuccess_003E5__10)
											{
												Action action = onFailure;
												if (onFailure == null)
												{
													goto IL_1050;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v995.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
											}
											else
											{
												Action<Vector2> action2 = onSuccess;
												if (onSuccess == null)
												{
													goto IL_1050;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v996 @ rax_v48 (System.Action`1<UnityEngine.Vector2>)+18] (should have been resolved before IL gen)");
											}
											goto IL_1229;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_1050;
			IL_0cb9:
			_003ClastSecond_003E5__3 = (int)num13;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj10 = _003CtargetPizza_003E5__8;
					float2 position = ((ArcadeSprite)null).position;
					bool flag38 = (object)_003CtargetPizza_003E5__8 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2315 @ rbx_v24 (System.Object)+40]");
					bool flag39 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2315 @ rbx_v24 (System.Object)+40]");
					if (((Circle)0).Contains(vector))
					{
						_003CdurationLeft_003E5__2 = 0f;
						_003Csuccess_003E5__10 = true;
						break;
					}
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_1050;
			IL_1229:
			return false;
			IL_1050:
			throw new NullReferenceException();
			IL_1388:
			PhaserSprite phaserSprite8 = phaserSprite7.setVisible(visible);
			goto IL_0cb9;
			IL_057e:
			EventTargetInstace eventTargetInstace = null;
			eventTargetInstace._eventTargetIndex = chosenEventTarget;
			eventTargetInstace._eventTargetPosition = targetLocation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.StageEventManager+<_SabotageWithCallbacks>d__98)+38]");
			_ = 0;
			_003CsabotageInstance_003E5__7 = eventTargetInstace;
			if (_003C_003E4__this != null && stageEventManager._eventTargets != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA48C0");
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
				{
					ObjectPool pool2 = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
					if ((object)pool2 != null)
					{
						GameObject gameObject7 = pool2.GetObject((Vector3)(&value), (Quaternion)(&quaternion2));
						if ((object)gameObject7 != null)
						{
							PizzaCircle component2 = gameObject7.GetComponent<PizzaCircle>();
							_003CtargetPizza_003E5__8 = component2;
							if ((object)_003CtargetPizza_003E5__8 != null)
							{
								_003CtargetPizza_003E5__8.Init(16f);
								object obj11 = _003CtargetPizza_003E5__8;
								if ((object)_003CtargetPizza_003E5__8 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rbx_v37 (System.Object)+30]");
									SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha((SpriteRenderer)0, 1f);
									CursorData cursorData3 = new CursorData();
									cursorData3.IconAlpha = 1f;
									cursorData3._cursorProportionOfScreenFromCenter = 0.45f;
									cursorData3.AnimationName = "arrow_0";
									cursorData3.AnimationStartingFrame = 1;
									cursorData3.AnimationFramesCount = 8;
									cursorData3.AnimationFrameRate = 16;
									Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
									cursorData3.CursorSprite = sprite;
									cursorData3.CursorScale = 2f;
									cursorData3.CursorColorHex = "#ff0000";
									cursorData3.CursorAlpha = 1f;
									cursorData3.OnScreenPointAt = true;
									cursorData3._cursorProportionOfScreenFromCenter = 0.3f;
									_003CcursorData_003E5__9 = cursorData3;
									if ((object)_003CtargetPizza_003E5__8 != null)
									{
										GameObject gameObject8 = _003CtargetPizza_003E5__8.gameObject;
										if (stageEventManager._signalBus != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
											_003Csuccess_003E5__10 = false;
											num6 = _003CdurationLeft_003E5__2;
											num7 = 0f;
											num8 = 1000f;
											goto IL_120a;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_1050;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private GameSessionData _gameSessionData;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private DiContainer _diContainer;

	private DestructibleFactory _destructibleFactory;

	private Stage _ourStage;

	private Camera _mainCamera;

	private ShootingStarsManager _shootingStarsManager;

	private ShootingStarsManager2 _shootingStarsManager2;

	private static int RandomEventId;

	private float _playDiamondGridStartX;

	private float _playDiamondGridStartY;

	private List<List<int>> _playDiamondGrid;

	private List<List<EnemyDiamond>> _playDiamondEnemyGrid;

	private bool _playDiamondActive;

	private float _playDiamondDuration = 60000f;

	private Timer _playDiamondDisappearTimer;

	private float _playDiamondPlayerAtGridPrevX;

	private float _playDiamondPlayerAtGridPrevY;

	private bool _stageEventsDisabled;

	private bool _isTeleportingToRemotePlayer;

	private bool _finishedTeleportingToRemotePlayer;

	private const float DontSpawnIfAbove = 500f;

	private int _003CSpawned_003Ek__BackingField;

	public EnemyType? _playDiamond_enemyType;

	private List<EventTargetInstace> _eventTargets;

	public int Spawned
	{
		get
		{
			return _003CSpawned_003Ek__BackingField;
		}
		set
		{
			_003CSpawned_003Ek__BackingField = value;
		}
	}

	public bool IsTeleportingToRemotePlayer
	{
		get
		{
			return _isTeleportingToRemotePlayer;
		}
		set
		{
			_isTeleportingToRemotePlayer = value;
		}
	}

	public bool FinishedTeleportingToRemotePlayer
	{
		get
		{
			return _finishedTeleportingToRemotePlayer;
		}
		set
		{
			_finishedTeleportingToRemotePlayer = value;
		}
	}

	private unsafe Vector3 PlayerPos
	{
		get
		{
			//IL_00f5: Expected native int or pointer, but got O
			//IL_0103: Expected native int or pointer, but got O
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						float ret;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
						Vector3 vector = default(Vector3);
						((Vector3*)(nint)vector)->x = ret;
						((Vector3*)(nint)vector)->z = 0f;
						return vector;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	public void Initialize()
	{
		Action action = Cleanup;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4420");
		Camera main = Camera.main;
		_mainCamera = main;
	}

	public void Dispose()
	{
		Action action = Cleanup;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA45A0");
	}

	public virtual void Init(Stage stage)
	{
		_ourStage = stage;
		ShootingStarsManager shootingStarsManager = _diContainer.Instantiate<ShootingStarsManager>();
		_shootingStarsManager = shootingStarsManager;
		ShootingStarsManager shootingStarsManager2 = _shootingStarsManager;
		Camera main = Camera.main;
		shootingStarsManager2._mainCamera = main;
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.ExplosionStars);
		shootingStarsManager2._explosionStarsPool = pool;
		ShootingStarsManager2 shootingStarsManager3 = _diContainer.Instantiate<ShootingStarsManager2>();
		_shootingStarsManager2 = shootingStarsManager3;
		ShootingStarsManager2 shootingStarsManager4 = _shootingStarsManager2;
		Camera main2 = Camera.main;
		shootingStarsManager4._mainCamera = main2;
		ObjectPool pool2 = HeroVfxManager._factory.GetPool(HeroVfxType.ExplosionStars2);
		shootingStarsManager4._explosionStarsPool = pool2;
		RandomEventId = 0;
		List<EventTargetInstace> eventTargets = _eventTargets;
		int version = eventTargets._version + 1;
		eventTargets._version = version;
		eventTargets._size = 0;
		if (eventTargets._size > 0)
		{
			Array.Clear(eventTargets._items, 0, eventTargets._size);
		}
		DebugAddConsoleCommands();
	}

	public void DisableStageEvents()
	{
		_stageEventsDisabled = true;
	}

	public bool TriggerEvent(VampireSurvivors.Data.Stage.Event stageDataEvent, bool fromTrisection = false)
	{
		//IL_023c: Expected I, but got O
		//IL_00ec: Invalid comparison between F4 and I4
		//IL_02a9: Expected I, but got O
		//IL_01db: Expected I4, but got F4
		//IL_030e: Expected I, but got O
		_003C_003Ec__DisplayClass40_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass40_0();
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		CS_0024_003C_003E8__locals13.stageDataEvent = stageDataEvent;
		bool fromTrisection2 = default(bool);
		CS_0024_003C_003E8__locals13.fromTrisection = fromTrisection2;
		if (!_stageEventsDisabled)
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			VampireSurvivors.Data.Stage.Event stageDataEvent2 = CS_0024_003C_003E8__locals13.stageDataEvent;
			if (mainCharacters._size >= stageDataEvent2._003CminPlayersNeeded_003Ek__BackingField)
			{
				VampireSurvivors.Data.Stage.Event stageDataEvent3 = CS_0024_003C_003E8__locals13.stageDataEvent;
				StageEventType stageEventType = Enum.Parse<StageEventType>(stageDataEvent3._003CeventType_003Ek__BackingField);
				VampireSurvivors.Data.Stage.Event stageDataEvent4 = CS_0024_003C_003E8__locals13.stageDataEvent;
				CS_0024_003C_003E8__locals13.stageEventType = stageEventType;
				int num = default(int);
				object obj = default(object);
				float num2 = default(float);
				bool flag = default(bool);
				if (!(stageDataEvent4._003Cdelay_003Ek__BackingField > 0f))
				{
					return TriggerSwitchEvent(stageEventType, stageDataEvent4._003Cchance_003Ek__BackingField, stageDataEvent4._003Cduration_003Ek__BackingField, num, obj, num2, flag);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				string message = $"TriggerEvent - Type: {stageDataEvent4._003CeventType_003Ek__BackingField}, Delay: {arg}, Repeat: {arg2}";
				Debug.Log(message);
				Action onComplete = delegate
				{
					StageEventManager stageEventManager = CS_0024_003C_003E8__locals13._003C_003E4__this;
					VampireSurvivors.Data.Stage.Event stageDataEvent6 = CS_0024_003C_003E8__locals13.stageDataEvent;
					if (!stageEventManager._stageEventsDisabled)
					{
						string message2 = "EventTriggered: " + stageDataEvent6._003CeventType_003Ek__BackingField;
						Debug.Log(message2);
						VampireSurvivors.Data.Stage.Event stageDataEvent7 = CS_0024_003C_003E8__locals13.stageDataEvent;
						int moreX = default(int);
						object moreY = default(object);
						float moreZ = default(float);
						bool fromTrisection3 = default(bool);
						bool flag2 = CS_0024_003C_003E8__locals13._003C_003E4__this.TriggerSwitchEvent(CS_0024_003C_003E8__locals13.stageEventType, stageDataEvent7._003Cchance_003Ek__BackingField, stageDataEvent7._003Cduration_003Ek__BackingField, moreX, moreY, moreZ, fromTrisection3);
					}
					else
					{
						string message3 = "Not triggering queued event " + stageDataEvent6._003CeventType_003Ek__BackingField + " because stage events are disabled";
						Debug.Log(message3);
					}
				};
				float duration = stageDataEvent4._003Cdelay_003Ek__BackingField * 0.001f;
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)num != 0, (MonoBehaviour)obj, (int)num2, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
				return false;
			}
			object[] array = new object[3];
			VampireSurvivors.Data.Stage.Event stageDataEvent5 = CS_0024_003C_003E8__locals13.stageDataEvent;
			if (stageDataEvent5._003CeventType_003Ek__BackingField != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				nint num4 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj5 = default(object);
			if (obj5 != null)
			{
				nint num5 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Debug.LogFormat("Stage Data Event {0} skipped because player count of {1} is less than minPlayersNeeded of {2}", array);
			return false;
		}
		return true;
	}

	public void InternalUpdate()
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_01e1: Invalid comparison between F4 and I4
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected I4, but got Unknown
		//IL_0cab: Invalid comparison between F4 and I4
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected I4, but got Unknown
		//IL_022d: Expected F4, but got I4
		//IL_0cdb: Expected O, but got F8
		//IL_0ce8: Expected O, but got F8
		//IL_0d0d: Invalid comparison between F4 and I4
		//IL_0d1c: Invalid comparison between F4 and I4
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected I4, but got Unknown
		//IL_02b6: Expected F4, but got I4
		//IL_0d82: Expected O, but got I4
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected I4, but got Unknown
		//IL_0301: Expected O, but got I4
		//IL_030f: Expected O, but got I4
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0dc8: Expected O, but got I4
		//IL_0dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd5: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected I4, but got Unknown
		//IL_03ef: Expected O, but got I8
		//IL_0401: Expected O, but got I8
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_0e1d: Expected O, but got I4
		//IL_0e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2a: Expected O, but got Unknown
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected I4, but got Unknown
		//IL_04a3: Expected O, but got I8
		//IL_04b5: Expected O, but got I8
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Expected O, but got Unknown
		//IL_047a: Expected F8, but got I4
		//IL_0e5b: Expected O, but got I4
		//IL_0e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e68: Expected O, but got Unknown
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Expected I4, but got Unknown
		//IL_0599: Expected O, but got I8
		//IL_05ab: Expected O, but got I8
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_0611: Expected F8, but got I4
		//IL_0e8c: Invalid comparison between F8 and I4
		//IL_0e9e: Expected F8, but got I4
		//IL_0679: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected I4, but got Unknown
		//IL_06d4: Expected O, but got F8
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Expected O, but got Unknown
		//IL_06f9: Invalid comparison between F8 and I4
		//IL_0708: Invalid comparison between F8 and I4
		//IL_0717: Invalid comparison between F8 and I4
		//IL_0747: Expected F8, but got I4
		//IL_0f78: Expected O, but got I4
		//IL_0f80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f85: Expected O, but got Unknown
		//IL_077f: Expected O, but got I4
		//IL_0787: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Expected O, but got Unknown
		//IL_0ee2: Expected O, but got F8
		//IL_0eef: Expected O, but got F8
		//IL_0f14: Invalid comparison between F8 and I4
		//IL_0f23: Invalid comparison between F8 and I4
		//IL_07bd: Expected O, but got I4
		//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Expected O, but got Unknown
		//IL_0a44: Invalid comparison between F8 and I
		//IL_0803: Expected O, but got I4
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_0a6b: Expected O, but got I
		//IL_0874: Invalid comparison between F8 and I
		//IL_089b: Expected O, but got I
		//IL_0b01: Invalid comparison between I and F8
		//IL_0bb1: Invalid comparison between F8 and I
		//IL_0c08: Expected O, but got I4
		//IL_0b46: Invalid comparison between I and F8
		//IL_09b0: Expected O, but got I
		//IL_09df: Expected O, but got I4
		if (_shootingStarsManager != null)
		{
			_shootingStarsManager.InternalUpdate();
		}
		_shootingStarsManager2.InternalUpdate();
		if (!_playDiamondActive)
		{
			return;
		}
		List<List<int>> playDiamondGrid = _playDiamondGrid;
		if (playDiamondGrid._size <= 0)
		{
			goto IL_0c59;
		}
		List<int>[] items = playDiamondGrid._items;
		List<int> list = items[0];
		List<List<int>> playDiamondGrid2 = _playDiamondGrid;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
		double num = 0.0 - 1.0;
		double num2 = (double)playDiamondGrid2._size - 1.0;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj = position - _playDiamondGridStartX;
		float num3 = (float)obj / 0.32f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		object obj3 = default(object);
		object obj2 = obj3 - _playDiamondGridStartY;
		float num4 = (float)obj2 / 0.32f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E6CCF4h\"");
		if (_playDiamondPlayerAtGridPrevX == num3)
		{
			bool flag = _playDiamondPlayerAtGridPrevY == num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E6CCF4h\"");
			if (flag)
			{
				return;
			}
		}
		_playDiamondPlayerAtGridPrevX = num3;
		_playDiamondPlayerAtGridPrevY = num4;
		float num5 = num3 - 15f;
		bool flag2 = default(bool);
		if (!(num5 > 0f))
		{
			flag2 = (byte)(num5 & -2147483649L) != 0;
			if ((flag2 ? 1 : 0) <= 2139095040)
			{
				num5 = 0f;
			}
		}
		double a;
		bool flag4;
		if (!(num > (double)num5))
		{
			flag2 = (byte)(num5 & -2147483649L) != 0;
			bool flag3 = (flag2 ? 1 : 0) <= 2139095040;
			a = num;
			flag4 = flag2;
			if (flag3)
			{
				goto IL_0c7b;
			}
		}
		a = num5;
		flag4 = flag2;
		goto IL_0c7b;
		IL_0de3:
		double a2;
		double num6 = Math.Round(a2);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm6\"");
		bool flag6;
		bool flag7;
		bool flag5 = flag6 == flag7;
		bool flag8;
		object obj4 = !flag8;
		object obj5 = flag5 & obj4;
		bool flag9;
		double num7;
		double num8;
		bool flag11;
		bool flag12;
		bool flag13;
		bool flag14;
		if (obj5 == null)
		{
			flag9 = (byte)(num7 & 0x7FFFFFFFFFFFFFFFL) != 0;
			object obj6 = (flag9 ? 1 : 0) - 9218868437227405312L;
			object obj7 = (flag9 ? 1 : 0) ^ 0x7FF0000000000000L;
			object obj8 = flag9 ^ obj6;
			object obj9 = obj7 & obj8;
			flag7 = (nint)obj9 < 0;
			flag6 = (nint)obj6 < 0;
			flag8 = obj6 == null;
			bool flag10 = (flag9 ? 1 : 0) <= 9218868437227405312L;
			num8 = 0.0;
			flag11 = flag9;
			flag12 = flag8;
			flag13 = flag6;
			flag14 = flag7;
			if (flag10)
			{
				goto IL_0e38;
			}
		}
		num8 = num7;
		flag11 = flag9;
		flag12 = flag8;
		flag13 = flag6;
		flag14 = flag7;
		goto IL_0e38;
		IL_0e38:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm6\"");
		bool flag15 = flag13 == flag14;
		object obj10 = !flag12;
		object obj11 = flag15 & obj10;
		double a3;
		bool flag17;
		if (obj11 == null)
		{
			flag11 = (byte)(num8 & 0x7FFFFFFFFFFFFFFFL) != 0;
			bool flag16 = (flag11 ? 1 : 0) <= 9218868437227405312L;
			a3 = num2;
			flag17 = flag11;
			if (flag16)
			{
				goto IL_0e76;
			}
		}
		a3 = num8;
		flag17 = flag11;
		goto IL_0e76;
		IL_0d3e:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
		double a4;
		num7 = Math.Round(a4);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm1,xmm6\"");
		bool flag19;
		bool flag20;
		bool flag18 = flag19 == flag20;
		bool flag21;
		object obj12 = !flag21;
		object obj13 = flag18 & obj12;
		double num10;
		double num9 = num10;
		bool flag22;
		if (obj13 == null)
		{
			flag22 = (byte)(num10 & 0x7FFFFFFFFFFFFFFFL) != 0;
			object obj14 = (flag22 ? 1 : 0) - 9218868437227405312L;
			object obj15 = (flag22 ? 1 : 0) ^ 0x7FF0000000000000L;
			object obj16 = flag22 ^ obj14;
			object obj17 = obj15 & obj16;
			flag20 = (nint)obj17 < 0;
			flag19 = (nint)obj14 < 0;
			flag21 = obj14 == null;
			bool flag23 = (flag22 ? 1 : 0) > 9218868437227405312L;
			num9 = num10;
			if (!flag23)
			{
				num9 = 0.0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag24 = flag19 == flag20;
		object obj18 = !flag21;
		object obj19 = flag24 & obj18;
		if (obj19 == null)
		{
			flag22 = (byte)(num9 & 0x7FFFFFFFFFFFFFFFL) != 0;
			object obj20 = (flag22 ? 1 : 0) - 9218868437227405312L;
			object obj21 = (flag22 ? 1 : 0) ^ 0x7FF0000000000000L;
			object obj22 = flag22 ^ obj20;
			object obj23 = obj21 & obj22;
			flag20 = (nint)obj23 < 0;
			flag19 = (nint)obj20 < 0;
			flag21 = obj20 == null;
			bool flag25 = (flag22 ? 1 : 0) <= 9218868437227405312L;
			a2 = num;
			flag9 = flag22;
			flag8 = flag21;
			flag6 = flag19;
			flag7 = flag20;
			if (flag25)
			{
				goto IL_0de3;
			}
		}
		a2 = num9;
		flag9 = flag22;
		flag8 = flag21;
		flag6 = flag19;
		flag7 = flag20;
		goto IL_0de3;
		IL_0c59:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_0e76:
		double num11 = Math.Round(a3);
		bool flag26 = !(num2 > 0.0);
		double num12 = 0.0;
		double num13 = num7;
		if (flag26)
		{
			return;
		}
		object obj27 = default(object);
		IntPtr intPtr = default(IntPtr);
		double num20 = default(double);
		UnityEngine.Object obj38 = default(UnityEngine.Object);
		object obj26 = default(object);
		object obj39 = default(object);
		while (true)
		{
			object obj24 = num ^ num;
			object obj25 = num & obj24;
			bool flag27 = (nint)obj25 < 0;
			bool flag28 = num < 0.0;
			bool flag29 = num == 0.0;
			if (num > 0.0)
			{
				obj26 = obj26;
				obj27 = obj27;
				double num14 = 0.0;
				double num15 = num13;
				double num16 = num11;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm8,xmm6\"");
					bool flag30 = flag28 == flag27;
					object obj28 = !flag29;
					object obj29 = flag30 & obj28;
					if (obj29 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm7\"");
						bool flag31 = flag28 == flag27;
						object obj30 = !flag29;
						object obj31 = flag31 & obj30;
						if (obj31 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm10,xmm0\"");
							bool flag32 = flag28 == flag27;
							object obj32 = !flag29;
							object obj33 = flag32 & obj32;
							num16 = num14;
							if (obj33 == null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm9\"");
								bool flag33 = flag28 == flag27;
								object obj34 = !flag29;
								object obj35 = flag33 & obj34;
								num16 = num14;
								if (obj35 == null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
									num16 = num14;
									if (!flag17)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										double num17 = num14;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v54+18]");
										if (!(num17 < 0.0))
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v54+10]");
										object obj36 = 0;
										_ = 4294967295L;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v54+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										float num18 = (float)num12 * 0.32f;
										num15 = (double)num18 + (double)_playDiamondGridStartY;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F8B0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										_ = _playDiamondDuration;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										obj26 = (nint)intPtr;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ r8_v9+598] (should have been resolved before IL gen)");
										int num19 = _003CSpawned_003Ek__BackingField + 1;
										_003CSpawned_003Ek__BackingField = num19;
										obj27 = 0;
										num16 = num20;
									}
									goto IL_0eb6;
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
					if ((flag17 ? 1 : 0) == -1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						double num21 = num14;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v35+18]");
						if (!(num21 < 0.0))
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v35+10]");
						object obj37 = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rax_v35+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						flag17 = obj38;
						if (flag17)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v42+274]");
							if (0.0 == num14)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rax_v47+278]");
								if (0.0 == num12)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									obj26 = obj39;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ r8_v9+398] (should have been resolved before IL gen)");
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							double num22 = num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v44 (UnityEngine.Object)+18]");
							if (!(num22 < 0.0))
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v44 (UnityEngine.Object)+1C]");
							_ = (nint)0 + (nint)1;
							int num23 = _003CSpawned_003Ek__BackingField - 1;
							_003CSpawned_003Ek__BackingField = num23;
							obj26 = 0;
						}
					}
					goto IL_0eb6;
					IL_0eb6:
					num14++;
					double num24 = num14 - num;
					object obj40 = num14 ^ num;
					object obj41 = num14 ^ num24;
					object obj42 = obj40 & obj41;
					flag27 = (nint)obj42 < 0;
					flag28 = num24 < 0.0;
					flag29 = num24 == 0.0;
					bool flag34 = num14 < num;
					num13 = num15;
					num11 = num16;
					if (flag34)
					{
						continue;
					}
					goto IL_0c0d;
				}
				break;
			}
			goto IL_0c0d;
			IL_0c0d:
			num12++;
			if (!(num12 < num2))
			{
				return;
			}
		}
		goto IL_0c59;
		IL_0c7b:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
		num10 = Math.Round(a);
		float num25 = num4 - 15f;
		float num26;
		bool flag36;
		if (!(num25 > 0f))
		{
			flag4 = (byte)(num25 & -2147483649L) != 0;
			bool flag35 = (flag4 ? 1 : 0) <= 2139095040;
			num26 = 0f;
			flag36 = flag4;
			if (flag35)
			{
				goto IL_0cbf;
			}
		}
		num26 = num25;
		flag36 = flag4;
		goto IL_0cbf;
		IL_0cbf:
		float num27 = (float)num2 - num26;
		object obj43 = num2 ^ (double)num26;
		object obj44 = num2 ^ (double)num27;
		object obj45 = obj43 & obj44;
		bool flag37 = (nint)obj45 < 0;
		bool flag38 = num27 < 0f;
		bool flag39 = num27 == 0f;
		if (!(num2 > (double)num26))
		{
			flag36 = (byte)(num26 & -2147483649L) != 0;
			object obj46 = (flag36 ? 1 : 0) - 2139095040;
			object obj47 = (flag36 ? 1 : 0) ^ 0x7F800000;
			object obj48 = flag36 ^ obj46;
			object obj49 = obj47 & obj48;
			flag37 = (nint)obj49 < 0;
			flag38 = (nint)obj46 < 0;
			flag39 = obj46 == null;
			bool flag40 = (flag36 ? 1 : 0) <= 2139095040;
			a4 = num2;
			flag22 = flag36;
			flag21 = flag39;
			flag19 = flag38;
			flag20 = flag37;
			if (flag40)
			{
				goto IL_0d3e;
			}
		}
		a4 = num26;
		flag22 = flag36;
		flag21 = flag39;
		flag19 = flag38;
		flag20 = flag37;
		goto IL_0d3e;
	}

	public void PlaySwarm(float duration, int moreX, EnemyType moreY, float moreZ = 0.9f)
	{
		float moreZ2 = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration, moreX, moreY, moreZ2, rndDiv);
	}

	public void PlayDiamond_RandomPattern(float? duration, int moreX = 0, EnemyType? moreY = null, float moreZ = 0f)
	{
		//IL_005e: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_0151: Expected O, but got I4
		//IL_010c: Expected O, but got I
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0192: Expected O, but got I
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_021b: Expected F4, but got O
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num;
		float? num2;
		if ((object)duration == null)
		{
			num = 60000f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = duration;
		}
		PlayDiamond_RandomPatternClear();
		PatternGenerator patternGenerator = new PatternGenerator();
		List<List<EnemyDiamond>> playDiamondEnemyGrid = new List<List<EnemyDiamond>>();
		_playDiamondEnemyGrid = playDiamondEnemyGrid;
		object obj = 0;
		List<object> list3 = default(List<object>);
		do
		{
			List<object> playDiamondEnemyGrid2 = (List<object>)(object)_playDiamondEnemyGrid;
			List<EnemyDiamond> list = new List<EnemyDiamond>();
			int version = playDiamondEnemyGrid2._version + 1;
			playDiamondEnemyGrid2._version = version;
			object[] items = playDiamondEnemyGrid2._items;
			if (playDiamondEnemyGrid2._size >= items.Length)
			{
				playDiamondEnemyGrid2.AddWithResize((object)list);
				List<EnemyDiamond> list2 = (List<EnemyDiamond>)0;
			}
			else
			{
				int size = playDiamondEnemyGrid2._size + 1;
				playDiamondEnemyGrid2._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				List<EnemyDiamond> list2 = list;
			}
			object obj2 = 0;
			bool flag;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				list3.Add(null);
				obj2++;
				flag = (nint)obj2 < 100;
				List<EnemyDiamond> list2 = (List<EnemyDiamond>)0;
			}
			while (flag);
			obj++;
		}
		while ((nint)obj < 100);
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [188A10890h]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [188A10890h]\"");
		_playDiamondGridStartX = (float)position;
		float playDiamondGridStartY = default(float);
		_playDiamondGridStartY = playDiamondGridStartY;
		List<List<int>> playDiamondGrid = patternGenerator.generateGrid(100, 100);
		_playDiamondGrid = playDiamondGrid;
		_playDiamond_enemyType = moreY;
		_playDiamondActive = true;
		if ((object)num2 != null)
		{
			_playDiamondDuration = num;
			Action onComplete = PlayDiamond_RandomPatternClear;
			float duration2 = num * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer playDiamondDisappearTimer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_playDiamondDisappearTimer = playDiamondDisappearTimer;
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	public void PlayDiamond_RandomPatternClear()
	{
		//IL_0047: Expected O, but got I4
		//IL_0050: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_022a: Expected O, but got I4
		_playDiamondActive = false;
		_playDiamondPlayerAtGridPrevX = -1f;
		_playDiamondPlayerAtGridPrevY = -1f;
		if (_playDiamondDisappearTimer != null)
		{
			_playDiamondDisappearTimer.Cancel();
		}
		if (_playDiamondEnemyGrid == null)
		{
			return;
		}
		List<List<EnemyDiamond>> playDiamondEnemyGrid = _playDiamondEnemyGrid;
		object obj = 0;
		object obj2 = 0;
		object obj5 = default(object);
		object obj7 = default(object);
		while ((nint)obj2 < playDiamondEnemyGrid._size)
		{
			object obj3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				playDiamondEnemyGrid = _playDiamondEnemyGrid;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v11+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				if (obj5 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v14+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v22+274]");
						object obj6;
						if (0 == (nint)obj3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v27+278]");
							if (0 == (nint)obj)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								obj6 = obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v244 @ r8_v7+388] (should have been resolved before IL gen)");
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						object obj8 = obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v24+18]");
						if ((nint)obj8 >= 0)
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v24+1C]");
						_ = (nint)0 + (nint)1;
						int num = _003CSpawned_003Ek__BackingField - 1;
						_003CSpawned_003Ek__BackingField = num;
						obj6 = 0;
					}
				}
				obj3++;
			}
			obj++;
			obj2 = obj;
		}
	}

	public void PlayDiamondConcrete(float? duration, float? moreX = null, float? moreY = null, EnemyType? moreZ = null)
	{
		//IL_000e: Expected O, but got I4
		//IL_01b2: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00db: Invalid comparison between F4 and O
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0106: Invalid comparison between F4 and O
		object obj = default(object);
		object obj2;
		EnemyType enemyType;
		if (obj == null)
		{
			obj2 = 1;
			enemyType = EnemyType.EX_DIAMOND;
		}
		else
		{
			obj2 = obj;
			EnemyType enemyType2 = default(EnemyType);
			enemyType = enemyType2;
		}
		if ((object)moreX == null)
		{
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 position = gameSessionData._activeCharacter.position;
		}
		if ((object)moreY == null)
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData2 = core2._gameSessionData;
			float2 position2 = gameSessionData2._activeCharacter.position;
		}
		object obj3 = 0;
		Vector2 spawnPos = default(Vector2);
		bool forceSpawn = default(bool);
		do
		{
			object obj4 = 0;
			do
			{
				if (obj2 != null)
				{
					GameObject gameObject = _ourStage.SpawnEnemy(enemyType, spawnPos, asRemote: false, forceSpawn);
					obj4++;
					continue;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)14f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4));
			obj3++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)14f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3));
	}

	private void Cleanup()
	{
		_003CSpawned_003Ek__BackingField = 0;
	}

	protected unsafe bool TriggerSwitchEvent(StageEventType eventType, float? chance, float? duration, int moreX, object moreY, float moreZ = 0f, bool fromTrisection = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00fd: Invalid comparison between I4 and F4
		//IL_010e: Expected F4, but got I4
		//IL_035b: Expected F4, but got I
		//IL_03ac: Expected O, but got I4
		//IL_029f: Expected O, but got Ref
		//IL_025f: Expected O, but got I8
		//IL_0279: Expected O, but got I8
		//IL_03fb: Invalid comparison between F4 and I
		//IL_0421: Invalid comparison between F4 and I4
		//IL_044a: Expected O, but got I4
		//IL_0218: Expected O, but got I
		//IL_0198: Expected O, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (eventType == StageEventType.ERASE_ENEMIES)
		{
			PlayEraseEnemies();
			return true;
		}
		if (eventType == StageEventType.CYCLE_COMPLETE)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (!config._003CSelectedReapers_003Ek__BackingField)
			{
				PlayEraseEnemies();
			}
			else
			{
				GameManager core = GM.Core;
				core._stage.OnCycleComplete();
			}
		}
		else
		{
			float num = default(float);
			if (eventType != StageEventType.STALKER && eventType != StageEventType.FB_BIGFUZZ_POINTER)
			{
				int enemiesCount = _ourStage.EnemiesCount;
				bool flag = !((float)enemiesCount < 500f);
				num = enemiesCount;
				if (flag)
				{
					goto IL_0227;
				}
			}
			GameSessionData gameSessionData = _gameSessionData;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
			bool flag2 = (object)gameSessionData._activeCharacter == null;
			float num2 = 1f;
			if (!flag2)
			{
				bool flag3 = ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0;
				num2 = 1f;
				if (!flag3)
				{
					GameSessionData gameSessionData2 = _gameSessionData;
					gameSessionData = (GameSessionData)gameSessionData2._activeCharacter.PLuck();
					num2 = num;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-4D]");
			float num3 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-4D]");
			bool flag4 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-4D]");
			bool flag5 = (nint)0 == 0;
			bool flag6 = !flag4;
			bool flag7 = !flag5;
			object obj3 = flag7 & flag6;
			object obj4 = (object?)chance & obj3;
			if (obj4 != null)
			{
				float value = UnityEngine.Random.value;
				if ((object)chance != null)
				{
					_ = 0;
					float num4 = 1f / num2;
					_ = 1;
					float num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-3D]");
					num3 = num5 * 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-51]");
					gameSessionData = (GameSessionData)0;
				}
				else
				{
					gameSessionData = null;
				}
				num = value * 100f;
				float num6 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-4D]");
				bool flag8 = num6 < 0f;
				float num7 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-4D]");
				float num8 = num7 - 0f;
				bool flag9 = num8 == 0f;
				bool flag10 = !flag8;
				bool flag11 = !flag9;
				object obj5 = flag11 & flag10;
				object obj6 = (object)gameSessionData & obj5;
				if (obj6 != null)
				{
					goto IL_0227;
				}
			}
			if (eventType <= StageEventType.GENERIC_BOMB_SPAWN)
			{
				object obj7 = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rdx_v11+6E6ED38+eventType @ rdx (VampireSurvivors.Data.StageEventType)*4]");
				object obj8 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v291 @ rcx_v22 (should have been resolved before IL gen)");
			}
			else
			{
				Enum obj9 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				_ = typeof(StageEventType);
				_ = -1;
				string text = obj9.ToString();
				string message = "StageEvent " + text + " has not been implemented yet.";
				Debug.LogWarning(message);
			}
		}
		return true;
		IL_0227:
		return false;
	}

	private static EnemyType ConvertToEnemyType(object moreY, EnemyType defaultEnemyType)
	{
		//IL_0013: Expected I, but got O
		//IL_01e3: Expected I4, but got O
		//IL_0057: Expected I, but got O
		if (moreY != null)
		{
			nint num = (nint)typeof(EnemyType);
			bool flag = (object)moreY.GetType() != typeof(EnemyType);
			object obj = null;
			if (!flag)
			{
				obj = moreY;
			}
			if (obj != null)
			{
				nint num2 = (nint)moreY;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rcx_v8 (Il2CppClass<System.Object>)+40]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v8 (Il2CppClass<VampireSurvivors.Data.EnemyType>)+40]");
				if (num3 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [moreY @ rcx (System.Object)+10]");
					return EnemyType.BAT1;
				}
				throw new InvalidCastException();
			}
		}
		if (moreY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag2 = moreY != null;
			object obj2 = null;
			if (!flag2)
			{
				obj2 = moreY;
			}
			if (obj2 == null)
			{
				InvalidCastException ex = new InvalidCastException();
				return (EnemyType)ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v10 (System.Object)+10]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				bool flag3 = moreY != null;
				object obj3 = null;
				if (!flag3)
				{
					obj3 = moreY;
				}
				if (obj3 != null)
				{
					return Enum.Parse<EnemyType>((string)obj3);
				}
				throw new InvalidCastException();
			}
		}
		return defaultEnemyType;
	}

	public int GetRandomId()
	{
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		return RandomEventId;
	}

	private void GenerateBoss(EnemyType enemyType = EnemyType.BATSWARM)
	{
		//IL_0083: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * ((float)Math.PI * 2f);
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		_ = RandomEventId;
		_ = 0;
	}

	private unsafe void GenerateEnemySwarm(float duration, int count, EnemyType enemyType = EnemyType.BATSWARM, float moreZ = 0.9f, float rndDiv = 500f)
	{
		//IL_02aa: Expected O, but got F4
		//IL_01f3: Expected I, but got O
		//IL_0209: Expected O, but got I
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_028d: Expected I, but got O
		//IL_0376: Expected O, but got I4
		//IL_039d: Expected I, but got I8
		//IL_0269: Expected I, but got I8
		_003C_003Ec__DisplayClass51_0 obj = new _003C_003Ec__DisplayClass51_0();
		obj._003C_003E4__this = this;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		float num = (float)obj3 * ((float)Math.PI * 2f);
		List<EnemyController> enemies = new List<EnemyController>();
		obj.enemies = enemies;
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		obj.eventId = RandomEventId;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		int num2 = default(int);
		if (num2 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v671 @ rax_v28 (UnityEngine.Bounds)+10]");
			float num3 = 0f * 2f;
			object obj4 = default(object);
			float num4 = (float)Math.PI / (float)obj4;
			object obj5 = default(object);
			float num5 = num3 * (float)obj5;
			EnemyType enemyType2 = enemyType;
			float num6 = duration;
			bool flag = false;
			Camera mainCamera = _mainCamera;
			List<EnemyController> list = null;
			object obj6 = default(object);
			int num7 = (int)(&obj6);
			EnemyController enemyController = default(EnemyController);
			bool flag2;
			float num13 = default(float);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num8 = num + num4;
				float num9 = num * 0.8f;
				float num10 = num9 * num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v26 (PhaserScene+Renderer)+38]");
				float num11 = 0f + num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
				list = obj.enemies;
				num7 = obj.eventId;
				InitEventEnemy(obj.eventId, enemyController, obj.enemies);
				int num12 = _003CSpawned_003Ek__BackingField + 1;
				_003CSpawned_003Ek__BackingField = num12;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag2 = (flag ? 1 : 0) < num2;
				enemyType2 = EnemyType.BAT1;
				num6 = num13;
				num = num8;
				mainCamera = (Camera)(object)enemyController;
			}
			while (flag2);
		}
		Action action = null;
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass51_0._003CGenerateEnemySwarm_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num15;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num15 = unchecked((nint)6447293664L);
				goto IL_036d;
			}
		}
		num15 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_036d;
		IL_036d:
		object obj9 = 24;
		float duration2 = duration * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void GenerateEnemyWall(float duration, int count = 100, EnemyType enemyType = EnemyType.FLOWER, float moreZ = 0.9f, float radiusMul = 0.8f, float rndDiv = 50f)
	{
		//IL_0372: Expected O, but got F4
		//IL_029c: Expected I, but got O
		//IL_02b2: Expected O, but got I
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_0336: Expected I, but got O
		//IL_049a: Expected O, but got I4
		//IL_04c1: Expected I, but got I8
		//IL_0181: Expected O, but got F4
		//IL_0312: Expected I, but got I8
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_048c->IL033c: Incompatible stack heights: 1 vs 0
		//IL_04f7->IL033b: Incompatible stack heights: 1 vs 0
		//IL_019d->IL033c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass52_0 obj = new _003C_003Ec__DisplayClass52_0();
		bool flag2 = default(bool);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					return;
				}
				object obj2 = UnityEngine.Random.value;
				object obj3 = default(object);
				float num = (float)obj3 * ((float)Math.PI * 2f);
				List<EnemyController> enemies = new List<EnemyController>();
				obj.enemies = enemies;
				int randomEventId = RandomEventId + 1;
				RandomEventId = randomEventId;
				obj.eventId = RandomEventId;
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
						int num2 = default(int);
						if (num2 <= 0)
						{
							goto IL_024e;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ rax_v34 (UnityEngine.Bounds)+10]");
						float num3 = 0f * 2f;
						object obj4 = default(object);
						float num4 = num3 * (float)obj4;
						float num5 = (float)num2 * 0.5f;
						float num6 = (float)Math.PI / num5;
						EnemyType enemyType2 = enemyType;
						float num7 = duration;
						List<EnemyController> list = null;
						Camera mainCamera = _mainCamera;
						List<EnemyController> list2 = null;
						object obj5 = default(object);
						int num8 = (int)(&obj5);
						object obj6 = default(object);
						object obj7 = default(object);
						float num13 = default(float);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							float num9 = num + num6;
							float num10 = num * (float)obj6;
							float num11 = num10 * num4;
							float num12 = (float)obj7 + num11;
							if ((object)_ourStage == null)
							{
								break;
							}
							GameObject gameObject = _ourStage.SpawnEnemy(enemyType, (Vector2)num13, asRemote: false, flag2);
							if ((object)gameObject == null)
							{
								break;
							}
							EnemyController component = gameObject.GetComponent<EnemyController>();
							list2 = obj.enemies;
							num8 = obj.eventId;
							InitEventEnemy(obj.eventId, component, obj.enemies);
							int num14 = _003CSpawned_003Ek__BackingField + 1;
							_003CSpawned_003Ek__BackingField = num14;
							list = (List<EnemyController>)(list + 1);
							bool flag3 = (nint)list < num2;
							enemyType2 = EnemyType.BAT1;
							num7 = num13;
							num = num9;
							mainCamera = (Camera)(object)component;
							if (flag3)
							{
								continue;
							}
							goto IL_024e;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0491:
		object obj8 = 24;
		float duration2 = duration * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_024e:
		action = null;
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass52_0._003CGenerateEnemyWall_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj9 = (nint)0 >> 4;
		object obj10 = obj9 & 1;
		nint num16;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num16 = unchecked((nint)6447293664L);
				goto IL_0491;
			}
		}
		num16 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0491;
	}

	private void GenerateEnemyCardinalSpawn(float duration, CardinalTypeEnum cardinalType = CardinalTypeEnum.Cardinal, EnemyType enemyType = EnemyType.BATSWARM, float moreZ = 0.9f, float rndDiv = 500f)
	{
		//IL_0080: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
		List<float2> list = new List<float2>();
		float2 item = default(float2);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		list.Add(item);
		List<float2> list2 = null;
		list2.Add((float2)0);
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		bool flag = cardinalType == CardinalTypeEnum.Cardinal;
		float num = default(float);
		float rndDiv2;
		List<float2> directions;
		if (!flag)
		{
			object obj = cardinalType - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					return;
				}
				SpawnCardinalDirections(list, enemyType, num);
				rndDiv2 = num;
			}
			else
			{
				rndDiv2 = num;
			}
			directions = list2;
		}
		else
		{
			rndDiv2 = num;
			directions = list;
		}
		SpawnCardinalDirections(directions, enemyType, rndDiv2);
	}

	private void SpawnCardinalDirections(List<float2> directions, EnemyType enemyType, float rndDiv = 500f)
	{
		//IL_0028: Expected O, but got I4
		//IL_0152: Expected O, but got F4
		//IL_0050: Expected O, but got I
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0143->IL003b: Incompatible stack heights: 1 vs 0
		//IL_0148->IL0148: Incompatible stack heights: 1 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [directions @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		bool flag = (nint)0 <= (nint)0;
		object obj = 0;
		StageEventManager stageEventManager = this;
		if (flag)
		{
			return;
		}
		object item = default(object);
		object obj5;
		do
		{
			object obj2 = UnityEngine.Random.value;
			List<EnemyController> list = new List<EnemyController>();
			RandomEventId++;
			object obj3 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [directions @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
			bool flag2 = (nint)obj3 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [directions @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
			_ = RandomEventId;
			_ = 0;
			int version = list._version + 1;
			list._version = version;
			stageEventManager = (StageEventManager)(object)list._items;
			if (list._size >= (nint)stageEventManager._playerOptions)
			{
				((List<object>)(object)list).AddWithResize(item);
				stageEventManager = (StageEventManager)(object)list;
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			obj++;
			obj5 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [directions @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.float2>)+18]");
		}
		while ((nint)obj5 < 0);
	}

	public void PlayCircle(float? duration, int moreX = 100, EnemyType moreY = EnemyType.FLOWER, float moreZ = 0.9f)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 60000f);
		float moreZ2 = default(float);
		float radiusMul = default(float);
		float rndDiv = default(float);
		GenerateEnemyWall(duration2, moreX, moreY, moreZ2, radiusMul, rndDiv);
	}

	private void PlayJellyfish(float? duration, int moreX = 80, EnemyType moreY = EnemyType.JELLYFISH)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 60000f);
		float moreZ = default(float);
		float radiusMul = default(float);
		float rndDiv = default(float);
		GenerateEnemyWall(duration2, moreX, moreY, moreZ, radiusMul, rndDiv);
	}

	private void PlayBatSwarm(float? duration)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, 50, EnemyType.BATSWARM, moreZ, rndDiv);
	}

	private void PlayGhostSwarm(float? duration)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, 20, EnemyType.GHOSTSWARM, moreZ, rndDiv);
	}

	public unsafe void PlayMedusaSwarm(float? duration, int moreX = 1, EnemyType enemyType = EnemyType.MEDUSA1)
	{
		//IL_006d: Expected O, but got I4
		//IL_02aa: Expected O, but got F4
		//IL_02b3: Invalid comparison between F4 and O
		//IL_01a6: Expected I, but got O
		//IL_01bc: Expected O, but got I
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_0240: Expected I, but got O
		//IL_02f3: Expected O, but got I4
		//IL_031a: Expected I, but got I8
		//IL_021c: Expected I, but got I8
		//IL_0350->IL0245: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass60_0 obj = new _003C_003Ec__DisplayClass60_0();
		obj._003C_003E4__this = this;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num;
		float? num2;
		if ((object)duration == null)
		{
			num = 15000f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = duration;
		}
		List<EnemyController> enemies = new List<EnemyController>();
		obj.enemies = enemies;
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		obj.eventId = RandomEventId;
		object obj2 = UnityEngine.Random.value;
		object obj3 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
		}
		int num4 = default(int);
		bool flag2 = default(bool);
		if (num4 > 0)
		{
			bool flag = false;
			Vector2 spawnPos = default(Vector2);
			do
			{
				GameObject gameObject = _ourStage.SpawnEnemy(enemyType, spawnPos, asRemote: false, flag2);
				EnemyController component = gameObject.GetComponent<EnemyController>();
				InitEventEnemy(obj.eventId, component, obj.enemies);
				int num5 = _003CSpawned_003Ek__BackingField + 1;
				_003CSpawned_003Ek__BackingField = num5;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((flag ? 1 : 0) < num4);
		}
		bool flag3 = (object)num2 == null;
		Action action = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass60_0._003CPlayMedusaSwarm_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj4 = (nint)0 >> 4;
		object obj5 = obj4 & 1;
		nint num7;
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num7 = unchecked((nint)6447293664L);
				goto IL_02ea;
			}
		}
		num7 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_02ea;
		IL_02ea:
		object obj6 = 24;
		float duration2 = num * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void PlayVerticalSwarm(float? duration, int moreX = 1, EnemyType enemyType = EnemyType.XLSWORDIAN_V)
	{
		//IL_006d: Expected O, but got I4
		//IL_01ca: Expected I, but got O
		//IL_01e0: Expected O, but got I
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0264: Expected I, but got O
		//IL_02ce: Expected O, but got I4
		//IL_02f5: Expected I, but got I8
		//IL_0240: Expected I, but got I8
		_003C_003Ec__DisplayClass61_0 obj = new _003C_003Ec__DisplayClass61_0();
		obj._003C_003E4__this = this;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num;
		float? num2;
		if ((object)duration == null)
		{
			num = 15000f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = duration;
		}
		List<EnemyController> enemies = new List<EnemyController>();
		obj.enemies = enemies;
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		obj.eventId = RandomEventId;
		bool flag2 = default(bool);
		if (moreX > 0)
		{
			bool flag = false;
			Vector2 spawnPos = default(Vector2);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
				GameObject gameObject = _ourStage.SpawnEnemy(enemyType, spawnPos, asRemote: false, flag2);
				EnemyController component = gameObject.GetComponent<EnemyController>();
				InitEventEnemy(obj.eventId, component, obj.enemies);
				int num4 = _003CSpawned_003Ek__BackingField + 1;
				_003CSpawned_003Ek__BackingField = num4;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((flag ? 1 : 0) < moreX);
		}
		Action action;
		if ((object)num2 != null)
		{
			action = null;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass61_0._003CPlayVerticalSwarm_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num6;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num6 = unchecked((nint)6447293664L);
					goto IL_02c5;
				}
			}
			num6 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_02c5;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_02c5:
		object obj4 = 24;
		float duration2 = num * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void PlayMedusaWall(float? duration, int moreX = 1, EnemyType enemyType = EnemyType.MEDUSA1)
	{
		//IL_0101: Expected O, but got I4
		//IL_01ca: Expected O, but got I
		//IL_033a: Expected I, but got O
		//IL_0350: Expected O, but got I
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_03d4: Expected I, but got O
		//IL_0444: Expected O, but got I4
		//IL_046b: Expected I, but got I8
		//IL_03b0: Expected I, but got I8
		_003C_003Ec__DisplayClass62_0 obj = new _003C_003Ec__DisplayClass62_0();
		obj._003C_003E4__this = this;
		Stage ourStage = _ourStage;
		if (ourStage._enemySpawnLocations == null)
		{
			return;
		}
		List<Vector2> enemySpawnLocations = ourStage._enemySpawnLocations;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v11 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 == 0 || !GM.Core.IsStageHost)
		{
			return;
		}
		Stage ourStage2 = _ourStage;
		float num;
		float? num2;
		bool flag3 = default(bool);
		if (ourStage2._hasTileSet)
		{
			if ((object)duration == null)
			{
				num = 15000f;
				num2 = (float?)(object)1;
			}
			else
			{
				float num3 = default(float);
				num = num3;
				num2 = duration;
			}
			List<EnemyController> enemies = new List<EnemyController>();
			obj.enemies = enemies;
			int randomId = GetRandomId();
			obj.eventId = randomId;
			GameSessionData gameSessionData = _gameSessionData;
			Transform transform = gameSessionData._activeCharacter.transform;
			Vector3 position = transform.position;
			float value = UnityEngine.Random.value;
			Stage ourStage3 = _ourStage;
			if (0.5f > value)
			{
			}
			List<Vector2> enemySpawnLocations2 = ourStage3._enemySpawnLocations;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v23 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj2 = -1;
			bool flag = moreX <= 0;
			bool flag2 = false;
			if (flag)
			{
				goto IL_02cf;
			}
			Vector2 spawnPos = default(Vector2);
			while (true)
			{
				Stage ourStage4 = _ourStage;
				List<Vector2> enemySpawnLocations3 = ourStage4._enemySpawnLocations;
				object obj3 = flag2 % obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v26 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				GameObject gameObject = _ourStage.SpawnEnemy(enemyType, spawnPos, asRemote: false, flag3);
				EnemyController component = gameObject.GetComponent<EnemyController>();
				InitEventEnemy(obj.eventId, component, obj.enemies);
				int num4 = _003CSpawned_003Ek__BackingField + 1;
				_003CSpawned_003Ek__BackingField = num4;
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				if ((flag2 ? 1 : 0) < moreX)
				{
					continue;
				}
				goto IL_02cf;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			goto IL_0435;
		}
		PlayMedusaSwarm(duration, moreX, enemyType);
		return;
		IL_043b:
		object obj4 = 24;
		float duration2 = num * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_02cf:
		if ((object)num2 == null)
		{
			goto IL_0435;
		}
		action = null;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass62_0._003CPlayMedusaWall_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		nint num6;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num6 = unchecked((nint)6447293664L);
				goto IL_043b;
			}
		}
		num6 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_043b;
		IL_0435:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private void PlaySkullSwarm(float? duration, int moreX = 1, EnemyType moreY = EnemyType.SKULL2_SWARM)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 15000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, moreX, moreY, moreZ, rndDiv);
	}

	private unsafe void PlayPileAssault(float? duration, int moreX = 50, EnemyType enemyType = EnemyType.PILE1, float moreZ = 0.7f)
	{
		//IL_008b: Expected O, but got I4
		//IL_0511: Expected O, but got F4
		//IL_02dd: Expected I, but got O
		//IL_02f3: Expected O, but got I
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_0377: Expected I, but got O
		//IL_04ab: Expected O, but got I4
		//IL_04d2: Expected I, but got I8
		//IL_0353: Expected I, but got I8
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_049d->IL037d: Incompatible stack heights: 1 vs 0
		//IL_0508->IL037c: Incompatible stack heights: 2 vs 0
		//IL_01cd->IL037d: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass64_0 obj = new _003C_003Ec__DisplayClass64_0();
		float num;
		float? num2;
		bool flag2 = default(bool);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					return;
				}
				if ((object)duration == null)
				{
					num = 30000f;
					num2 = (float?)(object)1;
				}
				else
				{
					float num3 = default(float);
					num = num3;
					num2 = duration;
				}
				object obj2 = UnityEngine.Random.value;
				object obj3 = default(object);
				float num4 = (float)obj3 * ((float)Math.PI * 2f);
				int num6 = default(int);
				float num5 = (float)num6 * 0.5f;
				List<EnemyController> enemies = new List<EnemyController>();
				obj.enemies = enemies;
				int randomEventId = RandomEventId + 1;
				RandomEventId = randomEventId;
				obj.eventId = RandomEventId;
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
						if (num6 <= 0)
						{
							goto IL_0276;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v36 (UnityEngine.Bounds)+10]");
						float num7 = 0f * 2f;
						float num8 = num7 * 0.9f;
						float num9 = (float)Math.PI / num5;
						EnemyType enemyType2 = enemyType;
						List<EnemyController> list = null;
						Camera mainCamera = _mainCamera;
						List<EnemyController> list2 = null;
						object obj4 = default(object);
						int num10 = (int)(&obj4);
						object obj5 = default(object);
						object obj6 = default(object);
						Vector2 spawnPos = default(Vector2);
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							float num11 = num4 + num9;
							float num12 = num4 * (float)obj5;
							float num13 = num12 * num8;
							float num14 = (float)obj6 + num13;
							if ((object)_ourStage == null)
							{
								break;
							}
							GameObject gameObject = _ourStage.SpawnEnemy(enemyType, spawnPos, asRemote: false, flag2);
							if ((object)gameObject == null)
							{
								break;
							}
							EnemyController component = gameObject.GetComponent<EnemyController>();
							list2 = obj.enemies;
							num10 = obj.eventId;
							InitEventEnemy(obj.eventId, component, obj.enemies);
							int num15 = _003CSpawned_003Ek__BackingField + 1;
							_003CSpawned_003Ek__BackingField = num15;
							list = (List<EnemyController>)(list + 1);
							bool flag3 = (nint)list < num6;
							enemyType2 = EnemyType.BAT1;
							num4 = num11;
							mainCamera = (Camera)(object)component;
							if (flag3)
							{
								continue;
							}
							goto IL_0276;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_04a2:
		object obj7 = 24;
		float duration2 = num * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0276:
		bool flag4 = (object)num2 == null;
		action = null;
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass64_0._003CPlayPileAssault_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		nint num17;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num17 = unchecked((nint)6447293664L);
				goto IL_04a2;
			}
		}
		num17 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_04a2;
	}

	private void PlayMinoRush(float? duration, int moreX = 50)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, moreX, EnemyType.MIGNO_3_5SWARM, moreZ, rndDiv);
	}

	private void PlayJellySwarm(float? duration, int moreX = 50)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, moreX, EnemyType.JELLYFISH2_SWARM, moreZ, rndDiv);
	}

	private void PlayEctoSwarm(float? duration, int moreX = 50)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, moreX, EnemyType.ECTO2, moreZ, rndDiv);
	}

	private void PlayGenericBoss(object moreY)
	{
		EnemyType enemyType = ConvertToEnemyType(moreY, EnemyType.BATSWARM);
		GenerateBoss(enemyType);
	}

	private void PlayGenericSwarm(float? duration, int moreX, object moreY)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		EnemyType enemyType = ConvertToEnemyType(moreY, EnemyType.BATSWARM);
		bool flag = moreX == 0;
		int count = 50;
		if (!flag)
		{
			count = moreX;
		}
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, count, enemyType, moreZ, rndDiv);
	}

	private void PlayGenericCardinalSpawn(float? duration, int moreX, object moreY)
	{
		//IL_0017: Expected O, but got I4
		float duration2;
		float? num;
		if ((object)duration == null)
		{
			duration2 = 10000f;
			num = (float?)(object)1;
		}
		else
		{
			float num2 = default(float);
			duration2 = num2;
			num = duration;
		}
		int cardinalType;
		if (moreX != 1)
		{
			bool flag = moreX != 2;
			cardinalType = 0;
			if (!flag)
			{
				cardinalType = moreX;
			}
		}
		else
		{
			cardinalType = 1;
		}
		if ((object)num != null)
		{
			EnemyType enemyType = ConvertToEnemyType(moreY, EnemyType.BATSWARM);
			float moreZ = default(float);
			float rndDiv = default(float);
			GenerateEnemyCardinalSpawn(duration2, (CardinalTypeEnum)cardinalType, enemyType, moreZ, rndDiv);
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	private unsafe void PlayDragonStream(float? duration, int moreX = 12, EnemyType moreY = EnemyType.XLDRAGON1_FLAG, float moreZ = 4f)
	{
		//IL_008c: Expected O, but got I4
		//IL_0328: Expected I, but got O
		//IL_0391: Expected O, but got I
		//IL_03a9: Invalid comparison between F4 and I4
		//IL_021b: Expected I, but got O
		//IL_0231: Expected O, but got I
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0143: Expected O, but got I4
		//IL_02b5: Expected I, but got O
		//IL_0463: Expected O, but got I4
		//IL_048a: Expected I, but got I8
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_0291: Expected I, but got I8
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected I, but got Unknown
		_003C_003Ec__DisplayClass71_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass71_0();
		CS_0024_003C_003E8__locals23._003C_003E4__this = this;
		float moreZ2 = default(float);
		CS_0024_003C_003E8__locals23.moreZ = moreZ2;
		CS_0024_003C_003E8__locals23.moreY = moreY;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num;
		float? num2;
		if ((object)duration == null)
		{
			num = 60000f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = duration;
		}
		List<EnemyController> enemies = new List<EnemyController>();
		CS_0024_003C_003E8__locals23.enemies = enemies;
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		CS_0024_003C_003E8__locals23.eventId = RandomEventId;
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num5 = 0;
		Stage ourStage = _ourStage;
		object obj = Vector3.upVector * activeCharacter._lastFacingDirection;
		float num7 = default(float);
		float num6 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v19 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
		float num8 = num6 * 0f;
		float num9 = num8 + (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ rcx_v30 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		object obj2 = (nint)0 * (nint)0;
		float num10 = num9 + (float)obj2;
		float fixedY;
		if (!(num10 < 0f))
		{
			fixedY = num7;
		}
		else
		{
			float num11 = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v22 (VampireSurvivors.Objects.Stage)+11C]");
			float num12 = num11 - 0f;
			fixedY = num12;
		}
		CS_0024_003C_003E8__locals23.fixedY = fixedY;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Action action2;
		if ((object)num2 != null)
		{
			int num14 = default(int);
			float num13 = num / (float)num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			CS_0024_003C_003E8__locals23.times = 0;
			if (num14 > 0)
			{
				object obj3 = 1;
				do
				{
					bool flag = CS_0024_003C_003E8__locals23._003C_003E9__1 != null;
					Action onComplete = CS_0024_003C_003E8__locals23._003C_003E9__1;
					if (!flag)
					{
						Action action = delegate
						{
							//IL_013d: Expected O, but got I4
							//IL_0170: Invalid comparison between F4 and I4
							//IL_0013: Expected O, but got I4
							//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
							//IL_00d4: Expected O, but got Unknown
							//IL_00fe: Invalid comparison between F4 and O
							int num18 = CS_0024_003C_003E8__locals23.times & 1;
							bool flag2 = num18 == 0;
							object obj7 = !flag2;
							if (obj7 == null)
							{
							}
							int times = CS_0024_003C_003E8__locals23.times + 1;
							CS_0024_003C_003E8__locals23.times = times;
							if (CS_0024_003C_003E8__locals23.moreZ > 0f)
							{
								object obj8 = 0;
								Vector2 spawnPos = default(Vector2);
								bool forceSpawn = default(bool);
								float moreZ3;
								do
								{
									StageEventManager stageEventManager = CS_0024_003C_003E8__locals23._003C_003E4__this;
									GameObject gameObject = stageEventManager._ourStage.SpawnEnemy(CS_0024_003C_003E8__locals23.moreY, spawnPos, asRemote: false, forceSpawn);
									EnemyController component = gameObject.GetComponent<EnemyController>();
									InitEventEnemy(CS_0024_003C_003E8__locals23.eventId, component, CS_0024_003C_003E8__locals23.enemies);
									if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
									{
										float num19 = component._003CSpeed_003Ek__BackingField * 1.5f;
										component._003CSpeed_003Ek__BackingField = num19;
									}
									StageEventManager stageEventManager2 = CS_0024_003C_003E8__locals23._003C_003E4__this;
									obj8++;
									int num20 = stageEventManager2._003CSpawned_003Ek__BackingField + 1;
									stageEventManager2._003CSpawned_003Ek__BackingField = num20;
									moreZ3 = CS_0024_003C_003E8__locals23.moreZ;
								}
								while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)moreZ3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8));
							}
						};
						num5 = (nint)(CS_0024_003C_003E8__locals23 + 56);
						CS_0024_003C_003E8__locals23._003C_003E9__1 = action;
						onComplete = action;
					}
					float num15 = (float)obj3 * num13;
					float duration2 = num15 * 0.001f;
					Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					obj3++;
				}
				while (CS_0024_003C_003E8__locals23._003C_003E9__1 != null);
			}
			action2 = null;
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass71_0._003CPlayDragonStream_003Eb__0);
			((Delegate)action2).m_target = CS_0024_003C_003E8__locals23;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num17;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num17 = unchecked((nint)6447293664L);
					goto IL_045a;
				}
			}
			num17 = ((Delegate)action2).method_ptr;
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			goto IL_045a;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_045a:
		object obj6 = 24;
		float duration3 = num * 0.001f;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(duration3, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void PlaySkeleStream(float? duration, int moreX = 12, EnemyType moreY = EnemyType.XLDRAGON3_FLAG, float moreZ = 4f)
	{
		//IL_006d: Expected O, but got I4
		//IL_02c9: Expected I, but got O
		//IL_0309: Expected O, but got I
		//IL_031f: Expected O, but got I
		//IL_0390: Expected O, but got I4
		//IL_01bc: Expected I, but got O
		//IL_01d2: Expected O, but got I
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_0256: Expected I, but got O
		//IL_03ad: Expected O, but got I4
		//IL_03d4: Expected I, but got I8
		//IL_0232: Expected I, but got I8
		_003C_003Ec__DisplayClass72_0 obj = new _003C_003Ec__DisplayClass72_0();
		obj._003C_003E4__this = this;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num;
		float? num2;
		if ((object)duration == null)
		{
			num = 20000f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = duration;
		}
		List<EnemyController> enemies = new List<EnemyController>();
		obj.enemies = enemies;
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		obj.eventId = RandomEventId;
		GameSessionData gameSessionData = _gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num5 = 0;
		object obj2 = Vector3.upVector * activeCharacter._lastFacingDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rcx_v18 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v19 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
		object obj3 = num6 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rcx_v18 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		object obj4 = (nint)0 * (nint)0;
		object obj5 = obj2 + obj3;
		object obj6 = obj5 + obj4;
		if ((nint)obj6 >= 0)
		{
		}
		object obj7 = default(object);
		bool flag3 = default(bool);
		if ((nint)obj7 > 0)
		{
			bool flag = false;
			Vector2 spawnPos = default(Vector2);
			do
			{
				bool flag2 = !flag;
				object obj8 = !flag2;
				if (obj8 == null)
				{
				}
				GameObject gameObject = _ourStage.SpawnEnemy(moreY, spawnPos, asRemote: false, flag3);
				EnemyController component = gameObject.GetComponent<EnemyController>();
				InitEventEnemy(obj.eventId, component, obj.enemies);
				int num7 = _003CSpawned_003Ek__BackingField + 1;
				_003CSpawned_003Ek__BackingField = num7;
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			}
			while ((nint)obj7 > (flag ? 1 : 0));
		}
		Action action;
		if ((object)num2 != null)
		{
			action = null;
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r10_v2 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass72_0._003CPlaySkeleStream_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r10_v2 (Il2CppMethodInfo)+4C]");
			object obj9 = (nint)0 >> 4;
			object obj10 = obj9 & 1;
			nint num9;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r10_v2 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num9 = unchecked((nint)6447293664L);
					goto IL_03a4;
				}
			}
			num9 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_03a4;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_03a4:
		object obj11 = 24;
		float duration2 = num * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void PlaySkullPilePile(float? duration, int moreX = 1, EnemyType moreY = EnemyType.PILE4_SCALED, float moreZ = 12f)
	{
		//IL_0098: Expected O, but got I4
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_02b6: Expected O, but got I4
		//IL_0519->IL03fa: Incompatible stack heights: 1 vs 0
		//IL_03f9->IL03f9: Incompatible stack heights: 2 vs 0
		//IL_053f->IL03fa: Incompatible stack heights: 1 vs 0
		//IL_0270->IL03fa: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass73_0 CS_0024_003C_003E8__locals24 = new _003C_003Ec__DisplayClass73_0();
		float num;
		float? num2;
		bool canPause;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (CS_0024_003C_003E8__locals24 != null)
		{
			CS_0024_003C_003E8__locals24._003C_003E4__this = this;
			EnemyType moreY2 = default(EnemyType);
			CS_0024_003C_003E8__locals24.moreY = moreY2;
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					return;
				}
				if ((object)duration == null)
				{
					num = 30000f;
					num2 = (float?)(object)1;
				}
				else
				{
					float num3 = default(float);
					num = num3;
					num2 = duration;
				}
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v17 (UnityEngine.Transform)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v17 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out Vector3 _);
						Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
						List<EnemyController> enemies = new List<EnemyController>();
						CS_0024_003C_003E8__locals24.enemies = enemies;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v24 (UnityEngine.Bounds)+10]");
						float num4 = 0f * 2f;
						int randomEventId = RandomEventId + 1;
						RandomEventId = randomEventId;
						CS_0024_003C_003E8__locals24.eventId = RandomEventId;
						float num5 = num4 * 1.5f;
						object obj = default(object);
						float fixedY = (float)obj - num5;
						CS_0024_003C_003E8__locals24.fixedY = fixedY;
						Stage ourStage = _ourStage;
						if ((object)_ourStage != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v32 (VampireSurvivors.Objects.Stage)+11C]");
							float num6 = 0f * 3f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v24 (UnityEngine.Bounds)+10]");
							float num7 = 0f * 2f;
							float num8 = num6 / 0.34f;
							float num9 = num7 * 3f;
							float yStep = num9 / num8;
							CS_0024_003C_003E8__locals24.yStep = yStep;
							int num10 = default(int);
							bool flag2 = num10 <= 0;
							canPause = false;
							if (flag2)
							{
								goto IL_0382;
							}
							int num11 = 0;
							bool flag3 = false;
							object obj3 = default(object);
							while (true)
							{
								_003C_003Ec__DisplayClass73_1 obj2 = new _003C_003Ec__DisplayClass73_1();
								if (obj2 == null)
								{
									break;
								}
								obj2.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals24;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r15d,xmm6\"");
								obj2.counter = (flag3 ? 1 : 0);
								obj3--;
								bool flag4 = (nint)obj3 <= 0;
								bool flag5 = flag3;
								if (!flag4)
								{
									while (true)
									{
										_003C_003Ec__DisplayClass73_2 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass73_2();
										if (CS_0024_003C_003E8__locals18 == null)
										{
											break;
										}
										CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2 = obj2;
										CS_0024_003C_003E8__locals18.index = num11;
										Action onComplete = delegate
										{
											//IL_0032: Expected O, but got I4
											_003C_003Ec__DisplayClass73_1 obj5 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2;
											int num13 = obj5.counter & 1;
											bool flag9 = num13 == 0;
											object obj6 = !flag9;
											if (obj6 == null)
											{
											}
											_003C_003Ec__DisplayClass73_1 obj7 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2;
											_003C_003Ec__DisplayClass73_0 obj8 = obj7.CS_0024_003C_003E8__locals1;
											StageEventManager stageEventManager = obj8._003C_003E4__this;
											_003C_003Ec__DisplayClass73_0 obj9 = obj7.CS_0024_003C_003E8__locals1;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
											_003C_003Ec__DisplayClass73_1 obj10 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2;
											_003C_003Ec__DisplayClass73_0 obj11 = obj10.CS_0024_003C_003E8__locals1;
											_003C_003Ec__DisplayClass73_1 obj12 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2;
											_003C_003Ec__DisplayClass73_0 obj13 = obj12.CS_0024_003C_003E8__locals1;
											EnemyController enemyController = default(EnemyController);
											InitEventEnemy(obj11.eventId, enemyController, obj13.enemies);
											if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
											{
												enemyController._003CSpeed_003Ek__BackingField = 0f;
											}
											_003C_003Ec__DisplayClass73_1 obj14 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2;
											_003C_003Ec__DisplayClass73_0 obj15 = obj14.CS_0024_003C_003E8__locals1;
											StageEventManager stageEventManager2 = obj15._003C_003E4__this;
											int num14 = stageEventManager2._003CSpawned_003Ek__BackingField + 1;
											stageEventManager2._003CSpawned_003Ek__BackingField = num14;
											_003C_003Ec__DisplayClass73_1 obj16 = CS_0024_003C_003E8__locals18.CS_0024_003C_003E8__locals2;
											int counter = obj16.counter + 1;
											obj16.counter = counter;
										};
										object obj4 = (flag5 ? 1 : 0) + 1;
										float num12 = (float)obj4 * 30f;
										fixedY = num12 * 0.001f;
										Timer timer = Timers.Register(fixedY, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
										flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
										bool flag6 = (flag5 ? 1 : 0) < (nint)obj3;
										moreY2 = EnemyType.BAT1;
										flag3 = false;
										if (flag6)
										{
											continue;
										}
										goto IL_0350;
									}
									break;
								}
								goto IL_0350;
								IL_0350:
								num11++;
								bool flag7 = num11 < num10;
								canPause = flag3;
								if (flag7)
								{
									continue;
								}
								goto IL_0382;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0382:
		bool flag8 = (object)num2 == null;
		Action onComplete2 = delegate
		{
			//IL_0018: Expected O, but got I4
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0207: Expected O, but got Unknown
			//IL_0212: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			List<EnemyController> enemies2 = CS_0024_003C_003E8__locals24.enemies;
			bool flag9 = (nint)CS_0024_003C_003E8__locals24.enemies < 0;
			object obj5 = enemies2._size - 1;
			if (!flag9)
			{
				while (true)
				{
					StageEventManager stageEventManager = CS_0024_003C_003E8__locals24._003C_003E4__this;
					int num13 = stageEventManager._003CSpawned_003Ek__BackingField - 1;
					stageEventManager._003CSpawned_003Ek__BackingField = num13;
					List<EnemyController> enemies3 = CS_0024_003C_003E8__locals24.enemies;
					if ((nint)obj5 >= enemies3._size)
					{
						break;
					}
					EnemyController[] items = enemies3._items;
					EnemyController enemyController = items[obj5];
					bool flag10 = (nint)items[obj5] < 0;
					if ((object)items[obj5] != null)
					{
						flag10 = (nint)((UnityEngine.Object)enemyController).m_CachedPtr < 0;
						if (((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
						{
							flag10 = (enemyController._003CIsDead_003Ek__BackingField ? 1 : 0) < (false ? 1 : 0);
							if (!enemyController._003CIsDead_003Ek__BackingField)
							{
								object obj6 = enemyController._003CStageEventId_003Ek__BackingField - CS_0024_003C_003E8__locals24.eventId;
								flag10 = (nint)obj6 < 0;
								if (enemyController._003CStageEventId_003Ek__BackingField == CS_0024_003C_003E8__locals24.eventId)
								{
									enemyController._003CIsCullable_003Ek__BackingField = true;
									items[obj5].Disappear();
								}
							}
						}
					}
					obj5--;
					object obj7 = !flag10;
					if (obj7 == null)
					{
						return;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		};
		float duration2 = num * 0.001f;
		Timer timer2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
	}

	private unsafe void PlayPolterRoulette(float? duration, int moreX = 50, EnemyType moreY = EnemyType.POLTER_DEST, float moreZ = 1f)
	{
		//IL_008b: Expected O, but got I4
		//IL_0780: Expected O, but got F4
		//IL_0148: Expected I, but got O
		//IL_0159: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_0677: Expected O, but got F4
		//IL_0518: Expected I, but got O
		//IL_052e: Expected O, but got I
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		//IL_05b2: Expected I, but got O
		//IL_071a: Expected O, but got I4
		//IL_0741: Expected I, but got I8
		//IL_0329: Expected O, but got I
		//IL_01d5: Expected O, but got I
		//IL_058e: Expected I, but got I8
		//IL_036b: Expected O, but got F4
		//IL_0384: Expected I, but got F4
		//IL_025c: Expected O, but got I
		//IL_04b0: Expected I, but got O
		//IL_04b8: Expected I, but got O
		//IL_04c5: Expected O, but got I4
		//IL_040c: Expected O, but got F4
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e5: Expected O, but got Unknown
		//IL_0703: Expected I, but got O
		//IL_0233: Expected I4, but got F8
		//IL_041a: Expected I, but got O
		//IL_042a: Expected O, but got F4
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068a: Expected O, but got Unknown
		//IL_06a6: Expected I, but got F8
		//IL_0822->IL05b8: Incompatible stack heights: 1 vs 0
		//IL_019d->IL05b8: Incompatible stack heights: 1 vs 0
		//IL_0777->IL05b7: Incompatible stack heights: 2 vs 0
		//IL_01f5->IL05b8: Incompatible stack heights: 1 vs 0
		//IL_0453->IL05b8: Incompatible stack heights: 1 vs 0
		//IL_0354->IL05b8: Incompatible stack heights: 1 vs 0
		//IL_03e5->IL05b8: Incompatible stack heights: 1 vs 0
		//IL_0246->IL067c: Incompatible stack heights: 1 vs 2
		//IL_06b9->IL07b1: Incompatible stack heights: 2 vs 1
		//IL_06be->IL0296: Incompatible stack heights: 2 vs 1
		_003C_003Ec__DisplayClass74_0 obj = new _003C_003Ec__DisplayClass74_0();
		float num;
		float? num2;
		float num4;
		nint num6;
		nint num7;
		List<int> list2;
		bool flag5 = default(bool);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					return;
				}
				if ((object)duration == null)
				{
					num = 60000f;
					num2 = (float?)(object)1;
				}
				else
				{
					float num3 = default(float);
					num = num3;
					num2 = duration;
				}
				object obj2 = UnityEngine.Random.value;
				object obj3 = default(object);
				num4 = (float)obj3 * ((float)Math.PI * 2f);
				List<EnemyController> enemies = new List<EnemyController>();
				obj.enemies = enemies;
				int randomEventId = RandomEventId + 1;
				RandomEventId = randomEventId;
				obj.eventId = RandomEventId;
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
						List<int> list = new List<int>();
						object obj4 = default(object);
						bool flag2 = (nint)obj4 <= 0;
						nint num5 = (nint)moreY;
						num6 = 0;
						num7 = unchecked((nint)null);
						list2 = list;
						object obj5 = 0;
						if (flag2)
						{
							goto IL_0296;
						}
						while (true)
						{
							object obj6 = UnityEngine.Random.value;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
							double num8 = Math.Floor(0.0);
							if (list == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+10]");
							num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+18]");
							list2 = (List<int>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r8_v24 (Il2CppMethodInfo)+18]");
							if (num9 >= 0)
							{
								list.AddWithResize((int)num8);
								num7 = 0;
								list2 = list;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj7 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1150 @ rax_v42 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ r8_v24 (Il2CppMethodInfo)+18]");
								bool flag3 = num10 >= 0;
							}
							obj5++;
							bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
							num5 = 0;
							num6 = (nint)num8;
							flag5 = flag5;
							if (!flag4)
							{
								goto IL_0296;
							}
						}
					}
				}
			}
		}
		goto IL_05b8;
		IL_0711:
		object obj8 = 24;
		float duration2 = num * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_06be:
		bool flag6 = (object)num2 == null;
		action = null;
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass74_0._003CPlayPolterRoulette_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj9 = (nint)0 >> 4;
		object obj10 = obj9 & 1;
		nint num12;
		if (obj10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num12 = unchecked((nint)6447293664L);
				goto IL_0711;
			}
		}
		num12 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0711;
		IL_05b8:
		throw new NullReferenceException();
		IL_0296:
		int num13 = default(int);
		if (num13 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1147 @ rax_v41 (UnityEngine.Bounds)+10]");
			float num14 = 0f * 2f;
			float num15 = num14 * 0.85f;
			float num16 = (float)num13 * 0.5f;
			float num17 = (float)Math.PI / num16;
			object obj11 = 0;
			float num21 = default(float);
			object obj12 = default(object);
			EnemyController enemyController = default(EnemyController);
			while (true)
			{
				list2.Add((int)num6);
				list2.Add((int)num6);
				Stage ourStage = _ourStage;
				float num18 = num4 + num17;
				float num19 = num4 * 0.6f;
				float num20 = num19 * num15;
				if ((object)_ourStage == null)
				{
					break;
				}
				bool flag7 = !ourStage._hasTileSet;
				List<EnemyController> list3 = (List<EnemyController>)num7;
				List<EnemyController> list4;
				if (!flag7)
				{
					if ((object)ourStage._tilingTileset == null)
					{
						break;
					}
					bool flag8 = ourStage._tilingTileset.IsPointWithinCollisionLayer((Vector2)num21);
					num20 = num21;
					list3 = null;
					num6 = (nint)num21;
					list4 = null;
					list2 = (List<int>)(object)ourStage._tilingTileset;
					if (flag8)
					{
						goto IL_06d7;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4660");
				if ((nint)obj12 != -1)
				{
					if ((object)_ourStage == null)
					{
						break;
					}
					PropType destructibleType = _ourStage.DestructibleType;
					Destructible destructible = _ourStage.MakeDestructible(destructibleType, (Vector2)num21);
					nint num5 = unchecked((nint)null);
					num6 = (nint)destructibleType;
					list4 = (List<EnemyController>)num21;
					list2 = (List<int>)(object)_ourStage;
				}
				else
				{
					if ((object)_ourStage == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
					list4 = obj.enemies;
					InitEventEnemy(obj.eventId, enemyController, obj.enemies);
					int num22 = _003CSpawned_003Ek__BackingField + 1;
					_003CSpawned_003Ek__BackingField = num22;
					nint num5 = unchecked((nint)null);
					num6 = (nint)enemyController;
					list2 = (List<int>)obj.eventId;
				}
				goto IL_06d7;
				IL_06d7:
				obj11++;
				bool flag9 = (nint)obj11 < num13;
				num4 = num18;
				num7 = (nint)list4;
				if (flag9)
				{
					continue;
				}
				goto IL_06be;
			}
			goto IL_05b8;
		}
		goto IL_06be;
	}

	private void PlayImpSwarm(float? duration, int moreX = 50)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, moreX, EnemyType.IMP, moreZ, rndDiv);
	}

	private void PlaySkeletonSwarm(float? duration, int moreX = 50, EnemyType moreY = EnemyType.BATSWARM)
	{
		float num = default(float);
		float duration2 = (((object)duration != null) ? num : 10000f);
		float moreZ = default(float);
		float rndDiv = default(float);
		GenerateEnemySwarm(duration2, moreX, moreY, moreZ, rndDiv);
	}

	private unsafe void PlayShadeBomb(float? duration, int moreX = 1, EnemyType moreY = EnemyType.SHADERED)
	{
		//IL_008b: Expected O, but got I4
		//IL_0159: Expected F4, but got I
		//IL_0162: Expected O, but got I4
		//IL_02ec: Expected I, but got O
		//IL_0302: Expected O, but got I
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0386: Expected I, but got O
		//IL_0462: Expected O, but got F4
		//IL_0509: Expected O, but got I4
		//IL_0530: Expected I, but got I8
		//IL_0362: Expected I, but got I8
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_04f6->IL038c: Incompatible stack heights: 1 vs 0
		//IL_0566->IL038b: Incompatible stack heights: 2 vs 0
		//IL_01b6->IL038c: Incompatible stack heights: 1 vs 0
		//IL_01e0->IL038c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass77_0 obj = new _003C_003Ec__DisplayClass77_0();
		float num;
		float? num2;
		bool flag2 = default(bool);
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if ((object)GM.Core != null)
			{
				if (!GM.Core.IsStageHost)
				{
					return;
				}
				if ((object)duration == null)
				{
					num = 60000f;
					num2 = (float?)(object)1;
				}
				else
				{
					float num3 = default(float);
					num = num3;
					num2 = duration;
				}
				List<EnemyController> enemies = new List<EnemyController>();
				obj.enemies = enemies;
				int randomEventId = RandomEventId + 1;
				RandomEventId = randomEventId;
				obj.eventId = RandomEventId;
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						Vector3 vector = CameraExtensions.OrthographicBounds(_mainCamera).m_Center;
						int num4 = default(int);
						if (num4 <= 0)
						{
							goto IL_0285;
						}
						EnemyType enemyType = moreY;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ rax_v33 (UnityEngine.Bounds)+10]");
						float num5 = 0f;
						object obj2 = 0;
						Camera mainCamera = _mainCamera;
						List<EnemyController> list = null;
						object obj3 = default(object);
						int num6 = (int)(&obj3);
						object obj5 = default(object);
						Vector3 vector2 = default(Vector3);
						while (true)
						{
							object obj4 = UnityEngine.Random.value;
							float num7 = (float)vector * ((float)Math.PI * 2f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ rax_v33 (UnityEngine.Bounds)+10]");
							float num8 = 0f * 2f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							float num9 = num8 * 0.9f;
							float num10 = num7 * 0.8f;
							float num11 = num10 * num9;
							num5 = num11 + (float)obj5;
							if ((object)_ourStage == null)
							{
								break;
							}
							GameObject gameObject = _ourStage.SpawnEnemy(moreY, vector2, asRemote: false, flag2);
							if ((object)gameObject == null)
							{
								break;
							}
							EnemyController component = gameObject.GetComponent<EnemyController>();
							if ((object)component == null)
							{
								break;
							}
							component.TargetClosestPlayer();
							list = obj.enemies;
							num6 = obj.eventId;
							InitEventEnemy(obj.eventId, component, obj.enemies);
							int num12 = _003CSpawned_003Ek__BackingField + 1;
							_003CSpawned_003Ek__BackingField = num12;
							obj2++;
							bool flag3 = (nint)obj2 < num4;
							enemyType = EnemyType.BAT1;
							vector = vector2;
							mainCamera = (Camera)(object)component;
							if (!flag3)
							{
								goto IL_0285;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0500:
		object obj6 = 24;
		float duration2 = num * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action, null, isLooped: false, flag2, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0285:
		bool flag4 = (object)num2 == null;
		action = null;
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass77_0._003CPlayShadeBomb_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj7 = (nint)0 >> 4;
		object obj8 = obj7 & 1;
		nint num14;
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num14 = unchecked((nint)6447293664L);
				goto IL_0500;
			}
		}
		num14 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0500;
	}

	private void ShootStars(int moreX, object moreY, float moreZ)
	{
		float num = Convert.ToSingle(moreY);
		ShootingStarsManager._003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals7 = new ShootingStarsManager._003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = _shootingStarsManager;
		CS_0024_003C_003E8__locals7.radiusMul = moreZ;
		if (moreX <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals7._003C_003E9__0;
			if (CS_0024_003C_003E8__locals7._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals7._003C_003E9__0 = delegate
				{
					CS_0024_003C_003E8__locals7._003C_003E4__this.ShootOne(CS_0024_003C_003E8__locals7.radiusMul);
				});
			}
			float num2 = (float)(flag ? 1 : 0) * num;
			float duration = num2 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < moreX);
	}

	private void ShootStars2(int moreX, object moreY, float moreZ)
	{
		float num = Convert.ToSingle(moreY);
		ShootingStarsManager2._003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals7 = new ShootingStarsManager2._003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = _shootingStarsManager2;
		CS_0024_003C_003E8__locals7.radiusMul = moreZ;
		if (moreX <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals7._003C_003E9__0;
			if (CS_0024_003C_003E8__locals7._003C_003E9__0 == null)
			{
				onComplete = (CS_0024_003C_003E8__locals7._003C_003E9__0 = delegate
				{
					CS_0024_003C_003E8__locals7._003C_003E4__this.ShootOne(CS_0024_003C_003E8__locals7.radiusMul);
				});
			}
			float num2 = (float)(flag ? 1 : 0) * num;
			float duration = num2 * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < moreX);
	}

	private void SummonTimedEnemy(float? duration, int moreX, EnemyType enemyType)
	{
		//IL_005e: Expected O, but got I4
		//IL_00f5: Expected I, but got O
		//IL_03d6: Expected O, but got F4
		//IL_01a9: Expected I, but got O
		//IL_01b1: Expected I, but got O
		//IL_01c1: Expected O, but got I
		//IL_0241: Expected O, but got I4
		//IL_01fd: Expected O, but got I
		//IL_0253: Expected I4, but got O
		//IL_0233: Expected O, but got I4
		//IL_0268: Expected O, but got I
		//IL_02a2: Expected O, but got I
		//IL_03c8->IL030c: Incompatible stack heights: 1 vs 0
		//IL_041c->IL030c: Incompatible stack heights: 1 vs 0
		//IL_030b->IL030b: Incompatible stack heights: 2 vs 0
		//IL_0288->IL030c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass80_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass80_0();
		float num;
		float? num2;
		object obj4;
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			if ((object)duration == null)
			{
				num = 60000f;
				num2 = (float?)(object)1;
			}
			else
			{
				float num3 = default(float);
				num = num3;
				num2 = duration;
			}
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					int randomEventId = RandomEventId + 1;
					RandomEventId = randomEventId;
					if (CS_0024_003C_003E8__locals13 != null)
					{
						nint num4 = (nint)typeof(StageEventManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rax_v28 (Il2CppClass<VampireSurvivors.Objects.StageEventManager>)+B8]");
						nint num5 = 0;
						CS_0024_003C_003E8__locals13.eventId = RandomEventId;
						object obj = UnityEngine.Random.value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rax_v25 (UnityEngine.Bounds)+10]");
						float num6 = 0f * ((float)Math.PI * 2f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						if ((object)_ourStage != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
							EnemyController enemy = default(EnemyController);
							CS_0024_003C_003E8__locals13.enemy = enemy;
							InitEventEnemy(CS_0024_003C_003E8__locals13.eventId, CS_0024_003C_003E8__locals13.enemy, null);
							if (moreX > 0)
							{
								EnemyController enemy2 = CS_0024_003C_003E8__locals13.enemy;
								if ((object)CS_0024_003C_003E8__locals13.enemy != null)
								{
									nint num7 = (nint)typeof(EnemyStalker);
									nint num8 = (nint)enemy2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyStalker>)+130]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyStalker>)+130]");
									if (num9 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v896 @ rax_v49+FFFFFFF8+v880 @ rax_v43*8]");
										if (0 == (nint)typeof(EnemyStalker))
										{
											obj4 = 1;
											goto IL_043a;
										}
									}
									obj4 = 0;
									goto IL_043a;
								}
							}
							goto IL_0421;
						}
					}
				}
			}
		}
		goto IL_030c;
		IL_030c:
		throw new NullReferenceException();
		IL_0421:
		bool flag2 = (object)num2 == null;
		Action onComplete = delegate
		{
			EnemyController enemy3 = CS_0024_003C_003E8__locals13.enemy;
			if ((object)CS_0024_003C_003E8__locals13.enemy != null && ((UnityEngine.Object)enemy3).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemy4 = CS_0024_003C_003E8__locals13.enemy;
				if (!enemy4._003CIsDead_003Ek__BackingField && enemy4._003CStageEventId_003Ek__BackingField == CS_0024_003C_003E8__locals13.eventId)
				{
					enemy4._003CIsCullable_003Ek__BackingField = true;
					CS_0024_003C_003E8__locals13.enemy.Disappear();
				}
			}
		};
		float duration2 = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_043a:
		bool flag3 = obj4 == null;
		bool flag4 = false;
		if (!flag3)
		{
			flag4 = (byte)(int)CS_0024_003C_003E8__locals13.enemy != 0;
		}
		if (flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v46 (System.Boolean)+B0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v46 (System.Boolean)+B0]");
			if ((nint)0 == 0)
			{
				goto IL_030c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rcx_v35+18]");
			object obj6 = (nint)moreX * (nint)0;
		}
		goto IL_0421;
	}

	private void PlayStalker(float? duration, int moreX = 1)
	{
		//IL_005e: Expected O, but got I4
		//IL_00f5: Expected I, but got O
		//IL_03d6: Expected O, but got F4
		//IL_01a9: Expected I, but got O
		//IL_01b1: Expected I, but got O
		//IL_01c1: Expected O, but got I
		//IL_0241: Expected O, but got I4
		//IL_01fd: Expected O, but got I
		//IL_0253: Expected I4, but got O
		//IL_0233: Expected O, but got I4
		//IL_0268: Expected O, but got I
		//IL_02a2: Expected O, but got I
		//IL_03c8->IL030c: Incompatible stack heights: 1 vs 0
		//IL_041c->IL030c: Incompatible stack heights: 1 vs 0
		//IL_030b->IL030b: Incompatible stack heights: 2 vs 0
		//IL_0288->IL030c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass81_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass81_0();
		float num;
		float? num2;
		object obj4;
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			if ((object)duration == null)
			{
				num = 60000f;
				num2 = (float?)(object)1;
			}
			else
			{
				float num3 = default(float);
				num = num3;
				num2 = duration;
			}
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					int randomEventId = RandomEventId + 1;
					RandomEventId = randomEventId;
					if (CS_0024_003C_003E8__locals13 != null)
					{
						nint num4 = (nint)typeof(StageEventManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ rax_v28 (Il2CppClass<VampireSurvivors.Objects.StageEventManager>)+B8]");
						nint num5 = 0;
						CS_0024_003C_003E8__locals13.eventId = RandomEventId;
						object obj = UnityEngine.Random.value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v25 (UnityEngine.Bounds)+10]");
						float num6 = 0f * ((float)Math.PI * 2f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						if ((object)_ourStage != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
							EnemyController enemy = default(EnemyController);
							CS_0024_003C_003E8__locals13.enemy = enemy;
							InitEventEnemy(CS_0024_003C_003E8__locals13.eventId, CS_0024_003C_003E8__locals13.enemy, null);
							if (moreX > 0)
							{
								EnemyController enemy2 = CS_0024_003C_003E8__locals13.enemy;
								if ((object)CS_0024_003C_003E8__locals13.enemy != null)
								{
									nint num7 = (nint)typeof(EnemyStalker);
									nint num8 = (nint)enemy2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyStalker>)+130]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyStalker>)+130]");
									if (num9 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ rax_v49+FFFFFFF8+v875 @ rax_v43*8]");
										if (0 == (nint)typeof(EnemyStalker))
										{
											obj4 = 1;
											goto IL_043a;
										}
									}
									obj4 = 0;
									goto IL_043a;
								}
							}
							goto IL_0421;
						}
					}
				}
			}
		}
		goto IL_030c;
		IL_030c:
		throw new NullReferenceException();
		IL_0421:
		bool flag2 = (object)num2 == null;
		Action onComplete = delegate
		{
			EnemyController enemy3 = CS_0024_003C_003E8__locals13.enemy;
			if ((object)CS_0024_003C_003E8__locals13.enemy != null && ((UnityEngine.Object)enemy3).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemy4 = CS_0024_003C_003E8__locals13.enemy;
				if (!enemy4._003CIsDead_003Ek__BackingField && enemy4._003CStageEventId_003Ek__BackingField == CS_0024_003C_003E8__locals13.eventId)
				{
					enemy4._003CIsCullable_003Ek__BackingField = true;
					CS_0024_003C_003E8__locals13.enemy.Disappear();
				}
			}
		};
		float duration2 = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_043a:
		bool flag3 = obj4 == null;
		bool flag4 = false;
		if (!flag3)
		{
			flag4 = (byte)(int)CS_0024_003C_003E8__locals13.enemy != 0;
		}
		if (flag4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v46 (System.Boolean)+B0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v46 (System.Boolean)+B0]");
			if ((nint)0 == 0)
			{
				goto IL_030c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v35+18]");
			object obj6 = (nint)moreX * (nint)0;
		}
		goto IL_0421;
	}

	private void PlaySleeper(float? duration, int moreX = 1)
	{
		//IL_005e: Expected O, but got I4
		//IL_00f5: Expected I, but got O
		//IL_03b7: Expected O, but got F4
		//IL_0189: Expected I, but got O
		//IL_0191: Expected I, but got O
		//IL_01a1: Expected O, but got I
		//IL_0221: Expected O, but got I4
		//IL_01dd: Expected O, but got I
		//IL_0213: Expected O, but got I4
		//IL_03a9->IL02ed: Incompatible stack heights: 1 vs 0
		//IL_03fd->IL02ed: Incompatible stack heights: 1 vs 0
		//IL_02ec->IL02ec: Incompatible stack heights: 2 vs 0
		//IL_0262->IL02ed: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass82_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass82_0();
		float num;
		float? num2;
		object obj4;
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			if ((object)duration == null)
			{
				num = 60000f;
				num2 = (float?)(object)1;
			}
			else
			{
				float num3 = default(float);
				num = num3;
				num2 = duration;
			}
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					int randomEventId = RandomEventId + 1;
					RandomEventId = randomEventId;
					if (CS_0024_003C_003E8__locals13 != null)
					{
						nint num4 = (nint)typeof(StageEventManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rax_v28 (Il2CppClass<VampireSurvivors.Objects.StageEventManager>)+B8]");
						nint num5 = 0;
						CS_0024_003C_003E8__locals13.eventId = RandomEventId;
						object obj = UnityEngine.Random.value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v25 (UnityEngine.Bounds)+10]");
						float num6 = 0f * ((float)Math.PI * 2f);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
						if ((object)_ourStage != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
							EnemyController enemy = default(EnemyController);
							CS_0024_003C_003E8__locals13.enemy = enemy;
							InitEventEnemy(CS_0024_003C_003E8__locals13.eventId, CS_0024_003C_003E8__locals13.enemy, null);
							EnemyController enemy2 = CS_0024_003C_003E8__locals13.enemy;
							if ((object)CS_0024_003C_003E8__locals13.enemy == null)
							{
								goto IL_0402;
							}
							nint num7 = (nint)typeof(EnemyBlinder);
							nint num8 = (nint)enemy2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyBlinder>)+130]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyBlinder>)+130]");
							if (num9 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r9_v13 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rax_v49+FFFFFFF8+v835 @ rax_v43*8]");
								if (0 == (nint)typeof(EnemyBlinder))
								{
									obj4 = 1;
									goto IL_041b;
								}
							}
							obj4 = 0;
							goto IL_041b;
						}
					}
				}
			}
		}
		goto IL_02ed;
		IL_041b:
		bool flag2 = obj4 == null;
		EnemyController enemyController = null;
		if (!flag2)
		{
			enemyController = CS_0024_003C_003E8__locals13.enemy;
		}
		if ((object)enemyController != null)
		{
			EnemyData currentEnemyData = enemyController._currentEnemyData;
			if (enemyController._currentEnemyData == null)
			{
				goto IL_02ed;
			}
			float defaultSpeed = (float)moreX * currentEnemyData._003Cspeed_003Ek__BackingField;
			enemyController._defaultSpeed = defaultSpeed;
		}
		goto IL_0402;
		IL_02ed:
		throw new NullReferenceException();
		IL_0402:
		bool flag3 = (object)num2 == null;
		Action onComplete = delegate
		{
			EnemyController enemy3 = CS_0024_003C_003E8__locals13.enemy;
			if ((object)CS_0024_003C_003E8__locals13.enemy != null && ((UnityEngine.Object)enemy3).m_CachedPtr != (IntPtr)0)
			{
				EnemyController enemy4 = CS_0024_003C_003E8__locals13.enemy;
				if (!enemy4._003CIsDead_003Ek__BackingField && enemy4._003CStageEventId_003Ek__BackingField == CS_0024_003C_003E8__locals13.eventId)
				{
					enemy4._003CIsCullable_003Ek__BackingField = true;
					CS_0024_003C_003E8__locals13.enemy.Disappear();
				}
			}
		};
		float duration2 = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void PlayDrowner(float? duration, bool fromTrisection = false)
	{
		//IL_005e: Expected O, but got I4
		//IL_0198: Expected I, but got O
		//IL_01a6: Expected I, but got O
		//IL_01b6: Expected O, but got I
		//IL_01f2: Expected O, but got I
		//IL_023c: Expected O, but got I
		//IL_0244: Expected I, but got O
		//IL_027c: Expected O, but got I
		//IL_03cc->IL0310: Incompatible stack heights: 1 vs 0
		//IL_010f->IL0310: Incompatible stack heights: 1 vs 0
		//IL_030f->IL030f: Incompatible stack heights: 2 vs 0
		//IL_02b0->IL03d1: Incompatible stack heights: 3 vs 1
		_003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals16 = new _003C_003Ec__DisplayClass83_0();
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			float num;
			float? num2;
			if ((object)duration == null)
			{
				num = 60000f;
				num2 = (float?)(object)1;
			}
			else
			{
				float num3 = default(float);
				num = num3;
				num2 = duration;
			}
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
					int randomEventId = RandomEventId + 1;
					RandomEventId = randomEventId;
					if (CS_0024_003C_003E8__locals16 != null)
					{
						CS_0024_003C_003E8__locals16.eventId = RandomEventId;
						if ((object)_ourStage != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
							EnemyController enemy = default(EnemyController);
							CS_0024_003C_003E8__locals16.enemy = enemy;
							InitEventEnemy(CS_0024_003C_003E8__locals16.eventId, CS_0024_003C_003E8__locals16.enemy, null);
							if (fromTrisection)
							{
								EnemyController enemy2 = CS_0024_003C_003E8__locals16.enemy;
								if ((object)CS_0024_003C_003E8__locals16.enemy != null)
								{
									nint num4 = (nint)enemy2;
									nint num5 = (nint)typeof(EnemyDrowner);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
									if (num6 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ rax_v40+FFFFFFF8+v727 @ rax_v39*8]");
										if (0 == (nint)typeof(EnemyDrowner))
										{
											EnemyController enemy3 = CS_0024_003C_003E8__locals16.enemy;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
											object obj3 = 0;
											nint num7 = (nint)enemy3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rdx_v21 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
											bool flag2 = num8 < 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rax_v42+FFFFFFF8+v441 @ rax_v41*8]");
											bool flag3 = 0 != (nint)typeof(EnemyDrowner);
											_ = 1;
										}
									}
								}
							}
							bool flag4 = (object)num2 == null;
							Action onComplete = delegate
							{
								//IL_00d5: Expected I, but got O
								//IL_00dd: Expected I, but got O
								//IL_00ed: Expected O, but got I
								//IL_016d: Expected O, but got I4
								//IL_0129: Expected O, but got I
								//IL_015f: Expected O, but got I4
								EnemyController enemy4 = CS_0024_003C_003E8__locals16.enemy;
								if ((object)CS_0024_003C_003E8__locals16.enemy == null || ((UnityEngine.Object)enemy4).m_CachedPtr == (IntPtr)0)
								{
									return;
								}
								EnemyController enemy5 = CS_0024_003C_003E8__locals16.enemy;
								if (enemy5._003CIsDead_003Ek__BackingField || enemy5._003CStageEventId_003Ek__BackingField != CS_0024_003C_003E8__locals16.eventId)
								{
									return;
								}
								enemy5._003CIsCullable_003Ek__BackingField = true;
								EnemyController enemy6 = CS_0024_003C_003E8__locals16.enemy;
								if ((object)CS_0024_003C_003E8__locals16.enemy == null)
								{
									goto IL_018c;
								}
								nint num9 = (nint)typeof(EnemyDrowner);
								nint num10 = (nint)enemy6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
								nint num11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.Enemies.EnemyDrowner>)+130]");
								object obj7;
								if (num11 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+C8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v21+FFFFFFF8+v250 @ rax_v15*8]");
									if (0 == (nint)typeof(EnemyDrowner))
									{
										obj7 = 1;
										goto IL_01d0;
									}
								}
								obj7 = 0;
								goto IL_01d0;
								IL_018c:
								CS_0024_003C_003E8__locals16.enemy.Disappear();
								return;
								IL_01d0:
								bool flag5 = obj7 == null;
								EnemyController enemyController = null;
								if (!flag5)
								{
									enemyController = CS_0024_003C_003E8__locals16.enemy;
								}
								if ((object)enemyController != null)
								{
									_ = 1;
								}
								goto IL_018c;
							};
							float duration2 = num * 0.001f;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void PlayEraseEnemies()
	{
		//IL_01dc: Expected O, but got I4
		//IL_00e9: Expected O, but got Ref
		//IL_0278: Expected O, but got I
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected Ref, but got Unknown
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Expected Ref, but got Unknown
		//IL_0537: Expected O, but got I4
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected O, but got Unknown
		//IL_031f: Expected O, but got I
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_06c3: Expected O, but got I4
		//IL_03ea: Expected I, but got O
		//IL_03a5: Expected O, but got I
		//IL_067a->IL05f7: Incompatible stack heights: 1 vs 0
		//IL_0107->IL05f7: Incompatible stack heights: 1 vs 0
		//IL_0263->IL05f7: Incompatible stack heights: 1 vs 0
		//IL_0133->IL05f7: Incompatible stack heights: 1 vs 0
		//IL_015d->IL015d: Incompatible stack heights: 1 vs 0
		//IL_06a4->IL06a9: Incompatible stack heights: 1 vs 0
		//IL_02a9->IL06a9: Incompatible stack heights: 1 vs 0
		//IL_06dc->IL077b: Incompatible stack heights: 1 vs 0
		//IL_06e1->IL0409: Incompatible stack heights: 1 vs 0
		//IL_038f->IL05f7: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass84_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass84_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
					{
						goto IL_015d;
					}
					if ((object)_mainCamera != null)
					{
						Transform transform = _mainCamera.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.RosaryVfx);
							if ((object)pool != null)
							{
								RosaryVfx objectComponent = pool.GetObjectComponent<RosaryVfx>((Vector3)(&ret));
								if ((object)_mainCamera != null)
								{
									Transform transform2 = _mainCamera.transform;
									if ((object)objectComponent != null)
									{
										objectComponent.SetParent(transform2);
										objectComponent.Play();
										goto IL_015d;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05f7;
		IL_015d:
		Stage ourStage = _ourStage;
		bool flag8 = default(bool);
		if ((object)_ourStage != null)
		{
			List<EnemyController> spawnedEnemies = ourStage._spawnedEnemies;
			bool flag2 = (nint)ourStage._spawnedEnemies < 0;
			if (ourStage._spawnedEnemies != null)
			{
				object obj = spawnedEnemies._size - 1;
				if (flag2)
				{
					goto IL_0409;
				}
				object obj2 = default(object);
				object obj3 = default(object);
				while (true)
				{
					Stage ourStage2 = _ourStage;
					if ((object)_ourStage == null)
					{
						break;
					}
					List<EnemyController> spawnedEnemies2 = ourStage2._spawnedEnemies;
					if (ourStage2._spawnedEnemies == null)
					{
						break;
					}
					bool flag3 = (nint)obj >= spawnedEnemies2._size;
					Transform items = (Transform)(object)spawnedEnemies2._items;
					if (spawnedEnemies2._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v8 (UnityEngine.Transform)+20+v93 @ rdi_v10*8]");
					Transform transform3 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v8 (UnityEngine.Transform)+20+v93 @ rdi_v10*8]");
					if ((nint)0 == 0 || ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v9 (UnityEngine.Transform)+20C]");
					bool flag4;
					object obj4;
					if ((nint)0 != 0)
					{
						flag4 = (nint)obj2 < 0;
						bool flag5 = (nint)obj2 > 0;
						obj3 = obj2;
						obj4 = obj2;
						if (flag5)
						{
							goto IL_06aa;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v9 (UnityEngine.Transform)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v9 (UnityEngine.Transform)+C8]");
					bool flag6 = (nint)0 < (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v9 (UnityEngine.Transform)+C8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rsi_v7+10]");
						flag6 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rsi_v7+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v9 (UnityEngine.Transform)+C8]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbx_v9 (UnityEngine.Transform)+C8]");
							bool hasStateAuthority = ((CoherenceSync)0).HasStateAuthority;
							flag6 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
							bool flag7 = !hasStateAuthority;
							obj4 = obj3;
							flag4 = flag6;
							if (flag7)
							{
								goto IL_06aa;
							}
						}
					}
					nint num = (nint)transform3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1237 @ rax_v34 (Il2CppClass<UnityEngine.Transform>)+388] (should have been resolved before IL gen)");
					obj4 = obj3;
					flag4 = flag6;
					goto IL_06aa;
					IL_06aa:
					obj--;
					object obj6 = !flag4;
					flag8 = flag8;
					obj3 = obj4;
					if (obj6 != null)
					{
						continue;
					}
					goto IL_0409;
				}
			}
		}
		goto IL_05f7;
		IL_05f7:
		throw new NullReferenceException();
		IL_0409:
		Stage ourStage3 = _ourStage;
		if ((object)_ourStage != null)
		{
			Transform tilingBackground = (Transform)(object)ourStage3._tilingBackground;
			if ((object)ourStage3._tilingBackground == null || ((UnityEngine.Object)tilingBackground).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			Stage ourStage4 = _ourStage;
			if ((object)_ourStage != null)
			{
				TilingBackground tilingBackground2 = ourStage4._tilingBackground;
				if ((object)ourStage4._tilingBackground != null)
				{
					tilingBackground2._003CRunTimeHue_003Ek__BackingField = false;
					bool flag9 = ColorUtility.TryParseHtmlString("#ffffff", out *(Color*)(CS_0024_003C_003E8__locals13 + 28));
					bool flag10 = ColorUtility.TryParseHtmlString("#880000", out *(Color*)(CS_0024_003C_003E8__locals13 + 44));
					CS_0024_003C_003E8__locals13.lerp = 0f;
					object obj7 = 1;
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					do
					{
						bool flag11 = CS_0024_003C_003E8__locals13._003C_003E9__0 != null;
						Action onComplete = CS_0024_003C_003E8__locals13._003C_003E9__0;
						if (!flag11)
						{
							onComplete = (CS_0024_003C_003E8__locals13._003C_003E9__0 = delegate
							{
								//IL_008f: Invalid comparison between I4 and F4
								//IL_00da: Expected F4, but got I4
								float num3 = CS_0024_003C_003E8__locals13.lerp + 0.05f;
								StageEventManager stageEventManager = CS_0024_003C_003E8__locals13._003C_003E4__this;
								if (num3 > 1f)
								{
									num3 = 1f;
								}
								CS_0024_003C_003E8__locals13.lerp = num3;
								if (CS_0024_003C_003E8__locals13._003C_003E4__this != null)
								{
									Stage ourStage5 = stageEventManager._ourStage;
									if ((object)stageEventManager._ourStage != null)
									{
										TilingBackground tilingBackground3 = ourStage5._tilingBackground;
										if (!(0f > num3))
										{
											if (num3 > 1f)
											{
												num3 = 1f;
											}
										}
										else
										{
											num3 = 0f;
										}
										if ((object)ourStage5._tilingBackground != null)
										{
											TileSprite bgtile = tilingBackground3._bgtile;
											object spriteRenderer = bgtile._spriteRenderer;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v7 (System.Object)+10]");
											bool flag12 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rbx_v7 (System.Object)+10]");
											float value = default(float);
											SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
											return;
										}
									}
								}
								throw new NullReferenceException();
							});
						}
						float num2 = (float)obj7 * 100f;
						float duration = num2 * 0.001f;
						Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, flag8, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						obj7++;
					}
					while (CS_0024_003C_003E8__locals13._003C_003E9__0 != null);
					return;
				}
			}
		}
		goto IL_05f7;
	}

	private void PlayCycleComplete()
	{
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CSelectedReapers_003Ek__BackingField)
		{
			PlayEraseEnemies();
			return;
		}
		GameManager core = GM.Core;
		core._stage.OnCycleComplete();
	}

	private unsafe void SpawnInSteps(float? duration, int moreX = 24, EnemyType moreY = EnemyType.EX_AXE_BAT3, float moreZ = 0.9f)
	{
		//IL_008c: Expected O, but got I4
		//IL_0330: Expected O, but got I4
		//IL_021e: Expected I, but got O
		//IL_0234: Expected O, but got I
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_02b8: Expected I, but got O
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected I4, but got Unknown
		//IL_0368: Expected O, but got I4
		//IL_038f: Expected I, but got I8
		//IL_0294: Expected I, but got I8
		_003C_003Ec__DisplayClass86_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass86_0();
		CS_0024_003C_003E8__locals20.moreX = moreX;
		CS_0024_003C_003E8__locals20._003C_003E4__this = this;
		CS_0024_003C_003E8__locals20.moreY = moreY;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float num;
		float? num2;
		if ((object)duration == null)
		{
			num = 30000f;
			num2 = (float?)(object)1;
		}
		else
		{
			float num3 = default(float);
			num = num3;
			num2 = duration;
		}
		List<EnemyController> enemies = new List<EnemyController>();
		CS_0024_003C_003E8__locals20.enemies = enemies;
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		CS_0024_003C_003E8__locals20.eventId = RandomEventId;
		CS_0024_003C_003E8__locals20.index = 0;
		bool flag = false;
		object obj = 1;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Action action;
		while (true)
		{
			if ((flag ? 1 : 0) < CS_0024_003C_003E8__locals20.moreX)
			{
				if ((object)num2 != null)
				{
					Action onComplete = CS_0024_003C_003E8__locals20._003C_003E9__1;
					if (CS_0024_003C_003E8__locals20._003C_003E9__1 == null)
					{
						onComplete = (CS_0024_003C_003E8__locals20._003C_003E9__1 = delegate
						{
							//IL_034a->IL02af: Incompatible stack heights: 1 vs 0
							//IL_0371->IL02af: Incompatible stack heights: 1 vs 0
							//IL_00ff->IL02af: Incompatible stack heights: 1 vs 0
							//IL_0126->IL02af: Incompatible stack heights: 1 vs 0
							//IL_0155->IL02af: Incompatible stack heights: 1 vs 0
							//IL_0177->IL02af: Incompatible stack heights: 1 vs 0
							//IL_01a6->IL02af: Incompatible stack heights: 1 vs 0
							//IL_03bf->IL02af: Incompatible stack heights: 2 vs 0
							//IL_03e6->IL02af: Incompatible stack heights: 2 vs 0
							//IL_01d7->IL02af: Incompatible stack heights: 2 vs 0
							//IL_0200->IL02af: Incompatible stack heights: 2 vs 0
							//IL_0222->IL02af: Incompatible stack heights: 2 vs 0
							//IL_026f->IL02af: Incompatible stack heights: 2 vs 0
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
								{
									GameManager core = GM.Core;
									if ((object)GM.Core != null)
									{
										GameSessionData gameSessionData = core._gameSessionData;
										if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
										{
											Transform transform = gameSessionData._activeCharacter.transform;
											if ((object)transform != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v21 (UnityEngine.Transform)+10]");
												bool flag2 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v21 (UnityEngine.Transform)+10]");
												Transform.get_position_Injected((IntPtr)0, out Vector3 _);
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
													{
														GameManager core2 = GM.Core;
														if ((object)GM.Core != null)
														{
															GameSessionData gameSessionData2 = core2._gameSessionData;
															if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
															{
																Transform transform2 = gameSessionData2._activeCharacter.transform;
																if ((object)transform2 != null)
																{
																	bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																	Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
																	if ((object)GM.Core != null)
																	{
																		PhaserScene s_scene3 = ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null && s_scene3._renderer != null)
																		{
																			StageEventManager stageEventManager = CS_0024_003C_003E8__locals20._003C_003E4__this;
																			if (CS_0024_003C_003E8__locals20._003C_003E4__this != null && (object)stageEventManager._ourStage != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
																				EnemyController enemy = default(EnemyController);
																				InitEventEnemy(CS_0024_003C_003E8__locals20.eventId, enemy, CS_0024_003C_003E8__locals20.enemies);
																				StageEventManager stageEventManager2 = CS_0024_003C_003E8__locals20._003C_003E4__this;
																				if (CS_0024_003C_003E8__locals20._003C_003E4__this != null)
																				{
																					int num8 = stageEventManager2._003CSpawned_003Ek__BackingField + 1;
																					stageEventManager2._003CSpawned_003Ek__BackingField = num8;
																					int index = CS_0024_003C_003E8__locals20.index + 1;
																					CS_0024_003C_003E8__locals20.index = index;
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
							throw new NullReferenceException();
						});
					}
					float num4 = num / (float)CS_0024_003C_003E8__locals20.moreX;
					float num5 = (float)obj * num4;
					float duration2 = num5 * 0.001f;
					Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					obj++;
					flag = (byte)(obj - 1) != 0;
					continue;
				}
			}
			else if ((object)num2 != null)
			{
				action = null;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r10_v2 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass86_0._003CSpawnInSteps_003Eb__0);
				((Delegate)action).m_target = CS_0024_003C_003E8__locals20;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r10_v2 (Il2CppMethodInfo)+4C]");
				object obj2 = (nint)0 >> 4;
				object obj3 = obj2 & 1;
				nint num7;
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ r10_v2 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num7 = unchecked((nint)6447293664L);
						break;
					}
				}
				num7 = ((Delegate)action).method_ptr;
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				break;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			return;
		}
		object obj4 = 24;
		float duration3 = num * 0.001f;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		Timer timer2 = Timers.Register(duration3, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void PlayDiamondSquare(float? duration, int moreX = 1, EnemyType? moreY = null, float moreZ = 0f)
	{
		//IL_004f: Expected O, but got I4
		//IL_0081: Expected O, but got I4
		//IL_0109: Expected I, but got O
		//IL_011f: Expected O, but got I
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0196: Expected I, but got O
		//IL_01e0: Expected O, but got I4
		//IL_01f7: Expected I, but got I8
		//IL_017f: Expected I, but got I8
		_003C_003Ec__DisplayClass87_0 obj = new _003C_003Ec__DisplayClass87_0();
		obj._003C_003E4__this = this;
		obj.moreY = moreY;
		if ((object)moreY == null)
		{
			obj.moreY = (EnemyType?)(object)1;
		}
		if (moreX <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass87_1 obj2 = new _003C_003Ec__DisplayClass87_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			object obj3 = (flag ? 1 : 0) + (flag ? 1 : 0);
			float num = (obj2.length = (float)obj3 + 14f) * 0.5f;
			obj2.half = num;
			Action action = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass87_1._003CPlayDiamondSquare_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj4 = (nint)0 >> 4;
			object obj5 = obj4 & 1;
			nint num3;
			if (obj5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num3 = unchecked((nint)6447293664L);
					goto IL_01d7;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num3 = ((Delegate)action).method_ptr;
			goto IL_01d7;
			IL_01d7:
			object obj6 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			Timer timer = Timers.Register(0.030000001f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < moreX);
	}

	private unsafe void PlayDiamondRoad(float? duration, int moreX = 1, EnemyType? moreY = null, float moreZ = 0f)
	{
		//IL_004f: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		//IL_00f3: Expected O, but got I
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_016a: Expected I, but got O
		//IL_01b4: Expected O, but got I4
		//IL_01cb: Expected I, but got I8
		//IL_0153: Expected I, but got I8
		_003C_003Ec__DisplayClass88_0 obj = new _003C_003Ec__DisplayClass88_0();
		obj._003C_003E4__this = this;
		obj.moreY = moreY;
		if ((object)moreY == null)
		{
			obj.moreY = (EnemyType?)(object)1;
		}
		if (moreX <= 0)
		{
			return;
		}
		bool flag = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		do
		{
			_003C_003Ec__DisplayClass88_1 obj2 = new _003C_003Ec__DisplayClass88_1();
			obj2.CS_0024_003C_003E8__locals1 = obj;
			int width = (flag ? 1 : 0) + 4;
			obj2.width = width;
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass88_1._003CPlayDiamondRoad_003Eb__0);
			((Delegate)action).m_target = obj2;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_01ab;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_01ab;
			IL_01ab:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			Timer timer = Timers.Register(0.030000001f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
		}
		while ((flag ? 1 : 0) < moreX);
	}

	public List<EventTargetInstace> GetCurrentEventTargets()
	{
		return _eventTargets;
	}

	private void SabotagionEME(float? duration, int moreX, object moreY, float moreZ)
	{
		//IL_0017: Expected O, but got I4
		float duration2;
		float? num;
		if ((object)duration == null)
		{
			duration2 = 60000f;
			num = (float?)(object)1;
		}
		else
		{
			float num2 = default(float);
			duration2 = num2;
			num = duration;
		}
		if ((object)num != null)
		{
			Action<Vector2> action = null;
			((StageEventManager)(object)action).OnSabotagionEMESuccess((Vector2)this);
			Action action2 = OnSabotagionEMEFailure;
			float moreZ2 = default(float);
			Action<Vector2> onSuccess = default(Action<Vector2>);
			Action onFailure = default(Action);
			IEnumerator routine = _SabotageEMEWithCallbacks(duration2, moreX, moreY, moreZ2, onSuccess, onFailure);
			Coroutine coroutine = _ourStage.StartCoroutine(routine);
			return;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new NullReferenceException();
	}

	private void Sabotagion(float? duration, int moreX, object moreY, float moreZ)
	{
		//IL_005e: Expected O, but got I4
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float duration2;
		float? num;
		if ((object)duration == null)
		{
			duration2 = 60000f;
			num = (float?)(object)1;
		}
		else
		{
			float num2 = default(float);
			duration2 = num2;
			num = duration;
		}
		int targetLocation = GetTargetLocation(out var targetLocation2);
		GameManager core = GM.Core;
		string text = default(string);
		bool isPickleRush = default(bool);
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			if ((object)num != null)
			{
				if (moreY != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					bool flag = moreY != null;
					object obj = null;
					if (!flag)
					{
						obj = moreY;
					}
					if (obj == null)
					{
						throw new InvalidCastException();
					}
				}
				StartSabotagion(duration2, targetLocation, targetLocation2, text, isPickleRush);
				return;
			}
		}
		else if ((object)num != null)
		{
			if (moreY != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				bool flag2 = moreY != null;
				object obj2 = null;
				if (!flag2)
				{
					obj2 = moreY;
				}
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			OnlineStageManager._instance.SendStartSabotagion(duration2, targetLocation, targetLocation2, text, isPickleRush);
			return;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private unsafe int GetTargetLocation(out Vector2 targetLocation)
	{
		Stage ourStage = _ourStage;
		List<Vector2> specialLocations = ourStage._tilingTileset.GetSpecialLocations("EventTarget");
		int num = ChooseEventTargetIndex(specialLocations);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)num < (nint)0)
		{
			object obj = default(object);
			ref Vector2 reference = ref *(Vector2*)obj;
			return num;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		int result = default(int);
		return result;
	}

	private void Sabotage_PickleRush(float? duration, int moreX, object moreY, float moreZ)
	{
		//IL_005e: Expected O, but got I4
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		float duration2;
		float? num;
		if ((object)duration == null)
		{
			duration2 = 60000f;
			num = (float?)(object)1;
		}
		else
		{
			float num2 = default(float);
			duration2 = num2;
			num = duration;
		}
		object obj2;
		if (moreY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag = moreY != null;
			object obj = null;
			if (!flag)
			{
				obj = moreY;
			}
			bool flag2 = obj != null;
			obj2 = moreY;
			if (flag2)
			{
				goto IL_0292;
			}
		}
		obj2 = "eventLang/{SABOTAGE_PICKLE_RUSH}newsfeed";
		goto IL_0292;
		IL_0292:
		int targetLocation = GetTargetLocation(out var targetLocation2);
		GameManager core = GM.Core;
		string text = default(string);
		bool isPickleRush = default(bool);
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			if ((object)num != null)
			{
				if (obj2 != null)
				{
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					bool flag3 = obj3 != null;
					object obj4 = null;
					if (!flag3)
					{
						obj4 = obj2;
					}
					if (obj4 == null)
					{
						throw new InvalidCastException();
					}
				}
				StartSabotagion(duration2, targetLocation, targetLocation2, text, isPickleRush);
				return;
			}
		}
		else if ((object)num != null)
		{
			if (obj2 != null)
			{
				object obj5 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				bool flag4 = obj5 != null;
				object obj6 = null;
				if (!flag4)
				{
					obj6 = obj2;
				}
				if (obj6 == null)
				{
					throw new InvalidCastException();
				}
			}
			OnlineStageManager._instance.SendStartSabotagion(duration2, targetLocation, targetLocation2, text, isPickleRush);
			return;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private int ChooseEventTargetIndex(List<Vector2> eventTargets)
	{
		//IL_00e3: Expected O, but got I
		//IL_0488: Expected I4, but got O
		//IL_037c: Expected O, but got I
		//IL_03f4: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_02b3: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		List<int> list = new List<int>(0);
		int num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		int num2 = 0;
		int num3 = 0;
		int num9 = default(int);
		int length = default(int);
		int result = default(int);
		while (true)
		{
			int num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)num4 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
				if (num5 >= 0)
				{
					list.AddWithResize(num);
					num++;
					num2 = num;
					num3 = num;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
				if (num6 >= 0)
				{
					break;
				}
				num++;
				num3 = num;
				continue;
			}
			List<EventTargetInstace> eventTargets2 = _eventTargets;
			int num7 = 0;
			int num8 = 0;
			while (true)
			{
				if (num8 < eventTargets2._size)
				{
					List<EventTargetInstace> eventTargets3 = _eventTargets;
					if (num7 < eventTargets3._size)
					{
						EventTargetInstace[] items = eventTargets3._items;
						if (num7 >= items.Length)
						{
							break;
						}
						EventTargetInstace eventTargetInstace = items[num7];
						num2 = eventTargetInstace._eventTargetIndex;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
						((List<int>)0)._002Ector(eventTargetInstace._eventTargetIndex);
						if (num9 < 0)
						{
							goto IL_0493;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						if ((nint)num9 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj2 = -1;
							if (num9 < (nint)obj2)
							{
								num2 = num9 + 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
								nint num10 = 0;
								int sourceIndex = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
								Array.Copy((Array)num10, sourceIndex, (Array)0, num9, length);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							goto IL_0493;
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				bool flag = (nint)0 != 0;
				int num11 = 0;
				int capacity = num2;
				if (!flag)
				{
					while (true)
					{
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						bool flag2 = (nint)num12 >= (nint)0;
						capacity = num2;
						if (flag2)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
						if (num13 >= 0)
						{
							list.AddWithResize(num11);
							int num14 = num11 + 1;
							num2 = num11;
							num11 = num14;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj4 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
						if (num15 >= 0)
						{
							goto end_IL_0453;
						}
						num11++;
					}
				}
				list._002Ector(capacity);
				return result;
				IL_0493:
				eventTargets2 = _eventTargets;
				num7++;
				num8 = num7;
			}
			break;
			continue;
			end_IL_0453:
			break;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
	}

	public unsafe void StartSabotagion(float duration, int chosenEventTarget, Vector2 targetLocation, string newsFeed, bool isPickleRush)
	{
		IntPtr method = default(IntPtr);
		Action action = new Action(this, method);
		object obj = default(object);
		bool flag = obj != null;
		method = (nint)__ldftn(StageEventManager.OnSabotage_PickleRushFailure);
		if (!flag)
		{
			method = (nint)__ldftn(StageEventManager.OnSabotagionFailure);
		}
		Action<Vector2> action2 = null;
		((StageEventManager)(object)action2).OnSabotagionSuccess((Vector2)this);
		int moreX = default(int);
		object moreY = default(object);
		float moreZ = default(float);
		Action<Vector2> onSuccess = default(Action<Vector2>);
		IEnumerator routine = _SabotageWithCallbacks(duration, chosenEventTarget, targetLocation, moreX, moreY, moreZ, onSuccess, null);
		Coroutine coroutine = _ourStage.StartCoroutine(routine);
	}

	private IEnumerator _SabotageWithCallbacks(float duration, int chosenEventTarget, Vector2 targetLocation, int moreX, object moreY, float moreZ, Action<Vector2> onSuccess, Action onFailure)
	{
		_003C_SabotageWithCallbacks_003Ed__98 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.targetLocation = targetLocation;
		object moreY2 = default(object);
		obj.moreY = moreY2;
		obj.duration = duration;
		obj.chosenEventTarget = chosenEventTarget;
		Action<Vector2> onSuccess2 = default(Action<Vector2>);
		obj.onSuccess = onSuccess2;
		Action onFailure2 = default(Action);
		obj.onFailure = onFailure2;
		return obj;
	}

	private void OnSabotagionSuccess(Vector2 targetLocation)
	{
		//IL_0033: Expected F4, but got I4
		//IL_007d: Expected O, but got I
		//IL_00d7: Expected O, but got I
		//IL_04d4: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_04fc: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_0251: Expected O, but got I4
		//IL_0524: Expected O, but got I
		//IL_02d6: Expected O, but got I
		//IL_02bb: Expected O, but got I4
		//IL_054c: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_0325: Expected O, but got I4
		//IL_0574: Expected O, but got I
		//IL_03aa: Expected O, but got I
		//IL_038f: Expected O, but got I4
		//IL_059c: Expected O, but got I
		//IL_0414: Expected O, but got I
		//IL_03f9: Expected O, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_TaskComplete, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize(3f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1077936128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1092616192;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v7+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(50f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1112014848;
		}
		treasure._003Cchances_003Ek__BackingField = list;
		treasure._003Clevel_003Ek__BackingField = 3;
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
			}
		}
		Vector2 pos = default(Vector2);
		TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
	}

	private unsafe void OnSabotagionFailure()
	{
		//IL_0033: Expected F4, but got I4
		//IL_00f4: Expected I4, but got O
		//IL_0344: Expected F4, but got I4
		//IL_06ec: Expected O, but got I
		//IL_0394: Expected I, but got O
		//IL_03aa: Expected O, but got I
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_0424: Expected F4, but got I4
		//IL_015b: Expected I4, but got O
		//IL_0382: Expected O, but got I8
		//IL_044d: Expected I, but got O
		//IL_0600: Expected O, but got I4
		//IL_0613: Expected O, but got I4
		//IL_0625: Expected I, but got I8
		//IL_0672: Expected I4, but got F4
		//IL_0672: Expected O, but got F4
		//IL_040a: Expected I, but got I8
		//IL_0276: Expected I4, but got O
		//IL_0220: Expected I, but got O
		//IL_02ce: Expected O, but got I4
		//IL_04e7: Expected I, but got O
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Lid, 0f, 10, 0f, num, num2, num3, flag, 1f);
		GameManager core = GM.Core;
		bool flag2 = (object)GM.Core == null;
		int num4 = 10;
		bool useRealTime;
		if (!flag2)
		{
			bool flag3 = core._playerOptions == null;
			num4 = 10;
			if (!flag3)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				bool flag4 = config == null;
				num4 = 10;
				if (!flag4)
				{
					bool flag5 = !config._003CScreenShakeEnabled_003Ek__BackingField;
					Action action = null;
					num4 = 10;
					useRealTime = (byte)(int)num != 0;
					TweenConfig playerOptions = (TweenConfig)(object)core._playerOptions;
					if (flag5)
					{
						goto IL_0332;
					}
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					bool flag6 = (object)GM.Core == null;
					num4 = 10;
					if (!flag6)
					{
						useRealTime = (byte)(int)num != 0;
						PhaserScene s_scene = ArcadePhysics.s_scene;
						bool flag7 = ArcadePhysics.s_scene == null;
						num4 = 10;
						if (!flag7)
						{
							PhaserScene.CameraSet cameras = s_scene.cameras;
							bool flag8 = s_scene.cameras == null;
							num4 = 10;
							if (!flag8)
							{
								PhaserCamera main = cameras.main;
								bool flag9 = (object)cameras.main == null;
								num4 = 10;
								if (!flag9)
								{
									bool flag10 = array == null;
									num4 = 10;
									if (!flag10)
									{
										if (main.followOffset != null)
										{
											nint num5 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj = default(object);
											bool flag11 = obj == null;
											num4 = 10;
											if (flag11)
											{
												ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
												throw ex;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										bool flag12 = tweenConfig == null;
										num4 = (int)main.followOffset;
										if (!flag12)
										{
											tweenConfig.targets = array;
											tweenConfig.duration = 32f;
											tweenConfig.yoyo = true;
											tweenConfig.repeat = 128;
											tweenConfig.x = (float?)(object)1;
											TweenCallback onStart = _003C_003Ec._003C_003E9__100_0;
											bool flag13 = _003C_003Ec._003C_003E9__100_0 != null;
											nint num6 = (nint)main.followOffset;
											if (!flag13)
											{
												TweenCallback tweenCallback = (_003C_003Ec._003C_003E9__100_0 = delegate
												{
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													PhaserScene.CameraSet cameras2 = s_scene2.cameras;
													PhaserCamera main2 = cameras2.main;
													PhaserScene.BoxedVector2 followOffset = main2.followOffset;
													followOffset.x = -2f;
												});
												bool flag14 = false;
												onStart = tweenCallback;
												num6 = 0;
											}
											tweenConfig.onStart = onStart;
											TweenCallback onComplete = _003C_003Ec._003C_003E9__100_1;
											bool flag15 = _003C_003Ec._003C_003E9__100_1 != null;
											nint num7 = num6;
											if (!flag15)
											{
												TweenCallback tweenCallback2 = (_003C_003Ec._003C_003E9__100_1 = delegate
												{
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													PhaserScene.CameraSet cameras2 = s_scene2.cameras;
													PhaserCamera main2 = cameras2.main;
													PhaserScene.BoxedVector2 followOffset = main2.followOffset;
													followOffset.x = 0f;
													followOffset.y = 0f;
												});
												bool flag14 = false;
												onComplete = tweenCallback2;
												num7 = 0;
											}
											tweenConfig.onComplete = onComplete;
											num4 = (int)num7;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
											action = null;
											playerOptions = tweenConfig;
											goto IL_0332;
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
		IL_0332:
		bool flag16 = false;
		float num8 = 0f;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			TweenConfig playerOptions;
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				playerOptions = (TweenConfig)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v475 @ rax_v21 (should have been resolved before IL gen)");
			Action action2 = null;
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r10_v4 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(StageEventManager.SpawnLava);
			((Delegate)action2).m_target = this;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r10_v4 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num10;
			float num11;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ r10_v4 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num10 = unchecked((nint)6447293664L);
					goto IL_05f7;
				}
			}
			else
			{
				bool flag17 = this == null;
				num11 = 0f;
				num8 = 100f;
				if (flag17)
				{
					break;
				}
			}
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			num10 = ((Delegate)action2).method_ptr;
			goto IL_05f7;
			IL_05f7:
			object obj5 = 24;
			object obj6 = (flag16 ? 1 : 0) + 1;
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			float num12 = (float)obj6 * 200f;
			num11 = num12 * 0.001f;
			Timer timer = Timers.Register(num11, action2, null, isLooped: false, useRealTime, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			flag16 = (byte)((flag16 ? 1u : 0u) + 1u) != 0;
			bool flag18 = (flag16 ? 1 : 0) < 40;
			bool flag14 = false;
			Action action = action2;
			num8 = 100f;
			num4 = 0;
			playerOptions = (TweenConfig)(object)action2;
			if (!flag18)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
		object obj7 = default(object);
		throw obj7;
	}

	private unsafe void SpawnLava()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0b32: Expected I, but got O
		//IL_0b6e: Expected I, but got O
		//IL_0051: Expected O, but got I
		//IL_0bef: Expected I, but got O
		//IL_00b2: Expected I, but got I8
		//IL_00fb: Expected O, but got I
		//IL_015c: Expected I, but got I8
		//IL_0214: Expected O, but got F4
		//IL_02e0: Expected O, but got I4
		//IL_0419: Expected O, but got I4
		//IL_04f3: Expected O, but got I
		//IL_0768: Expected O, but got Ref
		//IL_077d: Expected native int or pointer, but got O
		//IL_0797: Expected O, but got I
		//IL_07b7: Expected O, but got Ref
		//IL_07d1: Expected native int or pointer, but got O
		//IL_07eb: Expected O, but got I
		//IL_080b: Expected O, but got Ref
		//IL_0825: Expected native int or pointer, but got O
		//IL_083f: Expected O, but got I
		//IL_085f: Expected O, but got Ref
		//IL_0879: Expected native int or pointer, but got O
		//IL_0ce2: Expected O, but got I4
		//IL_0897: Expected O, but got Ref
		//IL_08b8: Expected O, but got I
		//IL_08d2: Expected native int or pointer, but got O
		//IL_0cff: Expected O, but got I4
		//IL_08fd: Expected O, but got Ref
		//IL_091e: Expected O, but got I
		//IL_0938: Expected native int or pointer, but got O
		//IL_0d31: Expected O, but got I
		//IL_0a01: Expected I, but got O
		//IL_0a58: Expected I, but got O
		//IL_0ad1: Expected O, but got I
		//IL_0a24->IL0a24: Incompatible stack heights: 2 vs 1
		//IL_0a7b->IL0a7b: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass101_0 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass101_0();
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v3 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		if ((object)GM.Core != null)
		{
			nint num3 = (nint)typeof(ArcadePhysics);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v27 (Il2CppClass<ArcadePhysics>)+B8]");
			nint num4 = 0;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj3 == null)
						{
							MissingMethodException ex = new MissingMethodException();
							throw ex;
						}
						num4 = unchecked((nint)6573110936L);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v577 @ rax_v31 (should have been resolved before IL gen)");
					if ((object)GM.Core != null)
					{
						nint num5 = (nint)typeof(ArcadePhysics);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ rax_v35 (Il2CppClass<ArcadePhysics>)+B8]");
						nint num6 = 0;
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									if (obj4 == null)
									{
										MissingMethodException ex2 = new MissingMethodException();
										throw ex2;
									}
									num6 = unchecked((nint)6573110936L);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v774 @ rax_v39 (should have been resolved before IL gen)");
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene3 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer3 = s_scene3._renderer;
										if (s_scene3._renderer != null)
										{
											float num7 = -0.4f * renderer3.height;
											float num8 = renderer2.width * -0.4f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v29 (PhaserScene+Renderer)+38]");
											float num9 = 0f + num7;
											float num10 = (float)renderer.screenCenter + num8;
											if (CS_0024_003C_003E8__locals32 != null)
											{
												CS_0024_003C_003E8__locals32.position = (float2)num10;
												if ((object)_ourStage != null)
												{
													GameObject gameObject = _ourStage.gameObject;
													Vector2 pos = default(Vector2);
													PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "circle");
													if ((object)phaserSprite != null)
													{
														PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
														if ((object)phaserSprite2 != null)
														{
															PhaserSprite phaserSprite3 = phaserSprite2.setTint(16711680u);
															if ((object)phaserSprite3 != null)
															{
																PhaserSprite lavaSprite = phaserSprite3.setScale(0.5f, (float?)(object)0);
																CS_0024_003C_003E8__locals32.lavaSprite = lavaSprite;
																if ((object)CS_0024_003C_003E8__locals32.lavaSprite != null)
																{
																	float scale = CS_0024_003C_003E8__locals32.lavaSprite.scale;
																	float num11 = scale * 128f;
																	float circleRadius = num11 * 0.01f;
																	CS_0024_003C_003E8__locals32.circleRadius = circleRadius;
																	if ((object)_ourStage != null)
																	{
																		GameObject gameObject2 = _ourStage.gameObject;
																		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "ground");
																		if ((object)phaserSprite4 != null)
																		{
																			PhaserSprite phaserSprite5 = phaserSprite4.setTint(0u);
																			if ((object)phaserSprite5 != null)
																			{
																				PhaserSprite phaserSprite6 = phaserSprite5.setAlpha(0f);
																				if ((object)phaserSprite6 != null)
																				{
																					PhaserSprite crackSprite = phaserSprite6.setScale(0.5f, (float?)(object)0);
																					CS_0024_003C_003E8__locals32.crackSprite = crackSprite;
																					if ((object)CS_0024_003C_003E8__locals32.lavaSprite != null)
																					{
																						GameObject gameObject3 = CS_0024_003C_003E8__locals32.lavaSprite.gameObject;
																						nint num12 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1214 @ rdi_v13 (Il2CppMethodInfo)+38]");
																						if ((nint)0 == 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
																						}
																						_ = 0;
																						ParticleEmitterManager particleManager;
																						if (gameObject3.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 272))))
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																							particleManager = (ParticleEmitterManager)0;
																						}
																						else
																						{
																							particleManager = gameObject3.AddComponent<ParticleEmitterManager>();
																						}
																						CS_0024_003C_003E8__locals32.particleManager = particleManager;
																						Circle circle = new Circle();
																						float radius = CS_0024_003C_003E8__locals32.circleRadius * 100f;
																						circle._x = 0f;
																						circle._radius = radius;
																						EmitZone emitZone = new EmitZone();
																						emitZone._type = EmitZoneType.Random;
																						emitZone._source = circle;
																						CS_0024_003C_003E8__locals32.emitZone = emitZone;
																						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
																						List<string> list = new List<string>();
																						if (list != null)
																						{
																							int version = list._version + 1;
																							list._version = version;
																							string[] items = list._items;
																							if (list._items != null)
																							{
																								if (list._size >= items.Length)
																								{
																									((List<object>)(object)list).AddWithResize((object)"Smoke1");
																								}
																								else
																								{
																									int size = list._size + 1;
																									list._size = size;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								}
																								int version2 = list._version + 1;
																								list._version = version2;
																								string[] items2 = list._items;
																								if (list._items != null)
																								{
																									if (list._size >= items2.Length)
																									{
																										((List<object>)(object)list).AddWithResize((object)"Smoke2");
																									}
																									else
																									{
																										int size2 = list._size + 1;
																										list._size = size2;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																									}
																									if (particleSystemConfig != null)
																									{
																										particleSystemConfig._frame = list;
																										ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
																										_ = 0;
																										_ = 0;
																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
																										particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
																										_ = 0;
																										ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
																										_ = 0;
																										_ = 0;
																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
																										particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
																										_ = 0;
																										ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
																										_ = 0;
																										_ = 0;
																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(320f, 230f));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																										particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
																										_ = 0;
																										ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
																										_ = 0;
																										_ = 0;
																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
																										particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																										_ = 0;
																										ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
																										_ = 1;
																										_ = 1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																										particleSystemConfig._quantity = (int?)(object)0;
																										_ = 0;
																										_ = 0;
																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																										_ = 0;
																										particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
																										_ = 0;
																										_ = 0;
																										ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
																										_ = 1065353216;
																										_ = 1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																										particleSystemConfig._frequency = (float?)(object)0;
																										_ = 0;
																										_ = 0;
																										System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
																										_ = 0;
																										_ = 1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
																										particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
																										_ = 0;
																										particleSystemConfig._emitZone = CS_0024_003C_003E8__locals32.emitZone;
																										particleSystemConfig._on = true;
																										ParticleSystem pfxEmitter = CS_0024_003C_003E8__locals32.particleManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
																										CS_0024_003C_003E8__locals32.pfxEmitter = pfxEmitter;
																										Transform transform = CS_0024_003C_003E8__locals32.pfxEmitter.transform;
																										bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																										Vector2 value = default(Vector2);
																										Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
																										RenderingExtensions.Start(CS_0024_003C_003E8__locals32.pfxEmitter);
																										TweenConfig tweenConfig = new TweenConfig();
																										object[] array = new object[2];
																										if ((object)CS_0024_003C_003E8__locals32.lavaSprite != null)
																										{
																											nint num13 = (nint)array;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																											object obj5 = default(object);
																											bool flag2 = obj5 == null;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										if ((object)CS_0024_003C_003E8__locals32.crackSprite != null)
																										{
																											nint num14 = (nint)array;
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																											object obj6 = default(object);
																											bool flag3 = obj6 == null;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										tweenConfig.targets = array;
																										_ = 0;
																										tweenConfig.duration = 1000f;
																										_ = 1065353216;
																										_ = 1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
																										tweenConfig.alpha = (float?)(object)0;
																										TweenCallback onComplete = delegate
																										{
																											//IL_0008: Expected O, but got Ref
																											//IL_06e7: Expected O, but got F4
																											//IL_0068: Expected F4, but got I
																											//IL_06ff: Expected I4, but got I8
																											//IL_0703: Expected O, but got I4
																											//IL_070c: Unknown result type (might be due to invalid IL or missing references)
																											//IL_0711: Expected O, but got Unknown
																											//IL_023c: Expected O, but got Ref
																											//IL_0251: Expected native int or pointer, but got O
																											//IL_026b: Expected O, but got I
																											//IL_028b: Expected O, but got Ref
																											//IL_02a5: Expected native int or pointer, but got O
																											//IL_02bf: Expected O, but got I
																											//IL_02df: Expected O, but got Ref
																											//IL_0317: Expected native int or pointer, but got O
																											//IL_0331: Expected O, but got I
																											//IL_0351: Expected O, but got Ref
																											//IL_036b: Expected native int or pointer, but got O
																											//IL_0749: Expected O, but got I
																											//IL_03a9: Expected O, but got Ref
																											//IL_03ca: Expected O, but got I
																											//IL_03e4: Expected native int or pointer, but got O
																											//IL_0783: Expected O, but got I
																											//IL_0422: Expected O, but got Ref
																											//IL_0443: Expected O, but got I
																											//IL_045d: Expected native int or pointer, but got O
																											//IL_07bd: Expected O, but got I
																											//IL_054c: Expected O, but got I
																											//IL_083b: Expected O, but got I
																											//IL_05b1: Expected O, but got I8
																											//IL_05eb: Expected O, but got I8
																											//IL_06ac: Expected I4, but got F4
																											//IL_06ac: Expected O, but got F4
																											//IL_06ac: Expected I4, but got O
																											//IL_05b6->IL0821: Incompatible stack heights: 2 vs 1
																											//IL_05f0->IL08ac: Incompatible stack heights: 2 vs 1
																											object obj8 = default(object);
																											object obj7 = (object)(&obj8);
																											_003C_003Ec__DisplayClass101_1 CS_0024_003C_003E8__locals39 = new _003C_003Ec__DisplayClass101_1();
																											if (CS_0024_003C_003E8__locals39 != null)
																											{
																												CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals32;
																												_ = 0;
																												_ = 1065353216;
																												_ = 1;
																												object obj9 = UnityEngine.Random.value;
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
																												float? num15 = default(float?);
																												float num16 = default(float);
																												float num17 = default(float);
																												bool flag4 = default(bool);
																												PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.FireExplosion, 150f, 3, 0f, num15, num16, num17, flag4);
																												object obj10 = UnityEngine.Random.RandomRangeInt(-50, 50);
																												object obj11 = obj10 + 270;
																												ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
																												List<string> list2 = new List<string>();
																												list2._002Ector();
																												if (list2 != null)
																												{
																													int version3 = list2._version + 1;
																													list2._version = version3;
																													string[] items3 = list2._items;
																													if (list2._items != null)
																													{
																														if (list2._size >= items3.Length)
																														{
																															((List<object>)(object)list2).AddWithResize((object)"HitSmoke1");
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
																														if (list2._items != null)
																														{
																															if (list2._size >= items4.Length)
																															{
																																((List<object>)(object)list2).AddWithResize((object)"HitSmoke2");
																															}
																															else
																															{
																																int size4 = list2._size + 1;
																																list2._size = size4;
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																															}
																															if (particleSystemConfig2 != null)
																															{
																																particleSystemConfig2._frame = list2;
																																ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj8, 8));
																																_ = 0;
																																_ = 0;
																																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(500f));
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
																																particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
																																_ = 0;
																																ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj8, 24));
																																_ = 0;
																																_ = 0;
																																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
																																particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
																																_ = 0;
																																ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj8, 56));
																																float min = (float)obj11 + 10f;
																																float max = (float)obj11 - 10f;
																																_ = 0;
																																_ = 0;
																																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(min, max));
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
																																particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
																																_ = 0;
																																ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj8, 88));
																																_ = 0;
																																_ = 0;
																																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(200f, 300f));
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+68]");
																																_ = 0;
																																_ = 1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
																																particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
																																_ = 0;
																																_ = 0;
																																ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj8, 120));
																																_ = 5;
																																_ = 1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
																																particleSystemConfig2._quantity = (int?)(object)0;
																																_ = 0;
																																_ = 0;
																																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.5f, 0f));
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+78]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+88]");
																																_ = 0;
																																_ = 1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
																																particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
																																_ = 0;
																																_ = 0;
																																ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj8, 152));
																																_ = 1065353216;
																																_ = 1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
																																particleSystemConfig2._frequency = (float?)(object)0;
																																_ = 0;
																																_ = 0;
																																System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.5f, 0f));
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+98]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A8]");
																																_ = 0;
																																_ = 1;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
																																particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
																																_ = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
																																_ = 0;
																																particleSystemConfig2._emitZone = CS_0024_003C_003E8__locals32.emitZone;
																																particleSystemConfig2._on = true;
																																ParticleSystem pfxEmitter2 = CS_0024_003C_003E8__locals32.particleManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
																																CS_0024_003C_003E8__locals39.pfxEmitter2 = pfxEmitter2;
																																Transform transform2 = CS_0024_003C_003E8__locals39.pfxEmitter2.transform;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1231 @ rax_v71 (UnityEngine.Transform)+10]");
																																bool flag5 = (nint)0 == 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1231 @ rax_v71 (UnityEngine.Transform)+10]");
																																float value2 = default(float);
																																Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value2));
																																GravityWellConfig config = new GravityWellConfig
																																{
																																	_power = 1f,
																																	_epsilon = 50f,
																																	_gravity = 100f
																																};
																																GravityWell gravityWell = CS_0024_003C_003E8__locals32.particleManager.CreateGravityWell(config);
																																Transform transform3 = gravityWell.transform;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
																																object obj12 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
																																bool flag6 = (nint)0 != 0;
																																Component component = gravityWell;
																																if (!flag6)
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																																	bool flag7 = obj12 == null;
																																	component = (Component)6573110936L;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2027 @ rax_v81 (should have been resolved before IL gen)");
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
																																object obj13 = 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
																																if ((nint)0 == 0)
																																{
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
																																	bool flag8 = obj13 == null;
																																	component = (Component)6573110936L;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2051 @ rax_v84 (should have been resolved before IL gen)");
																																bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																																float value3 = default(float);
																																Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value3));
																																RenderingExtensions.Start(CS_0024_003C_003E8__locals39.pfxEmitter2);
																																Action onComplete2 = delegate
																																{
																																	//IL_007e: Expected I, but got O
																																	//IL_00e8: Expected I, but got O
																																	//IL_013e: Expected O, but got I4
																																	_003C_003Ec__DisplayClass101_0 obj14 = CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1;
																																	RenderingExtensions.StopEmitting(obj14.pfxEmitter);
																																	RenderingExtensions.StopEmitting(CS_0024_003C_003E8__locals39.pfxEmitter2);
																																	TweenConfig tweenConfig2 = new TweenConfig();
																																	object[] array2 = new object[2];
																																	_003C_003Ec__DisplayClass101_0 obj15 = CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1;
																																	if ((object)obj15.crackSprite != null)
																																	{
																																		nint num18 = (nint)array2;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																		object obj16 = default(object);
																																		if (obj16 == null)
																																		{
																																			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
																																			throw ex3;
																																		}
																																	}
																																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																	_003C_003Ec__DisplayClass101_0 obj17 = CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1;
																																	if ((object)obj17.lavaSprite != null)
																																	{
																																		nint num19 = (nint)array2;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																		object obj18 = default(object);
																																		if (obj18 == null)
																																		{
																																			ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
																																			throw ex4;
																																		}
																																	}
																																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																	tweenConfig2.targets = array2;
																																	tweenConfig2.alpha = (float?)(object)1;
																																	tweenConfig2.duration = 300f;
																																	_003C_003Ec__DisplayClass101_0 obj19 = CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1;
																																	TweenCallback onComplete3 = obj19._003C_003E9__3;
																																	if (obj19._003C_003E9__3 == null)
																																	{
																																		TweenCallback tweenCallback = delegate
																																		{
																																			GameObject gameObject4 = CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1.crackSprite.gameObject;
																																			UnityEngine.Object.Destroy(gameObject4, 0f);
																																			GameObject gameObject5 = CS_0024_003C_003E8__locals39.CS_0024_003C_003E8__locals1.lavaSprite.gameObject;
																																			UnityEngine.Object.Destroy(gameObject5, 0f);
																																		};
																																		onComplete3 = tweenCallback;
																																	}
																																	tweenConfig2.onComplete = onComplete3;
																																	MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																																};
																																Action<float> onUpdate = CS_0024_003C_003E8__locals32._003C_003E9__2;
																																if (CS_0024_003C_003E8__locals32._003C_003E9__2 == null)
																																{
																																	Action<float> action = null;
																																	float time = default(float);
																																	((_003C_003Ec__DisplayClass101_0)(object)action)._003CSpawnLava_003Eb__2(time);
																																	CS_0024_003C_003E8__locals32._003C_003E9__2 = action;
																																	onUpdate = action;
																																}
																																Timer timer = Timers.Register(2f, onComplete2, onUpdate, isLooped: false, (byte)(int)num15 != 0, (MonoBehaviour)num16, (int)num17, flag4 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
																																return;
																															}
																														}
																													}
																												}
																											}
																											throw new NullReferenceException();
																										};
																										tweenConfig.onComplete = onComplete;
																										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
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
			}
		}
		throw new NullReferenceException();
	}

	private void OnSabotage_PickleRushFailure()
	{
		//IL_0047: Expected F4, but got I4
		//IL_015c: Expected I4, but got I8
		//IL_0165: Expected O, but got I4
		//IL_00ce: Expected I4, but got F4
		//IL_00ce: Expected O, but got F4
		//IL_00ce: Expected I4, but got O
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		_003C_003Ec__DisplayClass102_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass102_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Scream, 0f, 10, 0f, num, num2, num3, flag, 1f);
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		CS_0024_003C_003E8__locals10.eventID = RandomEventId;
		CS_0024_003C_003E8__locals10.enemyType = EnemyType.CHAL_PICKLE_CIRCLE;
		SpawnCircleWave(EnemyType.CHAL_PICKLE_CIRCLE, RandomEventId, -1);
		object obj = 10000;
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals10._003C_003E9__0;
			if (CS_0024_003C_003E8__locals10._003C_003E9__0 == null)
			{
				Action action = delegate
				{
					//IL_0020: Expected I4, but got I8
					CS_0024_003C_003E8__locals10._003C_003E4__this.SpawnCircleWave(CS_0024_003C_003E8__locals10.enemyType, CS_0024_003C_003E8__locals10.eventID, -1);
				};
				StageEventManager stageEventManager = (StageEventManager)(CS_0024_003C_003E8__locals10 + 32);
				CS_0024_003C_003E8__locals10._003C_003E9__0 = action;
				onComplete = action;
			}
			float duration = (float)obj * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			obj += 10000;
		}
		while ((nint)obj <= 30000);
	}

	private int ChooseEMEEventTargetIndex(List<Vector2> eventTargets)
	{
		//IL_00e3: Expected O, but got I
		//IL_0488: Expected I4, but got O
		//IL_037c: Expected O, but got I
		//IL_03f4: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_02b3: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		List<int> list = new List<int>(0);
		int num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		int num2 = 0;
		int num3 = 0;
		int num9 = default(int);
		int length = default(int);
		int result = default(int);
		while (true)
		{
			int num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)num4 < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
				if (num5 >= 0)
				{
					list.AddWithResize(num);
					num++;
					num2 = num;
					num3 = num;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				object obj = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
				if (num6 >= 0)
				{
					break;
				}
				num++;
				num3 = num;
				continue;
			}
			List<EventTargetInstace> eventTargets2 = _eventTargets;
			int num7 = 0;
			int num8 = 0;
			while (true)
			{
				if (num8 < eventTargets2._size)
				{
					List<EventTargetInstace> eventTargets3 = _eventTargets;
					if (num7 < eventTargets3._size)
					{
						EventTargetInstace[] items = eventTargets3._items;
						if (num7 >= items.Length)
						{
							break;
						}
						EventTargetInstace eventTargetInstace = items[num7];
						num2 = eventTargetInstace._eventTargetIndex;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
						((List<int>)0)._002Ector(eventTargetInstace._eventTargetIndex);
						if (num9 < 0)
						{
							goto IL_0493;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						if ((nint)num9 < (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj2 = -1;
							if (num9 < (nint)obj2)
							{
								num2 = num9 + 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
								nint num10 = 0;
								int sourceIndex = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
								Array.Copy((Array)num10, sourceIndex, (Array)0, num9, length);
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							goto IL_0493;
						}
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
				bool flag = (nint)0 != 0;
				int num11 = 0;
				int capacity = num2;
				if (!flag)
				{
					while (true)
					{
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [eventTargets @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						bool flag2 = (nint)num12 >= (nint)0;
						capacity = num2;
						if (flag2)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
						if (num13 >= 0)
						{
							list.AddWithResize(num11);
							int num14 = num11 + 1;
							num2 = num11;
							num11 = num14;
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj4 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rdx_v8 (System.Int32)+18]");
						if (num15 >= 0)
						{
							goto end_IL_0453;
						}
						num11++;
					}
				}
				list._002Ector(capacity);
				return result;
				IL_0493:
				eventTargets2 = _eventTargets;
				num7++;
				num8 = num7;
			}
			break;
			continue;
			end_IL_0453:
			break;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
	}

	private IEnumerator _SabotageEMEWithCallbacks(float duration, int moreX, object moreY, float moreZ, Action<Vector2> onSuccess, Action onFailure)
	{
		_003C_SabotageEMEWithCallbacks_003Ed__104 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.moreY = moreY;
		Action<Vector2> onSuccess2 = default(Action<Vector2>);
		obj.onSuccess = onSuccess2;
		Action onFailure2 = default(Action);
		obj.onFailure = onFailure2;
		return obj;
	}

	private void OnSabotagionEMESuccess(Vector2 targetLocation)
	{
		//IL_0033: Expected F4, but got I4
		//IL_007d: Expected O, but got I
		//IL_00d7: Expected O, but got I
		//IL_04d4: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_04fc: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_0251: Expected O, but got I4
		//IL_0524: Expected O, but got I
		//IL_02d6: Expected O, but got I
		//IL_02bb: Expected O, but got I4
		//IL_054c: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_0325: Expected O, but got I4
		//IL_0574: Expected O, but got I
		//IL_03aa: Expected O, but got I
		//IL_038f: Expected O, but got I4
		//IL_059c: Expected O, but got I
		//IL_0414: Expected O, but got I
		//IL_03f9: Expected O, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_TaskComplete, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize(3f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1077936128;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(10f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1092616192;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v7+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(50f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1112014848;
		}
		treasure._003Cchances_003Ek__BackingField = list;
		treasure._003Clevel_003Ek__BackingField = 3;
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v686 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedInverse_003Ek__BackingField)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (!config2._003CVisuallyInvertStages_003Ek__BackingField)
			{
			}
		}
		Vector2 pos = default(Vector2);
		TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
	}

	private void OnSabotagionEMEFailure()
	{
		//IL_0047: Expected F4, but got I4
		//IL_015c: Expected I4, but got I8
		//IL_0165: Expected O, but got I4
		//IL_00ce: Expected I4, but got F4
		//IL_00ce: Expected O, but got F4
		//IL_00ce: Expected I4, but got O
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		_003C_003Ec__DisplayClass106_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass106_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Lid, 0f, 10, 0f, num, num2, num3, flag, 1f);
		int randomEventId = RandomEventId + 1;
		RandomEventId = randomEventId;
		CS_0024_003C_003E8__locals10.eventID = RandomEventId;
		CS_0024_003C_003E8__locals10.enemyType = EnemyType.CHAL_PICKLE_CIRCLE;
		SpawnCircleWave(EnemyType.CHAL_PICKLE_CIRCLE, RandomEventId, -1);
		object obj = 10000;
		do
		{
			Action onComplete = CS_0024_003C_003E8__locals10._003C_003E9__0;
			if (CS_0024_003C_003E8__locals10._003C_003E9__0 == null)
			{
				Action action = delegate
				{
					//IL_0020: Expected I4, but got I8
					CS_0024_003C_003E8__locals10._003C_003E4__this.SpawnCircleWave(CS_0024_003C_003E8__locals10.enemyType, CS_0024_003C_003E8__locals10.eventID, -1);
				};
				StageEventManager stageEventManager = (StageEventManager)(CS_0024_003C_003E8__locals10 + 32);
				CS_0024_003C_003E8__locals10._003C_003E9__0 = action;
				onComplete = action;
			}
			float duration = (float)obj * 0.001f;
			Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			obj += 10000;
		}
		while ((nint)obj <= 30000);
	}

	private void FB_BigFuzz_Pointer(float? duration, int moreX, object moreY, float moreZ)
	{
		float? num = default(float?);
		float num2 = default(float);
		float duration2 = (((object)num != null) ? num2 : 300000f);
		object moreY2;
		if (moreY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			bool flag = moreY != null;
			object obj = null;
			if (!flag)
			{
				obj = moreY;
			}
			bool flag2 = obj != null;
			moreY2 = moreY;
			if (flag2)
			{
				goto IL_017b;
			}
		}
		moreY2 = "eventLang/{FB_EVENT}";
		goto IL_017b;
		IL_017b:
		if (true)
		{
			Action<Vector2> action = null;
			((StageEventManager)(object)action)._003CFB_BigFuzz_Pointer_003Eb__107_0((Vector2)this);
			if (_003C_003Ec._003C_003E9__107_1 == null)
			{
				Action action2 = delegate
				{
				};
				_003C_003Ec._003C_003E9__107_1 = action2;
			}
			float moreZ2 = default(float);
			Action<Vector2> onSuccess = default(Action<Vector2>);
			Action onFailure = default(Action);
			IEnumerator routine = _FB_BigFuzz_Pointer(duration2, moreX, moreY2, moreZ2, onSuccess, onFailure);
			Coroutine coroutine = _ourStage.StartCoroutine(routine);
			return;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new NullReferenceException();
	}

	private IEnumerator _FB_BigFuzz_Pointer(float duration, int moreX, object moreY, float moreZ, Action<Vector2> onSuccess, Action onFailure)
	{
		_003C_FB_BigFuzz_Pointer_003Ed__108 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.duration = duration;
		obj.moreY = moreY;
		Action<Vector2> onSuccess2 = default(Action<Vector2>);
		obj.onSuccess = onSuccess2;
		Action onFailure2 = default(Action);
		obj.onFailure = onFailure2;
		return obj;
	}

	private unsafe void SpawnCircleWave(EnemyType enemyType, int eventID, int durationMillis = -1)
	{
		//IL_0208: Expected I, but got O
		//IL_021e: Expected O, but got I
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_02a2: Expected I, but got O
		//IL_0334: Expected O, but got I4
		//IL_034b: Expected I, but got I8
		//IL_027e: Expected I, but got I8
		_003C_003Ec__DisplayClass109_0 obj = new _003C_003Ec__DisplayClass109_0();
		obj._003C_003E4__this = this;
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float num = renderer2.height * 0.6f;
		float num2 = renderer.width * 0.6f;
		if (num2 > num)
		{
			obj.spawnCount = 30;
			List<EnemyController> enemies = new List<EnemyController>();
			obj.enemies = enemies;
		}
		bool flag = false;
		bool flag2 = false;
		Vector2 spawnPos = default(Vector2);
		bool flag3 = default(bool);
		while ((flag2 ? 1 : 0) < obj.spawnCount)
		{
			float num3 = (float)(flag ? 1 : 0) * ((float)Math.PI / 15f);
			double num4 = Math.Cos(num3);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm7,xmm0\"");
			double num5 = Math.Sin(num3);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
			GameObject gameObject = _ourStage.SpawnEnemy(enemyType, spawnPos, asRemote: false, flag3);
			EnemyController component = gameObject.GetComponent<EnemyController>();
			InitEventEnemy(eventID, component, obj.enemies);
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			flag2 = flag;
		}
		if (durationMillis <= 0)
		{
			return;
		}
		int num6 = _003CSpawned_003Ek__BackingField + obj.spawnCount;
		_003CSpawned_003Ek__BackingField = num6;
		Action action = null;
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass109_0._003CSpawnCircleWave_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj2 = (nint)0 >> 4;
		object obj3 = obj2 & 1;
		nint num8;
		if (obj3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ r10_v2 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num8 = unchecked((nint)6447293664L);
				goto IL_032b;
			}
		}
		num8 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_032b;
		IL_032b:
		object obj4 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		float duration = (float)durationMillis * 0.001f;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, action, null, isLooped: false, flag3, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private static void InitEventEnemy(int eventID, EnemyController enemy, List<EnemyController> enemies)
	{
		if ((object)enemy != null && ((UnityEngine.Object)enemy).m_CachedPtr != (IntPtr)0)
		{
			enemy._003CStageEventId_003Ek__BackingField = eventID;
			enemy._003CIsCullable_003Ek__BackingField = false;
			if (enemies != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
			}
		}
	}

	private unsafe void FB_Capsule_Event()
	{
		//IL_01cb: Expected I, but got O
		//IL_012b: Expected O, but got Ref
		//IL_012b: Expected O, but got Ref
		//IL_01e8->IL0175: Incompatible stack heights: 1 vs 0
		//IL_015d->IL0175: Incompatible stack heights: 1 vs 0
		//IL_0175->IL019a: Incompatible stack heights: 1 vs 0
		if ((object)GM.Core != null)
		{
			if (!GM.Core.IsStageHost)
			{
				return;
			}
			if ((object)_destructibleFactory != null)
			{
				ObjectPool pool = _destructibleFactory.GetPool(PropType.FB_CAPSULE);
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core._gameSessionData;
					if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						Transform transform = gameSessionData._activeCharacter.transform;
						if ((object)transform != null)
						{
							bool flag = ((StageEventManager)(object)transform)._gameSessionData == null;
							Transform.get_position_Injected((IntPtr)((StageEventManager)(object)transform)._gameSessionData, out Vector3 _);
							if ((object)pool != null)
							{
								object obj2 = default(object);
								object obj3 = default(object);
								GameObject obj = pool.GetObject((Vector3)(&obj2), (Quaternion)(&obj3));
								Destructible objectComponent = pool.GetObjectComponent<Destructible>(obj);
								if ((object)objectComponent != null)
								{
									objectComponent.Init(PropType.FB_CAPSULE);
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

	private void fnRosary()
	{
		Vector3 playerPos = PlayerPos;
		if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.ROSARY))
		{
			Vector2 pos = default(Vector2);
			Pickup pickup = PickupManager.CreatePickup(pos, ItemType.ROSARY);
		}
		GameManager core = GM.Core;
		Vector3 playerPos2 = PlayerPos;
		Vector3 playerPos3 = PlayerPos;
		core._gizmoManager.ShowHighlightAt(playerPos2.x, playerPos3.y);
	}

	public void fnPet()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 52 Invalid \"Jump target not found in method: 0x186E7C430\"");
		throw new NullReferenceException();
	}

	public void fnPetPlayer(VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0056: Expected F4, but got O
		GM.Core.DoPraise(player);
		GameManager core = GM.Core;
		float2 position = player.position;
		float2 position2 = player.position;
		float y = default(float);
		core._gizmoManager.ShowHighlightAt((float)position, y);
	}

	public void fnChicken()
	{
		//IL_00ee: Expected I, but got O
		//IL_0013: Expected O, but got I4
		//IL_012d: Expected I, but got O
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0035: Expected I, but got O
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		object obj = 0;
		Vector2 pos = default(Vector2);
		do
		{
			nint num3 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
			float num4 = 0f * ((float)Math.PI / 6f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,ebx\"");
			float num5 = 0f * ((float)Math.PI / 6f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if (!GM.Core.IsStageHost)
			{
				bool flag = NetworkItems.IsNetworkItem(ItemType.ROAST);
				num2 = unchecked((nint)null);
				if (flag)
				{
					goto IL_006d;
				}
			}
			Pickup pickup = PickupManager.CreatePickup(pos, ItemType.ROAST);
			num2 = 12;
			goto IL_006d;
			IL_006d:
			obj++;
		}
		while ((nint)obj < 12);
		GameManager core = GM.Core;
		Vector3 playerPos = PlayerPos;
		Vector3 playerPos2 = PlayerPos;
		core._gizmoManager.ShowHighlightAt(playerPos.x, playerPos2.y);
	}

	private void fnGoldFever()
	{
		GM.Core.TriggerGoldFever(10000f);
		Action onComplete = _003C_003Ec._003C_003E9__116_0;
		if (_003C_003Ec._003C_003E9__116_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__116_0 = delegate
			{
				GM.Core.TurnOnVacuumForGold();
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = _003C_003Ec._003C_003E9__116_1;
		if (_003C_003Ec._003C_003E9__116_1 == null)
		{
			onComplete2 = (_003C_003Ec._003C_003E9__116_1 = delegate
			{
				GM.Core.TurnOnVacuumForGold();
			});
		}
		Timer timer2 = Timers.Register(6.0000005f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = _003C_003Ec._003C_003E9__116_2;
		if (_003C_003Ec._003C_003E9__116_2 == null)
		{
			onComplete3 = (_003C_003Ec._003C_003E9__116_2 = delegate
			{
				GM.Core.TurnOnVacuumForGold();
			});
		}
		Timer timer3 = Timers.Register(9f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		GameManager core = GM.Core;
		Vector3 playerPos = PlayerPos;
		Vector3 playerPos2 = PlayerPos;
		core._gizmoManager.ShowHighlightAt(playerPos.x, playerPos2.y);
	}

	private void fnPassive()
	{
		//IL_0028: Expected O, but got I
		//IL_00a2: Expected O, but got I
		//IL_090b: Expected O, but got I
		//IL_010c: Expected O, but got I
		//IL_0953: Expected O, but got I
		//IL_0176: Expected O, but got I
		//IL_099b: Expected O, but got I
		//IL_01e0: Expected O, but got I
		//IL_09e3: Expected O, but got I
		//IL_024a: Expected O, but got I
		//IL_0a2b: Expected O, but got I
		//IL_02b4: Expected O, but got I
		//IL_0a73: Expected O, but got I
		//IL_031e: Expected O, but got I
		//IL_0abb: Expected O, but got I
		//IL_0388: Expected O, but got I
		//IL_0b03: Expected O, but got I
		//IL_03f2: Expected O, but got I
		//IL_0b4b: Expected O, but got I
		//IL_045c: Expected O, but got I
		//IL_0b93: Expected O, but got I
		//IL_04c6: Expected O, but got I
		//IL_0bdb: Expected O, but got I
		//IL_0530: Expected O, but got I
		//IL_0c23: Expected O, but got I
		//IL_059a: Expected O, but got I
		//IL_0c6b: Expected O, but got I
		//IL_0604: Expected O, but got I
		//IL_0cb3: Expected O, but got I
		//IL_066e: Expected O, but got I
		//IL_0cfb: Expected O, but got I
		//IL_06d8: Expected O, but got I
		//IL_0d43: Expected O, but got I
		//IL_0743: Expected O, but got I
		//IL_08b9: Expected O, but got I
		//IL_0deb->IL08ba: Incompatible stack heights: 1 vs 0
		//IL_0e12->IL08ba: Incompatible stack heights: 1 vs 0
		//IL_0805->IL08ba: Incompatible stack heights: 1 vs 0
		//IL_0853->IL08ba: Incompatible stack heights: 1 vs 0
		//IL_0891->IL08ba: Incompatible stack heights: 1 vs 0
		List<WeaponType> list = new List<WeaponType>();
		if (list != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v8+18]");
				if (num >= 0)
				{
					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)55);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					object obj2 = (nint)0 + (nint)1;
					_ = 55;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v10+18]");
					if (num2 >= 0)
					{
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)51);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						object obj4 = (nint)0 + (nint)1;
						_ = 51;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v12+18]");
						if (num3 >= 0)
						{
							((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)57);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							object obj6 = (nint)0 + (nint)1;
							_ = 57;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v14+18]");
							if (num4 >= 0)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)53);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								object obj8 = (nint)0 + (nint)1;
								_ = 53;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v16+18]");
								if (num5 >= 0)
								{
									((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)66);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									object obj10 = (nint)0 + (nint)1;
									_ = 66;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								object obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v18+18]");
									if (num6 >= 0)
									{
										((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)54);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										object obj12 = (nint)0 + (nint)1;
										_ = 54;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
									object obj13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v20+18]");
										if (num7 >= 0)
										{
											((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)62);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
											object obj14 = (nint)0 + (nint)1;
											_ = 62;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
										object obj15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v22+18]");
											if (num8 >= 0)
											{
												((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)60);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
												object obj16 = (nint)0 + (nint)1;
												_ = 60;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
											object obj17 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
												nint num9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v24+18]");
												if (num9 >= 0)
												{
													((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)61);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
													object obj18 = (nint)0 + (nint)1;
													_ = 61;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
												object obj19 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
													nint num10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v26+18]");
													if (num10 >= 0)
													{
														((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)59);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
														object obj20 = (nint)0 + (nint)1;
														_ = 59;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
													_ = (nint)0 + (nint)1;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
													object obj21 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
														nint num11 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v28+18]");
														if (num11 >= 0)
														{
															((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)56);
														}
														else
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
															object obj22 = (nint)0 + (nint)1;
															_ = 56;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
														_ = (nint)0 + (nint)1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
														object obj23 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
															nint num12 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v30+18]");
															if (num12 >= 0)
															{
																((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)50);
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																object obj24 = (nint)0 + (nint)1;
																_ = 50;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
															_ = (nint)0 + (nint)1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
															object obj25 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																nint num13 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v32+18]");
																if (num13 >= 0)
																{
																	((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)58);
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																	object obj26 = (nint)0 + (nint)1;
																	_ = 58;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																_ = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																object obj27 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																	nint num14 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v34+18]");
																	if (num14 >= 0)
																	{
																		((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)65);
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																		object obj28 = (nint)0 + (nint)1;
																		_ = 65;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																	_ = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																	object obj29 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																	if ((nint)0 != 0)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																		nint num15 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v36+18]");
																		if (num15 >= 0)
																		{
																			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)63);
																		}
																		else
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																			object obj30 = (nint)0 + (nint)1;
																			_ = 63;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																		_ = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																		object obj31 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																		if ((nint)0 != 0)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																			nint num16 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v38+18]");
																			if (num16 >= 0)
																			{
																				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)52);
																			}
																			else
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																				object obj32 = (nint)0 + (nint)1;
																				_ = 52;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
																			_ = (nint)0 + (nint)1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																			object obj33 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																				nint num17 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v40+18]");
																				if (num17 >= 0)
																				{
																					((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)77);
																				}
																				else
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
																					object obj34 = (nint)0 + (nint)1;
																					_ = 77;
																				}
																				WeaponType weaponType = VampireSurvivors.App.Tools.Extensions.PickRnd(list);
																				GameManager core = GM.Core;
																				if ((object)GM.Core != null)
																				{
																					GameSessionData gameSessionData = core._gameSessionData;
																					if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
																					{
																						Transform transform = gameSessionData._activeCharacter.transform;
																						if ((object)transform != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v32 (UnityEngine.Transform)+10]");
																							bool flag = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v32 (UnityEngine.Transform)+10]");
																							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
																							if ((object)GM.Core != null)
																							{
																								PhaserScene s_scene = ArcadePhysics.s_scene;
																								if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
																								{
																									Vector2 pos = default(Vector2);
																									float value = default(float);
																									ItemType relicType = default(ItemType);
																									bool validatePickups = default(bool);
																									Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, weaponType, value, relicType, validatePickups);
																									List<WeaponType> core2 = (List<WeaponType>)(object)GM.Core;
																									if ((object)GM.Core != null)
																									{
																										Vector3 playerPos = PlayerPos;
																										Vector3 playerPos2 = PlayerPos;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rbx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+148]");
																										if ((nint)0 != 0)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rbx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+148]");
																											((GizmoManager)0).ShowHighlightAt(playerPos.x, playerPos2.y);
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
				}
			}
		}
		throw new NullReferenceException();
	}

	private void fnLights()
	{
		GameManager core = GM.Core;
		core._stage.DebugSpawnDestructibles();
	}

	private void fnNduja()
	{
		//IL_00f3->IL0154: Incompatible stack heights: 1 vs 0
		//IL_012e->IL0154: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Transform transform = gameSessionData._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.NFT))
					{
						Vector2 pos = default(Vector2);
						Pickup pickup = PickupManager.CreatePickup(pos, ItemType.NFT);
					}
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						Vector3 playerPos = PlayerPos;
						Vector3 playerPos2 = PlayerPos;
						if (core2._gizmoManager != null)
						{
							core2._gizmoManager.ShowHighlightAt(playerPos.x, playerPos2.y);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void fnClover()
	{
		//IL_0013: Expected I, but got O
		//IL_0053: Expected O, but got I4
		//IL_01b5: Expected I, but got O
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0112: Expected I, but got O
		nint num = (nint)typeof(GM);
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		object obj = 0;
		Vector2 pos = default(Vector2);
		while (true)
		{
			nint num2 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num3 = 0f * 3.7699113f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,edi\"");
			float num4 = 0f * 3.7699113f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if (!GM.Core.IsStageHost && NetworkItems.IsNetworkItem(ItemType.CLOVER))
			{
				break;
			}
			Pickup pickup = PickupManager.CreatePickup(pos, ItemType.CLOVER);
			pickup._goToPlayer = true;
			PhysicsManager sInstance = PhysicsManager._sInstance;
			Group obj2 = sInstance._goToPlayerPickupGroup.add(pickup);
			PhysicsManager sInstance2 = PhysicsManager._sInstance;
			sInstance2._pickupGroup.remove(pickup);
			obj++;
			pickup.Time = 1f;
			bool flag = (nint)obj < 5;
			num = (nint)pickup;
			if (!flag)
			{
				GameManager core2 = GM.Core;
				Vector3 playerPos = PlayerPos;
				Vector3 playerPos2 = PlayerPos;
				core2._gizmoManager.ShowHighlightAt(playerPos.x, playerPos2.y);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void fnSkull()
	{
	}

	private void fnUltraWave()
	{
		_003C_003Ec__DisplayClass122_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass122_0();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		CS_0024_003C_003E8__locals2.saveSpawnType = stage._spawnType;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		stage2._spawnType = SpawnType.TILED;
		Action onComplete = delegate
		{
			GameManager core3 = GM.Core;
			Stage stage3 = core3._stage;
			stage3._spawnType = CS_0024_003C_003E8__locals2.saveSpawnType;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void fnSummonMolise()
	{
		//IL_0089: Expected O, but got I
		//IL_00e3: Expected O, but got I
		//IL_00c8: Expected O, but got I4
		//IL_03eb: Expected O, but got I
		//IL_014d: Expected O, but got I
		//IL_0132: Expected O, but got I4
		//IL_0413: Expected O, but got I
		//IL_01b7: Expected O, but got I
		//IL_019c: Expected O, but got I4
		//IL_043b: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0206: Expected O, but got I4
		//IL_0463: Expected O, but got I
		//IL_028b: Expected O, but got I
		//IL_0270: Expected O, but got I4
		_003C_003Ec__DisplayClass123_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass123_0();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		CS_0024_003C_003E8__locals2.saveSpawnType = stage._spawnType;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		stage2._spawnType = SpawnType.TILED;
		List<EnemyType?> list = new List<EnemyType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v9+18]");
		if (num3 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v11+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v13+18]");
		if (num5 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		StageData stageData = stage3._stageData;
		stageData._003Cminimum_003Ek__BackingField = 500;
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		stage4._maximum = 500;
		GameManager core5 = GM.Core;
		Stage stage5 = core5._stage;
		StageData stageData2 = stage5._stageData;
		stageData2._003Cfrequency_003Ek__BackingField = 100f;
		GameManager core6 = GM.Core;
		core6._stage.UpdateNormalEnemyPoolsOnly(list);
		Action onComplete = delegate
		{
			GameManager core7 = GM.Core;
			Stage stage6 = core7._stage;
			stage6._spawnType = CS_0024_003C_003E8__locals2.saveSpawnType;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void fnSummonNight()
	{
		//IL_0089: Expected O, but got I
		//IL_00e3: Expected O, but got I
		//IL_00c8: Expected O, but got I4
		//IL_03a7: Expected O, but got I
		//IL_014d: Expected O, but got I
		//IL_0132: Expected O, but got I4
		//IL_03cf: Expected O, but got I
		//IL_01b7: Expected O, but got I
		//IL_019c: Expected O, but got I4
		//IL_03f7: Expected O, but got I
		//IL_0221: Expected O, but got I
		//IL_0206: Expected O, but got I4
		//IL_041f: Expected O, but got I
		//IL_028b: Expected O, but got I
		//IL_0270: Expected O, but got I4
		//IL_0447: Expected O, but got I
		//IL_02f5: Expected O, but got I
		//IL_02da: Expected O, but got I4
		_003C_003Ec__DisplayClass124_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass124_0();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		CS_0024_003C_003E8__locals2.saveSpawnType = stage._spawnType;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		stage2._spawnType = SpawnType.TILED;
		List<EnemyType?> list = new List<EnemyType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v9+18]");
		if (num3 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v11+18]");
		if (num4 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v13+18]");
		if (num5 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v15+18]");
		if (num6 >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ rax_v9 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		GameManager core3 = GM.Core;
		core3._stage.UpdateNormalEnemyPoolsOnly(list);
		Action onComplete = delegate
		{
			GameManager core4 = GM.Core;
			Stage stage3 = core4._stage;
			stage3._spawnType = CS_0024_003C_003E8__locals2.saveSpawnType;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void fnMinuteOfPanic()
	{
		//IL_00ac: Expected O, but got I
		//IL_0106: Expected O, but got I
		//IL_00eb: Expected O, but got I4
		//IL_0162: Expected O, but got I
		//IL_01bc: Expected O, but got I
		//IL_01a1: Expected O, but got I4
		//IL_0218: Expected O, but got I
		//IL_0272: Expected O, but got I
		//IL_0257: Expected O, but got I4
		_003C_003Ec__DisplayClass125_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass125_0();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		CS_0024_003C_003E8__locals2.saveSpawnType = stage._spawnType;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		stage2._spawnType = SpawnType.TILED;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		List<EnemyType?> enemyTypes = stage3._enemyTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v3+18]");
		if (num >= 0)
		{
			enemyTypes.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v13 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		List<EnemyType?> enemyTypes2 = stage4._enemyTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v5+18]");
		if (num2 >= 0)
		{
			enemyTypes2.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v17 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1;
		}
		GameManager core5 = GM.Core;
		Stage stage5 = core5._stage;
		List<EnemyType?> enemyTypes3 = stage5._enemyTypes;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v7+18]");
		if (num3 >= 0)
		{
			enemyTypes3.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v21 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1;
		}
		GameManager core6 = GM.Core;
		Stage stage6 = core6._stage;
		StageData stageData = stage6._stageData;
		int num4 = stageData._003Cminimum_003Ek__BackingField + 50;
		stageData._003Cminimum_003Ek__BackingField = num4;
		GameManager core7 = GM.Core;
		Stage stage7 = core7._stage;
		core7._stage.UpdateNormalEnemyPoolsOnly(stage7._enemyTypes);
		Action onComplete = delegate
		{
			GameManager core8 = GM.Core;
			Stage stage8 = core8._stage;
			stage8._spawnType = CS_0024_003C_003E8__locals2.saveSpawnType;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void fnCandybox()
	{
		//IL_00f2: Expected I, but got O
		//IL_0100: Expected I, but got O
		//IL_0110: Expected O, but got I
		//IL_0190: Expected O, but got I4
		//IL_014c: Expected O, but got I
		//IL_0182: Expected O, but got I4
		//IL_01f4: Expected F4, but got O
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float2 position = gameSessionData._activeCharacter.position;
		GameManager core2 = GM.Core;
		GameSessionData gameSessionData2 = core2._gameSessionData;
		float2 position2 = gameSessionData2._activeCharacter.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.height * 0.45f;
		object obj = default(object);
		float y = num + (float)obj;
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.CANDYBOX, value, relicType, validatePickups);
		bool flag = (object)pickup == null;
		Pickup pickup2 = null;
		object obj4;
		if (!flag)
		{
			nint num2 = (nint)pickup;
			nint num3 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v37+FFFFFFF8+v328 @ rax_v33*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj4 = 1;
					goto IL_0216;
				}
			}
			obj4 = 0;
			goto IL_0216;
		}
		goto IL_023d;
		IL_023d:
		if ((object)pickup2 != null && ((UnityEngine.Object)pickup2).m_CachedPtr != (IntPtr)0)
		{
			_ = 0;
		}
		GameManager core3 = GM.Core;
		core3._gizmoManager.ShowHighlightAt((float)position, y);
		return;
		IL_0216:
		bool flag2 = obj4 == null;
		pickup2 = null;
		if (!flag2)
		{
			pickup2 = pickup;
		}
		goto IL_023d;
	}

	private void fnHighGravity(float? duration)
	{
	}

	private void fnCrabFest()
	{
		//IL_00be: Expected O, but got I
		//IL_0118: Expected O, but got I
		//IL_00fd: Expected O, but got I4
		_003C_003Ec__DisplayClass128_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass128_0();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		CS_0024_003C_003E8__locals2.saveSpawnType = stage._spawnType;
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		stage2._spawnType = SpawnType.TILED;
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		StageData stageData = stage3._stageData;
		List<EnemyType?> list = stageData._003Cenemies_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r8_v3+18]");
		if (num >= 0)
		{
			list.AddWithResize((EnemyType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v12 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.EnemyType>>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1;
		}
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		StageData stageData2 = stage4._stageData;
		int num2 = stageData2._003Cminimum_003Ek__BackingField + 50;
		stageData2._003Cminimum_003Ek__BackingField = num2;
		GameManager core5 = GM.Core;
		Stage stage5 = core5._stage;
		StageData stageData3 = stage5._stageData;
		stage5.UpdateNormalEnemyPoolsOnly(stageData3._003Cenemies_003Ek__BackingField);
		Action onComplete = delegate
		{
			GameManager core6 = GM.Core;
			Stage stage6 = core6._stage;
			stage6._spawnType = CS_0024_003C_003E8__locals2.saveSpawnType;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(30.000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void fnRemoveWalls()
	{
	}

	private unsafe void fnInvaders(float? duration, int moreX, object moreY, float moreZ)
	{
		//IL_0045: Expected O, but got I4
		//IL_009b: Expected I, but got O
		//IL_00a3: Expected I, but got O
		//IL_00b3: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_01f5: Expected I, but got O
		//IL_020b: Expected O, but got I
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0282: Expected I, but got O
		//IL_02e2: Expected O, but got I4
		//IL_02f5: Expected O, but got I4
		//IL_0307: Expected I, but got I8
		//IL_026b: Expected I, but got I8
		_003C_003Ec__DisplayClass130_0 obj = new _003C_003Ec__DisplayClass130_0();
		obj._003C_003E4__this = this;
		bool flag = (object)duration != null;
		float? num = duration;
		if (!flag)
		{
			num = (float?)(object)1;
		}
		if ((object)num != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r15d,dword ptr [rsp+6Ch]\"");
			if (moreY == null)
			{
				return;
			}
			nint num2 = (nint)typeof(JArray);
			nint num3 = (nint)moreY;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rdx_v5 (Il2CppClass<Newtonsoft.Json.Linq.JArray>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ r8_v5 (Il2CppClass<System.Object>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rdx_v5 (Il2CppClass<Newtonsoft.Json.Linq.JArray>)+130]");
			if (num4 < 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ r8_v5 (Il2CppClass<System.Object>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rax_v13+FFFFFFF8+v414 @ rax_v12*8]");
			if (0 != (nint)typeof(JArray))
			{
				return;
			}
			string value = moreY.ToString();
			List<EnemyType> list = JsonConvert.DeserializeObject<List<EnemyType>>(value);
			obj.list = list;
			obj.sameType = moreX;
			object obj4 = default(object);
			if ((nint)obj4 <= 0)
			{
				return;
			}
			bool flag2 = false;
			object obj11 = default(object);
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				_003C_003Ec__DisplayClass130_1 obj5 = new _003C_003Ec__DisplayClass130_1();
				obj5.CS_0024_003C_003E8__locals1 = obj;
				obj5.localI = (flag2 ? 1 : 0);
				Action action = null;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r10_v5 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass130_1._003CfnInvaders_003Eb__0);
				((Delegate)action).m_target = obj5;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r10_v5 (Il2CppMethodInfo)+4C]");
				object obj6 = (nint)0 >> 4;
				object obj7 = obj6 & 1;
				nint num6;
				if (obj7 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ r10_v5 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num6 = unchecked((nint)6447293664L);
						goto IL_02d9;
					}
				}
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				num6 = ((Delegate)action).method_ptr;
				goto IL_02d9;
				IL_02d9:
				object obj8 = 24;
				object obj9 = (flag2 ? 1 : 0) + 1;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				object obj10 = obj9 * obj11;
				float duration2 = (float)obj10 * 0.001f;
				Timer timer = Timers.Register(duration2, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			}
			while ((flag2 ? 1 : 0) < (nint)obj4);
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	private unsafe void DebugAddConsoleCommands()
	{
		//IL_28e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e6: Expected O, but got Unknown
		//IL_2930: Unknown result type (might be due to invalid IL or missing references)
		//IL_2935: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected O, but got Unknown
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected O, but got Unknown
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Expected O, but got Unknown
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Expected O, but got Unknown
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a4: Expected O, but got Unknown
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Expected O, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Expected O, but got Unknown
		//IL_08b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b6: Expected O, but got Unknown
		//IL_0916: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected O, but got Unknown
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Expected O, but got Unknown
		//IL_09d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d9: Expected O, but got Unknown
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2d: Expected O, but got Unknown
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Expected O, but got Unknown
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Expected O, but got Unknown
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Expected O, but got Unknown
		//IL_0b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba4: Expected O, but got Unknown
		//IL_0c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c09: Expected O, but got Unknown
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5d: Expected O, but got Unknown
		//IL_0cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Expected O, but got Unknown
		//IL_0d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d21: Expected O, but got Unknown
		//IL_0d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d80: Expected O, but got Unknown
		//IL_0dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Expected O, but got Unknown
		//IL_0e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Expected O, but got Unknown
		//IL_0e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e92: Expected O, but got Unknown
		//IL_0ef2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef7: Expected O, but got Unknown
		//IL_0f46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4b: Expected O, but got Unknown
		//IL_0fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb5: Expected O, but got Unknown
		//IL_1004: Unknown result type (might be due to invalid IL or missing references)
		//IL_1009: Expected O, but got Unknown
		//IL_1069: Unknown result type (might be due to invalid IL or missing references)
		//IL_106e: Expected O, but got Unknown
		//IL_10bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c2: Expected O, but got Unknown
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_112c: Expected O, but got Unknown
		//IL_117b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1180: Expected O, but got Unknown
		//IL_11e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e5: Expected O, but got Unknown
		//IL_1234: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected O, but got Unknown
		//IL_129e: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a3: Expected O, but got Unknown
		//IL_12f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f7: Expected O, but got Unknown
		//IL_136e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1373: Expected O, but got Unknown
		//IL_13ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b0: Expected O, but got Unknown
		//IL_1415: Unknown result type (might be due to invalid IL or missing references)
		//IL_141a: Expected O, but got Unknown
		//IL_1469: Unknown result type (might be due to invalid IL or missing references)
		//IL_146e: Expected O, but got Unknown
		//IL_14ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d3: Expected O, but got Unknown
		//IL_1522: Unknown result type (might be due to invalid IL or missing references)
		//IL_1527: Expected O, but got Unknown
		//IL_158c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1591: Expected O, but got Unknown
		//IL_15e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e5: Expected O, but got Unknown
		//IL_1645: Unknown result type (might be due to invalid IL or missing references)
		//IL_164a: Expected O, but got Unknown
		//IL_1699: Unknown result type (might be due to invalid IL or missing references)
		//IL_169e: Expected O, but got Unknown
		//IL_1703: Unknown result type (might be due to invalid IL or missing references)
		//IL_1708: Expected O, but got Unknown
		//IL_1757: Unknown result type (might be due to invalid IL or missing references)
		//IL_175c: Expected O, but got Unknown
		//IL_17bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c1: Expected O, but got Unknown
		//IL_1810: Unknown result type (might be due to invalid IL or missing references)
		//IL_1815: Expected O, but got Unknown
		//IL_187a: Unknown result type (might be due to invalid IL or missing references)
		//IL_187f: Expected O, but got Unknown
		//IL_18ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d3: Expected O, but got Unknown
		//IL_1933: Unknown result type (might be due to invalid IL or missing references)
		//IL_1938: Expected O, but got Unknown
		//IL_198c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1991: Expected O, but got Unknown
		//IL_19f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fb: Expected O, but got Unknown
		//IL_1a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4f: Expected O, but got Unknown
		//IL_1aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab4: Expected O, but got Unknown
		//IL_1b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0d: Expected O, but got Unknown
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b82: Expected O, but got Unknown
		//IL_1bbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc0: Expected O, but got Unknown
		//IL_1bcf: Expected I4, but got O
		//IL_1bdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be1: Expected O, but got Unknown
		//IL_1bf5: Expected native int or pointer, but got O
		//IL_1c08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c0d: Expected O, but got Unknown
		//IL_1c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c74: Expected O, but got Unknown
		//IL_1cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc8: Expected O, but got Unknown
		//IL_1d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2d: Expected O, but got Unknown
		//IL_1d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d81: Expected O, but got Unknown
		//IL_1de6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1deb: Expected O, but got Unknown
		//IL_1e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3f: Expected O, but got Unknown
		//IL_1eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebb: Expected O, but got Unknown
		//IL_1ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef8: Expected O, but got Unknown
		//IL_1f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f62: Expected O, but got Unknown
		//IL_1fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb6: Expected O, but got Unknown
		//IL_2016: Unknown result type (might be due to invalid IL or missing references)
		//IL_201b: Expected O, but got Unknown
		//IL_206a: Unknown result type (might be due to invalid IL or missing references)
		//IL_206f: Expected O, but got Unknown
		//IL_20d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d9: Expected O, but got Unknown
		//IL_2128: Unknown result type (might be due to invalid IL or missing references)
		//IL_212d: Expected O, but got Unknown
		//IL_218d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2192: Expected O, but got Unknown
		//IL_21e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e6: Expected O, but got Unknown
		//IL_224b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2250: Expected O, but got Unknown
		//IL_229f: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a4: Expected O, but got Unknown
		//IL_2304: Unknown result type (might be due to invalid IL or missing references)
		//IL_2309: Expected O, but got Unknown
		//IL_2358: Unknown result type (might be due to invalid IL or missing references)
		//IL_235d: Expected O, but got Unknown
		//IL_23c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c7: Expected O, but got Unknown
		//IL_2416: Unknown result type (might be due to invalid IL or missing references)
		//IL_241b: Expected O, but got Unknown
		//IL_247b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2480: Expected O, but got Unknown
		//IL_24cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d4: Expected O, but got Unknown
		//IL_2539: Unknown result type (might be due to invalid IL or missing references)
		//IL_253e: Expected O, but got Unknown
		//IL_258d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2592: Expected O, but got Unknown
		//IL_25f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f7: Expected O, but got Unknown
		//IL_2646: Unknown result type (might be due to invalid IL or missing references)
		//IL_264b: Expected O, but got Unknown
		//IL_26c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cc: Expected O, but got Unknown
		//IL_2704: Unknown result type (might be due to invalid IL or missing references)
		//IL_2709: Expected O, but got Unknown
		//IL_2769: Unknown result type (might be due to invalid IL or missing references)
		//IL_276e: Expected O, but got Unknown
		//IL_27bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c2: Expected O, but got Unknown
		//IL_2827: Unknown result type (might be due to invalid IL or missing references)
		//IL_282c: Expected O, but got Unknown
		//IL_287b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2880: Expected O, but got Unknown
		object obj2 = default(object);
		Enum obj = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = 0;
		_ = -1;
		string text = obj.ToString();
		string command = "SE_" + text;
		_ = typeof(StageEventType);
		Enum obj3 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 0;
		string text2 = obj3.ToString();
		string description = text2 + " StageEvent";
		Action method = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlayCircle((float?)(object)0, 100, EnemyType.FLOWER, moreZ);
		};
		DebugLogConsole.AddCommand(command, description, method);
		Enum obj4 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 1;
		string text3 = obj4.ToString();
		string command2 = "SE_" + text3;
		_ = typeof(StageEventType);
		Enum obj5 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 1;
		string text4 = obj5.ToString();
		string description2 = text4 + " StageEvent";
		Action method2 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlayJellyfish((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command2, description2, method2);
		Enum obj6 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 2;
		string text5 = obj6.ToString();
		string command3 = "SE_" + text5;
		_ = typeof(StageEventType);
		Enum obj7 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 2;
		string text6 = obj7.ToString();
		string description3 = text6 + " StageEvent";
		Action method3 = delegate
		{
			//IL_000b: Expected O, but got I4
			PlayBatSwarm((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command3, description3, method3);
		_ = typeof(StageEventType);
		_ = -1;
		Enum obj8 = (Enum)(obj2 - 64);
		_ = 3;
		string text7 = obj8.ToString();
		string command4 = "SE_" + text7;
		_ = typeof(StageEventType);
		Enum obj9 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 3;
		string text8 = obj9.ToString();
		string description4 = text8 + " StageEvent";
		Action method4 = delegate
		{
			//IL_000b: Expected O, but got I4
			PlayGhostSwarm((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command4, description4, method4);
		Enum obj10 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 4;
		string text9 = obj10.ToString();
		string command5 = "SE_" + text9;
		_ = typeof(StageEventType);
		Enum obj11 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 4;
		string text10 = obj11.ToString();
		string description5 = text10 + " StageEvent";
		Action method5 = PlayEraseEnemies;
		DebugLogConsole.AddCommand(command5, description5, method5);
		Enum obj12 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 5;
		string text11 = obj12.ToString();
		string command6 = "SE_" + text11;
		_ = typeof(StageEventType);
		Enum obj13 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 5;
		string text12 = obj13.ToString();
		string description6 = text12 + " StageEvent";
		Action method6 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlayMedusaSwarm((float?)(object)0, 12);
		};
		DebugLogConsole.AddCommand(command6, description6, method6);
		Enum obj14 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 6;
		string text13 = obj14.ToString();
		string command7 = "SE_" + text13;
		_ = typeof(StageEventType);
		Enum obj15 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 6;
		string text14 = obj15.ToString();
		string description7 = text14 + " StageEvent";
		Action method7 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlayMedusaWall((float?)(object)0, 6);
		};
		DebugLogConsole.AddCommand(command7, description7, method7);
		Enum obj16 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 7;
		string text15 = obj16.ToString();
		string command8 = "SE_" + text15;
		_ = typeof(StageEventType);
		_ = -1;
		_ = 7;
		Enum obj17 = (Enum)(obj2 - 64);
		string text16 = obj17.ToString();
		string description8 = text16 + " StageEvent";
		Action method8 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlaySkullSwarm((float?)(object)0, 32);
		};
		DebugLogConsole.AddCommand(command8, description8, method8);
		Enum obj18 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 8;
		string text17 = obj18.ToString();
		string command9 = "SE_" + text17;
		_ = typeof(StageEventType);
		Enum obj19 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 8;
		string text18 = obj19.ToString();
		string description9 = text18 + " StageEvent";
		Action method9 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlayShadeBomb((float?)(object)0, 2);
		};
		DebugLogConsole.AddCommand(command9, description9, method9);
		Enum obj20 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 9;
		string text19 = obj20.ToString();
		string command10 = "SE_" + text19;
		_ = typeof(StageEventType);
		Enum obj21 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 9;
		string text20 = obj21.ToString();
		string description10 = text20 + " StageEvent";
		Action method10 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlayPileAssault((float?)(object)0, 50, EnemyType.PILE1, moreZ);
		};
		DebugLogConsole.AddCommand(command10, description10, method10);
		Enum obj22 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 10;
		string text21 = obj22.ToString();
		string command11 = "SE_" + text21;
		_ = typeof(StageEventType);
		Enum obj23 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 10;
		string text22 = obj23.ToString();
		string description11 = text22 + " StageEvent";
		Action method11 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlayMinoRush((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command11, description11, method11);
		Enum obj24 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 11;
		string text23 = obj24.ToString();
		string command12 = "SE_" + text23;
		_ = typeof(StageEventType);
		Enum obj25 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 11;
		string text24 = obj25.ToString();
		string description12 = text24 + " StageEvent";
		Action method12 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlayStalker((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command12, description12, method12);
		Enum obj26 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 12;
		string text25 = obj26.ToString();
		string command13 = "SE_" + text25;
		_ = typeof(StageEventType);
		Enum obj27 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 12;
		string text26 = obj27.ToString();
		string description13 = text26 + " StageEvent";
		Action method13 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlayDrowner((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command13, description13, method13);
		Enum obj28 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 51;
		string text27 = obj28.ToString();
		string command14 = "SE_" + text27;
		_ = typeof(StageEventType);
		Enum obj29 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 51;
		string text28 = obj29.ToString();
		string description14 = text28 + " StageEvent";
		Action method14 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlaySleeper((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command14, description14, method14);
		Enum obj30 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 13;
		string text29 = obj30.ToString();
		string command15 = "SE_" + text29;
		_ = typeof(StageEventType);
		Enum obj31 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 13;
		string text30 = obj31.ToString();
		string description15 = text30 + " StageEvent";
		Action method15 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlayJellySwarm((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command15, description15, method15);
		Enum obj32 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 14;
		string text31 = obj32.ToString();
		string command16 = "SE_" + text31;
		_ = typeof(StageEventType);
		Enum obj33 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 14;
		string text32 = obj33.ToString();
		string description16 = text32 + " StageEvent";
		Action method16 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlayEctoSwarm((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command16, description16, method16);
		Enum obj34 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 15;
		string text33 = obj34.ToString();
		string command17 = "SE_" + text33;
		_ = typeof(StageEventType);
		Enum obj35 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 15;
		string text34 = obj35.ToString();
		string description17 = text34 + " StageEvent";
		Action method17 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlayMedusaSwarm((float?)(object)0, 3, EnemyType.XLDRAGON1_FLAG);
		};
		DebugLogConsole.AddCommand(command17, description17, method17);
		Enum obj36 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 16;
		string text35 = obj36.ToString();
		string command18 = "SE_" + text35;
		_ = typeof(StageEventType);
		Enum obj37 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 16;
		string text36 = obj37.ToString();
		string description18 = text36 + " StageEvent";
		Action method18 = delegate
		{
			//IL_000e: Expected O, but got Ref
			//IL_0026: Expected O, but got I4
			object obj114 = default(object);
			string moreY = ((Enum)(&obj114)).ToString();
			PlayGenericSwarm((float?)(object)0, 25, moreY);
		};
		DebugLogConsole.AddCommand(command18, description18, method18);
		Enum obj38 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 17;
		string text37 = obj38.ToString();
		string command19 = "SE_" + text37;
		_ = typeof(StageEventType);
		_ = -1;
		Enum obj39 = (Enum)(obj2 - 64);
		_ = 17;
		string text38 = obj39.ToString();
		string description19 = text38 + " StageEvent";
		Action method19 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlayDragonStream((float?)(object)0, 12, EnemyType.XLDRAGON1_FLAG, moreZ);
		};
		DebugLogConsole.AddCommand(command19, description19, method19);
		Enum obj40 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 19;
		string text39 = obj40.ToString();
		string command20 = "SE_" + text39;
		_ = typeof(StageEventType);
		Enum obj41 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 19;
		string text40 = obj41.ToString();
		string description20 = text40 + " StageEvent";
		Action method20 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlaySkeleStream((float?)(object)0, 12, EnemyType.XLDRAGON3_FLAG, moreZ);
		};
		DebugLogConsole.AddCommand(command20, description20, method20);
		Enum obj42 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 18;
		string text41 = obj42.ToString();
		string command21 = "SE_" + text41;
		_ = typeof(StageEventType);
		Enum obj43 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 18;
		string text42 = obj43.ToString();
		string description21 = text42 + " StageEvent";
		Action method21 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlaySkullPilePile((float?)(object)0, 1, EnemyType.PILE4_SCALED, moreZ);
		};
		DebugLogConsole.AddCommand(command21, description21, method21);
		Enum obj44 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 20;
		string text43 = obj44.ToString();
		string command22 = "SE_" + text43;
		_ = typeof(StageEventType);
		Enum obj45 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 20;
		string text44 = obj45.ToString();
		string description22 = text44 + " StageEvent";
		Action method22 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlayPolterRoulette((float?)(object)0, 50, EnemyType.POLTER_DEST, moreZ);
		};
		DebugLogConsole.AddCommand(command22, description22, method22);
		Enum obj46 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 21;
		string text45 = obj46.ToString();
		string command23 = "SE_" + text45;
		_ = typeof(StageEventType);
		Enum obj47 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 21;
		string text46 = obj47.ToString();
		string description23 = text46 + " StageEvent";
		Action method23 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlayCircle((float?)(object)0, 100, EnemyType.POLTER, moreZ);
		};
		DebugLogConsole.AddCommand(command23, description23, method23);
		Enum obj48 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 22;
		string text47 = obj48.ToString();
		string command24 = "SE_" + text47;
		_ = typeof(StageEventType);
		Enum obj49 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 22;
		string text48 = obj49.ToString();
		string description24 = text48 + " StageEvent";
		Action method24 = delegate
		{
			//IL_0010: Expected O, but got I4
			PlayImpSwarm((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command24, description24, method24);
		Enum obj50 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 23;
		string text49 = obj50.ToString();
		string command25 = "SE_" + text49;
		_ = typeof(StageEventType);
		Enum obj51 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 23;
		string text50 = obj51.ToString();
		string description25 = text50 + " StageEvent";
		Action method25 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlaySkeletonSwarm((float?)(object)0);
		};
		DebugLogConsole.AddCommand(command25, description25, method25);
		Enum obj52 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 24;
		string text51 = obj52.ToString();
		string command26 = "SE_" + text51;
		_ = typeof(StageEventType);
		Enum obj53 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 24;
		string text52 = obj53.ToString();
		string description26 = text52 + " StageEvent";
		Action method26 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object moreY = default(object);
			ShootStars(2, moreY, 1f);
		};
		DebugLogConsole.AddCommand(command26, description26, method26);
		Enum obj54 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 52;
		string text53 = obj54.ToString();
		string command27 = "SE_" + text53;
		_ = typeof(StageEventType);
		Enum obj55 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 52;
		string text54 = obj55.ToString();
		string description27 = text54 + " StageEvent";
		Action method27 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object moreY = default(object);
			ShootStars2(2, moreY, 1f);
		};
		DebugLogConsole.AddCommand(command27, description27, method27);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 44;
		Enum obj56 = (Enum)(obj2 - 64);
		string text55 = obj56.ToString();
		string command28 = "SE_" + text55;
		_ = typeof(StageEventType);
		Enum obj57 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 44;
		string text56 = obj57.ToString();
		string description28 = text56 + " StageEvent";
		Action method28 = delegate
		{
			//IL_0015: Expected O, but got I4
			PlayVerticalSwarm((float?)(object)0, 12);
		};
		DebugLogConsole.AddCommand(command28, description28, method28);
		Enum obj58 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 45;
		string text57 = obj58.ToString();
		string command29 = "SE_" + text57;
		_ = typeof(StageEventType);
		Enum obj59 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 45;
		string text58 = obj59.ToString();
		string description29 = text58 + " StageEvent";
		Action method29 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			PlayCircle((float?)(object)0, 100, EnemyType.MS_FLOWER1, moreZ);
		};
		DebugLogConsole.AddCommand(command29, description29, method29);
		Enum obj60 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 46;
		string text59 = obj60.ToString();
		string command30 = "SE_" + text59;
		_ = typeof(StageEventType);
		Enum obj61 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 46;
		string text60 = obj61.ToString();
		string description30 = text60 + " StageEvent";
		Action method30 = delegate
		{
			//IL_0019: Expected O, but got I4
			float moreZ = default(float);
			SpawnInSteps((float?)(object)0, 24, EnemyType.EX_AXE_BAT3, moreZ);
		};
		DebugLogConsole.AddCommand(command30, description30, method30);
		Enum obj62 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 47;
		string text61 = obj62.ToString();
		string command31 = "SE_" + text61;
		_ = typeof(StageEventType);
		Enum obj63 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 47;
		string text62 = obj63.ToString();
		string description31 = text62 + " StageEvent";
		Action method31 = delegate
		{
			//IL_001e: Expected O, but got I4
			//IL_001e: Expected O, but got I4
			float moreZ = default(float);
			PlayDiamondSquare((float?)(object)0, 1, (EnemyType?)(object)1, moreZ);
		};
		DebugLogConsole.AddCommand(command31, description31, method31);
		Enum obj64 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 48;
		string text63 = obj64.ToString();
		string command32 = "SE_" + text63;
		_ = typeof(StageEventType);
		Enum obj65 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 48;
		string text64 = obj65.ToString();
		string description32 = text64 + " StageEvent";
		Action method32 = delegate
		{
			//IL_001e: Expected O, but got I4
			//IL_001e: Expected O, but got I4
			float moreZ = default(float);
			PlayDiamondRoad((float?)(object)0, 1, (EnemyType?)(object)1, moreZ);
		};
		DebugLogConsole.AddCommand(command32, description32, method32);
		Enum obj66 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 49;
		string text65 = obj66.ToString();
		string command33 = "SE_" + text65;
		_ = typeof(StageEventType);
		Enum obj67 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 49;
		string text66 = obj67.ToString();
		string description33 = text66 + " StageEvent";
		Action method33 = delegate
		{
			//IL_001e: Expected O, but got I4
			//IL_001e: Expected O, but got I4
			//IL_001e: Expected O, but got I4
			EnemyType? moreZ = default(EnemyType?);
			PlayDiamondConcrete((float?)(object)0, (float?)(object)1, (float?)(object)1, moreZ);
		};
		DebugLogConsole.AddCommand(command33, description33, method33);
		Enum obj68 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 50;
		string text67 = obj68.ToString();
		string command34 = "SE_" + text67;
		_ = typeof(StageEventType);
		Enum obj69 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 50;
		string text68 = obj69.ToString();
		string description34 = text68 + " StageEvent";
		Action method34 = delegate
		{
			//IL_001e: Expected O, but got I4
			//IL_001e: Expected O, but got I4
			float moreZ = default(float);
			PlayDiamond_RandomPattern((float?)(object)1, 0, (EnemyType?)(object)1, moreZ);
		};
		DebugLogConsole.AddCommand(command34, description34, method34);
		Enum obj70 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 53;
		string text69 = obj70.ToString();
		string command35 = "SE_" + text69;
		_ = typeof(StageEventType);
		Enum obj71 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 53;
		string text70 = obj71.ToString();
		string description35 = text70 + " StageEvent (4 seconds)";
		Action method35 = delegate
		{
			//IL_001a: Expected O, but got I4
			float moreZ = default(float);
			Sabotagion((float?)(object)1, 0, null, moreZ);
		};
		DebugLogConsole.AddCommand(command35, description35, method35);
		Enum obj72 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 53;
		string text71 = obj72.ToString();
		string command36 = "SE_" + text71 + "_FULL";
		_ = typeof(StageEventType);
		Enum obj73 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 53;
		string text72 = obj73.ToString();
		string description36 = text72 + " StageEvent";
		Action method36 = delegate
		{
			//IL_0015: Expected O, but got I4
			float moreZ = default(float);
			Sabotagion((float?)(object)0, 0, null, moreZ);
		};
		DebugLogConsole.AddCommand(command36, description36, method36);
		Enum obj74 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 54;
		string text73 = obj74.ToString();
		string command37 = "SE_" + text73;
		_ = typeof(StageEventType);
		Enum obj75 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 53;
		string text74 = obj75.ToString();
		string description37 = text74 + " StageEvent (4 seconds)";
		Action method37 = delegate
		{
			//IL_001a: Expected O, but got I4
			float moreZ = default(float);
			Sabotage_PickleRush((float?)(object)1, 0, null, moreZ);
		};
		DebugLogConsole.AddCommand(command37, description37, method37);
		Enum obj76 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 54;
		string text75 = obj76.ToString();
		string command38 = "SE_" + text75 + "_FULL";
		_ = typeof(StageEventType);
		Enum obj77 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 53;
		string text76 = obj77.ToString();
		string description38 = text76 + " StageEvent";
		Action method38 = delegate
		{
			//IL_0015: Expected O, but got I4
			float moreZ = default(float);
			Sabotage_PickleRush((float?)(object)0, 0, null, moreZ);
		};
		DebugLogConsole.AddCommand(command38, description38, method38);
		_ = typeof(StageEventType);
		Enum obj78 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 56;
		string text77 = obj78.ToString();
		string command39 = "SE_" + text77;
		object obj79 = obj2 + 48;
		_ = 56;
		object arg = (StageEventType)obj79;
		System.ParamsArray paramsArray = (System.ParamsArray)(obj2 - 64);
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
		System.ParamsArray args = (System.ParamsArray)(obj2 - 32);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ rsp-30]");
		_ = 0;
		string description39 = string.FormatHelper((IFormatProvider)null, "{0} Stage Event", args);
		Action method39 = FB_Capsule_Event;
		DebugLogConsole.AddCommand(command39, description39, method39);
		Enum obj80 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 61;
		string text78 = obj80.ToString();
		string command40 = "SE_" + text78;
		_ = typeof(StageEventType);
		Enum obj81 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 61;
		string text79 = obj81.ToString();
		string description40 = text79 + " StageEvent";
		Action method40 = delegate
		{
			//IL_0015: Expected O, but got I4
			float moreZ = default(float);
			FB_BigFuzz_Pointer((float?)(object)0, 0, null, moreZ);
		};
		DebugLogConsole.AddCommand(command40, description40, method40);
		Enum obj82 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 26;
		string text80 = obj82.ToString();
		string command41 = "SE_" + text80;
		_ = typeof(StageEventType);
		Enum obj83 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 26;
		string text81 = obj83.ToString();
		string description41 = text81 + " StageEvent";
		Action method41 = fnRosary;
		DebugLogConsole.AddCommand(command41, description41, method41);
		Enum obj84 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 27;
		string text82 = obj84.ToString();
		string command42 = "SE_" + text82;
		_ = typeof(StageEventType);
		Enum obj85 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 27;
		string text83 = obj85.ToString();
		string description42 = text83 + " StageEvent";
		Action method42 = fnPet;
		DebugLogConsole.AddCommand(command42, description42, method42);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 28;
		Enum obj86 = (Enum)(obj2 - 64);
		string text84 = obj86.ToString();
		string command43 = "SE_" + text84;
		_ = typeof(StageEventType);
		Enum obj87 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 28;
		string text85 = obj87.ToString();
		string description43 = text85 + " StageEvent";
		Action method43 = fnChicken;
		DebugLogConsole.AddCommand(command43, description43, method43);
		Enum obj88 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 29;
		string text86 = obj88.ToString();
		string command44 = "SE_" + text86;
		_ = typeof(StageEventType);
		Enum obj89 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 29;
		string text87 = obj89.ToString();
		string description44 = text87 + " StageEvent";
		Action method44 = fnGoldFever;
		DebugLogConsole.AddCommand(command44, description44, method44);
		Enum obj90 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 30;
		string text88 = obj90.ToString();
		string command45 = "SE_" + text88;
		_ = typeof(StageEventType);
		Enum obj91 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 30;
		string text89 = obj91.ToString();
		string description45 = text89 + " StageEvent";
		Action method45 = fnPassive;
		DebugLogConsole.AddCommand(command45, description45, method45);
		Enum obj92 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 31;
		string text90 = obj92.ToString();
		string command46 = "SE_" + text90;
		_ = typeof(StageEventType);
		Enum obj93 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 31;
		string text91 = obj93.ToString();
		string description46 = text91 + " StageEvent";
		Action method46 = fnLights;
		DebugLogConsole.AddCommand(command46, description46, method46);
		Enum obj94 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 32;
		string text92 = obj94.ToString();
		string command47 = "SE_" + text92;
		_ = typeof(StageEventType);
		Enum obj95 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 32;
		string text93 = obj95.ToString();
		string description47 = text93 + " StageEvent";
		Action method47 = fnNduja;
		DebugLogConsole.AddCommand(command47, description47, method47);
		Enum obj96 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 33;
		string text94 = obj96.ToString();
		string command48 = "SE_" + text94;
		_ = typeof(StageEventType);
		Enum obj97 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 33;
		string text95 = obj97.ToString();
		string description48 = text95 + " StageEvent";
		Action method48 = fnClover;
		DebugLogConsole.AddCommand(command48, description48, method48);
		Enum obj98 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 34;
		string text96 = obj98.ToString();
		string command49 = "SE_" + text96;
		_ = typeof(StageEventType);
		Enum obj99 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 34;
		string text97 = obj99.ToString();
		string description49 = text97 + " StageEvent";
		Action method49 = fnSkull;
		DebugLogConsole.AddCommand(command49, description49, method49);
		Enum obj100 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 36;
		string text98 = obj100.ToString();
		string command50 = "SE_" + text98;
		_ = typeof(StageEventType);
		Enum obj101 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 36;
		string text99 = obj101.ToString();
		string description50 = text99 + " StageEvent";
		Action method50 = fnUltraWave;
		DebugLogConsole.AddCommand(command50, description50, method50);
		Enum obj102 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 37;
		string text100 = obj102.ToString();
		string command51 = "SE_" + text100;
		_ = typeof(StageEventType);
		Enum obj103 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 37;
		string text101 = obj103.ToString();
		string description51 = text101 + " StageEvent";
		Action method51 = fnSummonMolise;
		DebugLogConsole.AddCommand(command51, description51, method51);
		Enum obj104 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 38;
		string text102 = obj104.ToString();
		string command52 = "SE_" + text102;
		_ = typeof(StageEventType);
		Enum obj105 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 38;
		string text103 = obj105.ToString();
		string description52 = text103 + " StageEvent";
		Action method52 = fnSummonNight;
		DebugLogConsole.AddCommand(command52, description52, method52);
		Enum obj106 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 39;
		string text104 = obj106.ToString();
		string command53 = "SE_" + text104;
		_ = typeof(StageEventType);
		Enum obj107 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 39;
		string text105 = obj107.ToString();
		string description53 = text105 + " StageEvent";
		Action method53 = fnMinuteOfPanic;
		DebugLogConsole.AddCommand(command53, description53, method53);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 40;
		Enum obj108 = (Enum)(obj2 - 64);
		string text106 = obj108.ToString();
		string command54 = "SE_" + text106;
		_ = typeof(StageEventType);
		Enum obj109 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 40;
		string text107 = obj109.ToString();
		string description54 = text107 + " StageEvent";
		Action method54 = fnCandybox;
		DebugLogConsole.AddCommand(command54, description54, method54);
		Enum obj110 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 42;
		string text108 = obj110.ToString();
		string command55 = "SE_" + text108;
		_ = typeof(StageEventType);
		Enum obj111 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 42;
		string text109 = obj111.ToString();
		string description55 = text109 + " StageEvent";
		Action method55 = fnCrabFest;
		DebugLogConsole.AddCommand(command55, description55, method55);
		Enum obj112 = (Enum)(obj2 - 64);
		_ = typeof(StageEventType);
		_ = -1;
		_ = 43;
		string text110 = obj112.ToString();
		string command56 = "SE_" + text110;
		_ = typeof(StageEventType);
		Enum obj113 = (Enum)(obj2 - 64);
		_ = -1;
		_ = 43;
		string text111 = obj113.ToString();
		string description56 = text111 + " StageEvent";
		Action method56 = fnRemoveWalls;
		DebugLogConsole.AddCommand(command56, description56, method56);
	}

	public StageEventManager()
	{
		List<EventTargetInstace> eventTargets = new List<EventTargetInstace>();
		_eventTargets = eventTargets;
	}

	private void _003CFB_BigFuzz_Pointer_003Eb__107_0(Vector2 v)
	{
		Stage ourStage = _ourStage;
		List<Vector2> specialLocations = ourStage._tilingTileset.GetSpecialLocations("BossSpawn");
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void _003C_FB_BigFuzz_Pointer_003Eb__108_0()
	{
		_finishedTeleportingToRemotePlayer = true;
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_0()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlayCircle((float?)(object)0, 100, EnemyType.FLOWER, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_1()
	{
		//IL_0015: Expected O, but got I4
		PlayJellyfish((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_2()
	{
		//IL_000b: Expected O, but got I4
		PlayBatSwarm((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_3()
	{
		//IL_000b: Expected O, but got I4
		PlayGhostSwarm((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_4()
	{
		//IL_0015: Expected O, but got I4
		PlayMedusaSwarm((float?)(object)0, 12);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_5()
	{
		//IL_0015: Expected O, but got I4
		PlayMedusaWall((float?)(object)0, 6);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_6()
	{
		//IL_0015: Expected O, but got I4
		PlaySkullSwarm((float?)(object)0, 32);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_7()
	{
		//IL_0015: Expected O, but got I4
		PlayShadeBomb((float?)(object)0, 2);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_8()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlayPileAssault((float?)(object)0, 50, EnemyType.PILE1, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_9()
	{
		//IL_0010: Expected O, but got I4
		PlayMinoRush((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_10()
	{
		//IL_0010: Expected O, but got I4
		PlayStalker((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_11()
	{
		//IL_0010: Expected O, but got I4
		PlayDrowner((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_12()
	{
		//IL_0010: Expected O, but got I4
		PlaySleeper((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_13()
	{
		//IL_0010: Expected O, but got I4
		PlayJellySwarm((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_14()
	{
		//IL_0010: Expected O, but got I4
		PlayEctoSwarm((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_15()
	{
		//IL_0015: Expected O, but got I4
		PlayMedusaSwarm((float?)(object)0, 3, EnemyType.XLDRAGON1_FLAG);
	}

	private unsafe void _003CDebugAddConsoleCommands_003Eb__131_16()
	{
		//IL_000e: Expected O, but got Ref
		//IL_0026: Expected O, but got I4
		object obj = default(object);
		string moreY = ((Enum)(&obj)).ToString();
		PlayGenericSwarm((float?)(object)0, 25, moreY);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_17()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlayDragonStream((float?)(object)0, 12, EnemyType.XLDRAGON1_FLAG, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_18()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlaySkeleStream((float?)(object)0, 12, EnemyType.XLDRAGON3_FLAG, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_19()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlaySkullPilePile((float?)(object)0, 1, EnemyType.PILE4_SCALED, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_20()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlayPolterRoulette((float?)(object)0, 50, EnemyType.POLTER_DEST, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_21()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlayCircle((float?)(object)0, 100, EnemyType.POLTER, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_22()
	{
		//IL_0010: Expected O, but got I4
		PlayImpSwarm((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_23()
	{
		//IL_0015: Expected O, but got I4
		PlaySkeletonSwarm((float?)(object)0);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_24()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object moreY = default(object);
		ShootStars(2, moreY, 1f);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_25()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object moreY = default(object);
		ShootStars2(2, moreY, 1f);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_26()
	{
		//IL_0015: Expected O, but got I4
		PlayVerticalSwarm((float?)(object)0, 12);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_27()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		PlayCircle((float?)(object)0, 100, EnemyType.MS_FLOWER1, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_28()
	{
		//IL_0019: Expected O, but got I4
		float moreZ = default(float);
		SpawnInSteps((float?)(object)0, 24, EnemyType.EX_AXE_BAT3, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_29()
	{
		//IL_001e: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		float moreZ = default(float);
		PlayDiamondSquare((float?)(object)0, 1, (EnemyType?)(object)1, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_30()
	{
		//IL_001e: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		float moreZ = default(float);
		PlayDiamondRoad((float?)(object)0, 1, (EnemyType?)(object)1, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_31()
	{
		//IL_001e: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		EnemyType? moreZ = default(EnemyType?);
		PlayDiamondConcrete((float?)(object)0, (float?)(object)1, (float?)(object)1, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_32()
	{
		//IL_001e: Expected O, but got I4
		//IL_001e: Expected O, but got I4
		float moreZ = default(float);
		PlayDiamond_RandomPattern((float?)(object)1, 0, (EnemyType?)(object)1, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_33()
	{
		//IL_001a: Expected O, but got I4
		float moreZ = default(float);
		Sabotagion((float?)(object)1, 0, null, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_34()
	{
		//IL_0015: Expected O, but got I4
		float moreZ = default(float);
		Sabotagion((float?)(object)0, 0, null, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_35()
	{
		//IL_001a: Expected O, but got I4
		float moreZ = default(float);
		Sabotage_PickleRush((float?)(object)1, 0, null, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_36()
	{
		//IL_0015: Expected O, but got I4
		float moreZ = default(float);
		Sabotage_PickleRush((float?)(object)0, 0, null, moreZ);
	}

	private void _003CDebugAddConsoleCommands_003Eb__131_37()
	{
		//IL_0015: Expected O, but got I4
		float moreZ = default(float);
		FB_BigFuzz_Pointer((float?)(object)0, 0, null, moreZ);
	}
}
