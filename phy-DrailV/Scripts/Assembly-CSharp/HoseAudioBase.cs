using System;
using UnityEngine;

public abstract class HoseAudioBase : MonoBehaviour
{
	[NonSerialized]
	public Transform connector;

	public abstract void PlayConnectSound();

	public abstract void PlayDisconnectSound();
}
