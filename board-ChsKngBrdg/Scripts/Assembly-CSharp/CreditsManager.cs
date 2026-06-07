using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
	private SoundManager soundManager;

	public TMP_Text creditsText;

	public List<LocalizedString> creditsList;

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
		creditsText.gameObject.SetActive(value: false);
		SpeedrunTimer.doCountTime = false;
		StartCoroutine(Credits());
	}

	public IEnumerator Credits()
	{
		foreach (LocalizedString creditsEntry in creditsList)
		{
			yield return new WaitForSeconds(1f);
			creditsText.text = creditsEntry.GetLocalizedString();
			creditsText.gameObject.SetActive(value: true);
			SoundManager.LoadSoundEffect(base.transform, soundManager.titel_impact);
			yield return new WaitForSeconds(4f);
			creditsText.gameObject.SetActive(value: false);
		}
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene("Menu");
	}
}
