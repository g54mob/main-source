using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will allow you to cross fade a target Animator to the specified state.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Animation/Animation Crossfade")]
	public class MMF_AnimationCrossfade : MMF_Feedback
	{
		public enum TriggerModes
		{
			SetTrigger = 0,
			ResetTrigger = 1
		}

		public enum ValueModes
		{
			None = 0,
			Constant = 1,
			Random = 2,
			Incremental = 3
		}

		public enum Modes
		{
			Seconds = 0,
			Normalized = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Animation", true, 12, true, false)]
		[Tooltip("the animator whose parameters you want to update")]
		public Animator BoundAnimator;

		[Tooltip("the list of extra animators whose parameters you want to update")]
		public List<Animator> ExtraBoundAnimators;

		[Tooltip("the duration for the player to consider. This won't impact your animation, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual animation, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[MMFInspectorGroup("CrossFade", true, 16, false, false)]
		[Tooltip("the name of the state towards which to transition. That's the name of the yellow or gray box in your Animator")]
		public string StateName = "NewState";

		[Tooltip("an optional list of names of state towards which to transition. If left empty, StateName above will be used. If filled, a random state will be chosen from this list, ignoring the StateName specified above")]
		public List<string> RandomStateNames = new List<string>();

		[Tooltip("the ID of the Animator layer you want the crossfade to occur on")]
		public int Layer = -1;

		[Tooltip("the name of the Animator layer you want the crossfade to occur on. This is optional. If left empty, the layer ID above will be used, if not empty, the Layer id specified above will be ignored.")]
		public string LayerName = "";

		[Tooltip("whether to specify timing data for the crossfade in seconds or in normalized (0-1) values")]
		public Modes Mode;

		[Tooltip("in Seconds mode, the duration of the transition, in seconds")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float TransitionDuration = 0.1f;

		[Tooltip("in Seconds mode, the offset at which to transition to, in seconds")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float TimeOffset;

		[Tooltip("in Normalized mode, the duration of the transition, normalized between 0 and 1")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float NormalizedTransitionDuration = 0.1f;

		[Tooltip("in Normalized mode, the offset at which to transition to, normalized between 0 and 1")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float NormalizedTimeOffset;

		[Tooltip("according to Unity's docs, 'the time of the transition, normalized'. Really nobody's sure what this does. It's optional.")]
		public float NormalizedTransitionTime;

		protected int _stateHashName;

		protected int _layerID;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(DeclaredDuration);
			}
			set
			{
				DeclaredDuration = value;
			}
		}

		public override bool HasRandomness => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundAnimator = FindAutomatedTarget<Animator>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			_stateHashName = Animator.StringToHash(StateName);
			_layerID = Layer;
			if (LayerName != "" && BoundAnimator != null)
			{
				_layerID = BoundAnimator.GetLayerIndex(LayerName);
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (BoundAnimator == null)
			{
				Debug.LogWarning("[Animation Crossfade Feedback] The animation crossfade feedback on " + Owner.name + " doesn't have a BoundAnimator, it won't work. You need to specify one in its inspector.");
				return;
			}
			if (RandomStateNames.Count > 0)
			{
				int index = Random.Range(0, RandomStateNames.Count);
				StateName = RandomStateNames[index];
				_stateHashName = Animator.StringToHash(StateName);
			}
			CrossFade(BoundAnimator);
			foreach (Animator extraBoundAnimator in ExtraBoundAnimators)
			{
				CrossFade(extraBoundAnimator);
			}
		}

		protected virtual void CrossFade(Animator targetAnimator)
		{
			switch (Mode)
			{
			case Modes.Seconds:
				targetAnimator.CrossFadeInFixedTime(_stateHashName, TransitionDuration, _layerID, TimeOffset, NormalizedTransitionTime);
				break;
			case Modes.Normalized:
				targetAnimator.CrossFade(_stateHashName, NormalizedTransitionDuration, _layerID, NormalizedTimeOffset, NormalizedTransitionTime);
				break;
			}
		}
	}
}
