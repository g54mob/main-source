using System;
using System.Reflection;
using NodeCanvas.Framework;
using ParadoxNotion.Serialization;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

namespace NodeCanvas.Tasks.Conditions
{
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
