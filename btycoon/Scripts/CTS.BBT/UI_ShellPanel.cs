using UnityEngine;

public class UI_ShellPanel : MonoBehaviour
{
	[SerializeField]
	private GameObject _shellFurniturePanel;

	[SerializeField]
	private GameObject _buyConstructionPanel;

	public void ActiveFurnitureShell()
	{
		_shellFurniturePanel.SetActive(value: true);
		_buyConstructionPanel.SetActive(value: false);
	}

	public void ActiveBuyConstructionPanel()
	{
		_shellFurniturePanel.SetActive(value: false);
		_buyConstructionPanel.SetActive(value: true);
	}
}
