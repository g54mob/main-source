using UnityEngine;

public class AdventureGUI : MonoBehaviour
{
	public GameObject dogSelectionPanel;

	public GameObject adventureResultsPanel;

	private AdventureButtonBase adventureButtonRef;

	private AdventureDestinationType selectedDestination;

	private AdventureManager adventureRef;

	private void Awake()
	{
		dogSelectionPanel.SetActive(value: false);
		adventureResultsPanel.SetActive(value: false);
		adventureRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<AdventureManager>(GlobalObject.ADVENTURE_MANAGER);
	}

	public void SetAdventureRef(AdventureButtonBase newRef)
	{
		adventureButtonRef = newRef;
	}

	public void CloseGUI()
	{
		adventureButtonRef.UnloadGUI();
	}

	public void ShowDogSelectionPanel()
	{
		dogSelectionPanel.SetActive(value: true);
	}

	public void CloseDogSelectionGUI()
	{
		dogSelectionPanel.SetActive(value: false);
	}

	public void OnDogSelected(ulong dogID)
	{
		CloseDogSelectionGUI();
		DepartOnAdventure(selectedDestination, dogID);
	}

	public void SetSelectedDestination(AdventureDestinationType newType)
	{
		selectedDestination = newType;
	}

	private void DepartOnAdventure(AdventureDestinationType destination, ulong dogID)
	{
		if (adventureRef.CanAdventure())
		{
			AdventureResults adventureResults = adventureRef.GetAdventureResults(destination, dogID);
			ShowResults(adventureResults);
		}
	}

	private void ShowResults(AdventureResults results)
	{
		adventureResultsPanel.SetActive(value: true);
		adventureResultsPanel.GetComponent<AdventureResultsPanel>().DisplayResults(results);
	}

	public void CloseResults()
	{
		adventureRef.OnAdventureFinished();
		adventureResultsPanel.SetActive(value: false);
	}
}
