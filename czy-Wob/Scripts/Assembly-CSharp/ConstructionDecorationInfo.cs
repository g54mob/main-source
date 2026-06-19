using UnityEngine;

public class ConstructionDecorationInfo : MonoBehaviour
{
	public ulong associatedRoomID;

	public ConstructionManager constructionRef;

	public void OnButtonPressed()
	{
		constructionRef.SetConstructionMode(ConstructionManager.CurrentMode.PLACEMENT, associatedRoomID);
	}
}
