using System;
using System.Collections.Generic;
using DV;
using DV.Interaction.Inputs;
using UnityEngine;

public class NonVRPointerLogic : APointerLogic
{
	private const float TELEPORT_TO_TRAIN_RANGE_LONG = 80f;

	private const float TELEPORT_TO_TRAIN_RANGE_SHORT = 5f;

	private const float EXTERNAL_TELEPORT_RANGE = 300f;

	private const float FORWARD_TELEPORT_RANGE_LONG = 30f;

	private const float FORWARD_TELEPORT_RANGE_SHORT = 2f;

	private const float VERTICAL_TELEPORT_RANGE = 300f;

	private const float POINTING_UP_THRESHOLD = 0.985f;

	[SerializeField]
	private Rigidbody characterRigidbody;

	[NonSerialized]
	public bool externalCameraMode;

	private readonly HashSet<Collider> collidersToIgnore = new HashSet<Collider>();

	private TeleportForbiddenOverlapSafety noTeleport;

	private RaycastHit[] hits = new RaycastHit[10];

	private GameParams gameParams;

	public override void Disable()
	{
	}

	public override void Enable()
	{
	}

	public override void SetColor(Color color)
	{
	}

	private void Awake()
	{
		noTeleport = characterRigidbody.gameObject.AddComponent<TeleportForbiddenOverlapSafety>();
		gameParams = Globals.G.GameParams;
	}

	public override bool IsActivationButtonBeingHeld()
	{
		return InputManager.NewPlayer.GetButton(InputManager.Actions.Teleport);
	}

	public override bool IsActivationButtonJustReleased()
	{
		return InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Teleport);
	}

	private bool IllegalOverlap()
	{
		if ((bool)noTeleport)
		{
			if (!noTeleport.isInsideForbiddenCollider)
			{
				return noTeleport.CheckOverlap(PlayerManager.ActiveCamera.transform.position);
			}
			return true;
		}
		return false;
	}

	public override bool ScanForCab(int layerMask, out RaycastHit hit)
	{
		if (IllegalOverlap())
		{
			hit = default(RaycastHit);
			return false;
		}
		collidersToIgnore.Clear();
		int num = Physics.RaycastNonAlloc(base.transform.position, base.transform.forward, hits, gameParams.LongDashAllowed ? 80f : 5f, layerMask, QueryTriggerInteraction.Collide);
		RaycastUtils.SortDistanceAndExpandCache(ref hits, num);
		for (int i = 0; i < num; i++)
		{
			RaycastHit raycastHit = hits[i];
			if (raycastHit.collider.TryGetComponent<TeleportArcPassThrough>(out var component))
			{
				if (component.ShouldIgnoreCollidersForHit(raycastHit))
				{
					collidersToIgnore.UnionWith(component.colliders);
				}
			}
			else if (!collidersToIgnore.Contains(raycastHit.collider))
			{
				hit = raycastHit;
				return true;
			}
		}
		hit = default(RaycastHit);
		return false;
	}

	public override bool ScanForTeleportDestination(int layerMask, out RaycastHit hit)
	{
		if (Vector3.Dot(base.transform.forward, Vector3.up) > 0.985f || IllegalOverlap())
		{
			hit = default(RaycastHit);
			return false;
		}
		collidersToIgnore.Clear();
		float num = (externalCameraMode ? 300f : (gameParams.LongDashAllowed ? 30f : 2f));
		int num2 = Physics.RaycastNonAlloc(base.transform.position, base.transform.forward, hits, num, layerMask, QueryTriggerInteraction.Collide);
		RaycastUtils.SortDistanceAndExpandCache(ref hits, num2);
		for (int i = 0; i < num2; i++)
		{
			RaycastHit raycastHit = hits[i];
			TeleportArcPassThrough component = raycastHit.collider.GetComponent<TeleportArcPassThrough>();
			if (component != null)
			{
				if (component.ShouldIgnoreCollidersForHit(raycastHit))
				{
					collidersToIgnore.UnionWith(component.colliders);
				}
			}
			else if (!collidersToIgnore.Contains(raycastHit.collider))
			{
				hit = raycastHit;
				return true;
			}
		}
		Vector3 origin = base.transform.position + base.transform.forward * num;
		if (!externalCameraMode && Physics.Raycast(origin, Vector3.down, out var hitInfo, 300f, layerMask, QueryTriggerInteraction.Collide))
		{
			hit = hitInfo;
			return true;
		}
		hit = default(RaycastHit);
		return false;
	}
}
