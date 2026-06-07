using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	public class BE2_BlockSectionHeader_Toggle : MonoBehaviour, I_BE2_BlockSectionHeaderItem, I_BE2_BlockSectionHeaderInput
	{
		private Toggle _toggle;

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
			_toggle = GetComponent<Toggle>();
			Spot = GetComponent<I_BE2_Spot>();
		}

		private void OnEnable()
		{
			UpdateValues();
			_toggle.onValueChanged.AddListener(delegate
			{
				UpdateValues();
			});
		}

		private void OnDisable()
		{
			_toggle.onValueChanged.RemoveAllListeners();
		}

		private void Start()
		{
			UpdateValues();
		}

		public void UpdateValues()
		{
			StringValue = "false";
			FloatValue = 0f;
			if (_toggle.isOn)
			{
				StringValue = "true";
				FloatValue = 1f;
			}
			InputValues = new BE2_InputValues(StringValue, FloatValue, isText: true);
		}
	}
}
