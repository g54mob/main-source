namespace XGamingRuntime.Interop
{
	internal struct XblFormattedSecureDeviceAddress
	{
		private unsafe fixed byte value[4096];

		internal unsafe string GetValue()
		{
			fixed (byte* bytePointer = value)
			{
				return Converters.BytePointerToString(bytePointer, 4096);
			}
		}
	}
}
