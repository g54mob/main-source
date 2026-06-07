using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[RequireComponent(typeof(MMWiggle))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Camera/MM Camera Shaker")]
	public class MMCameraShaker : MonoBehaviour
	{
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Tooltip("a cooldown, in seconds, after a shake, during which no other shake can start")]
		public float CooldownBetweenShakes;

		protected MMWiggle _wiggle;

		protected float _shakeStartedTimestamp = float.MinValue;

		protected virtual void Awake()
		{
			_wiggle = GetComponent<MMWiggle>();
		}

		public virtual void ShakeCamera(float duration, float amplitude, float frequency, float amplitudeX, float amplitudeY, float amplitudeZ, bool useUnscaledTime)
		{
			if (!(Time.unscaledTime - _shakeStartedTimestamp < CooldownBetweenShakes))
			{
				if (amplitudeX != 0f || amplitudeY != 0f || amplitudeZ != 0f)
				{
					_wiggle.PositionWiggleProperties.AmplitudeMin.x = 0f - amplitudeX;
					_wiggle.PositionWiggleProperties.AmplitudeMin.y = 0f - amplitudeY;
					_wiggle.PositionWiggleProperties.AmplitudeMin.z = 0f - amplitudeZ;
					_wiggle.PositionWiggleProperties.AmplitudeMax.x = amplitudeX;
					_wiggle.PositionWiggleProperties.AmplitudeMax.y = amplitudeY;
					_wiggle.PositionWiggleProperties.AmplitudeMax.z = amplitudeZ;
				}
				else
				{
					_wiggle.PositionWiggleProperties.AmplitudeMin = Vector3.one * (0f - amplitude);
					_wiggle.PositionWiggleProperties.AmplitudeMax = Vector3.one * amplitude;
				}
				_shakeStartedTimestamp = Time.unscaledTime;
				_wiggle.PositionWiggleProperties.UseUnscaledTime = useUnscaledTime;
				_wiggle.PositionWiggleProperties.FrequencyMin = frequency;
				_wiggle.PositionWiggleProperties.FrequencyMax = frequency;
				_wiggle.PositionWiggleProperties.NoiseFrequencyMin = frequency * Vector3.one;
				_wiggle.PositionWiggleProperties.NoiseFrequencyMax = frequency * Vector3.one;
				_wiggle.WigglePosition(duration);
			}
		}

		public virtual void OnCameraShakeEvent(float duration, float amplitude, float frequency, float amplitudeX, float amplitudeY, float amplitudeZ, bool infinite, MMChannelData channelData, bool useUnscaledTime)
		{
			if (MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
			{
				ShakeCamera(duration, amplitude, frequency, amplitudeX, amplitudeY, amplitudeZ, useUnscaledTime);
			}
		}

		protected virtual void OnEnable()
		{
			MMCameraShakeEvent.Register(OnCameraShakeEvent);
		}

		protected virtual void OnDisable()
		{
			MMCameraShakeEvent.Unregister(OnCameraShakeEvent);
		}
	}
}
