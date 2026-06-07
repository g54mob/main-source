using UnityEngine;

namespace PajamaLlama.Flotsam.Landmarks.Generator
{
	public abstract class LandmarkTilesetBase : ScriptableObject
	{
		public abstract LandmarkCellType Type { get; }

		public abstract bool TryReturnPrefab(LandmarkCell cell, out LandmarkTilesetPrefab prefab, out Quaternion rotation);
	}
}
