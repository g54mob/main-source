public class Dresser : EntityMonoBehaviour
{
	public virtual void Use()
	{
		Manager.ui.OnVanitySlotsOpen();
	}

	public void OnPlayerLeftBuilding()
	{
		Manager.ui.HideAllInventoryAndCraftingUI();
	}
}
