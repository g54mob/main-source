using TMPro;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_DropdownDynamicResize : MonoBehaviour
	{
		private RectTransform _rectTransform;

		private TMP_Dropdown _dropdown;

		private float _minWidth = 70f;

		private float _offset = 45f;

		public float maxWidth;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_dropdown = GetComponent<TMP_Dropdown>();
		}

		private void Start()
		{
			Resize(_dropdown.value);
		}

		private void OnEnable()
		{
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.AddListener(Resize);
			}
		}

		private void OnDisable()
		{
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.RemoveAllListeners();
			}
		}

		public void Resize(int value)
		{
			if (_dropdown != null)
			{
				float num = _offset + _dropdown.captionText.GetPreferredValues(_dropdown.options[value].text).x;
				if (num < _minWidth)
				{
					num = _minWidth;
				}
				if (maxWidth > 0f && num > maxWidth)
				{
					num = maxWidth;
				}
				_rectTransform.sizeDelta = new Vector2(num, _rectTransform.sizeDelta.y);
			}
		}
	}
}
