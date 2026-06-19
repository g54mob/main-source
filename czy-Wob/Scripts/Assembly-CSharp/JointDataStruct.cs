using System;
using UnityEngine;

[Serializable]
public struct JointDataStruct
{
	[HideInInspector]
	public GameObject owningObject;

	[HideInInspector]
	public Vector3 owningObjectLocalPosition;

	[HideInInspector]
	public Quaternion owningObjectLocalRotation;

	public Rigidbody connectedBody;

	public Vector3 anchor;

	public Vector3 axis;

	public bool autoConfigureConnectedAnchor;

	public Vector3 connectedAnchor;

	public Vector3 secondaryAxis;

	public ConfigurableJointMotion xMotion;

	public ConfigurableJointMotion yMotion;

	public ConfigurableJointMotion zMotion;

	public ConfigurableJointMotion angularXMotion;

	public ConfigurableJointMotion angularYMotion;

	public ConfigurableJointMotion angularZMotion;

	public SoftJointLimitSpringStruct linearLimitSpring;

	public SoftJointLimitStruct linearLimit;

	public SoftJointLimitSpringStruct angularXLimitSpring;

	public SoftJointLimitStruct lowAngularXLimit;

	public SoftJointLimitStruct highAngularXLimit;

	public SoftJointLimitSpringStruct angularYZLimitSpring;

	public SoftJointLimitStruct angularYLimit;

	public SoftJointLimitStruct angularZLimit;

	public Vector3 targetPosition;

	public Vector3 targetVelocity;

	public JointDriveStruct xDrive;

	public JointDriveStruct yDrive;

	public JointDriveStruct zDrive;

	public Quaternion targetRotation;

	public Vector3 targetAngularVelocity;

	public RotationDriveMode rotationDriveMode;

	public JointDriveStruct angularXDrive;

	public JointDriveStruct angularYZDrive;

	public JointDriveStruct slerpDrive;

	public JointProjectionMode projectionMode;

	public float projectionDistance;

	public float projectionAngle;

	public bool configuredInWorldSpace;

	public bool swapBodies;

	public float breakForce;

	public float breakTorque;

	public bool enableCollision;

	public bool enablePreprocessing;

	public float massScale;

	public float connectedMassScale;

	public JointDataStruct(ConfigurableJoint jointRef)
	{
		owningObject = jointRef.gameObject;
		owningObjectLocalPosition = owningObject.transform.localPosition;
		owningObjectLocalRotation = owningObject.transform.localRotation;
		connectedBody = jointRef.connectedBody;
		anchor = jointRef.anchor;
		autoConfigureConnectedAnchor = jointRef.autoConfigureConnectedAnchor;
		axis = jointRef.axis;
		connectedAnchor = jointRef.connectedAnchor;
		secondaryAxis = jointRef.secondaryAxis;
		xMotion = jointRef.xMotion;
		yMotion = jointRef.yMotion;
		zMotion = jointRef.zMotion;
		angularXMotion = jointRef.angularXMotion;
		angularYMotion = jointRef.angularYMotion;
		angularZMotion = jointRef.angularZMotion;
		linearLimitSpring = new SoftJointLimitSpringStruct(jointRef.linearLimitSpring);
		linearLimit = new SoftJointLimitStruct(jointRef.linearLimit);
		angularXLimitSpring = new SoftJointLimitSpringStruct(jointRef.angularXLimitSpring);
		lowAngularXLimit = new SoftJointLimitStruct(jointRef.lowAngularXLimit);
		highAngularXLimit = new SoftJointLimitStruct(jointRef.highAngularXLimit);
		angularYZLimitSpring = new SoftJointLimitSpringStruct(jointRef.angularYZLimitSpring);
		angularYLimit = new SoftJointLimitStruct(jointRef.angularYLimit);
		angularZLimit = new SoftJointLimitStruct(jointRef.angularZLimit);
		targetPosition = jointRef.targetPosition;
		targetVelocity = jointRef.targetVelocity;
		xDrive = new JointDriveStruct(jointRef.xDrive);
		yDrive = new JointDriveStruct(jointRef.yDrive);
		zDrive = new JointDriveStruct(jointRef.zDrive);
		targetRotation = jointRef.targetRotation;
		targetAngularVelocity = jointRef.targetAngularVelocity;
		rotationDriveMode = jointRef.rotationDriveMode;
		angularXDrive = new JointDriveStruct(jointRef.angularXDrive);
		angularYZDrive = new JointDriveStruct(jointRef.angularYZDrive);
		slerpDrive = new JointDriveStruct(jointRef.slerpDrive);
		projectionMode = jointRef.projectionMode;
		projectionDistance = jointRef.projectionDistance;
		projectionAngle = jointRef.projectionAngle;
		configuredInWorldSpace = jointRef.configuredInWorldSpace;
		swapBodies = jointRef.swapBodies;
		breakForce = jointRef.breakForce;
		breakTorque = jointRef.breakTorque;
		enableCollision = jointRef.enableCollision;
		enablePreprocessing = jointRef.enablePreprocessing;
		massScale = jointRef.massScale;
		connectedMassScale = jointRef.connectedMassScale;
	}

