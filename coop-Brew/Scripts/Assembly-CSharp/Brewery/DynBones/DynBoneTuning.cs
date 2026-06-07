using UnityEngine;

namespace Brewery.DynBones
{
	[CreateAssetMenu(menuName = "Brewery/DynBones/Tuning", order = 150)]
	public class DynBoneTuning : ScriptableObject
	{
		[Header("Identity")]
		public string displayName;

		public bool enabled;

		[Header("Physics")]
		[Range(0f, 10f)]
		public float gravity;

		[Tooltip("Air resistance. Higher = settles faster.")]
		[Range(0f, 1f)]
		public float damping;

		[Tooltip("Rotation restoration stiffness. Higher = bone resists moving away from rest.")]
		[Range(0f, 1f)]
		public float stiffness;

		[Tooltip("Velocity decay during restoration. Higher = less bouncy.")]
		[Range(0f, 1f)]
		public float velocityAttenuation;

		[Tooltip("Particle collision radius.")]
		[Range(0.005f, 0.2f)]
		public float particleRadius;

		[Header("Collision")]
		public bool useBodyColliders;
	}
}
