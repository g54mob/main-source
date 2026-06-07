using UnityEngine;

namespace HighlightPlus.Demos
{
	public class SphereSelectionEventsExample : MonoBehaviour
	{
		public HighlightManager manager;

		private void Start()
		{
		}

		private bool OnObjectSelected(GameObject go)
		{
			return false;
		}

		private bool OnObjectUnSelected(GameObject go)
		{
			return false;
		}
	}
}
