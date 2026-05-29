using UnityEngine;
using UnityEngine.EventSystems;

public class TempHouseButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public BuildingSO tempHouseBuildingSO;

	private bool isUnlocked = true;

	private bool canUnlock;

	private bool isHoveringOver;

	private bool infoPanelIsOpen;

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHoveringOver = true;
	}

	private void Update()
	{
		if (isHoveringOver && isUnlocked && !infoPanelIsOpen)
		{
			infoPanelIsOpen = true;
			BuildInfoPanel.ins.SetInfo(tempHouseBuildingSO);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHoveringOver = false;
		infoPanelIsOpen = false;
		BuildInfoPanel.ins.SetBlank();
	}
}
