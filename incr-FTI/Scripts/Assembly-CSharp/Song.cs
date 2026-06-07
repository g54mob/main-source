using UnityEngine;

[CreateAssetMenu(fileName = "Song")]
public class Song : ScriptableObject
{
	public AudioClip clip;

	public float volumeAdjustment;

	public bool bypass;

	public bool onlyPlayOnAdvancedTowns;
}
