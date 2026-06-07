using System.Collections.Generic;
using UnityEngine;

public abstract class AFootstepsAudioProvider : MonoBehaviour
{
	public abstract FootstepsAudioScriptableObject Data { get; }

	public abstract Dictionary<string, FootstepsAudioScriptableObject.SurfaceType> SurfacesDictionary { get; }

	public abstract Dictionary<int, FootstepsAudioScriptableObject.SurfaceType> TerrainTextureIndexToSurfaceType { get; }

	public abstract void Play(AudioClip clip, Vector3 position, float volume, float pitch, Transform parent);

	public abstract bool IsPlayerAtWaterSurface(Vector3 footstepPosition);

	public abstract float SamplePuddle(Vector3 footstepPosition);
}
