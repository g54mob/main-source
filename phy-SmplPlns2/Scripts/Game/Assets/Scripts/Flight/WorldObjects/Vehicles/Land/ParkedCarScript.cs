using System;
using System.Collections;
using System.Linq;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class ParkedCarScript : MonoBehaviour, IRandomSpawnHandler
	{
		private NetworkedAreaBodyScript _body;

		private NetworkFlightObjectDamageReceiverScript _damageReceiver;

		[SerializeField]
		private GameObject _fireParticlesPrefab;

		[SerializeField]
		private Material[] _materialsWithoutEmission;

		[SerializeField]
		private GameObject _smokeParticlesPrefab;

		private VehicleList _vehicleList;

		[SerializeField]
		private VehicleListData _vehicleListData;

		public void OnSpawned(System.Random random, int spawnIndex, byte? networkedAreaItemId)
		{
			_vehicleList = new VehicleList(_vehicleListData);
			int randomVehicleIndex = _vehicleList.GetRandomVehicleIndex((float)random.NextDouble());
			if (randomVehicleIndex < 0)
			{
				return;
			}
			NetworkedAreaScript componentInParent = GetComponentInParent<NetworkedAreaScript>();
			if (componentInParent == null)
			{
				Debug.LogError("Parked car '" + base.name + "' could not find its networked area.", base.gameObject);
				return;
			}
			if (!networkedAreaItemId.HasValue)
			{
				networkedAreaItemId = componentInParent.AsyncRegistrationBegin();
			}
			SpawnCar(randomVehicleIndex, (float)random.NextDouble(), componentInParent, networkedAreaItemId.Value).Forget();
		}

		public async UniTaskVoid SpawnCar(int carType, float colorValue, NetworkedAreaScript networkedArea, byte networkedAreaItemId)
		{
			_body = GetComponent<NetworkedAreaBodyScript>();
			_body.Body.isKinematic = true;
			GameObject gameObject = (await UnityEngine.Object.InstantiateAsync(_vehicleListData.vehicles[carType].prefab, base.transform))?.FirstOrDefault();
			if (!(this == null) && !(gameObject == null))
			{
				gameObject.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				LayerUtility.SetLayerRecursive(base.gameObject, base.gameObject.layer);
				VehicleInfoScript componentInChildren = base.gameObject.GetComponentInChildren<VehicleInfoScript>(includeInactive: true);
				Rigidbody component = GetComponent<Rigidbody>();
				SimpleGroundVehicleScript simpleGroundVehicleScript = componentInChildren.CreateDrivingCar(component, _smokeParticlesPrefab, _fireParticlesPrefab, colorValue, FlightSceneScript.Instance.CarSpawner.CarLightDisabledMaterials);
				simpleGroundVehicleScript.VehicleDestroyed += OnVehicleDestroyed;
				_damageReceiver = simpleGroundVehicleScript.InitializeDamgeReceiver();
				simpleGroundVehicleScript.EnableWheelPhysics = false;
				networkedArea.AsyncRegistrationComplete(_body, networkedAreaItemId);
				_body.Body.isKinematic = false;
				_body.Area.FlightObjectLoaded += OnAreaFlightObjectLoaded;
				_body.Area.FlightObjectUnloaded += OnAreaFlightObjectUnloaded;
				if (_body.Area.IsFlightObjectLoaded)
				{
					OnAreaFlightObjectLoaded(networkedArea.NetworkFlightObject);
				}
			}
		}

		private void OnAreaFlightObjectLoaded(NetworkFlightObject obj)
		{
			NetworkFlightObjectDamageScript component = obj.GetComponent<NetworkFlightObjectDamageScript>();
			if (_body.DamageReceiverId.HasValue)
			{
				_damageReceiver.Initialize(_body.DamageReceiverId.Value, component);
			}
			else
			{
				Debug.LogError("NetworkedAreaItem was not configured to request a damage receiver ID", base.gameObject);
			}
		}

		private void OnAreaFlightObjectUnloaded(NetworkFlightObject obj)
		{
			if (_damageReceiver.IsInitialized)
			{
				_damageReceiver.Uninitialize();
			}
		}

		private void OnVehicleDestroyed(SimpleGroundVehicleScript vehicle)
		{
			StartCoroutine(RemoveVehicle(15f));
		}

		private IEnumerator RemoveVehicle(float time)
		{
			yield return new WaitForSeconds(time);
			if (_body?.Area?.IsOwner == true)
			{
				_body.IsActive = false;
			}
		}
	}
}
