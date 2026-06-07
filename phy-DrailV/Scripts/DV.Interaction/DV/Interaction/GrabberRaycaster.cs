using System;
using DV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.Interaction
{
	public class GrabberRaycaster : MonoBehaviour, IGrabberRaycaster
	{
		public const float SPHERE_CAST_RADIUS = 0.005f;

		public const float SPHERE_CAST_MAX_DIST = 4f;

		public LayerMask sphereCastMask;

		protected Grabber grabber;

		private IGrabberCursor grabberCursor;

		private AGrabHandler oldHoverHandler;

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

		public void ReleaseHover()
		{
			CurrentlyRaycasted = null;
			hit = default(RaycastHitDV);
			UpdateDesiredHover(null);
		}

		public void UpdateRaycast()
		{
			CurrentlyRaycasted = RaycastGrabHandler(grabberCursor.GetRay());
			AGrabHandler desiredHoverHandler = ((grabber.CurrentlyDragged != null) ? grabber.CurrentlyDragged : CurrentlyRaycasted);
			UpdateDesiredHover(desiredHoverHandler);
		}

		private void UpdateDesiredHover(AGrabHandler desiredHoverHandler)
		{
			if (desiredHoverHandler != oldHoverHandler)
			{
				if (oldHoverHandler != null)
				{
					this.UnHovered?.Invoke(oldHoverHandler);
				}
				if (desiredHoverHandler != null)
				{
					this.Hovered?.Invoke(desiredHoverHandler);
				}
				oldHoverHandler = desiredHoverHandler;
			}
		}

		public AGrabHandler RaycastGrabHandler(Ray ray)
		{
			hit = default(RaycastHitDV);
			if (Cursor.lockState == CursorLockMode.None && (bool)EventSystem.current && EventSystem.current.IsPointerOverGameObject())
			{
				return null;
			}
			if (!PhysicsQueryBuilder.SphereCast(ray.origin, 0.005f, ray.direction, 4f, sphereCastMask, QueryTriggerInteraction.Collide).TryGetFirst(out hit))
			{
				return null;
			}
			AGrabHandler aGrabHandler = hit.collider.GetComponentInParent<StaticInteractionArea>()?.grabHandler;
			if ((bool)aGrabHandler)
			{
				if (!PhysicsQueryBuilder.SphereCast(ray.origin, 0.005f, ray.direction, 4f, sphereCastMask).TryGetFirst(out var raycastHitDV))
				{
					return aGrabHandler;
				}
				GrabHandlerItem componentInParent = raycastHitDV.collider.GetComponentInParent<GrabHandlerItem>();
				GrabHandlerItem grabHandlerItem = ((aGrabHandler.transform.parent != null) ? aGrabHandler.transform.parent.GetComponentInParent<GrabHandlerItem>() : null);
				if (componentInParent != null && componentInParent != grabHandlerItem)
				{
					hit = raycastHitDV;
					return componentInParent;
				}
				return aGrabHandler;
			}
			aGrabHandler = hit.collider.GetComponentInParent<AGrabHandler>();
			if ((bool)aGrabHandler)
			{
				return aGrabHandler;
			}
			if (!PhysicsQueryBuilder.SphereCast(ray.origin, 0.005f, ray.direction, 4f, sphereCastMask).TryGetFirst(out hit))
			{
				return null;
			}
			return hit.collider.GetComponentInParent<AGrabHandler>();
		}
	}
}
