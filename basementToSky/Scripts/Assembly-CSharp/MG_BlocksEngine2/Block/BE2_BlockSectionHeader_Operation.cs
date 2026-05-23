using System.Globalization;
using MG_BlocksEngine2.Block.Instruction;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_BlockSectionHeader_Operation : MonoBehaviour, I_BE2_BlockSectionHeaderItem, I_BE2_BlockSectionHeaderInput
	{
		private I_BE2_Block _block;

		private I_BE2_Instruction _instruction;

		private RectTransform _rectTransform;

		private bool _isText;

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

		public I_BE2_Spot Spot => null;

		public float FloatValue => GetFloatValue();

		public string StringValue => GetStringValue();

		public BE2_InputValues InputValues => GetInputValues();

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_block = GetComponent<I_BE2_Block>();
			_instruction = GetComponent<I_BE2_Instruction>();
		}

		private string GetStringValue()
		{
			return _instruction.Operation();
		}

		private float GetFloatValue()
		{
			float result = 0f;
			try
			{
				result = float.Parse(_instruction.Operation(), CultureInfo.InvariantCulture);
				_isText = false;
			}
			catch
			{
				_isText = true;
			}
			return result;
		}

		private BE2_InputValues GetInputValues()
		{
			return new BE2_InputValues(GetStringValue(), GetFloatValue(), _isText);
		}

		public void UpdateValues()
		{
			GetInputValues();
		}
	}
}
