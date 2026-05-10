using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	public class E05_SmoothFollow : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private float distance;

		[SerializeField]
		private float height;

		[SerializeField]
		private float rotationDamping;

		[SerializeField]
		private float heightDamping;

		[UsedImplicitly]
		private void LateUpdate()
		{
		}
	}
}
