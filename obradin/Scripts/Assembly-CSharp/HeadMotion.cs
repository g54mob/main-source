using System;
using System.Collections.Generic;
using UnityEngine;

public class HeadMotion : MonoBehaviour
{
	public enum Id
	{
		FromWalk = 0,
		FromWaves = 1,
		FromCrouch = 2,
		FromPullCorpse = 3
	}

	private class Offset
	{
		public Id id;

		public Vector3 val;

		public int priority;

		public Vector3 cameraLocalPositionWithoutSelf;

		public Offset(Id id_)
		{
			id = id_;
			val = Vector3.zero;
			priority = 0;
		}
	}

	public GameObject pinnedToCamera;

	public float pinnedToCameraMotionScale = 0.75f;

	private float weight;

	private Vector3 cameraLocalPosition;

	private List<Offset> offsets = new List<Offset>();

	private bool ignoringForOneFrame;

	private int crouchCountdown;

	private float crouchT;

	public static HeadMotion instance { get; private set; }

	private void OnEnable()
	{
		instance = this;
	}

	private void OnDisable()
	{
		instance = null;
	}

	private void Start()
	{
		weight = 1f;
		cameraLocalPosition = Vector3.zero;
		for (int i = 0; i < Enum.GetNames(typeof(Id)).Length; i++)
		{
			offsets.Add(new Offset((Id)i));
		}
	}

	private void LateUpdate()
	{
		if (ignoringForOneFrame)
		{
			weight = Mathf.Max(0f, weight - Clock.play.deltaTime);
			ignoringForOneFrame = false;
		}
		else
		{
			weight = Mathf.Min(1f, weight + Clock.play.deltaTime * 0.25f);
		}
		if (crouchCountdown > 0)
		{
			crouchT = Mathf.Min(1f, crouchT + Clock.play.deltaTime);
			crouchCountdown--;
		}
		else
		{
			crouchT = Mathf.Max(0f, crouchT - Clock.play.deltaTime);
		}
		SetOffset(Id.FromCrouch, Util.SmoothStepEdges(0f, 1f, crouchT) * -0.5f * Vector3.up);
		cameraLocalPosition = Vector3.zero;
		Matrix4x4 worldToLocalMatrix = base.transform.parent.worldToLocalMatrix;
		foreach (Offset offset in offsets)
		{
			cameraLocalPosition += worldToLocalMatrix.MultiplyVector(offset.val);
		}
		foreach (Offset offset2 in offsets)
		{
			offset2.cameraLocalPositionWithoutSelf = cameraLocalPosition - worldToLocalMatrix.MultiplyVector(offset2.val);
		}
		base.transform.localPosition = weight * cameraLocalPosition;
		if (pinnedToCamera != null)
		{
			Vector3 zero = Vector3.zero;
			foreach (Offset offset3 in offsets)
			{
				zero += worldToLocalMatrix.MultiplyVector(offset3.val) * pinnedToCameraMotionScale;
			}
			pinnedToCamera.transform.localPosition = weight * zero;
		}
		for (int i = 0; i < offsets.Count; i++)
		{
			offsets[i].priority = 0;
		}
		Player.instance.UpdateMainCameraFrustumPlanes();
	}

	public void IgnoreForOneFrame()
	{
		ignoringForOneFrame = true;
	}

	public void SetOffset(Id id, Vector3 offset, int priority = 0)
	{
		if (float.IsNaN(offset.x))
		{
			Debug.Break();
		}
		if (priority >= offsets[(int)id].priority)
		{
			offsets[(int)id].val = offset;
			offsets[(int)id].priority = priority;
		}
	}

	public void CrouchForOneFrame()
	{
		crouchCountdown = 2;
	}

	public Vector3 GetCameraWorldPositionWithoutOffset(Id id)
	{
		return base.transform.parent.localToWorldMatrix.MultiplyPoint(offsets[(int)id].cameraLocalPositionWithoutSelf);
	}

	public static HeadMotion FindGlobalInstance()
	{
		return instance;
	}
}
