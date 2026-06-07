public interface ICalenderItem
{
	string GetTitle();

	string GetDescription();

	SDateTime? GetTime();

	ComingReleaseWindow.EventType GetEventType();

	bool MatchSWFilter(SoftwareType t, SoftwareCategory c);
}
