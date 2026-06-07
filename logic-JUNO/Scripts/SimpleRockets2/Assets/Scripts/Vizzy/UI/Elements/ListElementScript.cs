using System;
using System.Collections.Generic;
using ModApi.Craft.Program;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class ListElementScript : BlockElementScript
	{
		private TMP_Dropdown _dropdown;

		private bool _expanded;

		[SerializeField]
		private Sprite _iconBool;

		[SerializeField]
		private Sprite _iconDegrees;

		[SerializeField]
		private Sprite _iconList;

		[SerializeField]
		private Sprite _iconNone;

		[SerializeField]
		private Sprite _iconNumber;

		[SerializeField]
		private Sprite _iconRadians;

		[SerializeField]
		private Sprite _iconText;

		[SerializeField]
		private Sprite _iconVector;

		private float _minExpandedWidth;

		public List<ListItemInfo> Items { get; private set; }

		public string ListId { get; private set; }

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Initialize(string listId)
		{
			ListId = listId;
			List<ListItemInfo> listItems = base.Node.GetListItems(listId);
			if (listItems == null || listItems.Count == 0)
			{
				throw new Exception($"Node {base.Node.ToString()} did not provide a list for list id {listId}");
			}
			_minExpandedWidth = base.MinSize.x;
			foreach (ListItemInfo item in listItems)
			{
				_minExpandedWidth = Mathf.Max(item.Text.Length * 13 + 25, _minExpandedWidth);
				TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
				optionData.text = item.Text;
				optionData.image = GetIcon(item);
				_dropdown.options.Add(optionData);
			}
			Items = listItems;
			string currentValue = base.Node.GetListValue(listId);
			int num = listItems.FindIndex((ListItemInfo x) => string.Compare(x.Id, currentValue, ignoreCase: true) == 0);
			if (num < 0)
			{
				num = 0;
			}
			_dropdown.value = num;
			_dropdown.captionText.text = Items[num].Text;
			_dropdown.onValueChanged.AddListener(OnValueChanged);
		}

		public override Vector2 LayoutElement()
		{
			Vector2 blockSize = new Vector2(_dropdown.captionText.preferredWidth + 55f + (float)base.Padding.left + (float)base.Padding.right, base.RectTransform.sizeDelta.y + (float)base.Padding.top + (float)base.Padding.bottom);
			base.Size = SetBlockSize(blockSize);
			return base.Size;
		}

		protected override void Awake()
		{
			base.Awake();
			_dropdown = GetComponentInChildren<TMP_Dropdown>();
		}

		protected override void Update()
		{
			base.Update();
			if (_expanded == _dropdown.IsExpanded)
			{
				return;
			}
			_expanded = _dropdown.IsExpanded;
			if (_expanded)
			{
				Toggle[] componentsInChildren = GetComponentsInChildren<Toggle>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.AddComponent<DropdownItemScript>().Initialize(this);
				}
				RectTransform component = _dropdown.gameObject.GetComponentInChildren<ScrollRect>().GetComponent<RectTransform>();
				float x = Mathf.Max(_minExpandedWidth - base.Size.x, 0f);
				component.offsetMax = new Vector2(x, component.offsetMax.y);
			}
		}

		private Sprite GetIcon(ListItemInfo item)
		{
			return item.ItemType switch
			{
				ListItemInfoType.None => _iconNone, 
				ListItemInfoType.Degrees => _iconDegrees, 
				ListItemInfoType.List => _iconList, 
				ListItemInfoType.Number => _iconNumber, 
				ListItemInfoType.Radians => _iconRadians, 
				ListItemInfoType.Text => _iconText, 
				ListItemInfoType.Vector => _iconVector, 
				ListItemInfoType.Bool => _iconBool, 
				_ => null, 
			};
		}

		private void OnValueChanged(int index)
		{
			if (index >= 0 && index < _dropdown.options.Count)
			{
				base.Node.SetListValue(ListId, Items[index].Id);
				OnChildSizeChanged();
			}
		}
	}
}
