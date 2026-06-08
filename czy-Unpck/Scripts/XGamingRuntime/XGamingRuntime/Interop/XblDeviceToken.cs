namespace XGamingRuntime.Interop
{
	internal struct XblDeviceToken
	{
		private unsafe fixed byte Value[40];

		internal unsafe string GetValue()
		{
			fixed (byte* value = Value)
			{
				return Converters.BytePointerToString(value, 40);
			}
		}

		internal unsafe XblDeviceToken(XGamingRuntime.XblDeviceToken publicObject)
		{
			fixed (byte* value = Value)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, value, 40);
			}
		}
	}
}
