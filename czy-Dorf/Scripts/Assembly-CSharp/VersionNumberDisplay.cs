using Dorfromantik;
using TMPro;
using UnityEngine;

public class VersionNumberDisplay : MonoBehaviour
{
	private TextMeshProUGUI versionNumberLabel;

	[SerializeField]
	private BuildInfo buildInfo;

	[SerializeField]
	private Color buildNumberColor = Color.white;

	private void OnEnable()
	{
		versionNumberLabel = GetComponent<TextMeshProUGUI>();
		string text = "";
		if (buildInfo.branchName.ToLower().Contains("beta"))
		{
			text = "b";
		}
		else if (buildInfo.branchName.ToLower().Contains("testing"))
		{
			text = "t";
		}
		versionNumberLabel.text = Application.version + text + " <color=#" + ColorUtility.ToHtmlStringRGBA(buildNumberColor) + ">" + buildInfo.buildNumber;
	}
}
