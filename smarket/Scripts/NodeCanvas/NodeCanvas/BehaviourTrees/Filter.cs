using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Filter", 0)]
	[Category("Decorators")]
	[Description("Filters the access of its child either a specific number of times, or every specific amount of time.")]
	[Icon("Filter", false, null)]
	public class Filter : BTDecorator
	{
		public enum FilterMode
		{
			LimitNumberOfTimes = 0,
			CoolDown = 1
		}

		public enum Policy
		{
			SuccessOrFailure = 0,
			SuccessOnly = 1,
			FailureOnly = 2
		}

		[CompilerGenerated]
		private sealed class _003CCooldown_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Filter _003C_003E4__this;

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
			public _003CCooldown_003Ed__11(int _003C_003E1__state)
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

		[Tooltip("The mode to use.")]
		public FilterMode filterMode;

		[ShowIf("filterMode", 0)]
		[Name("Max Times", 0)]
		[Tooltip("The max ammount of times to allow the child to execute until the tree is completely restarted.")]
		public BBParameter<int> maxCount;

		[ShowIf("filterMode", 0)]
		[Name("Increase Count When", 0)]
		[Tooltip("Only increase count if the selected status is returned from the child.")]
		public Policy policy;

		[ShowIf("filterMode", 1)]
		[Tooltip("The time to disallow execution for.")]
		public BBParameter<float> coolDownTime;

		[Name("Optional When Filtered", 0)]
		[Tooltip("If enabled, the Filter Decorator will return an Optional status when it is filtered. Otherwise it will return Failure.")]
		public bool inactiveWhenLimited;

		private int executedCount;

		private float currentTime;

		public override void OnGraphStoped()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		[IteratorStateMachine(typeof(_003CCooldown_003Ed__11))]
		private IEnumerator Cooldown()
		{
			return null;
		}
	}
}
