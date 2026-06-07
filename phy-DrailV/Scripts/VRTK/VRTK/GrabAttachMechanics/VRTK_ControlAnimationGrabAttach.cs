using System;
using System.Collections;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Grab Attach Mechanics/VRTK_ControlAnimationGrabAttach")]
	public class VRTK_ControlAnimationGrabAttach : VRTK_BaseGrabAttach
	{
		[Tooltip("The maximum distance the grabbing object is away from the Interactable Object before it is automatically released.")]
		public float detachDistance = 1f;

		[Header("Animation Settings", order = 2)]
		[Tooltip("An Animation with the timeline to scrub through on grab. If this is set then the `Animator Timeline` will be ignored if it is also set.")]
		public Animation animationTimeline;

		[Tooltip("An Animator with the timeline to scrub through on grab.")]
		public Animator animatorTimeline;

		[Tooltip("The maximum amount of frames in the timeline.")]
		public float maxFrames = 1f;

		[Tooltip("An amount to multiply the distance by to determine the scrubbed frame to be on.")]
		public float distanceMultiplier = 1f;

		[Tooltip("If this is checked then the animation will rewind to the start on ungrab.")]
		public bool rewindOnRelease;

		[Tooltip("The speed in which the animation rewind will be multiplied by.")]
		public float rewindSpeedMultplier = 1f;

		protected float animationSpeed;

		protected float frameOffset;

		protected float currentFrame;

		protected Coroutine resetTimelineRoutine;

		protected bool atEnd;

		protected string animationName = "";

		public event ControlAnimationGrabAttachEventHandler AnimationFrameAtStart;

		public event ControlAnimationGrabAttachEventHandler AnimationFrameAtEnd;

		public event ControlAnimationGrabAttachEventHandler AnimationFrameChanged;

		public virtual void OnAnimationFrameChanged(ControlAnimationGrabAttachEventArgs e)
		{
			if (this.AnimationFrameChanged != null)
			{
				this.AnimationFrameChanged(this, e);
			}
		}

		public virtual void OnAnimationFrameAtStart(ControlAnimationGrabAttachEventArgs e)
		{
			if (this.AnimationFrameAtStart != null)
			{
				this.AnimationFrameAtStart(this, e);
			}
		}

		public virtual void OnAnimationFrameAtEnd(ControlAnimationGrabAttachEventArgs e)
		{
			if (this.AnimationFrameAtEnd != null)
			{
				this.AnimationFrameAtEnd(this, e);
			}
		}

		public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
		{
			CancelResetTimeline();
			atEnd = false;
			return base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint);
		}

		public override void StopGrab(bool applyGrabbingObjectVelocity)
		{
			base.StopGrab(applyGrabbingObjectVelocity);
			frameOffset = currentFrame;
			if (rewindOnRelease)
			{
				RewindAnimation();
			}
		}

		public override Transform CreateTrackPoint(Transform controllerPoint, GameObject currentGrabbedObject, GameObject currentGrabbingObject, ref bool customTrackPoint)
		{
			customTrackPoint = true;
			Transform obj = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, currentGrabbedObject.name, "ControlAnimation", "AttachPoint")).transform;
			obj.SetParent(null);
			obj.position = (precisionGrab ? controllerPoint.position : currentGrabbedObject.transform.position);
			return obj;
		}

		public override void ProcessUpdate()
		{
			if (trackPoint != null)
			{
				if (Vector3.Distance(trackPoint.position, initialAttachPoint.position) > detachDistance && grabbedObjectScript.IsDroppable())
				{
					ForceReleaseGrab();
					return;
				}
				float num = Vector3.Distance(trackPoint.position, controllerAttachPoint.transform.position);
				SetFrame(num + frameOffset);
			}
		}

		public virtual void SetFrame(float frame)
		{
			float num = frame * distanceMultiplier;
			SetTimelineSpeed(animationSpeed);
			if (num < maxFrames)
			{
				SetTimelinePosition(num);
				if (num == 0f)
				{
					OnAnimationFrameAtStart(SetEventPayload(num));
				}
				OnAnimationFrameChanged(SetEventPayload(num));
				currentFrame = frame;
				atEnd = false;
			}
			else if (!atEnd)
			{
				OnAnimationFrameAtEnd(SetEventPayload(num));
				atEnd = true;
			}
		}

		public virtual void RewindAnimation()
		{
			CancelResetTimeline();
			resetTimelineRoutine = StartCoroutine(ResetTimeline(currentFrame));
		}

		protected virtual void OnDisable()
		{
			CancelResetTimeline();
		}

		protected override void Initialise()
		{
			tracked = false;
			climbable = false;
			kinematic = true;
			InitTimeline();
		}

		protected virtual void InitTimeline()
		{
			animatorTimeline = ((animatorTimeline != null) ? animatorTimeline : GetComponent<Animator>());
			animationTimeline = ((animationTimeline != null) ? animationTimeline : GetComponent<Animation>());
			if (animationTimeline != null)
			{
				if (!animationTimeline.clip.legacy)
				{
					VRTK_Logger.Error("The `VRTK_ControlAnimationGrabAttach` script is using an `Animation Timeline` that has not been set to `Legacy Animation`. Only legacy animations are supported.");
				}
				{
					IEnumerator enumerator = animationTimeline.GetEnumerator();
					try
					{
						if (enumerator.MoveNext())
						{
							AnimationState animationState = (AnimationState)enumerator.Current;
							animationName = animationState.name;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
			SetTimelineSpeed(animationSpeed);
		}

		protected virtual void SetTimelineSpeed(float speed)
		{
			if (animationTimeline != null)
			{
				animationTimeline[animationName].speed = speed;
			}
			else if (animatorTimeline != null)
			{
				animatorTimeline.speed = speed;
			}
		}

		protected virtual void SetTimelinePosition(float framePosition)
		{
			if (animationTimeline != null)
			{
				animationTimeline[animationName].time = framePosition;
				animationTimeline.Play(animationName);
			}
			else if (animatorTimeline != null)
			{
				animatorTimeline.Play(0, 0, framePosition);
			}
		}

		protected virtual void CancelResetTimeline()
		{
			if (resetTimelineRoutine != null)
			{
				StopCoroutine(resetTimelineRoutine);
			}
		}

		protected virtual IEnumerator ResetTimeline(float frame)
		{
			while (frame > 0f)
			{
				SetFrame(frame);
				frame -= Time.fixedDeltaTime * rewindSpeedMultplier;
				frameOffset = currentFrame;
				yield return null;
			}
			SetFrame(0f);
		}

		protected virtual ControlAnimationGrabAttachEventArgs SetEventPayload(float frame)
		{
			ControlAnimationGrabAttachEventArgs result = default(ControlAnimationGrabAttachEventArgs);
			result.interactingObject = ((grabbedObjectScript != null) ? grabbedObjectScript.GetGrabbingObject() : null);
			result.currentFrame = frame;
			return result;
		}
	}
}
