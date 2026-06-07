using System;
using System.Collections.Generic;
using UnityEngine;

public class ProGifRecorder
{
	public enum RecorderState
	{
		Paused = 0,
		PreProcessing = 1,
		Recording = 2,
		Stopped = 3
	}

	public bool IsPreProcessingDone;

	public ProGifRecorderComponent recorderCom;

	private string _SavedFilePath = string.Empty;

	public RecorderState State
	{
		get
		{
			if (recorderCom != null)
			{
				return recorderCom.State;
			}
			return RecorderState.Stopped;
		}
	}

	public RenderTexture[] Frames
	{
		get
		{
			if (recorderCom == null)
			{
				return null;
			}
			return recorderCom.Frames.ToArray();
		}
	}

	public int Width
	{
		get
		{
			if (recorderCom == null)
			{
				return 0;
			}
			return recorderCom.Width;
		}
	}

	public int Height
	{
		get
		{
			if (recorderCom == null)
			{
				return 0;
			}
			return recorderCom.Height;
		}
	}

	public bool IsCustomRatio
	{
		get
		{
			if (recorderCom == null)
			{
				return false;
			}
			return recorderCom.IsCustomRatio;
		}
	}

	public int FPS
	{
		get
		{
			if (recorderCom == null)
			{
				return 0;
			}
			return recorderCom.FPS;
		}
	}

	public ImageRotator.Rotation Rotation
	{
		get
		{
			if (recorderCom == null)
			{
				return ImageRotator.Rotation.None;
			}
			return recorderCom.m_Rotation;
		}
	}

	public string SavedFilePath => _SavedFilePath;

	public float RecordProgress
	{
		get
		{
			if (recorderCom != null)
			{
				return recorderCom.RecordProgress;
			}
			return 0f;
		}
	}

	public float EstimatedMemoryUse
	{
		get
		{
			if (recorderCom != null)
			{
				return recorderCom.EstimatedMemoryUse;
			}
			return 0f;
		}
	}

	public event Action OnPreProcessingDone = delegate
	{
	};

	public event Action<int, float> OnFileSaveProgress = delegate
	{
	};

	public event Action<int, string> OnFileSaved = delegate
	{
	};

	public ProGifRecorder(Camera camera = null)
	{
		if (camera == null)
		{
			camera = Camera.main;
			if (camera == null)
			{
				Debug.LogWarning("You are trying to create recorder with NO Camera!");
				return;
			}
		}
		recorderCom = camera.gameObject.GetComponent<ProGifRecorderComponent>();
		if (recorderCom == null)
		{
			recorderCom = camera.gameObject.AddComponent<ProGifRecorderComponent>();
		}
		recorderCom.OnPreProcessingDone += Recorder_OnPreProcessingDone;
		IsPreProcessingDone = false;
		recorderCom.OnFileSaveProgress += Recorder_OnFileSaveProgress;
		recorderCom.OnFileSaved += Recorder_OnFileSaved;
	}

	public void Setup(bool autoAspect, int width, int height, int fps, float recorderTime, int repeat, int quality)
	{
		if (recorderCom != null)
		{
			recorderCom.Setup(autoAspect, width, height, fps, recorderTime, repeat, quality);
		}
	}

	public void Setup(Vector2 gifAspectRatio, int width, int height, int fps, float recorderTime, int repeat, int quality)
	{
		if (recorderCom != null)
		{
			recorderCom.Setup(gifAspectRatio, width, height, fps, recorderTime, repeat, quality);
		}
	}

	public RenderTexture GetTexture(int index = -1)
	{
		if (recorderCom != null)
		{
			if (recorderCom.Frames.Count <= 0)
			{
				return null;
			}
			if (index != 0)
			{
				index = ((index == -1) ? (recorderCom.Frames.Count - 1) : Mathf.Clamp(index, 0, recorderCom.Frames.Count - 1));
			}
			return recorderCom.Frames.ToArray()[index];
		}
		return null;
	}

	public void SetGifRotation(ImageRotator.Rotation rotation)
	{
		if (recorderCom != null)
		{
			recorderCom.SetGifRotation(rotation);
		}
	}

	public void SetGifAspectRatio(Vector2 gifAspectRatio)
	{
		if (recorderCom != null)
		{
			recorderCom.SetGifAspectRatio(gifAspectRatio);
		}
	}

	public void SetOverrideFrameDelay(float frameDelayInSeconds)
	{
		if (recorderCom != null)
		{
			recorderCom.SetOverrideFrameDelay(frameDelayInSeconds);
		}
	}

	public void SetTransparent(Color32 color32)
	{
		if (recorderCom != null)
		{
			recorderCom.SetTransparent(color32);
		}
	}

	public void SetTransparent(bool autoDetectTransparent)
	{
		if (recorderCom != null)
		{
			recorderCom.SetTransparent(autoDetectTransparent);
		}
	}

	public void Pause()
	{
		if (recorderCom != null)
		{
			recorderCom.Pause();
		}
	}

	public void Resume()
	{
		if (recorderCom != null)
		{
			recorderCom.Resume();
		}
	}

	public void Record(Action onDurationEnd)
	{
		if (recorderCom != null)
		{
			recorderCom.Record(onDurationEnd);
		}
	}

	public void Stop()
	{
		if (recorderCom != null)
		{
			recorderCom.Stop();
		}
	}

	public void FlushMemory()
	{
		if (recorderCom != null)
		{
			recorderCom.FlushMemory();
		}
	}

	public void Save()
	{
		if (recorderCom != null)
		{
			recorderCom.Save();
		}
	}

	public void Save(string filename)
	{
		if (recorderCom != null)
		{
			recorderCom.Save(filename);
		}
	}

	public void ForceSetFrames(Queue<RenderTexture> renderTextures)
	{
		if (recorderCom != null)
		{
			recorderCom.ForceSetFrames(renderTextures);
		}
	}

	private void Recorder_OnFileSaved(int id, string path)
	{
		_SavedFilePath = path;
		this.OnFileSaved(id, path);
	}

	private void Recorder_OnFileSaveProgress(int id, float progress)
	{
		this.OnFileSaveProgress(id, progress);
	}

	private void Recorder_OnPreProcessingDone()
	{
		IsPreProcessingDone = true;
		this.OnPreProcessingDone();
	}

	public void SetOnRecordAction(Action<float> onRecordAction)
	{
		if (recorderCom != null)
		{
			recorderCom.SetOnRecordAction(onRecordAction);
		}
	}

	public void Clear()
	{
		if (recorderCom != null)
		{
			recorderCom.RemoveScript();
		}
	}
}
