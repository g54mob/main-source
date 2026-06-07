using System;
using System.Collections.Generic;
using System.Reflection;
using UltimateReplay.Core;
using UnityEngine;

namespace UltimateReplay
{
	[ExecuteInEditMode]
	public abstract class ReplayBehaviour : MonoBehaviour, IReplaySerialize
	{
		internal static class Events
		{
			internal static void CallReplayStartEvents()
			{
				foreach (ReplayBehaviour allBehaviour in allBehaviours)
				{
					try
					{
						allBehaviour.OnReplayStart();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}

			internal static void CallReplayEndEvents()
			{
				foreach (ReplayBehaviour allBehaviour in allBehaviours)
				{
					try
					{
						allBehaviour.OnReplayEnd();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}

			internal static void CallReplayPlayPauseEvents(bool paused)
			{
				foreach (ReplayBehaviour allBehaviour in allBehaviours)
				{
					try
					{
						allBehaviour.OnReplayPlayPause(paused);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}

			internal static void CallReplayResetEvents()
			{
				foreach (ReplayBehaviour allBehaviour in allBehaviours)
				{
					try
					{
						allBehaviour.OnReplayReset();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}

			internal static void CallReplayUpdateEvents()
			{
				foreach (ReplayBehaviour allBehaviour in allBehaviours)
				{
					try
					{
						allBehaviour.OnReplayUpdate();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}

			internal static void CallReplaySpawnedEvents(ReplayObject spawnedObject, Vector3 position, Quaternion rotation)
			{
				ReplayBehaviour[] componentsInChildren = spawnedObject.GetComponentsInChildren<ReplayBehaviour>();
				foreach (ReplayBehaviour replayBehaviour in componentsInChildren)
				{
					try
					{
						replayBehaviour.OnReplaySpawned(position, rotation);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
		}

		private const byte variableIdentifier = 1;

		private const byte eventIdentifier = 2;

		private static HashSet<ReplayBehaviour> allBehaviours = new HashSet<ReplayBehaviour>();

		[SerializeField]
		private ReplayIdentity replayIdentity = new ReplayIdentity();

		private ReplayVariable[] replayVariables = new ReplayVariable[0];

		private Queue<ReplayEvent> replayEvents = new Queue<ReplayEvent>();

		public ReplayIdentity Identity
		{
			get
			{
				return replayIdentity;
			}
			set
			{
				replayIdentity = value;
			}
		}

		public bool IsRecording
		{
			get
			{
				if (ReplayManager.IsDisposing)
				{
					return false;
				}
				return ReplayManager.IsRecording;
			}
		}

		public bool IsReplaying
		{
			get
			{
				if (ReplayManager.IsDisposing)
				{
					return false;
				}
				return ReplayManager.IsReplaying;
			}
		}

		public PlaybackDirection PlaybackDirection
		{
			get
			{
				if (ReplayManager.IsDisposing)
				{
					return PlaybackDirection.Forward;
				}
				return ReplayManager.PlaybackDirection;
			}
		}

		public virtual void Reset()
		{
		}

		public virtual void Awake()
		{
			ReplayIdentity.RegisterIdentity(replayIdentity);
			ReplayFindVariables();
		}

		public virtual void OnDestroy()
		{
			ReplayIdentity.UnregisterIdentity(replayIdentity);
		}

		public virtual void OnEnable()
		{
			if (!allBehaviours.Contains(this))
			{
				allBehaviours.Add(this);
			}
		}

		public virtual void OnDisable()
		{
			if (allBehaviours.Contains(this))
			{
				allBehaviours.Remove(this);
			}
		}

		public virtual void OnReplaySerialize(ReplayState state)
		{
			ReplayBehaviourDataFlags replayBehaviourDataFlags = ReplayBehaviourDataFlags.None;
			if (replayEvents.Count > 0)
			{
				replayBehaviourDataFlags |= ReplayBehaviourDataFlags.Events;
			}
			if (replayVariables.Length != 0)
			{
				replayBehaviourDataFlags |= ReplayBehaviourDataFlags.Variables;
			}
			state.Write((byte)replayBehaviourDataFlags);
			if ((replayBehaviourDataFlags & ReplayBehaviourDataFlags.Events) != ReplayBehaviourDataFlags.None)
			{
				ReplaySerializeEvents(state);
			}
			if ((replayBehaviourDataFlags & ReplayBehaviourDataFlags.Variables) != ReplayBehaviourDataFlags.None)
			{
				ReplaySerializeVariables(state);
			}
		}

		public virtual void OnReplayDeserialize(ReplayState state)
		{
			if (!state.EndRead)
			{
				byte num = state.ReadByte();
				if ((num & 2) != 0)
				{
					ReplayDeserializeEvents(state);
				}
				if ((num & 1) != 0)
				{
					ReplayDeserializeVariables(state);
				}
			}
		}

		public virtual void OnReplayStart()
		{
		}

		public virtual void OnReplayEnd()
		{
		}

		public virtual void OnReplayPlayPause(bool paused)
		{
		}

		public virtual void OnReplayReset()
		{
		}

		public virtual void OnReplayUpdate()
		{
			ReplayInterpolateVariables(ReplayTime.Delta);
		}

		public virtual void OnReplayEvent(ReplayEvent replayEvent)
		{
		}

		public virtual void OnReplaySpawned(Vector3 position, Quaternion rotation)
		{
		}

		public void ReplayRecordEvent(ReplayEvents eventID, ReplayState state = null)
		{
			ReplayRecordEvent((byte)eventID, state);
		}

		public void ReplayRecordEvent(byte eventID, ReplayState state = null)
		{
			ReplayEvent item = new ReplayEvent
			{
				eventID = eventID,
				eventData = state
			};
			if (item.eventData == null)
			{
				item.eventData = new ReplayState();
			}
			replayEvents.Enqueue(item);
		}

		protected virtual void ReplaySerializeEvents(ReplayState state)
		{
			short value = (short)replayEvents.Count;
			state.Write(value);
			while (replayEvents.Count > 0)
			{
				ReplayEvent replayEvent = replayEvents.Dequeue();
				state.Write(replayEvent.eventID);
				state.Write((byte)replayEvent.eventData.Size);
				state.Write(replayEvent.eventData);
			}
		}

		protected virtual void ReplayDeserializeEvents(ReplayState state)
		{
			short num = state.Read16();
			for (int i = 0; i < num; i++)
			{
				ReplayEvent replayEvent = new ReplayEvent
				{
					eventID = state.ReadByte()
				};
				byte bytes = state.ReadByte();
				replayEvent.eventData = state.ReadState(bytes);
				try
				{
					OnReplayEvent(replayEvent);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		protected virtual void ReplaySerializeVariables(ReplayState state)
		{
			short value = (short)replayVariables.Length;
			state.Write(value);
			ReplayVariable[] array = replayVariables;
			foreach (ReplayVariable replayVariable in array)
			{
				state.Write(replayVariable.Name.GetHashCode());
				replayVariable.OnReplaySerialize(state);
			}
		}

		protected virtual void ReplayDeserializeVariables(ReplayState state)
		{
			short num = state.Read16();
			for (int i = 0; i < num; i++)
			{
				bool flag = false;
				int num2 = state.Read32();
				ReplayVariable[] array = replayVariables;
				foreach (ReplayVariable replayVariable in array)
				{
					if (replayVariable.Name.GetHashCode() == num2)
					{
						replayVariable.OnReplayDeserialize(state);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}

		protected virtual void ReplayInterpolateVariables(float delta)
		{
			ReplayVariable[] array = replayVariables;
			foreach (ReplayVariable replayVariable in array)
			{
				if (replayVariable.IsInterpolated)
				{
					replayVariable.Interpolate(delta);
				}
			}
		}

		protected virtual void ReplayFindVariables()
		{
			replayVariables = new ReplayVariable[0];
			FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.IsDefined(typeof(ReplayVarAttribute), inherit: true))
				{
					object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(ReplayVarAttribute), inherit: true);
					if (customAttributes.Length != 0)
					{
						ReplayVarAttribute attribute = customAttributes[0] as ReplayVarAttribute;
						ReplayVariable variable = new ReplayVariable(this, fieldInfo, attribute);
						ReplayRegisterVariable(variable);
					}
				}
			}
		}

		private void ReplayRegisterVariable(ReplayVariable variable)
		{
			Array.Resize(ref replayVariables, replayVariables.Length + 1);
			replayVariables[replayVariables.Length - 1] = variable;
		}
	}
}
