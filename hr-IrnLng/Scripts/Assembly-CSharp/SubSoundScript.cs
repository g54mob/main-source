using UnityEngine;

public class SubSoundScript : MonoBehaviour
{
	public Vector2 PitchRange;

	public Vector2 VolumeRange;

	public float CurrentIndex;

	private AudioSource Aud;

	private void Start()
	{
		Aud = GetComponent<AudioSource>();
	}

	private void Update()
	{
		Aud.pitch = Mathf.Lerp(PitchRange.x, PitchRange.y, CurrentIndex);
		Aud.volume = Mathf.Lerp(VolumeRange.x, VolumeRange.y, CurrentIndex);
	}

	public void SetIndex(float i)
	{
		CurrentIndex = i;
	}
}
