using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class SecretUnlockPopup : MonoBehaviour
{
	private Localize _SecretUnlock;

	private Image _Icon;

	private RectTransform _Panel;

	private TextMeshProUGUI _PageCount;

	private GameObject _UnlocksCircle;

	private TextMeshProUGUI _UnlockText;

	private CanvasGroup _CircleGroup;

	private List<SecretUnlockInfo> _secretsToShow;

	private int _currentSecretIndex;

	private DataManager _dataManager;

	private Dictionary<SecretType, SecretData> _secrets;

	private Action _onComplete;

	private void Construct(DataManager data)
	{
		_dataManager = data;
	}

	public unsafe void SetSecrets(List<SecretUnlockInfo> unlocks, Action onComplete)
	{
		//IL_003f: Expected O, but got Ref
		//IL_007e: Expected O, but got I4
		//IL_0086: Expected O, but got Ref
		//IL_00cd: Expected O, but got I4
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected I4, but got Unknown
		//IL_0152: Expected O, but got I4
		//IL_0363: Expected I4, but got O
		//IL_016f: Expected O, but got I4
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected I4, but got Unknown
		//IL_01f4: Expected O, but got I4
		//IL_03c2: Expected I4, but got O
		//IL_0211: Expected O, but got Ref
		//IL_023c: Expected I, but got O
		//IL_0328->IL024d: Incompatible stack heights: 1 vs 0
		//IL_0387->IL024d: Incompatible stack heights: 2 vs 0
		//IL_022f->IL024d: Incompatible stack heights: 3 vs 0
		_secretsToShow = unlocks;
		_currentSecretIndex = 0;
		_onComplete = onComplete;
		if (unlocks != null)
		{
			List<SecretUnlockInfo> list = default(List<SecretUnlockInfo>);
			string text = System.Number.FormatInt32(unlocks._size, (ReadOnlySpan<char>)(&list), null);
			string message = "Unlocks count : " + text;
			Debug.Log(message);
			list = unlocks;
			List<SecretUnlockInfo>.Enumerator enumerator = default(List<SecretUnlockInfo>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<SecretUnlockInfo>.Enumerator enumerator2 = (List<SecretUnlockInfo>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			object pageCount = _PageCount;
			if ((object)_PageCount != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rbx_v11 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rbx_v11 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject gameObject = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				if ((object)gameObject != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v43 (UnityEngine.GameObject)+10]");
					bool flag2 = (nint)0 == 0;
					object obj2 = unlocks._size - 1;
					int num = unlocks._size ^ 1;
					int num2 = unlocks._size ^ obj2;
					int num3 = num & num2;
					bool flag3 = num3 < 0;
					bool flag4 = (nint)obj2 < 0;
					bool flag5 = obj2 == null;
					bool flag6 = flag4 == flag3;
					bool flag7 = !flag5;
					object obj3 = flag7 & flag6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v43 (UnityEngine.GameObject)+10]");
					GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj3 != 0);
					object unlocksCircle = _UnlocksCircle;
					if ((object)_UnlocksCircle != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rbx_v15 (System.Object)+10]");
						bool flag8 = (nint)0 == 0;
						object obj4 = unlocks._size - 1;
						int num4 = unlocks._size ^ 1;
						int num5 = unlocks._size ^ obj4;
						int num6 = num4 & num5;
						bool flag9 = num6 < 0;
						bool flag10 = (nint)obj4 < 0;
						bool flag11 = obj4 == null;
						bool flag12 = flag10 == flag9;
						bool flag13 = !flag11;
						object obj5 = flag13 & flag12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rbx_v15 (System.Object)+10]");
						GameObject.SetActive_Injected((IntPtr)0, (byte)(int)obj5 != 0);
						object unlockText = _UnlockText;
						string text2 = System.Number.FormatInt32(unlocks._size, (ReadOnlySpan<char>)(&list), null);
						if ((object)_UnlockText != null)
						{
							nint num7 = (nint)unlockText;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v898 @ r9_v11 (Il2CppClass<System.Object>)+558] (should have been resolved before IL gen)");
							StartShowLoop();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void StartShowLoop()
	{
		//IL_0610: Expected I4, but got I8
		Sequence sequence = DOTween.Sequence();
		TweenCallback tweenCallback = delegate
		{
			//IL_00b3: Expected O, but got Ref
			//IL_00fd: Expected O, but got Ref
			//IL_0289: Expected I4, but got O
			//IL_02b8: Expected O, but got I
			//IL_02f7: Expected O, but got I
			//IL_0051->IL034e: Incompatible stack heights: 1 vs 0
			//IL_00db->IL034e: Incompatible stack heights: 1 vs 0
			//IL_0136->IL034e: Incompatible stack heights: 1 vs 0
			//IL_0165->IL034e: Incompatible stack heights: 1 vs 0
			//IL_0191->IL034e: Incompatible stack heights: 1 vs 0
			//IL_03f5->IL034e: Incompatible stack heights: 2 vs 0
			//IL_01df->IL034e: Incompatible stack heights: 2 vs 0
			//IL_020d->IL034e: Incompatible stack heights: 2 vs 0
			//IL_0239->IL034e: Incompatible stack heights: 2 vs 0
			//IL_026b->IL034e: Incompatible stack heights: 2 vs 0
			//IL_02a3->IL034e: Incompatible stack heights: 2 vs 0
			//IL_02d8->IL034e: Incompatible stack heights: 2 vs 0
			List<SecretUnlockInfo> secretsToShow3 = _secretsToShow;
			int currentSecretIndex = _currentSecretIndex;
			if (_secretsToShow != null)
			{
				bool flag3 = _currentSecretIndex >= secretsToShow3._size;
				SecretUnlockInfo[] items = secretsToShow3._items;
				if (secretsToShow3._items != null)
				{
					if (_currentSecretIndex >= items.Length)
					{
						throw new IndexOutOfRangeException();
					}
					SecretUnlockInfo secretUnlockInfo = items[currentSecretIndex];
					int value = _currentSecretIndex + 1;
					Rect ret = default(Rect);
					string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&ret), null);
					List<SecretUnlockInfo> secretsToShow4 = _secretsToShow;
					if (_secretsToShow != null)
					{
						string text2 = System.Number.FormatInt32(secretsToShow4._size, (ReadOnlySpan<char>)(&ret), null);
						string text3 = text + "/" + text2;
						if ((object)_PageCount != null)
						{
							_PageCount.text = text3;
							if ((object)_Panel != null)
							{
								Transform transform = _Panel.transform;
								if ((object)transform != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v38 (UnityEngine.Transform)+10]");
									bool flag4 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v38 (UnityEngine.Transform)+10]");
									Vector2 value2 = default(Vector2);
									Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
									if (items[currentSecretIndex] != null)
									{
										Sprite sprite = SpriteManager.GetSprite(secretUnlockInfo.FrameName, secretUnlockInfo.TextureName);
										if ((object)_Icon != null)
										{
											_Icon.sprite = sprite;
											if ((object)_SecretUnlock != null)
											{
												TextMeshProUGUI component = _SecretUnlock.GetComponent<TextMeshProUGUI>();
												if ((object)component != null)
												{
													component.text = secretUnlockInfo.Name;
													if ((object)_Icon != null)
													{
														RectTransform rectTransform = _Icon.rectTransform;
														int num2 = (int)_Icon;
														if ((object)_Icon != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdi_v15 (System.Int32)+E0]");
															object obj = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdi_v15 (System.Int32)+E0]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v16 (System.Object)+10]");
																bool flag5 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v16 (System.Object)+10]");
																Sprite.get_rect_Injected((IntPtr)0, out Rect _);
																object icon = _Icon;
																bool flag6 = (object)_Icon == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdi_v17 (System.Object)+E0]");
																object obj2 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdi_v17 (System.Object)+E0]");
																bool flag7 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdi_v18 (System.Object)+10]");
																bool flag8 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdi_v18 (System.Object)+10]");
																Sprite.get_rect_Injected((IntPtr)0, out ret);
																bool flag9 = (object)rectTransform == null;
																Vector2 sizeDelta = default(Vector2);
																rectTransform.sizeDelta = sizeDelta;
																TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_CircleGroup, 1f, 0.35f);
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
		IL_0af3:
		object message2;
		Tween t;
		Debugger.LogWarning(message2, t);
		return;
		IL_0533:
		List<SecretUnlockInfo> secretsToShow = _secretsToShow;
		int num = secretsToShow._size;
		if (sequence == null || !((Tween)sequence)._003Cactive_003Ek__BackingField || ((Tween)sequence).creationLocked)
		{
			return;
		}
		if (secretsToShow._size >= -1)
		{
			if (num == 0)
			{
				num = 1;
			}
		}
		else
		{
			num = -1;
		}
		((Tween)sequence).loops = num;
		if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
		{
			if (num <= -1)
			{
				((Tween)sequence).fullDuration = 1f / 0f;
				return;
			}
			float fullDuration = (float)num * ((Tween)sequence).duration;
			((Tween)sequence).fullDuration = fullDuration;
		}
		return;
		IL_07c1:
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScaleY(_Panel, 0f, 0.35f);
		TweenCallback tweenCallback3;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
			TweenCallback tweenCallback2 = delegate
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
			};
			tweenCallback3 = tweenCallback2;
		}
		else
		{
			TweenCallback tweenCallback4 = delegate
			{
				GameObject gameObject = base.gameObject;
				gameObject.SetActive(value: false);
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
				t = null;
				message2 = "You can't add elements to a NULL Sequence";
				goto IL_0af3;
			}
		}
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback3 != null)
				{
					Sequence sequence4 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
				}
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t = null;
			message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t = null;
			message2 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_0af3;
		IL_0355:
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScaleY(_Panel, 0f, 0.35f);
		TweenCallback tweenCallback6;
		object message3;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
		{
			Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t3, ((Tween)sequence).duration);
			TweenCallback tweenCallback5 = delegate
			{
				List<SecretUnlockInfo> secretsToShow3 = _secretsToShow;
				if (++_currentSecretIndex >= secretsToShow3._size)
				{
					_currentSecretIndex = 0;
				}
			};
			tweenCallback6 = tweenCallback5;
		}
		else
		{
			TweenCallback tweenCallback7 = delegate
			{
				List<SecretUnlockInfo> secretsToShow3 = _secretsToShow;
				if (++_currentSecretIndex >= secretsToShow3._size)
				{
					_currentSecretIndex = 0;
				}
			};
			bool flag2 = sequence == null;
			tweenCallback6 = tweenCallback7;
			if (flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message3 = "You can't add elements to a NULL Sequence";
				goto IL_0ad5;
			}
		}
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback6 != null)
				{
					Sequence sequence6 = Sequence.DoInsertCallback(sequence, tweenCallback6, ((Tween)sequence).duration);
				}
				goto IL_0533;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message3 = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_0ad5;
		IL_015a:
		TweenerCore<Vector3, Vector3, VectorOptions> t4 = ShortcutExtensions.DOScaleY(_Panel, 1f, 0.35f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t4, false))
		{
			Sequence sequence7 = Sequence.DoInsert(sequence, (Tween)t4, ((Tween)sequence).duration);
		}
		List<SecretUnlockInfo> secretsToShow2 = _secretsToShow;
		if (secretsToShow2._size != 1)
		{
			Sequence sequence8 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
			TweenCallback tweenCallback8 = delegate
			{
				//IL_0018: Expected O, but got I4
				List<SecretUnlockInfo> secretsToShow3 = _secretsToShow;
				object obj = secretsToShow3._size - 1;
				if (_currentSecretIndex >= (nint)obj)
				{
					Action onComplete = _onComplete;
					if (_onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v56.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_CircleGroup, 0f, 0.35f);
				}
			};
			object message4;
			if (sequence != null)
			{
				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence).creationLocked)
					{
						if (tweenCallback8 != null)
						{
							Sequence sequence9 = Sequence.DoInsertCallback(sequence, tweenCallback8, ((Tween)sequence).duration);
						}
						goto IL_0355;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message4 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					message4 = "You can't add elements to an inactive/killed Sequence";
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message4);
			goto IL_0355;
		}
		Sequence sequence10 = TweenSettingsExtensions.AppendInterval(sequence, 3.15f);
		TweenCallback tweenCallback9 = delegate
		{
			Action onComplete = _onComplete;
			if (_onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		};
		object message5;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback9 != null)
					{
						Sequence sequence11 = Sequence.DoInsertCallback(sequence, tweenCallback9, ((Tween)sequence).duration);
					}
					goto IL_07c1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message5 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message5 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message5);
		goto IL_07c1;
		IL_0ad5:
		Debugger.LogWarning(message3);
		goto IL_0533;
	}

	public SecretUnlockPopup()
	{
		List<SecretUnlockInfo> secretsToShow = new List<SecretUnlockInfo>();
		_secretsToShow = secretsToShow;
	}

	private unsafe void _003CStartShowLoop_003Eb__14_0()
	{
		//IL_00b3: Expected O, but got Ref
		//IL_00fd: Expected O, but got Ref
		//IL_0289: Expected I4, but got O
		//IL_02b8: Expected O, but got I
		//IL_02f7: Expected O, but got I
		//IL_0051->IL034e: Incompatible stack heights: 1 vs 0
		//IL_00db->IL034e: Incompatible stack heights: 1 vs 0
		//IL_0136->IL034e: Incompatible stack heights: 1 vs 0
		//IL_0165->IL034e: Incompatible stack heights: 1 vs 0
		//IL_0191->IL034e: Incompatible stack heights: 1 vs 0
		//IL_03f5->IL034e: Incompatible stack heights: 2 vs 0
		//IL_01df->IL034e: Incompatible stack heights: 2 vs 0
		//IL_020d->IL034e: Incompatible stack heights: 2 vs 0
		//IL_0239->IL034e: Incompatible stack heights: 2 vs 0
		//IL_026b->IL034e: Incompatible stack heights: 2 vs 0
		//IL_02a3->IL034e: Incompatible stack heights: 2 vs 0
		//IL_02d8->IL034e: Incompatible stack heights: 2 vs 0
		List<SecretUnlockInfo> secretsToShow = _secretsToShow;
		int currentSecretIndex = _currentSecretIndex;
		if (_secretsToShow != null)
		{
			bool flag = _currentSecretIndex >= secretsToShow._size;
			SecretUnlockInfo[] items = secretsToShow._items;
			if (secretsToShow._items != null)
			{
				if (_currentSecretIndex >= items.Length)
				{
					throw new IndexOutOfRangeException();
				}
				SecretUnlockInfo secretUnlockInfo = items[currentSecretIndex];
				int value = _currentSecretIndex + 1;
				Rect ret = default(Rect);
				string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&ret), null);
				List<SecretUnlockInfo> secretsToShow2 = _secretsToShow;
				if (_secretsToShow != null)
				{
					string text2 = System.Number.FormatInt32(secretsToShow2._size, (ReadOnlySpan<char>)(&ret), null);
					string text3 = text + "/" + text2;
					if ((object)_PageCount != null)
					{
						_PageCount.text = text3;
						if ((object)_Panel != null)
						{
							Transform transform = _Panel.transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v38 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rax_v38 (UnityEngine.Transform)+10]");
								Vector2 value2 = default(Vector2);
								Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)(&value2));
								if (items[currentSecretIndex] != null)
								{
									Sprite sprite = SpriteManager.GetSprite(secretUnlockInfo.FrameName, secretUnlockInfo.TextureName);
									if ((object)_Icon != null)
									{
										_Icon.sprite = sprite;
										if ((object)_SecretUnlock != null)
										{
											TextMeshProUGUI component = _SecretUnlock.GetComponent<TextMeshProUGUI>();
											if ((object)component != null)
											{
												component.text = secretUnlockInfo.Name;
												if ((object)_Icon != null)
												{
													RectTransform rectTransform = _Icon.rectTransform;
													int num = (int)_Icon;
													if ((object)_Icon != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdi_v15 (System.Int32)+E0]");
														object obj = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rdi_v15 (System.Int32)+E0]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v16 (System.Object)+10]");
															bool flag3 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdi_v16 (System.Object)+10]");
															Sprite.get_rect_Injected((IntPtr)0, out Rect _);
															object icon = _Icon;
															bool flag4 = (object)_Icon == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdi_v17 (System.Object)+E0]");
															object obj2 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rdi_v17 (System.Object)+E0]");
															bool flag5 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdi_v18 (System.Object)+10]");
															bool flag6 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdi_v18 (System.Object)+10]");
															Sprite.get_rect_Injected((IntPtr)0, out ret);
															bool flag7 = (object)rectTransform == null;
															Vector2 sizeDelta = default(Vector2);
															rectTransform.sizeDelta = sizeDelta;
															TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_CircleGroup, 1f, 0.35f);
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

	private void _003CStartShowLoop_003Eb__14_1()
	{
		Action onComplete = _onComplete;
		if (_onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v0.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void _003CStartShowLoop_003Eb__14_2()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void _003CStartShowLoop_003Eb__14_3()
	{
		//IL_0018: Expected O, but got I4
		List<SecretUnlockInfo> secretsToShow = _secretsToShow;
		object obj = secretsToShow._size - 1;
		if (_currentSecretIndex >= (nint)obj)
		{
			Action onComplete = _onComplete;
			if (_onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v56.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTweenModuleUI.DOFade(_CircleGroup, 0f, 0.35f);
		}
	}

	private void _003CStartShowLoop_003Eb__14_4()
	{
		List<SecretUnlockInfo> secretsToShow = _secretsToShow;
		if (++_currentSecretIndex >= secretsToShow._size)
		{
			_currentSecretIndex = 0;
		}
	}
}
