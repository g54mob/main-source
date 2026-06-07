using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkSpatialAudioListener")]
[RequireComponent(typeof(AkAudioListener))]
[RequireComponent(typeof(AkRoomAwareObject))]
[DisallowMultipleComponent]
public class AkSpatialAudioListener : MonoBehaviour
{
	public class SpatialAudioListenerList
	{
		private readonly List<AkSpatialAudioListener> listenerList;

		public List<AkSpatialAudioListener> ListenerList => null;

		public bool Add(AkSpatialAudioListener listener)
		{
			return false;
		}

		public bool Remove(AkSpatialAudioListener listener)
		{
			return false;
		}

		private void Refresh()
		{
		}
	}

	private static AkSpatialAudioListener s_SpatialAudioListener;

	private static readonly SpatialAudioListenerList spatialAudioListeners;

	private AkAudioListener AkAudioListener;

	public static AkAudioListener TheSpatialAudioListener => null;

	public static SpatialAudioListenerList SpatialAudioListeners => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
