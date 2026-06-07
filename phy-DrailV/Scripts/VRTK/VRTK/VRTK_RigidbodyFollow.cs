using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/Object Follow/VRTK_RigidbodyFollow")]
	public class VRTK_RigidbodyFollow : VRTK_ObjectFollow
	{
		public enum MovementOption
		{
			Set = 0,
			Move = 1,
			Add = 2,
			Track = 3
		}

		[Header("Follow Settings")]
		[Tooltip("Specifies how to position and rotate the rigidbody.")]
		public MovementOption movementOption;

		[Header("Track Movement Settings")]
		[Tooltip("The maximum distance the tracked `Game Object To Change` Rigidbody can be from the `Game Object To Follow` Rigidbody before the position is forcibly set to match the position.")]
		public float trackMaxDistance = 0.25f;

		protected Rigidbody rigidbodyToFollow;

		protected Rigidbody rigidbodyToChange;

		protected float maxDistanceDelta = 10f;

		public override void Follow()
		{
			CacheRigidbodies();
			base.Follow();
		}

		protected virtual void OnDisable()
		{
			rigidbodyToFollow = null;
			rigidbodyToChange = null;
		}

		protected virtual void FixedUpdate()
		{
			Follow();
		}

		protected virtual void CacheRigidbodies()
		{
			if (!(gameObjectToFollow == null) && !(gameObjectToChange == null) && (!(rigidbodyToFollow != null) || !(rigidbodyToChange != null)))
			{
				rigidbodyToFollow = gameObjectToFollow.GetComponent<Rigidbody>();
				rigidbodyToChange = gameObjectToChange.GetComponent<Rigidbody>();
			}
		}

		protected override Vector3 GetPositionToFollow()
		{
			if (!(rigidbodyToFollow != null))
			{
				return Vector3.zero;
			}
			return rigidbodyToFollow.position;
		}

		protected override Quaternion GetRotationToFollow()
		{
			if (!(rigidbodyToFollow != null))
			{
				return Quaternion.identity;
			}
			return rigidbodyToFollow.rotation;
		}

		protected override Vector3 GetScaleToFollow()
		{
			if (!(rigidbodyToFollow != null))
			{
				return Vector3.zero;
			}
			return rigidbodyToFollow.transform.localScale;
		}

		protected override void SetPositionOnGameObject(Vector3 newPosition)
		{
			switch (movementOption)
			{
			case MovementOption.Set:
				rigidbodyToChange.position = newPosition;
				break;
			case MovementOption.Move:
				rigidbodyToChange.MovePosition(newPosition);
				break;
			case MovementOption.Add:
				rigidbodyToChange.AddForce(newPosition - rigidbodyToChange.position);
				break;
			case MovementOption.Track:
				TrackPosition(newPosition);
				break;
			}
		}

		protected override void SetRotationOnGameObject(Quaternion newRotation)
		{
			switch (movementOption)
			{
			case MovementOption.Set:
				rigidbodyToChange.rotation = newRotation;
				break;
			case MovementOption.Move:
				rigidbodyToChange.MoveRotation(newRotation);
				break;
			case MovementOption.Add:
				rigidbodyToChange.AddTorque(newRotation * Quaternion.Inverse(rigidbodyToChange.rotation).eulerAngles);
				break;
			case MovementOption.Track:
				TrackRotation(newRotation);
				break;
			}
		}

		protected virtual void TrackPosition(Vector3 newPosition)
		{
			if (!(rigidbodyToFollow == null))
			{
				if (Vector3.Distance(rigidbodyToChange.position, rigidbodyToFollow.position) > trackMaxDistance)
				{
					rigidbodyToChange.position = rigidbodyToFollow.position;
					rigidbodyToChange.rotation = rigidbodyToFollow.rotation;
				}
				float num = float.PositiveInfinity;
				Vector3 target = (newPosition - rigidbodyToChange.position) / Time.fixedDeltaTime;
				Vector3 velocity = Vector3.MoveTowards(rigidbodyToChange.velocity, target, maxDistanceDelta);
				if (num == float.PositiveInfinity || velocity.sqrMagnitude < num)
				{
					rigidbodyToChange.velocity = velocity;
				}
			}
		}

		protected virtual void TrackRotation(Quaternion newRotation)
		{
			if (rigidbodyToFollow == null)
			{
				return;
			}
			float num = float.PositiveInfinity;
			(newRotation * Quaternion.Inverse(rigidbodyToChange.rotation)).ToAngleAxis(out var angle, out var axis);
			angle = ((!(angle > 180f)) ? angle : (angle -= 360f));
			if (angle != 0f)
			{
				Vector3 target = angle * axis;
				Vector3 angularVelocity = Vector3.MoveTowards(rigidbodyToChange.angularVelocity, target, maxDistanceDelta);
				if (num == float.PositiveInfinity || angularVelocity.sqrMagnitude < num)
				{
					rigidbodyToChange.angularVelocity = angularVelocity;
				}
			}
		}
	}
}
