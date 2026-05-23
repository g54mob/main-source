using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_BlockSection : MonoBehaviour, I_BE2_BlockSection
	{
		private RectTransform _rectTransform;

		public I_BE2_BlockLayout blockLayout;

		private I_BE2_BlockSectionHeader _header;

		private I_BE2_BlockSectionBody _body;

		public int index;

		public RectTransform RectTransform => _rectTransform;

		public I_BE2_BlockSectionHeader Header => _header;

		public I_BE2_BlockSectionBody Body => _body;

		public I_BE2_Block Block { get; set; }

		public Vector2 Size
		{
			get
			{
				if (_header != null)
				{
					Vector2 zero = Vector2.zero;
					zero.y = _header.Size.y;
					if (_body != null)
					{
						zero.y += _body.Size.y;
					}
					zero.x = _header.Size.x;
					return zero;
				}
				return GetComponent<RectTransform>().sizeDelta;
			}
		}

		private void OnValidate()
		{
			Awake();
		}

		private void OnEnable()
		{
			Awake();
		}

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			if (base.transform.childCount > 0)
			{
				_header = base.transform.GetChild(0).GetComponent<I_BE2_BlockSectionHeader>();
			}
			if (base.transform.childCount > 1)
			{
				_body = base.transform.GetChild(1).GetComponent<I_BE2_BlockSectionBody>();
			}
			if ((bool)base.transform.parent)
			{
				blockLayout = base.transform.parent.GetComponent<I_BE2_BlockLayout>();
			}
			index = base.transform.GetSiblingIndex();
			Block = GetComponentInParent<I_BE2_Block>();
		}

		public void UpdateLayout()
		{
			if (Header != null)
			{
				Header.UpdateLayout();
			}
			if (Body != null)
			{
				Body.UpdateLayout();
			}
			_rectTransform.sizeDelta = Size;
		}
	}
}
