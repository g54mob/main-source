using UnityEngine;

public class AdventureDestination : MonoBehaviour
{
	public GameObject progressBar;

	public GameObject selectionButton;

	public AdventureGUI guiRef;

	public AdventureDestinationType destinationType;

	private void Awake()
	{
		progressBar.SetActive(value: false);
		selectionButton.SetActive(value: true);
	}

	public void OnDestinationSelected()
	{
		guiRef.SetSelectedDestination(destinationType);
		guiRef.ShowDogSelectionPanel();
	}
}
