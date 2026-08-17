using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

public class SurvarotsDisplayContainer : MonoBehaviour, IArcanaDisplayContainer
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public ArcanaCardUI card;

		internal void _003CSetCardDetails_003Eb__0()
		{
			Tween tween = card.Reveal();
		}
	}

	private ArcanaCardUI _ArcanaCardPrefab;

	private RectTransform _ArcanaCardContainer;

	private CardInfoUI _cardInfoPanel;

	private float _ArcanaInfoScaleInDuration = 0.1f;

	private float _ArcanaPortraitInfoPanelOffset = 210f;

	private DataManager _dataManager;

	private GameManager _gameManager;

	private List<ArcanaCardUI> _spawnedCards;

	private List<Tween> _spawnedCardTimers;

	private CharacterSkillCard_Base _currentShowingCard;

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
		GameObject gameObject = _cardInfoPanel.gameObject;
		gameObject.SetActive(value: false);
	}

	public void SetCardDetails()
	{
		//IL_02b9: Expected I, but got O
		//IL_1468: Unknown result type (might be due to invalid IL or missing references)
		//IL_146d: Expected O, but got Unknown
		//IL_034c: Expected O, but got I
		//IL_14da: Unknown result type (might be due to invalid IL or missing references)
		//IL_14df: Expected O, but got Unknown
		//IL_19d7: Expected I4, but got I8
		//IL_18cd: Expected I4, but got I8
		//IL_1a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a87: Expected O, but got Unknown
		//IL_1565: Unknown result type (might be due to invalid IL or missing references)
		//IL_156a: Expected O, but got Unknown
		//IL_17c3: Expected I4, but got I8
		//IL_1ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aeb: Expected O, but got Unknown
		//IL_07c5: Expected O, but got I
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d3: Expected O, but got Unknown
		//IL_0847: Expected O, but got I
		//IL_1b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b08: Expected O, but got Unknown
		//IL_1b11: Expected F4, but got I4
		//IL_1ac9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ace: Expected O, but got Unknown
		//IL_1415: Expected O, but got I4
		//IL_1920: Unknown result type (might be due to invalid IL or missing references)
		//IL_1925: Expected O, but got Unknown
		//IL_192e: Expected F4, but got I4
		//IL_1aac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab1: Expected O, but got Unknown
		//IL_0825: Expected O, but got I8
		//IL_1816: Unknown result type (might be due to invalid IL or missing references)
		//IL_181b: Expected O, but got Unknown
		//IL_1824: Expected F4, but got I4
		//IL_095d: Expected O, but got I
		//IL_0965: Expected I, but got O
		//IL_096d: Expected O, but got F4
		//IL_090f: Expected O, but got I
		//IL_0917: Expected I, but got O
		//IL_091f: Expected O, but got F4
		//IL_169f: Expected O, but got I4
		//IL_16df: Expected O, but got I4
		//IL_170d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1712: Expected O, but got Unknown
		//IL_00a2->IL1351: Incompatible stack heights: 1 vs 0
		//IL_14f7->IL1a74: Incompatible stack heights: 1 vs 0
		//IL_14fc->IL0ad8: Incompatible stack heights: 1 vs 0
		//IL_1973->IL12d7: Incompatible stack heights: 1 vs 0
		//IL_06fe->IL1402: Incompatible stack heights: 15 vs 13
		//IL_1869->IL12d7: Incompatible stack heights: 1 vs 0
		//IL_19b8->IL12d7: Incompatible stack heights: 2 vs 0
		//IL_175f->IL12d7: Incompatible stack heights: 1 vs 0
		//IL_153c->IL12d7: Incompatible stack heights: 1 vs 0
		//IL_18ae->IL12d7: Incompatible stack heights: 2 vs 0
		//IL_0756->IL1407: Incompatible stack heights: 16 vs 14
		//IL_1a01->IL12d7: Incompatible stack heights: 3 vs 0
		//IL_17a4->IL12d7: Incompatible stack heights: 2 vs 0
		//IL_18f7->IL12d7: Incompatible stack heights: 3 vs 0
		//IL_17ed->IL12d7: Incompatible stack heights: 3 vs 0
		//IL_15c8->IL12d7: Incompatible stack heights: 3 vs 0
		//IL_1a35->IL11b8: Incompatible stack heights: 4 vs 0
		//IL_0d99->IL12d7: Incompatible stack heights: 3 vs 0
		//IL_1622->IL12d7: Incompatible stack heights: 4 vs 0
		//IL_0973->IL1439: Incompatible stack heights: 19 vs 0
		//IL_0925->IL1439: Incompatible stack heights: 19 vs 0
		//IL_0e18->IL12d7: Incompatible stack heights: 4 vs 0
		//IL_0e47->IL12d7: Incompatible stack heights: 4 vs 0
		//IL_0e71->IL12d7: Incompatible stack heights: 4 vs 0
		//IL_0ea3->IL12d7: Incompatible stack heights: 4 vs 0
		//IL_171f->IL1a96: Incompatible stack heights: 15 vs 4
		GameObject gameObject = base.gameObject;
		object[] array2;
		if ((object)gameObject != null)
		{
			gameObject.SetActive(value: true);
			DataManager dataManager = _dataManager;
			if (_dataManager != null && _spawnedCards != null)
			{
				List<ArcanaCardUI>.Enumerator enumerator = default(List<ArcanaCardUI>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rbx_v93 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rbx_v93 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj2, 0f);
				}
				List<ArcanaCardUI> spawnedCards = _spawnedCards;
				if (_spawnedCards != null)
				{
					int version = spawnedCards._version + 1;
					spawnedCards._version = version;
					spawnedCards._size = 0;
					if (spawnedCards._size > 0)
					{
						Array.Clear(spawnedCards._items, 0, spawnedCards._size);
					}
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = core._003CPausingPlayer_003Ek__BackingField;
						if ((object)core._003CPausingPlayer_003Ek__BackingField != null)
						{
							CharacterSkillCardsManager characterSkillCardsManager = characterController.CharacterSkillCardsManager;
							if (characterController.CharacterSkillCardsManager != null)
							{
								List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
								if (characterSkillCardsManager._characterCards != null)
								{
									if (characterCards._size != 0)
									{
										Sequence sequence = DOTween.Sequence();
										GameManager core2 = GM.Core;
										if ((object)GM.Core != null)
										{
											VampireSurvivors.Objects.Characters.CharacterController characterController2 = core2._003CPausingPlayer_003Ek__BackingField;
											if ((object)core2._003CPausingPlayer_003Ek__BackingField != null)
											{
												CharacterSkillCardsManager characterSkillCardsManager2 = characterController2.CharacterSkillCardsManager;
												if (characterController2.CharacterSkillCardsManager != null)
												{
													object[] array = (object[])(object)characterSkillCardsManager2._characterCards;
													if (characterSkillCardsManager2._characterCards != null)
													{
														nint num = unchecked((nint)null);
														Transform transform = null;
														List<CharacterSkillCard_Base>.Enumerator enumerator3 = default(List<CharacterSkillCard_Base>.Enumerator);
														List<CharacterSkillCard_Base>.Enumerator enumerator2 = enumerator3;
														List<CharacterSkillCard_Base>.Enumerator enumerator4 = default(List<CharacterSkillCard_Base>.Enumerator);
														bool isInteractable = default(bool);
														Action<SelectableUI, ArcanaData, ArcanaType, Transform> action = default(Action<SelectableUI, ArcanaData, ArcanaType, Transform>);
														object obj6 = default(object);
														Action<ArcanaType> action2 = default(Action<ArcanaType>);
														object obj8 = default(object);
														while (enumerator4.MoveNext())
														{
															CharacterSkillCard_Base characterSkillCard_Base = null;
															_003C_003Ec__DisplayClass15_0 obj3 = new _003C_003Ec__DisplayClass15_0();
															bool flag2 = dataManager._003CAllArcanas_003Ek__BackingField == null;
															object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)characterSkillCard_Base.Type);
															bool flag3 = obj4 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3072 @ rax_v370 (System.Object)+40]");
															Sprite sprite = SpriteManager.GetSprite((string)0, "randomazzo");
															ArcanaCardUI card = UnityEngine.Object.Instantiate(_ArcanaCardPrefab, _ArcanaCardContainer);
															bool flag4 = obj3 == null;
															obj3.card = card;
															bool flag5 = (object)obj3.card == null;
															obj3.card.OverrideBackFrameName("sv_back");
															bool flag6 = (object)obj3.card == null;
															obj3.card.SetCharacterCard(null);
															bool flag7 = (object)obj3.card == null;
															obj3.card.SetData((ArcanaData)obj4, characterSkillCard_Base.Type, isOpen: false, isInteractable);
															bool flag8 = (object)obj3.card == null;
															Selectable component = obj3.card.GetComponent<Selectable>();
															bool flag9 = (object)component == null;
															component.interactable = true;
															ArcanaCardUI card2 = obj3.card;
															bool flag10 = (object)obj3.card == null;
															card2._displayContainer = this;
															bool flag11 = (object)obj3.card == null;
															Button component2 = obj3.card.GetComponent<Button>();
															bool flag12 = (object)component2 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2340 @ rax_v382 (UnityEngine.UI.Button)+10]");
															bool flag13 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2340 @ rax_v382 (UnityEngine.UI.Button)+10]");
															Behaviour.set_enabled_Injected((IntPtr)0, true);
															ArcanaCardUI card3 = obj3.card;
															bool flag14 = (object)obj3.card == null;
															Delegate obj5 = Delegate.Combine(b: new Action<object, object, System.Int32Enum, object>(CardOnBecameSelected), a: card3.OnArcanaCardSelected);
															if ((object)obj5 == null)
															{
																card3.OnArcanaCardSelected = null;
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																bool flag15 = action == null;
																card3.OnArcanaCardSelected = action;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																bool flag16 = obj6 == null;
															}
															ArcanaCardUI card4 = obj3.card;
															bool flag17 = (object)obj3.card == null;
															Delegate obj7 = Delegate.Combine(b: new Action<ArcanaType>(CardOnBecameDeselected), a: card4.OnArcanaCardDeselected);
															if ((object)obj7 == null)
															{
																card4.OnArcanaCardDeselected = null;
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																bool flag18 = action2 == null;
																card4.OnArcanaCardDeselected = action2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																bool flag19 = obj8 == null;
															}
															List<object> spawnedCards2 = (List<object>)(object)_spawnedCards;
															bool flag20 = _spawnedCards == null;
															int version2 = spawnedCards2._version + 1;
															spawnedCards2._version = version2;
															object[] items = spawnedCards2._items;
															bool flag21 = spawnedCards2._items == null;
															if (spawnedCards2._size >= items.Length)
															{
																((List<object>)(object)_spawnedCards).AddWithResize((object)obj3.card);
															}
															else
															{
																int size = spawnedCards2._size + 1;
																spawnedCards2._size = size;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															TweenCallback callback = null;
															nint num2 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7253 @ r9_v90 (Il2CppMethodInfo)+8]");
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7253 @ r9_v90 (Il2CppMethodInfo)+4C]");
															object obj9 = (nint)0 >> 4;
															object obj10 = obj9 & 1;
															object obj11;
															if (obj10 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7253 @ r9_v90 (Il2CppMethodInfo)+52]");
																if ((nint)0 == 0)
																{
																	obj11 = 6447293664L;
																	goto IL_140c;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7241 @ rax_v398 (DG.Tweening.TweenCallback)+20]");
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7241 @ rax_v398 (DG.Tweening.TweenCallback)+10]");
															obj11 = 0;
															goto IL_140c;
															IL_140c:
															object obj12 = 24;
															_ = 6447293568L;
															float num3 = (float)num * 50f;
															float num4 = num3 * 0.001f;
															Tween tween = DOVirtual.DelayedCall(num4, callback);
															bool flag22 = tween == null;
															tween.stringId = "UI_CUSTOM_TIMER";
															List<object> spawnedCardTimers = (List<object>)(object)_spawnedCardTimers;
															bool flag23 = _spawnedCardTimers == null;
															int version3 = spawnedCardTimers._version + 1;
															spawnedCardTimers._version = version3;
															array = spawnedCardTimers._items;
															bool flag24 = spawnedCardTimers._items == null;
															if (spawnedCardTimers._size >= array.Length)
															{
																((List<object>)(object)_spawnedCardTimers).AddWithResize((object)tween);
																transform = (Transform)(num + 1);
																num = (nint)transform;
																enumerator2 = (List<CharacterSkillCard_Base>.Enumerator)num4;
															}
															else
															{
																int size2 = spawnedCardTimers._size + 1;
																spawnedCardTimers._size = size2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																transform = (Transform)(num + 1);
																num = (nint)transform;
																enumerator2 = (List<CharacterSkillCard_Base>.Enumerator)num4;
															}
														}
														object obj13 = 3 - transform;
														bool flag25 = (nint)obj13 <= 0;
														array2 = array;
														Transform transform2 = null;
														if (flag25)
														{
															goto IL_0ad8;
														}
														while (true)
														{
															ArcanaCardUI arcanaCardUI = UnityEngine.Object.Instantiate(_ArcanaCardPrefab, _ArcanaCardContainer);
															if ((object)arcanaCardUI == null)
															{
																break;
															}
															arcanaCardUI.SetGreyBackOnly();
															List<object> spawnedCards3 = (List<object>)(object)_spawnedCards;
															if (_spawnedCards == null)
															{
																break;
															}
															int version4 = spawnedCards3._version + 1;
															spawnedCards3._version = version4;
															array2 = spawnedCards3._items;
															if (spawnedCards3._items == null)
															{
																break;
															}
															if (spawnedCards3._size >= array2.Length)
															{
																((List<object>)(object)_spawnedCards).AddWithResize((object)arcanaCardUI);
															}
															else
															{
																int size3 = spawnedCards3._size + 1;
																spawnedCards3._size = size3;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															Selectable component3 = arcanaCardUI.GetComponent<Selectable>();
															if ((object)component3 == null)
															{
																break;
															}
															component3.interactable = false;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rax_v200 (VampireSurvivors.UI.ArcanaCardUI)+10]");
															bool flag26 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rax_v200 (VampireSurvivors.UI.ArcanaCardUI)+10]");
															Behaviour.set_enabled_Injected((IntPtr)0, false);
															transform2 = (Transform)(transform2 + 1);
															if (System.Runtime.CompilerServices.Unsafe.As<Transform, UIntPtr>(ref transform2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13))
															{
																goto IL_0ad8;
															}
														}
													}
												}
											}
										}
									}
									else
									{
										GameObject gameObject2 = base.gameObject;
										if ((object)gameObject2 != null)
										{
											gameObject2.SetActive(value: false);
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
		goto IL_12d7;
		IL_12d7:
		throw new NullReferenceException();
		IL_0ea8:
		LayoutElement layoutElement;
		layoutElement.ignoreLayout = true;
		GridLayoutGroup component4;
		object padding = ((LayoutGroup)component4).m_Padding;
		bool flag27 = ((LayoutGroup)component4).m_Padding == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6792 @ rcx_v259 (System.Object)+10]");
		bool flag28 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6792 @ rcx_v259 (System.Object)+10]");
		RectOffset.set_top_Injected((IntPtr)0, 95);
		object padding2 = ((LayoutGroup)component4).m_Padding;
		bool flag29 = ((LayoutGroup)component4).m_Padding == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6639 @ rcx_v262 (System.Object)+10]");
		bool flag30 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6639 @ rcx_v262 (System.Object)+10]");
		object obj14 = RectOffset.get_top_Injected((IntPtr)0);
		object padding3 = ((LayoutGroup)component4).m_Padding;
		bool flag31 = ((LayoutGroup)component4).m_Padding == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6560 @ rcx_v265 (System.Object)+10]");
		bool flag32 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6560 @ rcx_v265 (System.Object)+10]");
		object[] array3 = (object[])RectOffset.get_bottom_Injected((IntPtr)0);
		GameManager gameManager = _gameManager;
		bool flag33 = (object)_gameManager == null;
		GameSessionData gameSessionData = gameManager._gameSessionData;
		bool flag34 = gameManager._gameSessionData == null;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		bool flag35 = (object)gameSessionData._activeCharacter == null;
		CharacterSkillCardsManager characterSkillCardsManager3 = activeCharacter.CharacterSkillCardsManager;
		bool flag36 = activeCharacter.CharacterSkillCardsManager == null;
		List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager3._characterCards;
		bool flag37 = characterSkillCardsManager3._characterCards == null;
		float num5 = (float)characterCards2._size * 190f;
		object obj15 = component4 + 112;
		array2 = array3;
		goto IL_1a96;
		IL_0ad8:
		object obj22 = default(object);
		object obj21;
		if ((object)_ArcanaCardContainer != null)
		{
			component4 = _ArcanaCardContainer.GetComponent<GridLayoutGroup>();
			GameManager gameManager2 = _gameManager;
			if ((object)_gameManager != null)
			{
				GameSessionData gameSessionData2 = gameManager2._gameSessionData;
				if (gameManager2._gameSessionData != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = gameSessionData2._activeCharacter;
					if ((object)gameSessionData2._activeCharacter != null)
					{
						CharacterSkillCardsManager characterSkillCardsManager4 = activeCharacter2.CharacterSkillCardsManager;
						if (activeCharacter2.CharacterSkillCardsManager != null)
						{
							List<CharacterSkillCard_Base> characterCards3 = characterSkillCardsManager4._characterCards;
							if (characterSkillCardsManager4._characterCards != null)
							{
								bool num6;
								bool num7;
								bool num8;
								bool num9;
								if (characterCards3._size >= 4)
								{
									GameManager gameManager3 = _gameManager;
									GameSessionData gameSessionData3 = gameManager3._gameSessionData;
									VampireSurvivors.Objects.Characters.CharacterController activeCharacter3 = gameSessionData3._activeCharacter;
									CharacterSkillCardsManager characterSkillCardsManager5 = activeCharacter3.CharacterSkillCardsManager;
									List<CharacterSkillCard_Base> characterCards4 = characterSkillCardsManager5._characterCards;
									if (characterCards4._size != 4)
									{
										GameManager gameManager4 = _gameManager;
										GameSessionData gameSessionData4 = gameManager4._gameSessionData;
										VampireSurvivors.Objects.Characters.CharacterController activeCharacter4 = gameSessionData4._activeCharacter;
										CharacterSkillCardsManager characterSkillCardsManager6 = activeCharacter4.CharacterSkillCardsManager;
										List<CharacterSkillCard_Base> characterCards5 = characterSkillCardsManager6._characterCards;
										if ((object)component4 != null)
										{
											object padding4 = ((LayoutGroup)component4).m_Padding;
											if (characterCards5._size != 5)
											{
												if (((LayoutGroup)component4).m_Padding != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v213 (System.Object)+10]");
													bool flag38 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v213 (System.Object)+10]");
													RectOffset.set_left_Injected((IntPtr)0, 38);
													object padding5 = ((LayoutGroup)component4).m_Padding;
													if (((LayoutGroup)component4).m_Padding != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v236 (System.Object)+10]");
														bool flag39 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rcx_v236 (System.Object)+10]");
														RectOffset.set_right_Injected((IntPtr)0, 0);
														object obj16 = component4 + 104;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
														object obj17 = component4 + 112;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
														bool flag40 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
														IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
														Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
														if ((object)transform3 != null)
														{
															Transform child = transform3.GetChild(0);
															if ((object)child != null)
															{
																bool flag41 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
																IntPtr gcHandlePtr3 = Component.get_gameObject_Injected(((UnityEngine.Object)child).m_CachedPtr);
																GameObject gameObject3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr3);
																if ((object)gameObject3 != null)
																{
																	LayoutElement component5 = gameObject3.GetComponent<LayoutElement>();
																	if ((object)component5 != null)
																	{
																		bool flag42 = ((UnityEngine.Object)component5).m_CachedPtr != (IntPtr)0;
																		layoutElement = component5;
																		if (flag42)
																		{
																			goto IL_0ea8;
																		}
																	}
																	Transform transform4 = base.transform;
																	if ((object)transform4 != null)
																	{
																		Transform child2 = transform4.GetChild(0);
																		if ((object)child2 != null)
																		{
																			GameObject gameObject4 = child2.gameObject;
																			if ((object)gameObject4 != null)
																			{
																				LayoutElement layoutElement2 = gameObject4.AddComponent<LayoutElement>();
																				bool flag43 = (object)layoutElement2 == null;
																				layoutElement = layoutElement2;
																				if (!flag43)
																				{
																					goto IL_0ea8;
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
											else if (((LayoutGroup)component4).m_Padding != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v213 (System.Object)+10]");
												bool flag44 = (nint)0 == 0;
												num6 = flag44;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rcx_v213 (System.Object)+10]");
												RectOffset.set_left_Injected((IntPtr)0, 38);
												object padding6 = ((LayoutGroup)component4).m_Padding;
												if (((LayoutGroup)component4).m_Padding != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v216 (System.Object)+10]");
													bool flag45 = (nint)0 == 0;
													num7 = flag45;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v264 @ rcx_v216 (System.Object)+10]");
													RectOffset.set_right_Injected((IntPtr)0, 0);
													object padding7 = ((LayoutGroup)component4).m_Padding;
													if (((LayoutGroup)component4).m_Padding != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v219 (System.Object)+10]");
														bool flag46 = (nint)0 == 0;
														num8 = flag46;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rcx_v219 (System.Object)+10]");
														RectOffset.set_top_Injected((IntPtr)0, -42);
														object padding8 = ((LayoutGroup)component4).m_Padding;
														if (((LayoutGroup)component4).m_Padding != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v222 (System.Object)+10]");
															bool flag47 = (nint)0 == 0;
															num9 = flag47;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v222 (System.Object)+10]");
															RectOffset.set_bottom_Injected((IntPtr)0, 20);
															object obj18 = component4 + 104;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
															obj15 = component4 + 112;
															num5 = 0f;
															goto IL_1a96;
														}
													}
												}
											}
										}
									}
									else if ((object)component4 != null)
									{
										object padding9 = ((LayoutGroup)component4).m_Padding;
										if (((LayoutGroup)component4).m_Padding != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rcx_v190 (System.Object)+10]");
											bool flag48 = (nint)0 == 0;
											num6 = flag48;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rcx_v190 (System.Object)+10]");
											RectOffset.set_left_Injected((IntPtr)0, 38);
											object padding10 = ((LayoutGroup)component4).m_Padding;
											if (((LayoutGroup)component4).m_Padding != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v193 (System.Object)+10]");
												bool flag49 = (nint)0 == 0;
												num7 = flag49;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v193 (System.Object)+10]");
												RectOffset.set_right_Injected((IntPtr)0, 0);
												object padding11 = ((LayoutGroup)component4).m_Padding;
												if (((LayoutGroup)component4).m_Padding != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v196 (System.Object)+10]");
													bool flag50 = (nint)0 == 0;
													num8 = flag50;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v196 (System.Object)+10]");
													RectOffset.set_top_Injected((IntPtr)0, -35);
													object padding12 = ((LayoutGroup)component4).m_Padding;
													if (((LayoutGroup)component4).m_Padding != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v199 (System.Object)+10]");
														bool flag51 = (nint)0 == 0;
														num9 = flag51;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v199 (System.Object)+10]");
														RectOffset.set_bottom_Injected((IntPtr)0, 20);
														object obj19 = component4 + 112;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
														obj15 = component4 + 104;
														num5 = 0f;
														goto IL_1a96;
													}
												}
											}
										}
									}
								}
								else if ((object)component4 != null)
								{
									object padding13 = ((LayoutGroup)component4).m_Padding;
									if (((LayoutGroup)component4).m_Padding != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v163 (System.Object)+10]");
										bool flag52 = (nint)0 == 0;
										num6 = flag52;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rcx_v163 (System.Object)+10]");
										RectOffset.set_left_Injected((IntPtr)0, 38);
										object padding14 = ((LayoutGroup)component4).m_Padding;
										if (((LayoutGroup)component4).m_Padding != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v166 (System.Object)+10]");
											bool flag53 = (nint)0 == 0;
											num7 = flag53;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rcx_v166 (System.Object)+10]");
											RectOffset.set_right_Injected((IntPtr)0, 0);
											object padding15 = ((LayoutGroup)component4).m_Padding;
											if (((LayoutGroup)component4).m_Padding != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v169 (System.Object)+10]");
												bool flag54 = (nint)0 == 0;
												num8 = flag54;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v169 (System.Object)+10]");
												RectOffset.set_top_Injected((IntPtr)0, -35);
												object padding16 = ((LayoutGroup)component4).m_Padding;
												if (((LayoutGroup)component4).m_Padding != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rcx_v172 (System.Object)+10]");
													bool flag55 = (nint)0 == 0;
													num9 = flag55;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rcx_v172 (System.Object)+10]");
													RectOffset.set_bottom_Injected((IntPtr)0, 20);
													object obj20 = component4 + 104;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
													obj15 = component4 + 112;
													num5 = 0f;
													obj21 = obj22;
													goto IL_1a26;
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
		goto IL_12d7;
		IL_1a96:
		obj21 = obj22;
		goto IL_1a26;
		IL_1a26:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
	}

	public void ShowSelf()
	{
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController characterController = core._003CPausingPlayer_003Ek__BackingField;
		CharacterSkillCardsManager characterSkillCardsManager = characterController.CharacterSkillCardsManager;
		List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
		if (characterCards._size > 0)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
		}
	}

	public void HideSelf()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private unsafe void CardOnBecameSelected(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform)
	{
		//IL_00b3: Expected I, but got O
		//IL_00f0: Expected O, but got Ref
		//IL_029b: Expected I, but got O
		//IL_010f: Expected I, but got O
		//IL_011f: Expected O, but got I
		//IL_0157: Expected O, but got I
		//IL_02e8: Expected O, but got I4
		//IL_031f: Expected O, but got I
		//IL_019a->IL0281: Incompatible stack heights: 2 vs 0
		//IL_01c6->IL0281: Incompatible stack heights: 2 vs 0
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
					nint num2 = (nint)typeof(ArcanaCardUI);
					if ((object)arcanaCardUI != null)
					{
						nint num3 = (nint)arcanaCardUI;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v14 (Il2CppClass<VampireSurvivors.UI.ArcanaCardUI>)+130]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v10 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+130]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rdx_v14 (Il2CppClass<VampireSurvivors.UI.ArcanaCardUI>)+130]");
						bool flag = num4 < 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ r8_v10 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+C8]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v23+FFFFFFF8+v322 @ rax_v22*8]");
						bool flag2 = 0 != (nint)typeof(ArcanaCardUI);
						if ((object)_cardInfoPanel != null)
						{
							GameObject gameObject = _cardInfoPanel.gameObject;
							if ((object)gameObject != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj4 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj4 != null)
								{
									CharacterSkillCard_Base currentShowingCard = _currentShowingCard;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [arcanaCardUI @ rdx (VampireSurvivors.UI.SelectableUI)+110]");
									if (currentShowingCard == null)
									{
										if (!buttonDown || !_ignoreNextArcanaClick)
										{
											HideArcanaInfoPanel();
										}
										_ignoreNextArcanaClick = false;
										return;
									}
								}
								if (buttonDown)
								{
									_ignoreNextArcanaClick = true;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [arcanaCardUI @ rdx (VampireSurvivors.UI.SelectableUI)+110]");
								Transform cardTransform2 = default(Transform);
								ShowArcanaInfoPanel((CharacterSkillCard_Base)0, cardTransform2, arcanaData);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CardOnBecameDeselected(ArcanaType arcanaType)
	{
		HideArcanaInfoPanel();
	}

	public void ToggleArcanaInfoPanel(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform, bool toggleFromClick, bool toggleFromSelectionChange)
	{
		//IL_01a5: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0055: Expected O, but got I
		//IL_01f2: Expected O, but got I4
		//IL_0229: Expected O, but got I
		//IL_0098->IL0190: Incompatible stack heights: 2 vs 0
		//IL_00c4->IL0190: Incompatible stack heights: 2 vs 0
		nint num = (nint)typeof(ArcanaCardUI);
		if ((object)arcanaCardUI != null)
		{
			nint num2 = (nint)arcanaCardUI;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v1 (Il2CppClass<VampireSurvivors.UI.ArcanaCardUI>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rdx_v1 (Il2CppClass<VampireSurvivors.UI.ArcanaCardUI>)+130]");
			bool flag = num3 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v5 (Il2CppClass<VampireSurvivors.UI.SelectableUI>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v12+FFFFFFF8+v50 @ rax_v11*8]");
			bool flag2 = 0 != (nint)typeof(ArcanaCardUI);
			if ((object)_cardInfoPanel != null)
			{
				GameObject gameObject = _cardInfoPanel.gameObject;
				if ((object)gameObject != null)
				{
					bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					object obj4 = default(object);
					if (obj3 != null)
					{
						CharacterSkillCard_Base currentShowingCard = _currentShowingCard;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [arcanaCardUI @ rdx (VampireSurvivors.UI.SelectableUI)+110]");
						if (currentShowingCard == null)
						{
							if (obj4 == null || !_ignoreNextArcanaClick)
							{
								HideArcanaInfoPanel();
							}
							_ignoreNextArcanaClick = false;
							return;
						}
					}
					object obj6 = default(object);
					object obj5 = obj6 & obj4;
					if (obj5 != null)
					{
						_ignoreNextArcanaClick = true;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [arcanaCardUI @ rdx (VampireSurvivors.UI.SelectableUI)+110]");
					Transform cardTransform2 = default(Transform);
					ShowArcanaInfoPanel((CharacterSkillCard_Base)0, cardTransform2, arcanaData);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void ShowArcanaInfoPanel(CharacterSkillCard_Base card, Transform cardTransform, ArcanaData arcanaData)
	{
		//IL_02b5: Expected O, but got Ref
		//IL_01bc->IL014e: Incompatible stack heights: 1 vs 0
		if ((object)_cardInfoPanel != null)
		{
			GameObject gameObject = _cardInfoPanel.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.SetActive(value: true);
				if ((object)_cardInfoPanel != null)
				{
					_cardInfoPanel.SetData(card, arcanaData);
					if ((object)_cardInfoPanel != null)
					{
						Transform transform = _cardInfoPanel.transform;
						if ((object)transform != null)
						{
							bool flag = ((ArcanaData)(object)transform)._003CarcanaType_003Ek__BackingField == 0;
							Transform.get_position_Injected((IntPtr)((ArcanaData)(object)transform)._003CarcanaType_003Ek__BackingField, out Vector3 _);
							if ((object)cardTransform != null)
							{
								bool flag2 = ((UnityEngine.Object)cardTransform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)cardTransform).m_CachedPtr, out Vector3 ret2);
								bool flag3 = (object)_cardInfoPanel == null;
								Transform transform2 = _cardInfoPanel.transform;
								bool flag4 = (object)transform2 == null;
								bool flag5 = ((ArcanaData)(object)transform2)._003CarcanaType_003Ek__BackingField == 0;
								Vector3 value = default(Vector3);
								Transform.set_position_Injected((IntPtr)((ArcanaData)(object)transform2)._003CarcanaType_003Ek__BackingField, ref value);
								bool flag6 = (object)_cardInfoPanel == null;
								Transform transform3 = _cardInfoPanel.transform;
								bool flag7 = (object)transform3 == null;
								bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
								bool flag9 = (object)_cardInfoPanel == null;
								Transform target = _cardInfoPanel.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&ret2), _ArcanaInfoScaleInDuration);
								_currentShowingCard = card;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void HideArcanaInfoPanel()
	{
		GameObject gameObject = _cardInfoPanel.gameObject;
		gameObject.SetActive(value: false);
		_currentShowingCard = null;
	}

	public unsafe void ConfigureNavigationForCharacterCards(Selectable down = null, Selectable left = null, Selectable right = null, Selectable up = null)
	{
		//IL_008c: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00f3: Expected O, but got I4
		//IL_00fc: Expected O, but got I4
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_01d3: Expected O, but got I
		//IL_0279: Expected O, but got I
		//IL_01ed: Expected O, but got Ref
		//IL_01ed: Expected O, but got I
		//IL_01f6: Expected O, but got I4
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_02e0: Expected O, but got I
		//IL_02f0: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		List<ArcanaCardUI> spawnedCards = _spawnedCards;
		int num = spawnedCards._size ^ spawnedCards._size;
		int num2 = spawnedCards._size & num;
		bool flag = num2 < 0;
		bool flag2 = spawnedCards._size < 0;
		bool flag3 = spawnedCards._size == 0;
		if (flag3)
		{
			return;
		}
		bool flag4 = flag2 == flag;
		object obj = !flag4;
		object obj2 = obj | flag3;
		if (obj2 == null)
		{
			ArcanaCardUI[] items = spawnedCards._items;
			Selectable component = items[0].GetComponent<Selectable>();
			List<ArcanaCardUI> spawnedCards2 = _spawnedCards;
			Selectable selectable = left;
			Selectable target = component;
			object obj3 = 0;
			object obj4 = 0;
			object obj5 = default(object);
			Selectable selectable3 = default(Selectable);
			Component component3 = default(Component);
			Component component5 = default(Component);
			while (true)
			{
				if ((nint)obj4 < spawnedCards2._size)
				{
					List<ArcanaCardUI> spawnedCards3 = _spawnedCards;
					if ((nint)obj3 >= spawnedCards3._size)
					{
						break;
					}
					ArcanaCardUI[] items2 = spawnedCards3._items;
					ArcanaCardUI arcanaCardUI = items2[obj3];
					Selectable cachedSelectable = arcanaCardUI._cachedSelectable;
					if (cachedSelectable.m_Interactable)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v60+168]");
						Selectable selectable2 = (Selectable)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v60+168]");
						((Selectable)0).navigation = (Navigation)(&obj5);
						obj5 = 4;
						selectable = null;
					}
					List<ArcanaCardUI> spawnedCards4 = _spawnedCards;
					object obj6 = obj3 + 1;
					Selectable target2;
					if ((nint)obj6 >= spawnedCards4._size)
					{
						target2 = down;
					}
					else
					{
						object obj7 = obj3 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v57+168]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v58+D8]");
						if ((nint)0 == 0)
						{
							target2 = down;
						}
						else
						{
							object obj9 = obj3 + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v59+168]");
							target2 = (Selectable)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v59+168]");
							target = (Selectable)0;
						}
					}
					object obj10 = obj3 - 1;
					Selectable target3;
					if ((nint)obj10 <= -1)
					{
						target3 = selectable3;
					}
					else
					{
						object obj11 = obj3 - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v53+168]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v54+D8]");
						bool flag5 = (nint)0 == 0;
						target3 = null;
						if (!flag5)
						{
							object obj13 = obj3 - 1;
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
					obj3++;
					selectable = null;
					obj4 = obj3;
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

	public SurvarotsDisplayContainer()
	{
		List<ArcanaCardUI> spawnedCards = new List<ArcanaCardUI>();
		_spawnedCards = spawnedCards;
		List<Tween> spawnedCardTimers = new List<Tween>();
		_spawnedCardTimers = spawnedCardTimers;
	}
}
