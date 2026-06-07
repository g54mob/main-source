using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[DisallowMultipleComponent]
public class ProGifRecorderComponent : MonoBehaviour
{
	public enum EncodePlayMode
	{
		Normal = 0,
		Reverse = 1,
		PingPong = 2
	}

	public Action onDurationEnd;

	[SerializeField]
	private Vector2 m_GifRatio = new Vector2(0f, 0f);

	[SerializeField]
	private bool m_AutoAspect = true;

	[SerializeField]
	[Min(8f)]
	private int m_Width = 320;

	[SerializeField]
	[Min(8f)]
	private int m_Height = 200;

	[SerializeField]
	[Range(1f, 30f)]
	private int m_FramePerSecond = 15;

	[SerializeField]
	[Min(-1f)]
	private int m_Repeat;

	[SerializeField]
	[Range(1f, 100f)]
	private int m_Quality = 15;

	[SerializeField]
	[Min(0.1f)]
	private float m_RecordTime = 3f;

	public ImageRotator.Rotation m_Rotation;

	[SerializeField]
	private float m_FrameDelay_Override;

	[SerializeField]
	private Color32 m_TransparentColor = new Color32(0, 0, 0, 0);

	[SerializeField]
	private bool m_AutoTransparent;

	public EncodePlayMode m_EncodePlayMode;

	public System.Threading.ThreadPriority WorkerPriority = System.Threading.ThreadPriority.BelowNormal;

	private int m_MaxFrameCount;

	private Action<float> _OnRecordAction;

	private float m_Time;

	private float m_TimePerFrame;

	private Queue<RenderTexture> m_Frames;

	private RenderTexture m_RecycledRenderTexture;

	private int id;

	private float progress;

	private string filePath = string.Empty;

	private bool invokeFileProgress;

	private bool invokeFileSaved;

	public ProGifRecorder.RecorderState State { get; private set; }

	public string SaveFolder { get; set; }

	public float EstimatedMemoryUse => (float)m_FramePerSecond * m_RecordTime * (float)(m_Width * m_Height * 4) / 1048576f;

	public int Width => m_Width;

	public int Height => m_Height;

	public bool IsCustomRatio
	{
		get
		{
			if (m_GifRatio.x > 0f)
			{
				return m_GifRatio.y > 0f;
			}
			return false;
		}
	}

	public float RecordProgress => (float)m_Frames.Count / (float)m_MaxFrameCount;

	public int FPS => m_FramePerSecond;

	public Queue<RenderTexture> Frames => m_Frames;

	public event Action OnPreProcessingDone = delegate
	{
	};

	public event Action<int, float> OnFileSaveProgress = delegate
	{
	};

	public event Action<int, string> OnFileSaved = delegate
	{
	};

	public void SetOnRecordAction(Action<float> onRecordAction)
	{
		_OnRecordAction = onRecordAction;
	}

	public void ForceSetFrames(Queue<RenderTexture> renderTextures)
	{
		FlushMemory();
		m_Frames = renderTextures;
	}

	public void Setup(bool autoAspect, int width, int height, int fps, float recorderTime, int repeat, int quality)
	{
		_Setup(autoAspect, width, height, fps, recorderTime, repeat, quality, new Vector2(0f, 0f));
	}

	public void Setup(Vector2 gifAspectRatio, int width, int height, int fps, float recorderTime, int repeat, int quality)
	{
		_Setup(autoAspect: false, width, height, fps, recorderTime, repeat, quality, gifAspectRatio);
	}

