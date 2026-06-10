using UnityEngine;

namespace Aura2API
{
	public static class ObjectExtensions
	{
		public static void Destroy(this Object objectToDelete)
		{
			Object.Destroy(objectToDelete);
		}
	}
}
