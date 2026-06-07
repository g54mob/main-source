using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FSG.MeshAnimator
{
	public class MeshAnimatorManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CUnscaledUpdate_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MeshAnimatorManager _003C_003E4__this;

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
			public _003CUnscaledUpdate_003Ed__13(int _003C_003E1__state)
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

		private static AnimatorUpdateMode _mode;

		private static MeshAnimatorManager _instance;

		private static List<IMeshAnimator> _animators;

		private static List<IMeshAnimator> _addAnimators;

		private static List<IMeshAnimator> _removeAnimators;

		public static int AnimatorCount => 0;

		public static MeshAnimatorManager Instance => null;

		public static void AddAnimator(IMeshAnimator animator)
		{
		}

		public static void RemoveAnimator(IMeshAnimator animator)
		{
		}

		public static void SetUpdateMode(AnimatorUpdateMode updateMode)
		{
		}

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CUnscaledUpdate_003Ed__13))]
		private IEnumerator UnscaledUpdate()
		{
			return null;
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void UpdateTick(float time)
		{
		}
	}
}
