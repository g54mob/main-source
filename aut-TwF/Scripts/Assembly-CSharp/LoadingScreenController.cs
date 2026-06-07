using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
	public static int sceneToLoadIdx;

	[SerializeField]
	private LevelGenerator levelGenerator;

	[Header("Tips")]
	[SerializeField]
	private TextMeshProUGUI tipsText;

	[SerializeField]
	private LocalizedString[] tips;

	private bool generatingLevel;

	private void Start()
	{
		Time.timeScale = 1f;
		AudioSystem.Instance.ResetAllMixersVolumes();
		if (sceneToLoadIdx == 3)
		{
			StartCoroutine(GenerateLevelCotoutine());
		}
		LoadNextTip();
		LoadLevel();
	}

	private IEnumerator GenerateLevelCotoutine()
	{
		generatingLevel = true;
		yield return new WaitForSeconds(0.5f);
		LevelData currentLevelData = MatchInfo.instance.CurrentLevelData;
		EMapSize mapSize = MatchInfo.instance.CurrentMatchSettings.MapSize;
		yield return levelGenerator.GenerateLevel(MatchInfo.instance.CurrentLevelData != null, currentLevelData, mapSize);
		generatingLevel = false;
	}

	private void LoadNextTip()
	{
		int num = 0;
		if (PlayerPrefs.HasKey("lastTipIndex"))
		{
			num = PlayerPrefs.GetInt("lastTipIndex");
			num++;
			num %= tips.Length;
		}
		tipsText.text = tips[num].GetLocalizedString();
		PlayerPrefs.SetInt("lastTipIndex", num);
	}

	private void LoadLevel()
	{
		StartCoroutine(LoadLevelCoroutine());
	}

	private IEnumerator LoadLevelCoroutine()
	{
		int sceneBuildIndex = sceneToLoadIdx;
		float startLoadTime = Time.time;
		float minLoadTime = 1.5f;
		AsyncOperation loadAsyncOp = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Single);
		loadAsyncOp.allowSceneActivation = false;
		while (!loadAsyncOp.isDone)
		{
			if (loadAsyncOp.progress >= 0.9f && Time.time - startLoadTime > minLoadTime && !generatingLevel)
			{
				loadAsyncOp.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}
