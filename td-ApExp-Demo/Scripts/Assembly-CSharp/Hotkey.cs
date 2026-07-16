using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Hotkey : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private Image image;

	public Image arrowDirectionImg;

	[SerializeField]
	private InputActionReference inputActionRef;

	[SerializeField]
	private Sprite keyboardImage;

	[SerializeField]
	private Sprite gamepadImage;

	public InputActionReference InputActionRef
	{
		get
		{
			return inputActionRef;
		}
		set
		{
			inputActionRef = value;
			UpdateIconAndKey();
		}
	}

	private void Awake()
	{
	}

	public void ShowButtonText(bool show)
	{
		text.enabled = show;
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
	}

	public void UpdateIconAndKey(ControllerType controllerType = ControllerType.KeyboardMouse)
	{
		if (inputActionRef == null)
		{
			ClearIconAndKey();
			Debug.LogError("no inputactionreference on inputhotkeyimage!");
			return;
		}
		InputAssetsSO inputAssets = UIManager.Instance.InputAssetsManager.GetInputAssets(controllerType, inputActionRef);
		if (inputAssets == null)
		{
			ClearIconAndKey();
			return;
		}
		image.enabled = true;
		if (inputAssets.ArrowDirectionIcon == null)
		{
			if (controllerType == ControllerType.KeyboardMouse)
			{
				text.text = inputAssets.KeyChar.ToString();
			}
			else
			{
				text.text = "";
			}
			image.sprite = inputAssets.InputIcon;
		}
		else
		{
			arrowDirectionImg.sprite = inputAssets.ArrowDirectionIcon;
			arrowDirectionImg.enabled = true;
			text.text = "";
		}
	}

	private void ClearIconAndKey()
	{
		image.enabled = false;
		arrowDirectionImg.enabled = false;
		text.text = "";
	}
}
