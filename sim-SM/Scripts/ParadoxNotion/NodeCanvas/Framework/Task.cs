using System;
using System.Collections;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using ParadoxNotion.Services;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	[fsDeserializeOverwrite]
	[SpoofAOT]
	public abstract class Task : ISerializationCollectable, ISerializationCallbackReceiver
	{
		[AttributeUsage(AttributeTargets.Field)]
		protected class GetFromAgentAttribute : Attribute
		{
		}

		[fsSerializeAs("_isDisabled")]
		private bool _isUserDisabled;

		[fsSerializeAs("overrideAgent")]
		protected internal TaskAgentParameter _agentParameter;

		private ITaskSystem _ownerSystem;

		private Component _currentAgent;

		private string _taskName;

		private string _taskDescription;

		private string _obsoleteInfo;

		private bool _isRuntimeActive;

		private bool _isInitSuccess;

		private EventRouter _eventRouter;

		public ITaskSystem ownerSystem
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public Component ownerSystemAgent => null;

		public IBlackboard ownerSystemBlackboard => null;

		public float ownerSystemElapsedTime => 0f;

		public bool isUserEnabled
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public string obsolete => null;

		public string name => null;

		public string description => null;

		public string summaryInfo => null;

		protected virtual string info => null;

		public virtual Type agentType => null;

		public string agentInfo => null;

		public string agentParameterName => null;

		public bool agentIsOverride
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Component agent => null;

		public IBlackboard blackboard => null;

		public EventRouter router => null;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public Task()
		{
		}

		public static T Create<T>(ITaskSystem newOwnerSystem)
		{
			return default(T);
		}

		public static Task Create(Type type, ITaskSystem newOwnerSystem)
		{
			return null;
		}

		public virtual Task Duplicate(ITaskSystem newOwnerSystem)
		{
			return null;
		}

		public void Validate(ITaskSystem ownerSystem)
		{
		}

		public void SetOwnerSystem(ITaskSystem newOwnerSystem)
		{
		}

		protected bool Set(Component newAgent, IBlackboard newBB)
		{
			return false;
		}

		private bool Initialize(Component newAgent)
		{
			return false;
		}

		private bool InitializeFieldAttributes(Component newAgent)
		{
			return false;
		}

		protected bool Error(string error, string tag = "Execution")
		{
			return false;
		}

		protected Coroutine StartCoroutine(IEnumerator routine)
		{
			return null;
		}

		protected void StopCoroutine(Coroutine routine)
		{
		}

		protected void SendEvent(string name)
		{
		}

		protected void SendEvent<T>(string name, T value)
		{
		}

		internal virtual string GetWarningOrError()
		{
			return null;
		}

		protected virtual string OnErrorCheck()
		{
			return null;
		}

		private string GetHardError()
		{
			return null;
		}

		protected virtual string OnInit()
		{
			return null;
		}

		public virtual void OnCreate(ITaskSystem ownerSystem)
		{
		}

		public virtual void OnValidate(ITaskSystem ownerSystem)
		{
		}

		[Obsolete("Use OnDrawGizmosSelected")]
		public virtual void OnDrawGizmos()
		{
		}

		public virtual void OnDrawGizmosSelected()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
