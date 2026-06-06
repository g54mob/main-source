using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class CameraControllerCinematicLock
{
	[SerializeField]
	private Transform _target;

	[Space]
	[SerializeField]
	[ConditionalHide("_target", true)]
	[Range(0f, 1f)]
	private float _zoomLevel;

	[SerializeField]
	[ConditionalHide("_target", true)]
	private CameraController.TargetFocusOrientationType _orientation;

	[SerializeField]
	[ConditionalHide("_target", true)]
	[Tooltip("The camera is always locked for LookAt and FaceTarget orientation, toggle this to also lock it for the other orientations.")]
	private bool _lockCamera;

	[SerializeField]
	[ConditionalHide("_target", true)]
	[Tooltip("The camera is always centered on its transform for LookAt and FaceTarget orientation, toggle this to center for the other orientations.")]
	private bool _centerOnTransform;

	private bool _isTweening;

	public IEnumerator LockRoutine()
	{
		if ((bool)_target)
		{
			_isTweening = true;
			if (ShouldLock())
			{
				CameraController.Instance.CinematicLock(_target, _zoomLevel, _orientation, OnCenterOnTransformCompleted);
			}
			else
			{
				CameraController.Instance.CenterOnTransform(_target, _zoomLevel, _orientation, OnCenterOnTransformCompleted);
			}
			while (_isTweening)
			{
				yield return null;
			}
		}
	}

	public void Unlock()
	{
		if ((bool)_target && ShouldLock())
		{
			CameraController.Instance.UnlockCinematicLock(ShoudlCenterOnTransform());
		}
	}

	public bool ShouldLock()
	{
		if (!_lockCamera && _orientation != CameraController.TargetFocusOrientationType.LookAtTarget)
		{
			return _orientation == CameraController.TargetFocusOrientationType.FaceTarget;
		}
		return true;
	}

	public bool ShoudlCenterOnTransform()
	{
		if (!_centerOnTransform && _orientation != CameraController.TargetFocusOrientationType.LookAtTarget)
		{
			return _orientation == CameraController.TargetFocusOrientationType.FaceTarget;
		}
		return true;
	}

	private void OnCenterOnTransformCompleted()
	{
		_isTweening = false;
	}
}
