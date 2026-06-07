using UnityEngine;

namespace Brewery.NPC.Simple
{
	public class SimpleHotspot : MonoBehaviour
	{
		[Header("Hotspot Area")]
		[Tooltip("Size of the rectangular area where NPCs can stand (Width X, Height Y ignored, Depth Z)")]
		[SerializeField]
		private Vector3 areaSize;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugGizmo;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public Vector3 GetRandomPosition()
		{
			return default(Vector3);
		}

		private void OnDrawGizmos()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
