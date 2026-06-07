using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_Card : AUICard
{
	[SerializeField]
	private UI_CardFace cardFace;

	[SerializeField]
	private Image image_Icon;

	protected override void SetupContentProc(CardData cardData)
	{
	}

	protected override void OnClickButtonProc()
	{
	}

	protected override void DraggingOntoFieldProc()
	{
	}

	private void ActivateBuildMode()
	{
	}

	private void OnPlacementSuccessCallback()
	{
	}

	protected override void EndDragProc()
	{
	}

	public void OverrideIconSprite(Sprite sprite)
	{
	}

	public void UpdateRune(int slotIndex)
	{
	}

	public void PlayCardUpgradeVFX()
	{
	}

	protected override void ToggleSelectedEffectProc(bool isOn)
	{
	}

	public void ActivateCard()
	{
	}

	protected override void ToggleBannedProc(bool isBanned)
	{
	}

	protected override void ToggleCorruptedProc(bool isCorrupted)
	{
	}

	protected override void OnPointerEnterProc()
	{
	}

	protected override void OnPointerExitProc()
	{
	}
}
