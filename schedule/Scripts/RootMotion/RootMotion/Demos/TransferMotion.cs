using UnityEngine;

namespace RootMotion.Demos
{
	public class TransferMotion : MonoBehaviour
	{
		[Tooltip("The Transform to transfer motion to.")]
		public Transform to;

		[Tooltip("The amount of motion to transfer.")]
		[Range(0f, 1f)]
		public float transferMotion;

		private Vector3 lastPosition;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
