using TMPro;
using UnityEngine;

public class DebugOverlayUI : MonoBehaviour
{
	[Header("References")]
	public TMP_Text playTimeText;

	public TMP_Text versionText;

	private void Start()
	{
		versionText.text = "v" + Application.version;
	}

	private void Update()
	{
		if (!(GameManager.Instance == null))
		{
			float totalPlayTime = GameManager.Instance.totalPlayTime;
			int num = (int)(totalPlayTime / 3600f);
			int num2 = (int)(totalPlayTime % 3600f / 60f);
			int num3 = (int)(totalPlayTime % 60f);
			playTimeText.text = ((num > 0) ? $"{num}:{num2:D2}:{num3:D2}" : $"{num2}:{num3:D2}");
		}
	}
}
