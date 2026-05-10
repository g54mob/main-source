namespace FishNet.Object.Helping
{
	public static class CodegenHelper
	{
		public static bool NetworkObject_Deinitializing(NetworkBehaviour nb)
		{
			return false;
		}

		public static bool IsServer(NetworkBehaviour nb)
		{
			return false;
		}

		public static bool IsClient(NetworkBehaviour nb)
		{
			return false;
		}
	}
}
