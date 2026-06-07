namespace DV.VRTK_Extensions
{
	public class VRTK_WorldUiButtonInteractable_DV : VRTK_InteractableObject_DV
	{
		public WorldUiButtonVr button;

		public override bool InteractionAllowed => button.active;
	}
}
