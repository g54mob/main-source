using UnityEngine;
using UnityEngine.UI;

public class MenuSwapper : MonoBehaviour
{
	public Character character;

	public GameObject startMenu;

	public GameObject[] menus;

	public GameObject[] bigMenus;

	public GameObject[] allMenus;

	private GameObject menuOut;

	private GameObject temp;

	public int menuID;

	public GameObject smallAnchor;

	public GameObject bigAnchor;

	public bool stupidShit;

	private CanvasRenderer[] renderers;

	private void Start()
	{
		startMenu.transform.Translate(new Vector3(Screen.width * 2, Screen.height * 2));
		menus = GameObject.FindGameObjectsWithTag("Menu");
		bigMenus = GameObject.FindGameObjectsWithTag("Menu Big");
		for (int i = 0; i < allMenus.Length; i++)
		{
			allMenus[i].transform.position = new Vector3(10000f, 10000f);
		}
		startMenu.GetComponent<Canvas>().enabled = true;
		startMenu.transform.GetChild(0).position = new Vector3(smallAnchor.transform.position.x, smallAnchor.transform.position.y);
		menuID = 0;
		swapMenu(0);
		Invoke("doDumbShit", 0.3f);
	}

	public void swapMenu(int menuIn)
	{
		if (character.challenges.trollMenuSwap && Random.value <= 0.75f)
		{
			menuIn = Random.Range(0, 40);
			if (menuIn == 1 || menuIn == 2 || menuIn == 17 || menuIn == 24 || (menuIn == 4 && character.bossID < 4) || (menuIn == 5 && character.bossID < 17) || (menuIn == 6 && character.bossID < 37) || (menuIn == 7 && character.bossID < 37) || (menuIn == 18 && character.bossID < 30) || (menuIn == 39 && !character.settings.beardsOn))
			{
				menuIn = 0;
			}
		}
		if (menuIn != menuID)
		{
			swapOut(allMenus[menuID]);
			swapIn(allMenus[menuIn]);
			menuID = menuIn;
			character.menuID = menuID;
			character.refreshMenus();
		}
	}

	public void swapOut(GameObject menu)
	{
		if (menu != null)
		{
			menu.GetComponent<Canvas>().enabled = false;
			menu.GetComponentInChildren<GraphicRaycaster>().enabled = false;
			menu.transform.Translate(new Vector3(Screen.width * 3, Screen.height * 3));
			menu.transform.GetChild(0).Translate(new Vector3(Screen.width * 3, Screen.height * 3));
		}
	}

	public void swapIn(GameObject menu)
	{
		if (menu != null)
		{
			if (menu.transform.GetChild(0).tag == "Menu")
			{
				menu.GetComponent<Canvas>().transform.position = new Vector3(smallAnchor.transform.position.x, smallAnchor.transform.position.y);
				menu.transform.GetChild(0).position = new Vector3(smallAnchor.transform.position.x, smallAnchor.transform.position.y);
			}
			else
			{
				menu.GetComponent<Canvas>().transform.position = new Vector3(bigAnchor.transform.position.x, bigAnchor.transform.position.y);
				menu.transform.GetChild(0).position = new Vector3(bigAnchor.transform.position.x, bigAnchor.transform.position.y);
			}
			menu.GetComponent<Canvas>().enabled = true;
			menu.GetComponentInChildren<GraphicRaycaster>().enabled = true;
		}
	}

	public void doDumbShit()
	{
		for (int i = 0; i < allMenus.Length; i++)
		{
			if (allMenus[i] != null && i != menuID)
			{
				allMenus[i].GetComponent<Canvas>().enabled = true;
				allMenus[i].transform.Translate(new Vector3(-Screen.width * 2, -Screen.height * 2));
				allMenus[i].transform.Translate(new Vector3(Screen.width * 2, Screen.height * 2));
				allMenus[i].GetComponent<Canvas>().enabled = false;
				allMenus[i].GetComponentInChildren<GraphicRaycaster>().enabled = false;
			}
		}
	}
}
