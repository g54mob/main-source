using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_BlockSectionHeader_Dropdown : MonoBehaviour, I_BE2_BlockSectionHeaderItem, I_BE2_BlockSectionHeaderInput
	{
		private BE2_Dropdown _dropdown;

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
			_dropdown = BE2_Dropdown.GetBE2Component(base.transform);
			Spot = GetComponent<I_BE2_Spot>();
		}

		private void OnEnable()
		{
			UpdateValues();
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.AddListener(delegate
				{
					UpdateValues();
				});
			}
		}

		private void OnDisable()
		{
			if (_dropdown != null)
			{
				_dropdown.onValueChanged.RemoveAllListeners();
			}
		}

		private void Start()
		{
			GetComponent<BE2_DropdownDynamicResize>().Resize(0);
			UpdateValues();
		}

		public void UpdateValues()
		{
			bool isText = false;
			if (_dropdown.GetOptionsCount() > 0)
			{
				StringValue = _dropdown.GetSelectedOptionText();
			}
			else
			{
				StringValue = "";
			}
			FloatValue = _dropdown.value;
			InputValues = new BE2_InputValues(StringValue, FloatValue, isText);
		}
	}
}
