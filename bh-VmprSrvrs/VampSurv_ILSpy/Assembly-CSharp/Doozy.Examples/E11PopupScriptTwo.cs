using Cpp2ILInjected;
using Doozy.Engine.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Doozy.Examples;

public class E11PopupScriptTwo : MonoBehaviour
{
	public string PopupName;

	public string Title;

	public string Message;

	public string LabelButtonOne;

	public string LabelButtonTwo;

	public bool HideOnButtonOne;

	public bool HideOnButtonTwo;

	public InputField TitleInput;

	public InputField MessageInput;

	public InputField LabelButtonOneInput;

	public InputField LabelButtonTwoInput;

	public Toggle ButtonOneToggle;

	public Toggle ButtonTwoToggle;

	private UIPopup m_popup;

	private void OnEnable()
	{
		//IL_0134: Expected I4, but got O
		//IL_0169: Expected I4, but got O
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
		LabelButtonOneInput.SetText(LabelButtonOne, true);
		LabelButtonTwoInput.SetText(LabelButtonTwo, true);
		Toggle buttonOneToggle = ButtonOneToggle;
		HideOnButtonOne = buttonOneToggle.m_IsOn;
		Toggle buttonTwoToggle = ButtonTwoToggle;
		HideOnButtonTwo = buttonTwoToggle.m_IsOn;
		Toggle buttonOneToggle2 = ButtonOneToggle;
		UnityAction<bool> unityAction = null;
		((E11PopupScriptTwo)(object)unityAction)._003COnEnable_003Eb__14_2((byte)(int)this != 0);
		buttonOneToggle2.onValueChanged.AddListener(unityAction);
		Toggle buttonTwoToggle2 = ButtonTwoToggle;
		UnityAction<bool> unityAction2 = null;
		((E11PopupScriptTwo)(object)unityAction2)._003COnEnable_003Eb__14_3((byte)(int)this != 0);
		buttonTwoToggle2.onValueChanged.AddListener(unityAction2);
	}

	private void OnDisable()
	{
		InputField titleInput = TitleInput;
		titleInput.m_OnDidEndEdit.RemoveAllListeners();
		InputField messageInput = MessageInput;
		messageInput.m_OnDidEndEdit.RemoveAllListeners();
		InputField labelButtonOneInput = LabelButtonOneInput;
		labelButtonOneInput.m_OnDidEndEdit.RemoveAllListeners();
		InputField labelButtonTwoInput = LabelButtonTwoInput;
		labelButtonTwoInput.m_OnDidEndEdit.RemoveAllListeners();
		Toggle buttonOneToggle = ButtonOneToggle;
		buttonOneToggle.onValueChanged.RemoveAllListeners();
		Toggle buttonTwoToggle = ButtonTwoToggle;
		buttonTwoToggle.onValueChanged.RemoveAllListeners();
	}

	public void ShowPopup()
	{
		UIPopup popup = UIPopupManager.GetPopup(PopupName);
		m_popup = popup;
		UIPopup popup2 = m_popup;
		if ((object)m_popup == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rbx_v2 (Doozy.Engine.UI.UIPopup)+10]");
		if ((nint)0 != 0)
		{
			UIPopup popup3 = m_popup;
			string[] labelsTexts = new string[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			popup3.Data.SetLabelsTexts(labelsTexts);
			InputField labelButtonOneInput = LabelButtonOneInput;
			LabelButtonOne = labelButtonOneInput.m_Text;
			InputField labelButtonTwoInput = LabelButtonTwoInput;
			LabelButtonTwo = labelButtonTwoInput.m_Text;
			UIPopup popup4 = m_popup;
			string[] buttonsLabels = new string[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			popup4.Data.SetButtonsLabels(buttonsLabels);
			UIPopup popup5 = m_popup;
			UnityAction[] buttonsCallbacks = new UnityAction[2];
			UnityAction unityAction = ClickButtonOne;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UnityAction unityAction2 = ClickButtonTwo;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			popup5.Data.SetButtonsCallbacks(buttonsCallbacks);
			if (!HideOnButtonOne && !HideOnButtonTwo)
			{
				UIPopup popup6 = m_popup;
				popup6.HideOnClickOverlay = true;
				string message = "Popup '" + PopupName + "' is set to close when clicking its Overlay because you did not enable any hide option";
				DDebug.Log(message);
			}
			m_popup.Show();
		}
	}

	private void ClickButtonOne()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA46]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string message = "Clicked button ONE: " + LabelButtonOne;
		DDebug.Log(message);
		if (HideOnButtonOne)
		{
			ClosePopup();
		}
	}

	private void ClickButtonTwo()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA47]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string message = "Clicked button TWO: " + LabelButtonTwo;
		DDebug.Log(message);
		if (HideOnButtonTwo)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 43 Invalid \"Jump target not found in method: 0x180B86D00\"");
		}
	}

	private void ClosePopup()
	{
		UIPopup popup = m_popup;
		if ((object)m_popup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rbx_v1 (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				m_popup.Hide();
			}
		}
	}

	public E11PopupScriptTwo()
	{
		//IL_0083: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA49]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupName = "Popup2";
		Title = "Example Title";
		Message = "This is an example message for this UIPopup";
		LabelButtonOne = "Yes";
		LabelButtonTwo = "No";
		HideOnButtonOne = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v9 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003COnEnable_003Eb__14_0(string value)
	{
		Title = value;
	}

	private void _003COnEnable_003Eb__14_1(string value)
	{
		Message = value;
	}

	private void _003COnEnable_003Eb__14_2(bool value)
	{
		HideOnButtonOne = value;
	}

	private void _003COnEnable_003Eb__14_3(bool value)
	{
		HideOnButtonTwo = value;
	}
}
