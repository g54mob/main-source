using UnityEngine;

namespace Brewery.Skills
{
	public class CollectableSkillPoint : MonoBehaviour
	{
		[Header("Identity")]
		[Tooltip("Unique ID for this star. If empty, uses the GameObject name.")]
		[SerializeField]
		private string starId;

		[Header("Idle Animation (by code - efficient)")]
		[SerializeField]
		private float rotationSpeed;

		[SerializeField]
		private float bobHeight;

		[SerializeField]
		private float bobSpeed;

		[Header("Collection")]
		[Tooltip("Duration of the pop animation")]
		[SerializeField]
		private float popDuration;

		private Vector3 startPosition;

		private bool collected;

		private float bobOffset;

		private Collider triggerCollider;

		public string StarId => null;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnTriggerStay(Collider other)
		{
		}

		public void PlayCollectEffect()
		{
		}

		public void HideInstant()
		{
		}

		public void EnableCollection()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
