using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_WallCard : AUICard
{
	[SerializeField]
	private Image image_Icon;

	protected override void SetupContentProc(CardData cardData)
	{
	}

	protected override void DraggingOntoFieldProc()
	{
	}

	private void OnPlacementSuccessCallback()
	{
	}

	protected override void EndDragProc()
	{
	}
}
