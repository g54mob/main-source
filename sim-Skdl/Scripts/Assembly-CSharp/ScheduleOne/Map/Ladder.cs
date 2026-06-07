using ScheduleOne.Audio;
using ScheduleOne.Doors;
using UnityEngine;
using UnityEngine.AI;

namespace ScheduleOne.Map
{
	[RequireComponent(typeof(BoxCollider))]
	[RequireComponent(typeof(Rigidbody))]
	public class Ladder : MonoBehaviour
	{
		public const float NPCClimbOffset = 0.42f;

		public const float LadderMountDismountTimeMultiplier = 0.4f;

		public const float LadderClimbTimeMultiplier = 0.75f;

		public const float NPCClimbSoundInterval = 0.3f;

		public const float PlayerClimbSoundLengthInterval = 0.8f;

		[Header("References")]
		public OffMeshLink OffMeshLink;

		public AudioSourceController ClimbSound;

		public SewerDoorController LinkedManholeCover;

		private BoxCollider boxCollider;

		private float timeOnLastClimbSound;

		public Transform LadderTransform => null;

		public Vector2 LadderSize => default(Vector2);

		public Vector3 BottomCenter => default(Vector3);

		public Vector3 TopCenter => default(Vector3);

		private void Awake()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void OnDrawGizmos()
		{
		}

		public Vector2 ProjectOnLadderSurface(Vector3 position)
		{
			return default(Vector2);
		}

		public Vector2 NormalizeProjectedPosition(Vector2 projectedPosition)
		{
			return default(Vector2);
		}

		public void PlayClimbSound(Vector3 position)
		{
		}
	}
}
