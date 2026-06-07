using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SoundOnMouseOver : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ISelectHandler
{
	[SerializeField]
	private string soundDataName;

	[SerializeField]
	private string soundKey;

	[Header("當搖桿選擇時是否做一樣處理")]
	[SerializeField]
	private bool soundOnJoystickSelect;

	[SerializeField]
	private Selectable joystickSelectable;

	private int _lastPlayedFrame;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void PlayOncePerFrame()
	{
	}

	private void OnJoystickSelect()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnSelect(BaseEventData eventData)
	{
	}
}
