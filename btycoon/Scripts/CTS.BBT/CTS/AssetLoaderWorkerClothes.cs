using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/DLC/Worker Clothes Loader")]
	public class AssetLoaderWorkerClothes : ScriptableLoader
	{
		[SerializeField]
		private CharacterSpecificClothesData[] _clothes;

		public override void Load()
		{
			CharacterSpecificClothesData[] clothes = _clothes;
			for (int i = 0; i < clothes.Length; i++)
			{
				WorkerSpawner.AddClothes(clothes[i]);
			}
		}
	}
}
