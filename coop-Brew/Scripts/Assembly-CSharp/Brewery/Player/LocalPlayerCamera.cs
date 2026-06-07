using System;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

namespace Brewery.Player
{
	public class LocalPlayerCamera : MonoBehaviour
	{
		private Camera _camera;

		private NetworkObject _parentNetworkObject;

		private bool _isInitialized;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		public static Camera Camera { get; private set; }

		public static LocalPlayerCamera Instance { get; private set; }

		public static event Action<Camera> OnRegistered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action OnUnregistered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void TryInitialize()
		{
		}

		private void OnDestroy()
		{
		}

		public void ForceRegister()
		{
		}

		private void Register()
		{
		}

		private void Unregister()
		{
		}
	}
}
