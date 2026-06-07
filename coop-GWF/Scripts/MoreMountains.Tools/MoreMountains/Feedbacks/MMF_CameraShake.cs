using MoreMountains.FeedbacksForThirdParty;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("Define camera shake properties (duration in seconds, amplitude and frequency), and this will broadcast a MMCameraShakeEvent with these same settings. You'll need to add a MMCameraShaker on your camera for this to work (or a MMCinemachineCameraShaker component on your virtual camera if you're using Cinemachine). Note that although this event and system was built for cameras in mind, you could technically use it to shake other objects as well.")]
	[FeedbackPath("Camera/Camera Shake")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	public class MMF_CameraShake : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Camera Shake", true, 57, false, false)]
		[Tooltip("whether or not this shake should repeat forever, until stopped")]
		public bool RepeatUntilStopped;

		[Tooltip("the properties of the shake (duration, intensity, frequenc)")]
		public MMCameraShakeProperties CameraShakeProperties = new MMCameraShakeProperties(0.1f, 0.2f, 40f);

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(CameraShakeProperties.Duration);
			}
			set
			{
				CameraShakeProperties.Duration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				float num = ComputeIntensity(feedbacksIntensity, position);
				MMCameraShakeEvent.Trigger(FeedbackDuration, CameraShakeProperties.Amplitude * num, CameraShakeProperties.Frequency, CameraShakeProperties.AmplitudeX * num, CameraShakeProperties.AmplitudeY * num, CameraShakeProperties.AmplitudeZ * num, RepeatUntilStopped, ChannelData, ComputedTimescaleMode == TimescaleModes.Unscaled);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				MMCameraShakeStopEvent.Trigger(ChannelData);
			}
		}

		public override void AutomaticShakerSetup()
		{
			if (false)
			{
				MMCinemachineHelpers.AutomaticCinemachineShakersSetup(Owner, "CinemachineImpulse");
			}
			else if (!((MMCameraShaker)Object.FindFirstObjectByType(typeof(MMCameraShaker)) != null))
			{
				GameObject gameObject = new GameObject("CameraRig");
				gameObject.transform.position = Camera.main.transform.position;
				GameObject gameObject2 = new GameObject("CameraShaker");
				gameObject2.transform.SetParent(gameObject.transform);
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.AddComponent<MMCameraShaker>();
				MMWiggle component = gameObject2.GetComponent<MMWiggle>();
				component.PositionActive = true;
				component.PositionWiggleProperties = new WiggleProperties();
				component.PositionWiggleProperties.WigglePermitted = false;
				component.PositionWiggleProperties.WiggleType = WiggleTypes.Noise;
				Camera.main.transform.SetParent(gameObject2.transform);
				MMDebug.DebugLogInfo("Added a CameraRig to the main camera. You're all set.");
			}
		}
	}
}
