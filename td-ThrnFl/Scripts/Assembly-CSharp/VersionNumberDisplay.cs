using TMPro;
using UnityEngine;

public class VersionNumberDisplay : MonoBehaviour
{
	public TextMeshProUGUI display;

	private void OnEnable()
	{
		display.text = "version " + Application.version;
	}
}
