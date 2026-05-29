using FishNet.Managing.Logging;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Example.Scened
{
	public class SceneUnloaderExample : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Scenes to unload.")]
		private string[] _scenes;

		[Tooltip("True to only unload for the connectioning causing the trigger.")]
		[SerializeField]
		private bool _connectionOnly;

		[Tooltip("True to unload unused scenes.")]
		[SerializeField]
		private bool _unloadUnused;

		[Tooltip("True to fire when entering the trigger. False to fire when exiting the trigger.")]
		[SerializeField]
		private bool _onTriggerEnter;

		[Server(Logging = LoggingType.Off)]
		private void OnTriggerEnter(Collider other)
		{
		}

		[Server(Logging = LoggingType.Off)]
		private void OnTriggerExit(Collider other)
		{
		}

		private void UnloadScenes(NetworkObject triggeringIdentity)
		{
		}
	}
}
