using System;
using UnityEngine;
using VLB;

public abstract class VolumetricBeamControllerBase : MonoBehaviour
{
	[Serializable]
	public struct VolumetricBeamData
	{
		public VolumetricLightBeam beam;

		public float intensityOutsideMax;

		public float intensityInsideMax;
	}

	protected bool shouldBeActive;

	public abstract void ToggleActive(bool on);
}
