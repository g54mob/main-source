using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckProperty : ConditionTask
	{
		[SerializeField]
		protected ReflectedFunctionWrapper functionWrapper;

		[SerializeField]
		protected BBParameter checkValue;

		[SerializeField]
		protected CompareMethod comparison;

		private MethodInfo targetMethod => null;

		public override Type agentType => null;

		protected override string info => null;

		public override void OnValidate(ITaskSystem ownerSystem)
		{
		}

		protected override string OnInit()
		{
			return null;
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void SetMethod(MethodInfo method)
		{
		}
	}
}
