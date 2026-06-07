using UnityEngine;

namespace DV.Simulation.Controllers
{
	public abstract class ARefreshableChildrenController<T> : MonoBehaviour where T : MonoBehaviour
	{
		public T[] entries;

		private void OnValidate()
		{
			bool flag = false;
			T[] componentsInChildren = GetComponentsInChildren<T>();
			if (entries == null)
			{
				entries = componentsInChildren;
				flag = true;
			}
			if (entries.Length != componentsInChildren.Length)
			{
				entries = componentsInChildren;
				flag = true;
			}
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (entries[i] == null || !entries[i].Equals(componentsInChildren[i]))
				{
					entries = componentsInChildren;
					flag = true;
				}
			}
			if (flag && Application.isPlaying)
			{
				Debug.LogError("Refresh controller " + base.name + " on " + base.gameObject.name + " and serialize");
			}
		}
	}
}
