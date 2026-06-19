using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttachmentStruct
{
	public Coroutine attachRoutine;

	public Coroutine returnRoutine;

	public LineRenderer tendrilLine;

	public Rigidbody targetRB;

	public GameObject targetObject;

	public Vector3 attachmentPoint;

	public ConfigurableJoint attachmentJoint;

	public float tendrilLineStartLength;

	public Vector3 GetAttachmentPoint()
	{
		if (targetRB == null)
		{
			return attachmentPoint;
		}
		return targetRB.transform.TransformPoint(attachmentJoint.anchor);
	}

	public void CreateAttachmentJoint(Vector3 binPoint)
	{
		attachmentJoint = targetRB.gameObject.AddComponent<ConfigurableJoint>();
		attachmentJoint.configuredInWorldSpace = true;
		attachmentJoint.anchor = targetRB.transform.InverseTransformPoint(attachmentPoint);
		attachmentJoint.autoConfigureConnectedAnchor = false;
		attachmentJoint.connectedAnchor = binPoint;
		SoftJointLimitSpring linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 0f
		};
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = Vector3.Distance(binPoint, attachmentPoint),
			bounciness = 0.5f
		};
		attachmentJoint.linearLimit = linearLimit;
		attachmentJoint.linearLimitSpring = linearLimitSpring;
		SoftJointLimit lowAngularXLimit = default(SoftJointLimit);
		SoftJointLimit highAngularXLimit = default(SoftJointLimit);
		SoftJointLimit softJointLimit = default(SoftJointLimit);
		float num = 45f;
		float bounciness = 0.5f;
		lowAngularXLimit.limit = 0f - num;
		lowAngularXLimit.bounciness = bounciness;
		highAngularXLimit.limit = num;
		highAngularXLimit.bounciness = bounciness;
		softJointLimit.limit = num;
		softJointLimit.bounciness = bounciness;
		attachmentJoint.lowAngularXLimit = lowAngularXLimit;
		attachmentJoint.highAngularXLimit = highAngularXLimit;
		attachmentJoint.angularYLimit = softJointLimit;
		attachmentJoint.angularZLimit = softJointLimit;
		attachmentJoint.enablePreprocessing = false;
		attachmentJoint.projectionMode = JointProjectionMode.PositionAndRotation;
		attachmentJoint.projectionAngle = 1f;
		attachmentJoint.projectionDistance = 0.1f;
	}

	public void UpdateAttachmentPoint(float rate)
	{
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < tendrilLine.positionCount; i++)
		{
			list.Add(tendrilLine.GetPosition(i));
		}
		float num = Time.deltaTime * rate;
		Vector3 vector = list[list.Count - 1];
		Vector3 vector2 = list[list.Count - 2];
		int num2 = 2;
		float num3 = 0f;
		float num4 = Vector3.Distance(vector, vector2);
		int num5 = 0;
		while (num4 < num)
		{
			num2++;
			if (list.Count - num2 < 0)
			{
				break;
			}
			num3 += Vector3.Distance(vector, vector2);
			vector = vector2;
			vector2 = list[list.Count - num2];
			num4 += Vector3.Distance(vector, vector2);
			num5++;
		}
		Vector3 connectedAnchor = vector2;
		if (num4 > num)
		{
			if (num3 > num || num3 > num4)
			{
				Debug.LogError("ExtraDist is too big!");
			}
			connectedAnchor = MathUtil.GetPointAlongLine(vector, vector2, (num - num3) / (num4 - num3));
		}
		attachmentJoint.connectedAnchor = connectedAnchor;
		if (num5 > 0)
		{
			Vector3 position = tendrilLine.GetPosition(tendrilLine.positionCount - 1);
			while (num5 >= 0)
			{
				tendrilLine.positionCount--;
				num5--;
			}
			tendrilLine.positionCount++;
			tendrilLine.SetPosition(tendrilLine.positionCount - 1, position);
		}
	}
}
