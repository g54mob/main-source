using UnityEngine;

namespace PrefabSwapperSuburb
{
	[AddComponentMenu("PrefabSwapper/SwapPrefabListVisualizerSuburb")]
	public class SwapPrefabListVisualizer : MonoBehaviour
	{
		[Header("Use Rightclick > Refresh to refresh list")]
		public SwapPrefabList.SwapPrefabProperties[] prefabList;

		[ContextMenu("Refresh")]
		public void Refresh()
		{
			prefabList = SwapPrefabList.swapPrefabProperties;
			Debug.Log("PrefabSwapper ::: Refreshing visualization prefab list");
		}
	}
}
