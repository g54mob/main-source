using UnityEngine;

public class StartMenu : MonoBehaviour
{
	public Character character;

	public GameObject startMenu;

	public void intro()
	{
		if (character.firstTimePlaying)
		{
			startMenu.transform.localPosition = new Vector3(0f, 0f);
		}
		else
		{
			hideMenu();
		}
	}

	public void hideMenu()
	{
		startMenu.transform.position = new Vector3(-5000f, -5000f);
		CanvasRenderer[] componentsInChildren = startMenu.GetComponentsInChildren<CanvasRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].SetAlpha(0f);
		}
		if (character.firstTimePlaying)
		{
			character.tooltip.startTutorial();
		}
		else
		{
			character.tooltip.displayState();
		}
	}

	public void hideMenuStartTutorial()
	{
		startMenu.transform.position = new Vector3(-5000f, -5000f);
		CanvasRenderer[] componentsInChildren = startMenu.GetComponentsInChildren<CanvasRenderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].SetAlpha(0f);
		}
		if (character.firstTimePlaying)
		{
			character.tooltip.startTutorial();
		}
		else
		{
			character.tooltip.displayState();
		}
	}
}
