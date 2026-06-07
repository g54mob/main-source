namespace PIEHid64Net
{
	public interface PIEDataHandler
	{
		void HandlePIEHidData(byte[] data, PIEDevice sourceDevice, int error);
	}
}
