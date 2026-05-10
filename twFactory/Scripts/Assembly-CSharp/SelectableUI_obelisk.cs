using TMPro;
using UnityEngine;

public class SelectableUI_obelisk : SelectableUI
{
	[SerializeField]
	private TextMeshProUGUI obeliskNameText;

	[SerializeField]
	private TextMeshProUGUI obeliskDescriptionText;

	private Obelisk obelisk;

	public override ISelectable SelectedObject
	{
		get
		{
			return base.SelectedObject;
		}
		set
		{
			base.SelectedObject = value;
			obelisk = SelectedObject as Obelisk;
			UpdateObeliskInfo();
		}
	}

	private void UpdateObeliskInfo()
	{
		obeliskNameText.text = obelisk.ObeliskName;
		obeliskDescriptionText.text = obelisk.Description;
		GetComponent<AutoTransformRebuild>().RebuildTransform();
	}
}
