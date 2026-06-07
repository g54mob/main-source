using I2.Loc;
using TMPro;
using UnityEngine;

public class ClockOffUI : MonoBehaviour
{
	[Header("Texts")]
	[SerializeField]
	private TMP_Text headerText;

	[SerializeField]
	private TMP_Text descText;

	[SerializeField]
	private TMP_Text buttonText;

	[Header("Demo")]
	[SerializeField]
	private GameObject demoWarningObj;

	private void OnEnable()
	{
		UpdateUI();
	}

	private void UpdateUI()
	{
		bool num = SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo;
		bool flag = FactoryManager.Instance != null && FactoryManager.Instance.Level >= 3;
		bool flag2 = num && flag;
		if (buttonText != null)
		{
			buttonText.text = LocalizationManager.GetTranslation(flag2 ? "End Demo" : "Clock Out");
		}
		if (demoWarningObj != null)
		{
			demoWarningObj.SetActive(flag2);
		}
	}
}
