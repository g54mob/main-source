using SoulGames.EasyGridBuilderPro;
using UnityEngine;

namespace SoulGames.Utilities
{
	public class ColliderBridgeFreeObject : MonoBehaviour
	{
		private FreeObjectGhost listener;

		public void Awake()
		{
			listener = MultiGridManager.Instance.transform.GetComponentInChildren<FreeObjectGhost>();
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
