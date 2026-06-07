using System.Linq;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

namespace DV.CabControls
{
	public class SpeedZoneControlTouchBehaviour : MonoBehaviour, IControlTouchBehaviourVRTK
	{
		private const float RESET_DISTANCE = 0.003f;

		private const float MIN_SPEED = 0.09f;

		public Transform direction;

		public bool onlyDoForwardDirection;

		public bool useOnUntouch;

		private ControlImplBase controlImplBase;

		private GameObject controller;

		private Transform pipa;

		private Vector3 localToControllerFingerPosition;

		private Vector3 lastLocalToDirectionPosition;

		private Vector3 lastLocalToParentPipaPosition;

		private Vector3 localToParentButtonPosition;

		private bool wasUsedThisTouch;

		private Collider[] cols;

		protected virtual void Start()
		{
			localToParentButtonPosition = base.transform.localPosition;
			controlImplBase = GetComponent<ControlImplBase>();
			base.enabled = false;
			cols = GetComponentsInChildren<Collider>();
		}

		private void OnDestroy()
		{
			if ((bool)direction)
			{
				Object.Destroy(direction.gameObject);
			}
		}

		protected virtual void Update()
		{
			Vector3 position = controller.transform.TransformPoint(localToControllerFingerPosition);
			Vector3 vector = direction.InverseTransformPoint(position);
			Vector3 position2 = pipa.position;
			Vector3 lastPipaPosition = base.transform.parent.TransformPoint(lastLocalToParentPipaPosition);
			Vector3 pipaMovement = position2 - lastPipaPosition;
			bool castLine = pipaMovement != Vector3.zero;
			bool flag = cols.Select(delegate(Collider c)
			{
				if (c.ClosestPoint(lastPipaPosition) == lastPipaPosition)
				{
					return true;
				}
				RaycastHit hitInfo;
				return castLine && c.Raycast(new Ray(lastPipaPosition, pipaMovement.normalized), out hitInfo, pipaMovement.magnitude);
			}).Contains(value: true);
			float num = ((controlImplBase.Value > 0.5f) ? 1f : (-1f));
			if (onlyDoForwardDirection)
			{
				num = -1f;
			}
			if (wasUsedThisTouch)
			{
				if (!useOnUntouch && (vector.y - lastLocalToDirectionPosition.y) * num > 0.003f && !flag)
				{
					wasUsedThisTouch = false;
				}
				lastLocalToParentPipaPosition = base.transform.InverseTransformPoint(position2);
				return;
			}
			Vector3 vector2 = lastLocalToDirectionPosition - vector;
			if (Vector3.Dot(Vector3.up, vector2.normalized) * num > 0.707f && flag)
			{
				vector2.y *= num;
				vector2.y /= Time.deltaTime;
				if (vector2.y > 0.09f)
				{
					HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(controller), HapticIntensityType.Normal);
					controlImplBase.Use();
					wasUsedThisTouch = true;
				}
			}
			lastLocalToDirectionPosition = vector;
			lastLocalToParentPipaPosition = base.transform.InverseTransformPoint(position2);
		}

		public void Touch(InteractableObjectEventArgs e)
		{
			base.enabled = true;
			if (!controller)
			{
				controller = e.interactingObject;
				pipa = controller.transform.Find("[pipa]");
				localToControllerFingerPosition = controller.transform.InverseTransformPoint(base.transform.parent.TransformPoint(localToParentButtonPosition));
				lastLocalToParentPipaPosition = base.transform.parent.InverseTransformPoint(pipa.position);
			}
			wasUsedThisTouch = false;
		}

		public void UnTouch(InteractableObjectEventArgs e)
		{
			if (useOnUntouch && wasUsedThisTouch)
			{
				controlImplBase.Use();
			}
			if (controller == e.interactingObject)
			{
				controller = null;
			}
			base.enabled = false;
		}

		public static SpeedZoneControlTouchBehaviour Setup(GameObject gameObject)
		{
			SpeedZoneControlTouchBehaviour speedZoneControlTouchBehaviour = gameObject.AddComponent<SpeedZoneControlTouchBehaviour>();
			Transform transform = new GameObject("[interaction direction]").transform;
			transform.SetParent(gameObject.transform.parent);
			transform.localPosition = Vector3.zero;
			transform.gameObject.layer = LayerMask.NameToLayer("Interactable");
			speedZoneControlTouchBehaviour.direction = transform;
			return speedZoneControlTouchBehaviour;
		}
	}
}
