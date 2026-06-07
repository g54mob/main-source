using System;
using System.Collections;
using UnityEngine;

namespace NodeCanvas.Framework
{
	public abstract class ConditionTask<T> : ConditionTask where T : class
	{
		public sealed override Type agentType => null;

		public new T agent => null;
	}
	public abstract class ConditionTask : Task
	{
		[SerializeField]
		private bool _invert;

		private int yieldReturn;

		private int yields;

		private bool isRuntimeEnabled;

		public bool invert
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Enable(Component agent, IBlackboard bb)
		{
		}

		public void Disable()
		{
		}

		[Obsolete]
		public bool CheckCondition(Component agent, IBlackboard blackboard)
		{
			return false;
		}

		public bool Check(Component agent, IBlackboard blackboard)
		{
			return false;
		}

		public bool CheckOnce(Component agent, IBlackboard blackboard)
		{
			return false;
		}

		protected void YieldReturn(bool value)
		{
		}

		private IEnumerator Flip()
		{
			return null;
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual bool OnCheck()
		{
			return false;
		}
	}
}
