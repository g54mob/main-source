using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LayerSFXData
{
	public LayerSFX layerSFX;

	[Range(0f, 1f)]
	public float volume = 1f;

	public List<AudioClip> audioClips = new List<AudioClip>();
}
