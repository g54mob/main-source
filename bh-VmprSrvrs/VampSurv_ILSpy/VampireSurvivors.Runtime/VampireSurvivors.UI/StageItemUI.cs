using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class StageItemUI : SelectableUI
{
	private Image _Background;

	private Image _Icon;

	private Localize _NameText;

	private Localize _DescriptionText;

	private Text _StageNumber;

	private Image _Overlay;

	private Image _FrameCorners;

	private GameObject _Exclamation;

	private bool _unlocked;

	private Sequence _specialTween;

	private StageSelectPage _page;

	private StageData _stage;

	private PlayerOptions _playerOptions;

	private readonly string[] _frameNames;

	private StageType _003CType_003Ek__BackingField;

	public StageType Type
	{
		get
		{
			return _003CType_003Ek__BackingField;
		}
		set
		{
			_003CType_003Ek__BackingField = value;
		}
	}

	public TextMeshProUGUI DescriptionText
	{
		get
		{
			Localize descriptionText = _DescriptionText;
			if ((object)_DescriptionText != null && ((UnityEngine.Object)descriptionText).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_DescriptionText == null)
				{
					return (TextMeshProUGUI)(object)new NullReferenceException();
				}
				TextMeshProUGUI component = _DescriptionText.GetComponent<TextMeshProUGUI>();
				if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
				{
					return component;
				}
			}
			return null;
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		_page = null;
		_Icon = null;
		if ((object)_Overlay != null)
		{
			float optionalFloat = default(float);
			object optionalObj = default(object);
			object[] optionalArray = default(object[]);
			int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)_Overlay, false, optionalFloat, optionalObj, optionalArray);
		}
		if (_specialTween != null)
		{
			TweenExtensions.Kill(_specialTween);
		}
		_specialTween = null;
	}

	public void DoHighlight()
	{
		_Background.enabled = true;
	}

	public void DoUnhighlight()
	{
		_Background.enabled = false;
	}

	public unsafe void SetData(PlayerOptions player, StageSelectPage page, StageData stage, Sprite mapSprite, StageType stageType, int index, bool hideDescriptionText)
	{
		//IL_0182: Expected I, but got O
		//IL_182b: Expected O, but got I
		//IL_0565: Expected O, but got I
		//IL_0896: Expected O, but got I
		//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Expected O, but got Unknown
		//IL_0692: Expected O, but got I4
		//IL_0680: Expected O, but got F4
		//IL_093c: Expected O, but got I
		//IL_0641: Expected O, but got I4
		//IL_168b: Expected I, but got O
		//IL_0991: Unknown result type (might be due to invalid IL or missing references)
		//IL_0996: Expected O, but got Unknown
		//IL_0a69: Expected O, but got I4
		//IL_0a57: Expected O, but got F4
		//IL_0a18: Expected O, but got I4
		//IL_0c98: Expected O, but got I4
		//IL_1d45: Expected F4, but got O
		//IL_0c68: Expected O, but got F4
		//IL_0c76: Invalid comparison between F4 and I4
		//IL_0c29: Expected O, but got I4
		//IL_12e4: Expected I, but got O
		//IL_12fa: Expected O, but got I
		//IL_1303: Unknown result type (might be due to invalid IL or missing references)
		//IL_1308: Expected O, but got Unknown
		//IL_137e: Expected I, but got O
		//IL_1adb: Expected O, but got I4
		//IL_1af2: Expected I, but got I8
		//IL_19f6: Expected O, but got I
		//IL_0dde: Expected O, but got I4
		//IL_135a: Expected I, but got I8
		//IL_0dae: Expected O, but got F4
		//IL_0dbc: Invalid comparison between F4 and I4
		//IL_0d79: Expected O, but got I4
		//IL_1a4c: Expected O, but got I
		//IL_0f27: Expected O, but got I4
		//IL_0ef7: Expected O, but got F4
		//IL_0f05: Invalid comparison between F4 and I4
		//IL_150d: Expected I4, but got I8
		//IL_0ec2: Expected O, but got I4
		//IL_1026: Expected O, but got Ref
		//IL_1c66: Expected I, but got O
		//IL_1ce4: Expected I, but got O
		//IL_01f9->IL171a: Incompatible stack heights: 6 vs 3
		//IL_0191->IL16cf: Incompatible stack heights: 6 vs 3
		//IL_039b->IL1735: Incompatible stack heights: 10 vs 8
		//IL_0416->IL175a: Incompatible stack heights: 11 vs 9
		//IL_15e9->IL177f: Incompatible stack heights: 17 vs 15
		//IL_1962->IL1926: Incompatible stack heights: 19 vs 17
		//IL_0cf6->IL10fb: Incompatible stack heights: 20 vs 18
		//IL_0c8b->IL19bc: Incompatible stack heights: 20 vs 19
		//IL_0e3f->IL10fb: Incompatible stack heights: 22 vs 18
		//IL_0dd1->IL19e6: Incompatible stack heights: 22 vs 21
		//IL_0f5e->IL10fb: Incompatible stack heights: 24 vs 18
		//IL_0f85->IL10fb: Incompatible stack heights: 24 vs 18
		//IL_0f1a->IL1a3c: Incompatible stack heights: 24 vs 23
		//IL_10fb->IL10fb: Incompatible stack heights: 27 vs 18
		//IL_1ce9->IL10fb: Incompatible stack heights: 26 vs 18
		_stage = stage;
		_page = page;
		_playerOptions = player;
		StageData stage2 = _stage;
		bool flag = _stage == null;
		_unlocked = stage2._003Cunlocked_003Ek__BackingField;
		object obj = default(object);
		StageType stageType2 = default(StageType);
		StageType stageType3;
		if (obj == null)
		{
			bool flag2 = (object)_DescriptionText == null;
			GameObject gameObject = _DescriptionText.gameObject;
			bool flag3 = (object)gameObject == null;
			gameObject.SetActive(value: true);
			StageData stage3 = _stage;
			bool flag4 = _stage == null;
			if (stage3._003Cunlocked_003Ek__BackingField)
			{
				bool flag5 = stage == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C77]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				string prefix = stage.GetPrefix(stageType2);
				string term = prefix + "description";
				bool flag6 = (object)_DescriptionText == null;
				_DescriptionText.Term = term;
				stageType3 = stageType2;
				goto IL_171a;
			}
			bool flag7 = (object)_DescriptionText == null;
			TextMeshProUGUI component = _DescriptionText.GetComponent<TextMeshProUGUI>();
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("lang/stageSelect_not_discovered", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			bool flag8 = (object)component == null;
			nint num = (nint)component;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1263 @ r8_v98 (Il2CppClass<VampireSurvivors.UI.StageSelectPage>)+558] (should have been resolved before IL gen)");
		}
		else
		{
			bool flag9 = (object)_DescriptionText == null;
			GameObject gameObject2 = _DescriptionText.gameObject;
			bool flag10 = (object)gameObject2 == null;
			gameObject2.SetActive(value: false);
		}
		stageType3 = stageType2;
		goto IL_171a;
		IL_171a:
		bool flag11 = (object)_Icon == null;
		Sprite sprite = default(Sprite);
		_Icon.sprite = sprite;
		bool flag12 = stage == null;
		string localizedName = stage.GetLocalizedName(stageType3);
		bool flag13 = (object)_NameText == null;
		_NameText.Term = localizedName;
		bool flag14 = (object)_NameText == null;
		TextMeshProUGUI component2 = _NameText.GetComponent<TextMeshProUGUI>();
		bool flag15 = (object)component2 == null;
		string text = component2.text;
		if (text == null || text._stringLength <= 0)
		{
			bool flag16 = (object)_NameText == null;
			TextMeshProUGUI component3 = _NameText.GetComponent<TextMeshProUGUI>();
			bool flag17 = (object)component3 == null;
			component3.text = stage._003CstageName_003Ek__BackingField;
		}
		StageData stage4 = _stage;
		bool flag18 = _stage == null;
		if (!stage4._003Cunlocked_003Ek__BackingField)
		{
			bool flag19 = (object)_NameText == null;
			TextMeshProUGUI component4 = _NameText.GetComponent<TextMeshProUGUI>();
			bool flag20 = (object)component4 == null;
			component4.text = "???";
		}
		_003CType_003Ek__BackingField = stageType3;
		bool flag21 = (object)_StageNumber == null;
		_StageNumber.text = stage._003CstageNumber_003Ek__BackingField;
		bool flag22 = (object)_StageNumber == null;
		GameObject gameObject3 = _StageNumber.gameObject;
		StageData stage5 = _stage;
		bool flag23 = _stage == null;
		bool flag24 = (object)gameObject3 == null;
		gameObject3.SetActive(stage5._003Cunlocked_003Ek__BackingField);
		StageData stage6 = _stage;
		bool flag25 = _stage == null;
		bool flag26 = stage6._003Crelics_003Ek__BackingField == null;
		List<ItemType> value = stage6._003Crelics_003Ek__BackingField;
		bool flag27 = false;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj5 = default(object);
		object obj11 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		object obj18 = default(object);
		bool flag37 = default(bool);
		object obj19 = default(object);
		List<ItemType> list;
		while (true)
		{
			object obj8;
			StageSelectPage stageSelectPage2;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78_v18+1C]");
				if (obj3 == null)
				{
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78_v18+18]");
					if ((nint)obj4 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78_v18+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78_v18+10]");
						if ((nint)0 != 0)
						{
							object obj7 = obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rdx_v124+18]");
							if ((nint)obj7 >= 0)
							{
								goto IL_177f;
							}
							obj8 = obj5 + 1;
							StageSelectPage playerOptions = (StageSelectPage)(object)_playerOptions;
							if (_playerOptions == null)
							{
								throw new NullReferenceException();
							}
							if ((object)((BaseUIPage)playerOptions)._inputModule == null)
							{
								if (((BaseUIPage)playerOptions).previouslySelectedItemIndex == 0)
								{
									if (((BaseUIPage)playerOptions).ShouldLog)
									{
										StageSelectPage stageSelectPage = (StageSelectPage)((BaseUIPage)playerOptions).ShouldLog;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3192 @ rax_v327 (VampireSurvivors.UI.StageSelectPage)+2CC]");
										if ((nint)0 != 0)
										{
											stageSelectPage2 = stageSelectPage;
											goto IL_17af;
										}
									}
									stageSelectPage2 = (StageSelectPage)((BaseUIPage)playerOptions)._OffsetWhenSliderShown;
								}
								else
								{
									stageSelectPage2 = (StageSelectPage)((BaseUIPage)playerOptions).previouslySelectedItemIndex;
								}
							}
							else
							{
								stageSelectPage2 = (StageSelectPage)(object)((BaseUIPage)playerOptions)._inputModule;
							}
							goto IL_17af;
						}
						throw new NullReferenceException();
					}
				}
				bool flag28 = obj2 == null;
				GameObject gameObject4 = (GameObject)0;
				if (!flag28)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78_v18+1C]");
					if (obj3 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_-78_v18+18]");
						object obj9 = (nint)0 + (nint)1;
						StageData stage7 = _stage;
						bool flag29 = _stage == null;
						list = stage7._003CyellowRelics_003Ek__BackingField;
						bool flag30 = stage7._003CyellowRelics_003Ek__BackingField == null;
						object obj10 = obj9;
						nint num2 = 0;
						while (true)
						{
							object obj15;
							StageSelectPage stageSelectPage4;
							if (obj11 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_-78_v42+1C]");
								if (obj3 != null)
								{
									break;
								}
								object obj12 = obj10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_-78_v42+18]");
								if ((nint)obj12 >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_-78_v42+10]");
								object obj13 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_-78_v42+10]");
								if ((nint)0 != 0)
								{
									object obj14 = obj10;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2234 @ rdx_v119+18]");
									if ((nint)obj14 < 0)
									{
										obj15 = obj10 + 1;
										StageSelectPage playerOptions2 = (StageSelectPage)(object)_playerOptions;
										if (_playerOptions == null)
										{
											throw new NullReferenceException();
										}
										if ((object)((BaseUIPage)playerOptions2)._inputModule == null)
										{
											if (((BaseUIPage)playerOptions2).previouslySelectedItemIndex == 0)
											{
												if (((BaseUIPage)playerOptions2).ShouldLog)
												{
													StageSelectPage stageSelectPage3 = (StageSelectPage)((BaseUIPage)playerOptions2).ShouldLog;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3854 @ rax_v300 (VampireSurvivors.UI.StageSelectPage)+2CC]");
													if ((nint)0 != 0)
													{
														stageSelectPage4 = stageSelectPage3;
														goto IL_188e;
													}
												}
												stageSelectPage4 = (StageSelectPage)((BaseUIPage)playerOptions2)._OffsetWhenSliderShown;
											}
											else
											{
												stageSelectPage4 = (StageSelectPage)((BaseUIPage)playerOptions2).previouslySelectedItemIndex;
											}
										}
										else
										{
											stageSelectPage4 = (StageSelectPage)(object)((BaseUIPage)playerOptions2)._inputModule;
										}
										goto IL_188e;
									}
									throw new IndexOutOfRangeException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
							IL_188e:
							if ((object)stageSelectPage4 == null)
							{
								throw new NullReferenceException();
							}
							if ((object)stageSelectPage4._RelicPanel != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
								bool flag31 = obj16 != null;
								obj10 = obj15;
								if (!flag31)
								{
									obj10 = obj15;
									flag27 = true;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag32 = obj11 == null;
						num2 = 0;
						if (!flag32)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ stack_-78_v42+1C]");
							if (obj3 == null)
							{
								if (flag27 && _unlocked)
								{
									StageSelectPage exclamation = (StageSelectPage)(object)_Exclamation;
									bool flag33 = (object)_Exclamation == null;
									bool flag34 = ((UnityEngine.Object)exclamation).m_CachedPtr == (IntPtr)0;
									GameObject.SetActive_Injected(((UnityEngine.Object)exclamation).m_CachedPtr, true);
								}
								if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
								{
									break;
								}
								UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(this);
								goto IL_177f;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							num2 = unchecked((nint)null);
						}
						throw new NullReferenceException();
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					gameObject4 = null;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_17af:
			if ((object)stageSelectPage2 == null)
			{
				throw new NullReferenceException();
			}
			if ((object)stageSelectPage2._RelicPanel != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
				bool flag35 = obj17 != null;
				obj5 = obj8;
				if (flag35)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rdx_v124+20+v2489 @ rcx_v225*4]");
				if ((nint)0 != 100)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2193 @ rdx_v124+20+v1917 @ stack_-70_v17*4]");
					bool flag36 = (nint)0 != 400;
					obj5 = obj8;
					if (flag36)
					{
						continue;
					}
					Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
					if (loadedDlc == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A790");
					if (obj18 == null)
					{
						Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
						if (loadedDlc2 == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A790");
						if (!flag37)
						{
							obj5 = obj8;
							flag27 = flag37;
							continue;
						}
					}
					obj5 = obj8;
					flag27 = true;
				}
				else
				{
					Dictionary<DlcType, BundleManifestData> loadedDlc3 = DlcSystem.LoadedDlc;
					if (loadedDlc3 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A790");
					bool flag38 = obj19 == null;
					flag27 = !flag38;
					obj5 = obj8;
				}
				continue;
			}
			throw new NullReferenceException();
			IL_177f:
			throw new IndexOutOfRangeException();
		}
		IntPtr gcHandlePtr = Component.get_gameObject_Injected(((UnityEngine.Object)this).m_CachedPtr);
		GameObject gameObject5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
		bool flag39 = (object)gameObject5 == null;
		((UnityEngine.Object)gameObject5).SetName(stage._003CstageName_003Ek__BackingField);
		StageSelectPage stageSelectPage6;
		object obj20;
		bool flag43;
		object obj21 = default(object);
		Sprite sprite2;
		bool flag44;
		bool flag45;
		bool flag46;
		TweenerCore<Color, Color, ColorOptions> tweenerCore;
		object obj22;
		TweenCallback tweenCallback;
		Sequence specialTween3;
		object message2;
		nint num3;
		object obj23;
		object obj24;
		nint num4;
		Sequence specialTween4;
		Sequence specialTween5;
		StageSelectPage nameText;
		bool flag47;
		IntPtr gcHandlePtr2;
		Transform transform;
		bool flag48;
		Vector3 value2 = default(Vector3);
		StageSelectPage stageNumber;
		bool flag49;
		IntPtr gcHandlePtr3;
		Transform transform2;
		bool flag50;
		RectTransform rectTransform;
		RectTransform rectTransform2;
		bool flag51;
		Vector2 ret;
		bool flag52;
		bool flag53;
		Vector2 value3 = default(Vector2);
		object obj25;
		bool flag54;
		StageSelectPage playerOptions4;
		bool flag55;
		RelicPanel relicPanel;
		bool flag57;
		StageSelectPage playerOptions5;
		bool flag58;
		switch (stageType3)
		{
		case StageType.SINKING:
		{
			if (!Stage.HasValidStageXCharacters())
			{
				break;
			}
			StageSelectPage playerOptions3 = (StageSelectPage)(object)_playerOptions;
			bool flag41 = _playerOptions == null;
			if ((object)((BaseUIPage)playerOptions3)._inputModule == null)
			{
				if (((BaseUIPage)playerOptions3).previouslySelectedItemIndex == 0)
				{
					if (((BaseUIPage)playerOptions3).ShouldLog)
					{
						StageSelectPage stageSelectPage5 = (StageSelectPage)((BaseUIPage)playerOptions3).ShouldLog;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4232 @ rax_v280 (VampireSurvivors.UI.StageSelectPage)+2CC]");
						if ((nint)0 != 0)
						{
							stageSelectPage6 = stageSelectPage5;
							goto IL_1d08;
						}
					}
					stageSelectPage6 = (StageSelectPage)((BaseUIPage)playerOptions3)._OffsetWhenSliderShown;
					bool flag42 = ((BaseUIPage)playerOptions3)._OffsetWhenSliderShown == 0f;
				}
				else
				{
					stageSelectPage6 = (StageSelectPage)((BaseUIPage)playerOptions3).previouslySelectedItemIndex;
				}
			}
			else
			{
				stageSelectPage6 = (StageSelectPage)(object)((BaseUIPage)playerOptions3)._inputModule;
			}
			goto IL_1d08;
		}
		case StageType.STAGEX:
			{
				StageSelectPage overlay = (StageSelectPage)(object)_Overlay;
				bool flag40 = ((UnityEngine.Object)overlay).m_CachedPtr == (IntPtr)0;
				Behaviour.set_enabled_Injected(((UnityEngine.Object)overlay).m_CachedPtr, true);
				Sequence specialTween = DOTween.Sequence();
				_specialTween = specialTween;
				Sequence specialTween2 = _specialTween;
				object message;
				float duration;
				if (_specialTween != null)
				{
					if (((Tween)specialTween2)._003Cactive_003Ek__BackingField)
					{
						if (!((Tween)specialTween2).creationLocked)
						{
							specialTween2.lastTweenInsertTime = ((Tween)specialTween2).duration;
							duration = ((Tween)specialTween2).duration + 0.06f;
							((Tween)specialTween2).duration = duration;
							goto IL_128f;
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
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message = "You can't add elements to a NULL Sequence";
				}
				Debugger.LogWarning(message);
				duration = (float)list;
				goto IL_128f;
			}
			IL_1a3c:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rax_v239 (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+1A0]");
			obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rax_v239 (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+1A0]");
			flag43 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rcx_v190+18]");
			if ((nint)0 == 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			if ((nint)obj21 == -1)
			{
				break;
			}
			sprite2 = SpriteManager.GetSprite("eclipse.png", "UI");
			flag44 = (object)_Overlay == null;
			_Overlay.sprite = sprite2;
			flag45 = (object)_Overlay == null;
			_Overlay.enabled = true;
			flag46 = (object)_Overlay == null;
			_Overlay.color = (Color)(&value);
			tweenerCore = DOTweenModuleUI.DOFade(_Overlay, 1f, 1f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5079 @ rax_v251 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5079 @ rax_v251 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5079 @ rax_v251 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			Debug.Log("Moonglow anim activated");
			break;
			IL_1ad2:
			obj22 = 24;
			((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
			if (_specialTween != null)
			{
				if (((Tween)specialTween3)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)specialTween3).creationLocked)
					{
						Sequence sequence = Sequence.DoInsertCallback(_specialTween, tweenCallback, ((Tween)specialTween3).duration);
						list = null;
						goto IL_148b;
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
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message2);
			goto IL_148b;
			IL_128f:
			specialTween3 = _specialTween;
			tweenCallback = null;
			num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v17 (Il2CppMethodInfo)+8]");
			((Delegate)tweenCallback).method_ptr = (IntPtr)0;
			((Delegate)tweenCallback).method = (nint)__ldftn(StageItemUI._003CSetData_003Eb__23_0);
			((Delegate)tweenCallback).m_target = this;
			((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v17 (Il2CppMethodInfo)+4C]");
			obj23 = (nint)0 >> 4;
			obj24 = obj23 & 1;
			if (obj24 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v17 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num4 = unchecked((nint)6447293664L);
					goto IL_1ad2;
				}
			}
			num4 = ((Delegate)tweenCallback).method_ptr;
			((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
			goto IL_1ad2;
			IL_148b:
			specialTween4 = _specialTween;
			if (_specialTween != null && ((Tween)specialTween4)._003Cactive_003Ek__BackingField && !((Tween)specialTween4).creationLocked)
			{
				((Tween)specialTween4).loops = -1;
				if (((ABSSequentiable)specialTween4).tweenType == TweenType.Tweener)
				{
					((Tween)specialTween4).fullDuration = 1f / 0f;
				}
			}
			specialTween5 = _specialTween;
			if (_specialTween != null && ((Tween)specialTween5)._003Cactive_003Ek__BackingField)
			{
				((Tween)specialTween5).isRecyclable = false;
			}
			nameText = (StageSelectPage)(object)_NameText;
			flag47 = ((UnityEngine.Object)nameText).m_CachedPtr == (IntPtr)0;
			gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)nameText).m_CachedPtr);
			transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
			flag48 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
			stageNumber = (StageSelectPage)(object)_StageNumber;
			flag49 = ((UnityEngine.Object)stageNumber).m_CachedPtr == (IntPtr)0;
			gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)stageNumber).m_CachedPtr);
			transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			flag50 = ((PlayerOptions)(object)transform2).RunGoldUpdated == null;
			Transform.set_localScale_Injected((IntPtr)((PlayerOptions)(object)transform2).RunGoldUpdated, ref *(Vector3*)(&value));
			rectTransform = _StageNumber.rectTransform;
			rectTransform2 = _StageNumber.rectTransform;
			flag51 = ((UnityEngine.Object)rectTransform2).m_CachedPtr == (IntPtr)0;
			RectTransform.get_anchoredPosition_Injected(((UnityEngine.Object)rectTransform2).m_CachedPtr, out ret);
			flag52 = (object)rectTransform == null;
			flag53 = ((PlayerOptions)(object)rectTransform).RunGoldUpdated == null;
			RectTransform.set_anchoredPosition_Injected((IntPtr)((PlayerOptions)(object)rectTransform).RunGoldUpdated, ref value3);
			break;
			IL_19e6:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rax_v236 (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+1A0]");
			obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rax_v236 (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+1A0]");
			flag54 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v187+18]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj26 = default(object);
				if ((nint)obj26 != -1)
				{
					break;
				}
			}
			playerOptions4 = (StageSelectPage)(object)_playerOptions;
			flag55 = _playerOptions == null;
			if ((object)((BaseUIPage)playerOptions4)._inputModule == null)
			{
				if (((BaseUIPage)playerOptions4).previouslySelectedItemIndex == 0)
				{
					RewiredStandaloneInputModule rewiredStandaloneInputModule;
					if (((BaseUIPage)playerOptions4).ShouldLog)
					{
						rewiredStandaloneInputModule = (RewiredStandaloneInputModule)((BaseUIPage)playerOptions4).ShouldLog;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v839 @ rax_v239 (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+2CC]");
						if ((nint)0 != 0)
						{
							goto IL_1a3c;
						}
					}
					rewiredStandaloneInputModule = (RewiredStandaloneInputModule)((BaseUIPage)playerOptions4)._OffsetWhenSliderShown;
					bool flag56 = ((BaseUIPage)playerOptions4)._OffsetWhenSliderShown == 0f;
				}
				else
				{
					RewiredStandaloneInputModule rewiredStandaloneInputModule = (RewiredStandaloneInputModule)((BaseUIPage)playerOptions4).previouslySelectedItemIndex;
				}
			}
			else
			{
				RewiredStandaloneInputModule rewiredStandaloneInputModule = ((BaseUIPage)playerOptions4)._inputModule;
			}
			goto IL_1a3c;
			IL_1d08:
			relicPanel = stageSelectPage6._RelicPanel;
			flag57 = (object)stageSelectPage6._RelicPanel == null;
			if (((MonoBehaviour)relicPanel).m_CancellationTokenSource != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj27 = default(object);
				if ((nint)obj27 != -1)
				{
					break;
				}
			}
			playerOptions5 = (StageSelectPage)(object)_playerOptions;
			flag58 = _playerOptions == null;
			if ((object)((BaseUIPage)playerOptions5)._inputModule == null)
			{
				if (((BaseUIPage)playerOptions5).previouslySelectedItemIndex == 0)
				{
					RewiredStandaloneInputModule rewiredStandaloneInputModule2;
					if (((BaseUIPage)playerOptions5).ShouldLog)
					{
						rewiredStandaloneInputModule2 = (RewiredStandaloneInputModule)((BaseUIPage)playerOptions5).ShouldLog;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ rax_v236 (Rewired.Integration.UnityUI.RewiredStandaloneInputModule)+2CC]");
						if ((nint)0 != 0)
						{
							goto IL_19e6;
						}
					}
					rewiredStandaloneInputModule2 = (RewiredStandaloneInputModule)((BaseUIPage)playerOptions5)._OffsetWhenSliderShown;
					bool flag59 = ((BaseUIPage)playerOptions5)._OffsetWhenSliderShown == 0f;
				}
				else
				{
					RewiredStandaloneInputModule rewiredStandaloneInputModule2 = (RewiredStandaloneInputModule)((BaseUIPage)playerOptions5).previouslySelectedItemIndex;
				}
			}
			else
			{
				RewiredStandaloneInputModule rewiredStandaloneInputModule2 = ((BaseUIPage)playerOptions5)._inputModule;
			}
			goto IL_19e6;
		}
	}

	public void SetInfoPanel()
	{
		StageSelectPage page = _page;
		if ((object)_page != null && ((UnityEngine.Object)page).m_CachedPtr != (IntPtr)0)
		{
			StageSelectPage page2 = _page;
			StageItemUI highlightedStage = page2._highlightedStage;
			if ((object)page2._highlightedStage != null && ((UnityEngine.Object)highlightedStage).m_CachedPtr != (IntPtr)0)
			{
				StageItemUI highlightedStage2 = page2._highlightedStage;
				highlightedStage2._Background.enabled = false;
			}
			page2._highlightedStage = this;
			StageItemUI highlightedStage3 = page2._highlightedStage;
			highlightedStage3._Background.enabled = true;
			_page.SetInfoPanel(this, _stage, _003CType_003Ek__BackingField);
		}
	}

	public StageData GetData()
	{
		return _stage;
	}

	public StageType GetStageType()
	{
		return _003CType_003Ek__BackingField;
	}

	public bool HasHyperUnlocked()
	{
		//IL_0070: Expected I4, but got O
		StageData stage = _stage;
		if (_stage != null)
		{
			StageModifiers stageModifiers = stage._003Chyper_003Ek__BackingField;
			if (stage._003Chyper_003Ek__BackingField != null)
			{
				return stageModifiers._003Cunlocked_003Ek__BackingField;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void MakeDisabled()
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		//IL_0079: Expected O, but got Ref
		//IL_00ac: Expected O, but got Ref
		//IL_00cf: Expected O, but got Ref
		Color color = _Background.color;
		object obj = default(object);
		_Background.color = (Color)(&obj);
		Color color2 = _Icon.color;
		_Icon.color = (Color)(&obj);
		TextMeshProUGUI component = _NameText.GetComponent<TextMeshProUGUI>();
		Color color3 = component.color;
		component.color = (Color)(&obj);
		TextMeshProUGUI component2 = _DescriptionText.GetComponent<TextMeshProUGUI>();
		Color color4 = component2.color;
		component2.color = (Color)(&obj);
		Color color5 = _StageNumber.color;
		_StageNumber.color = (Color)(&obj);
	}

	public unsafe void MakeEnabled()
	{
		//IL_0015: Expected O, but got Ref
		//IL_002a: Expected O, but got Ref
		//IL_005f: Expected O, but got Ref
		//IL_0086: Expected O, but got Ref
		//IL_009a: Expected O, but got Ref
		float num = default(float);
		_Background.color = (Color)(&num);
		_Icon.color = (Color)(&num);
		TextMeshProUGUI component = _NameText.GetComponent<TextMeshProUGUI>();
		Color color = ColourHelper.HexToColor("DBDE03");
		component.color = (Color)(&num);
		TextMeshProUGUI component2 = _DescriptionText.GetComponent<TextMeshProUGUI>();
		component2.color = (Color)(&num);
		_StageNumber.color = (Color)(&num);
	}

	protected override void OnSelected()
	{
		SetInfoPanel();
	}

	public StageItemUI()
	{
		string[] frameNames = new string[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_frameNames = frameNames;
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
	}

	private unsafe void _003CSetData_003Eb__23_0()
	{
		//IL_01a4: Expected O, but got I
		//IL_0053: Expected O, but got Ref
		//IL_003e: Expected O, but got I8
		//IL_01f5: Expected O, but got I4
		//IL_011c: Expected O, but got I
		//IL_0179: Expected O, but got I8
		//IL_00c0->IL0188: Incompatible stack heights: 1 vs 0
		//IL_00f8->IL0188: Incompatible stack heights: 1 vs 0
		//IL_0234->IL0188: Incompatible stack heights: 1 vs 0
		//IL_017e->IL0212: Incompatible stack heights: 2 vs 1
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		StageItemUI stageItemUI = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			stageItemUI = (StageItemUI)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v50 @ rax_v7 (should have been resolved before IL gen)");
		float num = -1f * 0.35f;
		if ((object)_Overlay != null)
		{
			object obj2 = default(object);
			_Overlay.color = (Color)(&obj2);
			string[] frameNames = _frameNames;
			if (_frameNames != null)
			{
				object obj3 = UnityEngine.Random.RandomRangeInt(0, frameNames.Length);
				bool flag2 = (nint)obj3 >= frameNames.Length;
				Sprite sprite = SpriteManager.GetSprite(frameNames[obj3], "character_missing");
				if ((object)_Overlay != null)
				{
					_Overlay.sprite = sprite;
					Component icon = _Icon;
					if ((object)_Icon != null)
					{
						Transform transform = _Icon.transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
							bool flag3 = obj4 == null;
							icon = (Component)6573110936L;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v519 @ rax_v22 (should have been resolved before IL gen)");
						if ((object)transform != null)
						{
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
