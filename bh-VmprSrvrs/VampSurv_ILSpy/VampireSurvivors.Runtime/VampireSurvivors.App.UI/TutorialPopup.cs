using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI;

public class TutorialPopup : BasePopup
{
	public delegate void OnOkButtonClicked();

	private sealed class _003CWaitAndSelect_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TutorialPopup _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0135: Expected I4, but got O
			TutorialPopup tutorialPopup = _003C_003E4__this;
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
				EventSystem current = EventSystem.current;
				if ((object)current != null && (object)current.m_CurrentSelected != null)
				{
					Selectable component = current.m_CurrentSelected.GetComponent<Selectable>();
					if ((object)_003C_003E4__this != null)
					{
						tutorialPopup._previousSelection = component;
						if ((object)tutorialPopup._OkButton != null)
						{
							tutorialPopup._OkButton.Select();
							goto IL_0161;
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_0161;
			IL_0161:
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

	private Button _OkButton;

	private RectTransform _Panel;

	private TextMeshProUGUI _TitleText;

	private TextMeshProUGUI _DescriptionText;

	private OnOkButtonClicked m_OKButtonClicked;

	private PlayerOptions _playerOptions;

	private Selectable _previousSelection;

	public event OnOkButtonClicked OKButtonClicked
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 104;
			Delegate obj2 = this.m_OKButtonClicked;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnOkButtonClicked);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 104;
			Delegate obj2 = this.m_OKButtonClicked;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(OnOkButtonClicked);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		Button okButton = _OkButton;
		okButton.m_OnClick.RemoveAllListeners();
		_OkButton.interactable = false;
	}

	private void Update()
	{
	}

	public void Initialize(string id, string titleTerm, string descriptionTerm, string buttonTerm)
	{
		_ID = id;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(titleTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_TitleText.text = translation;
		string translation2 = LocalizationManager.GetTranslation(descriptionTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_DescriptionText.text = translation2;
		TextMeshProUGUI componentInChildren = _OkButton.GetComponentInChildren<TextMeshProUGUI>();
		string term = default(string);
		string translation3 = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		componentInChildren.text = translation3;
		Canvas component = GetComponent<Canvas>();
	}

	public override void Show()
	{
		//IL_005c: Expected O, but got I8
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0284: Expected O, but got I4
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		Transform transform = _Panel.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_Panel, 1f, 0.2f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
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
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rbp_v2+462E0+v374 @ rdx_v20*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rbp_v2+462E0+v374 @ rdx_v20*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rbp_v2+462E0+v374 @ rdx_v20*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rbp_v2+462E0+v374 @ rdx_v20*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rbp_v2+462E0+v374 @ rdx_v20*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						//IL_0020: Expected I, but got O
						Button okButton = _OkButton;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v2 (Il2CppClass<VampireSurvivors.App.UI.TutorialPopup>)+190]");
						UnityAction call = new UnityAction(this, (IntPtr)0);
						nint num3 = (nint)this;
						okButton.m_OnClick.AddListener(call);
						_OkButton.interactable = true;
					};
					tweenCallback2 = tweenCallback;
					goto IL_0182;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			//IL_0020: Expected I, but got O
			Button okButton = _OkButton;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v2 (Il2CppClass<VampireSurvivors.App.UI.TutorialPopup>)+190]");
			UnityAction call = new UnityAction(this, (IntPtr)0);
			nint num3 = (nint)this;
			okButton.m_OnClick.AddListener(call);
			_OkButton.interactable = true;
		};
		bool flag3 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag3)
		{
			goto IL_0182;
		}
		goto IL_0246;
		IL_0246:
		_003CWaitAndSelect_003Ed__15 obj9 = null;
		obj9._003C_003E1__state = 0;
		obj9._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj9);
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = false;
		return;
		IL_0182:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0246;
	}

	private IEnumerator WaitAndSelect()
	{
		_003CWaitAndSelect_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override void Hide()
	{
		base.Hide();
		Button okButton = _OkButton;
		okButton.m_OnClick.RemoveAllListeners();
		BackButtonController instance = BackButtonController.Instance;
		instance.ListenForControllerInput = true;
		OnOkButtonClicked oKButtonClicked = this.m_OKButtonClicked;
		if (this.m_OKButtonClicked != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v154.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		Selectable previousSelection = _previousSelection;
		if ((object)_previousSelection != null && ((UnityEngine.Object)previousSelection).m_CachedPtr != (IntPtr)0)
		{
			_previousSelection.Select();
		}
		PopupManager.ClosePopup(_ID);
	}

	private void _003CShow_003Eb__14_0()
	{
		//IL_0020: Expected I, but got O
		Button okButton = _OkButton;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ r8_v2 (Il2CppClass<VampireSurvivors.App.UI.TutorialPopup>)+190]");
		UnityAction call = new UnityAction(this, (IntPtr)0);
		nint num = (nint)this;
		okButton.m_OnClick.AddListener(call);
		_OkButton.interactable = true;
	}
}
