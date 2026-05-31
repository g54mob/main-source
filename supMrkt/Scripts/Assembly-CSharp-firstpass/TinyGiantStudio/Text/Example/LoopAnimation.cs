using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TinyGiantStudio.Text.Example
{
	[RequireComponent(typeof(Modular3DText))]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Extra/Loop Animation", 20102)]
	public class LoopAnimation : MonoBehaviour
	{
		private enum TargetType
		{
			letters = 0,
			words = 1
		}

		[CompilerGenerated]
		private sealed class _003CLetterAnimationRoutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoopAnimation _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CLetterAnimationRoutine_003Ed__10(int _003C_003E1__state)
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
		private sealed class _003CWordAnimationRoutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LoopAnimation _003C_003E4__this;

			private int _003Ci_003E5__2;

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
			public _003CWordAnimationRoutine_003Ed__11(int _003C_003E1__state)
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
		private Vector2 duration;

		[SerializeField]
		private TargetType targetType;

		[Space]
		[SerializeField]
		private Material focusedMaterial;

		public List<GameObject> targetLetterList;

		public List<List<GameObject>> targetWordsList;

		private Modular3DText Modular3DText => null;

		private void OnEnable()
		{
		}

		public void UpdateTargetList()
		{
		}

		[IteratorStateMachine(typeof(_003CLetterAnimationRoutine_003Ed__10))]
		private IEnumerator LetterAnimationRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWordAnimationRoutine_003Ed__11))]
		private IEnumerator WordAnimationRoutine()
		{
			return null;
		}

		private void Focus(GameObject target)
		{
		}

		private void UnFocus(GameObject target)
		{
		}
	}
}
