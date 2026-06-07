using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_BlockSectionHeader : MonoBehaviour, I_BE2_BlockSectionHeader
	{
		private RectTransform _rectTransform;

		private I_BE2_BlockSection _section;

		private I_BE2_BlockLayout _blockLayout;

		private Image _image;

		public float minHeight;

		public float minWidth = 150f;

		public float paddingRight;

		private I_BE2_BlockSectionHeaderItem[] _itemsArray;

		private I_BE2_BlockSectionHeaderInput[] _inputsArray;

		private Shadow _shadow;

		public RectTransform RectTransform => _rectTransform;

		public Vector2 Size
		{
			get
			{
				if (_rectTransform == null)
				{
					_rectTransform = GetComponent<RectTransform>();
				}
				return _rectTransform.sizeDelta;
			}
			set
			{
				_rectTransform.sizeDelta = value;
			}
		}

		public I_BE2_BlockSectionHeaderItem[] ItemsArray => _itemsArray;

		public I_BE2_BlockSectionHeaderInput[] InputsArray => _inputsArray;

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
			UpdateItemsArray();
			UpdateInputsArray();
			_rectTransform = GetComponent<RectTransform>();
			if ((bool)base.transform.parent)
			{
				_section = base.transform.parent.GetComponent<I_BE2_BlockSection>();
				_blockLayout = base.transform.parent.parent.GetComponent<I_BE2_BlockLayout>();
			}
			_image = GetComponent<Image>();
			_image.type = Image.Type.Sliced;
			_image.pixelsPerUnitMultiplier = 2f;
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnDrag, UpdateItemsArray);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateItemsArray);
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateInputsArray);
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnDrag, UpdateItemsArray);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateItemsArray);
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, UpdateInputsArray);
		}

		public void UpdateItemsArray()
		{
			_itemsArray = new I_BE2_BlockSectionHeaderItem[0];
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				I_BE2_BlockSectionHeaderItem component = base.transform.GetChild(i).GetComponent<I_BE2_BlockSectionHeaderItem>();
				if (component != null && component.Transform.gameObject.activeSelf)
				{
					BE2_ArrayUtils.Add(ref _itemsArray, component);
				}
			}
		}

		public void UpdateInputsArray()
		{
			_inputsArray = new I_BE2_BlockSectionHeaderInput[0];
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				I_BE2_BlockSectionHeaderInput component = base.transform.GetChild(i).GetComponent<I_BE2_BlockSectionHeaderInput>();
				if (component != null && component.Transform.gameObject.activeSelf)
				{
					BE2_ArrayUtils.Add(ref _inputsArray, component);
				}
			}
		}

		public void UpdateLayout()
		{
			if (_blockLayout != null)
			{
				_image.color = _blockLayout.Color;
			}
			if (_section.RectTransform.transform.GetSiblingIndex() == 0)
			{
				float num = 0f;
				float num2 = minHeight - 40f;
				float num3 = 0f;
				int num4 = _itemsArray.Length;
				for (int i = 0; i < num4; i++)
				{
					I_BE2_BlockSectionHeaderItem i_BE2_BlockSectionHeaderItem = _itemsArray[i];
					num += i_BE2_BlockSectionHeaderItem.Size.x + 15f;
					if (i_BE2_BlockSectionHeaderItem.Size.y > num3)
					{
						num3 = i_BE2_BlockSectionHeaderItem.Size.y;
					}
				}
				num += 15f + paddingRight;
				if (num < minWidth)
				{
					num = minWidth;
				}
				num2 += num3;
				if (num2 < minHeight)
				{
					num2 = minHeight;
				}
				_rectTransform.sizeDelta = new Vector2(num, num2);
			}
			else
			{
				_rectTransform.sizeDelta = new Vector2(_blockLayout.SectionsArray[0].Header.Size.x, _rectTransform.sizeDelta.y);
			}
		}
	}
}
