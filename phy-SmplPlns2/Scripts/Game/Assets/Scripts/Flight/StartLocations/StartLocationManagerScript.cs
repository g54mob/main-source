using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Proximity;
using Assets.Scripts.Levels;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Settings;
using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Serializing;
using UnityEngine;

namespace Assets.Scripts.Flight.StartLocations
{
	public class StartLocationManagerScript : MonoBehaviour
	{
		[Serializable]
		private struct DynamicLocationPositionRequestResult
		{
			public Vector3 Position;

			public CreateStartLocationResultType ResultType;

			public DynamicLocationPositionRequestResult(Vector3 position, CreateStartLocationResultType resultType)
			{
				Position = position;
				ResultType = resultType;
			}
		}

		private AsyncFlightSceneNetworkRequest<string, DynamicLocationPositionRequestResult> _dynamicLocationPositionRequest;

		private Dictionary<string, DynamicStartLocationScript> _dynamicLocationsById;

		private List<string> _dynamicLocationsUnavailable;

		private FlightSceneNetworkScript _flightSceneNetwork;

		private LocationSettings _locationSettings;

		private MapStartingLocations _mapStartLocations;

		public IReadOnlyList<StartLocationData> Locations => _mapStartLocations.StartingLocations;

		public static StartLocationManagerScript Create(GameObject gameObject, FlightSceneNetworkScript flightSceneNetwork)
		{
			StartLocationManagerScript startLocationManagerScript = gameObject.AddComponent<StartLocationManagerScript>();
			startLocationManagerScript.Initialize(flightSceneNetwork);
			return startLocationManagerScript;
		}

		public StartLocation CreateAvailableStartLocation(StartLocationData startLocationData)
		{
			StartLocation startLocation = new StartLocation(startLocationData);
			if (!startLocationData.IsDynamicLocation)
			{
				return startLocation;
			}
			DynamicStartLocationScript dynamicLocation = GetDynamicLocation(startLocation.DynamicLocationId);
			if (dynamicLocation != null && dynamicLocation.isActiveAndEnabled)
			{
				startLocation.DynamicLocationPosition = dynamicLocation.GlobalPosition;
				return startLocation;
			}
			throw new Exception("Unable to create a start location for location '" + startLocationData.DisplayName + "'. This location is dynamic and is not currently loaded or active.");
		}

		public StartLocationData CreateCustomStartingLocation(string name, string areaName, Vector3 position, Vector3 rotation, Vector3 initialVelocity, bool startGrounded)
		{
			Vector3 distributionAxis = Vector3.right;
			float distributionAmount = StartLocationData.DefaultMaxDistributionAmount;
			DynamicStartLocationScript dynamicLocation = GetDynamicLocation(ref position, ref rotation, ref initialVelocity, ref startGrounded, ref distributionAxis, ref distributionAmount);
			StartLocationData startLocationData = new StartLocationData
			{
				Id = name,
				DisplayName = name,
				AreaName = areaName,
				LocationType = StartLocationType.Custom,
				Position = position,
				Rotation = rotation,
				InitialVelocity = initialVelocity,
				StartOnGround = startGrounded,
				DynamicLocationId = dynamicLocation?.Id,
				DistributionAxis = distributionAxis,
				MaxDistributionAmount = distributionAmount
			};
			_locationSettings.RemoveCustomStartLocation(_mapStartLocations.MapId, startLocationData.Id);
			_locationSettings.AddCustomStartLocation(_mapStartLocations.MapId, startLocationData);
			_locationSettings.SaveIfNecessary();
			return startLocationData;
		}

		public async UniTask<(StartLocation Location, CreateStartLocationResultType ResultType)> CreateStartLocation(StartLocationData startLocationData)
		{
			StartLocation startLocation = new StartLocation(startLocationData);
			if (!startLocationData.IsDynamicLocation)
			{
				return (startLocation, CreateStartLocationResultType.Success);
			}
			DynamicStartLocationScript dynamicLocation = GetDynamicLocation(startLocation.DynamicLocationId);
			if (dynamicLocation != null)
			{
				startLocation.DynamicLocationPosition = dynamicLocation.GlobalPosition;
			}
			else
			{
				AsyncNetworkRequest<string, DynamicLocationPositionRequestResult>.Result result = await _dynamicLocationPositionRequest.SendRequest(startLocation.DynamicLocationId);
				if (result.TimedOut)
				{
					throw new Exception("Unable to determine the current location for '" + startLocationData.DisplayName + "'. The current location was requested from the server but the request timed out.");
				}
				if (result.ResultData.ResultType != CreateStartLocationResultType.Success)
				{
					return (null, result.ResultData.ResultType);
				}
				startLocation.DynamicLocationPosition = result.ResultData.Position;
			}
			return (startLocation, CreateStartLocationResultType.Success);
		}

