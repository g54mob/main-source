public class RepairShipVisualMod : IModification
{
	private DungeonInfo _targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.None;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Repairs a ship's schematic view";
		}
	}

	public string Description
	{
		get
		{
			return "if a ship's schematic view starts going out, this will repair it back to fully working state";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetUpgrade).Name;
		}
	}

	public int ScrapCost
	{
		get
		{
			return -20;
		}
	}

	public int MaxAllowed
	{
		get
		{
			return 1;
		}
	}

	public void SetTarget(object itemToReceiveMod)
	{
		_targetUpgrade = null;
	}

	public bool CanApplyModToTarget()
	{
		return UniverseSaveFile.Get(GlobalSettings.GameState.ThePlayer.MyShip.GroupKey, "SVVIDVFAIL", false);
	}

	public void ApplyModToTarget()
	{
		GlobalSettings.GameState.ThePlayer.MyShip.VideoFailManager = new VideoFailManager(GlobalSettings.GameState.ThePlayer.MyShip, 3000f, 7200f, 1200f, 2400f, 15f, 60f, 15f, 30f);
		UniverseSaveFile.Save("PLAYER", "MTIME", GlobalSettings.GameState.ThePlayer.MyShip.TimeInMission);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoLoss);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT_WRN", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextWarningVideoLoss);
		UniverseSaveFile.Save("PLAYER", "RESTORE_NXT", GlobalSettings.GameState.ThePlayer.MyShip.TimeOfNextVideoRestore);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT_MIN", GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMin);
		UniverseSaveFile.Save("PLAYER", "FAIL_NXT_MAX", GlobalSettings.GameState.ThePlayer.MyShip.TimeTilNextFailMax);
		UniverseSaveFile.Clear(GlobalSettings.GameState.ThePlayer.MyShip.GroupKey, "SVVIDVFAIL");
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairShipVisualMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
