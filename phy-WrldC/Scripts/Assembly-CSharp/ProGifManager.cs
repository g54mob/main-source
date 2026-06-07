using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProGifManager : MonoBehaviour
{
	public enum CommonColorEnum
	{
		White = 0,
		Black = 1,
		Blue = 2,
		Green = 3,
		Red = 4,
		LightYellow = 5
	}

	public static string PP_LastGifPathKey = "ProGIF_LastGifPathKey";

	public string m_GiphyUserName = "";

	public string m_GiphyApiKey = "";

	public string m_GiphyUploadApiKey = "";

	[HideInInspector]
	public ProGifRecorder m_GifRecorder;

	[HideInInspector]
	public ProGifPlayer m_GifPlayer;

	[HideInInspector]
	public string m_CurrentGifPath = "";

	private int m_MaxFps = 60;

	public Vector2 m_AspectRatio = new Vector2(0f, 0f);

	public bool m_AutoAspect = true;

	public int m_Width = 360;

	public int m_Height = 360;

	public float m_Duration = 3f;

	[Range(1f, 60f)]
	public int m_Fps = 15;

	public int m_Loop;

	[Range(1f, 100f)]
	public int m_Quality = 20;

	public ImageRotator.Rotation m_Rotation;

	public Color32 m_TransparentColor = new Color32(0, 0, 0, 0);

	public bool m_AutoTransparent;

	public bool m_OptimizeMemoryUsage = true;

	private Action<int, string> _OnFileSavedAction;

	private Action<int, float> _OnFileSaveProgressAction;

	private Action _OnRecorderPreProcessingDoneAction;

	private Action<float> _OnRecordProgressAction;

	private Action _OnRecordDurationMaxAction;

	private static ProGifManager _instance = null;

	public static ProGifManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject("[ProGifManager]").AddComponent<ProGifManager>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	public void SetRecordSettings(bool autoAspect, int width, int height, float duration, int fps, int loop, int quality)
	{
		m_AutoAspect = autoAspect;
		m_Width = width;
		m_Height = height;
		m_Fps = fps;
		m_Duration = duration;
		m_Loop = loop;
		m_Quality = quality;
		m_AspectRatio = new Vector2(0f, 0f);
	}

	public void SetRecordSettings(Vector2 aspectRatio, int width, int height, float duration, int fps, int loop, int quality)
	{
		m_AspectRatio = aspectRatio;
		m_Width = width;
		m_Height = height;
		m_Fps = fps;
		m_Duration = duration;
		m_Loop = loop;
		m_Quality = quality;
	}

	private void _InitRecorder(Camera camera, bool autoClear)
	{
		Clear();
		if (m_Fps > m_MaxFps)
		{
			m_Fps = m_MaxFps;
		}
		m_GifRecorder = new ProGifRecorder(camera);
		if (m_AspectRatio.x > 0f && m_AspectRatio.y > 0f)
		{
			m_GifRecorder.Setup(m_AspectRatio, m_Width, m_Height, m_Fps, m_Duration, m_Loop, m_Quality);
		}
		else
		{
			m_GifRecorder.Setup(m_AutoAspect, m_Width, m_Height, m_Fps, m_Duration, m_Loop, m_Quality);
		}
		m_GifRecorder.SetTransparent(m_TransparentColor);
		m_GifRecorder.SetTransparent(m_AutoTransparent);
		m_GifRecorder.SetGifRotation(m_Rotation);
		m_GifRecorder.OnPreProcessingDone += _OnRecorderPreProcessingDone;
		m_GifRecorder.OnFileSaveProgress += _OnRecorderFileSaveProgress;
		m_GifRecorder.OnFileSaved += _OnRecorderFileSaved;
		if (autoClear)
		{
			Action<int, string> value = delegate
			{
				ClearRecorder();
			};
			m_GifRecorder.OnFileSaved += value;
		}
	}

	private void _OnRecorderFileSaveProgress(int id, float progress)
	{
		if (_OnFileSaveProgressAction != null)
		{
			_OnFileSaveProgressAction(id, progress);
		}
	}

	private void _OnRecorderPreProcessingDone()
	{
		if (_OnRecorderPreProcessingDoneAction != null)
		{
			_OnRecorderPreProcessingDoneAction();
		}
	}

	public void StartRecord(Action<float> onRecordProgress = null, Action onRecordDurationMax = null, bool autoClear = true)
	{
		StartRecord(Camera.main, onRecordProgress, onRecordDurationMax);
	}

	public void StartRecord(Camera camera, Action<float> onRecordProgress = null, Action onRecordDurationMax = null, bool autoClear = true)
	{
		_InitRecorder(camera, autoClear);
		m_GifRecorder.Record(onRecordDurationMax);
		m_GifRecorder.SetOnRecordAction(onRecordProgress);
	}

	public void SetGifRotation(ImageRotator.Rotation rotation)
	{
		if (m_GifRecorder == null)
		{
			m_Rotation = rotation;
		}
		else
		{
			m_GifRecorder.SetGifRotation(rotation);
		}
	}

	public void SetTransparent(Color32 color32)
	{
		if (m_GifRecorder == null)
		{
			m_TransparentColor = color32;
			m_AutoTransparent = false;
		}
		else
		{
			m_GifRecorder.SetTransparent(color32);
		}
	}

	public void SetTransparent(bool autoDetectTransparent)
	{
		if (m_GifRecorder == null)
		{
			m_AutoTransparent = autoDetectTransparent;
			m_TransparentColor = new Color32(0, 0, 0, 0);
		}
		else
		{
			m_GifRecorder.SetTransparent(autoDetectTransparent);
		}
	}

	private void _UpdateRecordProgress(float progress)
	{
		if (_OnRecordProgressAction != null)
		{
			_OnRecordProgressAction(progress);
		}
	}

	private void _OnRecordDurationMax()
	{
		if (_OnRecordDurationMaxAction != null)
		{
			_OnRecordDurationMaxAction();
		}
	}

	public void PauseRecord()
	{
		if (m_GifRecorder != null)
		{
			m_GifRecorder.Pause();
		}
	}

	public void ResumeRecord()
	{
		if (m_GifRecorder != null)
		{
			m_GifRecorder.Resume();
		}
	}

	public void StopRecord()
	{
		if (m_GifRecorder != null)
		{
			m_GifRecorder.Stop();
		}
	}

	public void SaveRecord(Action onRecorderPreProcessingDone = null, Action<int, float> onFileSaveProgress = null, Action<int, string> onFileSaved = null, string fileNameWithoutExtension = "")
	{
		if (m_GifRecorder != null)
		{
			_OnRecorderPreProcessingDoneAction = onRecorderPreProcessingDone;
			_OnFileSaveProgressAction = onFileSaveProgress;
			_OnFileSavedAction = onFileSaved;
			m_GifRecorder.Save(fileNameWithoutExtension);
		}
	}

	public void StopAndSaveRecord(Action onRecorderPreProcessingDone = null, Action<int, float> onFileSaveProgress = null, Action<int, string> onFileSaved = null, string fileNameWithoutExtension = "")
	{
		if (m_GifRecorder != null)
		{
			m_GifRecorder.Stop();
			SaveRecord(onRecorderPreProcessingDone, onFileSaveProgress, onFileSaved, fileNameWithoutExtension);
		}
	}

	private void _OnRecorderFileSaved(int id, string path)
	{
		m_CurrentGifPath = path;
		PlayerPrefs.SetString(PP_LastGifPathKey, path);
		if (_OnFileSavedAction != null)
		{
			_OnFileSavedAction(id, path);
		}
		if (m_GifRecorder != null)
		{
			m_GifRecorder.FlushMemory();
		}
	}

	public void SetPlayerOptimization(bool enable)
	{
		m_OptimizeMemoryUsage = enable;
	}

	public void PlayGif(Image playerImage, Action<float> onLoading = null)
	{
		if (m_GifRecorder == null)
		{
			Debug.LogWarning("GIF recorder not found!");
			return;
		}
		m_GifPlayer = new ProGifPlayer();
		m_GifPlayer.Play(m_GifRecorder, playerImage, m_OptimizeMemoryUsage);
		m_GifPlayer.SetLoadingCallback(delegate(float progress)
		{
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
	}

	public void PlayGif(Renderer playerRenderer, Action<float> onLoading = null)
	{
		if (m_GifRecorder == null)
		{
			Debug.LogWarning("GIF recorder not found!");
			return;
		}
		m_GifPlayer = new ProGifPlayer();
		m_GifPlayer.Play(m_GifRecorder, playerRenderer, m_OptimizeMemoryUsage);
		m_GifPlayer.SetLoadingCallback(delegate(float progress)
		{
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
	}

	public void PlayGif(RawImage playerRawImage, Action<float> onLoading = null)
	{
		if (m_GifRecorder == null)
		{
			Debug.LogWarning("GIF recorder not found!");
			return;
		}
		m_GifPlayer = new ProGifPlayer();
		m_GifPlayer.Play(m_GifRecorder, playerRawImage, m_OptimizeMemoryUsage);
		m_GifPlayer.SetLoadingCallback(delegate(float progress)
		{
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
	}

	public void SetPlayerOnLoading(Action<float> onLoading)
	{
		if (m_GifPlayer == null)
		{
			Debug.LogWarning("Player not found!");
		}
		else
		{
			m_GifPlayer.SetLoadingCallback(onLoading);
		}
	}

	public void SetPlayerOnFirstFrame(Action<ProGifPlayerComponent.FirstGifFrame> onFirstFrame)
	{
		if (m_GifPlayer == null)
		{
			Debug.LogWarning("Player not found!");
		}
		else
		{
			m_GifPlayer.SetOnFirstFrameCallback(onFirstFrame);
		}
	}

	public void SetPlayerOnPlaying(Action<GifTexture> onPlaying)
	{
		if (m_GifPlayer == null)
		{
			Debug.LogWarning("Player not found!");
		}
		else
		{
			m_GifPlayer.SetOnPlayingCallback(onPlaying);
		}
	}

	public void PausePlayer()
	{
		if (m_GifPlayer == null)
		{
			Debug.LogWarning("Player not found!");
		}
		else
		{
			m_GifPlayer.Pause();
		}
	}

	public void ResumePlayer()
	{
		if (m_GifPlayer == null)
		{
			Debug.LogWarning("Player not found!");
		}
		else
		{
			m_GifPlayer.Resume();
		}
	}

	public void StopPlayer()
	{
		if (m_GifPlayer == null)
		{
			Debug.LogWarning("Player not found!");
		}
		else
		{
			m_GifPlayer.Stop();
		}
	}

	public void ShareTwitter(string filePath)
	{
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			ShareTwitter_Mobile(filePath);
			return;
		}
		if (string.IsNullOrEmpty(filePath))
		{
			filePath = m_CurrentGifPath;
		}
		GiphyManager instance = GiphyManager.Instance;
		instance.SetChannelAuthentication(m_GiphyUserName, m_GiphyApiKey, m_GiphyUploadApiKey);
		instance.Upload(filePath, new List<string> { "TestTweet", "SwanDEV", "GameGIF" }, delegate(GiphyUpload.Response uploadResponse)
		{
			new GifSocialShare().ShareTo(GifSocialShare.Social.Twitter, "", "", uploadResponse.data.id);
		}, delegate
		{
		});
	}

	public void ShareTwitter_Mobile(string filePath)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			filePath = m_CurrentGifPath;
		}
		GiphyManager giphyMgr = GiphyManager.Instance;
		giphyMgr.SetChannelAuthentication(m_GiphyUserName, m_GiphyApiKey, m_GiphyUploadApiKey);
		giphyMgr.Upload(filePath, new List<string> { "TestTweet", "SwanDEV", "GameGIF" }, delegate(GiphyUpload.Response uploadResponse)
		{
			giphyMgr.GetById(uploadResponse.data.id, delegate(GiphyGetById.Response byIdResponse)
			{
				new GifSocialShare().ShareTo(GifSocialShare.Social.Twitter_Mobile, "GIFTest", "This GIF is created with ProGIF/GameGIF. Get the plugins on the Asset Store now: http://u3d.as/QkW", "GameGIF", byIdResponse.data.bitly_gif_url);
			});
		}, delegate
		{
		});
	}

	public void ShareFacebook(string filePath = "")
	{
		if (string.IsNullOrEmpty(filePath))
		{
			filePath = m_CurrentGifPath;
		}
		GiphyManager giphyMgr = GiphyManager.Instance;
		giphyMgr.SetChannelAuthentication(m_GiphyUserName, m_GiphyApiKey, m_GiphyUploadApiKey);
		giphyMgr.Upload(filePath, new List<string> { "TestFB", "SwanDEV", "GameGIF" }, delegate(GiphyUpload.Response uploadResponse)
		{
			giphyMgr.GetById(uploadResponse.data.id, delegate(GiphyGetById.Response byIdResponse)
			{
				new GifSocialShare().ShareTo(GifSocialShare.Social.Facebook, "", "", "", byIdResponse.data.images.original.url);
			});
		}, delegate
		{
		});
	}

	public void Clear()
	{
		ClearRecorder();
		ClearPlayer();
	}

	public void ClearRecorder()
	{
		if (m_GifRecorder != null)
		{
			m_GifRecorder.OnPreProcessingDone -= _OnRecorderPreProcessingDone;
			m_GifRecorder.OnFileSaveProgress -= _OnRecorderFileSaveProgress;
			m_GifRecorder.OnFileSaved -= _OnRecorderFileSaved;
			m_GifRecorder.Clear();
			m_GifRecorder = null;
		}
	}

	public void ClearRecorder_Delay(Action onClear = null)
	{
		bool isSaved = false;
		bool isLoaded = false;
		bool isCleared = false;
		m_GifRecorder.recorderCom.OnFileSaved += delegate
		{
			isSaved = true;
			if (!isCleared && isLoaded)
			{
				isCleared = true;
				ClearRecorder();
				SDemoAnimation.Instance.WaitFrames(1, delegate
				{
					if (onClear != null)
					{
						onClear();
					}
				});
			}
		};
		ProGifPlayerComponent playerComponent = m_GifPlayer.playerComponent;
		playerComponent.OnLoading = (Action<float>)Delegate.Combine(playerComponent.OnLoading, (Action<float>)delegate(float progress)
		{
			if (progress >= 1f)
			{
				isLoaded = true;
				if (!isCleared && isSaved)
				{
					isCleared = true;
					ClearRecorder();
					SDemoAnimation.Instance.WaitFrames(1, delegate
					{
						if (onClear != null)
						{
							onClear();
						}
					});
				}
			}
		});
	}

	public void ClearPlayer()
	{
		if (m_GifPlayer != null)
		{
			m_GifPlayer.Clear();
			m_GifPlayer = null;
		}
	}

	public static T InstantiatePrefab<T>(GameObject prefab) where T : MonoBehaviour
	{
		if (prefab != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
			if (gameObject != null)
			{
				gameObject.name = "[Prefab]" + prefab.name;
				gameObject.transform.localScale = Vector3.one;
				return gameObject.GetComponent<T>();
			}
			Debug.Log("prefab is null!");
			return null;
		}
		return null;
	}

	public static Color GetColor(CommonColorEnum colorEnum)
	{
		Color result = Color.white;
		switch (colorEnum)
		{
		case CommonColorEnum.Black:
			result = Color.black;
			break;
		case CommonColorEnum.Blue:
			result = new Color(0f, 0.5f, 1f, 1f);
			break;
		case CommonColorEnum.Green:
			result = new Color(0.5f, 1f, 0.5f, 1f);
			break;
		case CommonColorEnum.Red:
			result = new Color(1f, 0.5f, 0.5f, 1f);
			break;
		case CommonColorEnum.LightYellow:
			result = new Color(1f, 44f / 51f, 22f / 51f, 1f);
			break;
		}
		return result;
	}
}
