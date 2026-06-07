using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/AI/Follow Target")]
	public class FollowTarget : MonoBehaviour
	{
		public Transform target;

		[Min(0f)]
		public float stopDistance = 3f;

		[Min(0f)]
		public float SlowDistance = 6f;

		[Tooltip("Limit for the Slowing Multiplier to be applied to the Speed Modifier")]
		[Range(0f, 1f)]
		[SerializeField]
		private float slowingLimit = 0.3f;

		private ICharacterMove animal;

		private float RemainingDistance;

		public float SlowMultiplier
		{
			get
			{
				float result = 1f;
				if (SlowDistance > stopDistance && RemainingDistance < SlowDistance)
				{
					result = Mathf.Max(RemainingDistance / SlowDistance, slowingLimit);
				}
				return result;
			}
		}

		private void Start()
		{
			animal = GetComponentInParent<ICharacterMove>();
		}

		private void Update()
		{
			Vector3 normalized = (target.position - base.transform.position).normalized;
			RemainingDistance = Vector3.Distance(base.transform.position, target.position);
			animal.Move((RemainingDistance > stopDistance) ? (normalized * SlowMultiplier) : Vector3.zero);
		}

		private void OnDisable()
		{
			animal.Move(Vector3.zero);
		}
	}
}
