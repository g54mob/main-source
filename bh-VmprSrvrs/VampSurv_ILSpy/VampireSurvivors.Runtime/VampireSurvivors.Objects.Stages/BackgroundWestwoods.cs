using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using I2.Loc;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundWestwoods : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<Action> _003C_003E9__27_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CCustomPreload_003Eb__27_0(Action cb)
		{
			//IL_0029: Expected I4, but got O
			//IL_0046: Expected O, but got I4
			_003C_003Ec__DisplayClass27_0 obj = new _003C_003Ec__DisplayClass27_0();
			obj.cb = cb;
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass27_0)(object)action)._003CCustomPreload_003Eb__1((byte)(int)obj != 0);
			SpriteLoader.LoadTextureAsync("wheelOfFortune3", "Gameplay", (DlcType?)(object)0, action);
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public Action cb;

		internal void _003CCustomPreload_003Eb__1(bool x)
		{
			Action action = cb;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private WestwoodsBounds _westwoodsBounds;

	private WestwoodsBounds.WestwoodsZone _currentUnlockedZone;

	private WestwoodsTrisectionManager _westwoodsTrisection;

	private WestwoodsWaterHue _westwoodsWaterHue;

	private PickupCustomMerchant _giacoreMerchant;

	private bool _giacoreRunning;

	private Vector3 _giacoreStartPosition;

	private Vector3 _giacoreTargetPosition;

	private float _giacoreRunTimer;

	private const float GiacoreRunDuration = 5f;

	private const string Zone1BarrierLayer = "Shadows";

	private const string Zone2BarrierLayer = "ShadowDecals";

	private float _barrier1Alpha = 1f;

	private float _barrier2Alpha = 1f;

	private bool _barrierFadeActive;

	private float _barrierFadeTimer;

	private Tilemap _barrier1Tilemap;

	private Tilemap _barrier2Tilemap;

	private const float BarrierFadeDuration = 0.5f;

	private const float Zone2MerchantXOffset = 14.3488f;

	private const float Zone3MerchantXOffset = 10.1f;

	private const string BACKGROUND_WESTWOODS = "background_westwoods_grayscale";

	private PhaserSprite _waterAnim;

	private TileSprite _water;

	private CustomActionInventoryItem _secretinoShopItem;

	public override bool HasCustomMadGrooveRestriction()
	{
		return true;
	}

	public override bool IsPositionPulledByMadGroove(float2 position)
	{
		//IL_01bf: Expected I4, but got O
		//IL_0139: Invalid comparison between O and F4
		//IL_0160: Invalid comparison between F4 and O
		//IL_0183: Invalid comparison between F4 and I4
		//IL_00b5: Invalid comparison between F4 and O
		//IL_00d9: Invalid comparison between O and F4
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		WestwoodsBounds.WestwoodsZone currentUnlockedZone = _currentUnlockedZone;
		WestwoodsBounds westwoodsBounds = _westwoodsBounds;
		float[] array = ((!westwoodsBounds._isStageInverse) ? westwoodsBounds._boundsXLimits : westwoodsBounds._inverseBoundsXLimits);
		if ((int)_currentUnlockedZone < array.Length)
		{
			if (westwoodsBounds._isStageInverse)
			{
				float num = array[(int)currentUnlockedZone];
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
				{
					bool flag = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)westwoodsBounds._inverseStaticBoundsLimit);
					object obj = position - westwoodsBounds._inverseStaticBoundsLimit;
					bool flag2 = obj == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
			else if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)array[(int)currentUnlockedZone]))
			{
				float staticBoundsLimit = westwoodsBounds._staticBoundsLimit;
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)staticBoundsLimit) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
				float num2 = westwoodsBounds._staticBoundsLimit - (float)position;
				bool flag6 = num2 == 0f;
				bool flag7 = !flag5;
				bool flag8 = !flag6;
				return flag8 & flag7;
			}
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public override void CustomPreload(Action onComplete)
	{
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		Action<Action> loadCall = _003C_003Ec._003C_003E9__27_0;
		if (_003C_003Ec._003C_003E9__27_0 == null)
		{
			loadCall = (_003C_003Ec._003C_003E9__27_0 = delegate(Action cb)
			{
				//IL_0029: Expected I4, but got O
				//IL_0046: Expected O, but got I4
				_003C_003Ec__DisplayClass27_0 obj = new _003C_003Ec__DisplayClass27_0();
				obj.cb = cb;
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass27_0)(object)action)._003CCustomPreload_003Eb__1((byte)(int)obj != 0);
				SpriteLoader.LoadTextureAsync("wheelOfFortune3", "Gameplay", (DlcType?)(object)0, action);
			});
		}
		asyncLoader.Add(loadCall);
		asyncLoader.Load();
	}

	public override void Create()
	{
		//IL_016c: Expected O, but got I4
		//IL_0268: Expected O, but got I4
		//IL_0268: Expected O, but got I
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_034a: Expected O, but got I
		base.Create();
		GameManager core = GM.Core;
		Stage stage = core._stage;
		GameObject gameObject;
		if ((object)stage._tilingTileset != null)
		{
			GameObject defaultSupportMap = stage._tilingTileset.DefaultSupportMap;
			gameObject = defaultSupportMap;
		}
		else
		{
			gameObject = null;
		}
		if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config = core2._playerOptions.Config;
			_currentUnlockedZone = (WestwoodsBounds.WestwoodsZone)config._003CWW_ZoneProgress_003Ek__BackingField;
			if (!InitBounds(gameObject))
			{
				return;
			}
			bool flag = InitWater(gameObject);
			Tilemap tilemap = GetTilemap("Shadows");
			_barrier1Tilemap = tilemap;
			Tilemap tilemap2 = GetTilemap("ShadowDecals");
			_barrier2Tilemap = tilemap2;
			bool flag2 = _currentUnlockedZone == WestwoodsBounds.WestwoodsZone.One;
			if (!flag2)
			{
				object obj = _currentUnlockedZone - 1;
				Tilemap tilemap3;
				if (!flag2)
				{
					if ((nint)obj != 1)
					{
						ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
						throw ex;
					}
					SetTilemapAlpha(_barrier1Tilemap, 0f);
					tilemap3 = _barrier2Tilemap;
				}
				else
				{
					tilemap3 = _barrier1Tilemap;
				}
				SetTilemapAlpha(tilemap3, 0f);
			}
			InitWestwoodsTrisection();
			Action<OnlineSignals.WestwoodsSpin> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA62D0");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rbx_v9 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			object obj2 = null;
			Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.WestwoodsSpin>)obj2)._003CSubscribeId_003Eb__0;
			((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.WestwoodsSpin>)0)._003CSubscribeId_003Eb__0((object)1);
			object obj4 = default(object);
			object obj3 = obj4 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			SignalBus signalBus = _signalBus;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v47 (System.Object)+10]");
			Type signalType = default(Type);
			Action<object> callback = default(Action<object>);
			signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
			SpawnGiocareMerchant(_currentUnlockedZone);
		}
		else
		{
			Exception exception = new Exception("Couldn't find support map");
			Debug.LogException(exception);
		}
	}

	protected override void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Action<OnlineSignals.WestwoodsSpin> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA62D0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		base.OnDestroy();
	}

	private void OnWestwoodsSpin(OnlineSignals.WestwoodsSpin spin)
	{
		_westwoodsTrisection.ShowCircles();
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		object obj = (object)spin << 13;
		object obj2 = obj ^ (object)spin;
		object obj3 = obj2 >> 17;
		object obj4 = obj2 ^ obj3;
		object obj5 = obj4 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj5 ^ obj4);
		((StageEventTrisectionManager)westwoodsTrisection)._eventsRng = eventsRng;
		Action onComplete = delegate
		{
			Action onEventSelected = delegate
			{
				Action onComplete2 = delegate
				{
					WestwoodsTrisectionManager westwoodsTrisection2 = _westwoodsTrisection;
					westwoodsTrisection2._isIdle = true;
					_westwoodsTrisection.TriggerTrisectionEvent();
					WestwoodsTrisectionManager westwoodsTrisection3 = _westwoodsTrisection;
					StageEventTrisectionManager.WeightedTrisectionEventData nextChosenEvent = ((StageEventTrisectionManager)westwoodsTrisection3)._nextChosenEvent;
					TrisectionEvent ev = nextChosenEvent.ev;
					StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField);
					if (stageEventType == StageEventType.LUCK_BOOST)
					{
						Action onUnlockZoneEvent = westwoodsTrisection3.OnUnlockZoneEvent;
						if (westwoodsTrisection3.OnUnlockZoneEvent != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					}
					else
					{
						PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
						if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0)
						{
							PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
							((Pickup)giacoreMerchant2)._003CDisableGet_003Ek__BackingField = false;
						}
					}
				};
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				Timer timer2 = Timers.Register(0.25f, onComplete2, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
			};
			_westwoodsTrisection.Spinnn(5000f, null, onEventSelected);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0066: Expected I, but got O
		//IL_004a: Expected I, but got O
		//IL_00da: Expected F4, but got I4
		//IL_0281: Expected I, but got O
		//IL_0312: Expected I, but got O
		//IL_0819: Expected O, but got I4
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Expected Ref, but got Unknown
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Expected Ref, but got Unknown
		//IL_06d8: Invalid comparison between I4 and F4
		//IL_0723: Expected F4, but got I4
		//IL_0479: Expected F4, but got O
		//IL_053e: Expected F4, but got I
		//IL_085e->IL0ab8: Incompatible stack heights: 1 vs 0
		//IL_0ab8->IL0a5a: Incompatible stack heights: 1 vs 0
		//IL_0a5a->IL09c3: Incompatible stack heights: 2 vs 0
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		nint num;
		if ((object)_giacoreMerchant != null)
		{
			bool flag = ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0;
			num = (nint)typeof(UnityEngine.Object);
			if (flag)
			{
				goto IL_08b9;
			}
		}
		nint num2 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v105 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		num = 0;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			List<Pickup> stagePickups = core._stagePickups;
			if (core._stagePickups != null)
			{
				List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
				while (enumerator.MoveNext())
				{
					float num3 = 0f;
				}
				num = (nint)(&enumerator);
				goto IL_08b9;
			}
		}
		goto IL_087a;
		IL_08b9:
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		if (_westwoodsTrisection != null)
		{
			if (westwoodsTrisection.queuedSpins > 0 && westwoodsTrisection._isIdle)
			{
				TriggerMinigameTrisection();
				num = (nint)_westwoodsTrisection;
				if (_westwoodsTrisection == null)
				{
					goto IL_087a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rcx_v24 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1D8]");
				_ = -1;
			}
			TileSprite water = _water;
			if ((object)_water == null || ((UnityEngine.Object)water).m_CachedPtr == (IntPtr)0)
			{
				goto IL_0549;
			}
			PhaserSprite waterAnim = _waterAnim;
			bool flag2 = (object)_waterAnim == null;
			num = (nint)typeof(UnityEngine.Object);
			if (!flag2 && (object)waterAnim._spriteRenderer != null)
			{
				Sprite sprite = waterAnim._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					string frameName = ((UnityEngine.Object)sprite).GetName();
					if ((object)_water != null)
					{
						_water.SetFrame(frameName, "background_westwoods_grayscale");
						PickupCustomMerchant water2 = (PickupCustomMerchant)(object)_water;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer = s_scene._renderer;
								if (s_scene._renderer != null && (object)_water != null)
								{
									water2._parentContainer = (PhaserContainer)renderer.screenCenter;
									if (((PhaserGameObject)water2)._scene != null)
									{
										((SpriteScroller)(object)((PhaserGameObject)water2)._scene).SetScrollOffsetX((float)renderer.screenCenter);
										PickupCustomMerchant water3 = (PickupCustomMerchant)(object)_water;
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene2 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer2 = s_scene2._renderer;
												if (s_scene2._renderer != null && (object)_water != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v92 (PhaserScene+Renderer)+38]");
													_ = 0;
													if (((PhaserGameObject)water3)._scene != null)
													{
														PhaserScene phaserScene = ((PhaserGameObject)water3)._scene;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v92 (PhaserScene+Renderer)+38]");
														((SpriteScroller)(object)phaserScene).SetScrollOffsetY(0f);
														List<Pickup> stagePickups = null;
														goto IL_0549;
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
		goto IL_087a;
		IL_0549:
		if (_westwoodsTrisection != null)
		{
			_westwoodsTrisection.TrisectionUpdate();
		}
		if (_westwoodsTrisection != null)
		{
			_westwoodsTrisection.UpdateTrisectionAudio();
		}
		if (_giacoreRunning)
		{
			PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
			if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant2).m_CachedPtr != (IntPtr)0)
			{
				float deltaTime = PauseSystem.DeltaTime;
				Vector3 value = default(Vector3);
				if ((_giacoreRunTimer = deltaTime + _giacoreRunTimer) < 5f)
				{
					if ((object)GM.Core != null)
					{
						if (GM.Core.IsStageHost)
						{
							if ((object)_giacoreMerchant == null)
							{
								goto IL_087a;
							}
							Transform transform = _giacoreMerchant.transform;
							float num4 = _giacoreRunTimer / 5f;
							if (!(0f > num4))
							{
								if (num4 > 1f)
								{
									num4 = 1f;
								}
							}
							else
							{
								num4 = 0f;
							}
							bool flag3 = (object)transform == null;
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						}
						goto IL_09c3;
					}
				}
				else
				{
					_giacoreRunning = false;
					if ((object)GM.Core != null)
					{
						if (GM.Core.IsStageHost)
						{
							Transform transform2 = _giacoreMerchant.transform;
							bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
						}
						PickupCustomMerchant giacoreMerchant3 = _giacoreMerchant;
						if ((object)_giacoreMerchant != null)
						{
							giacoreMerchant3._facePlayer = true;
							PickupCustomMerchant giacoreMerchant4 = _giacoreMerchant;
							if ((object)_giacoreMerchant != null)
							{
								((Pickup)giacoreMerchant4)._003CDisableGet_003Ek__BackingField = false;
								goto IL_09c3;
							}
						}
					}
				}
				goto IL_087a;
			}
		}
		goto IL_09c3;
		IL_087a:
		throw new NullReferenceException();
		IL_09c3:
		if (!_barrierFadeActive)
		{
			return;
		}
		bool flag6 = _currentUnlockedZone == WestwoodsBounds.WestwoodsZone.One;
		if (!flag6)
		{
			object obj = _currentUnlockedZone - 1;
			ref float barrierAlpha;
			Tilemap tilemaps;
			if (!flag6)
			{
				bool flag7 = (nint)obj != 1;
				barrierAlpha = ref *(float*)(this + 204);
				tilemaps = _barrier2Tilemap;
			}
			else
			{
				barrierAlpha = ref *(float*)(this + 200);
				tilemaps = _barrier1Tilemap;
			}
			_003COnUpdate_003Eg__FadeBarrier_007C31_0(ref barrierAlpha, tilemaps);
		}
	}

	public void TriggerMinigameTrisection()
	{
		//IL_0197: Expected I4, but got I8
		//IL_019b: Expected O, but got I4
		//IL_01e3: Expected I4, but got I8
		//IL_01e7: Expected O, but got I4
		if (!GM.Core.IsStageHost)
		{
			return;
		}
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		westwoodsTrisection._isIdle = false;
		Debug.Log("TriggerMinigameTrisection!");
		GameManager core = GM.Core;
		bool flag = default(bool);
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			object obj = UnityEngine.Random.RandomRangeInt(-2147483648, 2147483647);
			_westwoodsTrisection.ShowCircles();
			WestwoodsTrisectionManager westwoodsTrisection2 = _westwoodsTrisection;
			object obj2 = obj << 13;
			object obj3 = obj2 ^ obj;
			object obj4 = obj3 >> 17;
			object obj5 = obj3 ^ obj4;
			object obj6 = obj5 << 5;
			Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj6 ^ obj5);
			((StageEventTrisectionManager)westwoodsTrisection2)._eventsRng = eventsRng;
			Action onComplete = delegate
			{
				Action onEventSelected = delegate
				{
					Action onComplete2 = delegate
					{
						WestwoodsTrisectionManager westwoodsTrisection3 = _westwoodsTrisection;
						westwoodsTrisection3._isIdle = true;
						_westwoodsTrisection.TriggerTrisectionEvent();
						WestwoodsTrisectionManager westwoodsTrisection4 = _westwoodsTrisection;
						StageEventTrisectionManager.WeightedTrisectionEventData nextChosenEvent = ((StageEventTrisectionManager)westwoodsTrisection4)._nextChosenEvent;
						TrisectionEvent ev = nextChosenEvent.ev;
						StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField);
						if (stageEventType == StageEventType.LUCK_BOOST)
						{
							Action onUnlockZoneEvent = westwoodsTrisection4.OnUnlockZoneEvent;
							if (westwoodsTrisection4.OnUnlockZoneEvent != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						}
						else
						{
							PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
							if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0)
							{
								PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
								((Pickup)giacoreMerchant2)._003CDisableGet_003Ek__BackingField = false;
							}
						}
					};
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
					int repeat2 = default(int);
					TimerType type2 = default(TimerType);
					Timer timer2 = Timers.Register(0.25f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				};
				_westwoodsTrisection.Spinnn(5000f, null, onEventSelected);
			};
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		else
		{
			OnlineStageManager instance = OnlineStageManager._instance;
			Action<long, int> action = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			object obj7 = UnityEngine.Random.RandomRangeInt(-2147483648, 2147483647);
			bool flag2 = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, flag ? 1 : 0);
		}
	}

	private void OnMinigameSuccess()
	{
		//IL_02f9->IL01de: Incompatible stack heights: 1 vs 0
		//IL_0162->IL0162: Incompatible stack heights: 1 vs 0
		//IL_0329->IL034d: Incompatible stack heights: 1 vs 0
		//IL_0291->IL0229: Incompatible stack heights: 1 vs 0
		if (_currentUnlockedZone == WestwoodsBounds.WestwoodsZone.Three)
		{
			goto IL_0162;
		}
		UnlockNextZone(saveProgress: true);
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		Vector3 ret;
		if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0)
		{
			PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
			if ((object)_giacoreMerchant != null)
			{
				giacoreMerchant2._facePlayer = false;
				if ((object)_giacoreMerchant != null)
				{
					ArcadeSprite arcadeSprite = _giacoreMerchant.setFlipX(flipX: true);
					if ((object)_giacoreMerchant != null)
					{
						Transform transform = _giacoreMerchant.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
							_giacoreStartPosition = ret;
							_ = 0;
							goto IL_0229;
						}
					}
				}
			}
			goto IL_01de;
		}
		goto IL_0229;
		IL_0162:
		PickupCustomMerchant giacoreMerchant3 = _giacoreMerchant;
		if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant3).m_CachedPtr != (IntPtr)0)
		{
			PickupCustomMerchant giacoreMerchant4 = _giacoreMerchant;
			if ((object)_giacoreMerchant != null)
			{
				((Pickup)giacoreMerchant4)._003CDisableGet_003Ek__BackingField = false;
				return;
			}
			goto IL_01de;
		}
		return;
		IL_0229:
		if (_currentUnlockedZone == WestwoodsBounds.WestwoodsZone.Two)
		{
		}
		if ((object)_giacoreMerchant != null)
		{
			Transform transform2 = _giacoreMerchant.transform;
			if ((object)transform2 != null)
			{
				bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
				if ((object)GM.Core != null)
				{
					if (GM.Core.IsStageVisuallyInverted())
					{
						_giacoreRunTimer = 0f;
						_giacoreRunning = true;
						Vector3 giacoreTargetPosition = default(Vector3);
						_giacoreTargetPosition = giacoreTargetPosition;
						_ = 0;
						return;
					}
					goto IL_0162;
				}
			}
		}
		goto IL_01de;
		IL_01de:
		throw new NullReferenceException();
	}

	private bool InitBounds(GameObject support)
	{
		//IL_0126: Expected I4, but got O
		if ((object)support != null)
		{
			WestwoodsBounds componentInChildren = support.GetComponentInChildren<WestwoodsBounds>(includeInactive: false);
			_westwoodsBounds = componentInChildren;
			WestwoodsBounds westwoodsBounds = _westwoodsBounds;
			if ((object)_westwoodsBounds == null || ((UnityEngine.Object)westwoodsBounds).m_CachedPtr == (IntPtr)0)
			{
				Debug.LogError("Couldn't find WestwoodsBounds component on tileset support prefab, something's gone wrong!");
				return false;
			}
			WestwoodsBounds westwoodsBounds2 = _westwoodsBounds;
			if ((object)GM.Core != null)
			{
				bool isStageInverse = GM.Core.IsStageVisuallyInverted();
				if ((object)_westwoodsBounds != null)
				{
					westwoodsBounds2._isStageInverse = isStageInverse;
					if ((object)_westwoodsBounds != null)
					{
						_westwoodsBounds.EnableBoundsForZone(_currentUnlockedZone);
						return true;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void InitWestwoodsTrisection()
	{
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._diContainer != null)
		{
			WestwoodsTrisectionManager westwoodsTrisection = core._diContainer.Instantiate<WestwoodsTrisectionManager>();
			_westwoodsTrisection = westwoodsTrisection;
			if (_westwoodsTrisection != null)
			{
				_westwoodsTrisection.Initialize();
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && _westwoodsTrisection != null)
				{
					_westwoodsTrisection.Init(core2._stage);
					WestwoodsTrisectionManager westwoodsTrisection2 = _westwoodsTrisection;
					Action b = OnMinigameSuccess;
					if (_westwoodsTrisection != null)
					{
						Delegate obj = westwoodsTrisection2.OnUnlockZoneEvent;
						object obj2 = _westwoodsTrisection + 456;
						while (true)
						{
							Delegate obj3 = Delegate.Combine(obj, b);
							bool flag = (object)obj3 == null;
							Delegate obj4 = null;
							if (!flag)
							{
								bool flag2 = (object)obj3.GetType() != typeof(Action);
								obj4 = null;
								if (!flag2)
								{
									obj4 = obj3;
								}
								if ((object)obj4 == null)
								{
									break;
								}
							}
							bool flag3 = obj == obj2;
							Delegate obj5;
							if (obj == obj2)
							{
								obj2 = obj4;
								obj5 = obj;
							}
							else
							{
								obj5 = (Delegate)obj2;
							}
							Delegate obj6 = obj;
							if (!flag3)
							{
								obj6 = obj5;
							}
							bool flag4 = (object)obj6 != obj;
							obj = obj6;
							if (!flag4)
							{
								return;
							}
						}
						goto IL_028e;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_028e;
		IL_028e:
		throw new InvalidCastException();
	}

	private bool InitWater(GameObject support)
	{
		//IL_04f0: Expected I4, but got O
		//IL_024b: Expected O, but got I4
		//IL_0410: Expected O, but got I
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "background_westwoods_grayscale", "waterF1");
			if ((object)phaserSprite != null)
			{
				PhaserSprite waterAnim = phaserSprite.setVisible(visible: false);
				_waterAnim = waterAnim;
				int num = default(int);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("waterF", 1, 8, "background_westwoods_grayscale", num);
				PhaserSprite waterAnim2 = _waterAnim;
				if ((object)_waterAnim != null && (object)waterAnim2._spriteAnimation != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					waterAnim2._spriteAnimation.AddAnimation("loop", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
					PhaserSprite waterAnim3 = _waterAnim;
					if ((object)_waterAnim != null && (object)waterAnim3._spriteAnimation != null)
					{
						waterAnim3._spriteAnimation.SetAnimation("loop");
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
											float y = renderer2.height * 0.5f;
											float x = renderer.width * 0.5f;
											GameObject go = base.gameObject;
											TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, x, y, "background_westwoods_grayscale", (string)num);
											if (tileSpriteBuilder != null)
											{
												tileSpriteBuilder._depth = -10001f;
												tileSpriteBuilder._depthMul = 1f;
												Transform parent = base.transform;
												tileSpriteBuilder._parent = parent;
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene3 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserScene.Renderer renderer3 = s_scene3._renderer;
														if (s_scene3._renderer != null && (object)GM.Core != null)
														{
															PhaserScene s_scene4 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null)
															{
																PhaserScene.Renderer renderer4 = s_scene4._renderer;
																if (s_scene4._renderer != null)
																{
																	tileSpriteBuilder._tileHeight = renderer4.height;
																	tileSpriteBuilder._tileWidth = renderer3.width;
																	tileSpriteBuilder._name = "Water";
																	TileSprite water = tileSpriteBuilder.Build();
																	_water = water;
																	TileSprite tileSprite = RenderingExtensions.SetScrollFactor(_water, 0f);
																	if ((object)support != null)
																	{
																		nint num2 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rbx_v4 (Il2CppMethodInfo)+38]");
																		if ((nint)0 == 0)
																		{
																			TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor((TileSprite)0, 0f);
																		}
																		WestwoodsWaterHue componentInChildren = support.GetComponentInChildren<WestwoodsWaterHue>(includeInactive: false);
																		_westwoodsWaterHue = componentInChildren;
																		WestwoodsWaterHue westwoodsWaterHue = _westwoodsWaterHue;
																		if ((object)_westwoodsWaterHue == null || ((UnityEngine.Object)westwoodsWaterHue).m_CachedPtr == (IntPtr)0)
																		{
																			Debug.LogError("Couldn't find WestwoodsWaterHue component on tileset support prefab, something's gone wrong!");
																			return false;
																		}
																		WestwoodsWaterHue westwoodsWaterHue2 = _westwoodsWaterHue;
																		if ((object)_westwoodsWaterHue != null)
																		{
																			westwoodsWaterHue2._waterTileSprite = _water;
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
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void SpawnGiocareMerchant(WestwoodsBounds.WestwoodsZone currentUnlockedZone)
	{
		//IL_078e: Expected I, but got O
		//IL_07bf: Expected O, but got I
		//IL_0099: Expected I, but got O
		//IL_00ca: Expected O, but got I
		//IL_012f: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_020a: Expected I, but got O
		//IL_023b: Expected O, but got I
		//IL_0272: Expected O, but got I
		//IL_074b: Expected O, but got Ref
		//IL_06b8: Expected O, but got Ref
		//IL_091b->IL0773: Incompatible stack heights: 1 vs 0
		//IL_0598->IL0920: Incompatible stack heights: 1 vs 0
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		MultiplayerManager multiplayerManager = (MultiplayerManager)num2;
		float2 position3;
		ArcadeSprite arcadeSprite;
		PickupCustomMerchant giacoreMerchant;
		if (!flag)
		{
			multiplayerManager = core._multiplayer;
			if (core._multiplayer != null)
			{
				if (core._multiplayer.IsOnlineMultiplayer)
				{
					bool flag2 = (object)OnlineStageManager._instance == null;
					multiplayerManager = (MultiplayerManager)(object)OnlineStageManager._instance;
					if (flag2)
					{
						goto IL_0773;
					}
					if (!OnlineStageManager._instance.IsHost)
					{
						return;
					}
				}
				nint num3 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ rax_v19 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				nint num4 = 0;
				GameManager core2 = GM.Core;
				bool flag3 = (object)GM.Core == null;
				multiplayerManager = (MultiplayerManager)num4;
				if (!flag3)
				{
					List<CharacterType> list = new List<CharacterType>();
					bool flag4 = list == null;
					multiplayerManager = (MultiplayerManager)(object)list;
					if (!flag4)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						multiplayerManager = (MultiplayerManager)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
							if (0 >= (nint)multiplayerManager._signalBus)
							{
								((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)169);
								multiplayerManager = (MultiplayerManager)(object)list;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								object obj = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v630 @ rax_v21 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
								if (0 >= (nint)multiplayerManager._signalBus)
								{
									throw new IndexOutOfRangeException();
								}
								_ = 169;
							}
							if ((object)core2._stage != null)
							{
								core2._stage.SpawnCustomMerchants(list);
								nint num5 = (nint)typeof(GM);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v26 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
								nint num6 = 0;
								GameManager core3 = GM.Core;
								bool flag5 = (object)GM.Core == null;
								multiplayerManager = (MultiplayerManager)num6;
								if (!flag5)
								{
									List<Pickup> stagePickups = core3._stagePickups;
									bool flag6 = core3._stagePickups == null;
									multiplayerManager = (MultiplayerManager)num6;
									if (!flag6)
									{
										List<Pickup>.Enumerator ret = (List<Pickup>.Enumerator)core3._stagePickups;
										List<Pickup>.Enumerator enumerator = default(List<Pickup>.Enumerator);
										while (enumerator.MoveNext())
										{
											List<CharacterType> list2 = null;
										}
										GameManager core4 = GM.Core;
										if ((object)GM.Core != null)
										{
											Stage stage = core4._stage;
											if ((object)core4._stage != null)
											{
												bool flag7 = (object)stage._tilingTileset == null;
												UnityEngine.Object obj2 = null;
												if (!flag7)
												{
													List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("GIOCARE");
													SuperObject superObject = Enumerable.FirstOrDefault(scriptsFromName);
													stagePickups = null;
													obj2 = superObject;
												}
												if (!obj2)
												{
													goto IL_0767;
												}
												float2 float5 = default(float2);
												List<CharacterType> list3 = default(List<CharacterType>);
												if (currentUnlockedZone == WestwoodsBounds.WestwoodsZone.Two)
												{
													if ((object)GM.Core != null)
													{
														bool flag8 = GM.Core.IsStageVisuallyInverted();
														if ((object)obj2 != null)
														{
															if (flag8)
															{
																Transform transform = ((Component)obj2).transform;
																if ((object)transform == null)
																{
																	goto IL_0773;
																}
																Vector3 position = transform.position;
															}
															else
															{
																Transform transform2 = ((Component)obj2).transform;
																if ((object)transform2 == null)
																{
																	goto IL_0773;
																}
																Vector3 position2 = transform2.position;
															}
															Transform transform3 = ((Component)obj2).transform;
															if ((object)transform3 != null)
															{
																bool flag9 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
																Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)(&ret));
																if ((object)_giacoreMerchant != null)
																{
																	position3 = float5;
																	arcadeSprite = _giacoreMerchant;
																	goto IL_0920;
																}
															}
														}
													}
												}
												else if (currentUnlockedZone == WestwoodsBounds.WestwoodsZone.Three)
												{
													if ((object)GM.Core != null)
													{
														bool flag10 = GM.Core.IsStageVisuallyInverted();
														if ((object)obj2 != null)
														{
															if (flag10)
															{
																Transform transform4 = ((Component)obj2).transform;
																if ((object)transform4 == null)
																{
																	goto IL_0773;
																}
																Vector3 position4 = transform4.position;
															}
															else
															{
																Transform transform5 = ((Component)obj2).transform;
																if ((object)transform5 == null)
																{
																	goto IL_0773;
																}
																Vector3 position5 = transform5.position;
															}
															giacoreMerchant = _giacoreMerchant;
															Transform transform6 = ((Component)obj2).transform;
															if ((object)transform6 != null)
															{
																Vector3 position6 = transform6.position;
																bool flag11 = (object)_giacoreMerchant == null;
																multiplayerManager = (MultiplayerManager)(&list3);
																if (!flag11)
																{
																	position3 = float5;
																	goto IL_0966;
																}
															}
														}
													}
												}
												else
												{
													giacoreMerchant = _giacoreMerchant;
													if ((object)obj2 != null)
													{
														Transform transform7 = ((Component)obj2).transform;
														if ((object)transform7 != null)
														{
															Vector3 position7 = transform7.position;
															bool flag12 = (object)_giacoreMerchant == null;
															multiplayerManager = (MultiplayerManager)(&list3);
															if (!flag12)
															{
																position3 = float5;
																goto IL_0966;
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
		goto IL_0773;
		IL_0966:
		arcadeSprite = giacoreMerchant;
		goto IL_0920;
		IL_0773:
		throw new NullReferenceException();
		IL_0767:
		ConfigureGiocoreMerchant();
		return;
		IL_0920:
		arcadeSprite.position = position3;
		goto IL_0767;
	}

	private unsafe void ConfigureGiocoreMerchant()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0124: Expected O, but got Ref
		//IL_027f: Expected O, but got Ref
		//IL_03a2: Expected O, but got Ref
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_0729: Expected O, but got I4
		//IL_0731: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected O, but got Unknown
		//IL_076b: Expected O, but got I
		//IL_066d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		_ = 0;
		_ = 0;
		Action action = delegate
		{
			WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
			int queuedSpins = westwoodsTrisection.queuedSpins + 10;
			westwoodsTrisection.queuedSpins = queuedSpins;
			PickupCustomMerchant giacoreMerchant6 = _giacoreMerchant;
			giacoreMerchant6._shopCooldown = 70000f;
			giacoreMerchant6._shopCooldownTimer = 70000f;
		};
		Sprite sprite = SpriteManager.GetSprite("WheelIcon", "items");
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/chulareh_merchant_spinTheWheel_more", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text = translation.Replace("%0", "10");
		string translation2 = LocalizationManager.GetTranslation("lang/chulareh_merchant_spinTheWheel_more", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text2 = translation2.Replace("%0", "10");
		_ = 999;
		CustomActionInventoryItem item = (CustomActionInventoryItem)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
		_ = 0;
		giacoreMerchant.CustomActionInventoryItems.Add(item);
		PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
		_ = 0;
		_ = 0;
		_ = 0;
		Action action2 = delegate
		{
			WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
			int queuedSpins = westwoodsTrisection.queuedSpins + 5;
			westwoodsTrisection.queuedSpins = queuedSpins;
			PickupCustomMerchant giacoreMerchant6 = _giacoreMerchant;
			giacoreMerchant6._shopCooldown = 35000f;
			giacoreMerchant6._shopCooldownTimer = 35000f;
		};
		Sprite sprite2 = SpriteManager.GetSprite("WheelIcon", "items");
		string translation3 = LocalizationManager.GetTranslation("lang/chulareh_merchant_spinTheWheel_more", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text3 = translation3.Replace("%0", "5");
		string translation4 = LocalizationManager.GetTranslation("lang/chulareh_merchant_spinTheWheel_more", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text4 = translation4.Replace("%0", "5");
		_ = 499;
		CustomActionInventoryItem item2 = (CustomActionInventoryItem)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
		_ = 0;
		giacoreMerchant2.CustomActionInventoryItems.Add(item2);
		PickupCustomMerchant giacoreMerchant3 = _giacoreMerchant;
		_ = 0;
		_ = 0;
		_ = 0;
		Action action3 = delegate
		{
			WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
			int queuedSpins = westwoodsTrisection.queuedSpins + 1;
			westwoodsTrisection.queuedSpins = queuedSpins;
			PickupCustomMerchant giacoreMerchant6 = _giacoreMerchant;
			giacoreMerchant6._shopCooldown = 7000f;
			giacoreMerchant6._shopCooldownTimer = 7000f;
		};
		Sprite sprite3 = SpriteManager.GetSprite("WheelIcon", "items");
		string translation5 = LocalizationManager.GetTranslation("lang/chulareh_merchant_spinTheWheel", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string translation6 = LocalizationManager.GetTranslation("lang/chulareh_merchant_spinTheWheel", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_ = 99;
		CustomActionInventoryItem item3 = (CustomActionInventoryItem)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
		_ = 0;
		giacoreMerchant3.CustomActionInventoryItems.Add(item3);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<CharacterType> list = config._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v42 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = true;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			object obj3 = obj4 - -1;
			bool flag2 = obj3 == null;
			flag = flag2;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<CharacterType> list2 = config2._003CUnlockedCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		bool flag3;
		if ((nint)0 == 0)
		{
			flag3 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			object obj5 = obj6 - -1;
			bool flag4 = obj5 == null;
			flag3 = !flag4;
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		List<ItemType> list3 = config3._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v50 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag5;
		if ((nint)0 == 0)
		{
			flag5 = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj8 = default(object);
			object obj7 = obj8 - -1;
			bool flag6 = obj7 == null;
			flag5 = !flag6;
		}
		object obj9 = flag & flag5;
		object obj10 = flag3 & obj9;
		if (obj10 != null)
		{
			_ = 0;
			_ = 0;
			_ = 0;
			Action action4 = delegate
			{
				//IL_0082: Expected F4, but got I4
				Debug.Log("unlock secretino secret");
				GameManager core4 = GM.Core;
				PlayerOptionsData config4 = core4._playerOptions.Config;
				bool flag7 = core4._playerOptions.UnlockSecret(SecretType.WestwoodsPreorder, config4);
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ThingFound, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				RemoveSecretinoItem();
			};
			Sprite sprite4 = SpriteManager.GetSprite("p_secretino", "items");
			string translation7 = LocalizationManager.GetTranslation("lang/chulareh_merchant_secretino_title", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string translation8 = LocalizationManager.GetTranslation("lang/chulareh_merchant_secretino_body", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			_ = 49999;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
			_secretinoShopItem = (CustomActionInventoryItem)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7]");
			_ = 0;
			PickupCustomMerchant giacoreMerchant4 = _giacoreMerchant;
			CustomActionInventoryItem item4 = (CustomActionInventoryItem)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			_ = _secretinoShopItem;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundWestwoods)+118]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundWestwoods)+108]");
			_ = 0;
			giacoreMerchant4.CustomActionInventoryItems.Add(item4);
		}
		PickupCustomMerchant giacoreMerchant5 = _giacoreMerchant;
		((Pickup)giacoreMerchant5)._disableDespawn = true;
	}

	private unsafe void RemoveSecretinoItem()
	{
		//IL_0018: Expected O, but got Ref
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		CustomActionInventoryItem customActionInventoryItem = default(CustomActionInventoryItem);
		bool flag = giacoreMerchant.CustomActionInventoryItems.Remove((CustomActionInventoryItem)(&customActionInventoryItem));
	}

	private void UnlockNextZone(bool saveProgress)
	{
		if (_currentUnlockedZone >= WestwoodsBounds.WestwoodsZone.Three)
		{
			return;
		}
		WestwoodsBounds.WestwoodsZone zone = ++_currentUnlockedZone;
		_westwoodsBounds.EnableBoundsForZone(zone);
		_barrierFadeActive = true;
		_barrierFadeTimer = 0f;
		if (saveProgress)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if ((int)_currentUnlockedZone > config._003CWW_ZoneProgress_003Ek__BackingField)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				config2._003CWW_ZoneProgress_003Ek__BackingField = (int)_currentUnlockedZone;
			}
		}
	}

	private Tilemap GetTilemap(string layerName)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._tilingTileset != null)
			{
				return stage._tilingTileset.GetTilemapLayer(layerName);
			}
		}
		return (Tilemap)(object)new NullReferenceException();
	}

	private void SetTilemapAlpha(Tilemap tilemap, float alphaValue)
	{
		bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
		Tilemap.get_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, out Color _);
		bool flag2 = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		Tilemap.set_color_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref value);
	}

	public void DebugUnlockNextZone()
	{
		if (_currentUnlockedZone < WestwoodsBounds.WestwoodsZone.Three)
		{
			WestwoodsBounds.WestwoodsZone zone = ++_currentUnlockedZone;
			_westwoodsBounds.EnableBoundsForZone(zone);
			_barrierFadeActive = true;
			_barrierFadeTimer = 0f;
		}
	}

	private void _003COnWestwoodsSpin_003Eb__30_0()
	{
		Action onEventSelected = delegate
		{
			Action onComplete = delegate
			{
				WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
				westwoodsTrisection._isIdle = true;
				_westwoodsTrisection.TriggerTrisectionEvent();
				WestwoodsTrisectionManager westwoodsTrisection2 = _westwoodsTrisection;
				StageEventTrisectionManager.WeightedTrisectionEventData nextChosenEvent = ((StageEventTrisectionManager)westwoodsTrisection2)._nextChosenEvent;
				TrisectionEvent ev = nextChosenEvent.ev;
				StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField);
				if (stageEventType == StageEventType.LUCK_BOOST)
				{
					Action onUnlockZoneEvent = westwoodsTrisection2.OnUnlockZoneEvent;
					if (westwoodsTrisection2.OnUnlockZoneEvent != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				}
				else
				{
					PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
					if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0)
					{
						PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
						((Pickup)giacoreMerchant2)._003CDisableGet_003Ek__BackingField = false;
					}
				}
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		};
		_westwoodsTrisection.Spinnn(5000f, null, onEventSelected);
	}

	private void _003COnWestwoodsSpin_003Eb__30_1()
	{
		Action onComplete = delegate
		{
			WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
			westwoodsTrisection._isIdle = true;
			_westwoodsTrisection.TriggerTrisectionEvent();
			WestwoodsTrisectionManager westwoodsTrisection2 = _westwoodsTrisection;
			StageEventTrisectionManager.WeightedTrisectionEventData nextChosenEvent = ((StageEventTrisectionManager)westwoodsTrisection2)._nextChosenEvent;
			TrisectionEvent ev = nextChosenEvent.ev;
			StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField);
			if (stageEventType == StageEventType.LUCK_BOOST)
			{
				Action onUnlockZoneEvent = westwoodsTrisection2.OnUnlockZoneEvent;
				if (westwoodsTrisection2.OnUnlockZoneEvent != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
			else
			{
				PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
				if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0)
				{
					PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
					((Pickup)giacoreMerchant2)._003CDisableGet_003Ek__BackingField = false;
				}
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void _003COnWestwoodsSpin_003Eb__30_2()
	{
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		westwoodsTrisection._isIdle = true;
		_westwoodsTrisection.TriggerTrisectionEvent();
		WestwoodsTrisectionManager westwoodsTrisection2 = _westwoodsTrisection;
		StageEventTrisectionManager.WeightedTrisectionEventData nextChosenEvent = ((StageEventTrisectionManager)westwoodsTrisection2)._nextChosenEvent;
		TrisectionEvent ev = nextChosenEvent.ev;
		StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField);
		if (stageEventType == StageEventType.LUCK_BOOST)
		{
			Action onUnlockZoneEvent = westwoodsTrisection2.OnUnlockZoneEvent;
			if (westwoodsTrisection2.OnUnlockZoneEvent != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v211.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			return;
		}
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		if ((object)_giacoreMerchant != null && ((UnityEngine.Object)giacoreMerchant).m_CachedPtr != (IntPtr)0)
		{
			PickupCustomMerchant giacoreMerchant2 = _giacoreMerchant;
			((Pickup)giacoreMerchant2)._003CDisableGet_003Ek__BackingField = false;
		}
	}

	private unsafe void _003COnUpdate_003Eg__FadeBarrier_007C31_0(ref float barrierAlpha, Tilemap tilemaps)
	{
		//IL_0079: Invalid comparison between I4 and F4
		//IL_00c4: Expected F4, but got I4
		//IL_00f1: Expected Ref, but got F4
		if (0.5f < _barrierFadeTimer)
		{
			SetTilemapAlpha(tilemaps, 0f);
			_barrierFadeActive = false;
			return;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = (_barrierFadeTimer = deltaTime + _barrierFadeTimer);
		float num2 = num + num;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = num2 * -1f;
		float num4 = num3 + 1f;
		ref float reference = ref *(float*)num4;
		SetTilemapAlpha(tilemaps, num4);
	}

	private void _003CConfigureGiocoreMerchant_003Eb__38_0()
	{
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		int queuedSpins = westwoodsTrisection.queuedSpins + 10;
		westwoodsTrisection.queuedSpins = queuedSpins;
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		giacoreMerchant._shopCooldown = 70000f;
		giacoreMerchant._shopCooldownTimer = 70000f;
	}

	private void _003CConfigureGiocoreMerchant_003Eb__38_1()
	{
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		int queuedSpins = westwoodsTrisection.queuedSpins + 5;
		westwoodsTrisection.queuedSpins = queuedSpins;
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		giacoreMerchant._shopCooldown = 35000f;
		giacoreMerchant._shopCooldownTimer = 35000f;
	}

	private void _003CConfigureGiocoreMerchant_003Eb__38_2()
	{
		WestwoodsTrisectionManager westwoodsTrisection = _westwoodsTrisection;
		int queuedSpins = westwoodsTrisection.queuedSpins + 1;
		westwoodsTrisection.queuedSpins = queuedSpins;
		PickupCustomMerchant giacoreMerchant = _giacoreMerchant;
		giacoreMerchant._shopCooldown = 7000f;
		giacoreMerchant._shopCooldownTimer = 7000f;
	}

	private void _003CConfigureGiocoreMerchant_003Eb__38_3()
	{
		//IL_0082: Expected F4, but got I4
		Debug.Log("unlock secretino secret");
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = core._playerOptions.UnlockSecret(SecretType.WestwoodsPreorder, config);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ThingFound, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		RemoveSecretinoItem();
	}
}
