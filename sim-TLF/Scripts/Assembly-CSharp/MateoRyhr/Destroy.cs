using UnityEngine;

namespace MateoRyhr
{
	public class Destroy : MonoBehaviour
	{
		public void DestroyItself()
		{
			Object.Destroy(base.gameObject);
		}

		public void DestroyItselfDelay(float delay)
		{
			Object.Destroy(base.gameObject, delay);
		}

		public void DestroyOther(GameObject other)
		{
			Object.Destroy(other);
		}
	}
}
