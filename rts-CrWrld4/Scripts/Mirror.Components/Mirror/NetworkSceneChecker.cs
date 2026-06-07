using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mirror
{
	[Obsolete]
	[DisallowMultipleComponent]
	public class NetworkSceneChecker : NetworkVisibility
	{
		public bool forceHidden;

		private static readonly Dictionary<Scene, HashSet<NetworkIdentity>> sceneCheckerObjects;

		private Scene currentScene;

		[ServerCallback]
		private void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStopServer()
		{
		}

		[ServerCallback]
		private void Update()
		{
		}

		private void RebuildSceneObservers()
		{
		}

		public override bool OnCheckObserver(NetworkConnection conn)
		{
			return false;
		}

		public override void OnRebuildObservers(HashSet<NetworkConnection> observers, bool initialize)
		{
		}

		private void MirrorProcessed()
		{
		}
	}
}
