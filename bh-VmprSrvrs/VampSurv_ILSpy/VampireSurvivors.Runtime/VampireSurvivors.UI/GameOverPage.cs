using System;
using System.Collections.Generic;
using System.Reflection;
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
using VampireSurvivors.App.Framework.System;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class GameOverPage : BaseUIPage
{
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public GameOverPage _003C_003E4__this;

		public float startSize;

		internal unsafe void _003COnShowStart_003Eb__0()
		{
			//IL_00b3: Expected O, but got I
			//IL_00f2: Expected O, but got I
			//IL_0127: Expected O, but got I
			//IL_0376->IL02c5: Incompatible stack heights: 1 vs 0
			//IL_0112->IL02c5: Incompatible stack heights: 1 vs 0
			//IL_0147->IL02c5: Incompatible stack heights: 1 vs 0
			//IL_01de->IL02c5: Incompatible stack heights: 2 vs 0
			//IL_0200->IL02c5: Incompatible stack heights: 2 vs 0
			//IL_0289->IL02c4: Incompatible stack heights: 6 vs 0
			//IL_02ae->IL02c4: Incompatible stack heights: 6 vs 0
			//IL_02c4->IL02c4: Incompatible stack heights: 6 vs 0
			GameOverPage gameOverPage = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				object background = gameOverPage._Background;
				if ((object)gameOverPage._Background == null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v9 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					return;
				}
				GameOverPage gameOverPage2 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					object background2 = gameOverPage2._Background;
					if ((object)gameOverPage2._Background != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v12 (System.Object)+E0]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v12 (System.Object)+E0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v13 (System.Object)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v13 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out Rect _);
							object obj2 = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v14 (System.Object)+120]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v14 (System.Object)+120]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v15 (System.Object)+E0]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v15 (System.Object)+E0]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v16 (System.Object)+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v16 (System.Object)+10]");
										Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
										object obj5 = default(object);
										object obj6 = default(object);
										bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
										object obj7 = obj6;
										if (!flag3)
										{
											obj7 = obj5;
										}
										float num = ((!UIHelper.IsPortrait) ? UIHelper.ScreenWidth : UIHelper.ScreenHeight);
										float endValue = num / (float)obj7;
										GameOverPage gameOverPage3 = _003C_003E4__this;
										if ((object)_003C_003E4__this != null && (object)gameOverPage3._Background != null)
										{
											Transform transform = gameOverPage3._Background.transform;
											bool flag4 = (object)transform == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v41 (UnityEngine.Transform)+10]");
											bool flag5 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v41 (UnityEngine.Transform)+10]");
											Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&ret2));
											GameOverPage gameOverPage4 = _003C_003E4__this;
											bool flag6 = (object)_003C_003E4__this == null;
											bool flag7 = (object)gameOverPage4._Background == null;
											Transform transform2 = gameOverPage4._Background.transform;
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform2, endValue, 0.8f);
											if (tweenerCore != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v49 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
												if ((nint)0 != 0)
												{
													_ = 1;
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
			throw new NullReferenceException();
		}

		internal float _003COnShowStart_003Eb__1()
		{
			return startSize;
		}

		internal void _003COnShowStart_003Eb__2(float x)
		{
			startSize = x;
		}

		internal void _003COnShowStart_003Eb__3()
		{
			GameOverPage gameOverPage = _003C_003E4__this;
			gameOverPage._BackgroundPixelMat.SetFloatImpl(CellSizeX, startSize);
			GameOverPage gameOverPage2 = _003C_003E4__this;
			gameOverPage2._BackgroundPixelMat.SetFloatImpl(CellSizeY, startSize);
			GameOverPage gameOverPage3 = _003C_003E4__this;
			gameOverPage3._TitlePixelMat.SetFloatImpl(CellSizeX, startSize);
			GameOverPage gameOverPage4 = _003C_003E4__this;
			gameOverPage4._TitlePixelMat.SetFloatImpl(CellSizeY, startSize);
		}

		internal void _003COnShowStart_003Eb__4()
		{
			_003C_003E4__this.OnIntroEnded();
		}
	}

	private sealed class _003C_003Ec__DisplayClass48_0
	{
		public int coinVal;

		public GameOverPage _003C_003E4__this;

		internal int _003CEnterStageReward_003Eb__0()
		{
			return coinVal;
		}

		internal void _003CEnterStageReward_003Eb__1(int x)
		{
			coinVal = x;
		}

		internal unsafe void _003CEnterStageReward_003Eb__2()
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected I4, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A31DE]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameOverPage gameOverPage = _003C_003E4__this;
			int num = this + 16;
			string text = ((int*)num)->ToString("D0");
			gameOverPage._CoinReward.text = text;
		}

		internal void _003CEnterStageReward_003Eb__3()
		{
			_003C_003E4__this.AnimateButtons();
		}
	}

	private PixelationTool _Pixeler;

	private Button _QuitButton;

	private Button _ReviveButton;

	private Button _WatchAdForReviveButton;

	private Button _ArcadeFreeReviveButton;

	private UISpriteAnimation _ReviveAnimation;

	private Material _GameOverPixelise;

	private Image _WhiteFlash;

	private Image _Background;

	private Animator _Animator;

	private Image _Title;

	private Material _BackgroundPixelMat;

	private Material _TitlePixelMat;

	private Image _StageCompleted;

	private Image _MoneyPile;

	private TextMeshProUGUI _BonusCoins;

	private TextMeshProUGUI _CoinReward;

	private TextMeshProUGUI _ReviveCoins;

	private TextMeshProUGUI _QuitText;

	private TextMeshProUGUI _ReviveText;

	private SignalBus _signalBus;

	private GameSessionData _gameSessionData;

	private ArcanaManager _arcanaManager;

	private PlayerOptions _playerOptions;

	private DataManager _data;

	private UnityServicesManager _unityServicesManager;

	private int _awardGivenXTimes;

	private int _totalCoins;

	private bool _hasRevives;

	private bool _stageComplete;

	private static readonly int CellSizeX;

	private static readonly int CellSizeY;

	private static readonly int PixelSize;

	private static readonly int TexSize;

	private void Construct(SignalBus signal, GameSessionData gameSessionData, ArcanaManager arcanaManager, PlayerOptions player, DataManager data, UnityServicesManager unityServicesManager)
	{
		_signalBus = signal;
		_gameSessionData = gameSessionData;
		_arcanaManager = arcanaManager;
		PlayerOptions playerOptions = default(PlayerOptions);
		_playerOptions = playerOptions;
		DataManager data2 = default(DataManager);
		_data = data2;
		UnityServicesManager unityServicesManager2 = default(UnityServicesManager);
		_unityServicesManager = unityServicesManager2;
	}

	private void Start()
	{
		Button quitButton = _QuitButton;
		UnityAction call = Quit;
		quitButton.m_OnClick.AddListener(call);
		_awardGivenXTimes = 0;
	}

	private void OnDestroy()
	{
		Button quitButton = _QuitButton;
		Button.ButtonClickedEvent onClick = quitButton.m_OnClick;
		UnityAction unityAction = Quit;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		((UnityEventBase)onClick).m_Calls.RemoveListener(((Delegate)unityAction).m_target, methodImpl);
	}

	public void AnimateText()
	{
		Ease ease = default(Ease);
		_Pixeler.Animate(12f, 140f, 2f, ease);
	}

	public unsafe void Revive()
	{
		//IL_0023: Expected I4, but got O
		//IL_0031: Expected I4, but got O
		//IL_005b: Expected I, but got O
		//IL_0063: Expected O, but got Ref
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			bool flag = (byte)(int)core._characters != 0;
			if ((int)(~core._characters) == 0)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator characters = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)core._characters;
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				if (enumerator.MoveNext())
				{
					nint num = unchecked((nint)null);
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				if ((object)_ReviveButton != null)
				{
					_ReviveButton.interactable = false;
					PlayReviveAnimation();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Quit()
	{
		//IL_0095: Invalid comparison between F4 and I4
		//IL_00be: Expected O, but got I4
		//IL_0115: Expected F4, but got I4
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		TweenCallback onComplete = delegate
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type signalType = default(Type);
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		};
		Tween tween = UITimerHelper.RegisterMillis(420f, onComplete);
		GameManager core = GM.Core;
		bool flag = core._003CSurvivedSeconds_003Ek__BackingField < 1800f;
		float num = core._003CSurvivedSeconds_003Ek__BackingField - 1800f;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj = flag4 & flag3;
		if (obj != null)
		{
			int num2 = ReviveCashAmount();
			int totalCoins = num2 + _totalCoins;
			_totalCoins = totalCoins;
		}
		float num3 = _playerOptions.AddCoins(_totalCoins);
		_awardGivenXTimes = 0;
	}

	public void WatchAdForRevive()
	{
		_playerOptions.Save();
	}

	public void ArcadeFreeRevive()
	{
		_playerOptions.Save();
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001a: Expected O, but got I8
		//IL_0b2c: Expected I, but got O
		//IL_0b6d: Expected O, but got Ref
		//IL_0b92: Expected I, but got O
		//IL_0be7: Expected O, but got Ref
		//IL_0c22: Expected I, but got O
		//IL_0c77: Expected O, but got Ref
		//IL_0cb2: Expected I, but got O
		//IL_0d0a: Expected O, but got Ref
		//IL_0d48: Expected I, but got O
		//IL_0da0: Expected O, but got Ref
		//IL_0e00: Expected I, but got O
		//IL_0e58: Expected O, but got Ref
		//IL_0e96: Expected I, but got O
		//IL_0eee: Expected O, but got Ref
		//IL_0f2c: Expected I, but got O
		//IL_0f84: Expected O, but got Ref
		//IL_0fc2: Expected I, but got O
		//IL_101a: Expected O, but got Ref
		//IL_1058: Expected I, but got O
		//IL_10b0: Expected O, but got Ref
		//IL_1110: Expected O, but got I
		//IL_0599: Expected F4, but got I4
		//IL_05dc: Expected I, but got O
		//IL_05ea: Expected O, but got Ref
		//IL_065e: Expected O, but got Ref
		//IL_0666: Expected I, but got O
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Expected O, but got Unknown
		//IL_0945: Unknown result type (might be due to invalid IL or missing references)
		//IL_094a: Expected O, but got Unknown
		//IL_0961: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Expected O, but got Unknown
		//IL_11bb: Expected O, but got I4
		//IL_11cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d0: Expected O, but got Unknown
		//IL_05cf->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_060e->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_063c->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_0706->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_0732->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_113d->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_078b->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_07c3->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_07fb->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_0a22->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_118a->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_0a58->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_0a85->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_11a8->IL0af5: Incompatible stack heights: 43 vs 0
		//IL_0abb->IL0af5: Incompatible stack heights: 43 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass42_0 CS_0024_003C_003E8__locals27 = new _003C_003Ec__DisplayClass42_0();
		if (CS_0024_003C_003E8__locals27 != null)
		{
			object obj3 = 6603577472L;
			CS_0024_003C_003E8__locals27._003C_003E4__this = this;
			Camera main = Camera.main;
			if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
			{
				CameraExtensions.ResetOrthographicAndRenderTextureSize(main);
			}
			base.OnShowStart(g);
			if ((object)_StageCompleted != null)
			{
				Transform transform = _StageCompleted.transform;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ rcx_v73 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v813 @ rax_v83 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
				Transform transform2 = _MoneyPile.transform;
				nint num3 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rcx_v80 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num4 = 0;
				bool flag2 = (object)transform2 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1229 @ rax_v93 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj5);
				bool flag4 = (object)_BonusCoins == null;
				Transform transform3 = _BonusCoins.transform;
				nint num5 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1517 @ rcx_v86 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num6 = 0;
				bool flag5 = (object)transform3 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1518 @ rax_v101 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj6);
				bool flag7 = (object)_CoinReward == null;
				Transform transform4 = _CoinReward.transform;
				nint num7 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1799 @ rcx_v92 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num8 = 0;
				bool flag8 = (object)transform4 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1800 @ rax_v109 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1778 @ rax_v107 (UnityEngine.Transform)+10]");
				bool flag9 = (nint)0 == 0;
				object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1778 @ rax_v107 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj7);
				bool flag10 = (object)_ReviveCoins == null;
				Transform transform5 = _ReviveCoins.transform;
				bool flag11 = (object)transform5 == null;
				Transform parent = transform5.parent;
				nint num9 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2321 @ rcx_v99 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num10 = 0;
				bool flag12 = (object)parent == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2322 @ rax_v118 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2253 @ rax_v116 (UnityEngine.Transform)+10]");
				bool flag13 = (nint)0 == 0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2253 @ rax_v116 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj8);
				Action onComplete = delegate
				{
					//IL_00b3: Expected O, but got I
					//IL_00f2: Expected O, but got I
					//IL_0127: Expected O, but got I
					//IL_0376->IL02c5: Incompatible stack heights: 1 vs 0
					//IL_0112->IL02c5: Incompatible stack heights: 1 vs 0
					//IL_0147->IL02c5: Incompatible stack heights: 1 vs 0
					//IL_01de->IL02c5: Incompatible stack heights: 2 vs 0
					//IL_0200->IL02c5: Incompatible stack heights: 2 vs 0
					//IL_0289->IL02c4: Incompatible stack heights: 6 vs 0
					//IL_02ae->IL02c4: Incompatible stack heights: 6 vs 0
					//IL_02c4->IL02c4: Incompatible stack heights: 6 vs 0
					GameOverPage gameOverPage = CS_0024_003C_003E8__locals27._003C_003E4__this;
					if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null)
					{
						object background2 = gameOverPage._Background;
						if ((object)gameOverPage._Background == null)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v9 (System.Object)+10]");
						if ((nint)0 == 0)
						{
							return;
						}
						GameOverPage gameOverPage2 = CS_0024_003C_003E8__locals27._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null)
						{
							object background3 = gameOverPage2._Background;
							if ((object)gameOverPage2._Background != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v12 (System.Object)+E0]");
								object obj23 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v12 (System.Object)+E0]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v13 (System.Object)+10]");
									bool flag48 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v13 (System.Object)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out Rect _);
									object obj24 = CS_0024_003C_003E8__locals27._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v14 (System.Object)+120]");
										object obj25 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v14 (System.Object)+120]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v15 (System.Object)+E0]");
											object obj26 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdi_v15 (System.Object)+E0]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v16 (System.Object)+10]");
												bool flag49 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v16 (System.Object)+10]");
												Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
												object obj27 = default(object);
												object obj28 = default(object);
												bool flag50 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj27) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj28);
												object obj29 = obj28;
												if (!flag50)
												{
													obj29 = obj27;
												}
												float num25 = ((!UIHelper.IsPortrait) ? UIHelper.ScreenWidth : UIHelper.ScreenHeight);
												float endValue = num25 / (float)obj29;
												GameOverPage gameOverPage3 = CS_0024_003C_003E8__locals27._003C_003E4__this;
												if ((object)CS_0024_003C_003E8__locals27._003C_003E4__this != null && (object)gameOverPage3._Background != null)
												{
													Transform transform11 = gameOverPage3._Background.transform;
													bool flag51 = (object)transform11 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v41 (UnityEngine.Transform)+10]");
													bool flag52 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v41 (UnityEngine.Transform)+10]");
													Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&ret2));
													GameOverPage gameOverPage4 = CS_0024_003C_003E8__locals27._003C_003E4__this;
													bool flag53 = (object)CS_0024_003C_003E8__locals27._003C_003E4__this == null;
													bool flag54 = (object)gameOverPage4._Background == null;
													Transform target = gameOverPage4._Background.transform;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target, endValue, 0.8f);
													if (tweenerCore3 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rax_v49 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
														if ((nint)0 != 0)
														{
															_ = 1;
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
					throw new NullReferenceException();
				};
				bool flag14 = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				Timer timer = TimerHelper.RegisterMillisUI(1f, onComplete, null, isLooped: false, flag14, autoDestroyOwner, repeat);
				bool flag15 = (object)_Background == null;
				Material material = _Background.material;
				_BackgroundPixelMat = material;
				bool flag16 = (object)_Title == null;
				Material material2 = _Title.material;
				_TitlePixelMat = material2;
				GameSessionData gameSessionData = _gameSessionData;
				bool flag17 = _gameSessionData == null;
				GameManager core = GM.Core;
				bool flag18 = (object)GM.Core == null;
				CoopConfig coopConfig = core.CoopConfig;
				bool flag19 = (object)core.CoopConfig == null;
				EnterMultiplayerControl(gameSessionData._activeCharacter, coopConfig._levelupVibrationMilliseconds);
				bool flag20 = Multiplayer == null;
				Multiplayer.AllowAllPlayersToUseUI();
				bool flag21 = (object)_ReviveCoins == null;
				Transform transform6 = _ReviveCoins.transform;
				bool flag22 = (object)transform6 == null;
				Transform parent2 = transform6.parent;
				nint num11 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2860 @ rcx_v116 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num12 = 0;
				bool flag23 = (object)parent2 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2856 @ rax_v140 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2989 @ rax_v138 (UnityEngine.Transform)+10]");
				bool flag24 = (nint)0 == 0;
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2989 @ rax_v138 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj9);
				bool flag25 = (object)_QuitButton == null;
				GameObject gameObject = _QuitButton.gameObject;
				bool flag26 = (object)gameObject == null;
				gameObject.SetActive(value: false);
				bool flag27 = (object)_QuitButton == null;
				Transform transform7 = _QuitButton.transform;
				nint num13 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2715 @ rcx_v124 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num14 = 0;
				bool flag28 = (object)transform7 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2712 @ rax_v150 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3044 @ rax_v148 (UnityEngine.Transform)+10]");
				bool flag29 = (nint)0 == 0;
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3044 @ rax_v148 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj10);
				bool flag30 = (object)_QuitText == null;
				Transform transform8 = _QuitText.transform;
				nint num15 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2516 @ rcx_v130 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num16 = 0;
				bool flag31 = (object)transform8 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2513 @ rax_v158 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3098 @ rax_v156 (UnityEngine.Transform)+10]");
				bool flag32 = (nint)0 == 0;
				object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3098 @ rax_v156 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj11);
				bool flag33 = (object)_ReviveButton == null;
				Transform transform9 = _ReviveButton.transform;
				nint num17 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2216 @ rcx_v136 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num18 = 0;
				bool flag34 = (object)transform9 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2213 @ rax_v166 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3152 @ rax_v164 (UnityEngine.Transform)+10]");
				bool flag35 = (nint)0 == 0;
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3152 @ rax_v164 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj12);
				bool flag36 = (object)_ReviveText == null;
				Transform transform10 = _ReviveText.transform;
				nint num19 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1744 @ rdx_v89 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num20 = 0;
				bool flag37 = (object)transform10 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1983 @ rax_v174 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3207 @ rax_v172 (UnityEngine.Transform)+10]");
				bool flag38 = (nint)0 == 0;
				object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3207 @ rax_v172 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj13);
				bool flag39 = (object)_QuitButton == null;
				_QuitButton.interactable = false;
				bool flag40 = (object)_ReviveButton == null;
				_ReviveButton.interactable = false;
				bool flag41 = (object)GM.Core == null;
				bool hasRevives = GM.Core.HasAPlayerGotRevivals();
				_hasRevives = hasRevives;
				GameManager core2 = GM.Core;
				bool flag42 = (object)GM.Core == null;
				bool flag43 = core2._playerOptions == null;
				PlayerOptionsData config = core2._playerOptions.Config;
				bool flag44 = config == null;
				bool flag45 = config._003CClassicMusic_003Ek__BackingField;
				SfxType sfxType = SfxType.BGM_GameOver;
				if (!flag45)
				{
					sfxType = SfxType.BGM_GameOverB;
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				_ = 0;
				_ = 1068708659;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7F]");
				soundConfig.Volume = (float?)(object)0;
				soundConfig.Rate = 1f;
				PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 0f, 10, flag14 ? 1 : 0);
				Sequence sequence = DOTween.Sequence();
				Transform background = (Transform)(object)_Background;
				if ((object)_Background != null)
				{
					nint num21 = (nint)background;
					object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3311 @ r8_v40 (Il2CppClass<UnityEngine.Transform>)+298] (should have been resolved before IL gen)");
					if ((object)_Background != null)
					{
						Color color = _Background.color;
						if ((object)_Background != null)
						{
							Color color2 = _Background.color;
							object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							nint num22 = (nint)background;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3329 @ rax_v197 (Il2CppClass<UnityEngine.Transform>)+2A8] (should have been resolved before IL gen)");
							TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Background, 0.4f, 0.8f);
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3351 @ rax_v199 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							if ((object)_Title != null)
							{
								GameObject gameObject2 = _Title.gameObject;
								if ((object)gameObject2 != null)
								{
									gameObject2.SetActive(value: true);
									CS_0024_003C_003E8__locals27.startSize = 50f;
									if ((object)_BackgroundPixelMat != null)
									{
										_BackgroundPixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals27.startSize);
										if ((object)_BackgroundPixelMat != null)
										{
											_BackgroundPixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals27.startSize);
											if ((object)_TitlePixelMat != null)
											{
												_TitlePixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals27.startSize);
												if ((object)_TitlePixelMat != null)
												{
													_TitlePixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals27.startSize);
													DOGetter<float> getter = null;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
													DOSetter<float> dOSetter = null;
													((_003C_003Ec__DisplayClass42_0)(object)dOSetter)._003COnShowStart_003Eb__2(0.4f);
													TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 2f, 1f);
													TweenCallback tweenCallback = delegate
													{
														GameOverPage gameOverPage = CS_0024_003C_003E8__locals27._003C_003E4__this;
														gameOverPage._BackgroundPixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals27.startSize);
														GameOverPage gameOverPage2 = CS_0024_003C_003E8__locals27._003C_003E4__this;
														gameOverPage2._BackgroundPixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals27.startSize);
														GameOverPage gameOverPage3 = CS_0024_003C_003E8__locals27._003C_003E4__this;
														gameOverPage3._TitlePixelMat.SetFloatImpl(CellSizeX, CS_0024_003C_003E8__locals27.startSize);
														GameOverPage gameOverPage4 = CS_0024_003C_003E8__locals27._003C_003E4__this;
														gameOverPage4._TitlePixelMat.SetFloatImpl(CellSizeY, CS_0024_003C_003E8__locals27.startSize);
													};
													TweenCallback tweenCallback3;
													if (tweenerCore2 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3476 @ rax_v215 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3476 @ rax_v215 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
															if ((nint)0 != 0)
															{
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																bool flag46 = (nint)0 == 0;
																_ = 0;
																if (!flag46)
																{
																	object obj16 = tweenerCore2 + 184;
																	object obj17 = obj16 >> 12;
																	object obj18 = obj17 & 0x1FFFFF;
																	object obj19 = obj18 >> 6;
																	object obj20 = obj18 & 0x3F;
																	nint num24;
																	do
																	{
																		object obj21 = 1 << (int)obj20;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v31+462E0+v3706 @ rdx_v130*8]");
																		object obj22 = 0 | obj21;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v31+462E0+v3706 @ rdx_v130*8]");
																		nint num23 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v31+462E0+v3706 @ rdx_v130*8]");
																		if (num23 == 0)
																		{
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v31+462E0+v3706 @ rdx_v130*8]");
																		num24 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r15_v31+462E0+v3706 @ rdx_v130*8]");
																	}
																	while (num24 != 0);
																	TweenCallback tweenCallback2 = delegate
																	{
																		CS_0024_003C_003E8__locals27._003C_003E4__this.OnIntroEnded();
																	};
																	tweenCallback3 = tweenCallback2;
																	goto IL_09d9;
																}
															}
														}
													}
													TweenCallback tweenCallback4 = delegate
													{
														CS_0024_003C_003E8__locals27._003C_003E4__this.OnIntroEnded();
													};
													bool flag47 = tweenerCore2 == null;
													tweenCallback3 = tweenCallback4;
													if (!flag47)
													{
														goto IL_09d9;
													}
													goto IL_0a08;
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
		goto IL_0af5;
		IL_09d9:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3476 @ rax_v215 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0a08;
		IL_0a08:
		if ((object)_WatchAdForReviveButton != null)
		{
			GameObject gameObject3 = _WatchAdForReviveButton.gameObject;
			if ((object)GM.Core != null && (object)gameObject3 != null)
			{
				gameObject3.SetActive(value: false);
				if ((object)_ArcadeFreeReviveButton != null)
				{
					GameObject gameObject4 = _ArcadeFreeReviveButton.gameObject;
					if ((object)GM.Core != null && (object)gameObject4 != null)
					{
						gameObject4.SetActive(value: false);
						return;
					}
				}
			}
		}
		goto IL_0af5;
		IL_0af5:
		throw new NullReferenceException();
	}

	private bool CanShowAdvertReviveButton()
	{
		//IL_001e: Expected I4, but got O
		if ((object)GM.Core != null)
		{
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CanShowArcadeFreeReviveButton()
	{
		//IL_001e: Expected I4, but got O
		if ((object)GM.Core != null)
		{
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool IsAppleArcade()
	{
		return false;
	}

	private int ReviveCashAmount()
	{
		//IL_015a: Expected I4, but got O
		//IL_01a1: Expected I, but got O
		//IL_0066: Expected O, but got I4
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_010c: Expected O, but got I4
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected I4, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00fe: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00f0: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		int num = 0;
		int num2 = 0;
		if (!flag)
		{
			do
			{
				double maxReviveCount = core.GetMaxReviveCount();
				nint num3 = (nint)typeof(Math);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v7 (Il2CppClass<System.Math>)+E4]");
				bool flag2 = (nint)0 == 0;
				double num4 = Math.Floor(maxReviveCount);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v7 (Il2CppClass<System.Math>)+E4]");
				object obj5;
				if ((nint)0 > (nint)0)
				{
					object obj = _awardGivenXTimes - 1;
					object obj2 = obj + num;
					if (flag2)
					{
						goto IL_0103;
					}
					object obj3 = obj2 - 1;
					if (!flag2)
					{
						object obj4 = obj3 - 1;
						if (!flag2)
						{
							if ((nint)obj4 != 1)
							{
								goto IL_0103;
							}
							obj5 = 400;
						}
						else
						{
							obj5 = 300;
						}
					}
					else
					{
						obj5 = 200;
					}
					goto IL_01bd;
				}
				bool flag3 = num2 >= 65535;
				int result = 65535;
				if (!flag3)
				{
					result = num2;
				}
				return result;
				IL_01bd:
				num++;
				num2 += obj5;
				core = GM.Core;
				continue;
				IL_0103:
				obj5 = 100;
				goto IL_01bd;
			}
			while ((object)GM.Core != null);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private void OnIntroEnded()
	{
		//IL_0080: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_00aa: Expected O, but got I
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01e0: Invalid comparison between F4 and O
		//IL_0203: Invalid comparison between F4 and I4
		Dictionary<StageType, List<StageData>> convertedStages = _data.GetConvertedStages();
		PlayerOptionsData config = _playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)config._003CSelectedStage_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v19 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rax_v19 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v20+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v18+98]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v21+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,dword ptr [rsp+34h]\"");
				object obj5 = convertedStages * 1000;
				object obj6 = 922337203685477L + obj5;
				if ((long)obj6 <= 1844674407370954L)
				{
					GameManager core = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rcx\"");
					object obj7 = obj5 >> 26;
					object obj8 = obj7 >> 63;
					object obj9 = obj7 + obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rcx\"");
					object obj10 = obj5 + obj9;
					object obj11 = obj10 >> 5;
					object obj12 = obj11 >> 63;
					object obj13 = obj11 + obj12;
					object obj14 = obj13 * 60;
					object obj15 = obj9 - obj14;
					object obj16 = obj15 * 60;
					float num = core._003CSurvivedSeconds_003Ek__BackingField;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16);
					float num2 = core._003CSurvivedSeconds_003Ek__BackingField - (float)obj16;
					bool flag2 = num2 == 0f;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					if (!(_stageComplete = flag4 & flag3))
					{
						AnimateButtons();
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 313 Invalid \"Jump target not found in method: 0x186CD0E40\"");
					throw new NullReferenceException();
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException(null, "TimeSpan overflowed because the duration is too long.");
				ex._002Ector(null, "TimeSpan overflowed because the duration is too long.");
				throw ex;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void EnterStageReward()
	{
		_003C_003Ec__DisplayClass48_0 obj = new _003C_003Ec__DisplayClass48_0();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 71 Invalid \"Jump target not found in method: 0x186CD1480\"");
		obj._003C_003E4__this = this;
		int awardGivenXTimes = _awardGivenXTimes + 1;
		_awardGivenXTimes = awardGivenXTimes;
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0.5f);
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleUI.DOFade(_Title, 0f, 0.25f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 171 Invalid \"Jump target not found in method: 0x186CD1480\"");
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t, sequence.lastTweenInsertTime);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 188 Invalid \"Jump target not found in method: 0x186CD1480\"");
		Transform target = _Title.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target, 0f, 0.25f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 223 Invalid \"Jump target not found in method: 0x186CD1480\"");
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t2, sequence.lastTweenInsertTime);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 240 Invalid \"Jump target not found in method: 0x186CD1480\"");
		RectTransform rectTransform = _StageCompleted.rectTransform;
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScale(rectTransform, 1f, 0.25f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 276 Invalid \"Jump target not found in method: 0x186CD1480\"");
			Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t3, sequence.lastTweenInsertTime);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 293 Invalid \"Jump target not found in method: 0x186CD1480\"");
		RectTransform rectTransform2 = _MoneyPile.rectTransform;
		TweenerCore<Vector3, Vector3, VectorOptions> t4 = ShortcutExtensions.DOScale(rectTransform2, 1f, 0.25f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t4, false))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 328 Invalid \"Jump target not found in method: 0x186CD1480\"");
			Sequence sequence6 = Sequence.DoInsert(sequence, (Tween)t4, sequence.lastTweenInsertTime);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 345 Invalid \"Jump target not found in method: 0x186CD1480\"");
		RectTransform rectTransform3 = _BonusCoins.rectTransform;
		TweenerCore<Vector3, Vector3, VectorOptions> t5 = ShortcutExtensions.DOScale(rectTransform3, 1f, 0.25f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t5, false))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 380 Invalid \"Jump target not found in method: 0x186CD1480\"");
			Sequence sequence7 = Sequence.DoInsert(sequence, (Tween)t5, sequence.lastTweenInsertTime);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 397 Invalid \"Jump target not found in method: 0x186CD1480\"");
		RectTransform rectTransform4 = _CoinReward.rectTransform;
		TweenerCore<Vector3, Vector3, VectorOptions> t6 = ShortcutExtensions.DOScale(rectTransform4, 1f, 0.25f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t6, false))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 432 Invalid \"Jump target not found in method: 0x186CD1480\"");
			Sequence sequence8 = Sequence.DoInsert(sequence, (Tween)t6, sequence.lastTweenInsertTime);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 454 Invalid \"Jump target not found in method: 0x186CD1259\"");
	}

	private void PlayReviveAnimation()
	{
		//IL_023b: Expected F4, but got I4
		GameObject gameObject = _ReviveAnimation.gameObject;
		gameObject.SetActive(value: true);
		_ReviveAnimation.Play(hideWhenDone: true);
		Transform target = _ReviveButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.1f);
		Transform target2 = _ReviveText.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 0f, 0.1f);
		Image image = _ReviveButton.image;
		TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(image, 0f, 0.1f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_ReviveText, 0f, 0.1f);
		Transform transform = _ReviveCoins.transform;
		Transform parent = transform.parent;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(parent, 0f, 0.1f);
		Transform target3 = _QuitButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOScale(target3, 0f, 0.1f);
		Transform target4 = _QuitText.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOScale(target4, 0f, 0.1f);
		_Animator.enabled = false;
		TweenerCore<Color, Color, ColorOptions> tweenerCore8 = DOTweenModuleUI.DOFade(_Background, 0f, 0.625f);
		if (tweenerCore8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = !config._003CFlashingVFXEnabled_003Ek__BackingField;
		float endValue = 0f;
		if (!flag)
		{
			endValue = 1f;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore9 = DOTweenModuleUI.DOFade(_WhiteFlash, endValue, 0.1f);
		if (tweenerCore9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore10 = TweenSettingsExtensions.SetDelay(tweenerCore9, 0.425f);
		TweenCallback tweenCallback = delegate
		{
			//IL_02ae: Expected O, but got I8
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected O, but got Unknown
			//IL_0599: Expected O, but got I4
			//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ae: Expected O, but got Unknown
			TweenerCore<Color, Color, ColorOptions> tweenerCore11 = DOTweenModuleUI.DOFade(_WhiteFlash, 0f, 0.1f);
			object obj = 6603577472L;
			TweenCallback tweenCallback3;
			if (tweenerCore11 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag2 = (nint)0 == 0;
					_ = 0;
					if (!flag2)
					{
						object obj2 = tweenerCore11 + 184;
						object obj3 = obj2 >> 12;
						object obj4 = obj3 & 0x1FFFFF;
						object obj5 = obj4 >> 6;
						object obj6 = obj4 & 0x3F;
						nint num2;
						do
						{
							object obj7 = 1 << (int)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
							object obj8 = 0 | obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
							if (num == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
							num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
						}
						while (num2 != 0);
						TweenCallback tweenCallback2 = OnReviveAnimComplete;
						tweenCallback3 = tweenCallback2;
						goto IL_0111;
					}
				}
			}
			TweenCallback tweenCallback4 = OnReviveAnimComplete;
			bool flag3 = tweenerCore11 == null;
			tweenCallback3 = tweenCallback4;
			if (!flag3)
			{
				goto IL_0111;
			}
			goto IL_0142;
			IL_0142:
			GameObject gameObject2 = _Title.gameObject;
			gameObject2.SetActive(value: false);
			GameObject gameObject3 = _ReviveAnimation.gameObject;
			gameObject3.SetActive(value: false);
			Transform transform2 = _StageCompleted.transform;
			bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
			Transform transform3 = _MoneyPile.transform;
			bool flag5 = (object)transform3 == null;
			bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
			bool flag7 = (object)_BonusCoins == null;
			Transform transform4 = _BonusCoins.transform;
			bool flag8 = (object)transform4 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rax_v75 (UnityEngine.Transform)+10]");
			bool flag9 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rax_v75 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			bool flag10 = (object)_CoinReward == null;
			Transform transform5 = _CoinReward.transform;
			bool flag11 = (object)transform5 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rax_v83 (UnityEngine.Transform)+10]");
			bool flag12 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rax_v83 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value2);
			bool flag13 = (object)_ReviveCoins == null;
			Transform transform6 = _ReviveCoins.transform;
			bool flag14 = (object)transform6 == null;
			Transform parent2 = transform6.parent;
			bool flag15 = (object)parent2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v92 (UnityEngine.Transform)+10]");
			bool flag16 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v92 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			bool flag17 = (object)_QuitText == null;
			Transform transform7 = _QuitText.transform;
			bool flag18 = (object)transform7 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v100 (UnityEngine.Transform)+10]");
			bool flag19 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v100 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value2);
			bool flag20 = (object)_ReviveText == null;
			Transform transform8 = _ReviveText.transform;
			bool flag21 = (object)transform8 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1680 @ rax_v108 (UnityEngine.Transform)+10]");
			bool flag22 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1680 @ rax_v108 (UnityEngine.Transform)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref value);
			return;
			IL_0111:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
			goto IL_0142;
		};
		if (tweenerCore10 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void OnReviveAnimComplete()
	{
		ReviveCharacter();
	}

	private void AnimateButtons()
	{
		Debug.Log("Animating buttons");
		GameObject gameObject = _ReviveButton.gameObject;
		gameObject.SetActive(_hasRevives);
		float endValue;
		float duration;
		if (!_hasRevives)
		{
			GameObject gameObject2 = _QuitButton.gameObject;
			gameObject2.SetActive(value: true);
			Transform target = _QuitText.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.25f);
			Transform target2 = _QuitButton.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 1f, 0.25f);
			TweenCallback tweenCallback = delegate
			{
				Selectable quitButton = _QuitButton;
				if ((object)_QuitButton != null)
				{
					_QuitButton.interactable = true;
					quitButton = _QuitButton;
					if ((object)_QuitButton != null)
					{
						_QuitButton.Select();
						return;
					}
				}
				throw new NullReferenceException();
			};
			bool flag = tweenerCore2 == null;
			endValue = 1f;
			duration = 0.25f;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v57 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				bool flag2 = (nint)0 == 0;
				endValue = 1f;
				duration = 0.25f;
				if (!flag2)
				{
					endValue = 1f;
					duration = 0.25f;
				}
			}
		}
		else
		{
			Transform target3 = _ReviveText.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target3, 1f, 0.25f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore4 = DOTweenModuleUI.DOFade(_ReviveText, 1f, 0.25f);
			Image image = _ReviveButton.image;
			TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleUI.DOFade(image, 1f, 0.25f);
			Transform target4 = _ReviveButton.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOScale(target4, 1f, 0.25f);
			TweenCallback tweenCallback2 = delegate
			{
				_ReviveButton.interactable = true;
				_ReviveButton.Select();
			};
			bool flag3 = tweenerCore6 == null;
			endValue = 1f;
			duration = 0.25f;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				bool flag4 = (nint)0 == 0;
				endValue = 1f;
				duration = 0.25f;
				if (!flag4)
				{
					endValue = 1f;
					duration = 0.25f;
				}
			}
		}
		if (!_stageComplete)
		{
			return;
		}
		GameObject gameObject3 = _QuitButton.gameObject;
		gameObject3.SetActive(value: true);
		Transform target5 = _QuitText.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOScale(target5, endValue, duration);
		Transform target6 = _QuitButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore8 = ShortcutExtensions.DOScale(target6, endValue, duration);
		TweenCallback tweenCallback3 = delegate
		{
			Selectable quitButton = _QuitButton;
			if ((object)_QuitButton != null)
			{
				_QuitButton.interactable = true;
				quitButton = _QuitButton;
				if ((object)_QuitButton != null)
				{
					_QuitButton.Select();
					return;
				}
			}
			throw new NullReferenceException();
		};
		if (tweenerCore8 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rax_v15 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		if (_hasRevives)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/gameOver_revivePayout", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			int num = ReviveCashAmount();
			int num2 = default(int);
			string newValue = num2.ToString();
			string text = translation.Replace("%0", newValue);
			_ReviveCoins.text = text;
		}
		Transform transform = _ReviveCoins.transform;
		Transform parent = transform.parent;
		GameObject gameObject4 = parent.gameObject;
		gameObject4.SetActive(_hasRevives);
		Transform transform2 = _ReviveCoins.transform;
		Transform parent2 = transform2.parent;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore9 = ShortcutExtensions.DOScale(parent2, endValue, duration);
	}

	private unsafe void ReviveCharacter()
	{
		//IL_0045: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9E900");
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			ArcanaManager arcanaManager = _arcanaManager;
			bool flag = _arcanaManager == null;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			if (flag)
			{
				break;
			}
			if (arcanaManager._003CActiveArcanas_003Ek__BackingField == null)
			{
				continue;
			}
			List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rcx_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
				if (obj != null)
				{
					_arcanaManager.TriggerAwake(null);
				}
			}
		}
		throw new NullReferenceException();
	}

	static GameOverPage()
	{
		int cellSizeX = Shader.PropertyToID("_CellSizeX");
		CellSizeX = cellSizeX;
		int cellSizeY = Shader.PropertyToID("_CellSizeY");
		CellSizeY = cellSizeY;
		int pixelSize = Shader.PropertyToID("_PixelSize");
		PixelSize = pixelSize;
		int texSize = Shader.PropertyToID("_TexSize");
		TexSize = texSize;
	}

	private void _003CQuit_003Eb__39_0()
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

	private void _003CPlayReviveAnimation_003Eb__49_0()
	{
		//IL_02ae: Expected O, but got I8
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		//IL_0599: Expected O, but got I4
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_WhiteFlash, 0f, 0.1f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rbp_v1+462E0+v103 @ rdx_v64*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = OnReviveAnimComplete;
					tweenCallback2 = tweenCallback;
					goto IL_0111;
				}
			}
		}
		TweenCallback tweenCallback3 = OnReviveAnimComplete;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_0111;
		}
		goto IL_0142;
		IL_0142:
		GameObject gameObject = _Title.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = _ReviveAnimation.gameObject;
		gameObject2.SetActive(value: false);
		Transform transform = _StageCompleted.transform;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = _MoneyPile.transform;
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		bool flag6 = (object)_BonusCoins == null;
		Transform transform3 = _BonusCoins.transform;
		bool flag7 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rax_v75 (UnityEngine.Transform)+10]");
		bool flag8 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rax_v75 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		bool flag9 = (object)_CoinReward == null;
		Transform transform4 = _CoinReward.transform;
		bool flag10 = (object)transform4 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rax_v83 (UnityEngine.Transform)+10]");
		bool flag11 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1291 @ rax_v83 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value2);
		bool flag12 = (object)_ReviveCoins == null;
		Transform transform5 = _ReviveCoins.transform;
		bool flag13 = (object)transform5 == null;
		Transform parent = transform5.parent;
		bool flag14 = (object)parent == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v92 (UnityEngine.Transform)+10]");
		bool flag15 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1571 @ rax_v92 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		bool flag16 = (object)_QuitText == null;
		Transform transform6 = _QuitText.transform;
		bool flag17 = (object)transform6 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v100 (UnityEngine.Transform)+10]");
		bool flag18 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v100 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value2);
		bool flag19 = (object)_ReviveText == null;
		Transform transform7 = _ReviveText.transform;
		bool flag20 = (object)transform7 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1680 @ rax_v108 (UnityEngine.Transform)+10]");
		bool flag21 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1680 @ rax_v108 (UnityEngine.Transform)+10]");
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		return;
		IL_0111:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v2 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0142;
	}

	private void _003CAnimateButtons_003Eb__51_0()
	{
		_ReviveButton.interactable = true;
		_ReviveButton.Select();
	}

	private void _003CAnimateButtons_003Eb__51_1()
	{
		Selectable quitButton = _QuitButton;
		if ((object)_QuitButton != null)
		{
			_QuitButton.interactable = true;
			quitButton = _QuitButton;
			if ((object)_QuitButton != null)
			{
				_QuitButton.Select();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CAnimateButtons_003Eb__51_2()
	{
		Selectable quitButton = _QuitButton;
		if ((object)_QuitButton != null)
		{
			_QuitButton.interactable = true;
			quitButton = _QuitButton;
			if ((object)_QuitButton != null)
			{
				_QuitButton.Select();
				return;
			}
		}
		throw new NullReferenceException();
	}
}
