using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public class DynamicSoundGroup : MonoBehaviour
	{
		public GameObject variationTemplate;

		public bool alwaysHighestPriority;

		public float groupMasterVolume;

		public int retriggerPercentage;

		public MasterAudioGroup.VariationSequence curVariationSequence;

		public bool useNoRepeatRefill;

		public bool useInactivePeriodPoolRefill;

		public float inactivePeriodSeconds;

		public MasterAudioGroup.VariationMode curVariationMode;

		public MasterAudio.AudioLocation bulkVariationMode;

		public float chainLoopDelayMin;

		public float chainLoopDelayMax;

		public MasterAudioGroup.ChainedLoopLoopMode chainLoopMode;

		public int chainLoopNumLoops;

		public bool useDialogFadeOut;

		public float dialogFadeOutTime;

		public string comments;

		public bool logSound;

		public bool soundPlayedEventActive;

		public string soundPlayedCustomEvent;

		public int busIndex;

		public bool ignoreListenerPause;

		[Range(0f, 10f)]
		public int importance;

		public bool isUninterruptible;

		public MasterAudio.ItemSpatialBlendType spatialBlendType;

		public float spatialBlend;

		public MasterAudio.DefaultGroupPlayType groupPlayType;

		public string busName;

		public bool isExistingBus;

		public bool isCopiedFromDGSC;

		public MasterAudioGroup.LimitMode limitMode;

		public int limitPerXFrames;

		public float minimumTimeBetween;

		public bool limitPolyphony;

		public int voiceLimitCount;

		public MasterAudioGroup.TargetDespawnedBehavior targetDespawnedBehavior;

		public float despawnFadeTime;

		public bool isUsingOcclusion;

		public bool willOcclusionOverrideRaycastOffset;

		public float occlusionRayCastOffset;

		public bool willOcclusionOverrideFrequencies;

		public float occlusionMaxCutoffFreq;

		public float occlusionMinCutoffFreq;

		public bool copySettingsExpanded;

		public bool expandLinkedGroups;

		public List<string> childSoundGroups;

		public List<string> endLinkedGroups;

		public MasterAudio.LinkedGroupSelectionType linkedStartGroupSelectionType;

		public MasterAudio.LinkedGroupSelectionType linkedStopGroupSelectionType;

		public int addressableUnusedSecondsLifespan;

		public List<DynamicGroupVariation> groupVariations;
	}
}
