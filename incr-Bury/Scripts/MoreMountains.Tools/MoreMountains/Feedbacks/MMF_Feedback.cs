using System;
using System.Collections;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[Serializable]
	public abstract class MMF_Feedback
	{
		public const string _randomnessGroupName = "Feedback Randomness";

		public const string _rangeGroupName = "Feedback Range";

		public const string _automaticSetupGroupName = "Automatic Setup";

		[MMFInspectorGroup("Feedback Settings", true, 0, false, true)]
		[Tooltip("whether or not this feedback is active")]
		public bool Active = true;

		[HideInInspector]
		public int UniqueID;

		[Tooltip("the name of this feedback to display in the inspector")]
		public string Label = "MMFeedback";

		[MMFHidden]
		public string OriginalLabel = "";

		[Tooltip("whether to broadcast this feedback's message using an int or a scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the ID of the channel on which this feedback will communicate")]
		[MMEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to broadcast this feedback. The shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Tooltip("the chance of this feedback happening (in percent : 100 : happens all the time, 0 : never happens, 50 : happens once every two calls, etc)")]
		[Range(0f, 100f)]
		public float Chance = 100f;

		[Tooltip("a number of timing-related values (delay, repeat, etc)")]
		public MMFeedbackTiming Timing;

		[Tooltip("a set of settings letting you define automated target acquisition for this feedback, to (for example) automatically grab the target on this game object, or a parent, a child, or on a reference holder")]
		public MMFeedbackTargetAcquisition AutomatedTargetAcquisition;

		[MMFInspectorGroup("Feedback Randomness", true, 58, false, true)]
		[Tooltip("if this is true, intensity will be multiplied by a random value on play, picked between RandomMultiplier.x and RandomMultiplier.y")]
		public bool RandomizeOutput;

		[Tooltip("a random value (randomized between its x and y) by which to multiply the output of this feedback, if RandomizeOutput is true")]
		[MMFCondition("RandomizeOutput", true)]
		[MMFVector(new string[] { "Min", "Max" })]
		public Vector2 RandomMultiplier = new Vector2(0.8f, 1f);

		[Tooltip("if this is true, this feedback's duration will be multiplied by a random value on play, picked between RandomDurationMultiplier.x and RandomDurationMultiplier.y")]
		public bool RandomizeDuration;

		[Tooltip("a random value (randomized between its x and y) by which to multiply the duration of this feedback, if RandomizeDuration is true")]
		[MMFCondition("RandomizeDuration", true)]
		[MMFVector(new string[] { "Min", "Max" })]
		public Vector2 RandomDurationMultiplier = new Vector2(0.5f, 2f);

		[MMFInspectorGroup("Feedback Range", true, 47, false, false)]
		[Tooltip("if this is true, only shakers within the specified range will respond to this feedback")]
		public bool UseRange;

		[Tooltip("when in UseRange mode, only shakers within that distance will respond to this feedback")]
		public float RangeDistance = 5f;

		[Tooltip("when in UseRange mode, whether or not to modify the shake intensity based on the RangeFallOff curve")]
		public bool UseRangeFalloff;

		[Tooltip("the animation curve to use to define falloff (on the x 0 represents the range center, 1 represents the max distance to it)")]
		public AnimationCurve RangeFalloff = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the values to remap the falloff curve's y axis' 0 and 1")]
		[MMFVector(new string[] { "Zero", "One" })]
		public Vector2 RemapRangeFalloff = new Vector2(0f, 1f);

		[MMFInspectorGroup("Automatic Setup", true, 49, false, true)]
		[Tooltip("a button used to attempt an auto shaker setup for this feedback, adding whatever shaker it requires to function to the scene")]
		public MMF_Button AutomaticShakerSetupButton;

		[HideInInspector]
		public MMF_Player Owner;

		[HideInInspector]
		public bool DebugActive;

		protected float _lastPlayTimestamp = float.MinValue;

		protected int _playsLeft;

		protected bool _initialized;

		protected Coroutine _playCoroutine;

		protected Coroutine _infinitePlayCoroutine;

		protected Coroutine _sequenceCoroutine;

		protected Coroutine _repeatedPlayCoroutine;

		protected bool _requiresSetup;

		protected string _requiredTarget = "";

		protected float _randomDurationMultiplier = 1f;

		protected int _sequenceTrackID;

		protected float _beatInterval;

		protected bool BeatThisFrame;

		protected int LastBeatIndex;

		protected int CurrentSequenceIndex;

		protected float LastBeatTimestamp;

		protected MMChannelData _channelData;

		protected float _totalDuration;

		protected int _indexInOwnerFeedbackList;

		protected string _requiredTargetTextCached = ".";

		protected string _requiredTargetTextCachedExtra = "";

		protected float _repeatOffset;

		[Tooltip("use this color to customize the background color of the feedback in the MMF_Player's list")]
		public virtual Color DisplayColor => Color.black;

		public virtual IEnumerator Pause => null;

		public virtual bool HoldingPause => false;

		public virtual bool LooperPause => false;

		public virtual bool ScriptDrivenPause { get; set; }

		public virtual float ScriptDrivenPauseAutoResume { get; set; }

		public virtual bool LooperStart => false;

		public virtual bool HasChannel => false;

		public virtual bool HasAutomaticShakerSetup => false;

		public virtual bool HasRandomness => false;

		public virtual bool CanForceInitialValue => false;

		public virtual bool ForceInitialValueDelayed => false;

		public virtual bool HasAutomatedTargetAcquisition => false;

		public virtual MMF_ReferenceHolder ForcedReferenceHolder { get; set; }

		public virtual bool HasRange => false;

		public virtual int PlaysLeft => _playsLeft;

		public virtual bool HasCustomInspectors => false;

		public virtual bool InCooldown
		{
			get
			{
				if (Timing.CooldownDuration > 0f)
				{
					return FeedbackTime - _lastPlayTimestamp < Timing.CooldownDuration;
				}
				return false;
			}
		}

		public virtual bool IsPlaying { get; set; }

		public virtual float ComputedRandomMultiplier
		{
			get
			{
				if (!RandomizeOutput)
				{
					return 1f;
				}
				return UnityEngine.Random.Range(RandomMultiplier.x, RandomMultiplier.y);
			}
		}

		public virtual TimescaleModes ComputedTimescaleMode
		{
			get
			{
				if (Owner.ForceTimescaleMode)
				{
					return Owner.ForcedTimescaleMode;
				}
				return Timing.TimescaleMode;
			}
		}

		public virtual bool InScaledTimescaleMode
		{
			get
			{
				if (Owner.ForceTimescaleMode)
				{
					return Owner.ForcedTimescaleMode == TimescaleModes.Scaled;
				}
				return Timing.TimescaleMode == TimescaleModes.Scaled;
			}
		}

		public virtual float FeedbackTime
		{
			get
			{
				float timescaleMultiplier = Owner.TimescaleMultiplier;
				if (Timing.UseScriptDrivenTimescale)
				{
					return Timing.ScriptDrivenTime * timescaleMultiplier;
				}
				if (Owner.ForceTimescaleMode)
				{
					if (Owner.ForcedTimescaleMode == TimescaleModes.Scaled)
					{
						return Time.time * timescaleMultiplier;
					}
					return Time.unscaledTime * timescaleMultiplier;
				}
				if (Timing.TimescaleMode == TimescaleModes.Scaled)
				{
					return Time.time * timescaleMultiplier;
				}
				return Time.unscaledTime * timescaleMultiplier;
			}
		}

		public virtual float FeedbackDeltaTime
		{
			get
			{
				float timescaleMultiplier = Owner.TimescaleMultiplier;
				if (Timing.UseScriptDrivenTimescale)
				{
					return Timing.ScriptDrivenDeltaTime * timescaleMultiplier;
				}
				if (Owner.ForceTimescaleMode)
				{
					if (Owner.ForcedTimescaleMode == TimescaleModes.Scaled)
					{
						return Time.deltaTime * timescaleMultiplier;
					}
					return Time.unscaledDeltaTime * timescaleMultiplier;
				}
				if (Owner.SkippingToTheEnd)
				{
					return float.MaxValue;
				}
				if (Timing.TimescaleMode == TimescaleModes.Scaled)
				{
					return Time.deltaTime * timescaleMultiplier;
				}
				return Time.unscaledDeltaTime * timescaleMultiplier;
			}
		}

		public virtual float TotalDuration => _totalDuration;

		public virtual bool IsExpanded { get; set; }

		public virtual bool RequiresSetup => _requiresSetup;

		public virtual string RequiredTarget => _requiredTarget;

		public virtual bool DrawGroupInspectors => true;

		public virtual bool DisplayFullHeaderColor => false;

		public virtual string RequiresSetupText => "This feedback requires some additional setup.";

		public virtual string RequiredTargetText => "";

		public virtual string RequiredTargetTextExtra => "";

		public virtual string RequiredChannelText
		{
			get
			{
				if (ChannelMode == MMChannelModes.MMChannel)
				{
					if (MMChannelDefinition == null)
					{
						return "None";
					}
					return MMChannelDefinition.name;
				}
				return "Channel " + Channel;
			}
		}

		public virtual float FeedbackStartedAt
		{
			get
			{
				if (!Application.isPlaying)
				{
					return -1f;
				}
				return _lastPlayTimestamp;
			}
		}

		public virtual float FeedbackDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual bool FeedbackPlaying
		{
			get
			{
				if (FeedbackStartedAt > 0f)
				{
					return Time.time - FeedbackStartedAt < FeedbackDuration;
				}
				return false;
			}
		}

		public virtual MMChannelData ChannelData => _channelData.Set(ChannelMode, Channel, MMChannelDefinition);

		public virtual bool InInitialDelay { get; set; }

		protected virtual float FinalNormalizedTime
		{
			get
			{
				if (!NormalPlayDirection)
				{
					return 0f;
				}
				return 1f;
			}
		}

		public virtual bool NormalPlayDirection => Timing.PlayDirection switch
		{
			MMFeedbackTiming.PlayDirections.FollowMMFeedbacksDirection => Owner.Direction == MMFeedbacks.Directions.TopToBottom, 
			MMFeedbackTiming.PlayDirections.AlwaysNormal => true, 
			MMFeedbackTiming.PlayDirections.AlwaysRewind => false, 
			MMFeedbackTiming.PlayDirections.OppositeMMFeedbacksDirection => Owner.Direction != MMFeedbacks.Directions.TopToBottom, 
			_ => true, 
		};

		public virtual bool ShouldPlayInThisSequenceDirection
		{
			get
			{
				if (Timing == null)
				{
					return true;
				}
				return Timing.MMFeedbacksDirectionCondition switch
				{
					MMFeedbackTiming.MMFeedbacksDirectionConditions.Always => true, 
					MMFeedbackTiming.MMFeedbacksDirectionConditions.OnlyWhenForwards => Owner.Direction == MMFeedbacks.Directions.TopToBottom, 
					MMFeedbackTiming.MMFeedbacksDirectionConditions.OnlyWhenBackwards => Owner.Direction == MMFeedbacks.Directions.BottomToTop, 
					_ => true, 
				};
			}
		}

		public virtual string GetLabel()
		{
			return Label;
		}

		public virtual float ComputeIntensity(float intensity, Vector3 position)
		{
			return (Timing.ConstantIntensity ? 1f : intensity) * ComputedRandomMultiplier * Owner.ComputeRangeIntensityMultiplier(position);
		}

		public virtual void CacheRequiresSetup()
		{
		}

		public virtual bool EvaluateRequiresSetup()
		{
			return false;
		}

		public virtual void SetFeedbackDuration(float newDuration)
		{
			FeedbackDuration = newDuration;
			Owner.ComputeCachedTotalDuration();
		}

		public virtual void PreInitialization(MMF_Player owner, int index)
		{
			_channelData = new MMChannelData(ChannelMode, Channel, MMChannelDefinition);
		}

		public virtual void Initialization(MMF_Player owner, int index)
		{
			if (Timing == null)
			{
				Timing = new MMFeedbackTiming();
			}
			SetIndexInFeedbacksList(index);
			ResetCooldown();
			InInitialDelay = false;
			Timing.PlayCount = 0;
			_initialized = true;
			Owner = owner;
			_playsLeft = Timing.NumberOfRepeats + 1;
			_repeatOffset = 0f;
			_channelData = new MMChannelData(ChannelMode, Channel, MMChannelDefinition);
			AutomateTargetAcquisitionInternal();
			SetInitialDelay(Timing.InitialDelay);
			SetDelayBetweenRepeats(Timing.DelayBetweenRepeats);
			SetSequence(Timing.Sequence);
			CustomInitialization(owner);
		}

		public virtual void SetIndexInFeedbacksList(int index)
		{
			_indexInOwnerFeedbackList = index;
		}

		public virtual void AutomaticShakerSetup()
		{
		}

		protected virtual void AutomateTargetAcquisitionInternal()
		{
			if (HasAutomatedTargetAcquisition)
			{
				if (AutomatedTargetAcquisition == null)
				{
					AutomatedTargetAcquisition = new MMFeedbackTargetAcquisition();
				}
				if (AutomatedTargetAcquisition.Mode != MMFeedbackTargetAcquisition.Modes.None)
				{
					AutomateTargetAcquisition();
					CacheRequiresSetup();
				}
			}
		}

		public virtual void ForceAutomateTargetAcquisition()
		{
			AutomateTargetAcquisition();
			CacheRequiresSetup();
		}

		protected virtual void AutomateTargetAcquisition()
		{
		}

		protected virtual GameObject FindAutomatedTargetGameObject()
		{
			return MMFeedbackTargetAcquisition.FindAutomatedTargetGameObject(AutomatedTargetAcquisition, Owner, _indexInOwnerFeedbackList);
		}

		protected virtual T FindAutomatedTarget<T>()
		{
			return MMFeedbackTargetAcquisition.FindAutomatedTarget<T>(AutomatedTargetAcquisition, Owner, _indexInOwnerFeedbackList);
		}

		public virtual void Play(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active)
			{
				return;
			}
			if (!_initialized)
			{
				string text = ToString().Replace("MoreMountains.Feedbacks.", "");
				Debug.LogWarning("The " + text + " feedback on " + Owner.gameObject.name + " is being played without having been initialized. Always call the Initialization() method first. This can be done manually, or on Start or Awake (automatically on Start is the default). If you're auto playing your feedback on Start or on Enable, initialize on Awake (which runs before Start and Enable). You can change that setting on your MMF Player, unfold the Settings foldout at the top, and change the Initialization Mode.", Owner.gameObject);
			}
			if (!InCooldown)
			{
				if (Timing.InitialDelay > 0f)
				{
					_playCoroutine = Owner.StartCoroutine(PlayCoroutine(position, feedbacksIntensity));
				}
				else
				{
					RegularPlay(position, feedbacksIntensity);
				}
			}
		}

		protected virtual IEnumerator PlayCoroutine(Vector3 position, float feedbacksIntensity = 1f)
		{
			InInitialDelay = true;
			yield return WaitFor(ApplyTimeMultiplier(Timing.InitialDelay));
			InInitialDelay = false;
			RegularPlay(position, feedbacksIntensity);
		}

		protected virtual void RegularPlay(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Chance != 0f && (Chance == 100f || !(UnityEngine.Random.Range(0f, 100f) > Chance)) && (!Timing.LimitPlayCount || Timing.PlayCount < Timing.MaxPlayCount) && (!Timing.UseIntensityInterval || (!(feedbacksIntensity < Timing.IntensityIntervalMin) && !(feedbacksIntensity >= Timing.IntensityIntervalMax))))
			{
				_repeatOffset = 0f;
				if (Timing.RepeatForever)
				{
					_infinitePlayCoroutine = Owner.StartCoroutine(InfinitePlay(position, feedbacksIntensity));
				}
				else if (Timing.NumberOfRepeats > 0)
				{
					_repeatedPlayCoroutine = Owner.StartCoroutine(RepeatedPlay(position, feedbacksIntensity));
				}
				else if (Timing.Sequence == null)
				{
					TriggerCustomPlay(position, feedbacksIntensity);
				}
				else
				{
					_sequenceCoroutine = Owner.StartCoroutine(SequenceCoroutine(position, feedbacksIntensity));
				}
			}
		}

		protected virtual void TriggerCustomPlay(Vector3 position, float intensity)
		{
			Timing.PlayCount++;
			_lastPlayTimestamp = FeedbackTime;
			CustomPlayFeedback(position, intensity);
		}

		protected virtual IEnumerator InfinitePlay(Vector3 position, float feedbacksIntensity = 1f)
		{
			while (true)
			{
				yield return TriggerRepeatedPlay(position, feedbacksIntensity);
			}
		}

		protected virtual IEnumerator RepeatedPlay(Vector3 position, float feedbacksIntensity = 1f)
		{
			while (_playsLeft > 0)
			{
				_playsLeft--;
				yield return TriggerRepeatedPlay(position, feedbacksIntensity);
			}
			_playsLeft = Timing.NumberOfRepeats + 1;
		}

		protected virtual IEnumerator TriggerRepeatedPlay(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Timing.Sequence == null)
			{
				TriggerCustomPlay(position, feedbacksIntensity);
				float repeatStartTime = Time.time;
				float repeatDuration = Timing.DelayBetweenRepeats + FeedbackDuration;
				if (_repeatOffset <= Timing.DelayBetweenRepeats)
				{
					repeatDuration = Timing.DelayBetweenRepeats + FeedbackDuration - _repeatOffset;
				}
				yield return WaitFor(repeatDuration);
				yield return null;
				_repeatOffset = Time.time - repeatStartTime - repeatDuration;
			}
			else
			{
				_sequenceCoroutine = Owner.StartCoroutine(SequenceCoroutine(position, feedbacksIntensity));
				float delay = ApplyTimeMultiplier(Timing.DelayBetweenRepeats) + Timing.Sequence.Length;
				yield return WaitFor(delay);
			}
		}

		protected virtual IEnumerator SequenceCoroutine(Vector3 position, float feedbacksIntensity = 1f)
		{
			yield return null;
			float timeStartedAt = FeedbackTime;
			float lastFrame = FeedbackTime;
			BeatThisFrame = false;
			LastBeatIndex = 0;
			CurrentSequenceIndex = 0;
			LastBeatTimestamp = 0f;
			if (Timing.Quantized)
			{
				while (CurrentSequenceIndex < Timing.Sequence.QuantizedSequence[0].Line.Count)
				{
					_beatInterval = 60f / (float)Timing.TargetBPM;
					if (FeedbackTime - LastBeatTimestamp >= _beatInterval || LastBeatTimestamp == 0f)
					{
						BeatThisFrame = true;
						LastBeatIndex = CurrentSequenceIndex;
						LastBeatTimestamp = FeedbackTime;
						for (int i = 0; i < Timing.Sequence.SequenceTracks.Count; i++)
						{
							if (Timing.Sequence.QuantizedSequence[i].Line[CurrentSequenceIndex].ID == Timing.TrackID)
							{
								TriggerCustomPlay(position, feedbacksIntensity);
							}
						}
						CurrentSequenceIndex++;
					}
					yield return null;
				}
				yield break;
			}
			while (FeedbackTime - timeStartedAt < Timing.Sequence.Length)
			{
				foreach (MMSequenceNote item in Timing.Sequence.OriginalSequence.Line)
				{
					if (item.ID == Timing.TrackID && item.Timestamp >= lastFrame && item.Timestamp <= FeedbackTime - timeStartedAt)
					{
						TriggerCustomPlay(position, feedbacksIntensity);
					}
				}
				lastFrame = FeedbackTime - timeStartedAt;
				yield return null;
			}
		}

		public virtual void SetSequence(MMSequence newSequence)
		{
			Timing.Sequence = newSequence;
			if (!(Timing.Sequence != null))
			{
				return;
			}
			for (int i = 0; i < Timing.Sequence.SequenceTracks.Count; i++)
			{
				if (Timing.Sequence.SequenceTracks[i].ID == Timing.TrackID)
				{
					_sequenceTrackID = i;
				}
			}
		}

		public virtual void Stop(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (_playCoroutine != null)
			{
				Owner.StopCoroutine(_playCoroutine);
			}
			if (_infinitePlayCoroutine != null)
			{
				Owner.StopCoroutine(_infinitePlayCoroutine);
			}
			if (_repeatedPlayCoroutine != null)
			{
				Owner.StopCoroutine(_repeatedPlayCoroutine);
			}
			if (_sequenceCoroutine != null)
			{
				Owner.StopCoroutine(_sequenceCoroutine);
			}
			_playsLeft = Timing.NumberOfRepeats + 1;
			if (Timing.InterruptsOnStop)
			{
				CustomStopFeedback(position, feedbacksIntensity);
			}
		}

		public virtual void SkipToTheEnd(Vector3 position, float feedbacksIntensity = 1f)
		{
			CustomSkipToTheEnd(position, feedbacksIntensity);
		}

		public virtual void ForceInitialValue(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (CanForceInitialValue)
			{
				if (ForceInitialValueDelayed)
				{
					Owner.StartCoroutine(ForceInitialValueDelayedCo(position, feedbacksIntensity));
					return;
				}
				Play(position, feedbacksIntensity);
				Stop(position, feedbacksIntensity);
			}
		}

		protected virtual IEnumerator ForceInitialValueDelayedCo(Vector3 position, float feedbacksIntensity = 1f)
		{
			Play(position, feedbacksIntensity);
			yield return new WaitForEndOfFrame();
			Stop(position, feedbacksIntensity);
		}

		public virtual void RestoreInitialValues()
		{
			CustomRestoreInitialValues();
		}

		public virtual void ResetFeedback()
		{
			_playsLeft = Timing.NumberOfRepeats + 1;
			if (Timing.SetPlayCountToZeroOnReset)
			{
				ResetPlayCount();
			}
			CustomReset();
		}

		public virtual void ResetCooldown()
		{
			_lastPlayTimestamp = float.MinValue;
		}

		public virtual void PlayerComplete()
		{
			CustomPlayerComplete();
		}

		public virtual void SetDelayBetweenRepeats(float delay)
		{
			Timing.DelayBetweenRepeats = delay;
		}

		public virtual void SetInitialDelay(float delay)
		{
			Timing.InitialDelay = delay;
		}

		public virtual void ComputeNewRandomDurationMultiplier()
		{
			_randomDurationMultiplier = UnityEngine.Random.Range(RandomDurationMultiplier.x, RandomDurationMultiplier.y);
		}

		public virtual void ResetPlayCount()
		{
			Timing.PlayCount = 0;
		}

		protected virtual float ApplyTimeMultiplier(float duration)
		{
			if (Owner == null)
			{
				return 0f;
			}
			if (RandomizeDuration)
			{
				duration *= _randomDurationMultiplier;
			}
			return Owner.ApplyTimeMultiplier(duration);
		}

		protected virtual IEnumerator WaitFor(float delay)
		{
			if (InScaledTimescaleMode)
			{
				yield return MMFeedbacksCoroutine.WaitFor(delay);
			}
			else
			{
				yield return MMFeedbacksCoroutine.WaitForUnscaled(delay);
			}
		}

		public virtual void ComputeTotalDuration()
		{
			if (Timing != null && !Timing.ContributeToTotalDuration)
			{
				_totalDuration = 0f;
				return;
			}
			float num = 0f;
			if (Timing == null)
			{
				_totalDuration = 0f;
				return;
			}
			if (Timing.InitialDelay != 0f)
			{
				num += ApplyTimeMultiplier(Timing.InitialDelay);
			}
			num += FeedbackDuration;
			if (Timing.NumberOfRepeats != 0)
			{
				float num2 = ApplyTimeMultiplier(Timing.DelayBetweenRepeats);
				num += (float)Timing.NumberOfRepeats * (FeedbackDuration + num2);
			}
			_totalDuration = num;
		}

		protected virtual float ApplyDirection(float normalizedTime)
		{
			if (!NormalPlayDirection)
			{
				return 1f - normalizedTime;
			}
			return normalizedTime;
		}

		protected virtual void CustomInitialization(MMF_Player owner)
		{
		}

		protected abstract void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f);

		protected virtual void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void CustomSkipToTheEnd(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected virtual void CustomRestoreInitialValues()
		{
		}

		protected virtual void CustomPlayerComplete()
		{
		}

		protected virtual void CustomReset()
		{
		}

		public virtual void InitializeCustomAttributes()
		{
			if (HasAutomaticShakerSetup)
			{
				AutomaticShakerSetupButton = new MMF_Button("Automatic Shaker Setup", AutomaticShakerSetup);
			}
		}

		public virtual void OnValidate()
		{
			InitializeCustomAttributes();
			ComputeTotalDuration();
		}

		public virtual void OnAddFeedback()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnDrawGizmosSelectedHandler()
		{
		}
	}
}
