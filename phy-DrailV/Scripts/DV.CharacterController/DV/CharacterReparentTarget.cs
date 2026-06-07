using UnityEngine;

namespace DV
{
	public class CharacterReparentTarget : MonoBehaviour
	{
		public Transform target;

		public bool isTrain;

		private Transform playerTransform;

		private CharacterReparenting reparenting;

		public void SetPlayer(Transform playerTransform, CharacterReparenting reparenting)
		{
			this.playerTransform = playerTransform;
			this.reparenting = reparenting;
		}

		public void ClearPlayer()
		{
			playerTransform = null;
			reparenting = null;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && playerTransform != null && (playerTransform.IsChildOf(base.transform) || playerTransform.IsChildOf(target)))
			{
				Transform obj = playerTransform;
				Debug.LogWarning("Player is still parented to a target that is being destroyed, reparenting to null. Current parent: " + base.name, this);
				reparenting.ReparentTo(null);
				if (obj.TryGetComponent<CustomFirstPersonController>(out var component))
				{
					component.MoveBy(Vector3.zero);
				}
				ClearPlayer();
			}
		}
	}
}
