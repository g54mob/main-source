using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
	[SerializeField]
	private GameObject parentCanvas;

	[SerializeField]
	private GameObject destinationCanvas;

	public void ToggleCanvas()
	{
		parentCanvas.SetActive(value: false);
		destinationCanvas.SetActive(value: true);
	}
}
