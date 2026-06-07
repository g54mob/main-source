using System.Collections;
using MoreMountains.Feedbacks;
using Unity.Cinemachine;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MM Cinemachine Camera Shaker")]
	[RequireComponent(typeof(CinemachineCamera))]
	public class MMCinemachineCameraShaker : MonoBehaviour
	{
		[Header("Settings")]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMFEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMFEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Tooltip("The default amplitude that will be applied to your shakes if you don't specify one")]
		public float DefaultShakeAmplitude = 0.5f;

		[Tooltip("The default frequency that will be applied to your shakes if you don't specify one")]
		public float DefaultShakeFrequency = 10f;

		[Tooltip("the amplitude of the camera's noise when it's idle")]
		[MMFReadOnly]
		public float IdleAmplitude;

		[Tooltip("the frequency of the camera's noise when it's idle")]
		[MMFReadOnly]
		public float IdleFrequency = 1f;

		[Tooltip("the speed at which to interpolate the shake")]
		public float LerpSpeed = 5f;

		[Header("Test")]
		[Tooltip("a duration (in seconds) to apply when testing this shake via the TestShake button")]
		public float TestDuration = 0.3f;

		[Tooltip("the amplitude to apply when testing this shake via the TestShake button")]
		public float TestAmplitude = 2f;

		[Tooltip("the frequency to apply when testing this shake via the TestShake button")]
		public float TestFrequency = 20f;

		[MMFInspectorButton("TestShake")]
		public bool TestShakeButton;

		protected TimescaleModes _timescaleMode;

		protected Vector3 _initialPosition;

		protected Quaternion _initialRotation;

		protected CinemachineBasicMultiChannelPerlin _perlin;

		protected CinemachineCamera _virtualCamera;

		protected float _targetAmplitude;

		protected float _targetFrequency;

		private Coroutine _shakeCoroutine;

		public virtual float GetTime()
		{
			if (_timescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (_timescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected virtual void Awake()
		{
			_virtualCamera = base.gameObject.GetComponent<CinemachineCamera>();
			_perlin = _virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Noise) as CinemachineBasicMultiChannelPerlin;
		}

		protected virtual void Start()
		{
			if (_perlin != null)
			{
				IdleAmplitude = _perlin.AmplitudeGain;
				IdleFrequency = _perlin.FrequencyGain;
			}
			_targetAmplitude = IdleAmplitude;
			_targetFrequency = IdleFrequency;
		}

		protected virtual void Update()
		{
			if (_perlin != null)
			{
				_perlin.AmplitudeGain = _targetAmplitude;
				_perlin.FrequencyGain = Mathf.Lerp(_perlin.FrequencyGain, _targetFrequency, GetDeltaTime() * LerpSpeed);
			}
		}

		public virtual void ShakeCamera(float duration, bool infinite, bool useUnscaledTime = false)
		{
			StartCoroutine(ShakeCameraCo(duration, DefaultShakeAmplitude, DefaultShakeFrequency, infinite, useUnscaledTime));
		}

		public virtual void ShakeCamera(float duration, float amplitude, float frequency, bool infinite, bool useUnscaledTime = false)
		{
			if (_shakeCoroutine != null)
			{
				StopCoroutine(_shakeCoroutine);
			}
			_shakeCoroutine = StartCoroutine(ShakeCameraCo(duration, amplitude, frequency, infinite, useUnscaledTime));
		}

		protected virtual IEnumerator ShakeCameraCo(float duration, float amplitude, float frequency, bool infinite, bool useUnscaledTime)
		{
			_targetAmplitude = amplitude;
			_targetFrequency = frequency;
			_timescaleMode = (useUnscaledTime ? TimescaleModes.Unscaled : TimescaleModes.Scaled);
			if (!infinite)
			{
				yield return new WaitForSeconds(duration);
				CameraReset();
			}
		}

		public virtual void CameraReset()
		{
			_targetAmplitude = IdleAmplitude;
			_targetFrequency = IdleFrequency;
		}

		public virtual void OnCameraShakeEvent(float duration, float amplitude, float frequency, float amplitudeX, float amplitudeY, float amplitudeZ, bool infinite, MMChannelData channelData, bool useUnscaledTime)
		{
			if (MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
			{
				ShakeCamera(duration, amplitude, frequency, infinite, useUnscaledTime);
			}
		}

		public virtual void OnCameraShakeStopEvent(MMChannelData channelData)
		{
			if (MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
			{
				if (_shakeCoroutine != null)
				{
					StopCoroutine(_shakeCoroutine);
				}
				CameraReset();
			}
		}

		protected virtual void OnEnable()
		{
			MMCameraShakeEvent.Register(OnCameraShakeEvent);
			MMCameraShakeStopEvent.Register(OnCameraShakeStopEvent);
		}

		protected virtual void OnDisable()
		{
			MMCameraShakeEvent.Unregister(OnCameraShakeEvent);
			MMCameraShakeStopEvent.Unregister(OnCameraShakeStopEvent);
		}

		protected virtual void TestShake()
		{
			MMCameraShakeEvent.Trigger(TestDuration, TestAmplitude, TestFrequency, 0f, 0f, 0f, infinite: false, new MMChannelData(ChannelMode, Channel, MMChannelDefinition));
		}
	}
}
