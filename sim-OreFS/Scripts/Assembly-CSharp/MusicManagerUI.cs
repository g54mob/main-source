using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicManagerUI : MonoBehaviour
{
	[Header("Texts")]
	[SerializeField]
	private TextMeshProUGUI currentTimeText;

	[SerializeField]
	private TextMeshProUGUI totalTimeText;

	[Header("Optional")]
	[SerializeField]
	private Slider timeSlider;

	[Header("Station Controls")]
	[SerializeField]
	private Image stationImage;

	[SerializeField]
	private Sprite startIcon;

	[SerializeField]
	private Sprite stopIcon;

	private void Update()
	{
		MusicManager instance = MusicManager.Instance;
		if (instance == null)
		{
			SetTexts("00:00", "00:00");
			SetSlider(0f);
			UpdateStationIcon(paused: true);
			return;
		}
		float currentTime = instance.CurrentTime;
		float totalTime = instance.TotalTime;
		SetTexts(FormatTime(currentTime), FormatTime(totalTime));
		if (totalTime > 0.01f)
		{
			SetSlider(currentTime / totalTime);
		}
		else
		{
			SetSlider(0f);
		}
		UpdateStationIcon(instance.IsPaused);
	}

	public void NextMusic()
	{
		MusicManager instance = MusicManager.Instance;
		if (!(instance == null) && instance.IsInGameMode)
		{
			instance.NextTrack();
		}
	}

	public void PreviousMusic()
	{
		MusicManager instance = MusicManager.Instance;
		if (!(instance == null) && instance.IsInGameMode)
		{
			instance.PreviousTrack();
		}
	}

	public void ToggleMusic()
	{
		MusicManager instance = MusicManager.Instance;
		if (!(instance == null))
		{
			if (instance.IsPaused)
			{
				instance.ResumeMusic();
			}
			else
			{
				instance.PauseMusic();
			}
		}
	}

	private void UpdateStationIcon(bool paused)
	{
		if (!(stationImage == null))
		{
			stationImage.sprite = (paused ? startIcon : stopIcon);
		}
	}

	private void SetTexts(string cur, string total)
	{
		if (currentTimeText != null)
		{
			currentTimeText.text = cur;
		}
		if (totalTimeText != null)
		{
			totalTimeText.text = total;
		}
	}

	private void SetSlider(float value01)
	{
		if (timeSlider != null)
		{
			timeSlider.value = Mathf.Clamp01(value01);
		}
	}

	private string FormatTime(float seconds)
	{
		if (seconds < 0f)
		{
			seconds = 0f;
		}
		int num = Mathf.FloorToInt(seconds);
		int num2 = num / 60;
		int num3 = num % 60;
		return num2.ToString("00") + ":" + num3.ToString("00");
	}
}
