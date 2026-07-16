using UnityEngine;

public class ScreenSettingsBootstrapper : MonoBehaviour
{
	public MenuSettings set;

	private void Start()
	{
		MenuManager.Instance.GetMenu(MenuType.Options).GetComponent<MenuSettings>();
		set.UpdateScreenState();
	}

	private void LateUpdate()
	{
		if (set.isScreenStateDirty)
		{
			set.isScreenStateDirty = false;
			set.UpdateScreenState();
		}
	}
}
