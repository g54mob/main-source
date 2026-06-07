using MG_BlocksEngine2.DragDrop;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	public abstract class BE2_OuterArea
	{
		public Transform Transform;

		public RectTransform _rectTransform;

		public I_BE2_Spot spotOuterArea;

		public int childBlocksCount;

		public I_BE2_Block[] childBlocksArray;

		public BE2_OuterArea(Transform transform)
		{
			Transform = transform;
			_rectTransform = transform as RectTransform;
			spotOuterArea = transform.GetComponent<BE2_SpotOuterArea>();
			childBlocksArray = new I_BE2_Block[0];
			InitializeLayoutGroup();
		}

		protected virtual void InitializeLayoutGroup()
		{
		}

		public virtual Vector2 GetTopDropPosition(I_BE2_Block foundBlock)
		{
			return foundBlock.Transform.localPosition + new Vector3(0f, (BE2_DragDropManager.Instance.GhostBlockTransform as RectTransform).sizeDelta.y - 10f, 0f);
		}

		public void UpdateChildBlocksList()
		{
			childBlocksArray = new I_BE2_Block[0];
			int childCount = Transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				I_BE2_Block component = Transform.GetChild(i).GetComponent<I_BE2_Block>();
				if (component != null)
				{
					childBlocksArray = BE2_ArrayUtils.AddReturn(childBlocksArray, component);
				}
			}
			childBlocksCount = childBlocksArray.Length;
		}

		public void UpdateLayout()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
			UpdateChildBlocksList();
		}
	}
}
