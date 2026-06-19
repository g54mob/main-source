using UnityEngine;

namespace JSAM
{
	public static class JSAMCompatibility
	{
		public static T FindObjectOfType<T>() where T : Behaviour
		{
			return Object.FindFirstObjectByType<T>();
		}
	}
}
