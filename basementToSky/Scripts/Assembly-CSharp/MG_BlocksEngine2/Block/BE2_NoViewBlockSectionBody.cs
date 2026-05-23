using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_NoViewBlockSectionBody : MonoBehaviour, I_BE2_BlockSectionBody
	{
		private RectTransform _rectTransform;

		private I_BE2_BlockSection _section;

		private I_BE2_BlockLayout _blockLayout;

		public RectTransform RectTransform => _rectTransform;

		public I_BE2_Block[] ChildBlocksArray { get; set; }

		public I_BE2_BlockSection BlockSection { get; set; }

		public Vector2 Size => Vector2.zero;

		public I_BE2_Spot Spot { get; set; }

		public int ChildBlocksCount { get; set; }

		public Shadow Shadow { get; }

		private void OnValidate()
		{
			Awake();
		}

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			if ((bool)base.transform.parent)
			{
				_section = base.transform.parent.GetComponent<I_BE2_BlockSection>();
				_blockLayout = base.transform.parent.parent.GetComponent<I_BE2_BlockLayout>();
				BlockSection = base.transform.parent.GetComponent<I_BE2_BlockSection>();
			}
			ChildBlocksArray = new I_BE2_Block[0];
		}

		public void UpdateChildBlocksList()
		{
			ChildBlocksArray = new I_BE2_Block[0];
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				I_BE2_Block component = base.transform.GetChild(i).GetComponent<I_BE2_Block>();
				if (component != null)
				{
					ChildBlocksArray = BE2_ArrayUtils.AddReturn(ChildBlocksArray, component);
				}
			}
			ChildBlocksCount = ChildBlocksArray.Length;
		}

		public void UpdateLayout()
		{
			UpdateChildBlocksList();
		}
	}
}
