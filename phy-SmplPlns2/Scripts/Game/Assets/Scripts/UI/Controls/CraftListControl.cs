using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.CraftFiles;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class CraftListControl : ListControl<CraftFileInfo>
	{
		public CraftListControl(ScrollViewWidget scrollView)
			: base(scrollView, "craft-list-item")
		{
			base.CreateListItem = CreateCraftListItem;
			base.FilterListItem = FilterCraftListItem;
		}

		private void CreateCraftListItem(Widget widget, ListItem<CraftFileInfo> item)
		{
			List<string> value;
			using (CollectionPool<List<string>, string>.Get(out value))
			{
				value.AddRange(item.Item.Tags ?? Array.Empty<string>());
				for (int num = value.Count - 1; num >= 0; num--)
				{
					if (string.Equals(value[num], "Stock Craft", StringComparison.OrdinalIgnoreCase))
					{
						value.RemoveAt(num);
					}
				}
				string text = ((value.Count == 0) ? "No Tags" : string.Join(", ", value));
				string text2 = item.Item.FileNameWithoutExtension;
				if (item.Item.Id == "__editor__.xml")
				{
					text2 = "Designer Craft";
				}
				widget.FindWidget<TextWidget>("item-name").Text = text2;
				widget.FindWidget<TextWidget>("item-details").Text = Utilities.RelativeDateShort(DateTime.Now, item.Item.LastModified);
				widget.FindWidget<TextWidget>("item-path").Text = item.Item.SubdirectoryPath;
				widget.FindWidget<TextWidget>("item-tags").Text = "   " + text;
				widget.Tooltip = string.Format("{0}\nTags: {1}{2}\nLast Modified: {3:G}", item.Item.Name, text, "\nFile: " + item.Item.Id, item.Item.LastModified.ToLocalTime());
			}
		}

		private bool FilterCraftListItem(ListItem<CraftFileInfo> listItem, string searchFilter)
		{
			if (string.IsNullOrEmpty(searchFilter))
			{
				return false;
			}
			if (listItem.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase) || listItem.Item.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			if (listItem.Item.Tags != null)
			{
				foreach (string tag in listItem.Item.Tags)
				{
					if (tag.Contains(searchFilter, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
