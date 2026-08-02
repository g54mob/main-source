using UnityEngine;

namespace HQFPSTemplate
{
	public class Entity : MonoBehaviour
	{
		public readonly Value<float> Health = new Value<float>(100f);

		public readonly Attempt<DamageInfo> ChangeHealth = new Attempt<DamageInfo>();

		public readonly Attempt<DamageInfo, IDamageable> DealDamage = new Attempt<DamageInfo, IDamageable>();

		public readonly Value<bool> IsGrounded = new Value<bool>(initialValue: true);

		public readonly Value<Vector3> Velocity = new Value<Vector3>(Vector3.zero);

		public Value<Vector3> LookDirection = new Value<Vector3>();

		public readonly Message<float> FallImpact = new Message<float>();

		public readonly Message Death = new Message();

		public readonly Message Respawn = new Message();

		public Hitbox[] Hitboxes;

		[SerializeField]
		private Inventory m_Inventory;

		public Inventory Inventory => m_Inventory;

		private void Start()
		{
			Hitboxes = GetComponentsInChildren<Hitbox>();
			EntityComponent[] componentsInChildren = GetComponentsInChildren<EntityComponent>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnEntityStart();
			}
		}
	}
}
