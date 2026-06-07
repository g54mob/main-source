using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Web
{
	public class WebRequestUnity : WebRequest
	{
		private float _progress;

		private UnityWebRequest _webRequest;

		public override byte[] Bytes => _webRequest.downloadHandler.data;

		public override string Error => _webRequest.error;

		public override bool IsDone => _webRequest.isDone;

		public override float Progress
		{
			get
			{
				_progress = Mathf.Max(_progress, _webRequest.downloadProgress, _webRequest.uploadProgress);
				return _progress;
			}
		}

		public override string Text => _webRequest.downloadHandler.text;

		public override string Url => _webRequest.url;

		public WebRequestUnity(string url)
		{
			_webRequest = UnityWebRequest.Get(url);
			_webRequest.SendWebRequest();
		}

		public WebRequestUnity(string url, WWWForm form)
		{
			_webRequest = UnityWebRequest.Post(url, form);
			_webRequest.SendWebRequest();
		}
	}
}
