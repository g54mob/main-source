using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Feedbacks/MMF Player")]
	[DisallowMultipleComponent]
	public class MMF_Player : MMFeedbacks
	{
		[Serializable]
		private class MMF_FeedbackListCopy
		{
			[SerializeReference]
			public List<MMF_Feedback> FeedbackList;

			public static List<MMF_Feedback> CopyFrom(MMF_Player source)
			{
				MMF_FeedbackListCopy mMF_FeedbackListCopy = new MMF_FeedbackListCopy();
				mMF_FeedbackListCopy.FeedbackList = source.FeedbacksList;
				string json = JsonUtility.ToJson(mMF_FeedbackListCopy);
				mMF_FeedbackListCopy.FeedbackList = null;
				JsonUtility.FromJsonOverwrite(json, mMF_FeedbackListCopy);
				return mMF_FeedbackListCopy.FeedbackList;
			}
		}

		public enum AccessMethods
		{
			First = 0,
			Previous = 1,
			Closest = 2,
			Next = 3,
			Last = 4
		}

		[SerializeReference]
		public List<MMF_Feedback> FeedbacksList;

		public bool KeepPlayModeChanges;

		[Tooltip("if this is true, the inspector won't refresh while the feedback plays, this saves on performance but feedback inspectors' progress bars for example won't look as smooth")]
		public bool PerformanceMode;

		[Tooltip("if this is true, RestoreInitialValues will be called on all feedbacks on Disable")]
		public bool RestoreInitialValuesOnDisable;

		[Tooltip("if this is true, StopFeedbacks will be called on all feedbacks on Disable")]
		public bool StopFeedbacksOnDisable;

		[Tooltip("how many times this player has started playing")]
		[MMReadOnly]
		public int PlayCount;

		protected Type _t;

		protected float _cachedTotalDuration;

		protected bool _initialized;

		public override float TotalDuration => _cachedTotalDuration;

		public virtual bool SkippingToTheEnd { get; protected set; }

		public virtual bool HasAutomaticShakerSetup
		{
			get
			{
				if (FeedbacksList == null)
				{
					return false;
				}
				int count = FeedbacksList.Count;
				for (int i = 0; i < count; i++)
				{
					if (FeedbacksList[i] != null && FeedbacksList[i].HasAutomaticShakerSetup)
					{
						return true;
					}
				}
				return false;
			}
		}

		protected override void Awake()
		{
			if (AutoInitialization && (AutoPlayOnEnable || AutoPlayOnStart))
			{
				InitializationMode = InitializationModes.Awake;
			}
			if (AutoPlayOnEnable)
			{
				MMF_PlayerEnabler mMF_PlayerEnabler = GetComponent<MMF_PlayerEnabler>();
				if (mMF_PlayerEnabler == null)
				{
					mMF_PlayerEnabler = base.gameObject.AddComponent<MMF_PlayerEnabler>();
				}
				mMF_PlayerEnabler.TargetMmfPlayer = this;
			}
			if (InitializationMode == InitializationModes.Awake && Application.isPlaying)
			{
				Initialization();
			}
			InitializeFeedbackList();
			ExtraInitializationChecks();
			CheckForLoops();
			ComputeCachedTotalDuration();
			PreInitialization();
		}

		protected override void Start()
		{
			if (InitializationMode == InitializationModes.Start && Application.isPlaying)
			{
				Initialization();
			}
			if (AutoPlayOnStart && Application.isPlaying)
			{
				PlayFeedbacks();
			}
			CheckForLoops();
		}

		protected virtual void InitializeFeedbackList()
		{
			if (FeedbacksList == null)
			{
				FeedbacksList = new List<MMF_Feedback>();
			}
		}

		protected virtual void ExtraInitializationChecks()
		{
			if (Events == null)
			{
				Events = new MMFeedbacksEvents();
				Events.Initialization();
			}
		}

		protected override void OnEnable()
		{
			if (InitializationMode == InitializationModes.OnEnable && Application.isPlaying)
			{
				Initialization(base.gameObject);
			}
			Events.TriggerOnEnable(this);
			if (OnlyPlayIfWithinRange)
			{
				MMSetFeedbackRangeCenterEvent.Register(OnMMSetFeedbackRangeCenterEvent);
			}
			foreach (MMF_Feedback feedbacks in FeedbacksList)
			{
				feedbacks.CacheRequiresSetup();
			}
			if (AutoPlayOnEnable && Application.isPlaying && _lastOnEnableFrame != (float)Time.frameCount)
			{
				if (Time.frameCount < 2)
				{
					_lastOnEnableFrame = 2f;
					StartCoroutine(PlayFeedbacksAfterFrames(2));
				}
				else
				{
					PlayFeedbacks();
				}
			}
		}

		public virtual IEnumerator PlayFeedbacksAfterFrames(int framesAmount)
		{
			yield return MMFeedbacksCoroutine.WaitForFrames(framesAmount);
			PlayFeedbacks();
		}

		public virtual void PreInitialization()
		{
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null)
				{
					FeedbacksList[i].PreInitialization(this, i);
				}
			}
		}

		public override void Initialization(bool forceInitIfPlaying = false)
		{
			if (base.IsPlaying && !forceInitIfPlaying)
			{
				return;
			}
			SkippingToTheEnd = false;
			base.IsPlaying = false;
			ResetCooldown();
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null)
				{
					FeedbacksList[i].Initialization(this, i);
				}
			}
			Events.TriggerOnInitializationComplete(this);
			_initialized = true;
		}

		public override void Initialization(GameObject owner)
		{
			Initialization();
		}

		public override void PlayFeedbacks()
		{
			PlayFeedbacksInternal(base.transform.position, FeedbacksIntensity);
		}

		public override void PlayFeedbacks(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacksInternal(position, feedbacksIntensity, forceChangeDirection);
		}

		public override void PlayFeedbacksInReverse()
		{
			PlayFeedbacksInternal(base.transform.position, FeedbacksIntensity, forceChangeDirection: true);
		}

		public override void PlayFeedbacksInReverse(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacksInternal(position, feedbacksIntensity, forceChangeDirection);
		}

		public override void PlayFeedbacksOnlyIfReversed()
		{
			if ((Direction == Directions.BottomToTop && !base.ShouldChangeDirectionOnNextPlay) || (Direction == Directions.TopToBottom && base.ShouldChangeDirectionOnNextPlay))
			{
				PlayFeedbacks();
			}
		}

		public override void PlayFeedbacksOnlyIfReversed(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			if ((Direction == Directions.BottomToTop && !base.ShouldChangeDirectionOnNextPlay) || (Direction == Directions.TopToBottom && base.ShouldChangeDirectionOnNextPlay))
			{
				PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			}
		}

		public override void PlayFeedbacksOnlyIfNormalDirection()
		{
			if (Direction == Directions.TopToBottom)
			{
				PlayFeedbacks();
			}
		}

		public override void PlayFeedbacksOnlyIfNormalDirection(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			if (Direction == Directions.TopToBottom)
			{
				PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			}
		}

		public override IEnumerator PlayFeedbacksCoroutine(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			while (base.IsPlaying)
			{
				yield return null;
			}
		}

		protected override void PlayFeedbacksInternal(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			if (AutoInitialization && !_initialized)
			{
				Initialization();
			}
			if (IsAllowedToPlay(position))
			{
				SkippingToTheEnd = false;
				if (base.ShouldChangeDirectionOnNextPlay)
				{
					ChangeDirection();
					base.ShouldChangeDirectionOnNextPlay = false;
				}
				if (forceChangeDirection)
				{
					Direction = ((Direction != Directions.BottomToTop) ? Directions.BottomToTop : Directions.TopToBottom);
				}
				ResetFeedbacks();
				_lastStartFrame = Time.frameCount;
				_startTime = GetTime();
				_lastStartAt = _startTime;
				base.IsPlaying = true;
				if (Time.frameCount >= 2)
				{
					base.enabled = true;
				}
				PlayCount++;
				ComputeNewRandomDurationMultipliers();
				CheckForPauses();
				if (Time.frameCount < 2)
				{
					base.enabled = false;
					StartCoroutine(FrameOnePlayCo(position, feedbacksIntensity, forceChangeDirection));
				}
				else if (InitialDelay > 0f)
				{
					StartCoroutine(HandleInitialDelayCo(position, feedbacksIntensity, forceChangeDirection));
				}
				else
				{
					PreparePlay(position, feedbacksIntensity, forceChangeDirection);
				}
			}
		}

		public virtual bool IsAllowedToPlay(Vector3 position)
		{
			if (!CanPlay)
			{
				return false;
			}
			if (base.IsPlaying && !CanPlayWhileAlreadyPlaying)
			{
				return false;
			}
			if (AutoPlayOnEnable && _lastStartFrame == Time.frameCount)
			{
				return false;
			}
			if (!EvaluateChance())
			{
				return false;
			}
			if (CooldownDuration > 0f && GetTime() - _lastStartAt < CooldownDuration)
			{
				return false;
			}
			if (!MMFeedbacks.GlobalMMFeedbacksActive)
			{
				return false;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				return false;
			}
			if (OnlyPlayIfWithinRange)
			{
				if (RangeCenter == null)
				{
					return false;
				}
				if (Vector3.Distance(position, RangeCenter.position) > RangeDistance)
				{
					return false;
				}
			}
			return true;
		}

		protected virtual IEnumerator FrameOnePlayCo(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			yield return null;
			base.enabled = true;
			_startTime = GetTime();
			_lastStartAt = _startTime;
			base.IsPlaying = true;
			yield return MMFeedbacksCoroutine.WaitForUnscaled(ComputedInitialDelay);
			PreparePlay(position, feedbacksIntensity, forceChangeDirection);
		}

		protected override void PreparePlay(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			Events.TriggerOnPlay(this);
			_holdingMax = 0f;
			CheckForPauses();
			if (!_pauseFound)
			{
				PlayAllFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			}
			else
			{
				StartCoroutine(PausedFeedbacksCo(position, feedbacksIntensity));
			}
		}

		protected override void CheckForPauses()
		{
			_pauseFound = false;
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null)
				{
					if (FeedbacksList[i].Pause != null && FeedbacksList[i].Active && FeedbacksList[i].ShouldPlayInThisSequenceDirection)
					{
						_pauseFound = true;
					}
					if (FeedbacksList[i].HoldingPause && FeedbacksList[i].Active && FeedbacksList[i].ShouldPlayInThisSequenceDirection)
					{
						_pauseFound = true;
					}
				}
			}
		}

		protected override void PlayAllFeedbacks(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbackCanPlay(FeedbacksList[i]))
				{
					FeedbacksList[i].Play(position, feedbacksIntensity);
				}
			}
		}

		protected override IEnumerator HandleInitialDelayCo(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			base.IsPlaying = true;
			if (PlayerTimescaleMode == TimescaleModes.Scaled)
			{
				yield return MMFeedbacksCoroutine.WaitFor(ComputedInitialDelay);
			}
			else
			{
				yield return MMFeedbacksCoroutine.WaitForUnscaled(ComputedInitialDelay);
			}
			PreparePlay(position, feedbacksIntensity, forceChangeDirection);
		}

		protected override void Update()
		{
			if (_shouldStop)
			{
				if (HasFeedbackStillPlaying())
				{
					return;
				}
				base.IsPlaying = false;
				ApplyAutoChangeDirection();
				base.enabled = false;
				_shouldStop = false;
				PlayerCompleteFeedbacks();
				Events.TriggerOnComplete(this);
			}
			if (base.IsPlaying)
			{
				if (!_pauseFound && GetTime() - _startTime > TotalDuration)
				{
					_shouldStop = true;
				}
			}
			else
			{
				base.enabled = false;
			}
		}

		protected override IEnumerator PausedFeedbacksCo(Vector3 position, float feedbacksIntensity)
		{
			base.IsPlaying = true;
			int i = ((Direction != Directions.TopToBottom) ? (FeedbacksList.Count - 1) : 0);
			for (int count = FeedbacksList.Count; i >= 0 && i < count; i += ((Direction == Directions.TopToBottom) ? 1 : (-1)))
			{
				if (!base.IsPlaying || FeedbacksList[i] == null)
				{
					yield break;
				}
				if ((FeedbacksList[i].Active && FeedbacksList[i].ScriptDrivenPause) || InScriptDrivenPause)
				{
					InScriptDrivenPause = true;
					Events.TriggerOnPause(this);
					bool inAutoResume = FeedbacksList[i].ScriptDrivenPauseAutoResume > 0f;
					float scriptDrivenPauseStartedAt = GetTime();
					float autoResumeDuration = FeedbacksList[i].ScriptDrivenPauseAutoResume;
					while (InScriptDrivenPause)
					{
						if (inAutoResume && GetTime() - scriptDrivenPauseStartedAt > autoResumeDuration)
						{
							ResumeFeedbacks();
						}
						yield return null;
					}
				}
				if (FeedbacksList[i].Active && (FeedbacksList[i].HoldingPause || FeedbacksList[i].LooperPause) && FeedbacksList[i].ShouldPlayInThisSequenceDirection)
				{
					while (GetTime() - _lastStartAt < _holdingMax / TimescaleMultiplier && !SkippingToTheEnd)
					{
						yield return null;
					}
					_holdingMax = 0f;
					_lastStartAt = GetTime();
				}
				if (FeedbackCanPlay(FeedbacksList[i]))
				{
					FeedbacksList[i].Play(position, feedbacksIntensity);
				}
				if (FeedbacksList[i].Pause != null && FeedbacksList[i].Active && FeedbacksList[i].ShouldPlayInThisSequenceDirection && !SkippingToTheEnd)
				{
					bool flag = true;
					if (FeedbacksList[i].Chance < 100f && UnityEngine.Random.Range(0f, 100f) > FeedbacksList[i].Chance)
					{
						flag = false;
					}
					if (flag)
					{
						yield return FeedbacksList[i].Pause;
						Events.TriggerOnResume(this);
						_lastStartAt = GetTime();
						_holdingMax = 0f;
					}
				}
				if (FeedbacksList[i].Active && FeedbacksList[i].Pause == null && FeedbacksList[i].ShouldPlayInThisSequenceDirection && !FeedbacksList[i].Timing.ExcludeFromHoldingPauses)
				{
					float totalDuration = FeedbacksList[i].TotalDuration;
					_holdingMax = Mathf.Max(totalDuration, _holdingMax);
				}
				if (!FeedbacksList[i].LooperPause || !FeedbacksList[i].Active || !FeedbacksList[i].ShouldPlayInThisSequenceDirection || ((FeedbacksList[i] as MMF_Looper).NumberOfLoopsLeft <= 0 && !(FeedbacksList[i] as MMF_Looper).InInfiniteLoop))
				{
					continue;
				}
				while (HasFeedbackStillPlaying() && !SkippingToTheEnd)
				{
					yield return null;
				}
				bool loopAtLastPause = (FeedbacksList[i] as MMF_Looper).LoopAtLastPause;
				bool loopAtLastLoopStart = (FeedbacksList[i] as MMF_Looper).LoopAtLastLoopStart;
				int num = 0;
				int j = ((Direction == Directions.TopToBottom) ? (i - 1) : (i + 1));
				for (int count2 = FeedbacksList.Count; j >= 0 && j <= count2; j += ((Direction != Directions.TopToBottom) ? 1 : (-1)))
				{
					if (j == 0)
					{
						num = j - 1;
						break;
					}
					if (j == count2)
					{
						num = j;
						break;
					}
					if (FeedbacksList[j].Pause != null && !SkippingToTheEnd && FeedbacksList[j].FeedbackDuration > 0f && loopAtLastPause && FeedbacksList[j].Active)
					{
						num = j;
						break;
					}
					if (FeedbacksList[j].LooperStart && !SkippingToTheEnd && loopAtLastLoopStart && FeedbacksList[j].Active)
					{
						num = j;
						break;
					}
				}
				i = num;
			}
			float unscaledTimeAtEnd = GetTime();
			while (GetTime() - unscaledTimeAtEnd < _holdingMax && !SkippingToTheEnd)
			{
				yield return null;
			}
			while (HasFeedbackStillPlaying() && !SkippingToTheEnd)
			{
				yield return null;
			}
			base.IsPlaying = false;
			PlayerCompleteFeedbacks();
			Events.TriggerOnComplete(this);
			ApplyAutoChangeDirection();
		}

		protected virtual IEnumerator SkipToTheEndCo()
		{
			if (_startTime == GetTime())
			{
				yield return null;
			}
			SkippingToTheEnd = true;
			Events.TriggerOnSkipToTheEnd(this);
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null && FeedbacksList[i].Active)
				{
					FeedbacksList[i].SkipToTheEnd(base.transform.position);
				}
			}
			yield return null;
			yield return null;
			SkippingToTheEnd = false;
			StopFeedbacks();
		}

		public override void StopFeedbacks()
		{
			StopFeedbacks(true);
		}

		public override void StopFeedbacks(bool stopAllFeedbacks = true)
		{
			StopFeedbacks(base.transform.position, 1f, stopAllFeedbacks);
		}

		public override void StopFeedbacks(Vector3 position, float feedbacksIntensity = 1f, bool stopAllFeedbacks = true)
		{
			Events.TriggerOnStop(this);
			if (stopAllFeedbacks)
			{
				int count = FeedbacksList.Count;
				for (int i = 0; i < count; i++)
				{
					FeedbacksList[i].Stop(position, feedbacksIntensity);
				}
			}
			base.IsPlaying = false;
		}

		public override void ResetFeedbacks()
		{
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null && FeedbacksList[i].Active)
				{
					FeedbacksList[i].ResetFeedback();
				}
			}
			base.IsPlaying = false;
		}

		public override void ChangeDirection()
		{
			Events.TriggerOnChangeDirection(this);
			Direction = ((Direction != Directions.BottomToTop) ? Directions.BottomToTop : Directions.TopToBottom);
		}

		public virtual void SetDirection(Directions newDirection)
		{
			Direction = newDirection;
		}

		public void SetDirectionTopToBottom()
		{
			Direction = Directions.TopToBottom;
		}

		public void SetDirectionBottomToTop()
		{
			Direction = Directions.BottomToTop;
		}

		public virtual void PlayerCompleteFeedbacks()
		{
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null && FeedbacksList[i].Active)
				{
					FeedbacksList[i].PlayerComplete();
				}
			}
		}

		public override void PauseFeedbacks()
		{
			Events.TriggerOnPause(this);
			InScriptDrivenPause = true;
		}

		public virtual void RestoreInitialValues()
		{
			if (PlayCount <= 0)
			{
				return;
			}
			for (int num = FeedbacksList.Count - 1; num >= 0; num--)
			{
				if (FeedbacksList[num] != null && FeedbacksList[num].Active)
				{
					FeedbacksList[num].RestoreInitialValues();
				}
			}
			Events.TriggerOnRestoreInitialValues(this);
		}

		public virtual void ForceInitialValues()
		{
			for (int num = FeedbacksList.Count - 1; num >= 0; num--)
			{
				if (FeedbacksList[num] != null && FeedbacksList[num].Active)
				{
					FeedbacksList[num].ForceInitialValue(base.transform.position, FeedbacksIntensity);
				}
			}
		}

		public virtual void SkipToTheEnd()
		{
			StartCoroutine(SkipToTheEndCo());
		}

		public override void ResumeFeedbacks()
		{
			Events.TriggerOnResume(this);
			InScriptDrivenPause = false;
		}

		public virtual void ResetAllCooldowns()
		{
			ResetCooldown();
			ResetFeedbacksCooldowns();
		}

		public virtual void ResetCooldown()
		{
			_lastStartAt = float.MinValue;
		}

		public virtual void ResetFeedbacksCooldowns()
		{
			for (int num = FeedbacksList.Count - 1; num >= 0; num--)
			{
				if (FeedbacksList[num] != null && FeedbacksList[num].Active)
				{
					FeedbacksList[num].ResetCooldown();
				}
			}
		}

		public virtual void AddFeedback(MMF_Feedback newFeedback)
		{
			InitializeFeedbackList();
			newFeedback.Owner = this;
			newFeedback.UniqueID = Guid.NewGuid().GetHashCode();
			FeedbacksList.Add(newFeedback);
			newFeedback.OnAddFeedback();
			newFeedback.CacheRequiresSetup();
			newFeedback.InitializeCustomAttributes();
		}

		public new MMF_Feedback AddFeedback(Type feedbackType, bool add = true)
		{
			InitializeFeedbackList();
			MMF_Feedback mMF_Feedback = (MMF_Feedback)Activator.CreateInstance(feedbackType);
			mMF_Feedback.Label = FeedbackPathAttribute.GetFeedbackDefaultName(feedbackType);
			mMF_Feedback.OriginalLabel = mMF_Feedback.Label;
			mMF_Feedback.Owner = this;
			mMF_Feedback.Timing = new MMFeedbackTiming();
			mMF_Feedback.UniqueID = Guid.NewGuid().GetHashCode();
			if (add)
			{
				FeedbacksList.Add(mMF_Feedback);
			}
			mMF_Feedback.OnAddFeedback();
			mMF_Feedback.InitializeCustomAttributes();
			mMF_Feedback.CacheRequiresSetup();
			return mMF_Feedback;
		}

		public override void RemoveFeedback(int id)
		{
			if (FeedbacksList.Count >= id)
			{
				FeedbacksList.RemoveAt(id);
			}
		}

		public virtual void CopyPlayerFrom(MMF_Player source)
		{
			JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(source), this);
		}

		public virtual void CopyFeedbackListFrom(MMF_Player source)
		{
			FeedbacksList = MMF_FeedbackListCopy.CopyFrom(source);
		}

		public virtual void AddFeedbackListFrom(MMF_Player source)
		{
			List<MMF_Feedback> list = new List<MMF_Feedback>();
			List<MMF_Feedback> list2 = new List<MMF_Feedback>();
			list = MMF_FeedbackListCopy.CopyFrom(this);
			list2 = MMF_FeedbackListCopy.CopyFrom(source);
			list.AddRange(list2);
			FeedbacksList = list;
		}

		public virtual void AutomaticShakerSetup()
		{
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null)
				{
					FeedbacksList[i].AutomaticShakerSetup();
				}
			}
		}

		public override bool HasFeedbackStillPlaying()
		{
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i].Active && ((FeedbacksList[i].IsPlaying && !FeedbacksList[i].Timing.ExcludeFromHoldingPauses) || FeedbacksList[i].Timing.RepeatForever || FeedbacksList[i].InInitialDelay || (FeedbacksList[i].IsPlaying && FeedbacksList[i].Timing.NumberOfRepeats > 0 && FeedbacksList[i].PlaysLeft > 0)))
				{
					return true;
				}
			}
			return false;
		}

		protected override void CheckForLoops()
		{
			base.ContainsLoop = false;
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null && FeedbacksList[i].LooperPause && FeedbacksList[i].Active)
				{
					base.ContainsLoop = true;
					break;
				}
			}
		}

		protected virtual void ComputeNewRandomDurationMultipliers()
		{
			if (RandomizeDuration)
			{
				_randomDurationMultiplier = UnityEngine.Random.Range(RandomDurationMultiplier.x, RandomDurationMultiplier.y);
			}
			int count = FeedbacksList.Count;
			for (int i = 0; i < count; i++)
			{
				if (FeedbacksList[i] != null && FeedbacksList[i].RandomizeDuration)
				{
					FeedbacksList[i].ComputeNewRandomDurationMultiplier();
				}
			}
		}

		public virtual float ComputeRangeIntensityMultiplier(Vector3 position)
		{
			if (!OnlyPlayIfWithinRange)
			{
				return 1f;
			}
			if (RangeCenter == null)
			{
				return 0f;
			}
			float num = Vector3.Distance(position, RangeCenter.position);
			if (num > RangeDistance)
			{
				return 0f;
			}
			if (!UseRangeFalloff)
			{
				return 1f;
			}
			float time = MMFeedbacksHelpers.Remap(num, 0f, RangeDistance, 0f, 1f);
			return MMFeedbacksHelpers.Remap(RangeFalloff.Evaluate(time), 0f, 1f, RemapRangeFalloff.x, RemapRangeFalloff.y);
		}

		protected bool FeedbackCanPlay(MMF_Feedback feedback)
		{
			if (feedback.Timing.MMFeedbacksDirectionCondition == MMFeedbackTiming.MMFeedbacksDirectionConditions.Always)
			{
				return true;
			}
			if ((Direction == Directions.TopToBottom && feedback.Timing.MMFeedbacksDirectionCondition == MMFeedbackTiming.MMFeedbacksDirectionConditions.OnlyWhenForwards) || (Direction == Directions.BottomToTop && feedback.Timing.MMFeedbacksDirectionCondition == MMFeedbackTiming.MMFeedbacksDirectionConditions.OnlyWhenBackwards))
			{
				return true;
			}
			return false;
		}

		protected override void ApplyAutoChangeDirection()
		{
			if (AutoChangeDirectionOnEnd)
			{
				base.ShouldChangeDirectionOnNextPlay = true;
			}
		}

		public override float ApplyTimeMultiplier(float duration)
		{
			return duration * Mathf.Clamp(DurationMultiplier, 0.001f, float.MaxValue) * _randomDurationMultiplier / TimescaleMultiplier;
		}

		public virtual void ProxyDestroy(GameObject gameObjectToDestroy)
		{
			UnityEngine.Object.Destroy(gameObjectToDestroy);
		}

		public virtual void ProxyDestroy(GameObject gameObjectToDestroy, float delay)
		{
			UnityEngine.Object.Destroy(gameObjectToDestroy, delay);
		}

		public virtual void ProxyDestroyImmediate(GameObject gameObjectToDestroy)
		{
			UnityEngine.Object.DestroyImmediate(gameObjectToDestroy);
		}

		public virtual T GetFeedbackOfType<T>(AccessMethods method, int referenceIndex) where T : MMF_Feedback
		{
			_t = typeof(T);
			referenceIndex = Mathf.Clamp(referenceIndex, 0, FeedbacksList.Count);
			switch (method)
			{
			case AccessMethods.First:
			{
				for (int i = 0; i < FeedbacksList.Count; i++)
				{
					if (Check(i))
					{
						return (T)FeedbacksList[i];
					}
				}
				break;
			}
			case AccessMethods.Previous:
			{
				for (int num2 = referenceIndex; num2 >= 0; num2--)
				{
					if (Check(num2))
					{
						return (T)FeedbacksList[num2];
					}
				}
				break;
			}
			case AccessMethods.Closest:
			{
				int num3 = referenceIndex;
				int num4 = referenceIndex;
				for (int num5 = referenceIndex; num5 >= 0; num5--)
				{
					if (Check(num5))
					{
						num3 = num5;
						break;
					}
				}
				for (int k = referenceIndex; k < FeedbacksList.Count; k++)
				{
					if (Check(k))
					{
						num4 = k;
						break;
					}
				}
				if (num3 != referenceIndex || num4 != referenceIndex)
				{
					int index;
					if (num3 == referenceIndex)
					{
						index = num4;
					}
					else if (num4 == referenceIndex)
					{
						index = num3;
					}
					else
					{
						int num6 = Mathf.Abs(referenceIndex - num3);
						int num7 = Mathf.Abs(referenceIndex - num4);
						index = ((num6 > num7) ? num4 : num3);
					}
					return (T)FeedbacksList[index];
				}
				return null;
			}
			case AccessMethods.Next:
			{
				for (int j = referenceIndex; j < FeedbacksList.Count; j++)
				{
					if (Check(j))
					{
						return (T)FeedbacksList[j];
					}
				}
				break;
			}
			case AccessMethods.Last:
			{
				for (int num = FeedbacksList.Count - 1; num >= 0; num--)
				{
					if (Check(num))
					{
						return (T)FeedbacksList[num];
					}
				}
				break;
			}
			}
			return null;
			bool Check(int index2)
			{
				return FeedbacksList[index2].GetType() == _t;
			}
		}

		public virtual T GetFeedbackOfType<T>() where T : MMF_Feedback
		{
			_t = typeof(T);
			foreach (MMF_Feedback feedbacks in FeedbacksList)
			{
				if (feedbacks.GetType() == _t)
				{
					return (T)feedbacks;
				}
			}
			return null;
		}

		public virtual List<T> GetFeedbacksOfType<T>() where T : MMF_Feedback
		{
			_t = typeof(T);
			List<T> list = new List<T>();
			foreach (MMF_Feedback feedbacks in FeedbacksList)
			{
				if (feedbacks.GetType() == _t)
				{
					list.Add((T)feedbacks);
				}
			}
			return list;
		}

		public virtual T GetFeedbackOfType<T>(string searchedLabel) where T : MMF_Feedback
		{
			_t = typeof(T);
			foreach (MMF_Feedback feedbacks in FeedbacksList)
			{
				if (feedbacks.GetType() == _t && feedbacks.Label == searchedLabel)
				{
					return (T)feedbacks;
				}
			}
			return null;
		}

		public virtual List<T> GetFeedbacksOfType<T>(string searchedLabel) where T : MMF_Feedback
		{
			_t = typeof(T);
			List<T> list = new List<T>();
			foreach (MMF_Feedback feedbacks in FeedbacksList)
			{
				if (feedbacks.GetType() == _t && feedbacks.Label == searchedLabel)
				{
					list.Add((T)feedbacks);
				}
			}
			return list;
		}

		protected virtual void OnMMSetFeedbackRangeCenterEvent(Transform newTransform)
		{
			if (!IgnoreRangeEvents)
			{
				RangeCenter = newTransform;
			}
		}

		protected override void OnDisable()
		{
			Events.TriggerOnDisable(this);
			if (OnlyPlayIfWithinRange)
			{
				MMSetFeedbackRangeCenterEvent.Unregister(OnMMSetFeedbackRangeCenterEvent);
			}
			if (RestoreInitialValuesOnDisable)
			{
				RestoreInitialValues();
			}
			if (base.IsPlaying)
			{
				if (StopFeedbacksOnDisable)
				{
					StopFeedbacks();
				}
				StopAllCoroutines();
				for (int num = FeedbacksList.Count - 1; num >= 0; num--)
				{
					FeedbacksList[num].OnDisable();
				}
			}
		}

		protected override void OnValidate()
		{
			RefreshCache();
			if (FeedbacksList != null && FeedbacksList.Count > 0)
			{
				for (int num = FeedbacksList.Count - 1; num >= 0; num--)
				{
					FeedbacksList[num].OnValidate();
				}
			}
		}

		public virtual void RefreshCache()
		{
			if (FeedbacksList == null)
			{
				return;
			}
			DurationMultiplier = Mathf.Clamp(DurationMultiplier, 0.001f, float.MaxValue);
			for (int num = FeedbacksList.Count - 1; num >= 0; num--)
			{
				if (FeedbacksList[num] == null)
				{
					FeedbacksList.RemoveAt(num);
				}
				else
				{
					FeedbacksList[num].Owner = this;
					FeedbacksList[num].CacheRequiresSetup();
				}
			}
			ComputeCachedTotalDuration();
		}

		public virtual void ComputeCachedTotalDuration()
		{
			float num = 0f;
			if (FeedbacksList == null)
			{
				_cachedTotalDuration = ComputedInitialDelay;
				return;
			}
			CheckForPauses();
			if (!_pauseFound)
			{
				foreach (MMF_Feedback feedbacks in FeedbacksList)
				{
					feedbacks.ComputeTotalDuration();
					if (feedbacks != null && feedbacks.Active && feedbacks.ShouldPlayInThisSequenceDirection && num < feedbacks.TotalDuration)
					{
						num = feedbacks.TotalDuration;
					}
				}
			}
			else
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = 1000;
				float num8 = 0f;
				int num9 = ((Direction != Directions.TopToBottom) ? (Feedbacks.Count - 1) : 0);
				float num10 = 0f;
				while (num9 >= 0 && num9 < FeedbacksList.Count && num6 < num7)
				{
					num6++;
					if (FeedbacksList[num9] != null && FeedbacksList[num9].Active && FeedbacksList[num9].ShouldPlayInThisSequenceDirection)
					{
						FeedbacksList[num9].ComputeTotalDuration();
						if (FeedbacksList[num9].Pause != null)
						{
							if (FeedbacksList[num9].Timing != null && !FeedbacksList[num9].Timing.ContributeToTotalDuration)
							{
								continue;
							}
							if (FeedbacksList[num9].HoldingPause)
							{
								num10 += ApplyTimeMultiplier((FeedbacksList[num9] as MMF_Pause).PauseDuration);
								num += num10;
								num10 = 0f;
							}
							else
							{
								num8 += ApplyTimeMultiplier((FeedbacksList[num9] as MMF_Pause).PauseDuration);
							}
							if (FeedbacksList[num9].LooperStart)
							{
								num2 = num9;
							}
							if (!FeedbacksList[num9].LooperPause)
							{
								num4 = num9;
							}
							if (FeedbacksList[num9].LooperPause && (FeedbacksList[num9] as MMF_Looper).NumberOfLoops > 0)
							{
								if (num9 == num3)
								{
									num5--;
									if (num5 <= 0)
									{
										num9 += ((Direction == Directions.TopToBottom) ? 1 : (-1));
										continue;
									}
								}
								else
								{
									num3 = num9;
									num5 = (FeedbacksList[num9] as MMF_Looper).NumberOfLoops - 1;
								}
								if ((FeedbacksList[num9] as MMF_Looper).InfiniteLoop)
								{
									_cachedTotalDuration = 999f;
									return;
								}
								if ((FeedbacksList[num9] as MMF_Looper).LoopAtLastPause)
								{
									num9 = num4;
									num += num10;
									num10 = 0f;
									num8 = 0f;
								}
								else if ((FeedbacksList[num9] as MMF_Looper).LoopAtLastLoopStart)
								{
									num9 = num2;
									num += num10;
									num10 = 0f;
									num8 = 0f;
								}
								else
								{
									num9 = 0;
									num += num10;
									num10 = 0f;
									num8 = 0f;
								}
								continue;
							}
						}
						else
						{
							float num11 = FeedbacksList[num9].TotalDuration + num8;
							if (num10 < num11)
							{
								num10 = num11;
							}
						}
					}
					num9 += ((Direction == Directions.TopToBottom) ? 1 : (-1));
				}
				num += num10;
			}
			_cachedTotalDuration = ComputedInitialDelay + num;
			_cachedTotalDuration /= TimescaleMultiplier;
		}

		protected override void OnDestroy()
		{
			base.IsPlaying = false;
			foreach (MMF_Feedback feedbacks in FeedbacksList)
			{
				feedbacks.OnDestroy();
			}
		}

		protected void OnDrawGizmosSelected()
		{
			if (FeedbacksList != null)
			{
				for (int num = FeedbacksList.Count - 1; num >= 0; num--)
				{
					FeedbacksList[num].OnDrawGizmosSelectedHandler();
				}
			}
		}
	}
}
