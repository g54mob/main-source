using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Obsolete("Execute Function now supports static functions as well")]
	public class ExecuteStaticFunction : ActionTask, ISubParametersContainer
	{
		[SerializeField]
		protected ReflectedWrapper functionWrapper;

		private MethodInfo targetMethod => null;

		protected override string info => null;

		BBParameter[] ISubParametersContainer.GetSubParameters()
		{
			return null;
		}

		public override void OnValidate(ITaskSystem ownerSystem)
		{
		}

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
		}

		private void SetMethod(MethodInfo method)
		{
		}
	}
}
