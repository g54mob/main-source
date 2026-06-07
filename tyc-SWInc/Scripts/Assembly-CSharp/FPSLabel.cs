using UnityEngine;
using UnityEngine.UI;

public class FPSLabel : MonoBehaviour
{
	public Text textElement;

	public float updateInterval = 0.5f;

	private float accum;

	private int frames;

	private float timeleft;

	private float d;

	private void Start()
	{
		timeleft = updateInterval;
		d = Time.realtimeSinceStartup;
	}

	private Color GetColor(int fps)
	{
		if (fps < 20)
		{
			return Color.red * 0.5f;
		}
		if (fps < 30)
		{
			return Color.yellow * 0.5f;
		}
		return Color.green * 0.5f;
	}

	private void Update()
	{
		float num = Time.realtimeSinceStartup - d;
		d = Time.realtimeSinceStartup;
		timeleft -= num;
		accum += Time.timeScale / num;
		frames++;
		if ((double)timeleft <= 0.0)
		{
			int num2 = Mathf.RoundToInt(accum / (float)frames);
			textElement.text = string.Format("FPS: <Color=#{1}>{0}</Color>", num2, ColorUtility.ToHtmlStringRGBA(GetColor(num2)));
			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
		}
	}
}
