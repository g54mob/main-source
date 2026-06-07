using System.Collections;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_DashTeleport")]
	public class VRTK_DashTeleport : VRTK_HeightAdjustTeleport
	{
		[Header("Dash Settings")]
		[Tooltip("The fixed time it takes to dash to a new position.")]
		public float normalLerpTime = 0.1f;

		[Tooltip("The minimum speed for dashing in meters per second.")]
		public float minSpeedMps = 50f;

		[Tooltip("The Offset of the CapsuleCast above the camera.")]
		public float capsuleTopOffset = 0.2f;

		[Tooltip("The Offset of the CapsuleCast below the camera.")]
		public float capsuleBottomOffset = 0.5f;

		[Tooltip("The radius of the CapsuleCast.")]
		public float capsuleRadius = 0.5f;

		protected float minDistanceForNormalLerp;

		protected float lerpTime = 0.1f;

		protected Coroutine attemptLerpRoutine;

		public event DashTeleportEventHandler WillDashThruObjects;

		public event DashTeleportEventHandler DashedThruObjects;

		public virtual void OnWillDashThruObjects(DashTeleportEventArgs e)
		{
			if (this.WillDashThruObjects != null)
			{
				this.WillDashThruObjects(this, e);
			}
		}

		public virtual void OnDashedThruObjects(DashTeleportEventArgs e)
		{
			if (this.DashedThruObjects != null)
			{
				this.DashedThruObjects(this, e);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			minDistanceForNormalLerp = minSpeedMps * normalLerpTime;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (attemptLerpRoutine != null)
			{
				StopCoroutine(attemptLerpRoutine);
				attemptLerpRoutine = null;
			}
		}

		protected override Vector3 SetNewPosition(Vector3 position, Transform target, bool forceDestinationPosition)
		{
			return CheckTerrainCollision(position, target, forceDestinationPosition);
		}

		protected override Quaternion SetNewRotation(Quaternion? rotation)
		{
			if (ValidRigObjects())
			{
				if (!rotation.HasValue)
				{
					return playArea.rotation;
				}
				return rotation.Value;
			}
			return Quaternion.identity;
		}

		protected override void StartTeleport(object sender, DestinationMarkerEventArgs e)
		{
			base.StartTeleport(sender, e);
		}

		protected override void ProcessOrientation(object sender, DestinationMarkerEventArgs e, Vector3 targetPosition, Quaternion targetRotation)
		{
			if (ValidRigObjects())
			{
				Vector3 targetPosition2 = CalculateOffsetPosition(targetPosition, targetRotation);
				attemptLerpRoutine = StartCoroutine(lerpToPosition(sender, e, playArea.position, targetPosition2, playArea.rotation, targetRotation));
			}
		}

		protected virtual Vector3 CalculateOffsetPosition(Vector3 targetPosition, Quaternion targetRotation)
		{
			if (!headsetPositionCompensation)
			{
				return targetPosition;
			}
			Vector3 vector = new Vector3(headset.position.x - playArea.position.x, 0f, headset.position.z - playArea.position.z);
			Vector3 vector2 = Quaternion.Inverse(playArea.rotation) * targetRotation * vector;
			return targetPosition - (vector2 - vector);
		}

		protected override void EndTeleport(object sender, DestinationMarkerEventArgs e)
		{
		}

		protected virtual IEnumerator lerpToPosition(object sender, DestinationMarkerEventArgs e, Vector3 startPosition, Vector3 targetPosition, Quaternion startRotation, Quaternion targetRotation)
		{
			enableTeleport = false;
			bool gameObjectInTheWay = false;
			Vector3 position = headset.transform.position;
			Vector3 vector = new Vector3(position.x, playArea.position.y, position.z);
			Vector3 vector2 = position - playArea.position;
			Vector3 normalized = (targetPosition + vector2 - position).normalized;
			Vector3 point = vector + Vector3.up * capsuleBottomOffset + normalized;
			Vector3 point2 = position + Vector3.up * capsuleTopOffset + normalized;
			float num = Vector3.Distance(playArea.position, targetPosition - normalized * 0.5f);
			RaycastHit[] allHits = Physics.CapsuleCastAll(point, point2, capsuleRadius, normalized, num);
			for (int i = 0; i < allHits.Length; i++)
			{
				gameObjectInTheWay = ((allHits[i].collider.gameObject != e.target.gameObject) ? true : false);
			}
			if (gameObjectInTheWay)
			{
				OnWillDashThruObjects(SetDashTeleportEvent(allHits));
			}
			lerpTime = ((num >= minDistanceForNormalLerp) ? normalLerpTime : (VRTK_SharedMethods.DividerToMultiplier(minSpeedMps) * num));
			float elapsedTime = 0f;
			float currentLerpedTime = 0f;
			WaitForEndOfFrame delayInstruction = new WaitForEndOfFrame();
			while (currentLerpedTime < 1f)
			{
				playArea.position = Vector3.Lerp(startPosition, targetPosition, currentLerpedTime);
				playArea.rotation = Quaternion.Lerp(startRotation, targetRotation, currentLerpedTime);
				elapsedTime += Time.deltaTime;
				currentLerpedTime = elapsedTime / lerpTime;
				yield return delayInstruction;
			}
			playArea.position = targetPosition;
			playArea.rotation = targetRotation;
			if (gameObjectInTheWay)
			{
				OnDashedThruObjects(SetDashTeleportEvent(allHits));
			}
			base.EndTeleport(sender, e);
			enableTeleport = true;
		}

		protected virtual DashTeleportEventArgs SetDashTeleportEvent(RaycastHit[] hits)
		{
			DashTeleportEventArgs result = default(DashTeleportEventArgs);
			result.hits = hits;
			return result;
		}
	}
}
