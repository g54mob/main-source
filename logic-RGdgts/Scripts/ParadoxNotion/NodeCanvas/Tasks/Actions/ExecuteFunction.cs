using System;
using System.Collections;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class ExecuteFunction : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		protected ReflectedWrapper functionWrapper;

		private bool routineRunning;

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
