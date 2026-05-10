using UnityEngine;
using UnityEngine.UI.Extensions;

public class WarmUpComboboxes : MonoBehaviour
{
	public AutoCompleteComboBox acb;

	public ComboBox cb;

	public DropDownList ddl;

	private string[] dropDownItems = new string[4] { "More", "ComboBox", "Example", "Goodness" };

	private void Start()
	{
		acb.SetAvailableOptions(dropDownItems);
		cb.SetAvailableOptions(dropDownItems);
		DropDownList dropDownList = ddl;
		object[] list = dropDownItems;
		dropDownList.RefreshItems(list);
	}
}
