using System.Collections.Generic;
using UnityEngine;

public abstract class AkObstructionOcclusion : MonoBehaviour
{
	protected class ObstructionOcclusionValue
	{
		public float currentValue;

		public float targetValue;

		public bool Update(float fadeRate)
		{
			return false;
		}
	}

	private readonly List<AkAudioListener> listenersToRemove;

	protected readonly List<AkAudioListener> currentListenerList;

	private readonly Dictionary<AkAudioListener, ObstructionOcclusionValue> ObstructionOcclusionValues;

	protected float fadeRate;

	[Tooltip("Fade time in seconds")]
	public float fadeTime;

	[Tooltip("Layers of obstructers/occluders")]
	public LayerMask LayerMask;

	[Tooltip("Maximum distance to perform the obstruction/occlusion. Negative values mean infinite")]
	public float maxDistance;

	[Tooltip("The number of seconds between raycasts")]
	public float refreshInterval;

	private float refreshTime;

	protected void InitIntervalsAndFadeRates()
	{
	}

	protected abstract void UpdateCurrentListenerList();

	private void UpdateObstructionOcclusionValues()
	{
	}

	private void CastRays()
	{
	}

	protected abstract void SetObstructionOcclusion(KeyValuePair<AkAudioListener, ObstructionOcclusionValue> ObsOccPair);

	private void Update()
	{
	}
}
