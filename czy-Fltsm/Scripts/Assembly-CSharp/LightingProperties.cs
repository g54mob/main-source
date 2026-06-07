using System;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public class LightingProperties
{
	public LightProbeUsage LightProbes;

	public ReflectionProbeUsage ReflectionProbes;

	public Transform AnchorOverride;

	public ShadowCastingMode CastShadows;

	public bool ReceiveShadows;

	public MotionVectorGenerationMode MotionVectors;

	public bool LightmapStatic;
}
