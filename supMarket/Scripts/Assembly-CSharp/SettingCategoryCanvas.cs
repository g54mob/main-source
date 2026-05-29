using UnityEngine;
using __Project__.Scripts.UI;

public class SettingCategoryCanvas : NoktaSingleton<SettingCategoryCanvas>
{
	[SerializeField]
	private GameObject m_Menu;

	[SerializeField]
	private CategoryNameOverlay m_CategoryOverlay;

	private bool m_enabled;

	public bool Enable
	{
		set
		{
		}
	}

	private void SetCursor(bool isGamepad)
	{
	}

	private void Start()
	{
	}

	public void OpenMenu()
	{
	}

	public void CloseMenu()
	{
	}

	private void SetCategory(string input)
	{
	}
}
