using System;
using DV.CabControls.NonVR;
using DV.Customization.Gadgets;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.Interaction
{
	[ExecuteBefore(typeof(GrabberInputHandler))]
	public class GrabberRaycasterDV : MonoBehaviour, IGrabberRaycaster
	{
		public const float RAYCAST_MAX_DIST = 4f;

		private const float FPS_INTERACTION_RANGE_SQR = 2.25f;

		public LayerMask sphereCastMask;

		private Grabber grabber;

		private IGrabberCursor grabberCursor;

		private AGrabHandler oldHoverHandler;

		private bool isHovering;

		private RaycastHitDV hit;

		public AGrabHandler CurrentlyRaycasted { get; private set; }

		public RaycastHitDV CurrentlyHit => hit;

		public bool AnythingHit => hit.collider != null;

		public event Action<AGrabHandler> Hovered;

		public event Action<AGrabHandler> UnHovered;

		private void Awake()
		{
			grabberCursor = GetComponent<IGrabberCursor>();
			grabber = GetComponent<Grabber>();
		}

		private void Update()
		{
			UpdateRaycast();
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				ReleaseHover();
			}
		}

		public void ReleaseHover()
		{
			CurrentlyRaycasted = null;
			hit = default(RaycastHitDV);
			UpdateDesiredHover(null);
		}

		public void UpdateRaycast()
		{
			CurrentlyRaycasted = GetRaycastedGrabHandler(grabberCursor.GetRay());
			AGrabHandler desiredHoverHandler = ((grabber.CurrentlyDragged != null) ? grabber.CurrentlyDragged : CurrentlyRaycasted);
			UpdateDesiredHover(desiredHoverHandler);
		}

		private void UpdateDesiredHover(AGrabHandler desiredHoverHandler)
		{
			if (!(desiredHoverHandler != oldHoverHandler) && (!isHovering || !(desiredHoverHandler == null)))
			{
				return;
			}
			if (isHovering)
			{
				this.UnHovered?.Invoke(oldHoverHandler);
				isHovering = false;
				if (oldHoverHandler != null)
				{
					oldHoverHandler.OnUnhovered();
				}
			}
			if (desiredHoverHandler != null)
			{
				this.Hovered?.Invoke(desiredHoverHandler);
				isHovering = true;
				desiredHoverHandler.OnHovered();
			}
			oldHoverHandler = desiredHoverHandler;
		}

		public AGrabHandler RaycastPassThrough(Ray ray)
		{
			hit = default(RaycastHitDV);
			PhysicsQueryBuilder.QueryResults queryResults = PhysicsQueryBuilder.Raycast(ray.origin, ray.direction, 4f, sphereCastMask, QueryTriggerInteraction.Collide).FilterGadgetDepthHackGeneric((RaycastHitDV hit) => hit.collider.gameObject.layer != Layers.DVLayer.Train_Interior.ToInt());
			if (queryResults.Length <= 0)
			{
				return null;
			}
			for (int num = 0; num < queryResults.Length; num++)
			{
				hit = queryResults[num];
				if (hit.collider.TryGetComponent<GrabberRaycastPassThrough>(out var _))
				{
					continue;
				}
				AGrabHandler aGrabHandler = hit.collider.GetComponentInParent<StaticInteractionArea>()?.grabHandler;
				if (aGrabHandler != null)
				{
					GrabHandlerItem grabHandlerItem = ((aGrabHandler.transform.parent != null) ? aGrabHandler.transform.parent.GetComponentInParent<GrabHandlerItem>() : null);
					for (int num2 = num + 1; num2 < queryResults.Length; num2++)
					{
						RaycastHitDV raycastHitDV = queryResults[num2];
						if (!(raycastHitDV.collider.GetComponent<GrabberRaycastPassThrough>() != null) && !raycastHitDV.collider.isTrigger)
						{
							GrabHandlerItem componentInParent = raycastHitDV.collider.GetComponentInParent<GrabHandlerItem>();
							if (componentInParent == null)
							{
								break;
							}
							if (componentInParent != grabHandlerItem && !aGrabHandler.InteractionPassThrough(hit.point))
							{
								hit = raycastHitDV;
								return componentInParent;
							}
						}
					}
					if (!aGrabHandler.InteractionPassThrough(hit.point))
					{
						return aGrabHandler;
					}
					continue;
				}
				Collider collider = hit.collider;
				AGrabHandler componentInParent2 = collider.GetComponentInParent<AGrabHandler>();
				if (componentInParent2 != null && componentInParent2.interactionColliders.Contains(collider))
				{
					if (!componentInParent2.InteractionPassThrough(hit.point))
					{
						return componentInParent2;
					}
				}
				else if (!collider.isTrigger || (bool)collider.GetComponent<InfoArea>())
				{
					break;
				}
			}
			return null;
		}

		private AGrabHandler GetRaycastedGrabHandler(Ray ray)
		{
			if (Cursor.lockState == CursorLockMode.None && !CursorManager.Visible)
			{
				return null;
			}
			if (Cursor.lockState == CursorLockMode.None && (bool)EventSystem.current && EventSystem.current.IsPointerOverGameObject())
			{
				return null;
			}
			if (SingletonBehaviour<HotbarController>.Instance != null && SingletonBehaviour<HotbarController>.Instance.IsOpen)
			{
				return null;
			}
			bool flag = SingletonBehaviour<ScreenspaceMouse>.Instance.on;
			AGrabHandler aGrabHandler = RaycastPassThrough(ray);
			if (grabber.CurrentItemHeld != null)
			{
				bool isHoverableWhileHeld = grabber.CurrentItemHeld.GetComponent<ItemNonVR>().isHoverableWhileHeld;
				if (!flag)
				{
					return null;
				}
				if (aGrabHandler == grabber.CurrentItemHeld && !isHoverableWhileHeld)
				{
					return null;
				}
			}
			if (!aGrabHandler)
			{
				return null;
			}
			if (!(aGrabHandler is GrabHandlerItem) && Vector3.SqrMagnitude(ray.origin - aGrabHandler.transform.position) > 2.25f)
			{
				GrabHandlerItem grabHandlerItem = ((aGrabHandler.transform.parent != null) ? aGrabHandler.transform.parent.GetComponentInParent<GrabHandlerItem>() : null);
				if (grabHandlerItem != null)
				{
					return grabHandlerItem;
				}
			}
			return aGrabHandler;
		}
	}
}
