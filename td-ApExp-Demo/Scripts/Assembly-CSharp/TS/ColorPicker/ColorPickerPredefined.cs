using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TS.ColorPicker
{
	public class ColorPickerPredefined : Menu
	{
		[SerializeField]
		private Transform colorsContainer;

		[SerializeField]
		private Image currentColor;

		[Header("Colors")]
		[SerializeField]
		private Color[] predefinedColors;

		[Header("Events")]
		public Action<Color> OnChanged;

		public Action<Color> OnSubmit;

		public Action OnCancel;

		private Color _currentColor = Color.white;

		private AudioSource audioSource;

		protected override void Awake()
		{
			base.Awake();
			audioSource = GetComponent<AudioSource>();
		}

		private void Start()
		{
			InitColors();
		}

		private void OnDestroy()
		{
		}

		public override void Open(params object[] menuArgs)
		{
			base.Open();
			if (menuArgs != null && menuArgs.Length != 0 && menuArgs[0] is Color color)
			{
				FindColorButton(color);
				currentColor.color = color;
			}
		}

		private void InitColors()
		{
			for (int i = 0; i < colorsContainer.childCount && i < predefinedColors.Length; i++)
			{
				ColorPickerButton component = colorsContainer.GetChild(i).GetComponent<ColorPickerButton>();
				if (component != null)
				{
					component.SetColor(predefinedColors[i]);
				}
			}
			for (int j = predefinedColors.Length; j < colorsContainer.childCount; j++)
			{
				ColorPickerButton component2 = colorsContainer.GetChild(j).GetComponent<ColorPickerButton>();
				if (component2 != null)
				{
					component2.SetColor(Color.white);
				}
			}
		}

		public void FindColorButton(Color color)
		{
			foreach (Transform item in colorsContainer)
			{
				ColorPickerButton component = item.GetComponent<ColorPickerButton>();
				if (component != null && component.Color == color)
				{
					component.GetComponent<Button>().Select();
					break;
				}
			}
		}

		public void SetCurrentColor(Color color)
		{
			_currentColor = color;
			FindColorButton(color);
			currentColor.color = color;
			OnChanged?.Invoke(color);
		}

		public void UI_Button_Apply()
		{
			audioSource.Play();
			OnSubmit?.Invoke(_currentColor);
		}

		public void UI_Button_Cancel()
		{
			OnCancel?.Invoke();
			MenuManager.Instance.CloseCurrentMenu();
		}

		private void HandleBackPressed(int arg1, InputAction.CallbackContext context)
		{
			UI_Button_Cancel();
		}

		private void HandleEnter(int arg1, InputAction.CallbackContext context)
		{
			UI_Button_Apply();
		}
	}
}
