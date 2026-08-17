using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class UICamera : MonoBehaviour
{
	private sealed class _003CWaitAndCacheDefaultOrtoSize_003Ed__7(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public UICamera _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_00d1: Expected I4, but got O
			UICamera uICamera = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null || (object)uICamera._main == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				float orthographicSize = uICamera._main.orthographicSize;
				_defaultSize = orthographicSize;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private Camera _camera;

	private Camera _main;

	public static Camera _cameraUI;

	private static float _defaultSize;

	public static float ParticleScaleFactor
	{
		get
		{
			//IL_0053: Expected O, but got F4
			object cameraUI = _cameraUI;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rbx_v1 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rbx_v1 (System.Object)+10]");
			object obj = Camera.get_orthographicSize_Injected((IntPtr)0);
			float num = default(float);
			return num / _defaultSize;
		}
	}

	private void Start()
	{
		Camera component = GetComponent<Camera>();
		_camera = component;
		_cameraUI = _camera;
		Camera main = Camera.main;
		_main = main;
		_003CWaitAndCacheDefaultOrtoSize_003Ed__7 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAndCacheDefaultOrtoSize()
	{
		_003CWaitAndCacheDefaultOrtoSize_003Ed__7 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void Update()
	{
		//IL_0059: Expected O, but got F4
		Camera main = _main;
		bool flag = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
		object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
		float orthographicSize = default(float);
		_camera.orthographicSize = orthographicSize;
	}

	public unsafe static Vector3 UIToGame(Vector3 worldPos)
	{
		//IL_0130: Expected O, but got F4
		//IL_019a: Expected O, but got F4
		//IL_0217: Expected native int or pointer, but got O
		//IL_0224: Expected native int or pointer, but got O
		//IL_00fb->IL0082: Incompatible stack heights: 1 vs 0
		//IL_0165->IL0082: Incompatible stack heights: 2 vs 0
		//IL_01da->IL0082: Incompatible stack heights: 3 vs 0
		//IL_0073->IL0082: Incompatible stack heights: 3 vs 0
		if ((object)_cameraUI != null)
		{
			Transform transform = _cameraUI.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform cameraUI = (Transform)(object)_cameraUI;
				if ((object)_cameraUI != null)
				{
					bool flag2 = ((UnityEngine.Object)cameraUI).m_CachedPtr == (IntPtr)0;
					object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)cameraUI).m_CachedPtr);
					object obj2 = default(object);
					float num = worldPos.z / (float)obj2;
					Camera main = Camera.main;
					if ((object)main != null)
					{
						bool flag3 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
						object obj3 = Camera.get_orthographicSize_Injected(((UnityEngine.Object)main).m_CachedPtr);
						float num2 = num * (float)obj2;
						float z = num2 / 1.6f;
						Camera main2 = Camera.main;
						if ((object)main2 != null)
						{
							Transform transform2 = main2.transform;
							if ((object)transform2 != null)
							{
								bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out ret);
								Vector3 vector = default(Vector3);
								float x = default(float);
								((Vector3*)(nint)vector)->x = x;
								((Vector3*)(nint)vector)->z = z;
								return vector;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public UICamera()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
