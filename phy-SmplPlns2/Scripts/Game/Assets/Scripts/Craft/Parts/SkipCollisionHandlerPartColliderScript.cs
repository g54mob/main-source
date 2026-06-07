using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class SkipCollisionHandlerPartColliderScript : MonoBehaviour
	{
		private Collider _collider;

		private AircraftScript _craft;

		protected virtual void Awake()
		{
			if (!TryGetComponent<Collider>(out _collider))
			{
				Debug.LogError("SkipCollisionHandlerPartColliderScript requires a Collider component.");
				return;
			}
			_craft = GetComponentInParent<AircraftScript>();
			if (_craft == null)
			{
				Debug.LogError("SkipCollisionHandlerPartColliderScript requires an AircraftScript in its parent hierarchy.");
			}
			else
			{
				_craft.PartCollidersSkippingCollisionHandler.Add(_collider.GetInstanceID());
			}
		}

		protected virtual void OnDestroy()
		{
			if (_collider != null && _craft != null)
			{
				_craft.PartCollidersSkippingCollisionHandler.Remove(_collider.GetInstanceID());
			}
		}
	}
}
