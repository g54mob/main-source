using System;
using System.Collections.Generic;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Implemented Action", 9)]
	[Category("✫ Reflected")]
	[Description("Calls a function that has signature of 'public Status NAME()' or 'public Status NAME(T)'. You should return Status.Success, Failure or Running within that function.")]
	public class ImplementedAction_Multiplatform : ActionTask, IReflectedWrapper
	{
		[SerializeField]
		private SerializedMethodInfo method;

		[SerializeField]
		private List<BBObjectParameter> parameters = new List<BBObjectParameter>();

		private Status actionStatus = Status.Resting;

		private object[] args;

		private MethodInfo targetMethod => method;

		public override Type agentType
		{
			get
			{
				if (targetMethod == null)
				{
					return typeof(Transform);
				}
				if (!targetMethod.IsStatic)
				{
					return targetMethod.RTReflectedOrDeclaredType();
				}
				return null;
			}
		}

		protected override string info
		{
			get
			{
				if (method == null)
				{
					return "No Action Selected";
				}
				if (targetMethod == null)
				{
					return method.AsString().FormatError();
				}
				string arg = (targetMethod.IsStatic ? targetMethod.RTReflectedOrDeclaredType().FriendlyName() : base.agentInfo);
				return string.Format("[ {0}.{1}({2}) ]", arg, targetMethod.Name, (parameters.Count == 1) ? parameters[0].ToString() : "");
			}
		}

		ISerializedReflectedInfo IReflectedWrapper.GetSerializedInfo()
		{
			return method;
		}

		public override void OnValidate(ITaskSystem ownerSystem)
		{
			if (method != null && method.HasChanged())
			{
				SetMethod(method);
			}
		}

		protected override string OnInit()
		{
			if (method == null)
			{
				return "No method selected";
			}
			if (targetMethod == null)
			{
				return $"Missing method '{method.AsString()}'";
			}
			if (args == null)
			{
				args = new object[targetMethod.GetParameters().Length];
			}
			return null;
		}

		protected override void OnUpdate()
		{
			for (int i = 0; i < parameters.Count; i++)
			{
				args[i] = parameters[i].value;
			}
			actionStatus = (Status)targetMethod.Invoke(targetMethod.IsStatic ? null : base.agent, args);
			if (actionStatus == Status.Success)
			{
				EndAction(success: true);
			}
			else if (actionStatus == Status.Failure)
			{
				EndAction(success: false);
			}
		}

		protected override void OnStop()
		{
			actionStatus = Status.Resting;
		}

		private void SetMethod(MethodInfo method)
		{
			if (method != null)
			{
				this.method = new SerializedMethodInfo(method);
				parameters.Clear();
				ParameterInfo[] array = method.GetParameters();
				for (int i = 0; i < array.Length; i++)
				{
					BBObjectParameter item = new BBObjectParameter(array[i].ParameterType)
					{
						bb = base.blackboard
					};
					parameters.Add(item);
				}
			}
		}
	}
}
