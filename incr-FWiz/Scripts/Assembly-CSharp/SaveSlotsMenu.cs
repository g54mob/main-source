using UnityEngine;

public class SaveSlotsMenu : MonoBehaviour
{
	[SerializeField]
	private SaveSlotUI _uiSaveSlotPrefab;

	[SerializeField]
	private Transform _uiSaveSlotParent;

	[SerializeField]
	private MainMenuController _mainMenu;

	private void Awake()
	{
	}

	public void SelectSlot(int index)
	{
	}

	public void DeleteSlot(int index)
	{
	}

	public void OnAfterSelectSlot()
	{
	}
}
