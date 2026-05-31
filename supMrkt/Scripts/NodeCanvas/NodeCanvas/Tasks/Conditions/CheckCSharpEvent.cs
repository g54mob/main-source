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
	[Description("Will subscribe to a public event of Action type and return true when the event is raised.\n(eg public event System.Action [name])")]
	[fsMigrateVersions(new Type[] { typeof(CheckCSharpEvent_0) })]
	public class CheckCSharpEvent : ConditionTask, IReflectedWrapper, IMigratable<CheckCSharpEvent_0>, IMigratable, IMigratable<CheckStaticCSharpEvent>
	{
		[SerializeField]
		private SerializedEventInfo eventInfo;

		private Delegate handler;

		private EventInfo targetEvent => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckCSharpEvent_0>.Migrate(CheckCSharpEvent_0 model)
		{
		}

		void IMigratable<CheckStaticCSharpEvent>.Migrate(CheckStaticCSharpEvent model)
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

		public void Raised()
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
	[Category("✫ Reflected/Events")]
	[Description("Will subscribe to a public event of Action<T> type and return true when the event is raised.\n(eg public event System.Action<T> [name])")]
	[fsMigrateVersions(new Type[] { typeof(CheckCSharpEvent_0<>) })]
	public class CheckCSharpEvent<T> : ConditionTask, IReflectedWrapper, IMigratable<CheckCSharpEvent_0<T>>, IMigratable, IMigratable<CheckStaticCSharpEvent<T>>
	{
		[SerializeField]
		private SerializedEventInfo eventInfo;

		[SerializeField]
		[BlackboardOnly]
		private BBParameter<T> saveAs;

		private Delegate handler;

		private EventInfo targetEvent => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckCSharpEvent_0<T>>.Migrate(CheckCSharpEvent_0<T> model)
		{
		}

		void IMigratable<CheckStaticCSharpEvent<T>>.Migrate(CheckStaticCSharpEvent<T> model)
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
