using System;
using Doozy.Engine.UI.Base;

namespace Doozy.Engine.SceneManagement
{
	[Serializable]
	public class SceneLoadBehavior
	{
		public UIAction OnLoadScene;

		public UIAction OnSceneLoaded;

		public bool HasAnimatorEvents => false;

		public bool HasEffect => false;

		public bool HasGameEvents => false;

		public bool HasSound => false;

		public bool HasUnityEvents => false;

		public void Reset()
		{
		}
	}
}
