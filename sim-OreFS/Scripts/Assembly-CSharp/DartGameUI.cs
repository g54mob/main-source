using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class DartGameUI : MonoBehaviour
{
	[Header("Panel")]
	[SerializeField]
	private GameObject rootPanel;

	[Header("Score Rows (önceden sahneye konmuş)")]
	[SerializeField]
	private List<TextMeshProUGUI> scoreRows;

	[Header("Last Score Display")]
	[SerializeField]
	private TextMeshProUGUI lastDartScoreText;

	[Header("Settings")]
	[SerializeField]
	private float lastScoreFadeDuration = 1.5f;

	private Coroutine fadeCoroutine;

	public void Show()
	{
		if (rootPanel != null)
		{
			rootPanel.SetActive(value: true);
		}
	}

	public void Hide()
	{
		if (rootPanel != null)
		{
			rootPanel.SetActive(value: false);
		}
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
			fadeCoroutine = null;
		}
	}

	public void RefreshScoreboard(SyncList<DartPlayerScore> playerScores)
	{
		List<DartPlayerScore> list = new List<DartPlayerScore>();
		foreach (DartPlayerScore playerScore in playerScores)
		{
			list.Add(playerScore);
		}
		list.Sort((DartPlayerScore a, DartPlayerScore b) => b.score.CompareTo(a.score));
		for (int num = 0; num < scoreRows.Count; num++)
		{
			if (!(scoreRows[num] == null))
			{
				if (num < list.Count)
				{
					scoreRows[num].gameObject.SetActive(value: true);
					scoreRows[num].text = $"{num + 1}. {list[num].playerName}: {list[num].score}";
				}
				else
				{
					scoreRows[num].gameObject.SetActive(value: false);
				}
			}
		}
	}

	public void ShowDartScore(int score, string throwerName)
	{
		if (lastDartScoreText == null)
		{
			return;
		}
		if (score > 0)
		{
			lastDartScoreText.text = $"{throwerName} +{score}";
			if (score >= 50)
			{
				lastDartScoreText.color = Color.red;
			}
			else if (score >= 25)
			{
				lastDartScoreText.color = new Color(1f, 0.5f, 0f);
			}
			else if (score >= 10)
			{
				lastDartScoreText.color = Color.yellow;
			}
			else
			{
				lastDartScoreText.color = Color.white;
			}
		}
		else
		{
			lastDartScoreText.text = throwerName + " MISS";
			lastDartScoreText.color = Color.gray;
		}
		lastDartScoreText.gameObject.SetActive(value: true);
		if (fadeCoroutine != null)
		{
			StopCoroutine(fadeCoroutine);
		}
		fadeCoroutine = StartCoroutine(FadeLastScore());
	}

	public void OnScoreReset()
	{
		for (int i = 0; i < scoreRows.Count; i++)
		{
			if (scoreRows[i] != null)
			{
				scoreRows[i].gameObject.SetActive(value: false);
			}
		}
		if (lastDartScoreText != null)
		{
			lastDartScoreText.gameObject.SetActive(value: false);
		}
	}

	private IEnumerator FadeLastScore()
	{
		yield return new WaitForSeconds(lastScoreFadeDuration);
		if (lastDartScoreText != null)
		{
			lastDartScoreText.gameObject.SetActive(value: false);
		}
		fadeCoroutine = null;
	}
}