		public StartLocationData CreateTempStartingLocation(string name, Vector3 position, Vector3 rotation, Vector3 initialVelocity, bool startGrounded)
		{
			Vector3 distributionAxis = Vector3.right;
			float distributionAmount = StartLocationData.DefaultMaxDistributionAmount;
			DynamicStartLocationScript dynamicLocation = GetDynamicLocation(ref position, ref rotation, ref initialVelocity, ref startGrounded, ref distributionAxis, ref distributionAmount);
			return new StartLocationData
			{
				Id = name,
				DisplayName = name,
				AreaName = null,
				LocationType = StartLocationType.Temp,
				Position = position,
				Rotation = rotation,
				InitialVelocity = initialVelocity,
				StartOnGround = startGrounded,
				DynamicLocationId = dynamicLocation?.Id,
				DistributionAxis = distributionAxis,
				MaxDistributionAmount = distributionAmount
			};
		}

		public StartLocationData GetCurrentStartLocation()
		{
			return GetStartLocation(_mapStartLocations.SelectedLocationId) ?? _mapStartLocations.StartingLocations[0];
		}

		public DynamicStartLocationScript GetDynamicLocation(string locationId)
		{
			if (!_dynamicLocationsById.TryGetValue(locationId, out var value))
			{
				return null;
			}
			return value;
		}

		public StartLocationData GetStartLocation(string startLocationId, bool includeUndiscoveredLocations = false)
		{
			StartLocationData startLocationData = _mapStartLocations.StartingLocations.FirstOrDefault((StartLocationData x) => x.Id == startLocationId);
			if (startLocationData == null && includeUndiscoveredLocations)
			{
				startLocationData = _locationSettings.GetDiscoverableLocation(_mapStartLocations.MapId, startLocationId);
			}
			return startLocationData;
		}

		public bool IsDynamicLocationUnavailable(string locationId)
		{
			return _dynamicLocationsUnavailable.Contains(locationId);
		}

		public void RegisterDynamicLocation(DynamicStartLocationScript location)
		{
			_dynamicLocationsUnavailable.Remove(location.Id);
			if (_dynamicLocationsById.TryGetValue(location.Id, out var value))
			{
				bool flag = (object)value != null && value == null;
				Debug.LogError("Attempted to register a dynamic start location with id '" + location.Id + "' but a location with that ID was already registered." + System.Environment.NewLine + "Existing Location: " + (flag ? "Dead Game Object" : $"{value.name} ({value.GetInstanceID()})") + $"{System.Environment.NewLine}New Location: {location.name} ({location.GetInstanceID()})", location.gameObject);
				UnregisterDynamicLocation(location);
			}
			_dynamicLocationsById.Add(location.Id, location);
		}

		public void RemoveCustomStartingLocation(string id)
		{
			_locationSettings.RemoveCustomStartLocation(_mapStartLocations.MapId, id);
			_locationSettings.SaveIfNecessary();
		}

		public void SetCurrentLocation(StartLocationData location)
		{
			_locationSettings.SetSelectedLocation(_mapStartLocations, location.Id);
			_locationSettings.SaveIfNecessary();
		}

