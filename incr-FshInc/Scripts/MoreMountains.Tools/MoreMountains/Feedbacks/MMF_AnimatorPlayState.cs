using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will allow you to play the specified state on the target Animator, either in normalized or fixed time.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Animation/Animator Play State")]
	public class MMF_AnimatorPlayState : MMF_Feedback
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
			NormalizedTime = 0,
			FixedTime = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Animation", true, 12, true, false)]
		[Tooltip("the animator whose parameters you want to update")]
		public Animator BoundAnimator;

		[Tooltip("the list of extra animators whose parameters you want to update")]
		public List<Animator> ExtraBoundAnimators;

		[Tooltip("the duration for the player to consider. This won't impact your animation, but is a way to communicate to the MMF Player the duration of this feedback. Usually you'll want it to match your actual animation, and setting it can be useful to have this feedback work with holding pauses.")]
		public float DeclaredDuration;

		[MMFInspectorGroup("State", true, 16, false, false)]
		[Tooltip("The name of the state to play on the target animator")]
		public string StateName;

		[Tooltip("Whether to play the state at a normalized time (between 0 and 1) or a fixed time (in seconds)")]
		public Modes Mode;

		[Tooltip("The time offset between zero and one at which to play the specified state")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float NormalizedTime;

		[Tooltip("The time offset (in seconds) at which to play the specified state")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float FixedTime;

		[Tooltip("The layer index. If layer is -1, it plays the first state with the given state name or hash.")]
		public int LayerIndex = -1;

		[Tooltip("the name of the Animator layer you want the state to play on. This is optional. If left empty, the layer ID above will be used, if not empty, the Layer id specified above will be ignored.")]
		public string LayerName = "";

		[MMFInspectorGroup("Layer Weights", true, 22, false, false)]
		[Tooltip("whether or not to set layer weights on the specified layer when playing this feedback")]
		public bool SetLayerWeight;

		[Tooltip("the index of the layer to target when changing layer weights")]
		[MMFCondition("SetLayerWeight", true)]
		public int TargetLayerIndex = 1;

		[Tooltip("the new weight to set on the target animator layer")]
		[MMFCondition("SetLayerWeight", true)]
		public float NewWeight = 0.5f;

		protected int _targetParameter;

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
			_targetParameter = Animator.StringToHash(StateName);
			_layerID = TargetLayerIndex;
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
				Debug.LogWarning("[Animator Play State Feedback] The animator play state feedback on " + Owner.name + " doesn't have a BoundAnimator, it won't work. You need to specify one in its inspector.");
				return;
			}
			float intensityMultiplier = ComputeIntensity(feedbacksIntensity, position);
			PlayState(BoundAnimator, intensityMultiplier);
			foreach (Animator extraBoundAnimator in ExtraBoundAnimators)
			{
				PlayState(extraBoundAnimator, intensityMultiplier);
			}
		}

		protected virtual void PlayState(Animator targetAnimator, float intensityMultiplier)
		{
			if (SetLayerWeight)
			{
				targetAnimator.SetLayerWeight(_layerID, NewWeight);
			}
			if (Mode == Modes.NormalizedTime)
			{
				targetAnimator.Play(_targetParameter, LayerIndex, NormalizedTime);
			}
			else
			{
				targetAnimator.PlayInFixedTime(_targetParameter, LayerIndex, FixedTime);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active)
			{
				_ = FeedbackTypeAuthorized;
			}
		}
	}
}
