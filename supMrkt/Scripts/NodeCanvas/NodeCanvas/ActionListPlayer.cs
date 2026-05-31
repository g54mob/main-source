using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas
{
	[AddComponentMenu("NodeCanvas/Standalone Action List (Bonus)")]
	public class ActionListPlayer : MonoBehaviour, ITaskSystem, ISerializationCallbackReceiver
	{
		public bool playOnAwake;

		[SerializeField]
		private string _serializedList;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private Blackboard _blackboard;

		[NonSerialized]
		private ActionList _actionList;

		private float timeStarted;

		public ActionList actionList => null;

		public float elapsedTime => 0f;

		public float deltaTime => 0f;

		UnityEngine.Object ITaskSystem.contextObject => null;

		Component ITaskSystem.agent => null;

		public IBlackboard blackboard
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public static ActionListPlayer Create()
		{
			return null;
		}

		protected void Awake()
		{
		}

		public void UpdateTasksOwner()
		{
		}

		void ITaskSystem.SendEvent(string name, object value, object sender)
		{
		}

		void ITaskSystem.SendEvent<T>(string name, T value, object sender)
		{
		}

		[ContextMenu("Play")]
		public void Play()
		{
		}

		public void Play(Action<Status> OnFinish)
		{
		}

		public void Play(Component agent, IBlackboard blackboard, Action<Status> OnFinish)
		{
		}

		public Status Execute()
		{
			return default(Status);
		}

		public Status Execute(Component agent)
		{
			return default(Status);
		}
	}
}