		public void SetDynamicLocationUnavailable(string locationId, bool unavailable)
		{
			if (!_flightSceneNetwork.IsServerStarted)
			{
				using (PooledWriterDisposableWrapper pooledWriterDisposableWrapper = _flightSceneNetwork.GetPooledWriter())
				{
					pooledWriterDisposableWrapper.Writer.WriteString(locationId);
					pooledWriterDisposableWrapper.Writer.WriteBoolean(unavailable);
					_flightSceneNetwork.SendServerRpc(FlightSceneServerRpcType.StartLocations_SetDynamicLocationUnavailable, pooledWriterDisposableWrapper.GetData());
					return;
				}
			}
			if (unavailable)
			{
				if (!_dynamicLocationsUnavailable.Contains(locationId))
				{
					_dynamicLocationsUnavailable.Add(locationId);
				}
			}
			else
			{
				_dynamicLocationsUnavailable.Remove(locationId);
			}
		}

		public void UnregisterDynamicLocation(DynamicStartLocationScript location)
		{
			if (!_dynamicLocationsById.Remove(location.Id))
			{
				Debug.LogError("Attempted to unregister a dynamic start location with id '" + location.Id + "' but the location does not appear to be registered.");
			}
		}

		protected virtual void OnDestroy()
		{
			_dynamicLocationPositionRequest?.Dispose();
		}

		protected virtual void Start()
		{
			List<StartLocationData> mapStartLocations = LevelBase.GetMapStartLocations();
			if (mapStartLocations != null && mapStartLocations.Count > 0)
			{
				TodoException<StartLocationManagerScript>.LogOnce("MonoBehaviour-based start locations are currently not supported.");
			}
		}

		private static DynamicLocationPositionRequestResult ReadDynamicLocationPositionRequestResult(PooledReader reader)
		{
			return new DynamicLocationPositionRequestResult(reader.ReadVector3(), reader.ReadEnum<CreateStartLocationResultType>());
		}

		private static void WriteDynamicLocationPositionRequestResult(DynamicLocationPositionRequestResult resultData, PooledWriter writer)
		{
			writer.WriteVector3(resultData.Position);
			writer.WriteEnum(resultData.ResultType);
		}

		private float GetCustomDynamicLocationDistributionAmount(DynamicStartLocationScript dynamicLocation, Vector3 distributionAxis, float defaultDistributionAmount, Vector3 framePosition)
		{
			float num = defaultDistributionAmount;
			int num2 = 0;
			Collider[] componentsInChildren = dynamicLocation.GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (!collider.isTrigger)
				{
					num2 |= 1 << collider.gameObject.layer;
				}
			}
			Ray ray = new Ray(framePosition + new Vector3(0f, 1f, 0f), Vector3.down);
			if (Physics.Raycast(ray, out var hitInfo, dynamicLocation.Bounds.size.y, num2, QueryTriggerInteraction.Ignore) && hitInfo.collider.GetComponentInParent<DynamicStartLocationScript>() != null)
			{
				float maxDistance = hitInfo.distance + 5f;
				while (num >= 5f)
				{
					Ray ray2 = new Ray(ray.origin + distributionAxis * num, ray.direction);
					Ray ray3 = new Ray(ray.origin - distributionAxis * num, ray.direction);
					if (dynamicLocation.IsPositionInBounds(ray2.origin) && dynamicLocation.IsPositionInBounds(ray3.origin) && Physics.Raycast(ray2, out var hitInfo2, maxDistance, num2, QueryTriggerInteraction.Ignore) && Physics.Raycast(ray3, out var hitInfo3, maxDistance, num2, QueryTriggerInteraction.Ignore) && hitInfo2.collider.GetComponentInParent<DynamicStartLocationScript>() != null && hitInfo3.collider.GetComponentInParent<DynamicStartLocationScript>() != null)
					{
						break;
					}
					num -= 5f;
				}
			}
			return num;
		}

		private DynamicStartLocationScript GetDynamicLocation(ref Vector3 position, ref Vector3 rotation, ref Vector3 initialVelocity, ref bool startGrounded, ref Vector3 distributionAxis, ref float distributionAmount)
		{
			Vector3 vector = Utility.ConvertAbsoluteToFloatingOriginPosition(position);
			DynamicStartLocationScript dynamicLocationAtPosition = GetDynamicLocationAtPosition(vector);
			if (dynamicLocationAtPosition != null)
			{
				position = dynamicLocationAtPosition.Transform.InverseTransformPoint(vector);
				rotation = (Quaternion.Inverse(dynamicLocationAtPosition.Transform.rotation) * Quaternion.Euler(rotation)).eulerAngles;
				if (dynamicLocationAtPosition.StartVelocityMode == DynamicStartLocationVelocityMode.InheritBodyVelocityAlways || ((dynamicLocationAtPosition.StartVelocityMode == DynamicStartLocationVelocityMode.InheritBodyVelocityOnGround) & startGrounded))
				{
					initialVelocity = Vector3.zero;
				}
				distributionAmount = GetCustomDynamicLocationDistributionAmount(dynamicLocationAtPosition, distributionAxis, distributionAmount, vector);
			}
			return dynamicLocationAtPosition;
		}

