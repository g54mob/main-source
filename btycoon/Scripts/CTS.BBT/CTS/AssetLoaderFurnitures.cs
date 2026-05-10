using CTS.BBT;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/DLC/Furniture Loader")]
	public class AssetLoaderFurnitures : ScriptableLoader
	{
		[SerializeField]
		private FurnitureSO[] _furnitures;

		public override void Load()
		{
			FurnitureSO[] furnitures = _furnitures;
			for (int i = 0; i < furnitures.Length; i++)
			{
				FurnitureLoader.AddFurniture(furnitures[i]);
			}
		}
	}
}
