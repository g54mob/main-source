using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

public class Background5 : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, bool> _003C_003E9__48_1;

		public static Func<Equipment, bool> _003C_003E9__48_2;

		public static Func<VampireSurvivors.Objects.Characters.CharacterController, bool> _003C_003E9__48_0;

		public static Action _003C_003E9__70_2;

		public static Action _003C_003E9__70_0;

		public static DOGetter<float> _003C_003E9__72_0;

		public static DOSetter<float> _003C_003E9__72_1;

		public static DOGetter<float> _003C_003E9__76_0;

		public static DOSetter<float> _003C_003E9__76_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003COnUpdate_003Eb__48_0(VampireSurvivors.Objects.Characters.CharacterController p)
		{
			//IL_00c9: Expected I4, but got O
			if ((object)p != null)
			{
				CharacterWeaponsManager weaponsManager = p._weaponsManager;
				if ((object)p._weaponsManager != null)
				{
					Func<Equipment, bool> predicate = _003C_003E9__48_1;
					if (_003C_003E9__48_1 == null)
					{
						predicate = (_003C_003E9__48_1 = delegate(Equipment x)
						{
							//IL_0052: Expected I4, but got O
							//IL_0030: Expected O, but got I4
							if ((object)x == null)
							{
								NullReferenceException ex2 = new NullReferenceException();
								return (byte)(int)ex2 != 0;
							}
							object obj = x._equipmentType - 27;
							return obj == null;
						});
					}
					bool flag = Enumerable.Any(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, predicate);
					if (flag)
					{
						CharacterWeaponsManager weaponsManager2 = p._weaponsManager;
						if ((object)p._weaponsManager == null)
						{
							goto IL_00bb;
						}
						Func<Equipment, bool> predicate2 = _003C_003E9__48_2;
						if (_003C_003E9__48_2 == null)
						{
							predicate2 = (_003C_003E9__48_2 = delegate(Equipment x)
							{
								//IL_0052: Expected I4, but got O
								//IL_0030: Expected O, but got I4
								if ((object)x == null)
								{
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								}
								object obj = x._equipmentType - 28;
								return obj == null;
							});
						}
						flag = Enumerable.Any(((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField, predicate2);
					}
					return flag;
				}
			}
			goto IL_00bb;
			IL_00bb:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnUpdate_003Eb__48_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 27;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnUpdate_003Eb__48_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 28;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal unsafe void _003CEnterTheBossi_003Eb__70_0()
		{
			//IL_0050: Expected O, but got I4
			//IL_01b7: Expected I, but got O
			//IL_01cd: Expected O, but got I
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Expected O, but got Unknown
			//IL_026f: Expected I, but got O
			//IL_03a7: Expected O, but got I4
			//IL_03be: Expected I, but got I8
			//IL_022d: Expected I, but got I8
			//IL_0304: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Expected O, but got Unknown
			GameManager core = GM.Core;
			Stage stage = core._stage;
			List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
			bool flag = (nint)stage._spawnedEnemies < 0;
			object obj = spawnedEnemies._size - 1;
			if (flag)
			{
				goto IL_018c;
			}
			bool flag5 = default(bool);
			while (true)
			{
				GameManager core2 = GM.Core;
				Stage stage2 = core2._stage;
				List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
				if ((nint)obj >= spawnedEnemies2._size)
				{
					break;
				}
				EnemyController[] items = spawnedEnemies2._items;
				EnemyController enemyController = items[obj];
				CoherenceSync coherenceSync = enemyController._coherenceSync;
				bool flag2 = (nint)enemyController._coherenceSync < 0;
				bool flag4;
				if ((object)enemyController._coherenceSync != null)
				{
					flag2 = (nint)((UnityEngine.Object)coherenceSync).m_CachedPtr < 0;
					if (((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
					{
						bool hasStateAuthority = enemyController._coherenceSync.HasStateAuthority;
						flag2 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
						bool flag3 = !hasStateAuthority;
						flag4 = flag2;
						if (flag3)
						{
							goto IL_02fb;
						}
					}
				}
				enemyController.Disappear();
				flag4 = flag2;
				goto IL_02fb;
				IL_02fb:
				obj--;
				flag5 = flag5;
				if (!flag4)
				{
					continue;
				}
				goto IL_018c;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			goto IL_03d4;
			IL_03d4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
			object obj2 = default(object);
			throw obj2;
			IL_018c:
			SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
			Action onComplete = _003C_003E9__70_2;
			if (_003C_003E9__70_2 != null)
			{
				goto IL_0274;
			}
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec._003CEnterTheBossi_003Eb__70_2);
			((Delegate)action).m_target = _003C_003E9;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj3 = (nint)0 >> 4;
			object obj4 = obj3 & 1;
			nint num2;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_039e;
				}
			}
			else if (_003C_003E9 == null)
			{
				goto IL_03d4;
			}
			num2 = ((Delegate)action).method_ptr;
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			goto IL_039e;
			IL_0274:
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
			IL_039e:
			object obj5 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			_003C_003E9__70_2 = action;
			onComplete = action;
			goto IL_0274;
		}

		internal void _003CEnterTheBossi_003Eb__70_2()
		{
			SoundManager.StopMusic(SoundManager._003CCurrentBgm_003Ek__BackingField);
		}

		internal float _003CFadeOutSky_003Eb__72_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CFadeOutSky_003Eb__72_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}

		internal float _003CEnterPurpleSky_003Eb__76_0()
		{
			return GameManager.SfxVolumeFactor;
		}

		internal void _003CEnterPurpleSky_003Eb__76_1(float x)
		{
			GameManager.SfxVolumeFactor = x;
		}
	}

	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public Background5 _003C_003E4__this;

		public float number;

		internal unsafe void _003CSnapEggs_003Eb__0()
		{
			//IL_056a: Expected O, but got I4
			//IL_05ae: Invalid comparison between F4 and I4
			//IL_00ba: Expected O, but got I4
			//IL_0446: Expected I4, but got O
			//IL_05d7: Expected O, but got F4
			//IL_08b2: Expected O, but got F4
			//IL_04da: Expected I4, but got O
			//IL_0219: Expected I, but got O
			//IL_02bb: Expected I, but got O
			//IL_06cb: Expected O, but got F4
			//IL_06e9: Expected O, but got I4
			//IL_06f7: Expected O, but got I4
			//IL_08c0: Expected O, but got F4
			//IL_08ee: Expected O, but got I4
			//IL_0705: Expected O, but got F4
			//IL_07bb: Expected I, but got O
			//IL_07d1: Expected O, but got I
			//IL_07da: Unknown result type (might be due to invalid IL or missing references)
			//IL_07df: Expected O, but got Unknown
			//IL_0371: Expected I, but got O
			//IL_0805: Expected O, but got I4
			//IL_081c: Expected I, but got I8
			//IL_0832: Expected O, but got I4
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Expected O, but got Unknown
			//IL_03b7: Invalid comparison between F4 and O
			//IL_03d6: Expected O, but got I4
			//IL_035a: Expected I, but got I8
			//IL_0438->IL0530: Incompatible stack heights: 1 vs 0
			//IL_044f->IL0530: Incompatible stack heights: 1 vs 0
			//IL_04c8->IL0530: Incompatible stack heights: 1 vs 0
			//IL_04a6->IL04a6: Incompatible stack heights: 2 vs 1
			//IL_05f6->IL0530: Incompatible stack heights: 1 vs 0
			//IL_0135->IL0530: Incompatible stack heights: 1 vs 0
			//IL_064a->IL0530: Incompatible stack heights: 2 vs 0
			//IL_0169->IL0530: Incompatible stack heights: 2 vs 0
			//IL_019d->IL0530: Incompatible stack heights: 2 vs 0
			//IL_01e9->IL0530: Incompatible stack heights: 2 vs 0
			//IL_023d->IL023d: Incompatible stack heights: 3 vs 2
			//IL_02a1->IL0530: Incompatible stack heights: 3 vs 0
			//IL_02d9->IL02d9: Incompatible stack heights: 5 vs 4
			//IL_06bd->IL0530: Incompatible stack heights: 5 vs 0
			//IL_03f2->IL0837: Incompatible stack heights: 5 vs 1
			//IL_03f7->IL03f7: Incompatible stack heights: 5 vs 1
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1000f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_GameOver, soundConfig, 0f, 10, time);
			Background5 background = _003C_003E4__this;
			if ((object)_003C_003E4__this != null && (object)background._mainCamera != null)
			{
				Transform transform = background._mainCamera.transform;
				if ((object)transform != null)
				{
					bool flag = (byte)(~(((SoundManager.SoundConfig)(object)transform).Mute ? 1u : 0u)) != 0;
					Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform).Mute ? 1 : 0), out Vector3 _);
					float num = number;
					bool flag2 = !(number > 0f);
					int num2 = 10;
					if (!flag2)
					{
						object obj2 = default(object);
						object obj = obj2;
						object obj3 = 0;
						object obj5 = default(object);
						object obj4 = obj5;
						float num3 = number;
						int num4 = 10;
						Vector2 pos = default(Vector2);
						object obj9 = default(object);
						object obj11 = default(object);
						bool flag10;
						do
						{
							bool flag3 = (nint)obj3 >= 500;
							obj2 = obj;
							obj5 = obj4;
							num = num3;
							num2 = num4;
							if (flag3)
							{
								break;
							}
							_003C_003Ec__DisplayClass65_1 obj6 = new _003C_003Ec__DisplayClass65_1();
							object obj7 = UnityEngine.Random.value;
							object obj8 = UnityEngine.Random.value;
							TweenConfig tweenConfig;
							TweenCallback tweenCallback;
							if ((object)_003C_003E4__this != null)
							{
								GameObject gameObject = _003C_003E4__this.gameObject;
								SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, "items", "goldenegg");
								if ((object)spriteRenderer != null)
								{
									bool flag4 = (byte)(~(((SoundManager.SoundConfig)(object)spriteRenderer).Mute ? 1u : 0u)) != 0;
									Renderer.set_sortingOrder_Injected((IntPtr)(((SoundManager.SoundConfig)(object)spriteRenderer).Mute ? 1 : 0), 9000);
									Background5 background2 = _003C_003E4__this;
									if ((object)_003C_003E4__this != null)
									{
										Transform transform2 = spriteRenderer.transform;
										if ((object)transform2 != null)
										{
											transform2.SetParent(background2._spritesRootTransform, worldPositionStays: true);
											if (obj6 != null)
											{
												obj6.s = spriteRenderer;
												tweenConfig = new TweenConfig();
												object[] array = new object[2];
												if (array != null)
												{
													if ((object)obj6.s != null)
													{
														nint num5 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag5 = obj9 == null;
													}
													bool flag6 = array.Length <= 0;
													array[0] = obj6.s;
													SoundManager.SoundConfig s = (SoundManager.SoundConfig)(object)obj6.s;
													if ((object)obj6.s != null)
													{
														bool flag7 = (byte)(~(s.Mute ? 1u : 0u)) != 0;
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)(s.Mute ? 1 : 0));
														Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														if ((object)transform3 != null)
														{
															Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
															bool flag8 = (object)transform4 == null;
														}
														bool flag9 = array.Length <= 1;
														array[1] = transform3;
														if (tweenConfig != null)
														{
															tweenConfig.targets = array;
															object obj10 = UnityEngine.Random.value;
															float num6 = (float)obj11 + 0.32f;
															tweenConfig.x = (float?)(object)1;
															tweenConfig.y = (float?)(object)1;
															object obj12 = UnityEngine.Random.value;
															float num7 = num6 * 180f;
															float num8 = num7 + 180f;
															tweenConfig.angle = (float?)(object)1;
															object obj13 = UnityEngine.Random.value;
															float num9 = num8 * 300f;
															tweenConfig.ease = Ease.InCirc;
															float duration = num9 + 300f;
															tweenConfig.duration = duration;
															float delay = (float)obj3 * 10f;
															tweenConfig.delay = delay;
															tweenCallback = null;
															nint num10 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
															num2 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19 (Il2CppMethodInfo)+8]");
															((Delegate)tweenCallback).method_ptr = (IntPtr)0;
															((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass65_1._003CSnapEggs_003Eb__1);
															((Delegate)tweenCallback).m_target = obj6;
															((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19 (Il2CppMethodInfo)+4C]");
															object obj14 = (nint)0 >> 4;
															object obj15 = obj14 & 1;
															nint num11;
															if (obj15 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19 (Il2CppMethodInfo)+52]");
																if ((nint)0 == 0)
																{
																	num11 = unchecked((nint)6447293664L);
																	goto IL_07fc;
																}
															}
															((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
															num11 = ((Delegate)tweenCallback).method_ptr;
															goto IL_07fc;
														}
													}
												}
											}
										}
									}
								}
							}
							goto IL_0530;
							IL_07fc:
							object obj16 = 24;
							((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
							tweenConfig.onComplete = tweenCallback;
							obj5 = 24;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							num = number;
							obj3++;
							float num12 = number;
							flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
							obj2 = obj3;
							obj = obj3;
							obj4 = 24;
							num3 = number;
							num4 = num2;
						}
						while (flag10);
					}
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					Background5 background3 = _003C_003E4__this;
					if ((object)_003C_003E4__this != null && (int)(~array2) == 0)
					{
						if ((object)background3._snap != null)
						{
							bool value = ((bool*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj17 = default(object);
							bool flag11 = obj17 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							((SoundManager.SoundConfig)(object)tweenConfig2).Mute = (byte)(int)array2 != 0;
							_ = 1;
							_ = 1133903872;
							float num13 = number;
							if (!(500f > number))
							{
								num13 = 500f;
							}
							float num14 = num13 * 10f;
							float rate = num14 + 600f;
							((SoundManager.SoundConfig)(object)tweenConfig2).Rate = rate;
							MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
							return;
						}
					}
				}
			}
			goto IL_0530;
			IL_0530:
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass65_1
	{
		public SpriteRenderer s;

		internal void _003CSnapEggs_003Eb__1()
		{
			GameObject gameObject = s.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass67_0
	{
		public Weapon cs;

		public VampireSurvivors.Objects.Characters.CharacterController player;

		public Weapon ic;

		public PickupWeapon gRing;

		public PickupWeapon sRing;

		public PickupWeapon lMeta;

		public PickupWeapon rMeta;

		public Background5 _003C_003E4__this;

		internal void _003CPerformSnapYellows_003Eb__0()
		{
			//IL_06c2: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1000f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_GameOver, soundConfig, 0f, 10, time);
			Debug.Log("Despawning yellows");
			List<string> list = new List<string>();
			Weapon weapon = cs;
			if ((object)cs != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"cape");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				GameManager core = GM.Core;
				Weapon weapon2 = core._weaponsFacade.RemoveWeapon(WeaponType.SHROUD, player);
			}
			Weapon weapon3 = ic;
			if ((object)ic != null && ((UnityEngine.Object)weapon3).m_CachedPtr != (IntPtr)0)
			{
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._size >= items2.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"portal");
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				GameManager core2 = GM.Core;
				Weapon weapon4 = core2._weaponsFacade.RemoveWeapon(WeaponType.CORRIDOR, player);
			}
			PickupWeapon pickupWeapon = gRing;
			if ((object)gRing != null && ((UnityEngine.Object)pickupWeapon).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon pickupWeapon2 = gRing;
				((PickupGuarded)pickupWeapon2)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				gRing.Despawn();
				int version3 = list._version + 1;
				list._version = version3;
				string[] items3 = list._items;
				if (list._size >= items3.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"goldring");
				}
				else
				{
					int size3 = list._size + 1;
					list._size = size3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			PickupWeapon pickupWeapon3 = sRing;
			if ((object)sRing != null && ((UnityEngine.Object)pickupWeapon3).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon pickupWeapon4 = sRing;
				((PickupGuarded)pickupWeapon4)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				sRing.Despawn();
				int version4 = list._version + 1;
				list._version = version4;
				string[] items4 = list._items;
				if (list._size >= items4.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"silverring");
				}
				else
				{
					int size4 = list._size + 1;
					list._size = size4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			PickupWeapon pickupWeapon5 = lMeta;
			if ((object)lMeta != null && ((UnityEngine.Object)pickupWeapon5).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon pickupWeapon6 = lMeta;
				((PickupGuarded)pickupWeapon6)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				lMeta.Despawn();
				int version5 = list._version + 1;
				list._version = version5;
				string[] items5 = list._items;
				if (list._size >= items5.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"bsleft");
				}
				else
				{
					int size5 = list._size + 1;
					list._size = size5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			PickupWeapon pickupWeapon7 = rMeta;
			if ((object)rMeta != null && ((UnityEngine.Object)pickupWeapon7).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon pickupWeapon8 = rMeta;
				((PickupGuarded)pickupWeapon8)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				rMeta.Despawn();
				int version6 = list._version + 1;
				list._version = version6;
				string[] items6 = list._items;
				if (list._size >= items6.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"bsright");
				}
				else
				{
					int size6 = list._size + 1;
					list._size = size6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			_003C_003E4__this.RemovePowers(list);
		}
	}

	private sealed class _003C_003Ec__DisplayClass69_0
	{
		public SpriteRenderer s;

		public int index;

		public TweenCallback _003C_003E9__2;

		internal void _003CRemovePowers_003Eb__0()
		{
			s.enabled = true;
		}

		internal unsafe void _003CRemovePowers_003Eb__1()
		{
			//IL_0026: Expected O, but got Ref
			Transform transform = s.transform;
			object obj = default(object);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, (Vector3)(&obj), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num = (float)index + 1100f;
			float delay = num * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = _003C_003E9__2;
			if (_003C_003E9__2 == null)
			{
				tweenCallback = (_003C_003E9__2 = delegate
				{
					s.enabled = false;
					GameObject gameObject = s.gameObject;
					UnityEngine.Object.Destroy(gameObject, 0f);
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v6 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CRemovePowers_003Eb__2()
		{
			s.enabled = false;
			GameObject gameObject = s.gameObject;
			UnityEngine.Object.Destroy(gameObject, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass74_0
	{
		public SpriteRenderer r1;

		public SpriteRenderer r2;

		public SpriteRenderer r3;

		public SpriteRenderer r4;

		public SpriteRenderer r5;

		internal void _003CPowerOfFriendshipGoPlanet_003Eb__0()
		{
			r1.enabled = false;
			r2.enabled = false;
			r3.enabled = false;
			r4.enabled = false;
			r5.enabled = false;
		}
	}

	private sealed class _003C_003Ec__DisplayClass76_0
	{
		public object[] targetsArray;

		internal void _003CEnterPurpleSky_003Eb__2()
		{
			//IL_0043: Expected O, but got I4
			TweenConfig tweenConfig = new TweenConfig();
			tweenConfig.targets = targetsArray;
			tweenConfig.duration = 3000f;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.localY = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		}
	}

	private float _wind = 1f;

	public float _TintHelp;

	private float _minuteValueMillis = 60000f;

	private bool _hasKilledTheFinalBoss;

	private bool _hasTerraceBeenOpened;

	private Pickup _coffin;

	private BgmType _savedBgm;

	private EnemyTheEnder _ender;

	private EnemyDrownerNormal _drowner;

	private EnemyStalkerNormal _stalker;

	private EnemyStalkerNormal _trickster;

	private EnemyMaddenerNormal _maddener;

	private Transform _spritesRootTransform;

	private SpriteRenderer _snap;

	private SpriteAnimation _snapAnimation;

	private TileSprite _skyBlue;

	private TileSprite _skyRed;

	private GameObject _cloudsParent;

	private TileSprite _cloudsBlue;

	private TileSprite _cloudsWhite;

	private TileSprite _cloudsAddBlue;

	private TileSprite _cloudsAddRed;

	private TileSprite _cloudsRed;

	private SpriteRenderer _whiteFader;

	private SpriteRenderer _shootingRay;

	private SpriteRenderer _shootingRing;

	private TileSprite _floorLights;

	private TileSprite _skyLights;

	private SpriteRenderer _purpleOverlay;

	private SpriteRenderer _purpleOverlayAdd;

	private List<SpriteRenderer> _purpleClouds;

	private List<MultiTargetTween> _movingBgTweens;

	private MultiTargetTween _floorLightsTween;

	private MultiTargetTween _skyLightsTween;

	private List<EquipmentInfo> _playerEquipment;

	private bool _useReaperMinuteCheck;

	private Pickup _cosmoPavone;

	private WindowWeapon _003CWindowWeapon_003Ek__BackingField;

	protected virtual bool AlwaysSpawnEnder => false;

	protected virtual bool DropGospel => true;

	protected virtual float EnderShieldTime => 90000f;

	public WindowWeapon WindowWeapon
	{
		get
		{
			return _003CWindowWeapon_003Ek__BackingField;
		}
		set
		{
			_003CWindowWeapon_003Ek__BackingField = value;
		}
	}

	protected unsafe override void OnDestroy()
	{
		//IL_0140: Expected O, but got I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_0309: Expected I, but got O
		//IL_031f: Expected O, but got I
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_044b: Expected I, but got O
		//IL_0540: Expected O, but got I4
		//IL_0557: Expected I, but got I8
		//IL_037f: Expected I, but got I8
		//IL_0477: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_050e->IL04d4: Incompatible stack heights: 1 vs 0
		//IL_03d8->IL0576: Incompatible stack heights: 2 vs 0
		//IL_0198->IL049a: Incompatible stack heights: 1 vs 0
		//IL_020d->IL050e: Incompatible stack heights: 1 vs 0
		//IL_0212->IL0212: Incompatible stack heights: 1 vs 0
		//IL_042c->IL057b: Incompatible stack heights: 2 vs 0
		Camera mainCamera = _mainCamera;
		if ((object)_mainCamera != null && ((UnityEngine.Object)mainCamera).m_CachedPtr != (IntPtr)0)
		{
			Camera mainCamera2 = _mainCamera;
			bool flag = ((UnityEngine.Object)mainCamera2).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			Camera.set_backgroundColor_Injected(((UnityEngine.Object)mainCamera2).m_CachedPtr, ref value);
		}
		GameManager.SfxVolumeFactor = 1f;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				stage._003CStopCheckingMinutes_003Ek__BackingField = false;
				SetDefaultEnemyAndBossData();
				if (_floorLightsTween != null)
				{
					_floorLightsTween.Kill();
				}
				if (_skyLightsTween != null)
				{
					_skyLightsTween.Kill();
				}
				Camera movingBgTweens = (Camera)(object)_movingBgTweens;
				bool flag2 = (nint)_movingBgTweens < 0;
				if (_movingBgTweens != null)
				{
					Camera camera = (Camera)(movingBgTweens.m_NonSerializedVersion - 1);
					if (flag2)
					{
						goto IL_0212;
					}
					while (true)
					{
						List<MultiTargetTween> movingBgTweens2 = _movingBgTweens;
						if (_movingBgTweens == null)
						{
							break;
						}
						bool flag3 = (nint)camera >= movingBgTweens2._size;
						MultiTargetTween[] items = movingBgTweens2._items;
						if (movingBgTweens2._items == null)
						{
							break;
						}
						if (items[(object)camera] != null)
						{
							items[(object)camera].Kill();
						}
						camera = (Camera)(camera - 1);
						if ((nint)items[(object)camera] >= 0)
						{
							continue;
						}
						goto IL_0212;
					}
				}
			}
		}
		goto IL_049a;
		IL_0212:
		Action<EnemyController> value2 = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value2);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<EnemyController> action = default(Action<EnemyController>);
			bool flag4 = action == null;
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			bool flag5 = obj2 == null;
		}
		Action<Pickup> value3 = OnRemoteItemInstantiated;
		Delegate obj3 = Delegate.Remove(ItemInstantiator.OnRemoteItemInstantiated, value3);
		if ((object)obj3 == null)
		{
			ItemInstantiator.OnRemoteItemInstantiated = (Action<Pickup>)obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Pickup> action2 = default(Action<Pickup>);
			bool flag6 = action2 == null;
			ItemInstantiator.OnRemoteItemInstantiated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag7 = obj4 == null;
		}
		Action action3 = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ r9_v13 (Il2CppMethodInfo)+8]");
		((Delegate)action3).method_ptr = (IntPtr)0;
		((Delegate)action3).method = (nint)__ldftn(Background5.EnterTheBossi);
		((Delegate)action3).m_target = this;
		((Delegate)action3).method_code = (IntPtr)action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ r9_v13 (Il2CppMethodInfo)+4C]");
		object obj5 = (nint)0 >> 4;
		object obj6 = obj5 & 1;
		nint num2;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ r9_v13 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_0537;
			}
		}
		num2 = ((Delegate)action3).method_ptr;
		((Delegate)action3).method_code = (IntPtr)((Delegate)action3).m_target;
		goto IL_0537;
		IL_049a:
		throw new NullReferenceException();
		IL_0537:
		object obj7 = 24;
		((Delegate)action3).extra_arg = unchecked((nint)6447293568L);
		if (_signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj9 = default(object);
			object obj8 = obj9 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool throwIfMissing = default(bool);
			_signalBus.UnsubscribeInternal(signalType, (object)null, (object)action3, throwIfMissing);
			base.OnDestroy();
			return;
		}
		goto IL_049a;
	}

	protected override void OnUpdate()
	{
		//IL_012f: Expected O, but got F4
		//IL_01dc: Expected O, but got F4
		//IL_0289: Expected O, but got F4
		//IL_0336: Expected O, but got F4
		//IL_03e9: Expected O, but got F4
		//IL_049c: Expected O, but got F4
		//IL_054f: Expected O, but got F4
		//IL_0602: Expected O, but got F4
		//IL_06af: Expected O, but got F4
		//IL_075c: Expected O, but got F4
		//IL_0809: Expected O, but got F4
		//IL_08bc: Expected O, but got F4
		//IL_096f: Expected O, but got F4
		//IL_0a22: Expected O, but got F4
		//IL_1016: Expected O, but got I4
		//IL_11b4->IL0e39: Incompatible stack heights: 1 vs 0
		//IL_0de6->IL101b: Incompatible stack heights: 1 vs 0
		//IL_0e08->IL101b: Incompatible stack heights: 1 vs 0
		//IL_12c6->IL0fe0: Incompatible stack heights: 1 vs 0
		//IL_0f27->IL101b: Incompatible stack heights: 1 vs 0
		//IL_12e4->IL101b: Incompatible stack heights: 1 vs 0
		//IL_0e39->IL0e39: Incompatible stack heights: 1 vs 0
		//IL_0f05->IL0e39: Incompatible stack heights: 1 vs 0
		//IL_0f60->IL0fe0: Incompatible stack heights: 1 vs 0
		//IL_0f8e->IL101b: Incompatible stack heights: 1 vs 0
		//IL_0fb0->IL101b: Incompatible stack heights: 1 vs 0
		//IL_1008->IL101b: Incompatible stack heights: 1 vs 0
		//IL_0fe0->IL0fe0: Incompatible stack heights: 1 vs 0
		//IL_101b->IL0fe0: Incompatible stack heights: 1 vs 0
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 0.01f;
		float num2 = num * 1000f;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = deltaTime2 * 0.02f;
		float num4 = num3 * 1000f;
		float deltaTime3 = PauseSystem.DeltaTime;
		float num5 = deltaTime3 * 0.015f;
		float num6 = num5 * 1000f;
		float deltaTime4 = PauseSystem.DeltaTime;
		float num7 = deltaTime4 * 0.025f;
		float num8 = num7 * 1000f;
		PhaserScene.Renderer renderer2;
		Vector3 ret;
		object obj15 = default(object);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					TileSprite skyBlue = _skyBlue;
					if ((object)_skyBlue != null)
					{
						float num9 = num2 * _wind;
						object obj = num9 ^ -0f;
						float num10 = (float)obj * 0.01f;
						float scrollOffsetX = (skyBlue._xScrollOffset = num10 + skyBlue._xScrollOffset);
						if ((object)skyBlue._spriteScroller != null)
						{
							skyBlue._spriteScroller.SetScrollOffsetX(scrollOffsetX);
							TileSprite cloudsWhite = _cloudsWhite;
							if ((object)_cloudsWhite != null)
							{
								float num11 = num4 * _wind;
								object obj2 = num11 ^ -0f;
								float num12 = (float)obj2 * 0.01f;
								float scrollOffsetX2 = (cloudsWhite._xScrollOffset = num12 + cloudsWhite._xScrollOffset);
								if ((object)cloudsWhite._spriteScroller != null)
								{
									cloudsWhite._spriteScroller.SetScrollOffsetX(scrollOffsetX2);
									TileSprite cloudsBlue = _cloudsBlue;
									if ((object)_cloudsBlue != null)
									{
										float num13 = num6 * _wind;
										object obj3 = num13 ^ -0f;
										float num14 = (float)obj3 * 0.01f;
										float scrollOffsetX3 = (cloudsBlue._xScrollOffset = num14 + cloudsBlue._xScrollOffset);
										if ((object)cloudsBlue._spriteScroller != null)
										{
											cloudsBlue._spriteScroller.SetScrollOffsetX(scrollOffsetX3);
											TileSprite cloudsAddBlue = _cloudsAddBlue;
											if ((object)_cloudsAddBlue != null)
											{
												float num15 = num8 * _wind;
												object obj4 = num15 ^ -0f;
												float num16 = (float)obj4 * 0.01f;
												float scrollOffsetX4 = (cloudsAddBlue._xScrollOffset = num16 + cloudsAddBlue._xScrollOffset);
												if ((object)cloudsAddBlue._spriteScroller != null)
												{
													cloudsAddBlue._spriteScroller.SetScrollOffsetX(scrollOffsetX4);
													TileSprite skyBlue2 = _skyBlue;
													if ((object)_skyBlue != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
														float num17 = 0f * num2;
														object obj5 = num17 ^ -0f;
														float num18 = (float)obj5 * 0.01f;
														float scrollOffsetY = (skyBlue2._yScrollOffset = num18 + skyBlue2._yScrollOffset);
														if ((object)skyBlue2._spriteScroller != null)
														{
															skyBlue2._spriteScroller.SetScrollOffsetY(scrollOffsetY);
															TileSprite cloudsWhite2 = _cloudsWhite;
															if ((object)_cloudsWhite != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
																float num19 = 0f * num4;
																object obj6 = num19 ^ -0f;
																float num20 = (float)obj6 * 0.01f;
																float scrollOffsetY2 = (cloudsWhite2._yScrollOffset = num20 + cloudsWhite2._yScrollOffset);
																if ((object)cloudsWhite2._spriteScroller != null)
																{
																	cloudsWhite2._spriteScroller.SetScrollOffsetY(scrollOffsetY2);
																	TileSprite cloudsBlue2 = _cloudsBlue;
																	if ((object)_cloudsBlue != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
																		float num21 = 0f * num6;
																		object obj7 = num21 ^ -0f;
																		float num22 = (float)obj7 * 0.01f;
																		float scrollOffsetY3 = (cloudsBlue2._yScrollOffset = num22 + cloudsBlue2._yScrollOffset);
																		if ((object)cloudsBlue2._spriteScroller != null)
																		{
																			cloudsBlue2._spriteScroller.SetScrollOffsetY(scrollOffsetY3);
																			TileSprite cloudsAddBlue2 = _cloudsAddBlue;
																			if ((object)_cloudsAddBlue != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
																				float num23 = 0f * num8;
																				object obj8 = num23 ^ -0f;
																				float num24 = (float)obj8 * 0.01f;
																				float scrollOffsetY4 = (cloudsAddBlue2._yScrollOffset = num24 + cloudsAddBlue2._yScrollOffset);
																				if ((object)cloudsAddBlue2._spriteScroller != null)
																				{
																					cloudsAddBlue2._spriteScroller.SetScrollOffsetY(scrollOffsetY4);
																					TileSprite skyRed = _skyRed;
																					if ((object)_skyRed != null)
																					{
																						float num25 = num2 * _wind;
																						object obj9 = num25 ^ -0f;
																						float num26 = (float)obj9 * 0.01f;
																						float scrollOffsetX5 = (skyRed._xScrollOffset = num26 + skyRed._xScrollOffset);
																						if ((object)skyRed._spriteScroller != null)
																						{
																							skyRed._spriteScroller.SetScrollOffsetX(scrollOffsetX5);
																							TileSprite cloudsRed = _cloudsRed;
																							if ((object)_cloudsRed != null)
																							{
																								float num27 = num6 * _wind;
																								object obj10 = num27 ^ -0f;
																								float num28 = (float)obj10 * 0.01f;
																								float scrollOffsetX6 = (cloudsRed._xScrollOffset = num28 + cloudsRed._xScrollOffset);
																								if ((object)cloudsRed._spriteScroller != null)
																								{
																									cloudsRed._spriteScroller.SetScrollOffsetX(scrollOffsetX6);
																									TileSprite cloudsAddRed = _cloudsAddRed;
																									if ((object)_cloudsAddRed != null)
																									{
																										float num29 = num8 * _wind;
																										object obj11 = num29 ^ -0f;
																										float num30 = (float)obj11 * 0.01f;
																										float scrollOffsetX7 = (cloudsAddRed._xScrollOffset = num30 + cloudsAddRed._xScrollOffset);
																										if ((object)cloudsAddRed._spriteScroller != null)
																										{
																											cloudsAddRed._spriteScroller.SetScrollOffsetX(scrollOffsetX7);
																											TileSprite skyRed2 = _skyRed;
																											if ((object)_skyRed != null)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
																												float num31 = 0f * num2;
																												object obj12 = num31 ^ -0f;
																												float num32 = (float)obj12 * 0.01f;
																												float scrollOffsetY5 = (skyRed2._yScrollOffset = num32 + skyRed2._yScrollOffset);
																												if ((object)skyRed2._spriteScroller != null)
																												{
																													skyRed2._spriteScroller.SetScrollOffsetY(scrollOffsetY5);
																													TileSprite cloudsRed2 = _cloudsRed;
																													if ((object)_cloudsRed != null)
																													{
																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
																														float num33 = 0f * num4;
																														object obj13 = num33 ^ -0f;
																														float num34 = (float)obj13 * 0.01f;
																														float scrollOffsetY6 = (cloudsRed2._yScrollOffset = num34 + cloudsRed2._yScrollOffset);
																														if ((object)cloudsRed2._spriteScroller != null)
																														{
																															cloudsRed2._spriteScroller.SetScrollOffsetY(scrollOffsetY6);
																															TileSprite cloudsAddRed2 = _cloudsAddRed;
																															if ((object)_cloudsAddRed != null)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v20 (PhaserScene+Renderer)+40]");
																																float num35 = 0f * num6;
																																object obj14 = num35 ^ -0f;
																																float num36 = (float)obj14 * 0.01f;
																																float scrollOffsetY7 = (cloudsAddRed2._yScrollOffset = num36 + cloudsAddRed2._yScrollOffset);
																																if ((object)cloudsAddRed2._spriteScroller != null)
																																{
																																	cloudsAddRed2._spriteScroller.SetScrollOffsetY(scrollOffsetY7);
																																	if ((object)GM.Core != null)
																																	{
																																		PhaserScene s_scene2 = ArcadePhysics.s_scene;
																																		if (ArcadePhysics.s_scene != null)
																																		{
																																			renderer2 = s_scene2._renderer;
																																			if (s_scene2._renderer != null)
																																			{
																																				TileSprite floorLights = _floorLights;
																																				if ((object)_floorLights != null)
																																				{
																																					float num37 = (float)renderer2.screenCenter + 1.28f;
																																					float scrollOffsetX8 = (floorLights._xScrollOffset = num37 * 0.1f);
																																					if ((object)floorLights._spriteScroller != null)
																																					{
																																						floorLights._spriteScroller.SetScrollOffsetX(scrollOffsetX8);
																																						TileSprite floorLights2 = _floorLights;
																																						if ((object)_floorLights != null)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v53 (PhaserScene+Renderer)+38]");
																																							float num38 = 0f + 0.64f;
																																							float scrollOffsetY8 = (floorLights2._yScrollOffset = num38 * 0.1f);
																																							if ((object)floorLights2._spriteScroller != null)
																																							{
																																								floorLights2._spriteScroller.SetScrollOffsetY(scrollOffsetY8);
																																								TileSprite skyLights = _skyLights;
																																								if ((object)_skyLights != null)
																																								{
																																									float num39 = (float)renderer2.screenCenter + 1.28f;
																																									float scrollOffsetX9 = (skyLights._xScrollOffset = num39 * 0.2f);
																																									if ((object)skyLights._spriteScroller != null)
																																									{
																																										skyLights._spriteScroller.SetScrollOffsetX(scrollOffsetX9);
																																										TileSprite skyLights2 = _skyLights;
																																										if ((object)_skyLights != null)
																																										{
																																											skyLights2._yScrollOffset = 0.525f;
																																											if ((object)skyLights2._spriteScroller != null)
																																											{
																																												float yScrollOffset = skyLights2._yScrollOffset;
																																												skyLights2._spriteScroller.SetScrollOffsetY(skyLights2._yScrollOffset);
																																												Transform coffin = (Transform)(object)_coffin;
																																												if ((object)_coffin == null || ((UnityEngine.Object)coffin).m_CachedPtr == (IntPtr)0 || _hasTerraceBeenOpened)
																																												{
																																													goto IL_0e39;
																																												}
																																												if ((object)_coffin != null)
																																												{
																																													Transform transform = _coffin.transform;
																																													if ((object)transform != null)
																																													{
																																														bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																																														Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
																																														float num40 = (float)ret * 100f;
																																														float num41 = (float)obj15 * 100f;
																																														yScrollOffset = (float)renderer2.screenCenter * 100f;
																																														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v53 (PhaserScene+Renderer)+38]");
																																														deltaTime4 = 0f * 100f;
																																														float num42 = num40 - yScrollOffset;
																																														float num43 = num41 - deltaTime4;
																																														float num44 = num42 * num42;
																																														float num45 = num43 * num43;
																																														float num46 = num44 + num45;
																																														if (60000f > num46)
																																														{
																																															_coffin = null;
																																															GameManager core = GM.Core;
																																															if ((object)GM.Core == null || core._multiplayer == null)
																																															{
																																																goto IL_101b;
																																															}
																																															if (!core._multiplayer.IsOnlineMultiplayer)
																																															{
																																																OpenTerrace();
																																															}
																																															else
																																															{
																																																if ((object)OnlineStageManager._instance == null)
																																																{
																																																	goto IL_101b;
																																																}
																																																OnlineStageManager._instance.SendOpenTerrace();
																																															}
																																														}
																																														goto IL_0e39;
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
		goto IL_101b;
		IL_0e39:
		Transform cosmoPavone = (Transform)(object)_cosmoPavone;
		if ((object)_cosmoPavone == null || ((UnityEngine.Object)cosmoPavone).m_CachedPtr == (IntPtr)0 || _hasTerraceBeenOpened)
		{
			return;
		}
		if ((object)_cosmoPavone != null)
		{
			Transform transform2 = _cosmoPavone.transform;
			if ((object)transform2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ rax_v73 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ rax_v73 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				float num47 = (float)ret * 100f;
				float num48 = (float)obj15 * 100f;
				float num49 = (float)renderer2.screenCenter * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rax_v53 (PhaserScene+Renderer)+38]");
				float num50 = 0f * 100f;
				float num51 = num47 - num49;
				float num52 = num48 - num50;
				float num53 = num51 * num51;
				float num54 = num52 * num52;
				float num55 = num53 + num54;
				if (!(60000f > num55))
				{
					return;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = _003C_003Ec._003C_003E9__48_0;
					if (_003C_003Ec._003C_003E9__48_0 == null)
					{
						predicate = (_003C_003Ec._003C_003E9__48_0 = delegate(VampireSurvivors.Objects.Characters.CharacterController p)
						{
							//IL_00c9: Expected I4, but got O
							if ((object)p != null)
							{
								CharacterWeaponsManager weaponsManager = p._weaponsManager;
								if ((object)p._weaponsManager != null)
								{
									Func<Equipment, bool> predicate2 = _003C_003Ec._003C_003E9__48_1;
									if (_003C_003Ec._003C_003E9__48_1 == null)
									{
										predicate2 = (_003C_003Ec._003C_003E9__48_1 = delegate(Equipment x)
										{
											//IL_0052: Expected I4, but got O
											//IL_0030: Expected O, but got I4
											if ((object)x == null)
											{
												NullReferenceException ex2 = new NullReferenceException();
												return (byte)(int)ex2 != 0;
											}
											object obj16 = x._equipmentType - 27;
											return obj16 == null;
										});
									}
									bool flag4 = Enumerable.Any(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, predicate2);
									if (flag4)
									{
										CharacterWeaponsManager weaponsManager2 = p._weaponsManager;
										if ((object)p._weaponsManager == null)
										{
											goto IL_00bb;
										}
										Func<Equipment, bool> predicate3 = _003C_003Ec._003C_003E9__48_2;
										if (_003C_003Ec._003C_003E9__48_2 == null)
										{
											predicate3 = (_003C_003Ec._003C_003E9__48_2 = delegate(Equipment x)
											{
												//IL_0052: Expected I4, but got O
												//IL_0030: Expected O, but got I4
												if ((object)x == null)
												{
													NullReferenceException ex2 = new NullReferenceException();
													return (byte)(int)ex2 != 0;
												}
												object obj16 = x._equipmentType - 28;
												return obj16 == null;
											});
										}
										flag4 = Enumerable.Any(((EquipmentManager)weaponsManager2)._003CActiveEquipment_003Ek__BackingField, predicate3);
									}
									return flag4;
								}
							}
							goto IL_00bb;
							IL_00bb:
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						});
					}
					if (!Enumerable.Any(core2._characters, predicate))
					{
						return;
					}
					_cosmoPavone = null;
					GameManager core3 = GM.Core;
					if ((object)GM.Core != null && core3._multiplayer != null)
					{
						if (!core3._multiplayer.IsOnlineMultiplayer)
						{
							OpenTerrace();
							return;
						}
						bool flag3 = Enumerable.Any((IEnumerable<VampireSurvivors.Objects.Characters.CharacterController>)core3._multiplayer, null);
						if (flag3)
						{
							((OnlineStageManager)flag3).SendOpenTerrace();
							return;
						}
					}
				}
			}
		}
		goto IL_101b;
		IL_101b:
		throw new NullReferenceException();
	}

	public override void Create()
	{
		//IL_0085: Expected O, but got I4
		//IL_0085: Expected O, but got I
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_094a: Expected O, but got I
		//IL_01a9: Expected I4, but got O
		//IL_01bb: Expected I, but got O
		//IL_01f6: Expected I, but got O
		//IL_0206: Expected O, but got I
		//IL_0242: Expected O, but got I
		//IL_0330: Expected I, but got O
		//IL_03a6: Expected I4, but got I8
		//IL_03b4: Expected O, but got I4
		//IL_042b: Expected I, but got O
		//IL_0481: Expected O, but got I4
		//IL_04af: Expected I4, but got I8
		//IL_051f: Expected O, but got I
		//IL_052f: Expected O, but got I
		//IL_0589: Expected O, but got I
		//IL_0a16: Expected O, but got I
		//IL_0a26: Expected O, but got I
		//IL_05f3: Expected O, but got I
		//IL_0a5a: Expected O, but got I
		//IL_0a6a: Expected O, but got I
		//IL_065d: Expected O, but got I
		//IL_0792: Expected I4, but got O
		base.Create();
		Action action = EnterTheBossi;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rbx_v11 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.EnterTheBossi>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.EnterTheBossi>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v31 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> action3 = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, action3);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = !config._003CHasKilledTheFinalBoss_003Ek__BackingField;
		base._003CHasMovingBg_003Ek__BackingField = flag;
		if (AlwaysSpawnEnder)
		{
			base._003CHasMovingBg_003Ek__BackingField = true;
		}
		_wind = 1f;
		base._003CAlias_003Ek__BackingField = false;
		_useReaperMinuteCheck = true;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		_hasKilledTheFinalBoss = config2._003CHasKilledTheFinalBoss_003Ek__BackingField;
		if (AlwaysSpawnEnder)
		{
			_hasKilledTheFinalBoss = false;
		}
		GameManager core3 = GM.Core;
		GameSessionData gameSessionData = core3._gameSessionData;
		Weapon weapon = core3._weaponsFacade.AddHiddenWeapon(WeaponType.WINDOW, gameSessionData._activeCharacter, removeFromStore: true, (byte)(int)action3 != 0);
		nint num2 = (nint)typeof(WindowWeapon);
		Weapon weapon2;
		nint num3;
		if ((object)weapon == null)
		{
			num3 = 1;
			weapon2 = null;
			goto IL_0277;
		}
		num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.WindowWeapon>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Weapons.WindowWeapon>)+130]");
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ r9_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rax_v176+FFFFFFF8+v1086 @ rax_v175*8]");
			bool flag2 = 0 != (nint)typeof(WindowWeapon);
			weapon2 = weapon;
			if (!flag2)
			{
				goto IL_0277;
			}
		}
		throw new InvalidCastException();
		IL_0277:
		_003CWindowWeapon_003Ek__BackingField = (WindowWeapon)weapon2;
		GameManager core4 = GM.Core;
		PlayerOptionsData config3 = core4._playerOptions.Config;
		float num5 = ((!config3._003CSelectedHurry_003Ek__BackingField) ? 1f : 0.5f);
		float minuteValueMillis = num5 * 60000f;
		_minuteValueMillis = minuteValueMillis;
		GenerateSprites();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		TileSprite floorLights = _floorLights;
		if ((object)floorLights._spriteRenderer != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 30000f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween floorLightsTween = Tweens.Add(tweenConfig);
		_floorLightsTween = floorLightsTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		TileSprite skyLights = _skyLights;
		if ((object)skyLights._spriteRenderer != null)
		{
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 60000f;
		tweenConfig2.yoyo = true;
		tweenConfig2.repeat = -1;
		MultiTargetTween skyLightsTween = Tweens.Add(tweenConfig2);
		_skyLightsTween = skyLightsTween;
		if (!_hasKilledTheFinalBoss)
		{
			List<BgmType> list = new List<BgmType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v77+18]");
			if (num8 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)15);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				object obj10 = (nint)0 + (nint)1;
				_ = 15;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v79+18]");
			if (num9 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)16);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				object obj13 = (nint)0 + (nint)1;
				_ = 16;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+10]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			object obj15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdx_v81+18]");
			if (num10 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)17);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v134 (System.Collections.Generic.List`1<VampireSurvivors.Data.BgmType>)+18]");
				object obj16 = (nint)0 + (nint)1;
				_ = 17;
			}
			SoundManager.PreloadBgmAsync(list);
		}
		Pickup pickupItemFromWorld = PickupManager.GetPickupItemFromWorld(ItemType.COFFIN);
		if ((object)pickupItemFromWorld != null && ((UnityEngine.Object)pickupItemFromWorld).m_CachedPtr != (IntPtr)0)
		{
			_coffin = pickupItemFromWorld;
		}
		SetupCosmoTrigger();
		if (!UpdateEnemyAndBossData())
		{
			SnapYellows();
			if (GM.Core.IsStageHost)
			{
				Action onComplete = delegate
				{
					//IL_0165->IL00e5: Incompatible stack heights: 1 vs 0
					//IL_00ac->IL00e5: Incompatible stack heights: 1 vs 0
					GameManager core5 = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData2 = core5._gameSessionData;
						if (core5._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
						{
							Transform transform = gameSessionData2._activeCharacter.transform;
							if ((object)transform != null)
							{
								bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
								GameManager core6 = GM.Core;
								if ((object)GM.Core != null && (object)core6._stage != null)
								{
									Vector2 spawnPos = default(Vector2);
									bool forceSpawn = default(bool);
									GameObject enemy = core6._stage.SpawnEnemy(EnemyType.BOSS_MADDENER_NORMAL, spawnPos, asRemote: false, forceSpawn);
									OnMaddenerSpawned(enemy);
									return;
								}
							}
						}
					}
					throw new NullReferenceException();
				};
				float num11 = _minuteValueMillis * 0.16f;
				float duration = num11 * 0.001f;
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)action3 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				return;
			}
			Action<EnemyController> b = OnRemoteEnemySpawned;
			Delegate obj17 = Delegate.Combine(EnemyInstantiator.OnRemoteEnemySpawned, b);
			if ((object)obj17 == null)
			{
				EnemyInstantiator.OnRemoteEnemySpawned = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				Action<EnemyController> action4 = default(Action<EnemyController>);
				if (action4 == null)
				{
					throw new InvalidCastException();
				}
				EnemyInstantiator.OnRemoteEnemySpawned = action4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj18 = default(object);
				if (obj18 == null)
				{
					throw new InvalidCastException();
				}
			}
			Action<Pickup> b2 = OnRemoteItemInstantiated;
			Delegate obj19 = Delegate.Combine(ItemInstantiator.OnRemoteItemInstantiated, b2);
			if ((object)obj19 == null)
			{
				ItemInstantiator.OnRemoteItemInstantiated = null;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<Pickup> action5 = default(Action<Pickup>);
			if (action5 == null)
			{
				throw new InvalidCastException();
			}
			ItemInstantiator.OnRemoteItemInstantiated = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj20 = default(object);
			if (obj20 == null)
			{
				throw new InvalidCastException();
			}
		}
		else
		{
			_useReaperMinuteCheck = false;
		}
	}

	private void OnRemoteItemInstantiated(Pickup item)
	{
		if (item._003CPickupType_003Ek__BackingField == ItemType.COFFIN)
		{
			_coffin = item;
		}
		else if (item._003CPickupType_003Ek__BackingField == ItemType.COSMO_PAVONE)
		{
			_cosmoPavone = item;
		}
	}

	private void OnMaddenerSpawned(GameObject enemy)
	{
		//IL_0058: Expected O, but got I4
		EnemyMaddenerNormal component = enemy.GetComponent<EnemyMaddenerNormal>();
		_maddener = component;
		EnemyMaddenerNormal maddener = _maddener;
		((EnemyController)maddener)._003CIsBoss_003Ek__BackingField = true;
		ArcadeSprite arcadeSprite = _maddener.setScale(0f, (float?)(object)0);
		Action onComplete = FadeToMad;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		if (enemy._enemyType > EnemyType.BOSS_DROWNER_NORMAL)
		{
			if (enemy._enemyType == EnemyType.BOSS_STALKER_NORMAL)
			{
				GameObject enemyStalker = enemy.gameObject;
				OnStalkerSpawned(enemyStalker);
			}
			else if (enemy._enemyType == EnemyType.BOSS_TRICKSTER_NORMAL)
			{
				GameObject enemyTrickster = enemy.gameObject;
				OnTricksterSpawned(enemyTrickster);
			}
			else if (enemy._enemyType == EnemyType.BOSS_ENDER)
			{
				GameObject enemyEnder = enemy.gameObject;
				OnEnderSpawned(enemyEnder);
			}
		}
		else if (enemy._enemyType == EnemyType.BOSS_MADDENER_NORMAL)
		{
			GameObject enemy2 = enemy.gameObject;
			OnMaddenerSpawned(enemy2);
		}
		else if (enemy._enemyType == EnemyType.BOSS_DROWNER_NORMAL)
		{
			GameObject enemy3 = enemy.gameObject;
			OnDrownerSpawned(enemy3);
		}
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager.SfxVolumeFactor = 1f;
		GameManager core = GM.Core;
		Stage stage = core._stage;
		stage._003CStopCheckingMinutes_003Ek__BackingField = false;
		SetDefaultEnemyAndBossData();
		GM.Core.GiveBackAllEquipmentToPlayers(_playerEquipment);
	}

	public unsafe override void DisableMovingBackground()
	{
		//IL_0196->IL00b9: Incompatible stack heights: 1 vs 0
		//IL_01f0->IL00b9: Incompatible stack heights: 2 vs 0
		//IL_0250->IL00b9: Incompatible stack heights: 3 vs 0
		//IL_00aa->IL00b9: Incompatible stack heights: 4 vs 0
		if (_movingBgTweens != null)
		{
			List<MultiTargetTween>.Enumerator enumerator = default(List<MultiTargetTween>.Enumerator);
			while (enumerator.MoveNext())
			{
			}
			GameObject floorLights = (GameObject)(object)_floorLights;
			bool flag = (object)_floorLights == null;
			nint num = (nint)(&enumerator);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)floorLights).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)floorLights).m_CachedPtr);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject != null)
				{
					bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
					object skyLights = _skyLights;
					if ((object)_skyLights != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v14 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v14 (System.Object)+10]");
						IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
						if ((object)gameObject2 != null)
						{
							bool flag5 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
							GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, false);
							if (_floorLightsTween != null)
							{
								_floorLightsTween.Pause();
							}
							if (_skyLightsTween != null)
							{
								_skyLightsTween.Pause();
							}
							Background5 cloudsParent = (Background5)(object)_cloudsParent;
							if ((object)_cloudsParent != null)
							{
								bool flag6 = ((UnityEngine.Object)cloudsParent).m_CachedPtr == (IntPtr)0;
								GameObject.SetActive_Injected(((UnityEngine.Object)cloudsParent).m_CachedPtr, false);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void EnableMovingBackground()
	{
		//IL_0196->IL00b9: Incompatible stack heights: 1 vs 0
		//IL_01f0->IL00b9: Incompatible stack heights: 2 vs 0
		//IL_0250->IL00b9: Incompatible stack heights: 3 vs 0
		//IL_00aa->IL00b9: Incompatible stack heights: 4 vs 0
		if (_movingBgTweens != null)
		{
			List<MultiTargetTween>.Enumerator enumerator = default(List<MultiTargetTween>.Enumerator);
			while (enumerator.MoveNext())
			{
			}
			GameObject floorLights = (GameObject)(object)_floorLights;
			bool flag = (object)_floorLights == null;
			nint num = (nint)(&enumerator);
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)floorLights).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)floorLights).m_CachedPtr);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject != null)
				{
					bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
					object skyLights = _skyLights;
					if ((object)_skyLights != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v14 (System.Object)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdi_v14 (System.Object)+10]");
						IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
						GameObject gameObject2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
						if ((object)gameObject2 != null)
						{
							bool flag5 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
							GameObject.SetActive_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr, true);
							if (_floorLightsTween != null)
							{
								_floorLightsTween.Play();
							}
							if (_skyLightsTween != null)
							{
								_skyLightsTween.Play();
							}
							Background5 cloudsParent = (Background5)(object)_cloudsParent;
							if ((object)_cloudsParent != null)
							{
								bool flag6 = ((UnityEngine.Object)cloudsParent).m_CachedPtr == (IntPtr)0;
								GameObject.SetActive_Injected(((UnityEngine.Object)cloudsParent).m_CachedPtr, true);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateSprites()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1679: Expected O, but got I4
		//IL_1423: Expected O, but got I4
		//IL_148a: Expected O, but got Ref
		//IL_14de: Expected O, but got Ref
		//IL_0316: Expected O, but got I4
		//IL_0316: Expected I4, but got O
		//IL_0345: Expected F4, but got I
		//IL_0345: Expected F4, but got I
		//IL_03fb: Expected F4, but got I
		//IL_03fb: Expected F4, but got I
		//IL_0599: Expected F4, but got I
		//IL_0599: Expected F4, but got I
		//IL_065b: Expected F4, but got I
		//IL_065b: Expected F4, but got I
		//IL_071d: Expected F4, but got I
		//IL_071d: Expected F4, but got I
		//IL_09d6: Expected F4, but got I
		//IL_09d6: Expected F4, but got I
		//IL_0ae9: Expected F4, but got I
		//IL_0ae9: Expected F4, but got I
		//IL_0c5a: Expected F4, but got I
		//IL_0c5a: Expected F4, but got I
		//IL_0da5: Expected O, but got I4
		//IL_0eb8: Expected F4, but got I
		//IL_0eb8: Expected F4, but got I
		//IL_121f: Expected F4, but got I
		//IL_1267: Expected O, but got I
		//IL_0069->IL140e: Incompatible stack heights: 1 vs 0
		//IL_018e->IL140e: Incompatible stack heights: 4 vs 0
		//IL_01b8->IL140e: Incompatible stack heights: 4 vs 0
		//IL_020e->IL140e: Incompatible stack heights: 4 vs 0
		//IL_1578->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0254->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0280->IL140e: Incompatible stack heights: 5 vs 0
		//IL_02e8->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0361->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0417->IL140e: Incompatible stack heights: 5 vs 0
		//IL_049c->IL140e: Incompatible stack heights: 5 vs 0
		//IL_04c8->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0525->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0551->IL140e: Incompatible stack heights: 5 vs 0
		//IL_05b5->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0677->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0739->IL140e: Incompatible stack heights: 5 vs 0
		//IL_07e0->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0802->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0831->IL140e: Incompatible stack heights: 5 vs 0
		//IL_087c->IL140e: Incompatible stack heights: 5 vs 0
		//IL_09f2->IL140e: Incompatible stack heights: 5 vs 0
		//IL_08c1->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0918->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0a83->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0aaf->IL140e: Incompatible stack heights: 5 vs 0
		//IL_096f->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0b0a->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0b8a->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0bb9->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0bf4->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0c20->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0ce7->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0d29->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0d53->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0def->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0e6f->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0ed4->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0f55->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0f85->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0fb4->IL140e: Incompatible stack heights: 5 vs 0
		//IL_0ff9->IL140e: Incompatible stack heights: 5 vs 0
		//IL_1029->IL140e: Incompatible stack heights: 5 vs 0
		//IL_1069->IL140e: Incompatible stack heights: 5 vs 0
		//IL_109d->IL140e: Incompatible stack heights: 5 vs 0
		//IL_10db->IL140e: Incompatible stack heights: 5 vs 0
		//IL_10fd->IL140e: Incompatible stack heights: 5 vs 0
		//IL_112c->IL140e: Incompatible stack heights: 5 vs 0
		//IL_1177->IL140e: Incompatible stack heights: 5 vs 0
		//IL_124d->IL140e: Incompatible stack heights: 5 vs 0
		//IL_1199->IL140e: Incompatible stack heights: 5 vs 0
		//IL_12e9->IL140e: Incompatible stack heights: 5 vs 0
		//IL_1342->IL140e: Incompatible stack heights: 5 vs 0
		//IL_1372->IL140e: Incompatible stack heights: 5 vs 0
		//IL_13b2->IL140e: Incompatible stack heights: 5 vs 0
		//IL_13f6->IL140e: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		object obj3 = Screen.width;
		float tileWidth = (float)obj3 * 0.01f;
		object obj4 = Screen.height;
		float tileHeight = (float)obj4 * 0.01f;
		Vector2 vector = default(Vector2);
		string text = default(string);
		int num = default(int);
		Transform transform3;
		if ((object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj5);
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, "Background5SpritesRoot");
				if ((object)gameObject != null)
				{
					Transform spritesRootTransform = gameObject.transform;
					_spritesRootTransform = spritesRootTransform;
					object spritesRootTransform2 = _spritesRootTransform;
					bool flag2 = (object)_spritesRootTransform == null;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1658 @ rbx_v7 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1658 @ rbx_v7 (System.Object)+10]");
					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj6);
					bool flag4 = (object)_spritesRootTransform == null;
					_spritesRootTransform.SetParent(transform, worldPositionStays: true);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+3C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+38]");
					_ = 0;
					_ = _camBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+3C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+38]");
					_ = 0;
					_ = _camBounds;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+3C]");
					_ = 0;
					GameObject gameObject2 = base.gameObject;
					SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject2, vector, vector, "backgroundX", text);
					if ((object)spriteRenderer != null)
					{
						Transform transform2 = spriteRenderer.transform;
						if ((object)transform2 != null)
						{
							transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
							spriteRenderer.flipX = true;
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(spriteRenderer, 1.5f);
							if ((object)spriteRenderer2 != null)
							{
								bool flag5 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, 10000);
								SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0f);
								if ((object)spriteRenderer3 != null)
								{
									((UnityEngine.Object)spriteRenderer3).SetName("Snap");
									_snap = spriteRenderer3;
									if ((object)_snap != null)
									{
										GameObject gameObject3 = _snap.gameObject;
										if ((object)gameObject3 != null)
										{
											SpriteAnimation snapAnimation = gameObject3.AddComponent<SpriteAnimation>();
											_snapAnimation = snapAnimation;
											bool flag6 = default(bool);
											List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("snap", 16, 42, vector, text, num, flag6);
											if ((object)_snapAnimation != null)
											{
												bool autoSetAnimation = default(bool);
												_snapAnimation.AddAnimation("snap", animationFrames, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag6, autoSetAnimation);
												GameObject go = base.gameObject;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
												TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, num2, 0f, "backgroundX", text);
												if (tileSpriteBuilder != null)
												{
													tileSpriteBuilder._depth = -32768f;
													tileSpriteBuilder._depthMul = 1f;
													tileSpriteBuilder._parent = _spritesRootTransform;
													tileSpriteBuilder._tileWidth = tileWidth;
													tileSpriteBuilder._tileHeight = tileHeight;
													tileSpriteBuilder._name = "SkyBlue";
													TileSprite skyBlue = tileSpriteBuilder.Build();
													_skyBlue = skyBlue;
													GameObject go2 = base.gameObject;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
													nint num3 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
													TileSpriteBuilder tileSpriteBuilder2 = RenderingExtensions.AddTileSprite(go2, num3, 0f, "backgroundX", text);
													if (tileSpriteBuilder2 != null)
													{
														tileSpriteBuilder2._depth = -32768f;
														tileSpriteBuilder2._depthMul = 1f;
														tileSpriteBuilder2._parent = _spritesRootTransform;
														tileSpriteBuilder2._tileWidth = tileWidth;
														tileSpriteBuilder2._tileHeight = tileHeight;
														tileSpriteBuilder2._name = "SkyRed";
														TileSprite skyRed = tileSpriteBuilder2.Build();
														_skyRed = skyRed;
														if ((object)_skyRed != null)
														{
															GameObject gameObject4 = _skyRed.gameObject;
															if ((object)gameObject4 != null)
															{
																gameObject4.SetActive(value: false);
																GameObject gameObject5 = new GameObject();
																GameObject.Internal_CreateGameObject(gameObject5, "CloudsParent");
																_cloudsParent = gameObject5;
																if ((object)_cloudsParent != null)
																{
																	transform3 = _cloudsParent.transform;
																	if ((object)transform3 != null)
																	{
																		transform3.SetParent(_spritesRootTransform, worldPositionStays: true);
																		GameObject go3 = base.gameObject;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
																		nint num4 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
																		TileSpriteBuilder tileSpriteBuilder3 = RenderingExtensions.AddTileSprite(go3, num4, 0f, "backgroundX", text);
																		if (tileSpriteBuilder3 != null)
																		{
																			tileSpriteBuilder3._depth = -32767f;
																			tileSpriteBuilder3._depthMul = 1f;
																			tileSpriteBuilder3._alpha = 0.75f;
																			tileSpriteBuilder3._tileWidth = tileWidth;
																			tileSpriteBuilder3._tileHeight = tileHeight;
																			tileSpriteBuilder3._parent = transform3;
																			tileSpriteBuilder3._name = "CloudsWhite";
																			TileSprite cloudsWhite = tileSpriteBuilder3.Build();
																			_cloudsWhite = cloudsWhite;
																			GameObject go4 = base.gameObject;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
																			nint num5 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
																			TileSpriteBuilder tileSpriteBuilder4 = RenderingExtensions.AddTileSprite(go4, num5, 0f, "backgroundX", text);
																			if (tileSpriteBuilder4 != null)
																			{
																				tileSpriteBuilder4._depth = -32766f;
																				tileSpriteBuilder4._depthMul = 1f;
																				tileSpriteBuilder4._alpha = 0.5f;
																				tileSpriteBuilder4._tileWidth = tileWidth;
																				tileSpriteBuilder4._tileHeight = tileHeight;
																				tileSpriteBuilder4._parent = transform3;
																				tileSpriteBuilder4._name = "CloudsBlue";
																				TileSprite cloudsBlue = tileSpriteBuilder4.Build();
																				_cloudsBlue = cloudsBlue;
																				GameObject go5 = base.gameObject;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
																				nint num6 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
																				TileSpriteBuilder tileSpriteBuilder5 = RenderingExtensions.AddTileSprite(go5, num6, 0f, "backgroundX", text);
																				if (tileSpriteBuilder5 != null)
																				{
																					tileSpriteBuilder5._depth = -32765f;
																					tileSpriteBuilder5._depthMul = 1f;
																					tileSpriteBuilder5._alpha = 0.5f;
																					tileSpriteBuilder5._blendMode = BlendMode.Add;
																					tileSpriteBuilder5._tileWidth = tileWidth;
																					tileSpriteBuilder5._tileHeight = tileHeight;
																					tileSpriteBuilder5._parent = transform3;
																					tileSpriteBuilder5._name = "CloudsAddBlue";
																					TileSprite cloudsAddBlue = tileSpriteBuilder5.Build();
																					_cloudsAddBlue = cloudsAddBlue;
																					GameManager core = GM.Core;
																					if ((object)GM.Core != null && core._playerOptions != null)
																					{
																						PlayerOptionsData config = core._playerOptions.Config;
																						if (config != null)
																						{
																							if (!config._003CSelectedInverse_003Ek__BackingField)
																							{
																								goto IL_162c;
																							}
																							TileSprite skyBlue2 = _skyBlue;
																							if ((object)_skyBlue != null)
																							{
																								SpriteRenderer spriteRenderer4 = RenderingExtensions.SetTint(skyBlue2._spriteRenderer, 136u);
																								TileSprite cloudsWhite2 = _cloudsWhite;
																								if ((object)_cloudsWhite != null)
																								{
																									SpriteRenderer spriteRenderer5 = RenderingExtensions.SetTint(cloudsWhite2._spriteRenderer, 8947848u);
																									SpriteRenderer spriteRenderer6 = RenderingExtensions.SetAlpha(spriteRenderer5, 0.5f);
																									TileSprite cloudsBlue2 = _cloudsBlue;
																									if ((object)_cloudsBlue != null)
																									{
																										SpriteRenderer spriteRenderer7 = RenderingExtensions.SetTint(cloudsBlue2._spriteRenderer, 8947848u);
																										SpriteRenderer spriteRenderer8 = RenderingExtensions.SetAlpha(spriteRenderer7, 0.25f);
																										TileSprite cloudsAddBlue2 = _cloudsAddBlue;
																										if ((object)_cloudsAddBlue != null)
																										{
																											SpriteRenderer spriteRenderer9 = RenderingExtensions.SetTint(cloudsAddBlue2._spriteRenderer, 8947848u);
																											SpriteRenderer spriteRenderer10 = RenderingExtensions.SetAlpha(spriteRenderer9, 0.25f);
																											goto IL_162c;
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
		goto IL_140e;
		IL_140e:
		throw new NullReferenceException();
		IL_162c:
		GameObject go6 = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
		TileSpriteBuilder tileSpriteBuilder6 = RenderingExtensions.AddTileSprite(go6, num7, 0f, "backgroundX", text);
		if (tileSpriteBuilder6 != null)
		{
			tileSpriteBuilder6._depth = -32766f;
			tileSpriteBuilder6._depthMul = 1f;
			tileSpriteBuilder6._alpha = 0.5f;
			tileSpriteBuilder6._tileWidth = tileWidth;
			tileSpriteBuilder6._tileHeight = tileHeight;
			tileSpriteBuilder6._parent = transform3;
			tileSpriteBuilder6._name = "CloudsRed";
			TileSprite cloudsRed = tileSpriteBuilder6.Build();
			_cloudsRed = cloudsRed;
			if ((object)_cloudsRed != null)
			{
				GameObject gameObject6 = _cloudsRed.gameObject;
				if ((object)gameObject6 != null)
				{
					gameObject6.SetActive(value: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
					TileSpriteBuilder tileSpriteBuilder7 = RenderingExtensions.AddTileSprite(this, num8, 0f, "backgroundX", text);
					if (tileSpriteBuilder7 != null)
					{
						tileSpriteBuilder7._depth = -32765f;
						tileSpriteBuilder7._depthMul = 1f;
						tileSpriteBuilder7._alpha = 0.5f;
						tileSpriteBuilder7._blendMode = BlendMode.Add;
						tileSpriteBuilder7._tileWidth = tileWidth;
						tileSpriteBuilder7._tileHeight = tileHeight;
						TileSpriteBuilder tileSpriteBuilder8 = tileSpriteBuilder7.SetParent(transform3);
						if (tileSpriteBuilder8 != null)
						{
							TileSpriteBuilder tileSpriteBuilder9 = tileSpriteBuilder8.SetName("CloudsAddRed");
							if (tileSpriteBuilder9 != null)
							{
								TileSprite cloudsAddRed = tileSpriteBuilder9.Build();
								_cloudsAddRed = cloudsAddRed;
								if ((object)_cloudsAddRed != null)
								{
									GameObject gameObject7 = _cloudsAddRed.gameObject;
									if ((object)gameObject7 != null)
									{
										gameObject7.SetActive(value: false);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
										nint num9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
										SpriteRenderer component = RenderingExtensions.AddSprite(this, num9, 0f, "backgroundX", text);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1864048B0");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186404900");
										object obj7 = default(object);
										object obj8 = default(object);
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1864048B0");
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186404900");
										}
										float scale = default(float);
										SpriteRenderer spriteRenderer11 = RenderingExtensions.SetScale(component, scale);
										if ((object)spriteRenderer11 != null)
										{
											spriteRenderer11.sortingOrder = 10000;
											SpriteRenderer spriteRenderer12 = RenderingExtensions.SetAlpha(spriteRenderer11, 0f);
											if ((object)spriteRenderer12 != null)
											{
												Transform transform4 = spriteRenderer12.transform;
												if ((object)transform4 != null)
												{
													transform4.SetParent(_spritesRootTransform, worldPositionStays: true);
													((UnityEngine.Object)spriteRenderer12).SetName("WhiteFader");
													_whiteFader = spriteRenderer12;
													SpriteRenderer spriteRenderer13 = RenderingExtensions.AddSprite(this, 0f, 0f, vector, text, (string)num);
													SpriteRenderer spriteRenderer14 = RenderingExtensions.SetAlpha(spriteRenderer13, 0f);
													SpriteRenderer spriteRenderer15 = RenderingExtensions.SetTint(spriteRenderer14, 16776960u);
													if ((object)spriteRenderer15 != null)
													{
														((UnityEngine.Object)spriteRenderer15).SetName("ShootingRay");
														_shootingRay = spriteRenderer15;
														SpriteRenderer spriteRenderer16 = RenderingExtensions.AddSprite(this, 0f, 0f, "vfx", text);
														SpriteRenderer spriteRenderer17 = RenderingExtensions.SetAlpha(spriteRenderer16, 0f);
														SpriteRenderer spriteRenderer18 = RenderingExtensions.SetTint(spriteRenderer17, 16776960u);
														if ((object)spriteRenderer18 != null)
														{
															((UnityEngine.Object)spriteRenderer18).SetName("ShootingRing");
															_shootingRing = spriteRenderer18;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
															nint num10 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-45]");
															TileSpriteBuilder tileSpriteBuilder10 = RenderingExtensions.AddTileSprite(this, num10, 0f, "backgroundX", text);
															if (tileSpriteBuilder10 != null)
															{
																tileSpriteBuilder10._depth = -1999f;
																tileSpriteBuilder10._depthMul = 1f;
																tileSpriteBuilder10._alpha = 0.1f;
																tileSpriteBuilder10._blendMode = BlendMode.Add;
																tileSpriteBuilder10._tileWidth = tileWidth;
																tileSpriteBuilder10._tileHeight = tileHeight;
																TileSpriteBuilder tileSpriteBuilder11 = tileSpriteBuilder10.SetScale(4f);
																if (tileSpriteBuilder11 != null)
																{
																	TileSpriteBuilder tileSpriteBuilder12 = tileSpriteBuilder11.SetParent(_spritesRootTransform);
																	if (tileSpriteBuilder12 != null)
																	{
																		TileSpriteBuilder tileSpriteBuilder13 = tileSpriteBuilder12.SetName("FloorLights");
																		if (tileSpriteBuilder13 != null)
																		{
																			TileSprite floorLights = tileSpriteBuilder13.Build();
																			_floorLights = floorLights;
																			TileSprite floorLights2 = _floorLights;
																			if ((object)_floorLights != null)
																			{
																				floorLights2._xScrollOffset = -3.1999998f;
																				if ((object)floorLights2._spriteScroller != null)
																				{
																					floorLights2._spriteScroller.SetScrollOffsetX(floorLights2._xScrollOffset);
																					TileSprite floorLights3 = _floorLights;
																					if ((object)_floorLights != null)
																					{
																						floorLights3._yScrollOffset = floorLights3._yScrollOffset;
																						if ((object)floorLights3._spriteScroller != null)
																						{
																							floorLights3._spriteScroller.SetScrollOffsetY(floorLights3._yScrollOffset);
																							GameManager core2 = GM.Core;
																							if ((object)GM.Core != null && core2._playerOptions != null)
																							{
																								PlayerOptionsData config2 = core2._playerOptions.Config;
																								if (config2 != null)
																								{
																									if (config2._003CSelectedInverse_003Ek__BackingField)
																									{
																										TileSprite floorLights4 = _floorLights;
																										if ((object)_floorLights == null || (object)floorLights4._spriteRenderer == null)
																										{
																											goto IL_140e;
																										}
																										floorLights4._spriteRenderer.flipY = true;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+3C]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+44]");
																									_ = 0;
																									float y = (float)vector + (float)vector;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rcx_v1 (VampireSurvivors.Objects.Stages.Background5)+38]");
																									_ = 0;
																									_ = _camBounds;
																									GameObject go7 = base.gameObject;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
																									TileSpriteBuilder tileSpriteBuilder14 = RenderingExtensions.AddTileSprite(go7, 0f, y, "backgroundX", text);
																									_ = 0;
																									_ = 1056964608;
																									_ = 1;
																									if (tileSpriteBuilder14 != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
																										tileSpriteBuilder14._spritePivot = (Vector2?)(object)0;
																										_ = 1f;
																										tileSpriteBuilder14._depth = -1999f;
																										tileSpriteBuilder14._depthMul = 1f;
																										tileSpriteBuilder14._alpha = 0.05f;
																										tileSpriteBuilder14._blendMode = BlendMode.Add;
																										tileSpriteBuilder14._tileWidth = tileWidth;
																										tileSpriteBuilder14._tileHeight = tileHeight;
																										TileSpriteBuilder tileSpriteBuilder15 = tileSpriteBuilder14.SetScale(4f);
																										if (tileSpriteBuilder15 != null)
																										{
																											tileSpriteBuilder15._parent = _spritesRootTransform;
																											tileSpriteBuilder15._name = "SkyLights";
																											TileSprite skyLights = tileSpriteBuilder15.Build();
																											_skyLights = skyLights;
																											TileSprite skyLights2 = _skyLights;
																											if ((object)_skyLights != null)
																											{
																												skyLights2._xScrollOffset = -3.1999998f;
																												if ((object)skyLights2._spriteScroller != null)
																												{
																													skyLights2._spriteScroller.SetScrollOffsetX(skyLights2._xScrollOffset);
																													TileSprite skyLights3 = _skyLights;
																													if ((object)_skyLights != null)
																													{
																														float scrollOffsetY = (skyLights3._yScrollOffset += 0.525f);
																														if ((object)skyLights3._spriteScroller != null)
																														{
																															skyLights3._spriteScroller.SetScrollOffsetY(scrollOffsetY);
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
					}
				}
			}
		}
		goto IL_140e;
	}

	private void SetupCoffinTrigger()
	{
		Pickup pickupItemFromWorld = PickupManager.GetPickupItemFromWorld(ItemType.COFFIN);
		if ((object)pickupItemFromWorld != null && ((UnityEngine.Object)pickupItemFromWorld).m_CachedPtr != (IntPtr)0)
		{
			_coffin = pickupItemFromWorld;
		}
	}

	private void SetupCosmoTrigger()
	{
		//IL_01a3: Expected O, but got I
		//IL_01b5: Expected O, but got I4
		//IL_01c5: Expected O, but got I
		//IL_018e: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				return;
			}
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 == -1)
		{
			return;
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		Dictionary<CharacterType, float> dictionary = config3._003CCharacterEggCount_003Ek__BackingField;
		GameManager core4 = GM.Core;
		PlayerOptionsData config4 = core4._playerOptions.Config;
		int num = config3._003CCharacterEggCount_003Ek__BackingField.FindEntry(config4._selectedChar);
		object obj3;
		if (num < 0)
		{
			obj3 = 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v6 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Single>)+18]");
			object obj4 = 0;
			object obj5 = num + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v31+2C+v558 @ rax_v40*8]");
			obj3 = 0;
		}
		if ((nint)obj3 <= 0)
		{
			Pickup pickupItemFromWorld = PickupManager.GetPickupItemFromWorld(ItemType.NFT);
			if ((bool)pickupItemFromWorld)
			{
				Transform transform = pickupItemFromWorld.transform;
				Vector3 position = transform.position;
				Vector2 pos = default(Vector2);
				Pickup cosmoPavone = PickupManager.CreatePickup(pos, ItemType.COSMO_PAVONE);
				_cosmoPavone = cosmoPavone;
			}
		}
	}

	private bool UpdateEnemyAndBossData()
	{
		//IL_03f8: Expected I4, but got O
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_02c8: Expected I4, but got O
		//IL_0320: Expected I4, but got O
		object obj;
		if (!AlwaysSpawnEnder)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				DataManager dataManager = core._dataManager;
				if (core._dataManager != null && dataManager._003CAllStages_003Ek__BackingField != null)
				{
					obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllStages_003Ek__BackingField).get_Item((System.Int32Enum)13);
					JToken minuteDataFromStageDataList = DataHelper.GetMinuteDataFromStageDataList(30, (JArray)obj);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._playerOptions != null)
					{
						PlayerOptionsData config = core2._playerOptions.Config;
						if (config != null)
						{
							List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
							if (config._003CCollectedItems_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
								bool flag;
								if ((nint)0 == 0)
								{
									flag = false;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
									object obj3 = default(object);
									object obj2 = obj3 - -1;
									bool flag2 = obj2 == null;
									flag = !flag2;
								}
								if (!_hasKilledTheFinalBoss && flag)
								{
									if (minuteDataFromStageDataList != null)
									{
										JArray value = new JArray();
										minuteDataFromStageDataList.set_Item((object)"enemies", (JToken)value);
										JArray value2 = new JArray();
										minuteDataFromStageDataList.set_Item((object)"bosses", (JToken)value2);
									}
									GameManager core3 = GM.Core;
									if ((object)GM.Core != null)
									{
										DataManager dataManager2 = core3._dataManager;
										if (core3._dataManager != null && dataManager2._003CAllStages_003Ek__BackingField != null)
										{
											bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllStages_003Ek__BackingField).TryInsert((System.Int32Enum)13, obj, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
											return false;
										}
									}
								}
								else
								{
									if (minuteDataFromStageDataList == null)
									{
										goto IL_0488;
									}
									JArray jArray = new JArray();
									object obj4 = default(object);
									object content = (EnemyType)obj4;
									if (jArray != null)
									{
										jArray.Add(content);
										minuteDataFromStageDataList.set_Item((object)"enemies", (JToken)jArray);
										JArray jArray2 = new JArray();
										object content2 = (EnemyType)obj4;
										if (jArray2 != null)
										{
											jArray2.Add(content2);
											minuteDataFromStageDataList.set_Item((object)"bosses", (JToken)jArray2);
											goto IL_0488;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_03ea;
		}
		return false;
		IL_03ea:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0488:
		GameManager core4 = GM.Core;
		if ((object)GM.Core != null)
		{
			DataManager dataManager3 = core4._dataManager;
			if (core4._dataManager != null && dataManager3._003CAllStages_003Ek__BackingField != null)
			{
				bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllStages_003Ek__BackingField).TryInsert((System.Int32Enum)13, obj, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
				return true;
			}
		}
		goto IL_03ea;
	}

	private void SetDefaultEnemyAndBossData()
	{
		//IL_007a: Expected I4, but got O
		//IL_00ba: Expected I4, but got O
		GameManager core = GM.Core;
		DataManager dataManager = core._dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllStages_003Ek__BackingField).get_Item((System.Int32Enum)13);
		JToken minuteDataFromStageDataList = DataHelper.GetMinuteDataFromStageDataList(30, (JArray)obj);
		if (minuteDataFromStageDataList != null)
		{
			JArray jArray = new JArray();
			object obj2 = default(object);
			object content = (EnemyType)obj2;
			jArray.Add(content);
			minuteDataFromStageDataList.set_Item((object)"enemies", (JToken)jArray);
			JArray jArray2 = new JArray();
			object content2 = (EnemyType)obj2;
			jArray2.Add(content2);
			minuteDataFromStageDataList.set_Item((object)"bosses", (JToken)jArray2);
			GameManager core2 = GM.Core;
			DataManager dataManager2 = core2._dataManager;
			bool flag = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllStages_003Ek__BackingField).TryInsert((System.Int32Enum)13, obj, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
		}
	}

	public override void CheckMinute(int minute)
	{
		//IL_0673: Expected O, but got I8
		//IL_040d: Expected O, but got I
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_045c->IL069e: Incompatible stack heights: 1 vs 0
		//IL_0441->IL069e: Incompatible stack heights: 1 vs 0
		//IL_0483->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0275->IL069e: Incompatible stack heights: 1 vs 0
		//IL_00f8->IL0513: Incompatible stack heights: 1 vs 0
		//IL_01ca->IL0513: Incompatible stack heights: 1 vs 0
		//IL_04a5->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0293->IL0513: Incompatible stack heights: 1 vs 0
		//IL_011a->IL0513: Incompatible stack heights: 1 vs 0
		//IL_01ec->IL0513: Incompatible stack heights: 1 vs 0
		//IL_02ba->IL069e: Incompatible stack heights: 1 vs 0
		//IL_02e1->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0699->IL069e: Incompatible stack heights: 1 vs 0
		//IL_0303->IL0513: Incompatible stack heights: 1 vs 0
		//IL_05ed->IL069e: Incompatible stack heights: 1 vs 0
		//IL_060f->IL069e: Incompatible stack heights: 1 vs 0
		//IL_04ff->IL069e: Incompatible stack heights: 1 vs 0
		//IL_03c0->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0174->IL069e: Incompatible stack heights: 1 vs 0
		//IL_034a->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0246->IL069e: Incompatible stack heights: 1 vs 0
		//IL_0513->IL069e: Incompatible stack heights: 1 vs 0
		//IL_0188->IL069e: Incompatible stack heights: 1 vs 0
		//IL_025a->IL069e: Incompatible stack heights: 1 vs 0
		//IL_03ea->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0631->IL0513: Incompatible stack heights: 1 vs 0
		//IL_0416->IL069e: Incompatible stack heights: 1 vs 0
		//IL_0658->IL069e: Incompatible stack heights: 1 vs 0
		if (!_useReaperMinuteCheck)
		{
			return;
		}
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
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background5)+3C]");
					float num = 0f * 2f;
					float num2 = num * 0.5f;
					float num3 = num2 + 0.96f;
					float num4 = (float)ret - num3;
					Vector2 spawnPos = default(Vector2);
					bool flag2 = default(bool);
					switch (minute)
					{
					case 10:
					{
						GameManager core5 = GM.Core;
						if ((object)GM.Core != null && (object)core5._stage != null)
						{
							GameObject gameObject2 = core5._stage.SpawnEnemy(EnemyType.BOSS_STALKER_NORMAL, spawnPos, asRemote: false, flag2);
							if ((object)gameObject2 != null && ((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
							{
								OnStalkerSpawned(gameObject2);
							}
							return;
						}
						break;
					}
					case 15:
					{
						GameManager core6 = GM.Core;
						if ((object)GM.Core != null && (object)core6._stage != null)
						{
							GameObject gameObject3 = core6._stage.SpawnEnemy(EnemyType.BOSS_TRICKSTER_NORMAL, spawnPos, asRemote: false, flag2);
							if ((object)gameObject3 != null && ((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
							{
								OnTricksterSpawned(gameObject3);
							}
							return;
						}
						break;
					}
					case 30:
					{
						if ((object)GM.Core == null)
						{
							break;
						}
						if (!GM.Core.IsStageHost)
						{
							return;
						}
						GameManager core3 = GM.Core;
						if ((object)GM.Core == null || core3._multiplayer == null)
						{
							break;
						}
						if (!core3._multiplayer.IsOnlineMultiplayer)
						{
							GameManager core4 = GM.Core;
							if ((object)GM.Core != null && core4._signalBus != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
								object obj2 = default(object);
								object obj = obj2 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								Type signalType = default(Type);
								core4._signalBus.InternalFire(signalType, (object)null, (object)null, flag2);
								return;
							}
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
						long num5 = default(long);
						if (num5 != 0)
						{
							Action<long> action = null;
							((OnlineStageManager)(object)action).EnterTheBossi(num5);
							long startingOnlineClientFrame = ((OnlineStageManager)num5).GetStartingOnlineClientFrame();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v40 (System.Int64)+78]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v40 (System.Int64)+78]");
								bool flag3 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
								return;
							}
						}
						break;
					}
					case 4:
						SnapEggs();
						return;
					case 5:
					{
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null && (object)core2._stage != null)
						{
							GameObject gameObject = core2._stage.SpawnEnemy(EnemyType.BOSS_DROWNER_NORMAL, spawnPos, asRemote: false, flag2);
							if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
							{
								OnDrownerSpawned(gameObject);
							}
							return;
						}
						break;
					}
					default:
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnTricksterSpawned(GameObject enemyTrickster)
	{
		EnemyStalkerNormal component = enemyTrickster.GetComponent<EnemyStalkerNormal>();
		_trickster = component;
	}

	private void OnStalkerSpawned(GameObject enemyStalker)
	{
		//IL_0036: Expected O, but got I4
		EnemyStalkerNormal component = enemyStalker.GetComponent<EnemyStalkerNormal>();
		_stalker = component;
		ArcadeSprite arcadeSprite = _stalker.setScale(0f, (float?)(object)0);
	}

	private void OnDrownerSpawned(GameObject enemy)
	{
		//IL_0036: Expected O, but got I4
		EnemyDrownerNormal component = enemy.GetComponent<EnemyDrownerNormal>();
		_drowner = component;
		ArcadeSprite arcadeSprite = _drowner.setScale(0f, (float?)(object)0);
	}

	private unsafe void SnapEggs()
	{
		//IL_0091: Invalid comparison between I4 and F4
		_003C_003Ec__DisplayClass65_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass65_0();
		CS_0024_003C_003E8__locals18._003C_003E4__this = this;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CSelectedGoldenEggs_003Ek__BackingField)
		{
			return;
		}
		GameManager core2 = GM.Core;
		if (!(0f < (CS_0024_003C_003E8__locals18.number = core2._eggManager.RemoveBonuses())))
		{
			return;
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_snap, 1f);
		_snapAnimation.SetAnimation("snap");
		Action onComplete = delegate
		{
			//IL_056a: Expected O, but got I4
			//IL_05ae: Invalid comparison between F4 and I4
			//IL_00ba: Expected O, but got I4
			//IL_0446: Expected I4, but got O
			//IL_05d7: Expected O, but got F4
			//IL_08b2: Expected O, but got F4
			//IL_04da: Expected I4, but got O
			//IL_0219: Expected I, but got O
			//IL_02bb: Expected I, but got O
			//IL_06cb: Expected O, but got F4
			//IL_06e9: Expected O, but got I4
			//IL_06f7: Expected O, but got I4
			//IL_08c0: Expected O, but got F4
			//IL_08ee: Expected O, but got I4
			//IL_0705: Expected O, but got F4
			//IL_07bb: Expected I, but got O
			//IL_07d1: Expected O, but got I
			//IL_07da: Unknown result type (might be due to invalid IL or missing references)
			//IL_07df: Expected O, but got Unknown
			//IL_0371: Expected I, but got O
			//IL_0805: Expected O, but got I4
			//IL_081c: Expected I, but got I8
			//IL_0832: Expected O, but got I4
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Expected O, but got Unknown
			//IL_03b7: Invalid comparison between F4 and O
			//IL_03d6: Expected O, but got I4
			//IL_035a: Expected I, but got I8
			//IL_0438->IL0530: Incompatible stack heights: 1 vs 0
			//IL_044f->IL0530: Incompatible stack heights: 1 vs 0
			//IL_04c8->IL0530: Incompatible stack heights: 1 vs 0
			//IL_04a6->IL04a6: Incompatible stack heights: 2 vs 1
			//IL_05f6->IL0530: Incompatible stack heights: 1 vs 0
			//IL_0135->IL0530: Incompatible stack heights: 1 vs 0
			//IL_064a->IL0530: Incompatible stack heights: 2 vs 0
			//IL_0169->IL0530: Incompatible stack heights: 2 vs 0
			//IL_019d->IL0530: Incompatible stack heights: 2 vs 0
			//IL_01e9->IL0530: Incompatible stack heights: 2 vs 0
			//IL_023d->IL023d: Incompatible stack heights: 3 vs 2
			//IL_02a1->IL0530: Incompatible stack heights: 3 vs 0
			//IL_02d9->IL02d9: Incompatible stack heights: 5 vs 4
			//IL_06bd->IL0530: Incompatible stack heights: 5 vs 0
			//IL_03f2->IL0837: Incompatible stack heights: 5 vs 1
			//IL_03f7->IL03f7: Incompatible stack heights: 5 vs 1
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1000f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_GameOver, soundConfig, 0f, 10, time);
			Background5 background = CS_0024_003C_003E8__locals18._003C_003E4__this;
			if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null && (object)background._mainCamera != null)
			{
				Transform transform = background._mainCamera.transform;
				if ((object)transform != null)
				{
					bool flag = (byte)(~(((SoundManager.SoundConfig)(object)transform).Mute ? 1u : 0u)) != 0;
					Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform).Mute ? 1 : 0), out Vector3 _);
					float number = CS_0024_003C_003E8__locals18.number;
					bool flag2 = !(CS_0024_003C_003E8__locals18.number > 0f);
					int num = 10;
					if (!flag2)
					{
						object obj2 = default(object);
						object obj = obj2;
						object obj3 = 0;
						object obj5 = default(object);
						object obj4 = obj5;
						float number2 = CS_0024_003C_003E8__locals18.number;
						int num2 = 10;
						Vector2 pos = default(Vector2);
						object obj9 = default(object);
						object obj11 = default(object);
						bool flag10;
						do
						{
							bool flag3 = (nint)obj3 >= 500;
							obj2 = obj;
							obj5 = obj4;
							number = number2;
							num = num2;
							if (flag3)
							{
								break;
							}
							_003C_003Ec__DisplayClass65_1 obj6 = new _003C_003Ec__DisplayClass65_1();
							object obj7 = UnityEngine.Random.value;
							object obj8 = UnityEngine.Random.value;
							TweenConfig tweenConfig;
							TweenCallback tweenCallback;
							if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals18._003C_003E4__this.gameObject;
								SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject, pos, "items", "goldenegg");
								if ((object)spriteRenderer2 != null)
								{
									bool flag4 = (byte)(~(((SoundManager.SoundConfig)(object)spriteRenderer2).Mute ? 1u : 0u)) != 0;
									Renderer.set_sortingOrder_Injected((IntPtr)(((SoundManager.SoundConfig)(object)spriteRenderer2).Mute ? 1 : 0), 9000);
									Background5 background2 = CS_0024_003C_003E8__locals18._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
									{
										Transform transform2 = spriteRenderer2.transform;
										if ((object)transform2 != null)
										{
											transform2.SetParent(background2._spritesRootTransform, worldPositionStays: true);
											if (obj6 != null)
											{
												obj6.s = spriteRenderer2;
												tweenConfig = new TweenConfig();
												object[] array = new object[2];
												if (array != null)
												{
													if ((object)obj6.s != null)
													{
														nint num3 = (nint)array;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														bool flag5 = obj9 == null;
													}
													bool flag6 = array.Length <= 0;
													array[0] = obj6.s;
													SoundManager.SoundConfig s = (SoundManager.SoundConfig)(object)obj6.s;
													if ((object)obj6.s != null)
													{
														bool flag7 = (byte)(~(s.Mute ? 1u : 0u)) != 0;
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)(s.Mute ? 1 : 0));
														Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														if ((object)transform3 != null)
														{
															Transform transform4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((IntPtr)transform3);
															bool flag8 = (object)transform4 == null;
														}
														bool flag9 = array.Length <= 1;
														array[1] = transform3;
														if (tweenConfig != null)
														{
															tweenConfig.targets = array;
															object obj10 = UnityEngine.Random.value;
															float num4 = (float)obj11 + 0.32f;
															tweenConfig.x = (float?)(object)1;
															tweenConfig.y = (float?)(object)1;
															object obj12 = UnityEngine.Random.value;
															float num5 = num4 * 180f;
															float num6 = num5 + 180f;
															tweenConfig.angle = (float?)(object)1;
															object obj13 = UnityEngine.Random.value;
															float num7 = num6 * 300f;
															tweenConfig.ease = Ease.InCirc;
															float duration = num7 + 300f;
															tweenConfig.duration = duration;
															float delay = (float)obj3 * 10f;
															tweenConfig.delay = delay;
															tweenCallback = null;
															nint num8 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
															num = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19 (Il2CppMethodInfo)+8]");
															((Delegate)tweenCallback).method_ptr = (IntPtr)0;
															((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass65_1._003CSnapEggs_003Eb__1);
															((Delegate)tweenCallback).m_target = obj6;
															((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19 (Il2CppMethodInfo)+4C]");
															object obj14 = (nint)0 >> 4;
															object obj15 = obj14 & 1;
															nint num9;
															if (obj15 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ r10_v19 (Il2CppMethodInfo)+52]");
																if ((nint)0 == 0)
																{
																	num9 = unchecked((nint)6447293664L);
																	goto IL_07fc;
																}
															}
															((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
															num9 = ((Delegate)tweenCallback).method_ptr;
															goto IL_07fc;
														}
													}
												}
											}
										}
									}
								}
							}
							goto IL_0530;
							IL_07fc:
							object obj16 = 24;
							((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
							tweenConfig.onComplete = tweenCallback;
							obj5 = 24;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
							number = CS_0024_003C_003E8__locals18.number;
							obj3++;
							float number3 = CS_0024_003C_003E8__locals18.number;
							flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)number3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
							obj2 = obj3;
							obj = obj3;
							obj4 = 24;
							number2 = CS_0024_003C_003E8__locals18.number;
							num2 = num;
						}
						while (flag10);
					}
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					Background5 background3 = CS_0024_003C_003E8__locals18._003C_003E4__this;
					if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null && (int)(~array2) == 0)
					{
						if ((object)background3._snap != null)
						{
							bool value = ((bool*)(&array2))->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj17 = default(object);
							bool flag11 = obj17 == null;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							((SoundManager.SoundConfig)(object)tweenConfig2).Mute = (byte)(int)array2 != 0;
							_ = 1;
							_ = 1133903872;
							float num10 = CS_0024_003C_003E8__locals18.number;
							if (!(500f > CS_0024_003C_003E8__locals18.number))
							{
								num10 = 500f;
							}
							float num11 = num10 * 10f;
							float rate = num11 + 600f;
							((SoundManager.SoundConfig)(object)tweenConfig2).Rate = rate;
							MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
							return;
						}
					}
				}
			}
			goto IL_0530;
			IL_0530:
			throw new NullReferenceException();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void SnapYellows()
	{
		//IL_02c8: Expected O, but got I
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		Weapon weaponByType = activeCharacter._weaponsManager.GetWeaponByType(WeaponType.SHROUD);
		Weapon weaponByType2 = activeCharacter._weaponsManager.GetWeaponByType(WeaponType.CORRIDOR);
		PickupWeapon pickupWeaponFromWorld = PickupManager.GetPickupWeaponFromWorld(WeaponType.GOLD);
		PickupWeapon pickupWeaponFromWorld2 = PickupManager.GetPickupWeaponFromWorld(WeaponType.SILVER);
		PickupWeapon pickupWeaponFromWorld3 = PickupManager.GetPickupWeaponFromWorld(WeaponType.LEFT);
		PickupWeapon pickupWeaponFromWorld4 = PickupManager.GetPickupWeaponFromWorld(WeaponType.RIGHT);
		if (((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0) || ((object)weaponByType2 != null && ((UnityEngine.Object)weaponByType2).m_CachedPtr != (IntPtr)0) || ((object)pickupWeaponFromWorld != null && ((UnityEngine.Object)pickupWeaponFromWorld).m_CachedPtr != (IntPtr)0) || ((object)pickupWeaponFromWorld2 != null && ((UnityEngine.Object)pickupWeaponFromWorld2).m_CachedPtr != (IntPtr)0) || ((object)pickupWeaponFromWorld3 != null && ((UnityEngine.Object)pickupWeaponFromWorld3).m_CachedPtr != (IntPtr)0) || ((object)pickupWeaponFromWorld4 != null && ((UnityEngine.Object)pickupWeaponFromWorld4).m_CachedPtr != (IntPtr)0))
		{
			GameManager core2 = GM.Core;
			PickupWeapon pickupWeapon = default(PickupWeapon);
			VampireSurvivors.Objects.Characters.CharacterController characterController = default(VampireSurvivors.Objects.Characters.CharacterController);
			Weapon weapon = default(Weapon);
			Weapon weapon2 = default(Weapon);
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				PerformSnapYellows(pickupWeaponFromWorld, pickupWeaponFromWorld2, pickupWeaponFromWorld3, pickupWeapon, characterController, weapon, weapon2);
				return;
			}
			object instance = OnlineStageManager._instance;
			Action<CoherenceSync, CoherenceSync, CoherenceSync, CoherenceSync, CoherenceSync> action = OnlineStageManager._instance.SnapYellows;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v5 (System.Object)+78]");
			bool flag = ((CoherenceSync)0).SendCommand((Action<object, object, object, object, object>)action, MessageTarget.All, ((NetworkPickup)pickupWeaponFromWorld)._coherenceSync, pickupWeapon, characterController, weapon, weapon2);
		}
	}

	public void PerformSnapYellows(PickupWeapon gRing, PickupWeapon sRing, PickupWeapon lMeta, PickupWeapon rMeta, VampireSurvivors.Objects.Characters.CharacterController player, Weapon cs, Weapon ic)
	{
		_003C_003Ec__DisplayClass67_0 CS_0024_003C_003E8__locals35 = new _003C_003Ec__DisplayClass67_0();
		Weapon cs2 = default(Weapon);
		CS_0024_003C_003E8__locals35.cs = cs2;
		VampireSurvivors.Objects.Characters.CharacterController player2 = default(VampireSurvivors.Objects.Characters.CharacterController);
		CS_0024_003C_003E8__locals35.player = player2;
		Weapon ic2 = default(Weapon);
		CS_0024_003C_003E8__locals35.ic = ic2;
		CS_0024_003C_003E8__locals35.gRing = gRing;
		CS_0024_003C_003E8__locals35.sRing = sRing;
		CS_0024_003C_003E8__locals35.lMeta = lMeta;
		PickupWeapon rMeta2 = default(PickupWeapon);
		CS_0024_003C_003E8__locals35.rMeta = rMeta2;
		CS_0024_003C_003E8__locals35._003C_003E4__this = this;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_snap, 1f);
		_snapAnimation.SetAnimation("snap");
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_snap, 0f, 0.3f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TryRemoveStagePickup(CS_0024_003C_003E8__locals35.gRing);
		TryRemoveStagePickup(CS_0024_003C_003E8__locals35.sRing);
		TryRemoveStagePickup(CS_0024_003C_003E8__locals35.lMeta);
		TryRemoveStagePickup(CS_0024_003C_003E8__locals35.rMeta);
		Action onComplete = delegate
		{
			//IL_06c2: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = 1000f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_GameOver, soundConfig, 0f, 10, time);
			Debug.Log("Despawning yellows");
			List<string> list = new List<string>();
			Weapon cs3 = CS_0024_003C_003E8__locals35.cs;
			if ((object)CS_0024_003C_003E8__locals35.cs != null && ((UnityEngine.Object)cs3).m_CachedPtr != (IntPtr)0)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"cape");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				GameManager core = GM.Core;
				Weapon weapon = core._weaponsFacade.RemoveWeapon(WeaponType.SHROUD, CS_0024_003C_003E8__locals35.player);
			}
			Weapon ic3 = CS_0024_003C_003E8__locals35.ic;
			if ((object)CS_0024_003C_003E8__locals35.ic != null && ((UnityEngine.Object)ic3).m_CachedPtr != (IntPtr)0)
			{
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._size >= items2.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"portal");
				}
				else
				{
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				GameManager core2 = GM.Core;
				Weapon weapon2 = core2._weaponsFacade.RemoveWeapon(WeaponType.CORRIDOR, CS_0024_003C_003E8__locals35.player);
			}
			PickupWeapon gRing2 = CS_0024_003C_003E8__locals35.gRing;
			if ((object)CS_0024_003C_003E8__locals35.gRing != null && ((UnityEngine.Object)gRing2).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon gRing3 = CS_0024_003C_003E8__locals35.gRing;
				((PickupGuarded)gRing3)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				CS_0024_003C_003E8__locals35.gRing.Despawn();
				int version3 = list._version + 1;
				list._version = version3;
				string[] items3 = list._items;
				if (list._size >= items3.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"goldring");
				}
				else
				{
					int size3 = list._size + 1;
					list._size = size3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			PickupWeapon sRing2 = CS_0024_003C_003E8__locals35.sRing;
			if ((object)CS_0024_003C_003E8__locals35.sRing != null && ((UnityEngine.Object)sRing2).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon sRing3 = CS_0024_003C_003E8__locals35.sRing;
				((PickupGuarded)sRing3)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				CS_0024_003C_003E8__locals35.sRing.Despawn();
				int version4 = list._version + 1;
				list._version = version4;
				string[] items4 = list._items;
				if (list._size >= items4.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"silverring");
				}
				else
				{
					int size4 = list._size + 1;
					list._size = size4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			PickupWeapon lMeta2 = CS_0024_003C_003E8__locals35.lMeta;
			if ((object)CS_0024_003C_003E8__locals35.lMeta != null && ((UnityEngine.Object)lMeta2).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon lMeta3 = CS_0024_003C_003E8__locals35.lMeta;
				((PickupGuarded)lMeta3)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				CS_0024_003C_003E8__locals35.lMeta.Despawn();
				int version5 = list._version + 1;
				list._version = version5;
				string[] items5 = list._items;
				if (list._size >= items5.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"bsleft");
				}
				else
				{
					int size5 = list._size + 1;
					list._size = size5;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			PickupWeapon rMeta3 = CS_0024_003C_003E8__locals35.rMeta;
			if ((object)CS_0024_003C_003E8__locals35.rMeta != null && ((UnityEngine.Object)rMeta3).m_CachedPtr != (IntPtr)0)
			{
				PickupWeapon rMeta4 = CS_0024_003C_003E8__locals35.rMeta;
				((PickupGuarded)rMeta4)._003CSkipOnlineGuardsCheckOnDespawn_003Ek__BackingField = true;
				CS_0024_003C_003E8__locals35.rMeta.Despawn();
				int version6 = list._version + 1;
				list._version = version6;
				string[] items6 = list._items;
				if (list._size >= items6.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"bsright");
				}
				else
				{
					int size6 = list._size + 1;
					list._size = size6;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
			}
			CS_0024_003C_003E8__locals35._003C_003E4__this.RemovePowers(list);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void TryRemoveStagePickup(Pickup pickup)
	{
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
		object obj = default(object);
		if (obj != null)
		{
			GameManager core2 = GM.Core;
			bool flag = ((List<object>)(object)core2._stagePickups).Remove((object)pickup);
		}
	}

	private unsafe void RemovePowers(List<string> frames)
	{
		//IL_0624: Expected O, but got Ref
		//IL_0652: Expected I, but got O
		//IL_0668: Expected O, but got I
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_025e: Expected I, but got O
		//IL_069c: Expected O, but got I4
		//IL_06b3: Expected I, but got I8
		//IL_02ed: Expected I, but got O
		//IL_0303: Expected O, but got I
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		//IL_0247: Expected I, but got I8
		//IL_037a: Expected I, but got O
		//IL_06d9: Expected O, but got I4
		//IL_06f0: Expected I, but got I8
		//IL_0363: Expected I, but got I8
		//IL_041c->IL070d: Incompatible stack heights: 8 vs 1
		float num = (float)Math.PI * 2f / (float)frames._size;
		Transform transform = _mainCamera.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		int num2 = 0;
		int num3 = 0;
		Vector2 vector = default(Vector2);
		string spriteName = default(string);
		Vector2 vector2 = default(Vector2);
		while (num3 < frames._size)
		{
			_003C_003Ec__DisplayClass69_0 obj = new _003C_003Ec__DisplayClass69_0();
			bool flag2 = num2 >= frames._size;
			string[] items = frames._items;
			bool flag3 = num2 >= items.Length;
			GameObject gameObject = base.gameObject;
			SpriteRenderer s = RenderingExtensions.AddSprite(gameObject, vector, vector, "items", spriteName);
			obj.s = s;
			Transform s2 = (Transform)(object)obj.s;
			bool flag4 = ((UnityEngine.Object)s2).m_CachedPtr == (IntPtr)0;
			Renderer.set_enabled_Injected(((UnityEngine.Object)s2).m_CachedPtr, false);
			Transform s3 = (Transform)(object)obj.s;
			bool flag5 = ((UnityEngine.Object)s3).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)s3).m_CachedPtr, 2000);
			Transform transform2 = obj.s.transform;
			transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
			Transform s4 = (Transform)(object)obj.s;
			bool flag6 = ((UnityEngine.Object)s4).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)s4).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.get_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
			float num4 = (float)num2 * num;
			float num5 = num4 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num6 = (float)num2 * num;
			float num7 = num6 + 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Transform s5 = (Transform)(object)obj.s;
			obj.index = num2;
			bool flag8 = ((UnityEngine.Object)s5).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)s5).m_CachedPtr);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMove(target, (Vector3)(&vector2), 0.5f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 4;
					_ = 0;
				}
			}
			float num8 = (float)num2 * 100f;
			float num9 = num8 + 800f;
			float delay = num9 * 0.001f;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
			TweenCallback tweenCallback = null;
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ r10_v16 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass69_0._003CRemovePowers_003Eb__0);
			((Delegate)tweenCallback).m_target = obj;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ r10_v16 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num11;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1833 @ r10_v16 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num11 = unchecked((nint)6447293664L);
					goto IL_0693;
				}
			}
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			num11 = ((Delegate)tweenCallback).method_ptr;
			goto IL_0693;
			IL_06d0:
			object obj4 = 24;
			TweenCallback tweenCallback2;
			((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1826 @ rax_v79 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			num2++;
			vector2 = vector;
			num3 = num2;
			continue;
			IL_0693:
			object obj5 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1826 @ rax_v79 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
			tweenCallback2 = null;
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r10_v17 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass69_0._003CRemovePowers_003Eb__1);
			((Delegate)tweenCallback2).m_target = obj;
			((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r10_v17 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			nint num13;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ r10_v17 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num13 = unchecked((nint)6447293664L);
					goto IL_06d0;
				}
			}
			((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
			num13 = ((Delegate)tweenCallback2).method_ptr;
			goto IL_06d0;
		}
	}

	private unsafe void EnterTheBossi()
	{
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TweenConfig tilingBackground = (TweenConfig)(object)stage._tilingBackground;
		if ((object)stage._tilingBackground != null && tilingBackground.targets != null)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			TilingBackground tilingBackground2 = stage2._tilingBackground;
			TileSprite bgtile = tilingBackground2._bgtile;
			bgtile._spriteRenderer.enabled = false;
		}
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		GameManager core3 = GM.Core;
		Stage stage3 = core3._stage;
		stage3._003CStopCheckingMinutes_003Ek__BackingField = true;
		GameManager core4 = GM.Core;
		Stage stage4 = core4._stage;
		stage4._disableMinueteSpawning = true;
		_savedBgm = SoundManager._003CCurrentBgm_003Ek__BackingField;
		GameManager core5 = GM.Core;
		Stage stage5 = core5._stage;
		TilingTileset tilingTileset = stage5._tilingTileset;
		Tilemap tilemap = null;
		List<SuperTiled2Unity.SuperMap>.Enumerator enumerator = default(List<SuperTiled2Unity.SuperMap>.Enumerator);
		if (enumerator.MoveNext())
		{
			Component component = null;
			throw new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool flag = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, flag);
		Action onComplete = _003C_003Ec._003C_003E9__70_0;
		if (_003C_003Ec._003C_003E9__70_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__70_0 = delegate
			{
				//IL_0050: Expected O, but got I4
				//IL_01b7: Expected I, but got O
				//IL_01cd: Expected O, but got I
				//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
				//IL_01db: Expected O, but got Unknown
				//IL_026f: Expected I, but got O
				//IL_03a7: Expected O, but got I4
				//IL_03be: Expected I, but got I8
				//IL_022d: Expected I, but got I8
				//IL_0304: Unknown result type (might be due to invalid IL or missing references)
				//IL_0309: Expected O, but got Unknown
				GameManager core6 = GM.Core;
				Stage stage6 = core6._stage;
				List<EnemyController> spawnedEnemies = stage6._spawnedEnemies;
				bool flag2 = (nint)stage6._spawnedEnemies < 0;
				object obj3 = spawnedEnemies._size - 1;
				if (flag2)
				{
					goto IL_018c;
				}
				bool flag6 = default(bool);
				while (true)
				{
					GameManager core7 = GM.Core;
					Stage stage7 = core7._stage;
					List<EnemyController> spawnedEnemies2 = stage7._spawnedEnemies;
					if ((nint)obj3 >= spawnedEnemies2._size)
					{
						break;
					}
					EnemyController[] items = spawnedEnemies2._items;
					EnemyController enemyController = items[obj3];
					CoherenceSync coherenceSync = enemyController._coherenceSync;
					bool flag3 = (nint)enemyController._coherenceSync < 0;
					bool flag5;
					if ((object)enemyController._coherenceSync != null)
					{
						flag3 = (nint)((UnityEngine.Object)coherenceSync).m_CachedPtr < 0;
						if (((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
						{
							bool hasStateAuthority = enemyController._coherenceSync.HasStateAuthority;
							flag3 = (hasStateAuthority ? 1 : 0) < (false ? 1 : 0);
							bool flag4 = !hasStateAuthority;
							flag5 = flag3;
							if (flag4)
							{
								goto IL_02fb;
							}
						}
					}
					enemyController.Disappear();
					flag5 = flag3;
					goto IL_02fb;
					IL_02fb:
					obj3--;
					flag6 = flag6;
					if (!flag5)
					{
						continue;
					}
					goto IL_018c;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				goto IL_03d4;
				IL_03d4:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
				object obj4 = default(object);
				throw obj4;
				IL_018c:
				SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
				Action onComplete3 = _003C_003Ec._003C_003E9__70_2;
				if (_003C_003Ec._003C_003E9__70_2 != null)
				{
					goto IL_0274;
				}
				Action action = null;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r10_v3 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec._003CEnterTheBossi_003Eb__70_2);
				((Delegate)action).m_target = _003C_003Ec._003C_003E9;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r10_v3 (Il2CppMethodInfo)+4C]");
				object obj5 = (nint)0 >> 4;
				object obj6 = obj5 & 1;
				nint num2;
				if (obj6 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ r10_v3 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num2 = unchecked((nint)6447293664L);
						goto IL_039e;
					}
				}
				else if (_003C_003Ec._003C_003E9 == null)
				{
					goto IL_03d4;
				}
				num2 = ((Delegate)action).method_ptr;
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				goto IL_039e;
				IL_0274:
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				Timer timer3 = Timers.Register(0.5f, onComplete3, null, isLooped: false, flag6, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				return;
				IL_039e:
				object obj7 = 24;
				((Delegate)action).extra_arg = unchecked((nint)6447293568L);
				_003C_003Ec._003C_003E9__70_2 = action;
				onComplete3 = action;
				goto IL_0274;
			});
		}
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(5f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			GameManager core6 = GM.Core;
			Stage stage6 = core6._stage;
			List<Vector2> destructibleLocations = stage6._destructibleLocations;
			if (stage6._destructibleLocations != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
			}
			RemoveWalls();
			FadeOutSky();
		};
		Timer timer2 = Timers.Register(6.0000005f, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void RemoveWalls()
	{
		Debug.Log("RemoveWalls");
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				TilingTileset tilingTileset = stage._tilingTileset;
				if ((object)stage._tilingTileset != null)
				{
					List<SuperTiled2Unity.SuperMap>.Enumerator maps = (List<SuperTiled2Unity.SuperMap>.Enumerator)tilingTileset._maps;
					if (tilingTileset._maps != null)
					{
						List<SuperTiled2Unity.SuperMap>.Enumerator enumerator = default(List<SuperTiled2Unity.SuperMap>.Enumerator);
						if (enumerator.MoveNext())
						{
							Component component = null;
							throw new NullReferenceException();
						}
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage != null && (object)stage2._tilingTileset != null)
							{
								stage2._tilingTileset.SetTilemapCollisionsEnabled(isEnabled: false);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void FadeOutSky()
	{
		//IL_006a: Expected I, but got O
		//IL_00d4: Expected I, but got O
		//IL_013e: Expected I, but got O
		//IL_01a8: Expected I, but got O
		//IL_0212: Expected I, but got O
		//IL_027c: Expected I, but got O
		//IL_02e6: Expected I, but got O
		//IL_034a: Expected O, but got I4
		//IL_0382: Expected O, but got I4
		Debug.Log("FadeOutSky");
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[7];
		TileSprite skyBlue = _skyBlue;
		if ((object)skyBlue._spriteRenderer != null)
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
		TileSprite skyRed = _skyRed;
		if ((object)skyRed._spriteRenderer != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		TileSprite cloudsBlue = _cloudsBlue;
		if ((object)cloudsBlue._spriteRenderer != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		TileSprite cloudsRed = _cloudsRed;
		if ((object)cloudsRed._spriteRenderer != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		TileSprite cloudsAddBlue = _cloudsAddBlue;
		if ((object)cloudsAddBlue._spriteRenderer != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		TileSprite cloudsAddRed = _cloudsAddRed;
		if ((object)cloudsAddRed._spriteRenderer != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		TileSprite cloudsWhite = _cloudsWhite;
		if ((object)cloudsWhite._spriteRenderer != null)
		{
			nint num7 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1000f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		bool alwaysSpawnEnder = AlwaysSpawnEnder;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.1f;
		SoundManager.PlayMusic(BgmType.TheEndIndeed, soundConfig);
		DOGetter<float> getter = _003C_003Ec._003C_003E9__72_0;
		if (_003C_003Ec._003C_003E9__72_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__72_0 = dOGetter;
			getter = dOGetter;
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__72_1;
		if (_003C_003Ec._003C_003E9__72_1 == null)
		{
			DOSetter<float> dOSetter = null;
			float x = default(float);
			((_003C_003Ec)(object)dOSetter)._003CFadeOutSky_003Eb__72_1(x);
			_003C_003Ec._003C_003E9__72_1 = dOSetter;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0.25f, 5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action onComplete = delegate
		{
			PowerOfFriendshipGoPlanet();
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = BgmType.TheEndIntro;
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			GM.Core.SetupMusicBanger(loop: false);
			PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
			PlaylistController.SongEndedEventHandler value = delegate
			{
				// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
				PlaylistController onlyPlaylistController2 = MasterAudio.OnlyPlaylistController;
				PlaylistController.SongEndedEventHandler value2 = _003CFadeOutSky_003Eg__OnIntroEnded_007C72_4;
				onlyPlaylistController2.SongEnded -= value2;
				GameManager core3 = GM.Core;
				PlayerOptionsData config3 = core3._playerOptions.Config;
				config3._003CSelectedBGM_003Ek__BackingField = BgmType.TheEndMain;
				GM.Core.SetupMusicBanger();
			};
			onlyPlaylistController.SongEnded += value;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(20f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			//IL_025f->IL01b5: Incompatible stack heights: 1 vs 0
			//IL_0146->IL01b5: Incompatible stack heights: 1 vs 0
			//IL_0281->IL01b4: Incompatible stack heights: 1 vs 0
			//IL_01a0->IL01b4: Incompatible stack heights: 1 vs 0
			//IL_01b4->IL01b4: Incompatible stack heights: 1 vs 0
			EnterPurpleSky();
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._lootManager != null)
			{
				core._lootManager.SetPlainLootTable();
				Transform ender = (Transform)(object)_ender;
				if ((object)_ender != null && ((UnityEngine.Object)ender).m_CachedPtr != (IntPtr)0)
				{
					return;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core2._gameSessionData;
					if (core2._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						Transform transform = gameSessionData._activeCharacter.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							GameManager core3 = GM.Core;
							if ((object)GM.Core != null && (object)core3._stage != null)
							{
								Vector2 spawnPos = default(Vector2);
								bool forceSpawn = default(bool);
								GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.BOSS_ENDER, spawnPos, asRemote: false, forceSpawn);
								if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
								{
									OnEnderSpawned(gameObject);
								}
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		};
		Timer timer2 = Timers.Register(24.800001f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void OnEnderSpawned(GameObject enemyEnder)
	{
		EnemyTheEnder component = enemyEnder.GetComponent<EnemyTheEnder>();
		_ender = component;
		EnemyTheEnder ender = _ender;
		if ((object)_ender != null && ((UnityEngine.Object)ender).m_CachedPtr != (IntPtr)0)
		{
			EnemyTheEnder ender2 = _ender;
			Action action = FadeOutPurpleSky;
			ender2._003COnDefeat_003Ek__BackingField = action;
			bool dropGospel = DropGospel;
			_ender.DropGospel = dropGospel;
			float enderShieldTime = EnderShieldTime;
			float shieldTime = default(float);
			_ender.ShieldTime = shieldTime;
		}
	}

	private void PowerOfFriendshipGoPlanet()
	{
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Expected O, but got Unknown
		//IL_049b: Expected I, but got O
		//IL_04f2: Expected I, but got O
		//IL_0549: Expected I, but got O
		//IL_05a0: Expected I, but got O
		//IL_05f7: Expected I, but got O
		//IL_067d: Expected O, but got I4
		//IL_07fc->IL079f: Incompatible stack heights: 1 vs 0
		//IL_00f4->IL079f: Incompatible stack heights: 1 vs 0
		//IL_018e->IL079f: Incompatible stack heights: 1 vs 0
		//IL_0866->IL079f: Incompatible stack heights: 2 vs 0
		//IL_0259->IL079f: Incompatible stack heights: 2 vs 0
		//IL_08d0->IL079f: Incompatible stack heights: 3 vs 0
		//IL_0324->IL079f: Incompatible stack heights: 3 vs 0
		//IL_093a->IL079f: Incompatible stack heights: 4 vs 0
		//IL_03ef->IL079f: Incompatible stack heights: 4 vs 0
		//IL_09a4->IL079f: Incompatible stack heights: 5 vs 0
		//IL_046c->IL079f: Incompatible stack heights: 5 vs 0
		//IL_04be->IL04be: Incompatible stack heights: 6 vs 5
		//IL_0515->IL0515: Incompatible stack heights: 6 vs 5
		//IL_056c->IL056c: Incompatible stack heights: 6 vs 5
		//IL_063c->IL079f: Incompatible stack heights: 5 vs 0
		//IL_05c3->IL05c3: Incompatible stack heights: 6 vs 5
		//IL_061a->IL061a: Incompatible stack heights: 6 vs 5
		//IL_0744->IL079f: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass74_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass74_0();
		Bounds camBounds = _camBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background5)+3C]");
		object obj = camBounds - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background5)+3C]");
		float num = 0f * 2f;
		object obj2 = default(object);
		float y = (float)obj2 - (float)obj2;
		float num2 = num * 0.2f;
		float x = num2 + (float)obj;
		GameObject gameObject = base.gameObject;
		string spriteName = default(string);
		SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, x, y, "enemies", spriteName);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 5f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
		if ((object)spriteRenderer2 != null)
		{
			bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
			Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, 10000);
			Transform transform = spriteRenderer2.transform;
			if ((object)transform != null)
			{
				transform.SetParent(_spritesRootTransform, worldPositionStays: true);
				((UnityEngine.Object)spriteRenderer2).SetName("r1");
				if (CS_0024_003C_003E8__locals20 != null)
				{
					CS_0024_003C_003E8__locals20.r1 = spriteRenderer2;
					float num3 = num * 0.35f;
					float x2 = num3 + (float)obj;
					GameObject gameObject2 = base.gameObject;
					SpriteRenderer component2 = RenderingExtensions.AddSprite(gameObject2, x2, y, "enemies3", spriteName);
					SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(component2, 5f);
					SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
					if ((object)spriteRenderer4 != null)
					{
						bool flag2 = ((UnityEngine.Object)spriteRenderer4).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer4).m_CachedPtr, 10001);
						Transform transform2 = spriteRenderer4.transform;
						if ((object)transform2 != null)
						{
							transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
							((UnityEngine.Object)spriteRenderer4).SetName("r2");
							CS_0024_003C_003E8__locals20.r2 = spriteRenderer4;
							float num4 = num * 0.5f;
							float x3 = num4 + (float)obj;
							GameObject gameObject3 = base.gameObject;
							SpriteRenderer component3 = RenderingExtensions.AddSprite(gameObject3, x3, y, "enemies", spriteName);
							SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(component3, 5f);
							SpriteRenderer spriteRenderer6 = RenderingExtensions.SetAlpha(spriteRenderer5, 0f);
							if ((object)spriteRenderer6 != null)
							{
								bool flag3 = ((UnityEngine.Object)spriteRenderer6).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer6).m_CachedPtr, 10002);
								Transform transform3 = spriteRenderer6.transform;
								if ((object)transform3 != null)
								{
									transform3.SetParent(_spritesRootTransform, worldPositionStays: true);
									((UnityEngine.Object)spriteRenderer6).SetName("r3");
									CS_0024_003C_003E8__locals20.r3 = spriteRenderer6;
									float num5 = num * 0.65f;
									float x4 = num5 + (float)obj;
									GameObject gameObject4 = base.gameObject;
									SpriteRenderer component4 = RenderingExtensions.AddSprite(gameObject4, x4, y, "enemies2", spriteName);
									SpriteRenderer spriteRenderer7 = RenderingExtensions.SetScale(component4, 5f);
									SpriteRenderer spriteRenderer8 = RenderingExtensions.SetAlpha(spriteRenderer7, 0f);
									if ((object)spriteRenderer8 != null)
									{
										bool flag4 = ((UnityEngine.Object)spriteRenderer8).m_CachedPtr == (IntPtr)0;
										Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer8).m_CachedPtr, 10003);
										Transform transform4 = spriteRenderer8.transform;
										if ((object)transform4 != null)
										{
											transform4.SetParent(_spritesRootTransform, worldPositionStays: true);
											((UnityEngine.Object)spriteRenderer8).SetName("r4");
											CS_0024_003C_003E8__locals20.r4 = spriteRenderer8;
											float num6 = num * 0.8f;
											float x5 = num6 + (float)obj;
											GameObject gameObject5 = base.gameObject;
											SpriteRenderer component5 = RenderingExtensions.AddSprite(gameObject5, x5, y, "enemies3", spriteName);
											SpriteRenderer spriteRenderer9 = RenderingExtensions.SetScale(component5, 5f);
											SpriteRenderer spriteRenderer10 = RenderingExtensions.SetAlpha(spriteRenderer9, 0f);
											if ((object)spriteRenderer10 != null)
											{
												bool flag5 = ((UnityEngine.Object)spriteRenderer10).m_CachedPtr == (IntPtr)0;
												Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer10).m_CachedPtr, 10004);
												Transform transform5 = spriteRenderer10.transform;
												if ((object)transform5 != null)
												{
													transform5.SetParent(_spritesRootTransform, worldPositionStays: true);
													((UnityEngine.Object)spriteRenderer10).SetName("r5");
													CS_0024_003C_003E8__locals20.r5 = spriteRenderer10;
													TweenConfig tweenConfig = new TweenConfig();
													object[] array = new object[5];
													if (array != null)
													{
														if ((object)CS_0024_003C_003E8__locals20.r1 != null)
														{
															nint num7 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj3 = default(object);
															bool flag6 = obj3 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)CS_0024_003C_003E8__locals20.r2 != null)
														{
															nint num8 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj4 = default(object);
															bool flag7 = obj4 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)CS_0024_003C_003E8__locals20.r3 != null)
														{
															nint num9 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj5 = default(object);
															bool flag8 = obj5 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)CS_0024_003C_003E8__locals20.r4 != null)
														{
															nint num10 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj6 = default(object);
															bool flag9 = obj6 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)CS_0024_003C_003E8__locals20.r5 != null)
														{
															nint num11 = (nint)array;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj7 = default(object);
															bool flag10 = obj7 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig != null)
														{
															tweenConfig.targets = array;
															tweenConfig.yoyo = true;
															tweenConfig.duration = 2000f;
															tweenConfig.alpha = (float?)(object)1;
															Func<int, float> staggerDelay = Tweens.Stagger(100f);
															tweenConfig.staggerDelay = staggerDelay;
															TweenCallback onComplete = delegate
															{
																CS_0024_003C_003E8__locals20.r1.enabled = false;
																CS_0024_003C_003E8__locals20.r2.enabled = false;
																CS_0024_003C_003E8__locals20.r3.enabled = false;
																CS_0024_003C_003E8__locals20.r4.enabled = false;
																CS_0024_003C_003E8__locals20.r5.enabled = false;
															};
															tweenConfig.onComplete = onComplete;
															MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
															StaggerMoveReaper(0, CS_0024_003C_003E8__locals20.r1);
															StaggerMoveReaper(1, CS_0024_003C_003E8__locals20.r2);
															StaggerMoveReaper(2, CS_0024_003C_003E8__locals20.r3);
															StaggerMoveReaper(3, CS_0024_003C_003E8__locals20.r4);
															Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1507 Invalid \"Jump target not found in method: 0x186EDEB70\"");
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

	private unsafe void StaggerMoveReaper(int index, SpriteRenderer reaper)
	{
		//IL_0136: Expected O, but got Ref
		//IL_018b->IL00bb: Incompatible stack heights: 1 vs 0
		//IL_01a8->IL00bb: Incompatible stack heights: 1 vs 0
		if ((object)reaper != null)
		{
			Transform transform = reaper.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				float delay = (float)index * 0.1f;
				TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOLocalMove(transform, (Vector3)(&ret), 3.8000002f);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = TweenSettingsExtensions.SetDelay(t, delay);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore != null)
				{
					TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(transform, 1f, 3.8000002f);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t2, delay);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore2 != null)
					{
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void EnterPurpleSky()
	{
		//IL_0ab8: Expected I, but got O
		//IL_0ace: Expected O, but got I
		//IL_0b58: Expected I, but got O
		//IL_0b6e: Expected O, but got I
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0075: Expected O, but got I8
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0cb2: Expected O, but got I4
		//IL_0cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc7: Expected O, but got Unknown
		//IL_029f: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		//IL_08fc: Expected I, but got O
		//IL_03b2: Expected I4, but got I8
		//IL_0a7c: Expected I4, but got O
		//IL_08a6: Expected O, but got F4
		//IL_08af: Expected O, but got I4
		//IL_0542: Expected O, but got Ref
		//IL_060a: Expected O, but got I4
		//IL_06f2: Expected F4, but got I4
		//IL_06d1: Expected O, but got I4
		//IL_06dc: Expected F4, but got I4
		//IL_018f->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_01cc->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0227->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0264->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_08ef->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0941->IL0a86: Incompatible stack heights: 2 vs 0
		//IL_0726->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_035d->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0989->IL0a86: Incompatible stack heights: 2 vs 0
		//IL_076e->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0387->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_07a7->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_041d->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0459->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0482->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_0530->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_057c->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_05eb->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_05c9->IL05c9: Incompatible stack heights: 2 vs 1
		//IL_0661->IL0a86: Incompatible stack heights: 1 vs 0
		//IL_06aa->IL0a86: Incompatible stack heights: 1 vs 0
		DOGetter<float> getter = _003C_003Ec._003C_003E9__76_0;
		if (_003C_003Ec._003C_003E9__76_0 == null)
		{
			DOGetter<float> dOGetter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			_003C_003Ec._003C_003E9__76_0 = dOGetter;
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v167 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5+<>c>)+B8]");
			object obj = (nint)0 + (nint)64;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			getter = dOGetter;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = 6603577472L;
				obj = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj6 = 1 << (int)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v5+462E0+v153 @ rdx_v106*8]");
					object obj7 = 0 | obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v5+462E0+v153 @ rdx_v106*8]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v5+462E0+v153 @ rdx_v106*8]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v5+462E0+v153 @ rdx_v106*8]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v5+462E0+v153 @ rdx_v106*8]");
				}
				while (num3 != 0);
				getter = dOGetter;
			}
		}
		DOSetter<float> setter = _003C_003Ec._003C_003E9__76_1;
		if (_003C_003Ec._003C_003E9__76_1 == null)
		{
			DOSetter<float> dOSetter = null;
			float x = default(float);
			((_003C_003Ec)(object)dOSetter)._003CEnterPurpleSky_003Eb__76_1(x);
			_003C_003Ec._003C_003E9__76_1 = dOSetter;
			nint num4 = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v188 (Il2CppClass<VampireSurvivors.Objects.Stages.Background5+<>c>)+B8]");
			object obj = (nint)0 + (nint)72;
			setter = dOSetter;
		}
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 1f, 5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null && (object)_mainCamera != null)
		{
			Transform transform = _mainCamera.transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v28 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rax_v28 (UnityEngine.Transform)+10]");
				float ret;
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, vector, "backgroundX", "CloudsOverlay");
				if ((object)spriteRenderer != null)
				{
					spriteRenderer.enabled = false;
					Transform transform2 = spriteRenderer.transform;
					if ((object)transform2 != null)
					{
						transform2.SetParent(_spritesRootTransform, worldPositionStays: true);
						_purpleOverlay = spriteRenderer;
						GameObject gameObject2 = base.gameObject;
						SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject2, vector, "backgroundX", "CloudsOverlayAdd");
						if ((object)spriteRenderer2 != null)
						{
							spriteRenderer2.enabled = false;
							Transform transform3 = spriteRenderer2.transform;
							if ((object)transform3 != null)
							{
								transform3.SetParent(_spritesRootTransform, worldPositionStays: true);
								_purpleOverlayAdd = spriteRenderer2;
								bool flag3 = true;
								List<MultiTargetTween>.Enumerator enumerator = (List<MultiTargetTween>.Enumerator)0;
								Vector2 vector2 = vector;
								object obj8 = 0;
								float num5 = 1f;
								bool flag4 = false;
								bool flag5 = false;
								string text = default(string);
								TweenerCore<float, float, FloatOptions> arg = default(TweenerCore<float, float, FloatOptions>);
								object arg2 = default(object);
								Vector2 vector3 = default(Vector2);
								object obj10 = default(object);
								object obj12 = default(object);
								object value4 = default(object);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								while (true)
								{
									if ((flag5 ? 1 : 0) < 4)
									{
										_003C_003Ec__DisplayClass76_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass76_0();
										List<Transform> list = new List<Transform>();
										List<Transform> list2 = list;
										bool flag6 = flag4;
										while ((flag6 ? 1 : 0) < 12)
										{
											float num6 = (float)vector + (float)vector;
											SpriteRenderer component = RenderingExtensions.AddSprite(this, ret, num6, "backgroundX", text);
											SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(component, 0f);
											if ((object)spriteRenderer3 == null)
											{
												goto end_IL_0c5a;
											}
											Transform transform4 = spriteRenderer3.transform;
											if ((object)transform4 == null)
											{
												goto end_IL_0c5a;
											}
											transform4.SetParent(_spritesRootTransform, worldPositionStays: true);
											int sortingOrder = (int)(4294965296L - (flag6 ? 1 : 0));
											spriteRenderer3.sortingOrder = sortingOrder;
											GameObject gameObject3 = spriteRenderer3.gameObject;
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
											string text2 = $"PurpleCloud[{arg}][{arg2}]";
											if ((object)gameObject3 == null)
											{
												goto end_IL_0c5a;
											}
											((UnityEngine.Object)gameObject3).SetName(text2);
											Transform transform5 = spriteRenderer3.transform;
											if (list2 == null)
											{
												goto end_IL_0c5a;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049F4B0");
											if (_purpleClouds == null)
											{
												goto end_IL_0c5a;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5230");
											float value = UnityEngine.Random.value;
											bool flag7 = value < 0.5f;
											bool flipX = !flag7;
											spriteRenderer3.flipX = flipX;
											float value2 = UnityEngine.Random.value;
											bool flag8 = value2 < 0.5f;
											bool flipY = !flag8;
											spriteRenderer3.flipY = flipY;
											float value3 = UnityEngine.Random.value;
											Transform transform6 = spriteRenderer3.transform;
											if ((object)transform6 == null)
											{
												goto end_IL_0c5a;
											}
											transform6.localEulerAngles = (Vector3)(&vector3);
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[1];
											if (array == null)
											{
												goto end_IL_0c5a;
											}
											if ((object)transform5 != null)
											{
												object obj9 = array;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												bool flag9 = obj10 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											if (tweenConfig == null)
											{
												goto end_IL_0c5a;
											}
											_ = 1;
											object obj11 = (flag6 ? 1 : 0) * 307;
											float num7 = (float)obj11 + 20000f;
											_ = 4;
											_ = 4294967295L;
											_ = 0;
											MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
											if (_movingBgTweens == null)
											{
												goto end_IL_0c5a;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
											if (base._003CDisableMovingBg_003Ek__BackingField)
											{
												if (_movingBgTweens == null)
												{
													goto end_IL_0c5a;
												}
												while (enumerator.MoveNext())
												{
												}
												enumerator = (List<MultiTargetTween>.Enumerator)1;
												float x = 0f;
												list2 = list;
											}
											else
											{
												float x = 0f;
												list2 = list;
											}
											flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
											vector3 = vector;
											num5 = num6;
											flag4 = false;
										}
										List<object> list3 = new List<object>();
										if (list3 == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1937 @ rax_v96 (System.Collections.Generic.List`1<System.Object>)+18]");
										list3.InsertRange(0, list2);
										object[] targetsArray = list3.ToArray();
										if (CS_0024_003C_003E8__locals4 == null)
										{
											break;
										}
										CS_0024_003C_003E8__locals4.targetsArray = targetsArray;
										TweenConfig tweenConfig2 = new TweenConfig();
										if (tweenConfig2 == null)
										{
											break;
										}
										tweenConfig2.targets = CS_0024_003C_003E8__locals4.targetsArray;
										Func<int, float> staggerDelay = Tweens.Stagger(50f);
										tweenConfig2.staggerDelay = staggerDelay;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background5)+3C]");
										float num8 = 0f * 2f;
										float num9 = num8 / 3.1999998f;
										float num10 = num9 / 5f;
										Func<int, float> staggerScale = Tweens.Stagger(num10);
										tweenConfig2.staggerScale = staggerScale;
										tweenConfig2.duration = 1000f;
										tweenConfig2.ease = Ease.InOutSine;
										TweenCallback onComplete = delegate
										{
											//IL_0043: Expected O, but got I4
											TweenConfig tweenConfig4 = new TweenConfig();
											tweenConfig4.targets = CS_0024_003C_003E8__locals4.targetsArray;
											tweenConfig4.duration = 3000f;
											tweenConfig4.ease = Ease.InOutSine;
											tweenConfig4.localY = (float?)(object)1;
											MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
										};
										tweenConfig2.onComplete = onComplete;
										MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
										flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
										vector2 = (Vector2)num10;
										obj8 = 0;
										flag3 = false;
										continue;
									}
									TweenConfig tweenConfig3 = new TweenConfig();
									object[] array2 = new object[1];
									if (array2 == null)
									{
										break;
									}
									nint num11 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									bool flag10 = obj12 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig3 == null)
									{
										break;
									}
									tweenConfig3.targets = array2;
									Dictionary<string, object> dictionary = new Dictionary<string, object>();
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
									if (dictionary == null)
									{
										break;
									}
									bool flag11 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_TintHelp", value4, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
									tweenConfig3.custom = dictionary;
									tweenConfig3.delay = 1000f;
									tweenConfig3.duration = 3000f;
									TweenCallback onUpdate = delegate
									{
										Camera mainCamera = _mainCamera;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm2\"");
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
										bool flag12 = ((UnityEngine.Object)mainCamera).m_CachedPtr == (IntPtr)0;
										float value5 = default(float);
										Camera.set_backgroundColor_Injected(((UnityEngine.Object)mainCamera).m_CachedPtr, ref *(Color*)(&value5));
									};
									tweenConfig3.onUpdate = onUpdate;
									TweenCallback onComplete2 = delegate
									{
										_skyLights.SetVisible(visible: false);
										_floorLights.SetVisible(visible: false);
									};
									tweenConfig3.onComplete = onComplete2;
									MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
									Action onComplete3 = ShowPurpleOverlays;
									Timer timer = Timers.Register(1f, onComplete3, null, isLooped: false, (byte)(int)text != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, flag4);
									return;
									continue;
									end_IL_0c5a:
									break;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void FadeOutPurpleSky()
	{
		//IL_00d5: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_01a5: Expected I, but got O
		//IL_0218: Expected O, but got I4
		//IL_025d: Expected I, but got O
		_skyLights.SetVisible(visible: true);
		_floorLights.SetVisible(visible: true);
		List<EquipmentInfo> playerEquipment = GM.Core.RemoveAllEquipmentFromPlayers();
		_playerEquipment = playerEquipment;
		List<object> list = new List<object>();
		list.InsertRange(list._size, _purpleClouds);
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = list.ToArray();
		tweenConfig.targets = targets;
		tweenConfig.duration = 5000f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array = new object[2];
		if ((object)_purpleOverlay != null)
		{
			nint num = (nint)array;
			SpriteRenderer purpleOverlay = _purpleOverlay;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ rcx_v70 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+40]");
			((List<object>)(object)purpleOverlay).InsertRange(0, (IEnumerable<object>)_purpleClouds);
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		((List<object>)(object)array).InsertRange(0, (IEnumerable<object>)(object)_purpleOverlay);
		if ((object)_purpleOverlayAdd != null)
		{
			nint num2 = (nint)array;
			SpriteRenderer purpleOverlayAdd = _purpleOverlayAdd;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v76 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+40]");
			((List<object>)(object)purpleOverlayAdd).InsertRange(0, (IEnumerable<object>)(object)_purpleOverlay);
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		((List<object>)(object)array).InsertRange(1, (IEnumerable<object>)(object)_purpleOverlayAdd);
		tweenConfig2.targets = array;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 1000f;
		MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array2 = new object[1];
		nint num3 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v714 @ rcx_v36 (Il2CppClass<System.Collections.Generic.List`1<System.Object>>)+40]");
		((List<object>)(object)this).InsertRange(0, (IEnumerable<object>)(object)_purpleOverlayAdd);
		object obj3 = default(object);
		if (obj3 != null)
		{
			((List<object>)(object)array2).InsertRange(0, (IEnumerable<object>)this);
			tweenConfig3.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_TintHelp", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig3.custom = dictionary;
			tweenConfig3.duration = 5000f;
			TweenCallback onStart = delegate
			{
				_TintHelp = 1f;
			};
			tweenConfig3.onStart = onStart;
			TweenCallback onUpdate = delegate
			{
				Camera mainCamera = _mainCamera;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm2\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
				bool flag2 = ((UnityEngine.Object)mainCamera).m_CachedPtr == (IntPtr)0;
				float value2 = default(float);
				Camera.set_backgroundColor_Injected(((UnityEngine.Object)mainCamera).m_CachedPtr, ref *(Color*)(&value2));
			};
			tweenConfig3.onUpdate = onUpdate;
			MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	private void ShowPurpleOverlays()
	{
		//IL_0392: Expected I4, but got I8
		//IL_03e6: Expected I4, but got I8
		//IL_0218: Expected I, but got O
		//IL_030a: Expected I, but got O
		//IL_03ac->IL0329: Incompatible stack heights: 1 vs 0
		//IL_011f->IL0329: Incompatible stack heights: 1 vs 0
		//IL_0183->IL0329: Incompatible stack heights: 2 vs 0
		//IL_0206->IL0329: Incompatible stack heights: 2 vs 0
		//IL_01d8->IL01d8: Incompatible stack heights: 3 vs 2
		//IL_0275->IL0329: Incompatible stack heights: 2 vs 0
		//IL_02f8->IL0329: Incompatible stack heights: 2 vs 0
		//IL_02ca->IL02ca: Incompatible stack heights: 3 vs 2
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.Background5)+3C]");
		float num = 0f * 2f;
		object obj = default(object);
		float num2 = (float)obj * 2f;
		if ((object)_purpleOverlay != null)
		{
			_purpleOverlay.enabled = true;
			float yScale = num2 / 3.1999998f;
			float xScale = num / 3.1999998f;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_purpleOverlay, xScale, yScale);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
			if ((object)spriteRenderer2 != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
				Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, -1700);
				if ((object)_purpleOverlayAdd != null)
				{
					_purpleOverlayAdd.enabled = true;
					float yScale2 = num2 / 3.1999998f;
					SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(xScale: num / 3.1999998f, component: _purpleOverlayAdd, yScale: yScale2);
					SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
					if ((object)spriteRenderer4 != null)
					{
						bool flag2 = ((UnityEngine.Object)spriteRenderer4).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer4).m_CachedPtr, -1701);
						Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
						((Renderer)spriteRenderer4).SetMaterial(material);
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							if ((object)_purpleOverlayAdd != null)
							{
								SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(_purpleOverlayAdd, 0f, yScale2);
								bool flag3 = (object)spriteRenderer5 == null;
							}
							SpriteRenderer spriteRenderer6 = RenderingExtensions.SetScale((SpriteRenderer)(object)array, 0f, yScale2);
							if (tweenConfig != null)
							{
								((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
								_ = 1148846080;
								_ = 1;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									if ((object)_purpleOverlay != null)
									{
										SpriteRenderer spriteRenderer7 = RenderingExtensions.SetScale(_purpleOverlay, 0f, yScale2);
										bool flag4 = (object)spriteRenderer7 == null;
									}
									SpriteRenderer spriteRenderer8 = RenderingExtensions.SetScale((SpriteRenderer)(object)array2, 0f, yScale2);
									if (tweenConfig2 != null)
									{
										((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
										_ = 1;
										_ = 1167867904;
										MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
										return;
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

	private void FadeToMad()
	{
		//IL_00b3: Expected I, but got O
		//IL_0125: Expected O, but got I4
		EnemyMaddenerNormal maddener = _maddener;
		if ((object)_maddener == null || ((UnityEngine.Object)maddener).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		EnemyMaddenerNormal maddener2 = _maddener;
		if (((EnemyController)maddener2)._003CIsDead_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_whiteFader != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.delay = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			ToggleBlue(visible: false);
			ToggleRed(visible: true);
			ToggleAlias(toggle: true);
			EnemyMaddenerNormal maddener3 = _maddener;
			base._003CAlias_003Ek__BackingField = true;
			if ((object)_maddener != null && ((UnityEngine.Object)maddener3).m_CachedPtr != (IntPtr)0)
			{
				EnemyMaddenerNormal maddener4 = _maddener;
				Action action = RevertMad;
				maddener4._003COnDefeat_003Ek__BackingField = action;
			}
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_whiteFader, 0f, 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void RevertMad()
	{
		//IL_002c: Expected I, but got O
		//IL_009e: Expected O, but got I4
		base._003CAlias_003Ek__BackingField = false;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_whiteFader != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.delay = 500f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			ToggleBlue(visible: true);
			ToggleRed(visible: false);
			ToggleAlias(toggle: false);
			base._003CAlias_003Ek__BackingField = false;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_whiteFader, 0f, 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void ToggleBlue(bool visible)
	{
		GameObject gameObject = _skyBlue.gameObject;
		gameObject.SetActive(visible);
		GameObject gameObject2 = _cloudsBlue.gameObject;
		gameObject2.SetActive(visible);
		GameObject gameObject3 = _cloudsAddBlue.gameObject;
		gameObject3.SetActive(visible);
		if (visible)
		{
			TileSprite floorLights = _floorLights;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(floorLights._spriteRenderer, 16777215u);
			TileSprite skyLights = _skyLights;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(skyLights._spriteRenderer, 16777215u);
		}
	}

	private void ToggleRed(bool visible)
	{
		GameObject gameObject = _skyRed.gameObject;
		gameObject.SetActive(visible);
		GameObject gameObject2 = _cloudsRed.gameObject;
		gameObject2.SetActive(visible);
		GameObject gameObject3 = _cloudsAddRed.gameObject;
		gameObject3.SetActive(visible);
		if (visible)
		{
			TileSprite floorLights = _floorLights;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(floorLights._spriteRenderer, 16711680u);
			TileSprite skyLights = _skyLights;
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(skyLights._spriteRenderer, 16711680u);
		}
	}

	private void ToggleAlias(bool toggle)
	{
		//IL_001f: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			object obj = 0;
			object obj2 = 0;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdi_v4+10]");
				if ((nint)0 != 0)
				{
					break;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void OpenTerrace()
	{
		//IL_005c: Expected O, but got I
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected O, but got Unknown
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Expected O, but got Unknown
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_0857: Expected O, but got Unknown
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Expected O, but got Unknown
		//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Expected O, but got Unknown
		//IL_0939: Unknown result type (might be due to invalid IL or missing references)
		//IL_093e: Expected O, but got Unknown
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_098b: Expected O, but got Unknown
		//IL_09d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d8: Expected O, but got Unknown
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a03: Expected O, but got Unknown
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a42: Expected O, but got Unknown
		//IL_0a7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a81: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d7: Expected O, but got Unknown
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Expected O, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Expected O, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Expected O, but got Unknown
		//IL_069f: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Expected O, but got Unknown
		//IL_0708->IL0ab1: Incompatible stack heights: 8 vs 0
		//IL_0725->IL074c: Incompatible stack heights: 8 vs 0
		//IL_0738->IL0ab1: Incompatible stack heights: 8 vs 0
		if (_hasTerraceBeenOpened)
		{
			return;
		}
		_hasTerraceBeenOpened = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1073741824;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -500f;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp+10]");
		soundConfig.Volume = (float?)(object)0;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._tilingTileset != null)
			{
				Tilemap tilemapLayer = stage._tilingTileset.GetTilemapLayer("Walls");
				if ((object)tilemapLayer == null || !((SoundManager.SoundConfig)(object)tilemapLayer).Mute)
				{
					Debug.LogError("Wall not found");
					return;
				}
				_ = 31;
				_ = 4294967281L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
				_ = 0;
				_ = 0;
				bool flag = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rcx_v60 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj2 = default(object);
				object obj = obj2 - 32;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj, (IntPtr)0);
				_ = 32;
				_ = 4294967281L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				bool flag2 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rcx_v64 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj3 = obj2 - 16;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj3, (IntPtr)0);
				_ = 31;
				_ = 4294967280L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
				_ = 0;
				_ = 0;
				bool flag3 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rcx_v68 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj4 = obj2 - 32;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj4, (IntPtr)0);
				_ = 32;
				_ = 4294967280L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				bool flag4 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1060 @ rcx_v72 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj5 = obj2 - 16;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj5, (IntPtr)0);
				_ = 31;
				_ = 4294967279L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
				_ = 0;
				_ = 0;
				bool flag5 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rcx_v76 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj6 = obj2 - 32;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj6, (IntPtr)0);
				_ = 32;
				_ = 4294967279L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				bool flag6 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1320 @ rcx_v80 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj7 = obj2 - 16;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj7, (IntPtr)0);
				_ = 31;
				_ = 4294967278L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-20]");
				_ = 0;
				_ = 0;
				bool flag7 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1375 @ rcx_v84 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj8 = obj2 - 32;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj8, (IntPtr)0);
				_ = 32;
				_ = 4294967278L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				bool flag8 = (byte)(~(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1u : 0u)) != 0;
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1430 @ rcx_v88 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				object obj9 = obj2 - 16;
				Tilemap.SetTileAsset_Injected((IntPtr)(((SoundManager.SoundConfig)(object)tilemapLayer).Mute ? 1 : 0), ref *(Vector3Int*)obj9, (IntPtr)0);
				_ = 31;
				Vector3Int position = (Vector3Int)(obj2 - 16);
				_ = 4294967277L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position, null);
				_ = 32;
				Vector3Int position2 = (Vector3Int)(obj2 - 16);
				_ = 4294967277L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position2, null);
				_ = 31;
				Vector3Int position3 = (Vector3Int)(obj2 - 16);
				_ = 4294967276L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position3, null);
				_ = 32;
				Vector3Int position4 = (Vector3Int)(obj2 - 16);
				_ = 4294967276L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position4, null);
				_ = 31;
				Vector3Int position5 = (Vector3Int)(obj2 - 16);
				_ = 4294967275L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position5, null);
				_ = 32;
				Vector3Int position6 = (Vector3Int)(obj2 - 16);
				_ = 4294967275L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position6, null);
				_ = 30;
				Vector3Int position7 = (Vector3Int)(obj2 - 16);
				_ = 4294967279L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position7, null);
				_ = 33;
				_ = 4294967279L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				Vector3Int position8 = (Vector3Int)(obj2 - 16);
				tilemapLayer.SetTile(position8, null);
				_ = 30;
				Vector3Int position9 = (Vector3Int)(obj2 - 16);
				_ = 4294967278L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position9, null);
				_ = 33;
				Vector3Int position10 = (Vector3Int)(obj2 - 16);
				_ = 4294967278L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position10, null);
				_ = 30;
				Vector3Int position11 = (Vector3Int)(obj2 - 16);
				_ = 4294967277L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position11, null);
				_ = 33;
				Vector3Int position12 = (Vector3Int)(obj2 - 16);
				_ = 4294967277L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position12, null);
				_ = 30;
				Vector3Int position13 = (Vector3Int)(obj2 - 16);
				_ = 4294967276L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position13, null);
				_ = 33;
				Vector3Int position14 = (Vector3Int)(obj2 - 16);
				_ = 4294967276L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position14, null);
				_ = 30;
				Vector3Int position15 = (Vector3Int)(obj2 - 16);
				_ = 4294967275L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position15, null);
				_ = 33;
				Vector3Int position16 = (Vector3Int)(obj2 - 16);
				_ = 4294967275L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-10]");
				_ = 0;
				_ = 0;
				tilemapLayer.SetTile(position16, null);
				PhaserTilemap component = tilemapLayer.GetComponent<PhaserTilemap>();
				if (!(component != null))
				{
					return;
				}
				if ((object)component != null)
				{
					component.RefreshData();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public Background5()
	{
		List<SpriteRenderer> purpleClouds = new List<SpriteRenderer>();
		_purpleClouds = purpleClouds;
		_movingBgTweens = new List<MultiTargetTween>();
		_playerEquipment = new List<EquipmentInfo>();
		_useReaperMinuteCheck = true;
		base._002Ector();
	}

	private void _003CCreate_003Eb__49_0()
	{
		//IL_0165->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_00ac->IL00e5: Incompatible stack heights: 1 vs 0
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
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && (object)core2._stage != null)
					{
						Vector2 spawnPos = default(Vector2);
						bool forceSpawn = default(bool);
						GameObject enemy = core2._stage.SpawnEnemy(EnemyType.BOSS_MADDENER_NORMAL, spawnPos, asRemote: false, forceSpawn);
						OnMaddenerSpawned(enemy);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void _003CEnterTheBossi_003Eb__70_1()
	{
		GameManager core = GM.Core;
		Stage stage = core._stage;
		List<Vector2> destructibleLocations = stage._destructibleLocations;
		if (stage._destructibleLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v6 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		RemoveWalls();
		FadeOutSky();
	}

	private void _003CFadeOutSky_003Eb__72_2()
	{
		PowerOfFriendshipGoPlanet();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = BgmType.TheEndIntro;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GM.Core.SetupMusicBanger(loop: false);
		PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
		PlaylistController.SongEndedEventHandler value = delegate
		{
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			PlaylistController onlyPlaylistController2 = MasterAudio.OnlyPlaylistController;
			PlaylistController.SongEndedEventHandler value2 = _003CFadeOutSky_003Eg__OnIntroEnded_007C72_4;
			onlyPlaylistController2.SongEnded -= value2;
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			config3._003CSelectedBGM_003Ek__BackingField = BgmType.TheEndMain;
			GM.Core.SetupMusicBanger();
		};
		onlyPlaylistController.SongEnded += value;
	}

	internal static void _003CFadeOutSky_003Eg__OnIntroEnded_007C72_4(string songName)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		PlaylistController onlyPlaylistController = MasterAudio.OnlyPlaylistController;
		PlaylistController.SongEndedEventHandler value = _003CFadeOutSky_003Eg__OnIntroEnded_007C72_4;
		onlyPlaylistController.SongEnded -= value;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = BgmType.TheEndMain;
		GM.Core.SetupMusicBanger();
	}

	private void _003CFadeOutSky_003Eb__72_3()
	{
		//IL_025f->IL01b5: Incompatible stack heights: 1 vs 0
		//IL_0146->IL01b5: Incompatible stack heights: 1 vs 0
		//IL_0281->IL01b4: Incompatible stack heights: 1 vs 0
		//IL_01a0->IL01b4: Incompatible stack heights: 1 vs 0
		//IL_01b4->IL01b4: Incompatible stack heights: 1 vs 0
		EnterPurpleSky();
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._lootManager != null)
		{
			core._lootManager.SetPlainLootTable();
			Transform ender = (Transform)(object)_ender;
			if ((object)_ender != null && ((UnityEngine.Object)ender).m_CachedPtr != (IntPtr)0)
			{
				return;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core2._gameSessionData;
				if (core2._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform = gameSessionData._activeCharacter.transform;
					if ((object)transform != null)
					{
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null && (object)core3._stage != null)
						{
							Vector2 spawnPos = default(Vector2);
							bool forceSpawn = default(bool);
							GameObject gameObject = core3._stage.SpawnEnemy(EnemyType.BOSS_ENDER, spawnPos, asRemote: false, forceSpawn);
							if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
							{
								OnEnderSpawned(gameObject);
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void _003CEnterPurpleSky_003Eb__76_3()
	{
		Camera mainCamera = _mainCamera;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		bool flag = ((UnityEngine.Object)mainCamera).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Camera.set_backgroundColor_Injected(((UnityEngine.Object)mainCamera).m_CachedPtr, ref *(Color*)(&value));
	}

	private void _003CEnterPurpleSky_003Eb__76_4()
	{
		_skyLights.SetVisible(visible: false);
		_floorLights.SetVisible(visible: false);
	}

	private void _003CFadeOutPurpleSky_003Eb__77_0()
	{
		_TintHelp = 1f;
	}

	private unsafe void _003CFadeOutPurpleSky_003Eb__77_1()
	{
		Camera mainCamera = _mainCamera;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		bool flag = ((UnityEngine.Object)mainCamera).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Camera.set_backgroundColor_Injected(((UnityEngine.Object)mainCamera).m_CachedPtr, ref *(Color*)(&value));
	}

	private void _003CFadeToMad_003Eb__79_0()
	{
		ToggleBlue(visible: false);
		ToggleRed(visible: true);
		ToggleAlias(toggle: true);
		EnemyMaddenerNormal maddener = _maddener;
		base._003CAlias_003Ek__BackingField = true;
		if ((object)_maddener != null && ((UnityEngine.Object)maddener).m_CachedPtr != (IntPtr)0)
		{
			EnemyMaddenerNormal maddener2 = _maddener;
			Action action = RevertMad;
			maddener2._003COnDefeat_003Ek__BackingField = action;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_whiteFader, 0f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	private void _003CRevertMad_003Eb__80_0()
	{
		ToggleBlue(visible: true);
		ToggleRed(visible: false);
		ToggleAlias(toggle: false);
		base._003CAlias_003Ek__BackingField = false;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_whiteFader, 0f, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}
}
