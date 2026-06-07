using TMPro;
using UnityEngine;

public class RewiredDropDown : RewiredComponent
{
	[Header("Drop Down")]
	[SerializeField]
	private TMP_Dropdown _dropDown;

	protected override void OnButtonDown()
	{
		_dropDown.Show();
	}
}
