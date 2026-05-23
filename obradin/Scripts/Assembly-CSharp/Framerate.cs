using UnityEngine;

public class Framerate
{
	private static bool active;

	private static bool ready;

	private static double time;

	private static float fps;

	private static RingBuffer<int> fpsHistory;

	public static void Update()
	{
		if (Input.GetKeyDown(KeyCode.M) && Input.GetKey(KeyCode.LeftControl))
		{
			active = !active;
		}
		if (active)
		{
			if (!ready)
			{
				time = Time.realtimeSinceStartup;
				fpsHistory = new RingBuffer<int>(240);
				fpsHistory.Fill(0);
				ready = true;
			}
			double num = time;
			time = Time.realtimeSinceStartup;
			fps = 1f / (float)(time - num);
			fpsHistory.Add(Mathf.FloorToInt(fps));
		}
	}

	public static void Draw(RenderTexture target = null)
	{
		if (active)
		{
			DebugDrawer.DrawFrameRate(fpsHistory, target);
		}
	}
}
