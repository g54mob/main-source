using DV.DopplerEffects;
using UnityEngine;

public class AudioReferences
{
	public AudioSource source;

	public Doppler doppler;

	public AudioReferences(AudioSource source, Doppler doppler)
	{
		this.source = source;
		this.doppler = doppler;
	}
}
