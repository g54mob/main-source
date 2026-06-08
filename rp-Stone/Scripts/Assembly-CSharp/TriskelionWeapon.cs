public class TriskelionWeapon : Weapon
{
	private void HandleWeaponEquipped(Character c, Weapon w)
	{
		if (w == this && (GameStates.Singleton.CurrentState == GameStates.State.Playing || GameStates.Singleton.CurrentState == GameStates.State.PlayItemScreen))
		{
			AchievementController.singleton.ReportTriskelionStoneUsed();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Character.OnCharacterEquippedWeapon += HandleWeaponEquipped;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		Character.OnCharacterEquippedWeapon -= HandleWeaponEquipped;
	}
}
