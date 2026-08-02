using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Trigger Disable")]
	public sealed class TriggerDisable : MonoBehaviour
	{
		[Tooltip("If <c>true</c>, the object is destroyed instead of just deactivated.")]
		public bool RemoveObject;

		private void OnTriggerEnter2D(Collider2D other)
		{
			DeactivateGameObject();
		}

		private void OnTriggerEnter(Collider other)
		{
			DeactivateGameObject();
		}

		private void DeactivateGameObject()
		{
			if (RemoveObject)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