	private void _Setup(bool autoAspect, int width, int height, int fps, float recorderTime, int repeat, int quality, Vector2 gifAspectRatio)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to setup the component during the pre-processing step.");
			return;
		}
		FlushMemory();
		SetGifAspectRatio(gifAspectRatio);
		m_AutoAspect = IsCustomRatio || autoAspect;
		m_Width = (int)Mathf.Clamp(width, 8f, float.PositiveInfinity);
		if (m_AutoAspect)
		{
			float num = ((Camera.main != null) ? Camera.main.aspect : ((float)(Screen.width / Screen.height)));
			if (num < 1f)
			{
				m_Height = (int)Mathf.Clamp(Mathf.RoundToInt((float)m_Width / num), 8f, float.PositiveInfinity);
			}
			else
			{
				m_Width = (int)Mathf.Clamp(Mathf.RoundToInt((float)m_Width * num), 8f, float.PositiveInfinity);
				m_Height = (int)Mathf.Clamp(Mathf.RoundToInt((float)m_Width / num), 8f, float.PositiveInfinity);
			}
		}
		else
		{
			m_Height = (int)Mathf.Clamp(height, 8f, float.PositiveInfinity);
		}
		m_FramePerSecond = Mathf.Clamp(fps, 1, 30);
		m_RecordTime = Mathf.Clamp(recorderTime, 0.1f, float.PositiveInfinity);
		m_Repeat = (int)Mathf.Clamp(repeat, -1f, float.PositiveInfinity);
		m_Quality = Mathf.Clamp(quality, 1, 100);
		Init();
	}

	public void SetOverrideFrameDelay(float frameDelayInSeconds)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to set gif (override) frame delay during the pre-processing step.");
		}
		else
		{
			m_FrameDelay_Override = frameDelayInSeconds;
		}
	}

	public void SetTransparent(Color32 color32)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to set gif transparent during the pre-processing step.");
		}
		else
		{
			m_TransparentColor = color32;
		}
	}

	public void SetTransparent(bool autoDetectTransparent)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to set gif transparent during the pre-processing step.");
		}
		else
		{
			m_AutoTransparent = autoDetectTransparent;
		}
	}

	public void SetGifRotation(ImageRotator.Rotation rotation)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to set gif rotation during the pre-processing step.");
		}
		else
		{
			m_Rotation = rotation;
		}
	}

	public void SetGifAspectRatio(Vector2 gifAspectRatio)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to set gif aspact ratio during the pre-processing step.");
		}
		else
		{
			m_GifRatio = gifAspectRatio;
		}
	}

	public void Pause()
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to pause recording during the pre-processing step. The recorder is automatically paused when pre-processing.");
		}
		else if (State == ProGifRecorder.RecorderState.Stopped)
		{
			Debug.LogWarning("Attempting to pause recording after it has been stopped.");
		}
		else
		{
			State = ProGifRecorder.RecorderState.Paused;
		}
	}

	public void Resume()
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to resume recording during the pre-processing step.");
		}
		else if (State == ProGifRecorder.RecorderState.Stopped)
		{
			Debug.LogWarning("Attempting to resume recording after it has been stopped.");
		}
		else
		{
			State = ProGifRecorder.RecorderState.Recording;
		}
	}

	public void Record(Action onDurationEnd = null)
	{
		this.onDurationEnd = onDurationEnd;
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to start recording during the pre-processing step.");
		}
		else if (State == ProGifRecorder.RecorderState.Stopped)
		{
			Debug.LogWarning("Attempting to start recording after it has been stopped.");
		}
		else
		{
			State = ProGifRecorder.RecorderState.Recording;
		}
	}

	public void Stop()
	{
		State = ProGifRecorder.RecorderState.Stopped;
	}

	public void FlushMemory()
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to flush memory during the pre-processing step.");
			return;
		}
		Init();
		if (m_RecycledRenderTexture != null)
		{
			Flush(m_RecycledRenderTexture);
		}
		if (m_Frames == null)
		{
			return;
		}
		foreach (RenderTexture frame in m_Frames)
		{
			Flush(frame);
		}
		m_Frames.Clear();
	}

	public void Save()
	{
		Save(GenerateFileName());
	}

	public void Save(string filename)
	{
		if (State == ProGifRecorder.RecorderState.PreProcessing)
		{
			Debug.LogWarning("Attempting to save during the pre-processing step.");
			return;
		}
		if (m_Frames.Count == 0)
		{
			Debug.LogWarning("Nothing to save. Maybe you forgot to start the recorder?");
			return;
		}
		State = ProGifRecorder.RecorderState.PreProcessing;
		if (string.IsNullOrEmpty(filename))
		{
			filename = GenerateFileName();
		}
		StartCoroutine(PreProcess(filename));
	}

	private void Awake()
	{
		m_Frames = new Queue<RenderTexture>();
		Init();
	}

	private void Update()
	{
		if (invokeFileProgress)
		{
			invokeFileProgress = false;
			this.OnFileSaveProgress(id, progress);
		}
		if (invokeFileSaved)
		{
			invokeFileSaved = false;
			this.OnFileSaved(id, filePath);
		}
	}

	private void OnDestroy()
	{
		FlushMemory();
	}

	public void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (State != ProGifRecorder.RecorderState.Recording)
		{
			Graphics.Blit(source, destination);
			return;
		}
		m_Time += Time.unscaledDeltaTime;
		if (m_Time >= m_TimePerFrame)
		{
			if (_OnRecordAction != null)
			{
				_OnRecordAction(RecordProgress);
			}
			if (m_Frames.Count >= m_MaxFrameCount)
			{
				m_RecycledRenderTexture = m_Frames.Dequeue();
				if (onDurationEnd != null)
				{
					onDurationEnd();
					onDurationEnd = null;
				}
			}
			m_Time -= m_TimePerFrame;
			RenderTexture renderTexture = m_RecycledRenderTexture;
			m_RecycledRenderTexture = null;
			if (renderTexture == null)
			{
				renderTexture = new RenderTexture(m_Width, m_Height, 24, RenderTextureFormat.ARGB32);
				renderTexture.wrapMode = TextureWrapMode.Clamp;
				renderTexture.filterMode = FilterMode.Bilinear;
				renderTexture.anisoLevel = 0;
			}
			renderTexture.DiscardContents();
			Graphics.Blit(source, renderTexture);
			m_Frames.Enqueue(renderTexture);
		}
		Graphics.Blit(source, destination);
	}

	private void Init()
	{
		State = ProGifRecorder.RecorderState.Paused;
		ComputeHeight();
		m_MaxFrameCount = Mathf.RoundToInt(m_RecordTime * (float)m_FramePerSecond);
		m_TimePerFrame = 1f / (float)m_FramePerSecond;
		m_Time = 0f;
		if (string.IsNullOrEmpty(SaveFolder))
		{
			SaveFolder = new FilePathName().GetSaveDirectory();
		}
	}

	public void ComputeHeight()
	{
		if (m_AutoAspect && !IsCustomRatio && Camera.main != null)
		{
			m_Height = Mathf.RoundToInt((float)m_Width / Camera.main.aspect);
		}
	}

	private void Flush(Texture texture)
	{
		if (!(RenderTexture.active == texture))
		{
			UnityEngine.Object.Destroy(texture);
		}
	}

	private string GenerateFileName()
	{
		return new FilePathName().GetGifFileName();
	}

	private IEnumerator PreProcess(string filename)
	{
		string filepath = SaveFolder + "/" + filename + ".gif";
		List<Frame> frames = new List<Frame>(m_Frames.Count);
		if (IsCustomRatio)
		{
			float num = (float)m_Width / (float)m_Height;
			float num2 = m_GifRatio.x / m_GifRatio.y;
			if (num > num2)
			{
				if (num2 == 1f)
				{
					if (m_Width > m_Height)
					{
						m_Width = m_Height;
					}
					else if (m_Height > m_Width)
					{
						m_Height = m_Width;
					}
				}
				else
				{
					m_Width = (int)((float)m_Height * num2);
				}
			}
			else if (num < num2)
			{
				if (num2 == 1f)
				{
					if (m_Width > m_Height)
					{
						m_Width = m_Height;
					}
					else if (m_Height > m_Width)
					{
						m_Height = m_Width;
					}
				}
				else
				{
					m_Height = (int)((float)m_Width / num2);
				}
			}
		}
		Texture2D temp = new Texture2D(m_Width, m_Height, TextureFormat.RGB24, mipChain: false)
		{
			hideFlags = HideFlags.HideAndDontSave,
			wrapMode = TextureWrapMode.Clamp,
			filterMode = FilterMode.Bilinear,
			anisoLevel = 0
		};
		RenderTexture[] array = m_Frames.ToArray();
		switch (m_EncodePlayMode)
		{
		case EncodePlayMode.Reverse:
			array = array.Reverse().ToArray();
			break;
		case EncodePlayMode.PingPong:
			array = array.Concat(array.Reverse()).ToArray();
			break;
		}
		RenderTexture[] array2 = array;
		foreach (RenderTexture source in array2)
		{
			Frame item = ToGifFrame(source, temp);
			frames.Add(item);
			yield return null;
		}
		Flush(temp);
		State = ProGifRecorder.RecorderState.Paused;
		if (this.OnPreProcessingDone != null)
		{
			this.OnPreProcessingDone();
		}
		ProGifEncoder proGifEncoder = new ProGifEncoder(m_Repeat, m_Quality);
		if (m_AutoTransparent)
		{
			proGifEncoder.m_AutoTransparent = m_AutoTransparent;
		}
		else if (m_TransparentColor.a != 0)
		{
			proGifEncoder.SetTransparencyColor(m_TransparentColor);
		}
		if (m_FrameDelay_Override > 0f)
		{
			proGifEncoder.SetDelay(Mathf.RoundToInt(m_FrameDelay_Override * 1000f));
		}
		else
		{
			proGifEncoder.SetDelay(Mathf.RoundToInt(m_TimePerFrame * 1000f));
		}
		ProGifWorker proGifWorker = new ProGifWorker(WorkerPriority);
		proGifWorker.m_Encoder = proGifEncoder;
		proGifWorker.m_Frames = frames;
		proGifWorker.m_FilePath = filepath;
		proGifWorker.m_OnFileSaved = FileSaved;
		proGifWorker.m_OnFileSaveProgress = FileSaveProgress;
		proGifWorker.Start();
	}

	private void FileSaved(int id, string path)
	{
		this.id = id;
		filePath = path;
		invokeFileSaved = true;
	}

	private void FileSaveProgress(int id, float progress)
	{
		this.id = id;
		this.progress = progress;
		invokeFileProgress = true;
	}

	private Frame ToGifFrame(RenderTexture source, Texture2D target)
	{
		RenderTexture.active = source;
		if (IsCustomRatio)
		{
			target.ReadPixels(new Rect((source.width - target.width) / 2, (source.height - target.height) / 2, target.width, target.height), 0, 0);
		}
		else
		{
			target.ReadPixels(new Rect(0f, 0f, source.width, source.height), 0, 0);
		}
		target.Apply();
		RenderTexture.active = null;
		int width = target.width;
		int height = target.height;
		if (m_Rotation == ImageRotator.Rotation.None)
		{
			return new Frame
			{
				Width = width,
				Height = height,
				Data = target.GetPixels32()
			};
		}
		switch (m_Rotation)
		{
		case ImageRotator.Rotation.Right:
			width = target.height;
			height = target.width;
			break;
		case ImageRotator.Rotation.Left:
			width = target.height;
			height = target.width;
			break;
		}
		Color32[] data = ImageRotator.RotateImageToColor32(target, m_Rotation);
		return new Frame
		{
			Width = width,
			Height = height,
			Data = data
		};
	}

	public void RemoveScript()
	{
		OnDestroy();
		UnityEngine.Object.Destroy(this);
	}
}
