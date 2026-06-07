using ScheduleOne.Combat;
using ScheduleOne.Core.Audio;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Audio
{
	[RequireComponent(typeof(Rigidbody))]
	public class RBImpactSounds : MonoBehaviour
	{
		public const float MinImpactMomentum = 4f;

		public const float SoundCooldown = 0.25f;

		[SerializeField]
		[FormerlySerializedAs("Material")]
		private EImpactSound _material;

		private float _lastImpactTime;

		private Rigidbody _rb;

		private void Awake()
		{
		}

		private void OnImpacted(Impact impact)
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}
	}
}
