using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsToggleInitializer : MonoBehaviour
{
	[SerializeField]
	private string playerPrefsKey;

	[SerializeField]
	private int defaultValue = 1;

	private Toggle toggle;

	private Image toggleBg;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		toggleBg = GetComponent<Image>();
	}

	private void Start()
	{
		if (!string.IsNullOrWhiteSpace(playerPrefsKey))
		{
			bool isOnWithoutNotify = PlayerPrefs.GetInt(playerPrefsKey, defaultValue) == 1;
			toggle.SetIsOnWithoutNotify(isOnWithoutNotify);
			toggleBg.enabled = isOnWithoutNotify;
		}
	}
}
