using System.Linq;
using DV.Utils;
using UnityEngine;

public class TutorialObjectRegistry : SingletonBehaviour<TutorialObjectRegistry>
{
	public GameObject[] objectList;

	public static GameObject Get(string name)
	{
		return SingletonBehaviour<TutorialObjectRegistry>.Instance.objectList.FirstOrDefault((GameObject o) => (bool)o && o.name == name);
	}

	public static T Get<T>(string name) where T : Component
	{
		GameObject gameObject = Get(name);
		if (!gameObject)
		{
			return null;
		}
		return gameObject.GetComponent<T>();
	}
}
