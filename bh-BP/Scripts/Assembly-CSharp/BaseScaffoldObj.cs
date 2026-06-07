using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

public class BaseScaffoldObj : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AnimateEntry_003Ed__10 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseScaffoldObj _003C_003E4__this;

		public int idx;

		private int _003Ci_003E5__2;

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
		public _003C_AnimateEntry_003Ed__10(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_AnimateExit_003Ed__12 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseScaffoldObj _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003C_AnimateExit_003Ed__12(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_AnimateExit_003Ed__13 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseScaffoldObj _003C_003E4__this;

		public int idx;

		private int _003Ci_003E5__2;

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
		public _003C_AnimateExit_003Ed__13(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_RunHitFlash_003Ed__16 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseScaffoldObj _003C_003E4__this;

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
		public _003C_RunHitFlash_003Ed__16(int _003C_003E1__state)
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

	public BuildingType Type;

	public GameObject[] Layers;

	[OdinSerialize]
	public BaseScaffoldPiece[][] Pieces;

	private int _curProgressIdx;

	private BuildingObj _tgtBld;

	private CoroutineHandle _hitFlashAnim;

	public void Init(BuildingObj b)
	{
	}

	public void UpdateProgress(float progress)
	{
	}

	public void SetProgressIdx(int idx)
	{
	}

	public void AnimateEntry(int idx)
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateEntry_003Ed__10))]
	private IEnumerator<float> _AnimateEntry(int idx)
	{
		return null;
	}

	public void AnimateExit()
	{
	}

	[IteratorStateMachine(typeof(_003C_AnimateExit_003Ed__12))]
	private IEnumerator<float> _AnimateExit()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_AnimateExit_003Ed__13))]
	private IEnumerator<float> _AnimateExit(int idx)
	{
		return null;
	}

	public void OnValidate()
	{
	}

	public void RunHitFlash()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunHitFlash_003Ed__16))]
	private IEnumerator<float> _RunHitFlash()
	{
		return null;
	}

	public BuildingObj GetTgtBld()
	{
		return null;
	}
}
