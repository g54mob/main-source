using UnityEngine;

public static class GameObjectExtensions
{
	public static void ToggleActive(this GameObject go)
	{
		go.SetActive(!go.activeSelf);
	}

	public static T GetOrAddComponent<T>(this GameObject go) where T : Component
	{
		T val = go.GetComponent<T>();
		if (!val)
		{
			val = go.AddComponent<T>();
		}
		return val;
	}

	public static T GetOrAddComponent<T>(this MonoBehaviour behaviour) where T : Component
	{
		return behaviour.gameObject.GetOrAddComponent<T>();
	}
}
