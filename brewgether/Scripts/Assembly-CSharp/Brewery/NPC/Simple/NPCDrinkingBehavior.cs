using System;
using System.Runtime.CompilerServices;
using Brewery.Items;

namespace Brewery.NPC.Simple
{
	internal class NPCDrinkingBehavior
	{
		private readonly NPCContext ctx;

		private readonly Action<string> spawnDrinkClientRpc;

		private readonly Action removeDrinkClientRpc;

		private readonly Action<string, BeerDataSnapshot> spawnDrinkWithMetadataClientRpc;

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

		public NPCDrinkingBehavior(NPCContext context, Action<string> spawnRpc, Action removeRpc, Action<string, BeerDataSnapshot> spawnWithMetadataRpc = null)
		{
		}

		public void ReceiveDrinkFromBarman(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		public void UpdateDrinkingStateMachine()
		{
		}

		public bool ShouldLeaveBar()
		{
			return false;
		}

		public bool HasTimedOutWaitingForDrink()
		{
			return false;
		}

		public float GetWaitingTime()
		{
			return 0f;
		}

		public void UpdateWaveAnimation()
		{
		}

		private void TrySpawnEmptyBottleOnTable()
		{
		}

		private void SpawnDrinkInHand(string beverageName, BeerDataSnapshot? metadata = null)
		{
		}

		private void RemoveDrinkFromHand()
		{
		}

		public void DropDrink()
		{
		}
	}
}
