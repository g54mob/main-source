using TMPro;
using UnityEngine;

public class RoachCountdown : MonoBehaviour
{
	public int curRats;

	public int maxRats = 15;

	public TextMeshProUGUI ratsAmount;

	public TextMeshProUGUI timeRemaining;

	public float secondsRemaining;

	private bool gotObjective;

	public static RoachCountdown Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public void StartEvent(int maxRats_)
	{
		curRats = 0;
		secondsRemaining = 60f;
		maxRats = maxRats_;
		CurrentDayManager.Instance.Invoke("CompleteOccurrence", 57f);
		ratsAmount.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		ratsAmount.text = curRats + " / " + maxRats;
	}

	public void GotARoach()
	{
		curRats++;
		ratsAmount.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		ratsAmount.text = curRats + " / " + maxRats;
		if (curRats >= maxRats && !gotObjective)
		{
			gotObjective = true;
			StoreManager.Instance.SetAlert("OBJECTIVE COMPLETE", "green");
			StoreManager.Instance.Invoke("CollectRoachObjective", 1.2f);
			base.gameObject.SetActive(value: false);
		}
	}

	private void FixedUpdate()
	{
		timeRemaining.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		timeRemaining.text = FormatTime((int)secondsRemaining);
		if (secondsRemaining < 0f)
		{
			if (base.gameObject.activeSelf)
			{
				gotObjective = true;
				StoreManager.Instance.SetAlert("OBJECTIVE FAILED", "red");
				base.gameObject.SetActive(value: false);
			}
		}
		else
		{
			secondsRemaining -= Time.deltaTime;
		}
	}

	public static string FormatTime(int totalSeconds)
	{
		int num = totalSeconds / 60;
		int num2 = totalSeconds % 60;
		return $"{num:D2}:{num2:D2}";
	}
}
