using UnityEngine;

namespace UIScripts.InfoHandles
{
	public class SetLayerToTemplate : MonoBehaviour
	{
		public int order = 21;

		private void OnEnable()
		{
			Canvas component = GetComponent<Canvas>();
			component.sortingLayerID = SortingLayer.NameToID("UI");
			component.sortingOrder = order;
		}
	}
}
