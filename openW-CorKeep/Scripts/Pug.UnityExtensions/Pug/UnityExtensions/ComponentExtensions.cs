using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class ComponentExtensions
	{
		public static void GetRequiredComponent<T>(this MonoBehaviour monoBehaviour, out T component) where T : Component
		{
			component = monoBehaviour.GetComponent<T>();
			if (component == null)
			{
				Debug.LogError("Component " + typeof(T).Name + " not found on " + monoBehaviour.name, monoBehaviour);
			}
		}

		public static void GetRequiredComponent<T>(this GameObject gameObject, out T component) where T : Component
		{
			component = gameObject.GetComponent<T>();
			if (component == null)
			{
				Debug.LogError("Component " + typeof(T).Name + " not found on " + gameObject.name, gameObject);
			}
		}

		public static void GetRequiredComponent<T>(this Component componentIn, out T component) where T : Component
		{
			component = componentIn.GetComponent<T>();
			if (component == null)
			{
				Debug.LogError("Component " + typeof(T).Name + " not found on " + componentIn.name, componentIn);
			}
		}
	}
}
