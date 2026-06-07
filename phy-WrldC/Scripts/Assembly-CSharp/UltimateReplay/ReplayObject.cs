using System.Collections.Generic;
using UltimateReplay.Core;
using UnityEngine;

namespace UltimateReplay
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public sealed class ReplayObject : MonoBehaviour, IReplaySerialize
	{
		[SerializeField]
		private ReplayIdentity replayIdentity = new ReplayIdentity();

		[SerializeField]
		[HideInInspector]
		private string prefabIdentity = string.Empty;

		private ReplayState behaviourState = new ReplayState();

		[HideInInspector]
		[SerializeField]
		private ReplayBehaviour[] observedComponents = new ReplayBehaviour[0];

		public ReplayIdentity ReplayIdentity
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

		public string PrefabIdentity => prefabIdentity;

		public bool IsPrefab => !string.IsNullOrEmpty(prefabIdentity);

		public IEnumerable<ReplayBehaviour> ObservedComponents
		{
			get
			{
				ReplayBehaviour[] array = observedComponents;
				foreach (ReplayBehaviour replayBehaviour in array)
				{
					if (replayBehaviour != null)
					{
						yield return replayBehaviour;
					}
				}
			}
		}

		public int ObservedComponentsCount
		{
			get
			{
				int num = 0;
				foreach (ReplayBehaviour observedComponent in ObservedComponents)
				{
					_ = observedComponent;
					num++;
				}
				return num;
			}
		}

		public void Awake()
		{
			ReplayIdentity.RegisterIdentity(replayIdentity);
		}

		public void Update()
		{
		}

		public void OnEnable()
		{
			if (Application.isPlaying)
			{
				ReplayManager.Scene.RegisterReplayObject(this);
			}
		}

		public void OnDisable()
		{
			if (Application.isPlaying && !ReplayManager.IsDisposing)
			{
				ReplayManager.Scene.UnregisterReplayObject(this);
			}
		}

		public void OnDestroy()
		{
			ReplayIdentity.UnregisterIdentity(replayIdentity);
		}

		public void Reset()
		{
			UpdatePrefabLinks();
		}

		public void OnReplaySerialize(ReplayState state)
		{
			if (observedComponents.Length == 0)
			{
				return;
			}
			state.Write(prefabIdentity);
			ReplayBehaviour[] array = observedComponents;
			foreach (ReplayBehaviour replayBehaviour in array)
			{
				if (!(replayBehaviour == null))
				{
					behaviourState.Clear();
					replayBehaviour.OnReplaySerialize(behaviourState);
					if (behaviourState.Size != 0)
					{
						state.Write(replayBehaviour.Identity);
						state.Write((short)behaviourState.Size);
						state.Write(behaviourState);
					}
				}
			}
		}

		public void OnReplayDeserialize(ReplayState state)
		{
			state.ReadString();
			while (!state.EndRead)
			{
				ReplayIdentity replayIdentity = state.ReadIdentity();
				short num = state.Read16();
				bool flag = false;
				ReplayBehaviour[] array = observedComponents;
				foreach (ReplayBehaviour replayBehaviour in array)
				{
					if (!(replayBehaviour == null) && replayBehaviour.Identity == replayIdentity)
					{
						behaviourState = state.ReadState(num);
						replayBehaviour.OnReplayDeserialize(behaviourState);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					for (int j = 0; j < num; j++)
					{
						state.ReadByte();
					}
					Debug.LogWarning("Possible replay state corruption for replay object " + base.gameObject);
				}
			}
		}

		public bool IsComponentObserved(ReplayBehaviour component)
		{
			foreach (ReplayBehaviour observedComponent in ObservedComponents)
			{
				if (component == observedComponent)
				{
					return true;
				}
			}
			return false;
		}

		public void RebuildComponentList()
		{
			List<ReplayBehaviour> list = new List<ReplayBehaviour>();
			ReplayBehaviour[] componentsInChildren = GetComponentsInChildren<ReplayBehaviour>(includeInactive: false);
			foreach (ReplayBehaviour replayBehaviour in componentsInChildren)
			{
				if (!replayBehaviour.GetType().IsDefined(typeof(ReplayIgnoreAttribute), inherit: true))
				{
					list.Add(replayBehaviour);
				}
			}
			observedComponents = list.ToArray();
		}

		public void UpdatePrefabLinks()
		{
			Debug.LogWarning("UpdatePrefabLinks can only be called inside the Unity editor. Calling at runtime will have no effect");
		}
	}
}
