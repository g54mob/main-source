using System;
using Aggro.Core;
using Aggro.Core.Networking;
using UnityEngine;

public class ModifierBoxes : ModifierBase
{
	public ShiftOrderObject order;

	[Min(1f)]
	public int cardCountChange = 2;

	[Min(0f)]
	public int cardCountNoChange = 6;

	private Deck<bool> _serverDeck;

	protected override void OnEntityCreated()
	{
		NetworkAggroManagerBase<WarehouseManager>.instance.AddToOrders(order);
		if (base.isServer)
		{
			_serverDeck = new Deck<bool>(GetSeed());
			_serverDeck.AddCard(card: true, cardCountChange);
			_serverDeck.AddCard(card: false, cardCountNoChange);
			_serverDeck.Shuffle();
		}
	}

	public override bool Evaluate()
	{
		if (GameUtil.isGym)
		{
			return true;
		}
		if (order != null)
		{
			return Array.IndexOf(GameUtil.orders, order) < 0;
		}
		return false;
	}

	public bool TryReplaceOrder(out ShiftOrderObject replace)
	{
		if (_serverDeck.DrawCard())
		{
			replace = order;
			return true;
		}
		replace = null;
		return false;
	}

	public override bool Weaved()
	{
		return true;
	}
}
