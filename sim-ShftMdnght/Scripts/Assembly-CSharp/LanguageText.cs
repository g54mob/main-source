using TMPro;
using UnityEngine;

public class LanguageText : MonoBehaviour
{
	public bool useTextComponentAsKey;

	public string id = "UI Text 4";

	public string key;

	public bool resetEveryEnable;

	public bool fontOnly;

	public void OnEnable()
	{
		if (resetEveryEnable)
		{
			Start();
		}
	}

	public void Start()
	{
		GetComponent<TextMeshProUGUI>().font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		if (!fontOnly)
		{
			if (useTextComponentAsKey)
			{
				GetComponent<TextMeshProUGUI>().text = JSONAccess.Instance.GetMiscText(id, GetComponent<TextMeshProUGUI>().text);
			}
			else
			{
				GetComponent<TextMeshProUGUI>().text = JSONAccess.Instance.GetMiscText(id, key);
			}
		}
	}
}
