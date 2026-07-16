using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TS.ColorPicker
{
	public class ColorPicker : Menu
	{
		private ColorPickerMode _currentMode;

		[Header("Elements")]
		[SerializeField]
		private RectTransform shadeSelector;

		[SerializeField]
		private RectTransform hueSelector;

		[SerializeField]
		private RectTransform shadeCursor;

		[SerializeField]
		private RectTransform hueCursor;

		[SerializeField]
		private float moveSpeed = 100f;

		private Vector2 shadePos;

		private float huePos;

		[Header("References")]
		[SerializeField]
		private HsbPicker _hsbPicker;

		[SerializeField]
		private Image _colorResult;

		[SerializeField]
		private InputHex _inputHex;

		[Header("Events")]
		public UnityEvent<Color> OnChanged;

		public UnityEvent<Color> OnSubmit;

		public UnityEvent OnCancel;

		private InputColorChannels _inputRgb;

		private Color _currentColor = Color.white;

		private Texture2D _screenTexture;

		[SerializeField]
		private float paintCooldown = 0.1f;

		private float paintCooldownElapsed;

		private AudioSource audioSource;

		private bool inShadeMode;

		private bool inHueMode;

		private new void Awake()
		{
			_inputRgb = GetComponent<InputColorChannels>();
			audioSource = GetComponent<AudioSource>();
		}

		private void Start()
		{
			_hsbPicker.ValueChanged = HsbPicker_ValueChanged;
			_inputRgb.ValueChanged = InputColorChannels_RGB_ValueChanged;
			_inputHex.ValueChanged = InputHex_ValueChanged;
			InputManager.Instance.OnEnter += HandleEnter;
			InputManager.Instance.OnBackPressed += HandleBackPressed;
			base.enabled = false;
		}

		private void OnDestroy()
		{
			InputManager.Instance.OnEnter -= HandleEnter;
			InputManager.Instance.OnBackPressed -= HandleBackPressed;
		}

		private void Update()
		{
			paintCooldownElapsed -= Time.deltaTime;
			Vector2 vector = Mouse.current.position.ReadValue();
			Color pixel = _screenTexture.GetPixel((int)vector.x, (int)vector.y);
			UpdateColor(pixel);
			if (_currentMode == ColorPickerMode.Shade || _currentMode == ColorPickerMode.Hue)
			{
				EventSystem.current.SetSelectedGameObject(null);
				InputManager.Instance.GetAnyLeftStickInput();
				if (_currentMode == ColorPickerMode.Shade)
				{
					Debug.LogWarning("Moving shade cursor");
					StickMoveCursor(shadeSelector, ref shadePos, shadeCursor);
				}
				else if (_currentMode == ColorPickerMode.Hue)
				{
					Debug.LogWarning("Moving hue cursor");
					StickMoveCursorVertical(hueSelector, ref huePos, hueCursor);
				}
			}
			if (Input.anyKeyDown)
			{
				Object.Destroy(_screenTexture);
				base.enabled = false;
			}
		}

		public void OnShadePickerSelected()
		{
			Debug.LogWarning("Shade picker selected");
			_currentMode = ColorPickerMode.Shade;
			EventSystem.current.SetSelectedGameObject(shadeSelector.gameObject);
		}

		public void OnHuePickerSelected()
		{
			Debug.LogWarning("Hue picker selected");
			_currentMode = ColorPickerMode.Hue;
			EventSystem.current.SetSelectedGameObject(hueSelector.gameObject);
		}

		private void StickMoveCursor(RectTransform targetArea, ref Vector2 pos, RectTransform cursor)
		{
			Vector2 vector = InputManager.Instance.GetAnyLeftStickInput() * moveSpeed * Time.deltaTime;
			pos += vector;
			pos.x = Mathf.Clamp(pos.x, 0f, targetArea.rect.width);
			pos.y = Mathf.Clamp(pos.y, 0f, targetArea.rect.height);
			cursor.anchoredPosition = pos;
		}

		private void StickMoveCursorVertical(RectTransform targetArea, ref float yPos, RectTransform cursor)
		{
			float num = InputManager.Instance.GetAnyLeftStickInput().y * moveSpeed * Time.deltaTime;
			yPos += num;
			yPos = Mathf.Clamp(yPos, 0f, targetArea.rect.height);
			cursor.anchoredPosition = new Vector2(cursor.anchoredPosition.x, yPos);
		}

		public override void Open(params object[] menuArgs)
		{
			base.Open();
			inShadeMode = true;
			inHueMode = false;
			if (menuArgs != null && menuArgs.Length != 0 && menuArgs[0] is Color color)
			{
				UpdateColor(color);
			}
		}

		public void Open(Color color)
		{
		}

		private void HsbPicker_ValueChanged(HsbPicker sender, float hue, float saturation, float brightness)
		{
			Color color = Color.HSVToRGB(hue, saturation, brightness);
			SetCurrentColor(color);
			SetRgbChannels(color);
			SetHexValue(color);
		}

		private void InputColorChannels_RGB_ValueChanged(InputColorChannels sender, Color color)
		{
			SetCurrentColor(color);
			SetHexValue(color);
			SetHsb(color);
		}

		private void InputHex_ValueChanged(InputHex sender, Color color)
		{
			SetCurrentColor(color);
			SetRgbChannels(color);
			SetHsb(color);
		}

		private void Enable(bool enable)
		{
			base.gameObject.SetActive(enable);
		}

		private void UpdateColor(Color color)
		{
			SetCurrentColor(color);
			SetRgbChannels(color);
			SetHexValue(color);
			SetHsb(color);
		}

		private void SetCurrentColor(Color color)
		{
			_currentColor = color;
			_colorResult.color = _currentColor;
			OnChanged?.Invoke(color);
		}

		private void SetRgbChannels(Color color)
		{
			_inputRgb.SetValues(new float[3] { color.r, color.g, color.b });
		}

		private void SetHexValue(Color color)
		{
			_inputHex.Value = color;
		}

		private void SetHsb(Color color)
		{
			_hsbPicker.SetColor(color);
		}

		public void UI_Button_Apply()
		{
			audioSource.Play();
			paintCooldownElapsed = paintCooldown;
			OnSubmit?.Invoke(_currentColor);
			MenuManager.Instance.CloseCurrentMenu();
		}

		public void UI_Button_Cancel()
		{
			OnCancel?.Invoke();
			MenuManager.Instance.CloseCurrentMenu();
		}

		private void HandleBackPressed(int arg1, InputAction.CallbackContext context)
		{
			if (_currentMode != ColorPickerMode.None)
			{
				_currentMode = ColorPickerMode.None;
				EventSystem.current.SetSelectedGameObject(defaultSelectedGo);
			}
			else
			{
				UI_Button_Cancel();
			}
		}

		private void HandleEnter(int arg1, InputAction.CallbackContext context)
		{
			if (_currentMode != ColorPickerMode.None)
			{
				_currentMode = ColorPickerMode.None;
				EventSystem.current.SetSelectedGameObject(defaultSelectedGo);
			}
			else
			{
				UI_Button_Apply();
			}
		}
	}
}
