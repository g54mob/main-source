using System;
using System.IO;
using UnityEngine;

namespace Crosstales.Common.Util
{
	[DisallowMultipleComponent]
	public class TakeScreenshot : MonoBehaviour
	{
		[Tooltip("Prefix for the generate file names.")]
		public string Prefix = "CT_Screenshot";

		[Tooltip("Factor by which to increase resolution (default: 1).")]
		public int Scale = 1;

		[Tooltip("Key-press to capture the screen (default: F8).")]
		public KeyCode KeyCode = KeyCode.F8;

		[Tooltip("Show file location (default: true).")]
		public bool ShowFileLocation = true;

		private Texture2D texture;

		private bool locationShown;

		public void Start()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.transform.root.gameObject);
		}

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode))
			{
				Capture();
			}
		}

		public void Capture()
		{
			string[] obj = new string[5]
			{
				Application.persistentDataPath,
				null,
				null,
				null,
				null
			};
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			obj[1] = directorySeparatorChar.ToString();
			obj[2] = Prefix;
			obj[3] = DateTime.Now.ToString("_dd-MM-yyyy-HH-mm-ss-f");
			obj[4] = ".png";
			string text = string.Concat(obj);
			ScreenCapture.CaptureScreenshot(text, Scale);
			Debug.Log("Screenshot saved: " + text);
			if (!locationShown && ShowFileLocation)
			{
				BaseHelper.ShowFileLocation(text);
				locationShown = true;
			}
		}
	}
}
