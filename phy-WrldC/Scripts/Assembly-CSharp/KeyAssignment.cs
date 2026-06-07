using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyAssignment : MonoBehaviour
{
	[SerializeField]
	private KeyCode key;

	[SerializeField]
	private AxisCode axis = AxisCode.None;

	[SerializeField]
	private bool isAxisCaptureEnabled = true;

	[SerializeField]
	private bool isAxisSensitive;

	[SerializeField]
	private Color disabledKeyColor;

	[SerializeField]
	private Color disabledLabelColor;

	private Toggle toggle;

	private TextMeshProUGUI keyText;

	private TextMeshProUGUI labelText;

	private Image keyImage;

	private TextMeshProUGUI axisSensitiveIcon;

	private TextMeshProUGUI keyControlledByLogicIcon;

	private bool shouldCaptureKey;

	private Color originalKeyColor;

	private Color originalLabelColor;

	private bool isAlreadyInitialized;

	public KeyCode Key => key;

	public AxisCode Axis => axis;

	public bool IsAxisEnabled { get; set; }

	public string PressAKeyText { get; set; }

	public bool IsInteractable
	{
		set
		{
			keyText.color = (value ? originalKeyColor : disabledKeyColor);
			labelText.color = (value ? originalLabelColor : disabledLabelColor);
			toggle.interactable = value;
		}
	}

	public bool IsAxisSensitive
	{
		get
		{
			return isAxisSensitive;
		}
		set
		{
			isAxisSensitive = value;
			axisSensitiveIcon.gameObject.SetActive(isAxisSensitive);
		}
	}

	public bool IsKeyControlledByLogic
	{
		get
		{
			return keyControlledByLogicIcon.gameObject.activeSelf;
		}
		set
		{
			keyControlledByLogicIcon.gameObject.SetActive(value);
		}
	}

	public event Action<KeyCode, AxisCode> OnKeyAssignment;

	public event Action OnKeyBeginingAssigment;

	public event Action OnKeyEndingAssigment;

	private void Awake()
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(OnValueChangedEvent);
		keyText = base.transform.FindComponent<TextMeshProUGUI>("Label", isRecursively: true);
		labelText = base.transform.FindComponent<TextMeshProUGUI>("LabelText", isRecursively: true);
		keyImage = base.transform.FindComponent<Image>("Image", isRecursively: true);
		axisSensitiveIcon = base.transform.FindComponent<TextMeshProUGUI>("AxisSensitiveIcon", isRecursively: true);
		keyControlledByLogicIcon = base.transform.FindComponent<TextMeshProUGUI>("LogicIcon", isRecursively: true);
		axisSensitiveIcon.gameObject.SetActive(isAxisSensitive);
		keyControlledByLogicIcon.gameObject.SetActive(value: false);
		originalKeyColor = keyText.color;
		originalLabelColor = labelText.color;
		shouldCaptureKey = false;
		PressAKeyText = "Press a key";
		IsAxisEnabled = true;
		isAlreadyInitialized = true;
	}

	private void Update()
	{
		if (!shouldCaptureKey)
		{
			return;
		}
		if (Input.anyKeyDown)
		{
			KeyCode keyCode = KeyCode.None;
			foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
			{
				if (Input.GetKey(value))
				{
					keyCode = value;
				}
			}
			if (IsKeyAllowed(keyCode))
			{
				switch (keyCode)
				{
				case KeyCode.Escape:
				case KeyCode.Mouse0:
					toggle.isOn = false;
					SetKey(key, axis);
					this.OnKeyEndingAssigment?.Invoke();
					shouldCaptureKey = false;
					return;
				case KeyCode.Backspace:
				case KeyCode.Delete:
					keyCode = KeyCode.None;
					break;
				}
				key = keyCode;
				axis = AxisCode.None;
				this.OnKeyAssignment?.Invoke(key, axis);
				toggle.isOn = false;
				SetKey(key, axis);
				this.OnKeyEndingAssigment?.Invoke();
				shouldCaptureKey = false;
			}
		}
		else
		{
			if (!IsAxisEnabled || !isAxisCaptureEnabled)
			{
				return;
			}
			bool flag = false;
			foreach (AxisCode value2 in Enum.GetValues(typeof(AxisCode)))
			{
				if (value2 == AxisCode.None)
				{
					continue;
				}
				if (Util.IsAxisCodePositive(value2))
				{
					if (Input.GetAxis(value2.ToString()) >= 0.5f)
					{
						axis = value2;
						flag = true;
					}
				}
				else if (Input.GetAxis(value2.ToString()) <= -0.5f)
				{
					axis = value2;
					flag = true;
				}
			}
			if (flag)
			{
				key = KeyCode.None;
				this.OnKeyAssignment?.Invoke(key, axis);
				toggle.isOn = false;
				SetKey(key, axis);
				this.OnKeyEndingAssigment?.Invoke();
				shouldCaptureKey = false;
			}
		}
	}

	private void OnDisable()
	{
		if (shouldCaptureKey)
		{
			toggle.isOn = false;
			SetKey(key, axis);
			this.OnKeyEndingAssigment?.Invoke();
			shouldCaptureKey = false;
		}
	}

	public void AddListener(Action<KeyCode, AxisCode> newEvent)
	{
		OnKeyAssignment += newEvent;
	}

	public void RemoveAllListeners()
	{
		this.OnKeyAssignment = null;
	}

	public void SetKey(KeyCode key, AxisCode axis = AxisCode.None)
	{
		this.key = key;
		if (key != KeyCode.None)
		{
			Sprite sprite = Util.ConvertKeyCodeToSprite(key);
			if (sprite != null)
			{
				keyText.enabled = false;
				keyImage.enabled = true;
				keyImage.sprite = sprite;
			}
			else
			{
				keyText.enabled = true;
				keyImage.enabled = false;
				keyText.SetText(Util.ConvertKeyCodeToString(key));
			}
			this.axis = AxisCode.None;
		}
		else
		{
			Sprite sprite2 = Util.ConvertAxisCodeToSprite(axis);
			if (sprite2 != null)
			{
				keyText.enabled = false;
				keyImage.enabled = true;
				keyImage.sprite = sprite2;
			}
			else
			{
				keyText.enabled = true;
				keyImage.enabled = false;
				keyText.SetText(axis.ToString());
			}
			this.axis = axis;
		}
	}

	public void SetLabel(string label)
	{
		labelText.SetText(label);
	}

	public string GetLabel()
	{
		return labelText.GetParsedText();
	}

	private void OnValueChangedEvent(bool value)
	{
		shouldCaptureKey = value;
		if (shouldCaptureKey)
		{
			keyText.enabled = true;
			keyImage.enabled = false;
			keyText.SetText(PressAKeyText);
			this.OnKeyBeginingAssigment?.Invoke();
		}
	}

	private bool IsKeyAllowed(KeyCode key)
	{
		if ((uint)(key - 324) <= 5u)
		{
			return false;
		}
		return true;
	}
}
