namespace XGamingRuntime.Interop
{
	public struct XblMultiplayerSessionMemberRole
	{
		internal readonly UTF8StringPtr roleTypeName;

		internal readonly UTF8StringPtr roleName;

		internal XblMultiplayerSessionMemberRole(XGamingRuntime.XblMultiplayerSessionMemberRole publicObject, DisposableCollection disposableCollection)
		{
			roleTypeName = default(UTF8StringPtr);
			roleName = default(UTF8StringPtr);
		}
	}
}
