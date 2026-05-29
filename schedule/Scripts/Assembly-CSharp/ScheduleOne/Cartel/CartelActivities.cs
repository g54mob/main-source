using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Map;
using UnityEngine;

namespace ScheduleOne.Cartel
{
	public class CartelActivities : NetworkBehaviour
	{
		public const int MAX_COOLDOWN_HOURS = 24;

		public const int MIN_COOLDOWN_HOURS = 6;

		[Header("References")]
		public List<CartelActivity> GlobalActivities;

		public CartelRegionActivities[] RegionalActivities;

		private bool NetworkInitialize___EarlyScheduleOne_002ECartel_002ECartelActivitiesAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ECartel_002ECartelActivitiesAssembly_002DCSharp_002Edll_Excuted;

		public CartelActivity CurrentGlobalActivity { get; private set; }

		public int HoursUntilNextGlobalActivity { get; set; }

		private void Start()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public CartelRegionActivities GetRegionalActivities(EMapRegion region)
		{
			return null;
		}

		private void HourPass()
		{
		}

		private void TryStartActivity()
		{
		}

		[TargetRpc]
		[ObserversRpc(RunLocally = true)]
		private void StartGlobalActivity(NetworkConnection conn, EMapRegion region, int activityIndex)
		{
		}

		private void ActivityEnded()
		{
		}

		private bool CanNewActivityBegin()
		{
			return false;
		}

		private List<CartelActivity> GetActivitiesReadyToStart()
		{
			return null;
		}

		private List<EMapRegion> GetValidRegionsForActivity()
		{
			return null;
		}

		public static int GetNewCooldown()
		{
			return 0;
		}

		private static float GetInfluenceFraction()
		{
			return 0f;
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_StartGlobalActivity_1796582335(NetworkConnection conn, EMapRegion region, int activityIndex)
		{
		}

		private void RpcLogic___StartGlobalActivity_1796582335(NetworkConnection conn, EMapRegion region, int activityIndex)
		{
		}

		private void RpcReader___Observers_StartGlobalActivity_1796582335(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_StartGlobalActivity_1796582335(NetworkConnection conn, EMapRegion region, int activityIndex)
		{
		}

		private void RpcReader___Target_StartGlobalActivity_1796582335(PooledReader PooledReader0, Channel channel)
		{
		}

		public virtual void Awake()
		{
		}
	}
}
