using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Graphics;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.UI;

public abstract class ProgrammaticUI : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ISelectableUI, bool> _003C_003E9__39_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGenerateNavigation_003Eb__39_0(ISelectableUI ui)
		{
			if (ui != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
				Component component = default(Component);
				if ((object)component != null)
				{
					GameObject gameObject = component.gameObject;
					if ((object)gameObject != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v10 (UnityEngine.GameObject)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 87 ConditionalJump @-1, v147 @ ZF_v9 (System.Boolean) --- -1 Nop");
						/*Error: End of method reached without returning.*/;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003CWaitAndActivateInputField_003Ed__17(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TMP_InputField field;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c7: Expected I4, but got O
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
				Canvas.ForceUpdateCanvases();
				if ((object)field == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				field.ActivateInputField();
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

	protected TextMeshProUGUI _Title;

	protected RectTransform _Content;

	protected GameObject _LabelledButtonPrefab;

	protected GameObject _LabelPrefab;

	protected GameObject _InputPrefab;

	protected GameObject _ButtonPrefab;

	protected GameObject _SaveSlotPrefab;

	protected GameObject _AccountDetailPrefab;

	protected GameObject _PrivacyPolicyGatePrefab;

	protected GameObject _PrivacyPolicyScrollerPrefab;

	protected GameObject _DateOfBirthPrefab;

	protected GameObject _HelpAndSupportPrefab;

	protected List<ISelectableUI> _spawnedSelectables;

	protected List<IUIObject> _spawnedUnselectables;

	private Selectable OnUp;

	private Selectable OnDown;

	protected override void Update()
	{
		//IL_011b: Expected O, but got I4
		//IL_007f: Expected I, but got O
		//IL_00f3: Expected I, but got O
		base.Update();
		object obj = Input.GetKeyDownInt(KeyCode.Tab);
		if (obj == null)
		{
			return;
		}
		EventSystem current = EventSystem.current;
		GameObject currentSelected = current.m_CurrentSelected;
		bool flag = (object)current.m_CurrentSelected == null;
		Component component = null;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)currentSelected).m_CachedPtr == (IntPtr)0;
			component = null;
			if (!flag2)
			{
				Selectable component2 = current.m_CurrentSelected.GetComponent<Selectable>();
				nint num = (nint)component2;
				Selectable selectable = component2.FindSelectableOnDown();
				component = selectable;
			}
		}
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			TMP_InputField componentInChildren = component.GetComponentInChildren<TMP_InputField>();
			if ((object)componentInChildren != null)
			{
			}
			nint num2 = (nint)component;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v549 @ rax_v31 (Il2CppClass<UnityEngine.Component>)+398] (should have been resolved before IL gen)");
		}
	}

	private IEnumerator WaitAndActivateInputField(TMP_InputField field)
	{
		_003CWaitAndActivateInputField_003Ed__17 obj = null;
		obj._003C_003E1__state = 0;
		obj.field = field;
		return obj;
	}

	public unsafe void AddAccountDetail(bool linked, string account, string detail, string buttonText = "", Action callback = null)
	{
		//IL_017d: Expected O, but got I4
		//IL_0549: Expected O, but got Ref
		//IL_00ef: Expected O, but got I4
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected Ref, but got Unknown
		//IL_027a: Expected I8, but got I
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected Ref, but got Unknown
		//IL_02a7: Expected O, but got I4
		//IL_0378: Expected O, but got I4
		//IL_05fc: Expected O, but got I4
		//IL_0640: Expected O, but got I4
		//IL_05e2->IL0522: Incompatible stack heights: 1 vs 0
		//IL_047b->IL0522: Incompatible stack heights: 1 vs 0
		//IL_0626->IL0522: Incompatible stack heights: 2 vs 0
		//IL_0658->IL0522: Incompatible stack heights: 3 vs 0
		//IL_0512->IL0522: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_AccountDetailPrefab, _Content);
		AccountDetailUI component;
		Image icon;
		if ((object)gameObject != null)
		{
			component = gameObject.GetComponent<AccountDetailUI>();
			if ((object)component != null)
			{
				if (!linked)
				{
					Sprite sprite = SpriteManager.GetSprite("no16", "UI.png");
					if ((object)component._Icon != null)
					{
						component._Icon.sprite = sprite;
						icon = component._Icon;
						if ((object)component._Icon != null)
						{
							object obj = 0;
							goto IL_053c;
						}
					}
				}
				else
				{
					Sprite sprite2 = SpriteManager.GetSprite("menu_checkbox_24_checkmark", "UI.png");
					if ((object)component._Icon != null)
					{
						component._Icon.sprite = sprite2;
						icon = component._Icon;
						if ((object)component._Icon != null)
						{
							object obj = 0;
							goto IL_053c;
						}
					}
				}
			}
		}
		goto IL_0522;
		IL_03e3:
		RectTransform component2 = component.GetComponent<RectTransform>();
		Rect ret = default(Rect);
		if ((object)_Content != null)
		{
			VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
			Transform content = _Content;
			if ((object)_Content != null)
			{
				bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
				RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out ret);
				if ((object)component3 != null)
				{
					object padding = ((LayoutGroup)component3).m_Padding;
					if (((LayoutGroup)component3).m_Padding != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v30 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v30 (System.Object)+10]");
						object obj2 = RectOffset.get_left_Injected((IntPtr)0);
						object padding2 = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v33 (System.Object)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v33 (System.Object)+10]");
							Transform transform = (Transform)RectOffset.get_right_Injected((IntPtr)0);
							if ((object)component2 != null)
							{
								Vector2 sizeDelta = component2.sizeDelta;
								object obj3 = (object)transform + obj2;
								Vector2 sizeDelta2 = default(Vector2);
								component2.sizeDelta = sizeDelta2;
								if (_spawnedSelectables != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0522;
		IL_053c:
		icon.color = (Color)(&ret);
		if ((object)component._Account != null)
		{
			component._Account.text = account;
			if ((object)component._Detail != null)
			{
				component._Detail.text = detail;
				Transform transform2 = default(Transform);
				if ((object)transform2 != null)
				{
					object obj4 = "";
					if ((object)transform2 == "")
					{
						goto IL_037e;
					}
					if ("" != null)
					{
						IntPtr cachedPtr = ((UnityEngine.Object)transform2).m_CachedPtr;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ rdx_v20+10]");
						if (cachedPtr == (IntPtr)0)
						{
							ref byte first = ref *(byte*)(transform2 + 20);
							ulong length = (ulong)((nint)((UnityEngine.Object)transform2).m_CachedPtr + (nint)((UnityEngine.Object)transform2).m_CachedPtr);
							bool flag4 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
							object obj = 0;
							if (flag4)
							{
								goto IL_037e;
							}
						}
					}
					if ((object)component._ButtonLabel != null)
					{
						component._ButtonLabel.text = (string)(object)transform2;
						if ((object)component._Button != null)
						{
							((UnityEngine.Object)component._Button).SetName((string)(object)transform2);
							Button button = component._Button;
							if ((object)component._Button != null)
							{
								object obj5 = default(object);
								UnityAction call = ((Action)obj5).Invoke;
								if (button.m_OnClick != null)
								{
									button.m_OnClick.AddListener(call);
									object obj = 0;
									goto IL_03e3;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0522;
		IL_037e:
		if ((object)component._Button != null)
		{
			GameObject gameObject2 = component._Button.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
				goto IL_03e3;
			}
		}
		goto IL_0522;
		IL_0522:
		throw new NullReferenceException();
	}

	public unsafe void AddSaveSlot(string title, string savedata, string buttonText = "", Action callback = null)
	{
		//IL_0098: Expected I, but got O
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected Ref, but got Unknown
		//IL_0190: Expected I8, but got I4
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Ref, but got Unknown
		//IL_01b9: Expected I, but got O
		//IL_0286: Expected I, but got O
		//IL_04cd: Expected O, but got I4
		//IL_0511: Expected O, but got I4
		//IL_04b3->IL0430: Incompatible stack heights: 1 vs 0
		//IL_0389->IL0430: Incompatible stack heights: 1 vs 0
		//IL_04f7->IL0430: Incompatible stack heights: 2 vs 0
		//IL_0529->IL0430: Incompatible stack heights: 3 vs 0
		//IL_0420->IL0430: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_SaveSlotPrefab, _Content);
		SaveSlotContainerUI component;
		if ((object)gameObject != null)
		{
			component = gameObject.GetComponent<SaveSlotContainerUI>();
			if ((object)component != null)
			{
				TextMeshProUGUI title2 = component._Title;
				if ((object)component._Title != null)
				{
					nint num = (nint)title2;
					component._Title.text = title;
					if ((object)component._SaveData != null)
					{
						component._SaveData.text = savedata;
						if (buttonText != null)
						{
							object obj = "";
							if ((object)buttonText == "")
							{
								goto IL_028c;
							}
							if ("" != null)
							{
								int stringLength = buttonText._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rdx_v18+10]");
								if ((nint)stringLength == 0)
								{
									ref byte first = ref *(byte*)(buttonText + 20);
									ulong length = (ulong)(buttonText._stringLength + buttonText._stringLength);
									bool flag = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
									num = unchecked((nint)null);
									if (flag)
									{
										goto IL_028c;
									}
								}
							}
							if ((object)component._ButtonLabel != null)
							{
								component._ButtonLabel.text = buttonText;
								if ((object)component._Button != null)
								{
									((UnityEngine.Object)component._Button).SetName(buttonText);
									Button button = component._Button;
									if ((object)component._Button != null)
									{
										object obj2 = default(object);
										UnityAction call = ((Action)obj2).Invoke;
										if (button.m_OnClick != null)
										{
											button.m_OnClick.AddListener(call);
											num = unchecked((nint)null);
											goto IL_02f1;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0430;
		IL_0430:
		throw new NullReferenceException();
		IL_02f1:
		RectTransform component2 = component.GetComponent<RectTransform>();
		if ((object)_Content != null)
		{
			VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
			string content = (string)(object)_Content;
			if ((object)_Content != null)
			{
				bool flag2 = content._stringLength == 0;
				RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
				if ((object)component3 != null)
				{
					object padding = ((LayoutGroup)component3).m_Padding;
					if (((LayoutGroup)component3).m_Padding != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v27 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v27 (System.Object)+10]");
						object obj3 = RectOffset.get_left_Injected((IntPtr)0);
						object padding2 = ((LayoutGroup)component3).m_Padding;
						if (((LayoutGroup)component3).m_Padding != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v30 (System.Object)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rcx_v30 (System.Object)+10]");
							string text = (string)RectOffset.get_right_Injected((IntPtr)0);
							if ((object)component2 != null)
							{
								Vector2 sizeDelta = component2.sizeDelta;
								object obj4 = text + obj3;
								Vector2 sizeDelta2 = default(Vector2);
								component2.sizeDelta = sizeDelta2;
								if (_spawnedSelectables != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0430;
		IL_028c:
		if ((object)component._Button != null)
		{
			GameObject gameObject2 = component._Button.gameObject;
			if ((object)gameObject2 != null)
			{
				gameObject2.SetActive(value: false);
				goto IL_02f1;
			}
		}
		goto IL_0430;
	}

	public LabeledButtonUI AddLabeledButton(string labelText, string buttonText, Action callback, bool textIsLocalizationTerm = true, bool isEnabledByDefault = true)
	{
		//IL_035c: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_0342->IL02d1: Incompatible stack heights: 1 vs 0
		//IL_0226->IL02d1: Incompatible stack heights: 1 vs 0
		//IL_0386->IL02d1: Incompatible stack heights: 2 vs 0
		//IL_03b8->IL02d1: Incompatible stack heights: 3 vs 0
		//IL_02bd->IL02d1: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_LabelledButtonPrefab, _Content);
		if ((object)gameObject != null)
		{
			LabeledButtonUI component = gameObject.GetComponent<LabeledButtonUI>();
			object obj = default(object);
			bool flag = obj == null;
			string text = labelText;
			string text2 = buttonText;
			if (!flag)
			{
				string text3 = Translate(labelText);
				string text4 = Translate(buttonText);
				text = text3;
				text2 = text4;
			}
			if ((object)component != null && (object)component._Label != null)
			{
				component._Label.text = text;
				if ((object)component._ButtonLabel != null)
				{
					component._ButtonLabel.text = text2;
					if ((object)component._Button != null)
					{
						((UnityEngine.Object)component._Button).SetName(text2);
						component.SetButtonCallback(callback);
						if ((object)component._Button != null)
						{
							bool interactable = default(bool);
							component._Button.interactable = interactable;
							RectTransform component2 = gameObject.GetComponent<RectTransform>();
							if ((object)_Content != null)
							{
								VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
								string content = (string)(object)_Content;
								if ((object)_Content != null)
								{
									bool flag2 = content._stringLength == 0;
									RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
									if ((object)component3 != null)
									{
										object padding = ((LayoutGroup)component3).m_Padding;
										if (((LayoutGroup)component3).m_Padding != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v30 (System.Object)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v30 (System.Object)+10]");
											object obj2 = RectOffset.get_left_Injected((IntPtr)0);
											object padding2 = ((LayoutGroup)component3).m_Padding;
											if (((LayoutGroup)component3).m_Padding != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v33 (System.Object)+10]");
												bool flag4 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v33 (System.Object)+10]");
												string text5 = (string)RectOffset.get_right_Injected((IntPtr)0);
												if ((object)component2 != null)
												{
													Vector2 sizeDelta = component2.sizeDelta;
													object obj3 = text5 + obj2;
													Vector2 sizeDelta2 = default(Vector2);
													component2.sizeDelta = sizeDelta2;
													if (_spawnedSelectables != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
														return component;
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

	public AccountHelpAndSupportUI AddHelpAndSupport(string helpText, string privacyPolicyText)
	{
		//IL_0289: Expected O, but got I4
		//IL_02cd: Expected O, but got I4
		//IL_026f->IL021b: Incompatible stack heights: 1 vs 0
		//IL_0170->IL021b: Incompatible stack heights: 1 vs 0
		//IL_02b3->IL021b: Incompatible stack heights: 2 vs 0
		//IL_02e5->IL021b: Incompatible stack heights: 3 vs 0
		//IL_0207->IL021b: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_HelpAndSupportPrefab, _Content);
		if ((object)gameObject != null)
		{
			AccountHelpAndSupportUI component = gameObject.GetComponent<AccountHelpAndSupportUI>();
			if ((object)component != null)
			{
				TextMeshProUGUI helpText2 = component._HelpText;
				if ((object)component._HelpText != null)
				{
					component._HelpText.text = helpText;
					if ((object)component._PrivacyPolicyText != null)
					{
						component._PrivacyPolicyText.text = privacyPolicyText;
						RectTransform component2 = component.GetComponent<RectTransform>();
						if ((object)_Content != null)
						{
							VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
							Transform content = _Content;
							if ((object)_Content != null)
							{
								bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
								RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
								if ((object)component3 != null)
								{
									object padding = ((LayoutGroup)component3).m_Padding;
									if (((LayoutGroup)component3).m_Padding != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Object)+10]");
										bool flag2 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rcx_v26 (System.Object)+10]");
										object obj = RectOffset.get_left_Injected((IntPtr)0);
										object padding2 = ((LayoutGroup)component3).m_Padding;
										if (((LayoutGroup)component3).m_Padding != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v29 (System.Object)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v29 (System.Object)+10]");
											Transform transform = (Transform)RectOffset.get_right_Injected((IntPtr)0);
											if ((object)component2 != null)
											{
												Vector2 sizeDelta = component2.sizeDelta;
												object obj2 = (object)transform + obj;
												Vector2 sizeDelta2 = default(Vector2);
												component2.sizeDelta = sizeDelta2;
												if (_spawnedSelectables != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
													return component;
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

	public void AddPrivacyPolicyGate(string warningMessage, string centerButtonText, Action centerButtonCallback, bool textIsLocalizationTerm = true)
	{
		//IL_03a4: Expected O, but got I4
		//IL_03e8: Expected O, but got I4
		//IL_038a->IL02e5: Incompatible stack heights: 1 vs 0
		//IL_023e->IL02e5: Incompatible stack heights: 1 vs 0
		//IL_03ce->IL02e5: Incompatible stack heights: 2 vs 0
		//IL_0400->IL02e5: Incompatible stack heights: 3 vs 0
		//IL_02d5->IL02e5: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_PrivacyPolicyGatePrefab, _Content);
		if ((object)gameObject != null)
		{
			PrivacyPolicyGateUI component = gameObject.GetComponent<PrivacyPolicyGateUI>();
			if ((object)component != null && (object)component._WarningMessage != null)
			{
				component._WarningMessage.text = warningMessage;
				if ((object)component._WarningMessage != null)
				{
					((UnityEngine.Object)component._WarningMessage).SetName(warningMessage);
					object obj = default(object);
					bool flag = obj == null;
					string text = centerButtonText;
					if (!flag)
					{
						string text2 = Translate(centerButtonText);
						text = text2;
					}
					if ((object)component._CenterButtonLabel != null)
					{
						component._CenterButtonLabel.text = text;
						if ((object)component._CenterButton != null)
						{
							((UnityEngine.Object)component._CenterButton).SetName(text);
							Button centerButton = component._CenterButton;
							if ((object)component._CenterButton != null)
							{
								UnityAction call = centerButtonCallback.Invoke;
								if (centerButton.m_OnClick != null)
								{
									centerButton.m_OnClick.AddListener(call);
									RectTransform component2 = component.GetComponent<RectTransform>();
									if ((object)_Content != null)
									{
										VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
										string content = (string)(object)_Content;
										if ((object)_Content != null)
										{
											bool flag2 = content._stringLength == 0;
											RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
											if ((object)component3 != null)
											{
												object padding = ((LayoutGroup)component3).m_Padding;
												if (((LayoutGroup)component3).m_Padding != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v33 (System.Object)+10]");
													bool flag3 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v33 (System.Object)+10]");
													object obj2 = RectOffset.get_left_Injected((IntPtr)0);
													object padding2 = ((LayoutGroup)component3).m_Padding;
													if (((LayoutGroup)component3).m_Padding != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v36 (System.Object)+10]");
														bool flag4 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v36 (System.Object)+10]");
														string text3 = (string)RectOffset.get_right_Injected((IntPtr)0);
														if ((object)component2 != null)
														{
															Vector2 sizeDelta = component2.sizeDelta;
															object obj3 = text3 + obj2;
															Vector2 sizeDelta2 = default(Vector2);
															component2.sizeDelta = sizeDelta2;
															if (_spawnedSelectables != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
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
		throw new NullReferenceException();
	}

	public void AddPrivacyPolicyScroller(string leftButtonText, Action leftButtonCallback, string rightButtonText, Action rightButtonCallback, bool textIsLocalizationTerm = true)
	{
		//IL_0465: Expected O, but got I4
		//IL_04a9: Expected O, but got I4
		//IL_044b->IL035a: Incompatible stack heights: 1 vs 0
		//IL_02b3->IL035a: Incompatible stack heights: 1 vs 0
		//IL_048f->IL035a: Incompatible stack heights: 2 vs 0
		//IL_04c1->IL035a: Incompatible stack heights: 3 vs 0
		//IL_034a->IL035a: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_PrivacyPolicyScrollerPrefab, _Content);
		if ((object)gameObject != null)
		{
			PrivacyPolicyScrollerUI component = gameObject.GetComponent<PrivacyPolicyScrollerUI>();
			object obj = default(object);
			bool flag = obj == null;
			string text = leftButtonText;
			if (!flag)
			{
				string text2 = Translate(leftButtonText);
				text = text2;
			}
			if ((object)component != null && (object)component._LeftButtonLabel != null)
			{
				component._LeftButtonLabel.text = text;
				if ((object)component._LeftButton != null)
				{
					((UnityEngine.Object)component._LeftButton).SetName(text);
					Button leftButton = component._LeftButton;
					if ((object)component._LeftButton != null)
					{
						UnityAction call = leftButtonCallback.Invoke;
						if (leftButton.m_OnClick != null)
						{
							leftButton.m_OnClick.AddListener(call);
							bool flag2 = obj == null;
							string text3 = rightButtonText;
							if (!flag2)
							{
								string text4 = Translate(rightButtonText);
								text3 = text4;
							}
							if ((object)component._RightButtonLabel != null)
							{
								component._RightButtonLabel.text = text3;
								if ((object)component._RightButton != null)
								{
									((UnityEngine.Object)component._RightButton).SetName(text3);
									Button rightButton = component._RightButton;
									if ((object)component._RightButton != null)
									{
										object obj2 = default(object);
										UnityAction call2 = ((Action)obj2).Invoke;
										if (rightButton.m_OnClick != null)
										{
											rightButton.m_OnClick.AddListener(call2);
											RectTransform component2 = component.GetComponent<RectTransform>();
											if ((object)_Content != null)
											{
												VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
												string content = (string)(object)_Content;
												if ((object)_Content != null)
												{
													bool flag3 = content._stringLength == 0;
													RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
													if ((object)component3 != null)
													{
														object padding = ((LayoutGroup)component3).m_Padding;
														if (((LayoutGroup)component3).m_Padding != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v38 (System.Object)+10]");
															bool flag4 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v38 (System.Object)+10]");
															object obj3 = RectOffset.get_left_Injected((IntPtr)0);
															object padding2 = ((LayoutGroup)component3).m_Padding;
															if (((LayoutGroup)component3).m_Padding != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v41 (System.Object)+10]");
																bool flag5 = (nint)0 == 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v41 (System.Object)+10]");
																string text5 = (string)RectOffset.get_right_Injected((IntPtr)0);
																if ((object)component2 != null)
																{
																	Vector2 sizeDelta = component2.sizeDelta;
																	object obj4 = text5 + obj3;
																	Vector2 sizeDelta2 = default(Vector2);
																	component2.sizeDelta = sizeDelta2;
																	if (_spawnedSelectables != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
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
		throw new NullReferenceException();
	}

	public GameObject AddDateOfBirth(string label, Action onAllFieldsFilled)
	{
		//IL_0098: Expected I, but got O
		GameObject gameObject = UnityEngine.Object.Instantiate(_DateOfBirthPrefab, _Content);
		if ((object)gameObject != null)
		{
			DateOfBirthField component = gameObject.GetComponent<DateOfBirthField>();
			if ((object)component != null)
			{
				TextMeshProUGUI label2 = component._Label;
				if ((object)component._Label != null)
				{
					nint num = (nint)label2;
					component._Label.text = label;
					if (_spawnedSelectables != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
						return gameObject;
					}
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	public ButtonUI AddButton(string buttonText, Action callback, bool textIsLocalizationTerm = true)
	{
		//IL_033c: Expected O, but got I4
		//IL_0380: Expected O, but got I4
		//IL_0322->IL0282: Incompatible stack heights: 1 vs 0
		//IL_01d7->IL0282: Incompatible stack heights: 1 vs 0
		//IL_0366->IL0282: Incompatible stack heights: 2 vs 0
		//IL_0398->IL0282: Incompatible stack heights: 3 vs 0
		//IL_026e->IL0282: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_ButtonPrefab, _Content);
		if ((object)gameObject != null)
		{
			ButtonUI component = gameObject.GetComponent<ButtonUI>();
			bool flag = !textIsLocalizationTerm;
			string text = buttonText;
			if (!flag)
			{
				string text2 = Translate(buttonText);
				text = text2;
			}
			if ((object)component != null && (object)component._ButtonLabel != null)
			{
				component._ButtonLabel.text = text;
				if ((object)component._Button != null)
				{
					((UnityEngine.Object)component._Button).SetName(text);
					Button button = component._Button;
					if ((object)component._Button != null)
					{
						UnityAction call = callback.Invoke;
						if (button.m_OnClick != null)
						{
							button.m_OnClick.AddListener(call);
							RectTransform component2 = gameObject.GetComponent<RectTransform>();
							if ((object)_Content != null)
							{
								VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
								string content = (string)(object)_Content;
								if ((object)_Content != null)
								{
									bool flag2 = content._stringLength == 0;
									RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
									if ((object)component3 != null)
									{
										object padding = ((LayoutGroup)component3).m_Padding;
										if (((LayoutGroup)component3).m_Padding != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v31 (System.Object)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v31 (System.Object)+10]");
											object obj = RectOffset.get_left_Injected((IntPtr)0);
											object padding2 = ((LayoutGroup)component3).m_Padding;
											if (((LayoutGroup)component3).m_Padding != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v34 (System.Object)+10]");
												bool flag4 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v34 (System.Object)+10]");
												string text3 = (string)RectOffset.get_right_Injected((IntPtr)0);
												if ((object)component2 != null)
												{
													Vector2 sizeDelta = component2.sizeDelta;
													object obj2 = text3 + obj;
													Vector2 sizeDelta2 = default(Vector2);
													component2.sizeDelta = sizeDelta2;
													if (_spawnedSelectables != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
														return component;
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

	public void AddLabel(string labelText)
	{
		//IL_0250: Expected O, but got I4
		//IL_0294: Expected O, but got I4
		//IL_0236->IL01e2: Incompatible stack heights: 1 vs 0
		//IL_013b->IL01e2: Incompatible stack heights: 1 vs 0
		//IL_027a->IL01e2: Incompatible stack heights: 2 vs 0
		//IL_02ac->IL01e2: Incompatible stack heights: 3 vs 0
		//IL_01d2->IL01e2: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_LabelPrefab, _Content);
		if ((object)gameObject != null)
		{
			LabelUI component = gameObject.GetComponent<LabelUI>();
			if ((object)component != null)
			{
				TextMeshProUGUI label = component._Label;
				if ((object)component._Label != null)
				{
					component._Label.text = labelText;
					RectTransform component2 = component.GetComponent<RectTransform>();
					if ((object)_Content != null)
					{
						VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
						GameObject content = (GameObject)(object)_Content;
						if ((object)_Content != null)
						{
							bool flag = ((UnityEngine.Object)content).m_CachedPtr == (IntPtr)0;
							RectTransform.get_rect_Injected(((UnityEngine.Object)content).m_CachedPtr, out Rect _);
							if ((object)component3 != null)
							{
								object padding = ((LayoutGroup)component3).m_Padding;
								if (((LayoutGroup)component3).m_Padding != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v25 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v25 (System.Object)+10]");
									object obj = RectOffset.get_left_Injected((IntPtr)0);
									object padding2 = ((LayoutGroup)component3).m_Padding;
									if (((LayoutGroup)component3).m_Padding != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v28 (System.Object)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v28 (System.Object)+10]");
										GameObject gameObject2 = (GameObject)RectOffset.get_right_Injected((IntPtr)0);
										if ((object)component2 != null)
										{
											Vector2 sizeDelta = component2.sizeDelta;
											object obj2 = (object)gameObject2 + obj;
											Vector2 sizeDelta2 = default(Vector2);
											component2.sizeDelta = sizeDelta2;
											if (_spawnedUnselectables != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B980");
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

	public LabeledInputUI AddLabeledEmailInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
	{
		bool textIsLocalizationTerm2 = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		UnityAction<string> onChange2 = default(UnityAction<string>);
		return AddLabeledInput(labelText, defaultValue, placeholder, textIsLocalizationTerm2, contentType, onChange2);
	}

	public LabeledInputUI AddLabeledPasswordInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, UnityAction<string> onChange = null)
	{
		bool textIsLocalizationTerm2 = default(bool);
		TMP_InputField.ContentType contentType = default(TMP_InputField.ContentType);
		UnityAction<string> onChange2 = default(UnityAction<string>);
		return AddLabeledInput(labelText, defaultValue, placeholder, textIsLocalizationTerm2, contentType, onChange2);
	}

	private LabeledInputUI AddLabeledInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true, TMP_InputField.ContentType contentType = TMP_InputField.ContentType.Alphanumeric, UnityAction<string> onChange = null)
	{
		//IL_042e: Expected O, but got I4
		//IL_0472: Expected O, but got I4
		//IL_0414->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_02f8->IL03a3: Incompatible stack heights: 1 vs 0
		//IL_0458->IL03a3: Incompatible stack heights: 2 vs 0
		//IL_048a->IL03a3: Incompatible stack heights: 3 vs 0
		//IL_038f->IL03a3: Incompatible stack heights: 3 vs 0
		GameObject gameObject = UnityEngine.Object.Instantiate(_InputPrefab, _Content);
		if ((object)gameObject != null)
		{
			LabeledInputUI component = gameObject.GetComponent<LabeledInputUI>();
			object obj = default(object);
			bool flag = obj == null;
			string text = labelText;
			if (!flag)
			{
				string text2 = Translate(labelText);
				text = text2;
			}
			if ((object)component != null && (object)component._Label != null)
			{
				component._Label.text = text;
				if ((object)component._Input != null)
				{
					TMP_InputField.ContentType contentType2 = default(TMP_InputField.ContentType);
					component._Input.contentType = contentType2;
					bool flag2 = defaultValue == null;
					string text3 = placeholder;
					if (!flag2)
					{
						bool flag3 = defaultValue._stringLength <= 0;
						text3 = placeholder;
						if (!flag3)
						{
							if ((object)component._Input == null)
							{
								goto IL_03a3;
							}
							component._Input.SetText(defaultValue, true);
							text3 = null;
						}
					}
					if (placeholder != null && placeholder._stringLength > 0)
					{
						component.SetInputPlaceholderText(placeholder);
					}
					UnityAction<string> unityAction = default(UnityAction<string>);
					if (unityAction != null)
					{
						TMP_InputField input = component._Input;
						if ((object)component._Input == null || input.m_OnValueChanged == null)
						{
							goto IL_03a3;
						}
						input.m_OnValueChanged.AddListener(unityAction);
					}
					RectTransform component2 = component.GetComponent<RectTransform>();
					if ((object)_Content != null)
					{
						VerticalLayoutGroup component3 = _Content.GetComponent<VerticalLayoutGroup>();
						string content = (string)(object)_Content;
						if ((object)_Content != null)
						{
							bool flag4 = content._stringLength == 0;
							RectTransform.get_rect_Injected((IntPtr)content._stringLength, out Rect _);
							if ((object)component3 != null)
							{
								object padding = ((LayoutGroup)component3).m_Padding;
								if (((LayoutGroup)component3).m_Padding != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v30 (System.Object)+10]");
									bool flag5 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v30 (System.Object)+10]");
									object obj2 = RectOffset.get_left_Injected((IntPtr)0);
									object padding2 = ((LayoutGroup)component3).m_Padding;
									if (((LayoutGroup)component3).m_Padding != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v33 (System.Object)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v33 (System.Object)+10]");
										string text4 = (string)RectOffset.get_right_Injected((IntPtr)0);
										if ((object)component2 != null)
										{
											Vector2 sizeDelta = component2.sizeDelta;
											object obj3 = text4 + obj2;
											Vector2 sizeDelta2 = default(Vector2);
											component2.sizeDelta = sizeDelta2;
											if (_spawnedSelectables != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B920");
												return component;
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
		goto IL_03a3;
		IL_03a3:
		throw new NullReferenceException();
	}

	public unsafe virtual void Clear()
	{
		//IL_0013: Expected F4, but got I4
		//IL_0429: Expected O, but got Ref
		//IL_0021: Expected F4, but got I4
		//IL_0029: Expected O, but got Ref
		//IL_0148: Expected F4, but got I4
		//IL_0156: Expected F4, but got I4
		//IL_015e: Expected O, but got Ref
		//IL_02cd: Expected I4, but got O
		//IL_02cd: Expected O, but got I
		//IL_0359: Expected I4, but got O
		//IL_0359: Expected O, but got I
		bool flag = _spawnedSelectables == null;
		ProgrammaticUI programmaticUI = this;
		if (!flag)
		{
			float num = 0f;
			List<ISelectableUI>.Enumerator enumerator = default(List<ISelectableUI>.Enumerator);
			if (enumerator.MoveNext())
			{
				float num2 = 0f;
				List<ISelectableUI>.Enumerator enumerator2 = (List<ISelectableUI>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			bool flag2 = _spawnedUnselectables == null;
			programmaticUI = (ProgrammaticUI)(&enumerator);
			if (!flag2)
			{
				float num3 = 0f;
				List<IUIObject>.Enumerator enumerator3 = default(List<IUIObject>.Enumerator);
				if (enumerator3.MoveNext())
				{
					float num4 = 0f;
					List<IUIObject>.Enumerator enumerator4 = (List<IUIObject>.Enumerator)(&enumerator3);
					throw new NullReferenceException();
				}
				programmaticUI = (ProgrammaticUI)(object)_spawnedSelectables;
				if (_spawnedSelectables != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v4 (VampireSurvivors.App.Scripts.UI.ProgrammaticUI)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)programmaticUI).m_CancellationTokenSource = null;
					if ((nint)((MonoBehaviour)programmaticUI).m_CancellationTokenSource > 0)
					{
						Array.Clear((Array)(nint)((UnityEngine.Object)programmaticUI).m_CachedPtr, 0, (int)((MonoBehaviour)programmaticUI).m_CancellationTokenSource);
					}
					programmaticUI = (ProgrammaticUI)(object)_spawnedUnselectables;
					if (_spawnedUnselectables != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v4 (VampireSurvivors.App.Scripts.UI.ProgrammaticUI)+1C]");
						_ = (nint)0 + (nint)1;
						((MonoBehaviour)programmaticUI).m_CancellationTokenSource = null;
						if ((nint)((MonoBehaviour)programmaticUI).m_CancellationTokenSource > 0)
						{
							Array.Clear((Array)(nint)((UnityEngine.Object)programmaticUI).m_CachedPtr, 0, (int)((MonoBehaviour)programmaticUI).m_CancellationTokenSource);
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private string Translate(string term)
	{
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		return LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
	}

	public void ShowLoading(string message)
	{
		Debug.Log("SHOW LOADING BLOCK");
		string accountTranslation = AccountPage.GetAccountTranslation("common_loading_popup_title");
		Action onClose = default(Action);
		PopupManager.CreateAccountBlockingPopup("account-loading", accountTranslation, message, textisLocalizationTerm: false, onClose);
	}

	public virtual void SelectFirstSelectable()
	{
		//IL_0065: Expected O, but got I4
		//IL_0141: Expected O, but got I4
		//IL_0159->IL015f: Incompatible stack heights: 3 vs 0
		//IL_00c7->IL015e: Incompatible stack heights: 4 vs 0
		if (_spawnedSelectables != null)
		{
			List<ISelectableUI> spawnedSelectables = _spawnedSelectables;
			if (spawnedSelectables._size > 0)
			{
				List<ISelectableUI>.Enumerator enumerator = default(List<ISelectableUI>.Enumerator);
				object obj2 = default(object);
				while (enumerator.MoveNext())
				{
					bool flag = enumerator.MoveNext();
					bool flag2 = !flag;
					GameObject gameObject = ((Component)flag).gameObject;
					bool flag3 = (object)gameObject == null;
					bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
						bool flag5 = obj2 == null;
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v700 @ rdx_v19+398] (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		Selectable component = BackButtonController.Instance.GetComponent<Selectable>();
		component.Select();
	}

	public unsafe void SelectFirstSelectable(List<GameObject> ignoreObjects)
	{
		//IL_0041: Expected O, but got Ref
		if (_spawnedSelectables != null)
		{
			List<ISelectableUI> spawnedSelectables = _spawnedSelectables;
			List<ISelectableUI>.Enumerator enumerator = default(List<ISelectableUI>.Enumerator);
			if (spawnedSelectables._size > 0 && enumerator.MoveNext())
			{
				List<ISelectableUI>.Enumerator enumerator2 = (List<ISelectableUI>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
		Selectable component = BackButtonController.Instance.GetComponent<Selectable>();
		component.Select();
	}

	public void HideLoading()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("account-loading");
	}

	public void ShowOkPopup(string title, string description, Action callback)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		PopupManager.CreateWarningPopup("programmatic-ui-popup", title, description, callback, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
	}

	public void ShowAccountErrorPopup(string title, string description, string helpText, Action callback)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Action callback2 = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		bool helpTextIsLocalizationTerm = default(bool);
		PopupManager.CreateAccountErrorPopup("programmatic-ui-account-error-popup", title, description, helpText, callback2, titleIsLocalizationTerm, descriptionIsLocalizationTerm, helpTextIsLocalizationTerm);
	}

	public void ShowYesNoPopup(string title, string description, Action yesCallback, Action noCallback)
	{
		//IL_0082: Expected I4, but got O
		//IL_0082: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E70]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string translation = AccountPage.GetTranslation("options_yes");
		string translation2 = AccountPage.GetTranslation("options_no");
		string button2Text = default(string);
		Action button1Callback = default(Action);
		Action button2Callback = default(Action);
		bool titleIsLocalizationTerm = default(bool);
		bool button2TextIsLocalizationTerm = default(bool);
		PopupManager.CreateTwoButtonPopup("programmatic-ui-two-btn-popup", title, description, translation, button2Text, button1Callback, button2Callback, titleIsLocalizationTerm, (byte)(int)translation2 != 0, (byte)(int)yesCallback != 0, button2TextIsLocalizationTerm);
	}

	public unsafe void GenerateNavigation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_009f: Expected O, but got I4
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_014b: Expected I, but got O
		//IL_0183: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_054d: Expected O, but got Ref
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_041c: Expected O, but got I4
		//IL_0465: Expected O, but got I4
		//IL_02ec: Expected O, but got Ref
		//IL_0302: Expected O, but got I
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_049b: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (_spawnedSelectables != null)
		{
			List<ISelectableUI> spawnedSelectables = _spawnedSelectables;
			if (spawnedSelectables._size > 0)
			{
				Func<ISelectableUI, bool> predicate = _003C_003Ec._003C_003E9__39_0;
				if (_003C_003Ec._003C_003E9__39_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__39_0 = delegate(ISelectableUI ui)
					{
						if (ui != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							Component component = default(Component);
							if ((object)component != null)
							{
								GameObject gameObject = component.gameObject;
								if ((object)gameObject != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v10 (UnityEngine.GameObject)+10]");
									bool flag3 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 87 ConditionalJump @-1, v147 @ ZF_v9 (System.Boolean) --- -1 Nop");
									/*Error: End of method reached without returning.*/;
								}
							}
						}
						throw new NullReferenceException();
					});
					Selectable selectable = null;
				}
				IEnumerable<ISelectableUI> enumerable = Enumerable.Where(spawnedSelectables, predicate);
				if (enumerable != null)
				{
					List<object> list = new List<object>(enumerable);
					Selectable selectable2 = null;
					object obj3 = 0;
					IEnumerable<object> enumerable2 = null;
					IEnumerable<object> enumerable3 = enumerable;
					IEnumerable<object> enumerable4 = null;
					object obj11 = default(object);
					Selectable selectable6 = default(Selectable);
					object obj15 = default(object);
					object obj16 = default(object);
					Selectable selectable8 = default(Selectable);
					Selectable selectable9 = default(Selectable);
					while (true)
					{
						object obj4;
						object obj5;
						ISelectableUI selectableUI;
						if ((nint)enumerable4 < list._size)
						{
							obj4 = enumerable2 - 1;
							obj5 = enumerable2 + 1;
							if ((nint)enumerable2 >= list._size)
							{
								break;
							}
							object[] items = list._items;
							selectableUI = (ISelectableUI)items[(object)enumerable2];
							nint num = (nint)selectableUI;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r10_v5 (Il2CppClass<VampireSurvivors.UI.ISelectableUI>)+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_01bf;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r10_v5 (Il2CppClass<VampireSurvivors.UI.ISelectableUI>)+B0]");
							object obj6 = 0;
							IEnumerable<object> enumerable5 = null;
							while (true)
							{
								object obj7 = (object)enumerable5 + (object)enumerable5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ r8_v48+v932 @ rax_v109*8]");
								if (0 == (nint)typeof(ISelectableUI))
								{
									break;
								}
								enumerable5 = (IEnumerable<object>)(enumerable5 + 1);
								IEnumerable<object> enumerable6 = enumerable5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ r10_v5 (Il2CppClass<VampireSurvivors.UI.ISelectableUI>)+12E]");
								if ((nint)enumerable6 < 0)
								{
									continue;
								}
								goto IL_01bf;
							}
							object obj8 = (object)enumerable5 + (object)enumerable5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v929 @ r8_v48+8+v1030 @ rcx_v66*8]");
							object obj9 = (nint)0 << 4;
							object obj10 = obj9 + 312;
							obj11 = obj10 + num;
							goto IL_01ce;
						}
						Selectable onDown = OnDown;
						bool flag = (object)OnDown == null;
						Navigation navigation = (Navigation)enumerable3;
						Selectable selectable3 = (Selectable)(object)typeof(UnityEngine.Object);
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)onDown).m_CachedPtr == (IntPtr)0;
							navigation = (Navigation)enumerable3;
							selectable3 = (Selectable)(object)typeof(UnityEngine.Object);
							if (!flag2)
							{
								Selectable onDown2 = OnDown;
								List<ISelectableUI> spawnedSelectables2 = _spawnedSelectables;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v71 (UnityEngine.UI.Selectable)+48]");
								_ = 0;
								_ = onDown2.m_Navigation;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v71 (UnityEngine.UI.Selectable)+38]");
								_ = 0;
								object obj12 = spawnedSelectables2._size - 1;
								if ((nint)obj12 >= list._size)
								{
									break;
								}
								object[] items2 = list._items;
								object obj13 = spawnedSelectables2._size - 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
								selectable3 = OnDown;
								navigation = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
								_ = 0;
								OnDown.navigation = navigation;
							}
						}
						if (list._size > 0)
						{
							if (list._size <= 0)
							{
								break;
							}
							((List<ISelectableUI>)(object)selectable3)._002Ector((IEnumerable<ISelectableUI>)navigation);
						}
						IEnumerable<ISelectableUI> collection = (IEnumerable<ISelectableUI>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						_ = 0;
						_ = 0;
						((List<ISelectableUI>)(object)SignalBus)._002Ector(collection);
						return;
						IL_01bf:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						goto IL_01ce;
						IL_01ce:
						object obj14 = obj11;
						Selectable selectable4 = selectableUI.GetSelectable();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ rax_v90 (UnityEngine.UI.Selectable)+48]");
						_ = 0;
						Selectable selectable5;
						if ((nint)obj4 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							selectable5 = selectable6;
							obj14 = obj15;
						}
						else
						{
							selectable5 = OnUp;
						}
						Selectable selectable7;
						if ((nint)obj5 >= list._size)
						{
							selectable7 = OnDown;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
							obj14 = obj16;
							selectable7 = selectable8;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BB80");
						Navigation navigation2 = (Navigation)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
						_ = 4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
						obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
						_ = 0;
						selectable9.navigation = navigation2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						((List<ISelectableUI>)(object)list)._002Ector((IEnumerable<ISelectableUI>)enumerable2);
						enumerable2 = (IEnumerable<object>)(enumerable2 + 1);
						selectable2 = selectable7;
						enumerable3 = enumerable2;
						Selectable selectable = selectable5;
						enumerable4 = enumerable2;
					}
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					throw new NullReferenceException();
				}
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
		}
		Debug.LogWarning("Cannot generate navigation in OptionsController as the _spawnedElements list is empty");
	}

	protected ProgrammaticUI()
	{
		List<ISelectableUI> spawnedSelectables = new List<ISelectableUI>();
		_spawnedSelectables = spawnedSelectables;
		_spawnedUnselectables = new List<IUIObject>();
		base._002Ector();
	}
}
