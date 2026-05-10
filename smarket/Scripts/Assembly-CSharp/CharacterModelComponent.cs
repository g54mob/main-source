using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterModelComponent : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnableAnimator_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Animator animator;

		public CharacterModelComponent _003C_003E4__this;

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
		public _003CEnableAnimator_003Ed__13(int _003C_003E1__state)
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

	private GameObject m_ModelInstance;

	private CharacterModelDefinition m_ModelDefinition;

	[SerializeField]
	private Transform m_Parent;

	private Dictionary<string, CharacterModelObjectReference> m_References;

	public CharacterModelDefinition ModelDefinition
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public event Action ModelChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void SpawnModel()
	{
	}

	private void LoadReferences()
	{
	}

	public bool TryGetReference(string name, out CharacterModelObjectReference reference)
	{
		reference = null;
		return false;
	}

	[IteratorStateMachine(typeof(_003CEnableAnimator_003Ed__13))]
	private IEnumerator EnableAnimator(Animator animator)
	{
		return null;
	}
}
