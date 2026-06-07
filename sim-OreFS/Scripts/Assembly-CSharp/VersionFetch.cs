using System.Collections;
using TMPro;
using UnityEngine;

public class VersionFetch : MonoBehaviour
{
	[Header("UI")]
	[SerializeField]
	private TextMeshProUGUI versionText;

	[Header("Steam")]
	[SerializeField]
	private SteamAppChecker steamAppChecker;

	private void OnEnable()
	{
		if (versionText == null)
		{
			Debug.LogWarning("[VersionFetch] TextMeshProUGUI (versionText) atanmadı!");
			return;
		}
		if (steamAppChecker == null)
		{
			steamAppChecker = SteamAppChecker.Instance;
		}
		StartCoroutine(VersionCheckCoroutine());
	}

	private IEnumerator VersionCheckCoroutine()
	{
		yield return new WaitForSecondsRealtime(0.1f);
		string text = "v" + Application.version;
		string text2 = string.Empty;
		if (steamAppChecker != null)
		{
			text2 = steamAppChecker.CurrentGameVersion switch
			{
				GameVersion.Demo => " Demo", 
				GameVersion.Prologue => " Prologue", 
				_ => string.Empty, 
			};
		}
		else
		{
			Debug.LogWarning("[VersionFetch] SteamAppChecker bulunamadı. Demo/Prologue etiketi yazılmayacak.");
		}
		versionText.text = text + text2;
	}
}
