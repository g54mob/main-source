using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing.Logging;
using FishNet.Managing.Scened;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Example.Scened
{
	public class SceneLoaderExample : MonoBehaviour
	{
		[Tooltip("True to move the triggering object.")]
		[SerializeField]
		private bool _moveObject;

		[Tooltip("True to move all connection objects (clients).")]
		[SerializeField]
		private bool _moveAllObjects;

		[Tooltip("True to replace current scenes with new scenes. First scene loaded will become active scene.")]
		[SerializeField]
		private ReplaceOption _replaceOption;

		[Tooltip("Scenes to load.")]
		[SerializeField]
		private string[] _scenes;

		[Tooltip("True to only unload for the connectioning causing the trigger.")]
		[SerializeField]
		private bool _connectionOnly;

		[Tooltip("True to automatically unload the loaded scenes when no more connections are using them.")]
		[SerializeField]
		private bool _automaticallyUnload;

		[Tooltip("True to fire when entering the trigger. False to fire when exiting the trigger.")]
		[SerializeField]
		private bool _onTriggerEnter;

		private Dictionary<NetworkConnection, float> _triggeredTimes;

		[Server(Logging = LoggingType.Off)]
		private void OnTriggerEnter(Collider other)
		{
		}

		[Server(Logging = LoggingType.Off)]
		private void OnTriggerExit(Collider other)
		{
		}

		private void LoadScene(NetworkObject triggeringIdentity)
		{
		}
	}
}
