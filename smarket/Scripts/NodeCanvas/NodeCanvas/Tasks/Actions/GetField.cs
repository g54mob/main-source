using System;
using System.Reflection;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Reflected")]
	[Description("Get a variable of a script and save it to the blackboard")]
	[Name("Get Field", 6)]
	[fsMigrateVersions(new Type[] { typeof(GetField_0) })]
	public class GetField : ActionTask, IReflectedWrapper, IMigratable<GetField_0>, IMigratable
	{
		[SerializeField]
		protected SerializedFieldInfo field;

		[SerializeField]
		[BlackboardOnly]
		protected BBObjectParameter saveAs;

		private FieldInfo targetField => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<GetField_0>.Migrate(GetField_0 model)
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
