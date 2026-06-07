using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SetProperty_Multiplatform : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		protected SerializedMethodInfo method;

		[SerializeField]
		protected BBObjectParameter parameter;

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

		private void SetMethod(MethodInfo method)
		{
		}
	}
}
