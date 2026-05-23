using System.Globalization;
using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_BlockSectionHeader_InputField : MonoBehaviour, I_BE2_BlockSectionHeaderItem, I_BE2_BlockSectionHeaderInput
	{
		private BE2_InputField _inputField;

		private RectTransform _rectTransform;

		public Transform Transform => base.transform;

		public Vector2 Size
		{
			get
			{
				if (!_rectTransform)
				{
					return GetComponent<RectTransform>().sizeDelta;
				}
				return _rectTransform.sizeDelta;
			}
		}

		public I_BE2_Spot Spot { get; set; }

		public float FloatValue { get; set; }

		public string StringValue { get; set; }

		public BE2_InputValues InputValues { get; set; }

		private void OnValidate()
		{
			Awake();
		}

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_inputField = BE2_InputField.GetBE2Component(base.transform);
			Spot = GetComponent<I_BE2_Spot>();
		}

		private void OnEnable()
		{
			UpdateValues();
			_inputField.onEndEdit.AddListener(delegate
			{
				UpdateValues();
			});
		}

		private void OnDisable()
		{
			_inputField.onEndEdit.RemoveAllListeners();
		}

		private void Start()
		{
			UpdateValues();
		}

		public void UpdateValues()
		{
			string stringValue = "";
			if (_inputField.text != null)
			{
				stringValue = _inputField.text;
			}
			StringValue = stringValue;
			float floatValue = 0f;
			bool isText;
			try
			{
				floatValue = float.Parse(StringValue, CultureInfo.InvariantCulture);
				isText = false;
			}
			catch
			{
				isText = true;
			}
			FloatValue = floatValue;
			InputValues = new BE2_InputValues(StringValue, FloatValue, isText);
		}
	}
}
