namespace PlayerCommand
{
	public enum DebugCommand : byte
	{
		Destroy = 0,
		FillTile = 1,
		ClearTile = 2,
		CreateEntity = 3,
		SetPlayerHunger = 4,
		ToggleEnemyBehaviour = 5,
		EnableSuperMan = 6,
		SetPlayerPosition = 7,
		SetMovementSpeedMultiplier = 8,
		SetPlayerBaseMaxHealth = 9,
		DisableSuperman = 10,
		TriggerEnvironmentEvent = 11,
		ResetEnvironmentEventCooldowns = 12,
		SetEnvironmentEventsEnabled = 13,
		SetPlayerMana = 14,
		SetAllItemsInInventoryToLevel = 15,
		RepairAll = 16,
		SetUnlimitedPlayerMana = 17,
		SetPlayerHealth = 18,
		CreateAndDropItem = 19,
		SetPlayerImmuneToDamage = 20,
		SetSkillValue = 21,
		SetPlayerState = 22,
		SetGodMode = 23,
		ConsoleCommandUsed = 24
	}
}
