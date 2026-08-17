using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class ItemFoundPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__40_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CReceiveItem_003Eb__40_0()
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				AppWarningState.HasShown = false;
				WarningPage.Corrupt = true;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public float timer;

		public ItemFoundPage _003C_003E4__this;

		public TweenCallback _003C_003E9__4;

		public TweenCallback _003C_003E9__3;

		internal float _003CSetRelicDisplay_003Eb__0()
		{
			return timer;
		}

		internal void _003CSetRelicDisplay_003Eb__1(float x)
		{
			timer = x;
		}

		internal unsafe void _003CSetRelicDisplay_003Eb__2()
		{
			//IL_004a: Expected O, but got Ref
			//IL_01ae: Expected O, but got Ref
			ItemFoundPage itemFoundPage = _003C_003E4__this;
			Transform transform = itemFoundPage._GetButton.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			ItemFoundPage itemFoundPage2 = _003C_003E4__this;
			Transform transform2 = itemFoundPage2._GetButton.transform;
			object obj = default(object);
			transform2.localEulerAngles = (Vector3)(&obj);
			ItemFoundPage itemFoundPage3 = _003C_003E4__this;
			itemFoundPage3._GetButton.SetActive(value: true);
			ItemFoundPage itemFoundPage4 = _003C_003E4__this;
			Transform transform3 = itemFoundPage4._GetButton.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform3, 1f, 0.15f);
			ItemFoundPage itemFoundPage5 = _003C_003E4__this;
			Transform transform4 = itemFoundPage5._GetButton.transform;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(transform4, (Vector3)(&obj), 0.15f);
			TweenCallback tweenCallback = _003C_003E9__3;
			if (_003C_003E9__3 == null)
			{
				tweenCallback = (_003C_003E9__3 = delegate
				{
					TweenCallback callback = _003C_003E9__4;
					if (_003C_003E9__4 == null)
					{
						callback = (_003C_003E9__4 = delegate
						{
							ItemFoundPage itemFoundPage6 = _003C_003E4__this;
							Button component = itemFoundPage6._GetButton.GetComponent<Button>();
							component.interactable = true;
							ItemFoundPage itemFoundPage7 = _003C_003E4__this;
							Selectable component2 = itemFoundPage7._GetButton.GetComponent<Selectable>();
							component2.Select();
							ItemFoundPage itemFoundPage8 = _003C_003E4__this;
							Button component3 = itemFoundPage8._GetButton.GetComponent<Button>();
							UnityAction call = _003C_003E4__this.Receive;
							component3.m_OnClick.AddListener(call);
						});
					}
					Tween tween = DOVirtual.DelayedCall(0.15f, callback);
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal void _003CSetRelicDisplay_003Eb__3()
		{
			TweenCallback callback = _003C_003E9__4;
			if (_003C_003E9__4 == null)
			{
				callback = (_003C_003E9__4 = delegate
				{
					ItemFoundPage itemFoundPage = _003C_003E4__this;
					Button component = itemFoundPage._GetButton.GetComponent<Button>();
					component.interactable = true;
					ItemFoundPage itemFoundPage2 = _003C_003E4__this;
					Selectable component2 = itemFoundPage2._GetButton.GetComponent<Selectable>();
					component2.Select();
					ItemFoundPage itemFoundPage3 = _003C_003E4__this;
					Button component3 = itemFoundPage3._GetButton.GetComponent<Button>();
					UnityAction call = _003C_003E4__this.Receive;
					component3.m_OnClick.AddListener(call);
				});
			}
			Tween tween = DOVirtual.DelayedCall(0.15f, callback);
		}

		internal void _003CSetRelicDisplay_003Eb__4()
		{
			ItemFoundPage itemFoundPage = _003C_003E4__this;
			Button component = itemFoundPage._GetButton.GetComponent<Button>();
			component.interactable = true;
			ItemFoundPage itemFoundPage2 = _003C_003E4__this;
			Selectable component2 = itemFoundPage2._GetButton.GetComponent<Selectable>();
			component2.Select();
			ItemFoundPage itemFoundPage3 = _003C_003E4__this;
			Button component3 = itemFoundPage3._GetButton.GetComponent<Button>();
			UnityAction call = _003C_003E4__this.Receive;
			component3.m_OnClick.AddListener(call);
		}
	}

	private Localize _ItemName;

	private Localize _ItemDescription;

	private Localize _Title;

	private RectTransform _ContentPanel;

	private Image _Icon;

	private GameObject _GetButton;

	private GameObject _DiscardButton;

	private YellowSignManager _YellowSign;

	private UISpriteAnimation _BurstVFX;

	private ParticleEmitterManager _ParticleEmitter;

	private RectTransform _Panel;

	private GospelManager _Gospel;

	private RectTransform _ScrollView;

	private GameObject _New;

	private TextMeshProUGUI _LevelText;

	private SignalBus _signalBus;

	private ItemType _item;

	private ItemData _itemData;

	private DataManager _dataManager;

	private WeaponType _weapon;

	private WeaponData _weaponData;

	private WeaponData _baseWeaponData;

	private PlayerOptions _playerOptions;

	private AchievementManager _achievementManager;

	private VampireSurvivors.Objects.Characters.CharacterController _playerWhoFoundIt;

	private bool _axisReset;

	private bool _canDiscard;

	private bool _discarded;

	private bool _hasReceived;

	private ParticleSystem _colorParticles;

	private bool _shouldTime;

	private float _autoAcceptCurrentTime;

	private float _autoAcceptTimeLimit = 10f;

	private void Construct(SignalBus signalBus, DataManager data, PlayerOptions playerOptions, AchievementManager achievementManager)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_01b4: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_01ed: Expected O, but got I
		_signalBus = signalBus;
		DataManager dataManager = default(DataManager);
		_dataManager = dataManager;
		_playerOptions = playerOptions;
		AchievementManager achievementManager2 = default(AchievementManager);
		_achievementManager = achievementManager2;
		Action<GameplaySignals.PlayerPickedUpNewItemSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EC90");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v388 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.PlayerPickedUpNewItemSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.PlayerPickedUpNewItemSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v17 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action<OnlineSignals.OnlineCloseItemFoundPage> action3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ED70");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineCloseItemFoundPage>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineCloseItemFoundPage>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ rax_v32 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, (Action<object>)(object)achievementManager);
	}

	private void OnClosePage(OnlineSignals.OnlineCloseItemFoundPage close)
	{
		if ((object)close != null)
		{
			_discarded = true;
			View.Hide();
		}
		else
		{
			ReceiveItem();
		}
	}

	protected unsafe override void Update()
	{
		//IL_02e2: Expected O, but got F4
		//IL_00de: Invalid comparison between F4 and I4
		//IL_0158: Expected O, but got Ref
		//IL_018c: Expected O, but got Ref
		//IL_01b6: Expected F4, but got I4
		float num = default(float);
		if (!_axisReset)
		{
			VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
			if ((object)interactingPlayer != null && ((UnityEngine.Object)interactingPlayer).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController interactingPlayer2 = GM.Core.InteractingPlayer;
				if (interactingPlayer2._player != null && IsLocalPlayerControllingUi())
				{
					VampireSurvivors.Objects.Characters.CharacterController interactingPlayer3 = GM.Core.InteractingPlayer;
					num = interactingPlayer3._player.GetAxis("Move Vertical");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186CE61BDh\"");
					if (num == 0f)
					{
						bool flag = !_canDiscard;
						_axisReset = true;
						if (!flag)
						{
							Selectable component = _GetButton.GetComponent<Selectable>();
							Selectable component2 = _DiscardButton.GetComponent<Selectable>();
							object obj = default(object);
							component.navigation = (Navigation)(&obj);
							SetNavigationDown(component, component2);
							SetNavigationUp(component, component2);
							component2.navigation = (Navigation)(&obj);
							SetNavigationDown(component2, component);
							SetNavigationUp(component2, component);
							num = 4f;
						}
					}
				}
			}
		}
		if (!_shouldTime || !IsLocalPlayerControllingUi())
		{
			return;
		}
		object obj2 = Time.deltaTime;
		if (!((_autoAcceptCurrentTime = num + _autoAcceptCurrentTime) > _autoAcceptTimeLimit))
		{
			return;
		}
		if (!_hasReceived)
		{
			_hasReceived = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				ReceiveItem();
			}
			else
			{
				OnlineStageManager._instance.SendCloseItemFoundPage(discard: false);
			}
		}
		else
		{
			Debug.LogWarning("Would have received the item again!");
		}
		_autoAcceptCurrentTime = 0f;
		_shouldTime = false;
	}

	private void FixedUpdate()
	{
		//IL_002c: Expected O, but got F4
		object obj = Time.fixedDeltaTime;
		float t = default(float);
		bool fixedTimeStep = default(bool);
		_colorParticles.Simulate(t, withChildren: true, restart: false, fixedTimeStep);
	}

	public void Receive()
	{
		if (!_hasReceived)
		{
			_hasReceived = true;
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				ReceiveItem();
			}
			else
			{
				OnlineStageManager._instance.SendCloseItemFoundPage(discard: false);
			}
		}
		else
		{
			Debug.LogWarning("Would have received the item again!");
		}
	}

	public void Discard()
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			_discarded = true;
			View.Hide();
		}
		else
		{
			OnlineStageManager._instance.SendCloseItemFoundPage(discard: true);
		}
	}

	private void DiscardItem()
	{
		_discarded = true;
		View.Hide();
	}

	private unsafe void ReceiveItem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0451: Expected O, but got Ref
		//IL_01dc: Expected O, but got I4
		//IL_04bb: Expected O, but got Ref
		//IL_04d5: Expected native int or pointer, but got O
		//IL_0278: Expected O, but got Ref
		//IL_04ed: Expected O, but got Ref
		//IL_04fb: Expected O, but got Ref
		//IL_053f: Expected O, but got Ref
		//IL_0559: Expected native int or pointer, but got O
		//IL_0571: Expected O, but got Ref
		//IL_057f: Expected O, but got Ref
		//IL_07d6: Expected O, but got I
		//IL_062f: Expected O, but got I
		//IL_0692: Expected O, but got I
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_07ee: Expected O, but got Ref
		//IL_0811: Expected I, but got O
		//IL_082d: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_discarded = false;
		Button component = _GetButton.GetComponent<Button>();
		component.interactable = false;
		Button component2 = _GetButton.GetComponent<Button>();
		component2.m_OnClick.RemoveAllListeners();
		if (_weaponData != null && _weapon != WeaponType.VOID)
		{
			GameManager core = GM.Core;
			if (!core._levelUpFactory.IsBanished(_weapon))
			{
				GameManager core2 = GM.Core;
				core2._levelUpFactory.RemoveFromExcluded(_weapon);
			}
			GM.Core.LevelWeaponUp(_weapon, removeFromStore: true, _playerWhoFoundIt);
		}
		PlayerOptions playerOptions;
		ArcanaType arcanaType;
		if (_item != ItemType.RELIC_RANDOMAZZO)
		{
			if (_item != ItemType.RELIC_DARKASSO)
			{
				if (_item != ItemType.RELIC_YELLOW)
				{
					float num = default(float);
					if (_item != ItemType.RELIC_GGOSPEL)
					{
						if (_item == ItemType.RELIC_MIRROR || _item == ItemType.RELIC_TRUMPET)
						{
							object obj3 = _item - 51;
							bool flag = obj3 == null;
							bool flag2 = !flag;
							AchievementType t = (AchievementType)((flag2 ? 1 : 0) + 137);
							bool flag3 = _achievementManager.Unlock(t);
							AppWarningState.HasShown = false;
							WarningPage.Corrupt = true;
							Transform target = _GetButton.transform;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.15f);
							Transform target2 = _GetButton.transform;
							Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
							_ = -180f;
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, endValue, 0.15f);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
							BgmType bgmType = default(BgmType);
							SoundManager.StopMusic(bgmType);
							_ = 0;
							_ = 1065353216;
							_ = 1065353216;
							_ = 4;
							Action action = delegate
							{
								WarningPage.Corrupt = true;
								PlayerOptionsData config3 = _playerOptions.Config;
								config3._003CSelectedStage_003Ek__BackingField = StageType.FOREST;
								GM.Core.ResetGameToMenu();
							};
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
							object obj4 = (nint)0 >> 32;
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1106 @ rdi_v8 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-31]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
							_ = 0;
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-35]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v921 @ rdi_v9 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
							object obj6 = default(object);
							object obj5 = obj6 + 32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
							Type type = default(Type);
							Type signalType = type;
							object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-59]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-49]");
							_ = 0;
							object signal = (IntPtr)obj7;
							_signalBus.InternalFire(signalType, signal, (object)null, (byte)(int)num != 0);
							return;
						}
						goto IL_079b;
					}
					Transform target3 = _GetButton.transform;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target3, 0f, 0.15f);
					Transform target4 = _GetButton.transform;
					Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					_ = -180f;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target4, endValue2, 0.15f);
					PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(32f));
					ParticleSystem.MinMaxCurve rateOverTime = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
					_ = 0;
					((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = rateOverTime;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1.5f));
					ParticleSystem.MinMaxCurve startLifetime = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
					ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
					_ = 0;
					((ParticleSystem.MainModule*)mainModule)->startLifetime = startLifetime;
					GospelManager gospel = _Gospel;
					Action callback = delegate
					{
						View.Hide();
					};
					gospel._claps = 0;
					gospel._maxClaps = 7;
					gospel.Clap();
					gospel._callback = callback;
					PlayerOptionsData config = gospel._playerOptions.Config;
					SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					_ = 0;
					_ = 1056964608;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
					soundConfig.Volume = (float?)(object)0;
					soundConfig.Rate = 1f;
					PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Piano, soundConfig, 0f, 10, num);
					SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
					_ = 0;
					_ = 1056964608;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
					soundConfig2.Volume = (float?)(object)0;
					soundConfig2.Rate = 1f;
					PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.CFFX, soundConfig2, 0f, 10, num);
					GameManager core3 = GM.Core;
					PlayerOptionsData config2 = core3._playerOptions.Config;
					config2._003CHasKilledTheFinalBoss_003Ek__BackingField = true;
					GameManager core4 = GM.Core;
					core4._playerOptions.Save();
					return;
				}
				_GetButton.SetActive(value: false);
				Action onComplete = _003C_003Ec._003C_003E9__40_0;
				if (_003C_003Ec._003C_003E9__40_0 == null)
				{
					onComplete = (_003C_003Ec._003C_003E9__40_0 = delegate
					{
						GameManager core5 = GM.Core;
						if (!core5._multiplayer.IsOnlineMultiplayer)
						{
							AppWarningState.HasShown = false;
							WarningPage.Corrupt = true;
						}
					});
				}
				_YellowSign.DoClaps(onComplete);
				return;
			}
			playerOptions = _playerOptions;
			arcanaType = ArcanaType.D06_BOLERO;
		}
		else
		{
			playerOptions = _playerOptions;
			arcanaType = ArcanaType.T06_SARABANDE;
		}
		playerOptions.UnlockArcana(arcanaType);
		GM.Core.QueueOpenArcana(ArcanaUiType.MAIN);
		goto IL_079b;
		IL_079b:
		View.Hide();
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action<GameplaySignals.PlayerPickedUpNewItemSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9EC90");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action<OnlineSignals.OnlineCloseItemFoundPage> token2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ED70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0050: Expected O, but got I
		//IL_010e: Expected O, but got Ref
		//IL_05ec: Expected O, but got Ref
		//IL_01ae: Expected O, but got Ref
		//IL_0611: Expected I, but got O
		//IL_061f: Expected O, but got Ref
		//IL_066c: Expected O, but got I8
		//IL_06c1: Expected O, but got I4
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_0712: Expected O, but got I4
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_04cc: Expected O, but got Ref
		//IL_053b: Expected O, but got Ref
		//IL_06db->IL0580: Incompatible stack heights: 1 vs 0
		//IL_03b0->IL0580: Incompatible stack heights: 1 vs 0
		//IL_045f->IL0580: Incompatible stack heights: 1 vs 0
		//IL_048d->IL0580: Incompatible stack heights: 1 vs 0
		//IL_04b9->IL0580: Incompatible stack heights: 1 vs 0
		//IL_0528->IL0580: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.OnShowStart(g);
		_hasReceived = false;
		_axisReset = false;
		EnterMultiplayerControl(_playerWhoFoundIt);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1067450368;
		soundConfig.Rate = 1f;
		soundConfig.Detune = 1000f;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
		soundConfig.Volume = (float?)(object)0;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
		if ((object)_BurstVFX != null)
		{
			Image componentInParent = _BurstVFX.GetComponentInParent<Image>();
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					Color color = componentInParent.color;
					Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					componentInParent.color = color2;
					_BurstVFX.Play();
					Transform parent = base.transform;
					_ScrollView.SetParent(parent, worldPositionStays: true);
					SoundManager.SoundConfig panel = (SoundManager.SoundConfig)(object)_Panel;
					_ = 1f;
					bool flag = (byte)(~(panel.Mute ? 1u : 0u)) != 0;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Transform.set_localScale_Injected((IntPtr)(panel.Mute ? 1 : 0), ref *(Vector3*)obj3);
					Transform transform = _Panel.transform;
					_ = 180f;
					Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					transform.localEulerAngles = localEulerAngles;
					nint num = (nint)typeof(Vector3);
					Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v769 @ rax_v36 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					_ = Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rax_v37 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_Panel, endValue, 0.15f);
					object obj4 = 6603577472L;
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v39 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 1;
							_ = 0;
						}
					}
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_Panel, 1f, 0.15f);
					TweenCallback tweenCallback2;
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag2 = (nint)0 == 0;
							_ = 0;
							if (!flag2)
							{
								object obj5 = tweenerCore2 + 184;
								object obj6 = obj5 >> 12;
								object obj7 = obj6 & 0x1FFFFF;
								object obj8 = obj7 >> 6;
								object obj9 = obj7 & 0x3F;
								nint num4;
								do
								{
									object obj10 = 1 << (int)obj9;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ r14_v6+462E0+v917 @ rdx_v39*8]");
									object obj11 = 0 | obj10;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ r14_v6+462E0+v917 @ rdx_v39*8]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ r14_v6+462E0+v917 @ rdx_v39*8]");
									if (num3 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ r14_v6+462E0+v917 @ rdx_v39*8]");
									num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v777 @ r14_v6+462E0+v917 @ rdx_v39*8]");
								}
								while (num4 != 0);
								TweenCallback tweenCallback = delegate
								{
									_ScrollView.SetParent(_Panel, worldPositionStays: true);
									Vector2 anchoredPosition3 = default(Vector2);
									_ScrollView.anchoredPosition = anchoredPosition3;
								};
								tweenCallback2 = tweenCallback;
								goto IL_0346;
							}
						}
					}
					TweenCallback tweenCallback3 = delegate
					{
						_ScrollView.SetParent(_Panel, worldPositionStays: true);
						Vector2 anchoredPosition3 = default(Vector2);
						_ScrollView.anchoredPosition = anchoredPosition3;
					};
					bool flag3 = tweenerCore2 == null;
					tweenCallback2 = tweenCallback3;
					if (!flag3)
					{
						goto IL_0346;
					}
					goto IL_06b8;
				}
			}
		}
		goto IL_0580;
		IL_0580:
		throw new NullReferenceException();
		IL_06b8:
		object obj12 = Screen.width;
		if ((object)_ContentPanel != null)
		{
			Vector2 anchoredPosition = _ContentPanel.anchoredPosition;
			if ((object)_ContentPanel != null)
			{
				Vector2 anchoredPosition2 = default(Vector2);
				_ContentPanel.anchoredPosition = anchoredPosition2;
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore3 = DOTweenModuleUI.DOAnchorPosX(_ContentPanel, 0f, 0.15f);
				ParticleSystem colorParticles = _colorParticles;
				if ((object)_colorParticles == null || ((UnityEngine.Object)colorParticles).m_CachedPtr == (IntPtr)0)
				{
					MakeColorParticles();
				}
				RenderingExtensions.Start(_colorParticles);
				if ((object)_GetButton != null)
				{
					Selectable component = _GetButton.GetComponent<Selectable>();
					if ((object)_DiscardButton != null)
					{
						Selectable component2 = _DiscardButton.GetComponent<Selectable>();
						if ((object)component != null)
						{
							Navigation navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
							_ = ((SoundManager.SoundConfig)(object)component).Loop;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v56 (UnityEngine.UI.Selectable)+38]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rax_v56 (UnityEngine.UI.Selectable)+48]");
							_ = 0;
							component.navigation = navigation;
							if ((object)component2 != null)
							{
								Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								_ = component2.m_Navigation;
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v57 (UnityEngine.UI.Selectable)+38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v57 (UnityEngine.UI.Selectable)+48]");
								_ = 0;
								component2.navigation = navigation2;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0580;
		IL_0346:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v840 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_06b8;
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _playerWhoFoundIt;
	}

	protected override void OnHideFinish(GameObject g)
	{
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0310: Expected O, but got I
		//IL_0348: Expected I, but got O
		//IL_02ed->IL0290: Incompatible stack heights: 1 vs 0
		base.OnHideFinish(g);
		UISpriteAnimation burstVFX = _BurstVFX;
		if ((object)_BurstVFX != null && ((UnityEngine.Object)burstVFX).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_BurstVFX != null)
			{
				_BurstVFX.Reset();
				Component burstVFX2 = _BurstVFX;
				if ((object)_BurstVFX != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v22 (UnityEngine.Component)+25]");
					if ((nint)0 != 0)
					{
						Transform transform = _BurstVFX.transform;
						bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					}
					goto IL_0290;
				}
			}
			goto IL_024c;
		}
		goto IL_0290;
		IL_024c:
		throw new NullReferenceException();
		IL_0290:
		ExitMultiplayerControl();
		object signal;
		nint num2;
		if (!_discarded)
		{
			if (_signalBus == null)
			{
				goto IL_024c;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			object obj3 = default(object);
			signal = (IntPtr)obj3;
			num2 = num;
		}
		else
		{
			if (_signalBus == null)
			{
				goto IL_024c;
			}
			num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj5 = default(object);
			object obj4 = obj5 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr2 = default(IntPtr);
			num2 = intPtr2;
			signal = null;
		}
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num2, signal, (object)null, requireDeclaration);
		if ((object)_colorParticles != null)
		{
			_colorParticles.Stop();
			if ((object)_colorParticles != null)
			{
				Transform transform2 = _colorParticles.transform;
				if ((object)transform2 != null)
				{
					Transform parent = transform2.parent;
					if ((object)parent != null)
					{
						GameObject obj6 = parent.gameObject;
						UnityEngine.Object.Destroy(obj6, 0f);
						_colorParticles = null;
						return;
					}
				}
			}
		}
		goto IL_024c;
	}

	private unsafe void CacheItem(GameplaySignals.PlayerPickedUpNewItemSignal sig)
	{
		//IL_01d7: Expected O, but got Ref
		//IL_0155: Expected O, but got I
		//IL_03c5: Expected O, but got Ref
		//IL_016c: Expected O, but got I
		//IL_0381: Expected O, but got I
		//IL_0398: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController character = sig.Character;
		_playerWhoFoundIt = sig.Character;
		if ((object)sig.Character == null || ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController playerOne = GM.Core.PlayerOne;
			_playerWhoFoundIt = playerOne;
		}
		_discarded = false;
		_item = ItemType.VOID;
		_itemData = null;
		_weapon = WeaponType.VOID;
		_weaponData = null;
		DataManager dataManager = _dataManager;
		if (sig.IsWeapon)
		{
			WeaponType weapon = (WeaponType)((int)sig.Item >> 32);
			_weapon = weapon;
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = dataManager.GetConvertedWeapons();
			System.Int32Enum key = (System.Int32Enum)((int)sig.Item >> 32);
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v61 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0458;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v61 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v62+20]");
			_weaponData = (WeaponData)0;
			_baseWeaponData = _weaponData;
		}
		else
		{
			_item = sig.Item;
			object itemData = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)sig.Item);
			_itemData = (ItemData)itemData;
		}
		if (_item != ItemType.VOID)
		{
			ItemType itemType = default(ItemType);
			string text = ((Enum)(&itemType)).ToString();
			if (text.Contains("RELIC"))
			{
				Button component = _GetButton.GetComponent<Button>();
				component.interactable = false;
			}
			if (_item != ItemType.VOID)
			{
				IntPtr intPtr = default(IntPtr);
				string text2 = ((Enum)(&intPtr)).ToString();
				if (!text2.Contains("RELIC"))
				{
					SetItemDisplay();
					goto IL_03ac;
				}
				SetRelicDisplay();
				_canDiscard = false;
				return;
			}
		}
		WeaponData baseWeaponData = _baseWeaponData;
		int num = ((!baseWeaponData._003CisPowerUp_003Ek__BackingField) ? GM.Core.GetWeaponLevel(_weapon, _playerWhoFoundIt) : GM.Core.GetAccessoryLevel(_weapon, _playerWhoFoundIt));
		WeaponData baseWeaponData2 = _baseWeaponData;
		bool flag = baseWeaponData2._003CallowDuplicates_003Ek__BackingField;
		int num2 = 0;
		if (!flag)
		{
			num2 = num;
		}
		if (num2 > 0)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
			System.Int32Enum key2 = (System.Int32Enum)((int)sig.Item >> 32);
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item(key2);
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v28 (System.Object)+18]");
			if ((nint)num3 >= (nint)0)
			{
				goto IL_0458;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v28 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v26+20+v276 @ rdi_v9 (System.Int32)*8]");
			_weaponData = (WeaponData)0;
		}
		SetWeaponDisplay(num2);
		goto IL_03ac;
		IL_03ac:
		_canDiscard = true;
		return;
		IL_0458:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void SetItemDisplay()
	{
		bool active = IsLocalPlayerControllingUi();
		_GetButton.SetActive(active);
		bool active2 = IsLocalPlayerControllingUi();
		_DiscardButton.SetActive(active2);
		Selectable component = _GetButton.GetComponent<Selectable>();
		component.Select();
		Button component2 = _GetButton.GetComponent<Button>();
		component2.interactable = false;
		Button component3 = _DiscardButton.GetComponent<Button>();
		component3.interactable = false;
		TextMeshProUGUI component4 = _ItemName.GetComponent<TextMeshProUGUI>();
		string localizedName = _itemData.GetLocalizedName(_item);
		component4.text = localizedName;
		TextMeshProUGUI component5 = _ItemDescription.GetComponent<TextMeshProUGUI>();
		string localizedDescription = _itemData.GetLocalizedDescription(_item);
		component5.text = localizedDescription;
		ItemData itemData = _itemData;
		Sprite sprite = SpriteManager.GetSprite(itemData._003CframeName_003Ek__BackingField, itemData._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		SetIconSize();
		_Title.Term = "lang/newItem_header";
		TweenCallback callback = delegate
		{
			Button component6 = _DiscardButton.GetComponent<Button>();
			component6.interactable = true;
			Button component7 = _GetButton.GetComponent<Button>();
			component7.interactable = true;
			Button component8 = _GetButton.GetComponent<Button>();
			component8.Select();
			Button component9 = _GetButton.GetComponent<Button>();
			UnityAction call = Receive;
			component9.m_OnClick.AddListener(call);
		};
		Tween tween = DOVirtual.DelayedCall(0.25f, callback);
	}

	private unsafe void SetWeaponDisplay(int level)
	{
		//IL_0280: Expected O, but got Ref
		bool active = IsLocalPlayerControllingUi();
		_GetButton.SetActive(active);
		bool active2 = IsLocalPlayerControllingUi();
		_DiscardButton.SetActive(active2);
		Selectable component = _GetButton.GetComponent<Selectable>();
		component.Select();
		Button component2 = _GetButton.GetComponent<Button>();
		component2.interactable = false;
		Button component3 = _DiscardButton.GetComponent<Button>();
		component3.interactable = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C61]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = _weaponData.GetPrefix(_weapon);
		string term = prefix + "name";
		_ItemName.Term = term;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix2 = _weaponData.GetPrefix(_weapon);
		string term2 = prefix2 + "description";
		_ItemDescription.Term = term2;
		WeaponData baseWeaponData = _baseWeaponData;
		Sprite sprite = SpriteManager.GetSprite(baseWeaponData._003CframeName_003Ek__BackingField, baseWeaponData._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		_Title.Term = "lang/newItem_header";
		SetIconSize();
		if (level <= 0)
		{
			_New.SetActive(value: true);
			GameObject gameObject = _LevelText.gameObject;
			gameObject.SetActive(value: false);
		}
		else
		{
			_New.SetActive(value: false);
			GameObject gameObject2 = _LevelText.gameObject;
			gameObject2.SetActive(value: true);
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/weapon_level_", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			int value = level + 1;
			object obj = default(object);
			string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj), null);
			string text2 = translation + text;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
			TextMeshProUGUI component4 = _ItemDescription.GetComponent<TextMeshProUGUI>();
			string localizedDescriptionForLevel = _baseWeaponData.GetLocalizedDescriptionForLevel(_weaponData, _weapon);
			component4.text = localizedDescriptionForLevel;
		}
		TweenCallback callback = delegate
		{
			Button component5 = _DiscardButton.GetComponent<Button>();
			component5.interactable = true;
			Button component6 = _GetButton.GetComponent<Button>();
			component6.interactable = true;
			Button component7 = _GetButton.GetComponent<Button>();
			component7.Select();
			Button component8 = _GetButton.GetComponent<Button>();
			UnityAction call = Receive;
			component8.m_OnClick.AddListener(call);
		};
		Tween tween = DOVirtual.DelayedCall(0.25f, callback);
	}

	private unsafe void SetRelicDisplay()
	{
		_003C_003Ec__DisplayClass48_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass48_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		_GetButton.SetActive(value: false);
		_DiscardButton.SetActive(value: false);
		_New.SetActive(value: true);
		GameObject gameObject = _LevelText.gameObject;
		gameObject.SetActive(value: false);
		TextMeshProUGUI component = _ItemName.GetComponent<TextMeshProUGUI>();
		string localizedName = _itemData.GetLocalizedName(_item);
		component.text = localizedName;
		TextMeshProUGUI component2 = _ItemDescription.GetComponent<TextMeshProUGUI>();
		string localizedDescription = _itemData.GetLocalizedDescription(_item);
		component2.text = localizedDescription;
		ItemData itemData = _itemData;
		Sprite sprite = SpriteManager.GetSprite(itemData._003CframeName_003Ek__BackingField, itemData._003Ctexture_003Ek__BackingField);
		_Icon.sprite = sprite;
		_Title.Term = "lang/relicFound";
		SetIconSize();
		CS_0024_003C_003E8__locals17.timer = 0f;
		if (!IsLocalPlayerControllingUi())
		{
			return;
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass48_0)(object)dOSetter)._003CSetRelicDisplay_003Eb__1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, 5f);
		TweenCallback tweenCallback = delegate
		{
			//IL_004a: Expected O, but got Ref
			//IL_01ae: Expected O, but got Ref
			ItemFoundPage itemFoundPage = CS_0024_003C_003E8__locals17._003C_003E4__this;
			Transform transform = itemFoundPage._GetButton.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			ItemFoundPage itemFoundPage2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			Transform transform2 = itemFoundPage2._GetButton.transform;
			object obj = default(object);
			transform2.localEulerAngles = (Vector3)(&obj);
			ItemFoundPage itemFoundPage3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			itemFoundPage3._GetButton.SetActive(value: true);
			ItemFoundPage itemFoundPage4 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			Transform target = itemFoundPage4._GetButton.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 1f, 0.15f);
			ItemFoundPage itemFoundPage5 = CS_0024_003C_003E8__locals17._003C_003E4__this;
			Transform target2 = itemFoundPage5._GetButton.transform;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj), 0.15f);
			TweenCallback tweenCallback2 = CS_0024_003C_003E8__locals17._003C_003E9__3;
			if (CS_0024_003C_003E8__locals17._003C_003E9__3 == null)
			{
				tweenCallback2 = (CS_0024_003C_003E8__locals17._003C_003E9__3 = delegate
				{
					TweenCallback callback = CS_0024_003C_003E8__locals17._003C_003E9__4;
					if (CS_0024_003C_003E8__locals17._003C_003E9__4 == null)
					{
						callback = (CS_0024_003C_003E8__locals17._003C_003E9__4 = delegate
						{
							ItemFoundPage itemFoundPage6 = CS_0024_003C_003E8__locals17._003C_003E4__this;
							Button component3 = itemFoundPage6._GetButton.GetComponent<Button>();
							component3.interactable = true;
							ItemFoundPage itemFoundPage7 = CS_0024_003C_003E8__locals17._003C_003E4__this;
							Selectable component4 = itemFoundPage7._GetButton.GetComponent<Selectable>();
							component4.Select();
							ItemFoundPage itemFoundPage8 = CS_0024_003C_003E8__locals17._003C_003E4__this;
							Button component5 = itemFoundPage8._GetButton.GetComponent<Button>();
							UnityAction call = CS_0024_003C_003E8__locals17._003C_003E4__this.Receive;
							component5.m_OnClick.AddListener(call);
						});
					}
					Tween tween = DOVirtual.DelayedCall(0.15f, callback);
				});
			}
			if (tweenerCore3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private unsafe void MakeColorParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f4: Expected O, but got Ref
		//IL_0409: Expected native int or pointer, but got O
		//IL_0423: Expected O, but got I
		//IL_046e: Expected O, but got Ref
		//IL_0487: Expected native int or pointer, but got O
		//IL_04a6: Expected O, but got I
		//IL_04d4: Expected O, but got I4
		//IL_04ed: Expected O, but got Ref
		//IL_0507: Expected native int or pointer, but got O
		//IL_07a5: Expected O, but got I4
		//IL_0539: Expected O, but got Ref
		//IL_0553: Expected native int or pointer, but got O
		//IL_07df: Expected O, but got I
		//IL_058b: Expected O, but got Ref
		//IL_05b2: Expected O, but got I
		//IL_05d9: Expected O, but got I
		//IL_05f3: Expected native int or pointer, but got O
		//IL_060d: Expected O, but got I
		//IL_0646: Expected O, but got I
		//IL_082d: Expected O, but got I
		//IL_09f9: Expected O, but got I
		//IL_08af: Expected O, but got Ref
		//IL_08c7: Expected O, but got Ref
		//IL_08e1: Expected native int or pointer, but got O
		//IL_08f4: Expected O, but got Ref
		//IL_0901: Expected O, but got Ref
		//IL_0911: Expected O, but got I
		//IL_0947: Expected O, but got Ref
		//IL_09ae: Expected I, but got O
		//IL_0737->IL08a1: Incompatible stack heights: 2 vs 1
		//IL_0764->IL0939: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
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
					((List<object>)(object)list).AddWithResize((object)"PfxYellow.png");
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
						((List<object>)(object)list).AddWithResize((object)"PfxRed.png");
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
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
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
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"PfxColor1.png");
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
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"PfxColor2.png");
								}
								else
								{
									int size5 = list._size + 1;
									list._size = size5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
									particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
									_ = 0;
									Camera main = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBounds(main);
									object obj3 = default(object);
									float max = (float)obj3 * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-8]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(1000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(-195f, -390f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+8]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
									_ = 0;
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2.6f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
									_ = 0;
									_ = 24;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 0;
									_ = 16777215;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
									particleSystemConfig._tint = (uint?)(object)0;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+48]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+58]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D0]");
									particleSystemConfig._blendMode = (BlendMode?)(object)0;
									particleSystemConfig._on = true;
									if ((object)_ParticleEmitter != null)
									{
										Transform transform = _ParticleEmitter.transform;
										Transform parent = default(Transform);
										string psName = default(string);
										bool isAdditive = default(bool);
										bool requiresMasking = default(bool);
										ParticleSystem colorParticles = _ParticleEmitter.CreateUIEmitter(particleSystemConfig, "UI", 0, parent, psName, isAdditive, requiresMasking);
										_colorParticles = colorParticles;
										if ((object)_colorParticles != null)
										{
											_ = _colorParticles;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C8]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												if (obj4 == null)
												{
													MissingMethodException ex = new MissingMethodException();
													throw ex;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1750 @ rax_v64 (should have been resolved before IL gen)");
											Component colorParticles2 = _colorParticles;
											if ((object)_colorParticles != null)
											{
												bool flag = ((UnityEngine.Object)colorParticles2).m_CachedPtr == (IntPtr)0;
												ParticleSystem.Pause_Injected(((UnityEngine.Object)colorParticles2).m_CachedPtr, true);
												_ = _colorParticles;
												_ = _colorParticles;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BCA0]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag2 = obj5 == null;
												}
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1876 @ rax_v73 (should have been resolved before IL gen)");
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
												ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = (ParticleSystem.RotationOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
												((ParticleSystem.RotationOverLifetimeModule*)rotationOverLifetimeModule)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve3);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC98]");
												if ((nint)0 == 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
													bool flag3 = obj7 == null;
												}
												object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1907 @ rax_v78 (should have been resolved before IL gen)");
												Transform transform2 = _colorParticles.transform;
												bool flag4 = (object)transform2 == null;
												bool flag5 = ((List<string>)(object)transform2)._items == null;
												Vector3 value = default(Vector3);
												Transform.set_localPosition_Injected((IntPtr)((List<string>)(object)transform2)._items, ref value);
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
		throw new NullReferenceException();
	}

	private void SetIconSize()
	{
		//IL_0219->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_026d->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0102->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_012c->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0156->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0192->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_02d2->IL01b9: Incompatible stack heights: 3 vs 0
		//IL_031f->IL01b9: Incompatible stack heights: 4 vs 0
		if ((object)_Icon != null)
		{
			RectTransform rectTransform = _Icon.rectTransform;
			Image icon = _Icon;
			if ((object)_Icon != null)
			{
				Image sprite = (Image)(object)icon.m_Sprite;
				if ((object)icon.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image icon2 = _Icon;
					if ((object)_Icon != null)
					{
						object sprite2 = icon2.m_Sprite;
						if ((object)icon2.m_Sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v13 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rbx_v13 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 sizeDelta = default(Vector2);
								rectTransform.sizeDelta = sizeDelta;
								if ((object)_Icon != null)
								{
									Transform transform = _Icon.transform;
									if ((object)transform != null)
									{
										Transform parent = transform.parent;
										if ((object)parent != null)
										{
											Image component = parent.GetComponent<Image>();
											if ((object)component != null)
											{
												RectTransform rectTransform2 = component.rectTransform;
												object sprite3 = component.m_Sprite;
												if ((object)component.m_Sprite != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v14 (System.Object)+10]");
													bool flag3 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v14 (System.Object)+10]");
													Sprite.get_rect_Injected((IntPtr)0, out ret2);
													Image sprite4 = (Image)(object)component.m_Sprite;
													if ((object)component.m_Sprite != null)
													{
														bool flag4 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
														Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out ret);
														if ((object)rectTransform2 != null)
														{
															rectTransform2.sizeDelta = sizeDelta;
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
		throw new NullReferenceException();
	}

	private void _003CReceiveItem_003Eb__40_1()
	{
		View.Hide();
	}

	private void _003CReceiveItem_003Eb__40_2()
	{
		WarningPage.Corrupt = true;
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.FOREST;
		GM.Core.ResetGameToMenu();
	}

	private void _003COnShowStart_003Eb__42_0()
	{
		_ScrollView.SetParent(_Panel, worldPositionStays: true);
		Vector2 anchoredPosition = default(Vector2);
		_ScrollView.anchoredPosition = anchoredPosition;
	}

	private void _003CSetItemDisplay_003Eb__46_0()
	{
		Button component = _DiscardButton.GetComponent<Button>();
		component.interactable = true;
		Button component2 = _GetButton.GetComponent<Button>();
		component2.interactable = true;
		Button component3 = _GetButton.GetComponent<Button>();
		component3.Select();
		Button component4 = _GetButton.GetComponent<Button>();
		UnityAction call = Receive;
		component4.m_OnClick.AddListener(call);
	}

	private void _003CSetWeaponDisplay_003Eb__47_0()
	{
		Button component = _DiscardButton.GetComponent<Button>();
		component.interactable = true;
		Button component2 = _GetButton.GetComponent<Button>();
		component2.interactable = true;
		Button component3 = _GetButton.GetComponent<Button>();
		component3.Select();
		Button component4 = _GetButton.GetComponent<Button>();
		UnityAction call = Receive;
		component4.m_OnClick.AddListener(call);
	}
}
