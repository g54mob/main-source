using System;
using System.Collections.Generic;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class ImplementedAction_Multiplatform : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private List<BBObjectParameter> parameters;

		private Status actionStatus;

		private object[] args;

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

		protected override void OnUpdate()
		{
		}

		protected override void OnStop()
		{
		}

		private void SetMethod(MethodInfo method)
		{
		}
	}
}
