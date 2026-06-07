using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ScheduleOne.Effects
{
	public abstract class EffectHandler : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoDelayDeactivate_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public EffectHandler _003C_003E4__this;

			public Action onComplete;

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
			public _003CDoDelayDeactivate_003Ed__24(int _003C_003E1__state)
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

		[Header("Settings")]
		[SerializeField]
		private string _id;

		[SerializeField]
		private bool _scaleToParent;

		[SerializeField]
		private bool _positionToParent;

		[SerializeField]
		private bool _activeByDefault;

		private Coroutine _delayDeactivateCoroutine;

		public virtual string Id => null;

		public virtual bool ScaleToParent => false;

		public virtual bool PositionToParent => false;

		public abstract void Activate();

		public abstract void Deactivate();

		public abstract void SetNumericParameter(string effectName, string variable, float value);

		public abstract void SetNumericParameterForAll(string variable, float value);

		public abstract void SetVectorParameter(string effectName, string variable, Vector3 value);

		public abstract void SetVectorParameter(string effectName, string variable, Vector2 value);

		public abstract void SetVectorParameterForAll(string variable, Vector3 value);

		public abstract void SetVectorParameterForAll(string variable, Vector2 value);

		public abstract void SetColorParameterForAll(string variable, Color value);

		public virtual void Initialise()
		{
		}

		public void SetPosition(Vector3 position)
		{
		}

		public void SetSize(Vector3 size)
		{
		}

		public void DelayDeactivate(float duration, Action onComplete = null)
		{
		}

		[IteratorStateMachine(typeof(_003CDoDelayDeactivate_003Ed__24))]
		private IEnumerator DoDelayDeactivate(float duration, Action onComplete = null)
		{
			return null;
		}

		protected string AddPrefixToVariableName(string variable)
		{
			return null;
		}
	}
}
