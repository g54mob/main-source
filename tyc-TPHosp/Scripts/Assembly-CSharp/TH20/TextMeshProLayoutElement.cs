using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class TextMeshProLayoutElement : MonoBehaviour, ILayoutElement
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private bool _resizeWidth;

		[SerializeField]
		private bool _resizeHeight;

		private bool _enabled;

		public float flexibleHeight => 0f;

		public float flexibleWidth => 0f;

		public int layoutPriority
		{
			get
			{
				if (_text == null || !_enabled)
				{
					return -1;
				}
				return _text.layoutPriority + 1;
			}
		}

		public float minHeight
		{
			get
			{
				if (_resizeHeight)
				{
					return _text.preferredHeight;
				}
				return 0f;
			}
		}

		public float minWidth
		{
			get
			{
				if (_resizeWidth)
				{
					return _text.preferredWidth;
				}
				return 0f;
			}
		}

		public float preferredHeight
		{
			get
			{
				if (_resizeHeight)
				{
					return _text.preferredHeight;
				}
				return 0f;
			}
		}

		public float preferredWidth
		{
			get
			{
				if (_resizeWidth)
				{
					return _text.preferredWidth;
				}
				return 0f;
			}
		}

		private void OnEnable()
		{
			_enabled = true;
		}

		private void OnDisable()
		{
			_enabled = false;
		}

		public void CalculateLayoutInputHorizontal()
		{
		}

		public void CalculateLayoutInputVertical()
		{
		}
	}
}
