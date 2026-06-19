using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalsManager : MustCallDestroy
	{
		public struct PendingArrival
		{
			public ArrivalMethodDefinition Definition;

			public IArrivedCallback Callback;

			public int ArrivalPriority
			{
				get
				{
					if (Callback != null)
					{
						return Callback.GetArrivalPriority();
					}
					return 0;
				}
			}
		}

		private readonly Level _level;

		private readonly List<ArrivalMethod> _arrivals;

		private readonly List<PendingArrival> _pendingArrivals;

		public List<ArrivalMethod> Arrivals => _arrivals;

		public List<PendingArrival> PendingArrivals => _pendingArrivals;

		public ArrivalsManager(Level level)
		{
			_level = level;
			_arrivals = new List<ArrivalMethod>();
			_pendingArrivals = new List<PendingArrival>();
		}

		public void Add(ArrivalMethodDefinition methodDefinition, IArrivedCallback callback)
		{
			if (!methodDefinition.IsAvailable())
			{
				methodDefinition = _level.CharacterManager.GetDefaultArrivalMethod();
			}
			if (methodDefinition is ArrivalMethodVehicleDefinition vehicleDefinition && TryAddPassengerToExistingVehicle(vehicleDefinition, callback))
			{
				return;
			}
			if (methodDefinition.IsSpawnPointFree())
			{
				_arrivals.Add(methodDefinition.Create(_level, callback));
				return;
			}
			_pendingArrivals.Add(new PendingArrival
			{
				Definition = methodDefinition,
				Callback = callback
			});
			_pendingArrivals.Sort((PendingArrival arrival1, PendingArrival arrival2) => arrival2.ArrivalPriority.CompareTo(arrival1.ArrivalPriority));
		}

		public void Update()
		{
			_arrivals.RemoveAll(delegate(ArrivalMethod method)
			{
				if (!method.Update())
				{
					return false;
				}
				method.Destroy();
				return true;
			});
			PendingArrival[] array = _pendingArrivals.ToArray();
			for (int num = 0; num < array.Length; num++)
			{
				PendingArrival item = array[num];
				ArrivalMethodVehicleDefinition arrivalMethodVehicleDefinition = item.Definition as ArrivalMethodVehicleDefinition;
				if (!item.Definition.IsAvailable())
				{
					item.Callback.OnFailed();
					_pendingArrivals.Remove(item);
				}
				else if (arrivalMethodVehicleDefinition != null && TryAddPassengerToExistingVehicle(arrivalMethodVehicleDefinition, item.Callback))
				{
					_pendingArrivals.Remove(item);
				}
				else if (item.Definition.IsSpawnPointFree())
				{
					_arrivals.Add(item.Definition.Create(_level, item.Callback));
					_pendingArrivals.Remove(item);
				}
			}
		}

		private bool TryAddPassengerToExistingVehicle(ArrivalMethodVehicleDefinition vehicleDefinition, IArrivedCallback callback)
		{
			foreach (ArrivalMethod arrival in _arrivals)
			{
				if (arrival is ArrivalMethodVehicle arrivalMethodVehicle && arrivalMethodVehicle.Definition == vehicleDefinition && !arrivalMethodVehicle.IsAtMaxCapacity())
				{
					arrivalMethodVehicle.AddPassenger(callback);
					return true;
				}
			}
			return false;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			ArrivalMethod[] array = _arrivals.ToArray();
			foreach (ArrivalMethod arrival in array)
			{
				if (arrival.IsValid())
				{
					arrival.RestoreFromSave();
					continue;
				}
				Level level = _level;
				level.PostConstruct = (Action)Delegate.Combine(level.PostConstruct, (Action)delegate
				{
					arrival.OnFail();
					arrival.Destroy();
					_arrivals.Remove(arrival);
				});
			}
			Level level2 = _level;
			level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, (Action)delegate
			{
				PendingArrival[] array2 = _pendingArrivals.ToArray();
				for (int j = 0; j < array2.Length; j++)
				{
					PendingArrival item = array2[j];
					if (!item.Callback.IsValid())
					{
						item.Callback.OnFailed();
						_pendingArrivals.Remove(item);
					}
				}
			});
		}

		public override void Destroy()
		{
			_arrivals.ClearAndCallDestroy();
			base.Destroy();
		}

		public void CancelPatientArrivals(IPatientSpawned patientSpawned)
		{
			for (int num = _pendingArrivals.Count - 1; num >= 0; num--)
			{
				PendingArrival item = _pendingArrivals[num];
				if (item.Callback.HasPatientSpawnedCallback(patientSpawned))
				{
					_pendingArrivals.Remove(item);
				}
			}
		}

		public bool IsArriving(Character character)
		{
			foreach (ArrivalMethod arrival in _arrivals)
			{
				if (arrival.IsArriving(character))
				{
					return true;
				}
			}
			return false;
		}
	}
}
