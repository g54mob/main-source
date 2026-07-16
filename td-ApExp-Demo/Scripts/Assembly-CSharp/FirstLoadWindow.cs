using UnityEngine;

public class FirstLoadWindow : MonoBehaviour
{
	public void Accept()
	{
		SaveManager.Instance.SetDataTrackingEnabled(isEnabled: true);
		MenuManager.Instance.CloseCurrentMenu();
	}

	public void Decline()
	{
		SaveManager.Instance.SetDataTrackingEnabled(isEnabled: false);
		MenuManager.Instance.CloseCurrentMenu();
	}
}
