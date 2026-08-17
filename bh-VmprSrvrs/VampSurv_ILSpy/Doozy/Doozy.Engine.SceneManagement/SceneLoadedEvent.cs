using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement;

[Serializable]
public class SceneLoadedEvent : UnityEvent<Scene, LoadSceneMode>
{
	public SceneLoadedEvent()
	{
		_ = 0;
		base._002Ector();
	}
}
