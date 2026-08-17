using System;
using Cpp2ILInjected;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupQueueData
{
	public UIPopup Popup;

	public string PopupName;

	public bool InstantAction;

	public UIPopupQueueData(UIPopup popup, bool instantAction = false)
	{
		PopupName = popup._003CPopupName_003Ek__BackingField;
		Popup = popup;
		InstantAction = instantAction;
	}

	public UIPopupQueueData(string popupName, UIPopup popup, bool instantAction = false)
	{
		PopupName = popupName;
		Popup = popup;
		InstantAction = instantAction;
	}

	public UIPopup Show()
	{
		UIPopup popup = Popup;
		if ((object)Popup != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (Doozy.Engine.UI.UIPopup)+10]");
			if ((nint)0 != 0)
			{
				if ((object)Popup != null)
				{
					Popup.Show(InstantAction);
					return Popup;
				}
				return (UIPopup)(object)new NullReferenceException();
			}
		}
		return null;
	}
}
