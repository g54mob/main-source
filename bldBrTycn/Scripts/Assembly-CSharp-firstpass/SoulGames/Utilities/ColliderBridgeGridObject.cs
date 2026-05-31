using SoulGames.EasyGridBuilderPro;
using UnityEngine;

namespace SoulGames.Utilities
{
	public class ColliderBridgeGridObject : MonoBehaviour
	{
		private GridObjectGhost listener;

		public void Awake()
		{
			listener = MultiGridManager.Instance.transform.GetComponentInChildren<GridObjectGhost>();
		}

		private void OnTriggerEnter(Collider other)
		{
			listener.OnTriggerEnter(other);
		}

		private void OnTriggerExit(Collider other)
		{
			listener.OnTriggerExit(other);
		}

		private void OnTriggerStay(Collider other)
		{
			listener.OnTriggerStay(other);
		}
	}
}
