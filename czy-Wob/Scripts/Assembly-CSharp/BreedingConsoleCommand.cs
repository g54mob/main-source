using TMPro;
using UnityEngine;

public class BreedingConsoleCommand : MonoBehaviour
{
	public TextMeshProUGUI consoleText;

	public void SetText(string command)
	{
		consoleText.text = command;
	}
}
