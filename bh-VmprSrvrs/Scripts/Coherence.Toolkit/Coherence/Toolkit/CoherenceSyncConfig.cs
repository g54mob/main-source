using System;
using Coherence.Log;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public sealed class CoherenceSyncConfig : ScriptableObject
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private string selfId;

		[SerializeField]
		[Tooltip("If disabled, this Object will not be included in the Schema and it will not be synchronized with the network.")]
		private bool includeInSchema;

		[SerializeReference]
		[ObjectProvider(typeof(INetworkObjectProvider), "Load via", "Choose how coherence will load this prefab to memory when a new remote entity spawns in the network. You can hook your own implementation using the INetworkObjectProvider interface.")]
		private INetworkObjectProvider objectProvider;

		[SerializeReference]
		[ObjectProvider(typeof(INetworkObjectInstantiator), "Instantiate via", "Choose how coherence will instantiate this prefab into the scene when a new remote entity spawns in the network. You can hook your own implementation using the INetworkObjectInstantiator interface.")]
		private INetworkObjectInstantiator objectInstantiator;

		private Coherence.Log.Logger logger;

		public bool IncludeInSchema
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string ID => null;

		internal string SelfID => null;

		public INetworkObjectProvider Provider
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public INetworkObjectInstantiator Instantiator
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		private void OnDestroy()
		{
		}

		public void GetInstanceAsync(Action<CoherenceSync> onInstantiate)
		{
		}

		public void GetInstanceAsync(Scene scene, Action<CoherenceSync> onInstantiate)
		{
		}

		public void GetInstanceAsync(Vector3 position, Quaternion rotation, Action<CoherenceSync> onInstantiate)
		{
		}

		public void GetInstanceAsync(Scene scene, Vector3 position, Quaternion rotation, Action<CoherenceSync> onInstantiate)
		{
		}

		public void GetInstanceAsync(ICoherenceBridge bridge, Vector3 position, Quaternion rotation, Action<CoherenceSync> onInstantiate)
		{
		}

		public CoherenceSync GetInstance()
		{
			return null;
		}

		public CoherenceSync GetInstance(Scene scene)
		{
			return null;
		}

		public CoherenceSync GetInstance(Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public CoherenceSync GetInstance(Scene scene, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public CoherenceSync GetInstance(ICoherenceBridge bridge, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public void ReleaseInstance(CoherenceSync instance)
		{
		}

		private CoherenceSync GetInstance(ICoherenceBridge bridge, Vector3 position, Quaternion rotation, ICoherenceSync sync)
		{
			return null;
		}

		private bool AssertProviderInstantiatorPresent()
		{
			return false;
		}

		internal void Init(string identifier)
		{
		}
	}
}
