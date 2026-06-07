using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement
{
	[Serializable]
	public class ActiveSceneChangedEvent : UnityEvent<Scene, Scene>
	{
	}
}
