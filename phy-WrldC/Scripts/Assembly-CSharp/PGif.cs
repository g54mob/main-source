using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PGif : MonoBehaviour
{
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

	public Dictionary<string, ProGifRecorder> m_GifRecorderDict = new Dictionary<string, ProGifRecorder>();

	public Dictionary<string, ProGifPlayer> m_GifPlayerDict = new Dictionary<string, ProGifPlayer>();

	private static PGif _instance;

	public static PGif Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject("[PGif]").AddComponent<PGif>();
			}
			return _instance;
		}
	}

	public static bool HasInstance => _instance != null;

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

	public void SetGifRotation(ImageRotator.Rotation rotation)
	{
		m_Rotation = rotation;
	}

	public void SetTransparent(Color32 color32)
	{
		m_TransparentColor = color32;
		m_AutoTransparent = false;
	}

	public void SetTransparent(bool autoDetectTransparent)
	{
		m_AutoTransparent = autoDetectTransparent;
		m_TransparentColor = new Color32(0, 0, 0, 0);
	}

	public void StartRecord(Camera camera, string recorderName, Action<float> onRecordProgress = null, Action onRecordDurationMax = null, Action onPreProcessingDone = null, Action<int, float> onFileSaveProgress = null, Action<int, string> onFileSaved = null, bool autoClear = true)
	{
		if (camera.GetComponent<ProGifRecorderComponent>() != null)
		{
			Debug.LogWarning("The target camera already has a recorder attached!");
			return;
		}
		ProGifRecorder newGifRecorder = new ProGifRecorder(camera);
		if (m_GifRecorderDict.ContainsKey(recorderName))
		{
			m_GifRecorderDict[recorderName] = newGifRecorder;
		}
		else
		{
			m_GifRecorderDict.Add(recorderName, newGifRecorder);
		}
		if (m_AspectRatio.x > 0f && m_AspectRatio.y > 0f)
		{
			newGifRecorder.Setup(m_AspectRatio, m_Width, m_Height, m_Fps, m_Duration, m_Loop, m_Quality);
		}
		else
		{
			newGifRecorder.Setup(m_AutoAspect, m_Width, m_Height, m_Fps, m_Duration, m_Loop, m_Quality);
		}
		newGifRecorder.SetTransparent(m_TransparentColor);
		newGifRecorder.SetTransparent(m_AutoTransparent);
		newGifRecorder.SetGifRotation(m_Rotation);
		newGifRecorder.Record(onRecordDurationMax);
		newGifRecorder.SetOnRecordAction(onRecordProgress);
		newGifRecorder.OnPreProcessingDone += onPreProcessingDone;
		newGifRecorder.OnFileSaveProgress += onFileSaveProgress;
		newGifRecorder.OnFileSaved += onFileSaved;
		if (autoClear)
		{
			Action<int, string> value = delegate
			{
				newGifRecorder.Clear();
				newGifRecorder = null;
			};
			newGifRecorder.OnFileSaved += value;
		}
	}

	public ProGifRecorder GetRecorder(string recorderName)
	{
		ProGifRecorder value = null;
		if (!m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			Debug.LogWarning("GetRecorder - Recorder not found: " + recorderName);
		}
		return value;
	}

	public void PauseRecord(string recorderName)
	{
		ProGifRecorder value = null;
		if (m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			value.Pause();
		}
		else
		{
			Debug.LogWarning("PauseRecord - Recorder not found: " + recorderName);
		}
	}

	public void ResumeRecord(string recorderName)
	{
		ProGifRecorder value = null;
		if (m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			value.Resume();
		}
		else
		{
			Debug.LogWarning("ResumeRecord - Recorder not found: " + recorderName);
		}
	}

	public void StopRecord(string recorderName)
	{
		ProGifRecorder value = null;
		if (m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			value.Stop();
		}
		else
		{
			Debug.LogWarning("StopRecord - Recorder not found: " + recorderName);
		}
	}

	public void SaveRecord(string recorderName, string fileNameWithoutExtension = "")
	{
		ProGifRecorder value = null;
		if (m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			value.Save(fileNameWithoutExtension);
		}
		else
		{
			Debug.LogWarning("SaveRecord - Recorder not found: " + recorderName);
		}
	}

	public void StopAndSaveRecord(string recorderName, string fileNameWithoutExtension = "")
	{
		ProGifRecorder value = null;
		if (m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			value.Stop();
			value.Save(fileNameWithoutExtension);
		}
		else
		{
			Debug.LogWarning("StopAndSaveRecord - Recorder not found: " + recorderName);
		}
	}

	public void ClearRecorder(string recorderName)
	{
		ProGifRecorder value = null;
		if (m_GifRecorderDict.TryGetValue(recorderName, out value))
		{
			value.FlushMemory();
			value.Clear();
			value = null;
		}
		else
		{
			Debug.LogWarning("ClearRecorder - Recorder not found: " + recorderName);
		}
	}

	public void ClearRecorder_Delay(string recorderName, string importingPlayerName, Action<string> onClear = null)
	{
		bool isSaved = false;
		bool isLoaded = false;
		bool isCleared = false;
		GetRecorder(recorderName).recorderCom.OnFileSaved += delegate
		{
			isSaved = true;
			if (!isCleared && isLoaded)
			{
				isCleared = true;
				ClearRecorder(recorderName);
				SDemoAnimation.Instance.WaitFrames(1, delegate
				{
					if (onClear != null)
					{
						onClear(recorderName);
					}
				});
			}
		};
		ProGifPlayerComponent playerComponent = GetPlayer(importingPlayerName).playerComponent;
		playerComponent.OnLoading = (Action<float>)Delegate.Combine(playerComponent.OnLoading, (Action<float>)delegate(float progress)
		{
			if (progress >= 1f)
			{
				isLoaded = true;
				if (!isCleared && isSaved)
				{
					isCleared = true;
					ClearRecorder(recorderName);
					SDemoAnimation.Instance.WaitFrames(1, delegate
					{
						if (onClear != null)
						{
							onClear(recorderName);
						}
					});
				}
			}
		});
	}

	private ProGifPlayer _SetupPlayer(GameObject targetPlayerObject, string playerName)
	{
		if (targetPlayerObject.GetComponent<ProGifPlayerComponent>() != null)
		{
			targetPlayerObject.GetComponent<ProGifPlayerComponent>().Clear();
		}
		ProGifPlayer proGifPlayer = new ProGifPlayer();
		if (m_GifPlayerDict.ContainsKey(playerName))
		{
			m_GifPlayerDict[playerName] = proGifPlayer;
		}
		else
		{
			m_GifPlayerDict.Add(playerName, proGifPlayer);
		}
		return proGifPlayer;
	}

	public void PlayGif(ProGifRecorder recorderSource, Image playerImage, string playerName, Action<float> onLoading = null)
	{
		if (recorderSource == null)
		{
			Debug.Log("GIF recorder not found!");
			return;
		}
		ProGifPlayer proGifPlayer = _SetupPlayer(playerImage.gameObject, playerName);
		proGifPlayer.Play(recorderSource, playerImage, m_OptimizeMemoryUsage);
		proGifPlayer.SetLoadingCallback(delegate(float progress)
		{
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
	}

	public void PlayGif(ProGifRecorder recorderSource, Renderer playerRenderer, string playerName, Action<float> onLoading = null)
	{
		if (recorderSource == null)
		{
			Debug.Log("GIF recorder not found!");
			return;
		}
		ProGifPlayer proGifPlayer = _SetupPlayer(playerRenderer.gameObject, playerName);
		proGifPlayer.Play(recorderSource, playerRenderer, m_OptimizeMemoryUsage);
		proGifPlayer.SetLoadingCallback(delegate(float progress)
		{
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
	}

	public void PlayGif(ProGifRecorder recorderSource, RawImage playerRawImage, string playerName, Action<float> onLoading = null)
	{
		if (recorderSource == null)
		{
			Debug.Log("GIF recorder not found!");
			return;
		}
		ProGifPlayer proGifPlayer = _SetupPlayer(playerRawImage.gameObject, playerName);
		proGifPlayer.Play(recorderSource, playerRawImage, m_OptimizeMemoryUsage);
		proGifPlayer.SetLoadingCallback(delegate(float progress)
		{
			if (onLoading != null)
			{
				onLoading(progress);
			}
		});
	}

	public void SetPlayerOnLoading(string playerName, Action<float> onLoading)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.SetLoadingCallback(onLoading);
		}
		else
		{
			Debug.LogWarning("SetPlayerOnLoading - Player not found: " + playerName);
		}
	}

	public void SetPlayerOnFirstFrame(string playerName, Action<ProGifPlayerComponent.FirstGifFrame> onFirstFrame)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.SetOnFirstFrameCallback(onFirstFrame);
		}
		else
		{
			Debug.LogWarning("SetPlayerOnFirstFrame - Player not found: " + playerName);
		}
	}

	public void SetPlayerOnPlaying(string playerName, Action<GifTexture> onPlaying)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.SetOnPlayingCallback(onPlaying);
		}
		else
		{
			Debug.LogWarning("SetPlayerOnPlaying - Player not found: " + playerName);
		}
	}

	public ProGifPlayer GetPlayer(string playerName)
	{
		ProGifPlayer value = null;
		if (!m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			Debug.LogWarning("GetPlayer - Player not found: " + playerName);
		}
		return value;
	}

	public void PausePlayer(string playerName)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.Pause();
		}
		else
		{
			Debug.LogWarning("PausePlayer - Player not found: " + playerName);
		}
	}

	public void ResumePlayer(string playerName)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.Resume();
		}
		else
		{
			Debug.LogWarning("ResumePlayer - Player not found: " + playerName);
		}
	}

	public void StopPlayer(string playerName)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.Stop();
		}
		else
		{
			Debug.LogWarning("StopPlayer - Player not found: " + playerName);
		}
	}

	public void ClearPlayer(string playerName)
	{
		ProGifPlayer value = null;
		if (m_GifPlayerDict.TryGetValue(playerName, out value))
		{
			value.Clear();
			value = null;
		}
		else
		{
			Debug.LogWarning("ClearPlayer - Player not found: " + playerName);
		}
	}

	public static void iSetRecordSettings(bool autoAspect, int width, int height, float duration, int fps, int loop, int quality)
	{
		Instance.SetRecordSettings(autoAspect, width, height, duration, fps, loop, quality);
	}

	public static void iSetRecordSettings(Vector2 aspectRatio, int width, int height, float duration, int fps, int loop, int quality)
	{
		Instance.SetRecordSettings(aspectRatio, width, height, duration, fps, loop, quality);
	}

	public static void iSetGifRotation(ImageRotator.Rotation rotation)
	{
		Instance.SetGifRotation(rotation);
	}

	public static void iSetTransparent(Color32 color32)
	{
		Instance.SetTransparent(color32);
	}

	public static void iSetTransparent(bool autoDetectTransparent)
	{
		Instance.SetTransparent(autoDetectTransparent);
	}

	public static void iStartRecord(Camera camera, string recorderName, Action<float> onRecordProgress = null, Action onRecordDurationMax = null, Action onPreProcessingDone = null, Action<int, float> onFileSaveProgress = null, Action<int, string> onFileSaved = null, bool autoClear = true)
	{
		Instance.StartRecord(camera, recorderName, onRecordProgress, onRecordDurationMax, onPreProcessingDone, onFileSaveProgress, onFileSaved, autoClear);
	}

	public static ProGifRecorder iGetRecorder(string recorderName)
	{
		return Instance.GetRecorder(recorderName);
	}

	public static void iPauseRecord(string recorderName)
	{
		Instance.PauseRecord(recorderName);
	}

	public static void iResumeRecord(string recorderName)
	{
		Instance.ResumeRecord(recorderName);
	}

	public static void iStopRecord(string recorderName)
	{
		Instance.StopRecord(recorderName);
	}

	public static void iSaveRecord(string recorderName, string fileNameWithoutExtension = "")
	{
		Instance.SaveRecord(recorderName, fileNameWithoutExtension);
	}

	public static void iStopAndSaveRecord(string recorderName, string fileNameWithoutExtension = "")
	{
		Instance.StopAndSaveRecord(recorderName, fileNameWithoutExtension);
	}

	public static void iClearRecorder(string recorderName)
	{
		Instance.ClearRecorder(recorderName);
	}

	public static void iClearRecorder_Delay(string recorderName, string importingPlayerName, Action<string> onClear = null)
	{
		Instance.ClearRecorder_Delay(recorderName, importingPlayerName, onClear);
	}

	public static void iSetPlayerOptimization(bool enable)
	{
		Instance.m_OptimizeMemoryUsage = enable;
	}

	public static void iPlayGif(ProGifRecorder recorderSource, Image playerImage, string playerName, Action<float> onLoading = null)
	{
		Instance.PlayGif(recorderSource, playerImage, playerName, onLoading);
	}

	public static void iPlayGif(ProGifRecorder recorderSource, Renderer playerRenderer, string playerName, Action<float> onLoading = null)
	{
		Instance.PlayGif(recorderSource, playerRenderer, playerName, onLoading);
	}

	public static ProGifPlayer iGetPlayer(string playerName)
	{
		return Instance.GetPlayer(playerName);
	}

	public static void iPausePlayer(string playerName)
	{
		Instance.PausePlayer(playerName);
	}

	public static void iResumePlayer(string playerName)
	{
		Instance.ResumePlayer(playerName);
	}

	public static void iStopPlayer(string playerName)
	{
		Instance.StopPlayer(playerName);
	}

	public static void iClearPlayer(string playerName)
	{
		Instance.ClearPlayer(playerName);
	}
}
