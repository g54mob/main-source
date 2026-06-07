using UnityEngine;

namespace ModApi.Common.UI
{
	public class OverrideSortingOnStart : MonoBehaviour
	{
		protected virtual void Start()
		{
			Canvas component = GetComponent<Canvas>();
			if (component != null)
			{
				component.overrideSorting = true;
			}
			Object.Destroy(this);
		}
	}
}
