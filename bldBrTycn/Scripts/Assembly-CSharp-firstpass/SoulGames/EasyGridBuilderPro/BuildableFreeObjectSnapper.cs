using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class BuildableFreeObjectSnapper : MonoBehaviour
	{
		[Tooltip("When mouse pointer enter inside of this bounding box area Buildable Free Object will snap to this object's origin")]
		[SerializeField]
		private Vector3 snappingTriggerSize = new Vector3(1f, 1f, 1f);

		private void Start()
		{
			BoxCollider boxCollider = base.gameObject.AddComponent<BoxCollider>();
			boxCollider.isTrigger = base.enabled;
			boxCollider.size = snappingTriggerSize;
		}

		private void OnDrawGizmos()
		{
			Color cyan = Color.cyan;
			cyan.a = 0.25f;
			Gizmos.color = cyan;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawCube(Vector3.zero, snappingTriggerSize);
			Gizmos.DrawWireCube(Vector3.zero, snappingTriggerSize);
		}
	}
}
