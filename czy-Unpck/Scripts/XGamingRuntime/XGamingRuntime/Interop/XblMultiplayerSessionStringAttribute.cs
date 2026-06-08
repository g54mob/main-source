namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerSessionStringAttribute
	{
		private unsafe fixed byte name[100];

		private unsafe fixed byte value[100];

		internal unsafe string GetName()
		{
			fixed (byte* bytePointer = name)
			{
				return Converters.BytePointerToString(bytePointer, 100);
			}
		}

		internal unsafe string GetValue()
		{
			fixed (byte* bytePointer = value)
			{
				return Converters.BytePointerToString(bytePointer, 100);
			}
		}

		internal unsafe XblMultiplayerSessionStringAttribute(XGamingRuntime.XblMultiplayerSessionStringAttribute publicObject)
		{
			fixed (byte* bytePointer = name)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Name, bytePointer, 100);
			}
			fixed (byte* bytePointer2 = value)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer2, 100);
			}
		}
	}
}
