using System;
using UnityEngine;

[Serializable]
public class PerformanceDeviceProfile
{
	[field: Header("Visual Settings")]
	[field: Tooltip("The Unity quality level to use for this platform configuration.")]
	[field: SerializeField]
	public string OverallQualityLevel { get; private set; } = "Radical";

	[field: SerializeField]
	public ShadowResolution ShadowQuality { get; private set; } = ShadowResolution.Medium;

	[field: Range(0f, 2f)]
	[field: SerializeField]
	public int ObjectShadows { get; private set; } = 2;

	[field: Range(0f, 2f)]
	[field: SerializeField]
	public int DynamicWater { get; private set; } = 2;

	[field: Range(0f, 2f)]
	[field: SerializeField]
	public int SsaoQuality { get; private set; } = 2;

	[field: SerializeField]
	public bool Reflections { get; private set; } = true;

	[field: Range(0f, 2f)]
	[field: SerializeField]
	public int Bloom { get; private set; } = 2;

	[field: SerializeField]
	public PugLightQuality LightQuality { get; private set; } = PugLightQuality.High;

	[field: SerializeField]
	public PugParticleQuality ParticleQuality { get; private set; } = PugParticleQuality.Medium;

	[field: Header("Audio Settings")]
	[field: Range(0f, 1f)]
	[field: SerializeField]
	public float SfxVolume { get; private set; } = 0.5f;

	[field: Range(0f, 1f)]
	[field: SerializeField]
	public float MusicVolume { get; private set; } = 0.5f;

	[field: Range(0f, 1f)]
	[field: SerializeField]
	public float AmbientSfxVolume { get; private set; } = 0.5f;

	[field: Range(0f, 1f)]
	[field: SerializeField]
	public float InstrumentVolume { get; private set; } = 0.5f;

	[field: Header("Other Settings")]
	[field: Range(0f, 2f)]
	[field: SerializeField]
	public int VsyncCount { get; private set; } = 1;

	[field: SerializeField]
	public int MaxQueuedFrames { get; private set; } = 2;

	[field: Range(-1f, 120f)]
	[field: SerializeField]
	public int TargetFrameRate { get; private set; } = -1;

	[field: Range(0f, 1f)]
	[field: SerializeField]
	[field: Tooltip("Sets the virtual volume that an ambient track needs to exceed in order for its audio asset to be loaded and start playing. See AmbiendSoundsHandler for reference. Should always be higher than the unload threshold!\n\nA tiny difference between this and the unload threshold means that the ambience assets will be loaded and unloaded constantly, and will cause more tracks to play at the same time which will have a performance hit on weaker devices.")]
	public float AmbienceAssetLoadThreshold { get; private set; } = 0.02f;

	[field: Range(0f, 1f)]
	[field: SerializeField]
	[field: Tooltip("Sets the virtual volume that an ambient track needs to fall under in order for its audio asset to be unloaded. See AmbiendSoundsHandler for reference. Should always be lower than the load threshold!\n\nA tiny difference between this and the load threshold means that the ambience assets will be loaded and unloaded constantly, and will cause more tracks to play at the same time which will have a performance hit on weaker devices.")]
	public float AmbienceAssetUnloadThreshold { get; private set; } = 0.01f;
}
