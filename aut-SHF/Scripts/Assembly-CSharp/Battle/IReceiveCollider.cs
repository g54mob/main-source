using UnityEngine;

namespace Battle
{
	public interface IReceiveCollider
	{
		CircleCollider2D Collider { get; }

		bool ThroughCollider { get; set; }

		int? ColliderGroupId { get; set; }

		GameObject ColliderGroupRoot { get; set; }

		bool ReceiveOk { get; }

		void SettingColliderGroup(GameObject root)
		{
		}
	}
}
