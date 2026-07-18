using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildFinishInstance
{
	public List<BuildFinishComponent> buildFinishComponents;

	public float timeBetweenSeparateTiles;

	public AudioClip soundEffect;
}
