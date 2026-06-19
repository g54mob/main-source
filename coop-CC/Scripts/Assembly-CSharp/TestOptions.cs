using System.Collections;
using Aggro.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TestOptions : MonoBehaviour, IInputController
{
	public Transform parent;

	private void Start()
	{
		StartCoroutine(LoadCo());
	}

	private IEnumerator LoadCo()
	{
		yield return GameUtil.InitializeGameCo();
		yield return SceneManager.LoadSceneAsync("scene-debug", LoadSceneMode.Additive);
		AggroInputManager.Enable();
		yield return null;
		AggroInputManager.PushController(this);
		while (true)
		{
			yield return null;
			if (!AggroSettings.isShowing)
			{
				if (Keyboard.current.escapeKey.wasPressedThisFrame)
				{
					AggroSettings.ShowSettings("game", parent, InputMode.KBM);
				}
				else if (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
				{
					AggroSettings.ShowSettings("game", parent, InputMode.Gamepad);
				}
			}
			AggroInputManager.Update();
			if (AggroSettings.isShowing && AggroInputManager.mode != AggroSettings.inputMode)
			{
				AggroSettings.SetInputMode(AggroInputManager.mode);
			}
		}
	}

	public void OnInputControlGained()
	{
		AggroInputManager.EnableUIModule();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.DisableUIModule();
	}
}
