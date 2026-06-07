using UnityEngine;

public class SceneFactory : MonoBehaviour
{
	public static GameObject Instantiate(string path)
	{
		GameObject gameObject = Resources.Load(path) as GameObject;
		if (gameObject != null)
		{
			return Object.Instantiate(gameObject);
		}
		return null;
	}

	public static GameObject InstantiateOrPrimitive(string path)
	{
		return InstantiateOrPrimitive(Resources.Load(path) as GameObject);
	}

	public static GameObject InstantiateOrPrimitive(GameObject prot)
	{
		if (prot == null)
		{
			return GameObject.CreatePrimitive(PrimitiveType.Cube);
		}
		return Object.Instantiate(prot);
	}
}
