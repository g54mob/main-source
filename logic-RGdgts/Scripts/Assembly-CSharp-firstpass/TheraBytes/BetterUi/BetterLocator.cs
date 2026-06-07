using System;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class BetterLocator : MonoBehaviour, IResolutionDependency
	{
		[Serializable]
		public class RectTransformDataConfigCollection : SizeConfigCollection<RectTransformData>
		{
		}

		[SerializeField]
		private RectTransformData transformFallback;

		[SerializeField]
		private RectTransformDataConfigCollection transformConfigs;

		public RectTransformData CurrentTransformData => null;

		private RectTransform rectTransform => null;

		private void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}
	}
}
