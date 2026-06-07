using UnityEngine;
using UnityEngine.UI;

public class MultipleCameraDemo : MonoBehaviour
{
	public Camera mCamera1;

	public Camera mCamera2;

	public Camera mCamera3;

	public Text cam1Text;

	public Text cam2Text;

	public Text cam3Text;

	public Image image1;

	public Image image2;

	public Image image3;

	public MeshRenderer m_CubeMesh;

	private Texture2D _refTexture2d;

	private Texture2D _refImageTexture2d;

	private int _counter;

	private void Start()
	{
		PGif.iSetRecordSettings(autoAspect: true, 480, 480, 5f, 10, 0, 30);
		PGif.iStartRecord(mCamera1, "Cam1", OnRecordProgress1, OnRecordDurationMax1, OnPreProcessingDone1, OnFileSaveProgress1, OnFileSaved1, autoClear: false);
		cam1Text.text = "Camera1 started recording";
		PGif.iSetRecordSettings(new Vector2(1f, 1f), 300, 300, 5f, 15, 1, 30);
		PGif.iStartRecord(mCamera2, "Cam2", OnRecordProgress2, OnRecordDurationMax2, OnPreProcessingDone2, OnFileSaveProgress2, OnFileSaved2, autoClear: false);
		cam2Text.text = "Camera2 started recording";
		PGif.iSetRecordSettings(new Vector2(4f, 3f), 200, 200, 7f, 20, 1, 30);
		PGif.iStartRecord(mCamera3, "Cam3", OnRecordProgress3, OnRecordDurationMax3, OnPreProcessingDone3, OnFileSaveProgress3, OnFileSaved3, autoClear: false);
		cam3Text.text = "Camera3 started recording";
	}

	public void OnRecordProgress1(float progress)
	{
	}

	public void OnRecordDurationMax1()
	{
		Debug.Log("Cam1 - [MultipleCameraDemo] On recorder buffer max.");
		cam1Text.text = "Camera1 duration Max";
	}

	public void OnPreProcessingDone1()
	{
		Debug.Log("Cam1 - [MultipleCameraDemo] On pre-processing done.");
		cam1Text.text = "Camera1 pre-processing done";
		PGif.iResumeRecord("Cam1");
		Debug.Log("Resume the recorder: Cam1");
	}

	public void OnFileSaveProgress1(int id, float progress)
	{
		cam1Text.text = "Camera1 Save progress: " + progress;
	}

	public void OnFileSaved1(int id, string path)
	{
		Debug.Log("Cam1 - [MultipleCameraDemo] On saved, path: " + path);
		cam1Text.text = "Camera1 Saved: " + path;
	}

	public void OnRecordProgress2(float progress)
	{
	}

	public void OnRecordDurationMax2()
	{
		Debug.Log("Cam2 - [MultipleCameraDemo] On recorder buffer max.");
		cam2Text.text = "Camera2 duration Max";
	}

	public void OnPreProcessingDone2()
	{
		Debug.Log("Cam2 - [MultipleCameraDemo] On pre-processing done.");
		cam2Text.text = "Camera2 pre-processing done";
		PGif.iResumeRecord("Cam2");
		Debug.Log("Resume the recorder: Cam2");
	}

	public void OnFileSaveProgress2(int id, float progress)
	{
		cam2Text.text = "Camera2 Save progress: " + progress;
	}

	public void OnFileSaved2(int id, string path)
	{
		Debug.Log("Cam2 - [MultipleCameraDemo] On saved, path: " + path);
		cam2Text.text = "Camera3 Saved: " + path;
	}

	public void OnRecordProgress3(float progress)
	{
	}

	public void OnRecordDurationMax3()
	{
		Debug.Log("Cam3 - [MultipleCameraDemo] On recorder buffer max.");
		cam3Text.text = "Camera3 duration Max";
	}

	public void OnPreProcessingDone3()
	{
		Debug.Log("Cam3 - [MultipleCameraDemo] On pre-processing done.");
		cam3Text.text = "Camera3 pre-processing done";
		PGif.iResumeRecord("Cam3");
		Debug.Log("Resume the recorder: Cam3");
	}

	public void OnFileSaveProgress3(int id, float progress)
	{
		cam3Text.text = "Camera3 Save progress: " + progress;
	}

	public void OnFileSaved3(int id, string path)
	{
		Debug.Log("Cam3 - [MultipleCameraDemo] On saved, path: " + path);
		cam3Text.text = "Camera3 Saved: " + path;
		PGif.iGetPlayer("GifPlayer3").SetOnPlayingCallback(delegate
		{
		});
	}

