using UnityEngine;

public class ResearchGUI : MonoBehaviour
{
	public GameObject dogSelectionPanel;

	private void Awake()
	{
		dogSelectionPanel.SetActive(value: false);
	}
}
