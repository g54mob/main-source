using System.IO;
using UnityEngine;

public class SimpleStartDemo : MonoBehaviour
{
	public TextMesh textGameState;

	public TextMesh textGifState;

	public float gameTimingToStopRecord = 12f;

	private bool gameEnd;

	public Camera mCamera;

	[Space]
	[Tooltip("The recorder will save gif using this filename if this is provided. The new gif will replace the old one if their filename are the same.")]
	public string optionalGifFileName = "MyGif";

	[Header("Native Save (+MobileMediaPlugin)")]
	public bool saveToNative;

	public bool deleteOriginGif;

	public string folderName = "GIF Demo";

	private float nextUpdateTime;

	private void Start()
	{
		ProGifManager instance = ProGifManager.Instance;
		instance.SetRecordSettings(autoAspect: true, 300, 300, 3f, 15, 1, 30);
		instance.StartRecord((mCamera != null) ? mCamera : Camera.main, delegate(float progress)
		{
			Debug.Log("[SimpleStartDemo] On record progress: " + progress);
		}, delegate
		{
			Debug.Log("[SimpleStartDemo] On recorder buffer max.");
		});
		textGameState.text = "Game Started";
		textGifState.text = "Start Record..";
	}

	private void Update()
	{
		if (gameEnd)
		{
			return;
		}
		if (Time.time > nextUpdateTime)
		{
			Camera.main.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}
		if (Time.time > gameTimingToStopRecord - 1f)
		{
			textGameState.text = "Game Over";
		}
		if (!(Time.time > gameTimingToStopRecord))
		{
			return;
		}
		gameEnd = true;
		ProGifManager gifMgr = ProGifManager.Instance;
		gifMgr.StopAndSaveRecord(delegate
		{
			Debug.Log("[SimpleStartDemo] On pre-processing done.");
		}, delegate(int id, float progress)
		{
			if (progress < 1f)
			{
				textGifState.text = "Making Gif : " + Mathf.CeilToInt(progress * 100f) + "%";
			}
			else
			{
				textGifState.text = "The gif file is created, find the path in the debug console.";
			}
		}, delegate(int id, string path)
		{
			gifMgr.Clear();
			Debug.Log("[SimpleStartDemo] On saved, origin save path: " + path);
			if (saveToNative)
			{
				string text = MobileMedia.CopyMedia(path, folderName, Path.GetFileNameWithoutExtension(path), ".gif", isImage: true);
				if (deleteOriginGif)
				{
					File.Delete(path);
				}
				MobileMedia.SaveBytes(File.ReadAllBytes(path), "YourGifFolderName", "YourGifFileName", ".gif", isImage: true);
				Debug.Log("Native Save Path(Andorid Only): " + text);
			}
		}, optionalGifFileName);
	}
}
