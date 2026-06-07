using System;

namespace DV.Telemetry
{
	public interface ITelemetryFieldHandler
	{
		int ColumnCount { get; }

		bool CanAccept(Type t);

		string GetColumnName(int index);

		string GetColumnData(object data, int column);
	}
}
