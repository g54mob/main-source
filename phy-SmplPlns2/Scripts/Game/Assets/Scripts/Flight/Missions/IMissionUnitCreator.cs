namespace Assets.Scripts.Flight.Missions
{
	public interface IMissionUnitCreator
	{
		IMissionUnit CreateMissionUnit(UnitType type, UnitFaction faction, string id, string callsign);
	}
}
