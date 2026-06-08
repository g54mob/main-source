namespace XGamingRuntime.Interop
{
	internal struct XStorePackageUpdate
	{
		private unsafe fixed byte packageIdentifier[33];

		internal readonly NativeBool isMandatory;

		internal unsafe string GetPackageIdentifier()
		{
			fixed (byte* bytePointer = packageIdentifier)
			{
				return Converters.BytePointerToString(bytePointer, 33);
			}
		}

		internal unsafe XStorePackageUpdate(XGamingRuntime.XStorePackageUpdate publicObject)
		{
			fixed (byte* bytePointer = packageIdentifier)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.PackageIdentifier, bytePointer, 33);
			}
			isMandatory = new NativeBool(publicObject.IsMandatory);
		}
	}
}
