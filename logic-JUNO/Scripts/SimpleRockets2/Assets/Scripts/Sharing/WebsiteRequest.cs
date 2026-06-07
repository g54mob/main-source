using System;
using Assets.Scripts.Sharing.Handlers;
using Assets.Scripts.Web;
using ModApi.Common.Events;
using UnityEngine;
using Web.Client.Models;

namespace Assets.Scripts.Sharing
{
	public class WebsiteRequest
	{
		public delegate void WebsiteRequestEventHandler(WebsiteRequest request);

		private class CanceledWebRequest : WebRequest
		{
			public override byte[] Bytes => null;

			public override string Error => null;

			public override bool IsDone => true;

			public override float Progress => 0f;

			public override string Text => null;

			public override string Url { get; }

			public CanceledWebRequest(string url)
			{
				Url = url;
			}
		}

		private ClientResponse _response;

		public bool Active => CurrentRequest != null;

		public string BaseUrl { get; }

		public float EndTime { get; private set; }

		public string Error
		{
			get
			{
				string result = null;
				if (CurrentRequest?.Error != null)
				{
					result = CurrentRequest.Error;
				}
				else if (_response?.Error != null)
				{
					result = _response.Error;
				}
				return result;
			}
		}

		public bool IsCanceled { get; private set; }

		public bool IsDone { get; private set; }

		public float Progress => CurrentRequest.Progress;

		public IRequestHandler RequestHandler { get; private set; }

		public ClientResponse Response => _response;

		public byte[] ResponseBytes => CurrentRequest.Bytes;

		public string ResponseText => CurrentRequest.Text;

		public float StartTime { get; private set; }

		public bool Success
		{
			get
			{
				if (Active && CurrentRequest.IsDone)
				{
					return Error == null;
				}
				throw new InvalidOperationException("An operation has not been completed.");
			}
		}

		private WebRequest CurrentRequest { get; set; }

		public event WebsiteRequestEventHandler Canceled;

		public event WebsiteRequestEventHandler Completed;

		public event WebsiteRequestEventHandler Progressed;

		public WebsiteRequest(IRequestHandler handler)
		{
			BaseUrl = Game.SimpleRocketsWebsiteUrl;
			RequestHandler = handler;
		}

		public WebsiteRequest(string baseUrl, IRequestHandler handler)
		{
			BaseUrl = baseUrl;
			RequestHandler = handler;
		}

		public void Cancel()
		{
			IsCanceled = true;
		}

		public void SendRequest()
		{
			if (CurrentRequest == null)
			{
				SubmitAndProcessResponse();
				return;
			}
			throw new InvalidOperationException("A request has already been performed.  Create another instance to perform another.");
		}

		private static void AddUserData(WWWForm form)
		{
			form.AddField("UserName", Game.Instance.Settings.UserName);
			form.AddField("ClientToken", Game.Instance.Settings.ClientToken);
			form.AddField("DeviceId", Game.Instance.Device.DeviceId);
			form.AddField("Platform", Application.platform.ToString());
			form.AddField("ClientVersion", Game.Version.ToString());
		}

		private void SubmitAndProcessResponse()
		{
			if (RequestHandler.IncludeClientData)
			{
				AddUserData(RequestHandler.Form);
			}
			StartTime = Time.unscaledTime;
			string url = BaseUrl + RequestHandler.Endpoint;
			if (IsCanceled)
			{
				CurrentRequest = new CanceledWebRequest(url);
			}
			else
			{
				CurrentRequest = WebRequest.Create(url, RequestHandler.Form);
			}
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(() => Update());
		}

		private bool Update()
		{
			bool flag = false;
			if (CurrentRequest.IsDone || IsCanceled)
			{
				flag = true;
				if (!IsCanceled)
				{
					if (!string.IsNullOrEmpty(ResponseText))
					{
						try
						{
							if (RequestHandler.ExpectClientResponse)
							{
								_response = WebUtility.CreateClientResponse(ResponseText);
							}
							else
							{
								_response = null;
							}
						}
						catch (Exception)
						{
						}
					}
					try
					{
						RequestHandler.OnComplete(this);
					}
					catch (Exception ex2)
					{
						Debug.LogErrorFormat("{0} threw an exception when processing OnComplete(): {1}", RequestHandler.GetType().ToString(), ex2.Message);
					}
					try
					{
						this.Completed?.Invoke(this);
					}
					catch (Exception ex3)
					{
						Debug.LogErrorFormat("An exception was thrown by a WebsiteRequest.Completed event subscriber: ", ex3.Message);
					}
				}
				else
				{
					try
					{
						_response = null;
						RequestHandler.OnCanceled(this);
					}
					catch (Exception ex4)
					{
						Debug.LogErrorFormat("{0} threw an exception when processing OnCanceled(): {1}", RequestHandler.GetType().ToString(), ex4.Message);
					}
					try
					{
						this.Canceled?.Invoke(this);
					}
					catch (Exception ex5)
					{
						Debug.LogErrorFormat("An exception was thrown by a WebsiteRequest.Canceled event subscriber: ", ex5.Message);
					}
				}
			}
			else
			{
				try
				{
					this.Progressed?.Invoke(this);
				}
				catch (Exception ex6)
				{
					Debug.LogErrorFormat("An exception by a WebsiteRequest.Progressed event subscriber: ", ex6.Message);
				}
			}
			if (flag && !IsDone)
			{
				EndTime = Time.unscaledTime;
				IsDone = true;
			}
			return !flag;
		}
	}
}
