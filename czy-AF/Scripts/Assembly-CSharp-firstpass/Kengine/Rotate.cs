using UnityEngine;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Rotate")]
	public class Rotate : MonoBehaviour
	{
		public Vector3 rotation = Vector3.zero;

		private void Update()
		{
			base.transform.Rotate(rotation * Time.deltaTime);
		}
	}
}
