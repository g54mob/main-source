using DV.Interaction;
using DV.VRTK_Extensions;

public class CassetteUseVR : CassetteUseBase
{
	private VRTK_InteractableObject_DV interactable;

	protected override void ModeSpecificInitialize()
	{
	}

	public override bool HandleUse(ItemUseTarget target)
	{
		CassetteInteractionArea component = target.GetComponent<CassetteInteractionArea>();
		if (component == null)
		{
			return false;
		}
		component.RequestInsertCassette(cassette);
		return true;
	}
}
