using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UMA;
using UMA.CharacterSystem;
using UMA.PoseTools;
using UnityEngine;

public class AICharacterExpressions : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTalking_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<string> _syllables;

		public AICharacterExpressions _003C_003E4__this;

		private List<string>.Enumerator _003C_003E7__wrap1;

		private string _003C_s_003E5__3;

		private float _003Ct_003E5__4;

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
		public _003CTalking_003Ed__7(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private DynamicCharacterAvatar avatar;

	private UMAExpressionPlayer expressionPlayer;

	private float pauseBetweenFaceShape;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnCreated(UMAData umadata)
	{
	}

	public void Talk(string sentence)
	{
	}

	[IteratorStateMachine(typeof(_003CTalking_003Ed__7))]
	private IEnumerator Talking(List<string> _syllables)
	{
		return null;
	}

	private void MouthShape_none(float t)
	{
	}

	private void MouthShape_A(float t)
	{
	}

	private void MouthShape_O(float t)
	{
	}

	private void MouthShape_U(float t)
	{
	}

	private void MouthShape_BPM(float t)
	{
	}

	private void MouthShape_FV(float t)
	{
	}

	private void MouthShape_CDG(float t)
	{
	}
}
