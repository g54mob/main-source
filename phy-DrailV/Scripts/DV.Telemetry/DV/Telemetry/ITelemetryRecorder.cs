namespace DV.Telemetry
{
	public interface ITelemetryRecorder
	{
		void RecordTelemetry();

		void SaveTelemetry(string prefix = "");

		void ReleaseTelemetryBuffers();
	}
}
