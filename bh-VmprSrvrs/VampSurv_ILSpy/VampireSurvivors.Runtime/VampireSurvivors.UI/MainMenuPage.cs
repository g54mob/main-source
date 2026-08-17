using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Com.LuisPedroFonseca.ProCamera2D;
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
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cheats;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;
using VampireSurvivors.Signals;
using VampireSurvivors.Spells;
using Zenject;

namespace VampireSurvivors.UI;

public class MainMenuPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__90_1;

		public static Action _003C_003E9__92_0;

		public static Func<KeyValuePair<StageType, List<StageData>>, bool> _003C_003E9__98_0;

		public static Func<KeyValuePair<StageType, List<StageData>>, StageType> _003C_003E9__98_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CShowOnlineCheckEntitlementCallback_003Eb__90_1()
		{
		}

		internal void _003COnOnlineNotAllowed_003Eb__92_0()
		{
		}

		internal bool _003CGetValidQuickStages_003Eb__98_0(KeyValuePair<StageType, List<StageData>> kvp)
		{
			//IL_00f9: Expected O, but got I
			//IL_003d: Expected O, but got I
			//IL_0052: Expected O, but got I
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v6+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v9+68]");
				if ((nint)0 != 0 && (nint)kvp != 12 && (nint)kvp != 15)
				{
					object obj4 = kvp - 16;
					bool flag = obj4 == null;
					return !flag;
				}
				return false;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			bool result = default(bool);
			return result;
		}

		internal StageType _003CGetValidQuickStages_003Eb__98_1(KeyValuePair<StageType, List<StageData>> kvp)
		{
			//IL_0038: Expected I4, but got O
			//IL_0033: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A32D9]");
			if ((nint)0 == 0)
			{
				_ = 1;
				return (StageType)kvp;
			}
			return (StageType)kvp;
		}
	}

	private sealed class _003C_003Ec__DisplayClass74_0
	{
		public float current;

		public ParticleSystem.EmissionModule ps;

		public DOGetter<float> _003C_003E9__7;

		public DOSetter<float> _003C_003E9__8;

		public TweenCallback _003C_003E9__9;

		internal float _003CPlayAdventureUnlockAnimation_003Eb__3()
		{
			return current;
		}

		internal void _003CPlayAdventureUnlockAnimation_003Eb__4(float x)
		{
			current = x;
		}

		internal unsafe void _003CPlayAdventureUnlockAnimation_003Eb__5()
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0027: Expected O, but got Ref
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(current);
			ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(this + 24);
			object obj = default(object);
			((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj);
		}

		internal unsafe void _003CPlayAdventureUnlockAnimation_003Eb__6()
		{
			DOGetter<float> getter = _003C_003E9__7;
			if (_003C_003E9__7 == null)
			{
				DOGetter<float> dOGetter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				_003C_003E9__7 = dOGetter;
				getter = dOGetter;
			}
			DOSetter<float> setter = _003C_003E9__8;
			if (_003C_003E9__8 == null)
			{
				DOSetter<float> dOSetter = null;
				float x = default(float);
				((_003C_003Ec__DisplayClass74_0)(object)dOSetter)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
				_003C_003E9__8 = dOSetter;
				setter = dOSetter;
			}
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, 0f, 1f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 6;
					_ = 0;
				}
			}
			TweenCallback tweenCallback = _003C_003E9__9;
			if (_003C_003E9__9 == null)
			{
				tweenCallback = (_003C_003E9__9 = delegate
				{
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					//IL_001a: Expected O, but got Unknown
					//IL_0027: Expected O, but got Ref
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(current);
					ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(this + 24);
					object obj = default(object);
					((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj);
				});
			}
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		}

		internal float _003CPlayAdventureUnlockAnimation_003Eb__7()
		{
			return current;
		}

		internal void _003CPlayAdventureUnlockAnimation_003Eb__8(float x)
		{
			current = x;
		}

		internal unsafe void _003CPlayAdventureUnlockAnimation_003Eb__9()
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0027: Expected O, but got Ref
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(current);
			ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(this + 24);
			object obj = default(object);
			((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj);
		}
	}

	private sealed class _003CSetAdventuresPortraitLayout_003Ed__77(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_021d: Expected I4, but got I8
			MainMenuPage mainMenuPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				bool flag2 = (object)mainMenuPage._DLCStoreButton == null;
				Transform transform = mainMenuPage._DLCStoreButton.transform;
				bool flag3 = (object)transform == null;
				bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				bool flag5 = (object)mainMenuPage._StartButtonAdventureAnchor == null;
				Transform transform2 = mainMenuPage._StartButtonAdventureAnchor.transform;
				bool flag6 = (object)transform2 == null;
				bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
				bool flag8 = (object)mainMenuPage._AdventureButton == null;
				Transform transform3 = mainMenuPage._AdventureButton.transform;
				bool flag9 = (object)mainMenuPage._StartButtonAdventureAnchor == null;
				Transform transform4 = mainMenuPage._StartButtonAdventureAnchor.transform;
				bool flag10 = (object)transform4 == null;
				bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret2);
				bool flag12 = (object)transform3 == null;
				bool flag13 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
				bool flag14 = (object)mainMenuPage._AdventureShadow == null;
				Transform transform5 = mainMenuPage._AdventureShadow.transform;
				bool flag15 = (object)mainMenuPage._AdventureButton == null;
				Transform transform6 = mainMenuPage._AdventureButton.transform;
				bool flag16 = (object)transform6 == null;
				bool flag17 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out ret);
				bool flag18 = (object)transform5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v59 (UnityEngine.Transform)+10]");
				bool flag19 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v59 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref ret2);
				bool flag20 = (object)mainMenuPage._AdventureButton == null;
				mainMenuPage._AdventureButton.SetActive(value: true);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
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

	private sealed class _003CWaitAndReShow_003Ed__69(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00cf: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				GameObject gameObject = _003C_003E4__this.gameObject;
				_003C_003E4__this.OnShowStart(gameObject);
			}
			return false;
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

	private Selectable _FirstSelected;

	private GameObject _BestiaryButton;

	private GameObject _SecretsButton;

	private GameObject _PowerUpButton;

	private GameObject _StartButton;

	private GameObject _UnlocksButton;

	private GameObject _CollectionButton;

	private GameObject _CreditsButton;

	private Button _QuickStartButton;

	private GameObject _QuitButton;

	private GameObject _DlcButton;

	private GameObject _DLCStoreButton;

	private GameObject LogoAnchor;

	private GameObject _AdventureButton;

	private GameObject _OnlineButton;

	private Image _AdventureFader;

	private Image _AdventureShadow;

	private ParticleSystem _DustParticles;

	private Transform _MiddleVampire;

	private Transform _TitleLogo;

	private PixelateEffect _pixelEffect;

	private AscensionPanel _AscensionPanel;

	private Transform _StartButtonDefaultAnchor;

	private Transform _AdventureButtonDefaultAnchor;

	private Transform _PowerUpButtonDefaultAnchor;

	private Transform _CollectionButtonDefaultAnchor;

	private Transform _BestiaryButtonDefaultAnchor;

	private Transform _CreditsButtonDefaultAnchor;

	private Transform _UnlocksButtonDefaultAnchor;

	private Transform _SecretsButtonDefaultAnchor;

	private Transform _DLCStoreButtonDefaultAnchor;

	private Transform _QuickStartButtonDefaultAnchor;

	private Transform _StartButtonAdventureAnchor;

	private Transform _AdventureButtonAdventureAnchor;

	private Transform _PowerUpButtonAdventureAnchor;

	private Transform _CollectionButtonAdventureAnchor;

	private Transform _BestiaryButtonAdventureAnchor;

	private Transform _CreditsButtonAdventureAnchor;

	private Transform _UnlocksButtonAdventureAnchor;

	private Transform _SecretsButtonAdventureAnchor;

	private Transform _DLCStoreButtonAdventureAnchor;

	private Transform _QuickStartButtonAdventureAnchor;

	private DiContainer _diContainer;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private MultiplayerManager _multiplayerManager;

	private AdventureManager _adventureManager;

	private UnityServicesManager _unityServicesManager;

	private SpellsManager _spellsManager;

	private Material _pixelizer;

	private GameObject _automationButton;

	private IntroSceneCheatManager _cheats;

	private bool _doShadowGag;

	public PlayerOptions PlayerOptions => _playerOptions;

	private void Construct(SignalBus signal, DiContainer container, PlayerOptions player, DataManager dataManager, MultiplayerManager multiplayerManager, AdventureManager adventureManager, UnityServicesManager unityServicesManager, SpellsManager spellsManager)
	{
		//IL_0029: Expected O, but got I
		_signalBus = signal;
		_diContainer = container;
		_playerOptions = player;
		IntPtr intPtr = default(IntPtr);
		_dataManager = (DataManager)(nint)intPtr;
		MultiplayerManager multiplayerManager2 = default(MultiplayerManager);
		_multiplayerManager = multiplayerManager2;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
		UnityServicesManager unityServicesManager2 = default(UnityServicesManager);
		_unityServicesManager = unityServicesManager2;
		SpellsManager spellsManager2 = default(SpellsManager);
		_spellsManager = spellsManager2;
	}

	protected override void Awake()
	{
		base.Awake();
		_AutoSizeAfterParse = true;
	}

	private void Start()
	{
		//IL_02b4: Expected O, but got I4
		//IL_02b4: Expected O, but got I
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_0374: Expected O, but got I
		IntroSceneCheatManager cheats = _diContainer.Instantiate<IntroSceneCheatManager>();
		_cheats = cheats;
		_cheats.Initialize();
		AdventureManager adventureManager = _adventureManager;
		Action b = ReselectStartButton;
		Delegate obj = Delegate.Combine(adventureManager._003COnAdventureExitEvent_003Ek__BackingField, b);
		if ((object)obj != null)
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			obj = obj2;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj;
		AdventureManager adventureManager2 = _adventureManager;
		Action b2 = ExitAdventureLayout;
		Delegate obj3 = Delegate.Combine(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, b2);
		if ((object)obj3 != null)
		{
			bool flag3 = (object)obj3.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag3)
			{
				obj4 = obj3;
			}
			bool flag4 = (object)obj4 == null;
			obj3 = obj4;
			if (flag4)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj3;
		AdventureManager adventureManager3 = _adventureManager;
		Action b3 = HideAscensionPanel;
		Delegate obj5 = Delegate.Combine(adventureManager3._003COnAdventureExitEvent_003Ek__BackingField, b3);
		if ((object)obj5 != null)
		{
			bool flag5 = (object)obj5.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag5)
			{
				obj6 = obj5;
			}
			bool flag6 = (object)obj6 == null;
			obj5 = obj6;
			if (flag6)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager3._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj5;
		Action<UISignals.SetMainMenuPageVisibility> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F890");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rbx_v9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj7 = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetMainMenuPageVisibility>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<UISignals.SetMainMenuPageVisibility>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus = SignalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v36 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus.SubscribeInternal(signalType, (object)null, (object)0, callback);
	}

	protected override void Update()
	{
		_cheats.InternalUpdate();
	}

	private void OnDestroy()
	{
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		if (_cheats != null)
		{
			_cheats.Dispose();
		}
		AdventureManager adventureManager = _adventureManager;
		Action value = ReselectStartButton;
		Delegate obj = Delegate.Remove(adventureManager._003COnAdventureExitEvent_003Ek__BackingField, value);
		if ((object)obj != null)
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			obj = obj2;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj;
		AdventureManager adventureManager2 = _adventureManager;
		Action value2 = ExitAdventureLayout;
		Delegate obj3 = Delegate.Remove(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, value2);
		if ((object)obj3 != null)
		{
			bool flag3 = (object)obj3.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag3)
			{
				obj4 = obj3;
			}
			bool flag4 = (object)obj4 == null;
			obj3 = obj4;
			if (flag4)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj3;
		AdventureManager adventureManager3 = _adventureManager;
		Action value3 = HideAscensionPanel;
		Delegate obj5 = Delegate.Remove(adventureManager3._003COnAdventureExitEvent_003Ek__BackingField, value3);
		if ((object)obj5 != null)
		{
			bool flag5 = (object)obj5.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag5)
			{
				obj6 = obj5;
			}
			bool flag6 = (object)obj6 == null;
			obj5 = obj6;
			if (flag6)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager3._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj5;
		Action<UISignals.SetMainMenuPageVisibility> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F890");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		SignalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
	}

	private void ReselectStartButton()
	{
		Selectable component = _StartButton.GetComponent<Selectable>();
		component.Select();
	}

	private void Test(bool t)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !t;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "POPUP CLICKED : " + text;
		Debug.Log(message);
	}

	private bool HasAdventuresUnlocked()
	{
		//IL_0173: Expected I4, but got O
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			if (playerOptions._mainGameConfig != null)
			{
				List<ItemType> list = mainGameConfig._003CCollectedItems_003Ek__BackingField;
				if (mainGameConfig._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj = default(object);
						if ((nint)obj != -1)
						{
							return true;
						}
					}
					PlayerOptions playerOptions2 = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
						if (playerOptions2._mainGameConfig != null)
						{
							if (!mainGameConfig2._003CHasPlayedStage3_003Ek__BackingField)
							{
								return false;
							}
							if (_adventureManager != null)
							{
								return _adventureManager.HasLoadedAtLeastOneDlcWithAdventures();
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_057d: Expected I, but got O
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected O, but got Unknown
		//IL_059b: Expected O, but got I
		//IL_0709: Expected O, but got I4
		//IL_0839: Expected I, but got O
		//IL_0842: Expected O, but got I4
		//IL_0f40: Expected O, but got I4
		//IL_100d: Expected O, but got I4
		//IL_11e7: Expected O, but got I4
		//IL_101c: Expected O, but got I4
		//IL_09d5: Expected O, but got I4
		//IL_1059: Unknown result type (might be due to invalid IL or missing references)
		//IL_105e: Expected O, but got Unknown
		//IL_0f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f95: Expected O, but got Unknown
		//IL_0c1c: Expected O, but got I
		//IL_0fcd: Expected O, but got I
		//IL_0c41: Expected O, but got I
		//IL_0ff4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff9: Expected O, but got Unknown
		//IL_10c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c7: Expected O, but got Unknown
		//IL_10f6: Expected O, but got I
		//IL_1113: Expected O, but got I
		//IL_0b2b: Expected I, but got O
		//IL_0b34: Expected O, but got I4
		//IL_1187: Expected O, but got I
		//IL_0e27: Expected O, but got I
		//IL_11ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b3: Expected O, but got Unknown
		//IL_0d73->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0ba3->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0da1->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0bd1->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0c90->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0dcd->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0bfd->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0cbc->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_108a->IL0e2c: Incompatible stack heights: 2 vs 0
		//IL_0d00->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_0e03->IL0e2c: Incompatible stack heights: 2 vs 0
		//IL_0d2c->IL0e2c: Incompatible stack heights: 1 vs 0
		//IL_11fb->IL11b8: Incompatible stack heights: 4 vs 1
		//IL_11b8->IL11ec: Incompatible stack heights: 5 vs 4
		base.OnShowStart(g);
		PlayerOptions playerOptions = _playerOptions;
		_doShadowGag = false;
		if (_playerOptions != null)
		{
			if (playerOptions._003CJustGotJubilee_003Ek__BackingField)
			{
				playerOptions._003CJustGotJubilee_003Ek__BackingField = false;
				_doShadowGag = true;
			}
			if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
			{
				goto IL_01d3;
			}
			PlayerOptions playerOptions2 = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData mainGameConfig = playerOptions2._mainGameConfig;
				if (playerOptions2._mainGameConfig != null)
				{
					if (mainGameConfig._003CShouldPlayAdventureReveal_003Ek__BackingField && HasAdventuresUnlocked())
					{
						goto IL_01c8;
					}
					PlayerOptions playerOptions3 = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig2 = playerOptions3._mainGameConfig;
						if (playerOptions3._mainGameConfig != null)
						{
							if (mainGameConfig2._003CHasSeenAdventureReveal_003Ek__BackingField && HasAdventuresUnlocked())
							{
								SetAdventuresLayout();
								goto IL_01de;
							}
							if (HasAdventuresUnlocked())
							{
								goto IL_01c8;
							}
							goto IL_01d3;
						}
					}
				}
			}
		}
		goto IL_0e2c;
		IL_0b3a:
		GameObject dLCStoreButton = _DLCStoreButton;
		object obj3 = default(object);
		if ((object)_DLCStoreButton != null)
		{
			bool flag = ((UnityEngine.Object)dLCStoreButton).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)dLCStoreButton).m_CachedPtr);
			if (obj == null)
			{
				goto IL_11b8;
			}
			if (!UIHelper.IsPortrait)
			{
				if ((object)_DLCStoreButton != null)
				{
					Transform transform = _DLCStoreButton.transform;
					if ((object)_DlcButton != null)
					{
						Transform transform2 = _DlcButton.transform;
						if ((object)transform2 != null)
						{
							_ = 0;
							_ = 0;
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							object obj2 = obj3 - 16;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj2);
							bool flag3 = (object)transform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-8]");
							_ = 0;
							GameObject gameObject = (GameObject)(nint)((UnityEngine.Object)transform).m_CachedPtr;
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							object obj5 = 0;
							object obj6 = obj3 - 32;
							goto IL_11ec;
						}
					}
				}
			}
			else if ((object)_DLCStoreButton != null)
			{
				Transform transform3 = _DLCStoreButton.transform;
				if ((object)_FirstSelected != null)
				{
					Transform transform4 = _FirstSelected.transform;
					if ((object)transform4 != null)
					{
						_ = 0;
						_ = 0;
						bool flag5 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
						object obj7 = obj3 - 16;
						Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj7);
						if ((object)LogoAnchor != null)
						{
							Transform transform5 = LogoAnchor.transform;
							if ((object)transform5 != null)
							{
								_ = 0;
								_ = 0;
								bool flag6 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
								object obj8 = obj3 - 32;
								Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj8);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-1C]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-C]");
								object obj9 = num - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-8]");
								object obj10 = num2 - 0;
								float num3 = (float)obj9 * 0.5f;
								float num4 = (float)obj10 * 0.5f;
								float num5 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-C]");
								float num6 = num5 + 0f;
								float num7 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-8]");
								float num8 = num7 + 0f;
								bool flag7 = (object)transform3 == null;
								GameObject gameObject = (GameObject)(nint)((UnityEngine.Object)transform3).m_CachedPtr;
								bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								object obj5 = 0;
								object obj6 = obj3 - 16;
								goto IL_11ec;
							}
						}
					}
				}
			}
		}
		goto IL_0e2c;
		IL_01c8:
		PlayAdventureUnlockAnimation();
		goto IL_01de;
		IL_01d3:
		SetDefaultLayout();
		goto IL_01de;
		IL_0852:
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			goto IL_0b3a;
		}
		if ((object)_QuickStartButton != null)
		{
			GameObject gameObject2 = _QuickStartButton.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
				AdventureManager adventureManager = _adventureManager;
				if (_adventureManager != null)
				{
					PlayerOptions playerOptions4 = adventureManager._playerOptions;
					if (adventureManager._playerOptions != null)
					{
						PlayerOptionsData currentAdventureSaveData = playerOptions4._currentAdventureSaveData;
						if (playerOptions4._currentAdventureSaveData != null)
						{
							if (currentAdventureSaveData._003CAdventureCompletionCount_003Ek__BackingField <= 0)
							{
								if ((object)_AscensionPanel != null)
								{
									GameObject gameObject3 = _AscensionPanel.gameObject;
									if ((object)gameObject3 != null)
									{
										gameObject3.SetActive(value: false);
										object obj11 = 0;
										goto IL_0b3a;
									}
								}
							}
							else if ((object)_AscensionPanel != null)
							{
								GameObject gameObject4 = _AscensionPanel.gameObject;
								if ((object)gameObject4 != null)
								{
									gameObject4.SetActive(value: true);
									AdventureManager adventureManager2 = _adventureManager;
									if (_adventureManager != null)
									{
										PlayerOptions playerOptions5 = adventureManager2._playerOptions;
										AdventureManager adventureManager3 = _adventureManager;
										PlayerOptionsData adventurePod = ((adventureManager2._playerOptions == null) ? null : playerOptions5._currentAdventureSaveData);
										if ((object)_AscensionPanel != null)
										{
											_AscensionPanel.SetData(adventurePod, adventureManager3.CurrentAdventure);
											if ((object)_StartButton != null)
											{
												Selectable component = _StartButton.GetComponent<Selectable>();
												if ((object)_AscensionPanel != null)
												{
													_AscensionPanel.SetSelected(component);
													nint num9 = unchecked((nint)null);
													object obj11 = 0;
													goto IL_0b3a;
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
		goto IL_0e2c;
		IL_01de:
		if ((object)_FirstSelected != null)
		{
			_FirstSelected.Select();
			GameObject dlcButton = _DlcButton;
			if ((object)_DlcButton == null || ((UnityEngine.Object)dlcButton).m_CachedPtr == (IntPtr)0)
			{
				goto IL_034b;
			}
			List<DlcType> missingDlc = DlcSystem.GetMissingDlc();
			if (missingDlc != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v194 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0317;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null && config._003CUnlockedStages_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
						goto IL_0317;
					}
				}
			}
		}
		goto IL_0e2c;
		IL_0317:
		if ((object)_DlcButton != null)
		{
			_DlcButton.SetActive(value: false);
			goto IL_034b;
		}
		goto IL_0e2c;
		IL_034b:
		if ((object)_BestiaryButton != null && _playerOptions != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2 != null)
			{
				List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
				if (config2._003CCollectedItems_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v49 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
					bool active;
					if ((nint)0 == 0)
					{
						active = false;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v49 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						object obj13 = default(object);
						object obj12 = obj13 - -1;
						bool flag9 = obj12 == null;
						active = !flag9;
					}
					_BestiaryButton.SetActive(active);
					if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
					{
						if ((object)_SecretsButton == null)
						{
							goto IL_0e2c;
						}
						_SecretsButton.SetActive(value: false);
					}
					else
					{
						UpdateSecretsButtonVisibility();
					}
					if ((object)_SecretsButton != null)
					{
						Button component2 = _SecretsButton.GetComponent<Button>();
						if ((object)component2 != null)
						{
							bool interactable = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
							component2.interactable = interactable;
							if (!_doShadowGag)
							{
								goto IL_0605;
							}
							if ((object)_SecretsButton != null)
							{
								Image component3 = _SecretsButton.GetComponent<Image>();
								if ((object)component3 != null)
								{
									nint num9 = (nint)component3;
									Color color = (Color)(obj3 - 16);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F20]");
									_ = 0;
									component3.color = color;
									if ((object)_SecretsButton != null)
									{
										Button component4 = _SecretsButton.GetComponent<Button>();
										if ((object)component4 != null)
										{
											goto IL_0605;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0e2c;
		IL_0605:
		if (_playerOptions != null)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			if (config3 != null)
			{
				List<StageType> list2 = config3._003CUnlockedStages_003Ek__BackingField;
				if (config3._003CUnlockedStages_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ rax_v69 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
					if ((nint)0 < (nint)5)
					{
						if ((object)_QuickStartButton != null)
						{
							GameObject gameObject5 = _QuickStartButton.gameObject;
							if ((object)gameObject5 != null)
							{
								gameObject5.SetActive(value: false);
								object obj11 = 0;
								goto IL_0852;
							}
						}
					}
					else if ((object)_QuickStartButton != null)
					{
						GameObject gameObject6 = _QuickStartButton.gameObject;
						if ((object)gameObject6 != null)
						{
							gameObject6.SetActive(value: true);
							Button quickStartButton = _QuickStartButton;
							if ((object)_QuickStartButton != null && quickStartButton.m_OnClick != null)
							{
								quickStartButton.m_OnClick.RemoveAllListeners();
								Button quickStartButton2 = _QuickStartButton;
								if ((object)_QuickStartButton != null)
								{
									UnityAction call = QuickStartGame;
									if (quickStartButton2.m_OnClick != null)
									{
										quickStartButton2.m_OnClick.AddListener(call);
										nint num9 = unchecked((nint)null);
										object obj11 = 0;
										goto IL_0852;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0e2c;
		IL_11b8:
		UpdateUnlocksButtonText();
		if (_spellsManager != null)
		{
			SpellsManager._003CCachedStageType_003Ek__BackingField = (StageType?)(object)0;
			SpellsManager._003CCachedBgm_003Ek__BackingField = (BgmType?)(object)0;
			SpellsManager._003CCachedBgmMod_003Ek__BackingField = (BgmModType?)(object)0;
		}
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			return;
		}
		if (_playerOptions != null)
		{
			PlayerOptionsData config4 = _playerOptions.Config;
			if (config4 != null)
			{
				if (config4._003CShouldPlayAdventureReveal_003Ek__BackingField)
				{
					return;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config5 = _playerOptions.Config;
					if (config5 != null)
					{
						if (!config5._003CHasSeenAdventureReveal_003Ek__BackingField)
						{
						}
						return;
					}
				}
			}
		}
		goto IL_0e2c;
		IL_0e2c:
		throw new NullReferenceException();
		IL_11ec:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2761 @ rax_v107 (should have been resolved before IL gen)");
		goto IL_11b8;
	}

	private void SetMobileDlcStoreVisibility()
	{
	}

	private unsafe void OnAdventureAscended(bool result)
	{
		//IL_0042: Expected O, but got Ref
		//IL_0082: Expected O, but got Ref
		//IL_010c: Expected O, but got I4
		if (result)
		{
			AdventureManager adventureManager = _adventureManager;
			AdventureType adventureType = default(AdventureType);
			object arg = adventureType;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string message = string.FormatHelper((IFormatProvider)null, "Adventure ascension successful of type {0}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message);
			object arg2 = adventureType;
			paramsArray = new System.ParamsArray(arg2);
			string message2 = string.FormatHelper((IFormatProvider)null, "Re-initializing the Adventure of type {0}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message2);
			_adventureManager.InitAdventure(adventureManager.CurrentAdventure);
			AdventureManager adventureManager2 = _adventureManager;
			AscensionPanel ascensionPanel = _AscensionPanel;
			PlayerOptionsData playerOptionsData = (PlayerOptionsData)(object)adventureManager2._playerOptions;
			AdventureManager adventureManager3 = _adventureManager;
			if (adventureManager2._playerOptions != null)
			{
				playerOptionsData = (PlayerOptionsData)playerOptionsData._003CSelectedMaxWeapons_003Ek__BackingField;
			}
			ascensionPanel._adventurePod = playerOptionsData;
			ascensionPanel._adventureType = adventureManager3.CurrentAdventure;
			ascensionPanel.RefreshData();
			_AscensionPanel.RefreshData();
			AscensionPanel ascensionPanel2 = _AscensionPanel;
			ascensionPanel2._shouldGenerateNavigation = true;
			Selectable component = _StartButton.GetComponent<Selectable>();
			component.Select();
		}
	}

	private void HideAscensionPanel()
	{
		GameObject gameObject = _AscensionPanel.gameObject;
		gameObject.SetActive(value: false);
	}

	private void ExitAdventureLayout()
	{
		//IL_008f: Expected O, but got I4
		UpdateUnlocksButtonText();
		GameObject gameObject = base.gameObject;
		bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
		object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
		if (obj != null)
		{
			_003CWaitAndReShow_003Ed__69 obj2 = null;
			obj2._003C_003E1__state = 0;
			obj2._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj2);
		}
		Button component = _SecretsButton.GetComponent<Button>();
		component.interactable = true;
	}

	private IEnumerator WaitAndReShow()
	{
		_003CWaitAndReShow_003Ed__69 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
	}

	private void OnEnable()
	{
		//IL_0014: Expected I4, but got O
		AdventureManager adventureManager = _adventureManager;
		Action<bool> action = null;
		((MainMenuPage)(object)action).OnAdventureAscended((byte)(int)this != 0);
		Delegate obj = Delegate.Combine(adventureManager._003COnAdventureAscended_003Ek__BackingField, action);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
	}

	private void OnDisable()
	{
		//IL_0014: Expected I4, but got O
		AdventureManager adventureManager = _adventureManager;
		Action<bool> action = null;
		((MainMenuPage)(object)action).OnAdventureAscended((byte)(int)this != 0);
		Delegate obj = Delegate.Remove(adventureManager._003COnAdventureAscended_003Ek__BackingField, action);
		if ((object)obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			if ((object)obj == null)
			{
				throw new InvalidCastException();
			}
		}
		adventureManager._003COnAdventureAscended_003Ek__BackingField = (Action<bool>)obj;
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		_QuitButton.SetActive(value: false);
	}

	private unsafe void PlayAdventureUnlockAnimation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1079: Expected I, but got O
		//IL_10ba: Expected O, but got Ref
		//IL_0152: Expected O, but got Ref
		//IL_0191: Expected O, but got Ref
		//IL_1109: Expected O, but got Ref
		//IL_1163: Expected O, but got Ref
		//IL_11a1: Expected I, but got O
		//IL_11af: Expected O, but got Ref
		//IL_1218: Expected I, but got O
		//IL_1226: Expected O, but got Ref
		//IL_12bc: Expected O, but got Ref
		//IL_12df: Expected O, but got Ref
		//IL_136c: Expected O, but got Ref
		//IL_138f: Expected O, but got Ref
		//IL_0360->IL0360: Incompatible stack heights: 7 vs 6
		//IL_044a->IL1045: Incompatible stack heights: 7 vs 0
		//IL_040c->IL1045: Incompatible stack heights: 7 vs 0
		//IL_0557->IL1045: Incompatible stack heights: 7 vs 0
		//IL_0519->IL1045: Incompatible stack heights: 7 vs 0
		//IL_065f->IL1045: Incompatible stack heights: 7 vs 0
		//IL_0621->IL1045: Incompatible stack heights: 7 vs 0
		//IL_06f5->IL1045: Incompatible stack heights: 7 vs 0
		//IL_076c->IL1045: Incompatible stack heights: 7 vs 0
		//IL_087e->IL1045: Incompatible stack heights: 7 vs 0
		//IL_083e->IL1045: Incompatible stack heights: 7 vs 0
		//IL_08b6->IL1045: Incompatible stack heights: 7 vs 0
		//IL_0942->IL1045: Incompatible stack heights: 8 vs 0
		//IL_0a0d->IL1045: Incompatible stack heights: 8 vs 0
		//IL_09cd->IL1045: Incompatible stack heights: 8 vs 0
		//IL_0a45->IL1045: Incompatible stack heights: 8 vs 0
		//IL_0b0f->IL1045: Incompatible stack heights: 9 vs 0
		//IL_0ad1->IL1045: Incompatible stack heights: 9 vs 0
		//IL_0bd9->IL1045: Incompatible stack heights: 9 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Sequence sequence;
		TweenCallback tweenCallback6;
		if ((object)_AdventureButton != null)
		{
			Button component = _AdventureButton.GetComponent<Button>();
			if ((object)component != null)
			{
				component.interactable = false;
				SetDefaultLayout();
				if ((object)_AdventureButton != null)
				{
					_AdventureButton.SetActive(value: true);
					if ((object)_AdventureShadow != null)
					{
						GameObject gameObject = _AdventureShadow.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							if ((object)_AdventureButton != null)
							{
								Transform transform = _AdventureButton.transform;
								nint num = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ rcx_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num2 = 0;
								_ = Vector3.zeroVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v786 @ rax_v41 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								_ = 0;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
								Transform transform2 = _AdventureButton.transform;
								_ = 180f;
								Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								transform2.localEulerAngles = localEulerAngles;
								Transform transform3 = _AdventureShadow.transform;
								_ = 180f;
								Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								transform3.localEulerAngles = localEulerAngles2;
								RectTransform component2 = _AdventureButton.GetComponent<RectTransform>();
								Vector2 anchoredPosition = default(Vector2);
								component2.anchoredPosition = anchoredPosition;
								Transform transform4 = _AdventureShadow.transform;
								Transform transform5 = _AdventureButton.transform;
								_ = 0;
								_ = 0;
								bool flag2 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
								object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
								Transform.get_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out *(Vector3*)obj4);
								bool flag3 = (object)transform4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v53 (UnityEngine.Transform)+10]");
								bool flag4 = (nint)0 == 0;
								object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v879 @ rax_v53 (UnityEngine.Transform)+10]");
								Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj5);
								bool flag5 = (object)_AdventureShadow == null;
								_AdventureShadow.enabled = true;
								TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_AdventureFader, 0.4f, 0.6f);
								sequence = DOTween.Sequence();
								bool flag6 = (object)_AdventureButton == null;
								Transform target = _AdventureButton.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 5f, 0.6f);
								if (tweenerCore2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1581 @ rax_v70 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 18;
										_ = 0;
									}
								}
								if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
								{
									bool flag7 = sequence == null;
									Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, ((Tween)sequence).duration);
								}
								bool flag8 = (object)_AdventureButton == null;
								Transform target2 = _AdventureButton.transform;
								nint num3 = (nint)typeof(Vector3);
								Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1710 @ rcx_v67 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num4 = 0;
								_ = Vector3.zeroVector;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1713 @ rax_v76 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
								_ = 0;
								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, endValue, 0.6f);
								if (tweenerCore3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1716 @ rax_v78 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 18;
										_ = 0;
									}
								}
								if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore3, false))
								{
									if (sequence == null)
									{
										goto IL_1045;
									}
									Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore3, sequence.lastTweenInsertTime);
								}
								if ((object)_AdventureShadow != null)
								{
									RectTransform rectTransform = _AdventureShadow.rectTransform;
									TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore4 = DOTweenModuleUI.DOAnchorPosY(rectTransform, -260f, 0.6f);
									if (tweenerCore4 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1830 @ rax_v83 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 18;
											_ = 0;
										}
									}
									if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore4, false))
									{
										if (sequence == null)
										{
											goto IL_1045;
										}
										Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)tweenerCore4, sequence.lastTweenInsertTime);
									}
									if ((object)_AdventureShadow != null)
									{
										RectTransform rectTransform2 = _AdventureShadow.rectTransform;
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(rectTransform2, 3.6f, 0.6f);
										if (tweenerCore5 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1944 @ rax_v88 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
											if ((nint)0 != 0)
											{
												_ = 18;
												_ = 0;
											}
										}
										if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore5, false))
										{
											if (sequence == null)
											{
												goto IL_1045;
											}
											Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)tweenerCore5, sequence.lastTweenInsertTime);
										}
										if ((object)_AdventureShadow != null)
										{
											Transform target3 = _AdventureShadow.transform;
											nint num5 = (nint)typeof(Vector3);
											Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2073 @ rcx_v84 (Il2CppClass<UnityEngine.Vector3>)+B8]");
											nint num6 = 0;
											_ = Vector3.zeroVector;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2076 @ rax_v94 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
											_ = 0;
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DOLocalRotate(target3, endValue2, 0.6f);
											if (tweenerCore6 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2079 @ rax_v96 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 18;
													_ = 0;
												}
											}
											if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore6, false))
											{
												if (sequence == null)
												{
													goto IL_1045;
												}
												Sequence sequence6 = Sequence.DoInsert(sequence, (Tween)tweenerCore6, sequence.lastTweenInsertTime);
											}
											Sequence sequence7 = TweenSettingsExtensions.AppendInterval(sequence, 0.01f);
											Canvas.ForceUpdateCanvases();
											RectTransform component3 = GetComponent<RectTransform>();
											LayoutRebuilder.ForceRebuildLayoutImmediate(component3);
											if ((object)_AdventureButton != null)
											{
												Transform target4 = _AdventureButton.transform;
												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOScale(target4, 1f, 0.6f);
												if (tweenerCore7 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2229 @ rax_v107 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
													if ((nint)0 != 0)
													{
														_ = 26;
														_ = 1077936128;
														_ = 0;
													}
												}
												if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore7, false))
												{
													if (sequence == null)
													{
														goto IL_1045;
													}
													Sequence sequence8 = Sequence.DoInsert(sequence, (Tween)tweenerCore7, ((Tween)sequence).duration);
												}
												if ((object)_AdventureButton != null)
												{
													Transform target5 = _AdventureButton.transform;
													object adventureButtonAdventureAnchor = _AdventureButtonAdventureAnchor;
													if ((object)_AdventureButtonAdventureAnchor != null)
													{
														_ = 0;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rsi_v25 (System.Object)+10]");
														bool flag9 = (nint)0 == 0;
														object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rsi_v25 (System.Object)+10]");
														Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
														Vector3 endValue3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
														_ = 0;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore8 = ShortcutExtensions.DOMove(target5, endValue3, 0.6f);
														if (tweenerCore8 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2383 @ rax_v118 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 26;
																_ = 0;
															}
														}
														if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore8, false))
														{
															if (sequence == null)
															{
																goto IL_1045;
															}
															Sequence sequence9 = Sequence.DoInsert(sequence, (Tween)tweenerCore8, sequence.lastTweenInsertTime);
														}
														TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(_AdventureFader, 0f, 0.6f);
														if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
														{
															if (sequence == null)
															{
																goto IL_1045;
															}
															Sequence sequence10 = Sequence.DoInsert(sequence, (Tween)t, sequence.lastTweenInsertTime);
														}
														if ((object)_AdventureShadow != null)
														{
															Transform target6 = _AdventureShadow.transform;
															TweenerCore<Quaternion, Vector3, QuaternionOptions> adventureButtonAdventureAnchor2 = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)(object)_AdventureButtonAdventureAnchor;
															if ((object)_AdventureButtonAdventureAnchor != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
																bool flag10 = (nint)0 == 0;
																object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v28 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
																Vector3 endValue4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
																_ = 0;
																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore9 = ShortcutExtensions.DOMove(target6, endValue4, 0.6f);
																if (tweenerCore9 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2570 @ rax_v132 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																	if ((nint)0 != 0)
																	{
																		_ = 26;
																		_ = 0;
																	}
																}
																if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore9, false))
																{
																	if (sequence == null)
																	{
																		goto IL_1045;
																	}
																	Sequence sequence11 = Sequence.DoInsert(sequence, (Tween)tweenerCore9, sequence.lastTweenInsertTime);
																}
																if ((object)_AdventureShadow != null)
																{
																	Transform target7 = _AdventureShadow.transform;
																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore10 = ShortcutExtensions.DOScale(target7, 1f, 0.6f);
																	if (tweenerCore10 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2684 @ rax_v137 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																		if ((nint)0 != 0)
																		{
																			_ = 26;
																			_ = 0;
																		}
																	}
																	TweenCallback tweenCallback2;
																	if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore10, false))
																	{
																		if (sequence == null)
																		{
																			goto IL_1045;
																		}
																		Sequence sequence12 = Sequence.DoInsert(sequence, (Tween)tweenerCore10, sequence.lastTweenInsertTime);
																		TweenCallback tweenCallback = delegate
																		{
																			//IL_00f1: Expected O, but got I8
																			//IL_062e: Expected O, but got Ref
																			//IL_065d: Expected I, but got O
																			//IL_06a6: Expected O, but got Ref
																			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
																			//IL_03c6: Expected O, but got Unknown
																			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
																			//IL_03e2: Expected O, but got Unknown
																			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
																			//IL_03fe: Expected O, but got Unknown
																			//IL_0733: Expected O, but got I4
																			//IL_0743: Unknown result type (might be due to invalid IL or missing references)
																			//IL_0748: Expected O, but got Unknown
																			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
																			//IL_04ce: Expected O, but got Unknown
																			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
																			//IL_04ea: Expected O, but got Unknown
																			//IL_0501: Unknown result type (might be due to invalid IL or missing references)
																			//IL_0506: Expected O, but got Unknown
																			//IL_0785: Expected O, but got I4
																			//IL_0795: Unknown result type (might be due to invalid IL or missing references)
																			//IL_079a: Expected O, but got Unknown
																			//IL_0083->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_00b0->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_00df->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_060c->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_01c4->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_01f3->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_022a->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_0259->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_0286->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_02ba->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_02e6->IL05a9: Incompatible stack heights: 1 vs 0
																			_003C_003Ec__DisplayClass74_0 CS_0024_003C_003E8__locals55 = new _003C_003Ec__DisplayClass74_0();
																			float num7 = default(float);
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, null, 0f, 10, num7);
																			TweenButtonsDuringUnlockAnimation();
																			Canvas canvas = UIHelper.Canvas;
																			TweenerCore<float, float, FloatOptions> tweenerCore11;
																			if ((object)canvas != null)
																			{
																				bool flag12 = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
																				Canvas.set_renderMode_Injected(((UnityEngine.Object)canvas).m_CachedPtr, RenderMode.WorldSpace);
																				ProCamera2DShake instance = ProCamera2DShake.Instance;
																				if ((object)instance != null)
																				{
																					instance.Shake(0);
																					if ((object)_DustParticles != null)
																					{
																						_DustParticles.Play(withChildren: true);
																						if ((object)_DustParticles != null)
																						{
																							object obj8 = 6603577472L;
																							if (CS_0024_003C_003E8__locals55 != null)
																							{
																								CS_0024_003C_003E8__locals55.ps = (ParticleSystem.EmissionModule)_DustParticles;
																								CS_0024_003C_003E8__locals55.current = 0f;
																								Vector3 vector = default(Vector3);
																								Tweener tweener = ShortcutExtensions.DOPunchScale(_MiddleVampire, (Vector3)(&vector), 0.15f, 0, num7);
																								if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField)
																								{
																									((Tween)tweener).easeType = Ease.OutExpo;
																									((Tween)tweener).customEase = null;
																								}
																								nint num8 = (nint)typeof(Vector3);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																								nint num9 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
																								float num10 = 0f * 80f;
																								bool snapping = default(bool);
																								Tweener tweener2 = ShortcutExtensions.DOPunchPosition(_TitleLogo, (Vector3)(&vector), 0.15f, 0, num7, snapping);
																								if (tweener2 != null && ((Tween)tweener2)._003Cactive_003Ek__BackingField)
																								{
																									((Tween)tweener2).easeType = Ease.OutExpo;
																									((Tween)tweener2).customEase = null;
																								}
																								PlayerOptions playerOptions = _playerOptions;
																								if (_playerOptions != null)
																								{
																									PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
																									if (playerOptions._mainGameConfig != null)
																									{
																										mainGameConfig._003CHasSeenAdventureReveal_003Ek__BackingField = true;
																										PlayerOptions playerOptions2 = _playerOptions;
																										if (_playerOptions != null)
																										{
																											PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
																											if (playerOptions2._mainGameConfig != null)
																											{
																												mainGameConfig2._003CShouldPlayAdventureReveal_003Ek__BackingField = false;
																												if (_playerOptions != null)
																												{
																													_playerOptions.Save();
																													if ((object)_AdventureButton != null)
																													{
																														Button component4 = _AdventureButton.GetComponent<Button>();
																														if ((object)component4 != null)
																														{
																															component4.interactable = true;
																															DOGetter<float> getter = null;
																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																															DOSetter<float> dOSetter = null;
																															((_003C_003Ec__DisplayClass74_0)(object)dOSetter)._003CPlayAdventureUnlockAnimation_003Eb__4(80f);
																															tweenerCore11 = DOTween.To(getter, dOSetter, 2000f, 0.3f);
																															TweenCallback tweenCallback10;
																															if (tweenerCore11 != null)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																																if ((nint)0 != 0)
																																{
																																	_ = 24;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																																	bool flag13 = (nint)0 == 0;
																																	_ = 0;
																																	if (!flag13)
																																	{
																																		object obj9 = tweenerCore11 + 184;
																																		object obj10 = obj9 >> 12;
																																		object obj11 = obj10 & 0x1FFFFF;
																																		object obj12 = obj11 >> 6;
																																		object obj13 = obj11 & 0x3F;
																																		nint num12;
																																		do
																																		{
																																			object obj14 = 1 << (int)obj13;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			object obj15 = 0 | obj14;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			nint num11 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			if (num11 == 0)
																																			{
																																			}
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			num12 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																		}
																																		while (num12 != 0);
																																		TweenCallback tweenCallback9 = delegate
																																		{
																																			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																																			//IL_001a: Expected O, but got Unknown
																																			//IL_0027: Expected O, but got Ref
																																			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals55.current);
																																			ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals55 + 24);
																																			object obj23 = default(object);
																																			((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																																		};
																																		tweenCallback10 = tweenCallback9;
																																		goto IL_0471;
																																	}
																																}
																															}
																															TweenCallback tweenCallback11 = delegate
																															{
																																//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																																//IL_001a: Expected O, but got Unknown
																																//IL_0027: Expected O, but got Ref
																																ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals55.current);
																																ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals55 + 24);
																																object obj23 = default(object);
																																((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																															};
																															bool flag14 = tweenerCore11 == null;
																															tweenCallback10 = tweenCallback11;
																															if (!flag14)
																															{
																																goto IL_0471;
																															}
																															goto IL_053b;
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
																			IL_053b:
																			TweenCallback tweenCallback12 = delegate
																			{
																				DOGetter<float> getter2 = CS_0024_003C_003E8__locals55._003C_003E9__7;
																				if (CS_0024_003C_003E8__locals55._003C_003E9__7 == null)
																				{
																					DOGetter<float> dOGetter = null;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																					CS_0024_003C_003E8__locals55._003C_003E9__7 = dOGetter;
																					getter2 = dOGetter;
																				}
																				DOSetter<float> setter = CS_0024_003C_003E8__locals55._003C_003E9__8;
																				if (CS_0024_003C_003E8__locals55._003C_003E9__8 == null)
																				{
																					DOSetter<float> dOSetter2 = null;
																					float x = default(float);
																					((_003C_003Ec__DisplayClass74_0)(object)dOSetter2)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
																					CS_0024_003C_003E8__locals55._003C_003E9__8 = dOSetter2;
																					setter = dOSetter2;
																				}
																				TweenerCore<float, float, FloatOptions> tweenerCore12 = DOTween.To(getter2, setter, 0f, 1f);
																				if (tweenerCore12 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																					if ((nint)0 != 0)
																					{
																						_ = 6;
																						_ = 0;
																					}
																				}
																				TweenCallback tweenCallback15 = CS_0024_003C_003E8__locals55._003C_003E9__9;
																				if (CS_0024_003C_003E8__locals55._003C_003E9__9 == null)
																				{
																					tweenCallback15 = (CS_0024_003C_003E8__locals55._003C_003E9__9 = delegate
																					{
																						//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																						//IL_001a: Expected O, but got Unknown
																						//IL_0027: Expected O, but got Ref
																						ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals55.current);
																						ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals55 + 24);
																						object obj23 = default(object);
																						((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																					});
																				}
																				if (tweenerCore12 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																					if ((nint)0 == 0)
																					{
																					}
																				}
																			};
																			bool flag15 = tweenerCore11 == null;
																			TweenCallback tweenCallback13 = tweenCallback12;
																			if (flag15)
																			{
																				return;
																			}
																			goto IL_0579;
																			IL_0579:
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																			if ((nint)0 == 0)
																			{
																			}
																			return;
																			IL_0471:
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																				if ((nint)0 != 0)
																				{
																					object obj16 = tweenerCore11 + 112;
																					object obj17 = obj16 >> 12;
																					object obj18 = obj17 & 0x1FFFFF;
																					object obj19 = obj18 >> 6;
																					object obj20 = obj18 & 0x3F;
																					nint num14;
																					do
																					{
																						object obj21 = 1 << (int)obj20;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						object obj22 = 0 | obj21;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						nint num13 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						if (num13 == 0)
																						{
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						num14 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																					}
																					while (num14 != 0);
																					TweenCallback tweenCallback14 = delegate
																					{
																						DOGetter<float> getter2 = CS_0024_003C_003E8__locals55._003C_003E9__7;
																						if (CS_0024_003C_003E8__locals55._003C_003E9__7 == null)
																						{
																							DOGetter<float> dOGetter = null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																							CS_0024_003C_003E8__locals55._003C_003E9__7 = dOGetter;
																							getter2 = dOGetter;
																						}
																						DOSetter<float> setter = CS_0024_003C_003E8__locals55._003C_003E9__8;
																						if (CS_0024_003C_003E8__locals55._003C_003E9__8 == null)
																						{
																							DOSetter<float> dOSetter2 = null;
																							float x = default(float);
																							((_003C_003Ec__DisplayClass74_0)(object)dOSetter2)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
																							CS_0024_003C_003E8__locals55._003C_003E9__8 = dOSetter2;
																							setter = dOSetter2;
																						}
																						TweenerCore<float, float, FloatOptions> tweenerCore12 = DOTween.To(getter2, setter, 0f, 1f);
																						if (tweenerCore12 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																							if ((nint)0 != 0)
																							{
																								_ = 6;
																								_ = 0;
																							}
																						}
																						TweenCallback tweenCallback15 = CS_0024_003C_003E8__locals55._003C_003E9__9;
																						if (CS_0024_003C_003E8__locals55._003C_003E9__9 == null)
																						{
																							tweenCallback15 = (CS_0024_003C_003E8__locals55._003C_003E9__9 = delegate
																							{
																								//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																								//IL_001a: Expected O, but got Unknown
																								//IL_0027: Expected O, but got Ref
																								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals55.current);
																								ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals55 + 24);
																								object obj23 = default(object);
																								((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																							});
																						}
																						if (tweenerCore12 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																							if ((nint)0 == 0)
																							{
																							}
																						}
																					};
																					tweenCallback13 = tweenCallback14;
																					goto IL_0579;
																				}
																			}
																			goto IL_053b;
																		};
																		tweenCallback2 = tweenCallback;
																	}
																	else
																	{
																		TweenCallback tweenCallback3 = delegate
																		{
																			//IL_00f1: Expected O, but got I8
																			//IL_062e: Expected O, but got Ref
																			//IL_065d: Expected I, but got O
																			//IL_06a6: Expected O, but got Ref
																			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
																			//IL_03c6: Expected O, but got Unknown
																			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
																			//IL_03e2: Expected O, but got Unknown
																			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
																			//IL_03fe: Expected O, but got Unknown
																			//IL_0733: Expected O, but got I4
																			//IL_0743: Unknown result type (might be due to invalid IL or missing references)
																			//IL_0748: Expected O, but got Unknown
																			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
																			//IL_04ce: Expected O, but got Unknown
																			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
																			//IL_04ea: Expected O, but got Unknown
																			//IL_0501: Unknown result type (might be due to invalid IL or missing references)
																			//IL_0506: Expected O, but got Unknown
																			//IL_0785: Expected O, but got I4
																			//IL_0795: Unknown result type (might be due to invalid IL or missing references)
																			//IL_079a: Expected O, but got Unknown
																			//IL_0083->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_00b0->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_00df->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_060c->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_01c4->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_01f3->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_022a->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_0259->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_0286->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_02ba->IL05a9: Incompatible stack heights: 1 vs 0
																			//IL_02e6->IL05a9: Incompatible stack heights: 1 vs 0
																			_003C_003Ec__DisplayClass74_0 CS_0024_003C_003E8__locals59 = new _003C_003Ec__DisplayClass74_0();
																			float num7 = default(float);
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, null, 0f, 10, num7);
																			TweenButtonsDuringUnlockAnimation();
																			Canvas canvas = UIHelper.Canvas;
																			TweenerCore<float, float, FloatOptions> tweenerCore11;
																			if ((object)canvas != null)
																			{
																				bool flag12 = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
																				Canvas.set_renderMode_Injected(((UnityEngine.Object)canvas).m_CachedPtr, RenderMode.WorldSpace);
																				ProCamera2DShake instance = ProCamera2DShake.Instance;
																				if ((object)instance != null)
																				{
																					instance.Shake(0);
																					if ((object)_DustParticles != null)
																					{
																						_DustParticles.Play(withChildren: true);
																						if ((object)_DustParticles != null)
																						{
																							object obj8 = 6603577472L;
																							if (CS_0024_003C_003E8__locals59 != null)
																							{
																								CS_0024_003C_003E8__locals59.ps = (ParticleSystem.EmissionModule)_DustParticles;
																								CS_0024_003C_003E8__locals59.current = 0f;
																								Vector3 vector = default(Vector3);
																								Tweener tweener = ShortcutExtensions.DOPunchScale(_MiddleVampire, (Vector3)(&vector), 0.15f, 0, num7);
																								if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField)
																								{
																									((Tween)tweener).easeType = Ease.OutExpo;
																									((Tween)tweener).customEase = null;
																								}
																								nint num8 = (nint)typeof(Vector3);
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																								nint num9 = 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
																								float num10 = 0f * 80f;
																								bool snapping = default(bool);
																								Tweener tweener2 = ShortcutExtensions.DOPunchPosition(_TitleLogo, (Vector3)(&vector), 0.15f, 0, num7, snapping);
																								if (tweener2 != null && ((Tween)tweener2)._003Cactive_003Ek__BackingField)
																								{
																									((Tween)tweener2).easeType = Ease.OutExpo;
																									((Tween)tweener2).customEase = null;
																								}
																								PlayerOptions playerOptions = _playerOptions;
																								if (_playerOptions != null)
																								{
																									PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
																									if (playerOptions._mainGameConfig != null)
																									{
																										mainGameConfig._003CHasSeenAdventureReveal_003Ek__BackingField = true;
																										PlayerOptions playerOptions2 = _playerOptions;
																										if (_playerOptions != null)
																										{
																											PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
																											if (playerOptions2._mainGameConfig != null)
																											{
																												mainGameConfig2._003CShouldPlayAdventureReveal_003Ek__BackingField = false;
																												if (_playerOptions != null)
																												{
																													_playerOptions.Save();
																													if ((object)_AdventureButton != null)
																													{
																														Button component4 = _AdventureButton.GetComponent<Button>();
																														if ((object)component4 != null)
																														{
																															component4.interactable = true;
																															DOGetter<float> getter = null;
																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																															DOSetter<float> dOSetter = null;
																															((_003C_003Ec__DisplayClass74_0)(object)dOSetter)._003CPlayAdventureUnlockAnimation_003Eb__4(80f);
																															tweenerCore11 = DOTween.To(getter, dOSetter, 2000f, 0.3f);
																															TweenCallback tweenCallback10;
																															if (tweenerCore11 != null)
																															{
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																																if ((nint)0 != 0)
																																{
																																	_ = 24;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																																	bool flag13 = (nint)0 == 0;
																																	_ = 0;
																																	if (!flag13)
																																	{
																																		object obj9 = tweenerCore11 + 184;
																																		object obj10 = obj9 >> 12;
																																		object obj11 = obj10 & 0x1FFFFF;
																																		object obj12 = obj11 >> 6;
																																		object obj13 = obj11 & 0x3F;
																																		nint num12;
																																		do
																																		{
																																			object obj14 = 1 << (int)obj13;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			object obj15 = 0 | obj14;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			nint num11 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			if (num11 == 0)
																																			{
																																			}
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																			num12 = 0;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																																		}
																																		while (num12 != 0);
																																		TweenCallback tweenCallback9 = delegate
																																		{
																																			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																																			//IL_001a: Expected O, but got Unknown
																																			//IL_0027: Expected O, but got Ref
																																			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals59.current);
																																			ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals59 + 24);
																																			object obj23 = default(object);
																																			((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																																		};
																																		tweenCallback10 = tweenCallback9;
																																		goto IL_0471;
																																	}
																																}
																															}
																															TweenCallback tweenCallback11 = delegate
																															{
																																//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																																//IL_001a: Expected O, but got Unknown
																																//IL_0027: Expected O, but got Ref
																																ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals59.current);
																																ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals59 + 24);
																																object obj23 = default(object);
																																((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																															};
																															bool flag14 = tweenerCore11 == null;
																															tweenCallback10 = tweenCallback11;
																															if (!flag14)
																															{
																																goto IL_0471;
																															}
																															goto IL_053b;
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
																			IL_053b:
																			TweenCallback tweenCallback12 = delegate
																			{
																				DOGetter<float> getter2 = CS_0024_003C_003E8__locals59._003C_003E9__7;
																				if (CS_0024_003C_003E8__locals59._003C_003E9__7 == null)
																				{
																					DOGetter<float> dOGetter = null;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																					CS_0024_003C_003E8__locals59._003C_003E9__7 = dOGetter;
																					getter2 = dOGetter;
																				}
																				DOSetter<float> setter = CS_0024_003C_003E8__locals59._003C_003E9__8;
																				if (CS_0024_003C_003E8__locals59._003C_003E9__8 == null)
																				{
																					DOSetter<float> dOSetter2 = null;
																					float x = default(float);
																					((_003C_003Ec__DisplayClass74_0)(object)dOSetter2)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
																					CS_0024_003C_003E8__locals59._003C_003E9__8 = dOSetter2;
																					setter = dOSetter2;
																				}
																				TweenerCore<float, float, FloatOptions> tweenerCore12 = DOTween.To(getter2, setter, 0f, 1f);
																				if (tweenerCore12 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																					if ((nint)0 != 0)
																					{
																						_ = 6;
																						_ = 0;
																					}
																				}
																				TweenCallback tweenCallback15 = CS_0024_003C_003E8__locals59._003C_003E9__9;
																				if (CS_0024_003C_003E8__locals59._003C_003E9__9 == null)
																				{
																					tweenCallback15 = (CS_0024_003C_003E8__locals59._003C_003E9__9 = delegate
																					{
																						//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																						//IL_001a: Expected O, but got Unknown
																						//IL_0027: Expected O, but got Ref
																						ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals59.current);
																						ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals59 + 24);
																						object obj23 = default(object);
																						((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																					});
																				}
																				if (tweenerCore12 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																					if ((nint)0 == 0)
																					{
																					}
																				}
																			};
																			bool flag15 = tweenerCore11 == null;
																			TweenCallback tweenCallback13 = tweenCallback12;
																			if (flag15)
																			{
																				return;
																			}
																			goto IL_0579;
																			IL_0579:
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																			if ((nint)0 == 0)
																			{
																			}
																			return;
																			IL_0471:
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																			if ((nint)0 != 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																				if ((nint)0 != 0)
																				{
																					object obj16 = tweenerCore11 + 112;
																					object obj17 = obj16 >> 12;
																					object obj18 = obj17 & 0x1FFFFF;
																					object obj19 = obj18 >> 6;
																					object obj20 = obj18 & 0x3F;
																					nint num14;
																					do
																					{
																						object obj21 = 1 << (int)obj20;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						object obj22 = 0 | obj21;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						nint num13 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						if (num13 == 0)
																						{
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																						num14 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
																					}
																					while (num14 != 0);
																					TweenCallback tweenCallback14 = delegate
																					{
																						DOGetter<float> getter2 = CS_0024_003C_003E8__locals59._003C_003E9__7;
																						if (CS_0024_003C_003E8__locals59._003C_003E9__7 == null)
																						{
																							DOGetter<float> dOGetter = null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																							CS_0024_003C_003E8__locals59._003C_003E9__7 = dOGetter;
																							getter2 = dOGetter;
																						}
																						DOSetter<float> setter = CS_0024_003C_003E8__locals59._003C_003E9__8;
																						if (CS_0024_003C_003E8__locals59._003C_003E9__8 == null)
																						{
																							DOSetter<float> dOSetter2 = null;
																							float x = default(float);
																							((_003C_003Ec__DisplayClass74_0)(object)dOSetter2)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
																							CS_0024_003C_003E8__locals59._003C_003E9__8 = dOSetter2;
																							setter = dOSetter2;
																						}
																						TweenerCore<float, float, FloatOptions> tweenerCore12 = DOTween.To(getter2, setter, 0f, 1f);
																						if (tweenerCore12 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																							if ((nint)0 != 0)
																							{
																								_ = 6;
																								_ = 0;
																							}
																						}
																						TweenCallback tweenCallback15 = CS_0024_003C_003E8__locals59._003C_003E9__9;
																						if (CS_0024_003C_003E8__locals59._003C_003E9__9 == null)
																						{
																							tweenCallback15 = (CS_0024_003C_003E8__locals59._003C_003E9__9 = delegate
																							{
																								//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																								//IL_001a: Expected O, but got Unknown
																								//IL_0027: Expected O, but got Ref
																								ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals59.current);
																								ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals59 + 24);
																								object obj23 = default(object);
																								((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj23);
																							});
																						}
																						if (tweenerCore12 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
																							if ((nint)0 == 0)
																							{
																							}
																						}
																					};
																					tweenCallback13 = tweenCallback14;
																					goto IL_0579;
																				}
																			}
																			goto IL_053b;
																		};
																		bool flag11 = sequence == null;
																		tweenCallback2 = tweenCallback3;
																		if (flag11)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
																			if ((nint)0 == 0)
																			{
																				_ = 1;
																			}
																			Debugger.LogWarning("You can't add elements to a NULL Sequence");
																			TweenCallback tweenCallback4 = delegate
																			{
																				CanvasGroup component4 = GetComponent<CanvasGroup>();
																				component4.interactable = false;
																			};
																			goto IL_0eb3;
																		}
																	}
																	object message;
																	if (((Tween)sequence)._003Cactive_003Ek__BackingField)
																	{
																		if (!((Tween)sequence).creationLocked)
																		{
																			if (tweenCallback2 != null)
																			{
																				Sequence sequence13 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
																				goto IL_0d7c;
																			}
																			TweenCallback tweenCallback5 = delegate
																			{
																				CanvasGroup component4 = GetComponent<CanvasGroup>();
																				component4.interactable = false;
																			};
																			if (sequence != null)
																			{
																				tweenCallback6 = tweenCallback5;
																				goto IL_0d9a;
																			}
																			goto IL_0eb3;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
																		if ((nint)0 == 0)
																		{
																			_ = 1;
																		}
																		message = "You can't add elements to an inactive/killed Sequence";
																	}
																	Debugger.LogWarning(message);
																	goto IL_0d7c;
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
		goto IL_1045;
		IL_0d9a:
		object message2;
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback6 != null)
				{
					Sequence sequence14 = Sequence.DoInsertCallback(sequence, tweenCallback6, ((Tween)sequence).duration);
				}
				goto IL_0ee6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_1493;
		IL_1493:
		Debugger.LogWarning(message2);
		goto IL_0ee6;
		IL_0ee6:
		Sequence sequence15 = TweenSettingsExtensions.AppendInterval(sequence, 1f);
		TweenCallback tweenCallback7 = delegate
		{
			CanvasGroup component4 = GetComponent<CanvasGroup>();
			component4.interactable = true;
		};
		Tween t2;
		object message3;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback7 != null)
					{
						Sequence sequence16 = Sequence.DoInsertCallback(sequence, tweenCallback7, ((Tween)sequence).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t2 = null;
				message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t2 = null;
				message3 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t2 = null;
			message3 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message3, t2);
		return;
		IL_1045:
		throw new NullReferenceException();
		IL_0eb3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		message2 = "You can't add elements to a NULL Sequence";
		goto IL_1493;
		IL_0d7c:
		TweenCallback tweenCallback8 = delegate
		{
			CanvasGroup component4 = GetComponent<CanvasGroup>();
			component4.interactable = false;
		};
		tweenCallback6 = tweenCallback8;
		goto IL_0d9a;
	}

	private unsafe void TweenButtonsDuringUnlockAnimation()
	{
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected O, but got Unknown
		//IL_0687: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Expected O, but got Unknown
		//IL_0731: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c0: Expected O, but got Unknown
		//IL_07db: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Expected O, but got Unknown
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0890: Expected O, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_091d: Expected O, but got Unknown
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Expected O, but got Unknown
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Expected O, but got Unknown
		//IL_09eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Expected O, but got Unknown
		//IL_0a78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7d: Expected O, but got Unknown
		//IL_0a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa0: Expected O, but got Unknown
		//IL_0b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Expected O, but got Unknown
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Expected O, but got Unknown
		//IL_0bd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bdd: Expected O, but got Unknown
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Expected O, but got Unknown
		//IL_0c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8a: Expected O, but got Unknown
		//IL_0ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caa: Expected O, but got Unknown
		//IL_00bc->IL0628: Incompatible stack heights: 1 vs 0
		//IL_00f4->IL0628: Incompatible stack heights: 1 vs 0
		//IL_0159->IL0628: Incompatible stack heights: 2 vs 0
		//IL_0191->IL0628: Incompatible stack heights: 2 vs 0
		//IL_01f6->IL0628: Incompatible stack heights: 3 vs 0
		//IL_022e->IL0628: Incompatible stack heights: 3 vs 0
		//IL_0293->IL0628: Incompatible stack heights: 4 vs 0
		//IL_02cb->IL0628: Incompatible stack heights: 4 vs 0
		//IL_0330->IL0628: Incompatible stack heights: 5 vs 0
		//IL_0368->IL0628: Incompatible stack heights: 5 vs 0
		//IL_03cd->IL0628: Incompatible stack heights: 6 vs 0
		//IL_0405->IL0628: Incompatible stack heights: 6 vs 0
		//IL_046a->IL0628: Incompatible stack heights: 7 vs 0
		//IL_04a2->IL0628: Incompatible stack heights: 7 vs 0
		//IL_0507->IL0628: Incompatible stack heights: 8 vs 0
		//IL_053f->IL0628: Incompatible stack heights: 8 vs 0
		//IL_05a4->IL0628: Incompatible stack heights: 9 vs 0
		//IL_05dc->IL0628: Incompatible stack heights: 9 vs 0
		if ((object)_StartButton != null)
		{
			Transform target = _StartButton.transform;
			Transform startButtonAdventureAnchor = _StartButtonAdventureAnchor;
			if ((object)_StartButtonAdventureAnchor != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)startButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 72;
				Transform.get_position_Injected(((UnityEngine.Object)startButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj);
				Vector3 endValue = (Vector3)(obj2 - 56);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
				_ = 0;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(target, endValue, 0.3f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rax_v62 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 27;
						_ = 1077936128;
						_ = 0;
					}
				}
				if ((object)_PowerUpButton != null)
				{
					Transform target2 = _PowerUpButton.transform;
					Transform powerUpButtonAdventureAnchor = _PowerUpButtonAdventureAnchor;
					if ((object)_PowerUpButtonAdventureAnchor != null)
					{
						_ = 0;
						_ = 0;
						bool flag2 = ((UnityEngine.Object)powerUpButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
						object obj3 = obj2 - 72;
						Transform.get_position_Injected(((UnityEngine.Object)powerUpButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj3);
						Vector3 endValue2 = (Vector3)(obj2 - 56);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
						_ = 0;
						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOMove(target2, endValue2, 0.3f);
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v946 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 27;
								_ = 1077936128;
								_ = 0;
							}
						}
						if ((object)_CreditsButton != null)
						{
							Transform target3 = _CreditsButton.transform;
							Transform creditsButtonAdventureAnchor = _CreditsButtonAdventureAnchor;
							if ((object)_CreditsButtonAdventureAnchor != null)
							{
								_ = 0;
								_ = 0;
								bool flag3 = ((UnityEngine.Object)creditsButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
								object obj4 = obj2 - 72;
								Transform.get_position_Injected(((UnityEngine.Object)creditsButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj4);
								Vector3 endValue3 = (Vector3)(obj2 - 56);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
								_ = 0;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOMove(target3, endValue3, 0.3f);
								if (tweenerCore3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1242 @ rax_v80 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 27;
										_ = 1077936128;
										_ = 0;
									}
								}
								if ((object)_CollectionButton != null)
								{
									Transform target4 = _CollectionButton.transform;
									object collectionButtonAdventureAnchor = _CollectionButtonAdventureAnchor;
									if ((object)_CollectionButtonAdventureAnchor != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v25 (System.Object)+10]");
										bool flag4 = (nint)0 == 0;
										object obj5 = obj2 - 72;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rbx_v25 (System.Object)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
										Vector3 endValue4 = (Vector3)(obj2 - 56);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
										_ = 0;
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOMove(target4, endValue4, 0.3f);
										if (tweenerCore4 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1500 @ rax_v89 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
											if ((nint)0 != 0)
											{
												_ = 27;
												_ = 1077936128;
												_ = 0;
											}
										}
										if ((object)_BestiaryButton != null)
										{
											Transform target5 = _BestiaryButton.transform;
											object bestiaryButtonAdventureAnchor = _BestiaryButtonAdventureAnchor;
											if ((object)_BestiaryButtonAdventureAnchor != null)
											{
												_ = 0;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v26 (System.Object)+10]");
												bool flag5 = (nint)0 == 0;
												object obj6 = obj2 - 72;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rbx_v26 (System.Object)+10]");
												Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
												Vector3 endValue5 = (Vector3)(obj2 - 56);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
												_ = 0;
												TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOMove(target5, endValue5, 0.3f);
												if (tweenerCore5 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1841 @ rax_v98 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
													if ((nint)0 != 0)
													{
														_ = 27;
														_ = 1077936128;
														_ = 0;
													}
												}
												if ((object)_UnlocksButton != null)
												{
													Transform target6 = _UnlocksButton.transform;
													object unlocksButtonAdventureAnchor = _UnlocksButtonAdventureAnchor;
													if ((object)_UnlocksButtonAdventureAnchor != null)
													{
														_ = 0;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v27 (System.Object)+10]");
														bool flag6 = (nint)0 == 0;
														object obj7 = obj2 - 72;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rbx_v27 (System.Object)+10]");
														Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj7);
														Vector3 endValue6 = (Vector3)(obj2 - 56);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
														_ = 0;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOMove(target6, endValue6, 0.3f);
														if (tweenerCore6 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2025 @ rax_v107 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 27;
																_ = 1077936128;
																_ = 0;
															}
														}
														if ((object)_SecretsButton != null)
														{
															Transform target7 = _SecretsButton.transform;
															object secretsButtonAdventureAnchor = _SecretsButtonAdventureAnchor;
															if ((object)_SecretsButtonAdventureAnchor != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v28 (System.Object)+10]");
																bool flag7 = (nint)0 == 0;
																object obj8 = obj2 - 72;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v28 (System.Object)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj8);
																Vector3 endValue7 = (Vector3)(obj2 - 56);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																_ = 0;
																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOMove(target7, endValue7, 0.3f);
																if (tweenerCore7 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2149 @ rax_v116 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																	if ((nint)0 != 0)
																	{
																		_ = 27;
																		_ = 1077936128;
																		_ = 0;
																	}
																}
																if ((object)_DLCStoreButton != null)
																{
																	Transform target8 = _DLCStoreButton.transform;
																	object dLCStoreButtonAdventureAnchor = _DLCStoreButtonAdventureAnchor;
																	if ((object)_DLCStoreButtonAdventureAnchor != null)
																	{
																		_ = 0;
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Object)+10]");
																		bool flag8 = (nint)0 == 0;
																		object obj9 = obj2 - 72;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rbx_v29 (System.Object)+10]");
																		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj9);
																		Vector3 endValue8 = (Vector3)(obj2 - 56);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																		_ = 0;
																		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore8 = ShortcutExtensions.DOMove(target8, endValue8, 0.3f);
																		if (tweenerCore8 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2273 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																			if ((nint)0 != 0)
																			{
																				_ = 27;
																				_ = 1077936128;
																				_ = 0;
																			}
																		}
																		if ((object)_QuickStartButton != null)
																		{
																			Transform target9 = _QuickStartButton.transform;
																			object quickStartButtonAdventureAnchor = _QuickStartButtonAdventureAnchor;
																			if ((object)_QuickStartButtonAdventureAnchor != null)
																			{
																				_ = 0;
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v30 (System.Object)+10]");
																				bool flag9 = (nint)0 == 0;
																				object obj10 = obj2 - 72;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v30 (System.Object)+10]");
																				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj10);
																				Vector3 endValue9 = (Vector3)(obj2 - 56);
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																				_ = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																				_ = 0;
																				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore9 = ShortcutExtensions.DOMove(target9, endValue9, 0.3f);
																				if (tweenerCore9 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2397 @ rax_v134 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																					if ((nint)0 != 0)
																					{
																						_ = 27;
																						_ = 1077936128;
																						_ = 0;
																					}
																				}
																				if ((object)_DlcButton != null)
																				{
																					Transform target10 = _DlcButton.transform;
																					Transform dLCStoreButtonAdventureAnchor2 = _DLCStoreButtonAdventureAnchor;
																					if ((object)_DLCStoreButtonAdventureAnchor != null)
																					{
																						_ = 0;
																						_ = 0;
																						bool flag10 = ((UnityEngine.Object)dLCStoreButtonAdventureAnchor2).m_CachedPtr == (IntPtr)0;
																						object obj11 = obj2 - 72;
																						Transform.get_position_Injected(((UnityEngine.Object)dLCStoreButtonAdventureAnchor2).m_CachedPtr, out *(Vector3*)obj11);
																						Vector3 endValue10 = (Vector3)(obj2 - 56);
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-48]");
																						_ = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
																						_ = 0;
																						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore10 = ShortcutExtensions.DOMove(target10, endValue10, 0.3f);
																						if (tweenerCore10 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2521 @ rax_v143 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																							if ((nint)0 != 0)
																							{
																								_ = 27;
																								_ = 1077936128;
																								_ = 0;
																							}
																						}
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
		throw new NullReferenceException();
	}

	private unsafe void SetAdventuresLayout()
	{
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Expected O, but got Unknown
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected O, but got Unknown
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Expected O, but got Unknown
		//IL_076d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Expected O, but got Unknown
		//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c9: Expected O, but got Unknown
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected O, but got Unknown
		//IL_0880: Unknown result type (might be due to invalid IL or missing references)
		//IL_0885: Expected O, but got Unknown
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Expected O, but got Unknown
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Expected O, but got Unknown
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Expected O, but got Unknown
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a09: Expected O, but got Unknown
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Expected O, but got Unknown
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Expected O, but got Unknown
		//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b33: Expected O, but got Unknown
		//IL_0b88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_0bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf5: Expected O, but got Unknown
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Expected O, but got Unknown
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb7: Expected O, but got Unknown
		//IL_0d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Expected O, but got Unknown
		//IL_0d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d79: Expected O, but got Unknown
		//IL_0dce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd3: Expected O, but got Unknown
		//IL_0595->IL05b6: Incompatible stack heights: 59 vs 0
		if ((object)_StartButton != null)
		{
			Transform transform = _StartButton.transform;
			Transform startButtonAdventureAnchor = _StartButtonAdventureAnchor;
			if ((object)_StartButtonAdventureAnchor != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)startButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)startButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj);
				bool flag2 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
				bool flag4 = (object)_PowerUpButton == null;
				Transform transform2 = _PowerUpButton.transform;
				Transform powerUpButtonAdventureAnchor = _PowerUpButtonAdventureAnchor;
				bool flag5 = (object)_PowerUpButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				bool flag6 = ((UnityEngine.Object)powerUpButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
				object obj4 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)powerUpButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj4);
				bool flag7 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj5 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj5);
				bool flag9 = (object)_CreditsButton == null;
				Transform transform3 = _CreditsButton.transform;
				Transform creditsButtonAdventureAnchor = _CreditsButtonAdventureAnchor;
				bool flag10 = (object)_CreditsButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				bool flag11 = ((UnityEngine.Object)creditsButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
				object obj6 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)creditsButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj6);
				bool flag12 = (object)transform3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag13 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				object obj7 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj7);
				bool flag14 = (object)_CollectionButton == null;
				Transform transform4 = _CollectionButton.transform;
				Transform collectionButtonAdventureAnchor = _CollectionButtonAdventureAnchor;
				bool flag15 = (object)_CollectionButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				bool flag16 = ((UnityEngine.Object)collectionButtonAdventureAnchor).m_CachedPtr == (IntPtr)0;
				object obj8 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)collectionButtonAdventureAnchor).m_CachedPtr, out *(Vector3*)obj8);
				bool flag17 = (object)transform4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag18 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				object obj9 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj9);
				bool flag19 = (object)_BestiaryButton == null;
				Transform transform5 = _BestiaryButton.transform;
				object bestiaryButtonAdventureAnchor = _BestiaryButtonAdventureAnchor;
				bool flag20 = (object)_BestiaryButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rbx_v65 (System.Object)+10]");
				bool flag21 = (nint)0 == 0;
				object obj10 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1079 @ rbx_v65 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj10);
				bool flag22 = (object)transform5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag23 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				object obj11 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)obj11);
				bool flag24 = (object)_UnlocksButton == null;
				Transform transform6 = _UnlocksButton.transform;
				object unlocksButtonAdventureAnchor = _UnlocksButtonAdventureAnchor;
				bool flag25 = (object)_UnlocksButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1237 @ rbx_v67 (System.Object)+10]");
				bool flag26 = (nint)0 == 0;
				object obj12 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1237 @ rbx_v67 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj12);
				bool flag27 = (object)transform6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag28 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				object obj13 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj13);
				bool flag29 = (object)_SecretsButton == null;
				Transform transform7 = _SecretsButton.transform;
				object secretsButtonAdventureAnchor = _SecretsButtonAdventureAnchor;
				bool flag30 = (object)_SecretsButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rbx_v69 (System.Object)+10]");
				bool flag31 = (nint)0 == 0;
				object obj14 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rbx_v69 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj14);
				bool flag32 = (object)transform7 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag33 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
				object obj15 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj15);
				bool flag34 = (object)_AdventureButton == null;
				Transform transform8 = _AdventureButton.transform;
				object adventureButtonAdventureAnchor = _AdventureButtonAdventureAnchor;
				bool flag35 = (object)_AdventureButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rbx_v71 (System.Object)+10]");
				bool flag36 = (nint)0 == 0;
				object obj16 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1661 @ rbx_v71 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj16);
				bool flag37 = (object)transform8 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag38 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
				object obj17 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Vector3*)obj17);
				bool flag39 = (object)_DLCStoreButton == null;
				Transform transform9 = _DLCStoreButton.transform;
				object dLCStoreButtonAdventureAnchor = _DLCStoreButtonAdventureAnchor;
				bool flag40 = (object)_DLCStoreButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1889 @ rbx_v73 (System.Object)+10]");
				bool flag41 = (nint)0 == 0;
				object obj18 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1889 @ rbx_v73 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj18);
				bool flag42 = (object)transform9 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag43 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
				object obj19 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, ref *(Vector3*)obj19);
				bool flag44 = (object)_DlcButton == null;
				Transform transform10 = _DlcButton.transform;
				object dLCStoreButtonAdventureAnchor2 = _DLCStoreButtonAdventureAnchor;
				bool flag45 = (object)_DLCStoreButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2116 @ rbx_v75 (System.Object)+10]");
				bool flag46 = (nint)0 == 0;
				object obj20 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2116 @ rbx_v75 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj20);
				bool flag47 = (object)transform10 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag48 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
				object obj21 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform10).m_CachedPtr, ref *(Vector3*)obj21);
				bool flag49 = (object)_QuickStartButton == null;
				Transform transform11 = _QuickStartButton.transform;
				object quickStartButtonDefaultAnchor = _QuickStartButtonDefaultAnchor;
				bool flag50 = (object)_QuickStartButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2272 @ rbx_v77 (System.Object)+10]");
				bool flag51 = (nint)0 == 0;
				object obj22 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2272 @ rbx_v77 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj22);
				bool flag52 = (object)transform11 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag53 = ((UnityEngine.Object)transform11).m_CachedPtr == (IntPtr)0;
				object obj23 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform11).m_CachedPtr, ref *(Vector3*)obj23);
				bool flag54 = (object)_AdventureButton == null;
				_AdventureButton.SetActive(value: true);
				bool flag55 = (object)_AdventureShadow == null;
				GameObject gameObject = _AdventureShadow.gameObject;
				bool flag56 = (object)gameObject == null;
				gameObject.SetActive(value: false);
				bool flag57 = (object)_OnlineButton == null;
				_OnlineButton.SetActive(value: true);
				bool flag58 = (object)_QuickStartButton == null;
				GameObject gameObject2 = _QuickStartButton.gameObject;
				bool flag59 = (object)gameObject2 == null;
				gameObject2.SetActive(value: true);
				Transform automationButton = (Transform)(object)_automationButton;
				if ((object)_automationButton != null && ((UnityEngine.Object)automationButton).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_automationButton == null)
					{
						goto IL_05b6;
					}
					_automationButton.SetActive(value: true);
				}
				UpdateSecretsButtonVisibility();
				return;
			}
		}
		goto IL_05b6;
		IL_05b6:
		throw new NullReferenceException();
	}

	private IEnumerator SetAdventuresPortraitLayout()
	{
		_003CSetAdventuresPortraitLayout_003Ed__77 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SetDefaultLayout()
	{
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected O, but got Unknown
		//IL_06d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0732: Expected O, but got Unknown
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Expected O, but got Unknown
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Expected O, but got Unknown
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08aa: Expected O, but got Unknown
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Expected O, but got Unknown
		//IL_0967: Unknown result type (might be due to invalid IL or missing references)
		//IL_096c: Expected O, but got Unknown
		//IL_09cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d4: Expected O, but got Unknown
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2e: Expected O, but got Unknown
		//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Expected O, but got Unknown
		//IL_0aeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Expected O, but got Unknown
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b58: Expected O, but got Unknown
		//IL_0bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Expected O, but got Unknown
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Expected O, but got Unknown
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c74: Expected O, but got Unknown
		//IL_0cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdc: Expected O, but got Unknown
		//IL_0d31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d36: Expected O, but got Unknown
		//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9e: Expected O, but got Unknown
		//IL_0df3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df8: Expected O, but got Unknown
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Expected I4, but got Unknown
		//IL_0599->IL05c1: Incompatible stack heights: 59 vs 0
		if ((object)_StartButton != null)
		{
			Transform transform = _StartButton.transform;
			Transform startButtonDefaultAnchor = _StartButtonDefaultAnchor;
			if ((object)_StartButtonDefaultAnchor != null)
			{
				_ = 0;
				_ = 0;
				bool flag = ((UnityEngine.Object)startButtonDefaultAnchor).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)startButtonDefaultAnchor).m_CachedPtr, out *(Vector3*)obj);
				bool flag2 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
				bool flag4 = (object)_PowerUpButton == null;
				Transform transform2 = _PowerUpButton.transform;
				Transform powerUpButtonDefaultAnchor = _PowerUpButtonDefaultAnchor;
				bool flag5 = (object)_PowerUpButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				bool flag6 = ((UnityEngine.Object)powerUpButtonDefaultAnchor).m_CachedPtr == (IntPtr)0;
				object obj4 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)powerUpButtonDefaultAnchor).m_CachedPtr, out *(Vector3*)obj4);
				bool flag7 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag8 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj5 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj5);
				bool flag9 = (object)_CreditsButton == null;
				Transform transform3 = _CreditsButton.transform;
				Transform creditsButtonDefaultAnchor = _CreditsButtonDefaultAnchor;
				bool flag10 = (object)_CreditsButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				bool flag11 = ((UnityEngine.Object)creditsButtonDefaultAnchor).m_CachedPtr == (IntPtr)0;
				object obj6 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)creditsButtonDefaultAnchor).m_CachedPtr, out *(Vector3*)obj6);
				bool flag12 = (object)transform3 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag13 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				object obj7 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj7);
				bool flag14 = (object)_CollectionButton == null;
				Transform transform4 = _CollectionButton.transform;
				Transform collectionButtonDefaultAnchor = _CollectionButtonDefaultAnchor;
				bool flag15 = (object)_CollectionButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				bool flag16 = ((UnityEngine.Object)collectionButtonDefaultAnchor).m_CachedPtr == (IntPtr)0;
				object obj8 = obj2 - 48;
				Transform.get_position_Injected(((UnityEngine.Object)collectionButtonDefaultAnchor).m_CachedPtr, out *(Vector3*)obj8);
				bool flag17 = (object)transform4 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag18 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
				object obj9 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)obj9);
				bool flag19 = (object)_BestiaryButton == null;
				Transform transform5 = _BestiaryButton.transform;
				object bestiaryButtonDefaultAnchor = _BestiaryButtonDefaultAnchor;
				bool flag20 = (object)_BestiaryButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1065 @ rbx_v65 (System.Object)+10]");
				bool flag21 = (nint)0 == 0;
				object obj10 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1065 @ rbx_v65 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj10);
				bool flag22 = (object)transform5 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag23 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				object obj11 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)obj11);
				bool flag24 = (object)_UnlocksButton == null;
				Transform transform6 = _UnlocksButton.transform;
				object unlocksButtonDefaultAnchor = _UnlocksButtonDefaultAnchor;
				bool flag25 = (object)_UnlocksButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rbx_v67 (System.Object)+10]");
				bool flag26 = (nint)0 == 0;
				object obj12 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1223 @ rbx_v67 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj12);
				bool flag27 = (object)transform6 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag28 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				object obj13 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj13);
				bool flag29 = (object)_SecretsButton == null;
				Transform transform7 = _SecretsButton.transform;
				object secretsButtonDefaultAnchor = _SecretsButtonDefaultAnchor;
				bool flag30 = (object)_SecretsButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1488 @ rbx_v69 (System.Object)+10]");
				bool flag31 = (nint)0 == 0;
				object obj14 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1488 @ rbx_v69 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj14);
				bool flag32 = (object)transform7 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag33 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
				object obj15 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, ref *(Vector3*)obj15);
				bool flag34 = (object)_AdventureButton == null;
				Transform transform8 = _AdventureButton.transform;
				object adventureButtonDefaultAnchor = _AdventureButtonDefaultAnchor;
				bool flag35 = (object)_AdventureButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1647 @ rbx_v71 (System.Object)+10]");
				bool flag36 = (nint)0 == 0;
				object obj16 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1647 @ rbx_v71 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj16);
				bool flag37 = (object)transform8 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag38 = ((UnityEngine.Object)transform8).m_CachedPtr == (IntPtr)0;
				object obj17 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform8).m_CachedPtr, ref *(Vector3*)obj17);
				bool flag39 = (object)_DLCStoreButton == null;
				Transform transform9 = _DLCStoreButton.transform;
				object dLCStoreButtonDefaultAnchor = _DLCStoreButtonDefaultAnchor;
				bool flag40 = (object)_DLCStoreButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1875 @ rbx_v73 (System.Object)+10]");
				bool flag41 = (nint)0 == 0;
				object obj18 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1875 @ rbx_v73 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj18);
				bool flag42 = (object)transform9 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag43 = ((UnityEngine.Object)transform9).m_CachedPtr == (IntPtr)0;
				object obj19 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform9).m_CachedPtr, ref *(Vector3*)obj19);
				bool flag44 = (object)_QuickStartButton == null;
				Transform transform10 = _QuickStartButton.transform;
				object quickStartButtonDefaultAnchor = _QuickStartButtonDefaultAnchor;
				bool flag45 = (object)_QuickStartButtonDefaultAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2102 @ rbx_v75 (System.Object)+10]");
				bool flag46 = (nint)0 == 0;
				object obj20 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2102 @ rbx_v75 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj20);
				bool flag47 = (object)transform10 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag48 = ((UnityEngine.Object)transform10).m_CachedPtr == (IntPtr)0;
				object obj21 = obj2 - 16;
				Transform.set_position_Injected(((UnityEngine.Object)transform10).m_CachedPtr, ref *(Vector3*)obj21);
				bool flag49 = (object)_DlcButton == null;
				Transform transform11 = _DlcButton.transform;
				object dLCStoreButtonAdventureAnchor = _DLCStoreButtonAdventureAnchor;
				bool flag50 = (object)_DLCStoreButtonAdventureAnchor == null;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2258 @ rbx_v77 (System.Object)+10]");
				bool flag51 = (nint)0 == 0;
				object obj22 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2258 @ rbx_v77 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj22);
				bool flag52 = (object)transform11 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-28]");
				_ = 0;
				bool flag53 = ((UnityEngine.Object)transform11).m_CachedPtr == (IntPtr)0;
				object obj23 = obj2 - 32;
				Transform.set_position_Injected(((UnityEngine.Object)transform11).m_CachedPtr, ref *(Vector3*)obj23);
				UpdateSecretsButtonVisibility();
				bool flag54 = (object)_AdventureButton == null;
				_AdventureButton.SetActive(value: false);
				bool flag55 = (object)_AdventureShadow == null;
				GameObject gameObject = _AdventureShadow.gameObject;
				bool flag56 = (object)gameObject == null;
				gameObject.SetActive(value: false);
				bool flag57 = (object)_OnlineButton == null;
				bool active = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
				_OnlineButton.SetActive(active);
				bool flag58 = (object)_QuickStartButton == null;
				GameObject gameObject2 = _QuickStartButton.gameObject;
				bool flag59 = (object)gameObject2 == null;
				bool active2 = !AdventureManager._003CIsInAdventureMode_003Ek__BackingField;
				gameObject2.SetActive(active2);
				GameObject automationButton = _automationButton;
				if ((object)_automationButton == null || ((UnityEngine.Object)automationButton).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
				if ((object)_automationButton != null)
				{
					object obj24 = default(object);
					bool active3 = (byte)(obj24 ^ 1) != 0;
					_automationButton.SetActive(active3);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void ShowAchievements()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F970");
	}

	public void ShowCollections()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FA20");
	}

	public void ShowDLCStore()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	private void SetVisibility(UISignals.SetMainMenuPageVisibility sig)
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		if ((object)sig == null)
		{
			component.alpha = 0f;
			component.interactable = false;
			component.blocksRaycasts = false;
		}
		else
		{
			component.alpha = 1f;
			component.interactable = true;
			component.blocksRaycasts = true;
		}
	}

	public void GetDlc()
	{
		Application.OpenURL("https://store.steampowered.com/dlc/1794680/Vampire_Survivors/");
	}

	public void ShowOptions()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FAD0");
	}

	public void ShowCredits()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void ShowPowerUps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FB80");
	}

	public void ShowCharacterSelect()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FC30");
	}

	public void ShowOnline()
	{
		//IL_005d: Expected I4, but got O
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance != null && OnlinePlatformSupport.OnlinePlatformSupportInstance.WaitForServerResponseOnEnteringOnline)
		{
			Action onClose = default(Action);
			PopupManager.CreateAccountBlockingPopup("OnlinePlatformSupportCommunicating", "", "", textisLocalizationTerm: false, onClose);
		}
		Action<bool> action = null;
		((MainMenuPage)(object)action)._003CShowOnline_003Eb__88_0((byte)(int)this != 0);
		OnlinePlatformSupport.CheckHasInternetConnection(action);
	}

	private void ShowOnlineCheckAgeOKCallback(bool isAgeOk)
	{
		//IL_003d: Expected I4, but got O
		if (!isAgeOk)
		{
			CloseOnlineCommunicatingPopup();
			bool titleIsLocalizationTerm = default(bool);
			bool descriptionIsLocalizationTerm = default(bool);
			PopupManager.CreateWarningPopup("OnlineAgeNotOk", "Age Check", "Age does not meet requirements for online play", null, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
		}
		else
		{
			Action<bool> action = null;
			((MainMenuPage)(object)action).ShowOnlineCheckEntitlementCallback((byte)(int)this != 0);
			OnlinePlatformSupport.CheckOnlineEntitlement(action);
		}
	}

	private void ShowOnlineCheckEntitlementCallback(bool hasEntitlement)
	{
		//IL_00eb: Expected I4, but got O
		//IL_00b5: Expected I4, but got O
		//IL_0120: Expected I4, but got O
		MainMenuPage mainMenuPage = this;
		if (!hasEntitlement)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 66 Invalid \"Jump target not found in method: 0x186D0EEF0\"");
			MainMenuPage mainMenuPage2 = default(MainMenuPage);
			mainMenuPage = mainMenuPage2;
		}
		PlayerOptionsData config = mainMenuPage._playerOptions.Config;
		if (!config._003CAcceptedEULA_003Ek__BackingField)
		{
			mainMenuPage.CloseOnlineCommunicatingPopup();
			Action action = mainMenuPage._003CShowOnlineCheckEntitlementCallback_003Eb__90_0;
			bool button2TextIsLocalizationTerm = (byte)(int)_003C_003Ec._003C_003E9__90_1 != 0;
			if (_003C_003Ec._003C_003E9__90_1 == null)
			{
				button2TextIsLocalizationTerm = (byte)(int)(_003C_003Ec._003C_003E9__90_1 = delegate
				{
				}) != 0;
			}
			Action button1Callback = default(Action);
			Action button2Callback = default(Action);
			bool titleIsLocalizationTerm = default(bool);
			bool descriptionIsLocalizationTerm = default(bool);
			PopupManager.CreateEULAPopup("EULAPopup", "lang/account_privacy_policy_title", "lang/account_privacy_policy_accept", "lang/account_privacy_policy_decline", button1Callback, button2Callback, titleIsLocalizationTerm, descriptionIsLocalizationTerm, (byte)(int)action != 0, button2TextIsLocalizationTerm);
		}
		else
		{
			mainMenuPage.CloseOnlineCommunicatingPopup();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A978D0");
		}
	}

	private void CloseOnlineCommunicatingPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A32C6]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance != null && OnlinePlatformSupport.OnlinePlatformSupportInstance.WaitForServerResponseOnEnteringOnline)
		{
			PopupManager.ClosePopup("OnlinePlatformSupportCommunicating");
		}
	}

	private void OnOnlineNotAllowed()
	{
		CloseOnlineCommunicatingPopup();
		Action callback = _003C_003Ec._003C_003E9__92_0;
		if (_003C_003Ec._003C_003E9__92_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__92_0 = delegate
			{
			});
		}
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		PopupManager.CreateWarningPopup("OnlineNotAllowed", "Online Entitlement", "Online play is not available to user", callback, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
	}

	public void ShowBestiary()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FCE0");
	}

	public unsafe void ShowSecrets()
	{
		//IL_0021: Expected I, but got O
		//IL_002e: Expected O, but got Ref
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		Image component = _SecretsButton.GetComponent<Image>();
		nint num = (nint)component;
		object obj = default(object);
		component.color = (Color)(&obj);
		Button component2 = _SecretsButton.GetComponent<Button>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	public void ShowAdventuresView()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FD90");
	}

	private void QuickStartGame()
	{
		//IL_0051: Expected O, but got I
		//IL_012b: Expected O, but got I4
		//IL_0134: Expected O, but got I4
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_0345: Expected O, but got I
		//IL_035a: Expected O, but got I
		//IL_036f: Expected O, but got I
		//IL_085f: Expected O, but got I
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Expected O, but got Unknown
		//IL_063f: Expected O, but got I
		//IL_03cc: Expected O, but got I
		//IL_03e1: Expected O, but got I
		//IL_03f7: Expected O, but got I
		//IL_0747: Expected O, but got I
		//IL_075c: Expected O, but got I
		List<CharacterType> validQuickCharacters = GetValidQuickCharacters();
		VampireSurvivors.App.Tools.Extensions.Shuffle(validQuickCharacters);
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData;
		PlayerOptionsData playerOptionsData;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rdx_v7+20]");
			config.SelectedCharacter = CharacterType.VOID;
			PlayerOptionsData config2 = _playerOptions.Config;
			List<StageType> validQuickStages = GetValidQuickStages();
			StageType stageType = VampireSurvivors.App.Tools.Extensions.PickRnd(validQuickStages);
			config2._003CSelectedStage_003Ek__BackingField = stageType;
			int playerCount = _multiplayerManager.GetPlayerCount();
			if (playerCount > 1 || _multiplayerManager.IsOnlineMultiplayer)
			{
				MultiplayerManager multiplayerManager = _multiplayerManager;
				List<CoopSlotData> slotsSelections = multiplayerManager._slotsSelections;
				object obj2 = 0;
				object obj3 = 0;
				while ((nint)obj3 < slotsSelections._size)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					if ((nint)obj4 >= 0)
					{
						CharacterType characterType = VampireSurvivors.App.Tools.Extensions.PickRnd(validQuickCharacters);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18047FAC0");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					obj2++;
					obj3 = obj2;
				}
			}
			convertedCharacterData = _dataManager.GetConvertedCharacterData();
			PlayerOptions playerOptions = _playerOptions;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
						if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							playerOptionsData = currentAdventureSaveData;
							goto IL_02b2;
						}
					}
					playerOptionsData = playerOptions._mainGameConfig;
				}
				else
				{
					playerOptionsData = playerOptions._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_02b2;
		}
		goto IL_088f;
		IL_0853:
		List<StageData> list = ((Dictionary<StageType, List<StageData>>)0).get_Item(StageType.SINKING);
		object obj5 = list + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		return;
		IL_05aa:
		Dictionary<StageType, List<StageData>> convertedStages;
		PlayerOptionsData playerOptionsData2;
		object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)playerOptionsData2._003CSelectedStage_003Ek__BackingField);
		PlayerOptionsData playerOptionsData3;
		if (obj6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v48 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v48 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_088f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v48 (System.Object)+10]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v49+20]");
				if ((nint)0 != 0)
				{
					PlayerOptions playerOptions2 = _playerOptions;
					if (playerOptions2._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions2._hostGameConfig == null)
						{
							if (playerOptions2._currentAdventureSaveData != null)
							{
								PlayerOptionsData currentAdventureSaveData2 = playerOptions2._currentAdventureSaveData;
								if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									playerOptionsData3 = currentAdventureSaveData2;
									goto IL_097a;
								}
							}
							playerOptionsData3 = playerOptions2._mainGameConfig;
						}
						else
						{
							playerOptionsData3 = playerOptions2._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
					}
					goto IL_097a;
				}
			}
		}
		goto IL_0853;
		IL_090f:
		PlayerOptionsData playerOptionsData4;
		BgmType bgmType;
		playerOptionsData4._003CSelectedBGM_003Ek__BackingField = bgmType;
		PlayerOptions playerOptions3 = _playerOptions;
		goto IL_09d0;
		IL_02b2:
		object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)playerOptionsData._selectedChar);
		if (obj8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v20 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v20 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_088f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v20 (System.Object)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rcx_v45+20]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v46+100]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rcx_v46+100]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rcx_v47+10]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v20 (System.Object)+10]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v61+20]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1060 @ rax_v62+100]");
						bgmType = Enum.Parse<BgmType>((string)0);
						PlayerOptions playerOptions4 = _playerOptions;
						if (playerOptions4._onlineClientWithRunDataConfig == null)
						{
							if (playerOptions4._hostGameConfig == null)
							{
								if (playerOptions4._currentAdventureSaveData != null)
								{
									playerOptionsData4 = playerOptions4._currentAdventureSaveData;
									if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_090f;
									}
								}
								playerOptionsData4 = playerOptions4._mainGameConfig;
							}
							else
							{
								playerOptionsData4 = playerOptions4._hostGameConfig;
							}
						}
						else
						{
							playerOptionsData4 = playerOptions4._onlineClientWithRunDataConfig;
						}
						goto IL_090f;
					}
				}
			}
		}
		convertedStages = _dataManager.GetConvertedStages();
		PlayerOptions playerOptions5 = _playerOptions;
		if (playerOptions5._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions5._hostGameConfig == null)
			{
				if (playerOptions5._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData3 = playerOptions5._currentAdventureSaveData;
					if ((object)currentAdventureSaveData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData2 = currentAdventureSaveData3;
						goto IL_05aa;
					}
				}
				playerOptionsData2 = playerOptions5._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions5._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions5._onlineClientWithRunDataConfig;
		}
		goto IL_05aa;
		IL_09a2:
		PlayerOptionsData playerOptionsData5;
		playerOptionsData5._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		goto IL_0853;
		IL_097a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v48 (System.Object)+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_088f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ rax_v48 (System.Object)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v52+20]");
		object obj15 = 0;
		PlayerOptionsData playerOptionsData6 = playerOptionsData3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rax_v53+6C]");
		playerOptionsData6._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Forest;
		playerOptions3 = _playerOptions;
		goto IL_09d0;
		IL_09d0:
		if (playerOptions3._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions3._hostGameConfig == null)
			{
				if (playerOptions3._currentAdventureSaveData != null)
				{
					playerOptionsData5 = playerOptions3._currentAdventureSaveData;
					if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_09a2;
					}
				}
				playerOptionsData5 = playerOptions3._mainGameConfig;
			}
			else
			{
				playerOptionsData5 = playerOptions3._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData5 = playerOptions3._onlineClientWithRunDataConfig;
		}
		goto IL_09a2;
		IL_088f:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private List<CharacterType> GetValidQuickCharacters()
	{
		//IL_0082: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_01ea: Expected O, but got I4
		//IL_01fc: Expected O, but got I4
		//IL_0213: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_026f: Expected O, but got I
		//IL_0289: Expected O, but got I
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030a: Expected O, but got Unknown
		List<CharacterType> list = new List<CharacterType>();
		PlayerOptionsData config = _playerOptions.Config;
		List<CharacterType> list2 = config._003CBoughtCharacters_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v11 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		List<System.Int32Enum> list4;
		if ((nint)0 <= (nint)0)
		{
			List<CharacterType> list3 = new List<CharacterType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v26+18]");
			if (num >= 0)
			{
				((List<System.Int32Enum>)(object)list3).AddWithResize((System.Int32Enum)1);
				list4 = (List<System.Int32Enum>)(object)list3;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 1;
				list4 = (List<System.Int32Enum>)(object)list3;
			}
		}
		else
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			Predicate<CharacterType> match = delegate(CharacterType c)
			{
				//IL_0071: Expected I4, but got O
				if (_dataManager != null)
				{
					Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
					if (convertedCharacterData != null)
					{
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)c);
						int num3 = num2 >> 31;
						return (byte)(num3 ^ 1) != 0;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			};
			List<System.Int32Enum> list5 = ((List<System.Int32Enum>)(object)config2._003CBoughtCharacters_003Ek__BackingField).FindAll((Predicate<System.Int32Enum>)(object)match);
			list4 = list5;
		}
		int playerCount = _multiplayerManager.GetPlayerCount();
		if (playerCount > 1 || _multiplayerManager.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			if ((nint)0 < (nint)4)
			{
				List<CharacterType> list6 = new List<CharacterType>();
				List<CharacterType> list7 = list6.FindAll((Predicate<CharacterType>)1);
				List<CharacterType> list8 = list6.FindAll((Predicate<CharacterType>)2);
				List<CharacterType> list9 = list6.FindAll((Predicate<CharacterType>)3);
				List<CharacterType> list10 = list6.FindAll((Predicate<CharacterType>)4);
				Predicate<CharacterType> predicate = null;
				List<CharacterType> result = default(List<CharacterType>);
				while (true)
				{
					Predicate<CharacterType> predicate2 = predicate;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					if ((nint)predicate2 >= 0)
					{
						break;
					}
					Predicate<CharacterType> predicate3 = predicate;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
					if ((nint)predicate3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ rax_v17 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
						object obj3 = 0;
						List<System.Int32Enum> list11 = list4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v16+20+v113 @ rbx_v9 (System.Predicate`1<VampireSurvivors.Data.CharacterType>)*4]");
						List<CharacterType> list12 = ((List<CharacterType>)(object)list11).FindAll((Predicate<CharacterType>)0);
						if (list12 == null)
						{
							List<CharacterType> match2 = list6.FindAll(predicate);
							List<CharacterType> list13 = ((List<CharacterType>)(object)list4).FindAll((Predicate<CharacterType>)(object)match2);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdi_v4 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						if ((nint)0 >= (nint)4)
						{
							break;
						}
						predicate = (Predicate<CharacterType>)(predicate + 1);
						continue;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					return result;
				}
			}
		}
		return (List<CharacterType>)(object)list4;
	}

	private List<StageType> GetValidQuickStages()
	{
		//IL_0040: Expected O, but got I
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0251: Expected O, but got I8
		//IL_00d4: Expected O, but got I
		//IL_021d: Expected O, but got I4
		//IL_00a0: Expected O, but got I8
		Dictionary<StageType, List<StageData>> availableStages = StageSelectPage.GetAvailableStages(_dataManager, _playerOptions);
		Func<KeyValuePair<StageType, List<StageData>>, bool> predicate = _003C_003Ec._003C_003E9__98_0;
		if (_003C_003Ec._003C_003E9__98_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__98_0 = delegate(KeyValuePair<StageType, List<StageData>> kvp)
			{
				//IL_00f9: Expected O, but got I
				//IL_003d: Expected O, but got I
				//IL_0052: Expected O, but got I
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c4: Expected O, but got Unknown
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [kvp @ rdx (System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>)+8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v6+20]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v9+68]");
					if ((nint)0 != 0 && (nint)kvp != 12 && (nint)kvp != 15)
					{
						object obj8 = kvp - 16;
						bool flag = obj8 == null;
						return !flag;
					}
					return false;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			});
		}
		IEnumerable<KeyValuePair<StageType, List<StageData>>> source = Enumerable.Where(availableStages, predicate);
		Func<KeyValuePair<StageType, List<StageData>>, StageType> selector = _003C_003Ec._003C_003E9__98_1;
		if (_003C_003Ec._003C_003E9__98_1 != null)
		{
			goto IL_00e6;
		}
		Func<KeyValuePair<StageType, List<StageData>>, StageType> func = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ r10_v3 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		_ = _003C_003Ec._003C_003E9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ r10_v3 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ r10_v3 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj3 = 6447978640L;
				goto IL_0214;
			}
		}
		else if (_003C_003Ec._003C_003E9 == null)
		{
			IEnumerable<StageType> enumerable = Enumerable.Select(null, (Func<KeyValuePair<StageType, List<StageData>>, StageType>)6570564832L);
			throw enumerable;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v27 (System.Func`2<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>, VampireSurvivors.Data.StageType>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v27 (System.Func`2<System.Collections.Generic.KeyValuePair`2<VampireSurvivors.Data.StageType, System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>>, VampireSurvivors.Data.StageType>)+20]");
		_ = 0;
		goto IL_0214;
		IL_0214:
		object obj4 = 24;
		_ = 6447978672L;
		_003C_003Ec._003C_003E9__98_1 = func;
		selector = func;
		goto IL_00e6;
		IL_00e6:
		IEnumerable<StageType> enumerable2 = Enumerable.Select(source, selector);
		if (enumerable2 != null)
		{
			return (List<StageType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable2);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void UpdateUnlocksButtonText()
	{
		TextMeshProUGUI componentInChildren = _UnlocksButton.GetComponentInChildren<TextMeshProUGUI>(includeInactive: false);
		bool ignoreRTLnumbers;
		bool fixForRTL;
		int maxLineLengthForRTL;
		string term;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			ignoreRTLnumbers = true;
			fixForRTL = true;
			maxLineLengthForRTL = 0;
			term = "lang/menu_unlocks";
		}
		else
		{
			ignoreRTLnumbers = true;
			fixForRTL = true;
			maxLineLengthForRTL = 0;
			term = "adventureLang/adv_adventureMenu_Progress";
		}
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, fixForRTL, maxLineLengthForRTL, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	private void UpdateSecretsButtonVisibility()
	{
		PlayerOptionsData config = _playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag;
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				flag = true;
				goto IL_0098;
			}
		}
		flag = CollectionsPage.IsMagician;
		goto IL_0098;
		IL_0098:
		bool flag2 = !flag;
		bool active = !flag2;
		_SecretsButton.SetActive(active);
	}

	private unsafe void _003CPlayAdventureUnlockAnimation_003Eb__74_0()
	{
		//IL_00f1: Expected O, but got I8
		//IL_062e: Expected O, but got Ref
		//IL_065d: Expected I, but got O
		//IL_06a6: Expected O, but got Ref
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_0733: Expected O, but got I4
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0748: Expected O, but got Unknown
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_0785: Expected O, but got I4
		//IL_0795: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_0083->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_00b0->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_00df->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_060c->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_01c4->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_01f3->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_022a->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_0259->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_0286->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_02ba->IL05a9: Incompatible stack heights: 1 vs 0
		//IL_02e6->IL05a9: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass74_0 CS_0024_003C_003E8__locals29 = new _003C_003Ec__DisplayClass74_0();
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, null, 0f, 10, num);
		TweenButtonsDuringUnlockAnimation();
		Canvas canvas = UIHelper.Canvas;
		TweenerCore<float, float, FloatOptions> tweenerCore;
		if ((object)canvas != null)
		{
			bool flag = ((UnityEngine.Object)canvas).m_CachedPtr == (IntPtr)0;
			Canvas.set_renderMode_Injected(((UnityEngine.Object)canvas).m_CachedPtr, RenderMode.WorldSpace);
			ProCamera2DShake instance = ProCamera2DShake.Instance;
			if ((object)instance != null)
			{
				instance.Shake(0);
				if ((object)_DustParticles != null)
				{
					_DustParticles.Play(withChildren: true);
					if ((object)_DustParticles != null)
					{
						object obj = 6603577472L;
						if (CS_0024_003C_003E8__locals29 != null)
						{
							CS_0024_003C_003E8__locals29.ps = (ParticleSystem.EmissionModule)_DustParticles;
							CS_0024_003C_003E8__locals29.current = 0f;
							Vector3 vector = default(Vector3);
							Tweener tweener = ShortcutExtensions.DOPunchScale(_MiddleVampire, (Vector3)(&vector), 0.15f, 0, num);
							if (tweener != null && ((Tween)tweener)._003Cactive_003Ek__BackingField)
							{
								((Tween)tweener).easeType = Ease.OutExpo;
								((Tween)tweener).customEase = null;
							}
							nint num2 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ rax_v31 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v833 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
							float num4 = 0f * 80f;
							bool snapping = default(bool);
							Tweener tweener2 = ShortcutExtensions.DOPunchPosition(_TitleLogo, (Vector3)(&vector), 0.15f, 0, num, snapping);
							if (tweener2 != null && ((Tween)tweener2)._003Cactive_003Ek__BackingField)
							{
								((Tween)tweener2).easeType = Ease.OutExpo;
								((Tween)tweener2).customEase = null;
							}
							PlayerOptions playerOptions = _playerOptions;
							if (_playerOptions != null)
							{
								PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
								if (playerOptions._mainGameConfig != null)
								{
									mainGameConfig._003CHasSeenAdventureReveal_003Ek__BackingField = true;
									PlayerOptions playerOptions2 = _playerOptions;
									if (_playerOptions != null)
									{
										PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
										if (playerOptions2._mainGameConfig != null)
										{
											mainGameConfig2._003CShouldPlayAdventureReveal_003Ek__BackingField = false;
											if (_playerOptions != null)
											{
												_playerOptions.Save();
												if ((object)_AdventureButton != null)
												{
													Button component = _AdventureButton.GetComponent<Button>();
													if ((object)component != null)
													{
														component.interactable = true;
														DOGetter<float> getter = null;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
														DOSetter<float> dOSetter = null;
														((_003C_003Ec__DisplayClass74_0)(object)dOSetter)._003CPlayAdventureUnlockAnimation_003Eb__4(80f);
														tweenerCore = DOTween.To(getter, dOSetter, 2000f, 0.3f);
														TweenCallback tweenCallback2;
														if (tweenerCore != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 24;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																bool flag2 = (nint)0 == 0;
																_ = 0;
																if (!flag2)
																{
																	object obj2 = tweenerCore + 184;
																	object obj3 = obj2 >> 12;
																	object obj4 = obj3 & 0x1FFFFF;
																	object obj5 = obj4 >> 6;
																	object obj6 = obj4 & 0x3F;
																	nint num6;
																	do
																	{
																		object obj7 = 1 << (int)obj6;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																		object obj8 = 0 | obj7;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																		nint num5 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																		if (num5 == 0)
																		{
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																		num6 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1040 @ rdx_v35*8]");
																	}
																	while (num6 != 0);
																	TweenCallback tweenCallback = delegate
																	{
																		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
																		//IL_001a: Expected O, but got Unknown
																		//IL_0027: Expected O, but got Ref
																		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals29.current);
																		ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals29 + 24);
																		object obj16 = default(object);
																		((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj16);
																	};
																	tweenCallback2 = tweenCallback;
																	goto IL_0471;
																}
															}
														}
														TweenCallback tweenCallback3 = delegate
														{
															//IL_0015: Unknown result type (might be due to invalid IL or missing references)
															//IL_001a: Expected O, but got Unknown
															//IL_0027: Expected O, but got Ref
															ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals29.current);
															ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals29 + 24);
															object obj16 = default(object);
															((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj16);
														};
														bool flag3 = tweenerCore == null;
														tweenCallback2 = tweenCallback3;
														if (!flag3)
														{
															goto IL_0471;
														}
														goto IL_053b;
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
		IL_053b:
		TweenCallback tweenCallback4 = delegate
		{
			DOGetter<float> getter2 = CS_0024_003C_003E8__locals29._003C_003E9__7;
			if (CS_0024_003C_003E8__locals29._003C_003E9__7 == null)
			{
				DOGetter<float> dOGetter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				CS_0024_003C_003E8__locals29._003C_003E9__7 = dOGetter;
				getter2 = dOGetter;
			}
			DOSetter<float> setter = CS_0024_003C_003E8__locals29._003C_003E9__8;
			if (CS_0024_003C_003E8__locals29._003C_003E9__8 == null)
			{
				DOSetter<float> dOSetter2 = null;
				float x = default(float);
				((_003C_003Ec__DisplayClass74_0)(object)dOSetter2)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
				CS_0024_003C_003E8__locals29._003C_003E9__8 = dOSetter2;
				setter = dOSetter2;
			}
			TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, setter, 0f, 1f);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 6;
					_ = 0;
				}
			}
			TweenCallback tweenCallback7 = CS_0024_003C_003E8__locals29._003C_003E9__9;
			if (CS_0024_003C_003E8__locals29._003C_003E9__9 == null)
			{
				tweenCallback7 = (CS_0024_003C_003E8__locals29._003C_003E9__9 = delegate
				{
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					//IL_001a: Expected O, but got Unknown
					//IL_0027: Expected O, but got Ref
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals29.current);
					ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals29 + 24);
					object obj16 = default(object);
					((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj16);
				});
			}
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		bool flag4 = tweenerCore == null;
		TweenCallback tweenCallback5 = tweenCallback4;
		if (!flag4)
		{
			goto IL_0579;
		}
		return;
		IL_0579:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		return;
		IL_0471:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v44 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj9 = tweenerCore + 112;
				object obj10 = obj9 >> 12;
				object obj11 = obj10 & 0x1FFFFF;
				object obj12 = obj11 >> 6;
				object obj13 = obj11 & 0x3F;
				nint num8;
				do
				{
					object obj14 = 1 << (int)obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
					object obj15 = 0 | obj14;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
					if (num7 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
					num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rbp_v5+462E0+v1157 @ rdx_v31*8]");
				}
				while (num8 != 0);
				TweenCallback tweenCallback6 = delegate
				{
					DOGetter<float> getter2 = CS_0024_003C_003E8__locals29._003C_003E9__7;
					if (CS_0024_003C_003E8__locals29._003C_003E9__7 == null)
					{
						DOGetter<float> dOGetter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						CS_0024_003C_003E8__locals29._003C_003E9__7 = dOGetter;
						getter2 = dOGetter;
					}
					DOSetter<float> setter = CS_0024_003C_003E8__locals29._003C_003E9__8;
					if (CS_0024_003C_003E8__locals29._003C_003E9__8 == null)
					{
						DOSetter<float> dOSetter2 = null;
						float x = default(float);
						((_003C_003Ec__DisplayClass74_0)(object)dOSetter2)._003CPlayAdventureUnlockAnimation_003Eb__8(x);
						CS_0024_003C_003E8__locals29._003C_003E9__8 = dOSetter2;
						setter = dOSetter2;
					}
					TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, setter, 0f, 1f);
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 6;
							_ = 0;
						}
					}
					TweenCallback tweenCallback7 = CS_0024_003C_003E8__locals29._003C_003E9__9;
					if (CS_0024_003C_003E8__locals29._003C_003E9__9 == null)
					{
						tweenCallback7 = (CS_0024_003C_003E8__locals29._003C_003E9__9 = delegate
						{
							//IL_0015: Unknown result type (might be due to invalid IL or missing references)
							//IL_001a: Expected O, but got Unknown
							//IL_0027: Expected O, but got Ref
							ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(CS_0024_003C_003E8__locals29.current);
							ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)(CS_0024_003C_003E8__locals29 + 24);
							object obj16 = default(object);
							((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&obj16);
						});
					}
					if (tweenerCore2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
				};
				tweenCallback5 = tweenCallback6;
				goto IL_0579;
			}
		}
		goto IL_053b;
	}

	private void _003CPlayAdventureUnlockAnimation_003Eb__74_1()
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		component.interactable = false;
	}

	private void _003CPlayAdventureUnlockAnimation_003Eb__74_2()
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		component.interactable = true;
	}

	private void _003CShowOnline_003Eb__88_0(bool hasInternetConnection)
	{
		//IL_001b: Expected I4, but got O
		if (!hasInternetConnection)
		{
			OnOnlineNotAllowed();
			return;
		}
		Action<bool> action = null;
		((MainMenuPage)(object)action).ShowOnlineCheckAgeOKCallback((byte)(int)this != 0);
		OnlinePlatformSupport.CheckAgeOk(action);
	}

	private void _003CShowOnlineCheckEntitlementCallback_003Eb__90_0()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CAcceptedEULA_003Ek__BackingField = true;
		_playerOptions.Save();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A978D0");
	}

	private bool _003CGetValidQuickCharacters_003Eb__97_0(CharacterType c)
	{
		//IL_0071: Expected I4, but got O
		if (_dataManager != null)
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			if (convertedCharacterData != null)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).FindEntry((System.Int32Enum)c);
				int num2 = num >> 31;
				return (byte)(num2 ^ 1) != 0;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
