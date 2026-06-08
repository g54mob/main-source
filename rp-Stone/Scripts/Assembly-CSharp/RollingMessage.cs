using UnityEngine;

public class RollingMessage : MonoBehaviour
{
	public int positionX;

	public int positionY;

	public AsciiString messageLabel;

	public AsciiString messageHighlight;

	private float messageDelay;

	private bool messageDone = true;

	private string messageText;

	private Color messageColor;

	private int messageCharIndex;

	private float messageElapsedTime = 999f;

	private const float messageTimePerChar = 0.015f;

	private const float messageIdleTime = 0.2f;

	private const float messageFadeOutTime = 0.8f;

	public void Show(string message, Color textColor, float delay = 0f)
	{
		messageLabel.Clear();
		messageHighlight.Clear();
		messageDone = false;
		messageText = message;
		messageColor = textColor;
		messageCharIndex = -1;
		messageDelay = delay;
		if (delay <= 0f)
		{
			NextMessageChar();
		}
	}

	private void Update()
	{
		if (messageDelay > 0f)
		{
			messageDelay -= Utils.deltaTime;
		}
		else if (messageDone)
		{
			if (messageElapsedTime - 0.2f < 0.8f)
			{
				messageLabel.color = Color.Lerp(messageColor, Color.black, (messageElapsedTime - 0.2f) / 0.8f);
				messageElapsedTime += Utils.deltaTime;
				if (messageElapsedTime - 0.2f >= 0.8f)
				{
					messageLabel.Clear();
				}
			}
		}
		else if (messageElapsedTime >= 0.015f)
		{
			NextMessageChar();
		}
		else
		{
			messageHighlight.color = Color.Lerp(Color.white, messageColor, messageElapsedTime / 0.015f);
			messageElapsedTime += Utils.deltaTime;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += positionX;
		offsetY += positionY;
		messageLabel.Draw(r, offsetX, offsetY);
		messageHighlight.Draw(r, offsetX, offsetY);
	}

	private void NextMessageChar()
	{
		messageElapsedTime = 0f;
		messageCharIndex++;
		if (messageCharIndex >= messageText.Length)
		{
			messageDone = true;
			messageHighlight.Clear();
			return;
		}
		string text = new string('#', messageText.Length - messageCharIndex - 1);
		messageLabel.SetValue(messageText.Substring(0, messageCharIndex + 1) + text);
		messageLabel.color = messageColor;
		messageHighlight.SetValue(new string('#', messageCharIndex) + messageText[messageCharIndex] + text);
	}
}
