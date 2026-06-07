using DV;
using DV.VRTK_Extensions;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	public class VRTK_TwoHandedPoleGrab : VRTK_BaseGrabAttach
	{
		private class TwoHandedGrabData
		{
			public Transform controllerAttachPoint;

			private readonly Transform referenceTransform;

			private readonly VRTK_InteractUse_DV use;

			private bool firstTwist = true;

			private bool requiresUseToTwist;

			private bool twistModifierPressed;

			private Transform playArea;

			private Vector3 previousRight;

			private Vector3 previousForward;

			public bool IsSecondary { get; set; }

			public Transform GrabReference { get; private set; }

			public bool TwistAndMoveAllowed
			{
				get
				{
					if (requiresUseToTwist)
					{
						return twistModifierPressed;
					}
					return true;
				}
			}

			public TwoHandedGrabData(Transform grabReference, Transform weightedReferenceTransform, Transform controllerAttachPoint, VRTK_InteractUse_DV use, bool secondary)
			{
				GrabReference = grabReference;
				referenceTransform = weightedReferenceTransform;
				this.controllerAttachPoint = controllerAttachPoint;
				IsSecondary = secondary;
				this.use = use;
				playArea = VRTK_DeviceFinder.PlayAreaTransform();
			}

			public float UpdateGrabReferenceAndGetAngleDelta()
			{
				float result = 0f;
				if (GrabReference == null || !TwistAndMoveAllowed)
				{
					return result;
				}
				GrabReference.transform.rotation = controllerAttachPoint.rotation;
				bool num = Mathf.Abs(Vector3.Dot(referenceTransform.forward, GrabReference.forward)) > 0.70710677f;
				(float forwardAngle, float rightAngle) tuple = CalculateAngleDeltas();
				float item = tuple.forwardAngle;
				float item2 = tuple.rightAngle;
				result = (num ? item2 : item);
				if (Mathf.Approximately(result, 0f))
				{
					return 0f;
				}
				return result;
			}

			public void UpdateGrabReferencePosition()
			{
				GrabReference.position = controllerAttachPoint.position;
			}

			public void SetInitialAngleVectors()
			{
				previousForward = GrabReference.forward;
				previousRight = GrabReference.right;
			}

			private (float forwardAngle, float rightAngle) CalculateAngleDeltas()
			{
				float item;
				float item2;
				if (!firstTwist)
				{
					Vector3 forward = referenceTransform.forward;
					item = Vector3.SignedAngle(previousForward, GrabReference.forward, forward);
					item2 = Vector3.SignedAngle(previousRight, GrabReference.right, forward);
				}
				else
				{
					firstTwist = false;
					item = (item2 = 0f);
				}
				previousForward = GrabReference.forward;
				previousRight = GrabReference.right;
				return (forwardAngle: item, rightAngle: item2);
			}

			public void ManageUseListeners(bool on)
			{
				if (!(use == null))
				{
					use.UseButtonPressed -= OnUseButtonPressed;
					use.UseButtonReleased -= OnUseButtonReleased;
					if (on && requiresUseToTwist)
					{
						use.UseButtonPressed += OnUseButtonPressed;
						use.UseButtonReleased += OnUseButtonReleased;
					}
				}
			}

			private void OnUseButtonPressed(object sender, ControllerInteractionEventArgs e)
			{
				SetInitialAngleVectors();
				firstTwist = true;
				twistModifierPressed = true;
			}

			private void OnUseButtonReleased(object sender, ControllerInteractionEventArgs e)
			{
				SetInitialAngleVectors();
				twistModifierPressed = false;
			}
		}

		private Transform farGrabReference;

		private Transform nearGrabReference;

		private Transform weightedTransformReference;

		private Transform playArea;

		private TwoHandedGrabData farGrabData;

		private TwoHandedGrabData nearGrabData;

		private GameObject primaryGrabbingObject;

		private GameObject secondaryGrabbingObject;

		private Rigidbody grabbedRigidbody;

		private Vector3 midpoint;

		private bool secondaryFar;

		[SerializeField]
		private bool isHeavy;

		[SerializeField]
		private float maxDistanceFactor = 0.25f;

		[SerializeField]
		private Vector4 translationFactors = new Vector4(0.75f, 1f, 0.5f, 0.75f);

		[SerializeField]
		private Vector4 angularFactors = new Vector4(0.75f, 1f, 0.5f, 0.75f);

		[SerializeField]
		private Vector3 centerOfMass = Vector3.zero;

		[SerializeField]
		private float constraintAngle = 115f;

		public float frontLimit;

		public float backLimit;

		public float untwistTime = 0.7f;

		private float untwistVel;

		public bool destroyJointImmediatelyOnThrow = true;

		private const float RESNAP_THRESHOLD = 0.0025000002f;

		public SoftJointLimit angularXLimitLow = new SoftJointLimit
		{
			limit = -1f
		};

		public SoftJointLimit angularXLimitHigh = new SoftJointLimit
		{
			limit = 1f
		};

		public SoftJointLimitSpring angularXLimitSpring = new SoftJointLimitSpring
		{
			spring = 1000f,
			damper = 50f
		};

		public SoftJointLimit angularYLimit = new SoftJointLimit
		{
			limit = 1f
		};

		public SoftJointLimit angularZLimit = new SoftJointLimit
		{
			limit = 1f
		};

		public SoftJointLimitSpring angularYZLimitSpring = new SoftJointLimitSpring
		{
			spring = 1000f,
			damper = 50f
		};

		protected Joint givenJoint;

		protected Joint controllerAttachJoint;

		public bool TwoHanded { get; private set; }

		public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
		{
			if (base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint))
			{
				InitPrimaryGrab(grabbingObject, givenGrabbedObject, snapToController: true);
				return true;
			}
			return false;
		}

		private void InitPrimaryGrab(GameObject grabbingObject, GameObject givenGrabbedObject, bool snapToController)
		{
			primaryGrabbingObject = grabbingObject;
			grabbedSnapHandle = GetSnapHandle(grabbingObject);
			if (snapToController)
			{
				SnapObjectToGrabToController(givenGrabbedObject);
			}
			secondaryFar = false;
			CreateJoint(givenGrabbedObject);
		}

		public override void StopGrab(bool applyGrabbingObjectVelocity)
		{
			ReleaseObject(applyGrabbingObjectVelocity);
			base.StopGrab(applyGrabbingObjectVelocity);
			ClearTwoHandedData();
		}

		public bool StopSecondaryGrab(bool becomePrimary, VRTK_InteractableObject ungrabbedObject)
		{
			ClearTwoHandedData();
			if (!becomePrimary)
			{
				initialAttachPoint.position = controllerAttachPoint.transform.position;
				initialAttachPoint.rotation = controllerAttachPoint.transform.rotation;
				secondaryGrabbingObject = null;
				InitPrimaryGrab(primaryGrabbingObject, ungrabbedObject.gameObject, snapToController: false);
				return false;
			}
			StartGrab(secondaryGrabbingObject, ungrabbedObject.gameObject, PipaUtils.PipaTransform(secondaryGrabbingObject.gameObject).GetComponent<Rigidbody>());
			secondaryGrabbingObject = null;
			return true;
		}

		private void ClearTwoHandedData()
		{
			TwoHanded = (secondaryFar = false);
			if (nearGrabData != null)
			{
				nearGrabData.ManageUseListeners(on: false);
			}
			if (farGrabData != null)
			{
				farGrabData.ManageUseListeners(on: false);
			}
			nearGrabData = (farGrabData = null);
			midpoint = Vector3.zero;
			if ((bool)grabbedRigidbody)
			{
				grabbedRigidbody = null;
			}
			if (farGrabReference != null)
			{
				Object.Destroy(farGrabReference.gameObject);
			}
			if (nearGrabReference != null)
			{
				Object.Destroy(nearGrabReference.gameObject);
			}
			if (weightedTransformReference != null)
			{
				Object.Destroy(weightedTransformReference.gameObject);
			}
		}

		public bool StartSecondaryGrab(GameObject secondaryGrabbingObject, Rigidbody givenControllerAttachPoint, Transform grabPoint)
		{
			if (grabbedObject == null || givenControllerAttachPoint == null)
			{
				return false;
			}
			ReleaseFromController(applyGrabbingObjectVelocity: false);
			this.secondaryGrabbingObject = secondaryGrabbingObject;
			Transform parent = VRTK_DeviceFinder.PlayAreaTransform();
			Transform transform = new GameObject("PrimaryGrabReference").transform;
			transform.SetParent(parent, worldPositionStays: true);
			transform.position = controllerAttachPoint.transform.position;
			Transform transform2 = new GameObject("SecondaryGrabReference").transform;
			transform2.SetParent(parent, worldPositionStays: true);
			transform2.transform.position = givenControllerAttachPoint.transform.position;
			Transform transform3 = grabbedObject.transform;
			weightedTransformReference = new GameObject("WeightedTransformReference").transform;
			weightedTransformReference.SetParent(parent, worldPositionStays: true);
			weightedTransformReference.position = transform3.position;
			weightedTransformReference.rotation = transform3.rotation;
			float z = weightedTransformReference.InverseTransformPoint(transform.position).z;
			float z2 = weightedTransformReference.InverseTransformPoint(transform2.position).z;
			secondaryFar = z < z2;
			Transform transform4;
			Transform transform5;
			VRTK_InteractUse_DV component;
			VRTK_InteractUse_DV component2;
			if (!secondaryFar)
			{
				nearGrabReference = transform;
				farGrabReference = transform2;
				transform4 = controllerAttachPoint.transform;
				transform5 = givenControllerAttachPoint.transform;
				component = primaryGrabbingObject.GetComponent<VRTK_InteractUse_DV>();
				component2 = secondaryGrabbingObject.GetComponent<VRTK_InteractUse_DV>();
			}
			else
			{
				nearGrabReference = transform2;
				farGrabReference = transform;
				transform4 = givenControllerAttachPoint.transform;
				transform5 = controllerAttachPoint.transform;
				component = secondaryGrabbingObject.GetComponent<VRTK_InteractUse_DV>();
				component2 = primaryGrabbingObject.GetComponent<VRTK_InteractUse_DV>();
			}
			Vector3 localPosition = initialAttachPoint.localPosition;
			localPosition.x = (localPosition.y = 0f);
			initialAttachPoint.localPosition = localPosition;
			nearGrabData = new TwoHandedGrabData(nearGrabReference, weightedTransformReference, transform4, component, secondaryFar);
			farGrabData = new TwoHandedGrabData(farGrabReference, weightedTransformReference, transform5, component2, !secondaryFar);
			RecalculateMidpoint();
			TwoHanded = true;
			nearGrabData.ManageUseListeners(on: true);
			farGrabData.ManageUseListeners(on: true);
			grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
			centerOfMass = ((grabbedRigidbody != null) ? grabbedRigidbody.centerOfMass : Vector3.zero);
			centerOfMass.x = (centerOfMass.y = 0f);
			return true;
		}

		private void RecalculateMidpoint()
		{
			if (playArea == null)
			{
				playArea = VRTK_DeviceFinder.PlayAreaTransform();
			}
			midpoint = playArea.InverseTransformPoint((farGrabData.controllerAttachPoint.position + nearGrabData.controllerAttachPoint.position) * 0.5f);
		}

		protected override void Initialise()
		{
			tracked = false;
			climbable = false;
			kinematic = false;
		}

		protected virtual void SetSnappedObjectPosition(GameObject obj)
		{
			if (grabbedSnapHandle == null)
			{
				obj.transform.position = controllerAttachPoint.transform.position;
				return;
			}
			obj.transform.rotation = controllerAttachPoint.transform.rotation * Quaternion.Inverse(grabbedSnapHandle.transform.localRotation);
			obj.transform.position = controllerAttachPoint.transform.position - (grabbedSnapHandle.transform.position - obj.transform.position);
		}

		protected virtual void SnapObjectToGrabToController(GameObject givenGrabbedObject)
		{
			if (!precisionGrab)
			{
				SetSnappedObjectPosition(givenGrabbedObject);
			}
		}

		public override void ProcessFixedUpdate()
		{
			if (TimeUtil.IsFlowing)
			{
				UpdatePositionAndRotation();
			}
		}

		private void UpdatePositionAndRotation()
		{
			if (!(grabbedObject == null) && TwoHanded)
			{
				ApplyTwoHandedTwist();
				RecalculateTwoHandedParameters();
			}
		}

		private void RecalculateTwoHandedParameters()
		{
			Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
			Vector3 position = transform.InverseTransformPoint(weightedTransformReference.position) - midpoint;
			nearGrabData.UpdateGrabReferencePosition();
			farGrabData.UpdateGrabReferencePosition();
			RecalculateMidpoint();
			Vector3 position2 = transform.InverseTransformPoint(weightedTransformReference.position) - midpoint;
			Vector3 vector = transform.TransformPoint(position2) - transform.TransformPoint(position);
			weightedTransformReference.position -= vector;
			Vector3 normalized = (nearGrabData.controllerAttachPoint.position - farGrabData.controllerAttachPoint.position).normalized;
			Vector3 normalized2 = Vector3.Cross(weightedTransformReference.forward, normalized).normalized;
			if (!Mathf.Approximately(normalized2.sqrMagnitude, 0f))
			{
				float angle = Vector3.SignedAngle(weightedTransformReference.forward, normalized, normalized2);
				Vector3 eulerAngles = weightedTransformReference.rotation.eulerAngles;
				bool flag = Mathf.Abs(Vector3.Dot(weightedTransformReference.forward, Vector3.up)) < 0.996f;
				float z = eulerAngles.z;
				weightedTransformReference.RotateAround(transform.TransformPoint(midpoint), normalized2, angle);
				if (!flag && Mathf.Abs(Vector3.Dot(weightedTransformReference.forward, Vector3.up)) < 0.996f)
				{
					Vector3 eulerAngles2 = weightedTransformReference.rotation.eulerAngles;
					eulerAngles2.z = z;
					weightedTransformReference.rotation = Quaternion.Euler(eulerAngles2);
				}
			}
			nearGrabData.UpdateGrabReferencePosition();
			farGrabData.UpdateGrabReferencePosition();
			Transform obj = grabbedObject.transform;
			float t = Mathf.Abs(obj.InverseTransformPoint(transform.TransformPoint(midpoint)).z - centerOfMass.z) / maxDistanceFactor;
			float t2;
			float t3;
			if (isHeavy)
			{
				t2 = Mathf.Lerp(translationFactors[3], translationFactors[2], t);
				t3 = Mathf.Lerp(angularFactors[3], angularFactors[2], t);
			}
			else
			{
				t2 = Mathf.Lerp(translationFactors[1], translationFactors[0], t);
				t3 = Mathf.Lerp(angularFactors[1], angularFactors[0], t);
			}
			Vector3 desiredPosition = Vector3.Lerp(obj.position, weightedTransformReference.position, t2);
			Quaternion desiredRotation = Quaternion.Slerp(obj.rotation, weightedTransformReference.rotation, t3);
			PhysicsMovememnt(desiredPosition, desiredRotation);
		}

		public void PhysicsMovememnt(Vector3 desiredPosition, Quaternion desiredRotation)
		{
			if (!(grabbedObject == null))
			{
				Vector3 vector = desiredPosition - grabbedObject.transform.position;
				(desiredRotation * Quaternion.Inverse(grabbedObject.transform.rotation)).ToAngleAxis(out var angle, out var axis);
				angle = ((!(angle > 180f)) ? angle : (angle -= 360f));
				if (angle != 0f)
				{
					Vector3 angularVelocity = Vector3.MoveTowards(target: angle * axis, current: grabbedObjectRigidBody.angularVelocity, maxDistanceDelta: 10f);
					grabbedObjectRigidBody.angularVelocity = angularVelocity;
				}
				Vector3 target = vector / Time.fixedDeltaTime;
				Vector3 velocity = Vector3.MoveTowards(grabbedObjectRigidBody.velocity, target, 10f);
				grabbedObjectRigidBody.velocity = velocity;
			}
		}

		private void ApplyTwoHandedTwist()
		{
			if (!TwoHanded)
			{
				return;
			}
			float num = farGrabData.UpdateGrabReferenceAndGetAngleDelta();
			float num2 = nearGrabData.UpdateGrabReferenceAndGetAngleDelta();
			float num3 = ((!(Mathf.Abs(num) < Mathf.Abs(num2))) ? num : num2);
			Vector3 eulerAngles = weightedTransformReference.rotation.eulerAngles;
			if (num3 != 0f)
			{
				eulerAngles = weightedTransformReference.rotation.eulerAngles;
				eulerAngles.z = (eulerAngles.z + num3 + 360f) % 360f;
			}
			if (Mathf.Abs(Vector3.Dot(grabbedObject.transform.forward, Vector3.up)) < 0.87f)
			{
				float num4 = ((eulerAngles.z < 180f) ? (0f - eulerAngles.z) : (360f - eulerAngles.z));
				if (Mathf.Abs(num4) < 0.001f)
				{
					eulerAngles.z = 0f;
				}
				else
				{
					float num5 = Mathf.SmoothDamp(0f, num4, ref untwistVel, untwistTime);
					eulerAngles.z += num5;
				}
			}
			weightedTransformReference.rotation = Quaternion.Euler(eulerAngles);
		}

		private void ConstrainZRotation()
		{
			Transform transform = grabbedObject.transform;
			if (!(Mathf.Abs(Vector3.Dot(transform.forward, Vector3.up)) > 0.70710677f))
			{
				Vector3 eulerAngles = transform.eulerAngles;
				float num = (eulerAngles.z + 360f) % 360f;
				float num2 = 360f - constraintAngle;
				if (num >= constraintAngle && num <= num2)
				{
					float z = ((num - constraintAngle > num2 - num) ? num2 : constraintAngle);
					eulerAngles.z = z;
					transform.rotation = Quaternion.Euler(eulerAngles);
				}
			}
		}

		public void ReactToForceMove(bool start)
		{
			if (TwoHanded)
			{
				nearGrabData.UpdateGrabReferencePosition();
				farGrabData.UpdateGrabReferencePosition();
				nearGrabData.SetInitialAngleVectors();
				farGrabData.SetInitialAngleVectors();
				RecalculateMidpoint();
			}
		}

		public void ToggleHeaviness(bool isHeavy)
		{
			this.isHeavy = isHeavy;
		}

		protected override Rigidbody ReleaseFromController(bool applyGrabbingObjectVelocity)
		{
			if (controllerAttachJoint != null)
			{
				Rigidbody component = controllerAttachJoint.GetComponent<Rigidbody>();
				DestroyJoint(destroyJointImmediatelyOnThrow, applyGrabbingObjectVelocity);
				controllerAttachJoint = null;
				return component;
			}
			return null;
		}

		protected virtual void OnJointBreak(float force)
		{
			ForceReleaseGrab();
		}

		protected virtual void CreateJoint(GameObject obj)
		{
			if (givenJoint != null)
			{
				DestroyJoint(withDestroyImmediate: true, applyGrabbingObjectVelocity: false);
			}
			Vector3 translation = obj.transform.InverseTransformPoint(controllerAttachPoint.transform.position);
			translation.z = 0f;
			if (translation.sqrMagnitude > 0.0025000002f)
			{
				obj.transform.Translate(translation, Space.Self);
			}
			ConfigurableJoint configurableJoint = obj.AddComponent<ConfigurableJoint>();
			configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
			configurableJoint.xMotion = ConfigurableJointMotion.Limited;
			configurableJoint.yMotion = ConfigurableJointMotion.Limited;
			configurableJoint.zMotion = ConfigurableJointMotion.Limited;
			configurableJoint.lowAngularXLimit = angularXLimitLow;
			configurableJoint.highAngularXLimit = angularXLimitHigh;
			configurableJoint.angularXLimitSpring = angularXLimitSpring;
			configurableJoint.angularYLimit = angularYLimit;
			configurableJoint.angularZLimit = angularZLimit;
			configurableJoint.angularYZLimitSpring = angularYZLimitSpring;
			givenJoint = configurableJoint;
			if (precisionGrab)
			{
				givenJoint.anchor = obj.transform.InverseTransformPoint(controllerAttachPoint.position);
			}
			controllerAttachJoint = givenJoint;
			controllerAttachJoint.breakForce = ((!grabbedObjectScript.IsDroppable() || grabbedObjectScript.validDrop == VRTK_InteractableObject.ValidDropTypes.DropValidSnapDropZone) ? float.PositiveInfinity : controllerAttachJoint.breakForce);
			controllerAttachJoint.connectedBody = controllerAttachPoint;
		}

		protected virtual void DestroyJoint(bool withDestroyImmediate, bool applyGrabbingObjectVelocity)
		{
			if (!(controllerAttachJoint == null) && !(controllerAttachJoint.connectedBody == null))
			{
				controllerAttachJoint.connectedBody = null;
				if (withDestroyImmediate || applyGrabbingObjectVelocity)
				{
					Object.DestroyImmediate(controllerAttachJoint);
				}
				else
				{
					Object.Destroy(controllerAttachJoint);
				}
			}
		}
	}
}
