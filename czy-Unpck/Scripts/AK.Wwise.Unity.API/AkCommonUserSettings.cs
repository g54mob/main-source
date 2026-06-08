using System;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class AkCommonUserSettings
{
	[Serializable]
	public class SpatialAudioSettings
	{
		[Tooltip("Maximum number of portals that sound can propagate through.")]
		[Range(0f, 8f)]
		public uint m_MaxSoundPropagationDepth = 8u;

		[Tooltip("Distance (in game units) that an emitter or listener has to move to trigger a recalculation of reflections/diffraction. Larger values can reduce the CPU load at the cost of reduced accuracy.")]
		public float m_MovementThreshold = 1f;

		[Tooltip("The number of primary rays used in stochastic ray casting.")]
		public uint m_NumberOfPrimaryRays = 100u;

		[Range(0f, 4f)]
		[Tooltip("The maximum number of reflections that will be processed for a sound path before it reaches the listener.")]
		[FormerlySerializedAs("m_ReflectionsOrder")]
		public uint m_MaxReflectionOrder = 1u;

		[Tooltip("Length of the rays that are cast inside Spatial Audio. Effectively caps the maximum length of an individual segment in a reflection or diffraction path.")]
		public float m_MaxPathLength = 10000f;

		[Tooltip("Controls the maximum percentage of an audio frame used by the raytracing engine. Percentage [0, 100] of the current audio frame. A value of 0 indicates no limit on the amount of CPU used for raytracing.")]
		public float m_CPULimitPercentage;

		[Tooltip("Enable computation of diffraction along reflection paths.")]
		[FormerlySerializedAs("m_EnableDiffraction")]
		public bool m_EnableDiffractionOnReflections = true;

		[Tooltip("Enable computation of geometric diffraction and transmission paths for all sources that have that have the \"Enable Diffraction and Transmission\" box checked in the Positioning tab of the Wwise Property Editor. This flag enables sound paths around (diffraction) and thorugh (transmission) geometry. Setting to EnableGeometricDiffractionAndTransmission to false implies that geometry is only to be used for reflection calculation. Diffraction edges must be enabled on geometry for diffraction calculation. If EnableGeometricDiffractionAndTransmission is false but a sound has \"Enable Diffraction and Transmission\" checked in the positioning tab of the authoring tool, the sound will only diffract through portals but pass through geometry as if it is not there. One would typically disable this setting if the game intends to perform its own obstruction calculation, but in the situation where geometry is still passed to spatial audio for reflection calculation.")]
		[FormerlySerializedAs("m_EnableDirectPathDiffraction")]
		public bool m_EnableGeometricDiffractionAndTransmission = true;

		[Tooltip("An emitter that is diffracted through a portal or around geometry will have its apparent or virtual position calculated by Wwise Spatial Audio and passed on to the sound engine.")]
		public bool m_CalcEmitterVirtualPosition = true;

		[Tooltip("Use the Wwise obstruction curve for modeling the effect of diffraction on a sound. Diffraction is only applied to sounds that have the \"Enable Diffraction and Transmission\" box checked in the Positioning tab of the Wwise Property Editor. Diffraction can also be applied using the diffraction built-in parameter, mapped to an RTPC (the built-in parameter is populated whether or not UseObstruction is checked). While the obstruction curve is a global setting for all sounds, using it to simulate diffraction is preferred over an RTPC, because it provides greater accuracy when modeling multiple diffraction paths, or a combination of diffraction and transmission paths. This is due to the fact that RTPCs can not be separately applied to individual sound paths. Only the path with the least amount of diffraction is sent to the RTPC.")]
		public bool m_UseObstruction = true;

		[Tooltip("Use the Wwise occlusion curve for modeling the effect of transmission loss on a sound. The transmission loss factor is applied using the occlusion curve defined in the wwise project settings. Transmission loss is only applied to sounds that have the \"Enable Diffraction and Transmission\" box checked in the Positioning tab of the Wwise Property Editor. Transmission loss can also be applied using the transmission loss built-in parameter, mapped to an RTPC (the built-in parameter is populated whether or not UseOcclusion is checked). While the occlusion curve is a global setting for all sounds, using it to simulate transmission loss is preferred over an RTPC, because it provides greater accuracy when modeling both transmission and diffraction. This is due to the fact that RTPCs can not be applied to individual sound paths, therefore any parameter mapped to a transmission loss RTPC will also affect any potential diffraction paths originating from an emitter.")]
		public bool m_UseOcclusion = true;
	}

	[Tooltip("Path for the SoundBanks. This must contain one sub folder per platform, with the same as in the Wwise project.")]
	public string m_BasePath = AkBasePathGetter.DefaultBasePath;

	[Tooltip("Language sub-folder used at startup.")]
	public string m_StartupLanguage = "English(US)";

	[Tooltip("Enable Wwise engine logging. This is used to turn on/off the logging of the Wwise engine.")]
	public bool m_EngineLogging = true;

	[Tooltip("Maximum number of automation paths for positioning sounds.")]
	public uint m_MaximumNumberOfPositioningPaths = 255u;

	[Tooltip("Size of the command queue.")]
	public uint m_CommandQueueSize = 262144u;

	[Tooltip("Number of samples per audio frame (256, 512, 1024, or 2048).")]
	public uint m_SamplesPerFrame = 1024u;

	[Tooltip("Main output device settings.")]
	public AkCommonOutputSettings m_MainOutputSettings;

	[Tooltip("Multiplication factor for all streaming look-ahead heuristic values.")]
	[Range(0f, 1f)]
	public float m_StreamingLookAheadRatio = 1f;

	[Tooltip("Sampling Rate. Default is 48000 Hz. Use 24000hz for low quality. Any positive reasonable sample rate is supported; however, be careful setting a custom value. Using an odd or really low sample rate may cause the sound engine to malfunction.")]
	public uint m_SampleRate = 48000u;

	[Tooltip("Number of refill buffers in voice buffer. Set to 2 for double-buffered, defaults to 4.")]
	public ushort m_NumberOfRefillsInVoice = 4;

	[Tooltip("Spatial audio common settings.")]
	public SpatialAudioSettings m_SpatialAudioSettings;

	protected static string GetPluginPath()
	{
		string text = Path.Combine(Application.dataPath, "Plugins" + Path.DirectorySeparatorChar);
		string text2 = "x86";
		text2 += "_64";
		if (File.Exists(Path.Combine(text, "AkSoundEngine.dll")))
		{
			return text;
		}
		if (File.Exists(Path.Combine(text, text2, "AkSoundEngine.dll")))
		{
			return Path.Combine(text, text2);
		}
		Debug.Log("Cannot find Wwise plugin path");
		return null;
	}

	public virtual void CopyTo(AkInitSettings settings)
	{
		settings.uMaxNumPaths = m_MaximumNumberOfPositioningPaths;
		settings.uCommandQueueSize = m_CommandQueueSize;
		settings.uNumSamplesPerFrame = m_SamplesPerFrame;
		m_MainOutputSettings.CopyTo(settings.settingsMainOutput);
		settings.szPluginDLLPath = GetPluginPath();
		Debug.Log("WwiseUnity: Setting Plugin DLL path to: " + ((settings.szPluginDLLPath == null) ? "NULL" : settings.szPluginDLLPath));
	}

	public void CopyTo(AkMusicSettings settings)
	{
		settings.fStreamingLookAheadRatio = m_StreamingLookAheadRatio;
	}

	public void CopyTo(AkStreamMgrSettings settings)
	{
	}

	public virtual void CopyTo(AkDeviceSettings settings)
	{
	}

	private void SetSampleRate(AkPlatformInitSettings settings)
	{
		settings.uSampleRate = m_SampleRate;
	}

	public virtual void CopyTo(AkPlatformInitSettings settings)
	{
		SetSampleRate(settings);
		settings.uNumRefillsInVoice = m_NumberOfRefillsInVoice;
	}

	public virtual void CopyTo(AkSpatialAudioInitSettings settings)
	{
		settings.uMaxSoundPropagationDepth = m_SpatialAudioSettings.m_MaxSoundPropagationDepth;
		settings.fMovementThreshold = m_SpatialAudioSettings.m_MovementThreshold;
		settings.uNumberOfPrimaryRays = m_SpatialAudioSettings.m_NumberOfPrimaryRays;
		settings.uMaxReflectionOrder = m_SpatialAudioSettings.m_MaxReflectionOrder;
		settings.fMaxPathLength = m_SpatialAudioSettings.m_MaxPathLength;
		settings.fCPULimitPercentage = m_SpatialAudioSettings.m_CPULimitPercentage;
		settings.bEnableDiffractionOnReflection = m_SpatialAudioSettings.m_EnableDiffractionOnReflections;
		settings.bEnableGeometricDiffractionAndTransmission = m_SpatialAudioSettings.m_EnableGeometricDiffractionAndTransmission;
		settings.bCalcEmitterVirtualPosition = m_SpatialAudioSettings.m_CalcEmitterVirtualPosition;
		settings.bUseObstruction = m_SpatialAudioSettings.m_UseObstruction;
		settings.bUseOcclusion = m_SpatialAudioSettings.m_UseOcclusion;
	}

	public virtual void CopyTo(AkUnityPlatformSpecificSettings settings)
	{
	}

	public virtual void Validate()
	{
		if (m_SpatialAudioSettings.m_MovementThreshold < 0f)
		{
			m_SpatialAudioSettings.m_MovementThreshold = 0f;
		}
		if (m_SpatialAudioSettings.m_MaxPathLength < 0f)
		{
			m_SpatialAudioSettings.m_MaxPathLength = 0f;
		}
		if (m_SpatialAudioSettings.m_CPULimitPercentage < 0f)
		{
			m_SpatialAudioSettings.m_CPULimitPercentage = 0f;
		}
		else if (m_SpatialAudioSettings.m_CPULimitPercentage > 100f)
		{
			m_SpatialAudioSettings.m_CPULimitPercentage = 100f;
		}
	}
}
