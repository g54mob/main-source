using System;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/GuideIconSource", fileName = "GuideIconSource")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class GuideIconSource : ScriptableObject
	{
		[Serializable]
		public class GuideIconItem
		{
			[HideInInspector]
			public string name;

			public GuideIcon icon;

			public Sprite sprite;
		}

		public GuideIconItem[] items;

		private Sprite[] itemsIndexed;

		public void BuildIndex()
		{
		}

		public Sprite GetIcon(GuideIcon icon)
		{
			return null;
		}

		private void OnValidate()
		{
		}
	}
}