	private void _PlayGif(string recorderName, string playerName, Image destination, ProGifRecorderComponent.EncodePlayMode encodePlayMode)
	{
		if (PGif.iGetRecorder(recorderName) == null || PGif.iGetRecorder(recorderName).Frames == null)
		{
			Debug.LogWarning("The recorder not exist or has been cleared: " + recorderName);
			return;
		}
		PGif.iPlayGif(PGif.iGetRecorder(recorderName), destination, playerName, delegate(float progress)
		{
			float gifWHRatio = (float)PGif.iGetRecorder(recorderName).Width / (float)PGif.iGetRecorder(recorderName).Height;
			_SetDisplaySize(gifWHRatio, destination);
			if (progress >= 1f)
			{
				switch (encodePlayMode)
				{
				case ProGifRecorderComponent.EncodePlayMode.PingPong:
					PGif.iGetPlayer(playerName).PingPong();
					break;
				case ProGifRecorderComponent.EncodePlayMode.Reverse:
					PGif.iGetPlayer(playerName).Reverse();
					break;
				case ProGifRecorderComponent.EncodePlayMode.Normal:
					break;
				}
			}
		});
	}

	private void _SetDisplaySize(float gifWHRatio, Image destination)
	{
		int num = (int)destination.rectTransform.sizeDelta.x;
		int num2 = (int)destination.rectTransform.sizeDelta.y;
		int num3 = num;
		int num4 = num2;
		if (gifWHRatio > 1f)
		{
			num3 = num;
			num4 = (int)((float)num3 / gifWHRatio);
		}
		else if (gifWHRatio < 1f)
		{
			num4 = num2;
			num3 = (int)((float)num4 * gifWHRatio);
		}
		destination.rectTransform.sizeDelta = new Vector2(num3, num4);
	}

	public void SaveRecord_Cam1()
	{
		PGif.iGetRecorder("Cam1").recorderCom.m_EncodePlayMode = ProGifRecorderComponent.EncodePlayMode.Normal;
		PGif.iSaveRecord("Cam1");
		Debug.Log("Save the recorder: Cam1");
		_PlayGif("Cam1", "GifPlayer1", image1, ProGifRecorderComponent.EncodePlayMode.Normal);
	}

	public void SaveRecord_Cam2()
	{
		PGif.iGetRecorder("Cam2").recorderCom.m_EncodePlayMode = ProGifRecorderComponent.EncodePlayMode.PingPong;
		PGif.iSaveRecord("Cam2");
		Debug.Log("Save the recorder: Cam2");
		_PlayGif("Cam2", "GifPlayer2", image2, ProGifRecorderComponent.EncodePlayMode.PingPong);
	}

	public void SaveRecord_Cam3()
	{
		PGif.iGetRecorder("Cam3").recorderCom.m_EncodePlayMode = ProGifRecorderComponent.EncodePlayMode.Reverse;
		PGif.iSaveRecord("Cam3");
		Debug.Log("Save the recorder: Cam3");
		_PlayGif("Cam3", "GifPlayer3", image3, ProGifRecorderComponent.EncodePlayMode.Reverse);
	}

	public void UpdateCubeText(TextMesh tm)
	{
		_counter++;
		if (_counter > 9)
		{
			_counter = 0;
		}
		tm.text = _counter.ToString();
	}

	public void FastPreviewAndSaveGif_WithCombinedRecorders()
	{
		PGif.iStopRecord("Cam1");
		PGif.iStopRecord("Cam2");
		RenderTexture[] frames = PGif.iGetRecorder("Cam2").Frames;
		ProGifRecorderComponent recorderCom = PGif.iGetRecorder("Cam1").recorderCom;
		for (int i = 0; i < frames.Length; i++)
		{
			recorderCom.Frames.Enqueue(frames[i]);
		}
		Image previewImage = image1;
		PGif.iPlayGif(PGif.iGetRecorder("Cam1"), previewImage, "GifPreviewPlayer", delegate
		{
			float gifWHRatio = (float)PGif.iGetRecorder("Cam1").Width / (float)PGif.iGetRecorder("Cam1").Height;
			_SetDisplaySize(gifWHRatio, previewImage);
		});
		SaveRecord_Cam1();
	}

	public void SaveRecord_CombineCam1AndCam2()
	{
		PGif.iStopRecord("Cam2");
		RenderTexture[] frames = PGif.iGetRecorder("Cam2").Frames;
		ProGifRecorderComponent recorderCom = PGif.iGetRecorder("Cam1").recorderCom;
		for (int i = 0; i < frames.Length; i++)
		{
			recorderCom.Frames.Enqueue(frames[i]);
		}
		PGif.iStopAndSaveRecord("Cam1");
	}
}