	public void ApplyPropertiesToJoint(ConfigurableJoint jointRef, bool autoConfigure = false, bool moveOwningObject = true)
	{
		if (jointRef == null)
		{
			Debug.LogError("NULL joint passed into ApplyPropertiesToJoint.");
			return;
		}
		if (owningObject != null && moveOwningObject)
		{
			owningObject.transform.localPosition = owningObjectLocalPosition;
			owningObject.transform.localRotation = owningObjectLocalRotation;
		}
		jointRef.autoConfigureConnectedAnchor = autoConfigure;
		jointRef.connectedBody = connectedBody;
		jointRef.anchor = anchor;
		jointRef.axis = axis;
		if (!autoConfigure)
		{
			jointRef.connectedAnchor = connectedAnchor;
		}
		jointRef.secondaryAxis = secondaryAxis;
		jointRef.xMotion = xMotion;
		jointRef.yMotion = yMotion;
		jointRef.zMotion = zMotion;
		jointRef.angularXMotion = angularXMotion;
		jointRef.angularYMotion = angularYMotion;
		jointRef.angularZMotion = angularZMotion;
		jointRef.linearLimitSpring = linearLimitSpring.CreateSpring();
		jointRef.linearLimit = linearLimit.CreateLimit();
		jointRef.angularXLimitSpring = angularXLimitSpring.CreateSpring();
		jointRef.lowAngularXLimit = lowAngularXLimit.CreateLimit();
		jointRef.highAngularXLimit = highAngularXLimit.CreateLimit();
		jointRef.angularYZLimitSpring = angularYZLimitSpring.CreateSpring();
		jointRef.angularYLimit = angularYLimit.CreateLimit();
		jointRef.angularZLimit = angularZLimit.CreateLimit();
		jointRef.targetPosition = targetPosition;
		jointRef.targetVelocity = targetVelocity;
		jointRef.xDrive = xDrive.CreateDrive();
		jointRef.yDrive = yDrive.CreateDrive();
		jointRef.zDrive = zDrive.CreateDrive();
		jointRef.targetRotation = targetRotation;
		jointRef.targetAngularVelocity = targetAngularVelocity;
		jointRef.rotationDriveMode = rotationDriveMode;
		jointRef.angularXDrive = angularXDrive.CreateDrive();
		jointRef.angularYZDrive = angularYZDrive.CreateDrive();
		jointRef.slerpDrive = slerpDrive.CreateDrive();
		jointRef.projectionMode = projectionMode;
		jointRef.projectionDistance = projectionDistance;
		jointRef.projectionAngle = projectionAngle;
		jointRef.configuredInWorldSpace = configuredInWorldSpace;
		jointRef.swapBodies = swapBodies;
		jointRef.breakForce = breakForce;
		jointRef.breakTorque = breakTorque;
		jointRef.enableCollision = enableCollision;
		jointRef.enablePreprocessing = enablePreprocessing;
		jointRef.massScale = massScale;
		jointRef.connectedMassScale = connectedMassScale;
	}

	public ConfigurableJoint CreateJoint(bool autoConfigure = false, bool moveOwningObject = true)
	{
		if (owningObject != null && moveOwningObject)
		{
			Rigidbody component = owningObject.GetComponent<Rigidbody>();
			bool isKinematic = component.isKinematic;
			component.isKinematic = false;
			owningObject.transform.localPosition = owningObjectLocalPosition;
			owningObject.transform.localRotation = owningObjectLocalRotation;
			component.isKinematic = isKinematic;
		}
		ConfigurableJoint configurableJoint = owningObject.AddComponent<ConfigurableJoint>();
		ApplyPropertiesToJoint(configurableJoint, autoConfigure, moveOwningObject);
		return configurableJoint;
	}
}
