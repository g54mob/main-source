using System.Reflection;

namespace DV.Telemetry
{
	public class TelemetryDataField
	{
		public FieldInfo field;

		public ITelemetryFieldHandler handler;

		public int columns;

		public int startingColumn;
	}
}
