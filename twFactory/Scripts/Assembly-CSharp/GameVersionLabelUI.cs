using TMPro;
using UnityEngine;

public class GameVersionLabelUI : MonoBehaviour
{
	private void Start()
	{
		GetComponentInChildren<TextMeshProUGUI>().text = Application.version;
	}
}
