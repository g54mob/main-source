using UnityEngine;
using UnityEngine.UI;

public class UIOptionSelector : MonoBehaviour
{
	public string[] Options;

	public Text CurrentOptionLabel;

	public int DefaultOption;

	public UIOptionChangedEvent OnOptionChanged = new UIOptionChangedEvent();

	private int currentSelection;

	private void Start()
	{
		currentSelection = DefaultOption;
		updateCurrentOption();
	}

	public void Previous()
	{
		currentSelection--;
		if (currentSelection < 0)
		{
			currentSelection = 0;
		}
		updateCurrentOption();
		OnOptionChanged.Invoke(currentSelection);
	}

	public void Next()
	{
		currentSelection++;
		if (currentSelection >= Options.Length)
		{
			currentSelection = Options.Length - 1;
		}
		updateCurrentOption();
		OnOptionChanged.Invoke(currentSelection);
	}

	private void updateCurrentOption()
	{
		CurrentOptionLabel.text = Options[currentSelection];
	}
}
