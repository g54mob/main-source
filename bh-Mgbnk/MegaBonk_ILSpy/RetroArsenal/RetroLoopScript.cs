using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace RetroArsenal;

public class RetroLoopScript : MonoBehaviour
{
	private sealed class _003CEffectLoop_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RetroLoopScript _003C_003E4__this;

		private GameObject _003CeffectPlayer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CEffectLoop_003Ed__7(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_035b: Expected I4, but got I8
			//IL_03d9: Expected I4, but got O
			//IL_00c9: Expected O, but got Ref
			//IL_00c9: Expected O, but got Ref
			//IL_00c9: Expected O, but got I
			//IL_0134: Expected O, but got Ref
			//IL_02fd: Expected F4, but got I
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					Transform transform = _003C_003E4__this.transform;
					if ((object)transform != null)
					{
						Vector3 position = transform.position;
						Transform transform2 = _003C_003E4__this.transform;
						if ((object)transform2 != null)
						{
							Quaternion rotation = transform2.rotation;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+20]");
							float num = default(float);
							object obj = default(object);
							GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)0, (Vector3)(&num), (Quaternion)(&obj));
							_003CeffectPlayer_003E5__2 = gameObject;
							if ((object)_003CeffectPlayer_003E5__2 != null)
							{
								Transform transform3 = _003CeffectPlayer_003E5__2.transform;
								if ((object)transform3 != null)
								{
									transform3.localScale = (Vector3)(&num);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+2C]");
									if ((nint)0 == 0)
									{
										goto IL_0210;
									}
									if ((object)_003CeffectPlayer_003E5__2 != null)
									{
										Light component2 = _003CeffectPlayer_003E5__2.GetComponent<Light>();
										if (!component2)
										{
											goto IL_0210;
										}
										if ((object)_003CeffectPlayer_003E5__2 != null)
										{
											Light component3 = _003CeffectPlayer_003E5__2.GetComponent<Light>();
											if ((object)component3 != null)
											{
												component3.enabled = false;
												goto IL_0210;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_03cb;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				UnityEngine.Object.Destroy(_003CeffectPlayer_003E5__2);
				if ((object)_003C_003E4__this == null)
				{
					goto IL_03cb;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BC3]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				Coroutine coroutine = _003C_003E4__this.StartCoroutine("EffectLoop");
			}
			return false;
			IL_02ec:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+28]");
			WaitForSeconds waitForSeconds = new WaitForSeconds(0f);
			_003C_003E2__current = waitForSeconds;
			_003C_003E1__state = 1;
			return true;
			IL_0210:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (UnityEngine.Component)+2D]");
			if ((nint)0 == 0)
			{
				goto IL_02ec;
			}
			if ((object)_003CeffectPlayer_003E5__2 != null)
			{
				AudioSource component4 = _003CeffectPlayer_003E5__2.GetComponent<AudioSource>();
				if (!component4)
				{
					goto IL_02ec;
				}
				if ((object)_003CeffectPlayer_003E5__2 != null)
				{
					AudioSource component5 = _003CeffectPlayer_003E5__2.GetComponent<AudioSource>();
					if ((object)component5 != null)
					{
						component5.enabled = false;
						goto IL_02ec;
					}
				}
			}
			goto IL_03cb;
			IL_03cb:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
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

	public GameObject chosenEffect;

	public float loopTimeLimit = 2f;

	public bool disableLights = true;

	public bool disableSound;

	public float spawnScale = 1f;

	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BC3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Coroutine coroutine = StartCoroutine("EffectLoop");
	}

	public void PlayEffect()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172BC3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Coroutine coroutine = StartCoroutine("EffectLoop");
	}

	private IEnumerator EffectLoop()
	{
		_003CEffectLoop_003Ed__7 obj = new _003CEffectLoop_003Ed__7(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
