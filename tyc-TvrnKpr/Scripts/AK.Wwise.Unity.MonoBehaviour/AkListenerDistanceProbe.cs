using UnityEngine;

[RequireComponent(typeof(AkAudioListener))]
[DisallowMultipleComponent]
[DefaultExecutionOrder(-10)]
public class AkListenerDistanceProbe : MonoBehaviour
{
	[Tooltip("Game object that is assigned as the distance probe for this listener.")]
	public AkGameObj distanceProbe;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
