public class ShipSurveyor : BaseShipUpgrade
{
	public override ShipUpgradeType UpgradeType
	{
		get
		{
			return ShipUpgradeType.ShipSurveyor;
		}
	}

	public override bool IsPermanentUpgrade
	{
		get
		{
			return false;
		}
	}

	public override string Name
	{
		get
		{
			return "Ship Surveyor";
		}
	}

	public override string Description
	{
		get
		{
			return "Surveys ships to determine their structural layout";
		}
	}

	public override string CommandValue
	{
		get
		{
			return string.Empty;
		}
	}

	public bool HasRadiationDetectorMod
	{
		get
		{
			return (AppliedModifications & ModificationStorageIdEnum.SUSurveyorRadiation) != 0;
		}
	}

	public ShipSurveyor(int id)
		: base(id)
	{
	}

	protected override void OnInitialize()
	{
		SendConsoleResponseMessage(" ", ConsoleMessageType.Info);
		SendConsoleResponseMessage(string.Format("{0} analyzing structure layout...", Name), ConsoleMessageType.Info);
		int num = 0;
		DungeonManager instance = DungeonManager.Instance;
		Room[] rooms = instance.rooms;
		foreach (Room room in rooms)
		{
			if (!room.isExplored)
			{
				num++;
				room.ExternallyMarkAsOnSchematic();
			}
			if ((AppliedModifications & ModificationStorageIdEnum.SUSurveyorRadiation) != ModificationStorageIdEnum.None)
			{
				room.RevealRadiationOverlay();
			}
		}
		SendConsoleResponseMessage(string.Format("...found {0} rooms.", num), ConsoleMessageType.Info);
		UpgradeUsed();
	}
}
