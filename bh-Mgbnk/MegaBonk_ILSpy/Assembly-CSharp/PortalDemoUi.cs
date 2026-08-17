using Assets.Scripts.Utility;
using UnityEngine;

public class PortalDemoUi : MonoBehaviour
{
	public void Open()
	{
		MyTime.Pause();
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
	}

	private void OnDisable()
	{
		MyTime.Unpause();
	}
}
