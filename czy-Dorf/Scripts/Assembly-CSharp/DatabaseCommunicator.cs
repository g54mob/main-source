using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using WWWKit;

public class DatabaseCommunicator : MonoBehaviour
{
	private sealed class _003CSendWebRequestNonAsync_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Dictionary<string, object> stringDataToSend;

		public Dictionary<string, byte[]> binaryDataToSend;

		public string url;

		public Action<string> callback;

		private UnityWebRequest _003Crequest_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSendWebRequestNonAsync_003Ed__5(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			switch (_003C_003E1__state)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				WWWForm wWWForm = new WWWForm();
				if (stringDataToSend != null)
				{
					foreach (KeyValuePair<string, object> item in stringDataToSend)
					{
						wWWForm.AddField(item.Key, item.Value.ToString());
					}
				}
				if (binaryDataToSend != null)
				{
					foreach (KeyValuePair<string, byte[]> item2 in binaryDataToSend)
					{
						wWWForm.AddBinaryData(item2.Key, item2.Value, "blueprint", "application /octet-stream");
					}
				}
				DownloadHandlerBuffer downloadHandler = new DownloadHandlerBuffer();
				if (binaryDataToSend != null || stringDataToSend != null)
				{
					_003Crequest_003E5__2 = UnityWebRequest.Post(url, wWWForm);
				}
				else
				{
					_003Crequest_003E5__2 = new UnityWebRequest(url, "GET", downloadHandler, null);
				}
				_003C_003E2__current = _003Crequest_003E5__2.SendWebRequest();
				_003C_003E1__state = 1;
				return true;
			}
			case 1:
				_003C_003E1__state = -1;
				if (_003Crequest_003E5__2.error == null && callback != null)
				{
					callback(_003Crequest_003E5__2.downloadHandler.text);
				}
				else if (callback != null)
				{
					callback("connection error " + _003Crequest_003E5__2.error);
				}
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public Action<string> callback;

		internal void _003CSendWebRequestAsync_003Eb__0(UnityWebRequest www)
		{
			Debug.Log("Result: " + www.downloadHandler.text);
			if (www.error == null && callback != null)
			{
				callback(www.downloadHandler.text);
			}
			else if (callback != null)
			{
				callback("connection error");
			}
		}
	}

	private sealed class _003CSendWebRequestAsync_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Action<string> callback;

		public string url;

		public DatabaseCommunicator _003C_003E4__this;

		public Dictionary<string, object> stringDataToSend;

		public Dictionary<string, byte[]> binaryDataToSend;

		private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

		private WebAsync _003CwebAsync_003E5__2;

		private IEnumerator _003Ce_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CSendWebRequestAsync_003Ed__6(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			DatabaseCommunicator monoBehaviour = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				_003C_003E8__1 = new _003C_003Ec__DisplayClass6_0();
				_003C_003E8__1.callback = callback;
				_003CwebAsync_003E5__2 = new WebAsync();
				WebRequest webRequest = WebRequest.Create(url);
				webRequest.Method = "HEAD";
				_003Ce_003E5__3 = _003CwebAsync_003E5__2.GetResponse(webRequest);
				goto IL_009c;
			}
			case 1:
				_003C_003E1__state = -1;
				goto IL_009c;
			case 2:
				{
					_003C_003E1__state = -1;
					return false;
				}
				IL_009c:
				if (_003Ce_003E5__3.MoveNext())
				{
					_003C_003E2__current = _003Ce_003E5__3.Current;
					_003C_003E1__state = 1;
					return true;
				}
				if (_003CwebAsync_003E5__2.requestState.errorMessage == null)
				{
					Debug.Log("web connection available");
					new WWWForm();
					WWWClient wWWClient = new WWWClient(monoBehaviour, url);
					if (stringDataToSend != null)
					{
						foreach (KeyValuePair<string, object> item in stringDataToSend)
						{
							wWWClient.AddData(item.Key, item.Value.ToString());
						}
					}
					if (binaryDataToSend != null)
					{
						foreach (KeyValuePair<string, byte[]> item2 in binaryDataToSend)
						{
							wWWClient.AddBinaryData(item2.Key, item2.Value, "blueprint", "application /octet-stream");
						}
					}
					Debug.Log("sending " + stringDataToSend?.ToString() + " & " + binaryDataToSend);
					wWWClient.OnDone = delegate(UnityWebRequest www)
					{
						Debug.Log("Result: " + www.downloadHandler.text);
						if (www.error == null && _003C_003E8__1.callback != null)
						{
							_003C_003E8__1.callback(www.downloadHandler.text);
						}
						else if (_003C_003E8__1.callback != null)
						{
							_003C_003E8__1.callback("connection error");
						}
					};
					wWWClient.Request();
				}
				else
				{
					Debug.Log(_003CwebAsync_003E5__2.requestState.errorMessage);
					_003C_003E8__1.callback("connection error");
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	public static DatabaseCommunicator singleton;

	public bool asyncWebRequests;

	private Dictionary<string, string> urlToPlayerPrefsArray;

	private void Awake()
	{
		if (singleton == null)
		{
			singleton = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public void StartSendingWebRequest(string url, Action<string> onCompleted, Dictionary<string, object> stringDataToSend = null, Dictionary<string, byte[]> binaryDataToSend = null)
	{
		if (!asyncWebRequests)
		{
			StartCoroutine(SendWebRequestNonAsync(url, onCompleted, stringDataToSend, binaryDataToSend));
		}
		else
		{
			StartCoroutine(SendWebRequestAsync(url, onCompleted, stringDataToSend, binaryDataToSend));
		}
	}

	public IEnumerator SendWebRequestNonAsync(string url, Action<string> callback, Dictionary<string, object> stringDataToSend = null, Dictionary<string, byte[]> binaryDataToSend = null)
	{
		return new _003CSendWebRequestNonAsync_003Ed__5(0)
		{
			url = url,
			callback = callback,
			stringDataToSend = stringDataToSend,
			binaryDataToSend = binaryDataToSend
		};
	}

	public IEnumerator SendWebRequestAsync(string url, Action<string> callback, Dictionary<string, object> stringDataToSend = null, Dictionary<string, byte[]> binaryDataToSend = null)
	{
		return new _003CSendWebRequestAsync_003Ed__6(0)
		{
			_003C_003E4__this = this,
			url = url,
			callback = callback,
			stringDataToSend = stringDataToSend,
			binaryDataToSend = binaryDataToSend
		};
	}
}
