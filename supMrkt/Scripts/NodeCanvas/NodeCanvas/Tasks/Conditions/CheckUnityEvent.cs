using System;
using System.Reflection;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Reflected/Events")]
	[Description("Will subscribe to a public UnityEvent and return true when that event is raised.")]
	[fsMigrateVersions(new Type[] { typeof(CheckUnityEvent_0) })]
	public class CheckUnityEvent : ConditionTask, IReflectedWrapper, IMigratable<CheckUnityEvent_0>, IMigratable
	{
		[SerializeField]
		private SerializedUnityEventInfo _eventInfo;

		private UnityEvent unityEvent;

		private MemberInfo targetMember => null;

		private bool isStatic => false;

		private Type eventType => null;

		private FieldInfo targetEventField => null;

		private PropertyInfo targetEventProp => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckUnityEvent_0>.Migrate(CheckUnityEvent_0 model)
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

		private void SetTargetEvent(MemberInfo newMember)
		{
		}
	}
	[Category("✫ Reflected/Events")]
	[Description("Will subscribe to a public UnityEvent<T> and return true when that event is raised.")]
	[fsMigrateVersions(new Type[] { typeof(CheckUnityEvent_0<>) })]
	public class CheckUnityEvent<T> : ConditionTask, IReflectedWrapper, IMigratable<CheckUnityEvent_0<T>>, IMigratable
	{
		[SerializeField]
		private SerializedUnityEventInfo _eventInfo;

		[SerializeField]
		[BlackboardOnly]
		private BBParameter<T> saveAs;

		private UnityEvent<T> unityEvent;

		private MemberInfo targetMember => null;

		private bool isStatic => false;

		private Type eventType => null;

		private FieldInfo targetEventField => null;

		private PropertyInfo targetEventProp => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckUnityEvent_0<T>>.Migrate(CheckUnityEvent_0<T> model)
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

		private void SetTargetEvent(MemberInfo newMember)
		{
		}
	}
}
