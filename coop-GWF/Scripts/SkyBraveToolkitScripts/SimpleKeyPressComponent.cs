using UnityEngine;
using UnityEngine.Events;

public class SimpleKeyPressComponent : MonoBehaviour
{
	public KeyCode KeyToCheck;

	public UnityEvent onKeyPressed;

	private void Update()
	{
		if (Input.GetKeyDown(KeyToCheck))
		{
			onKeyPressed.Invoke();
		}
	}
}
