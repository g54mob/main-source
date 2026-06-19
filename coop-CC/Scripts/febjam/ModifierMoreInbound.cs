using Aggro.Core;
using Mirror;
using UnityEngine;

public class ModifierMoreInbound : ModifierBase
{
	[Min(1f)]
	public float inboundCountMultiplier = 2f;

	public DeckCard<GameObject>[] inboundCards;

	private Deck<GameObject> _serverDeck;

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			int seed = Hash.Calculate(GameUtil.seed, Hash.Calculate(GetType()));
			_serverDeck = new Deck<GameObject>(seed);
			_serverDeck.AddCards(inboundCards);
			_serverDeck.Shuffle();
		}
	}

	[Server]
	public GameObject ServerGetInboundPrefab()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'UnityEngine.GameObject ModifierMoreInbound::ServerGetInboundPrefab()' called when server was not active");
			return null;
		}
		return _serverDeck.DrawCard();
	}

	public override bool Weaved()
	{
		return true;
	}
}
