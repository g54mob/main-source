using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_BlockSectionBody : MonoBehaviour, I_BE2_BlockSectionBody
	{
		private I_BE2_BlockSection _section;

		private I_BE2_BlockLayout _blockLayout;

		private Image _image;

		private RectTransform _rectTransform;

		private Shadow _shadow;

		public RectTransform RectTransform => _rectTransform;

		public I_BE2_Block[] ChildBlocksArray { get; set; }

		public I_BE2_BlockSection BlockSection { get; set; }

		public Vector2 Size
		{
			get
			{
				return _rectTransform.sizeDelta;
			}
			set
			{
				_rectTransform.sizeDelta = value;
			}
		}

		public I_BE2_Spot Spot { get; set; }

		public int ChildBlocksCount { get; set; }

		public Shadow Shadow
		{
			get
			{
				if (!_shadow)
				{
					if ((bool)GetComponent<Shadow>())
					{
						_shadow = GetComponent<Shadow>();
					}
					else
					{
						_shadow = base.gameObject.AddComponent<Shadow>();
					}
					_shadow.effectColor = Color.green;
					_shadow.effectDistance = new Vector2(-6f, -6f);
				}
				return _shadow;
			}
		}

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
			_image = GetComponent<Image>();
			_image.type = Image.Type.Sliced;
			_image.pixelsPerUnitMultiplier = 2f;
			ChildBlocksArray = new I_BE2_Block[0];
			Spot = GetComponent<I_BE2_Spot>();
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
			if (_image.sprite != null && _blockLayout != null)
			{
				_image.color = _blockLayout.Color;
			}
			float num = 50f;
			if (_section.Block.Type == BlockTypeEnum.trigger || _section.Block.Type == BlockTypeEnum.define)
			{
				num = 0f;
			}
			float num2 = 0f;
			UpdateChildBlocksList();
			int num3 = ChildBlocksArray.Length;
			for (int i = 0; i < num3; i++)
			{
				num2 += ChildBlocksArray[i].Layout.Size.y - 10f;
			}
			num2 -= 10f;
			if (num2 < num)
			{
				num2 = num;
			}
			if (_section.RectTransform.transform.GetSiblingIndex() == _section.RectTransform.transform.parent.childCount - 2 && _section.Block.Type != BlockTypeEnum.trigger && _section.Block.Type != BlockTypeEnum.define)
			{
				num2 += 50f;
			}
			_rectTransform.sizeDelta = new Vector2(_section.Size.x, num2);
		}
	}
}
