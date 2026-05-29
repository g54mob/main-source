using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Implemented Action (Desktop Only)", 9)]
	[Category("✫ Reflected/Faster Versions (Desktop Platforms Only)")]
	[Description("This version works in destop/JIT platform only.\n\nCalls a function that has signature of 'public Status NAME()' or 'public Status NAME(T)'. You should return Status.Success, Failure or Running within that function.")]
	public class ImplementedAction : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		protected ReflectedFunctionWrapper functionWrapper;

		private Status actionStatus;

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
