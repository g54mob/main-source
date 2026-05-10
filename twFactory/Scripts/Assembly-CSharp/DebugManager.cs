using UnityEngine;

public class DebugManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			Time.timeScale = 1f;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			Time.timeScale = 2f;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			Time.timeScale = 3f;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			Time.timeScale = 10f;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad9))
		{
			Time.timeScale = 0.25f;
		}
		else if (Input.GetKeyDown(KeyCode.Keypad0))
		{
			Time.timeScale = 0f;
		}
	}
}
