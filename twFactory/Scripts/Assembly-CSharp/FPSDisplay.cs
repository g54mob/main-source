using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	[SerializeField]
	private TextAnchor fpsPosition = TextAnchor.UpperRight;

	private float deltaTime;

	public static bool showInfo = true;

	private static List<string> messages;

	private GUIStyle style;

	private Rect rect;

	private Color styleTextColor;

	private void Awake()
	{
		style = new GUIStyle();
		messages = new List<string>();
		styleTextColor = new Color(0f, 0f, 0.5f, 1f);
	}

	private void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}

	public static void AddMessage(string message)
	{
		messages.Add(message);
		if (messages.Count > 40)
		{
			messages.RemoveAt(0);
		}
	}

	private void OnGUI()
	{
		if (!showInfo)
		{
			return;
		}
		int width = Screen.width;
		int height = Screen.height;
		rect = new Rect(0f, 0f, width, height * 2 / 100);
		style.alignment = fpsPosition;
		style.fontSize = height * 2 / 100;
		style.normal.textColor = styleTextColor;
		float num = deltaTime * 1000f;
		float num2 = 1f / deltaTime;
		string text = $"{num:0.0} ms ({num2:0.} fps)";
		if (messages.Count > 0)
		{
			text += "\n\n\n";
			foreach (string message in messages)
			{
				text = text + "\n" + message;
			}
		}
		GUI.Label(rect, text, style);
	}
}
