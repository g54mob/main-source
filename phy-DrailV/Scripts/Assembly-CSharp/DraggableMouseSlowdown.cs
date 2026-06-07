using DV.Interaction;
using UnityEngine;

public class DraggableMouseSlowdown : MonoBehaviour
{
	public Grabber grabber;

	public CustomFirstPersonController fpsController;

	private void Start()
	{
		if (grabber == null || fpsController == null)
		{
			Debug.LogError("grabber or fpsController is not set! Destroying self.");
			Object.Destroy(this);
		}
		else
		{
			grabber.GrabStarted += OnGrabbed;
			grabber.GrabStopped += OnUnGrabbed;
		}
	}

	private void OnGrabbed(AGrabHandler grabHandler)
	{
		if (grabHandler != null && !grabHandler.AllowPickupAndThrow())
		{
			fpsController.m_MouseLook.RequestMouseSensitivityState(this, MouseSensitivityState.Slow);
		}
	}

	private void OnUnGrabbed(AGrabHandler grabHandler)
	{
		fpsController.m_MouseLook.RemoveRequest(this);
	}
}
