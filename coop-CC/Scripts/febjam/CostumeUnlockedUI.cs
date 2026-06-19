using System.Collections;
using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class CostumeUnlockedUI : MonoBehaviour, IInputController
{
	public GameObject container;

	public LocalizedText costumeName;

	public Image costumeIcon;

	[Space]
	public GameObject kbmContainer;

	public GameObject gamepadContainer;

	private bool _continue;

	public EaseUI easeUI;

	public GameObject clickCatch;

	private void Awake()
	{
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
	}

	public IEnumerator ShowUnlockCo(CostumeObject costume)
	{
		container.SetActive(value: true);
		clickCatch.SetActive(value: true);
		easeUI.transform.localScale = Vector3.zero;
		easeUI.EaseIn();
		costumeName.SetIndex(costume.costumeName);
		costumeIcon.sprite = costume.costumeTextures[SaveManager.data.GetColorIndex()];
		AggroInputManager.PushController(this);
		_continue = false;
		while (!_continue)
		{
			switch (AggroInputManager.mode)
			{
			case InputMode.KBM:
				kbmContainer.SetActive(value: true);
				gamepadContainer.SetActive(value: false);
				break;
			case InputMode.Gamepad:
				kbmContainer.SetActive(value: false);
				gamepadContainer.SetActive(value: true);
				break;
			default:
				throw new InvalidEnumException();
			}
			yield return null;
			if (AggroInputManager.input.UnlockMenu.Continue.WasPerformedThisFrame())
			{
				_continue = true;
			}
		}
		easeUI.EaseOut();
		yield return new WaitForSeconds(0.3f);
		AggroInputManager.RemoveController(this);
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
	}

	public void OnContinue()
	{
		_continue = true;
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.UnlockMenu.Enable();
		AggroInputManager.EnableUIModule();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.UnlockMenu.Disable();
	}
}
