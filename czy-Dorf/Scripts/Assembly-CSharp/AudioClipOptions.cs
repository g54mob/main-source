using UnityEngine;

public class AudioClipOptions : ScriptableObject
{
	public AudioClip audioClip;

	public Vector2 randomPitch = new Vector2(1f, 1f);

	public float volume = 0.5f;

	public float spatialBlend;

	public bool looping;

	public float dopplerLevel;

	public bool useCustom3DSettings;

	public AudioRolloffMode rolloffMode;

	public float minDistance;

	public float maxDistance;

	public bool useCustomCurves;

	public AudioCurveSettings[] audioCurves;
}
