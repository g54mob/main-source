using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class PrefabReassembler : MonoBehaviour
{
	private sealed class _003CSpawnRoutine_003Ed__3(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public PrefabReassembler _003C_003E4__this;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0208: Expected I4, but got I8
			//IL_0235: Expected I4, but got O
			//IL_0067: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_0108: Expected O, but got I
			//IL_0156: Expected O, but got I
			Component component = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003Ci_003E5__2 = _003C_003E1__state;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_01c7;
				}
				int num = _003Ci_003E5__2 + 1;
				_003Ci_003E5__2 = num;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (UnityEngine.Component)+20]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (UnityEngine.Component)+20]");
				if ((nint)0 != 0)
				{
					int num2 = _003Ci_003E5__2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v5+18]");
					if ((nint)num2 >= (nint)0)
					{
						goto IL_01c7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (UnityEngine.Component)+20]");
					object obj2 = 0;
					int num3 = _003Ci_003E5__2;
					int num4 = _003Ci_003E5__2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v2+18]");
					if ((nint)num4 < (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v2+10]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v2+10]");
						if ((nint)0 != 0)
						{
							Transform transform = _003C_003E4__this.transform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rdx_v4+20+v142 @ rax_v7 (System.Int32)*8]");
							GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)0, transform);
							if ((object)gameObject != null)
							{
								Transform transform2 = gameObject.transform;
								if ((object)transform2 != null)
								{
									transform2.SetAsLastSibling();
									_003C_003E2__current = null;
									_003C_003E1__state = 1;
									return true;
								}
							}
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_01c7:
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

	private List<GameObject> _PrefabComponents;

	private void Start()
	{
		_003CSpawnRoutine_003Ed__3 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void Update()
	{
	}

	private IEnumerator SpawnRoutine()
	{
		_003CSpawnRoutine_003Ed__3 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public PrefabReassembler()
	{
		List<GameObject> prefabComponents = new List<GameObject>();
		_PrefabComponents = prefabComponents;
	}
}
