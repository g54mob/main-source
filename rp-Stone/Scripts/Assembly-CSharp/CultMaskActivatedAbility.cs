public class CultMaskActivatedAbility : WeaponActivatedAbility
{
	public override bool IsAvailable()
	{
		Data.Quest questData = GameStates.Singleton.level.QuestData;
		if (questData != null && !questData.id.StartsWith("nagaraja"))
		{
			return !questData.id.StartsWith("initiate");
		}
		return false;
	}
}
