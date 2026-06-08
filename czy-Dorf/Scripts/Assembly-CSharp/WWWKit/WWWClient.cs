using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;

namespace WWWKit
{
	public class WWWClient
	{
		public delegate void FinishedDelegate(UnityWebRequest www);

		public delegate void DisposedDelegate();

		private sealed class _003CRequestCoroutine_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WWWClient _003C_003E4__this;

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
			public _003CRequestCoroutine_003Ed__32(int _003C_003E1__state)
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
				WWWClient wWWClient = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					if (wWWClient.mForm.data.Length != 0)
					{
						foreach (KeyValuePair<string, string> header in wWWClient.mForm.headers)
						{
							wWWClient.mHeaders[Convert.ToString(header.Key)] = Convert.ToString(header.Value);
						}
						DownloadHandlerBuffer downloadHandler = new DownloadHandlerBuffer();
						UploadHandlerRaw uploadHandler = new UploadHandlerRaw(wWWClient.mForm.data);
						wWWClient.mWww = new UnityWebRequest(wWWClient.mUrl, "POST", downloadHandler, uploadHandler);
						wWWClient.mWww.SendWebRequest();
					}
					else
					{
						DownloadHandlerBuffer downloadHandler2 = new DownloadHandlerBuffer();
						wWWClient.mWww = new UnityWebRequest(wWWClient.mUrl, "GET", downloadHandler2, null);
						wWWClient.mWww.SendWebRequest();
					}
					_003C_003E2__current = wWWClient.mMonoBehaviour.StartCoroutine(wWWClient.CheckTimeout());
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					if (wWWClient.mDisposed)
					{
						Debug.Log("mDisposed");
						if (wWWClient.mOnDisposed != null)
						{
							wWWClient.mOnDisposed();
						}
					}
					else if (string.IsNullOrEmpty(wWWClient.mWww.error))
					{
						Debug.Log("complete");
						if (wWWClient.mOnDone != null)
						{
							wWWClient.mOnDone(wWWClient.mWww);
						}
					}
					else
					{
						Debug.Log("fail");
						if (wWWClient.mOnFail != null)
						{
							wWWClient.mOnFail(wWWClient.mWww);
						}
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

		private sealed class _003CCheckTimeout_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WWWClient _003C_003E4__this;

			private float _003CstartTime_003E5__2;

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
			public _003CCheckTimeout_003Ed__33(int _003C_003E1__state)
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
				WWWClient wWWClient = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003CstartTime_003E5__2 = Time.time;
					goto IL_0076;
				case 1:
					_003C_003E1__state = -1;
					goto IL_0076;
				case 2:
					{
						_003C_003E1__state = -1;
						return false;
					}
					IL_0076:
					if (!wWWClient.mDisposed && !wWWClient.mWww.isDone)
					{
						if (!(wWWClient.mTimeout > 0f) || !(Time.time - _003CstartTime_003E5__2 >= wWWClient.mTimeout))
						{
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
						wWWClient.Dispose();
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

		private MonoBehaviour mMonoBehaviour;

		private string mUrl;

		private UnityWebRequest mWww;

		private WWWForm mForm;

		private Dictionary<string, string> mHeaders;

		private float mTimeout;

		private FinishedDelegate mOnDone;

		private FinishedDelegate mOnFail;

		private DisposedDelegate mOnDisposed;

		private bool mDisposed;

		public FinishedDelegate OnDone
		{
			set
			{
				mOnDone = value;
			}
		}

		public WWWClient(MonoBehaviour monoBehaviour, string url)
		{
			mMonoBehaviour = monoBehaviour;
			mUrl = url;
			mHeaders = new Dictionary<string, string>();
			mForm = new WWWForm();
			mTimeout = -1f;
			mDisposed = false;
		}

		public void AddData(string fieldName, string value)
		{
			mForm.AddField(fieldName, value);
		}

		public void AddBinaryData(string fieldName, byte[] contents, string fileName, string mimeType)
		{
			mForm.AddBinaryData(fieldName, contents, fileName, mimeType);
		}

		public void Request()
		{
			mMonoBehaviour.StartCoroutine(RequestCoroutine());
		}

		public void Dispose()
		{
			if (mWww != null && !mDisposed)
			{
				mWww.Dispose();
				mDisposed = true;
			}
		}

		private IEnumerator RequestCoroutine()
		{
			return new _003CRequestCoroutine_003Ed__32(0)
			{
				_003C_003E4__this = this
			};
		}

		private IEnumerator CheckTimeout()
		{
			return new _003CCheckTimeout_003Ed__33(0)
			{
				_003C_003E4__this = this
			};
		}
	}
}
