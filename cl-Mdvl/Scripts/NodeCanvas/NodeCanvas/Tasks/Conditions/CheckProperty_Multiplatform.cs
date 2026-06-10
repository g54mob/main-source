using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Name("Check Property", 9)]
	[Category("✫ Reflected")]
	[Description("Check a property on a script and return if it's equal or not to the check value")]
	public class CheckProperty_Multiplatform : ConditionTask, IReflectedWrapper
	{
		[SerializeField]
		protected SerializedMethodInfo method;

		[SerializeField]
		protected BBObjectParameter checkValue;

		[SerializeField]
		protected CompareMethod comparison;

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
					return "No Property Selected";
				}
				if (targetMethod == null)
				{
					return method.AsString().FormatError();
				}
				string arg = (targetMethod.IsStatic ? targetMethod.RTReflectedOrDeclaredType().FriendlyName() : base.agentInfo);
				return $"{arg}.{targetMethod.Name}{OperationTools.GetCompareString(comparison) + checkValue.ToString()}";
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
				return "No Property Selected";
			}
			if (targetMethod == null)
			{
				return method.AsString();
			}
			return null;
		}

		protected override bool OnCheck()
		{
			Component obj = (targetMethod.IsStatic ? null : base.agent);
			if (checkValue.varType == typeof(float))
			{
				return OperationTools.Compare((float)targetMethod.Invoke(obj, null), (float)checkValue.value, comparison, 0.05f);
			}
			if (checkValue.varType == typeof(int))
			{
				return OperationTools.Compare((int)targetMethod.Invoke(obj, null), (int)checkValue.value, comparison);
			}
			return ObjectUtils.AnyEquals(targetMethod.Invoke(obj, null), checkValue.value);
		}

		private void SetMethod(MethodInfo method)
		{
			if (method != null)
			{
				this.method = new SerializedMethodInfo(method);
				checkValue.SetType(method.ReturnType);
				comparison = CompareMethod.EqualTo;
			}
		}
	}
}
