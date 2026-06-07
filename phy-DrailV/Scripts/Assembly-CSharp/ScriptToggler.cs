using UnityEngine;

public class ScriptToggler : MonoBehaviour
{
	[Header("Enables/disables script when key is pressed")]
	public KeyCode key = KeyCode.H;

	public Behaviour scriptToToggle;

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			scriptToToggle.enabled = !scriptToToggle.enabled;
		}
	}
}
