using Aggro.Core;
using UnityEngine;

public class InputModeSwap : EntityBehaviourBase
{
	public GameObject[] gamePadEnable;

	public GameObject[] kbmEnable;

	private InputMode _prevMode;

	private void OnEnable()
	{
		SetGameObjects();
	}

	[UpdateInGroup(-10)]
	protected override void OnUpdatePresentationLate()
	{
		if (_prevMode != AggroInputManager.mode)
		{
			SetGameObjects();
		}
	}

	private void SetGameObjects()
	{
		_prevMode = AggroInputManager.mode;
		GameObject[] array = ((AggroInputManager.mode == InputMode.Gamepad) ? kbmEnable : gamePadEnable);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		array = ((AggroInputManager.mode == InputMode.Gamepad) ? gamePadEnable : kbmEnable);
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
	}
}
