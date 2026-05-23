using TMPro;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_InputFieldDynamicResize : MonoBehaviour
	{
		private RectTransform _rectTransform;

		private TMP_InputField _inputField;

		public float minWidth = 70f;

		public float widthOffset = 35f;

		public float maxWidth;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_inputField = GetComponent<TMP_InputField>();
		}

		private void OnEnable()
		{
			if (_inputField == null)
			{
				Awake();
			}
			if (_inputField != null)
			{
				_inputField.onValueChanged.AddListener(Resize);
			}
		}

		private void OnDisable()
		{
			if (_inputField == null)
			{
				Awake();
			}
			if (_inputField != null)
			{
				_inputField.onValueChanged.RemoveAllListeners();
			}
		}

		public void Resize(string value)
		{
			float num = widthOffset + _inputField.textComponent.GetPreferredValues(value).x;
			if (num < minWidth)
			{
				num = minWidth;
			}
			if (maxWidth > 0f && num > maxWidth)
			{
				num = maxWidth;
			}
			_rectTransform.sizeDelta = new Vector2(num, _rectTransform.sizeDelta.y);
			_inputField.textComponent.transform.localPosition = Vector3.zero;
		}
	}
}
