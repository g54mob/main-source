using System.Collections.Generic;
using System.IO;
using UltimateReplay.Core;
using UnityEngine;

namespace UltimateReplay.Storage
{
	public sealed class ReplayInitialDataBuffer : IReplaySerialize, IReplayDataSerialize
	{
		private Dictionary<ReplayIdentity, List<ReplayInitialData>> initialStates = new Dictionary<ReplayIdentity, List<ReplayInitialData>>();

		public void OnReplaySerialize(ReplayState state)
		{
			state.Write(initialStates.Count);
			foreach (KeyValuePair<ReplayIdentity, List<ReplayInitialData>> initialState in initialStates)
			{
				state.Write(initialState.Key);
				state.Write(initialState.Value.Count);
				for (int i = 0; i < initialState.Value.Count; i++)
				{
					initialState.Value[i].OnReplaySerialize(state);
				}
			}
		}

		public void OnReplayDataSerialize(BinaryWriter writer)
		{
			ReplayState replayState = new ReplayState();
			OnReplaySerialize(replayState);
			replayState.WriteToBinary(writer);
		}

		public void OnReplayDeserialize(ReplayState state)
		{
			int num = state.Read32();
			for (int i = 0; i < num; i++)
			{
				ReplayIdentity key = state.ReadIdentity();
				int num2 = state.Read32();
				for (int j = 0; j < num2; j++)
				{
					ReplayInitialData item = default(ReplayInitialData);
					item.OnReplayDeserialize(state);
					if (!initialStates.ContainsKey(key))
					{
						initialStates.Add(key, new List<ReplayInitialData>());
					}
					initialStates[key].Add(item);
				}
			}
		}

		public void OnReplayDataDeserialize(BinaryReader reader)
		{
			ReplayState replayState = new ReplayState();
			replayState.ReadFromBinary(reader);
			OnReplayDeserialize(replayState);
		}

		public bool HasInitialReplayObjectData(ReplayIdentity identity)
		{
			return initialStates.ContainsKey(identity);
		}

		public void RecordInitialReplayObjectData(ReplayObject obj, float timestamp, Vector3 position, Quaternion rotation, Vector3 scale)
		{
			ReplayInitialData item = new ReplayInitialData
			{
				objectIdentity = obj.ReplayIdentity,
				timestamp = timestamp,
				position = position,
				rotation = rotation,
				scale = scale
			};
			if (obj.transform.parent != null)
			{
				ReplayObject component = obj.transform.parent.GetComponent<ReplayObject>();
				if (component != null)
				{
					item.parentIdentity = component.ReplayIdentity;
				}
			}
			int observedComponentsCount = obj.ObservedComponentsCount;
			int num = 0;
			item.observedComponentIdentities = new ReplayIdentity[observedComponentsCount];
			foreach (ReplayBehaviour observedComponent in obj.ObservedComponents)
			{
				item.observedComponentIdentities[num] = observedComponent.Identity;
				num++;
			}
			item.UpdateDataFlags();
			if (!initialStates.ContainsKey(obj.ReplayIdentity))
			{
				initialStates.Add(obj.ReplayIdentity, new List<ReplayInitialData>());
			}
			initialStates[obj.ReplayIdentity].Add(item);
		}

		public ReplayInitialData RestoreInitialReplayObjectData(ReplayIdentity identity, float timestamp)
		{
			ReplayInitialData result = new ReplayInitialData
			{
				objectIdentity = identity,
				timestamp = timestamp,
				position = Vector3.zero,
				rotation = Quaternion.identity,
				scale = Vector3.one,
				parentIdentity = null,
				observedComponentIdentities = null
			};
			if (initialStates.ContainsKey(identity))
			{
				List<ReplayInitialData> list = initialStates[identity];
				if (list.Count > 0)
				{
					if (list.Count == 1)
					{
						return list[0];
					}
					int num = -1;
					float num2 = float.MaxValue;
					for (int i = 0; i < list.Count; i++)
					{
						float num3 = Mathf.Abs(timestamp - list[i].timestamp);
						if (num3 < num2)
						{
							num = i;
							num2 = num3;
						}
					}
					if (num != -1)
					{
						result = list[num];
					}
				}
			}
			return result;
		}
	}
}
