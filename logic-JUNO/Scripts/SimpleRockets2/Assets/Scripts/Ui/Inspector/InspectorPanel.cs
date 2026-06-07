using System.Collections.Generic;
using System.Linq;
using ModApi.Ui.Inspector;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui.Inspector
{
	public class InspectorPanel
	{
		private List<ItemElement> _elements = new List<ItemElement>();

		private int _itemSpacing;

		public bool Collapsed { get; set; }

		public ElementBuilder ElementBuilder { get; private set; }

		public XmlElement ItemsParent { get; private set; }

		public InspectorModel Model { get; private set; }

		public InspectorPanel(InspectorModel model, ElementBuilder elementBuilder, XmlElement itemsParent)
		{
			Model = model;
			ElementBuilder = elementBuilder;
			ItemsParent = itemsParent;
			_itemSpacing = ItemsParent.GetAttribute("spacing", "5").ToInt();
			AutoGenerateGroupCollapsedIds(Model.Groups, model.Title);
		}

		public void ClearModelElements()
		{
			foreach (ItemElement element in _elements)
			{
				Object.Destroy(element.GameObject);
			}
			_elements.Clear();
		}

		public void Destroy()
		{
			foreach (ItemElement element in _elements)
			{
				element.OnDesroyed();
			}
			Model.OnInspectorPanelClosed();
			Model = null;
		}

		public void RebuildModelElements()
		{
			_elements.ForEach(delegate(ItemElement x)
			{
				Object.Destroy(x.GameObject);
			});
			_elements.Clear();
			if (Model == null)
			{
				return;
			}
			foreach (GroupModel group in Model.Groups)
			{
				ElementBuilder.BuildGroup(group, ItemsParent, _elements);
			}
		}

		public void ReplaceGroup(GroupModel originalGroup, GroupModel newGroup)
		{
			int index = Model.IndexOfGroup(originalGroup);
			Model.RemoveGroup(originalGroup);
			Model.AddGroup(newGroup, index);
			int index2 = -1;
			GameObject gameObject = originalGroup.Header?.ItemElement?.GameObject ?? originalGroup.Items.FirstOrDefault()?.ItemElement?.GameObject;
			if (gameObject != null)
			{
				index2 = gameObject.transform.GetSiblingIndex();
				DestroyGroup(originalGroup);
			}
			ElementBuilder.BuildGroup(newGroup, ItemsParent, _elements, index2);
		}

		public int Update()
		{
			int num = 0;
			foreach (ItemElement element in _elements)
			{
				element.UpdateVisibility();
				bool flag = element.ModelVisible && !element.Collapsed && !Collapsed;
				if (element.Visible != flag)
				{
					element.Visible = flag;
				}
				if (element.Visible)
				{
					element.Update();
					int height = element.Height;
					if (height > 0)
					{
						num += height + _itemSpacing;
					}
				}
			}
			return num;
		}

		private static void AutoGenerateGroupCollapsedIds(IEnumerable<ItemModel> items, string parentId)
		{
			if (parentId == null)
			{
				parentId = string.Empty;
			}
			foreach (ItemModel item in items)
			{
				if (item is GroupModel groupModel)
				{
					string text = parentId + "." + groupModel.CollapsedId;
					if (groupModel.AutoGenerateCollapsedId)
					{
						groupModel.FullCollapsedId = text;
					}
					AutoGenerateGroupCollapsedIds(groupModel.Items, text);
				}
			}
		}

		private void DestroyGroup(GroupModel group)
		{
			if (group.Header != null)
			{
				DestroyItemModelElement(group.Header);
			}
			foreach (ItemModel item in group.Items)
			{
				if (item is GroupModel groupModel)
				{
					DestroyGroup(groupModel);
				}
				else
				{
					DestroyItemModelElement(item);
				}
			}
		}

		private void DestroyItemModelElement(ItemModel itemModel)
		{
			_elements.Remove(itemModel.ItemElement as ItemElement);
			Object.Destroy(itemModel.ItemElement.GameObject);
			itemModel.NotifyElementDestroyed(itemModel.ItemElement);
		}
	}
}
