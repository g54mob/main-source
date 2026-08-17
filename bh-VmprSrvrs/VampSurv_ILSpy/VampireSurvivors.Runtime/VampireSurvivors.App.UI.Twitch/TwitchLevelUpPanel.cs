using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Lexone.UnityTwitchChat;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI.Twitch;

public class TwitchLevelUpPanel : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public TwitchLevelUpPanel _003C_003E4__this;

		public int num;

		internal void _003CEnterCountdownNumber_003Eb__0()
		{
			_003C_003E4__this.ExitCountdownNumber(num);
		}
	}

	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public TwitchLevelUpPanel _003C_003E4__this;

		public int num;

		internal void _003CExitCountdownNumber_003Eb__0()
		{
			if (this.num > 1)
			{
				int num = this.num - 1;
				_003C_003E4__this.EnterCountdownNumber(num);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass46_0
	{
		public TwitchLevelUpPanel _003C_003E4__this;

		public int twitchChoice;

		internal void _003CCountdownComplete_003Eb__0()
		{
			TwitchLevelUpPanel twitchLevelUpPanel = _003C_003E4__this;
			List<TwitchLevelUpOption> twitchOptions = twitchLevelUpPanel._twitchOptions;
			int num = twitchChoice;
			if (twitchChoice < twitchOptions._size)
			{
				TwitchLevelUpOption[] items = twitchOptions._items;
				TwitchLevelUpOption twitchLevelUpOption = items[num];
				Action callback = twitchLevelUpOption._callback;
				if (twitchLevelUpOption._callback != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v143.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private RectTransform _CountDownBackground;

	private Transform _CountDownFill;

	private TextMeshProUGUI _CountDownNumberText;

	private TwitchLevelUpOption _OptionPrefab;

	private RectTransform _PositionOption1;

	private RectTransform _PositionOption2;

	private RectTransform _PositionOption3;

	private RectTransform _PositionOption4;

	private RectTransform _PositionRerolls;

	private RectTransform _PositionSkip;

	private RectTransform _PositionBanish;

	private RectTransform _PositionPass;

	private GameObject _NavigatorsRoot;

	private CanvasGroup _canvasGroup;

	private LevelUpPage _levelUpPage;

	private bool _banishChoice;

	private bool _countdownStarted;

	private int _rerollOptionNumber;

	private int _skipOptionNumber;

	private int _banishOptionNumber;

	private int _passOptionNumber;

	private int _twitchLimitCount;

	private List<int> _twitchOptionCounter;

	private int _howManyOptions;

	private List<TwitchLevelUpOption> _twitchOptionsPool;

	private List<TwitchLevelUpOption> _twitchOptions;

	private Tween _twitchCountdownBarTween;

	private RewiredStandaloneInputModule _inputModule;

	private const int CountdownLength = 7;

	private RewiredStandaloneInputModule InputModule
	{
		get
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Expected O, but got Unknown
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_015f: Expected O, but got I4
			RewiredStandaloneInputModule inputModule = _inputModule;
			RewiredStandaloneInputModule rewiredStandaloneInputModule;
			if ((object)_inputModule == null || ((UnityEngine.Object)inputModule).m_CachedPtr == (IntPtr)0)
			{
				rewiredStandaloneInputModule = UnityEngine.Object.FindObjectOfType<RewiredStandaloneInputModule>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_inputModule = rewiredStandaloneInputModule;
				if (flag)
				{
					goto IL_012d;
				}
				object obj = this + 216;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			rewiredStandaloneInputModule = _inputModule;
			goto IL_012d;
			IL_012d:
			return rewiredStandaloneInputModule;
		}
	}

	private void Awake()
	{
		//IL_003d: Expected O, but got I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_006a->IL017a: Incompatible stack heights: 1 vs 0
		//IL_0237->IL017a: Incompatible stack heights: 2 vs 0
		//IL_0291->IL017a: Incompatible stack heights: 3 vs 0
		//IL_00cd->IL017a: Incompatible stack heights: 3 vs 0
		//IL_0174->IL0296: Incompatible stack heights: 3 vs 0
		CanvasGroup component = GetComponent<CanvasGroup>();
		_canvasGroup = component;
		if ((object)_canvasGroup != null)
		{
			_canvasGroup.alpha = 0f;
			object obj = 0;
			object obj2 = default(object);
			while (true)
			{
				bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1830B46D0");
				if (obj2 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v33 (System.Object)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v33 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
				if ((object)gameObject == null)
				{
					break;
				}
				bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
				List<object> twitchOptionsPool = (List<object>)(object)_twitchOptionsPool;
				if (_twitchOptionsPool == null)
				{
					break;
				}
				int version = twitchOptionsPool._version + 1;
				twitchOptionsPool._version = version;
				object[] items = twitchOptionsPool._items;
				if (twitchOptionsPool._items == null)
				{
					break;
				}
				if (twitchOptionsPool._size >= items.Length)
				{
					((List<object>)(object)_twitchOptionsPool).AddWithResize(obj2);
				}
				else
				{
					int size = twitchOptionsPool._size + 1;
					twitchOptionsPool._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				obj++;
				bool flag4 = (nint)obj < 10;
				Vector3 zeroVector = Vector3.zeroVector;
				Quaternion identityQuaternion = Quaternion.identityQuaternion;
				if (!flag4)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Update()
	{
		_twitchLimitCount = 0;
	}

	public void InitTwitchPanel(LevelUpPage levelUpPage)
	{
		_levelUpPage = levelUpPage;
		DisableAllUIInteraction();
		_canvasGroup.alpha = 1f;
		VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
		interactingPlayer._003CAlwaysRandomLimitBreak_003Ek__BackingField = true;
		_banishChoice = false;
		CleanTwitchOptions();
		CreateCountDownBar();
	}

	public void ShowCountdown()
	{
		_countdownStarted = false;
		DisableAllUIInteraction();
		CreateButtons();
		IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
		Action<Chatter> value = ProcessMessage;
		twitchClient.OnChatMessage += value;
		Action onComplete = StartCountdown;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer timer = TimerHelper.RegisterMillisUI(5000f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
	}

	public void EnableAllUIInteraction()
	{
		_NavigatorsRoot.SetActive(value: true);
		RewiredStandaloneInputModule inputModule = InputModule;
		inputModule.enabled = true;
		Debug.Log("Re-enabling all UI interaction");
	}

	private unsafe void CreateCountDownBar()
	{
		//IL_0100: Expected O, but got Ref
		//IL_008d->IL011a: Incompatible stack heights: 1 vs 0
		if ((object)_CountDownBackground != null)
		{
			Transform transform = _CountDownBackground.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_CountDownBackground, 1f, 0.15f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ rax_v21 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				if ((object)_CountDownFill != null)
				{
					Transform transform2 = _CountDownFill.transform;
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
					bool flag4 = (object)_CountDownNumberText == null;
					Transform transform3 = ((Component)_CountDownNumberText).transform;
					bool flag5 = (object)transform3 == null;
					transform3.localEulerAngles = (Vector3)(&value);
					TextMeshProUGUI textMeshProUGUI = RenderingExtensions.SetScale(_CountDownNumberText, 0f);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CreateButtons()
	{
		//IL_0678: Expected O, but got Ref
		//IL_0171->IL0552: Incompatible stack heights: 2 vs 1
		//IL_01ff->IL06a9: Incompatible stack heights: 2 vs 1
		//IL_028d->IL0577: Incompatible stack heights: 2 vs 1
		//IL_0683->IL0683: Incompatible stack heights: 3 vs 1
		_howManyOptions = 0;
		_rerollOptionNumber = 0;
		_banishOptionNumber = 0;
		List<int> twitchOptionCounter = new List<int>();
		_twitchOptionCounter = twitchOptionCounter;
		LevelUpPage levelUpPage = _levelUpPage;
		List<LevelUpItemUI> spawnedItems = levelUpPage._spawnedItems;
		CleanTwitchOptions();
		bool flag = spawnedItems._size <= 0;
		LevelUpItemUI[] items = spawnedItems._items;
		TwitchLevelUpOption twitchLevelUpOption = SpawnTwitchOption(targetPositionTransform: items[0].GetComponent<RectTransform>(), callback: OptionZeroSelected, parent: _PositionOption1);
		if (spawnedItems._size > 1)
		{
			bool flag2 = spawnedItems._size <= 1;
			LevelUpItemUI[] items2 = spawnedItems._items;
			TwitchLevelUpOption twitchLevelUpOption2 = SpawnTwitchOption(targetPositionTransform: items2[1].GetComponent<RectTransform>(), callback: OptionOneSelected, parent: _PositionOption2);
			_howManyOptions = 1;
		}
		if (spawnedItems._size > 2)
		{
			bool flag3 = spawnedItems._size <= 2;
			LevelUpItemUI[] items3 = spawnedItems._items;
			TwitchLevelUpOption twitchLevelUpOption3 = SpawnTwitchOption(targetPositionTransform: items3[2].GetComponent<RectTransform>(), callback: OptionTwoSelected, parent: _PositionOption3);
			_howManyOptions = 2;
		}
		if (spawnedItems._size > 3)
		{
			bool flag4 = spawnedItems._size <= 3;
			LevelUpItemUI[] items4 = spawnedItems._items;
			TwitchLevelUpOption twitchLevelUpOption4 = SpawnTwitchOption(targetPositionTransform: items4[3].GetComponent<RectTransform>(), callback: OptionThreeSelected, parent: _PositionOption4);
			_howManyOptions = 3;
		}
		LevelUpPage levelUpPage2 = _levelUpPage;
		if (levelUpPage2._hasReRolls)
		{
			TwitchLevelUpOption twitchLevelUpOption5 = SpawnTwitchOption(targetPositionTransform: levelUpPage2._RerollButton.GetComponent<RectTransform>(), callback: OnTwitchReroll, parent: _PositionRerolls);
			List<TwitchLevelUpOption> twitchOptions = _twitchOptions;
			int rerollOptionNumber = twitchOptions._size - 1;
			_rerollOptionNumber = rerollOptionNumber;
		}
		LevelUpPage levelUpPage3 = _levelUpPage;
		if (levelUpPage3._hasSkips)
		{
			TwitchLevelUpOption twitchLevelUpOption6 = SpawnTwitchOption(targetPositionTransform: levelUpPage3._SkipButton.GetComponent<RectTransform>(), callback: OnTwitchSkip, parent: _PositionSkip);
			List<TwitchLevelUpOption> twitchOptions2 = _twitchOptions;
			int skipOptionNumber = twitchOptions2._size - 1;
			_skipOptionNumber = skipOptionNumber;
		}
		LevelUpPage levelUpPage4 = _levelUpPage;
		if (levelUpPage4._hasBanish)
		{
			TwitchLevelUpOption twitchLevelUpOption7 = SpawnTwitchOption(targetPositionTransform: levelUpPage4._BanishButton.GetComponent<RectTransform>(), callback: OnTwitchBanish, parent: _PositionBanish);
			List<TwitchLevelUpOption> twitchOptions3 = _twitchOptions;
			int banishOptionNumber = twitchOptions3._size - 1;
			_banishOptionNumber = banishOptionNumber;
		}
		LevelUpPage levelUpPage5 = _levelUpPage;
		if (levelUpPage5._canPass)
		{
			TwitchLevelUpOption twitchLevelUpOption8 = SpawnTwitchOption(targetPositionTransform: levelUpPage5._PassButton.GetComponent<RectTransform>(), callback: OnTwitchPass, parent: _PositionPass);
			List<TwitchLevelUpOption> twitchOptions4 = _twitchOptions;
			int passOptionNumber = twitchOptions4._size - 1;
			_passOptionNumber = passOptionNumber;
		}
		List<TwitchLevelUpOption>.Enumerator enumerator = default(List<TwitchLevelUpOption>.Enumerator);
		List<TwitchLevelUpOption>.Enumerator enumerator2 = default(List<TwitchLevelUpOption>.Enumerator);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rbx_v15 (System.Object)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rbx_v15 (System.Object)+10]");
			IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
			Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.15f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rbx_v15 (System.Object)+10]");
			bool flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rbx_v15 (System.Object)+10]");
			IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
			Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target2, (Vector3)(&enumerator2), 0.15f);
		}
	}

	private unsafe TwitchLevelUpOption SpawnTwitchOption(Transform parent, RectTransform targetPositionTransform, Action callback)
	{
		//IL_0146: Expected O, but got I
		//IL_01c2: Expected O, but got I
		//IL_0260: Expected O, but got Ref
		//IL_0305: Expected O, but got Ref
		//IL_045f->IL0321: Incompatible stack heights: 2 vs 0
		//IL_03d8->IL0321: Incompatible stack heights: 2 vs 0
		//IL_0084->IL0321: Incompatible stack heights: 3 vs 0
		//IL_011e->IL0321: Incompatible stack heights: 2 vs 0
		//IL_0166->IL0321: Incompatible stack heights: 2 vs 0
		//IL_00dc->IL03be: Incompatible stack heights: 4 vs 2
		//IL_01ac->IL03dd: Incompatible stack heights: 2 vs 3
		//IL_03f5->IL0321: Incompatible stack heights: 3 vs 0
		//IL_0222->IL0321: Incompatible stack heights: 3 vs 0
		if ((object)parent != null)
		{
			bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)parent).m_CachedPtr, out Vector3 ret);
			Rect worldRect = VampireSurvivors.App.Tools.Extensions.GetWorldRect(targetPositionTransform);
			bool flag2 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
			Transform.set_position_Injected(((UnityEngine.Object)parent).m_CachedPtr, ref ret);
			List<object> twitchOptionsPool = (List<object>)(object)_twitchOptionsPool;
			if (_twitchOptionsPool != null)
			{
				Component component;
				if (twitchOptionsPool._size > 0)
				{
					bool flag3 = twitchOptionsPool._size <= 0;
					object[] items = twitchOptionsPool._items;
					if (twitchOptionsPool._items == null)
					{
						goto IL_0321;
					}
					bool flag4 = items.Length <= 0;
					bool flag5 = ((List<object>)(object)_twitchOptionsPool).Remove(items[0]);
					component = (Component)items[0];
				}
				else
				{
					component = null;
				}
				if (_twitchOptions != null)
				{
					bool flag6 = _twitchOptions.Remove((TwitchLevelUpOption)component);
					List<int> twitchOptionCounter = _twitchOptionCounter;
					if (_twitchOptionCounter != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v13+18]");
							if (num >= 0)
							{
								_twitchOptionCounter.AddWithResize(0);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj2 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rcx_v32 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r8_v13+18]");
								bool flag7 = num2 >= 0;
								_ = 0;
							}
							if ((object)component != null)
							{
								Transform transform = component.transform;
								if ((object)transform != null)
								{
									transform.SetParent(parent, worldPositionStays: false);
									bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
									List<TwitchLevelUpOption> twitchOptions = _twitchOptions;
									bool flag9 = _twitchOptions == null;
									object obj3 = default(object);
									string text = System.Number.FormatInt32(twitchOptions._size, (ReadOnlySpan<char>)(&obj3), null);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbx_v14 (UnityEngine.Component)+20]");
									bool flag10 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
									GameObject gameObject = component.gameObject;
									bool flag11 = (object)gameObject == null;
									gameObject.SetActive(value: true);
									Transform transform2 = component.transform;
									bool flag12 = (object)transform2 == null;
									transform2.localEulerAngles = (Vector3)(&obj3);
									TwitchLevelUpOption twitchLevelUpOption = RenderingExtensions.SetScale((TwitchLevelUpOption)component, 0.2f);
									return (TwitchLevelUpOption)component;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0321;
		IL_0321:
		throw new NullReferenceException();
	}

	private TwitchLevelUpOption GrabOptionFromPool()
	{
		List<TwitchLevelUpOption> twitchOptionsPool = _twitchOptionsPool;
		if (twitchOptionsPool._size > 0)
		{
			if (twitchOptionsPool._size > 0)
			{
				TwitchLevelUpOption[] items = twitchOptionsPool._items;
				bool flag = ((List<object>)(object)_twitchOptionsPool).Remove((object)items[0]);
				return items[0];
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			TwitchLevelUpOption result = default(TwitchLevelUpOption);
			return result;
		}
		return null;
	}

	private void AdjustOptionSpawnPosition(Transform spawnParentTransform, RectTransform targetRectTransform)
	{
		bool flag = ((UnityEngine.Object)spawnParentTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)spawnParentTransform).m_CachedPtr, out Vector3 ret);
		Rect worldRect = VampireSurvivors.App.Tools.Extensions.GetWorldRect(targetRectTransform);
		bool flag2 = ((UnityEngine.Object)spawnParentTransform).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)spawnParentTransform).m_CachedPtr, ref ret);
	}

	private void CleanTwitchOptions()
	{
		//IL_0018: Expected O, but got I4
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_055f: Expected O, but got I4
		//IL_0070->IL0318: Incompatible stack heights: 1 vs 0
		//IL_00a7->IL0318: Incompatible stack heights: 1 vs 0
		//IL_03b4->IL0318: Incompatible stack heights: 2 vs 0
		//IL_040e->IL0318: Incompatible stack heights: 3 vs 0
		//IL_010a->IL0318: Incompatible stack heights: 4 vs 0
		//IL_0141->IL0318: Incompatible stack heights: 4 vs 0
		//IL_04aa->IL0318: Incompatible stack heights: 6 vs 0
		//IL_018b->IL0318: Incompatible stack heights: 6 vs 0
		//IL_01da->IL0318: Incompatible stack heights: 7 vs 0
		//IL_0211->IL0318: Incompatible stack heights: 7 vs 0
		//IL_0568->IL056d: Incompatible stack heights: 10 vs 0
		//IL_056d->IL0237: Incompatible stack heights: 10 vs 0
		List<TwitchLevelUpOption> twitchOptions = _twitchOptions;
		bool flag = (nint)_twitchOptions < 0;
		if (_twitchOptions != null)
		{
			object obj = twitchOptions._size - 1;
			if (flag)
			{
				goto IL_0237;
			}
			Vector3 value = default(Vector3);
			while (true)
			{
				List<TwitchLevelUpOption> twitchOptions2 = _twitchOptions;
				if (_twitchOptions == null)
				{
					break;
				}
				bool flag2 = (nint)obj >= twitchOptions2._size;
				TwitchLevelUpOption[] items = twitchOptions2._items;
				if (twitchOptions2._items == null)
				{
					break;
				}
				object obj2 = items[obj];
				if ((object)items[obj] == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v18 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v18 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject == null)
				{
					break;
				}
				bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, false);
				List<TwitchLevelUpOption> twitchOptions3 = _twitchOptions;
				if (_twitchOptions == null)
				{
					break;
				}
				bool flag5 = (nint)obj >= twitchOptions3._size;
				TwitchLevelUpOption[] items2 = twitchOptions3._items;
				if (twitchOptions3._items == null)
				{
					break;
				}
				object obj3 = items2[obj];
				if ((object)items2[obj] == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v20 (System.Object)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v20 (System.Object)+10]");
				IntPtr gcHandlePtr2 = Component.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
				bool flag7 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
				Transform parent = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
				if ((object)transform == null)
				{
					break;
				}
				transform.SetParent(parent, worldPositionStays: true);
				List<TwitchLevelUpOption> twitchOptions4 = _twitchOptions;
				if (_twitchOptions == null)
				{
					break;
				}
				bool flag8 = (nint)obj >= twitchOptions4._size;
				TwitchLevelUpOption[] items3 = twitchOptions4._items;
				if (twitchOptions4._items == null)
				{
					break;
				}
				object obj4 = items3[obj];
				if ((object)items3[obj] == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v22 (System.Object)+10]");
				bool flag9 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdi_v22 (System.Object)+10]");
				IntPtr gcHandlePtr4 = Component.get_transform_Injected((IntPtr)0);
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr4);
				bool flag10 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1216 @ rax_v69 (UnityEngine.Transform)+10]");
				bool flag11 = (nint)0 == 0;
				bool flag12 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1216 @ rax_v69 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				obj--;
				object obj5 = !flag12;
				if (obj5 != null)
				{
					continue;
				}
				goto IL_0237;
			}
		}
		goto IL_0318;
		IL_0237:
		List<object> twitchOptionsPool = (List<object>)(object)_twitchOptionsPool;
		if (_twitchOptionsPool != null)
		{
			((List<object>)(object)_twitchOptionsPool).InsertRange(twitchOptionsPool._size, (IEnumerable<object>)_twitchOptions);
			List<TwitchLevelUpOption> twitchOptions5 = _twitchOptions;
			if (_twitchOptions != null)
			{
				int version = twitchOptions5._version + 1;
				twitchOptions5._version = version;
				twitchOptions5._size = 0;
				if (twitchOptions5._size > 0)
				{
					Array.Clear(twitchOptions5._items, 0, twitchOptions5._size);
				}
				return;
			}
		}
		goto IL_0318;
		IL_0318:
		throw new NullReferenceException();
	}

	private void StartCountdown()
	{
		//IL_0036: Expected O, but got I8
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_020a: Expected O, but got I4
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		if (_countdownStarted)
		{
			return;
		}
		_countdownStarted = true;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(_CountDownFill, 0f, 7.0000005f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbp_v2+462E0+v161 @ rdx_v12*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbp_v2+462E0+v161 @ rdx_v12*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbp_v2+462E0+v161 @ rdx_v12*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbp_v2+462E0+v161 @ rdx_v12*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbp_v2+462E0+v161 @ rdx_v12*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = CountdownComplete;
					tweenCallback2 = tweenCallback;
					goto IL_015c;
				}
			}
		}
		TweenCallback tweenCallback3 = CountdownComplete;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_015c;
		}
		goto IL_018b;
		IL_015c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_018b;
		IL_018b:
		_twitchCountdownBarTween = tweenerCore;
		EnterCountdownNumber(6);
	}

	private unsafe void EnterCountdownNumber(int num)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		//IL_009a: Expected O, but got Ref
		//IL_00bd: Expected O, but got Ref
		//IL_0299: Expected O, but got Ref
		_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass43_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.num = num;
		int num2 = CS_0024_003C_003E8__locals5 + 24;
		string text = ((int*)num2)->ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Transform transform = _CountDownNumberText.transform;
		Transform transform2 = RenderingExtensions.SetScale(transform, 0f);
		Transform transform3 = transform.transform;
		object obj = default(object);
		transform3.localEulerAngles = (Vector3)(&obj);
		Color color = _CountDownNumberText.color;
		_CountDownNumberText.color = (Color)(&obj);
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(transform, 1f, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(transform, (Vector3)(&obj), 0.5f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, 0f);
		}
		TweenCallback onComplete = delegate
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this.ExitCountdownNumber(CS_0024_003C_003E8__locals5.num);
		};
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = onComplete;
		}
	}

	private void ExitCountdownNumber(int num)
	{
		_003C_003Ec__DisplayClass44_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass44_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.num = num;
		Transform target = _CountDownNumberText.transform;
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 2f, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(_CountDownNumberText, 0f, 0.5f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, 0f);
		}
		TweenCallback onComplete = delegate
		{
			if (CS_0024_003C_003E8__locals5.num > 1)
			{
				int num2 = CS_0024_003C_003E8__locals5.num - 1;
				CS_0024_003C_003E8__locals5._003C_003E4__this.EnterCountdownNumber(num2);
			}
		};
		if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			sequence.onComplete = onComplete;
		}
	}

	private void EndCountDownNumber(int num)
	{
		if (num > 1)
		{
			int num2 = num - 1;
			EnterCountdownNumber(num2);
		}
	}

	private unsafe void CountdownComplete()
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0370: Expected I, but got O
		//IL_0386: Expected O, but got I
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_040a: Expected I, but got O
		//IL_04f8: Expected O, but got I4
		//IL_050f: Expected I, but got I8
		//IL_03e6: Expected I, but got I8
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_02ff: Expected F4, but got I4
		//IL_022a->IL040f: Incompatible stack heights: 1 vs 0
		//IL_0261->IL040f: Incompatible stack heights: 1 vs 0
		//IL_0322->IL04cb: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass46_0 obj = new _003C_003Ec__DisplayClass46_0();
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			if (TwitchIntegration._sInstance != null)
			{
				IRC twitchClient = TwitchIntegration._sInstance.TwitchClient;
				Action<Chatter> value = ProcessMessage;
				if ((object)twitchClient != null)
				{
					twitchClient.OnChatMessage -= value;
					int twitchChoice = CalculateChoice();
					obj.twitchChoice = twitchChoice;
					List<TwitchLevelUpOption> list = new List<TwitchLevelUpOption>();
					List<TwitchLevelUpOption> twitchOptions = _twitchOptions;
					bool flag = _twitchOptions == null;
					IRC iRC = null;
					IRC iRC2 = null;
					if (!flag)
					{
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						while (true)
						{
							if ((nint)iRC2 < twitchOptions._size)
							{
								if ((nint)iRC != obj.twitchChoice)
								{
									if (_twitchOptions == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									if (list == null)
									{
										break;
									}
									list._002Ector();
								}
								twitchOptions = _twitchOptions;
								iRC = (IRC)(iRC + 1);
								if (_twitchOptions == null)
								{
									break;
								}
								iRC2 = iRC;
								continue;
							}
							Sequence sequence = DOTween.Sequence();
							if (list == null)
							{
								break;
							}
							IRC iRC3 = null;
							IRC iRC4 = null;
							while (true)
							{
								if ((nint)iRC3 < list._size)
								{
									bool flag2 = (nint)iRC4 >= list._size;
									TwitchLevelUpOption[] items = list._items;
									if (list._items == null)
									{
										break;
									}
									IRC iRC5 = (IRC)(object)items[(object)iRC4];
									if ((object)items[(object)iRC4] == null)
									{
										break;
									}
									bool flag3 = ((UnityEngine.Object)iRC5).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)iRC5).m_CachedPtr);
									Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.15f);
									if (tweenerCore != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ rax_v49 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 != 0)
										{
											_ = 1;
											_ = 0;
										}
									}
									bool flag4 = TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false);
									bool flag5 = !flag4;
									float num = 0.15f;
									if (!flag5)
									{
										Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
										num = 0f;
									}
									iRC4 = (IRC)(iRC4 + 1);
									iRC3 = iRC4;
									continue;
								}
								Action action = null;
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r10_v1 (Il2CppMethodInfo)+8]");
								((Delegate)action).method_ptr = (IntPtr)0;
								((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass46_0._003CCountdownComplete_003Eb__0);
								((Delegate)action).m_target = obj;
								((Delegate)action).method_code = (IntPtr)action;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r10_v1 (Il2CppMethodInfo)+4C]");
								object obj2 = (nint)0 >> 4;
								object obj3 = obj2 & 1;
								nint num3;
								if (obj3 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r10_v1 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num3 = unchecked((nint)6447293664L);
										goto IL_04ef;
									}
								}
								num3 = ((Delegate)action).method_ptr;
								((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
								goto IL_04ef;
								IL_04ef:
								object obj4 = 24;
								((Delegate)action).extra_arg = unchecked((nint)6447293568L);
								Timer timer = TimerHelper.RegisterMillisUI(1000f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
								return;
							}
							break;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ProcessMessage(Chatter chatter)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00b7: Expected O, but got I4
		//IL_00c4: Expected O, but got I8
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0a35: Expected O, but got I4
		//IL_0768: Expected O, but got I4
		//IL_056a: Expected O, but got I4
		//IL_0857: Expected O, but got I4
		//IL_0659: Expected O, but got I4
		//IL_0946: Expected O, but got I4
		//IL_038c: Expected O, but got I4
		//IL_047b: Expected O, but got I4
		//IL_09c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Expected Ref, but got Unknown
		//IL_09e5: Expected I8, but got I4
		//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f4: Expected Ref, but got Unknown
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abd: Expected Ref, but got Unknown
		//IL_0ad4: Expected I8, but got I4
		//IL_0ade: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae3: Expected Ref, but got Unknown
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0701: Expected Ref, but got Unknown
		//IL_0718: Expected I8, but got I4
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected Ref, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected Ref, but got Unknown
		//IL_051a: Expected I8, but got I4
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected Ref, but got Unknown
		//IL_07eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f0: Expected Ref, but got Unknown
		//IL_0807: Expected I8, but got I4
		//IL_0811: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Expected Ref, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Expected Ref, but got Unknown
		//IL_0609: Expected I8, but got I4
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_0618: Expected Ref, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected Ref, but got Unknown
		//IL_021e: Expected I8, but got I4
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected Ref, but got Unknown
		//IL_08da: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected Ref, but got Unknown
		//IL_08f6: Expected I8, but got I4
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_0905: Expected Ref, but got Unknown
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected Ref, but got Unknown
		//IL_033c: Expected I8, but got I4
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected Ref, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected Ref, but got Unknown
		//IL_042b: Expected I8, but got I4
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2D3F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (chatter == null || _twitchLimitCount > 20)
		{
			return;
		}
		int twitchLimitCount = _twitchLimitCount + 1;
		_twitchLimitCount = twitchLimitCount;
		string text = chatter.message;
		if (chatter.message == null)
		{
			return;
		}
		object obj = chatter.message + 20;
		object obj2 = 0;
		object obj3 = 2166136261L;
		while (true)
		{
			if ((nint)obj2 < text._stringLength)
			{
				if ((nint)obj2 >= text._stringLength)
				{
					break;
				}
				obj2++;
				object obj4 = obj ^ obj3;
				obj3 = obj4 * 16777619;
				obj += 2;
				continue;
			}
			if ((nint)obj3 > 856466825)
			{
				if ((nint)obj3 > 906799682)
				{
					if ((nint)obj3 == 923577301)
					{
						object obj5 = "2";
						if ((object)text != "2")
						{
							if ("2" == null)
							{
								return;
							}
							int stringLength = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdx_v50+10]");
							if ((nint)stringLength != 0)
							{
								return;
							}
							ref byte first = ref *(byte*)(text + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							if (!System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("2" + 20), length))
							{
								return;
							}
						}
						IRCTags tags = chatter.tags;
						IncreaseTwitchOption(1, tags.displayName);
						return;
					}
					if ((nint)obj3 == 1007465396)
					{
						object obj6 = "9";
						if ((object)text != "9")
						{
							if ("9" == null)
							{
								return;
							}
							int stringLength2 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rdx_v46+10]");
							if ((nint)stringLength2 != 0)
							{
								return;
							}
							ref byte first2 = ref *(byte*)(text + 20);
							ulong length2 = (ulong)(text._stringLength + text._stringLength);
							if (!System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("9" + 20), length2))
							{
								return;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 323 Invalid \"Jump target not found in method: 0x186BFA900\"");
						obj3 = 8;
						text = null;
					}
					if ((nint)obj3 != 1024243015)
					{
						return;
					}
					object obj7 = "8";
					if ((object)text != "8")
					{
						if ("8" == null)
						{
							return;
						}
						int stringLength3 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v42+10]");
						if ((nint)stringLength3 != 0)
						{
							return;
						}
						ref byte first3 = ref *(byte*)(text + 20);
						ulong length3 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("8" + 20), length3))
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 408 Invalid \"Jump target not found in method: 0x186BFA900\"");
					obj3 = 7;
					text = null;
				}
				if ((nint)obj3 == 873244444)
				{
					object obj8 = "1";
					if ((object)text != "1")
					{
						if ("1" == null)
						{
							return;
						}
						int stringLength4 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v37+10]");
						if ((nint)stringLength4 != 0)
						{
							return;
						}
						ref byte first4 = ref *(byte*)(text + 20);
						ulong length4 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("1" + 20), length4))
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 493 Invalid \"Jump target not found in method: 0x186BFA900\"");
					obj3 = 0;
					text = null;
				}
				if ((nint)obj3 != 906799682)
				{
					return;
				}
				object obj9 = "3";
				if ((object)text != "3")
				{
					if ("3" == null)
					{
						return;
					}
					int stringLength5 = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdx_v33+10]");
					if ((nint)stringLength5 != 0)
					{
						return;
					}
					ref byte first5 = ref *(byte*)(text + 20);
					ulong length5 = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("3" + 20), length5))
					{
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 578 Invalid \"Jump target not found in method: 0x186BFA900\"");
				obj3 = 2;
				text = null;
			}
			if ((nint)obj3 > 806133968)
			{
				if ((nint)obj3 == 822911587)
				{
					object obj10 = "4";
					if ((object)text != "4")
					{
						if ("4" == null)
						{
							return;
						}
						int stringLength6 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rdx_v27+10]");
						if ((nint)stringLength6 != 0)
						{
							return;
						}
						ref byte first6 = ref *(byte*)(text + 20);
						ulong length6 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("4" + 20), length6))
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 677 Invalid \"Jump target not found in method: 0x186BFA900\"");
					obj3 = 3;
					text = null;
				}
				if ((nint)obj3 == 839689206)
				{
					object obj11 = "7";
					if ((object)text != "7")
					{
						if ("7" == null)
						{
							return;
						}
						int stringLength7 = text._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v23+10]");
						if ((nint)stringLength7 != 0)
						{
							return;
						}
						ref byte first7 = ref *(byte*)(text + 20);
						ulong length7 = (ulong)(text._stringLength + text._stringLength);
						if (!System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("7" + 20), length7))
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 762 Invalid \"Jump target not found in method: 0x186BFA900\"");
					obj3 = 6;
					text = null;
				}
				if ((nint)obj3 != 856466825)
				{
					return;
				}
				object obj12 = "6";
				if ((object)text != "6")
				{
					if ("6" == null)
					{
						return;
					}
					int stringLength8 = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v19+10]");
					if ((nint)stringLength8 != 0)
					{
						return;
					}
					ref byte first8 = ref *(byte*)(text + 20);
					ulong length8 = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref first8, ref *(byte*)("6" + 20), length8))
					{
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 847 Invalid \"Jump target not found in method: 0x186BFA900\"");
				obj3 = 5;
				text = null;
			}
			if ((nint)obj3 == 468396612)
			{
				object obj13 = "10";
				if ((object)text != "10")
				{
					if ("10" == null)
					{
						return;
					}
					int stringLength9 = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v13+10]");
					if ((nint)stringLength9 != 0)
					{
						return;
					}
					ref byte first9 = ref *(byte*)(text + 20);
					ulong length9 = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref first9, ref *(byte*)("10" + 20), length9))
					{
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 932 Invalid \"Jump target not found in method: 0x186BFA900\"");
				obj3 = 9;
				text = null;
			}
			if ((nint)obj3 != 806133968)
			{
				return;
			}
			object obj14 = "5";
			if ((object)text != "5")
			{
				if ("5" == null)
				{
					return;
				}
				int stringLength10 = text._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v9+10]");
				if ((nint)stringLength10 != 0)
				{
					return;
				}
				ref byte first10 = ref *(byte*)(text + 20);
				ulong length10 = (ulong)(text._stringLength + text._stringLength);
				if (!System.SpanHelpers.SequenceEqual(ref first10, ref *(byte*)("5" + 20), length10))
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1017 Invalid \"Jump target not found in method: 0x186BFA900\"");
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowIndexOutOfRangeException();
	}

	private void IncreaseTwitchOption(int num, string username)
	{
		//IL_0207: Expected O, but got I
		//IL_0222: Expected O, but got I
		//IL_0285: Expected O, but got I
		//IL_02cc: Invalid comparison between F4 and I
		//IL_02f3: Expected F4, but got I
		List<int> twitchOptionCounter = _twitchOptionCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num >= (nint)0)
		{
			return;
		}
		if (num > 0)
		{
			if (num == _rerollOptionNumber)
			{
				LevelUpPage levelUpPage = _levelUpPage;
				if (!levelUpPage._hasReRolls)
				{
					return;
				}
			}
			if (num == _skipOptionNumber)
			{
				LevelUpPage levelUpPage2 = _levelUpPage;
				if (!levelUpPage2._hasSkips)
				{
					return;
				}
			}
			if (num == _banishOptionNumber)
			{
				LevelUpPage levelUpPage3 = _levelUpPage;
				if (!levelUpPage3._hasBanish)
				{
					return;
				}
			}
			if (num == _passOptionNumber)
			{
				LevelUpPage levelUpPage4 = _levelUpPage;
				if (!levelUpPage4._canPass)
				{
					return;
				}
			}
		}
		if (!_countdownStarted)
		{
			StartCountdown();
		}
		List<int> twitchOptionCounter2 = _twitchOptionCounter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+20+num @ rdx (System.Int32)*4]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rcx_v8 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			_ = (nint)0 + (nint)1;
			List<int> twitchOptionCounter3 = _twitchOptionCounter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)num < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v12 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj3 = 0;
				List<TwitchLevelUpOption> twitchOptions = _twitchOptions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v9+20+num @ rdx (System.Int32)*4]");
				float num2 = 0f * 0.025f;
				float num3 = num2 + 1f;
				float num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10610]");
				if (num4 > 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A10610]");
					num3 = 0f;
				}
				if (num < twitchOptions._size)
				{
					TwitchLevelUpOption[] items = twitchOptions._items;
					float scale = num3 + 0.05f;
					TwitchLevelUpOption twitchLevelUpOption = RenderingExtensions.SetScale(items[num], scale);
					Transform target = items[num].transform;
					TweenerCore<Vector3, Vector3, VectorOptions> component = ShortcutExtensions.DOScale(target, num3, 0.05f);
					TwitchLevelUpOption twitchLevelUpOption2 = RenderingExtensions.SetScale((TwitchLevelUpOption)(object)component, num3);
					return;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private int CalculateChoice()
	{
		//IL_004b: Expected O, but got I
		//IL_0448: Expected O, but got I4
		//IL_0209: Expected O, but got I
		//IL_0311: Expected O, but got I
		//IL_0150->IL03c2: Incompatible stack heights: 1 vs 0
		//IL_034e->IL03e9: Incompatible stack heights: 1 vs 0
		//IL_0429->IL046f: Incompatible stack heights: 1 vs 0
		//IL_042e->IL02d4: Incompatible stack heights: 1 vs 0
		List<int> list = new List<int>();
		List<int> twitchOptionCounter = _twitchOptionCounter;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		List<int> list2 = list;
		int num4 = 0;
		nint num8 = default(nint);
		object obj2 = default(object);
		int num10 = default(int);
		object obj4 = default(object);
		int num16 = default(int);
		while (true)
		{
			int num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v8 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)num5 < (nint)0)
			{
				List<int> twitchOptionCounter2 = _twitchOptionCounter;
				int num6 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v31 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)num6 < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rax_v31 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj = 0;
					int num7 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v28+18]");
					bool flag = (nint)num7 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v28+20+v97 @ rbx_v3 (System.Int32)*4]");
					if ((nint)0 == num2)
					{
						list2.Add(num3);
						num8 = 0;
					}
					_twitchOptionCounter.Add(num3);
					bool flag2 = (nint)obj2 <= num2;
					nint num9 = num8;
					if (!flag2)
					{
						_twitchOptionCounter.Add(num3);
						List<int> list3 = new List<int> { num3 };
						num = num3;
						num2 = num10;
						num9 = 0;
						list2 = list3;
					}
					twitchOptionCounter = _twitchOptionCounter;
					num3++;
					num8 = num9;
					num4 = num3;
					continue;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdi_v12 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)0 <= (nint)1)
				{
					break;
				}
				List<int> list4 = new List<int>();
				bool flag3 = _howManyOptions < 0;
				List<int> list5 = list4;
				int num11 = 0;
				int num12 = num;
				int num13 = 0;
				List<int> list6 = list4;
				if (flag3)
				{
					goto IL_02d4;
				}
				while (true)
				{
					List<int> twitchOptionCounter3 = _twitchOptionCounter;
					int num14 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v16 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)num14 >= (nint)0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v16 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj3 = 0;
					int num15 = num13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v15+18]");
					bool flag4 = (nint)num15 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rcx_v15+20+v98 @ rbx_v8 (System.Int32)*4]");
					if ((nint)0 == num11)
					{
						list6.Add(num13);
					}
					_twitchOptionCounter.Add(num13);
					if ((nint)obj4 > num11)
					{
						_twitchOptionCounter.Add(num13);
						List<int> list7 = new List<int>();
						num11 = num16;
						num12 = num13;
						list6 = list7;
					}
					num13++;
					bool flag5 = num13 <= _howManyOptions;
					num = num12;
					list5 = list6;
					if (flag5)
					{
						continue;
					}
					goto IL_02d4;
				}
			}
			goto IL_034e;
			IL_02d4:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)0 <= (nint)1)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			object obj5 = UnityEngine.Random.RandomRangeInt(0, 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)obj5 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rdi_v11 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v26+18]");
				bool flag6 = (nint)obj5 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v26+20+v134 @ rax_v28*4]");
				num = 0;
				break;
			}
			goto IL_034e;
			IL_034e:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
		return num;
	}

	private void DisableAllUIInteraction()
	{
		_NavigatorsRoot.SetActive(value: false);
		RewiredStandaloneInputModule inputModule = InputModule;
		inputModule.enabled = false;
		Debug.Log("Disabling all UI interaction");
	}

	private void OptionZeroSelected()
	{
		OptionSelected(0);
	}

	private void OptionOneSelected()
	{
		OptionSelected(1);
	}

	private void OptionTwoSelected()
	{
		OptionSelected(2);
	}

	private void OptionThreeSelected()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x186BFAFE0\"");
	}

	private void OptionSelected(int num)
	{
		LevelUpPage levelUpPage = _levelUpPage;
		List<LevelUpItemUI> spawnedItems = levelUpPage._spawnedItems;
		if (num < spawnedItems._size)
		{
			LevelUpItemUI[] items = spawnedItems._items;
			items[num].Select();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void OnTwitchReroll()
	{
		_levelUpPage.Reroll();
		ResetTwitchOptionCounterValues();
		CreateCountDownBar();
		ShowCountdown();
		DisableAllUIInteraction();
	}

	private void OnTwitchSkip()
	{
		_levelUpPage.Skip();
	}

	private void OnTwitchBanish()
	{
		//IL_015b: Expected O, but got I4
		//IL_0164: Expected O, but got I4
		//IL_0351: Expected O, but got I4
		//IL_035a: Expected O, but got I4
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_0243: Expected O, but got I
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		bool banishChoice = !_banishChoice;
		_banishChoice = banishChoice;
		if (~(_banishChoice ? 1u : 0u) == 0)
		{
			_levelUpPage.CancelBanishMode();
		}
		else
		{
			_levelUpPage.SetBanishMode();
			LevelUpPage levelUpPage = _levelUpPage;
			levelUpPage._hasReRolls = false;
			LevelUpPage levelUpPage2 = _levelUpPage;
			levelUpPage2._hasSkips = false;
			LevelUpPage levelUpPage3 = _levelUpPage;
			levelUpPage3._hasBanish = false;
			LevelUpPage levelUpPage4 = _levelUpPage;
			levelUpPage4._canPass = false;
			LevelUpPage levelUpPage5 = _levelUpPage;
			levelUpPage5._RerollButton.SetActive(value: false);
			LevelUpPage levelUpPage6 = _levelUpPage;
			levelUpPage6._SkipButton.SetActive(value: false);
			LevelUpPage levelUpPage7 = _levelUpPage;
			levelUpPage7._BanishButton.SetActive(value: false);
			LevelUpPage levelUpPage8 = _levelUpPage;
			levelUpPage8._CancelButton.SetActive(value: false);
			LevelUpPage levelUpPage9 = _levelUpPage;
			levelUpPage9._PassButton.SetActive(value: false);
		}
		List<TwitchLevelUpOption> twitchOptions = _twitchOptions;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < twitchOptions._size)
			{
				List<TwitchLevelUpOption> twitchOptions2 = _twitchOptions;
				if ((nint)obj >= twitchOptions2._size)
				{
					break;
				}
				TwitchLevelUpOption[] items = twitchOptions2._items;
				TwitchLevelUpOption twitchLevelUpOption = RenderingExtensions.SetScale(items[obj], 1f);
				twitchOptions = _twitchOptions;
				obj++;
				obj2 = obj;
				continue;
			}
			List<int> twitchOptionCounter = _twitchOptionCounter;
			object obj3 = 0;
			object obj4 = 0;
			while (true)
			{
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v15 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)obj5 < 0)
				{
					List<int> twitchOptionCounter2 = _twitchOptionCounter;
					object obj6 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32>)+18]");
					if ((nint)obj6 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj7 = 0;
					object obj8 = obj3 + 1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v16 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					twitchOptionCounter = _twitchOptionCounter;
					bool flag = _twitchOptionCounter != null;
					obj3 = obj8;
					obj4 = obj8;
					if (!flag)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				CreateCountDownBar();
				ShowCountdown();
				DisableAllUIInteraction();
				return;
			}
			break;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void SetBanishMode()
	{
		_levelUpPage.SetBanishMode();
		LevelUpPage levelUpPage = _levelUpPage;
		levelUpPage._hasReRolls = false;
		LevelUpPage levelUpPage2 = _levelUpPage;
		levelUpPage2._hasSkips = false;
		LevelUpPage levelUpPage3 = _levelUpPage;
		levelUpPage3._hasBanish = false;
		LevelUpPage levelUpPage4 = _levelUpPage;
		levelUpPage4._canPass = false;
		LevelUpPage levelUpPage5 = _levelUpPage;
		levelUpPage5._RerollButton.SetActive(value: false);
		LevelUpPage levelUpPage6 = _levelUpPage;
		levelUpPage6._SkipButton.SetActive(value: false);
		LevelUpPage levelUpPage7 = _levelUpPage;
		levelUpPage7._BanishButton.SetActive(value: false);
		LevelUpPage levelUpPage8 = _levelUpPage;
		levelUpPage8._CancelButton.SetActive(value: false);
		LevelUpPage levelUpPage9 = _levelUpPage;
		levelUpPage9._PassButton.SetActive(value: false);
	}

	private void OnTwitchPass()
	{
		_levelUpPage.Pass();
		ResetTwitchOptionCounterValues();
		CreateCountDownBar();
		ShowCountdown();
	}

	private void ResetTwitchOptionCounterValues()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_005d: Expected O, but got I
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		List<int> twitchOptionCounter = _twitchOptionCounter;
		object obj = 0;
		object obj2 = 0;
		List<int> twitchOptionCounter2 = _twitchOptionCounter;
		while (true)
		{
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rcx_v7 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)obj3 < 0)
			{
				object obj4 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v9 (System.Collections.Generic.List`1<System.Int32>)+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v9 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj5 = 0;
				object obj6 = obj + 1;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v9 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				twitchOptionCounter2 = _twitchOptionCounter;
				obj = obj6;
				obj2 = obj6;
				twitchOptionCounter = _twitchOptionCounter;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TwitchLevelUpPanel()
	{
		List<int> twitchOptionCounter = new List<int>();
		_twitchOptionCounter = twitchOptionCounter;
		List<TwitchLevelUpOption> twitchOptionsPool = new List<TwitchLevelUpOption>();
		_twitchOptionsPool = twitchOptionsPool;
		List<TwitchLevelUpOption> twitchOptions = new List<TwitchLevelUpOption>();
		_twitchOptions = twitchOptions;
	}
}
