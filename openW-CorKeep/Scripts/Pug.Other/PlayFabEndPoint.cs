using System;
using PlayFab.Party;

public class PlayFabEndPoint
{
	public readonly ulong Id;

	public readonly PlayFabPlayer Player;

	public PlayFabEndPoint(PlayFabPlayer player)
	{
		Player = player;
		Id = Convert.ToUInt64(player.EntityKey.Id, 16);
	}
}
