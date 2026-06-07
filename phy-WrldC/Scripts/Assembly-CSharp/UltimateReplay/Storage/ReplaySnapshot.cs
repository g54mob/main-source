using System;
using System.Collections.Generic;
using System.IO;
using UltimateReplay.Core;
using UnityEngine;

namespace UltimateReplay.Storage
{
	[Serializable]
	public sealed class ReplaySnapshot : IReplaySerialize, IReplayDataSerialize
	{
		private static Queue<ReplayObject> sharedDestroyQueue = new Queue<ReplayObject>();

		private float timeStamp;

		private HashSet<ReplayCreatedObject> newReplayObjectsThisFrame = new HashSet<ReplayCreatedObject>();

		private Dictionary<ReplayIdentity, ReplayState> states = new Dictionary<ReplayIdentity, ReplayState>();

		public float TimeStamp => timeStamp;

		public int Size
		{
			get
			{
				int num = 0;
				foreach (ReplayState value in states.Values)
				{
					num += value.Size;
				}
				return num;
			}
		}

		public ReplaySnapshot(float timeStamp)
		{
			this.timeStamp = timeStamp;
		}

		public void OnReplaySerialize(ReplayState state)
		{
			state.Write(timeStamp);
			state.Write(states.Count);
			foreach (KeyValuePair<ReplayIdentity, ReplayState> state2 in states)
			{
				state.Write(state2.Key);
				state.Write((short)state2.Value.Size);
				state.Write(state2.Value);
			}
		}

		public void OnReplayDataSerialize(BinaryWriter writer)
		{
			writer.Write(timeStamp);
			writer.Write(states.Count);
			foreach (KeyValuePair<ReplayIdentity, ReplayState> state in states)
			{
				writer.Write(state.Key);
				writer.Write((short)state.Value.Size);
				writer.Write(state.Value.ToArray());
			}
		}

		public void OnReplayDeserialize(ReplayState state)
		{
			timeStamp = state.ReadFloat();
			int num = state.Read32();
			for (int i = 0; i < num; i++)
			{
				ReplayIdentity key = state.ReadIdentity();
				short bytes = state.Read16();
				ReplayState value = state.ReadState(bytes);
				states.Add(key, value);
			}
		}

		public void OnReplayDataDeserialize(BinaryReader reader)
		{
			timeStamp = reader.ReadSingle();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				ReplayIdentity key = new ReplayIdentity(reader.ReadInt16());
				short count = reader.ReadInt16();
				ReplayState value = new ReplayState(reader.ReadBytes(count));
				states.Add(key, value);
			}
		}

		public void RecordSnapshot(ReplayIdentity identity, ReplayState state)
		{
			if (!states.ContainsKey(identity))
			{
				states.Add(identity, state);
			}
		}

		public ReplayState RestoreSnapshot(ReplayIdentity identity)
		{
			if (states.ContainsKey(identity))
			{
				ReplayState replayState = states[identity];
				replayState.PrepareForRead();
				return replayState;
			}
			return null;
		}

		public void RestoreReplayObjects(ReplayScene scene, ReplayInitialDataBuffer initialStateBuffer)
		{
			List<ReplayObject> activeReplayObjects = scene.ActiveReplayObjects;
			foreach (ReplayObject item in activeReplayObjects)
			{
				if (!states.ContainsKey(item.ReplayIdentity) && item.IsPrefab)
				{
					sharedDestroyQueue.Enqueue(item);
				}
			}
			while (sharedDestroyQueue.Count > 0)
			{
				ReplayManager.ReplayDestroy(sharedDestroyQueue.Dequeue().gameObject);
			}
			foreach (KeyValuePair<ReplayIdentity, ReplayState> state in states)
			{
				bool flag = false;
				foreach (ReplayObject item2 in activeReplayObjects)
				{
					if (item2.ReplayIdentity == state.Key)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					continue;
				}
				ReplayState value = state.Value;
				value.PrepareForRead();
				string text = value.ReadString();
				GameObject gameObject = ReplayManager.FindReplayPrefab(text);
				if (gameObject == null)
				{
					if (string.IsNullOrEmpty(text))
					{
						text = string.Concat("Unkwnown Replay Object (", state.Key, ")");
						Debug.LogWarning($"Failed to recreate replay scene object '{text}'. The object could not be found within the current scene and it is not a registered replay prefab. You may need to reload the scene before playback to ensure that all recorded objects are present.");
					}
					else
					{
						Debug.LogWarning($"Failed to recreate replay prefab '{text}'. No such prefab is registered.");
					}
					continue;
				}
				ReplayInitialData replayInitialData = default(ReplayInitialData);
				if (initialStateBuffer != null && initialStateBuffer.HasInitialReplayObjectData(state.Key))
				{
					replayInitialData = initialStateBuffer.RestoreInitialReplayObjectData(state.Key, timeStamp);
				}
				Vector3 position = Vector3.zero;
				Quaternion rotation = Quaternion.identity;
				Vector3 localScale = Vector3.one;
				if ((replayInitialData.InitialFlags & ReplayInitialDataFlags.Position) != ReplayInitialDataFlags.None)
				{
					position = replayInitialData.position;
				}
				if ((replayInitialData.InitialFlags & ReplayInitialDataFlags.Rotation) != ReplayInitialDataFlags.None)
				{
					rotation = replayInitialData.rotation;
				}
				if ((replayInitialData.InitialFlags & ReplayInitialDataFlags.Scale) != ReplayInitialDataFlags.None)
				{
					localScale = replayInitialData.scale;
				}
				GameObject gameObject2 = ReplayManager.ReplayInstantiate(gameObject, position, rotation);
				if (gameObject2 == null)
				{
					Debug.LogWarning($"Replay instanitate failed for prefab '{text}'. Some replay objects may be missing");
					continue;
				}
				gameObject2.transform.localScale = localScale;
				ReplayObject component = gameObject2.GetComponent<ReplayObject>();
				if (!(component != null))
				{
					continue;
				}
				component.ReplayIdentity = state.Key;
				if (replayInitialData.observedComponentIdentities != null)
				{
					int num = 0;
					foreach (ReplayBehaviour observedComponent in component.ObservedComponents)
					{
						if (replayInitialData.observedComponentIdentities.Length > num)
						{
							observedComponent.Identity = replayInitialData.observedComponentIdentities[num];
						}
						num++;
					}
				}
				newReplayObjectsThisFrame.Add(new ReplayCreatedObject
				{
					replayObject = component,
					replayInitialData = replayInitialData
				});
				ReplayBehaviour.Events.CallReplaySpawnedEvents(component, replayInitialData.position, replayInitialData.rotation);
			}
			foreach (ReplayCreatedObject item3 in newReplayObjectsThisFrame)
			{
				if (!(item3.replayInitialData.parentIdentity != null))
				{
					continue;
				}
				bool flag2 = false;
				foreach (ReplayObject activeReplayObject in scene.ActiveReplayObjects)
				{
					if (activeReplayObject.ReplayIdentity == item3.replayInitialData.parentIdentity)
					{
						item3.replayObject.transform.SetParent(activeReplayObject.transform, worldPositionStays: false);
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					Debug.LogWarning($"Newly created replay object '{item3.replayObject.name}' references identity '{item3.replayInitialData.parentIdentity}' as a transform parent but the object could not be found in the current scene. Has the target parent been deleted this frame?");
				}
			}
			newReplayObjectsThisFrame.Clear();
		}

		public void Reset()
		{
			states.Clear();
		}

		internal void CorrectTimestamp(float offset)
		{
			timeStamp += offset;
		}
	}
}
