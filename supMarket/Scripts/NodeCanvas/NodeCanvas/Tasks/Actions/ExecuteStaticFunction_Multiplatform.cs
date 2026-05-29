using System;
using System.Collections.Generic;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Obsolete("Execute Function now supports static functions as well")]
	public class ExecuteStaticFunction_Multiplatform : ActionTask
	{
		[SerializeField]
		protected SerializedMethodInfo method;

		[SerializeField]
		protected List<BBObjectParameter> parameters;

		[SerializeField]
		[BlackboardOnly]
		protected BBObjectParameter returnValue;

		private MethodInfo targetMethod => null;

		protected override string info => null;

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
