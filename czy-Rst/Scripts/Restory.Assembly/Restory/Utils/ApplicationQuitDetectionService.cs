using System;
using UnityEngine;

namespace Restory.Utils
{
	public class ApplicationQuitDetectionService : MonoBehaviour
	{
		public bool IsInQuit { get; private set; }

		public event Action OnStartQuit;

		public event Action OnEndQuit;

		private void OnApplicationQuit()
		{
			IsInQuit = true;
			this.OnStartQuit?.Invoke();
			Debug.Log("[ApplicationQuitDetectionService] application quit started");
			this.OnEndQuit?.Invoke();
			Debug.Log("[ApplicationQuitDetectionService] application quit ended");
		}

		private void OnDisable()
		{
			Debug.Log("[ApplicationQuitDetectionService] OnDisable");
		}

		private void OnDestroy()
		{
			Debug.Log("[ApplicationQuitDetectionService] OnDestroy");
		}
	}
}
