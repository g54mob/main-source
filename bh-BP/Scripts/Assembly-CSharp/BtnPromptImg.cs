using UnityEngine;
using UnityEngine.UI;

public class BtnPromptImg : MonoBehaviour
{
	public Image TgtImg;

	public bool ShowController;

	public ControllerBtn TgtControllerBtn;

	public bool IsDirectionalFaceBtn;

	public CardinalDir TgtFaceBtnDir;

	public bool ShowKeyboard;

	public KeyboardBtn TgtKeyboardBtn;

	public bool ShowTouch;

	private bool _inited;

	private void Reset()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnInputChanged()
	{
	}
}
