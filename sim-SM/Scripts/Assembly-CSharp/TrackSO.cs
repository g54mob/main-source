using UnityEngine;

[CreateAssetMenu(fileName = "TrackSO", menuName = "Scriptable Objects/Audio")]
public class TrackSO : ScriptableObject
{
	public AudioClip trackAudioClip;

	public Sprite trackArt;

	public float trackLength;

	private void OnValidate()
	{
	}
}
