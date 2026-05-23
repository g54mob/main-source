using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_BlockSectionHeader_VariableLabel : MonoBehaviour, I_BE2_BlockSectionHeaderItem, I_BE2_BlockSectionHeaderInput
	{
		private BE2_Text _text;

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
			_text = BE2_Text.GetBE2Text(base.transform);
			Spot = GetComponent<I_BE2_Spot>();
		}

		private void OnEnable()
		{
			UpdateValues();
		}

		public void UpdateValues()
		{
			string stringValue = "";
			if (_text.text != null)
			{
				stringValue = _text.text;
			}
			StringValue = stringValue;
			FloatValue = 0f;
			InputValues = new BE2_InputValues(StringValue, FloatValue, isText: true);
		}
	}
}
