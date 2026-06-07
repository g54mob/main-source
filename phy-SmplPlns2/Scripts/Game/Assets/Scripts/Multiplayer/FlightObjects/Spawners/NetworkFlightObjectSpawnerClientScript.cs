using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.FlightObjects.Spawners.SpawnerData;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Spawners
{
	public abstract class NetworkFlightObjectSpawnerClientScript : MonoBehaviour
	{
		private FlightSceneNetworkScript _flightSceneNetwork;

		private NetworkFlightObjectManager _manager;

		public NetworkFlightObjectManager Manager => _manager;

		public abstract string SpawnerId { get; }

		public abstract NetworkFlightObjectSpawnerType Type { get; }

		protected virtual Dictionary<string, string> GetSpawnerDataKeyValuePairs()
		{
			ISpawnerData[] components = GetComponents<ISpawnerData>();
			if (components.Length == 0)
			{
				return null;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			ISpawnerData[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].GetSpawnerData(dictionary);
			}
			return dictionary;
		}

		protected virtual void OnDestroy()
		{
			if ((object)_flightSceneNetwork != null)
			{
				_flightSceneNetwork.ClientStarted -= OnClientStarted;
			}
			if (_flightSceneNetwork != null && _flightSceneNetwork.IsClientInitialized)
			{
				_flightSceneNetwork.UnregisterFlightObjectSpawner(SpawnerId);
			}
		}

		protected virtual void OnInitialized()
		{
		}

		protected virtual void Start()
		{
			_flightSceneNetwork = FlightSceneScript.Instance.FlightSceneNetwork;
			_manager = _flightSceneNetwork.FlightObjectsManager;
			if (_flightSceneNetwork.IsClientStarted)
			{
				OnClientStarted();
			}
			else
			{
				_flightSceneNetwork.ClientStarted += OnClientStarted;
			}
		}

		protected abstract void WriteSpawnerData(PooledWriter data);

		protected void WriteSpawnerDataKeyValuePairs(PooledWriter writer, IDictionary<string, string> data)
		{
			writer.WriteUInt8Unpacked((byte)(data?.Count ?? 0));
			if (data == null)
			{
				return;
			}
			foreach (KeyValuePair<string, string> datum in data)
			{
				writer.WriteString(datum.Key);
				writer.WriteString(datum.Value);
			}
		}

		private void OnClientStarted()
		{
			using (PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter())
			{
				WriteSpawnerData(pooledWriterDisposableWrapper);
				_flightSceneNetwork.RegisterFlightObjectSpawner(SpawnerId, Type, pooledWriterDisposableWrapper.Writer.GetArraySegment());
			}
			OnInitialized();
		}
	}
}
