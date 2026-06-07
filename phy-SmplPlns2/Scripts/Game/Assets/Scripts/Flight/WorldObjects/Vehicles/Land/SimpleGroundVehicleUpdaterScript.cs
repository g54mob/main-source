using System;
using System.Collections.Generic;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	public class SimpleGroundVehicleUpdaterScript : MonoBehaviour
	{
		private static class Profile
		{
			public static class PostFixedUpdate
			{
				public static readonly ProfilerMarker CheckForObstructions = new ProfilerMarker("CheckForObstructions");

				public static readonly ProfilerMarker OnFixedUpdate = new ProfilerMarker("OnFixedUpdate");

				public static readonly ProfilerMarker UpdateSuspension = new ProfilerMarker("UpdateSuspension");
			}

			public static readonly ProfilerMarker CreateWheelSuspensionRaycastJob = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.CreateWheelSuspensionRaycastJob");

			public static readonly ProfilerMarker DisposeWheelSuspensionRaycastJob = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.DisposeWheelSuspensionRaycastJob");

			public static readonly ProfilerMarker OnPostFixedUpdate = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.OnPostFixedUpdate");

			public static readonly ProfilerMarker OnPreFixedUpdate = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.OnPreFixedUpdate");

			public static readonly ProfilerMarker Register = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.Register");

			public static readonly ProfilerMarker RegisterForPhysicsSimulation = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.RegisterForPhysicsSimulation");

			public static readonly ProfilerMarker Unregister = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.Unregister");

			public static readonly ProfilerMarker UnregisterForPhysicsSimulation = new ProfilerMarker("SimpleGroundVehicleUpdaterScript.UnregisterForPhysicsSimulation");

			private const string _prefix = "SimpleGroundVehicleUpdaterScript";
		}

		[SerializeField]
		private int _obstructionCheckFrameSpread = 4;

		private Queue<SimpleGroundVehicleScript> _obstructionCheckQueue;

		[SerializeField]
		private List<SimpleGroundVehicleScript> _physicsVehicles;

		[SerializeField]
		private List<SimpleGroundVehicleScript> _vehicles;

		private NativeArray<RaycastCommand> _wheelSuspensionRaycastCommands;

		private JobHandle? _wheelSuspensionRaycastJob;

		private List<SimpleWheel> _wheelSuspensionRaycastList;

		private NativeArray<RaycastHit> _wheelSuspensionRaycastResults;

		public IReadOnlyList<SimpleGroundVehicleScript> PhysicsVehicles => _physicsVehicles;

		public IReadOnlyList<SimpleGroundVehicleScript> Vehicles => _vehicles;

		public void Register(SimpleGroundVehicleScript vehicle)
		{
			using (Profile.Register.Auto())
			{
				_vehicles.Add(vehicle);
			}
		}

		public void RegisterForPhysicsSimulation(SimpleGroundVehicleScript vehicle)
		{
			using (Profile.RegisterForPhysicsSimulation.Auto())
			{
				_physicsVehicles.Add(vehicle);
				_obstructionCheckQueue.Enqueue(vehicle);
			}
		}

		public void Unregister(SimpleGroundVehicleScript vehicle)
		{
			using (Profile.Unregister.Auto())
			{
				_vehicles.Remove(vehicle);
			}
		}

		public void UnregisterForPhysicsSimulation(SimpleGroundVehicleScript vehicle)
		{
			using (Profile.UnregisterForPhysicsSimulation.Auto())
			{
				_physicsVehicles.Remove(vehicle);
				_obstructionCheckQueue.Remove(vehicle);
			}
		}

		protected virtual void Awake()
		{
			_vehicles = new List<SimpleGroundVehicleScript>();
			_physicsVehicles = new List<SimpleGroundVehicleScript>();
			_obstructionCheckQueue = new Queue<SimpleGroundVehicleScript>();
		}

		protected virtual void OnDestroy()
		{
			DisposeWheelSuspensionRaycastJob();
		}

		protected virtual void OnDisable()
		{
			GamePlayerLoop.UnregisterPreFixedUpdate(OnPreFixedUpdate);
			GamePlayerLoop.UnregisterPostFixedUpdate(OnPostFixedUpdate);
		}

		protected virtual void OnEnable()
		{
			GamePlayerLoop.RegisterPreFixedUpdate(OnPreFixedUpdate);
			GamePlayerLoop.RegisterPostFixedUpdate(OnPostFixedUpdate);
		}

		private void CreateWheelSuspensionRaycastJob()
		{
			using (Profile.CreateWheelSuspensionRaycastJob.Auto())
			{
				_wheelSuspensionRaycastList = CollectionPool<List<SimpleWheel>, SimpleWheel>.Get();
				foreach (SimpleGroundVehicleScript physicsVehicle in _physicsVehicles)
				{
					_wheelSuspensionRaycastList.AddRange(physicsVehicle.SimpleWheels);
				}
				_wheelSuspensionRaycastCommands = SimpleWheel.BuildRaycastCommands(_wheelSuspensionRaycastList);
				_wheelSuspensionRaycastResults = new NativeArray<RaycastHit>(_wheelSuspensionRaycastList.Count, Allocator.TempJob, NativeArrayOptions.UninitializedMemory);
				_wheelSuspensionRaycastJob = RaycastCommand.ScheduleBatch(_wheelSuspensionRaycastCommands, _wheelSuspensionRaycastResults, 4);
			}
		}

		private void DisposeWheelSuspensionRaycastJob()
		{
			using (Profile.DisposeWheelSuspensionRaycastJob.Auto())
			{
				if (_wheelSuspensionRaycastJob.HasValue)
				{
					_wheelSuspensionRaycastJob.Value.Complete();
					_wheelSuspensionRaycastJob = null;
				}
				if (_wheelSuspensionRaycastCommands.IsCreated)
				{
					_wheelSuspensionRaycastCommands.Dispose();
				}
				if (_wheelSuspensionRaycastResults.IsCreated)
				{
					_wheelSuspensionRaycastResults.Dispose();
				}
				if (_wheelSuspensionRaycastList != null)
				{
					CollectionPool<List<SimpleWheel>, SimpleWheel>.Release(_wheelSuspensionRaycastList);
					_wheelSuspensionRaycastList = null;
				}
			}
		}

		private unsafe void OnPostFixedUpdate()
		{
			using (Profile.OnPostFixedUpdate.Auto())
			{
				_wheelSuspensionRaycastJob.Value.Complete();
				using (Profile.PostFixedUpdate.UpdateSuspension.Auto())
				{
					void* unsafePtr = _wheelSuspensionRaycastCommands.GetUnsafePtr();
					void* unsafePtr2 = _wheelSuspensionRaycastResults.GetUnsafePtr();
					for (int i = 0; i < _wheelSuspensionRaycastList.Count; i++)
					{
						SimpleWheel simpleWheel = _wheelSuspensionRaycastList[i];
						ref RaycastCommand raycastCommand = ref UnsafeUtility.ArrayElementAsRef<RaycastCommand>(unsafePtr, i);
						ref RaycastHit raycastResult = ref UnsafeUtility.ArrayElementAsRef<RaycastHit>(unsafePtr2, i);
						try
						{
							simpleWheel.UpdateSuspension(ref raycastCommand, ref raycastResult);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
					}
				}
				DisposeWheelSuspensionRaycastJob();
				using (Profile.PostFixedUpdate.CheckForObstructions.Auto())
				{
					int num = Mathf.CeilToInt((float)_obstructionCheckQueue.Count / (float)_obstructionCheckFrameSpread);
					for (int j = 0; j < num; j++)
					{
						SimpleGroundVehicleScript simpleGroundVehicleScript = _obstructionCheckQueue.Dequeue();
						try
						{
							simpleGroundVehicleScript.CheckForObstructions();
						}
						catch (Exception exception2)
						{
							Debug.LogException(exception2);
						}
						_obstructionCheckQueue.Enqueue(simpleGroundVehicleScript);
					}
				}
				using (Profile.PostFixedUpdate.OnFixedUpdate.Auto())
				{
					foreach (SimpleGroundVehicleScript physicsVehicle in _physicsVehicles)
					{
						try
						{
							physicsVehicle.OnFixedUpdate();
						}
						catch (Exception exception3)
						{
							Debug.LogException(exception3);
						}
					}
				}
			}
		}

		private void OnPreFixedUpdate()
		{
			using (Profile.OnPreFixedUpdate.Auto())
			{
				CreateWheelSuspensionRaycastJob();
			}
		}
	}
}
