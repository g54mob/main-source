using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class BuildableObjectAreaBlocker : MonoBehaviour
	{
		[Tooltip("Size of the area that used to block buildable objects")]
		[SerializeField]
		private Vector3 blockingAreaTriggerSize = new Vector3(1f, 1f, 1f);

		private void Start()
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			boxCollider.isTrigger = base.enabled;
			boxCollider.size = blockingAreaTriggerSize;
		}

		private void OnDrawGizmos()
		{
			Color red = Color.red;
			red.a = 0.25f;
			Gizmos.color = red;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawCube(Vector3.zero, blockingAreaTriggerSize);
			Gizmos.DrawWireCube(Vector3.zero, blockingAreaTriggerSize);
		}
	}
}
