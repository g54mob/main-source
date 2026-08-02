using TMPro;
using UnityEngine;

public class TestTimerPanel : MonoBehaviour
{
	public TextMeshProUGUI timerText;

	public TextMeshProUGUI totalTimerText;

	public TextMeshProUGUI currentTimeText;

	public float timer;

	public float totalGameTime;

	public CanvasGroup canvasGroup;

	private bool isShowing;

	private void Start()
	{
		string totalGameTimeSaveKey = GetTotalGameTimeSaveKey();
		totalGameTime = PlayerPrefs.GetFloat(totalGameTimeSaveKey, 0f);
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.F5))
		{
			totalGameTime -= timer;
			timer = 0f;
			SaveTotalGameTime();
		}
		if (Input.GetKeyDown(KeyCode.F6))
		{
			ShowCanvas(!isShowing);
		}
		timer += Time.deltaTime;
		totalGameTime += Time.deltaTime;
		int num = Mathf.FloorToInt(timer / 60f);
		int num2 = Mathf.FloorToInt(timer - (float)(num * 60));
		timerText.text = $"{num:00}:{num2:00}";
		if (totalTimerText != null)
		{
			int num3 = Mathf.FloorToInt(totalGameTime / 60f);
			int num4 = Mathf.FloorToInt(totalGameTime - (float)(num3 * 60));
			totalTimerText.text = $"Total: {num3:00}:{num4:00}";
		}
		if (currentTimeText != null && TrainGameManager.Instance != null)
		{
			float num5 = Mathf.Repeat(TrainGameManager.Instance.currentTime, 24f);
			int num6 = Mathf.FloorToInt(num5);
			int num7 = Mathf.FloorToInt((num5 - (float)num6) * 60f);
			currentTimeText.text = $"Current: {num6:00}:{num7:00}";
		}
	}

	private void OnDisable()
	{
		SaveTotalGameTime();
	}

	private void OnDestroy()
	{
		SaveTotalGameTime();
	}

	private void SaveTotalGameTime()
	{
		PlayerPrefs.SetFloat(GetTotalGameTimeSaveKey(), totalGameTime);
		PlayerPrefs.Save();
	}

	private string GetTotalGameTimeSaveKey()
	{
		return (string.IsNullOrEmpty(CustomNetworkManager.loadedGameKey) ? "DefaultGame" : CustomNetworkManager.loadedGameKey) + "_TotalGameTime";
	}

	public void ShowCanvas(bool show)
	{
		canvasGroup.alpha = (show ? 1f : 0f);
	}
}
