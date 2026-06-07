using System;
using UnityEngine;

[Serializable]
public class CSingleton<T> : MonoBehaviour where T : Component
{
	private static T instance;

	private static object padlock = new object();

	private static bool isQuitting = false;

	public static bool IsQuitting => isQuitting;

	public static T Instance
	{
		get
		{
			lock (padlock)
			{
				if (isQuitting)
				{
					Debug.LogWarning("[Singleton] Cancel creating '" + typeof(T)?.ToString() + "' , application is closing.");
					return null;
				}
				if (instance == null)
				{
					instance = UnityEngine.Object.FindObjectOfType<T>();
					if (UnityEngine.Object.FindObjectsOfType(typeof(T)).Length > 1)
					{
						Debug.LogWarning("[Singleton] More than 1 " + typeof(T)?.ToString() + " in the game");
						return instance;
					}
					if (instance == null)
					{
						GameObject obj = new GameObject
						{
							name = "(singleton)" + typeof(T).ToString()
						};
						instance = obj.AddComponent<T>();
						UnityEngine.Object.DontDestroyOnLoad(obj);
					}
				}
				return instance;
			}
		}
	}

	public virtual void OnApplicationQuit()
	{
		isQuitting = true;
	}
}
