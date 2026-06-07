using UnityEngine;

public class DemoQuitSwitch : MonoBehaviour
{
	public UIFrame demoFrame;

	public void Trigger()
	{
		UIFrameManager.instance.QuitToDesktop();
	}
}
