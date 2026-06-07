using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Xamin
{
	[RequireComponent(typeof(AudioSource))]
	public class CircleSelector : MonoBehaviour
	{
		public enum ControlType
		{
			MouseAndTouch = 0,
			Gamepad = 1,
			CustomVector = 2
		}

		public enum ButtonSource
		{
			Prefabs = 0,
			Scene = 1
		}

		public enum AnimationType
		{
			ZoomIn = 0,
			ZoomOut = 1
		}

		[Range(2f, 10f)]
		private int buttonCount;

		private int startButCount;

		[Header("Customization")]
		public Color AccentColor = Color.red;

		public Color DisabledColor = Color.gray;

		public Color BackgroundColor = Color.white;

		[Space(10f)]
		public bool UseSeparators = true;

		[SerializeField]
		private GameObject separatorPrefab;

		[Header("Animations")]
		[Range(0.0001f, 1f)]
		public float LerpAmount = 0.145f;

		public AnimationType OpenAnimation;

		public AnimationType CloseAnimation;

		public float Size = 1f;

		private Image _cursor;

		private Image _background;

		private float _desiredFill;

		private float radius = 120f;

		[Header("Sound")]
		public AudioClip SegmentChangedSound;

		public AudioClip SegmentClickedSound;

		[Header("Text")]
		public TextMeshProUGUI nameText;

		public TextMeshProUGUI descText;

		[Header("Interaction")]
		public List<GameObject> Buttons = new List<GameObject>();

		public ButtonSource buttonSource;

		private readonly List<Button> buttonsInstances = new List<Button>();

		private Vector2 _menuCenter;

		public bool RaiseOnSelection;

		public bool AutoSelection;

		private GameObject _selectedSegment;

		private float _audioCoolDown;

		private bool _previousUseSeparators;

		public bool flip = true;

		public bool selectOnlyOnHover;

		public float pieThickness = 85f;

		public bool snap;

		public bool tiltTowardsMouse;

		public float tiltAmount = 15f;

		private bool opened;

		public InputActionReference gamepadAxis;

		public InputActionReference activationButton;

		[Header("Controls")]
		public ControlType controlType;

		public Vector2 CustomInputVector;

		public UnityEvent closeEvent;

		private AudioSource localAudioSource;

		private Dictionary<GameObject, Button> instancedButtons;

		[HideInInspector]
		public GameObject SelectedSegment
		{
			get
			{
				return _selectedSegment;
			}
			set
			{
				if (value == null || value == SelectedSegment)
				{
					return;
				}
				_selectedSegment = value;
				if (instancedButtons != null && instancedButtons.ContainsKey(_selectedSegment))
				{
					Button button = instancedButtons[_selectedSegment];
					if (nameText != null)
					{
						nameText.text = LocalizationManager.GetTranslation(button.localizationName);
					}
					if (descText != null)
					{
						descText.text = LocalizationManager.GetTranslation(button.localizationDesc);
					}
				}
				if (!(SegmentChangedSound == null) && _audioCoolDown <= 0f)
				{
					localAudioSource.PlayOneShot(SegmentChangedSound);
					_audioCoolDown = 0.05f;
				}
			}
		}

		public static CircleSelector Instance { get; private set; }

		public bool IsOpen => opened;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			instancedButtons = new Dictionary<GameObject, Button>();
			base.transform.localScale = Vector3.zero;
			_cursor = base.transform.Find("Cursor").GetComponent<Image>();
			_background = base.transform.Find("Background").GetComponent<Image>();
			buttonCount = Buttons.Count;
			foreach (Button buttonsInstance in buttonsInstances)
			{
				UnityEngine.Object.Destroy(buttonsInstance.gameObject);
			}
			buttonsInstances.Clear();
			if (buttonCount > 0 && buttonCount < 11)
			{
				startButCount = buttonCount;
				_desiredFill = 1f / (float)buttonCount;
				float num = _desiredFill * 360f;
				float num2 = 0f;
				foreach (Transform item in base.transform.Find("Separators"))
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				for (int i = 0; i < buttonCount; i++)
				{
					GameObject gameObject = ((buttonSource != ButtonSource.Prefabs) ? Buttons[i] : UnityEngine.Object.Instantiate(Buttons[i], Vector2.zero, base.transform.rotation));
					gameObject.transform.SetParent(base.transform.Find("Buttons"));
					float num3 = num2 + num / 2f;
					num2 = num3 + num / 2f;
					GameObject obj = UnityEngine.Object.Instantiate(separatorPrefab, Vector3.zero, Quaternion.identity);
					obj.transform.SetParent(base.transform.Find("Separators"));
					obj.transform.localScale = Vector3.one;
					obj.transform.localPosition = Vector3.zero;
					obj.transform.localRotation = Quaternion.Euler(0f, 0f, num2);
					gameObject.transform.localPosition = new Vector2(radius * Mathf.Cos((num3 - 90f) * (MathF.PI / 180f)), (0f - radius) * Mathf.Sin((num3 - 90f) * (MathF.PI / 180f)));
					gameObject.transform.localScale = Vector3.one;
					if (num3 > 360f)
					{
						num3 -= 360f;
					}
					gameObject.name = num3.ToString();
					if ((bool)gameObject.GetComponent<Button>())
					{
						instancedButtons[gameObject] = gameObject.GetComponent<Button>();
						Button button = instancedButtons[gameObject];
						instancedButtons[gameObject] = button;
						if (button.useCustomColor)
						{
							button.SetColor(button.customColor);
						}
						else
						{
							button.SetColor(button.useCustomColor ? button.customColor : AccentColor);
						}
					}
					else
					{
						gameObject.GetComponent<Image>().color = DisabledColor;
					}
					if (buttonSource == ButtonSource.Prefabs)
					{
						buttonsInstances.Add(gameObject.GetComponent<Button>());
					}
				}
			}
			localAudioSource = GetComponent<AudioSource>();
			if (buttonsInstances.Count != 0)
			{
				SelectedSegment = buttonsInstances[buttonsInstances.Count - 1].gameObject;
			}
		}

		public void Open()
		{
			if (!(TutorialManager.Instance != null) || !TutorialManager.Instance.IsTutorialRunning || TutorialManager.Instance.CurrentSubStep == TutorialSubStepType.OpenRadialMenu || TutorialManager.Instance.IsSubStepCompleted(TutorialSubStepType.OpenRadialMenu))
			{
				_menuCenter = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
				opened = true;
				base.transform.localScale = ((OpenAnimation == AnimationType.ZoomIn) ? Vector3.zero : (Vector3.one * 10f));
				UpdateAllButtonLockStatus();
				TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Equipments, TutorialStepType.UseEquipments, TutorialSubStepType.OpenRadialMenu);
			}
		}

		private void UpdateAllButtonLockStatus()
		{
			for (int i = 0; i < Buttons.Count; i++)
			{
				Button button = ((buttonSource == ButtonSource.Prefabs && i < buttonsInstances.Count) ? buttonsInstances[i] : ((Buttons[i] != null) ? Buttons[i].GetComponent<Button>() : null));
				if (button != null && button.isEquipment)
				{
					button.UpdateLockStatus();
				}
			}
		}

		public void Open(Vector2 origin)
		{
			Open();
			_menuCenter = origin;
			Vector2 vector = new Vector2(_menuCenter.x - (float)Screen.width / 2f, _menuCenter.y - (float)Screen.height / 2f);
			base.transform.localPosition = vector;
		}

		public void Close()
		{
			SelectedSegment = null;
			_selectedSegment = null;
			opened = false;
			if (nameText != null)
			{
				nameText.text = "";
			}
			if (descText != null)
			{
				descText.text = "";
			}
			closeEvent.Invoke();
		}

		public Button GetButtonWithId(string id)
		{
			for (int i = 0; i < Buttons.Count; i++)
			{
				Button button = ((buttonSource == ButtonSource.Prefabs) ? buttonsInstances[i] : Buttons[i].GetComponent<Button>());
				if (button.id == id)
				{
					return button;
				}
			}
			return null;
		}

		private void ChangeSeparatorsState()
		{
			if (!base.transform.Find("Separators"))
			{
				Debug.LogError("Can't find Separators");
			}
			else
			{
				base.transform.Find("Separators").gameObject.SetActive(UseSeparators);
			}
		}

		private void Update()
		{
			if (_audioCoolDown > 0f)
			{
				_audioCoolDown -= Time.deltaTime;
			}
			if (opened)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(Size, Size, Size), 0.2f);
				_background.color = BackgroundColor;
				if (UseSeparators != _previousUseSeparators)
				{
					ChangeSeparatorsState();
				}
				if (base.transform.localScale.x >= Size - 0.2f)
				{
					_cursor.fillAmount = Mathf.Lerp(_cursor.fillAmount, _desiredFill, 0.2f);
					Vector3 vector = new Vector3(_menuCenter.x, _menuCenter.y, 0f);
					Vector2 vector2 = Vector2.zero;
					if (controlType == ControlType.MouseAndTouch)
					{
						vector2 = Mouse.current.position.ReadValue() - (Vector2)vector;
					}
					else if (controlType == ControlType.Gamepad)
					{
						vector2 = new Vector2(gamepadAxis.action.ReadValue<Vector2>().x, gamepadAxis.action.ReadValue<Vector2>().y);
					}
					else if (controlType == ControlType.CustomVector)
					{
						vector2 = CustomInputVector;
					}
					float num = 57.29578f * Mathf.Atan2(vector2.x, vector2.y);
					if (num < 0f)
					{
						num += 360f;
					}
					float z = 0f - (num - _cursor.fillAmount * 360f / 2f);
					float num2 = Vector2.Distance(_menuCenter, Mouse.current.position.ReadValue());
					if ((selectOnlyOnHover && controlType == ControlType.MouseAndTouch && num2 > pieThickness) || (selectOnlyOnHover && controlType == ControlType.Gamepad && Mathf.Abs(gamepadAxis.action.ReadValue<Vector2>().x) + Mathf.Abs(gamepadAxis.action.ReadValue<Vector2>().y) != 0f) || !selectOnlyOnHover)
					{
						_cursor.enabled = true;
						float num3 = float.MaxValue;
						GameObject selectedSegment = null;
						for (int i = 0; i < buttonCount; i++)
						{
							GameObject gameObject = ((buttonSource != ButtonSource.Prefabs) ? Buttons[i] : buttonsInstances[i].gameObject);
							gameObject.transform.localScale = Vector3.one;
							float num4 = float.Parse(gameObject.name);
							if (Mathf.Abs(num4 - num) < num3)
							{
								selectedSegment = gameObject;
								num3 = Mathf.Abs(num4 - num);
							}
						}
						SelectedSegment = selectedSegment;
						if (snap)
						{
							z = 0f - (float.Parse(SelectedSegment.name) - _cursor.fillAmount * 360f / 2f);
						}
						_cursor.transform.localRotation = Quaternion.Slerp(_cursor.transform.localRotation, Quaternion.Euler(0f, 0f, z), LerpAmount);
						instancedButtons[SelectedSegment].SetColor(Color.Lerp(instancedButtons[SelectedSegment].currentColor, BackgroundColor, LerpAmount));
						for (int j = 0; j < Buttons.Count; j++)
						{
							Button button = ((buttonSource == ButtonSource.Prefabs) ? buttonsInstances[j] : instancedButtons[Buttons[j]]);
							if (button.gameObject != SelectedSegment)
							{
								if (button.isUnlocked)
								{
									button.SetColor(Color.Lerp(button.currentColor, button.useCustomColor ? button.customColor : AccentColor, LerpAmount));
								}
								else
								{
									button.SetColor(Color.Lerp(button.currentColor, DisabledColor, LerpAmount));
								}
							}
						}
						try
						{
							if ((bool)SelectedSegment && instancedButtons[SelectedSegment].isUnlocked)
							{
								_cursor.color = Color.Lerp(_cursor.color, instancedButtons[SelectedSegment].useCustomColor ? instancedButtons[SelectedSegment].customColor : AccentColor, LerpAmount);
							}
							else
							{
								_cursor.color = Color.Lerp(_cursor.color, DisabledColor, LerpAmount);
							}
						}
						catch
						{
						}
					}
					else if (_cursor.isActiveAndEnabled && (bool)SelectedSegment)
					{
						_cursor.enabled = false;
						if (nameText != null)
						{
							nameText.text = "";
						}
						if (descText != null)
						{
							descText.text = "";
						}
						if (instancedButtons[SelectedSegment].isUnlocked)
						{
							instancedButtons[SelectedSegment].SetColor(instancedButtons[SelectedSegment].useCustomColor ? instancedButtons[SelectedSegment].customColor : AccentColor);
						}
						else
						{
							instancedButtons[SelectedSegment].SetColor(DisabledColor);
						}
						for (int k = 0; k < Buttons.Count; k++)
						{
							Button button2 = ((buttonSource == ButtonSource.Prefabs) ? buttonsInstances[k] : instancedButtons[Buttons[k]]);
							if (button2.gameObject != SelectedSegment)
							{
								if (button2.isUnlocked)
								{
									button2.SetColor(instancedButtons[SelectedSegment].useCustomColor ? instancedButtons[SelectedSegment].customColor : AccentColor);
								}
								else
								{
									button2.SetColor(DisabledColor);
								}
							}
						}
					}
					if (_cursor.isActiveAndEnabled)
					{
						CheckForInput();
					}
					else if (activationButton != null && activationButton.action != null && activationButton.action.triggered)
					{
						Close();
					}
				}
				_previousUseSeparators = UseSeparators;
			}
			else
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, (CloseAnimation == AnimationType.ZoomIn) ? Vector3.zero : (Vector3.one * 10f), 0.05f);
				_cursor.color = Color.Lerp(_cursor.color, Color.clear, LerpAmount / 3f);
				_background.color = Color.Lerp(_background.color, Color.clear, LerpAmount / 3f);
			}
		}

		private void CheckForInput()
		{
			if (activationButton == null || activationButton.action == null)
			{
				return;
			}
			if (activationButton.action.triggered && !AutoSelection)
			{
				_cursor.rectTransform.localPosition = Vector3.Lerp(_cursor.rectTransform.localPosition, new Vector3(0f, 0f, RaiseOnSelection ? (-10) : 0), LerpAmount);
				if (instancedButtons[SelectedSegment].isUnlocked)
				{
					SelectedSegment.transform.localScale = new Vector2(0.8f, 0.8f);
				}
			}
			else
			{
				_cursor.rectTransform.localPosition = Vector3.Lerp(_cursor.rectTransform.localPosition, Vector3.zero, LerpAmount);
			}
			if (activationButton.action.triggered && (bool)SelectedSegment && !AutoSelection)
			{
				if (instancedButtons[SelectedSegment].isUnlocked)
				{
					instancedButtons[SelectedSegment].ExecuteAction();
					localAudioSource.PlayOneShot(SegmentClickedSound);
				}
				else if (instancedButtons[SelectedSegment].isEquipment)
				{
					NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_EquipmentLocked"));
				}
				Close();
			}
		}

		public void AutoSelect()
		{
			if ((bool)SelectedSegment && AutoSelection)
			{
				if (instancedButtons[SelectedSegment].isUnlocked)
				{
					instancedButtons[SelectedSegment].ExecuteAction();
					localAudioSource.PlayOneShot(SegmentClickedSound);
				}
				else if (instancedButtons[SelectedSegment].isEquipment)
				{
					NotificationManager.Instance?.ShowNotification(LocalizationManager.GetTranslation("Notification_EquipmentLocked"));
				}
			}
		}

		public void SwitchGamepad()
		{
			controlType = ControlType.Gamepad;
		}

		public void SwitchKeyboard()
		{
			controlType = ControlType.MouseAndTouch;
		}

		private void OnEnable()
		{
			if (activationButton != null && activationButton.action != null)
			{
				activationButton.action.Enable();
			}
			if (gamepadAxis != null && gamepadAxis.action != null)
			{
				gamepadAxis.action.Enable();
			}
		}

		private void OnDisable()
		{
			if (activationButton != null && activationButton.action != null)
			{
				activationButton.action.Disable();
			}
			if (gamepadAxis != null && gamepadAxis.action != null)
			{
				gamepadAxis.action.Disable();
			}
		}
	}
}
