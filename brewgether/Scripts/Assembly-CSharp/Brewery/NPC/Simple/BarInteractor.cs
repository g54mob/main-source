using System;
using System.Runtime.CompilerServices;
using Brewery.Bar;
using Brewery.Items;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class BarInteractor
	{
		private readonly NPCContext ctx;

		private readonly INPCMotor motor;

		private readonly Action<string> spawnDrinkClientRpc;

		private readonly Action<string, BeerDataSnapshot> spawnDrinkWithMetadataClientRpc;

		private readonly Action removeDrinkClientRpc;

		private bool hasCleanedUp;

		private float lastRegistrationAttemptTime;

		private const float REGISTRATION_COOLDOWN = 2f;

		private const float BAR_INTERACTION_DISTANCE = 2.5f;

		private const float BAR_SPOT_FLOOR_TOLERANCE = 0.6f;

		private BarServingManager lastServingManager;

		private SimpleNPCController cachedController;

		private SimpleBarLocation subscribedBar;

		private string AiId => null;

		public bool IsSitting => false;

		public bool IsAtBar => false;

		public bool IsHoldingDrink => false;

		public event Action OnDrinkFinished
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public BarInteractor(NPCContext context, INPCMotor agentMotor, Action<string> spawnRpc, Action removeRpc, Action<string, BeerDataSnapshot> spawnWithMetadataRpc = null)
		{
		}

		private void Say(string trigger)
		{
		}

		public bool TryReserveSpot(SimpleBarLocation bar, SimpleNPCController controller)
		{
			return false;
		}

		public Vector3 GetBarSpotPosition()
		{
			return default(Vector3);
		}

		public Vector3 GetWarpPosition()
		{
			return default(Vector3);
		}

		public float CalculateWalkTimeout(float distance, float speed)
		{
			return 0f;
		}

		public void ArriveAtBarSpot()
		{
		}

		private void EnterSittingMode()
		{
		}

		public void ExitSittingMode()
		{
		}

		private void RegisterForServing()
		{
		}

		private void UnregisterFromServing()
		{
		}

		public void HoldDrinkWithoutDrinking(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		public void StartDrinkingHeldDrink()
		{
		}

		public void ReceiveDrink(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		public void TickDrinking()
		{
		}

		public bool ShouldLeaveBar()
		{
			return false;
		}

		public bool HasTimedOutWaiting()
		{
			return false;
		}

		private void FinishCurrentDrink()
		{
		}

		private float GetDrunkDurationSeconds()
		{
			return 0f;
		}

		private void TrySpawnEmptyBottleOnTable()
		{
		}

		private void UpdateWaveAnimation()
		{
		}

		public void WanderAroundStandingSpot()
		{
		}

		private void SpawnDrinkInHand(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		private void RemoveDrinkFromHand()
		{
		}

		public void ForceClearHeldDrink(string reason)
		{
		}

		public void DropDrink()
		{
		}

		public void CleanupBarPresence(string reason)
		{
		}

		public void ResetCleanupState()
		{
		}

		private void SubscribeToBarDestruction(SimpleBarLocation bar)
		{
		}

		private void UnsubscribeFromBarDestruction()
		{
		}

		private void OnBarDestroying(SimpleBarLocation bar)
		{
		}
	}
}
