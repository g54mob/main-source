using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public class MasterAudioGroup : MonoBehaviour
	{
		public enum TargetDespawnedBehavior
		{
			None = 0,
			Stop = 1,
			FadeOut = 2
		}

		public enum VariationSequence
		{
			Randomized = 0,
			TopToBottom = 1
		}

		public enum VariationMode
		{
			Normal = 0,
			LoopedChain = 1,
			Dialog = 2
		}

		public enum ChainedLoopLoopMode
		{
			Endless = 0,
			NumberOfLoops = 1
		}

		public enum LimitMode
		{
			None = 0,
			FrameBased = 1,
			TimeBased = 2
		}

		public const float UseCurveSpatialBlend = -99f;

		public const string NoBus = "[NO BUS]";

		public const int MinNoRepeatVariations = 3;

		public int busIndex;

		public MasterAudio.ItemSpatialBlendType spatialBlendType;

		public float spatialBlend;

		public MasterAudio.DefaultGroupPlayType groupPlayType;

		public bool isSelected;

		public bool isExpanded;

		public float groupMasterVolume;

		public int retriggerPercentage;

		public VariationMode curVariationMode;

		public bool alwaysHighestPriority;

		public bool ignoreListenerPause;

		[Range(0f, 10f)]
		public int importance;

		public bool isUninterruptible;

		public float chainLoopDelayMin;

		public float chainLoopDelayMax;

		public ChainedLoopLoopMode chainLoopMode;

		public int chainLoopNumLoops;

		public bool useDialogFadeOut;

		public float dialogFadeOutTime;

		public VariationSequence curVariationSequence;

		public bool useNoRepeatRefill;

		public bool useInactivePeriodPoolRefill;

		public float inactivePeriodSeconds;

		public List<SoundGroupVariation> groupVariations;

		public MasterAudio.AudioLocation bulkVariationMode;

		public string comments;

		public bool logSound;

		public bool copySettingsExpanded;

		public bool expandLinkedGroups;

		public List<string> childSoundGroups;

		public List<string> endLinkedGroups;

		public MasterAudio.LinkedGroupSelectionType linkedStartGroupSelectionType;

		public MasterAudio.LinkedGroupSelectionType linkedStopGroupSelectionType;

		public LimitMode limitMode;

		public int limitPerXFrames;

		public float minimumTimeBetween;

		public bool useClipAgePriority;

		public bool limitPolyphony;

		public int voiceLimitCount;

		public TargetDespawnedBehavior targetDespawnedBehavior;

		public float despawnFadeTime;

		public bool isUsingOcclusion;

		public bool willOcclusionOverrideRaycastOffset;

		public float occlusionRayCastOffset;

		public bool willOcclusionOverrideFrequencies;

		public float occlusionMaxCutoffFreq;

		public float occlusionMinCutoffFreq;

		public bool isSoloed;

		public bool isMuted;

		public bool soundPlayedEventActive;

		public string soundPlayedCustomEvent;

		public bool willCleanUpDelegatesAfterStop;

		public int frames;

		private List<int> _activeAudioSourcesIds;

		private string _objectName;

		private Transform _trans;

		private float _originalVolume;

		private readonly List<int> _actorInstanceIds;

		public float SpatialBlendForGroup => 0f;

		public int ActiveVoices => 0;

		public int TotalVoices => 0;

		public bool WillCleanUpDelegatesAfterStop
		{
			set
			{
			}
		}

		public GroupBus BusForGroup => null;

		public float OriginalVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool LoggingEnabledForGroup => false;

		public int ChainLoopCount { get; set; }

		public string GameObjectName => null;

		public MasterAudio.GroupPlayType GroupPlayType => default(MasterAudio.GroupPlayType);

		public bool HasLiveActors => false;

		public bool UsesNoRepeat => false;

		private Transform Trans => null;

		private List<int> ActiveAudioSourceIds => null;

		public event Action LastVariationFinishedPlay
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		public void AddActiveAudioSourceId(int varInstanceId)
		{
		}

		public void RemoveActiveAudioSourceId(int varInstanceId)
		{
		}

		public void AddActorInstanceId(int instanceId)
		{
		}

		public void RemoveActorInstanceId(int instanceId)
		{
		}

		public void FireLastVariationFinishedPlay()
		{
		}

		public void SubscribeToLastVariationFinishedPlay(Action finishedCallback)
		{
		}

		public void UnsubscribeFromLastVariationFinishedPlay()
		{
		}
	}
}
