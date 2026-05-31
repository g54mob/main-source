using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

namespace Photon.Realtime
{
	public class ConnectionHandler : MonoBehaviour
	{
		public bool DisconnectAfterKeepAlive;

		public int KeepAliveInBackground;

		public bool ApplyDontDestroyOnLoad;

		[NonSerialized]
		public static bool AppQuits;

		[NonSerialized]
		public static bool AppPause;

		[NonSerialized]
		public static bool AppPauseRecent;

		[NonSerialized]
		public static bool AppOutOfFocus;

		[NonSerialized]
		public static bool AppOutOfFocusRecent;

		private bool didSendAcks;

		private readonly Stopwatch backgroundStopwatch;

		private Timer stateTimer;

		public LoadBalancingClient Client { get; set; }

		public int CountSendAcksOnly { get; private set; }

		public bool FallbackThreadRunning { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void StaticReset()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public void OnApplicationQuit()
		{
		}

		public void OnApplicationPause(bool pause)
		{
		}

		private void ResetAppPauseRecent()
		{
		}

		public void OnApplicationFocus(bool focus)
		{
		}

		private void ResetAppOutOfFocusRecent()
		{
		}

		public static bool IsNetworkReachableUnity()
		{
			return false;
		}

		public void StartFallbackSendAckThread()
		{
		}

		public void StopFallbackSendAckThread()
		{
		}

		public void RealtimeFallbackInvoke()
		{
		}

		public void RealtimeFallback(object state = null)
		{
		}
	}
}
