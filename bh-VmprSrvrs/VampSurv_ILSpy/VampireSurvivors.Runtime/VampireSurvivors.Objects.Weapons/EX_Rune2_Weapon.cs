using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EX_Rune2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__50_0;

		public static TweenCallback _003C_003E9__50_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__50_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__50_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass41_0
	{
		public EX_Rune2_Weapon _003C_003E4__this;

		public Vector3 startingPosition;

		public Vector3 startingPosition2;
	}

	private sealed class _003C_003Ec__DisplayClass41_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass41_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFire_003Eb__0()
		{
			//IL_047e: Expected O, but got I4
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected Ref, but got Unknown
			//IL_0414: Expected O, but got I4
			//IL_0210: Expected O, but got I
			//IL_0082->IL041e: Incompatible stack heights: 1 vs 0
			//IL_00ab->IL041e: Incompatible stack heights: 1 vs 0
			//IL_00da->IL041e: Incompatible stack heights: 1 vs 0
			//IL_00fc->IL041e: Incompatible stack heights: 1 vs 0
			//IL_011e->IL041e: Incompatible stack heights: 1 vs 0
			//IL_04d5->IL041e: Incompatible stack heights: 1 vs 0
			//IL_03fc->IL041e: Incompatible stack heights: 1 vs 0
			//IL_01a6->IL041e: Incompatible stack heights: 1 vs 0
			//IL_01d5->IL041e: Incompatible stack heights: 1 vs 0
			//IL_01fa->IL041e: Incompatible stack heights: 1 vs 0
			//IL_022c->IL041e: Incompatible stack heights: 1 vs 0
			//IL_0524->IL041e: Incompatible stack heights: 2 vs 0
			//IL_026a->IL041e: Incompatible stack heights: 2 vs 0
			//IL_0299->IL041e: Incompatible stack heights: 2 vs 0
			//IL_02bb->IL041e: Incompatible stack heights: 2 vs 0
			//IL_02ea->IL041e: Incompatible stack heights: 2 vs 0
			//IL_0590->IL041e: Incompatible stack heights: 3 vs 0
			//IL_0316->IL041e: Incompatible stack heights: 3 vs 0
			//IL_035f->IL041e: Incompatible stack heights: 3 vs 0
			//IL_0381->IL041e: Incompatible stack heights: 3 vs 0
			//IL_03ab->IL03ab: Incompatible stack heights: 3 vs 1
			_003C_003Ec__DisplayClass41_0 obj = CS_0024_003C_003E8__locals1;
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
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						_003C_003Ec__DisplayClass41_0 obj3 = CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							EX_Rune2_Weapon eX_Rune2_Weapon = obj3._003C_003E4__this;
							if ((object)obj3._003C_003E4__this != null && (object)((Equipment)eX_Rune2_Weapon)._003COwner_003Ek__BackingField != null && (object)core._stage != null)
							{
								ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)eX_Rune2_Weapon)._003COwner_003Ek__BackingField + 176);
								EnemyController enemyController = core._stage.PickRandomEnemyController(ref rng);
								GameObject gameObject2;
								if ((object)enemyController != null)
								{
									bool flag2 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
									gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals1;
									if (!flag2)
									{
										if (CS_0024_003C_003E8__locals1 != null)
										{
											IntPtr cachedPtr = ((UnityEngine.Object)gameObject2).m_CachedPtr;
											if (((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v32 (System.IntPtr)+178]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v32 (System.IntPtr)+178]");
													Transform transform = ((Component)0).transform;
													if ((object)transform != null)
													{
														bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
														Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
														if (CS_0024_003C_003E8__locals1 != null)
														{
															_ = 0;
															_003C_003Ec__DisplayClass41_0 obj4 = CS_0024_003C_003E8__locals1;
															if (CS_0024_003C_003E8__locals1 != null)
															{
																EX_Rune2_Weapon eX_Rune2_Weapon2 = obj4._003C_003E4__this;
																if ((object)obj4._003C_003E4__this != null && (object)eX_Rune2_Weapon2._well2 != null)
																{
																	Transform transform2 = eX_Rune2_Weapon2._well2.transform;
																	if ((object)transform2 != null)
																	{
																		bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
																		obj4.startingPosition2 = ret;
																		_ = 0;
																		_003C_003Ec__DisplayClass41_0 obj5 = CS_0024_003C_003E8__locals1;
																		if (CS_0024_003C_003E8__locals1 != null && (object)obj5._003C_003E4__this != null)
																		{
																			Vector2 startPosition = default(Vector2);
																			bool flipMyY = default(bool);
																			obj5._003C_003E4__this.FireStripAtEnemy(enemyController, localIndex, startPosition, flipMyY);
																			_003C_003Ec__DisplayClass41_0 obj6 = CS_0024_003C_003E8__locals1;
																			if (CS_0024_003C_003E8__locals1 != null && (object)obj6._003C_003E4__this != null)
																			{
																				obj6._003C_003E4__this.FireStripAtEnemy(enemyController, localIndex, startPosition, flipMyY);
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
										goto IL_041e;
									}
								}
								else
								{
									gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals1;
								}
								if ((object)gameObject2 != null)
								{
									_003C_003Ec__DisplayClass41_0 obj7 = CS_0024_003C_003E8__locals1;
									IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject2).m_CachedPtr;
									EX_Rune2_Weapon eX_Rune2_Weapon3 = obj7._003C_003E4__this;
									if ((object)obj7._003C_003E4__this != null)
									{
										object obj8 = eX_Rune2_Weapon3.AccumulatedProjectiles + 1;
										return;
									}
								}
							}
						}
					}
				}
			}
			goto IL_041e;
			IL_041e:
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass47_0
	{
		public EX_Rune2_Weapon _003C_003E4__this;

		public ParticleSystem.ShapeModule s;

		public ParticleSystem.EmissionModule e;

		public TweenCallback _003C_003E9__2;

		public TweenCallback _003C_003E9__3;

		public Action _003C_003E9__7;

		internal void _003CDoSingularity_003Eb__0()
		{
			//IL_007f: Expected O, but got I
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			Circle circleEmitCircle = eX_Rune2_Weapon._circleEmitCircle;
			float num = (circleEmitCircle._radius = eX_Rune2_Weapon.radius * 100f);
			float diameter = num + num;
			circleEmitCircle._diameter = diameter;
			EX_Rune2_Weapon eX_Rune2_Weapon2 = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v252 @ rax_v12 (should have been resolved before IL gen)");
		}

		internal unsafe void _003CDoSingularity_003Eb__1()
		{
			//IL_002c: Expected I, but got O
			//IL_022a: Expected O, but got I4
			//IL_026b: Expected O, but got I4
			//IL_02c3: Expected O, but got I4
			//IL_031b: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_003C_003E4__this != null)
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
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"radius", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			TweenCallback onUpdate = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				onUpdate = (_003C_003E9__2 = delegate
				{
					//IL_0021: Expected O, but got I
					EX_Rune2_Weapon eX_Rune2_Weapon3 = _003C_003E4__this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj2 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v199 @ rax_v11 (should have been resolved before IL gen)");
				});
			}
			tweenConfig.onUpdate = onUpdate;
			tweenConfig.duration = 1000f;
			tweenConfig.delay = 3000f;
			TweenCallback onStart = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				onStart = (_003C_003E9__3 = delegate
				{
					//IL_0008: Expected O, but got Ref
					//IL_0024: Expected O, but got I
					//IL_0186: Unknown result type (might be due to invalid IL or missing references)
					//IL_018b: Expected O, but got Unknown
					//IL_01a5: Expected O, but got I
					//IL_021a: Unknown result type (might be due to invalid IL or missing references)
					//IL_021f: Expected O, but got Unknown
					//IL_0237: Expected O, but got Ref
					//IL_024c: Expected native int or pointer, but got O
					//IL_0257: Unknown result type (might be due to invalid IL or missing references)
					//IL_025c: Expected O, but got Unknown
					//IL_026a: Expected O, but got Ref
					//IL_029f: Expected O, but got Ref
					//IL_02ad: Expected native int or pointer, but got O
					//IL_00d0: Expected O, but got I
					//IL_01ef: Expected O, but got Ref
					//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
					//IL_01fa: Expected O, but got Unknown
					object obj3 = default(object);
					object obj2 = (object)(&obj3);
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
					object obj4 = 0;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj4 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
					}
					object obj5 = this + 24;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53 @ rax_v9 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj6 == null)
						{
							MissingMethodException ex3 = new MissingMethodException();
							throw ex3;
						}
					}
					object obj7 = this + 24;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v92 @ rax_v12 (should have been resolved before IL gen)");
					ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 9));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(-1f));
					ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)(this + 24);
					ParticleSystem.MinMaxCurve arcSpeed = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 55));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
					_ = 0;
					((ParticleSystem.ShapeModule*)shapeModule)->arcSpeed = arcSpeed;
					ParticleSystem.Burst burst = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 73));
					*(ParticleSystem.Burst*)(nint)burst = new ParticleSystem.Burst(0f, 1);
					_ = 1008981770;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
					object obj8 = 0;
					_ = 4294967295L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj8 == null)
						{
							MissingMethodException ex4 = new MissingMethodException();
							throw ex4;
						}
					}
					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj3, 9));
					object obj10 = this + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v172 @ rax_v18 (should have been resolved before IL gen)");
				});
			}
			tweenConfig.onStart = onStart;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			eX_Rune2_Weapon._playerControlled = true;
			_003C_003E4__this.ExplodeSingularity();
			_003C_003E4__this.ScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_exp45, soundConfig, 200f, 4, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			soundConfig2.Detune = -400f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Carrello, soundConfig2, 200f, 4, time);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			soundConfig3.Detune = -600f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Carrello, soundConfig3, 200f, 4, time);
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Volume = (float?)(object)1;
			soundConfig4.Rate = 1f;
			soundConfig4.Detune = -2000f;
			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Carrello, soundConfig4, 200f, 4, time);
			EX_Rune2_Weapon eX_Rune2_Weapon2 = _003C_003E4__this;
			float singularityTimes = eX_Rune2_Weapon2._singularityTimes + 1f;
			eX_Rune2_Weapon2._singularityTimes = singularityTimes;
		}

		internal void _003CDoSingularity_003Eb__2()
		{
			//IL_0021: Expected O, but got I
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v199 @ rax_v11 (should have been resolved before IL gen)");
		}

		internal unsafe void _003CDoSingularity_003Eb__3()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0024: Expected O, but got I
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Expected O, but got Unknown
			//IL_01a5: Expected O, but got I
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Expected O, but got Unknown
			//IL_0237: Expected O, but got Ref
			//IL_024c: Expected native int or pointer, but got O
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_026a: Expected O, but got Ref
			//IL_029f: Expected O, but got Ref
			//IL_02ad: Expected native int or pointer, but got O
			//IL_00d0: Expected O, but got I
			//IL_01ef: Expected O, but got Ref
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Expected O, but got Unknown
			object obj2 = default(object);
			object obj = (object)(&obj2);
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
			object obj3 = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			object obj4 = this + 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53 @ rax_v9 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj5 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj6 = this + 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v92 @ rax_v12 (should have been resolved before IL gen)");
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(-1f));
			ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)(this + 24);
			ParticleSystem.MinMaxCurve arcSpeed = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 55));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			_ = 0;
			((ParticleSystem.ShapeModule*)shapeModule)->arcSpeed = arcSpeed;
			ParticleSystem.Burst burst = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			*(ParticleSystem.Burst*)(nint)burst = new ParticleSystem.Burst(0f, 1);
			_ = 1008981770;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
			object obj7 = 0;
			_ = 4294967295L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj7 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
			}
			object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			object obj9 = this + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v172 @ rax_v18 (should have been resolved before IL gen)");
		}

		internal void _003CDoSingularity_003Eb__4()
		{
			//IL_003a: Expected O, but got I4
			//IL_007b: Expected O, but got I4
			//IL_00d3: Expected O, but got I4
			//IL_012b: Expected O, but got I4
			_003C_003E4__this.ScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_exp5, soundConfig, 200f, 4, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			soundConfig2.Detune = -600f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Carrello, soundConfig2, 200f, 4, time);
			SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
			soundConfig3.Volume = (float?)(object)1;
			soundConfig3.Rate = 1f;
			soundConfig3.Detune = -800f;
			PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Carrello, soundConfig3, 200f, 4, time);
			SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
			soundConfig4.Volume = (float?)(object)1;
			soundConfig4.Rate = 1f;
			soundConfig4.Detune = -2000f;
			PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Carrello, soundConfig4, 200f, 4, time);
		}

		internal void _003CDoSingularity_003Eb__5()
		{
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			eX_Rune2_Weapon._doingSingularity = false;
			Action onComplete = _003C_003E9__7;
			if (_003C_003E9__7 == null)
			{
				onComplete = (_003C_003E9__7 = delegate
				{
					//IL_0065: Expected F4, but got I
					EX_Rune2_Weapon eX_Rune2_Weapon2 = _003C_003E4__this;
					eX_Rune2_Weapon2._playerControlled = false;
					EX_Rune2_Weapon eX_Rune2_Weapon3 = _003C_003E4__this;
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)eX_Rune2_Weapon3)._003COwner_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rdx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					float angleValue = num ^ 0;
					eX_Rune2_Weapon3._angleValue = angleValue;
				});
			}
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}

		internal void _003CDoSingularity_003Eb__7()
		{
			//IL_0065: Expected F4, but got I
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			eX_Rune2_Weapon._playerControlled = false;
			EX_Rune2_Weapon eX_Rune2_Weapon2 = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)eX_Rune2_Weapon2)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rdx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float angleValue = num ^ 0;
			eX_Rune2_Weapon2._angleValue = angleValue;
		}

		internal void _003CDoSingularity_003Eb__6()
		{
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			ParticleEmitterManager particleEmitterManager = eX_Rune2_Weapon._pfxManager.SetDepth(renderer.pixelHeight);
			EX_Rune2_Weapon eX_Rune2_Weapon2 = _003C_003E4__this;
			float2 position = ((Equipment)eX_Rune2_Weapon2)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon2._emitter1, pos, 80);
			EX_Rune2_Weapon eX_Rune2_Weapon3 = _003C_003E4__this;
			float2 position2 = ((Equipment)eX_Rune2_Weapon3)._003COwner_003Ek__BackingField.position;
			RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon3._emitter2, pos, 80);
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public Rectangle rect;

		public float halfWidth;

		public EX_Rune2_Weapon _003C_003E4__this;

		internal void _003CExplodeSingularity_003Eb__0()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			Rectangle rectangle = rect;
			float num = halfWidth;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			float x = (float)obj * eX_Rune2_Weapon.SingularityExplosionValue;
			rectangle._x = x;
			Rectangle rectangle2 = rect;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			EX_Rune2_Weapon eX_Rune2_Weapon2 = _003C_003E4__this;
			float width = (float)renderer.pixelWidth * eX_Rune2_Weapon2.SingularityExplosionValue;
			rectangle2._width = width;
			EX_Rune2_Weapon eX_Rune2_Weapon3 = _003C_003E4__this;
			float2 position = ((Equipment)eX_Rune2_Weapon3)._003COwner_003Ek__BackingField.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon3._emitter1, pos, 160);
			EX_Rune2_Weapon eX_Rune2_Weapon4 = _003C_003E4__this;
			float2 position2 = ((Equipment)eX_Rune2_Weapon4)._003COwner_003Ek__BackingField.position;
			RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon4._emitter2, pos, 160);
		}

		internal void _003CExplodeSingularity_003Eb__1()
		{
			EX_Rune2_Weapon eX_Rune2_Weapon = _003C_003E4__this;
			eX_Rune2_Weapon._skipEmitUpdate = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass53_0
	{
		public EX_Rune2_Weapon _003C_003E4__this;

		public Vector2 startPosition;

		public EnemyController enemy;

		public bool flipMyY;
	}

	private sealed class _003C_003Ec__DisplayClass53_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass53_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireStripAtEnemy_003Eb__0()
		{
			//IL_0248: Expected O, but got I4
			//IL_00f4: Expected I, but got O
			//IL_00fc: Expected I, but got O
			//IL_010c: Expected O, but got I
			//IL_018c: Expected O, but got I4
			//IL_0148: Expected O, but got I
			//IL_017e: Expected O, but got I4
			//IL_0084->IL01e8: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL01e8: Incompatible stack heights: 1 vs 0
			//IL_01c2->IL01e8: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass53_0 obj = CS_0024_003C_003E8__locals1;
			Projectile projectile;
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
					_003C_003Ec__DisplayClass53_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex);
						if ((object)projectile == null)
						{
							return;
						}
						nint num = (nint)typeof(EX_Rune1_Projectile);
						nint num2 = (nint)projectile;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v18+FFFFFFF8+v392 @ rcx_v14*8]");
							if (0 == (nint)typeof(EX_Rune1_Projectile))
							{
								obj6 = 1;
								goto IL_0265;
							}
						}
						obj6 = 0;
						goto IL_0265;
					}
				}
			}
			goto IL_01e8;
			IL_01e8:
			throw new NullReferenceException();
			IL_0265:
			bool flag2 = obj6 == null;
			EX_Rune1_Projectile eX_Rune1_Projectile = null;
			if (!flag2)
			{
				eX_Rune1_Projectile = (EX_Rune1_Projectile)projectile;
			}
			if ((object)eX_Rune1_Projectile != null)
			{
				_003C_003Ec__DisplayClass53_0 obj7 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					eX_Rune1_Projectile.SetEnemyTarget(obj7.enemy, obj7.flipMyY);
					return;
				}
				goto IL_01e8;
			}
		}
	}

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _emitter1;

	private ParticleSystem _emitter2;

	private Circle _emitZone;

	private GravityWell _well1;

	private GravityWell _well2;

	private ParticleSystem.MainModule _mainModule1;

	private ParticleSystem.MainModule _mainModule2;

	private float _angleValue;

	private ParticleEmitterManager _fixedCircleManager;

	private ParticleSystem _fixedCircleEmitter;

	private Circle _circleEmitCircle;

	private EmitZone _circleEmitZone;

	private MultiTargetTween _singularityTween;

	private float _singularityTime;

	private bool _doingSingularity;

	private MultiTargetTween _restoreTween;

	private float _singularityTimes;

	private bool _skipEmitUpdate;

	private bool _hasBullets;

	private MultiTargetTween _singularityExplosionTween;

	private MultiTargetTween _screenShakeTween;

	private EX_Rune2_SpinningProjectile _bulletA;

	private EX_Rune2_SpinningProjectile _bulletB;

	[NonSerialized]
	public float radius;

	[NonSerialized]
	public float SingularityExplosionValue;

	public int AccumulatedProjectiles;

	private int activations;

	private ParticleSystem.Particle[] _activeParticles1;

	private ParticleSystem.Particle[] _activeParticles2;

	private float Lifetime1_Min = 1800f;

	private float Lifetime1_Max = 4000f;

	private float Lifetime2_Min = 600f;

	private float Lifetime2_Max = 1200f;

	private Projectile _SpinningPrefab;

	private BulletPool _spinningPool;

	private Projectile InvisProjectilePrefab;

	private BulletPool InvisProjectilesPool;

	private bool _playerControlled;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0079: Expected O, but got I
		//IL_0257: Expected O, but got I
		//IL_00a7: Expected I, but got O
		//IL_0475: Expected O, but got I
		//IL_0285: Expected I, but got O
		//IL_00d9: Expected O, but got I
		//IL_00eb: Expected I, but got O
		//IL_02b7: Expected O, but got I
		//IL_02c9: Expected I, but got O
		//IL_0138: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_0178: Expected I, but got O
		//IL_0356: Expected I, but got O
		//IL_01aa: Expected O, but got I
		//IL_0388: Expected O, but got I
		//IL_116e: Expected O, but got I4
		//IL_0811: Expected O, but got Ref
		//IL_0832: Expected O, but got I
		//IL_084e: Expected native int or pointer, but got O
		//IL_0868: Expected O, but got I
		//IL_0888: Expected O, but got Ref
		//IL_08a2: Expected native int or pointer, but got O
		//IL_11a0: Expected O, but got I
		//IL_08da: Expected O, but got Ref
		//IL_08f4: Expected native int or pointer, but got O
		//IL_0939: Expected O, but got I
		//IL_0988: Expected O, but got I
		//IL_11da: Expected O, but got I
		//IL_0d4e: Expected O, but got Ref
		//IL_0d6f: Expected O, but got I
		//IL_0d8b: Expected native int or pointer, but got O
		//IL_0da5: Expected O, but got I
		//IL_0dc5: Expected O, but got Ref
		//IL_0ddf: Expected native int or pointer, but got O
		//IL_0ded: Expected O, but got I4
		//IL_1202: Expected O, but got I4
		//IL_0e1a: Expected O, but got Ref
		//IL_0e34: Expected native int or pointer, but got O
		//IL_1249: Expected O, but got I
		//IL_1291: Expected O, but got I
		//IL_1350: Expected O, but got Ref
		//IL_12e4: Expected O, but got I
		//IL_1384: Expected O, but got Ref
		//IL_0fac: Expected O, but got I
		//IL_0fc1: Expected O, but got I
		//IL_1061: Expected O, but got I
		//IL_1076: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		_hasBullets = false;
		if (_spinningPool != null)
		{
			goto IL_01bb;
		}
		BulletPool spinningPool = new BulletPool(_SpinningPrefab);
		object obj3 = this + 568;
		_spinningPool = spinningPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v325+18]");
			object obj4 = 0;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ r8_v226 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rcx_v243+30]");
			Collider collider = ((Factory)0).overlap(_spinningPool, core.Enemies, collideCallback, processCallback, callbackContext);
			nint num2 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v331 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num3 = 0;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v332+18]");
				object obj5 = 0;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1409 @ r8_v229 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune2_Weapon>)+3A0]");
				ArcadePhysicsCallback arcadePhysicsCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num4 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v343 @ rcx_v249+30]");
				Collider collider2 = ((Factory)0).overlap(_spinningPool, physicsManager._destructiblesGroup, arcadePhysicsCallback, processCallback, callbackContext);
				ArcadePhysicsCallback arcadePhysicsCallback2 = arcadePhysicsCallback;
				goto IL_01bb;
			}
		}
		goto IL_1148;
		IL_01bb:
		if (InvisProjectilesPool != null)
		{
			goto IL_0399;
		}
		BulletPool bulletPool = new BulletPool(InvisProjectilePrefab);
		bulletPool.UpperLimit = 100;
		object obj6 = this + 584;
		InvisProjectilesPool = bulletPool;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rax_v308+18]");
			object obj7 = 0;
			GameManager core3 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ r8_v219 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune2_Weapon>)+5E0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num5 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rcx_v228+30]");
			Collider collider3 = ((Factory)0).overlap(InvisProjectilesPool, core3.Enemies, collideCallback2, processCallback, callbackContext);
			nint num6 = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v314 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num7 = 0;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rax_v315+18]");
				object obj8 = 0;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1420 @ r8_v222 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune2_Weapon>)+3A0]");
				ArcadePhysicsCallback arcadePhysicsCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num8 = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v234+30]");
				Collider collider4 = ((Factory)0).overlap(InvisProjectilesPool, physicsManager2._destructiblesGroup, arcadePhysicsCallback3, processCallback, callbackContext);
				ArcadePhysicsCallback arcadePhysicsCallback2 = arcadePhysicsCallback3;
				goto IL_0399;
			}
		}
		goto IL_1148;
		IL_1148:
		throw new NullReferenceException();
		IL_0399:
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		_emitZone = circle;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rbx_v7 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager pfxManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 336))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
			pfxManager = (ParticleEmitterManager)0;
		}
		else
		{
			pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxManager = pfxManager;
		GameObject gameObject2 = _pfxManager.gameObject;
		((UnityEngine.Object)gameObject2).SetName("PfxManager (Rune2)");
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_02");
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
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_03");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_04");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_05");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_06");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(Lifetime1_Min, Lifetime1_Max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.5f, 0.8f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
		_ = 0;
		_ = 0;
		particleSystemConfig._on = false;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _emitZone;
		particleSystemConfig._emitZone = emitZone;
		ParticleSystem emitter = _pfxManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter1");
		_emitter1 = emitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version6 = list2._version + 1;
		list2._version = version6;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"_runes_02");
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
			((List<object>)(object)list2).AddWithResize((object)"_runes_03");
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
			((List<object>)(object)list2).AddWithResize((object)"_runes_04");
		}
		else
		{
			int size8 = list2._size + 1;
			list2._size = size8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list2._version + 1;
		list2._version = version9;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"_runes_05");
		}
		else
		{
			int size9 = list2._size + 1;
			list2._size = size9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list2._version + 1;
		list2._version = version10;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"_runes_06");
		}
		else
		{
			int size10 = list2._size + 1;
			list2._size = size10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 176));
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(Lifetime2_Min, Lifetime2_Max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
		_ = 0;
		obj = 1;
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 240));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 0.65f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
		_ = 0;
		particleSystemConfig2._scaleEase = Easing.OutQuint;
		particleSystemConfig2._on = false;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _emitZone;
		particleSystemConfig2._emitZone = emitZone2;
		ParticleSystem emitter2 = _pfxManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
		_emitter2 = emitter2;
		_ = _emitter1;
		_ = _emitter1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj9 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2991 @ rax_v95 (should have been resolved before IL gen)");
		object obj11 = default(object);
		ParticleSystem.Particle[] activeParticles = new ParticleSystem.Particle[obj11];
		_activeParticles1 = activeParticles;
		_ = _emitter2;
		_ = _emitter2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj12 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3144 @ rax_v102 (should have been resolved before IL gen)");
		object obj14 = default(object);
		ParticleSystem.Particle[] activeParticles2 = new ParticleSystem.Particle[obj14];
		_activeParticles2 = activeParticles2;
		_ = _emitter1;
		_mainModule1 = (ParticleSystem.MainModule)_emitter1;
		_ = _emitter2;
		_mainModule2 = (ParticleSystem.MainModule)_emitter2;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		gravityWellConfig._y = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		gravityWellConfig._x = (float?)(object)0;
		gravityWellConfig._power = 1f;
		gravityWellConfig._epsilon = 200f;
		gravityWellConfig._gravity = 400f;
		GravityWell well = _pfxManager.CreateGravityWell(gravityWellConfig);
		_well1 = well;
		GravityWellConfig gravityWellConfig2 = new GravityWellConfig();
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		gravityWellConfig2._y = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		gravityWellConfig2._x = (float?)(object)0;
		gravityWellConfig2._power = 1f;
		gravityWellConfig2._epsilon = 200f;
		gravityWellConfig2._gravity = 400f;
		GravityWell well2 = _pfxManager.CreateGravityWell(gravityWellConfig2);
		_well2 = well2;
		RenderingExtensions.SetMaxParticles(_emitter1, 5000);
		RenderingExtensions.SetMaxParticles(_emitter2, 5000);
		_singularityTime = 0f;
		_doingSingularity = false;
		_skipEmitUpdate = false;
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0734: Expected O, but got I
		//IL_00d2: Expected O, but got I
		//IL_0451: Expected F4, but got I
		//IL_0464: Expected O, but got I4
		//IL_04a5: Expected F4, but got I
		//IL_04b8: Expected O, but got I4
		//IL_04d8: Expected O, but got Ref
		//IL_04f2: Expected native int or pointer, but got O
		//IL_076c: Expected O, but got I
		//IL_052a: Expected O, but got Ref
		//IL_0544: Expected native int or pointer, but got O
		//IL_07a6: Expected O, but got I
		//IL_0590: Expected O, but got I4
		//IL_07ec: Expected O, but got I
		//IL_0817: Expected O, but got I
		//IL_08f5: Expected O, but got Ref
		//IL_090f: Expected O, but got I
		//IL_0861: Expected O, but got Ref
		//IL_088d: Expected I, but got O
		//IL_08d1: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 220f;
		_circleEmitCircle = circle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Edge;
		emitZone._source = _circleEmitCircle;
		_ = 0;
		_ = 120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		emitZone._quantity = (int?)(object)0;
		emitZone._yoyo = false;
		_circleEmitZone = emitZone;
		GameObject gameObject = base.gameObject;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rbx_v2 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager fixedCircleManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			fixedCircleManager = (ParticleEmitterManager)0;
		}
		else
		{
			fixedCircleManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_fixedCircleManager = fixedCircleManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_02");
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
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_03");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_04");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_05");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_runes_06");
		}
		else
		{
			int size5 = list._size + 1;
			list._size = size5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-79]");
		_ = 0;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6B]");
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-79]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+7]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.5f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+17]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+27]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
		_ = 0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(1500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-79]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._emitZone = _circleEmitZone;
		particleSystemConfig._on = true;
		ParticleSystem fixedCircleEmitter = _fixedCircleManager.CreateEmitter(particleSystemConfig, null, "FixedCircleEmitter");
		_fixedCircleEmitter = fixedCircleEmitter;
		_ = _fixedCircleEmitter;
		_ = _fixedCircleEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1831 @ rax_v65 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B8B8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1857 @ rax_v68 (should have been resolved before IL gen)");
		RenderingExtensions.Start(_fixedCircleEmitter);
		Transform transform = _well2.transform;
		Transform parent = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Transform transform2 = _well2.transform;
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v989 @ rcx_v74 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		_ = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ rax_v77 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1886 @ rax_v75 (UnityEngine.Transform)+10]");
		bool flag = (nint)0 == 0;
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1886 @ rax_v75 (UnityEngine.Transform)+10]");
		Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj7);
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0125: Expected O, but got Ref
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected I4, but got Unknown
		//IL_01ca: Expected I4, but got F4
		//IL_0780: Expected O, but got I4
		//IL_02fd: Invalid comparison between I4 and F4
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_05c7: Invalid comparison between O and F4
		//IL_05f2: Expected F4, but got O
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_07bb: Expected O, but got I4
		//IL_0580: Expected O, but got I4
		//IL_0293: Expected O, but got I4
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected Ref, but got Unknown
		//IL_0734->IL0662: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL0662: Incompatible stack heights: 1 vs 0
		//IL_0104->IL0662: Incompatible stack heights: 1 vs 0
		//IL_014b->IL0662: Incompatible stack heights: 1 vs 0
		//IL_0227->IL0662: Incompatible stack heights: 2 vs 0
		//IL_080f->IL0662: Incompatible stack heights: 1 vs 0
		//IL_0617->IL0662: Incompatible stack heights: 1 vs 0
		//IL_048f->IL0662: Incompatible stack heights: 1 vs 0
		//IL_0373->IL0662: Incompatible stack heights: 1 vs 0
		//IL_04d2->IL0662: Incompatible stack heights: 1 vs 0
		//IL_0392->IL0662: Incompatible stack heights: 1 vs 0
		//IL_07c4->IL02f4: Incompatible stack heights: 3 vs 1
		//IL_03b4->IL0662: Incompatible stack heights: 1 vs 0
		//IL_029c->IL02f4: Incompatible stack heights: 3 vs 1
		//IL_02f4->IL02f4: Incompatible stack heights: 3 vs 1
		_003C_003Ec__DisplayClass41_0 obj = new _003C_003Ec__DisplayClass41_0();
		Vector2 vector2;
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			int num = activations + 1;
			activations = num;
			if ((object)_well1 != null)
			{
				Transform transform = _well1.transform;
				if ((object)transform != null)
				{
					if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
					}
					else
					{
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						obj.startingPosition = ret;
						_ = 0;
						if ((object)_well2 != null)
						{
							Transform transform2 = _well2.transform;
							if ((object)transform2 != null)
							{
								bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								obj.startingPosition2 = ret;
								_ = 0;
								GameManager core = GM.Core;
								if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
									if ((object)core._stage != null)
									{
										List<EnemyController> closestEnemiesSorted = core._stage.GetClosestEnemiesSorted((Vector3)(&ret), excludeDead: true);
										float num2 = base.PAmount();
										if (closestEnemiesSorted != null)
										{
											Vector2 vector = default(Vector2);
											int num3 = (int)(AccumulatedProjectiles + vector);
											if (closestEnemiesSorted._size <= num3)
											{
												num3 = closestEnemiesSorted._size;
											}
											if (num3 <= closestEnemiesSorted._size)
											{
												AccumulatedProjectiles = 0;
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm7\"");
												float num4 = num2 - (float)closestEnemiesSorted._size;
												AccumulatedProjectiles = (int)num4;
												num3 = closestEnemiesSorted._size;
											}
											bool flag2 = closestEnemiesSorted._size <= 0;
											vector2 = (Vector2)closestEnemiesSorted._size;
											bool flag7 = default(bool);
											if (!flag2)
											{
												bool flag3 = closestEnemiesSorted._size <= 0;
												EnemyController[] items = closestEnemiesSorted._items;
												if (closestEnemiesSorted._items == null)
												{
													goto IL_0662;
												}
												bool flag4 = items.Length <= 0;
												List<EnemyController> list = (List<EnemyController>)(object)items[0];
												bool flag5 = (object)items[0] == null;
												vector2 = (Vector2)closestEnemiesSorted._size;
												if (!flag5)
												{
													bool flag6 = list._items == null;
													vector2 = (Vector2)closestEnemiesSorted._size;
													if (!flag6)
													{
														FireStripAtEnemy(items[0], 0, vector, flag7);
														FireStripAtEnemy(items[0], 0, vector, flag7);
														vector2 = vector;
													}
												}
											}
											if (!((float)num3 > 1f))
											{
												goto IL_058e;
											}
											int num5 = 1;
											MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
											int repeat = default(int);
											TimerType type = default(TimerType);
											while (true)
											{
												WeaponData currentWeaponData = _currentWeaponData;
												if (_currentWeaponData == null)
												{
													break;
												}
												object obj2 = num5 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
												if ((nint)obj2 <= 0)
												{
													GameManager core2 = GM.Core;
													if ((object)GM.Core == null || (object)((Equipment)this)._003COwner_003Ek__BackingField == null || (object)core2._stage == null)
													{
														break;
													}
													ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
													EnemyController enemyController = core2._stage.PickRandomEnemyController(ref rng);
													if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
													{
														FireStripAtEnemy(enemyController, num5, vector, flag7);
														FireStripAtEnemy(enemyController, num5, vector, flag7);
													}
													else
													{
														int accumulatedProjectiles = AccumulatedProjectiles + 1;
														AccumulatedProjectiles = accumulatedProjectiles;
													}
												}
												else
												{
													_003C_003Ec__DisplayClass41_1 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass41_1();
													if (CS_0024_003C_003E8__locals20 == null)
													{
														break;
													}
													CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 = obj;
													CS_0024_003C_003E8__locals20.localIndex = num5;
													WeaponData currentWeaponData2 = _currentWeaponData;
													if (_currentWeaponData == null)
													{
														break;
													}
													Action onComplete = delegate
													{
														//IL_047e: Expected O, but got I4
														//IL_0131: Unknown result type (might be due to invalid IL or missing references)
														//IL_0136: Expected Ref, but got Unknown
														//IL_0414: Expected O, but got I4
														//IL_0210: Expected O, but got I
														//IL_0082->IL041e: Incompatible stack heights: 1 vs 0
														//IL_00ab->IL041e: Incompatible stack heights: 1 vs 0
														//IL_00da->IL041e: Incompatible stack heights: 1 vs 0
														//IL_00fc->IL041e: Incompatible stack heights: 1 vs 0
														//IL_011e->IL041e: Incompatible stack heights: 1 vs 0
														//IL_04d5->IL041e: Incompatible stack heights: 1 vs 0
														//IL_03fc->IL041e: Incompatible stack heights: 1 vs 0
														//IL_01a6->IL041e: Incompatible stack heights: 1 vs 0
														//IL_01d5->IL041e: Incompatible stack heights: 1 vs 0
														//IL_01fa->IL041e: Incompatible stack heights: 1 vs 0
														//IL_022c->IL041e: Incompatible stack heights: 1 vs 0
														//IL_0524->IL041e: Incompatible stack heights: 2 vs 0
														//IL_026a->IL041e: Incompatible stack heights: 2 vs 0
														//IL_0299->IL041e: Incompatible stack heights: 2 vs 0
														//IL_02bb->IL041e: Incompatible stack heights: 2 vs 0
														//IL_02ea->IL041e: Incompatible stack heights: 2 vs 0
														//IL_0590->IL041e: Incompatible stack heights: 3 vs 0
														//IL_0316->IL041e: Incompatible stack heights: 3 vs 0
														//IL_035f->IL041e: Incompatible stack heights: 3 vs 0
														//IL_0381->IL041e: Incompatible stack heights: 3 vs 0
														//IL_03ab->IL03ab: Incompatible stack heights: 3 vs 1
														_003C_003Ec__DisplayClass41_0 obj4 = CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
														if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
														{
															GameObject gameObject = obj4._003C_003E4__this.gameObject;
															if ((object)gameObject != null)
															{
																bool flag9 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
																object obj5 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
																if (obj5 == null)
																{
																	return;
																}
																GameManager core3 = GM.Core;
																if ((object)GM.Core != null)
																{
																	_003C_003Ec__DisplayClass41_0 obj6 = CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																	if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null)
																	{
																		EX_Rune2_Weapon eX_Rune2_Weapon = obj6._003C_003E4__this;
																		if ((object)obj6._003C_003E4__this != null && (object)((Equipment)eX_Rune2_Weapon)._003COwner_003Ek__BackingField != null && (object)core3._stage != null)
																		{
																			ref Unity.Mathematics.Random rng2 = ref *(Unity.Mathematics.Random*)(((Equipment)eX_Rune2_Weapon)._003COwner_003Ek__BackingField + 176);
																			EnemyController enemyController2 = core3._stage.PickRandomEnemyController(ref rng2);
																			GameObject gameObject2;
																			if ((object)enemyController2 != null)
																			{
																				bool flag10 = ((UnityEngine.Object)enemyController2).m_CachedPtr == (IntPtr)0;
																				gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																				if (!flag10)
																				{
																					if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null)
																					{
																						IntPtr cachedPtr = ((UnityEngine.Object)gameObject2).m_CachedPtr;
																						if (((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v32 (System.IntPtr)+178]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v32 (System.IntPtr)+178]");
																								Transform transform3 = ((Component)0).transform;
																								if ((object)transform3 != null)
																								{
																									bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																									Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 ret2);
																									if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null)
																									{
																										_ = 0;
																										_003C_003Ec__DisplayClass41_0 obj7 = CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																										if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null)
																										{
																											EX_Rune2_Weapon eX_Rune2_Weapon2 = obj7._003C_003E4__this;
																											if ((object)obj7._003C_003E4__this != null && (object)eX_Rune2_Weapon2._well2 != null)
																											{
																												Transform transform4 = eX_Rune2_Weapon2._well2.transform;
																												if ((object)transform4 != null)
																												{
																													bool flag12 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																													Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret2);
																													obj7.startingPosition2 = ret2;
																													_ = 0;
																													_003C_003Ec__DisplayClass41_0 obj8 = CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																													if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null && (object)obj8._003C_003E4__this != null)
																													{
																														Vector2 startPosition = default(Vector2);
																														bool flipMyY = default(bool);
																														obj8._003C_003E4__this.FireStripAtEnemy(enemyController2, CS_0024_003C_003E8__locals20.localIndex, startPosition, flipMyY);
																														_003C_003Ec__DisplayClass41_0 obj9 = CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																														if (CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1 != null && (object)obj9._003C_003E4__this != null)
																														{
																															obj9._003C_003E4__this.FireStripAtEnemy(enemyController2, CS_0024_003C_003E8__locals20.localIndex, startPosition, flipMyY);
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
																					goto IL_041e;
																				}
																			}
																			else
																			{
																				gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																			}
																			if ((object)gameObject2 != null)
																			{
																				_003C_003Ec__DisplayClass41_0 obj10 = CS_0024_003C_003E8__locals20.CS_0024_003C_003E8__locals1;
																				IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject2).m_CachedPtr;
																				EX_Rune2_Weapon eX_Rune2_Weapon3 = obj10._003C_003E4__this;
																				if ((object)obj10._003C_003E4__this != null)
																				{
																					object obj11 = eX_Rune2_Weapon3.AccumulatedProjectiles + 1;
																					return;
																				}
																			}
																		}
																	}
																}
															}
														}
														goto IL_041e;
														IL_041e:
														throw new NullReferenceException();
													};
													float num6 = (float)num5 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
													float duration = num6 * 0.001f;
													Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
													_lastShotTimer = lastShotTimer;
												}
												num5++;
												bool flag8 = num3 > num5;
												vector2 = (Vector2)num5;
												if (flag8)
												{
													continue;
												}
												goto IL_058e;
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
		goto IL_0662;
		IL_058e:
		float num7 = base.PInterval();
		float num8 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num9 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
				return;
			}
			goto IL_0662;
		}
		return;
		IL_0662:
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0b94: Expected O, but got F4
		//IL_0b99: Expected I, but got O
		//IL_0986: Expected O, but got F4
		//IL_04cb: Expected O, but got I
		//IL_04e8: Expected O, but got I
		//IL_04f1: Expected F4, but got I4
		//IL_0c06: Expected O, but got F4
		//IL_0a0c: Expected F4, but got O
		//IL_0a37: Expected O, but got I
		//IL_03c1: Expected O, but got I
		//IL_03c9: Expected O, but got Ref
		//IL_06d8: Expected I4, but got I8
		//IL_07db: Expected I4, but got I8
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_071e: Expected I4, but got Unknown
		//IL_081c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Expected I4, but got Unknown
		//IL_076e: Expected I4, but got O
		//IL_077b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected O, but got Unknown
		//IL_0871: Expected I4, but got O
		//IL_087e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0883: Expected O, but got Unknown
		//IL_0a7c->IL08a1: Incompatible stack heights: 1 vs 0
		//IL_0521->IL0521: Incompatible stack heights: 2 vs 1
		//IL_054b->IL08a1: Incompatible stack heights: 1 vs 0
		//IL_0646->IL08a1: Incompatible stack heights: 1 vs 0
		//IL_0674->IL08a1: Incompatible stack heights: 1 vs 0
		//IL_03e6->IL0a58: Incompatible stack heights: 4 vs 1
		//IL_06a0->IL08a1: Incompatible stack heights: 1 vs 0
		//IL_07b7->IL08a1: Incompatible stack heights: 5 vs 0
		//IL_0b5d->IL08a1: Incompatible stack heights: 5 vs 0
		//IL_0b86->IL08a1: Incompatible stack heights: 5 vs 0
		//IL_0755->IL08a1: Incompatible stack heights: 6 vs 0
		//IL_0798->IL0b39: Incompatible stack heights: 6 vs 5
		//IL_0858->IL08a1: Incompatible stack heights: 6 vs 0
		//IL_079d->IL079d: Incompatible stack heights: 6 vs 5
		//IL_089b->IL0b62: Incompatible stack heights: 6 vs 5
		//IL_08a0->IL08a0: Incompatible stack heights: 6 vs 5
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InternalUpdate();
		if (!_hasBullets)
		{
			InitBullets();
			_hasBullets = true;
		}
		object obj3 = Time.deltaTime;
		nint num = (nint)this;
		float num3 = default(float);
		float num2 = num3 * 1000f;
		float num4 = (_singularityTime = num2 + _singularityTime);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune2_Weapon>)+5D0]");
		int num5 = 0;
		float num6 = SingularityDelay();
		if (num4 > num3)
		{
			_singularityTime = 0f;
			DoSingularity();
			num5 = 0;
		}
		if (!_doingSingularity)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer = s_scene._renderer;
					if (s_scene._renderer != null && (object)GM.Core != null)
					{
						PhaserScene s_scene2 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer2 = s_scene2._renderer;
							if (s_scene2._renderer != null)
							{
								float num7 = renderer2.height * 0.5f;
								float num8 = renderer.width * 0.5f;
								if (!(num7 > num8))
								{
									num8 = num7;
								}
								Circle emitZone = _emitZone;
								radius = num8;
								if (_emitZone != null)
								{
									float num9 = num8 * 0.8f;
									float num10 = (emitZone._radius = num9 * 100f);
									float diameter = num10 + num10;
									emitZone._diameter = diameter;
									Circle circleEmitCircle = _circleEmitCircle;
									if (_circleEmitCircle != null)
									{
										float num11 = (circleEmitCircle._radius = radius * 100f);
										num3 = (circleEmitCircle._diameter = num11 + num11);
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer3 = s_scene3._renderer;
												if (s_scene3._renderer != null && (object)_pfxManager != null)
												{
													num5 = -renderer3.pixelHeight;
													ParticleEmitterManager particleEmitterManager = _pfxManager.SetDepth(num5);
													EmitZone circleEmitZone = _circleEmitZone;
													if (_circleEmitZone != null)
													{
														circleEmitZone._source = _circleEmitCircle;
														float num12 = 100f;
														goto IL_097d;
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
			goto IL_08a1;
		}
		goto IL_097d;
		IL_0a58:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1922 @ rax_v28 (should have been resolved before IL gen)");
		if ((object)_well1 != null)
		{
			goto IL_0521;
		}
		goto IL_08a1;
		IL_097d:
		object obj4 = Time.deltaTime;
		float num13 = (_angleValue = num3 + _angleValue);
		float2 ret2;
		float2 a = default(float2);
		float2 float6 = default(float2);
		if (_playerControlled)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)_well1 != null)
				{
					Transform transform = _well1.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
						object obj5 = Time.deltaTime;
						float num14 = (float)ret * 5f;
						float2 b = default(float2);
						Vector3.Slerp_Injected(ref *(Vector3*)(&a), ref *(Vector3*)(&b), (float)_circleEmitZone, out *(Vector3*)(&ret2));
						bool flag2 = (object)_well1 == null;
						Transform transform2 = _well1.transform;
						bool flag3 = (object)transform2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1830 @ rax_v110 (UnityEngine.Transform)+10]");
						Transform transform3 = (Transform)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1830 @ rax_v110 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						object obj6 = 0;
						PhaserScene s_scene = (PhaserScene)(&ret2);
						float num15 = num14;
						a = ret2;
						float2 float5 = ret2;
						goto IL_0a58;
					}
				}
			}
		}
		else if ((object)_well1 != null)
		{
			Transform transform4 = _well1.transform;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					float num16 = num13 * radius;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+84]");
					float num12 = 0f - num16;
					bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					object obj6 = 0;
					bool flag6 = (nint)0 != 0;
					Transform transform3 = (Transform)(nint)((UnityEngine.Object)transform4).m_CachedPtr;
					float num15 = 0f;
					a = float6;
					float2 float5 = float6;
					if (!flag6)
					{
						bool flag7 = (nint)0 == 0;
						goto IL_0521;
					}
					goto IL_0a58;
				}
			}
		}
		goto IL_08a1;
		IL_0521:
		((UnityEngine.Object)_well1).SetName("WELL UNO");
		if ((object)_well2 != null)
		{
			((UnityEngine.Object)_well2).SetName("DUE DUE");
			if (!_skipEmitUpdate)
			{
				RenderingExtensions.SetBlendMode(_emitter1, BlendMode.Add);
				RenderingExtensions.SetBlendMode(_emitter2, BlendMode.Add);
				RenderingExtensions.SetEmitZone(emitZone: new EmitZone
				{
					_type = EmitZoneType.Random,
					_source = _emitZone
				}, pfx: _emitter1);
				RenderingExtensions.SetEmitZone(emitZone: new EmitZone
				{
					_type = EmitZoneType.Random,
					_source = _emitZone
				}, pfx: _emitter2);
			}
			if ((object)_fixedCircleEmitter != null)
			{
				Transform transform5 = _fixedCircleEmitter.transform;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Transform transform6 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
					if ((object)transform6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rax_v34 (UnityEngine.Transform)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ rax_v34 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret2));
						bool flag9 = (object)transform5 == null;
						bool flag10 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
						Transform.set_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&a));
						bool flag11 = (object)_emitter1 == null;
						int particles = _emitter1.GetParticles(_activeParticles1, -1, 0);
						if (particles <= 0)
						{
							goto IL_079d;
						}
						Extensions.Shuffle(_activeParticles1);
						object obj7 = null;
						while (true)
						{
							ParticleSystem.Particle[] activeParticles = _activeParticles1;
							if (_activeParticles1 == null)
							{
								break;
							}
							int num17 = obj7 % particles;
							bool flag12 = num17 >= activeParticles.Length;
							if (InvisProjectilesPool == null)
							{
								break;
							}
							Projectile projectile = InvisProjectilesPool.SpawnAt(float6, this, (int)obj7);
							obj7++;
							if ((nint)obj7 < 20)
							{
								continue;
							}
							goto IL_079d;
						}
					}
				}
			}
		}
		goto IL_08a1;
		IL_08a1:
		throw new NullReferenceException();
		IL_079d:
		if ((object)_emitter2 != null)
		{
			int particles2 = _emitter2.GetParticles(_activeParticles2, -1, 0);
			if (particles2 <= 0)
			{
				return;
			}
			Extensions.Shuffle(_activeParticles2);
			object obj8 = null;
			while (true)
			{
				ParticleSystem.Particle[] activeParticles2 = _activeParticles2;
				if (_activeParticles2 == null)
				{
					break;
				}
				int num18 = obj8 % particles2;
				bool flag13 = num18 >= activeParticles2.Length;
				if (InvisProjectilesPool == null)
				{
					break;
				}
				Projectile projectile2 = InvisProjectilesPool.SpawnAt(float6, this, (int)obj8);
				obj8++;
				if ((nint)obj8 >= 20)
				{
					return;
				}
			}
		}
		goto IL_08a1;
	}

	public override void Cleanup()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Cleanup();
		}
		if (_secondaryPool != null)
		{
			_secondaryPool.Cleanup();
		}
		if (_restoreTween != null)
		{
			_restoreTween.Kill();
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		if (_singularityTween != null)
		{
			_singularityTween.Kill();
		}
		if (_singularityExplosionTween != null)
		{
			_singularityExplosionTween.Kill();
		}
		_emitter1.Stop();
		_emitter2.Stop();
		_fixedCircleEmitter.Stop();
		EX_Rune2_SpinningProjectile bulletA = _bulletA;
		if ((object)_bulletA != null && ((UnityEngine.Object)bulletA).m_CachedPtr != (IntPtr)0)
		{
			_bulletA.Despawn();
		}
		EX_Rune2_SpinningProjectile bulletB = _bulletB;
		if ((object)_bulletB != null && ((UnityEngine.Object)bulletB).m_CachedPtr != (IntPtr)0)
		{
			_bulletB.Despawn();
		}
		base.Cleanup();
	}

	protected virtual float SingularityPower()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		bool flag = _currentWeaponData == null;
		float num2 = default(float);
		float num = num2;
		if (!flag)
		{
			bool flag2 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			num = num2;
			if (!flag2)
			{
				float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
				bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
				num = num2;
				if (!flag3)
				{
					float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PSpeed();
					bool flag4 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
					num = num2;
					if (!flag4)
					{
						num = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
							float num5 = num2 * currentWeaponData._003Cpower_003Ek__BackingField;
							float num6 = num5 * num2;
							float num7 = num6 * num;
							return num + num7;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	protected virtual float SingularityDelay()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldown();
		object obj = default(object);
		float num2 = (float)obj + characterController._003CSilentCooldown_003Ek__BackingField;
		bool flag = !(0.1f < num2);
		float num3 = 0.1f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = num3 * 10000f;
		return num4 + 10000f;
	}

	private void InitBullets()
	{
		//IL_00bd: Expected I, but got O
		//IL_00cb: Expected I, but got O
		//IL_00db: Expected O, but got I
		//IL_015b: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_014d: Expected O, but got I4
		//IL_0293: Expected I, but got O
		//IL_02a1: Expected I, but got O
		//IL_02b1: Expected O, but got I
		//IL_0331: Expected O, but got I4
		//IL_02ed: Expected O, but got I
		//IL_0323: Expected O, but got I4
		//IL_040b->IL039b: Incompatible stack heights: 1 vs 0
		//IL_0062->IL039b: Incompatible stack heights: 1 vs 0
		//IL_045a->IL039b: Incompatible stack heights: 2 vs 0
		//IL_0188->IL039b: Incompatible stack heights: 2 vs 0
		//IL_01b6->IL039b: Incompatible stack heights: 2 vs 0
		//IL_01df->IL039b: Incompatible stack heights: 2 vs 0
		//IL_020b->IL039b: Incompatible stack heights: 2 vs 0
		//IL_04e1->IL039b: Incompatible stack heights: 3 vs 0
		//IL_0241->IL039b: Incompatible stack heights: 3 vs 0
		//IL_0530->IL039b: Incompatible stack heights: 4 vs 0
		//IL_035d->IL039b: Incompatible stack heights: 4 vs 0
		//IL_038b->IL039b: Incompatible stack heights: 4 vs 0
		Vector3 ret;
		Vector3 ret2;
		Projectile projectile;
		float2 pos = default(float2);
		Transform bulletA;
		object obj3;
		if ((object)_well1 != null)
		{
			Transform transform = _well1.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_well1 != null)
				{
					Transform transform2 = _well1.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret2);
						if (_spinningPool != null)
						{
							projectile = _spinningPool.SpawnAt(pos, this);
							if ((object)projectile == null)
							{
								bulletA = null;
								goto IL_045f;
							}
							nint num = (nint)projectile;
							nint num2 = (nint)typeof(EX_Rune2_SpinningProjectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune2_SpinningProjectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ rdx_v45 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune2_SpinningProjectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ r8_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v899 @ rax_v89+FFFFFFF8+v798 @ rax_v84*8]");
								if (0 == (nint)typeof(EX_Rune2_SpinningProjectile))
								{
									obj3 = 1;
									goto IL_046e;
								}
							}
							obj3 = 0;
							goto IL_046e;
						}
					}
				}
			}
		}
		goto IL_039b;
		IL_039b:
		throw new NullReferenceException();
		IL_0544:
		object obj4;
		bool flag3 = obj4 == null;
		Transform bulletB = null;
		Projectile projectile2;
		if (!flag3)
		{
			bulletB = (Transform)(object)projectile2;
		}
		goto IL_0535;
		IL_045f:
		_bulletA = (EX_Rune2_SpinningProjectile)(object)bulletA;
		if ((object)_well1 != null)
		{
			Transform transform3 = _well1.transform;
			if ((object)_bulletA != null && (object)_well2 != null)
			{
				Transform transform4 = _well2.transform;
				if ((object)transform4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v41 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v41 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret2);
					if ((object)_well2 != null)
					{
						Transform transform5 = _well2.transform;
						if ((object)transform5 != null)
						{
							bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out ret);
							if (_spinningPool != null)
							{
								projectile2 = _spinningPool.SpawnAt(pos, this, 1);
								bool flag6 = (object)projectile2 == null;
								bulletB = null;
								if (flag6)
								{
									goto IL_0535;
								}
								nint num4 = (nint)projectile2;
								nint num5 = (nint)typeof(EX_Rune2_SpinningProjectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune2_SpinningProjectile>)+130]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1156 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ rdx_v40 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune2_SpinningProjectile>)+130]");
								if (num6 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1156 @ r8_v26 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1212 @ rax_v70+FFFFFFF8+v1158 @ rax_v66*8]");
									if (0 == (nint)typeof(EX_Rune2_SpinningProjectile))
									{
										obj4 = 1;
										goto IL_0544;
									}
								}
								obj4 = 0;
								goto IL_0544;
							}
						}
					}
				}
			}
		}
		goto IL_039b;
		IL_0535:
		_bulletB = (EX_Rune2_SpinningProjectile)(object)bulletB;
		if ((object)_well2 != null)
		{
			Transform transform6 = _well2.transform;
			if ((object)_bulletB != null)
			{
				return;
			}
		}
		goto IL_039b;
		IL_046e:
		bool flag7 = obj3 == null;
		bulletA = null;
		if (!flag7)
		{
			bulletA = (Transform)(object)projectile;
		}
		goto IL_045f;
	}

	private unsafe void DoSingularity()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0044: Expected O, but got I
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Expected O, but got Unknown
		//IL_0611: Expected O, but got I
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected O, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Expected O, but got Unknown
		//IL_0787: Expected O, but got Ref
		//IL_07b5: Expected O, but got Ref
		//IL_07c3: Expected native int or pointer, but got O
		//IL_00df: Expected O, but got I
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Expected O, but got Unknown
		//IL_06c8: Expected O, but got I
		//IL_01ba: Expected O, but got I
		//IL_024f: Expected I, but got O
		//IL_02b4: Expected O, but got Ref
		//IL_0436: Expected I, but got O
		//IL_049b: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_003C_003Ec__DisplayClass47_0 CS_0024_003C_003E8__locals35 = new _003C_003Ec__DisplayClass47_0();
		CS_0024_003C_003E8__locals35._003C_003E4__this = this;
		_ = _fixedCircleEmitter;
		CS_0024_003C_003E8__locals35.s = (ParticleSystem.ShapeModule)_fixedCircleEmitter;
		_ = _fixedCircleEmitter;
		CS_0024_003C_003E8__locals35.e = (ParticleSystem.EmissionModule)_fixedCircleEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = CS_0024_003C_003E8__locals35 + 24;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v766 @ rax_v29 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = CS_0024_003C_003E8__locals35 + 24;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v841 @ rax_v32 (should have been resolved before IL gen)");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.ShapeModule shapeModule = (ParticleSystem.ShapeModule)(CS_0024_003C_003E8__locals35 + 24);
		ParticleSystem.MinMaxCurve arcSpeed = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
		_ = 0;
		((ParticleSystem.ShapeModule*)shapeModule)->arcSpeed = arcSpeed;
		ParticleSystem.Burst burst = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		*(ParticleSystem.Burst*)(nint)burst = new ParticleSystem.Burst(0f, 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
		object obj7 = 0;
		_ = 1048576000;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj7 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		object obj8 = CS_0024_003C_003E8__locals35 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v940 @ rax_v38 (should have been resolved before IL gen)");
		_doingSingularity = true;
		ScreenShake();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1056964608;
		soundConfig.Rate = 1f;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
		soundConfig.Volume = (float?)(object)0;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_magic_charge4, soundConfig, 400f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1056964608;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+77]");
		soundConfig2.Volume = (float?)(object)0;
		soundConfig2.Detune = -500f;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Sfx_magic_charge4, soundConfig2, 400f, 3, time);
		if (_singularityTween != null)
		{
			_singularityTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj9 = default(object);
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
			_ = 1036831949;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"radius", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 5000f;
			TweenCallback onUpdate = delegate
			{
				//IL_007f: Expected O, but got I
				EX_Rune2_Weapon eX_Rune2_Weapon = CS_0024_003C_003E8__locals35._003C_003E4__this;
				Circle circleEmitCircle = eX_Rune2_Weapon._circleEmitCircle;
				float num5 = (circleEmitCircle._radius = eX_Rune2_Weapon.radius * 100f);
				float diameter = num5 + num5;
				circleEmitCircle._diameter = diameter;
				EX_Rune2_Weapon eX_Rune2_Weapon2 = CS_0024_003C_003E8__locals35._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
				object obj13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj13 == null)
					{
						MissingMethodException ex6 = new MissingMethodException();
						throw ex6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v252 @ rax_v12 (should have been resolved before IL gen)");
			};
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onComplete = delegate
			{
				//IL_002c: Expected I, but got O
				//IL_022a: Expected O, but got I4
				//IL_026b: Expected O, but got I4
				//IL_02c3: Expected O, but got I4
				//IL_031b: Expected O, but got I4
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				if ((object)CS_0024_003C_003E8__locals35._003C_003E4__this != null)
				{
					nint num5 = (nint)array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj13 = default(object);
					if (obj13 == null)
					{
						ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
						throw ex6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value3 = default(object);
				bool flag3 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"radius", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig3.custom = dictionary3;
				TweenCallback onUpdate3 = CS_0024_003C_003E8__locals35._003C_003E9__2;
				if (CS_0024_003C_003E8__locals35._003C_003E9__2 == null)
				{
					onUpdate3 = (CS_0024_003C_003E8__locals35._003C_003E9__2 = delegate
					{
						//IL_0021: Expected O, but got I
						EX_Rune2_Weapon eX_Rune2_Weapon3 = CS_0024_003C_003E8__locals35._003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj14 == null)
							{
								MissingMethodException ex7 = new MissingMethodException();
								throw ex7;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v199 @ rax_v11 (should have been resolved before IL gen)");
					});
				}
				tweenConfig3.onUpdate = onUpdate3;
				tweenConfig3.duration = 1000f;
				tweenConfig3.delay = 3000f;
				TweenCallback onStart2 = CS_0024_003C_003E8__locals35._003C_003E9__3;
				if (CS_0024_003C_003E8__locals35._003C_003E9__3 == null)
				{
					onStart2 = (CS_0024_003C_003E8__locals35._003C_003E9__3 = delegate
					{
						//IL_0008: Expected O, but got Ref
						//IL_0024: Expected O, but got I
						//IL_0186: Unknown result type (might be due to invalid IL or missing references)
						//IL_018b: Expected O, but got Unknown
						//IL_01a5: Expected O, but got I
						//IL_021a: Unknown result type (might be due to invalid IL or missing references)
						//IL_021f: Expected O, but got Unknown
						//IL_0237: Expected O, but got Ref
						//IL_024c: Expected native int or pointer, but got O
						//IL_0257: Unknown result type (might be due to invalid IL or missing references)
						//IL_025c: Expected O, but got Unknown
						//IL_026a: Expected O, but got Ref
						//IL_029f: Expected O, but got Ref
						//IL_02ad: Expected native int or pointer, but got O
						//IL_00d0: Expected O, but got I
						//IL_01ef: Expected O, but got Ref
						//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
						//IL_01fa: Expected O, but got Unknown
						object obj15 = default(object);
						object obj14 = (object)(&obj15);
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
						object obj16 = 0;
						_ = 0;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj16 == null)
							{
								MissingMethodException ex7 = new MissingMethodException();
								throw ex7;
							}
						}
						object obj17 = CS_0024_003C_003E8__locals35 + 24;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53 @ rax_v9 (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj18 == null)
							{
								MissingMethodException ex8 = new MissingMethodException();
								throw ex8;
							}
						}
						object obj19 = CS_0024_003C_003E8__locals35 + 24;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v92 @ rax_v12 (should have been resolved before IL gen)");
						ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj15, 9));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(-1f));
						ParticleSystem.ShapeModule shapeModule2 = (ParticleSystem.ShapeModule)(CS_0024_003C_003E8__locals35 + 24);
						ParticleSystem.MinMaxCurve arcSpeed2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj15, 55));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
						_ = 0;
						((ParticleSystem.ShapeModule*)shapeModule2)->arcSpeed = arcSpeed2;
						ParticleSystem.Burst burst2 = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj15, 73));
						*(ParticleSystem.Burst*)(nint)burst2 = new ParticleSystem.Burst(0f, 1);
						_ = 1008981770;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
						object obj20 = 0;
						_ = 4294967295L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAA0]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							if (obj20 == null)
							{
								MissingMethodException ex9 = new MissingMethodException();
								throw ex9;
							}
						}
						object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj15, 9));
						object obj22 = CS_0024_003C_003E8__locals35 + 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v172 @ rax_v18 (should have been resolved before IL gen)");
					});
				}
				tweenConfig3.onStart = onStart2;
				MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig3);
				EX_Rune2_Weapon eX_Rune2_Weapon = CS_0024_003C_003E8__locals35._003C_003E4__this;
				eX_Rune2_Weapon._playerControlled = true;
				CS_0024_003C_003E8__locals35._003C_003E4__this.ExplodeSingularity();
				CS_0024_003C_003E8__locals35._003C_003E4__this.ScreenShake();
				SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
				soundConfig3.Rate = 1f;
				soundConfig3.Volume = (float?)(object)1;
				float time2 = default(float);
				PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Sfx_exp45, soundConfig3, 200f, 4, time2);
				SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
				soundConfig4.Volume = (float?)(object)1;
				soundConfig4.Rate = 1f;
				soundConfig4.Detune = -400f;
				PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Carrello, soundConfig4, 200f, 4, time2);
				SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
				soundConfig5.Volume = (float?)(object)1;
				soundConfig5.Rate = 1f;
				soundConfig5.Detune = -600f;
				PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Carrello, soundConfig5, 200f, 4, time2);
				SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
				soundConfig6.Volume = (float?)(object)1;
				soundConfig6.Rate = 1f;
				soundConfig6.Detune = -2000f;
				PlaySoundResult playSoundResult6 = SoundManager.PlaySound(SfxType.Carrello, soundConfig6, 200f, 4, time2);
				EX_Rune2_Weapon eX_Rune2_Weapon2 = CS_0024_003C_003E8__locals35._003C_003E4__this;
				float singularityTimes = eX_Rune2_Weapon2._singularityTimes + 1f;
				eX_Rune2_Weapon2._singularityTimes = singularityTimes;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween singularityTween = Tweens.Add(tweenConfig);
			_singularityTween = singularityTween;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			float num2 = renderer2.height * 0.4f;
			float num3 = renderer.width * 0.4f;
			if (!(num2 > num3))
			{
				num3 = num2;
			}
			if (_restoreTween != null)
			{
				_restoreTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			if (obj11 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object value2 = default(object);
				bool flag2 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"radius", value2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				tweenConfig2.custom = dictionary2;
				tweenConfig2.duration = 200f;
				tweenConfig2.delay = 8000f;
				TweenCallback onStart = delegate
				{
					//IL_003a: Expected O, but got I4
					//IL_007b: Expected O, but got I4
					//IL_00d3: Expected O, but got I4
					//IL_012b: Expected O, but got I4
					CS_0024_003C_003E8__locals35._003C_003E4__this.ScreenShake();
					SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
					soundConfig3.Rate = 1f;
					soundConfig3.Volume = (float?)(object)1;
					float time2 = default(float);
					PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Sfx_exp5, soundConfig3, 200f, 4, time2);
					SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
					soundConfig4.Volume = (float?)(object)1;
					soundConfig4.Rate = 1f;
					soundConfig4.Detune = -600f;
					PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Carrello, soundConfig4, 200f, 4, time2);
					SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
					soundConfig5.Volume = (float?)(object)1;
					soundConfig5.Rate = 1f;
					soundConfig5.Detune = -800f;
					PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Carrello, soundConfig5, 200f, 4, time2);
					SoundManager.SoundConfig soundConfig6 = new SoundManager.SoundConfig();
					soundConfig6.Volume = (float?)(object)1;
					soundConfig6.Rate = 1f;
					soundConfig6.Detune = -2000f;
					PlaySoundResult playSoundResult6 = SoundManager.PlaySound(SfxType.Carrello, soundConfig6, 200f, 4, time2);
				};
				tweenConfig2.onStart = onStart;
				TweenCallback onComplete2 = delegate
				{
					EX_Rune2_Weapon eX_Rune2_Weapon = CS_0024_003C_003E8__locals35._003C_003E4__this;
					eX_Rune2_Weapon._doingSingularity = false;
					Action onComplete3 = CS_0024_003C_003E8__locals35._003C_003E9__7;
					if (CS_0024_003C_003E8__locals35._003C_003E9__7 == null)
					{
						onComplete3 = (CS_0024_003C_003E8__locals35._003C_003E9__7 = delegate
						{
							//IL_0065: Expected F4, but got I
							EX_Rune2_Weapon eX_Rune2_Weapon2 = CS_0024_003C_003E8__locals35._003C_003E4__this;
							eX_Rune2_Weapon2._playerControlled = false;
							EX_Rune2_Weapon eX_Rune2_Weapon3 = CS_0024_003C_003E8__locals35._003C_003E4__this;
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)eX_Rune2_Weapon3)._003COwner_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rdx_v2 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							float angleValue = num5 ^ 0;
							eX_Rune2_Weapon3._angleValue = angleValue;
						});
					}
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer timer = Timers.Register(2f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				};
				tweenConfig2.onComplete = onComplete2;
				TweenCallback onUpdate2 = delegate
				{
					EX_Rune2_Weapon eX_Rune2_Weapon = CS_0024_003C_003E8__locals35._003C_003E4__this;
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer3 = s_scene3._renderer;
					ParticleEmitterManager particleEmitterManager = eX_Rune2_Weapon._pfxManager.SetDepth(renderer3.pixelHeight);
					EX_Rune2_Weapon eX_Rune2_Weapon2 = CS_0024_003C_003E8__locals35._003C_003E4__this;
					float2 position = ((Equipment)eX_Rune2_Weapon2)._003COwner_003Ek__BackingField.position;
					Vector2 pos = default(Vector2);
					RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon2._emitter1, pos, 80);
					EX_Rune2_Weapon eX_Rune2_Weapon3 = CS_0024_003C_003E8__locals35._003C_003E4__this;
					float2 position2 = ((Equipment)eX_Rune2_Weapon3)._003COwner_003Ek__BackingField.position;
					RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon3._emitter2, pos, 80);
				};
				tweenConfig2.onUpdate = onUpdate2;
				MultiTargetTween restoreTween = Tweens.Add(tweenConfig2);
				_restoreTween = restoreTween;
				return;
			}
			ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
			throw ex4;
		}
		ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
		throw ex5;
	}

	private unsafe void ExplodeSingularity()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00b0: Expected O, but got Ref
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0143: Expected O, but got Ref
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_03d6: Expected I, but got O
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		_skipEmitUpdate = true;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		object obj2 = default(object);
		object obj = obj2 * Lifetime1_Max;
		float num3 = Lifetime1_Min * (float)obj2;
		float max = (float)obj * 0.001f;
		float min = num3 * 0.001f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, max);
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(this + 392);
		object obj3 = default(object);
		((ParticleSystem.MainModule*)mainModule)->startLifetime = (ParticleSystem.MinMaxCurve)(&obj3);
		float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		float num5 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		object obj4 = 0 * Lifetime2_Max;
		float num6 = Lifetime2_Min * 0f;
		float max2 = (float)obj4 * 0.001f;
		float min2 = num6 * 0.001f;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(min2, max2);
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)(this + 400);
		((ParticleSystem.MainModule*)mainModule2)->startLifetime = (ParticleSystem.MinMaxCurve)(&obj3);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Rectangle rectangle = new Rectangle();
		float width = renderer.width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj5 = width ^ 0;
		float x = (float)obj5 * 0.5f;
		rectangle._y = -0.049999997f;
		rectangle._width = renderer2.width;
		rectangle._height = 0.099999994f;
		rectangle._x = x;
		CS_0024_003C_003E8__locals13.rect = rectangle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = CS_0024_003C_003E8__locals13.rect;
		RenderingExtensions.SetEmitZone(_emitter1, emitZone);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = CS_0024_003C_003E8__locals13.rect;
		RenderingExtensions.SetEmitZone(_emitter2, emitZone2);
		Material material = MaterialManager.GetMaterial(MaterialType.ParticlesAdditive);
		ParticleSystemRenderer component = _emitter1.GetComponent<ParticleSystemRenderer>();
		Material material2 = ((Renderer)component).GetMaterial();
		Shader shader = material.shader;
		material2.shader = shader;
		Material material3 = MaterialManager.GetMaterial(MaterialType.ParticlesAdditive);
		ParticleSystemRenderer component2 = _emitter2.GetComponent<ParticleSystemRenderer>();
		Material material4 = ((Renderer)component2).GetMaterial();
		Shader shader2 = material3.shader;
		material4.shader = shader2;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		float halfWidth = (float)renderer3.pixelWidth * 0.5f;
		CS_0024_003C_003E8__locals13.halfWidth = halfWidth;
		SingularityExplosionValue = 0f;
		if (_singularityExplosionTween != null)
		{
			_singularityExplosionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num7 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj6 = default(object);
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"SingularityExplosionValue", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = 200f;
			TweenCallback onUpdate = delegate
			{
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				//IL_002b: Expected O, but got Unknown
				EX_Rune2_Weapon eX_Rune2_Weapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
				Rectangle rect = CS_0024_003C_003E8__locals13.rect;
				float halfWidth2 = CS_0024_003C_003E8__locals13.halfWidth;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj7 = halfWidth2 ^ 0;
				float x2 = (float)obj7 * eX_Rune2_Weapon.SingularityExplosionValue;
				rect._x = x2;
				Rectangle rect2 = CS_0024_003C_003E8__locals13.rect;
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer4 = s_scene4._renderer;
				EX_Rune2_Weapon eX_Rune2_Weapon2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float width2 = (float)renderer4.pixelWidth * eX_Rune2_Weapon2.SingularityExplosionValue;
				rect2._width = width2;
				EX_Rune2_Weapon eX_Rune2_Weapon3 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float2 position = ((Equipment)eX_Rune2_Weapon3)._003COwner_003Ek__BackingField.position;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon3._emitter1, pos, 160);
				EX_Rune2_Weapon eX_Rune2_Weapon4 = CS_0024_003C_003E8__locals13._003C_003E4__this;
				float2 position2 = ((Equipment)eX_Rune2_Weapon4)._003COwner_003Ek__BackingField.position;
				RenderingExtensions.EmitParticleAt(eX_Rune2_Weapon4._emitter2, pos, 160);
			};
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onComplete = delegate
			{
				EX_Rune2_Weapon eX_Rune2_Weapon = CS_0024_003C_003E8__locals13._003C_003E4__this;
				eX_Rune2_Weapon._skipEmitUpdate = false;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween singularityExplosionTween = Tweens.Add(tweenConfig);
			_singularityExplosionTween = singularityExplosionTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	protected override void OnStart()
	{
		base.OnStart();
	}

	private void ScreenShake()
	{
		//IL_00e2: Expected I, but got O
		//IL_0162: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
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
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__50_0;
		if (_003C_003Ec._003C_003E9__50_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__50_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__50_1;
		if (_003C_003Ec._003C_003E9__50_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__50_1 = delegate
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
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (visible)
		{
			RenderingExtensions.Start(_fixedCircleEmitter);
			EX_Rune2_SpinningProjectile bulletA = _bulletA;
			if ((object)_bulletA == null || ((UnityEngine.Object)bulletA).m_CachedPtr == (IntPtr)0)
			{
				InitBullets();
			}
			return;
		}
		_fixedCircleEmitter.Stop();
		EX_Rune2_SpinningProjectile bulletA2 = _bulletA;
		if ((object)_bulletA != null && ((UnityEngine.Object)bulletA2).m_CachedPtr != (IntPtr)0)
		{
			_bulletA.Despawn();
			_bulletA = null;
		}
		EX_Rune2_SpinningProjectile bulletB = _bulletB;
		if ((object)_bulletB != null && ((UnityEngine.Object)bulletB).m_CachedPtr != (IntPtr)0)
		{
			_bulletB.Despawn();
			_bulletB = null;
		}
	}

	protected float StripLength()
	{
		float num = base.PAmount();
		float num2 = base.PSpeed();
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		object obj2 = default(object);
		object obj = obj2 * obj2;
		return (float)obj2 * (float)obj;
	}

	private void FireStripAtEnemy(EnemyController enemy, int index, Vector2 startPosition, bool flipMyY = false)
	{
		//IL_004c: Expected I, but got O
		//IL_005c: Expected O, but got I
		//IL_0090: Invalid comparison between F4 and I4
		//IL_0382: Expected O, but got I4
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_0473: Invalid comparison between F4 and I4
		//IL_0312: Invalid comparison between F4 and I4
		//IL_02dc: Expected I4, but got F4
		//IL_0141: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_0159: Expected O, but got I
		//IL_0201: Expected O, but got I4
		//IL_019d: Expected O, but got I
		//IL_01cc: Expected O, but got I
		//IL_01ea: Expected O, but got I
		//IL_01f3: Expected O, but got I4
		_003C_003Ec__DisplayClass53_0 obj = new _003C_003Ec__DisplayClass53_0();
		obj._003C_003E4__this = this;
		obj.startPosition = startPosition;
		obj.enemy = enemy;
		bool flipMyY2 = default(bool);
		obj.flipMyY = flipMyY2;
		float num = base.PAmount();
		float num2 = base.PSpeed();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num3 = (nint)characterController;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+520]");
		Action action = (Action)0;
		float num4 = characterController.PDuration();
		float num5 = (float)startPosition * (float)startPosition;
		float num6 = (float)startPosition * num5;
		float num7 = default(float);
		if (num6 > 0f)
		{
			bool flag = false;
			float num8 = default(float);
			num7 = num8;
			float num10 = default(float);
			Action action2 = default(Action);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag5;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				float num9 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num10);
				float num11 = (float)(flag ? 1 : 0) * num9;
				Projectile projectile;
				object obj3;
				if (!(num11 > 0f))
				{
					projectile = base.FireOneProjectile((Vector2)action2, flag ? 1 : 0);
					bool flag2 = (object)projectile == null;
					action = action2;
					if (!flag2)
					{
						nint num12 = (nint)typeof(EX_Rune1_Projectile);
						nint num13 = (nint)projectile;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						Action action3 = (Action)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						bool flag3 = num14 < 0;
						action = action2;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v678 @ r9_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rcx_v34+FFFFFFF8+v679 @ rcx_v28 (System.Action)*8]");
							bool flag4 = 0 != (nint)typeof(EX_Rune1_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
							action = (Action)0;
							if (!flag4)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
								action = (Action)0;
								obj3 = 1;
								goto IL_0487;
							}
						}
						obj3 = 0;
						goto IL_0487;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass53_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass53_1();
					CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals9.localIndex = (flag ? 1 : 0);
					float hitBoxDelay = base.HitBoxDelay;
					Action action4 = delegate
					{
						//IL_0248: Expected O, but got I4
						//IL_00f4: Expected I, but got O
						//IL_00fc: Expected I, but got O
						//IL_010c: Expected O, but got I
						//IL_018c: Expected O, but got I4
						//IL_0148: Expected O, but got I
						//IL_017e: Expected O, but got I4
						//IL_0084->IL01e8: Incompatible stack heights: 1 vs 0
						//IL_00a6->IL01e8: Incompatible stack heights: 1 vs 0
						//IL_01c2->IL01e8: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass53_0 obj10 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						Projectile projectile2;
						object obj15;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass53_0 obj12 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj12._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									projectile2 = obj12._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals9.localIndex);
									if ((object)projectile2 == null)
									{
										return;
									}
									nint num16 = (nint)typeof(EX_Rune1_Projectile);
									nint num17 = (nint)projectile2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
									object obj13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									nint num18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
									if (num18 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
										object obj14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v18+FFFFFFF8+v392 @ rcx_v14*8]");
										if (0 == (nint)typeof(EX_Rune1_Projectile))
										{
											obj15 = 1;
											goto IL_0265;
										}
									}
									obj15 = 0;
									goto IL_0265;
								}
							}
						}
						goto IL_01e8;
						IL_01e8:
						throw new NullReferenceException();
						IL_0265:
						bool flag8 = obj15 == null;
						EX_Rune1_Projectile eX_Rune1_Projectile2 = null;
						if (!flag8)
						{
							eX_Rune1_Projectile2 = (EX_Rune1_Projectile)projectile2;
						}
						if ((object)eX_Rune1_Projectile2 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass53_0 obj16 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
						{
							eX_Rune1_Projectile2.SetEnemyTarget(obj16.enemy, obj16.flipMyY);
							return;
						}
						goto IL_01e8;
					};
					float num15 = (float)(flag ? 1 : 0) * hitBoxDelay;
					float duration = num15 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, action4, null, isLooped: false, (byte)(int)num7 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					action = action4;
				}
				goto IL_02fc;
				IL_02fc:
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				flag5 = num6 > (float)(flag ? 1 : 0);
				num7 = num7;
				continue;
				IL_0487:
				bool flag6 = obj3 == null;
				EX_Rune1_Projectile eX_Rune1_Projectile = null;
				if (!flag6)
				{
					eX_Rune1_Projectile = (EX_Rune1_Projectile)projectile;
				}
				if ((object)eX_Rune1_Projectile != null)
				{
					eX_Rune1_Projectile.SetEnemyTarget(obj.enemy, obj.flipMyY);
					action = (Action)(object)obj.enemy;
				}
				goto IL_02fc;
			}
			while (flag5);
		}
		if (!obj.flipMyY)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r15d\"");
			soundConfig.Volume = (float?)(object)1;
			object obj4 = (object)action >> 31;
			object obj5 = (object)action + obj4;
			object obj6 = obj5 * 2;
			object obj7 = obj5 + obj6;
			object obj8 = obj7 + obj7;
			object obj9 = index - obj8;
			float detune = (float)obj9 * -500f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Magic4, soundConfig, 200f, 12, num7);
		}
	}

	protected virtual bool OnBulletOverlapsEnemy_AllDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0133: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0150;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = SingularityPower();
									float damage = default(float);
									base.DealDamage(component, damage);
								}
								goto IL_0150;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0150:
		return false;
	}
}
