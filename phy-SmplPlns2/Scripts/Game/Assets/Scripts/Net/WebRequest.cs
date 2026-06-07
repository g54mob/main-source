using System;
using Jundroo.Common.Events;
using UnityEngine;

namespace Assets.Scripts.Net
{
	public abstract class WebRequest
	{
		public abstract byte[] Bytes { get; }

		public abstract string Error { get; }

		public WWWForm Form { get; private set; }

		public bool HasError => !string.IsNullOrEmpty(Error);

		public bool IsCanceled { get; set; }

		public abstract bool IsDone { get; }

		public abstract float Progress { get; }

		public abstract string Text { get; }

		public abstract string Url { get; }

		private static bool IsMac
		{
			get
			{
				if (Application.platform != RuntimePlatform.OSXEditor)
				{
					return Application.platform == RuntimePlatform.OSXPlayer;
				}
				return true;
			}
		}

		public event WebRequestDelegate Complete;

		public static WebRequest Get(string url)
		{
			WebRequestUnity r = WebRequestUnity.CreateGetRequest(url);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(() => r.Update());
			return r;
		}

		public static WebRequest Post(string url, WWWForm form)
		{
			WebRequestUnity r = WebRequestUnity.CreatePostRequest(url, form);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(() => r.Update());
			return r;
		}

		private bool Update()
		{
			bool result = true;
			if (IsDone || IsCanceled)
			{
				result = false;
				try
				{
					this.Complete?.Invoke(this);
				}
				catch (Exception ex)
				{
					Debug.LogErrorFormat("An exception was thrown by a WebRequest.Completed event subscriber: ", ex.Message);
				}
			}
			return result;
		}
	}
}
