using TMPro;
using UnityEngine;

public class CustomDropDown : TMP_Dropdown
{
	[Header("Custom Drop Down")]
	[SerializeField]
	private bool _isSelectable = true;

	public override void Select()
	{
		if (_isSelectable)
		{
			base.Select();
		}
	}
}
