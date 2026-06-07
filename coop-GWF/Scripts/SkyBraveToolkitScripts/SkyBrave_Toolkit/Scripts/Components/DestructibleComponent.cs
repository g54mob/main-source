using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class DestructibleComponent : MonoBehaviour
	{
		private void OnEnable()
		{
		}

		public void DisableObject()
		{
			base.gameObject.SetActive(value: false);
		}

		public void DestroyObject()
		{
			Object.Destroy(base.gameObject);
		}
	}
}
