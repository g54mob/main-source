using TMPro;
using UnityEngine;

public class InEditorEditModeMenuManager : MonoBehaviour
{
	public GameObject savedNotification;

	public GameObject finalizedNotification;

	public TextMeshProUGUI titleError;

	public GameObject compileError;

	public TextMeshProUGUI[] slotDates;

	public GameObject[] slotLoadButtons;

	public void OnEnable()
	{
	}

	private void RefreshSlots()
	{
	}

	private void RefreshSlot(int slot)
	{
	}

	public void LoadGameEntryClicked()
	{
	}

	public void SaveGameEntryClicked()
	{
	}

	public void LoadSlotClicked(int slot)
	{
	}

	public void SaveSlotClicked(int slot)
	{
	}

	private bool IsObjectiveSet()
	{
		return false;
	}

	public void FinalizeEntryClicked()
	{
	}

	private void GenerateFinalizedScreenshot(string filename)
	{
	}

	public static Texture2D ResizeTexture(Texture2D tex, int width, int height)
	{
		return null;
	}

	public static void CleanMission()
	{
	}

	private string GetFinalizeFile()
	{
		return null;
	}
}
