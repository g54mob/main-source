using System;
using UnityEngine;

public abstract class WorldTimeBasedEventsProvider : MonoBehaviour
{
	public abstract bool IsWorldMoverReady { get; }

	public abstract bool IsWorldStreamingInitLoaded { get; }

	public abstract Camera ActiveCamera { get; }

	public abstract Vector3 CurrentMove { get; }

	public abstract float GetTime();

	public abstract void RegisterToLightingQualityPreferenceUpdated(Action callback);

	public abstract void UnregisterFromPreferenceUpdated(Action callback);

	public abstract int GetLightingQualityLevel();
}
