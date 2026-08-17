using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ServerFeedPrefab : MonoBehaviour
{
	private sealed class _003CShow_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ServerFeedPrefab _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShow_003Ed__9(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0281: Expected I4, but got I8
			//IL_043f: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_026d: Expected I4, but got I8
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0082: Expected I4, but got I8
			//IL_0362: Invalid comparison between I4 and F4
			//IL_006e: Expected I4, but got I8
			//IL_03ad: Expected F4, but got I4
			//IL_0163: Invalid comparison between I4 and F4
			//IL_01ae: Expected F4, but got I4
			ServerFeedPrefab serverFeedPrefab = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_02e5;
				}
				object obj2 = obj - 1;
				if (!flag)
				{
					if ((nint)obj2 != 1)
					{
						goto IL_0468;
					}
					_003C_003E1__state = -1;
				}
				else
				{
					_003C_003E1__state = -1;
					_003Ctimer_003E5__2 = 0f;
					if ((object)_003C_003E4__this == null || (object)serverFeedPrefab.canvasGroup == null)
					{
						goto IL_0431;
					}
					serverFeedPrefab.canvasGroup.alpha = 1f;
				}
				if (1f > _003Ctimer_003E5__2)
				{
					float deltaTime = Time.deltaTime;
					float num = deltaTime + deltaTime;
					float num2 = (_003Ctimer_003E5__2 = num + _003Ctimer_003E5__2);
					if ((object)_003C_003E4__this != null)
					{
						if (!(0f > num2))
						{
							if (num2 > 1f)
							{
								num2 = 1f;
							}
						}
						else
						{
							num2 = 0f;
						}
						if ((object)serverFeedPrefab.canvasGroup != null)
						{
							float num3 = num2 * -1f;
							float alpha = num3 + 1f;
							serverFeedPrefab.canvasGroup.alpha = alpha;
							_003C_003E2__current = null;
							_003C_003E1__state = 3;
							goto IL_04ba;
						}
					}
				}
				else if ((object)_003C_003E4__this != null)
				{
					Action<ServerFeedPrefab> timeoutAction = serverFeedPrefab.timeoutAction;
					if (serverFeedPrefab.timeoutAction != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v238 @ rax_v17 (System.Action`1<ServerFeedPrefab>)+18] (should have been resolved before IL gen)");
					}
					goto IL_0468;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				_003Ctimer_003E5__2 = 0f;
				if ((object)_003C_003E4__this != null && (object)serverFeedPrefab.canvasGroup != null)
				{
					serverFeedPrefab.canvasGroup.alpha = 0f;
					goto IL_02e5;
				}
			}
			goto IL_0431;
			IL_02e5:
			if (1f > _003Ctimer_003E5__2)
			{
				float deltaTime2 = Time.deltaTime;
				float num4 = deltaTime2 + deltaTime2;
				float num5 = (_003Ctimer_003E5__2 = num4 + _003Ctimer_003E5__2);
				if ((object)_003C_003E4__this != null)
				{
					if (!(0f > num5))
					{
						if (num5 > 1f)
						{
							num5 = 1f;
						}
					}
					else
					{
						num5 = 0f;
					}
					if ((object)serverFeedPrefab.canvasGroup != null)
					{
						serverFeedPrefab.canvasGroup.alpha = num5;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						goto IL_04ba;
					}
				}
			}
			else if ((object)_003C_003E4__this != null)
			{
				WaitForSeconds waitForSeconds = new WaitForSeconds(serverFeedPrefab.startFadeTime);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 2;
				goto IL_04ba;
			}
			goto IL_0431;
			IL_0431:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0468:
			return false;
			IL_04ba:
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public CanvasGroup canvasGroup;

	public RawImage i_icon;

	public TextMeshProUGUI t_info;

	private float currentTime;

	private float fadeTime = 0.5f;

	private float startFadeTime = 8.5f;

	private float destroyTime;

	private Action<ServerFeedPrefab> timeoutAction;

	public void SetFeed(string f, float duration, Action<ServerFeedPrefab> timeoutAction, Texture icon = null)
	{
		this.timeoutAction = timeoutAction;
		GameObject gameObject = t_info.gameObject;
		gameObject.SetActive(value: true);
		t_info.text = f;
		UnityEngine.Object obj = default(UnityEngine.Object);
		if (obj != null)
		{
			i_icon.enabled = true;
			i_icon.texture = (Texture)obj;
		}
		else
		{
			i_icon.enabled = false;
		}
		startFadeTime = duration;
		currentTime = 0f;
		_003CShow_003Ed__9 obj2 = new _003CShow_003Ed__9(0);
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
	}

	private IEnumerator Show()
	{
		_003CShow_003Ed__9 obj = new _003CShow_003Ed__9(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
