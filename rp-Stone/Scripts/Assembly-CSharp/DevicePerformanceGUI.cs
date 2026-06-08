using UnityEngine;

public class DevicePerformanceGUI : MonoBehaviour
{
	private readonly float LERP = 0.1f;

	private float averageDT;

	private float averageMS;

	private float accumulatedMS;

	public static DevicePerformanceGUI singleton { get; private set; }

	private void OnGUI()
	{
		GUIStyle style = GUI.skin.GetStyle("Label");
		style.alignment = TextAnchor.UpperRight;
		float num = 250f;
		float num2 = 25f;
		GUI.color = ColorConstants.rewardGreen;
		float num3 = 10f;
		float num4 = ((averageDT <= 0f) ? 999f : (1f / averageDT));
		GUI.Label(new Rect((float)Screen.width - num - 10f, num3, num, num2), num4.ToString("0.0") + " fps", style);
		num3 += num2 + 5f;
		GUI.Label(new Rect((float)Screen.width - num - 10f, num3, num, num2), averageMS.ToString("0.0") + "ms Stonescript", style);
	}

	private void AddDeltaTime(float dt)
	{
		if (averageDT < 0.001f)
		{
			averageDT = dt;
		}
		else
		{
			averageDT = Mathf.Lerp(averageDT, dt, LERP);
		}
	}

	public void AddStonescriptMilliseconds(int ms)
	{
		if (averageMS < 1E-05f)
		{
			averageMS = ms;
		}
		else
		{
			accumulatedMS += ms;
		}
	}

	private void Update()
	{
		AddDeltaTime(Time.deltaTime);
		averageMS = Mathf.Lerp(averageMS, accumulatedMS, LERP);
		accumulatedMS = 0f;
	}

	private void Awake()
	{
		singleton = this;
	}
}
