using UnityEngine;

public class MapCoorsTexScript : MonoBehaviour
{
	private JoystickCursorScript JoyScript;

	private void Start()
	{
		JoyScript = GameObject.Find("JoystickCursor").GetComponent<JoystickCursorScript>();
	}

	private void Update()
	{
	}

	private void OnGUI()
	{
		if (!JoyScript.JoystickCursorActive)
		{
			Transform obj = base.transform;
			Vector3 position = (base.transform.position = Input.mousePosition);
			obj.position = position;
		}
		else
		{
			base.transform.position = JoyScript.MyRect.position;
		}
	}
}
