using UnityEngine;

public class TurnOffIfEnglish : MonoBehaviour
{
	private void OnEnable()
	{
		if (PlayerPrefs.GetString("Language") == "ENGLISH")
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
