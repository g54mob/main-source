using UnityEngine;

namespace DV.Utils
{
	[ExecutionOrder(-10000)]
	public class SingletonInstanceFinder : MonoBehaviour
	{
		private void Awake()
		{
			__SingletonBehaviourBase[] array = Object.FindObjectsOfType<__SingletonBehaviourBase>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CheckInstance();
			}
			Object.Destroy(base.gameObject);
		}
	}
}
