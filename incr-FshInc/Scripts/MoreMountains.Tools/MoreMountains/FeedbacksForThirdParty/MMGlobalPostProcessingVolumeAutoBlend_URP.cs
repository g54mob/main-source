using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Rendering;

namespace MoreMountains.FeedbacksForThirdParty
{
	[RequireComponent(typeof(Volume))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MM Global Post Processing Volume Auto Blend URP")]
	public class MMGlobalPostProcessingVolumeAutoBlend_URP : MonoBehaviour, MMEventListener<MMPostProcessingVolumeAutoBlendURPShakeEvent>, MMEventListenerBase
	{
		public enum TimeScales
		{
			Scaled = 0,
			Unscaled = 1
		}

		public enum BlendTriggerModes
		{
			OnEnable = 0,
			Script = 1
		}

		[Header("Channel")]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Header("Blend")]
		public BlendTriggerModes BlendTriggerMode = BlendTriggerModes.Script;

		public float BlendDuration = 1f;

		public AnimationCurve Curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[Header("Weight")]
		[Range(0f, 1f)]
		public float InitialWeight;

		[Range(0f, 1f)]
		public float FinalWeight = 1f;

		[Header("Behaviour")]
		public TimeScales TimeScale = TimeScales.Unscaled;

		public bool DisableVolumeOnZeroWeight = true;

		public bool DisableSelfAfterEnd = true;

		public bool Interruptable = true;

		public bool StartFromCurrentValue = true;

		[Tooltip("reset to initial value on end ")]
		public bool ResetToInitialValueOnEnd;

		[Header("Tests")]
		[MMFInspectorButton("Blend")]
		public bool TestBlend;

		[MMFInspectorButton("BlendBack")]
		public bool TestBlendBackwards;

		protected float _initial;

		protected float _destination;

		protected float _startTime;

		protected bool _blending;

		protected Volume _volume;

		protected float GetTime()
		{
			if (TimeScale != TimeScales.Unscaled)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}

		protected virtual void Awake()
		{
			_volume = base.gameObject.GetComponent<Volume>();
			_volume.weight = InitialWeight;
			this.MMEventStartListening();
		}

		protected virtual void OnEnable()
		{
			if (BlendTriggerMode == BlendTriggerModes.OnEnable && !_blending)
			{
				Blend();
			}
		}

		public virtual void Blend()
		{
			if (!_blending || Interruptable)
			{
				_initial = (StartFromCurrentValue ? _volume.weight : InitialWeight);
				_destination = FinalWeight;
				StartBlending();
			}
		}

		public virtual void BlendBack()
		{
			if (!_blending || Interruptable)
			{
				_initial = (StartFromCurrentValue ? _volume.weight : FinalWeight);
				_destination = InitialWeight;
				StartBlending();
			}
		}

		protected virtual void StartBlending()
		{
			_startTime = GetTime();
			_blending = true;
			base.enabled = true;
			if (DisableVolumeOnZeroWeight)
			{
				_volume.enabled = true;
			}
		}

		public virtual void StopBlending()
		{
			_blending = false;
		}

		protected virtual void Update()
		{
			if (!_blending)
			{
				return;
			}
			float num = GetTime() - _startTime;
			if (num < BlendDuration)
			{
				float time = MMFeedbacksHelpers.Remap(num, 0f, BlendDuration, 0f, 1f);
				_volume.weight = Mathf.LerpUnclamped(_initial, _destination, Curve.Evaluate(time));
				return;
			}
			_volume.weight = (ResetToInitialValueOnEnd ? _initial : _destination);
			_blending = false;
			if (DisableVolumeOnZeroWeight && _volume.weight == 0f)
			{
				_volume.enabled = false;
			}
			if (DisableSelfAfterEnd)
			{
				base.enabled = false;
			}
		}

		public virtual void RestoreInitialValues()
		{
			_volume.weight = _initial;
		}

		public void OnMMEvent(MMPostProcessingVolumeAutoBlendURPShakeEvent shakeEvent)
		{
			if (shakeEvent.TargetAutoBlend != null)
			{
				if (!shakeEvent.TargetAutoBlend.Equals(this))
				{
					return;
				}
			}
			else if (shakeEvent.ChannelData == null || !MMChannel.Match(shakeEvent.ChannelData, ChannelMode, Channel, MMChannelDefinition))
			{
				return;
			}
			if (shakeEvent.Mode == MMF_GlobalPPVolumeAutoBlend_URP.Modes.Default)
			{
				if (!shakeEvent.NormalPlayDirection)
				{
					if (shakeEvent.BlendAction == MMF_GlobalPPVolumeAutoBlend_URP.Actions.Blend)
					{
						BlendBack();
					}
					else if (shakeEvent.BlendAction == MMF_GlobalPPVolumeAutoBlend_URP.Actions.BlendBack)
					{
						Blend();
					}
				}
				else if (shakeEvent.BlendAction == MMF_GlobalPPVolumeAutoBlend_URP.Actions.Blend)
				{
					Blend();
				}
				else if (shakeEvent.BlendAction == MMF_GlobalPPVolumeAutoBlend_URP.Actions.BlendBack)
				{
					BlendBack();
				}
			}
			else
			{
				BlendDuration = shakeEvent.BlendDuration;
				Curve = shakeEvent.BlendCurve;
				TimeScale = shakeEvent.TimeScale;
				if (!shakeEvent.NormalPlayDirection)
				{
					InitialWeight = shakeEvent.FinalWeight;
					FinalWeight = shakeEvent.InitialWeight;
				}
				else
				{
					InitialWeight = shakeEvent.InitialWeight;
					FinalWeight = shakeEvent.FinalWeight;
				}
				ResetToInitialValueOnEnd = shakeEvent.ResetToInitialValueOnEnd;
				Blend();
			}
		}

		protected void OnDestroy()
		{
			this.MMEventStopListening();
		}
	}
}