		private DynamicStartLocationScript GetDynamicLocationAtPosition(Vector3 framePosition)
		{
			DynamicStartLocationScript result = null;
			float num = float.MaxValue;
			foreach (DynamicStartLocationScript value in _dynamicLocationsById.Values)
			{
				if (value.IsPositionInBounds(framePosition))
				{
					float sqrMagnitude = value.Bounds.size.sqrMagnitude;
					if (sqrMagnitude < num)
					{
						result = value;
						num = sqrMagnitude;
					}
				}
			}
			return result;
		}

		private void Initialize(FlightSceneNetworkScript flightSceneNetwork)
		{
			_flightSceneNetwork = flightSceneNetwork;
			_dynamicLocationsById = new Dictionary<string, DynamicStartLocationScript>();
			_dynamicLocationsUnavailable = new List<string>();
			_flightSceneNetwork.SubscribeToServerRpc(FlightSceneServerRpcType.StartLocations_SetDynamicLocationUnavailable, OnSetDynamicLocationUnavailableServerRpc);
			_dynamicLocationPositionRequest = new AsyncFlightSceneNetworkRequest<string, DynamicLocationPositionRequestResult>(FlightSceneServerRpcType.StartLocations_GetDynamicLocation, FlightSceneClientRpcType.StartLocations_ReceiveDynamicLocation, ProcessDynamicLocationPositionRequest, 30000);
			_dynamicLocationPositionRequest.ConfigureResultSerialization(WriteDynamicLocationPositionRequestResult, ReadDynamicLocationPositionRequestResult);
			_locationSettings = Game.Instance.Settings.Cloud.Locations;
			_mapStartLocations = _locationSettings.GetAvailableLocations(Game.Instance.CurrentMap.MapId);
		}

		private void OnSetDynamicLocationUnavailableServerRpc(ArraySegment<byte> data, NetworkConnection sender)
		{
			PooledReaderDisposableWrapper pooledReader = _flightSceneNetwork.GetPooledReader(data);
			string locationId = pooledReader.Reader.ReadStringAllocated();
			bool unavailable = pooledReader.Reader.ReadBoolean();
			SetDynamicLocationUnavailable(locationId, unavailable);
		}

		private void ProcessDynamicLocationPositionRequest(string dynamicLocationId, AsyncFlightSceneNetworkRequest<string, DynamicLocationPositionRequestResult>.CallbackDelegate callback)
		{
			if (IsDynamicLocationUnavailable(dynamicLocationId))
			{
				callback(new DynamicLocationPositionRequestResult(Vector3.zero, CreateStartLocationResultType.Unavailable));
				return;
			}
			DynamicStartLocationScript dynamicLocation = GetDynamicLocation(dynamicLocationId);
			if (dynamicLocation != null)
			{
				callback(new DynamicLocationPositionRequestResult(dynamicLocation.GlobalPosition, CreateStartLocationResultType.Success));
				return;
			}
			ProximityLoadedObject proximityLoadedObjectForDynamicLocation = ProximityLoader.Instance.GetProximityLoadedObjectForDynamicLocation(dynamicLocationId);
			if (proximityLoadedObjectForDynamicLocation != null)
			{
				callback(new DynamicLocationPositionRequestResult(Utility.ConvertFloatingOriginToAbsolutePosition(proximityLoadedObjectForDynamicLocation.Position), CreateStartLocationResultType.Success));
				return;
			}
			Debug.LogError("Dynamic start location '" + dynamicLocationId + "' could not be found.");
			callback(new DynamicLocationPositionRequestResult(Vector3.zero, CreateStartLocationResultType.NotFound));
		}
	}
}
