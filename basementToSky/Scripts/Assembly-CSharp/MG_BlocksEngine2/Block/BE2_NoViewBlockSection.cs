using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_NoViewBlockSection : MonoBehaviour, I_BE2_BlockSection
	{
		private RectTransform _rectTransform;

		public I_BE2_BlockLayout blockLayout;

		private I_BE2_BlockSectionHeader _header;

		private I_BE2_BlockSectionBody _body;

		public int index;

		public RectTransform RectTransform => _rectTransform;

		public I_BE2_BlockSectionHeader Header
		{
			get
			{
				return _header;
			}
			set
			{
				_header = value;
			}
		}

		public I_BE2_BlockSectionBody Body
		{
			get
			{
				return _body;
			}
			set
			{
				_body = value;
			}
		}

		public I_BE2_Block Block { get; set; }

		public Vector2 Size => Vector2.zero;

		private void OnValidate()
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
		}
	}
}
