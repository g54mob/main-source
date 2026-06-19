using System.Collections.Generic;
using UnityEngine;

public class SmartMotion : MonoBehaviour
{
	public delegate void MotionFinishedCallback();

	private MotionFinishedCallback currentCallback;

	private List<TimedRotation> keyframes = new List<TimedRotation>();

	private int currentFrame;

	private Vector3 motionMultiplier = Vector3.one;

	private bool isMovingLimb;

	private LegController associatedController;

	public void SetController(LegController controller)
	{
		associatedController = controller;
	}

	public void setIsMovingLimb(bool limbVal)
	{
		isMovingLimb = limbVal;
	}

	public void FixedUpdate()
	{
		for (int i = 0; i < keyframes.Count; i++)
		{
			keyframes[i].FixedUpdate();
		}
	}

	public void AddKeyframe(float executionTime, Vector3 targetAngle, bool considerX = true, bool considerY = false, bool considerZ = true, int numGroundedLegsRequired = 0)
	{
		TimedRotation timedRotation = new TimedRotation(base.gameObject);
		timedRotation.InitializeTimedRotation(targetAngle, executionTime, considerX, considerY, considerZ, numGroundedLegsRequired);
		timedRotation.SetIsLimb(isMovingLimb);
		timedRotation.SetController(associatedController);
		keyframes.Add(timedRotation);
	}

	public void StartMotion()
	{
		StartMotion(Vector3.one);
	}

	public void StartMotion(MotionFinishedCallback callback, Vector3 motionMultiplier)
	{
		currentCallback = callback;
		StartMotion(motionMultiplier);
	}

	public void StartMotion(Vector3 motionMultiplier)
	{
		this.motionMultiplier = motionMultiplier;
		PlayNextMotion();
	}

	public void StopMotion()
	{
		currentCallback = null;
		Finish();
	}

	private void PlayNextMotion()
	{
		keyframes[currentFrame].StartTimedRotation(OnMotionFinished, motionMultiplier);
	}

	private void OnMotionFinished()
	{
		currentFrame++;
		if (currentFrame >= keyframes.Count)
		{
			Finish();
		}
		else
		{
			PlayNextMotion();
		}
	}

	private void Finish()
	{
		if (currentCallback != null)
		{
			currentCallback();
			currentCallback = null;
		}
		keyframes.Clear();
		Object.Destroy(this);
	}
}
