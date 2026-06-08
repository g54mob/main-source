namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionNumberAttribute
	{
		private unsafe fixed byte name[100];

		internal readonly double value;

		internal unsafe string GetName()
		{
			fixed (byte* bytePointer = name)
			{
				return Converters.BytePointerToString(bytePointer, 100);
			}
		}

		internal unsafe XblMultiplayerSessionNumberAttribute(XGamingRuntime.XblMultiplayerSessionNumberAttribute publicObject)
		{
			fixed (byte* bytePointer = name)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Name, bytePointer, 100);
			}
			value = publicObject.Value;
		}
	}
}
