namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionReferenceUri
	{
		private unsafe fixed byte value[284];

		internal unsafe string GetValue()
		{
			fixed (byte* bytePointer = value)
			{
				return Converters.BytePointerToString(bytePointer, 284);
			}
		}

		internal unsafe XblMultiplayerSessionReferenceUri(XGamingRuntime.XblMultiplayerSessionReferenceUri publicObject)
		{
			fixed (byte* bytePointer = value)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 284);
			}
		}
	}
}
