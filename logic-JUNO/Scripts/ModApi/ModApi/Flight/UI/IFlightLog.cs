using System.Collections.Generic;
using ModApi.Craft.Parts;

namespace ModApi.Flight.UI
{
	public interface IFlightLog
	{
		IReadOnlyList<FlightLogEntry> LogEntries { get; }

		event LogEntryAddedDelegate LogEntryAdded;

		FlightLogEntry AddLog(string text, FlightLogEntryCategory category, bool isDynamic = false, IPartScript associatedPart = null);

		void LogDisconnectedPart(IPartScript part);

		void LogExplodedPart(IPartScript part);

		void LogPartDamage(IPartScript part, float damage, PartDamageType type, bool destroyed, float thresholdScale = 1f);

		void LogTotalCraftDestruction(string message);

		void UpdateLogEntry(int id, string text);
	}
}
