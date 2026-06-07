using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class Toast : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private LocalizeStringHandler titleHandler;

	[SerializeField]
	private LocalizeStringHandler descriptionHandler;

	[SerializeField]
	private Image image;

	private Action _toastClicked;

	public void Setup(LocalizedString title, LocalizedString description, Sprite sprite, Action callback)
	{
		titleHandler.SetLocalizedString(title);
		descriptionHandler.SetLocalizedString(description);
		image.overrideSprite = sprite;
		_toastClicked = callback;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		_toastClicked?.Invoke();
	}
}
