using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.UI.Core;
using Febucci.UI.Core.Parsing;
using UnityEngine;

namespace Febucci.UI.Examples
{
	[AddComponentMenu(null)]
	[DisallowMultipleComponent]
	internal class ExampleEvents : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateCrate_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ExampleEvents _003C_003E4__this;

			public int crateIndex;

			private Transform _003Ccrate_003E5__2;

			private Vector3 _003CinitialScale_003E5__3;

			private Vector3 _003CtargetScale_003E5__4;

			private float _003Ct_003E5__5;

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
			public _003CAnimateCrate_003Ed__20(int _003C_003E1__state)
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
		private TypewriterCore typewriter;

		[TextArea(1, 5)]
		[SerializeField]
		private string[] dialoguesLines;

		[SerializeField]
		private Sprite[] faces;

		[SerializeField]
		private SpriteRenderer faceRenderer;

		[SerializeField]
		private GameObject continueText;

		[SerializeField]
		private Transform[] crates;

		private Vector3[] cratesInitialScale;

		private int dialogueIndex;

		private int dialogueLength;

		private bool currentLineShown;

		private bool CurrentLineShown
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private bool TryGetInt(string parameter, out int result)
		{
			result = default(int);
			return false;
		}

		private void OnMessage(EventMarker eventData)
		{
		}

		private void Awake()
		{
		}

		private void ContinueSequence()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateCrate_003Ed__20))]
		private IEnumerator AnimateCrate(int crateIndex)
		{
			return null;
		}
	}
}
