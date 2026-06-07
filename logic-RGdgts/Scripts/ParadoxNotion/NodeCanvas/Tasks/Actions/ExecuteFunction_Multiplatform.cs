using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class ExecuteFunction_Multiplatform : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		protected SerializedMethodInfo method;

		[SerializeField]
		protected List<BBObjectParameter> parameters;

		[SerializeField]
		[BlackboardOnly]
		protected BBObjectParameter returnValue;

		private object[] args;

		private bool routineRunning;

		private bool[] parameterIsByRef;

		private MethodInfo targetMethod => null;

		public override Type agentType => null;

		protected override string info => null;

		ISerializedReflectedInfo IReflectedWrapper.GetSerializedInfo()
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

		protected override void OnStop()
		{
		}

		private IEnumerator InternalCoroutine(IEnumerator routine)
		{
			return null;
		}

		private void SetMethod(MethodInfo method)
		{
		}
	}
}
