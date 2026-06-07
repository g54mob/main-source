using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class AkCommonUserSettings
{
	[Serializable]
	public class SpatialAudioSettings
	{
		public enum TransmissionOperation
		{
			Add = 0,
			Multiply = 1,
			Max = 2
		}

		[Tooltip("Maximum number of portals that sound can propagate through. The default value is 8.")]
		[Range(0f, 8f)]
		public uint m_MaxSoundPropagationDepth;

		[Tooltip("Distance (in game units) that an emitter or listener has to move to trigger a recalculation of reflections and diffraction. A high distance value has a lower CPU load than a low distance value, but the accuracy is also lower. Note that this value does not affect the ray tracing itself. Rays are cast each time a Spatial Audio update is executed. The default value is 0.25.")]
		public float m_MovementThreshold;

		[Tooltip("The number of primary rays used in the ray tracing engine. A larger value increases the chances of finding reflection and diffraction paths but results in higher CPU usage. When the CPU limit is active (see the CPU Limit Percentage Spatial Audio Setting), this setting represents the maximum allowed number of primary rays. The default value is 35.")]
		public uint m_NumberOfPrimaryRays;

		[Range(0f, 4f)]
		[Tooltip("The maximum reflection order: the number of \"bounces\" in a reflection path. A higher reflection order renders more detail at the expense of higher CPU usage. The default value is 2.")]
		[FormerlySerializedAs("m_ReflectionsOrder")]
		public uint m_MaxReflectionOrder;

		[Range(0f, 8f)]
		[Tooltip("Maximum diffraction order: the number of \"bends\" in a diffraction path. A high diffraction order accommodates more complex geometry at the expense of higher CPU usage. Diffraction must be enabled on the geometry to find diffraction paths. Set to 0 to disable diffraction on all geometry. This parameter limits the recursion depth of diffraction rays cast from the listener to scan the environment and also the depth of the diffraction search to find paths between emitter and listener. To optimize CPU usage, set it to the maximum number of edges you expect the obstructing geometry to traverse. The default value is 4.")]
		public uint m_MaxDiffractionOrder;

		[Range(0f, 4f)]
		[Tooltip("The maximum possible number of diffraction points at each end of a reflection path. Diffraction on reflection allows reflections to fade in and out smoothly as the listener or emitter moves in and out of the reflection's shadow zone. When greater than zero, diffraction rays are sent from the listener to search for reflections around one or more corners from the listener. Diffraction must be enabled on the geometry to find diffracted reflections. Set to 0 to disable diffraction on reflections. Set to 2 or greater to allow Reflection paths to travel through Portals. The default value is 2.")]
		public uint m_DiffractionOnReflectionsOrder;

		[Tooltip("The maximum number of game-defined auxiliary sends that can originate from a single emitter. An emitter can send to its own Room and to all adjacent Rooms if the emitter and listener are in the same Room. If a limit is set, the most prominent sends are kept, based on spread to the adjacent portal from the emitter's perspective. Set to 1 to only allow emitters to send directly to their current Room, and to the Room a listener is transitioning to if inside a portal. Set to 0 to disable the limit. The default value is 3.")]
		public uint m_MaxEmitterRoomAuxSends;

		[Tooltip("Length of the rays that are cast inside Spatial Audio. Effectively caps the maximum length of an individual segment in a reflection or diffraction path. The default value is 1000.")]
		public float m_MaxPathLength;

		[Tooltip("Defines the targeted computation time allocated for the ray tracing engine as a percentage [0, 100] of the current audio frame. The ray tracing engine dynamically adapts the number of primary rays to target the specified computation time. The computed number of primary rays cannot exceed the value specified by the Number Of Primary Rays Spatial Audio Setting. A value of 0 indicates no target has been set. In this case, the number of primary rays is fixed and is set by the Number Of Primary Rays Spatial Audio Setting. The default value is 0.")]
		public float m_CPULimitPercentage;

		[Tooltip("Enable computation of geometric diffraction and transmission paths for all sources that have the \"Diffraction and Transmission\" option selected in the Positioning tab of the Wwise Property Editor. This flag enables sound paths around (diffraction) and through (transmission) geometry. Setting EnableGeometricDiffractionAndTransmission to false implies that geometry is only to be used for reflection calculation. Diffraction edges must be enabled on geometry for diffraction calculation. If EnableGeometricDiffractionAndTransmission is false but a sound has \"Diffraction and Transmission\" selected in the Positioning tab of Wwise Authoring, the sound will diffract through portals but pass through geometry as if it isn't there. Typically, we recommend you disable this setting if the game will perform obstruction calculations, but geometry is still passed to Spatial Audio for reflection calculations. The default value is true.")]
		[FormerlySerializedAs("m_EnableDirectPathDiffraction")]
		public bool m_EnableGeometricDiffractionAndTransmission;

		[Tooltip("An emitter that is diffracted through a portal or around geometry will have its apparent or virtual position calculated by Wwise Spatial Audio and passed on to the sound engine. The default value is true.")]
		public bool m_CalcEmitterVirtualPosition;

		[Min(1f)]
		[Tooltip("The computation of spatial audio paths is spread on LoadBalancingSpread frames. Spreading the computation of paths over several frames can prevent CPU peaks. The spread introduces a delay in path computation. The default value is 1.")]
		public uint m_LoadBalancingSpread;

		[Min(0f)]
		[Tooltip("Limit the maximum number of diffraction paths computed per emitter, excluding the direct/transmission path. The acoustics engine searches for up to uMaxDiffractionPaths paths and stops searching when this limit is reached. Setting a low number for uMaxDiffractionPaths (1-4) uses fewer CPU resources, but is more likely to cause discontinuities in the resulting audio. This can occur, for example, when a more prominent path is discovered, displacing a less prominent one. Conversely, a larger number (8 or more) produces higher quality output but requires more CPU resources. The recommended range is 2-8.")]
		public uint m_MaxDiffractionPaths;

		[Min(0f)]
		[Tooltip("[\"Experimental\"] Set a global reflection path limit among all sound emitters with early reflections enabled. Potential reflection paths, discovered by raycasting, are first sorted according to a heuristic to determine which paths are the most prominent. Afterwards, the full reflection path calculation is performed on only the uMaxReflectionPaths, most prominent paths. Limiting the total number of reflection path calculations can significantly reduce CPU usage. Recommended range: 10-50. Set to 0 to disable the limit. In this case, the number of paths computed is unbounded and depends on how many are discovered by raycasting.")]
		public uint m_MaxGlobalReflectionPaths;

		[Min(0f)]
		[Tooltip("The largest possible diffraction value, in degrees, beyond which paths are not computed and are inaudible. Must be greater than zero. Default value: 180 degrees. A large value (for example, 360 degrees) allows paths to propagate further around corners and obstacles, but takes more CPU time to compute. A gain is applied to each diffraction path to taper the volume of the path to zero as the diffraction angle approaches fMaxDiffractionAngleDegrees, and appears in the Voice Inspector as 'Propagation Path Gain'. This tapering gain is applied in addition to the diffraction curves, and prevents paths from popping in or out suddenly when the maximum diffraction angle is exceeded. In Wwise Authoring, the horizontal axis of a diffraction curve in the attenuation editor is defined over the range 0-100%, corresponding to angles 0-180 degrees.  If fMaxDiffractionAngleDegrees is greater than 180 degrees, diffraction coefficients over 100% are clamped and the curve is evaluated at the rightmost point.")]
		public float m_MaxDiffractionAngleDegrees;

		[Tooltip("[\"Experimental\"]  Enable parameter smoothing on the diffraction paths output from the Acoustics Engine. Set fSmoothingConstantMs to a value greater than 0 to define the time constant (in milliseconds) for parameter smoothing. The time constant of an exponential moving average is the amount of time for the smoothed response of a unit step function to reach 1 - 1/e ~= 63.2% of the original signal. A large value (eg. 500-1000 ms) results in less variance but introduces lag, which is a good choice when using conservative values for uNumberOfPrimaryRays (eg. 5-10), uMaxDiffractionPaths (eg. 1-3) or fMovementThreshold ( > 1m ), in order to reduce overall CPU cost. A small value (eg. 10-100 ms) results in greater accuracy and faster convergence of rendering parameters. Set to 0 to disable path smoothing.")]
		public float m_SmoothingConstantMs;

		[Tooltip("The operation used to determine transmission loss on direct paths.")]
		public TransmissionOperation m_TransmissionOperation;
	}

	[Tooltip("Path for the SoundBanks. This must contain one sub folder per platform, with the same as in the Wwise project.")]
	public string m_BasePath;

	[Tooltip("Language sub-folder used at startup.")]
	public string m_StartupLanguage;

	[Tooltip("Enable Wwise engine logging. This is used to turn on/off the logging of the Wwise engine.")]
	public bool m_EngineLogging;

	[Tooltip("Whether Decoded Banks are enabled.")]
	public bool m_IsDecodedBankEnabled;

	[Tooltip("Whether Auto Bank is enabled in Wwise.")]
	public bool m_IsAutoBankEnabled;

	[Tooltip("The default value of the \"Attenuation Scaling Factor\" when an AkAudioListener is created.")]
	public float m_DefaultListenerScalingFactor;

	[Tooltip("Maximum number of automation paths for positioning sounds.")]
	public uint m_MaximumNumberOfPositioningPaths;

	[Tooltip("Size of the command queue.")]
	public uint m_CommandQueueSize;

	[Tooltip("Number of samples per audio frame (256, 512, 1024, or 2048).")]
	public uint m_SamplesPerFrame;

	[Tooltip("Main output device settings.")]
	public AkCommonOutputSettings m_MainOutputSettings;

	[Tooltip("Multiplication factor for all streaming look-ahead heuristic values.")]
	[Range(0f, 1f)]
	public float m_StreamingLookAheadRatio;

	[Tooltip("Sampling rate in Hz. The default value is 48000. Use 24000 for low quality audio. Any positive, reasonable sample rate is supported. However, very low sample rates might cause the sound engine to malfunction.")]
	public uint m_SampleRate;

	[Tooltip("Number of refill buffers in voice buffer. Set to 2 for double-buffered. The default value is to 4.")]
	public ushort m_NumberOfRefillsInVoice;

	[Tooltip("Spatial audio common settings.")]
	public SpatialAudioSettings m_SpatialAudioSettings;

	protected string GetPluginPath()
	{
		return null;
	}

	public virtual void CopyTo(AkInitSettings settings)
	{
	}

	public void CopyTo(AkMusicSettings settings)
	{
	}

	public void CopyTo(AkStreamMgrSettings settings)
	{
	}

	public virtual void CopyTo(AkDeviceSettings settings)
	{
	}

	private void SetSampleRate(AkPlatformInitSettings settings)
	{
	}

	public virtual void CopyTo(AkPlatformInitSettings settings)
	{
	}

	public virtual void CopyTo(AkSpatialAudioInitSettings settings)
	{
	}

	public virtual void Validate()
	{
	}
}
