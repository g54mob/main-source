using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	[ExecuteInEditMode]
	public class BE2_NoViewBlockSectionHeader : MonoBehaviour, I_BE2_BlockSectionHeader
	{
		private RectTransform _rectTransform;

		private I_BE2_BlockSection _section;

		private I_BE2_BlockLayout _blockLayout;

		private I_BE2_BlockSectionHeaderItem[] _itemsArray;

		private I_BE2_BlockSectionHeaderInput[] _inputsArray;

		public RectTransform RectTransform => _rectTransform;

		public Vector2 Size => Vector2.zero;

		public I_BE2_BlockSectionHeaderItem[] ItemsArray => _itemsArray;

		public I_BE2_BlockSectionHeaderInput[] InputsArray => _inputsArray;

		public Shadow Shadow { get; }

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
		}
	}
}
