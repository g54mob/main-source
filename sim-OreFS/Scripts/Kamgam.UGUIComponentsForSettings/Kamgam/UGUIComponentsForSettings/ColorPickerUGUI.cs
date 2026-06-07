using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class ColorPickerUGUI : MonoBehaviour
	{
		public delegate void OnColorChangedDelegate(Color color);

		public delegate void OnSelectionChangedDelegate(int selectedIndex);

		public GameObject Active;

		public Image ColorImage;

		public UnityEvent<Color> OnColorChangedEvent;

		public OnColorChangedDelegate OnColorChanged;

		public UnityEvent<int> OnSelectionChangedEvent;

		public OnSelectionChangedDelegate OnSelectionChanged;

		protected ColorPickerButtonUGUI[] _colorButtons;

		protected int _selectedIndex = -1;

		public ColorPickerButtonUGUI[] ColorButtons
		{
			get
			{
				if (_colorButtons == null)
				{
					_colorButtons = GetComponentsInChildren<ColorPickerButtonUGUI>(includeInactive: true);
					ColorPickerButtonUGUI[] colorButtons = _colorButtons;
					foreach (ColorPickerButtonUGUI colorBtn in colorButtons)
					{
						colorBtn.GetComponent<Button>().onClick.AddListener(delegate
						{
							onColorButtonClick(colorBtn);
						});
					}
				}
				return _colorButtons;
			}
		}

		public bool IsActive => Active.gameObject.activeSelf;

		public int SelectedIndex
		{
			get
			{
				return _selectedIndex;
			}
			set
			{
				if (value != _selectedIndex)
				{
					_selectedIndex = value;
					if (ColorButtons != null && ColorButtons.Length > _selectedIndex)
					{
						Color color = ColorButtons[_selectedIndex].Color;
						updateColorImage(color);
						OnColorChangedEvent?.Invoke(color);
						OnColorChanged?.Invoke(color);
					}
					OnSelectionChangedEvent?.Invoke(_selectedIndex);
					OnSelectionChanged?.Invoke(_selectedIndex);
				}
			}
		}

		public void Update()
		{
			if (InputUtils.CancelUp() && IsActive)
			{
				SetActive(active: false);
			}
		}

		public void Toggle()
		{
			Active.gameObject.SetActive(!IsActive);
		}

		public void SetActive(bool active)
		{
			if (active != IsActive && !active)
			{
				SelectionUtils.SetSelected(GetComponent<Selectable>().gameObject);
			}
			Active.gameObject.SetActive(active);
		}

		protected void updateColorImage(Color color)
		{
			ColorImage.color = color;
		}

		private void onColorButtonClick(ColorPickerButtonUGUI button)
		{
			if (ColorButtons == null || ColorButtons.Length == 0)
			{
				return;
			}
			for (int i = 0; i < ColorButtons.Length; i++)
			{
				if (ColorButtons[i] == button)
				{
					SelectedIndex = i;
					break;
				}
			}
			SetActive(active: false);
		}

		public void SetColorOptions(IList<Color> colorOptions)
		{
			int num = Mathf.Max(colorOptions.Count, ColorButtons.Length);
			for (int i = 0; i < num; i++)
			{
				if (i < _colorButtons.Length && i < colorOptions.Count)
				{
					_colorButtons[i].Color = colorOptions[i];
					_colorButtons[i].gameObject.SetActive(value: true);
				}
				else if (i >= ColorButtons.Length)
				{
					Debug.LogWarning("ColorPickerUGUI: There are more color options (" + colorOptions.Count + ") in the than there are ColorPickerButtonUGUI buttons (" + ColorButtons.Length + "). Please add more buttons to the UI.");
				}
				else
				{
					ColorButtons[i].gameObject.SetActive(value: false);
				}
			}
		}

		public List<Color> GetColorOptions()
		{
			List<Color> list = new List<Color>();
			for (int i = 0; i < ColorButtons.Length; i++)
			{
				if (ColorButtons[i].gameObject.activeSelf)
				{
					list.Add(ColorButtons[i].Color);
				}
			}
			return list;
		}
	}
}
