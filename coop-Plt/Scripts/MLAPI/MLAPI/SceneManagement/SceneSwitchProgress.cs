using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace MLAPI.SceneManagement
{
	public class SceneSwitchProgress
	{
		public delegate void OnCompletedDelegate(bool timedOut);

		public delegate void OnClientLoadedSceneDelegate(ulong clientId);

		private Coroutine timeOutCoroutine;

		private UnityEngine.AsyncOperation sceneLoadOperation;

		public List<ulong> DoneClients { get; } = new List<ulong>();

		public float TimeAtInitiation { get; } = NetworkingManager.Singleton.NetworkTime;

		public bool IsCompleted { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsCompleted instead", false)]
		public bool isCompleted => IsCompleted;

		public bool IsAllClientsDoneLoading { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsCompleted instead", false)]
		public bool isAllClientsDoneLoading => IsAllClientsDoneLoading;

		internal Guid guid { get; } = Guid.NewGuid();

		public event OnCompletedDelegate OnComplete;

		public event OnClientLoadedSceneDelegate OnClientLoadedScene;

		internal SceneSwitchProgress()
		{
			timeOutCoroutine = NetworkingManager.Singleton.StartCoroutine(NetworkingManager.Singleton.TimeOutSwitchSceneProgress(this));
		}

		internal void AddClientAsDone(ulong clientId)
		{
			DoneClients.Add(clientId);
			if (this.OnClientLoadedScene != null)
			{
				this.OnClientLoadedScene(clientId);
			}
			CheckCompletion();
		}

		internal void RemoveClientAsDone(ulong clientId)
		{
			DoneClients.Remove(clientId);
			CheckCompletion();
		}

		internal void SetSceneLoadOperation(UnityEngine.AsyncOperation sceneLoadOperation)
		{
			this.sceneLoadOperation = sceneLoadOperation;
			this.sceneLoadOperation.completed += delegate
			{
				CheckCompletion();
			};
		}

		internal void CheckCompletion()
		{
			if (!IsCompleted && DoneClients.Count == NetworkingManager.Singleton.ConnectedClientsList.Count && sceneLoadOperation.isDone)
			{
				IsCompleted = true;
				IsAllClientsDoneLoading = true;
				NetworkSceneManager.sceneSwitchProgresses.Remove(guid);
				if (this.OnComplete != null)
				{
					this.OnComplete(timedOut: false);
				}
				NetworkingManager.Singleton.StopCoroutine(timeOutCoroutine);
			}
		}

		internal void SetTimedOut()
		{
			if (!IsCompleted)
			{
				IsCompleted = true;
				NetworkSceneManager.sceneSwitchProgresses.Remove(guid);
				if (this.OnComplete != null)
				{
					this.OnComplete(timedOut: true);
				}
			}
		}
	}
}
