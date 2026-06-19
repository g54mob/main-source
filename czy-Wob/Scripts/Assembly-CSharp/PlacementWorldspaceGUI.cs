public class PlacementWorldspaceGUI : WorldSpaceBillboard
{
	private PlaceableObject objectRef;

	public void SetObjectRef(PlaceableObject newRef)
	{
		objectRef = newRef;
	}

	public void OnEditButtonClicked()
	{
		objectRef.OnEditButtonClicked();
	}

	public void OnMoveButtonClicked()
	{
		objectRef.OnMoveButtonClicked();
	}

	public void OnDestroyButtonClicked()
	{
		objectRef.OnDestroyButtonClicked();
	}
}
