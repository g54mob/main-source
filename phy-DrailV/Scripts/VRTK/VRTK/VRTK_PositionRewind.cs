using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Presence/VRTK_PositionRewind")]
	public class VRTK_PositionRewind : MonoBehaviour
	{
		public enum CollisionDetectors
		{
			HeadsetOnly = 0,
			BodyOnly = 1,
			HeadsetAndBody = 2
		}

		[Header("Rewind Settings")]
		[Tooltip("The colliders to determine if a collision has occured for the rewind to be actioned.")]
		public CollisionDetectors collisionDetector;

		[Tooltip("If this is checked then the collision detector will ignore colliders set to `Is Trigger = true`.")]
		public bool ignoreTriggerColliders;

		[Tooltip("The amount of time from original headset collision until the rewind to the last good known position takes place.")]
		public float rewindDelay = 0.5f;

		[Tooltip("The additional distance to push the play area back upon rewind to prevent being right next to the wall again.")]
		public float pushbackDistance = 0.5f;

		[Tooltip("The threshold to determine how low the headset has to be before it is considered the user is crouching. The last good position will only be recorded in a non-crouching position.")]
		public float crouchThreshold = 0.5f;

		[Tooltip("The threshold to determind how low the headset can be to perform a position rewind. If the headset Y position is lower than this threshold then a rewind won't occur.")]
		public float crouchRewindThreshold = 0.1f;

		[Tooltip("A specified VRTK_PolicyList to use to determine whether any objects will be acted upon by the Position Rewind.")]
		public VRTK_PolicyList targetListPolicy;

		[Header("Custom Settings")]
		[Tooltip("The VRTK Body Physics script to use for the collisions and rigidbodies. If this is left blank then the first Body Physics script found in the scene will be used.")]
		public VRTK_BodyPhysics bodyPhysics;

		[Tooltip("The VRTK Headset Collision script to use to determine if the headset is colliding. If this is left blank then the script will need to be applied to the same GameObject.")]
		public VRTK_HeadsetCollision headsetCollision;

		protected Transform headset;

		protected Transform playArea;

		protected Vector3 lastGoodStandingPosition;

		protected Vector3 lastGoodHeadsetPosition;

		protected float highestHeadsetY;

		protected float lastPlayAreaY;

		protected bool lastGoodPositionSet;

		protected bool hasCollided;

		protected bool isColliding;

		protected bool isRewinding;

		protected float collideTimer;

		public event PositionRewindEventHandler PositionRewindToSafe;

		public virtual void OnPositionRewindToSafe(PositionRewindEventArgs e)
		{
			if (this.PositionRewindToSafe != null)
			{
				this.PositionRewindToSafe(this, e);
			}
		}

		public virtual void SetLastGoodPosition()
		{
			if (playArea != null && headset != null)
			{
				lastGoodPositionSet = true;
				lastGoodStandingPosition = playArea.position;
				lastGoodHeadsetPosition = headset.position;
			}
		}

		public virtual void RewindPosition()
		{
			if (headset != null)
			{
				Vector3 position = playArea.position;
				Vector3 vector = lastGoodHeadsetPosition - headset.position;
				Vector3 vector2 = vector.normalized * pushbackDistance;
				playArea.position += vector + vector2;
				if (bodyPhysics != null)
				{
					bodyPhysics.ResetVelocities();
				}
				OnPositionRewindToSafe(SetEventPayload(position));
			}
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			lastGoodPositionSet = false;
			headset = VRTK_DeviceFinder.HeadsetTransform();
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			bodyPhysics = ((bodyPhysics != null) ? bodyPhysics : Object.FindObjectOfType<VRTK_BodyPhysics>());
			headsetCollision = ((headsetCollision != null) ? headsetCollision : GetComponentInChildren<VRTK_HeadsetCollision>());
			ManageListeners(state: true);
		}

		protected virtual void OnDisable()
		{
			ManageListeners(state: false);
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			if (isColliding)
			{
				if (collideTimer > 0f)
				{
					collideTimer -= Time.deltaTime;
					return;
				}
				collideTimer = 0f;
				isColliding = false;
				DoPositionRewind();
			}
		}

		protected virtual PositionRewindEventArgs SetEventPayload(Vector3 previousPosition)
		{
			PositionRewindEventArgs result = default(PositionRewindEventArgs);
			result.collidedPosition = previousPosition;
			result.resetPosition = playArea.position;
			return result;
		}

		protected virtual bool CrouchThresholdReached()
		{
			float num = 0.005f;
			if (!(playArea.position.y > lastPlayAreaY + num))
			{
				return playArea.position.y < lastPlayAreaY - num;
			}
			return true;
		}

		protected virtual void SetHighestHeadsetY()
		{
			highestHeadsetY = (CrouchThresholdReached() ? crouchThreshold : ((headset.localPosition.y > highestHeadsetY) ? headset.localPosition.y : highestHeadsetY));
		}

		protected virtual void UpdateLastGoodPosition()
		{
			float num = highestHeadsetY - crouchThreshold;
			if (headset.localPosition.y > num && num > crouchThreshold)
			{
				SetLastGoodPosition();
			}
			lastPlayAreaY = playArea.position.y;
		}

		protected virtual void FixedUpdate()
		{
			if (!isColliding && playArea != null)
			{
				SetHighestHeadsetY();
				UpdateLastGoodPosition();
			}
		}

		protected virtual void StartCollision(GameObject target, Collider collider)
		{
			if ((!ignoreTriggerColliders || !collider.isTrigger) && !VRTK_PolicyList.Check(target, targetListPolicy))
			{
				isColliding = true;
				if (!hasCollided && collideTimer <= 0f)
				{
					hasCollided = true;
					collideTimer = rewindDelay;
				}
			}
		}

		protected virtual void EndCollision(Collider collider)
		{
			if (!ignoreTriggerColliders || !(collider != null) || !collider.isTrigger)
			{
				isColliding = false;
				hasCollided = false;
				isRewinding = false;
			}
		}

		protected virtual bool BodyCollisionsEnabled()
		{
			if (!(bodyPhysics == null))
			{
				return bodyPhysics.enableBodyCollisions;
			}
			return true;
		}

		protected virtual bool CanRewind()
		{
			if (!isRewinding && ((playArea != null) & lastGoodPositionSet) && headset.localPosition.y > crouchRewindThreshold)
			{
				return BodyCollisionsEnabled();
			}
			return false;
		}

		protected virtual void DoPositionRewind()
		{
			if (CanRewind())
			{
				isRewinding = true;
				RewindPosition();
			}
		}

		protected virtual bool HeadsetListen()
		{
			if (collisionDetector != CollisionDetectors.HeadsetAndBody)
			{
				return collisionDetector == CollisionDetectors.HeadsetOnly;
			}
			return true;
		}

		protected virtual bool BodyListen()
		{
			if (collisionDetector != CollisionDetectors.HeadsetAndBody)
			{
				return collisionDetector == CollisionDetectors.BodyOnly;
			}
			return true;
		}

		protected virtual void ManageListeners(bool state)
		{
			if (state)
			{
				if (headsetCollision != null && HeadsetListen())
				{
					headsetCollision.HeadsetCollisionDetect += HeadsetCollisionDetect;
					headsetCollision.HeadsetCollisionEnded += HeadsetCollisionEnded;
				}
				if (bodyPhysics != null && BodyListen())
				{
					bodyPhysics.StartColliding += StartColliding;
					bodyPhysics.StopColliding += StopColliding;
				}
			}
			else
			{
				if (headsetCollision != null && HeadsetListen())
				{
					headsetCollision.HeadsetCollisionDetect -= HeadsetCollisionDetect;
					headsetCollision.HeadsetCollisionEnded -= HeadsetCollisionEnded;
				}
				if (bodyPhysics != null && BodyListen())
				{
					bodyPhysics.StartColliding -= StartColliding;
					bodyPhysics.StopColliding -= StopColliding;
				}
			}
		}

		private void StartColliding(object sender, BodyPhysicsEventArgs e)
		{
			StartCollision(e.target, e.collider);
		}

		private void StopColliding(object sender, BodyPhysicsEventArgs e)
		{
			EndCollision(e.collider);
		}

		protected virtual void HeadsetCollisionDetect(object sender, HeadsetCollisionEventArgs e)
		{
			StartCollision(e.collider.gameObject, e.collider);
		}

		protected virtual void HeadsetCollisionEnded(object sender, HeadsetCollisionEventArgs e)
		{
			EndCollision(e.collider);
		}
	}
}
