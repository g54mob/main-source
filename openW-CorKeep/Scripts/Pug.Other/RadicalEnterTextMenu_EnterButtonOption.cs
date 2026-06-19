using I2.Loc;
using UnityEngine;

public class RadicalEnterTextMenu_EnterButtonOption : RadicalMenuOption
{
	public GameObject selectedMarker;

	public RadicalEnterTextMenu enterTextMenu;

	public LocalizedString joinTerm;

	public LocalizedString stopJoinTerm;

	protected override void Update()
	{
		bool flag = labelText.GetText() == joinTerm;
		bool flag2 = labelText.GetText() == stopJoinTerm;
		if (enterTextMenu.IsConnecting && !flag2)
		{
			labelText.Render(stopJoinTerm.mTerm);
		}
		else if (!enterTextMenu.IsConnecting && !flag)
		{
			labelText.Render(joinTerm.mTerm);
		}
		base.Update();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		enterTextMenu.ButtonPressed();
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
	}
}
