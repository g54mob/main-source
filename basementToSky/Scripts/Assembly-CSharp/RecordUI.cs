using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI recordText;

	[SerializeField]
	private TextMeshProUGUI highRecordText;

	[SerializeField]
	private TextMeshProUGUI scoreText;

	[SerializeField]
	private GameObject scoreTextPrefab;

	[SerializeField]
	private Transform scoreTextPos;

	private List<GameObject> scoreList = new List<GameObject>();

	[SerializeField]
	private GameObject windSpeedText;

	[SerializeField]
	private WindDirectionArrow dirArrow;

	[SerializeField]
	private GameObject rocketCamUI;

	[SerializeField]
	private GameObject windDirArrow;

	private float lastRecord;

	private float highRecord;

	private int score;

	private int heightScore;

	private float scorePerMeter = 10f;

	private void Start()
	{
		highRecord = ES3.Load("HighRecord", 0f);
		highRecordText.text = Mathf.Round(highRecord * 10f) / 10f + "M";
		recordText.text = "0 M";
		QuestManager.S.OnRocketRecord += Qm_OnRocketRecord;
		GameManager.S.OnRocketLaunch += Gm_OnRocketLaunch;
		DigitalCamera.OnDicaInstalled += DigitalCamera_OnDicaInstalled;
		RocketMount.OnRocketMounted += RocketMount_OnRocketMounted;
		BusStopUI.OnRocketRetrived += BusStopUI_OnRocketRetrived;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		GameManager.S.OnRocketLanded += S_OnRocketLanded;
		ScoreSystem.OnScored += ScoreSystem_OnScored;
		rocketCamUI.SetActive(value: false);
	}

	private void DigitalCamera_OnDicaInstalled()
	{
		if (GameManager.S.isDicaInstalled || GameManager.S.isRocketCamInstalled)
		{
			rocketCamUI.SetActive(value: true);
		}
	}

	private void ScoreSystem_OnScored(string arg1, int arg2)
	{
		AudioManager.S.PlaySFX(AudioManager.S.score);
		GameObject gameObject = UnityEngine.Object.Instantiate(scoreTextPrefab, scoreTextPos);
		gameObject.transform.SetAsFirstSibling();
		scoreList.Add(gameObject);
		if (scoreList.Count > 3)
		{
			UnityEngine.Object.Destroy(scoreList[2]);
			scoreList.RemoveAt(2);
		}
		gameObject.GetComponent<ScoreTextUI>().scoreText.text = $"{arg1} +{arg2}";
		score += arg2;
		scoreText.text = score.ToString();
	}

	private void PauseUI_OnSaveAndQuit()
	{
		ES3.Save("HighRecord", highRecord);
		ES3.Save("LastRecord", lastRecord);
	}

	private void BusStopUI_OnRocketRetrived()
	{
		rocketCamUI.SetActive(value: false);
	}

	private void RocketMount_OnRocketMounted()
	{
		if (GameManager.S.isDicaInstalled || GameManager.S.isRocketCamInstalled)
		{
			rocketCamUI.SetActive(value: true);
		}
	}

	private void Gm_OnRocketLaunch(int obj)
	{
		recordText.gameObject.SetActive(value: true);
		highRecordText.gameObject.SetActive(value: true);
		if (GameManager.S.isDicaInstalled)
		{
			scoreText.gameObject.SetActive(value: true);
		}
		if (scoreList.Count != 0)
		{
			foreach (GameObject score in scoreList)
			{
				UnityEngine.Object.Destroy(score.gameObject);
			}
			scoreList.Clear();
		}
		if (GameManager.S.isWindRooksterInstalled)
		{
			windDirArrow.gameObject.SetActive(value: true);
			dirArrow.target = dirArrow.targetUI0;
		}
		if (GameManager.S.isAnemometerInstalled)
		{
			windSpeedText.SetActive(value: true);
			dirArrow.target = dirArrow.targetUI;
		}
		lastRecord = 0f;
		recordText.text = "0 M";
		this.score = 0;
		heightScore = 0;
		scoreText.text = this.score.ToString();
	}

	private void Qm_OnRocketRecord(float record)
	{
		if (record > lastRecord)
		{
			float num = record - lastRecord;
			int num2 = 0;
			float num3 = 2f;
			if (record <= 1000f)
			{
				num2 = Mathf.FloorToInt(num * scorePerMeter);
			}
			else if (lastRecord < 1000f && record > 1000f)
			{
				float num4 = 1000f - lastRecord;
				float num5 = record - 1000f;
				num2 = Mathf.FloorToInt(num4 * scorePerMeter + num5 * num3);
			}
			else
			{
				num2 = Mathf.FloorToInt(num * num3);
			}
			float num6 = 1f;
			if (GameManager.S.intelPerkList[0])
			{
				num6 += 0.2f;
			}
			if (GameManager.S.isRocketCamInstalled)
			{
				num6 += 0.2f;
			}
			num2 = Mathf.FloorToInt((float)num2 * num6);
			if (num2 > 0)
			{
				score += num2;
				scoreText.text = score.ToString();
			}
			lastRecord = record;
			recordText.text = Mathf.Round(record * 10f) / 10f + "M";
			if (lastRecord > highRecord)
			{
				highRecord = lastRecord;
				highRecordText.text = recordText.text;
			}
		}
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
		QuestManager.S.OnRocketRecord -= Qm_OnRocketRecord;
		GameManager.S.OnRocketLaunch -= Gm_OnRocketLaunch;
		DigitalCamera.OnDicaInstalled -= DigitalCamera_OnDicaInstalled;
		RocketMount.OnRocketMounted -= RocketMount_OnRocketMounted;
		BusStopUI.OnRocketRetrived -= BusStopUI_OnRocketRetrived;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		GameManager.S.OnRocketLanded -= S_OnRocketLanded;
		ScoreSystem.OnScored -= ScoreSystem_OnScored;
	}

	private void S_OnRocketLanded(object sender, EventArgs e)
	{
		recordText.gameObject.SetActive(value: false);
		highRecordText.gameObject.SetActive(value: false);
		scoreText.gameObject.SetActive(value: false);
		windDirArrow.gameObject.SetActive(value: false);
		windSpeedText.SetActive(value: false);
		ES3.Save("Score", score);
	}
}
