namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionTag
	{
		private unsafe fixed byte value[100];

		internal unsafe string GetValue()
		{
			fixed (byte* bytePointer = value)
			{
				return Converters.BytePointerToString(bytePointer, 100);
			}
		}

		internal unsafe XblMultiplayerSessionTag(XGamingRuntime.XblMultiplayerSessionTag publicObject)
		{
			fixed (byte* bytePointer = value)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 100);
			}
		}
	}
}
