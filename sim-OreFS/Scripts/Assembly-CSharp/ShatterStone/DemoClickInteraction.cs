using UnityEngine;

namespace ShatterStone
{
	public class DemoClickInteraction : MonoBehaviour
	{
		[SerializeField]
		private Camera mainCamera;

		[SerializeField]
		private float maxDistance = 100f;

		[Tooltip("Tag used to identify ore nodes in the scene.")]
		[SerializeField]
		private string oreNodeTag = "OreNode";

		[SerializeField]
		private string orePickupTag = "OrePickup";

		private void Update()
		{
			bool flag = false;
			Vector2 vector = default(Vector2);
			if (Input.GetMouseButtonDown(0))
			{
				flag = true;
				vector = Input.mousePosition;
			}
			if (flag && Physics.Raycast(mainCamera.ScreenPointToRay(vector), out var hitInfo, maxDistance))
			{
				if (hitInfo.collider.CompareTag(oreNodeTag))
				{
					hitInfo.collider.GetComponent<OreNode>()?.Interact();
				}
				if (hitInfo.collider.CompareTag(orePickupTag))
				{
					hitInfo.collider.GetComponent<PickupController>()?.CollectItem();
				}
			}
		}
	}
}
