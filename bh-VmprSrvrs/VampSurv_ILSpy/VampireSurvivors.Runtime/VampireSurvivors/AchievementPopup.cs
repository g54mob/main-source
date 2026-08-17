using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class AchievementPopup : MonoBehaviour
{
	private Localize _TitleText;

	private Localize AchievementName;

	private TextMeshProUGUI _AchievementUnlock;

	private Image Icon;

	private Image _Frame;

	private RectTransform AchievementPanel;

	private TextMeshProUGUI PageCount;

	private GameObject _UnlocksCircle;

	private TextMeshProUGUI _UnlockText;

	private List<AchievementData> _achievementsToShow;

	private int _currentAchievementIndex;

	private AchievementManager _achievementManager;

	private DataManager _dataManager;

	private Sequence _showLoop;

	private bool _cancelAfterOneCycle;

	private static Color _defaultBackgroundPanelColor;

	private static Color _adventureBackgroundPanelColor;

	private static string _defaultBackgroundSpriteName;

	private static string _adventureBackgroundSpriteName;

	private void Construct(AchievementManager achiement, DataManager data)
	{
		_achievementManager = achiement;
		_dataManager = data;
	}

	private void OnDestroy()
	{
		CancelLoop();
	}

	public unsafe void SetAchievements(List<AchievementData> achievements, bool cancelAfterOneCycle = false)
	{
		//IL_0046: Expected O, but got I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected I4, but got Unknown
		//IL_012b: Expected O, but got I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected I4, but got Unknown
		//IL_0275: Expected O, but got Ref
		//IL_022b: Expected O, but got Ref
		//IL_023c: Expected I, but got O
		//IL_024f: Expected O, but got I4
		_achievementsToShow = achievements;
		_currentAchievementIndex = 0;
		_cancelAfterOneCycle = cancelAfterOneCycle;
		GameObject gameObject = PageCount.gameObject;
		object obj = achievements._size - 1;
		int num = achievements._size ^ 1;
		int num2 = achievements._size ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		bool flag3 = obj == null;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool active = flag5 & flag4;
		gameObject.SetActive(active);
		GameObject unlocksCircle = _UnlocksCircle;
		if ((object)_UnlocksCircle != null && ((UnityEngine.Object)unlocksCircle).m_CachedPtr != (IntPtr)0)
		{
			object obj2 = achievements._size - 1;
			int num4 = achievements._size ^ 1;
			int num5 = achievements._size ^ obj2;
			int num6 = num4 & num5;
			bool flag6 = num6 < 0;
			bool flag7 = (nint)obj2 < 0;
			bool flag8 = obj2 == null;
			bool flag9 = flag7 == flag6;
			bool flag10 = !flag8;
			bool active2 = flag10 & flag9;
			_UnlocksCircle.SetActive(active2);
		}
		TextMeshProUGUI unlockText = _UnlockText;
		object obj3 = default(object);
		if ((object)_UnlockText != null && ((UnityEngine.Object)unlockText).m_CachedPtr != (IntPtr)0)
		{
			TextMeshProUGUI unlockText2 = _UnlockText;
			string text = System.Number.FormatInt32(achievements._size, (ReadOnlySpan<char>)(&obj3), null);
			nint num7 = (nint)unlockText2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v480 @ r9_v4 (Il2CppMethodInfo)+558] (should have been resolved before IL gen)");
			obj3 = 0;
		}
		Image component = AchievementPanel.GetComponent<Image>();
		component.color = (Color)(&obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 485 Invalid \"Jump target not found in method: 0x1871FECA0\"");
		throw new NullReferenceException();
	}

	public void CancelLoop()
	{
		if (_showLoop != null)
		{
			TweenExtensions.Kill(_showLoop);
		}
		_showLoop = null;
	}

	private unsafe void StartShowLoop()
	{
		//IL_042f: Expected I4, but got I8
		Sequence sequence = DOTween.Sequence();
		TweenCallback tweenCallback = delegate
		{
			//IL_01d0: Expected I, but got O
			//IL_022d: Expected O, but got I
			//IL_023d: Expected O, but got I
			//IL_0208: Expected O, but got I
			//IL_0218: Expected O, but got I
			//IL_0290: Expected O, but got Ref
			//IL_02c0: Expected O, but got Ref
			//IL_05af: Expected O, but got I
			//IL_04c7: Expected O, but got I
			//IL_05ee: Expected O, but got I
			//IL_0506: Expected O, but got I
			//IL_0051->IL068f: Incompatible stack heights: 1 vs 0
			//IL_00ab->IL068f: Incompatible stack heights: 1 vs 0
			//IL_012a->IL068f: Incompatible stack heights: 1 vs 0
			//IL_00fd->IL068f: Incompatible stack heights: 1 vs 0
			//IL_0723->IL068f: Incompatible stack heights: 1 vs 0
			//IL_01a2->IL068f: Incompatible stack heights: 1 vs 0
			//IL_07d7->IL068f: Incompatible stack heights: 2 vs 0
			//IL_03eb->IL068f: Incompatible stack heights: 2 vs 0
			//IL_0813->IL068f: Incompatible stack heights: 2 vs 0
			//IL_0562->IL068f: Incompatible stack heights: 2 vs 0
			//IL_059a->IL068f: Incompatible stack heights: 2 vs 0
			//IL_05cf->IL068f: Incompatible stack heights: 2 vs 0
			//IL_047a->IL068f: Incompatible stack heights: 2 vs 0
			//IL_04b2->IL068f: Incompatible stack heights: 2 vs 0
			//IL_04e7->IL068f: Incompatible stack heights: 2 vs 0
			//IL_0948->IL068f: Incompatible stack heights: 3 vs 0
			//IL_060e->IL068f: Incompatible stack heights: 3 vs 0
			//IL_089b->IL068f: Incompatible stack heights: 3 vs 0
			//IL_0526->IL068f: Incompatible stack heights: 3 vs 0
			//IL_099b->IL068f: Incompatible stack heights: 4 vs 0
			//IL_0644->IL068f: Incompatible stack heights: 4 vs 0
			//IL_067f->IL068f: Incompatible stack heights: 4 vs 0
			//IL_08e9->IL068f: Incompatible stack heights: 4 vs 0
			//IL_0548->IL0548: Incompatible stack heights: 4 vs 2
			List<AchievementData> achievementsToShow2 = _achievementsToShow;
			int currentAchievementIndex = _currentAchievementIndex;
			AchievementData[] items;
			Rect ret = default(Rect);
			Vector2 value2 = default(Vector2);
			Behaviour frame2;
			bool flag6;
			if (_achievementsToShow != null)
			{
				bool flag2 = _currentAchievementIndex >= achievementsToShow2._size;
				items = achievementsToShow2._items;
				if (achievementsToShow2._items != null)
				{
					if (_currentAchievementIndex >= items.Length)
					{
						throw new IndexOutOfRangeException();
					}
					AchievementData achievementData = items[currentAchievementIndex];
					if (items[currentAchievementIndex] != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4926]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						string term;
						if (achievementData._003CadventureUnlockData_003Ek__BackingField == null)
						{
							if ((object)_TitleText == null)
							{
								goto IL_068f;
							}
							term = "lang/genericPopup_achievement";
						}
						else
						{
							if ((object)_TitleText == null)
							{
								goto IL_068f;
							}
							term = "adventureLang/adv_adventureGenericPopup_Progress";
						}
						_TitleText.Term = term;
						if ((object)AchievementPanel != null)
						{
							Image component = AchievementPanel.GetComponent<Image>();
							string spriteName = ((achievementData._003CadventureUnlockData_003Ek__BackingField == null) ? _defaultBackgroundSpriteName : _adventureBackgroundSpriteName);
							Sprite sprite = SpriteManager.GetSprite(spriteName);
							if ((object)component != null)
							{
								component.sprite = sprite;
								bool flag3 = achievementData._003CadventureUnlockData_003Ek__BackingField == null;
								nint num = (nint)achievementData;
								if (!flag3)
								{
									AdventureProgressData adventureProgressData = achievementData._003CadventureUnlockData_003Ek__BackingField;
									AchievementType achievementType = (AchievementType)adventureProgressData._003CType_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+188]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+190]");
									object obj2 = 0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+178]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+180]");
									object obj2 = 0;
									AchievementType achievementType = achievementData._003CType_003Ek__BackingField;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1073 @ rax_v44 (should have been resolved before IL gen)");
								string term2 = default(string);
								AchievementName.Term = term2;
								TextMeshProUGUI pageCount = PageCount;
								int value = _currentAchievementIndex + 1;
								string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&ret), null);
								List<AchievementData> achievementsToShow3 = _achievementsToShow;
								string text2 = System.Number.FormatInt32(achievementsToShow3._size, (ReadOnlySpan<char>)(&ret), null);
								string text3 = text + "/" + text2;
								pageCount.text = text3;
								Transform transform = AchievementPanel.transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v59 (UnityEngine.Transform)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v59 (UnityEngine.Transform)+10]");
								Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
								Sprite spriteForAchievement = _achievementManager.GetSpriteForAchievement(items[currentAchievementIndex]);
								Icon.sprite = spriteForAchievement;
								Sprite frameForSprite = _achievementManager.GetFrameForSprite(items[currentAchievementIndex]);
								_Frame.sprite = frameForSprite;
								Image frame = _Frame;
								string sprite2 = (string)(object)frame.m_Sprite;
								if ((object)frame.m_Sprite != null)
								{
									bool flag5 = sprite2._stringLength == 0;
									frame2 = _Frame;
									if (!flag5)
									{
										if ((object)_Frame == null)
										{
											goto IL_068f;
										}
										flag6 = true;
										goto IL_07dc;
									}
								}
								else
								{
									frame2 = _Frame;
								}
								if ((object)frame2 != null)
								{
									flag6 = false;
									goto IL_07dc;
								}
							}
						}
					}
				}
			}
			goto IL_068f;
			IL_07dc:
			frame2.enabled = flag6;
			Image frame3 = _Frame;
			Vector2 sizeDelta = default(Vector2);
			if ((object)_Frame != null)
			{
				string sprite3 = (string)(object)frame3.m_Sprite;
				if ((object)frame3.m_Sprite == null || sprite3._stringLength == 0)
				{
					goto IL_0548;
				}
				if ((object)_Frame != null)
				{
					RectTransform rectTransform = _Frame.rectTransform;
					string frame4 = (string)(object)_Frame;
					if ((object)_Frame != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rsi_v33 (System.String)+E0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rsi_v33 (System.String)+E0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rsi_v34 (System.Object)+10]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rsi_v34 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&value2));
							string frame5 = (string)(object)_Frame;
							if ((object)_Frame != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rsi_v35 (System.String)+E0]");
								string text4 = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rsi_v35 (System.String)+E0]");
								if ((nint)0 != 0)
								{
									bool flag8 = text4._stringLength == 0;
									Sprite.get_rect_Injected((IntPtr)text4._stringLength, out ret);
									if ((object)rectTransform != null)
									{
										rectTransform.sizeDelta = sizeDelta;
										goto IL_0548;
									}
								}
							}
						}
					}
				}
			}
			goto IL_068f;
			IL_068f:
			throw new NullReferenceException();
			IL_0548:
			if ((object)Icon != null)
			{
				RectTransform rectTransform2 = Icon.rectTransform;
				string icon = (string)(object)Icon;
				if ((object)Icon != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rsi_v27 (System.String)+E0]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rsi_v27 (System.String)+E0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rsi_v28 (System.Object)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rsi_v28 (System.Object)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out ret);
						string icon2 = (string)(object)Icon;
						if ((object)Icon != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rsi_v29 (System.String)+E0]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rsi_v29 (System.String)+E0]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rsi_v30 (System.Object)+10]");
								bool flag10 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rsi_v30 (System.Object)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&value2));
								if ((object)rectTransform2 != null)
								{
									rectTransform2.sizeDelta = sizeDelta;
									if (_achievementManager != null)
									{
										string unlockText = _achievementManager.GetUnlockText(items[currentAchievementIndex]);
										if ((object)_AchievementUnlock != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_068f;
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence2 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_015a;
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
		goto IL_015a;
		IL_015a:
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScaleY(AchievementPanel, 1f, 0.35f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
		}
		List<AchievementData> achievementsToShow = _achievementsToShow;
		if (achievementsToShow._size == 1 && !_cancelAfterOneCycle)
		{
			return;
		}
		Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScaleY(AchievementPanel, 0f, 0.35f);
		TweenCallback tweenCallback3;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
			TweenCallback tweenCallback2 = delegate
			{
				List<AchievementData> achievementsToShow2 = _achievementsToShow;
				if (++_currentAchievementIndex >= achievementsToShow2._size)
				{
					if (!_cancelAfterOneCycle)
					{
						_currentAchievementIndex = 0;
					}
					else
					{
						CancelLoop();
					}
				}
			};
			tweenCallback3 = tweenCallback2;
		}
		else
		{
			TweenCallback tweenCallback4 = delegate
			{
				List<AchievementData> achievementsToShow2 = _achievementsToShow;
				if (++_currentAchievementIndex >= achievementsToShow2._size)
				{
					if (!_cancelAfterOneCycle)
					{
						_currentAchievementIndex = 0;
					}
					else
					{
						CancelLoop();
					}
				}
			};
			bool flag = sequence == null;
			tweenCallback3 = tweenCallback4;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Debugger.LogWarning("You can't add elements to a NULL Sequence");
				goto IL_04a8;
			}
		}
		object message2;
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback3 != null)
				{
					Sequence sequence6 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
				}
				goto IL_03d6;
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
		Debugger.LogWarning(message2);
		goto IL_03d6;
		IL_04a8:
		_showLoop = sequence;
		return;
		IL_03d6:
		if (((Tween)sequence)._003Cactive_003Ek__BackingField && !((Tween)sequence).creationLocked)
		{
			((Tween)sequence).loops = -1;
			((Tween)sequence).loopType = LoopType.Restart;
			if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
			{
				((Tween)sequence).fullDuration = 1f / 0f;
			}
		}
		goto IL_04a8;
	}

	private void SetLocalizedTitleText(bool isAdventure)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4926]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!isAdventure)
		{
			_TitleText.Term = "lang/genericPopup_achievement";
		}
		else
		{
			_TitleText.Term = "adventureLang/adv_adventureGenericPopup_Progress";
		}
	}

	public AchievementPopup()
	{
		List<AchievementData> achievementsToShow = new List<AchievementData>();
		_achievementsToShow = achievementsToShow;
	}

	static AchievementPopup()
	{
		//IL_0026: Expected O, but got I
		//IL_0037: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		_defaultBackgroundPanelColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11FC0]");
		_adventureBackgroundPanelColor = (Color)0;
		_defaultBackgroundSpriteName = "frame1_c2";
		_adventureBackgroundSpriteName = "AdventurePanel";
	}

	private unsafe void _003CStartShowLoop_003Eb__23_0()
	{
		//IL_01d0: Expected I, but got O
		//IL_022d: Expected O, but got I
		//IL_023d: Expected O, but got I
		//IL_0208: Expected O, but got I
		//IL_0218: Expected O, but got I
		//IL_0290: Expected O, but got Ref
		//IL_02c0: Expected O, but got Ref
		//IL_05af: Expected O, but got I
		//IL_04c7: Expected O, but got I
		//IL_05ee: Expected O, but got I
		//IL_0506: Expected O, but got I
		//IL_0051->IL068f: Incompatible stack heights: 1 vs 0
		//IL_00ab->IL068f: Incompatible stack heights: 1 vs 0
		//IL_012a->IL068f: Incompatible stack heights: 1 vs 0
		//IL_00fd->IL068f: Incompatible stack heights: 1 vs 0
		//IL_0723->IL068f: Incompatible stack heights: 1 vs 0
		//IL_01a2->IL068f: Incompatible stack heights: 1 vs 0
		//IL_07d7->IL068f: Incompatible stack heights: 2 vs 0
		//IL_03eb->IL068f: Incompatible stack heights: 2 vs 0
		//IL_0813->IL068f: Incompatible stack heights: 2 vs 0
		//IL_0562->IL068f: Incompatible stack heights: 2 vs 0
		//IL_059a->IL068f: Incompatible stack heights: 2 vs 0
		//IL_05cf->IL068f: Incompatible stack heights: 2 vs 0
		//IL_047a->IL068f: Incompatible stack heights: 2 vs 0
		//IL_04b2->IL068f: Incompatible stack heights: 2 vs 0
		//IL_04e7->IL068f: Incompatible stack heights: 2 vs 0
		//IL_0948->IL068f: Incompatible stack heights: 3 vs 0
		//IL_060e->IL068f: Incompatible stack heights: 3 vs 0
		//IL_089b->IL068f: Incompatible stack heights: 3 vs 0
		//IL_0526->IL068f: Incompatible stack heights: 3 vs 0
		//IL_099b->IL068f: Incompatible stack heights: 4 vs 0
		//IL_0644->IL068f: Incompatible stack heights: 4 vs 0
		//IL_067f->IL068f: Incompatible stack heights: 4 vs 0
		//IL_08e9->IL068f: Incompatible stack heights: 4 vs 0
		//IL_0548->IL0548: Incompatible stack heights: 4 vs 2
		List<AchievementData> achievementsToShow = _achievementsToShow;
		int currentAchievementIndex = _currentAchievementIndex;
		AchievementData[] items;
		Rect ret = default(Rect);
		Vector2 value2 = default(Vector2);
		Behaviour frame2;
		bool flag5;
		if (_achievementsToShow != null)
		{
			bool flag = _currentAchievementIndex >= achievementsToShow._size;
			items = achievementsToShow._items;
			if (achievementsToShow._items != null)
			{
				if (_currentAchievementIndex >= items.Length)
				{
					throw new IndexOutOfRangeException();
				}
				AchievementData achievementData = items[currentAchievementIndex];
				if (items[currentAchievementIndex] != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4926]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					string term;
					if (achievementData._003CadventureUnlockData_003Ek__BackingField == null)
					{
						if ((object)_TitleText == null)
						{
							goto IL_068f;
						}
						term = "lang/genericPopup_achievement";
					}
					else
					{
						if ((object)_TitleText == null)
						{
							goto IL_068f;
						}
						term = "adventureLang/adv_adventureGenericPopup_Progress";
					}
					_TitleText.Term = term;
					if ((object)AchievementPanel != null)
					{
						Image component = AchievementPanel.GetComponent<Image>();
						string spriteName = ((achievementData._003CadventureUnlockData_003Ek__BackingField == null) ? _defaultBackgroundSpriteName : _adventureBackgroundSpriteName);
						Sprite sprite = SpriteManager.GetSprite(spriteName);
						if ((object)component != null)
						{
							component.sprite = sprite;
							bool flag2 = achievementData._003CadventureUnlockData_003Ek__BackingField == null;
							nint num = (nint)achievementData;
							if (!flag2)
							{
								AdventureProgressData adventureProgressData = achievementData._003CadventureUnlockData_003Ek__BackingField;
								AchievementType achievementType = (AchievementType)adventureProgressData._003CType_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+188]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+190]");
								object obj2 = 0;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+178]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ r8_v18 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+180]");
								object obj2 = 0;
								AchievementType achievementType = achievementData._003CType_003Ek__BackingField;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1073 @ rax_v44 (should have been resolved before IL gen)");
							string term2 = default(string);
							AchievementName.Term = term2;
							TextMeshProUGUI pageCount = PageCount;
							int value = _currentAchievementIndex + 1;
							string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&ret), null);
							List<AchievementData> achievementsToShow2 = _achievementsToShow;
							string text2 = System.Number.FormatInt32(achievementsToShow2._size, (ReadOnlySpan<char>)(&ret), null);
							string text3 = text + "/" + text2;
							pageCount.text = text3;
							Transform transform = AchievementPanel.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v59 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v59 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
							Sprite spriteForAchievement = _achievementManager.GetSpriteForAchievement(items[currentAchievementIndex]);
							Icon.sprite = spriteForAchievement;
							Sprite frameForSprite = _achievementManager.GetFrameForSprite(items[currentAchievementIndex]);
							_Frame.sprite = frameForSprite;
							Image frame = _Frame;
							string sprite2 = (string)(object)frame.m_Sprite;
							if ((object)frame.m_Sprite != null)
							{
								bool flag4 = sprite2._stringLength == 0;
								frame2 = _Frame;
								if (!flag4)
								{
									if ((object)_Frame == null)
									{
										goto IL_068f;
									}
									flag5 = true;
									goto IL_07dc;
								}
							}
							else
							{
								frame2 = _Frame;
							}
							if ((object)frame2 != null)
							{
								flag5 = false;
								goto IL_07dc;
							}
						}
					}
				}
			}
		}
		goto IL_068f;
		IL_07dc:
		frame2.enabled = flag5;
		Image frame3 = _Frame;
		Vector2 sizeDelta = default(Vector2);
		if ((object)_Frame != null)
		{
			string sprite3 = (string)(object)frame3.m_Sprite;
			if ((object)frame3.m_Sprite == null || sprite3._stringLength == 0)
			{
				goto IL_0548;
			}
			if ((object)_Frame != null)
			{
				RectTransform rectTransform = _Frame.rectTransform;
				string frame4 = (string)(object)_Frame;
				if ((object)_Frame != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rsi_v33 (System.String)+E0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rsi_v33 (System.String)+E0]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rsi_v34 (System.Object)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rsi_v34 (System.Object)+10]");
						Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&value2));
						string frame5 = (string)(object)_Frame;
						if ((object)_Frame != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rsi_v35 (System.String)+E0]");
							string text4 = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rsi_v35 (System.String)+E0]");
							if ((nint)0 != 0)
							{
								bool flag7 = text4._stringLength == 0;
								Sprite.get_rect_Injected((IntPtr)text4._stringLength, out ret);
								if ((object)rectTransform != null)
								{
									rectTransform.sizeDelta = sizeDelta;
									goto IL_0548;
								}
							}
						}
					}
				}
			}
		}
		goto IL_068f;
		IL_068f:
		throw new NullReferenceException();
		IL_0548:
		if ((object)Icon != null)
		{
			RectTransform rectTransform2 = Icon.rectTransform;
			string icon = (string)(object)Icon;
			if ((object)Icon != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rsi_v27 (System.String)+E0]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rsi_v27 (System.String)+E0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rsi_v28 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rsi_v28 (System.Object)+10]");
					Sprite.get_rect_Injected((IntPtr)0, out ret);
					string icon2 = (string)(object)Icon;
					if ((object)Icon != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rsi_v29 (System.String)+E0]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rsi_v29 (System.String)+E0]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rsi_v30 (System.Object)+10]");
							bool flag9 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rsi_v30 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&value2));
							if ((object)rectTransform2 != null)
							{
								rectTransform2.sizeDelta = sizeDelta;
								if (_achievementManager != null)
								{
									string unlockText = _achievementManager.GetUnlockText(items[currentAchievementIndex]);
									if ((object)_AchievementUnlock != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_068f;
	}

	private void _003CStartShowLoop_003Eb__23_1()
	{
		List<AchievementData> achievementsToShow = _achievementsToShow;
		if (++_currentAchievementIndex >= achievementsToShow._size)
		{
			if (!_cancelAfterOneCycle)
			{
				_currentAchievementIndex = 0;
			}
			else
			{
				CancelLoop();
			}
		}
	}
}
