using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundSphere : MonoBehaviour
{
	[Serializable]
	public class Filter
	{
		public string soundId;

		[Readonly]
		public int soundIndex;

		public float centerVolume = 1f;

		public float fadeExponent = 1f;

		public float directionality = 1f;
	}

	public bool debugShowInEditor = true;

	public bool cylinder;

	public List<Filter> filters;

	[Readonly]
	public Bounds bounds;

	public void Apply(SoundRoom.Listener listener, List<SoundRoom.VolPan> volPans)
	{
		Matrix4x4 m = base.transform.worldToLocalMatrix * listener.matrix;
		if (cylinder)
		{
			m.m13 = 0f;
		}
		if (m.GetT().sqrMagnitude > 1f)
		{
			return;
		}
		float magnitude = m.GetT().magnitude;
		float num = 0f - Vector3.Dot(m.GetT().normalized, m.GetX().normalized);
		foreach (Filter filter in filters)
		{
			if (filter.soundIndex >= 0 && filter.soundIndex < volPans.Count)
			{
				SoundRoom.VolPan volPan = volPans[filter.soundIndex];
				float num2 = (1f - Mathf.Pow(magnitude, filter.fadeExponent)) * filter.centerVolume;
				float num3 = num * filter.directionality;
				volPan.vol += num2;
				volPan.pan += num2 * num3;
			}
		}
	}
}
