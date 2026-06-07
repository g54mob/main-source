using UnityEngine;

public class DebugConsoleToggle : MonoBehaviour
{
	private void Awake()
	{
		Debug.developerConsoleVisible = true;
	}
}
