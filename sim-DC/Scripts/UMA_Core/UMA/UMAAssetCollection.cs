using UnityEngine;

namespace UMA
{
	public class UMAAssetCollection : ScriptableObject
	{
		public RaceData[] raceData;

		public SlotDataAsset[] slotData;

		public OverlayDataAsset[] overlayData;

		public virtual void AddToContext(UMAContextBase context)
		{
		}
	}
}
