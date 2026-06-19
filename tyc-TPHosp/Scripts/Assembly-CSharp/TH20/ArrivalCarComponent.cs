using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ArrivalCarComponent : ArrivalBaseComponent
	{
		private static readonly ArrivalVehicleFlowControl _control = new ArrivalVehicleFlowControl();

		private static readonly List<ArrivalCarComponent> _spawnPoints = new List<ArrivalCarComponent>();

		public static bool ValidArrivalComponent(int id)
		{
			return _control.ValidComponent(id);
		}

		public static ArrivalBaseComponent GetArrivalComponent(int id)
		{
			return _control.GetComponent(id);
		}

		private void Awake()
		{
			_control.Add(this);
			_spawnPoints.Add(this);
		}

		private void OnDestroy()
		{
			_control.Remove(this);
			_spawnPoints.Remove(this);
		}

		public static bool IsAvailable()
		{
			return _spawnPoints.Count != 0;
		}

		public static bool IsSpawnPointFree()
		{
			return _control.IsSpawnPointFree();
		}

		public static int Reserve()
		{
			return _control.Reserve();
		}

		public static void Free(int id)
		{
			_control.Free(id);
		}

		public static void RestoreFromSave(int id)
		{
			_control.RestoreFromSave(id);
		}

		public static int TotalSpawnPoints()
		{
			return _spawnPoints.Count;
		}

		public static int TotalFreeSpawnPoints()
		{
			return _control.TotalFree();
		}
	}
}
