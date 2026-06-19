using FMODUnity;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class DemoPopupContent : MonoBehaviour
{
	public LocalizeStringEvent _titleText;

	public LocalizeStringEvent _messageText;

	public LocalizeStringEvent _outgoingButtonText;

	public LocalizeStringEvent _returnButtonText;

	public EventReference LockSound;

	private void OnEnable()
	{
	}

	public void Show(LocalizedString TitleString, LocalizedString MessageString, LocalizedString WishlistButtonString, LocalizedString RejectButtonString)
	{
	}
}
