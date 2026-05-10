using UnityEngine;
using __Project__.Scripts.Computer;

public class ComputerOperatingSystem : MonoBehaviour
{
	[SerializeField]
	private AppWindow[] m_AppWindows;

	private AppWindow m_CurrentWindow;

	private AppWindow GetAppWindowByName(string appName)
	{
		return null;
	}

	public void OpenApp(string appName)
	{
	}

	public void CloseApp(string appName)
	{
	}

	public void CloseAllApp()
	{
	}
}
