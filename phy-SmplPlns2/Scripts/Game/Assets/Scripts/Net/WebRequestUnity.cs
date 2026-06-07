using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Net
{
	public class WebRequestUnity : WebRequest
	{
		private UnityWebRequest _webRequest;

		public override byte[] Bytes => _webRequest.downloadHandler.data;

		public override string Error => _webRequest.error;

		public override bool IsDone => _webRequest.isDone;

		public override float Progress => Mathf.Max(_webRequest.downloadProgress, _webRequest.uploadProgress);

		public override string Text => _webRequest.downloadHandler.text;

		public override string Url => _webRequest.url;

		public static WebRequestUnity CreateGetRequest(string url)
		{
			WebRequestUnity webRequestUnity = new WebRequestUnity();
			webRequestUnity._webRequest = UnityWebRequest.Get(url);
			webRequestUnity._webRequest.SendWebRequest();
			return webRequestUnity;
		}

		public static WebRequestUnity CreatePostRequest(string url, WWWForm form)
		{
			WebRequestUnity webRequestUnity = new WebRequestUnity();
			webRequestUnity._webRequest = UnityWebRequest.Post(url, form);
			webRequestUnity._webRequest.SendWebRequest();
			return webRequestUnity;
		}
	}
}
