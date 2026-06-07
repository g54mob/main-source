using UnityEngine;

namespace Oculus.Platform
{
	public static class CloudStorage2
	{
		public static Request<string> GetUserDirectoryPath()
		{
			if (Core.IsInitialized())
			{
				return new Request<string>(CAPI.ovr_CloudStorage2_GetUserDirectoryPath());
			}
			Debug.LogError(Core.PlatformUninitializedError);
			return null;
		}
	}
}
