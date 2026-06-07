using UnityEngine;

public class GenericMenuManager : MonoBehaviour
{
	public enum MenuState
	{
		idle = 0,
		open = 1
	}

	public static GenericMenuManager Singleton;

	public MenuState menuState;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Update()
	{
		if (HudManager.Singleton.activeUiGroup == HudManager.ActiveUiGroup.Playing)
		{
			menuState = MenuState.idle;
		}
		else
		{
			menuState = MenuState.open;
		}
	}
}
