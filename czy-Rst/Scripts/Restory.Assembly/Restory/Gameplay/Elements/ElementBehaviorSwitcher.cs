using Restory.Constants;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementBehaviorSwitcher : MonoBehaviour
	{
		[SerializeField]
		private BoxCollider castCollider;

		[SerializeField]
		private Collider detectionCollider;

		[SerializeField]
		private Collider physicsCollider;

		[SerializeField]
		private MeshCollider textureCollider;

		[SerializeField]
		private GameObject detectionBoxes;

		[SerializeField]
		private ElementPhysicsHandler physicsHandler;

		[SerializeField]
		private bool isInDebugMode;

		public BoxCollider CastCollider => castCollider;

		public Collider DetectionCollider => detectionCollider;

		public Collider PhysicsCollider => physicsCollider;

		public void SwitchToInstalledBehavior()
		{
			physicsHandler.TogglePhysics(enable: false);
			SetPhysicsLayer(ProjectConstants.Layers.Device);
			if ((bool)textureCollider)
			{
				textureCollider.enabled = false;
			}
			physicsCollider.enabled = false;
			castCollider.enabled = false;
			detectionCollider.enabled = true;
			detectionBoxes.SetActive(value: true);
			if (detectionCollider is BoxCollider)
			{
				detectionCollider.isTrigger = true;
			}
			if (isInDebugMode)
			{
				Debug.LogError(base.transform.parent.name + " switched to Installed behavior", base.gameObject);
			}
		}

		public void SwitchToDraggingBehavior()
		{
			physicsHandler.TogglePhysics(enable: false);
			SetPhysicsLayer(ProjectConstants.Layers.Dragging);
			castCollider.enabled = false;
			detectionCollider.enabled = false;
			physicsCollider.enabled = false;
			if ((bool)textureCollider)
			{
				textureCollider.enabled = false;
			}
			detectionBoxes.SetActive(value: false);
			if (isInDebugMode)
			{
				Debug.LogError(base.transform.parent.name + " switched to Dragging behavior", base.gameObject);
			}
		}

		public void SwitchToPackedBehavior()
		{
			castCollider.enabled = false;
			detectionCollider.enabled = false;
			physicsCollider.enabled = false;
			if ((bool)textureCollider)
			{
				textureCollider.enabled = false;
			}
			detectionBoxes.SetActive(value: false);
			physicsHandler.TogglePhysics(enable: false);
			SetPhysicsLayer(ProjectConstants.Layers.Device);
			if (isInDebugMode)
			{
				Debug.LogError(base.transform.parent.name + " switched to Packed behavior", base.gameObject);
			}
		}

		public void SwitchToPlacedBehavior()
		{
			if ((bool)textureCollider)
			{
				textureCollider.enabled = false;
			}
			detectionCollider.enabled = false;
			castCollider.enabled = false;
			physicsCollider.enabled = true;
			detectionBoxes.SetActive(value: false);
			if (physicsCollider is BoxCollider)
			{
				physicsCollider.isTrigger = false;
			}
			physicsHandler.TogglePhysics(enable: true);
			if (isInDebugMode)
			{
				Debug.LogError(base.transform.parent.name + " switched to Placed behavior", base.gameObject);
			}
		}

		public void SwitchToTextureEditingBehavior()
		{
			physicsHandler.TogglePhysics(enable: false);
			SetPhysicsLayer(ProjectConstants.Layers.Device);
			physicsCollider.enabled = false;
			castCollider.enabled = false;
			detectionCollider.enabled = false;
			if ((bool)textureCollider)
			{
				textureCollider.enabled = true;
			}
			detectionBoxes.SetActive(value: false);
			if (isInDebugMode)
			{
				Debug.LogError(base.transform.parent.name + " switched to TextureEditing behavior", base.gameObject);
			}
		}

		public void SwitchDetectionCollider(bool shouldColliderBeActive)
		{
			detectionCollider.enabled = shouldColliderBeActive;
			if (isInDebugMode)
			{
				Debug.LogError($"{base.transform.parent.name} turned its Detection collider to enabled = {shouldColliderBeActive}", base.gameObject);
			}
		}

		public void SetPhysicsLayer(int layer)
		{
			physicsCollider.gameObject.layer = layer;
			physicsHandler.SetPhysicsLayer(layer);
		}
	}
}
