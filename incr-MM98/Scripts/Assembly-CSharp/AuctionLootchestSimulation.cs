using R3;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Auction Lootchest", fileName = "AuctionLootchestSimulation")]
public class AuctionLootchestSimulation : ScriptableObject, IIncrementalSimulation
{
	private DisposableBag _subscriptions;

	public void Registered(UIRegistry? registry)
	{
		_subscriptions = default(DisposableBag);
		Database.State.Auction.AvailableLootchests.Select((int x) => x < ModifierType.AuctionLootchestCapacity.Int()).Subscribe(Database.State.Auction.TimeNextLootchest, HandleLootchestTimer).AddTo(ref _subscriptions);
		(from x in Database.Modifiers.ObserveAsFloat(ModifierType.AuctionEscrowInterest)
			select x != 0f).Subscribe(Database.State.Auction.EscrowInterestInterval, HandleEscrowInterestTimer).AddTo(ref _subscriptions);
	}

	public void Unregistered()
	{
		_subscriptions.Dispose();
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		if (Database.State.Game.Launched.Value)
		{
			Lootchest(deltaTime);
			EscrowInterest(deltaTime);
		}
	}

	private void Lootchest(float deltaTime)
	{
		if (Database.State.Auction.TimeNextLootchest.AdvanceTimer(deltaTime))
		{
			Database.Commands.Auction.ReceiveLootchest();
		}
	}

	private void EscrowInterest(float deltaTime)
	{
		if (Database.State.Auction.EscrowInterestInterval.AdvanceTimer(deltaTime))
		{
			Database.Commands.Auction.EscrowInterest();
			Database.State.Auction.EscrowInterestInterval.ResetTimer();
		}
	}

	private static void HandleLootchestTimer(bool start, ReactiveProperty<TimerData> property)
	{
		if (start && property.Value.IsDone)
		{
			property.StartTimer(0f, ModifierType.AuctionLootchestDuration.Float());
		}
		else if (!start && property.Value.IsActive)
		{
			property.StopTimer();
		}
	}

	private static void HandleEscrowInterestTimer(bool start, ReactiveProperty<TimerData> property)
	{
		if (start && !property.Value.IsActive)
		{
			property.StartTimer(0f, 60f);
		}
		else if (!start && property.Value.IsActive)
		{
			property.StopTimer();
		}
	}
}
