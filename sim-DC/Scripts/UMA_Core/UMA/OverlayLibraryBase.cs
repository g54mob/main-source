using UnityEngine;

namespace UMA
{
	public abstract class OverlayLibraryBase : MonoBehaviour
	{
		public abstract void AddOverlayAsset(OverlayDataAsset overlay);

		public abstract OverlayData InstantiateOverlay(string name);

		public abstract OverlayData InstantiateOverlay(int nameHash);

		public abstract OverlayData InstantiateOverlay(string name, Color color);

		public abstract OverlayData InstantiateOverlay(int nameHash, Color color);

		public abstract bool HasOverlay(string Name);

		public abstract bool HasOverlay(int NameHash);

		public abstract OverlayDataAsset[] GetAllOverlayAssets();

		public abstract void UpdateDictionary();

		public abstract void ValidateDictionary();
	}
}
