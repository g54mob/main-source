using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TinyGiantStudio.Text.Example
{
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Extra/Typewriter", 20101)]
	public class Typewriter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFirstStart_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Typewriter _003C_003E4__this;

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
			public _003CFirstStart_003Ed__15(int _003C_003E1__state)
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
		private sealed class _003CTypingRoutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Typewriter _003C_003E4__this;

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
			public _003CTypingRoutine_003Ed__16(int _003C_003E1__state)
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

		[TextArea]
		public string text;

		[Space(20f)]
		public Modular3DText modular3DText;

		[SerializeField]
		private bool startAutomatically;

		[SerializeField]
		private float startDelay;

		[Tooltip("Minimum and maximum possible speed.")]
		public Vector2 typeDelay;

		[SerializeField]
		private string typingSymbol;

		[Space(10f)]
		[SerializeField]
		private AudioClip typeSound;

		[Tooltip("Minimum and maximum possible volume. \nA variation of values makes it look natural.")]
		[SerializeField]
		private Vector2 volume;

		[SerializeField]
		private AudioSource audioSource;

		private bool typing;

		private int currentLetter;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		public void StartTyping()
		{
		}

		[IteratorStateMachine(typeof(_003CFirstStart_003Ed__15))]
		private IEnumerator FirstStart()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTypingRoutine_003Ed__16))]
		private IEnumerator TypingRoutine()
		{
			return null;
		}
	}
}
