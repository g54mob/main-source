using MG_BlocksEngine2.Utils;
using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_BlockSectionHeader_Label : MonoBehaviour, I_BE2_BlockSectionHeaderItem
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

		private void OnValidate()
		{
			Awake();
			_text = BE2_Text.GetBE2Text(base.transform);
			if (_text != null)
			{
				_text.raycastTarget = false;
			}
		}

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}
	}
}
