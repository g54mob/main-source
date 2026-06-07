namespace PIEHid64Net
{
	public interface PIEErrorHandler
	{
		void HandlePIEHidError(PIEDevice sourceDevices, long error);
	}
}
