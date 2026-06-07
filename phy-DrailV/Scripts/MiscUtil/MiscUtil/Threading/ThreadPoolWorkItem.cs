using System;
using System.Threading;

namespace MiscUtil.Threading
{
	public class ThreadPoolWorkItem
	{
		private Delegate target;

		private object[] parameters;

		private int priority;

		private bool preserveParameters;

		private object id;

		public Delegate Target => target;

		public object[] Parameters => parameters;

		public int Priority => priority;

		public bool PreserveParameters => preserveParameters;

		public object ID => id;

		public ThreadPoolWorkItem(object id, bool preserveParameters, bool cloneParameters, int priority, Delegate target, params object[] parameters)
		{
			if ((object)target == null)
			{
				throw new ArgumentNullException("target");
			}
			this.id = id;
			this.priority = priority;
			this.preserveParameters = preserveParameters;
			this.target = target;
			if (parameters != null)
			{
				this.parameters = (cloneParameters ? ((object[])parameters.Clone()) : parameters);
			}
		}

		public ThreadPoolWorkItem(Delegate target, params object[] parameters)
			: this(null, preserveParameters: true, cloneParameters: true, 0, target, parameters)
		{
		}

		internal void Invoke()
		{
			object[] args = parameters;
			if (!preserveParameters)
			{
				parameters = null;
			}
			if (target is ThreadStart)
			{
				((ThreadStart)target)();
			}
			else
			{
				target.DynamicInvoke(args);
			}
		}
	}
}
