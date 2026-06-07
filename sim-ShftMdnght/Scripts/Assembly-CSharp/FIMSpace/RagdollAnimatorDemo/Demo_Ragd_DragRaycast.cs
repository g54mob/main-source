using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_DragRaycast : FimpossibleComponent
	{
		public LayerMask RaycastMask;

		[Tooltip("Use right mouse button to drag")]
		[Range(0f, 2f)]
		public float DragPower = 0.75f;

		public bool SetKinematic;

		[Range(0f, 2f)]
		public float DragRotatePower;

		[Range(0f, 1f)]
		public float FadeMusclesTo = 0.4f;

		[Space(4f)]
		[Tooltip("Used in demos to play animations on dragged character")]
		public bool PlayAnimations;

		public bool SetFall = true;

		public bool RestoreStandingMode;

		public MonoBehaviour DisableOnDrag;

		private Rigidbody dragging;

		private RagdollAnimator2BoneIndicator draggingIndicator;

		private Vector3 startDragPosition = Vector3.zero;

		private Vector3 dragScreenPos = Vector3.zero;

		private Vector3 dragHitLocalPos = Vector3.zero;

		private Quaternion startDragRotation = Quaternion.identity;

		public override string HeaderInfo => "Ragdoll needs to have added bone indicators with Extra Features in order to make this component work!";

		private void Update()
		{
			if ((bool)dragging)
			{
				if (Input.GetMouseButtonUp(1))
				{
					EndDragging();
				}
			}
			else
			{
				if (!Input.GetMouseButtonDown(1) || !Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.PositiveInfinity, RaycastMask) || !hitInfo.rigidbody)
				{
					return;
				}
				RagdollAnimator2BoneIndicator component = hitInfo.transform.GetComponent<RagdollAnimator2BoneIndicator>();
				if (!(component == null))
				{
					RagdollHandler parentHandler = component.ParentHandler;
					if (SetFall)
					{
						parentHandler.User_SwitchFallState();
					}
					draggingIndicator = component;
					StartDrag(hitInfo, component.DummyBoneRigidbody);
					parentHandler.User_FadeMusclesPower(FadeMusclesTo, 0.7f);
					if (PlayAnimations)
					{
						parentHandler.Mecanim.CrossFadeInFixedTime("Fall", 0.25f);
						parentHandler.Mecanim.SetBool("Action", value: true);
					}
				}
			}
		}

		private void FixedUpdate()
		{
			if (dragging == null)
			{
				return;
			}
			Vector3 vector = startDragPosition;
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = Camera.main.transform.InverseTransformPoint(startDragPosition).z;
			vector += Camera.main.ScreenToWorldPoint(mousePosition) - dragScreenPos;
			if (dragging.isKinematic)
			{
				dragging.position = vector;
				return;
			}
			dragging.AddRigidbodyForceToMoveTowards(vector, DragPower);
			if (DragRotatePower > 0f)
			{
				dragging.AddRigidbodyTorqueToRotateTowards(startDragRotation, DragPower);
			}
		}

		private void StartDrag(RaycastHit hit, Rigidbody dummyBone)
		{
			dragging = dummyBone;
			startDragPosition = hit.point;
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = Camera.main.transform.InverseTransformPoint(startDragPosition).z;
			dragScreenPos = Camera.main.ScreenToWorldPoint(mousePosition);
			dragHitLocalPos = hit.rigidbody.transform.InverseTransformPoint(hit.point);
			startDragRotation = dummyBone.rotation;
			if (SetKinematic)
			{
				dragging.isKinematic = true;
			}
			if ((bool)DisableOnDrag)
			{
				DisableOnDrag.enabled = false;
			}
		}

		private void EndDragging()
		{
			if (SetKinematic)
			{
				dragging.isKinematic = false;
			}
			if (RestoreStandingMode && (bool)draggingIndicator)
			{
				draggingIndicator.ParentHandler.AnimatingMode = RagdollHandler.EAnimatingMode.Standing;
			}
			draggingIndicator = null;
			dragging = null;
			if ((bool)DisableOnDrag)
			{
				DisableOnDrag.enabled = true;
			}
		}
	}
}
