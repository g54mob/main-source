using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckField : ConditionTask, IReflectedWrapper, IMigratable<CheckField_0>, IMigratable
	{
		[SerializeField]
		protected BBObjectParameter checkValue;

		[SerializeField]
		protected CompareMethod comparison;

		[SerializeField]
		protected SerializedFieldInfo field;

		private FieldInfo targetField => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckField_0>.Migrate(CheckField_0 model)
		{
		}

		ISerializedReflectedInfo IReflectedWrapper.GetSerializedInfo()
		{
			return null;
		}

		protected override string OnInit()
		{
			return null;
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void SetTargetField(FieldInfo newField)
		{
		}
	}
}
