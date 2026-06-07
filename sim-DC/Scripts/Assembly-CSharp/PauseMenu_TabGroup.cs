using System.Collections.Generic;
using UnityEngine;

public class PauseMenu_TabGroup : MonoBehaviour
{
	public List<PauseMenu_TabButton> tabButtons;

	public PauseMenu_TabButton selectedTab;

	public List<GameObject> objectsToSwap;

	public void Subscribe(PauseMenu_TabButton tabbutton)
	{
	}

	public void OnTabEnter(PauseMenu_TabButton tabbutton)
	{
	}

	public void OnTabExit(PauseMenu_TabButton tabbutton)
	{
	}

	public void OnTabSelected(PauseMenu_TabButton tabbutton)
	{
	}

	public void ResetTabs()
	{
	}
}
