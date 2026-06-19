public class GiantDrill : EntityMonoBehaviour
{
	public void Use()
	{
		Emote.SpawnEmoteText(Manager.main.player.center, Emote.EmoteType.ItsPowerRemainsSealed);
	}
}
