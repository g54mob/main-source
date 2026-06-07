namespace XGamingRuntime.Interop
{
	internal struct XPackageFeature
	{
		internal readonly UTF8StringPtr id;

		internal readonly UTF8StringPtr displayName;

		internal readonly UTF8StringPtr tags;

		internal readonly NativeBool hidden;

		internal XPackageFeature(XGamingRuntime.XPackageFeature publicObject, DisposableCollection disposableCollection)
		{
			id = default(UTF8StringPtr);
			displayName = default(UTF8StringPtr);
			tags = default(UTF8StringPtr);
			hidden = default(NativeBool);
		}
	}
}
