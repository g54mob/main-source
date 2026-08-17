using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Doozy.Examples;

public class E11PopupScriptOne : MonoBehaviour
{
	public string PopupName;

	public string Title;

	public string Message;

	public bool HideOnBackButton;

	public bool HideOnClickAnywhere;

	public bool HideOnClickOverlay;

	public bool HideOnClickContainer;

	public InputField TitleInput;

	public InputField MessageInput;

	public Toggle BackButtonToggle;

	public Toggle ClickAnywhereToggle;

	public Toggle ClickOverlayToggle;

	public Toggle ClickContainerToggle;

	private void OnEnable()
	{
		//IL_013a: Expected I4, but got O
		//IL_016f: Expected I4, but got O
		//IL_01a4: Expected I4, but got O
		//IL_01d9: Expected I4, but got O
		TitleInput.SetText(Title, true);
		MessageInput.SetText(Message, true);
		InputField titleInput = TitleInput;
		UnityAction<string> call = delegate(string value)
		{
			Title = value;
		};
		titleInput.m_OnDidEndEdit.AddListener(call);
		InputField messageInput = MessageInput;
		UnityAction<string> call2 = delegate(string value)
		{
			Message = value;
		};
		messageInput.m_OnDidEndEdit.AddListener(call2);
		Toggle backButtonToggle = BackButtonToggle;
		HideOnBackButton = backButtonToggle.m_IsOn;
		Toggle clickAnywhereToggle = ClickAnywhereToggle;
		HideOnClickAnywhere = clickAnywhereToggle.m_IsOn;
		Toggle clickOverlayToggle = ClickOverlayToggle;
		HideOnClickOverlay = clickOverlayToggle.m_IsOn;
		Toggle clickContainerToggle = ClickContainerToggle;
		HideOnClickContainer = clickContainerToggle.m_IsOn;
		Toggle backButtonToggle2 = BackButtonToggle;
		UnityAction<bool> unityAction = null;
		((E11PopupScriptOne)(object)unityAction)._003COnEnable_003Eb__13_2((byte)(int)this != 0);
		backButtonToggle2.onValueChanged.AddListener(unityAction);
		Toggle clickAnywhereToggle2 = ClickAnywhereToggle;
		UnityAction<bool> unityAction2 = null;
		((E11PopupScriptOne)(object)unityAction2)._003COnEnable_003Eb__13_3((byte)(int)this != 0);
		clickAnywhereToggle2.onValueChanged.AddListener(unityAction2);
		Toggle clickOverlayToggle2 = ClickOverlayToggle;
		UnityAction<bool> unityAction3 = null;
		((E11PopupScriptOne)(object)unityAction3)._003COnEnable_003Eb__13_4((byte)(int)this != 0);
		clickOverlayToggle2.onValueChanged.AddListener(unityAction3);
		Toggle clickContainerToggle2 = ClickContainerToggle;
		UnityAction<bool> unityAction4 = null;
		((E11PopupScriptOne)(object)unityAction4)._003COnEnable_003Eb__13_5((byte)(int)this != 0);
		clickContainerToggle2.onValueChanged.AddListener(unityAction4);
	}

	private void OnDisable()
	{
		InputField titleInput = TitleInput;
		titleInput.m_OnDidEndEdit.RemoveAllListeners();
		InputField messageInput = MessageInput;
		messageInput.m_OnDidEndEdit.RemoveAllListeners();
		Toggle backButtonToggle = BackButtonToggle;
		backButtonToggle.onValueChanged.RemoveAllListeners();
		Toggle clickAnywhereToggle = ClickAnywhereToggle;
		clickAnywhereToggle.onValueChanged.RemoveAllListeners();
		Toggle clickOverlayToggle = ClickOverlayToggle;
		clickOverlayToggle.onValueChanged.RemoveAllListeners();
		Toggle clickContainerToggle = ClickContainerToggle;
		clickContainerToggle.onValueChanged.RemoveAllListeners();
	}

	public unsafe void ShowPopup()
	{
		//IL_01bf: Expected Ref, but got F4
		UIPopup popup = UIPopupManager.GetPopup(PopupName);
		if ((object)popup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v5 (Doozy.Engine.UI.UIPopup)+10]");
		if ((nint)0 != 0)
		{
			string[] labelsTexts = new string[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			popup.Data.SetLabelsTexts(labelsTexts);
			popup.HideOnBackButton = HideOnBackButton;
			popup.HideOnClickAnywhere = HideOnClickAnywhere;
			popup.HideOnClickOverlay = HideOnClickOverlay;
			popup.HideOnClickContainer = HideOnClickContainer;
			if (!HideOnBackButton && !HideOnClickAnywhere && !HideOnClickOverlay && !HideOnClickContainer)
			{
				popup.AutoHideAfterShow = true;
				popup.AutoHideAfterShowDelay = 3f;
				string[] array = new string[5];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				float num = (float)popup + 100f;
				string text = ((float*)num)->ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				DDebug.Log(message);
			}
			popup.Show();
		}
	}

	public E11PopupScriptOne()
	{
		//IL_0073: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA41]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupName = "Popup1";
		Title = "Example Title";
		Message = "This is an example message for this UIPopup";
		HideOnBackButton = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rcx_v7 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003COnEnable_003Eb__13_0(string value)
	{
		Title = value;
	}

	private void _003COnEnable_003Eb__13_1(string value)
	{
		Message = value;
	}

	private void _003COnEnable_003Eb__13_2(bool value)
	{
		HideOnBackButton = value;
	}

	private void _003COnEnable_003Eb__13_3(bool value)
	{
		HideOnClickAnywhere = value;
	}

	private void _003COnEnable_003Eb__13_4(bool value)
	{
		HideOnClickOverlay = value;
	}

	private void _003COnEnable_003Eb__13_5(bool value)
	{
		HideOnClickContainer = value;
	}
}
