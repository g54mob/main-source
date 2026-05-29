using UnityEngine;

public class Feedback : MonoBehaviour
{
	[SerializeField]
	private string link;

	private string TimeFormatter(double seconds)
	{
		float num = Mathf.Floor((float)(seconds % 60.0) * 100f) / 100f;
		int num2 = (int)(seconds / 60.0) % 60;
		int num3 = (int)(seconds / 3600.0);
		return $"{num3}:{num2:00}:{num:00}";
	}

	private string prefilledLink()
	{
		return "https://docs.google.com/forms/d/e/1FAIpQLSdof8rNlW34rrOUCU-M6CXLCBYtfjlABzjpy7g2S5Basmylug/viewform?usp=pp_url&entry.1454977015=" + TimeFormatter(GameManager.ins.totalTimeElapsed);
	}

	public void ClickedFeedbackForm()
	{
		Application.OpenURL(prefilledLink());
	}
}
