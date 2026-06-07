using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement
{
	[Serializable]
	public class SceneUnloadedEvent : UnityEvent<Scene>
	{
	}
}
