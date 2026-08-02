using UnityEngine;

public class FPS_Counter : MonoBehaviour
{
	public float updateInterval = 0.5f;

	private float accum;

	private int frames;

	private float timeleft;

	private float fps;

	private GUIStyle textStyle = new GUIStyle();

	private void Start()
	{
		timeleft = updateInterval;
		textStyle.fontStyle = FontStyle.Bold;
		textStyle.normal.textColor = Color.white;
	}

	private void Update()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		frames++;
		if ((double)timeleft <= 0.0)
		{
			fps = accum / (float)frames;
			timeleft = updateInterval;
			accum = 0f;
			frames = 0;
		}
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(5f, 5f, 100f, 25f), fps.ToString("F2") + "FPS", textStyle);
	}
}
