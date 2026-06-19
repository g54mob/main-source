using UnityEngine;

namespace Aggro.Core
{
	public class EntityCollider : EntityBehaviourBase
	{
		private Collider _collider;

		private bool _colliderEnableState;

		public Collider col => _collider;

		protected override void OnInitializeBehaviour()
		{
			_collider = GetComponent<Collider>();
			if (_collider != null)
			{
				_colliderEnableState = _collider.enabled;
			}
			else
			{
				base.enabled = false;
			}
		}

		protected override void OnEntityDestroyed()
		{
			if (base.enabled && _collider != null)
			{
				_collider.enabled = _colliderEnableState;
			}
		}
	}
}
