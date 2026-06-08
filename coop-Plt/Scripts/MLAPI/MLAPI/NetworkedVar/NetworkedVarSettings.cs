namespace MLAPI.NetworkedVar
{
	public class NetworkedVarSettings
	{
		public NetworkedVarPermission WritePermission = NetworkedVarPermission.ServerOnly;

		public NetworkedVarPermission ReadPermission;

		public NetworkedVarPermissionsDelegate WritePermissionCallback;

		public NetworkedVarPermissionsDelegate ReadPermissionCallback;

		public float SendTickrate;

		public string SendChannel = "MLAPI_DEFAULT_MESSAGE";
	}
}
