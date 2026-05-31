using System;
using System.Reflection;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Reflected/Events")]
	[Description("Will subscribe to a public event of Action<T> type and return true when the event is raised and it's value is equal to provided value as well.\n(eg public event System.Action<T> [name])")]
	[fsMigrateVersions(new Type[] { typeof(CheckCSharpEventValue_0<>) })]
	public class CheckCSharpEventValue<T> : ConditionTask, IReflectedWrapper, IMigratable<CheckCSharpEventValue_0<T>>, IMigratable
	{
		[SerializeField]
		private SerializedEventInfo eventInfo;

		[SerializeField]
		private BBParameter<T> checkValue;

		private Delegate handler;

		private EventInfo targetEvent => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckCSharpEventValue_0<T>>.Migrate(CheckCSharpEventValue_0<T> model)
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

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public void Raised(T eventValue)
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}

		private void SetTargetEvent(EventInfo info)
		{
		}
	}
}
