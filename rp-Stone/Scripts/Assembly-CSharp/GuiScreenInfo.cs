using System.Collections.Generic;
using UnityEngine;

public class GuiScreenInfo : MonoBehaviour
{
	private List<string> message = new List<string>();

	private void OnGUI()
	{
		message.Clear();
		message.Add("Full Screen: " + Screen.fullScreen);
		message.Add("Resolution: " + Screen.width + "x" + Screen.height);
		message.Add("---");
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			message.Add(resolutions[i].ToString());
		}
		for (int j = 0; j < message.Count; j++)
		{
			GUI.Label(new Rect(10f, 10 + j * 20, 300f, 20f), message[j]);
		}
	}
}
