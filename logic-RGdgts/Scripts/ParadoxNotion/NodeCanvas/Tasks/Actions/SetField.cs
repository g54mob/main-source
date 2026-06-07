using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SetField : ActionTask, IReflectedWrapper, IMigratable<SetField_0>, IMigratable
	{
		[SerializeField]
		protected SerializedFieldInfo field;

		[SerializeField]
		protected BBObjectParameter setValue;

		private FieldInfo targetField => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<SetField_0>.Migrate(SetField_0 model)
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

		protected override void OnExecute()
		{
		}

		private void SetTargetField(FieldInfo newField)
		{
		}
	}
}
