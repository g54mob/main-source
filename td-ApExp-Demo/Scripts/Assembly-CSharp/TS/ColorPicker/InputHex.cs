using TMPro;
using UnityEngine;

namespace TS.ColorPicker
{
	public class InputHex : MonoBehaviour
	{
		public delegate void OnValueChanged(InputHex sender, Color color);

		[Header("Inner")]
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private TMP_InputField _input;

		public OnValueChanged ValueChanged;

		public string Label
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public Color Value
		{
			get
			{
				ColorUtility.TryParseHtmlString($"#{_input.text}", out var color);
				return color;
			}
			set
			{
				_input.text = ColorUtility.ToHtmlStringRGBA(value);
			}
		}

		private void Start()
		{
			_input.onEndEdit.AddListener(Input_EndEdit);
		}

		private void Input_EndEdit(string arg0)
		{
			if (!string.IsNullOrEmpty(arg0))
			{
				ValueChanged?.Invoke(this, Value);
			}
		}
	}
}
