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
	[Description("Will subscribe to a public UnityEvent<T> and return true when that event is raised and it's value is equal to provided value as well.")]
	[fsMigrateVersions(new Type[] { typeof(CheckUnityEventValue_0<>) })]
	public class CheckUnityEventValue<T> : ConditionTask, IReflectedWrapper, IMigratable<CheckUnityEventValue_0<T>>, IMigratable
	{
		[SerializeField]
		private SerializedUnityEventInfo _eventInfo;

		[SerializeField]
		private BBParameter<T> checkValue;

		private UnityEvent<T> unityEvent;

		private MemberInfo targetMember => null;

		private bool isStatic => false;

		private Type eventType => null;

		private FieldInfo targetEventField => null;

		private PropertyInfo targetEventProp => null;

		public override Type agentType => null;

		protected override string info => null;

		void IMigratable<CheckUnityEventValue_0<T>>.Migrate(CheckUnityEventValue_0<T> model)
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
