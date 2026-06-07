using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Scenes.Events;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Serializing;
using Jundroo.Common.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public class NetworkedActivityManager : MonoBehaviour
	{
		[SerializeField]
		private List<NetworkedActivityScript> _activities;

		[SerializeField]
		private NetworkedActivityDebugLogFlags _debugLogFlags;

		private Dictionary<string, NetworkedActivityData> _registeredActivities;

		public IReadOnlyList<NetworkedActivityScript> Activities => _activities;

		public NetworkedActivityDebugLogFlags DebugLogFlags
		{
			get
			{
				return _debugLogFlags;
			}
			set
			{
				_debugLogFlags = value;
			}
		}

		public IReadOnlyCollection<NetworkedActivityData> RegisteredActivities => _registeredActivities.Values;

		public event EventHandler<NetworkedActivityStateChangedEventArgs> ActivityStateChanged;

		public static NetworkedActivityManager Create(GameObject parentGameObject)
		{
			NetworkedActivityManager networkedActivityManager = new GameObject("NetworkedActivityManager").AddComponent<NetworkedActivityManager>();
			networkedActivityManager.transform.SetParent(parentGameObject.transform);
			try
			{
				networkedActivityManager.Initialize();
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred initializing the networked activity manager");
				Debug.LogException(exception);
			}
			return networkedActivityManager;
		}

		public async UniTask<bool> CreateActivity(string id)
		{
			NetworkedActivityData registeredActivity = GetRegisteredActivity(id);
			if (registeredActivity == null)
			{
				Debug.LogError("Unable to create activity '" + id + "' because an activity with that id could not be found.");
				return false;
			}
			return await CreateActivity(registeredActivity);
		}

		public async UniTask<bool> CreateActivity(NetworkedActivityData activityData)
		{
			FlightSceneNetworkScript fsn = FlightSceneScript.Instance?.FlightSceneNetwork;
			if (fsn == null)
			{
				Debug.LogError("Unable to create activity '" + activityData.Id + "' because the flight scene network is currently unavailable.");
				return false;
			}
			await LeaveActivity();
			Guid activityInstanceId = Guid.NewGuid();
			using (PooledWriterDisposableWrapper pooledWriterDisposableWrapper = fsn.GetPooledWriter())
			{
				pooledWriterDisposableWrapper.Writer.WriteGuidAllocated(activityInstanceId);
				activityData.SerializeWrite((PooledWriter)pooledWriterDisposableWrapper, includeDescription: false);
				fsn.SendServerRpc(FlightSceneServerRpcType.NetworkedActivityManager_CreateActivity, pooledWriterDisposableWrapper.GetData());
			}
			int timeoutInSeconds = 15;
			if (!(await UniTaskEx.WaitUntilWithTimeout(() => GetActivityByInstanceId(activityInstanceId) != null, timeoutInSeconds * 1000)))
			{
				Debug.LogError($"The local player was unable to create activity '{activityData.Id}'. The request timed out after {timeoutInSeconds} seconds.");
				return false;
			}
			return true;
		}

		public NetworkedActivityData GetRegisteredActivity(string id)
		{
			if (!_registeredActivities.TryGetValue(id, out var value))
			{
				return null;
			}
			return value;
		}

		public async UniTask LeaveActivity()
		{
			FlightSceneScript.Instance.FlightUI.ActivityManagerUI.CloseCurrentActivityUI();
			FlightScenePlayer player = FlightSceneScript.Instance.LocalPlayer;
			if (player.NetworkedActivity != null)
			{
				player.NetworkedActivity.LeaveActivity(player);
				int timeoutInSeconds = 15;
				if (!(await UniTaskEx.WaitUntilWithTimeout(() => player.NetworkedActivity == null, timeoutInSeconds * 1000)))
				{
					Debug.LogError($"The local player was unable to leave their current activity. The request timed out after {timeoutInSeconds} seconds.");
				}
			}
		}

		public void LoadActivitiesFromXml(XElement xml)
		{
			foreach (XElement item in xml.Elements("Activity"))
			{
				try
				{
					NetworkedActivityData networkedActivityData = NetworkedActivityData.LoadFromXml(item);
					if (_registeredActivities.ContainsKey(networkedActivityData.Id))
					{
						Debug.LogError("Unable to load activity with id '" + networkedActivityData.Id + "' because an activity with that id has already been loaded.");
					}
					else
					{
						_registeredActivities.Add(networkedActivityData.Id, networkedActivityData);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError($"An error occurred loading an activity from XML:{System.Environment.NewLine}{xml}");
				}
			}
		}

		public void OnActivityStateChanged(NetworkedActivityScript activity, NetworkedActivityState state)
		{
			switch (state)
			{
			case NetworkedActivityState.Initialized:
				_activities.Add(activity);
				break;
			case NetworkedActivityState.Destroyed:
				_activities.Remove(activity);
				break;
			}
			this.ActivityStateChanged?.Invoke(this, new NetworkedActivityStateChangedEventArgs(activity, state));
		}

		private void CreateActivityServerRpc(ArraySegment<byte> data, NetworkConnection sender)
		{
			FlightSceneNetworkScript flightSceneNetworkScript = FlightSceneScript.Instance?.FlightSceneNetwork;
			if (flightSceneNetworkScript == null)
			{
				Debug.LogError("The server is unable to create an activity because the flight scene network is currently unavailable.");
				return;
			}
			Guid instanceId = Guid.Empty;
			NetworkedActivityData networkedActivityData = null;
			using (PooledReaderDisposableWrapper pooledReaderDisposableWrapper = flightSceneNetworkScript.GetPooledReader(data))
			{
				instanceId = pooledReaderDisposableWrapper.Reader.ReadGuid();
				networkedActivityData = NetworkedActivityData.LoadFromNetwork((PooledReader)pooledReaderDisposableWrapper);
			}
			if (networkedActivityData == null)
			{
				Debug.LogError("The server is unable to create an activity because the requested activity data could not be read from the network.");
				return;
			}
			NetworkedActivityScript networkedActivityScript = Game.Instance.ResourceLoader.InstantiatePrefab<NetworkedActivityScript>("Flight/Activities/" + networkedActivityData.Prefab);
			if (networkedActivityScript == null)
			{
				Debug.LogError("The server is unable to create activity '" + networkedActivityData.Id + "' because a prefab with that name could not be found.");
				return;
			}
			Vector3 vector3Attribute = networkedActivityData.XmlData.GetVector3Attribute("position", Vector3.zero);
			Vector3 vector3Attribute2 = networkedActivityData.XmlData.GetVector3Attribute("rotation", Vector3.zero);
			networkedActivityScript.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			networkedActivityScript.transform.SetPositionAndRotation(Utility.ConvertAbsoluteToFloatingOriginPosition(vector3Attribute), Quaternion.Euler(vector3Attribute2));
			networkedActivityScript.ServerInitialize(instanceId, networkedActivityData);
			flightSceneNetworkScript.ServerManager.Spawn(networkedActivityScript.gameObject, sender);
		}

		private NetworkedActivityScript GetActivityByInstanceId(Guid id)
		{
			foreach (NetworkedActivityScript activity in _activities)
			{
				if (activity.InstanceId == id)
				{
					return activity;
				}
			}
			return null;
		}

		private void Initialize()
		{
			_debugLogFlags = NetworkedActivityDebugLogFlags.None;
			_registeredActivities = new Dictionary<string, NetworkedActivityData>();
			_activities = new List<NetworkedActivityScript>();
			LoadActivitiesFromXml(Game.Instance.ResourceLoader.LoadXml("Data/Activities/NetworkedActivities").Root);
			Game.Instance.SceneManager.SceneLoaded += OnSceneLoaded;
			Game.Instance.SceneManager.SceneUnloading += OnSceneUnloading;
		}

		private void OnSceneLoaded(object sender, SceneEventArgs e)
		{
			if (Game.Instance.NetworkGameManager.IsServer)
			{
				FlightSceneScript.Instance.FlightSceneNetwork.SubscribeToServerRpc(FlightSceneServerRpcType.NetworkedActivityManager_CreateActivity, CreateActivityServerRpc);
			}
		}

		private void OnSceneUnloading(object sender, SceneEventArgs e)
		{
			if (Game.Instance.NetworkGameManager.IsServer)
			{
				FlightSceneScript.Instance.FlightSceneNetwork.UnsubscribeFromServerRpc(FlightSceneServerRpcType.NetworkedActivityManager_CreateActivity);
			}
		}
	}
}
