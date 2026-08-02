using Rhizomatic;
using Rhizomatic.ImUI;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/GearInlayContainer", fileName = "GearInlayContainer")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class GearInlayContainer : ScriptableObject
	{
		public GearInlayPattern[] patterns;

		public GearInlayItem GetItem(string patternKey, float size)
		{
			return null;
		}

		public void InlayField(ImUIBuilder ui, Part part, string inlay)
		{
		}
	}
}
