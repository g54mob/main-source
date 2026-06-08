using UnityEngine;

namespace Kitchen
{
	public class FixedWorldRotation : MonoBehaviour
	{
		private void LateUpdate()
		{
			base.transform.rotation = Quaternion.identity;
		}
	}
}
