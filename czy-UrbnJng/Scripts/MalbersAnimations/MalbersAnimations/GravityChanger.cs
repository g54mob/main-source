using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Tools/Gravity Changer")]
	public class GravityChanger : MonoBehaviour
	{
		private IGravity animal;

		protected Collider Other;

		private void OnTriggerEnter(Collider other)
		{
			Other = other;
			animal = other.GetComponentInParent<IGravity>();
		}

		private void Update()
		{
			if (animal != null)
			{
				animal.Gravity = (base.transform.position - Other.transform.position).normalized;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			ResetAnimal();
		}

		public virtual void ResetAnimal()
		{
			animal?.Gravity_ResetDirection();
			animal = null;
			Other = null;
		}
	}
}
