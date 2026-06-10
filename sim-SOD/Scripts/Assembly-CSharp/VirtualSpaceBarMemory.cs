using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualSpaceBarMemory : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	private ButtonController _buttonController;

	private Rewired.Player _player;

	public GameObject lastSelectedButton;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	private void GetLastVirtualKeyboardCharacterButton()
	{
	}

	public void OnSelect(BaseEventData eventData)
	{
	}
}
