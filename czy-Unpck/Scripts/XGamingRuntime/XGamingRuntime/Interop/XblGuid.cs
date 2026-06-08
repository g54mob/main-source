namespace XGamingRuntime.Interop
{
	internal struct XblGuid
	{
		private unsafe fixed byte value[40];

		internal unsafe string GetValue()
		{
			fixed (byte* bytePointer = value)
			{
				return Converters.BytePointerToString(bytePointer, 40);
			}
		}

		internal unsafe XblGuid(XGamingRuntime.XblGuid publicObject)
		{
			fixed (byte* bytePointer = value)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 40);
			}
		}
	}
}
