public class AncientForge : EntityMonoBehaviour
{
	public void Use()
	{
		Emote.SpawnEmoteText(Manager.main.player.center, Emote.EmoteType.TheAncientForge);
	}
}
