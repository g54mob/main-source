using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Rewired;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class ArcanaDisplayContainer : MonoBehaviour, IArcanaDisplayContainer
{
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public ArcanaCardUI card;

		internal void _003CSetArcanaDetails_003Eb__0()
		{
			Tween tween = card.Reveal();
		}
	}

	private ArcanaCardUI _ArcanaCardPrefab;

	private RectTransform _ArcanaCardContainer;

	private ArcanaInfoPanel _ArcanaInfoPanel;

	private float _ArcanaInfoScaleInDuration = 0.1f;

	private float _ArcanaPortraitInfoPanelOffset = 210f;

	private DataManager _dataManager;

	private GameManager _gameManager;

	private List<ArcanaCardUI> _spawnedCards;

	private List<Tween> _spawnedCardTimers;

	private ArcanaType _currentShowingArcana;

	private bool _ignoreNextArcanaClick;

	public Selectable FirstCardSelectable
	{
		get
		{
			List<ArcanaCardUI> spawnedCards = _spawnedCards;
			if (spawnedCards._size > 0)
			{
				if (spawnedCards._size > 0)
				{
					ArcanaCardUI[] items = spawnedCards._items;
					return items[0].GetComponent<Selectable>();
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Selectable result = default(Selectable);
				return result;
			}
			return null;
		}
	}

	private void Construct(DataManager dataManager, GameManager game)
	{
		_dataManager = dataManager;
		_gameManager = game;
	}

	private void Start()
	{
		_ArcanaInfoPanel.Initialize();
		GameObject gameObject = _ArcanaInfoPanel.gameObject;
		gameObject.SetActive(value: false);
	}

	public void SetArcanaInfoPanelControllingPlayer(VampireSurvivors.Objects.Characters.CharacterController characterController)
	{
		ArcanaInfoPanel arcanaInfoPanel = _ArcanaInfoPanel;
		arcanaInfoPanel._controllingCharacter = characterController;
	}

	public unsafe void SetArcanaDetails()
	{
		//IL_0103: Expected I4, but got O
		//IL_0103: Expected O, but got I
		//IL_1220: Unknown result type (might be due to invalid IL or missing references)
		//IL_1225: Expected O, but got Unknown
		//IL_023a: Expected O, but got I
		//IL_0ad8: Expected O, but got I
		//IL_1007: Expected O, but got I
		//IL_0b24: Expected O, but got I
		//IL_0f1b: Expected O, but got I
		//IL_0b51: Expected O, but got I
		//IL_1292: Unknown result type (might be due to invalid IL or missing references)
		//IL_1297: Expected O, but got Unknown
		//IL_179e: Expected O, but got I
		//IL_03d0: Expected O, but got I
		//IL_168e: Expected O, but got I
		//IL_17e6: Expected O, but got I
		//IL_157e: Expected O, but got I
		//IL_12d7: Expected O, but got I
		//IL_16d6: Expected O, but got I
		//IL_0455: Expected O, but got I
		//IL_1822: Expected I4, but got I8
		//IL_1832: Expected O, but got I
		//IL_15c6: Expected O, but got I
		//IL_1712: Expected I4, but got I8
		//IL_1722: Expected O, but got I
		//IL_18cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d1: Expected O, but got Unknown
		//IL_131d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Expected O, but got Unknown
		//IL_1602: Expected I4, but got I8
		//IL_1612: Expected O, but got I
		//IL_1930: Unknown result type (might be due to invalid IL or missing references)
		//IL_1935: Expected O, but got Unknown
		//IL_137f: Expected O, but got I
		//IL_194d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1952: Expected O, but got Unknown
		//IL_195b: Expected F4, but got I4
		//IL_1913: Unknown result type (might be due to invalid IL or missing references)
		//IL_1918: Expected O, but got Unknown
		//IL_064d: Expected I, but got O
		//IL_0663: Expected O, but got I
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_1768: Unknown result type (might be due to invalid IL or missing references)
		//IL_176d: Expected O, but got Unknown
		//IL_1776: Expected F4, but got I4
		//IL_06da: Expected I, but got O
		//IL_18f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fb: Expected O, but got Unknown
		//IL_11c5: Expected O, but got I4
		//IL_11dc: Expected I, but got I8
		//IL_1658: Unknown result type (might be due to invalid IL or missing references)
		//IL_165d: Expected O, but got Unknown
		//IL_1666: Expected F4, but got I4
		//IL_13ec: Expected O, but got I
		//IL_06c3: Expected I, but got I8
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Expected O, but got Unknown
		//IL_080e: Expected O, but got F4
		//IL_144e: Expected O, but got I
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected O, but got Unknown
		//IL_07c0: Expected O, but got F4
		//IL_0d2e: Expected O, but got I
		//IL_14a1: Expected O, but got I
		//IL_14d8: Expected O, but got I4
		//IL_14e8: Expected O, but got I
		//IL_151f: Expected O, but got I4
		//IL_0dcc: Expected O, but got I
		//IL_0e01: Expected O, but got I
		//IL_1551: Unknown result type (might be due to invalid IL or missing references)
		//IL_1556: Expected O, but got Unknown
		//IL_12af->IL18be: Incompatible stack heights: 1 vs 0
		//IL_17be->IL10b8: Incompatible stack heights: 1 vs 0
		//IL_12b4->IL099e: Incompatible stack heights: 1 vs 0
		//IL_16ae->IL10b8: Incompatible stack heights: 1 vs 0
		//IL_0580->IL11b2: Incompatible stack heights: 13 vs 11
		//IL_1806->IL10b8: Incompatible stack heights: 2 vs 0
		//IL_159e->IL10b8: Incompatible stack heights: 1 vs 0
		//IL_12f7->IL10b8: Incompatible stack heights: 1 vs 0
		//IL_16f6->IL10b8: Incompatible stack heights: 2 vs 0
		//IL_1852->IL10b8: Incompatible stack heights: 3 vs 0
		//IL_15e6->IL10b8: Incompatible stack heights: 2 vs 0
		//IL_05d0->IL11b7: Incompatible stack heights: 14 vs 12
		//IL_1742->IL10b8: Incompatible stack heights: 3 vs 0
		//IL_1632->IL10b8: Incompatible stack heights: 3 vs 0
		//IL_1388->IL10b8: Incompatible stack heights: 3 vs 0
		//IL_13f5->IL10b8: Incompatible stack heights: 4 vs 0
		//IL_0813->IL11f1: Incompatible stack heights: 17 vs 0
		//IL_1457->IL10b8: Incompatible stack heights: 5 vs 0
		//IL_07c5->IL11f1: Incompatible stack heights: 17 vs 0
		//IL_0c67->IL10b8: Incompatible stack heights: 5 vs 0
		//IL_0c9e->IL10b8: Incompatible stack heights: 5 vs 0
		//IL_0d4e->IL10b8: Incompatible stack heights: 5 vs 0
		//IL_0cd0->IL10b8: Incompatible stack heights: 5 vs 0
		//IL_0d0a->IL10b8: Incompatible stack heights: 5 vs 0
		//IL_14c1->IL10b8: Incompatible stack heights: 6 vs 0
		//IL_1508->IL10b8: Incompatible stack heights: 7 vs 0
		//IL_1543->IL10b8: Incompatible stack heights: 8 vs 0
		//IL_0dec->IL10b8: Incompatible stack heights: 8 vs 0
		//IL_0e21->IL10b8: Incompatible stack heights: 8 vs 0
		//IL_155b->IL18e0: Incompatible stack heights: 8 vs 4
		DataManager dataManager = _dataManager;
		bool flag = _dataManager == null;
		ArcanaInfoPanel arcanaInfoPanel = (ArcanaInfoPanel)(object)this;
		if (!flag)
		{
			arcanaInfoPanel = _ArcanaInfoPanel;
			if ((object)_ArcanaInfoPanel != null)
			{
				_ArcanaInfoPanel.Initialize();
				if (_spawnedCards != null)
				{
					List<ArcanaCardUI>.Enumerator enumerator = default(List<ArcanaCardUI>.Enumerator);
					if (enumerator.MoveNext())
					{
						Component component = null;
						throw new NullReferenceException();
					}
					arcanaInfoPanel = (ArcanaInfoPanel)(object)_spawnedCards;
					if (_spawnedCards != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)arcanaInfoPanel).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)arcanaInfoPanel).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 0, (int)((MonoBehaviour)arcanaInfoPanel).m_CancellationTokenSource);
						}
						Sequence sequence = DOTween.Sequence();
						GameManager gameManager = _gameManager;
						bool flag2 = (object)_gameManager == null;
						arcanaInfoPanel = null;
						if (!flag2)
						{
							ArcanaManager arcanaManager = gameManager._arcanaManager;
							bool flag3 = gameManager._arcanaManager == null;
							arcanaInfoPanel = null;
							if (!flag3)
							{
								object[] array = (object[])(object)arcanaManager._003CActiveArcanas_003Ek__BackingField;
								bool flag4 = arcanaManager._003CActiveArcanas_003Ek__BackingField == null;
								arcanaInfoPanel = null;
								if (!flag4)
								{
									CancellationTokenSource cancellationTokenSource = null;
									Transform transform = null;
									List<ArcanaType>.Enumerator enumerator3 = default(List<ArcanaType>.Enumerator);
									List<ArcanaType>.Enumerator enumerator2 = enumerator3;
									List<ArcanaType>.Enumerator enumerator4 = default(List<ArcanaType>.Enumerator);
									bool isInteractable = default(bool);
									object obj4 = default(object);
									object obj5 = default(object);
									object obj7 = default(object);
									object obj8 = default(object);
									while (enumerator4.MoveNext())
									{
										_003C_003Ec__DisplayClass16_0 obj = new _003C_003Ec__DisplayClass16_0();
										bool flag5 = dataManager._003CAllArcanas_003Ek__BackingField == null;
										object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)0);
										bool flag6 = obj2 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2336 @ rax_v354 (System.Object)+40]");
										Sprite sprite = SpriteManager.GetSprite((string)0, "randomazzo");
										ArcanaCardUI card = UnityEngine.Object.Instantiate(_ArcanaCardPrefab, _ArcanaCardContainer);
										bool flag7 = obj == null;
										obj.card = card;
										bool flag8 = (object)obj.card == null;
										obj.card.SetData((ArcanaData)obj2, ArcanaType.T00_KILLER, isOpen: false, isInteractable);
										bool flag9 = (object)obj.card == null;
										Selectable component2 = obj.card.GetComponent<Selectable>();
										bool flag10 = (object)component2 == null;
										component2.interactable = true;
										ArcanaCardUI card2 = obj.card;
										bool flag11 = (object)obj.card == null;
										card2._displayContainer = this;
										bool flag12 = (object)obj.card == null;
										Button component3 = obj.card.GetComponent<Button>();
										bool flag13 = (object)component3 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1998 @ rax_v364 (UnityEngine.UI.Button)+10]");
										bool flag14 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1998 @ rax_v364 (UnityEngine.UI.Button)+10]");
										Behaviour.set_enabled_Injected((IntPtr)0, true);
										Transform card3 = (Transform)(object)obj.card;
										bool flag15 = (object)obj.card == null;
										Action<SelectableUI, ArcanaData, ArcanaType, Transform> b = (Action<SelectableUI, ArcanaData, ArcanaType, Transform>)(object)new Action<object, object, System.Int32Enum, object>(CardOnBecameSelected);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1002 @ rdi_v102 (UnityEngine.Transform)+A8]");
										Delegate obj3 = Delegate.Combine((Delegate)0, b);
										if ((object)obj3 == null)
										{
											_ = 0;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											bool flag16 = obj4 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											bool flag17 = obj5 == null;
										}
										Transform card4 = (Transform)(object)obj.card;
										bool flag18 = (object)obj.card == null;
										Action<ArcanaType> b2 = CardOnBecameDeselected;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ rdi_v103 (UnityEngine.Transform)+B0]");
										Delegate obj6 = Delegate.Combine((Delegate)0, b2);
										if ((object)obj6 == null)
										{
											_ = 0;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											bool flag19 = obj7 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											bool flag20 = obj8 == null;
										}
										List<object> spawnedCards = (List<object>)(object)_spawnedCards;
										bool flag21 = _spawnedCards == null;
										int version = spawnedCards._version + 1;
										spawnedCards._version = version;
										object[] items = spawnedCards._items;
										bool flag22 = spawnedCards._items == null;
										if (spawnedCards._size >= items.Length)
										{
											((List<object>)(object)_spawnedCards).AddWithResize((object)obj.card);
										}
										else
										{
											int size = spawnedCards._size + 1;
											spawnedCards._size = size;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										TweenCallback tweenCallback = null;
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6754 @ r9_v85 (Il2CppMethodInfo)+8]");
										((Delegate)tweenCallback).method_ptr = (IntPtr)0;
										((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass16_0._003CSetArcanaDetails_003Eb__0);
										((Delegate)tweenCallback).m_target = obj;
										((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6754 @ r9_v85 (Il2CppMethodInfo)+4C]");
										object obj9 = (nint)0 >> 4;
										object obj10 = obj9 & 1;
										nint num2;
										if (obj10 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6754 @ r9_v85 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num2 = unchecked((nint)6447293664L);
												goto IL_11bc;
											}
										}
										((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
										num2 = ((Delegate)tweenCallback).method_ptr;
										goto IL_11bc;
										IL_11bc:
										object obj11 = 24;
										((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
										float num3 = (float)cancellationTokenSource * 50f;
										float num4 = num3 * 0.001f;
										Tween tween = DOVirtual.DelayedCall(num4, tweenCallback);
										bool flag23 = tween == null;
										tween.stringId = "UI_CUSTOM_TIMER";
										List<object> spawnedCardTimers = (List<object>)(object)_spawnedCardTimers;
										bool flag24 = _spawnedCardTimers == null;
										int version2 = spawnedCardTimers._version + 1;
										spawnedCardTimers._version = version2;
										array = spawnedCardTimers._items;
										bool flag25 = spawnedCardTimers._items == null;
										if (spawnedCardTimers._size >= array.Length)
										{
											((List<object>)(object)_spawnedCardTimers).AddWithResize((object)tween);
											transform = (Transform)(cancellationTokenSource + 1);
											cancellationTokenSource = (CancellationTokenSource)(object)transform;
											enumerator2 = (List<ArcanaType>.Enumerator)num4;
										}
										else
										{
											int size2 = spawnedCardTimers._size + 1;
											spawnedCardTimers._size = size2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											transform = (Transform)(cancellationTokenSource + 1);
											cancellationTokenSource = (CancellationTokenSource)(object)transform;
											enumerator2 = (List<ArcanaType>.Enumerator)num4;
										}
									}
									object obj12 = 3 - transform;
									bool flag26 = (nint)obj12 <= 0;
									object[] array2 = array;
									CancellationTokenSource cancellationTokenSource2 = null;
									if (flag26)
									{
										goto IL_099e;
									}
									while (true)
									{
										ArcanaCardUI arcanaCardUI = UnityEngine.Object.Instantiate(_ArcanaCardPrefab, _ArcanaCardContainer);
										bool flag27 = (object)arcanaCardUI == null;
										arcanaInfoPanel = (ArcanaInfoPanel)(object)_ArcanaCardPrefab;
										if (flag27)
										{
											break;
										}
										arcanaCardUI.SetGreyBackOnly();
										List<object> spawnedCards2 = (List<object>)(object)_spawnedCards;
										bool flag28 = _spawnedCards == null;
										arcanaInfoPanel = (ArcanaInfoPanel)(object)_spawnedCards;
										if (flag28)
										{
											break;
										}
										int version3 = spawnedCards2._version + 1;
										spawnedCards2._version = version3;
										array2 = spawnedCards2._items;
										bool flag29 = spawnedCards2._items == null;
										arcanaInfoPanel = (ArcanaInfoPanel)(object)_spawnedCards;
										if (flag29)
										{
											break;
										}
										if (spawnedCards2._size >= array2.Length)
										{
											((List<object>)(object)_spawnedCards).AddWithResize((object)arcanaCardUI);
										}
										else
										{
											int size3 = spawnedCards2._size + 1;
											spawnedCards2._size = size3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										Selectable component4 = arcanaCardUI.GetComponent<Selectable>();
										bool flag30 = (object)component4 == null;
										arcanaInfoPanel = (ArcanaInfoPanel)(object)arcanaCardUI;
										if (flag30)
										{
											break;
										}
										component4.interactable = false;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rax_v182 (VampireSurvivors.UI.ArcanaCardUI)+10]");
										bool flag31 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rax_v182 (VampireSurvivors.UI.ArcanaCardUI)+10]");
										Behaviour.set_enabled_Injected((IntPtr)0, false);
										cancellationTokenSource2 = (CancellationTokenSource)(cancellationTokenSource2 + 1);
										if (System.Runtime.CompilerServices.Unsafe.As<CancellationTokenSource, UIntPtr>(ref cancellationTokenSource2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
										{
											goto IL_099e;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_10b8;
		IL_1874:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
		return;
		IL_10b8:
		throw new NullReferenceException();
		IL_099e:
		bool flag32 = (object)_ArcanaCardContainer == null;
		arcanaInfoPanel = (ArcanaInfoPanel)(object)_ArcanaCardContainer;
		GridLayoutGroup component5;
		LayoutElement layoutElement;
		object obj22 = default(object);
		object obj21;
		if (!flag32)
		{
			component5 = _ArcanaCardContainer.GetComponent<GridLayoutGroup>();
			GameManager gameManager2 = _gameManager;
			bool flag33 = (object)_gameManager == null;
			arcanaInfoPanel = (ArcanaInfoPanel)(object)typeof(UIHelper);
			if (!flag33)
			{
				ArcanaManager arcanaManager2 = gameManager2._arcanaManager;
				bool flag34 = gameManager2._arcanaManager == null;
				arcanaInfoPanel = (ArcanaInfoPanel)(object)typeof(UIHelper);
				if (!flag34)
				{
					List<ArcanaType> list = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
					bool flag35 = arcanaManager2._003CActiveArcanas_003Ek__BackingField == null;
					arcanaInfoPanel = (ArcanaInfoPanel)(object)typeof(UIHelper);
					if (!flag35)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ rax_v204 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
						bool num5;
						bool num6;
						bool num7;
						bool num8;
						if ((nint)0 >= (nint)4)
						{
							GameManager gameManager3 = _gameManager;
							arcanaInfoPanel = (ArcanaInfoPanel)(object)gameManager3._arcanaManager;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+B0]");
							object obj13 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ rax_v232+18]");
							if ((nint)0 != 4)
							{
								GameManager gameManager4 = _gameManager;
								arcanaInfoPanel = (ArcanaInfoPanel)(object)gameManager4._arcanaManager;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+B0]");
								object obj14 = 0;
								if ((object)component5 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
									arcanaInfoPanel = (ArcanaInfoPanel)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v763 @ rax_v256+18]");
									if ((nint)0 != 5)
									{
										if ((object)arcanaInfoPanel != null)
										{
											bool flag36 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
											RectOffset.set_left_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 38);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											arcanaInfoPanel = (ArcanaInfoPanel)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											if ((nint)0 != 0)
											{
												bool flag37 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
												RectOffset.set_right_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 0);
												object obj15 = component5 + 104;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
												object obj16 = component5 + 112;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
												bool flag38 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
												IntPtr intPtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
												Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(intPtr);
												bool flag39 = (object)transform2 == null;
												arcanaInfoPanel = (ArcanaInfoPanel)(nint)intPtr;
												if (!flag39)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rax_v292 (UnityEngine.Transform)+10]");
													bool flag40 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rax_v292 (UnityEngine.Transform)+10]");
													IntPtr child_Injected = Transform.GetChild_Injected((IntPtr)0, 0);
													Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(child_Injected);
													bool flag41 = (object)transform3 == null;
													arcanaInfoPanel = (ArcanaInfoPanel)(nint)child_Injected;
													if (!flag41)
													{
														bool flag42 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
														IntPtr intPtr2 = Component.get_gameObject_Injected(((UnityEngine.Object)transform3).m_CachedPtr);
														GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(intPtr2);
														bool flag43 = (object)gameObject == null;
														arcanaInfoPanel = (ArcanaInfoPanel)(nint)intPtr2;
														if (!flag43)
														{
															LayoutElement component6 = gameObject.GetComponent<LayoutElement>();
															if ((object)component6 != null)
															{
																bool flag44 = ((UnityEngine.Object)component6).m_CachedPtr != (IntPtr)0;
																layoutElement = component6;
																if (flag44)
																{
																	goto IL_0d0f;
																}
															}
															Transform transform4 = base.transform;
															bool flag45 = (object)transform4 == null;
															arcanaInfoPanel = (ArcanaInfoPanel)(object)this;
															if (!flag45)
															{
																Transform child = transform4.GetChild(0);
																bool flag46 = (object)child == null;
																arcanaInfoPanel = (ArcanaInfoPanel)(object)transform4;
																if (!flag46)
																{
																	GameObject gameObject2 = child.gameObject;
																	bool flag47 = (object)gameObject2 == null;
																	arcanaInfoPanel = (ArcanaInfoPanel)(object)child;
																	if (!flag47)
																	{
																		LayoutElement layoutElement2 = gameObject2.AddComponent<LayoutElement>();
																		bool flag48 = (object)layoutElement2 == null;
																		layoutElement = layoutElement2;
																		arcanaInfoPanel = (ArcanaInfoPanel)(object)gameObject2;
																		if (!flag48)
																		{
																			goto IL_0d0f;
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
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
										if ((nint)0 != 0)
										{
											bool flag49 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
											num5 = flag49;
											RectOffset.set_left_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 38);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											arcanaInfoPanel = (ArcanaInfoPanel)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											if ((nint)0 != 0)
											{
												bool flag50 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
												num6 = flag50;
												RectOffset.set_right_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 0);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
												arcanaInfoPanel = (ArcanaInfoPanel)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
												if ((nint)0 != 0)
												{
													bool flag51 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
													num7 = flag51;
													RectOffset.set_top_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, -42);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
													arcanaInfoPanel = (ArcanaInfoPanel)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
													if ((nint)0 != 0)
													{
														bool flag52 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
														num8 = flag52;
														RectOffset.set_bottom_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 20);
														object obj17 = component5 + 104;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
														object obj18 = component5 + 112;
														float num9 = 0f;
														goto IL_18e0;
													}
												}
											}
										}
									}
								}
							}
							else if ((object)component5 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
								arcanaInfoPanel = (ArcanaInfoPanel)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
								if ((nint)0 != 0)
								{
									bool flag53 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
									num5 = flag53;
									RectOffset.set_left_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 38);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
									arcanaInfoPanel = (ArcanaInfoPanel)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
									if ((nint)0 != 0)
									{
										bool flag54 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
										num6 = flag54;
										RectOffset.set_right_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 0);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
										arcanaInfoPanel = (ArcanaInfoPanel)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
										if ((nint)0 != 0)
										{
											bool flag55 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
											num7 = flag55;
											RectOffset.set_top_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, -35);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											arcanaInfoPanel = (ArcanaInfoPanel)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											if ((nint)0 != 0)
											{
												bool flag56 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
												num8 = flag56;
												RectOffset.set_bottom_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 20);
												object obj19 = component5 + 112;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
												object obj18 = component5 + 104;
												float num9 = 0f;
												goto IL_18e0;
											}
										}
									}
								}
							}
						}
						else
						{
							bool flag57 = (object)component5 == null;
							arcanaInfoPanel = (ArcanaInfoPanel)(object)typeof(UIHelper);
							if (!flag57)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
								arcanaInfoPanel = (ArcanaInfoPanel)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
								if ((nint)0 != 0)
								{
									bool flag58 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
									num5 = flag58;
									RectOffset.set_left_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 38);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
									arcanaInfoPanel = (ArcanaInfoPanel)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
									if ((nint)0 != 0)
									{
										bool flag59 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
										num6 = flag59;
										RectOffset.set_right_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 0);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
										arcanaInfoPanel = (ArcanaInfoPanel)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
										if ((nint)0 != 0)
										{
											bool flag60 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
											num7 = flag60;
											RectOffset.set_top_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, -35);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											arcanaInfoPanel = (ArcanaInfoPanel)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
											if ((nint)0 != 0)
											{
												bool flag61 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
												num8 = flag61;
												RectOffset.set_bottom_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 20);
												object obj20 = component5 + 104;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
												object obj18 = component5 + 112;
												float num9 = 0f;
												obj21 = obj22;
												goto IL_1874;
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
		goto IL_10b8;
		IL_0d0f:
		layoutElement.ignoreLayout = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
		arcanaInfoPanel = (ArcanaInfoPanel)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
		if ((nint)0 != 0)
		{
			bool flag62 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
			RectOffset.set_top_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr, 95);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
			arcanaInfoPanel = (ArcanaInfoPanel)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
			if ((nint)0 != 0)
			{
				bool flag63 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
				object obj23 = RectOffset.get_top_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
				arcanaInfoPanel = (ArcanaInfoPanel)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2662 @ rax_v200 (UnityEngine.UI.GridLayoutGroup)+20]");
				if ((nint)0 != 0)
				{
					bool flag64 = ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr == (IntPtr)0;
					object obj24 = RectOffset.get_bottom_Injected(((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr);
					arcanaInfoPanel = (ArcanaInfoPanel)(object)_gameManager;
					if ((object)_gameManager != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+118]");
						arcanaInfoPanel = (ArcanaInfoPanel)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+118]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+B0]");
							object[] array2 = (object[])0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v120 (VampireSurvivors.UI.ArcanaInfoPanel)+B0]");
							if ((nint)0 != 0)
							{
								float num9 = (float)array2.Length * 190f;
								object obj18 = component5 + 112;
								goto IL_18e0;
							}
						}
					}
				}
			}
		}
		goto IL_10b8;
		IL_18e0:
		obj21 = obj22;
		goto IL_1874;
	}

	private void OnEnable()
	{
		ArcanaInfoPanel arcanaInfoPanel = _ArcanaInfoPanel;
		if ((object)_ArcanaInfoPanel != null && ((UnityEngine.Object)arcanaInfoPanel).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _ArcanaInfoPanel.gameObject;
			gameObject.SetActive(value: false);
		}
	}

	private unsafe void CardOnBecameSelected(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform)
	{
		//IL_00b3: Expected I, but got O
		//IL_00f0: Expected O, but got Ref
		//IL_029d: Expected O, but got I4
		//IL_01ee: Expected I4, but got I8
		//IL_01a0->IL0261: Incompatible stack heights: 1 vs 0
		//IL_01cc->IL0261: Incompatible stack heights: 1 vs 0
		ReInput.PlayerHelper players = ReInput.players;
		if (players != null)
		{
			Rewired.Player player = players.GetPlayer(0);
			if (player != null && player.controllers != null)
			{
				Mouse mouse = player.controllers.Mouse;
				if (mouse != null)
				{
					nint num = (nint)mouse;
					bool buttonDown = mouse.GetButtonDown(0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					object obj = default(object);
					string message = string.FormatHelper((IFormatProvider)null, "Select from click: {0}", (System.ParamsArray)(&obj));
					Debug.Log(message);
					if ((object)_ArcanaInfoPanel != null)
					{
						GameObject gameObject = _ArcanaInfoPanel.gameObject;
						if ((object)gameObject != null)
						{
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj2 == null || _currentShowingArcana != arcanaType)
							{
								if (buttonDown)
								{
									_ignoreNextArcanaClick = true;
								}
								Transform cardTransform2 = default(Transform);
								ShowArcanaInfoPanel(arcanaData, arcanaType, cardTransform2);
								return;
							}
							if (buttonDown)
							{
								if (!_ignoreNextArcanaClick)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697E590");
								}
								goto IL_0224;
							}
							if ((object)_ArcanaInfoPanel != null)
							{
								GameObject gameObject2 = _ArcanaInfoPanel.gameObject;
								if ((object)gameObject2 != null)
								{
									gameObject2.SetActive(value: false);
									_currentShowingArcana = ArcanaType.VOID;
									goto IL_0224;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0224:
		_ignoreNextArcanaClick = false;
	}

	private void CardOnBecameDeselected(ArcanaType arcanaType)
	{
		//IL_0031: Expected I4, but got I8
		GameObject gameObject = _ArcanaInfoPanel.gameObject;
		gameObject.SetActive(value: false);
		_currentShowingArcana = ArcanaType.VOID;
	}

	public void ToggleArcanaInfoPanel(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform, bool toggleFromClick, bool toggleFromSelectionChange)
	{
		//IL_01b5: Expected O, but got I4
		//IL_00fe: Expected I4, but got I8
		//IL_00b0->IL017e: Incompatible stack heights: 1 vs 0
		//IL_00dc->IL017e: Incompatible stack heights: 1 vs 0
		if ((object)_ArcanaInfoPanel != null)
		{
			GameObject gameObject = _ArcanaInfoPanel.gameObject;
			if ((object)gameObject != null)
			{
				bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
				object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
				object obj4 = default(object);
				if (obj == null || _currentShowingArcana != arcanaType)
				{
					object obj3 = default(object);
					object obj2 = obj3 & obj4;
					if (obj2 != null)
					{
						_ignoreNextArcanaClick = true;
					}
					Transform cardTransform2 = default(Transform);
					ShowArcanaInfoPanel(arcanaData, arcanaType, cardTransform2);
					return;
				}
				if (obj4 != null)
				{
					if (!_ignoreNextArcanaClick)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697E590");
					}
					goto IL_0134;
				}
				if ((object)_ArcanaInfoPanel != null)
				{
					GameObject gameObject2 = _ArcanaInfoPanel.gameObject;
					if ((object)gameObject2 != null)
					{
						gameObject2.SetActive(value: false);
						_currentShowingArcana = ArcanaType.VOID;
						goto IL_0134;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0134:
		_ignoreNextArcanaClick = false;
	}

	public unsafe void ShowArcanaInfoPanel(ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform)
	{
		//IL_033c: Expected O, but got Ref
		//IL_0243->IL01d2: Incompatible stack heights: 1 vs 0
		//IL_034f->IL01fa: Incompatible stack heights: 9 vs 0
		if (_currentShowingArcana != arcanaType)
		{
			goto IL_006b;
		}
		if ((object)_ArcanaInfoPanel != null)
		{
			GameObject gameObject = _ArcanaInfoPanel.gameObject;
			if ((object)gameObject != null)
			{
				if (!gameObject.activeSelf)
				{
					goto IL_006b;
				}
				return;
			}
		}
		goto IL_01d2;
		IL_01d2:
		throw new NullReferenceException();
		IL_006b:
		if ((object)_ArcanaInfoPanel != null)
		{
			GameObject gameObject2 = _ArcanaInfoPanel.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: true);
				if ((object)_ArcanaInfoPanel != null)
				{
					_ArcanaInfoPanel.SetInfo(arcanaData, arcanaType);
					if ((object)_ArcanaInfoPanel != null)
					{
						Transform transform = _ArcanaInfoPanel.transform;
						if ((object)transform != null)
						{
							bool flag = ((ArcanaData)(object)transform)._003CarcanaType_003Ek__BackingField == 0;
							Transform.get_position_Injected((IntPtr)((ArcanaData)(object)transform)._003CarcanaType_003Ek__BackingField, out Vector3 _);
							if ((object)cardTransform != null)
							{
								bool flag2 = ((UnityEngine.Object)cardTransform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)cardTransform).m_CachedPtr, out Vector3 ret2);
								bool flag3 = (object)_ArcanaInfoPanel == null;
								Transform transform2 = _ArcanaInfoPanel.transform;
								bool flag4 = (object)transform2 == null;
								bool flag5 = ((ArcanaData)(object)transform2)._003CarcanaType_003Ek__BackingField == 0;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected((IntPtr)((ArcanaData)(object)transform2)._003CarcanaType_003Ek__BackingField, ref value);
								bool flag6 = (object)_ArcanaInfoPanel == null;
								Transform transform3 = _ArcanaInfoPanel.transform;
								bool flag7 = (object)transform3 == null;
								bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
								bool flag9 = (object)_ArcanaInfoPanel == null;
								Transform target = _ArcanaInfoPanel.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&ret2), _ArcanaInfoScaleInDuration);
								_currentShowingArcana = arcanaType;
								return;
							}
						}
					}
				}
			}
		}
		goto IL_01d2;
	}

	public void HideArcanaInfoPanel()
	{
		//IL_0031: Expected I4, but got I8
		GameObject gameObject = _ArcanaInfoPanel.gameObject;
		gameObject.SetActive(value: false);
		_currentShowingArcana = ArcanaType.VOID;
	}

	public unsafe void ConfigureNavigationForArcanaCards(Selectable down = null, Selectable left = null, Selectable right = null, Selectable up = null)
	{
		//IL_0076: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_0156: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_0170: Expected O, but got Ref
		//IL_0170: Expected O, but got I
		//IL_0179: Expected O, but got I4
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0263: Expected O, but got I
		//IL_0273: Expected O, but got I
		//IL_02b2: Expected O, but got I
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Expected O, but got Unknown
		List<ArcanaCardUI> spawnedCards = _spawnedCards;
		if (spawnedCards._size > 0)
		{
			ArcanaCardUI[] items = spawnedCards._items;
			Selectable component = items[0].GetComponent<Selectable>();
			List<ArcanaCardUI> spawnedCards2 = _spawnedCards;
			Selectable selectable = left;
			Selectable target = component;
			object obj = 0;
			object obj2 = 0;
			object obj3 = default(object);
			Selectable selectable3 = default(Selectable);
			Component component3 = default(Component);
			Component component5 = default(Component);
			while (true)
			{
				if ((nint)obj2 < spawnedCards2._size)
				{
					List<ArcanaCardUI> spawnedCards3 = _spawnedCards;
					if ((nint)obj >= spawnedCards3._size)
					{
						break;
					}
					ArcanaCardUI[] items2 = spawnedCards3._items;
					ArcanaCardUI arcanaCardUI = items2[obj];
					Selectable cachedSelectable = arcanaCardUI._cachedSelectable;
					if (cachedSelectable.m_Interactable)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v59+168]");
						Selectable selectable2 = (Selectable)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v59+168]");
						((Selectable)0).navigation = (Navigation)(&obj3);
						obj3 = 4;
						selectable = null;
					}
					List<ArcanaCardUI> spawnedCards4 = _spawnedCards;
					object obj4 = obj + 1;
					Selectable target2;
					if ((nint)obj4 >= spawnedCards4._size)
					{
						target2 = down;
					}
					else
					{
						object obj5 = obj + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v56+168]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v57+D8]");
						if ((nint)0 == 0)
						{
							target2 = down;
						}
						else
						{
							object obj7 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v58+168]");
							target2 = (Selectable)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v58+168]");
							target = (Selectable)0;
						}
					}
					object obj8 = obj - 1;
					Selectable target3;
					if ((nint)obj8 <= -1)
					{
						target3 = selectable3;
					}
					else
					{
						object obj9 = obj - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v52+168]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v53+D8]");
						bool flag = (nint)0 == 0;
						target3 = null;
						if (!flag)
						{
							object obj11 = obj - 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Selectable component2 = component3.GetComponent<Selectable>();
							target3 = component2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Selectable component4 = component5.GetComponent<Selectable>();
					VampireSurvivors.App.Tools.Extensions.SetNavigationUp(component4, target3);
					VampireSurvivors.App.Tools.Extensions.SetNavigationDown(component4, target2);
					VampireSurvivors.App.Tools.Extensions.SetNavigationLeft(component4, left);
					VampireSurvivors.App.Tools.Extensions.SetNavigationRight(component4, right);
					spawnedCards2 = _spawnedCards;
					obj++;
					selectable = null;
					obj2 = obj;
					continue;
				}
				if ((object)down != null && ((UnityEngine.Object)down).m_CachedPtr != (IntPtr)0)
				{
					VampireSurvivors.App.Tools.Extensions.SetNavigationUp(down, target);
				}
				if ((object)left != null && ((UnityEngine.Object)left).m_CachedPtr != (IntPtr)0)
				{
					List<ArcanaCardUI> spawnedCards5 = _spawnedCards;
					if (spawnedCards5._size <= 0)
					{
						break;
					}
					ArcanaCardUI[] items3 = spawnedCards5._items;
					Selectable component6 = items3[0].GetComponent<Selectable>();
					VampireSurvivors.App.Tools.Extensions.SetNavigationRight(left, component6);
				}
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public ArcanaDisplayContainer()
	{
		List<ArcanaCardUI> spawnedCards = new List<ArcanaCardUI>();
		_spawnedCards = spawnedCards;
		List<Tween> spawnedCardTimers = new List<Tween>();
		_spawnedCardTimers = spawnedCardTimers;
	}
}
