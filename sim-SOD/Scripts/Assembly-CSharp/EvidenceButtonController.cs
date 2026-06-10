using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EvidenceButtonController : ButtonController, IPointerDownHandler, IEventSystemHandler
{
	public PinnedItemController pinnedController;

	public Evidence evidence;

	public List<Evidence.DataKey> evidenceKeys;

	public RawImage evPhoto;

	public virtual void Setup(Evidence newEvidence, List<Evidence.DataKey> newKeys, PinnedItemController newController)
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	public virtual void ExtraSetup()
	{
	}

	public override void OnLeftClick()
	{
	}

	public override void OnHoverStart()
	{
	}

	public override void OnPointerDown(PointerEventData data)
	{
	}

	public override void VisualUpdate()
	{
	}

	public override void UpdateTooltipText()
	{
	}

	public override void RefreshAutomaticNavigation(bool enableLeft, bool enableRight, bool enableUp, bool enableDown, bool includeInactive)
	{
	}
}
