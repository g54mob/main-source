using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ScreenshotUploader : MonoBehaviour
{
	private IEnumerator Report(Texture2D texture, string imgname, string version, bool sandbox = false)
	{
		float t = Time.time;
		byte[] contents = texture.EncodeToPNG();
		int num = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
		WWWForm wWWForm = new WWWForm();
		string fileName = $"{version}_{deviceUniqueIdentifier}_{num}.png";
		wWWForm.AddField("category", "a5");
		wWWForm.AddBinaryData("png_image", contents, fileName);
		using UnityWebRequest www = UnityWebRequest.Post("https://feedback.luden.io/cgi-bin/upload.cgi", wWWForm);
		yield return www.SendWebRequest();
		if (www.isNetworkError || www.isHttpError)
		{
			Debug.Log(www.error);
		}
		else
		{
			Debug.Log($"uploaded in {Time.time - t:0.00}s");
		}
	}
}
