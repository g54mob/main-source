using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class ObjectPool<T> where T : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_CreateForShaderPrecompiling_003Ed__17 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public ObjectPool<T> _003C_003E4__this;

		public Vector3 pos;

		public Transform parentOnDisable;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003C_CreateForShaderPrecompiling_003Ed__17(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public T Prefab;

	[NonSerialized]
	public List<T> ActiveObjs;

	[NonSerialized]
	public List<T> Pool;

	public DelegateUtl.NoArgsEvent OnObjDisabled;

	public T this[int i]
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int Count => 0;

	public ObjectPool(T prefab)
	{
	}

	public T Get(Transform parent = null)
	{
		return null;
	}

	public void DisableAt(int index)
	{
	}

	public void DisableObj(T activeObj)
	{
	}

	public void DisableAll()
	{
	}

	public void DisableAllAndSetParent(Transform tgtParent)
	{
	}

	public void DisableChildren(Transform xfm)
	{
	}

	public void DetachFromPool(T obj)
	{
	}

	[IteratorStateMachine(typeof(ObjectPool<>._003C_CreateForShaderPrecompiling_003Ed__17))]
	public IEnumerator<float> _CreateForShaderPrecompiling(Vector3 pos, Transform parentOnDisable)
	{
		return null;
	}
}
