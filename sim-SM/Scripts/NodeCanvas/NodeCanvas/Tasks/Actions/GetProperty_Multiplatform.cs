using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Get Property", 8)]
	[Category("✫ Reflected")]
	[Description("Get a property of a script and save it to the blackboard")]
	public class GetProperty_Multiplatform : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		protected SerializedMethodInfo method;

		[SerializeField]
		[BlackboardOnly]
		protected BBObjectParameter returnValue;

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
