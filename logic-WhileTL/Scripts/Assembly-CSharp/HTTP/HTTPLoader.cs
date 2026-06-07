using System;
using System.Collections;
using Unity.Components.Logs;
using UnityEngine;

namespace HTTP
{
	public class HTTPLoader : MonoBehaviour, IHTTP
	{
		private WWW _currentLoad;

		private Action<string, bool> _callback;

		public static HTTPLoader Create(GameObject baseObject)
		{
			GameObject gameObject = baseObject;
			if (gameObject == null)
			{
				try
				{
					gameObject = GameObject.FindGameObjectWithTag("System");
				}
				catch
				{
				}
			}
			if (gameObject == null)
			{
				gameObject = new GameObject("__HTTPLoader__");
			}
			HTTPLoader hTTPLoader = gameObject.AddComponent<HTTPLoader>();
			hTTPLoader.Init();
			return hTTPLoader;
		}

		protected void Init()
		{
		}

		public void Get(string url, Action<string, bool> callback)
		{
			Log.Net("send GET url='{0}', time={1}s", url, Time.realtimeSinceStartup);
			WWW wWW = new WWW(url);
			if (Application.isPlaying)
			{
				StartCoroutine(Load(wWW, callback));
				return;
			}
			while (!wWW.isDone)
			{
			}
			Call(wWW, callback);
		}

		private IEnumerator Load(WWW www, Action<string, bool> callback)
		{
			yield return www;
			Log.Net("receive GET url='{0}', error='{1}' time={2}s", www.url, www.error, Time.realtimeSinceStartup);
			Call(www, callback);
		}

		private void Call(WWW w, Action<string, bool> done)
		{
			done?.Invoke(w.text, string.IsNullOrEmpty(w.error));
		}
	}
}
