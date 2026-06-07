using System;
using TMPro;
using UnityEngine.UI;

public class TooltipCapacityListItem : MenuButton
{
	public MenuButton expandSectionButton;

	public Image expandSectionImage;

	public TextMeshProUGUI descriptionLabel;

	public ProgressBar progressBar;

	public ConsumableState loadedState;

	[NonSerialized]
	public new bool isInitialized;

	public void ReloadLabel()
	{
		descriptionLabel.text = "Inventory".Localized();
	}

	protected override void Update()
	{
		base.Update();
		if (loadedState != null)
		{
			progressBar.TryUpdateDisplay(loadedState);
		}
	}
}
