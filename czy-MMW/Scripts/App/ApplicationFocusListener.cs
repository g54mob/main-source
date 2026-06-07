using Rewired;
using UnityEngine;

public class ApplicationFocusListener : MonoBehaviour
{
	private RuntimeAppCommandSource _appCommandSource;

	public static Controller LastKnownController;

	public void Initialize(RuntimeAppCommandSource appCommandSource)
	{
		_appCommandSource = appCommandSource;
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		_appCommandSource.AppHasFocus = hasFocus;
	}
}
