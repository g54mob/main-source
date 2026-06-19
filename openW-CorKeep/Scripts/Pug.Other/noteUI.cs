using Pug.UnityExtensions;
using UnityEngine;

public class noteUI : MonoBehaviour
{
	[SerializeField]
	private PlayerInput.InputType _input;

	public PugText buttonText;

	private float octaveYDif = 2.4375f;

	private float yOffset = -0.4625f;

	private float sharpYOffset = 0.5625f;

	private float sharpXOffset;

	public bool onUpperOctave;

	public bool isSharp;

	private void LateUpdate()
	{
		bool flag = Manager.main.player.inputModule.PrefersKeyboardAndMouse();
		if (!isSharp)
		{
			sharpYOffset = 0f;
		}
		sharpXOffset = 0f;
		if (!isSharp || flag)
		{
			sharpXOffset = -0.0625f;
		}
		bool num = Manager.main.player.inputModule.IsButtonCurrentlyDown(PlayerInput.InputType.OCTAVE_CHANGE);
		bool prefersJoystick = Manager.input.IsAnyGamepadConnected() && !Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse();
		string shortCutString = Manager.ui.GetShortCutString((int)_input, prefersJoystick, onlyReturnShortCutForActiveController: true);
		bool flag2 = !string.IsNullOrEmpty(shortCutString);
		buttonText.Render(shortCutString);
		if (num)
		{
			buttonText.transform.SetLocalPosition(sharpXOffset, yOffset + octaveYDif + sharpYOffset);
			if (onUpperOctave)
			{
				buttonText.gameObject.SetActive(value: false);
			}
		}
		else
		{
			buttonText.transform.SetLocalPosition(sharpXOffset, yOffset + sharpYOffset);
			if (!flag2 && onUpperOctave)
			{
				buttonText.gameObject.SetActive(value: false);
			}
			else
			{
				buttonText.gameObject.SetActive(value: true);
			}
		}
	}
}
