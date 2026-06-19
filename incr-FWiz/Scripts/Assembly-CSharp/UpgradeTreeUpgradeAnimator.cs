using FMODUnity;
using UnityEngine;

public class UpgradeTreeUpgradeAnimator : MonoBehaviour
{
	[SerializeField]
	private UpgradeTreeUI _upgradeTreeUI;

	private UpgradeTreeUIUpgrade _selectedSlot;

	private UpgradeTreeUIUpgrade _hoveredSlot;

	[SerializeField]
	private EventReference _onSelectSlotSound;

	[SerializeField]
	private EventReference _onUnselectSlotSound;

	[SerializeField]
	private UpgradeTreeUpgradeTooltip _tooltip;

	public void Initiate(UpgradeTreeUI upgradeTreeUI)
	{
	}

	private void OnDestroy()
	{
	}

	public void Enable()
	{
	}

	public void Disable()
	{
	}

	public void SetHoveredSlot(UpgradeTreeUIUpgrade hoveredSlot)
	{
	}

	public void ClearHoveredSlot()
	{
	}

	public void UpdateSelectedUIUpgrade(UpgradeTreeUIUpgrade selectedSlot)
	{
	}

	public void OnSelectedUIUpgrade(UpgradeTreeUIUpgrade selectedSlot)
	{
	}

	public void ClearSelectedSlot()
	{
	}
}
