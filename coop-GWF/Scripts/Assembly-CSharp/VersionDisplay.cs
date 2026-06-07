using TMPro;
using UnityEngine;

public class VersionDisplay : MonoBehaviour
{
	private TextMeshProUGUI versionText;

	private void Start()
	{
		versionText = GetComponent<TextMeshProUGUI>();
		versionText.text = Application.version;
	}
}
