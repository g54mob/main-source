using FullInspector;
using UnityEngine;

namespace TH20
{
	public static class SharedInstanceUtils
	{
		public static T[] GetSharedInstances<T>() where T : ScriptableObject
		{
			return Resources.FindObjectsOfTypeAll<T>();
		}

		public static SharedInstance<T> GetSharedInstance<T>(T instance)
		{
			SharedInstance<T>[] sharedInstances = GetSharedInstances<SharedInstance<T>>();
			foreach (SharedInstance<T> sharedInstance in sharedInstances)
			{
				if (sharedInstance != null && sharedInstance.GetInstance == (object)instance)
				{
					return sharedInstance;
				}
			}
			return null;
		}

		public static void MarkAsDirty<T>(T instance)
		{
		}
	}
}
