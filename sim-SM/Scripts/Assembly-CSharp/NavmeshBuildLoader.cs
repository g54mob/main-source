using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.AI.Navigation;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class NavmeshBuildLoader : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NavmeshBuildLoader _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
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
		public _003CStart_003Ed__4(int _003C_003E1__state)
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

	[SerializeField]
	private NavMeshSurface m_NavmeshSurface;

	[SerializeField]
	private Bounds m_StoreBounds;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__4))]
	private IEnumerator Start()
	{
		return null;
	}
}
