using UnityEngine;

namespace CTS
{
	public abstract class GamePlatformResources : ScriptableObject
	{
		public abstract bool IsCurrentPlatform();

		public abstract IPlatformLibrary GetLibrary();

		public abstract IPlatformUser GetUser();
	}
}
