using DV.Interaction;
using DV.Utils;
using UnityEngine;

public class CassetteUseNonVR : CassetteUseBase
{
	private GrabHandlerItem grabHandler;

	private RaycastHitDV currentHit;

	private Grabber grabber;

	protected override void ModeSpecificInitialize()
	{
		grabHandler = GetComponent<GrabHandlerItem>();
		if (grabHandler == null || cassetteItem == null || cassette == null)
		{
			Debug.LogWarning("Couldn't extract GrabHandlerItem, ItemBase, or Cassette used for nonVR interaction. Destroying self!", this);
			Object.Destroy(this);
		}
	}

	public override bool HandleUse(ItemUseTarget target)
	{
		CassetteInteractionArea componentInParent = target.GetComponentInParent<CassetteInteractionArea>();
		if (componentInParent == null || componentInParent.GetInsertedCassette() != null)
		{
			return false;
		}
		grabHandler.ForceEndInteraction();
		componentInParent.RequestInsertCassette(cassette);
		return true;
	}
}
