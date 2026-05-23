using System.IO;
using UnityEngine;
using VideoKit;

public class VideoKitTest : MonoBehaviour
{
	public RenderTexture rt;

	private bool isRecording;

	private void Start()
	{
		Rocket.OnRetriveRocketActive += Rocket_OnRetriveRocketActive;
		GameManager.S.OnRocketLaunch += S_OnRocketLaunch;
	}

	private void Rocket_OnRetriveRocketActive(GameObject obj)
	{
		if (isRecording)
		{
			GameManager.S.recorder.StopRecording();
			isRecording = false;
		}
	}

	private void OnDestroy()
	{
		Rocket.OnRetriveRocketActive -= Rocket_OnRetriveRocketActive;
		GameManager.S.OnRocketLaunch -= S_OnRocketLaunch;
	}

	private void S_OnRocketLaunch(int obj)
	{
		if (GameManager.S.isDicaInstalled || GameManager.S.isRocketCamInstalled)
		{
			StartRecording();
			isRecording = true;
		}
	}

	public void StartRecording()
	{
		GameManager.S.recorder.StartRecording();
		string path = "RocketLaunch";
		string text = Path.Combine(Application.persistentDataPath, path);
		SaveRenderTextureToPNG(rt, text + ".png");
	}

	public void StopRecording(MediaAsset asset)
	{
		string? path = asset.path;
		string path2 = "RocketLaunch.mp4";
		string text = Path.Combine(Application.persistentDataPath, path2);
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		File.Move(path, text);
		GameManager.S.NewVidRercorded("RocketLaunch");
		Debug.Log("녹화 완료! 최종 파일명: " + text);
	}

	public void SaveRenderTextureToPNG(RenderTexture rt, string filePath)
	{
		if (rt == null)
		{
			Debug.LogError("렌더 텍스처가 비어있습니다!");
			return;
		}
		Texture2D texture2D = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, mipChain: false);
		RenderTexture.active = rt;
		texture2D.ReadPixels(new Rect(0f, 0f, rt.width, rt.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = null;
		byte[] bytes = texture2D.EncodeToPNG();
		File.WriteAllBytes(filePath, bytes);
		Object.Destroy(texture2D);
		Debug.Log("썸네일 이미지 저장 완료: " + filePath);
	}
}
