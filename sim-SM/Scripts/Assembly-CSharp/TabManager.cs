using UnityEngine;

public class TabManager : MonoBehaviour
{
	private WindowTab[] m_Tabs;

	[HideInInspector]
	public WindowTab currentTab;

	public WindowTab FirstTab => null;

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void OpenTab(string tabName)
	{
	}

	public void ResetTabs()
	{
	}
}
