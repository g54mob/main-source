using System;
using UnityEngine;

namespace VRTK.SecondaryControllerGrabActions
{
	[AddComponentMenu("VRTK/Scripts/Interactions/Interactables/Secondary Controller Grab Actions/VRTK_AxisScaleGrabAction")]
	public class VRTK_AxisScaleGrabAction : VRTK_BaseGrabAction
	{
		[Tooltip("The distance the secondary grabbing object must move away from the original grab position before the secondary grabbing object auto ungrabs the Interactable Object.")]
		public float ungrabDistance = 1f;

		[Tooltip("Locks the specified checked axes so they won't be scaled")]
		public Vector3State lockAxis = Vector3State.False;

		[Tooltip("If checked all the axes will be scaled together (unless locked)")]
		public bool uniformScaling;

		[Header("Obsolete Settings")]
		[Obsolete("`VRTK_AxisScaleGrabAction.lockXAxis` has been replaced with the `VRTK_AxisScaleGrabAction.lockAxis`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public bool lockXAxis;

		[Obsolete("`VRTK_AxisScaleGrabAction.lockYAxis` has been replaced with the `VRTK_AxisScaleGrabAction.lockAxis`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public bool lockYAxis;

		[Obsolete("`VRTK_AxisScaleGrabAction.lockZAxis` has been replaced with the `VRTK_AxisScaleGrabAction.lockAxis`. This parameter will be removed in a future version of VRTK.")]
		[ObsoleteInspector]
		public bool lockZAxis;

		protected Vector3 initialScale;

		protected float initalLength;

		protected float initialScaleFactor;

		public override void Initialise(VRTK_InteractableObject currentGrabbdObject, VRTK_InteractGrab currentPrimaryGrabbingObject, VRTK_InteractGrab currentSecondaryGrabbingObject, Transform primaryGrabPoint, Transform secondaryGrabPoint)
		{
			base.Initialise(currentGrabbdObject, currentPrimaryGrabbingObject, currentSecondaryGrabbingObject, primaryGrabPoint, secondaryGrabPoint);
			initialScale = currentGrabbdObject.transform.localScale;
			initalLength = (grabbedObject.transform.position - secondaryGrabbingObject.transform.position).magnitude;
			initialScaleFactor = currentGrabbdObject.transform.localScale.x / initalLength;
			if ((lockXAxis || lockYAxis || lockZAxis) && lockAxis == Vector3State.False)
			{
				lockAxis = new Vector3State(lockXAxis, lockYAxis, lockZAxis);
			}
		}

		public override void ProcessUpdate()
		{
			base.ProcessUpdate();
			CheckForceStopDistance(ungrabDistance);
		}

		public override void ProcessFixedUpdate()
		{
			base.ProcessFixedUpdate();
			if (initialised)
			{
				if (uniformScaling)
				{
					UniformScale();
				}
				else
				{
					NonUniformScale();
				}
			}
		}

		protected virtual void ApplyScale(Vector3 newScale)
		{
			Vector3 localScale = grabbedObject.transform.localScale;
			float num = (lockAxis.xState ? localScale.x : newScale.x);
			float num2 = (lockAxis.yState ? localScale.y : newScale.y);
			float num3 = (lockAxis.zState ? localScale.z : newScale.z);
			if (num > 0f && num2 > 0f && num3 > 0f)
			{
				grabbedObject.transform.localScale = new Vector3(num, num2, num3);
			}
		}

		protected virtual void NonUniformScale()
		{
			Vector3 vector = grabbedObject.transform.rotation * grabbedObject.transform.position;
			Vector3 vector2 = grabbedObject.transform.rotation * secondaryInitialGrabPoint.position;
			Vector3 vector3 = grabbedObject.transform.rotation * secondaryGrabbingObject.transform.position;
			float x = CalculateAxisScale(vector.x, vector2.x, vector3.x);
			float y = CalculateAxisScale(vector.y, vector2.y, vector3.y);
			float z = CalculateAxisScale(vector.z, vector2.z, vector3.z);
			Vector3 newScale = new Vector3(x, y, z) + initialScale;
			ApplyScale(newScale);
		}

		protected virtual void UniformScale()
		{
			float magnitude = (grabbedObject.transform.position - secondaryGrabbingObject.transform.position).magnitude;
			float num = initialScaleFactor * magnitude;
			Vector3 newScale = new Vector3(num, num, num);
			ApplyScale(newScale);
		}

		protected virtual float CalculateAxisScale(float centerPosition, float initialPosition, float currentPosition)
		{
			float num = currentPosition - initialPosition;
			return (centerPosition < initialPosition) ? num : (0f - num);
		}
	}
}
