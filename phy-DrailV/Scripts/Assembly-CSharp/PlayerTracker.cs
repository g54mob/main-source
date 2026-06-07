using System;
using UnityEngine;

public class PlayerTracker : AWorldMoverPlayerTracker
{
	public Transform actualPlayer;

	public Transform cameraTransform;

	public bool applyOriginShift = true;

	private const float SYNC_THRESHOLD_SQRDIST = 1f;

	private void Awake()
	{
		base.transform.SetParent(null, worldPositionStays: true);
	}

	private void OnEnable()
	{
		PlayerManager.PlayerChanged += OnPlayerOrCameraChanged;
		PlayerManager.CameraChanged += OnPlayerOrCameraChanged;
		OnPlayerOrCameraChanged();
	}

	private void OnDisable()
	{
		PlayerManager.PlayerChanged -= OnPlayerOrCameraChanged;
		PlayerManager.CameraChanged -= OnPlayerOrCameraChanged;
	}

	private void OnPlayerOrCameraChanged()
	{
		actualPlayer = PlayerManager.PlayerTransform;
		cameraTransform = ((PlayerManager.ActiveCamera != null) ? PlayerManager.ActiveCamera.transform : null);
	}

	private void LateUpdate()
	{
		if ((bool)actualPlayer)
		{
			if (actualPlayer == base.transform)
			{
				throw new InvalidOperationException("PlayerTracker can't track itself");
			}
			if (actualPlayer.root != null && actualPlayer.root == base.transform.root)
			{
				throw new InvalidOperationException("PlayerTracker and actualPlayer can't be in the same hierarchy");
			}
			base.transform.position = GetPosition();
		}
	}

	public override bool IsSynced()
	{
		if (!actualPlayer)
		{
			return false;
		}
		return (GetPosition() - base.transform.position).sqrMagnitude <= 1f;
	}

	private Vector3 GetPosition()
	{
		if ((bool)cameraTransform)
		{
			return cameraTransform.position;
		}
		if ((bool)actualPlayer)
		{
			return actualPlayer.position;
		}
		return Vector3.zero;
	}

	public override Transform GetTrackerTransform()
	{
		return base.transform;
	}

	public override Transform GetActualPlayer()
	{
		return actualPlayer;
	}

	public override void SetActualPlayer(Transform playerTransform)
	{
		actualPlayer = playerTransform;
	}

	public override bool ShouldApplyOriginShift()
	{
		return applyOriginShift;
	}

	public override void SetShouldApplyOriginShift(bool value)
	{
		applyOriginShift = value;
	}
}
