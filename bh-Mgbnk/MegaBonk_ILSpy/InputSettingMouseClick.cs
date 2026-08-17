using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSettingMouseClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerEnterHandler
{
	public int index;

	public InputSettingNew inputSettingNew;

	public void OnPointerClick(PointerEventData eventData)
	{
		InputSettingNew inputSettingNew = this.inputSettingNew;
		InputSettingNew.selectedIndex = index;
		if (!inputSettingNew.disabledOverlay.activeSelf)
		{
			inputSettingNew.hostage = null;
			List<InputMapper.Context> contexts = (inputSettingNew.isController ? inputSettingNew.GetContextController() : inputSettingNew.GetContextKeyboardAndMouse());
			KeyListener.Instance.StartListening(inputSettingNew, contexts);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}
}
