namespace XGamingRuntime.Interop
{
	internal struct XStorePackageUpdate
	{
		private unsafe fixed byte packageIdentifier[33];

		internal readonly NativeBool isMandatory;

		internal string GetPackageIdentifier()
		{
			return null;
		}

		internal XStorePackageUpdate(XGamingRuntime.XStorePackageUpdate publicObject)
		{
			isMandatory = default(NativeBool);
		}
	}
}
