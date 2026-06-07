public class CheatModel : BaseModel
{
	public const string DelimitationZoneChangedEvent = "CheatModel.DelimitationZoneChangedEvent";

	private bool isWithouDelimitationZone;

	public bool IsUnbreakableCreation { get; set; }

	public bool IsUnlimitedAmmo { get; set; }

	public bool IsWithoutDelimitationZone
	{
		get
		{
			return isWithouDelimitationZone;
		}
		set
		{
			bool flag = isWithouDelimitationZone;
			isWithouDelimitationZone = value;
			if (value != flag)
			{
				NotifyChange("CheatModel.DelimitationZoneChangedEvent", value);
			}
		}
	}

	public bool IsAnyCheatEnabled
	{
		get
		{
			if (!IsUnbreakableCreation && !IsUnlimitedAmmo)
			{
				return IsWithoutDelimitationZone;
			}
			return true;
		}
	}

	public bool IsAllLevelsEnabled { get; set; }

	public CheatModel()
	{
		isWithouDelimitationZone = false;
		IsAllLevelsEnabled = false;
		ResetCheats();
	}

	public void ResetCheats()
	{
		IsUnbreakableCreation = false;
		IsUnlimitedAmmo = false;
		IsWithoutDelimitationZone = false;
	}
}
