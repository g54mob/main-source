using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProGifDemoMgr : MonoBehaviour
{
	public GameObject prefab_GifControlPanel;

	public GameObject prefab_GifPreviewAndSharePanel;

	public Transform componentContainerT;

	public Camera m_MainCamera;

	public CanvasScaler m_MainCanvasScaler;

	public TextMesh m_TM_Counter;

	public MeshRenderer m_CubeMesh;

	public RawImage m_RawImage;

	public DImageDisplayHandler m_ImageDisplayHandler;

	private Texture2D _refTexture2d;

	private static ProGifDemoMgr _instance;

	private int counter;

	private float nextBubbleMessageTime;

	private ProGifControlPanel m_ProGifPanel;

	public Button btn_ShowGifPanel;

	public Button btn_PauseRecord;

	public Button btn_ResumeRecord;

	public Button btn_SaveRecord;

	public Button btn_CancelRecord;

	public Button btn_ShowGifPlayerPanel;

	public Slider sld_Progress;

	public Text text_Progress;

	public static ProGifDemoMgr Instance => _instance;

	public static T InstantiatePrefab<T>(GameObject prefab) where T : MonoBehaviour
	{
		if (prefab != null)
		{
			GameObject gameObject = Object.Instantiate(prefab);
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

	private void Start()
	{
		_instance = this;
		SetButtonState(btn_PauseRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_ResumeRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_CancelRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		if (Screen.width > Screen.height)
		{
			m_MainCanvasScaler.referenceResolution = new Vector2(1920f, 1080f);
		}
		else
		{
			m_MainCanvasScaler.referenceResolution = new Vector2(1080f, 1920f);
		}
	}

	public void AddCounter()
	{
		if (!(m_TM_Counter == null))
		{
			counter++;
			if (counter > 9)
			{
				counter = 0;
			}
			m_TM_Counter.text = counter.ToString();
		}
	}

	public void UpdateRecordOrSaveProgress(float progress)
	{
		if (sld_Progress != null)
		{
			sld_Progress.value = progress;
		}
		if (text_Progress != null)
		{
			text_Progress.text = "Progress: " + (int)(100f * progress) + " %";
		}
		if (ProGifManager.Instance.m_GifRecorder != null && ProGifManager.Instance.m_GifRecorder.State == ProGifRecorder.RecorderState.Recording)
		{
			SetButtonState(btn_PauseRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
			SetButtonState(btn_ResumeRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
			RenderTexture texture = ProGifManager.Instance.m_GifRecorder.GetTexture();
			if ((bool)m_CubeMesh)
			{
				m_CubeMesh.material.mainTexture = texture;
			}
			if ((bool)m_ImageDisplayHandler && (bool)m_RawImage && (bool)texture)
			{
				m_ImageDisplayHandler.SetRawImage(m_RawImage, texture);
			}
		}
	}

	public void SetGifProgressColor(Color color)
	{
		if (sld_Progress.fillRect.GetComponent<Image>().color != color)
		{
			sld_Progress.fillRect.GetComponent<Image>().color = color;
		}
	}

	public void ShowGIFPanel()
	{
		if (ProGifManager.Instance.m_GifRecorder != null)
		{
			if (Time.time > nextBubbleMessageTime)
			{
				nextBubbleMessageTime = Time.time + 2f;
				if (ProGifManager.Instance.m_GifRecorder.State == ProGifRecorder.RecorderState.Paused)
				{
					Debug.Log("Making GIF, please wait");
				}
				else if (ProGifManager.Instance.m_GifRecorder.State == ProGifRecorder.RecorderState.Recording)
				{
					SaveRecord();
				}
			}
			return;
		}
		m_ProGifPanel = ProGifControlPanel.Create(prefab_GifControlPanel, componentContainerT);
		m_ProGifPanel.Setup(delegate
		{
			SetGifProgressColor(ProGifManager.GetColor(ProGifManager.CommonColorEnum.LightYellow));
			SetButtonState(btn_ShowGifPanel, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
			SetButtonState(btn_SaveRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
			SetButtonState(btn_ShowGifPlayerPanel, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
			SetButtonState(btn_CancelRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
		}, UpdateRecordOrSaveProgress, delegate
		{
			Debug.Log("DemoMgr - Record duration MAX.");
		});
	}

	public void PauseRecord()
	{
		Debug.Log("Pause Recording");
		ProGifManager.Instance.PauseRecord();
	}

	public void ResumeRecord()
	{
		Debug.Log("Resume Recording");
		ProGifManager.Instance.ResumeRecord();
	}

	public void CancelRecord()
	{
		ProGifManager.Instance.StopRecord();
		ProGifManager.Instance.ClearRecorder();
		UpdateRecordOrSaveProgress(0f);
		SetButtonState(btn_ShowGifPanel, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
		SetButtonState(btn_PauseRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_ResumeRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_SaveRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_CancelRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
	}

	public void SaveRecord()
	{
		ShowGifPreviewAndSharePanel("", loadFile: false);
		Debug.Log("Start making GIF");
		ProGifManager.Instance.StopAndSaveRecord(delegate
		{
			Debug.Log("On recorder pre-processing done.");
		}, delegate(int id, float progress)
		{
			UpdateRecordOrSaveProgress(progress);
			SetGifProgressColor(ProGifManager.GetColor(ProGifManager.CommonColorEnum.Red));
		}, delegate(int id, string path)
		{
			SetButtonState(btn_ShowGifPanel, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
			SetButtonState(btn_ShowGifPlayerPanel, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Blue), enable: true);
			SetButtonState(btn_SaveRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
			SetButtonState(btn_CancelRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
			UpdateRecordOrSaveProgress(1f);
			string text = MobileMedia.CopyMedia(path, "ProGif_Recorder", Path.GetFileNameWithoutExtension(path), ".gif", isImage: true);
			Debug.Log("Mobile Media Save Path: " + text);
			StartCoroutine(_OnFileSaved());
		});
		SetButtonState(btn_PauseRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_ResumeRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		SetButtonState(btn_SaveRecord, ProGifManager.GetColor(ProGifManager.CommonColorEnum.Black), enable: false);
		RenderTexture texture = ProGifManager.Instance.m_GifRecorder.GetTexture();
		if ((bool)m_CubeMesh)
		{
			m_CubeMesh.material.mainTexture = texture;
		}
		if ((bool)m_ImageDisplayHandler && (bool)m_RawImage && (bool)texture)
		{
			m_ImageDisplayHandler.SetRawImage(m_RawImage, texture);
		}
	}

	private IEnumerator _OnFileSaved()
	{
		yield return new WaitForSeconds(2f);
		_ResetGifProgress();
	}

	private void _ResetGifProgress()
	{
		UpdateRecordOrSaveProgress(0f);
		SetGifProgressColor(ProGifManager.GetColor(ProGifManager.CommonColorEnum.White));
	}

	private IEnumerator _OnLoadingComplete()
	{
		yield return new WaitForSeconds(2f);
		_ResetGifProgress();
	}

	public void ShowGifPreviewAndSharePanel(string gifPath, bool loadFile)
	{
		ProGifPreviewSharePanel.Create(prefab_GifPreviewAndSharePanel, componentContainerT).Setup(gifPath, loadFile, delegate(float progress)
		{
			UpdateRecordOrSaveProgress(progress);
			SetGifProgressColor(ProGifManager.GetColor(ProGifManager.CommonColorEnum.Green));
			Debug.Log("progress: " + (int)(progress * 100f) + " %");
			if (progress >= 1f)
			{
				StartCoroutine(_OnLoadingComplete());
			}
		});
		ProGifManager.Instance.m_GifPlayer.SetOnPlayingCallback(delegate(GifTexture gifTex)
		{
			if (m_CubeMesh != null)
			{
				gifTex.SetColorsToTexture2D(ref _refTexture2d);
				m_CubeMesh.material.mainTexture = _refTexture2d;
				m_RawImage.texture = _refTexture2d;
				if ((bool)m_ImageDisplayHandler && (bool)m_RawImage && (bool)_refTexture2d)
				{
					m_ImageDisplayHandler.SetRawImage(m_RawImage, _refTexture2d);
				}
			}
		});
	}

	public void ShowPlayerPanel(string gifPath)
	{
	}

	public void SetButtonState(Button button, Color color, bool enable)
	{
		button.enabled = enable;
		button.image.color = color;
	}
}
