using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StickyNoteUI : MonoBehaviour
{
	public static event Action OnReadStickyNoteDone;

	private void Start()
	{
		FirstPersonController.S.OnEscPressed += Player_OnEscPressed;
	}

	private void OnDestroy()
	{
		FirstPersonController.S.OnEscPressed -= Player_OnEscPressed;
	}

	private void Player_OnEscPressed()
	{
		if (base.gameObject.activeSelf)
		{
			Cursor.visible = false;
			FirstPersonController.S.canControl = true;
			StickyNoteUI.OnReadStickyNoteDone?.Invoke();
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
		{
			Cursor.visible = false;
			FirstPersonController.S.canControl = true;
			StickyNoteUI.OnReadStickyNoteDone?.Invoke();
			base.gameObject.SetActive(value: false);
		}
	}
}
