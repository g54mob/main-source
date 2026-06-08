using System.Collections.Generic;
using UnityEngine;

public class NavigationGroup : MonoBehaviour
{
	public AsciiSprite selectionSprite;

	public List<INavigatable> targetObjects = new List<INavigatable>();

	public int selectedIndex = -1;

	private bool refreshSelection;

	public void Add(INavigatable obj)
	{
		targetObjects.Add(obj);
	}

	public void UpdateTic()
	{
		refreshSelection = true;
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (refreshSelection)
		{
			refreshSelection = false;
			selectedIndex = -1;
			AsciiCellProcedural cell = r.GetCell(AsciiMouse.singleton.x, AsciiMouse.singleton.y);
			if (cell == null)
			{
				return;
			}
			ICellInteractable interactionLayer = cell.GetInteractionLayer();
			for (int i = 0; i < targetObjects.Count; i++)
			{
				if (interactionLayer == targetObjects[i])
				{
					selectedIndex = i;
					selectionSprite.Draw(r, interactionLayer.GetCenterX(), interactionLayer.GetCenterY());
					break;
				}
			}
		}
		else if (selectedIndex >= 0 && selectedIndex < targetObjects.Count)
		{
			ICellInteractable cellInteractable = (ICellInteractable)targetObjects[selectedIndex];
			if (cellInteractable != null)
			{
				selectionSprite.Draw(r, cellInteractable.GetCenterX(), cellInteractable.GetCenterY());
			}
		}
	}
}
