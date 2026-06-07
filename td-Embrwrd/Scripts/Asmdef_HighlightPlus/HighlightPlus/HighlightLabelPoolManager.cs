using System.Collections.Generic;
using UnityEngine;

namespace HighlightPlus
{
	[ExecuteAlways]
	[DefaultExecutionOrder(-100)]
	public class HighlightLabelPoolManager : MonoBehaviour
	{
		private static HighlightLabelPoolManager instance;

		private static readonly Dictionary<GameObject, Queue<HighlightLabel>> labelPools;

		private static readonly HashSet<HighlightLabel> activeLabels;

		private static readonly int initialPoolSize;

		private const string LABEL_INSTANCE_NAME = "Highlight Plus Label";

		private const string LABEL_POOL_NAME = "Highlight Plus Label Pool Manager";

		[RuntimeInitializeOnLoadMethod]
		private static void DomainReloadDisabledSupport()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		public static void DestroySceneLabels()
		{
		}

		private static void ClearPools()
		{
		}

		private static void InitializePool(GameObject prefab)
		{
		}

		private static HighlightLabel CreatePooledLabel(GameObject prefab)
		{
			return null;
		}

		public static HighlightLabel GetLabelInstance(GameObject prefab)
		{
			return null;
		}

		public static void ReturnToPool(HighlightLabel label)
		{
		}

		public static void Refresh()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
