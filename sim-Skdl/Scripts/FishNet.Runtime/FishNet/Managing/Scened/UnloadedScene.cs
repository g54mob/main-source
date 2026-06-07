using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
	public struct UnloadedScene
	{
		public readonly string Name;

		public readonly int Handle;

		public UnloadedScene(Scene s)
		{
			Name = null;
			Handle = 0;
		}

		public UnloadedScene(string name, int handle)
		{
			Name = null;
			Handle = 0;
		}
	}
}
