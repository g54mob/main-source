using UnityEngine;

namespace Assets.Scripts
{
	public class GlobalDebugScript : MonoBehaviour
	{
		public static GlobalDebugScript Create(GameObject parent)
		{
			GlobalDebugScript globalDebugScript = new GameObject("GlobalDebugScript").AddComponent<GlobalDebugScript>();
			globalDebugScript.transform.SetParent(parent.transform);
			return globalDebugScript;
		}

		protected virtual void Update()
		{
		}
	}
}
