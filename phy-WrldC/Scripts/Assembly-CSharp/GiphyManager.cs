using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GiphyManager : MonoBehaviour
{
	[Header("[Giphy Channel]")]
	public string m_GiphyUserName = "";

	public string m_GiphyApiKey = "";

	public string m_GiphyUploadApiKey = "";

	[Header("[Giphy APIs]")]
	public string m_NormalGifApi = "http://api.giphy.com/v1/gifs";

	public string m_UploadApi = "http://upload.giphy.com/v1/gifs";

	[Header("[Optional-Promotion]")]
	public string m_Source_Post_Url = "";

	private static GiphyManager _instance;

	private WWW wwwUpload;

	private Action<float> _onUploadProgress;

	public static GiphyManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject("[GiphyManager]").AddComponent<GiphyManager>();
			}
			return _instance;
		}
	}

	private bool HasUserName
	{
		get
		{
			_ = !string.IsNullOrEmpty(m_GiphyUserName);
			return true;
		}
	}

	private bool HasApiKey
	{
		get
		{
			bool num = !string.IsNullOrEmpty(m_GiphyApiKey);
			if (!num)
			{
				Debug.LogWarning("Giphy API Key is required!");
			}
			return num;
		}
	}

	private bool HasUploadApiKey
	{
		get
		{
			bool num = !string.IsNullOrEmpty(m_GiphyUploadApiKey);
			if (!num)
			{
				Debug.LogWarning("Giphy Upload API Key is required!");
			}
			return num;
		}
	}

	public void SetChannelAuthentication(string userName, string apiKey = "", string uploadApiKey = "")
	{
		m_GiphyUserName = userName;
		m_GiphyApiKey = apiKey;
		m_GiphyUploadApiKey = uploadApiKey;
	}

	private void Start()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	private void Update()
	{
		if (wwwUpload != null && _onUploadProgress != null)
		{
			_onUploadProgress(wwwUpload.uploadProgress);
		}
	}

	public void Upload(string filePath, Action<GiphyUpload.Response> onComplete, Action<float> onProgress = null, Action onFail = null)
	{
		if (HasUploadApiKey && HasUserName)
		{
			StartCoroutine(_Upload(filePath, null, onComplete, onProgress, onFail));
		}
	}

	public void Upload(string filePath, List<string> tags, Action<GiphyUpload.Response> onComplete, Action<float> onProgress = null, Action onFail = null)
	{
		if (HasUploadApiKey && HasUserName)
		{
			StartCoroutine(_Upload(filePath, tags, onComplete, onProgress, onFail));
		}
	}

	private IEnumerator _Upload(string filePath, List<string> tags, Action<GiphyUpload.Response> onComplete, Action<float> onProgress = null, Action onFail = null)
	{
		string url = m_UploadApi + "?api_key=" + m_GiphyUploadApiKey;
		_onUploadProgress = onProgress;
		string text = "";
		if (tags != null && tags.Count > 0)
		{
			foreach (string tag in tags)
			{
				if (!string.IsNullOrEmpty(tag))
				{
					text = text + tag + ",";
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Substring(0, text.Length - 1);
			}
		}
		byte[] contents = File.ReadAllBytes(filePath);
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddBinaryData("file", contents);
		wWWForm.AddField("username", m_GiphyUserName);
		wWWForm.AddField("api_key", m_GiphyUploadApiKey);
		if (!string.IsNullOrEmpty(text))
		{
			wWWForm.AddField("tags", text);
		}
		if (!string.IsNullOrEmpty(m_Source_Post_Url))
		{
			wWWForm.AddField("source_post_url", m_Source_Post_Url);
		}
		wwwUpload = new WWW(url, wWWForm);
		wwwUpload.threadPriority = ThreadPriority.High;
		yield return wwwUpload;
		if (!string.IsNullOrEmpty(wwwUpload.error))
		{
			onFail?.Invoke();
			Debug.Log("Error during upload: " + wwwUpload.error + "\n" + wwwUpload.text);
		}
		else
		{
			GiphyUpload.Response obj = JsonConvert.DeserializeObject<GiphyUpload.Response>(wwwUpload.text);
			onComplete(obj);
		}
		if (wwwUpload != null)
		{
			wwwUpload.Dispose();
			wwwUpload = null;
		}
	}

	public void GetById(string giphyGifId, Action<GiphyGetById.Response> onComplete, Action onFail = null)
	{
		if (HasApiKey && HasUserName)
		{
			StartCoroutine(_GetById(giphyGifId, onComplete, onFail));
		}
	}

	private IEnumerator _GetById(string giphyGifId, Action<GiphyGetById.Response> onComplete, Action onFail)
	{
		if (!string.IsNullOrEmpty(giphyGifId))
		{
			string url = m_NormalGifApi + "/" + giphyGifId + "?api_key=" + m_GiphyApiKey;
			WWW www = new WWW(url);
			yield return www;
			if (www.error == null)
			{
				GiphyGetById.Response obj = JsonConvert.DeserializeObject<GiphyGetById.Response>(www.text);
				onComplete?.Invoke(obj);
			}
			else
			{
				onFail?.Invoke();
				Debug.Log("Error during get by id: " + giphyGifId + ", Error: " + www.error);
			}
			www.Dispose();
		}
		else
		{
			Debug.LogWarning("GIF id is empty!");
		}
	}
}
