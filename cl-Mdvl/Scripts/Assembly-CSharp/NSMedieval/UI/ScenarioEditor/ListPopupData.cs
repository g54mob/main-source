using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.UI.ScenarioEditor
{
	public struct ListPopupData
	{
		public string Title { get; set; }

		public List<string> SelectedID { get; set; }

		public List<ListPopupItemData> ListItems { get; set; }

		public HumanoidInstance HumanoidInstance { get; set; }

		public ListPopupItemType ListType { get; set; }

		public static ListPopupData CreateInstance(string title, List<ListPopupItemData> listItems, List<string> selectedId, HumanoidInstance humanoidInstance, ListPopupItemType listType = ListPopupItemType.None)
		{
			return new ListPopupData
			{
				Title = title,
				ListItems = listItems,
				SelectedID = selectedId,
				HumanoidInstance = humanoidInstance,
				ListType = listType
			};
		}
	}
}
