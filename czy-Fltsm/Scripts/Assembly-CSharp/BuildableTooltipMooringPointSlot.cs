using UnityEngine;

public class BuildableTooltipMooringPointSlot : BuildableTooltipSlot
{
	[Header("Sprites")]
	[Tooltip("Background sprite for valid requirement.")]
	[SerializeField]
	private Sprite _validBackgroundSprite;

	[Tooltip("Background sprite for invalid requirement.")]
	[SerializeField]
	private Sprite _invalidBackgroundSprite;

	public override void UpdateSlot()
	{
		base.UpdateSlot();
		_backgroundImage.sprite = (Community.PlayerCommunity.IsThereAMooringPointFree() ? _validBackgroundSprite : _invalidBackgroundSprite);
	}
}
