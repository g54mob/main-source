using UnityEngine;

public class GameplayActionMessages
{
	private const float MESSAGE_DURATION = 3f;

	public static AsciiTextBox messageBox = new AsciiTextBox();

	private static float messageTimeRemaining;

	private static int lastRendererWidth;

	private static int resizeCooldown = 0;

	public static void SetMessage(string message, float durationOverride = -1f)
	{
		messageTimeRemaining = ((durationOverride > 0f) ? durationOverride : 3f);
		messageBox.width = lastRendererWidth;
		messageBox.Text = message;
		messageBox.color = ColorConstants.white;
	}

	public static void SetMessage(string message, Color colorOverride, float durationOverride = -1f)
	{
		SetMessage(message, durationOverride);
		messageBox.color = colorOverride;
	}

	public static void Draw(AsciiRenderProcedural r)
	{
		lastRendererWidth = r.width;
		resizeCooldown--;
		if (messageTimeRemaining > 0f)
		{
			if (messageBox.width != lastRendererWidth && resizeCooldown <= 0)
			{
				resizeCooldown = 10;
				SetMessage(messageBox.Text, messageBox.color, messageTimeRemaining);
			}
			messageBox.Draw(r, 0, 0);
		}
	}

	public static void Update()
	{
		messageTimeRemaining -= Utils.deltaTime;
	}
}
