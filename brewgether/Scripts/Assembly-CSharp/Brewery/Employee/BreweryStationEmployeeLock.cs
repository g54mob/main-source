using Brewery.Stations;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Employee
{
	[RequireComponent(typeof(BaseBreweryStation))]
	public class BreweryStationEmployeeLock : NetworkBehaviour
	{
		private const string TAG = "BREW_EMP|LOCK";

		public const ulong NO_EMPLOYEE = 0uL;

		private const ulong EMPLOYEE_SENTINEL_CLIENT_ID = 18446744073709551614uL;

		private readonly NetworkVariable<ulong> employeeClaimant;

		private BaseBreweryStation station;

		public bool IsClaimedByEmployee => false;

		public ulong ClaimantEmployeeId => 0uL;

		private void Awake()
		{
		}

		public bool TryClaimForEmployee(ulong employeeNetworkObjectId)
		{
			return false;
		}

		public void ReleaseForEmployee(ulong employeeNetworkObjectId)
		{
		}

		public void ForceRelease()
		{
		}

		public bool IsClaimedBy(ulong employeeNetworkObjectId)
		{
			return false;
		}

		public bool CleanupIfStale()
		{
			return false;
		}

		protected override void __initializeVariables()
		{
		}

		protected override void __initializeRpcs()
		{
		}

		protected internal override string __getTypeName()
		{
			return null;
		}
	}
}
