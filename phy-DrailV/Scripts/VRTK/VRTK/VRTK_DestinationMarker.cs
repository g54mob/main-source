using System;
using UnityEngine;

namespace VRTK
{
	public abstract class VRTK_DestinationMarker : MonoBehaviour
	{
		[Header("Destination Marker Settings", order = 1)]
		[Tooltip("If this is checked then the teleport flag is set to true in the Destination Set event so teleport scripts will know whether to action the new destination.")]
		public bool enableTeleport = true;

		[Tooltip("A specified VRTK_PolicyList to use to determine whether destination targets will be considered valid or invalid.")]
		public VRTK_PolicyList targetListPolicy;

		[Obsolete("`VRTK_DestinationMarker.navMeshCheckDistance` is no longer used. This parameter will be removed in a future version of VRTK.")]
		protected float navMeshCheckDistance;

		protected VRTK_NavMeshData navmeshData;

		protected bool headsetPositionCompensation;

		protected bool forceHoverOnRepeatedEnter = true;

		protected Collider existingCollider;

		public event DestinationMarkerEventHandler DestinationMarkerEnter;

		public event DestinationMarkerEventHandler DestinationMarkerExit;

		public event DestinationMarkerEventHandler DestinationMarkerHover;

		public event DestinationMarkerEventHandler DestinationMarkerSet;

		public virtual void OnDestinationMarkerEnter(DestinationMarkerEventArgs e)
		{
			if (this.DestinationMarkerEnter != null && (!forceHoverOnRepeatedEnter || e.raycastHit.collider != existingCollider))
			{
				existingCollider = e.raycastHit.collider;
				this.DestinationMarkerEnter(this, e);
			}
			if (forceHoverOnRepeatedEnter && e.raycastHit.collider == existingCollider)
			{
				OnDestinationMarkerHover(e);
			}
		}

		public virtual void OnDestinationMarkerExit(DestinationMarkerEventArgs e)
		{
			if (this.DestinationMarkerExit != null)
			{
				this.DestinationMarkerExit(this, e);
				existingCollider = null;
			}
		}

		public virtual void OnDestinationMarkerHover(DestinationMarkerEventArgs e)
		{
			if (this.DestinationMarkerHover != null)
			{
				this.DestinationMarkerHover(this, e);
			}
		}

		public virtual void OnDestinationMarkerSet(DestinationMarkerEventArgs e)
		{
			if (this.DestinationMarkerSet != null)
			{
				this.DestinationMarkerSet(this, e);
			}
		}

		[Obsolete("`DestinationMarker.SetNavMeshCheckDistance(distance)` has been replaced with the method `DestinationMarker.SetNavMeshCheckDistance(givenData)`. This method will be removed in a future version of VRTK.")]
		public virtual void SetNavMeshCheckDistance(float distance)
		{
			VRTK_NavMeshData vRTK_NavMeshData = base.gameObject.AddComponent<VRTK_NavMeshData>();
			vRTK_NavMeshData.distanceLimit = distance;
			SetNavMeshData(vRTK_NavMeshData);
		}

		public virtual void SetNavMeshData(VRTK_NavMeshData givenData)
		{
			navmeshData = givenData;
		}

		public virtual void SetHeadsetPositionCompensation(bool state)
		{
			headsetPositionCompensation = state;
		}

		public virtual void SetForceHoverOnRepeatedEnter(bool state)
		{
			forceHoverOnRepeatedEnter = state;
		}

		protected virtual void OnEnable()
		{
			VRTK_ObjectCache.registeredDestinationMarkers.Add(this);
		}

		protected virtual void OnDisable()
		{
			VRTK_ObjectCache.registeredDestinationMarkers.Remove(this);
		}

		protected virtual DestinationMarkerEventArgs SetDestinationMarkerEvent(float distance, Transform target, RaycastHit raycastHit, Vector3 position, VRTK_ControllerReference controllerReference, bool forceDestinationPosition = false, Quaternion? rotation = null)
		{
			DestinationMarkerEventArgs result = default(DestinationMarkerEventArgs);
			result.controllerReference = controllerReference;
			result.distance = distance;
			result.target = target;
			result.raycastHit = raycastHit;
			result.destinationPosition = position;
			result.destinationRotation = rotation;
			result.enableTeleport = enableTeleport;
			result.forceDestinationPosition = forceDestinationPosition;
			return result;
		}
	}
}
