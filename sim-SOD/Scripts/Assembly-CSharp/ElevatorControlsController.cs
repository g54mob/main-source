using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElevatorControlsController : MonoBehaviour
{
	public InfoWindow parentWindow;

	public Evidence evidence;

	public WindowContentController windowContent;

	public List<RectTransform> buttons;

	public TextMeshProUGUI inputText;

	private void OnEnable()
	{
	}

	public void PressNumberButton(int newInt)
	{
	}
}
