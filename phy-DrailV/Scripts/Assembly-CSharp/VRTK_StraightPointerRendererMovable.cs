using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class VRTK_StraightPointerRendererMovable : VRTK_StraightPointerRenderer
{
	private VRTK_Pointer pointer;

	private VRTK_InteractGrab grab;

	protected override void OnEnable()
	{
		if (pointer == null)
		{
			pointer = GetComponent<VRTK_Pointer>();
		}
		grab = GetComponentInParent<VRTK_InteractGrab>();
		cachedPointerAttachPoint = null;
		cachedAttachedHand = SDK_BaseController.ControllerHand.None;
		defaultMaterial = Resources.Load("WorldPointerOverlay") as Material;
		makeRendererVisible.Clear();
		CreatePointerOriginTransformFollow();
		CreatePointerObjects();
		if (pointer.activationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
		{
			pointer.activationButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			pointer.activateOnEnable = true;
		}
	}

	protected override void CreatePointerOriginTransformFollow()
	{
		base.CreatePointerOriginTransformFollow();
		pointerOriginTransformFollowGameObject.transform.SetParent(base.transform);
		pointerOriginTransformFollowGameObject.transform.localPosition = Vector3.zero;
		pointerOriginTransformFollowGameObject.transform.localRotation = Quaternion.identity;
	}

	protected override void CreatePointerObjects()
	{
		base.CreatePointerObjects();
		Transform obj = actualContainer.transform;
		Transform obj2 = actualTracer.transform;
		Vector3 vector = (actualCursor.transform.localPosition = Vector3.zero);
		Vector3 localPosition = (obj2.localPosition = vector);
		obj.localPosition = localPosition;
		Transform obj3 = actualContainer.transform;
		Transform obj4 = actualTracer.transform;
		Quaternion quaternion = (actualCursor.transform.localRotation = Quaternion.identity);
		Quaternion localRotation = (obj4.localRotation = quaternion);
		obj3.localRotation = localRotation;
	}

	protected override void SetPointerAppearance(float tracerLength)
	{
		base.SetPointerAppearance(tracerLength);
		if (destinationHit.collider == null)
		{
			if (SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.OnlyShowWhenHit)
			{
				actualTracer.transform.localScale = Vector3.zero;
			}
			actualCursor.transform.localScale = Vector3.zero;
		}
	}

	private bool ShouldShowPointer()
	{
		return true;
	}

	private void Update()
	{
		if (ShouldShowPointer())
		{
			ToggleRenderer(pointerState: true, actualState: false);
		}
		else
		{
			ToggleRenderer(pointerState: false, actualState: false);
		}
	}
}
