using System.Collections.Generic;
using UnityEngine;

public class ExampleInputCapture : MonoBehaviour
{
	[SerializeField]
	private KeyCode Cancel;

	[SerializeField]
	private KeyCode Alternate;

	[SerializeField]
	private KeyCode Options;

	[SerializeField]
	private KeyCode TabLeft;

	[SerializeField]
	private KeyCode TabRight;

	[SerializeField]
	private KeyCode Search;

	[SerializeField]
	private KeyCode Menu;

	public List<string> controllerAndKeyboardInput;

	public List<string> mouseInput;

	public string verticalControllerInput;

	private void Update()
	{
	}

	private void HandleInputReceiver()
	{
	}

	private void HandleControllerInput()
	{
	}
}
