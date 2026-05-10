using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Property (Desktop Only)", 7)]
	[Category("✫ Reflected/Faster Versions (Desktop Platforms Only)")]
	[Description("This version works in destop/JIT platform only.\n\nSet a property on a script.")]
	public class SetProperty : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		protected ReflectedActionWrapper functionWrapper;

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
